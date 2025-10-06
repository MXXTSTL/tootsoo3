using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.IO.Ports;
using System.Threading;
using System.Data.SqlClient;
using System.Windows.Forms.DataVisualization.Charting;
using System.Diagnostics;
using System.Net.NetworkInformation;
using SimpleTCP;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using tootsoo3;
using System.Windows.Forms.Integration;
using static System.Net.Mime.MediaTypeNames;
using System.Security.Cryptography;


namespace tootsoo3
{
    public partial class Тооцоо : Form
    {
        private hazailt8 myChart8; // class level дээр зарлана
        private hazailt16 myChart16; // class level дээр зарлана
        private hazailt24 myChart24; // class level дээр зарлана

        #region huwisagch
        int[] cname = new int[100];
        int[] cname1 = new int[100];
        int charttuluv;
        string response_utga, response_tg;
        int bytesRead, bytesRead_tg;
        string[] tonoglol = new string[30];
        string[,] tonoglolu = new string[300, 300];
        string[,] tonoglolu1 = new string[300, 300];
        float[,] tonoglolutga = new float[30, 30];
        string[] tonogloltg = new string[30];
        string[,] tonoglolutg = new string[300, 300];
        string[,] tonoglolu1tg = new string[300, 300];
        float[,] tonoglolutgatg = new float[30, 30];
        int m;
      
     
    
        int ehleh;
      
        int mtg;
        int r1tg, r2tg;
        int ehlehtg;
        int tolowtg;
        float[] avsan = new float[20];
        SqlConnection con, conp;
        float[] tg = new float[20];
        float[,] tg1 = new float[20, 20];
        Point? prevPosition = null;
        ToolTip tooltip = new ToolTip();
        double[, ,] maxmin = new double[30, 30, 30];
        DataTable table_zaaltguraw, table_daalgawar, table_d6;
      
        double[,] dundb = new double[30, 30];
        decimal[] niilber = new decimal[16];
        double tailanniilber;
        double[] tailan1 = new double[150];
     
        bool connected = false, ping85 = false, ping40 = false, ping41 = false, ping236 = false, ping50 = false;
        int maxminhour;
     
        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

    
        SimpleTcpClient client, client1;
       // ReportDataSource rds = new ReportDataSource();
        Ping isping = new Ping();
        PingReply reply85;
        byte[] data, buffer, data_tg, buffer_tg;

        private double daalgawar8, daalgawar16, daalgawar24, daalgawar81, daalgawar161, daalgawar241;
        int tooloh8, tooloh16, tooloh24;



        #endregion
     
        public Тооцоо()
        {
            InitializeComponent();
    
            charttuluv = 0;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            SqlHelper.LoadConnections();

            con = new SqlConnection();
            con.ConnectionString = SqlHelper.connectionlist[0].ConnectionString;

            conp = new SqlConnection();
            conp.ConnectionString = SqlHelper.connectionlist[15].ConnectionString;







            client1 = new SimpleTcpClient();
            client1.StringEncoder = Encoding.UTF8;
            client1.DataReceived += Client1_DataReceived;

            client = new SimpleTcpClient();
            client.StringEncoder = Encoding.UTF8;
            comboBox26.SelectedIndex = 0;

         
         
          
            davtamjReadTimer.Stop();
            davtamjConnectTimer.Stop();
            tootsooTimer.Start();
            dateTimerPickerEnd.Start();
            daalgavarTab(dateTimePicker1.Value);
            int totalWidth = dataGridView16.ClientSize.Width;
            dataGridView16.Columns[0].Width = (int)(totalWidth * 0.2); // 30%
            dataGridView16.Columns[1].Width = (int)(totalWidth * 0.2); // 70%
            dataGridView16.Columns[2].Width = (int)(totalWidth * 0.2); // 30%
            dataGridView16.Columns[3].Width = (int)(totalWidth * 0.2); // 70%
            dataGridView16.Columns[4].Width = (int)(totalWidth * 0.2); // 70%



            myChart8 = new hazailt8();

            ElementHost host8 = new ElementHost
            {
                Child = myChart8,
                Dock = DockStyle.Fill
            };

            panel5.Controls.Add(host8);

            myChart16 = new hazailt16();

            ElementHost host16 = new ElementHost
            {
                Child = myChart16,
                Dock = DockStyle.Fill
            };

            panel9.Controls.Add(host16);


            myChart24 = new hazailt24();

            ElementHost host24 = new ElementHost
            {
                Child = myChart24,
                Dock = DockStyle.Fill
            };

            panel10.Controls.Add(host24);

        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TabControl.SelectedIndex == 0)
            {
                davtamjReadTimer.Stop();
                davtamjConnectTimer.Stop();
                tootsooTimer.Start();
                daalgavarTab(dateTimePicker1.Value);

            }
            if (TabControl.SelectedIndex == 1)  //grafic
            {
                tootsooTimer.Start();
            
                davtamjReadTimer.Start();
                davtamjConnectTimer.Start();
                if (!backgroundWorker1.IsBusy)
                    backgroundWorker1.RunWorkerAsync();

            //    hazailt8.

                graficzurah();
             
           //     grafichazailt8();

            }
            if (TabControl.SelectedIndex == 2)  //dund grafic
            {
               

                davtamjReadTimer.Stop();
                davtamjConnectTimer.Stop();
                tootsooTimer.Stop();

                graficzurah_dund();
                datagrid1();


            }
            if (TabControl.SelectedIndex == 3)  // undur grafic
            {

                datagrid2();
                graficzurah_undur();
                davtamjReadTimer.Stop();
                davtamjConnectTimer.Stop();
                tootsooTimer.Stop();

            }
           
            

        }


        #region daalgavar database
        private void inserttodaalgawar(DateTime tsag, float daalgawar, float daalgawar1)
        {
            try           {
                // Нэмэх параметрүүд
                var parameters = new Dictionary<string, object>
        {
            {"@datetime", tsag},
            {"@daalgawar11", daalgawar},
            {"@daalgawar22", daalgawar1}
        };

                // Оруулах функцийг дахин ашиглахад зориулсан дотоод функц
                void ExecuteInsert(SqlConnection connection, string tableName)
                {
                    string query = $"INSERT INTO {tableName} (tsag, daalgawar, daalgawar1) VALUES (@datetime, @daalgawar11, @daalgawar22)";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        foreach (var param in parameters)
                            cmd.Parameters.AddWithValue(param.Key, param.Value);

                    connectionopen(connection);
                        int rowsAffected = cmd.ExecuteNonQuery();
                    connectionclose(connection);
                        if (rowsAffected == 0)
                        {
                            MessageBox.Show($"Insert into {tableName} failed!");
                        }
                    }
                }

                // Оруулах
                ExecuteInsert(con, "daalgawara");
                ExecuteInsert(con, "daalgawar");
                //                ExecuteInsert(con_Az, "daalgawar");
                  }
                   catch (Exception ex)
                   {
                       MessageBox.Show($"Error inserting data: {ex.Message}");
                       if (con.State == System.Data.ConnectionState.Open) con.Close();
                      // if (con_Az.State == System.Data.ConnectionState.Open) con_Az.Close();
                   }
              
            }



        private void inserttodaalgawar15(DateTime tsag, float daalgawar)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO daalgawara1(tsag, daalgawar) values (@datetime, @daalgawar11)", con);
            cmd.Parameters.AddWithValue("@datetime", tsag);
            cmd.Parameters.AddWithValue("@daalgawar11", daalgawar);
            connectionopen(con);
            if (cmd.ExecuteNonQuery() == 0)
            {
                MessageBox.Show("error");
            }
            connectionclose(con);
            cmd = new SqlCommand("INSERT INTO daalgawar1(tsag, daalgawar) values (@datetime, @daalgawar11)", con);
            cmd.Parameters.AddWithValue("@datetime", tsag);
            cmd.Parameters.AddWithValue("@daalgawar11", daalgawar);

            connectionopen(con);
            if (cmd.ExecuteNonQuery() == 0)
            {
                MessageBox.Show("error");
            }
            connectionclose(con);
        }
        private void updatetodaalgawar(DateTime tsag, float daalgawar, float daalgawar1)
        {
            SqlCommand cmd = new SqlCommand("UPDATE daalgawar SET tsag=@datetime, daalgawar=@daalgawar11, daalgawar1=@daalgawar22", con);
            cmd.Parameters.AddWithValue("@datetime", tsag);
            cmd.Parameters.AddWithValue("@daalgawar11", daalgawar);
            cmd.Parameters.AddWithValue("@daalgawar22", daalgawar1);
            con.Open();
            if (cmd.ExecuteNonQuery() == 0)
            {
                MessageBox.Show("error");
            }
            cmd = new SqlCommand("UPDATE daalgawara SET tsag=@datetime, daalgawar=@daalgawar11, daalgawar1=@daalgawar22", con);
            cmd.Parameters.AddWithValue("@datetime", tsag);
            cmd.Parameters.AddWithValue("@daalgawar11", daalgawar);
            cmd.Parameters.AddWithValue("@daalgawar22", daalgawar1);
            if (cmd.ExecuteNonQuery() == 0)
            {
                MessageBox.Show("error");
            }
            con.Close();

       //     con.Open();
       //     cmd = new SqlCommand("UPDATE daalgawar SET tsag=@datetime, daalgawar=@daalgawar11, daalgawar1=@daalgawar22", con_Az);
       //     cmd.Parameters.AddWithValue("@datetime", tsag);
       //     cmd.Parameters.AddWithValue("@daalgawar11", daalgawar);
       //     cmd.Parameters.AddWithValue("@daalgawar22", daalgawar1);
       //     if (cmd.ExecuteNonQuery() == 0)
       //     {
        //        MessageBox.Show("error");
         //   }
            //con_Az.Close();
        }
        private void deletefromdaalgawar(DateTime tsag, float daalgawar, float daalgawar1)
        {
            SqlCommand cmd = new SqlCommand("DELETE from daalgawar where (tsag=@datetime, daalgawar=@daalgawar11, daalgawar1=@daalgawar22)", con);
            cmd.Parameters.AddWithValue("@datetime", tsag);
            cmd.Parameters.AddWithValue("@daalgawar11", daalgawar);
            cmd.Parameters.AddWithValue("@daalgawar22", daalgawar1);

            con.Open();
            if (cmd.ExecuteNonQuery() == 0)
            {
                MessageBox.Show("error");
            }
            cmd = new SqlCommand("DELETE from daalgawara where (tsag=@datetime, daalgawar=@daalgawar11, daalgawar1=@daalgawar22)", con);
            cmd.Parameters.AddWithValue("@datetime", tsag);
            cmd.Parameters.AddWithValue("@daalgawar11", daalgawar);
            cmd.Parameters.AddWithValue("@daalgawar22", daalgawar1);

            if (cmd.ExecuteNonQuery() == 0)
            {
                MessageBox.Show("error");
            }
            con.Close();
        }
        #endregion
        private void tootsooTimer_Tick(object sender, EventArgs e)
        {
            try
            {
              
                tootsooTimer.Interval = 5000;
                
                bolovsruulaltBodoh(dateTimePicker1.Value);

                SqlDataAdapter daparameter = new SqlDataAdapter("select *from Parameters where id = 9  ", conp);

                DataSet dsparameter = new DataSet();
                daparameter.Fill(dsparameter, "undur");

                SqlDataAdapter daundur = new SqlDataAdapter("select TOP 1 *from undur1 order by id desc  ", con);

                DataSet dsundur = new DataSet();
                daundur.Fill(dsundur, "undur");

                label393.Text = "" + Math.Round(Convert.ToDouble(dsparameter.Tables[0].Rows[0][4]), 2).ToString() + " МВт";
                label49.Text = "" + Math.Round(Convert.ToDouble(dsundur.Tables[0].Rows[0][12]), 2).ToString() + " МВт";
                label52.Text = "" + Math.Round(Convert.ToDouble(dsundur.Tables[0].Rows[0][11]), 2).ToString() + " МВт";



                daalgawar8 = 0;
                daalgawar16 = 0;
                daalgawar24 = 0;
                daalgawar81 = 0;
                daalgawar161 = 0;
                daalgawar241 = 0;


                DateTime todayStart = DateTime.Today; // 00:00
                DateTime current = DateTime.Now; // 08:00

                // MessageBox.Show(todayStart.ToString());
                //  MessageBox.Show(current.ToString());



                SqlDataAdapter dadaalgawar = new SqlDataAdapter(@"
                    SELECT * FROM daalgawara1 
                    WHERE tsag >= @todayStart AND tsag <= @currentTime 
                    ORDER BY id ASC", con);

                dadaalgawar.SelectCommand.Parameters.AddWithValue("@todayStart", todayStart);
                dadaalgawar.SelectCommand.Parameters.AddWithValue("@currentTime", current);

                DataSet dsdaalgawar = new DataSet();
                dadaalgawar.Fill(dsdaalgawar, "daalgawara1");



                SqlDataAdapter dadaalgawar1 = new SqlDataAdapter(@"
                    SELECT * FROM daalgawara1 
                    WHERE tsag >= @todayStart  
                    ORDER BY id ASC", con);

                dadaalgawar1.SelectCommand.Parameters.AddWithValue("@todayStart", todayStart);

                DataSet dsdaalgawar1 = new DataSet();
                dadaalgawar1.Fill(dsdaalgawar1, "daalgawara1");
                




                SqlDataAdapter daHazailt = new SqlDataAdapter("select *from zaaltguraw1 where (select DATEPART(dd, tsag))=@udur and (select DATEPART(mm, tsag))=@sar  and (select DATEPART(yy, tsag))=@jil  ORDER BY id ASC", con);
                daHazailt.SelectCommand.Parameters.AddWithValue("@udur", DateTime.Now.Day);
                daHazailt.SelectCommand.Parameters.AddWithValue("@sar", DateTime.Now.Month);
                daHazailt.SelectCommand.Parameters.AddWithValue("@jil", DateTime.Now.Year);
                DataSet dsHazailt = new DataSet();
                daHazailt.Fill(dsHazailt, "zaaltguraw");

                DateTime clock8 = DateTime.ParseExact("08:01", "HH:mm", CultureInfo.InvariantCulture);
                DateTime clock16 = DateTime.ParseExact("16:01", "HH:mm", CultureInfo.InvariantCulture);

                tooloh16 = 0;
                DateTime? baseTime8 = null;
                DateTime? baseTime16 = null;
                DateTime? baseTime24 = null;

                DataRow baseRow8 = null;
                DataRow baseRow16 = null;
                DataRow baseRow24 = null;

                double bolowsruulalt8 = 0;
                double bolowsruulalt16 = 0;
                double bolowsruulalt24 = 0;
                DateTime? testtsag = null;
                for (int i = 0; i < dsHazailt.Tables[0].Rows.Count; ++i)
                {
                    var value = dsHazailt.Tables[0].Rows[i][1];
                    if (value != DBNull.Value && DateTime.TryParse(value.ToString(), out DateTime date))
                    {
                        var row = dsHazailt.Tables[0].Rows[i];

                        // 0–8 цаг
                        if (date <= clock8 && date.Hour >= 0 && baseRow8 == null && date.Minute % 15 == 0)
                        {
                            baseTime8 = date;
                            baseRow8 = row;
                        }

                        if (date <= clock8 && baseRow8 != null && date.Minute % 15 == 0)
                        {
                            bolowsruulalt8 = Calculate(row, baseRow8);
                        }

                        // 8–16 цаг
                        if (date <= clock16 && date.Hour >= 8 && baseRow16 == null && date.Minute % 15 == 0)
                        {
                            baseTime16 = date;
                            baseRow16 = row;
                            testtsag = date;
                        }

                      //  MessageBox.Show(baseRow16.ToString());
                        if (date <= clock16 && date.Hour >= 8 && baseRow16 != null && date.Minute % 15 == 0)
                        {
                            bolowsruulalt16 = Calculate(row, baseRow16);
                         //   testtsag = date;
                        }

                        // 16–24 цаг

                        if (date.Hour >= 16 && date.Hour < 24 && baseRow24 == null && date.Minute % 15 == 0)
                        {
                            baseTime24 = date;
                            baseRow24 = row;
                        }

                        if (date.Hour >= 16 && date.Hour < 24 && baseRow24 != null && date.Minute % 15 == 0)
                        {
                            bolowsruulalt24 = Calculate(row, baseRow24);
                        }
                    }
                }

                //  MessageBox.Show(testtsag.ToString());

                for (int i = 0; i < dsdaalgawar.Tables[0].Rows.Count; i++)
                {
                    var tsagValue = dsdaalgawar.Tables[0].Rows[i][1];
                    var utgaValue = dsdaalgawar.Tables[0].Rows[i][2];

                    if (tsagValue != DBNull.Value && utgaValue != DBNull.Value &&
                        DateTime.TryParse(tsagValue.ToString(), out DateTime date))
                    {
                        if (date > DateTime.Now)
                            continue; // эсвэл break, хамаарна

                        double utga = Convert.ToDouble(utgaValue);

                        if (date.Hour >= 0 && date.Hour < 8)
                            daalgawar8 += utga;
                        else if (date.Hour >= 8 && date.Hour < 16)
                            daalgawar16 += utga;
                        else if (date.Hour >= 16 && date.Hour < 24)
                            daalgawar24 += utga;

                    }
                }
             

                for (int i = 0; i < dsdaalgawar1.Tables[0].Rows.Count; i++)
                {
                    var tsagValue = dsdaalgawar1.Tables[0].Rows[i][1];
                    var utgaValue = dsdaalgawar1.Tables[0].Rows[i][2];

                    if (tsagValue != DBNull.Value && utgaValue != DBNull.Value &&
                        DateTime.TryParse(tsagValue.ToString(), out DateTime date))
                    {


                        double utga = Convert.ToDouble(utgaValue);

                        if (date.Hour >= 0 && date.Hour < 8)
                            daalgawar81 += utga;
                        else if (date.Hour >= 8 && date.Hour < 16)
                            daalgawar161 += utga;
                        else if (date.Hour >= 16 && date.Hour < 24)
                            daalgawar241 += utga;

                    }
                }

             //   MessageBox.Show(daalgawar81.ToString());

                float[] ha8 = new float[8];
                ha8[0] = Convert.ToSingle(daalgawar81);
                ha8[1] = Convert.ToSingle(bolowsruulalt8);
                ha8[2] = Convert.ToSingle(bolowsruulalt8 - daalgawar8);

           

                myChart8.a1 = ha8[0];
                myChart8.a2 = ha8[1];
                myChart8.a3 = ha8[2];


                ha8[0] = Convert.ToSingle(daalgawar161);
                ha8[1] = Convert.ToSingle(bolowsruulalt16);
                ha8[2] = Convert.ToSingle(bolowsruulalt16 - daalgawar16);

                myChart16.a1 = ha8[0];
                myChart16.a2 = ha8[1];
                myChart16.a3 = ha8[2];

                ha8[0] = Convert.ToSingle(daalgawar241);
                ha8[1] = Convert.ToSingle(bolowsruulalt24);
                ha8[2] = Convert.ToSingle(bolowsruulalt24 - daalgawar24);

                myChart24.a1 = ha8[0];
                myChart24.a2 = ha8[1];
                myChart24.a3 = ha8[2];

            }
            catch { }
        }



        #region button  

        private void button1_Click_1(object sender, EventArgs e)
        {
            // 1. Даалгаврын үндсэн дата авах
            DataTable tableDaalgawar = new DataTable();
            using (SqlDataAdapter da3 = new SqlDataAdapter("SELECT CONVERT(VARCHAR(8), tsag, 108) AS Цаг, daalgawar, daalgawar1 FROM daalgawara WHERE DATEPART(dd, tsag) = @d AND DATEPART(mm, tsag) = @m AND DATEPART(yy, tsag) = @y ORDER BY id ASC", con))
            {
                da3.SelectCommand.Parameters.AddWithValue("@d", DateTime.Now.Day);
                da3.SelectCommand.Parameters.AddWithValue("@m", DateTime.Now.Month);
                da3.SelectCommand.Parameters.AddWithValue("@y", DateTime.Now.Year);
                da3.Fill(tableDaalgawar);
            }

            // 2. Нөгөө даалгаврын дата
            DataTable tableDaalgawar1 = new DataTable();
            using (SqlDataAdapter da11 = new SqlDataAdapter("SELECT CONVERT(VARCHAR(8), tsag, 108) AS Цаг, daalgawar FROM daalgawara1 WHERE DATEPART(dd, tsag) = @d AND DATEPART(mm, tsag) = @m AND DATEPART(yy, tsag) = @y ORDER BY id ASC", con))
            {
                da11.SelectCommand.Parameters.AddWithValue("@d", DateTime.Now.Day);
                da11.SelectCommand.Parameters.AddWithValue("@m", DateTime.Now.Month);
                da11.SelectCommand.Parameters.AddWithValue("@y", DateTime.Now.Year);
                da11.Fill(tableDaalgawar1);
            }

            // dataGridView18.DataSource = tableDaalgawar1; // Хэрэв хүсэж байвал харагдуулахад

            // 3. Хугацаа хөрвүүлэлт
            DateTime clock = DateTime.ParseExact(textBox13.Text, "HH:mm:ss", CultureInfo.InvariantCulture);
            DateTime clock1 = DateTime.ParseExact(textBox14.Text, "HH:mm:ss", CultureInfo.InvariantCulture);

            // 4. tableDaalgawar дотор ижил цаг байгаа эсэх
            bool b = tableDaalgawar.AsEnumerable().Any(row => DateTime.ParseExact(row["Цаг"].ToString(), "HH:mm:ss", CultureInfo.InvariantCulture).Hour == clock.Hour);

            // 5. Хэрвээ байхгүй бол 1 минут тутам нэмэх
            if (!b)
            {
                while (clock <= clock1)
                {
                    avsan[19] = float.Parse(textBox15.Text);
                    avsan[18] = avsan[19] / 60;
                    inserttodaalgawar(clock, avsan[19], avsan[18]);
                    clock = clock.AddMinutes(1);
                }
            }

            // 6. 15 минут тутмын давхардлыг шалгах
            bool c = tableDaalgawar1.AsEnumerable().Any(row => DateTime.ParseExact(row["Цаг"].ToString(), "HH:mm:ss", CultureInfo.InvariantCulture).Hour == clock.Hour);

            clock = DateTime.ParseExact(textBox13.Text, "HH:mm:ss", CultureInfo.InvariantCulture);
            DateTime clock4 = DateTime.ParseExact("23:45:00", "HH:mm:ss", CultureInfo.InvariantCulture);

            // 7. Даалгавар1 дотор байхгүй бол 15 минут тутамд нэмэх
            if (!c)
            {
                while (clock < clock1)
                {
                    clock = clock.AddMinutes(15);
                    avsan[19] = float.Parse(textBox15.Text);
                    avsan[18] = avsan[19] / 4;

                    if (clock.Minute == clock4.Minute)
                    {
                        inserttodaalgawar15(clock, avsan[18]);
                        clock = clock.AddMinutes(14);
                        inserttodaalgawar15(clock, avsan[18]);
                    }
                    else
                    {
                        inserttodaalgawar15(clock, avsan[18]);
                    }
                }
            }

            daalgavarTab(dateTimePicker1.Value);
            MessageBox.Show("Даалгавар нэмэгдлээ");


        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            // 1. Даалгавар ачааллах
            DataTable tableDaalgawar = new DataTable();
            using (SqlDataAdapter da3 = new SqlDataAdapter(@"
    SELECT 
        CONVERT(VARCHAR(8), tsag, 108) AS Цаг,
        daalgawar AS Даалгавар,
        daalgawar1 AS Даалгавар1
    FROM daalgawara
    WHERE 
        DATEPART(dd, tsag) = @d AND
        DATEPART(mm, tsag) = @m AND
        DATEPART(yy, tsag) = @y
    ORDER BY id ASC", con))
            {
                da3.SelectCommand.Parameters.AddWithValue("@d", DateTime.Now.Day);
                da3.SelectCommand.Parameters.AddWithValue("@m", DateTime.Now.Month);
                da3.SelectCommand.Parameters.AddWithValue("@y", DateTime.Now.Year);
                da3.Fill(tableDaalgawar);
            }
            dataGridView5.DataSource = tableDaalgawar;

            // 2. Хугацааны муж тодорхойлох
            DateTime startTime = DateTime.ParseExact(textBox13.Text, "HH:mm:ss", CultureInfo.InvariantCulture);
            DateTime endTime = DateTime.ParseExact(textBox14.Text, "HH:mm:ss", CultureInfo.InvariantCulture);

            // 3. Устгах командууд
            void DeleteBetween(SqlConnection connection, string tableName)
            {
                using (SqlCommand cmd = new SqlCommand($"DELETE FROM {tableName} WHERE tsag BETWEEN @start AND @end", connection))
                {
                    cmd.Parameters.AddWithValue("@start", startTime);
                    cmd.Parameters.AddWithValue("@end", endTime);
                    cmd.ExecuteNonQuery();
                }
            }

            void DeleteBefore(SqlConnection connection, string tableName, int days)
            {
                using (SqlCommand cmd = new SqlCommand($"DELETE FROM {tableName} WHERE tsag < @limit", connection))
                {
                    cmd.Parameters.AddWithValue("@limit", DateTime.Today.AddDays(-days));
                    cmd.ExecuteNonQuery();
                }
            }

            // 4. Устгах - үндсэн
            connectionopen(con);
            DeleteBetween(con, "daalgawar");
            DeleteBetween(con, "daalgawara");
            DeleteBetween(con, "daalgawar1");
            DeleteBetween(con, "daalgawara1");
            DeleteBefore(con, "daalgawar1", 3);
            DeleteBefore(con, "daalgawara1", 3);
            DeleteBefore(con, "undur1", 3);
            DeleteBefore(con, "dund1", 3);
            connectionclose(con);

            // 5. Устгах - өөр дата сангаас
   //         con_Az.Open();
   //         DeleteBetween(con_Az, "daalgawar");
   //         con_Az.Close();

            // 6. Дахин ачааллах
            DataTable tableDaalgawar1 = new DataTable();
            using (SqlDataAdapter da11 = new SqlDataAdapter(@"
    SELECT 
        CONVERT(VARCHAR(8), tsag, 108) AS Цаг,
        daalgawar
    FROM daalgawara1
    WHERE 
        DATEPART(dd, tsag) = @d AND
        DATEPART(mm, tsag) = @m AND
        DATEPART(yy, tsag) = @y
    ORDER BY id ASC", con))
            {
                da11.SelectCommand.Parameters.AddWithValue("@d", DateTime.Now.Day);
                da11.SelectCommand.Parameters.AddWithValue("@m", DateTime.Now.Month);
                da11.SelectCommand.Parameters.AddWithValue("@y", DateTime.Now.Year);
                da11.Fill(tableDaalgawar1);
            }

            // 7. Дуусгах
            daalgavarTab(dateTimePicker1.Value);
            MessageBox.Show("Даалгавар устгагдлаа");



        }


        
        private void button2_Click(object sender, EventArgs e)
        {
            string strDate = textBox1.Text;
            DateTime clock = DateTime.ParseExact(strDate, "HH:mm:ss", CultureInfo.InvariantCulture);
            string strDate1 = textBox2.Text;
            DateTime clock1 = DateTime.ParseExact(strDate1, "HH:mm:ss", CultureInfo.InvariantCulture);

            // ----- Даалгавар дата авах -----
            SqlDataAdapter da3 = new SqlDataAdapter(@"
    SELECT 
        CONVERT(VARCHAR(8), tsag, 108) AS Цаг,
        ROUND(daalgawar, 3) AS Даалгавар,
        ROUND(daalgawar1, 3) AS Даалгавар1
    FROM daalgawar
    WHERE 
        DAY(tsag) = @day AND 
        MONTH(tsag) = @month AND 
        YEAR(tsag) = @year
    ORDER BY id ASC", con);

            da3.SelectCommand.Parameters.AddWithValue("@day", DateTime.Now.Day);
            da3.SelectCommand.Parameters.AddWithValue("@month", DateTime.Now.Month);
            da3.SelectCommand.Parameters.AddWithValue("@year", DateTime.Now.Year);

            DataSet ds3 = new DataSet();
            da3.Fill(ds3, "daalgawar");
            DataTable daalgawarTable18 = ds3.Tables[0]; // ✅ DataGridView ашиглалгүйгээр

            // ----- Цагийн интервалд таарах мөрүүдийг шүүж нийт дүн тооцох -----
            double shi = 0;

            foreach (DataRow row in daalgawarTable18.Rows)
            {
                DateTime tsag = DateTime.ParseExact(row["Цаг"].ToString(), "HH:mm:ss", CultureInfo.InvariantCulture);
                if (tsag <= clock1 && tsag > clock)
                {
                    shi += Convert.ToDouble(row["Даалгавар1"]);
                }
            }

            textBox3.Text = Math.Round(shi, 0).ToString();
            shi = 0;

        }
        private void button20_Click(object sender, EventArgs e)
        {
            client.Connect("192.168.3.245", Convert.ToInt32("5040"));
            client.WriteLineAndGetReply("#" + comboBox26.SelectedItem.ToString() + "#*" + textBox16.Text + "*", TimeSpan.FromSeconds(0));
            MessageBox.Show("Амжилттай");
        }

        #endregion

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                bolovsruulaltBodoh(dateTimePicker1.Value);
            }
            catch { }
        }
         private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                tootsooTimer.Stop();
                //        MessageBox.Show("timer2 stop");
            }
            if (!checkBox1.Checked)
            {
                tootsooTimer.Start();
                //      MessageBox.Show("timer2 start");
            }
        }
         private void dateTimerPickerEnd_Tick(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
        }
         private void comboBox26_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox26.SelectedIndex == 0)
            {
                if (dataGridView13.Rows.Count > 0)
                    textBox16.Text = dataGridView13.Rows[0].Cells[1].Value.ToString();
            }
            //     if(comboBox26.SelectedIndex == 0)
            //      textBox16.Text = dataGridView13.Rows[0].Cells[1].Value.ToString();
            if (comboBox26.SelectedIndex == 1)
                textBox16.Text = dataGridView13.Rows[0].Cells[2].Value.ToString();
            if (comboBox26.SelectedIndex == 2)
                textBox16.Text = dataGridView13.Rows[0].Cells[3].Value.ToString();
            if (comboBox26.SelectedIndex == 3)
                textBox16.Text = dataGridView13.Rows[0].Cells[4].Value.ToString();
            if (comboBox26.SelectedIndex == 4)
                textBox16.Text = dataGridView13.Rows[0].Cells[5].Value.ToString();
            if (comboBox26.SelectedIndex == 5)
                textBox16.Text = dataGridView13.Rows[0].Cells[6].Value.ToString();
            if (comboBox26.SelectedIndex == 6)
                textBox16.Text = dataGridView13.Rows[0].Cells[7].Value.ToString();
            if (comboBox26.SelectedIndex == 7)
                textBox16.Text = dataGridView13.Rows[0].Cells[8].Value.ToString();
            if (comboBox26.SelectedIndex == 8)
                textBox16.Text = dataGridView13.Rows[0].Cells[9].Value.ToString();

        }


        private void Тооцоо_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.Width > 1300)
                {
                    int totalWidth = dataGridView16.ClientSize.Width;
                    dataGridView16.Columns[0].Width = (int)(totalWidth * 0.2); // 30%
                    dataGridView16.Columns[1].Width = (int)(totalWidth * 0.2); // 70%
                    dataGridView16.Columns[2].Width = (int)(totalWidth * 0.2); // 30%
                    dataGridView16.Columns[3].Width = (int)(totalWidth * 0.2); // 70%
                    dataGridView16.Columns[4].Width = (int)(totalWidth * 0.2); // 70%
                }
            }
            catch { }

        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                try
                {



                    int index = (int)TabControl.Invoke((Func<int>)(() => TabControl.SelectedIndex));

                    if (index == 1)
                    {
                        reply85 = isping.Send("192.168.3.245");
                        ping85 = reply85.Status == IPStatus.Success;
                        if (ping85 == true)
                        {
                            ehleh = 0;
                            ehlehtg = 0;
                            string t1 = "#$";
                            string t2 = "'*:";
                        //    string ut;


                            #region TG
                            TcpClient client_tg = new TcpClient();
                            client_tg.Connect(IPAddress.Parse("192.168.3.245"), 10858);
                            data_tg = Encoding.UTF8.GetBytes("fas");

                            NetworkStream stream_tg = client_tg.GetStream();
                            stream_tg.Write(data_tg, 0, data_tg.Length);
                            buffer_tg = new byte[client_tg.ReceiveBufferSize];
                            bytesRead_tg = stream_tg.Read(buffer_tg, 0, client_tg.ReceiveBufferSize);
                            response_tg = Encoding.UTF8.GetString(buffer_tg, 0, bytesRead_tg);

                            #region  horwuuleh  TG
                            for (int i = 0; i < response_tg.Length; i++)
                            {
                                if (response_tg[i] == t1[0])
                                {
                                    tolowtg = 1;
                                    r1tg = i;

                                }
                                if (tolowtg == 1)
                                {
                                    if (response_tg[i] == t1[1])
                                    {
                                        r2tg = i;
                                        tolowtg = 0;

                                        tonogloltg[ehlehtg] = response_tg.Substring(r1tg, r2tg - r1tg);
                                        ehlehtg++;
                                    }
                                }

                            }


                            for (int i1 = 0; i1 < ehlehtg; i1++)
                            {
                                mtg = 0;
                                for (int i = 0; i < tonogloltg[i1].Length; i++)
                                {
                                    if (tonogloltg[i1][i] == t2[0])
                                    {
                                        tolowtg = 1;
                                        r1tg = i;

                                    }
                                    if (tolowtg == 1)
                                    {
                                        if (tonogloltg[i1][i] == t2[1])
                                        {
                                            r2tg = i;
                                            tolowtg = 0;

                                            tonoglolutg[i1, mtg] = tonogloltg[i1].Substring(r1tg, r2tg - r1tg);
                                            mtg++;
                                        }
                                    }

                                }
                            }

                            for (int i = 0; i < ehlehtg; i++)
                            {
                                for (int j = 0; j < 6; j++)
                                {
                                    for (int i1 = 0; i1 < tonoglolutg[i, j].Length; i1++)
                                    {
                                        if (tonoglolutg[i, j][i1] == t2[0])
                                        {
                                            i1++;
                                            tonoglolu1tg[i, j] = tonoglolutg[i, j].Substring(i1, tonoglolutg[i, j].Length - i1);
                                            //tonoglolutga[i, j] = Convert.ToUInt16(tonoglolu[i, j].Substring(i1, 2));
                                        }

                                        if (tonoglolutg[i, j][i1] == t2[2])
                                        {
                                            i1++;
                                            tonoglolu1tg[i, j] = tonoglolutg[i, j].Substring(i1, tonoglolutg[i, j].Length - i1);
                                            tonoglolutgatg[i, j] = float.Parse(tonoglolu1tg[i, j]);
                                        }

                                    }
                                }
                            }

                            #endregion
                            #region tg

                            if (label385.InvokeRequired)
                            {
                                label385.Invoke(new Action(() => label385.Text = Math.Round(tonoglolutgatg[0, 3], 2).ToString() + " МВт"));
                            }
                            if (label386.InvokeRequired)
                            {
                                label386.Invoke(new Action(() => label386.Text = Math.Round(tonoglolutgatg[1, 3], 2).ToString() + " МВт"));
                            }
                            if (label387.InvokeRequired)
                            {
                                label387.Invoke(new Action(() => label387.Text = Math.Round(tonoglolutgatg[2, 3], 2).ToString() + " МВт"));
                            }
                            if (label388.InvokeRequired)
                            {
                                label388.Invoke(new Action(() => label388.Text = Math.Round(tonoglolutgatg[3, 3], 2).ToString() + " МВт"));
                            }
                            if (label389.InvokeRequired)
                            {
                                label389.Invoke(new Action(() => label389.Text = Math.Round(tonoglolutgatg[4, 3], 2).ToString() + " МВт"));
                            }
                            if (label390.InvokeRequired)
                            {
                                label390.Invoke(new Action(() => label390.Text = Math.Round(tonoglolutgatg[5, 3], 2).ToString() + " МВт"));
                            }
                            if (label391.InvokeRequired)
                            {
                                label391.Invoke(new Action(() => label391.Text = Math.Round(tonoglolutgatg[6, 3], 2).ToString() + " МВт"));
                            }
                            if (label392.InvokeRequired)
                            {
                                label392.Invoke(new Action(() => label392.Text = Math.Round(tonoglolutgatg[7, 3], 2).ToString() + " МВт"));
                            }

                            if (label2.InvokeRequired)
                            {
                                double dundniilber = Math.Round(tonoglolutgatg[0, 3], 2) + Math.Round(tonoglolutgatg[1, 3], 2) + Math.Round(tonoglolutgatg[2, 3], 2) + Math.Round(tonoglolutgatg[3, 3], 2);
                                string dundstring = dundniilber.ToString() + "";
                                label2.Invoke(new Action(() => label2.Text = dundstring + " МВт"));
                            }
                            if (label13.InvokeRequired)
                            {
                                double undurniilber;
                                if (label393.Text.Length > 0)
                                {

                                    string newStr = label393.Text.Replace(" ", "");
                                    newStr = newStr.Replace("М", "");
                                    newStr = newStr.Replace("В", "");
                                    newStr = newStr.Replace("т", "");
                                    double tg9b = Math.Round(Convert.ToDouble(newStr), 2);
                                    undurniilber = tg9b + Math.Round(tonoglolutgatg[4, 3], 2) + Math.Round(tonoglolutgatg[5, 3], 2) + Math.Round(tonoglolutgatg[6, 3], 2) + Math.Round(tonoglolutgatg[7, 3], 2);
                                }
                                else
                                    undurniilber = Math.Round(tonoglolutgatg[4, 3], 2) + Math.Round(tonoglolutgatg[5, 3], 2) + Math.Round(tonoglolutgatg[6, 3], 2) + Math.Round(tonoglolutgatg[7, 3], 2);
                                string undurstring = undurniilber.ToString() + "";
                                label13.Invoke(new Action(() => label13.Text = undurstring + " MBт"));

                                // label13.Invoke(new Action(() => label13.Text = (Math.Round(tonoglolutgatg[4, 3], 2) + Math.Round(tonoglolutgatg[5, 3], 2) + Math.Round(tonoglolutgatg[6, 3], 2) + Math.Round(tonoglolutgatg[7, 3], 2)).ToString() + " МВт"));
                            }

                            if (label384.InvokeRequired)
                            {
                                double undurniilber;
                                if (label393.Text.Length > 0)
                                {

                                    string newStr = label393.Text.Replace(" ", "");
                                    newStr = newStr.Replace("М", "");
                                    newStr = newStr.Replace("В", "");
                                    newStr = newStr.Replace("т", "");
                                    double tg9b = Math.Round(Convert.ToDouble(newStr), 2);
                                    undurniilber = tg9b + Math.Round(tonoglolutgatg[4, 3], 2) + Math.Round(tonoglolutgatg[5, 3], 2) + Math.Round(tonoglolutgatg[6, 3], 2) + Math.Round(tonoglolutgatg[7, 3], 2);
                                }
                                else
                                    undurniilber = Math.Round(tonoglolutgatg[4, 3], 2) + Math.Round(tonoglolutgatg[5, 3], 2) + Math.Round(tonoglolutgatg[6, 3], 2) + Math.Round(tonoglolutgatg[7, 3], 2);

                                double dundniilber = Math.Round(tonoglolutgatg[0, 3], 2) + Math.Round(tonoglolutgatg[1, 3], 2) + Math.Round(tonoglolutgatg[2, 3], 2) + Math.Round(tonoglolutgatg[3, 3], 2);

                                string niitbolows = (undurniilber + dundniilber).ToString();
                                label384.Invoke(new Action(() => label384.Text = niitbolows + " МВт"));
                            }


                       

                            #endregion

                            #endregion

                            Thread.Sleep(700);

                        }
                    }
                    else
                    {
                        break;
                    }
                }

                catch { }

            }

        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (TabControl.SelectedIndex == 1)
                backgroundWorker1.RunWorkerAsync();

        }
        private void timerIPcheck_Tick(object sender, EventArgs e)
        {

            checkBox1.Checked = false;
             
            try 
            { 
            Ping pingSender = new Ping();
            bool pinging = false;

            SqlDataAdapter da = new SqlDataAdapter("select *from tongololip order by id", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "IP");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {

                if (Convert.ToInt16(ds.Tables[0].Rows[i][5]) == 1)
                {
                    string ipAddress = ds.Tables[0].Rows[i][1].ToString().Trim();
                    PingReply reply = pingSender.Send(ipAddress);
                    pinging = reply.Status == IPStatus.Success;
                    if (pinging == false) // 
                    {
                       // MessageBox.Show(ipAddress + " " + ds.Tables[0].Rows[i][2].ToString() + " холбогдохгүй байна.");
                    }
                }
            }
            }
            catch { }

        }



        private void datagrid1()
        {
            try
            {

                SqlDataAdapter daundur = new SqlDataAdapter(
                    "SELECT  CONVERT(varchar(8), tsag, 108) AS 'Цаг', tg1 AS 'ТГ-1',tg2 AS 'ТГ-2',  tg3 AS 'ТГ-3',tg4 AS 'ТГ-4' FROM dund1 WHERE CAST(tsag AS DATE) = CAST(GETDATE() AS DATE) order by id desc", con);
                DataSet dsundur = new DataSet();
                daundur.Fill(dsundur, "undur");
                dataGridView1.DataSource = dsundur.Tables[0];
            }
            catch { }
        }
        private void datagrid2()
        {
            try
            {
                SqlDataAdapter daundur = new SqlDataAdapter(
                    "SELECT  CONVERT(varchar(8), tsag, 108) AS 'Цаг', ROUND(tg5, 2) AS 'ТГ-5',ROUND(tg6, 2) AS 'ТГ-6',  ROUND(tg7, 2) AS 'ТГ-7',ROUND(tg8, 2) AS 'ТГ-8',ROUND(tg9, 2) AS 'ТГ-9' FROM undur1 WHERE CAST(tsag AS DATE) = CAST(GETDATE() AS DATE) order by id desc", con);
                DataSet dsundur = new DataSet();
                daundur.Fill(dsundur, "undur");
                dataGridView2.DataSource = dsundur.Tables[0];
            }
            catch { }
        }


        #region livechart

        public void grafichazailt8(float[] hutga8)
        {


            hazailt8 myChart = new hazailt8();
            Random rand = new Random();
            hutga8[0] = rand.Next(10); // 0-аас 9 хүртэлх санамсаргүй тоо
       //     MessageBox.Show(hutga8[0].ToString());
            myChart.a1 = hutga8[0];
            myChart.a2 = hutga8[1];
            myChart.a3 = hutga8[2];

            ElementHost host = new ElementHost
            {
                Child = myChart,
                Dock = DockStyle.Fill, 
                                       
            };

            panel5.Controls.Add(host); // panel1 дотор байрлуулах

        }
        public void grafichazailt16(float[] hutga8)
        {


            hazailt16 myChart = new hazailt16();

            myChart.a1 = hutga8[0];
            myChart.a2 = hutga8[1];
            myChart.a3 = hutga8[2];

            ElementHost host = new ElementHost
            {
                Child = myChart,
                Dock = DockStyle.Fill, // эсвэл Size/Location өгч болно
                                       //   Location = new System.Drawing.Point(250, 300),
                                       // Size = new System.Drawing.Size(400, 300)
            };
            panel9.Controls.Add(host); // panel1 дотор байрлуулах
        }
        public void grafichazailt24(float[] hutga8)
        {


            hazailt24 myChart = new hazailt24();


            myChart.a1 = hutga8[0];
            myChart.a2 = hutga8[1];
            myChart.a3 = hutga8[2];

            ElementHost host = new ElementHost
            {
                Child = myChart,
                Dock = DockStyle.Fill, // эсвэл Size/Location өгч болно
 
            };
            panel10.Controls.Add(host); // panel1 дотор байрлуулах

        }
        public void graficzurah()
        {

            chart1 myChart = new chart1();
            ElementHost host = new ElementHost
            {
                Child = myChart,
                Dock = DockStyle.Fill, // эсвэл Size/Location өгч болно
   
            };

            panel2.Controls.Add(host); // panel1 дотор байрлуулах

        }
        public void graficzurah_dund()
        {

            chart2 myChart = new chart2();
            ElementHost host = new ElementHost
            {
                Child = myChart,
                Dock = DockStyle.Fill, // эсвэл Size/Location өгч болно
                                       //   Location = new System.Drawing.Point(250, 300),
                                       // Size = new System.Drawing.Size(400, 300)
            };

            panel3.Controls.Add(host); // panel1 дотор байрлуулах

        }
        public void graficzurah_undur()
        {

            chart3 myChart = new chart3();
            ElementHost host = new ElementHost
            {
                Child = myChart,
                Dock = DockStyle.Fill, // эсвэл Size/Location өгч болно
                                       //   Location = new System.Drawing.Point(250, 300),
                                       // Size = new System.Drawing.Size(400, 300)
            };

            panel4.Controls.Add(host); // panel1 дотор байрлуулах

        }
        #endregion

        #region dawtamj
        private void davtamjReadTimer_Tick(object sender, EventArgs e)
        {
            if (connected)
            {
                try
                {
                    client1.WriteLineAndGetReply("65", TimeSpan.FromSeconds(0));
                }
                catch
                {
                    connected = false;
                }
            }
            else
            {
                davtamjReadTimer.Stop();
                davtamjConnectTimer.Start();
            }
        }
        private void davtamjConnectTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                client1.Connect("192.168.3.245", Convert.ToInt32("8236"));
                connected = true;
                davtamjConnectTimer.Stop();
                davtamjReadTimer.Start();
            }
            catch { }
        }
        private void Client1_DataReceived(object sender, SimpleTCP.Message e)
        {
            try
            {
                label379.Invoke((MethodInvoker)delegate ()
                {
                    double u = Math.Round(Convert.ToDouble(e.MessageString.Substring(0, e.MessageString.Length - 2)), 2);
                    label379.Text = u.ToString() + " Гц";
                });
            }

            catch { }

        }
        #endregion
        #region function
        double Calculate(DataRow row, DataRow baseRow)
        {
            double tg1 = Math.Round(Convert.ToDouble(row[2]) - Convert.ToDouble(baseRow[2]), 3) * 18;
            double tg2 = Math.Round(Convert.ToDouble(row[3]) - Convert.ToDouble(baseRow[3]), 3) * 18;
            double tg3 = Math.Round(Convert.ToDouble(row[4]) - Convert.ToDouble(baseRow[4]), 3) * 18;
            double tg4 = Math.Round(Convert.ToDouble(row[5]) - Convert.ToDouble(baseRow[5]), 3) * 18;
            double tg5 = Math.Round(Convert.ToDouble(row[6]) - Convert.ToDouble(baseRow[6]), 3) * 48;
            double tg6 = Math.Round(Convert.ToDouble(row[7]) - Convert.ToDouble(baseRow[7]), 3) * 48;
            double tg7 = Math.Round(Convert.ToDouble(row[8]) - Convert.ToDouble(baseRow[8]), 3) * 48;
            double tg8 = Math.Round(Convert.ToDouble(row[9]) - Convert.ToDouble(baseRow[9]), 3) * 48;
            double tg9 = Math.Round(Convert.ToDouble(row[10]) - Convert.ToDouble(baseRow[10]), 3) * 105;

            return Math.Round(tg1 + tg2 + tg3 + tg4 + tg5 + tg6 + tg7 + tg8 + tg9, 3);
        }

        private void bolovsruulaltBodoh(DateTime hugatsaa)
        {
            try
            {

                DateTime guravHonogiinUmnu = DateTime.Now.AddDays(-3);
                DataTable zaaltTable;
                DataTable daalgawarTable;

                string zaaltTableName = (hugatsaa < guravHonogiinUmnu) ? "zaaltguraw" : "zaaltguraw1";
                string daalgawarTableName = (hugatsaa < guravHonogiinUmnu) ? "daalgawar1" : "daalgawara1";

                using (SqlConnection cons = new SqlConnection(con.ConnectionString))
                {
                    con.Open();
                    // ----- Zaalt table query -----
                    SqlDataAdapter daZaalt = new SqlDataAdapter($@"
        SELECT 
            CONVERT(VARCHAR(5), tsag, 108) AS Цаг,
            ROUND(tg1, 3) AS ТГ1,
            ROUND(tg2, 3) AS ТГ2,
            ROUND(tg3, 3) AS ТГ3,
            ROUND(tg4, 3) AS ТГ4,
            ROUND(tg5, 3) AS ТГ5,
            ROUND(tg6, 3) AS ТГ6,
            ROUND(tg7, 3) AS ТГ7,
            ROUND(tg8, 3) AS ТГ8,
            ROUND(tg9, 3) AS ТГ9,
            ROUND(t1avsan, 3) AS Т1авсан,
            ROUND(t1ogson, 3) AS Т1өгсөн,
            ROUND(t2avsan, 3) AS Т2авсан,
            ROUND(t2ogson, 3) AS Т2өгсөн,
            ROUND(BTR5, 3) AS БТР5,
            ROUND(BTR6, 3) AS БТР6,
            ROUND(BTR7, 3) AS БТР7,
            ROUND(BTR8, 3) AS БТР8,
            ROUND(BTR9, 3) AS БТР9,
            ROUND(t12, 3) AS T12_6Kв,
            ROUND(t12_110kv, 3) AS T12_110Kв,
            ROUND(AO14, 3) AS AO14,
            ROUND(BO14, 3) AS BO14
        FROM {zaaltTableName}
        WHERE DAY(tsag) = @day AND MONTH(tsag) = @month AND YEAR(tsag) = @year
        ORDER BY id DESC", con);

                    daZaalt.SelectCommand.Parameters.AddWithValue("@day", hugatsaa.Day);
                    daZaalt.SelectCommand.Parameters.AddWithValue("@month", hugatsaa.Month);
                    daZaalt.SelectCommand.Parameters.AddWithValue("@year", hugatsaa.Year);

                    DataSet dsZaalt = new DataSet();
                    daZaalt.Fill(dsZaalt);
                    zaaltTable = dsZaalt.Tables[0];
                    dataGridView13.DataSource = zaaltTable;
                    table_zaaltguraw = zaaltTable;

                    // ----- Daalkgawar table query -----
                    SqlDataAdapter daDaalgawar = new SqlDataAdapter($@"
        SELECT CONVERT(VARCHAR(8), tsag, 108) AS Цаг, daalgawar
        FROM {daalgawarTableName}
        WHERE DAY(tsag) = @day AND MONTH(tsag) = @month AND YEAR(tsag) = @year
        ORDER BY id DESC", con);

                    daDaalgawar.SelectCommand.Parameters.AddWithValue("@day", hugatsaa.Day);
                    daDaalgawar.SelectCommand.Parameters.AddWithValue("@month", hugatsaa.Month);
                    daDaalgawar.SelectCommand.Parameters.AddWithValue("@year", hugatsaa.Year);

                    DataSet dsDaalgawar = new DataSet();
                    daDaalgawar.Fill(dsDaalgawar);
                    daalgawarTable = dsDaalgawar.Tables[0];
                    //  dataGridView18.DataSource = daalgawarTable;
                    table_daalgawar = daalgawarTable;

                    if (zaaltTable.Rows.Count > 0)
                    {
                        DateTime dd = Convert.ToDateTime(zaaltTable.Rows[0][0]);
                        bolovsruulaltToTextBox(hugatsaa);

                        // ✅ dataGridView6-ийн оронд dataTable6 үүсгэж ашиглана
                        DataTable dataTable6 = new DataTable();
                        dataTable6.Columns.Add("Цаг", typeof(string));
                        dataTable6.Columns.Add("НийлбэрДаалгавар", typeof(decimal));

                        // Даалгавар мөрүүдийг dd цагаас өмнө шүүж авна
                        List<DataRow> filteredDaalgawar = daalgawarTable.AsEnumerable()
                            .Where(row => DateTime.Parse(row[0].ToString()) <= dd)
                            .ToList();

                        // Хураангуйлсан нийлбэр
                        decimal niilberDaalgawar = 0;

                        for (int i = filteredDaalgawar.Count - 1; i >= 0; i--)
                        {
                            DateTime tsag = DateTime.Parse(filteredDaalgawar[i][0].ToString());
                            decimal daalgawar = Convert.ToDecimal(filteredDaalgawar[i][1]);

                            niilberDaalgawar += daalgawar;

                            DataRow newRow = dataTable6.NewRow();
                            newRow["Цаг"] = tsag.ToString("HH:mm:ss");
                            newRow["НийлбэрДаалгавар"] = niilberDaalgawar;
                            dataTable6.Rows.InsertAt(newRow, 0); // Хуучин дарааллаар байлгахын тулд эхэнд нь оруулж байна
                        }

                        //table_daalgawar6 = dataTable6; // хадгалах
                        niilber[15] = niilberDaalgawar;

                        // ----------------- dataGridView16-д Zaalt + Daalgawar нийлүүлэх ------------------
                        if (zaaltTable.Rows.Count > 1)
                        {
                            dataGridView16.Rows.Clear();
                            dataGridView16.Rows.Add(zaaltTable.Rows.Count);

                            decimal niilber0 = 0;
                            decimal niilber1 = 0;

                            for (int i = 0; i < zaaltTable.Rows.Count; i++)
                            {
                                dataGridView16[0, i].Value = zaaltTable.Rows[i][0];

                                // ✅ dataTable6-гаас тохирох мөр олж 4-р багана руу оруулна
                                if (i < dataTable6.Rows.Count)
                                {
                                    dataGridView16[4, i].Value = dataTable6.Rows[i]["НийлбэрДаалгавар"];
                                }
                            }

                            for (int i = zaaltTable.Rows.Count - 1; i > 0; i--)
                            {
                                decimal d1 = Convert.ToDecimal(zaaltTable.Rows[i - 1][1]) - Convert.ToDecimal(zaaltTable.Rows[i][1]);
                                decimal d2 = Convert.ToDecimal(zaaltTable.Rows[i - 1][2]) - Convert.ToDecimal(zaaltTable.Rows[i][2]);
                                decimal d3 = Convert.ToDecimal(zaaltTable.Rows[i - 1][3]) - Convert.ToDecimal(zaaltTable.Rows[i][3]);
                                decimal d4 = Convert.ToDecimal(zaaltTable.Rows[i - 1][4]) - Convert.ToDecimal(zaaltTable.Rows[i][4]);
                                niilber0 += (d1 + d2 + d3 + d4) * 18;

                                decimal b5 = Convert.ToDecimal(zaaltTable.Rows[i - 1][5]) - Convert.ToDecimal(zaaltTable.Rows[i][5]);
                                decimal b6 = Convert.ToDecimal(zaaltTable.Rows[i - 1][6]) - Convert.ToDecimal(zaaltTable.Rows[i][6]);
                                decimal b7 = Convert.ToDecimal(zaaltTable.Rows[i - 1][7]) - Convert.ToDecimal(zaaltTable.Rows[i][7]);
                                decimal b8 = Convert.ToDecimal(zaaltTable.Rows[i - 1][8]) - Convert.ToDecimal(zaaltTable.Rows[i][8]);
                                decimal b9 = Convert.ToDecimal(zaaltTable.Rows[i - 1][9]) - Convert.ToDecimal(zaaltTable.Rows[i][9]);
                                niilber1 += (b5 + b6 + b7 + b8) * 48 + b9 * 105;

                                dataGridView16[1, i - 1].Value = niilber0;
                                dataGridView16[2, i - 1].Value = niilber1;
                                dataGridView16[3, i - 1].Value = niilber0 + niilber1;

                                decimal daalgawarValue = Convert.ToDecimal(dataGridView16[4, i - 1].Value ?? 0);
                                dataGridView16[5, i - 1].Value = niilber0 + niilber1 - daalgawarValue;
                            }

                            niilber[0] = niilber0;
                            niilber[1] = niilber1;
                        }
                    }
                }

            }
            catch { }
        }
        private void bolovsruulaltToTextBox(DateTime hugatsaa)
        {
            try
            {
                DateTime guravHonogiinUmnu = DateTime.Now.AddDays(-3);
                if (hugatsaa < guravHonogiinUmnu)
                {
                    SqlDataAdapter da6 = new SqlDataAdapter("select (select CONVERT (VARCHAR(5), tsag, 108) 'hh:mi' ) AS Цаг,  (select ROUND(tg1, 3)) AS ТГ1, (select ROUND(tg2, 3)) AS ТГ2, (select ROUND(tg3, 3)) AS ТГ3, (select ROUND(tg4, 3)) AS ТГ4, (select ROUND(tg5, 3)) AS ТГ5, (select ROUND(tg6, 3)) AS ТГ6, (select ROUND(tg7, 3)) AS ТГ7, (select ROUND(tg8, 3)) AS ТГ8, (select ROUND(tg9, 3)) AS ТГ9, (select ROUND(t1avsan, 3)) AS Т1авсан, (select ROUND(t1ogson, 3)) AS Т1өгсөн, (select ROUND(t2avsan, 3)) AS Т2авсан, (select ROUND(t2ogson, 3)) AS Т2өгсөн, (select ROUND(BTR5, 3)) AS БТР5, (select ROUND(BTR6, 3)) AS БТР6, (select ROUND(BTR7, 3)) AS БТР7, (select ROUND(BTR8, 3)) AS БТР8, (select ROUND(BTR9, 3)) AS БТР9, (select ROUND(t12, 3)) AS T12_6Kв, (select ROUND(t12_110kv, 3)) AS T12_110Kв, (select ROUND(AO14, 3)) AS AO14, (select ROUND(BO14, 3)) AS BO14   from zaaltguraw where (select DATEPART(dd, tsag))=@unuudur and (select DATEPART(mm, tsag))=@mashinodoogiinsar  and (select DATEPART(yy, tsag))=@mashinjil  ORDER BY id DESC", con);
                    da6.SelectCommand.Parameters.AddWithValue("@unuudur", hugatsaa.Day);
                    da6.SelectCommand.Parameters.AddWithValue("@mashinodoogiinsar", hugatsaa.Month);
                    da6.SelectCommand.Parameters.AddWithValue("@mashinjil", hugatsaa.Year);
                    DataSet ds6 = new DataSet();
                    da6.Fill(ds6, "zaaltguraw");
                    dataGridView13.DataSource = ds6.Tables[0];
                }
                else
                {

                    SqlDataAdapter da6 = new SqlDataAdapter("select (select CONVERT (VARCHAR(5), tsag, 108) 'hh:mi' ) AS Цаг,  (select ROUND(tg1, 3)) AS ТГ1, (select ROUND(tg2, 3)) AS ТГ2, (select ROUND(tg3, 3)) AS ТГ3, (select ROUND(tg4, 3)) AS ТГ4, (select ROUND(tg5, 3)) AS ТГ5, (select ROUND(tg6, 3)) AS ТГ6, (select ROUND(tg7, 3)) AS ТГ7, (select ROUND(tg8, 3)) AS ТГ8, (select ROUND(tg9, 3)) AS ТГ9, (select ROUND(t1avsan, 3)) AS Т1авсан, (select ROUND(t1ogson, 3)) AS Т1өгсөн, (select ROUND(t2avsan, 3)) AS Т2авсан, (select ROUND(t2ogson, 3)) AS Т2өгсөн, (select ROUND(BTR5, 3)) AS БТР5, (select ROUND(BTR6, 3)) AS БТР6, (select ROUND(BTR7, 3)) AS БТР7, (select ROUND(BTR8, 3)) AS БТР8, (select ROUND(BTR9, 3)) AS БТР9, (select ROUND(t12, 3)) AS T12_6Kв, (select ROUND(t12_110kv, 3)) AS T12_110Kв, (select ROUND(AO14, 3)) AS AO14, (select ROUND(BO14, 3)) AS BO14   from zaaltguraw1 where (select DATEPART(dd, tsag))=@unuudur and (select DATEPART(mm, tsag))=@mashinodoogiinsar  and (select DATEPART(yy, tsag))=@mashinjil  ORDER BY id DESC", con);
                    da6.SelectCommand.Parameters.AddWithValue("@unuudur", hugatsaa.Day);
                    da6.SelectCommand.Parameters.AddWithValue("@mashinodoogiinsar", hugatsaa.Month);
                    da6.SelectCommand.Parameters.AddWithValue("@mashinjil", hugatsaa.Year);
                    DataSet ds6 = new DataSet();
                    da6.Fill(ds6, "zaaltguraw1");
                    dataGridView13.DataSource = ds6.Tables[0];
                }
                DateTime clock4 = DateTime.ParseExact("08:00", "HH:mm", CultureInfo.InvariantCulture);
                DateTime clock5 = DateTime.ParseExact("16:00", "HH:mm", CultureInfo.InvariantCulture);
                for (int i = 0; i < dataGridView13.Rows.Count; ++i)
                {
                    if (Convert.ToDateTime(dataGridView13.Rows[i].Cells[0].Value) <= clock4 && Convert.ToDateTime(dataGridView13.Rows[i].Cells[0].Value).Hour >= 0)
                    {
                        dataGridView13.Rows[i].Selected = true;
                        for (int a = 0; a < dataGridView13.SelectedRows.Count; ++a)
                        {
                            textBox4.Text = Math.Round(((((Convert.ToDouble(dataGridView13.SelectedRows[a].Cells[1].Value)) - (Convert.ToDouble(dataGridView13.SelectedRows[0].Cells[1].Value))) * 18) + (((Convert.ToDouble(dataGridView13.SelectedRows[a].Cells[2].Value)) - (Convert.ToDouble(dataGridView13.SelectedRows[0].Cells[2].Value))) * 18) + (((Convert.ToDouble(dataGridView13.SelectedRows[a].Cells[3].Value)) - (Convert.ToDouble(dataGridView13.SelectedRows[0].Cells[3].Value))) * 18) + (((Convert.ToDouble(dataGridView13.SelectedRows[a].Cells[4].Value)) - (Convert.ToDouble(dataGridView13.SelectedRows[0].Cells[4].Value))) * 18)), 3).ToString();
                            textBox5.Text = Math.Round(((((Convert.ToDouble(dataGridView13.SelectedRows[a].Cells[5].Value)) - (Convert.ToDouble(dataGridView13.SelectedRows[0].Cells[5].Value))) * 48) + (((Convert.ToDouble(dataGridView13.SelectedRows[a].Cells[6].Value)) - (Convert.ToDouble(dataGridView13.SelectedRows[0].Cells[6].Value))) * 48) + (((Convert.ToDouble(dataGridView13.SelectedRows[a].Cells[7].Value)) - (Convert.ToDouble(dataGridView13.SelectedRows[0].Cells[7].Value))) * 48) + (((Convert.ToDouble(dataGridView13.SelectedRows[a].Cells[8].Value)) - (Convert.ToDouble(dataGridView13.SelectedRows[0].Cells[8].Value))) * 48) + (((Convert.ToDouble(dataGridView13.SelectedRows[a].Cells[9].Value)) - (Convert.ToDouble(dataGridView13.SelectedRows[0].Cells[9].Value))) * 105)), 3).ToString();
                            textBox6.Text = Math.Round(((Convert.ToDouble(textBox4.Text)) + (Convert.ToDouble(textBox5.Text))), 3).ToString();
                        }
                    }
                }
                dataGridView13.ClearSelection();
                for (int i = 0; i < dataGridView13.Rows.Count; ++i)
                {
                    if (Convert.ToDateTime(dataGridView13.Rows[i].Cells[0].Value) <= clock5 && Convert.ToDateTime(dataGridView13.Rows[i].Cells[0].Value).Hour >= 8)
                    {
                        dataGridView13.Rows[i].Selected = true;
                        for (int a = 0; a < dataGridView13.SelectedRows.Count; ++a)
                        {
                            textBox7.Text = Math.Round(((((Convert.ToDouble(dataGridView13.SelectedRows[a].Cells[1].Value)) - (Convert.ToDouble(dataGridView13.SelectedRows[0].Cells[1].Value))) * 18) + (((Convert.ToDouble(dataGridView13.SelectedRows[a].Cells[2].Value)) - (Convert.ToDouble(dataGridView13.SelectedRows[0].Cells[2].Value))) * 18) + (((Convert.ToDouble(dataGridView13.SelectedRows[a].Cells[3].Value)) - (Convert.ToDouble(dataGridView13.SelectedRows[0].Cells[3].Value))) * 18) + (((Convert.ToDouble(dataGridView13.SelectedRows[a].Cells[4].Value)) - (Convert.ToDouble(dataGridView13.SelectedRows[0].Cells[4].Value))) * 18)), 3).ToString();
                            textBox8.Text = Math.Round(((((Convert.ToDouble(dataGridView13.SelectedRows[a].Cells[5].Value)) - (Convert.ToDouble(dataGridView13.SelectedRows[0].Cells[5].Value))) * 48) + (((Convert.ToDouble(dataGridView13.SelectedRows[a].Cells[6].Value)) - (Convert.ToDouble(dataGridView13.SelectedRows[0].Cells[6].Value))) * 48) + (((Convert.ToDouble(dataGridView13.SelectedRows[a].Cells[7].Value)) - (Convert.ToDouble(dataGridView13.SelectedRows[0].Cells[7].Value))) * 48) + (((Convert.ToDouble(dataGridView13.SelectedRows[a].Cells[8].Value)) - (Convert.ToDouble(dataGridView13.SelectedRows[0].Cells[8].Value))) * 48) + (((Convert.ToDouble(dataGridView13.SelectedRows[a].Cells[9].Value)) - (Convert.ToDouble(dataGridView13.SelectedRows[0].Cells[9].Value))) * 105)), 3).ToString();
                            textBox9.Text = Math.Round(((Convert.ToDouble(textBox7.Text)) + (Convert.ToDouble(textBox8.Text))), 3).ToString();
                        }
                    }
                }
                dataGridView13.ClearSelection();
                for (int i = 0; i < dataGridView13.Rows.Count; ++i)
                {
                    if (Convert.ToDateTime(dataGridView13.Rows[i].Cells[0].Value).Hour <= 23 && Convert.ToDateTime(dataGridView13.Rows[i].Cells[0].Value).Hour >= 16)
                    {
                        dataGridView13.Rows[i].Selected = true;
                        for (int a = 0; a < dataGridView13.SelectedRows.Count; ++a)
                        {
                            textBox10.Text = Math.Round(((((Convert.ToDouble(dataGridView13.SelectedRows[a].Cells[1].Value)) - (Convert.ToDouble(dataGridView13.SelectedRows[0].Cells[1].Value))) * 18) + (((Convert.ToDouble(dataGridView13.SelectedRows[a].Cells[2].Value)) - (Convert.ToDouble(dataGridView13.SelectedRows[0].Cells[2].Value))) * 18) + (((Convert.ToDouble(dataGridView13.SelectedRows[a].Cells[3].Value)) - (Convert.ToDouble(dataGridView13.SelectedRows[0].Cells[3].Value))) * 18) + (((Convert.ToDouble(dataGridView13.SelectedRows[a].Cells[4].Value)) - (Convert.ToDouble(dataGridView13.SelectedRows[0].Cells[4].Value))) * 18)), 3).ToString();
                            textBox11.Text = Math.Round(((((Convert.ToDouble(dataGridView13.SelectedRows[a].Cells[5].Value)) - (Convert.ToDouble(dataGridView13.SelectedRows[0].Cells[5].Value))) * 48) + (((Convert.ToDouble(dataGridView13.SelectedRows[a].Cells[6].Value)) - (Convert.ToDouble(dataGridView13.SelectedRows[0].Cells[6].Value))) * 48) + (((Convert.ToDouble(dataGridView13.SelectedRows[a].Cells[7].Value)) - (Convert.ToDouble(dataGridView13.SelectedRows[0].Cells[7].Value))) * 48) + (((Convert.ToDouble(dataGridView13.SelectedRows[a].Cells[8].Value)) - (Convert.ToDouble(dataGridView13.SelectedRows[0].Cells[8].Value))) * 48) + (((Convert.ToDouble(dataGridView13.SelectedRows[a].Cells[9].Value)) - (Convert.ToDouble(dataGridView13.SelectedRows[0].Cells[9].Value))) * 105)), 3).ToString();
                            textBox12.Text = Math.Round(((Convert.ToDouble(textBox10.Text)) + (Convert.ToDouble(textBox11.Text))), 3).ToString();
                        }
                    }
                }
                dataGridView13.ClearSelection();
            }
            catch { }
        }
      


        private void daalgavarTab(DateTime hugatsaa)
        {
            SqlDataAdapter da = new SqlDataAdapter("select (select CONVERT (VARCHAR(8), tsag, 108) 'hh:mi:ss' ) AS Цаг, (select ROUND(tg1, 3)) AS ТГ1, (select ROUND(tg2, 3)) AS ТГ2, (select ROUND(tg3, 3)) AS ТГ3, (select ROUND(tg4, 3)) AS ТГ4, (select ROUND(tg5, 3)) AS ТГ5, (select ROUND(tg6, 3)) AS ТГ6, (select ROUND(tg7, 3)) AS ТГ7, (select ROUND(tg8, 3)) AS ТГ8, (select ROUND(tg9, 3)) AS ТГ9 from mashin where (select DATEPART(dd, tsag))=@unuudur and (select DATEPART(mm, tsag))=@odoogiinsar and (select DATEPART(yy, tsag))=@jil ORDER BY id DESC", con);
            da.SelectCommand.Parameters.AddWithValue("@unuudur", hugatsaa.Day);
            da.SelectCommand.Parameters.AddWithValue("@odoogiinsar", hugatsaa.Month);
            da.SelectCommand.Parameters.AddWithValue("@jil", hugatsaa.Year);
            DataSet ds = new DataSet();
            da.Fill(ds, "mashin");


            SqlDataAdapter da1 = new SqlDataAdapter("select (select CONVERT (VARCHAR(8), tsag, 108) 'hh:mi:ss' ) AS Цаг, (select ROUND(undur, 3)) AS Өндөр, (select ROUND(dund, 3)) AS Дунд, (select ROUND(niilber, 3)) AS Нийлбэр from bolowsruulalt where (select DATEPART(dd, tsag))=@unuudur1 and (select DATEPART(mm, tsag))=@odoogiinsar1  and (select DATEPART(yy, tsag))=@jil1 ORDER BY id DESC", con);
            da1.SelectCommand.Parameters.AddWithValue("@unuudur1", hugatsaa.Day);
            da1.SelectCommand.Parameters.AddWithValue("@odoogiinsar1", hugatsaa.Month);
            da1.SelectCommand.Parameters.AddWithValue("@jil1", hugatsaa.Year);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1, "bolowsruulalt");
            //    dataGridView1.DataSource = ds1.Tables[0];

            SqlDataAdapter da3 = new SqlDataAdapter("select (select CONVERT (VARCHAR(8), tsag, 108) 'hh:mi:ss' ) AS Цаг, (select ROUND(daalgawar, 3)) AS Даалгавар, (select ROUND(daalgawar1, 3)) AS Даалгавар1 from daalgawar where (select DATEPART(dd, tsag))=@unuudur1 and (select DATEPART(mm, tsag))=@odoogiinsardaalgawar and (select DATEPART(yy, tsag))=@jildaalgawar ORDER BY id ASC", con);
            da3.SelectCommand.Parameters.AddWithValue("@unuudur1", hugatsaa.Day);
            da3.SelectCommand.Parameters.AddWithValue("@odoogiinsardaalgawar", hugatsaa.Month);
            da3.SelectCommand.Parameters.AddWithValue("@jildaalgawar", hugatsaa.Year);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3, "daalgawar");

            dataGridView5.DataSource = ds3.Tables[0];


        }

        public void connectionopen(SqlConnection connection)
        {

            if (connection.State == ConnectionState.Closed)
                connection.Open();
        }
        public void connectionclose(SqlConnection connection)
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();

        }


        #endregion
      
    }
}
