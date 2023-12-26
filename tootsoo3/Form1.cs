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
//using Microsoft.Reporting.WinForms;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace tootsoo3
{
    public partial class Тооцоо : Form
    {
        int[] cname = new int[100];
        int[] cname1 = new int[100];

        #region huwisagch
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
        double utganemeh;
        SqlCommand cmdutga;
        int r1, r2;
        int ehleh;
        int tolow;
        int mtg;
        int r1tg, r2tg;
        int ehlehtg;
        int tolowtg;
        float[] avsan = new float[20];
        SqlConnection con, contg, con85dt, confider, con85tooluur,  con50, conp, con50_pet, con_Az, cont;
        float[] tg = new float[20];
        float[,] tg1 = new float[20, 20];
        Point? prevPosition = null;
        ToolTip tooltip = new ToolTip();
        double[, ,] maxmin = new double[30, 30, 30];
        Double shi;
        double[,] dundb = new double[30, 30];
        decimal[] niilber = new decimal[16];
        double tailanniilber;
        double[] tailan1 = new double[150];
        DateTime dd, blDateTimeEnd;
        bool connected = false, ping85 = false, ping40 = false, ping41 = false, ping236 = false, ping50 = false;
        int maxminhour;
        DataTable table12, tableParameter, table1RO, table2RO, table7R, table8R, table9R, table10R, table11R, table12R, table13R, table14R,
            tableZaaltGuraw, tableORU, tableGRU, table1R, table2R, table3R, table4R, table5R, table6R, table, table_maxd, table_maxu;
        double t21, t22, t25, t26, beltgel_1RO, beltgel_7R, beltgel_2RO, beltgel_8R, beltgel_9R, beltgel_10R, beltgel_11R, beltgel_12R,
            beltgel_13R, beltgel_t112, beltgel_t113;
        SimpleTcpClient client, client1;
       // ReportDataSource rds = new ReportDataSource();
        WpfSchematic.WpfSchem generalSchem;
        Ping isping = new Ping();
        PingReply reply85, reply40, reply41, reply236, reply50;
        byte[] data, buffer, data_tg, buffer_tg;
        #endregion
        public Тооцоо()
        {
            InitializeComponent();
            generalSchem = elementHost1.Child as WpfSchematic.WpfSchem;
            con = new SqlConnection();
            con.ConnectionString = @"Server=192.168.20.85;Database=tootsooloh;User Id=hereglegch; Password=Passwd_123;";
          
          
            confider = new SqlConnection();
            confider.ConnectionString = @"Server=192.168.20.85;Database=r8000dund1;User Id=hereglegch; Password=Passwd_123;";

            cont = new SqlConnection();
             cont.ConnectionString = @"Data Source=KHURELEE-PC\SQLEXPRESS;Initial Catalog=tailan;Integrated Security=True;";
      //      cont.ConnectionString = @"Data Source=DESKTOP-S6OMBEL\SQLEXPRESS;Initial Catalog=tailan;Integrated Security=True;";

            contg = new SqlConnection();
            contg.ConnectionString = @"Server=192.168.20.85;Database=dotoodheregtseereal;User Id=hereglegch; Password=Passwd_123;";
          
          
            con50 = new SqlConnection();
            con50.ConnectionString = @"Server=192.168.20.50;Database=r8000dund1;User Id=hereglegch; Password=sql;";
           
            con50_pet = new SqlConnection();
            con50_pet.ConnectionString = @"Server=192.168.20.50;Database=pet;User Id=hereglegch; Password=sql;";
            
            conp = new SqlConnection();
            conp.ConnectionString = @"Server=192.168.20.85;Database=UI_hyanalt;User Id=hereglegch; Password=Passwd_123;";
           
            con85tooluur = new SqlConnection();
            con85tooluur.ConnectionString = @"Server=192.168.20.85;Database=Tooluuriin_zaalt;User Id=hereglegch; Password=Passwd_123;";
           
            con85dt = new SqlConnection();
            con85dt.ConnectionString = @"Server=192.168.20.85;Database=dotoodheregtsee;User Id=hereglegch; Password=Passwd_123;";

            con_Az = new SqlConnection();
            con_Az.ConnectionString = @"Server=192.168.20.85;Database=Telemekhanic;User Id=Tele_Az; Password=Az123;";
            charttuluv = 0;
        }

        private void bolovsruulaltBodoh(DateTime hugatsaa)
        {
            DateTime guravHonogiinUmnu = DateTime.Now.AddDays(-3);
            if (hugatsaa < guravHonogiinUmnu)
            {
                SqlDataAdapter da6 = new SqlDataAdapter("select tsag AS Цаг,  (select ROUND(tg1, 3)) AS ТГ1, (select ROUND(tg2, 3)) AS ТГ2, (select ROUND(tg3, 3)) AS ТГ3, (select ROUND(tg4, 3)) AS ТГ4, (select ROUND(tg5, 3)) AS ТГ5, (select ROUND(tg6, 3)) AS ТГ6, (select ROUND(tg7, 3)) AS ТГ7, (select ROUND(tg8, 3)) AS ТГ8, (select ROUND(tg9, 3)) AS ТГ9, (select ROUND(t1avsan, 3)) AS Т1авсан, (select ROUND(t1ogson, 3)) AS Т1өгсөн, (select ROUND(t2avsan, 3)) AS Т2авсан, (select ROUND(t2ogson, 3)) AS Т2өгсөн, (select ROUND(BTR5, 3)) AS БТР5, (select ROUND(BTR6, 3)) AS БТР6, (select ROUND(BTR7, 3)) AS БТР7, (select ROUND(BTR8, 3)) AS БТР8, (select ROUND(BTR9, 3)) AS БТР9, (select ROUND(t12, 3)) AS T12_6Kв, (select ROUND(t12_110kv, 3)) AS T12_110Kв, (select ROUND(AO14, 3)) AS AO14, (select ROUND(BO14, 3)) AS BO14   from zaaltguraw where (select DATEPART(dd, tsag))=@unuudur and (select DATEPART(mm, tsag))=@mashinodoogiinsar  and (select DATEPART(yy, tsag))=@mashinjil  ORDER BY id DESC", con);
                da6.SelectCommand.Parameters.AddWithValue("@unuudur", hugatsaa.Day);
                da6.SelectCommand.Parameters.AddWithValue("@mashinodoogiinsar", hugatsaa.Month);
                da6.SelectCommand.Parameters.AddWithValue("@mashinjil", hugatsaa.Year);
                DataSet ds6 = new DataSet();
                da6.Fill(ds6, "zaaltguraw");
                dataGridView13.DataSource = ds6.Tables[0];

                SqlDataAdapter da11 = new SqlDataAdapter("select (select CONVERT (VARCHAR(8), tsag, 108) 'hh:mi:ss' ) AS Цаг, daalgawar from daalgawar1 where (select DATEPART(dd, tsag))=@unuudur11 and (select DATEPART(mm, tsag))=@odoogiinsardaalg1  and (select DATEPART(yy, tsag))=@jildaalg1 ORDER BY id DESC", con);
                da11.SelectCommand.Parameters.AddWithValue("@unuudur11", hugatsaa.Day);
                da11.SelectCommand.Parameters.AddWithValue("@odoogiinsardaalg1", hugatsaa.Month);
                da11.SelectCommand.Parameters.AddWithValue("@jildaalg1", hugatsaa.Year);
                DataSet ds11 = new DataSet();
                da11.Fill(ds11, "daalgawar1");
                dataGridView18.DataSource = ds11.Tables[0];
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

                SqlDataAdapter da11 = new SqlDataAdapter("select (select CONVERT (VARCHAR(8), tsag, 108) 'hh:mi:ss' ) AS Цаг, daalgawar from daalgawara1 where (select DATEPART(dd, tsag))=@unuudur11 and (select DATEPART(mm, tsag))=@odoogiinsardaalg1  and (select DATEPART(yy, tsag))=@jildaalg1 ORDER BY id DESC", con);
                da11.SelectCommand.Parameters.AddWithValue("@unuudur11", hugatsaa.Day);
                da11.SelectCommand.Parameters.AddWithValue("@odoogiinsardaalg1", hugatsaa.Month);
                da11.SelectCommand.Parameters.AddWithValue("@jildaalg1", hugatsaa.Year);
                DataSet ds11 = new DataSet();
                da11.Fill(ds11, "daalgawara1");
                dataGridView18.DataSource = ds11.Tables[0];
            }
            if (dataGridView13.Rows.Count > 0)
            {
                dd = Convert.ToDateTime(dataGridView13.Rows[0].Cells[0].Value);

                bolovsruulaltToTextBox(hugatsaa);

                dataGridView6.Rows.Clear();
                if (dataGridView18.Rows.Count > 0)
                {
                    for (int i = 0; i < dataGridView18.Rows.Count; ++i)
                    {
                        if (Convert.ToDateTime(dataGridView18.Rows[i].Cells[0].Value) <= dd)
                        {
                            dataGridView6.Rows.Add(dataGridView18.Rows[i].Cells[0].Value, dataGridView18.Rows[i].Cells[1].Value);
                        }
                    }
                }
                niilber[15] = 0;
                try
                {
                    for (int i = dataGridView6.Rows.Count - 1; i < dataGridView6.Rows.Count; i--)
                    {
                        niilber[15] = niilber[15] + Convert.ToDecimal(dataGridView6[1, i - 1].Value);
                        dataGridView6[1, i - 1].Value = niilber[15];
                    }
                }
                catch { }
                if (dataGridView13.Rows.Count > 1)
                {
                    dataGridView16.Rows.Clear();
                    dataGridView16.Rows.Add(dataGridView13.Rows.Count);
                    //dataGridView2[bagana, mor]
                    for (int i = 0; i < dataGridView13.Rows.Count; i++)
                    {
                        dataGridView16[0, i].Value = dataGridView13[0, i].Value;
                    }

                    niilber[0] = 0; niilber[1] = 0;
                    if (dataGridView6.Rows.Count > 1)
                    {
                        for (int i = 0; i < dataGridView6.Rows.Count; i++)
                        {
                            dataGridView16[4, i].Value = dataGridView6[1, i].Value;
                        }
                    }
                    try
                    {
                        for (int i = dataGridView13.Rows.Count - 1; i < dataGridView13.Rows.Count; i--)
                        {
                            niilber[0] = niilber[0] + ((Convert.ToDecimal(dataGridView13[1, i - 1].Value) - Convert.ToDecimal(dataGridView13[1, i].Value)) * 18 + (Convert.ToDecimal(dataGridView13[2, i - 1].Value) - Convert.ToDecimal(dataGridView13[2, i].Value)) * 18 + (Convert.ToDecimal(dataGridView13[3, i - 1].Value) - Convert.ToDecimal(dataGridView13[3, i].Value)) * 18 + (Convert.ToDecimal(dataGridView13[4, i - 1].Value) - Convert.ToDecimal(dataGridView13[4, i].Value)) * 18);
                            dataGridView16[1, i - 1].Value = niilber[0];
                            niilber[1] = niilber[1] + ((Convert.ToDecimal(dataGridView13[5, i - 1].Value) - Convert.ToDecimal(dataGridView13[5, i].Value)) * 48 + (Convert.ToDecimal(dataGridView13[6, i - 1].Value) - Convert.ToDecimal(dataGridView13[6, i].Value)) * 48 + (Convert.ToDecimal(dataGridView13[7, i - 1].Value) - Convert.ToDecimal(dataGridView13[7, i].Value)) * 48 + (Convert.ToDecimal(dataGridView13[8, i - 1].Value) - Convert.ToDecimal(dataGridView13[8, i].Value)) * 48 + (Convert.ToDecimal(dataGridView13[9, i - 1].Value) - Convert.ToDecimal(dataGridView13[9, i].Value)) * 105);
                            dataGridView16[2, i - 1].Value = niilber[1];
                            dataGridView16[3, i - 1].Value = Convert.ToDecimal(dataGridView16[1, i - 1].Value) + Convert.ToDecimal(dataGridView16[2, i - 1].Value);
                            dataGridView16[5, i - 1].Value = Convert.ToDecimal(dataGridView16[3, i - 1].Value) - Convert.ToDecimal(dataGridView16[4, i - 1].Value);
                        }
                    }
                    catch { }
                }
            }
        }
        private void bolovsruulaltToTextBox(DateTime hugatsaa)
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
        private void graphic(DateTime hugatsaa)
        {
            try
            {
                graphicTimer.Interval = 60000;

                #region 3 honog omnoh
                DateTime guravHonogiinUmnu = DateTime.Now.AddDays(-3);
                if (hugatsaa < guravHonogiinUmnu)
                {
                    SqlDataAdapter da4 = new SqlDataAdapter("select (select CONVERT (VARCHAR(8), tsag, 108) 'hh:mi:ss' ) AS Цаг, (select ROUND(tg1, 3)) AS ТГ1, (select ROUND(tg2, 3)) AS ТГ2, (select ROUND(tg3, 3)) AS ТГ3, (select ROUND(tg4, 3)) AS ТГ4, (select ROUND(niilber, 3)) AS Нийлбэр from dund where (select DATEPART(dd, tsag))=@unuudurdund and (select DATEPART(mm, tsag))=@odoogiinsardund  and (select DATEPART(yy, tsag))=@jildund ORDER BY id DESC", con);
                    da4.SelectCommand.Parameters.AddWithValue("@unuudurdund", hugatsaa.Day);
                    da4.SelectCommand.Parameters.AddWithValue("@odoogiinsardund", hugatsaa.Month);
                    da4.SelectCommand.Parameters.AddWithValue("@jildund", hugatsaa.Year);
                    DataSet ds4 = new DataSet();
                    da4.Fill(ds4, "dund");
                    dataGridView3.DataSource = ds4.Tables[0];

                    SqlDataAdapter da5 = new SqlDataAdapter("select (select CONVERT (VARCHAR(8), tsag, 108) 'hh:mi:ss' ) AS Цаг, (select ROUND(tg5, 3)) AS ТГ5, (select ROUND(tg6, 3)) AS ТГ6, (select ROUND(tg7, 3)) AS ТГ7, (select ROUND(tg8, 3)) AS ТГ8, (select ROUND(tg9, 3)) AS ТГ9, (select ROUND(niilber, 3)) AS Нийлбэр, (select ROUND(niit, 3)) AS Нийт, (select ROUND(dotoodHeregtseeDund, 3)) AS Дунд ДХ, (select ROUND(dotoodHeregtseeUndur, 3)) AS Өндөр ДХ, (select ROUND(dotoodHeregtseeNiit, 3)) AS Нийт ДХ from undur where (select DATEPART(dd, tsag))=@unuudurundur and (select DATEPART(mm, tsag))=@odoogiinsarundur and (select DATEPART(yy, tsag))=@jilundur ORDER BY id DESC", con);
                    da5.SelectCommand.Parameters.AddWithValue("@unuudurundur", hugatsaa.Day);
                    da5.SelectCommand.Parameters.AddWithValue("@odoogiinsarundur", hugatsaa.Month);
                    da5.SelectCommand.Parameters.AddWithValue("@jilundur", hugatsaa.Year);
                    DataSet ds5 = new DataSet();
                    da5.Fill(ds5, "undur");
                    dataGridView4.DataSource = ds5.Tables[0];

                    SqlDataAdapter da3 = new SqlDataAdapter("select (select CONVERT (VARCHAR(8), tsag, 108) 'hh:mi:ss' ) AS Цаг, (select ROUND(daalgawar, 3)) AS Даалгавар, (select ROUND(daalgawar1, 3)) AS Даалгавар1 from daalgawar where (select DATEPART(dd, tsag))=@unuudur1 and (select DATEPART(mm, tsag))=@odoogiinsardaalgawar and (select DATEPART(yy, tsag))=@jildaalgawar ORDER BY id ASC", con);
                    da3.SelectCommand.Parameters.AddWithValue("@unuudur1", hugatsaa.Day);
                    da3.SelectCommand.Parameters.AddWithValue("@odoogiinsardaalgawar", hugatsaa.Month);
                    da3.SelectCommand.Parameters.AddWithValue("@jildaalgawar", hugatsaa.Year);
                    DataSet ds3 = new DataSet();
                    da3.Fill(ds3, "daalgawar");
                    dataGridView5.DataSource = ds3.Tables[0];

                    SqlDataAdapter da11 = new SqlDataAdapter("select (select CONVERT (VARCHAR(8), tsag, 108) 'hh:mi:ss' ) AS Цаг, daalgawar from daalgawar1 where (select DATEPART(dd, tsag))=@unuudur11 and (select DATEPART(mm, tsag))=@odoogiinsardaalg1  and (select DATEPART(yy, tsag))=@jildaalg1 ORDER BY id DESC", con);
                    da11.SelectCommand.Parameters.AddWithValue("@unuudur11", hugatsaa.Day);
                    da11.SelectCommand.Parameters.AddWithValue("@odoogiinsardaalg1", hugatsaa.Month);
                    da11.SelectCommand.Parameters.AddWithValue("@jildaalg1", hugatsaa.Year);
                    DataSet ds11 = new DataSet();
                    da11.Fill(ds11, "daalgawar1");
                    dataGridView18.DataSource = ds11.Tables[0];
                }
                #endregion
                #region 3 honog dotor
                else
                {
                    SqlDataAdapter da4 = new SqlDataAdapter("select (select CONVERT (VARCHAR(8), tsag, 108) 'hh:mi:ss' ) AS Цаг, (select ROUND(tg1, 3)) AS ТГ1, (select ROUND(tg2, 3)) AS ТГ2, (select ROUND(tg3, 3)) AS ТГ3, (select ROUND(tg4, 3)) AS ТГ4, (select ROUND(niilber, 3)) AS Нийлбэр from dund1 where (select DATEPART(dd, tsag))=@unuudurdund and (select DATEPART(mm, tsag))=@odoogiinsardund  and (select DATEPART(yy, tsag))=@jildund ORDER BY id DESC", con);
                    da4.SelectCommand.Parameters.AddWithValue("@unuudurdund", hugatsaa.Day);
                    da4.SelectCommand.Parameters.AddWithValue("@odoogiinsardund", hugatsaa.Month);
                    da4.SelectCommand.Parameters.AddWithValue("@jildund", hugatsaa.Year);
                    DataSet ds4 = new DataSet();
                    da4.Fill(ds4, "dund");
                    dataGridView3.DataSource = ds4.Tables[0];

                    SqlDataAdapter da5 = new SqlDataAdapter("select (select CONVERT (VARCHAR(8), tsag, 108) 'hh:mi:ss' ) AS Цаг, (select ROUND(tg5, 3)) AS ТГ5, (select ROUND(tg6, 3)) AS ТГ6, (select ROUND(tg7, 3)) AS ТГ7, (select ROUND(tg8, 3)) AS ТГ8, (select ROUND(tg9, 3)) AS ТГ9, (select ROUND(niilber, 3)) AS Нийлбэр, (select ROUND(niit, 3)) AS Нийт, dotoodHeregtseeDund, dotoodHeregtseeUndur, dotoodHeregtseeNiit, tugeelt from undur1 where (select DATEPART(dd, tsag))=@unuudurundur and (select DATEPART(mm, tsag))=@odoogiinsarundur and (select DATEPART(yy, tsag))=@jilundur ORDER BY id DESC", con);
                    da5.SelectCommand.Parameters.AddWithValue("@unuudurundur", hugatsaa.Day);
                    da5.SelectCommand.Parameters.AddWithValue("@odoogiinsarundur", hugatsaa.Month);
                    da5.SelectCommand.Parameters.AddWithValue("@jilundur", hugatsaa.Year);
                    DataSet ds5 = new DataSet();
                    da5.Fill(ds5, "undur");
                    dataGridView4.DataSource = ds5.Tables[0];

                    SqlDataAdapter da3 = new SqlDataAdapter("select (select CONVERT (VARCHAR(8), tsag, 108) 'hh:mi:ss' ) AS Цаг, (select ROUND(daalgawar, 3)) AS Даалгавар, (select ROUND(daalgawar1, 3)) AS Даалгавар1 from daalgawara where (select DATEPART(dd, tsag))=@unuudur1 and (select DATEPART(mm, tsag))=@odoogiinsardaalgawar and (select DATEPART(yy, tsag))=@jildaalgawar ORDER BY id ASC", con);
                    da3.SelectCommand.Parameters.AddWithValue("@unuudur1", hugatsaa.Day);
                    da3.SelectCommand.Parameters.AddWithValue("@odoogiinsardaalgawar", hugatsaa.Month);
                    da3.SelectCommand.Parameters.AddWithValue("@jildaalgawar", hugatsaa.Year);
                    DataSet ds3 = new DataSet();
                    da3.Fill(ds3, "daalgawar");
                    dataGridView5.DataSource = ds3.Tables[0];

                    SqlDataAdapter da11 = new SqlDataAdapter("select (select CONVERT (VARCHAR(8), tsag, 108) 'hh:mi:ss' ) AS Цаг, daalgawar from daalgawara1 where (select DATEPART(dd, tsag))=@unuudur11 and (select DATEPART(mm, tsag))=@odoogiinsardaalg1  and (select DATEPART(yy, tsag))=@jildaalg1 ORDER BY id DESC", con);
                    da11.SelectCommand.Parameters.AddWithValue("@unuudur11", hugatsaa.Day);
                    da11.SelectCommand.Parameters.AddWithValue("@odoogiinsardaalg1", hugatsaa.Month);
                    da11.SelectCommand.Parameters.AddWithValue("@jildaalg1", hugatsaa.Year);
                    DataSet ds11 = new DataSet();
                    da11.Fill(ds11, "daalgawar1");
                    dataGridView18.DataSource = ds11.Tables[0];
                }

                #endregion
                #region chart 4
                bolovsruulaltToTextBox(hugatsaa);

                SqlDataAdapter bolovsruulalt_hereglee = new SqlDataAdapter("select TOP(5) * from niithereglee ORDER BY id DESC", con);
                DataSet bolovsruulalt_heregle = new DataSet();
                bolovsruulalt_hereglee.Fill(bolovsruulalt_heregle, "niithereglee");
                label15.Text = "Бол: " + Math.Round(Convert.ToDouble(bolovsruulalt_heregle.Tables[0].Rows[0][7]) / 1000, 3).ToString() + " МВт";
                label48.Text = "Түг: " + Math.Round((Convert.ToDouble(bolovsruulalt_heregle.Tables[0].Rows[0][7]) / 1000) - (Convert.ToDouble(bolovsruulalt_heregle.Tables[0].Rows[0][6]) / 1000), 3).ToString() + " МВт";
                label47.Text = "ДХ: " + Math.Round(Convert.ToDouble(bolovsruulalt_heregle.Tables[0].Rows[0][6]) * 100 / Convert.ToDouble(bolovsruulalt_heregle.Tables[0].Rows[0][7]), 3).ToString() + "%";
                chart4.Series["Бол"].Points.Clear();
                chart4.Series["Түг"].Points.Clear();
                chart4.Series["ДХ"].Points.Clear();
                chart4.Series["Бол"].Points.AddXY(DateTime.Now.ToString("HH:mm"), double.Parse(label15.Text.Substring(5, label15.Text.Length - 9)));
                chart4.Series["Түг"].Points.AddY(double.Parse(label48.Text.Substring(5, label48.Text.Length - 9)));
                chart4.Series["ДХ"].Points.AddY(Convert.ToDouble(bolovsruulalt_heregle.Tables[0].Rows[0][6]) / 1000);

                #endregion
                #region bodotl
                //eeljin daalgawar
                double naimdaalgawar = 0;
                double naimdaalgawar35 = 0;
                double azurgaadaalgawar = 0;
                double azurgaadaalgawar35 = 0;
                double hoduruwdaalgawar = 0;
                double hoduruwdaalgawar35 = 0;
                double daalgawarniilber = 0;
                //double naim = 0;
                decimal daalga = 0;
                dataGridView6.Rows.Clear();
                dataGridView10.Rows.Clear();
                dataGridView11.Rows.Clear();
                dataGridView12.Rows.Clear();
                //dd = dd.AddMinutes(15);       
                if (dataGridView18.Rows.Count > 0)
                {
                    for (int i = 0; i < dataGridView18.Rows.Count; ++i)
                    {
                        daalgawarniilber += Convert.ToDouble(dataGridView18.Rows[i].Cells[1].Value);
                        if (Convert.ToDateTime(dataGridView18.Rows[i].Cells[0].Value) <= dd)
                        {
                            dataGridView6.Rows.Add(dataGridView18.Rows[i].Cells[0].Value, dataGridView18.Rows[i].Cells[1].Value);
                        }
                        if (Convert.ToDateTime(dataGridView18.Rows[i].Cells[0].Value).Hour >= 0 && Convert.ToDateTime(dataGridView18.Rows[i].Cells[0].Value).Hour < 8)
                        {
                            dataGridView10.Rows.Add(dataGridView18.Rows[i].Cells[0].Value, dataGridView18.Rows[i].Cells[1].Value);
                        }
                        if (Convert.ToDateTime(dataGridView18.Rows[i].Cells[0].Value).Hour >= 8 && Convert.ToDateTime(dataGridView18.Rows[i].Cells[0].Value).Hour < 16)
                        {
                            dataGridView11.Rows.Add(dataGridView18.Rows[i].Cells[0].Value, dataGridView18.Rows[i].Cells[1].Value);
                        }
                        if (Convert.ToDateTime(dataGridView18.Rows[i].Cells[0].Value).Hour >= 16 && Convert.ToDateTime(dataGridView18.Rows[i].Cells[0].Value).Hour <= 23)
                        {
                            dataGridView12.Rows.Add(dataGridView18.Rows[i].Cells[0].Value, dataGridView18.Rows[i].Cells[1].Value);
                        }
                    }
                }
                daalga = Convert.ToDecimal(dataGridView6.Rows[0].Cells[1].Value);

                niilber[15] = 0;
                try
                {
                    for (int i = dataGridView6.Rows.Count - 1; i < dataGridView6.Rows.Count; i--)
                    {
                        niilber[15] = niilber[15] + Convert.ToDecimal(dataGridView6[1, i - 1].Value);
                        dataGridView6[1, i - 1].Value = niilber[15];
                    }
                }
                catch { }
                for (int i = 0; i < dataGridView10.Rows.Count; ++i)
                {
                    DateTime date1 = DateTime.Now;
                    DateTime date2 = Convert.ToDateTime(dataGridView10.Rows[i].Cells[0].Value);
                    if (date2.TimeOfDay >= date1.TimeOfDay)
                    {
                    }
                    else
                    {
                        naimdaalgawar35 += Convert.ToDouble(dataGridView10.Rows[i].Cells[1].Value);
                    }
                    naimdaalgawar += Convert.ToDouble(dataGridView10.Rows[i].Cells[1].Value);
                }
                //naimdaalgawar = naimdaalgawar + Convert.ToDouble(dataGridView10.Rows[0].Cells[1].Value) + naim;
                for (int i = 0; i < dataGridView11.Rows.Count; ++i)
                {
                    azurgaadaalgawar += Convert.ToDouble(dataGridView11.Rows[i].Cells[1].Value);

                    DateTime date1 = DateTime.Now;
                    DateTime date2 = Convert.ToDateTime(dataGridView11.Rows[i].Cells[0].Value);
                    if (date2.TimeOfDay >= date1.TimeOfDay)
                    {
                        //           azurgaadaalgawar35 += Convert.ToDouble(dataGridView11.Rows[i].Cells[1].Value);
                    }
                    else
                    {
                        azurgaadaalgawar35 += Convert.ToDouble(dataGridView11.Rows[i].Cells[1].Value);
                    }
                }
                for (int i = 0; i < dataGridView12.Rows.Count; ++i)
                {
                    hoduruwdaalgawar += Convert.ToDouble(dataGridView12.Rows[i].Cells[1].Value);
                    DateTime date1 = DateTime.Now;
                    DateTime date2 = Convert.ToDateTime(dataGridView12.Rows[i].Cells[0].Value);
                    if (date2.TimeOfDay >= date1.TimeOfDay)
                    {
                        //           azurgaadaalgawar35 += Convert.ToDouble(dataGridView11.Rows[i].Cells[1].Value);
                    }
                    else
                    {
                        hoduruwdaalgawar35 += Convert.ToDouble(dataGridView12.Rows[i].Cells[1].Value);

                    }
                }

                #endregion
                #region chat solid
                if (!string.IsNullOrEmpty(textBox6.Text) || string.IsNullOrEmpty(naimdaalgawar35.ToString()))
                {
                    label27.Text = Math.Round((Convert.ToDouble(textBox6.Text) - naimdaalgawar35), 3).ToString();
                    // progress bar 
                    if (naimdaalgawar < Convert.ToDouble(textBox6.Text))
                    {
                        solidGauge1.ToColor = System.Windows.Media.Color.FromRgb(11, 211, 1);
                        solidGauge1.To = Convert.ToDouble(Math.Round(naimdaalgawar, 2));
                        solidGauge1.Value = Math.Round(Convert.ToDouble(textBox6.Text), 2);

                    }
                    if (naimdaalgawar > Convert.ToDouble(textBox6.Text))
                    {
                        solidGauge1.ToColor = System.Windows.Media.Color.FromRgb(11, 211, 1);
                        solidGauge1.To = Convert.ToDouble(Math.Round(naimdaalgawar, 2));
                        solidGauge1.Value = Math.Round(Convert.ToDouble(textBox6.Text), 2);
                    }
                }
                else
                {
                    label27.Text = "";
                    solidGauge1.To = Convert.ToInt16(Math.Round(naimdaalgawar, 0));
                    solidGauge1.Value = 0;
                }

                if (!string.IsNullOrEmpty(textBox9.Text) || string.IsNullOrEmpty(azurgaadaalgawar35.ToString()))
                {
                    label28.Text = Math.Round((Convert.ToDouble(textBox9.Text) - azurgaadaalgawar35), 3).ToString();
                    if (azurgaadaalgawar < Convert.ToDouble(textBox9.Text))
                    {
                        solidGauge2.ToColor = System.Windows.Media.Color.FromRgb(11, 211, 1);
                        solidGauge2.To = Convert.ToDouble(Math.Round(azurgaadaalgawar, 2));
                        solidGauge2.Value = Math.Round(Convert.ToDouble(textBox9.Text), 2);
                    }
                    if (azurgaadaalgawar > Convert.ToDouble(textBox9.Text))
                    {
                        solidGauge2.ToColor = System.Windows.Media.Color.FromRgb(11, 211, 1);
                        solidGauge2.To = Convert.ToDouble(Math.Round(azurgaadaalgawar, 2));
                        solidGauge2.Value = Math.Round(Convert.ToDouble(textBox9.Text), 2);
                    }
                }
                else
                {
                    label28.Text = "";
                    solidGauge2.To = Convert.ToInt16(Math.Round(azurgaadaalgawar, 0));
                    solidGauge2.Value = 0;
                }

                if (!string.IsNullOrEmpty(textBox12.Text) || string.IsNullOrEmpty(hoduruwdaalgawar35.ToString()))
                {
                    label29.Text = Math.Round((Convert.ToDouble(textBox12.Text) - hoduruwdaalgawar35), 3).ToString();
                    if (hoduruwdaalgawar < Convert.ToDouble(textBox12.Text))
                    {
                        solidGauge3.ToColor = System.Windows.Media.Color.FromRgb(11, 211, 1);
                        solidGauge3.To = Convert.ToInt16(Math.Round(hoduruwdaalgawar, 2));
                        solidGauge3.Value = Math.Round(Convert.ToDouble(textBox12.Text), 2);

                    }
                    if (hoduruwdaalgawar > Convert.ToDouble(textBox12.Text))
                    {
                        solidGauge3.ToColor = System.Windows.Media.Color.FromRgb(11, 211, 1);
                        solidGauge3.To = Convert.ToInt16(Math.Round(hoduruwdaalgawar, 2));
                        solidGauge3.Value = Math.Round(Convert.ToDouble(textBox12.Text), 2);
                    }
                }
                else
                {
                    label29.Text = "";
                    solidGauge3.To = Convert.ToInt16(Math.Round(hoduruwdaalgawar, 0));
                    solidGauge3.Value = 0;
                }
                #endregion
                //zurah
                double azurgaadaalgawar1 = 0;
                double azurgaadaalgawar2 = 0;
                double azurgaadaalgawar3 = 0;
                double azurgaadaalgawar4 = 0;
                double azurgaadaalgawar5 = 0;
                SqlDataAdapter da44 = new SqlDataAdapter("select TOP 1 *from undur order by id desc", con);
                DataSet ds44 = new DataSet();
                da44.Fill(ds44, "undur");
                SqlDataAdapter da45 = new SqlDataAdapter("select TOP 1 *from dund order by id desc", con);
                DataSet ds45 = new DataSet();
                da45.Fill(ds45, "dund");

                SqlDataAdapter da55 = new SqlDataAdapter("select TOP 1 *from daalgawar where (select DATEPART(hh, tsag))=@nowtsag order by id desc", con);
                da55.SelectCommand.Parameters.AddWithValue("@nowtsag", DateTime.Now.Hour);

                DataSet ds55 = new DataSet();
                da55.Fill(ds55, "daalgawar");

                azurgaadaalgawar1 = Math.Round(Convert.ToDouble(ds55.Tables[0].Rows[0][2]), 0);
                azurgaadaalgawar2 = Math.Round(Convert.ToDouble(ds44.Tables[0].Rows[0][7]), 0);
                azurgaadaalgawar3 = Math.Round(Convert.ToDouble(ds45.Tables[0].Rows[0][6]), 0);
                azurgaadaalgawar4 = azurgaadaalgawar3 + azurgaadaalgawar2 - azurgaadaalgawar1;

                        label34.Text = Math.Round(Convert.ToDouble(ds44.Tables[0].Rows[0][7]) + Convert.ToDouble(ds45.Tables[0].Rows[0][6]) - Convert.ToDouble(ds55.Tables[0].Rows[0][2]), 3).ToString() + "МВт";

                    if (chart1.ChartAreas.Count >= 0)
                    {
                        chart1.ChartAreas.Clear();
                        chart1.ChartAreas.Add("Нийт");
                        chart1.ChartAreas["Нийт"].BackColor = Color.WhiteSmoke;
                        chart1.BackColor = Color.WhiteSmoke;
                        chart1.ChartAreas["Нийт"].AxisX.MinorGrid.Enabled = true;

                        chart1.ChartAreas["Нийт"].AxisY.MajorGrid.LineColor = Color.Silver;
                        chart1.ChartAreas["Нийт"].AxisX.MajorGrid.LineColor = Color.Silver;
                        chart1.ChartAreas["Нийт"].AxisX.MinorGrid.LineColor = Color.Silver;
                    }
                    if (chart1.Series.Count >= 0)
                    {
                        chart1.Series.Clear();
                        chart1.Series.Add("Даалгавар");
                        chart1.Series.Add("Нийлбэр");
                        chart1.Series.Add("ДотоодХэрэгцээ");
                        chart1.Series.Add("Түгээлт");
                        chart1.Series["Даалгавар"].ChartArea = "Нийт";
                        chart1.Series["Нийлбэр"].ChartArea = "Нийт";
                        chart1.Series["ДотоодХэрэгцээ"].ChartArea = "Нийт";
                        chart1.Series["Түгээлт"].ChartArea = "Нийт";
                        chart1.Series["Даалгавар"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
                        chart1.Series["Даалгавар"].Color = Color.Red;
                        chart1.Series["Даалгавар"].BorderWidth = 3;
                        chart1.Series["Даалгавар"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
                        chart1.Series["Нийлбэр"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
                        chart1.Series["Нийлбэр"].Color = Color.Green;
                        chart1.Series["Нийлбэр"].BorderWidth = 2;
                        chart1.Series["Нийлбэр"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
                        chart1.Series["ДотоодХэрэгцээ"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
                        chart1.Series["ДотоодХэрэгцээ"].Color = Color.Blue;
                        chart1.Series["ДотоодХэрэгцээ"].BorderWidth = 2;
                        chart1.Series["ДотоодХэрэгцээ"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
                        chart1.Series["Түгээлт"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
                        chart1.Series["Түгээлт"].Color = Color.Brown;
                        chart1.Series["Түгээлт"].BorderWidth = 2;
                        chart1.Series["Түгээлт"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;

                    }

                    for (int i = 0; i < dataGridView4.Rows.Count - 1; i++)
                    {
                        chart1.Series["Нийлбэр"].Points.AddXY(Convert.ToDateTime(dataGridView4.Rows[i].Cells[0].Value.ToString()), double.Parse(dataGridView4.Rows[i].Cells[7].Value.ToString()));
                        chart1.Series["ДотоодХэрэгцээ"].Points.AddXY(Convert.ToDateTime(dataGridView4.Rows[i].Cells[0].Value.ToString()), double.Parse(dataGridView4.Rows[i].Cells[10].Value.ToString()));
                        chart1.Series["Түгээлт"].Points.AddXY(Convert.ToDateTime(dataGridView4.Rows[i].Cells[0].Value.ToString()), double.Parse(dataGridView4.Rows[i].Cells[11].Value.ToString()));
                    }
                    for (int i = 0; i < dataGridView5.Rows.Count - 1; i++)
                    {
                        chart1.Series["Даалгавар"].Points.AddXY(Convert.ToDateTime(dataGridView5.Rows[i].Cells[0].Value.ToString()), double.Parse(dataGridView5.Rows[i].Cells[1].Value.ToString()));
                    }
                



                if (dataGridView3.Rows.Count > 0)
                {
                    //         label385.Text = "" + Math.Round(Convert.ToDouble(dataGridView3.Rows[0].Cells[1].Value), 2).ToString() + " МВт";
                    //         label386.Text = "" + Math.Round(Convert.ToDouble(dataGridView3.Rows[0].Cells[2].Value), 2).ToString() + " МВт";
                    //         label387.Text = "" + Math.Round(Convert.ToDouble(dataGridView3.Rows[0].Cells[3].Value), 2).ToString() + " МВт";
                    //         label388.Text = "" + Math.Round(Convert.ToDouble(dataGridView3.Rows[0].Cells[4].Value), 2).ToString() + " МВт";
                    label2.Text = Math.Round((Math.Round(Convert.ToDouble(dataGridView3.Rows[0].Cells[1].Value), 3) + Math.Round(Convert.ToDouble(dataGridView3.Rows[0].Cells[2].Value), 3) + Math.Round(Convert.ToDouble(dataGridView3.Rows[0].Cells[3].Value), 3) + Math.Round(Convert.ToDouble(dataGridView3.Rows[0].Cells[4].Value), 3)), 2).ToString() + " МВт";
                }
                else
                {
                    label385.Text = 0.ToString();
                    label386.Text = 0.ToString();
                    label387.Text = 0.ToString();
                    label388.Text = 0.ToString();
                    label2.Text = 0.ToString();
                }
                if (dataGridView4.Rows.Count > 0)
                {
                    //                label389.Text = "" + Math.Round(Convert.ToDouble(dataGridView4.Rows[0].Cells[1].Value), 2).ToString() + " МВт";
                    //                label390.Text = "" + Math.Round(Convert.ToDouble(dataGridView4.Rows[0].Cells[2].Value), 2).ToString() + " МВт";
                    //                label391.Text = "" + Math.Round(Convert.ToDouble(dataGridView4.Rows[0].Cells[3].Value), 2).ToString() + " МВт";
                    //               label392.Text = "" + Math.Round(Convert.ToDouble(dataGridView4.Rows[0].Cells[4].Value), 2).ToString() + " МВт";
                    label393.Text = "" + Math.Round(Convert.ToDouble(dataGridView4.Rows[0].Cells[5].Value), 2).ToString() + " МВт";
                    //             label13.Text = Math.Round((Math.Round(Convert.ToDouble(dataGridView4.Rows[0].Cells[1].Value), 3) + Math.Round(Convert.ToDouble(dataGridView4.Rows[0].Cells[2].Value), 3) + Math.Round(Convert.ToDouble(dataGridView4.Rows[0].Cells[3].Value), 3) + Math.Round(Convert.ToDouble(dataGridView4.Rows[0].Cells[4].Value), 3) + Math.Round(Convert.ToDouble(dataGridView4.Rows[0].Cells[5].Value), 3)), 2).ToString() + " МВт";
                    label49.Text = Math.Round(Convert.ToDouble(dataGridView4.Rows[0].Cells[11].Value), 2).ToString() + " МВт";
                    label52.Text = Math.Round(Convert.ToDouble(dataGridView4.Rows[0].Cells[10].Value), 2).ToString() + " МВт";
                }
                else
                {
                    label389.Text = 0.ToString();
                    label390.Text = 0.ToString();
                    label391.Text = 0.ToString();
                    label392.Text = 0.ToString();
                    label393.Text = 0.ToString();
                    label13.Text = 0.ToString();
                }
              
                textBox12.Text = "0";
                textBox9.Text = "0";
                textBox6.Text = "0";

            }
            catch { }
        }
        private void graphicDund(DateTime hugatsaa)
        {
          
            DateTime guravHonogiinUmnu = DateTime.Now.AddDays(-3);
            if (hugatsaa < guravHonogiinUmnu)
            {
                SqlDataAdapter da4 = new SqlDataAdapter("select (select CONVERT (VARCHAR(8), tsag, 108) 'hh:mi:ss' ) AS Цаг, (select ROUND(tg1, 3)) AS ТГ1, (select ROUND(tg2, 3)) AS ТГ2, (select ROUND(tg3, 3)) AS ТГ3, (select ROUND(tg4, 3)) AS ТГ4, (select ROUND(niilber, 3)) AS Нийлбэр from dund where (select DATEPART(dd, tsag))=@unuudurdund and (select DATEPART(mm, tsag))=@odoogiinsardund  and (select DATEPART(yy, tsag))=@jildund ORDER BY id DESC", con);
                da4.SelectCommand.Parameters.AddWithValue("@unuudurdund", hugatsaa.Day);
                da4.SelectCommand.Parameters.AddWithValue("@odoogiinsardund", hugatsaa.Month);
                da4.SelectCommand.Parameters.AddWithValue("@jildund", hugatsaa.Year);
                DataSet ds4 = new DataSet();
                da4.Fill(ds4, "dund");
                table_maxd = ds4.Tables[0];
                dataGridView3.DataSource = ds4.Tables[0];
            }
            else
            {
                SqlDataAdapter da4 = new SqlDataAdapter("select (select CONVERT (VARCHAR(8), tsag, 108) 'hh:mi:ss' ) AS Цаг, (select ROUND(tg1, 3)) AS ТГ1, (select ROUND(tg2, 3)) AS ТГ2, (select ROUND(tg3, 3)) AS ТГ3, (select ROUND(tg4, 3)) AS ТГ4, (select ROUND(niilber, 3)) AS Нийлбэр from dund1 where (select DATEPART(dd, tsag))=@unuudurdund and (select DATEPART(mm, tsag))=@odoogiinsardund  and (select DATEPART(yy, tsag))=@jildund ORDER BY id DESC", con);
                da4.SelectCommand.Parameters.AddWithValue("@unuudurdund", hugatsaa.Day);
                da4.SelectCommand.Parameters.AddWithValue("@odoogiinsardund", hugatsaa.Month);
                da4.SelectCommand.Parameters.AddWithValue("@jildund", hugatsaa.Year);
                DataSet ds4 = new DataSet();
                da4.Fill(ds4, "dund");
                table_maxd = ds4.Tables[0];
                dataGridView3.DataSource = ds4.Tables[0];
            }
            if (chart2.ChartAreas.Count >= 0)
            {
                chart2.ChartAreas.Clear();
                chart2.ChartAreas.Add("Дунд");
                chart2.ChartAreas["Дунд"].AxisX.MinorGrid.Enabled = true;
            }
            if (chart2.Series.Count >= 0)
            {
                chart2.Series.Clear();
                chart2.Series.Add("ТГ1");
                chart2.Series.Add("ТГ2");
                chart2.Series.Add("ТГ3");
                chart2.Series.Add("ТГ4");
                chart2.Series.Add("Нийлбэр");
                chart2.Series["ТГ1"].ChartArea = "Дунд";
                chart2.Series["ТГ2"].ChartArea = "Дунд";
                chart2.Series["ТГ3"].ChartArea = "Дунд";
                chart2.Series["ТГ4"].ChartArea = "Дунд";
                chart2.Series["Нийлбэр"].ChartArea = "Дунд";
                chart2.Series["ТГ1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
                chart2.Series["ТГ1"].Color = Color.Black;
                chart2.Series["ТГ1"].BorderWidth = 2;
                chart2.Series["ТГ1"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
                chart2.Series["ТГ2"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
                chart2.Series["ТГ2"].Color = Color.Blue;
                chart2.Series["ТГ2"].BorderWidth = 2;
                chart2.Series["ТГ2"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
                chart2.Series["ТГ3"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
                chart2.Series["ТГ3"].Color = Color.Green;
                chart2.Series["ТГ3"].BorderWidth = 2;
                chart2.Series["ТГ3"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
                chart2.Series["ТГ4"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
                chart2.Series["ТГ4"].Color = Color.Brown;
                chart2.Series["ТГ4"].BorderWidth = 2;
                chart2.Series["ТГ4"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
                chart2.Series["Нийлбэр"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
                chart2.Series["Нийлбэр"].Color = Color.Red;
                chart2.Series["Нийлбэр"].BorderWidth = 2;
                chart2.Series["Нийлбэр"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
            }
            for (int i = 0; i < dataGridView3.Rows.Count - 1; i++)
            {
                chart2.Series["ТГ1"].Points.AddXY(Convert.ToDateTime(dataGridView3.Rows[i].Cells[0].Value.ToString()), double.Parse(dataGridView3.Rows[i].Cells[1].Value.ToString()));
                chart2.Series["ТГ2"].Points.AddXY(Convert.ToDateTime(dataGridView3.Rows[i].Cells[0].Value.ToString()), double.Parse(dataGridView3.Rows[i].Cells[2].Value.ToString()));
                chart2.Series["ТГ3"].Points.AddXY(Convert.ToDateTime(dataGridView3.Rows[i].Cells[0].Value.ToString()), double.Parse(dataGridView3.Rows[i].Cells[3].Value.ToString()));
                chart2.Series["ТГ4"].Points.AddXY(Convert.ToDateTime(dataGridView3.Rows[i].Cells[0].Value.ToString()), double.Parse(dataGridView3.Rows[i].Cells[4].Value.ToString()));
                chart2.Series["Нийлбэр"].Points.AddXY(Convert.ToDateTime(dataGridView3.Rows[i].Cells[0].Value.ToString()), double.Parse(dataGridView3.Rows[i].Cells[5].Value.ToString()));
            }
        }
        private void graphicUndur(DateTime hugatsaa)
        {
            DateTime guravHonogiinUmnu = DateTime.Now.AddDays(-3);
            if (hugatsaa < guravHonogiinUmnu)
            {
                SqlDataAdapter da5 = new SqlDataAdapter("select (select CONVERT (VARCHAR(8), tsag, 108) 'hh:mi:ss' ) AS Цаг, (select ROUND(tg5, 3)) AS ТГ5, (select ROUND(tg6, 3)) AS ТГ6, (select ROUND(tg7, 3)) AS ТГ7, (select ROUND(tg8, 3)) AS ТГ8, (select ROUND(tg9, 3)) AS ТГ9, (select ROUND(niilber, 3)) AS Нийлбэр, (select ROUND(niit, 3)) AS Нийт from undur where (select DATEPART(dd, tsag))=@unuudurundur and (select DATEPART(mm, tsag))=@odoogiinsarundur and (select DATEPART(yy, tsag))=@jilundur ORDER BY id DESC", con);
                da5.SelectCommand.Parameters.AddWithValue("@unuudurundur", hugatsaa.Day);
                da5.SelectCommand.Parameters.AddWithValue("@odoogiinsarundur", hugatsaa.Month);
                da5.SelectCommand.Parameters.AddWithValue("@jilundur", hugatsaa.Year);
                DataSet ds5 = new DataSet();
                da5.Fill(ds5, "undur");
                table_maxu = ds5.Tables[0];
                dataGridView4.DataSource = ds5.Tables[0];
            }
            else
            {
                SqlDataAdapter da5 = new SqlDataAdapter("select (select CONVERT (VARCHAR(8), tsag, 108) 'hh:mi:ss' ) AS Цаг, (select ROUND(tg5, 3)) AS ТГ5, (select ROUND(tg6, 3)) AS ТГ6, (select ROUND(tg7, 3)) AS ТГ7, (select ROUND(tg8, 3)) AS ТГ8, (select ROUND(tg9, 3)) AS ТГ9, (select ROUND(niilber, 3)) AS Нийлбэр, (select ROUND(niit, 3)) AS Нийт from undur1 where (select DATEPART(dd, tsag))=@unuudurundur and (select DATEPART(mm, tsag))=@odoogiinsarundur and (select DATEPART(yy, tsag))=@jilundur ORDER BY id DESC", con);
                da5.SelectCommand.Parameters.AddWithValue("@unuudurundur", hugatsaa.Day);
                da5.SelectCommand.Parameters.AddWithValue("@odoogiinsarundur", hugatsaa.Month);
                da5.SelectCommand.Parameters.AddWithValue("@jilundur", hugatsaa.Year);
                DataSet ds5 = new DataSet();
                da5.Fill(ds5, "undur");
                table_maxu = ds5.Tables[0];
                dataGridView4.DataSource = ds5.Tables[0];
            }
            if (chart3.ChartAreas.Count >= 0)
            {
                chart3.ChartAreas.Clear();
                chart3.ChartAreas.Add("Өндөр");
                chart3.ChartAreas["Өндөр"].AxisX.MinorGrid.Enabled = true;
            }
            if (chart3.Series.Count >= 0)
            {
                chart3.Series.Clear();
                chart3.Series.Add("ТГ5");
                chart3.Series.Add("ТГ6");
                chart3.Series.Add("ТГ7");
                chart3.Series.Add("ТГ8");
                chart3.Series.Add("ТГ9");
                chart3.Series.Add("Нийлбэр");
                chart3.Series["ТГ5"].ChartArea = "Өндөр";
                chart3.Series["ТГ6"].ChartArea = "Өндөр";
                chart3.Series["ТГ7"].ChartArea = "Өндөр";
                chart3.Series["ТГ8"].ChartArea = "Өндөр";
                chart3.Series["ТГ9"].ChartArea = "Өндөр";
                chart3.Series["Нийлбэр"].ChartArea = "Өндөр";
                chart3.Series["ТГ5"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
                chart3.Series["ТГ5"].Color = Color.Black;
                chart3.Series["ТГ5"].BorderWidth = 2;
                chart3.Series["ТГ5"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
                chart3.Series["ТГ6"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
                chart3.Series["ТГ6"].Color = Color.Blue;
                chart3.Series["ТГ6"].BorderWidth = 2;
                chart3.Series["ТГ6"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
                chart3.Series["ТГ7"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
                chart3.Series["ТГ7"].Color = Color.Brown;
                chart3.Series["ТГ7"].BorderWidth = 2;
                chart3.Series["ТГ7"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
                chart3.Series["ТГ8"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
                chart3.Series["ТГ8"].Color = Color.Indigo;
                chart3.Series["ТГ8"].BorderWidth = 2;
                chart3.Series["ТГ8"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
                chart3.Series["ТГ9"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
                chart3.Series["ТГ9"].Color = Color.Green;
                chart3.Series["ТГ9"].BorderWidth = 2;
                chart3.Series["ТГ9"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
                chart3.Series["Нийлбэр"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
                chart3.Series["Нийлбэр"].Color = Color.Red;
                chart3.Series["Нийлбэр"].BorderWidth = 2;
                chart3.Series["Нийлбэр"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
            }
            for (int i = 0; i < dataGridView4.Rows.Count - 1; i++)
            {
                chart3.Series["ТГ5"].Points.AddXY(Convert.ToDateTime(dataGridView4.Rows[i].Cells[0].Value.ToString()), double.Parse(dataGridView4.Rows[i].Cells[1].Value.ToString()));
                chart3.Series["ТГ6"].Points.AddXY(Convert.ToDateTime(dataGridView4.Rows[i].Cells[0].Value.ToString()), double.Parse(dataGridView4.Rows[i].Cells[2].Value.ToString()));
                chart3.Series["ТГ7"].Points.AddXY(Convert.ToDateTime(dataGridView4.Rows[i].Cells[0].Value.ToString()), double.Parse(dataGridView4.Rows[i].Cells[3].Value.ToString()));
                chart3.Series["ТГ8"].Points.AddXY(Convert.ToDateTime(dataGridView4.Rows[i].Cells[0].Value.ToString()), double.Parse(dataGridView4.Rows[i].Cells[4].Value.ToString()));
                chart3.Series["ТГ9"].Points.AddXY(Convert.ToDateTime(dataGridView4.Rows[i].Cells[0].Value.ToString()), double.Parse(dataGridView4.Rows[i].Cells[5].Value.ToString()));
                chart3.Series["Нийлбэр"].Points.AddXY(Convert.ToDateTime(dataGridView4.Rows[i].Cells[0].Value.ToString()), double.Parse(dataGridView4.Rows[i].Cells[6].Value.ToString()));
            }
        }
        private void daalgavarTab(DateTime hugatsaa)
        {
            SqlDataAdapter da = new SqlDataAdapter("select (select CONVERT (VARCHAR(8), tsag, 108) 'hh:mi:ss' ) AS Цаг, (select ROUND(tg1, 3)) AS ТГ1, (select ROUND(tg2, 3)) AS ТГ2, (select ROUND(tg3, 3)) AS ТГ3, (select ROUND(tg4, 3)) AS ТГ4, (select ROUND(tg5, 3)) AS ТГ5, (select ROUND(tg6, 3)) AS ТГ6, (select ROUND(tg7, 3)) AS ТГ7, (select ROUND(tg8, 3)) AS ТГ8, (select ROUND(tg9, 3)) AS ТГ9 from mashin where (select DATEPART(dd, tsag))=@unuudur and (select DATEPART(mm, tsag))=@odoogiinsar and (select DATEPART(yy, tsag))=@jil ORDER BY id DESC", con);
            da.SelectCommand.Parameters.AddWithValue("@unuudur", hugatsaa.Day);
            da.SelectCommand.Parameters.AddWithValue("@odoogiinsar", hugatsaa.Month);
            da.SelectCommand.Parameters.AddWithValue("@jil", hugatsaa.Year);
            DataSet ds = new DataSet();
            da.Fill(ds, "mashin");
            dataGridView2.DataSource = ds.Tables[0];

            SqlDataAdapter da1 = new SqlDataAdapter("select (select CONVERT (VARCHAR(8), tsag, 108) 'hh:mi:ss' ) AS Цаг, (select ROUND(undur, 3)) AS Өндөр, (select ROUND(dund, 3)) AS Дунд, (select ROUND(niilber, 3)) AS Нийлбэр from bolowsruulalt where (select DATEPART(dd, tsag))=@unuudur1 and (select DATEPART(mm, tsag))=@odoogiinsar1  and (select DATEPART(yy, tsag))=@jil1 ORDER BY id DESC", con);
            da1.SelectCommand.Parameters.AddWithValue("@unuudur1", hugatsaa.Day);
            da1.SelectCommand.Parameters.AddWithValue("@odoogiinsar1", hugatsaa.Month);
            da1.SelectCommand.Parameters.AddWithValue("@jil1", hugatsaa.Year);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1, "bolowsruulalt");
            dataGridView1.DataSource = ds1.Tables[0];

            SqlDataAdapter da3 = new SqlDataAdapter("select (select CONVERT (VARCHAR(8), tsag, 108) 'hh:mi:ss' ) AS Цаг, (select ROUND(daalgawar, 3)) AS Даалгавар, (select ROUND(daalgawar1, 3)) AS Даалгавар1 from daalgawar where (select DATEPART(dd, tsag))=@unuudur1 and (select DATEPART(mm, tsag))=@odoogiinsardaalgawar and (select DATEPART(yy, tsag))=@jildaalgawar ORDER BY id ASC", con);
            da3.SelectCommand.Parameters.AddWithValue("@unuudur1", hugatsaa.Day);
            da3.SelectCommand.Parameters.AddWithValue("@odoogiinsardaalgawar", hugatsaa.Month);
            da3.SelectCommand.Parameters.AddWithValue("@jildaalgawar", hugatsaa.Year);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3, "daalgawar");

            dataGridView5.DataSource = ds3.Tables[0];

            #region bodoh
            SqlConnection con1 = new SqlConnection();
            con1.ConnectionString = @"Server=192.168.20.85;Database=UI_hyanalt;User Id=hereglegch; Password=Passwd_123;";
            SqlDataAdapter daTuluv = new SqlDataAdapter("select *from Parameters order by id asc", con1);
            DataSet dsTuluv = new DataSet();
            daTuluv.Fill(dsTuluv, "negro");
            table = dsTuluv.Tables[0];

            if (Convert.ToInt16(table.Rows[46][8]) == 1)
            {
                comboBox1.SelectedIndex = 0;
            }
            if (Convert.ToInt16(table.Rows[46][8]) == 0)
            {
                comboBox1.SelectedIndex = 1;
            }

            if (Convert.ToInt16(table.Rows[47][8]) == 1)
            {
                comboBox2.SelectedIndex = 0;
            }
            if (Convert.ToInt16(table.Rows[47][8]) == 0)
            {
                comboBox2.SelectedIndex = 1;
            }

            if (Convert.ToInt16(table.Rows[48][8]) == 1)
            {
                comboBox3.SelectedIndex = 0;
            }
            if (Convert.ToInt16(table.Rows[48][8]) == 0)
            {
                comboBox3.SelectedIndex = 1;
            }

            if (Convert.ToInt16(table.Rows[49][8]) == 1)
            {
                comboBox4.SelectedIndex = 0;
            }
            if (Convert.ToInt16(table.Rows[49][8]) == 0)
            {
                comboBox4.SelectedIndex = 1;
            }

            if (Convert.ToInt16(table.Rows[50][8]) == 1)
            {
                comboBox5.SelectedIndex = 0;
            }
            if (Convert.ToInt16(table.Rows[50][8]) == 0)
            {
                comboBox5.SelectedIndex = 1;
            }

            if (Convert.ToInt16(table.Rows[51][8]) == 1)
            {
                comboBox6.SelectedIndex = 0;
            }
            if (Convert.ToInt16(table.Rows[51][8]) == 0)
            {
                comboBox6.SelectedIndex = 1;
            }

            if (Convert.ToInt16(table.Rows[52][8]) == 1)
            {
                comboBox7.SelectedIndex = 0;
            }
            if (Convert.ToInt16(table.Rows[52][8]) == 0)
            {
                comboBox7.SelectedIndex = 1;
            }

            if (Convert.ToInt16(table.Rows[53][8]) == 1)
            {
                comboBox8.SelectedIndex = 0;
            }
            if (Convert.ToInt16(table.Rows[53][8]) == 0)
            {
                comboBox8.SelectedIndex = 1;
            }

            if (Convert.ToInt16(table.Rows[54][8]) == 1)
            {
                comboBox9.SelectedIndex = 0;
            }
            if (Convert.ToInt16(table.Rows[54][8]) == 0)
            {
                comboBox9.SelectedIndex = 1;
            }

            if (Convert.ToInt16(table.Rows[55][8]) == 1)
            {
                comboBox10.SelectedIndex = 0;
            }
            if (Convert.ToInt16(table.Rows[55][8]) == 0)
            {
                comboBox10.SelectedIndex = 1;
            }

            if (Convert.ToInt16(table.Rows[57][8]) == 1)
            {
                comboBox11.SelectedIndex = 0;
            }
            if (Convert.ToInt16(table.Rows[57][8]) == 0)
            {
                comboBox11.SelectedIndex = 1;
            }

            if (Convert.ToInt16(table.Rows[59][8]) == 1)
            {
                comboBox12.SelectedIndex = 0;
            }
            if (Convert.ToInt16(table.Rows[59][8]) == 0)
            {
                comboBox12.SelectedIndex = 1;
            }

            if (Convert.ToInt16(table.Rows[60][8]) == 1)
            {
                comboBox13.SelectedIndex = 0;
            }
            if (Convert.ToInt16(table.Rows[60][8]) == 0)
            {
                comboBox13.SelectedIndex = 1;
            }

            if (Convert.ToInt16(table.Rows[61][8]) == 1)
            {
                comboBox14.SelectedIndex = 0;
            }
            if (Convert.ToInt16(table.Rows[61][8]) == 0)
            {
                comboBox14.SelectedIndex = 1;
            }

            if (Convert.ToInt16(table.Rows[62][8]) == 1)
            {
                comboBox15.SelectedIndex = 0;
            }
            if (Convert.ToInt16(table.Rows[62][8]) == 0)
            {
                comboBox15.SelectedIndex = 1;
            }

            if (Convert.ToInt16(table.Rows[64][8]) == 1)
            {
                comboBox16.SelectedIndex = 0;
            }
            if (Convert.ToInt16(table.Rows[64][8]) == 0)
            {
                comboBox16.SelectedIndex = 1;
            }

            if (Convert.ToInt16(table.Rows[65][8]) == 1)
            {
                comboBox17.SelectedIndex = 0;
            }
            if (Convert.ToInt16(table.Rows[65][8]) == 0)
            {
                comboBox17.SelectedIndex = 1;
            }

            if (Convert.ToInt16(table.Rows[56][8]) == 1)
            {
                comboBox18.SelectedIndex = 0;
            }
            if (Convert.ToInt16(table.Rows[56][8]) == 0)
            {
                comboBox18.SelectedIndex = 1;
            }

            if (Convert.ToInt16(table.Rows[58][8]) == 1)
            {
                comboBox19.SelectedIndex = 0;
            }
            if (Convert.ToInt16(table.Rows[58][8]) == 0)
            {
                comboBox19.SelectedIndex = 1;
            }

            if (Convert.ToInt16(table.Rows[66][8]) == 1)
            {
                comboBox20.SelectedIndex = 0;
            }
            if (Convert.ToInt16(table.Rows[66][8]) == 0)
            {
                comboBox20.SelectedIndex = 1;
            }

            if (Convert.ToInt16(table.Rows[67][8]) == 1)
            {
                comboBox21.SelectedIndex = 0;
            }
            if (Convert.ToInt16(table.Rows[67][8]) == 0)
            {
                comboBox21.SelectedIndex = 1;
            }

            if (Convert.ToInt16(table.Rows[16][8]) == 1)
            {
                comboBox22.SelectedIndex = 0;
            }
            if (Convert.ToInt16(table.Rows[16][8]) == 0)
            {
                comboBox22.SelectedIndex = 1;
            }

            if (Convert.ToInt16(table.Rows[17][8]) == 1)
            {
                comboBox23.SelectedIndex = 0;
            }
            if (Convert.ToInt16(table.Rows[17][8]) == 0)
            {
                comboBox23.SelectedIndex = 1;
            }

            if (Convert.ToInt16(table.Rows[63][8]) == 1)
            {
                comboBox24.SelectedIndex = 0;
            }
            if (Convert.ToInt16(table.Rows[63][8]) == 0)
            {
                comboBox24.SelectedIndex = 1;
            }

            if (Convert.ToInt16(table.Rows[19][8]) == 1)
            {
                comboBox25.SelectedIndex = 0;
            }
            if (Convert.ToInt16(table.Rows[19][8]) == 0)
            {
                comboBox25.SelectedIndex = 1;
            }
            #endregion
        }
        private void Reactive_CosTab(DateTime hugatsaa)
        {

            SqlDataAdapter da8 = new SqlDataAdapter("select (select CONVERT (VARCHAR(8), tsag, 108) 'hh:mi:ss' ) AS Цаг,  (select ROUND(tg1, 3)) AS ТГ1, (select ROUND(tg2, 3)) AS ТГ2, (select ROUND(tg3, 3)) AS ТГ3, (select ROUND(tg4, 3)) AS ТГ4, (select ROUND(tg5, 3)) AS ТГ5, (select ROUND(tg6, 3)) AS ТГ6, (select ROUND(tg7, 3)) AS ТГ7, (select ROUND(tg8, 3)) AS ТГ8, (select ROUND(tg9, 3)) AS ТГ9, (select ROUND(t1, 3)) AS Т1, (select ROUND(t2, 3)) AS Т2 from pf where (select DATEPART(dd, tsag))=@unuudurpf and (select DATEPART(mm, tsag))=@pfodoogiinsar and (select DATEPART(yy, tsag))=@pfodoogiinjil ORDER BY id DESC", con);
            da8.SelectCommand.Parameters.AddWithValue("@unuudurpf", hugatsaa.Day);
            da8.SelectCommand.Parameters.AddWithValue("@pfodoogiinsar", hugatsaa.Month);
            da8.SelectCommand.Parameters.AddWithValue("@pfodoogiinjil", hugatsaa.Year);
            DataSet ds8 = new DataSet();
            da8.Fill(ds8, "pf");
            dataGridView15.DataSource = ds8.Tables[0];

            SqlDataAdapter da9 = new SqlDataAdapter("select (select CONVERT (VARCHAR(8), tsag, 108) 'hh:mi:ss' ) AS Цаг,  (select ROUND(tg1, 3)) AS ТГ1, (select ROUND(tg2, 3)) AS ТГ2, (select ROUND(tg3, 3)) AS ТГ3, (select ROUND(tg4, 3)) AS ТГ4, (select ROUND(tg5, 3)) AS ТГ5, (select ROUND(tg6, 3)) AS ТГ6, (select ROUND(tg7, 3)) AS ТГ7, (select ROUND(tg8, 3)) AS ТГ8, (select ROUND(tg9, 3)) AS ТГ9, (select ROUND(dund, 3)) AS Дунд, (select ROUND(undur, 3)) AS Өндөр, (select ROUND(niit, 3)) AS Нийт from reactiveReal where (select DATEPART(dd, tsag))=@unuudurreactiveReal and (select DATEPART(mm, tsag))=@odoogiinsarreactiveReal and (select DATEPART(yy, tsag))=@jilreactiveReal ORDER BY id DESC", con);
            da9.SelectCommand.Parameters.AddWithValue("@unuudurreactiveReal", hugatsaa.Day);
            da9.SelectCommand.Parameters.AddWithValue("@odoogiinsarreactiveReal", hugatsaa.Month);
            da9.SelectCommand.Parameters.AddWithValue("@jilreactiveReal", hugatsaa.Year);
            DataSet ds9 = new DataSet();
            da9.Fill(ds9, "reactiveReal");
            dataGridView19.DataSource = ds9.Tables[0];

            DateTime guravHonogiinUmnu = DateTime.Now.AddDays(-3);
            if (hugatsaa > guravHonogiinUmnu)
            {
                SqlDataAdapter da7 = new SqlDataAdapter("select (select CONVERT (VARCHAR(5), tsag, 108) 'hh:mi' ) AS Цаг,  (select ROUND(tg1, 3)) AS ТГ1, (select ROUND(tg2, 3)) AS ТГ2, (select ROUND(tg3, 3)) AS ТГ3, (select ROUND(tg4, 3)) AS ТГ4, (select ROUND(tg5, 3)) AS ТГ5, (select ROUND(tg6, 3)) AS ТГ6, (select ROUND(tg7, 3)) AS ТГ7, (select ROUND(tg8, 3)) AS ТГ8, (select ROUND(tg9, 3)) AS ТГ9, (select ROUND(t1avsan, 3)) AS Т1индуктив, (select ROUND(t1ogson, 3)) AS Т1багтаамжит, (select ROUND(t2avsan, 3)) AS Т2индуктив, (select ROUND(t2ogson, 3)) AS Т2багтаамжит, (select ROUND(BTR5, 3)) AS БТР5, (select ROUND(BTR6, 3)) AS БТР6, (select ROUND(BTR7, 3)) AS БТР7, (select ROUND(BTR8, 3)) AS БТР8, (select ROUND(BTR9, 3)) AS БТР9 from reactive where (select DATEPART(dd, tsag))=@unuudurreactive and (select DATEPART(mm, tsag))=@reactiveodoogiinsar  and (select DATEPART(yy, tsag))=@reactivejil ORDER BY id DESC", con);
                da7.SelectCommand.Parameters.AddWithValue("@unuudurreactive", hugatsaa.Day);
                da7.SelectCommand.Parameters.AddWithValue("@reactiveodoogiinsar", hugatsaa.Month);
                da7.SelectCommand.Parameters.AddWithValue("@reactivejil", hugatsaa.Year);
                DataSet ds7 = new DataSet();
                da7.Fill(ds7, "reactive");
                dataGridView14.DataSource = ds7.Tables[0];
            }
            else
            {
                SqlDataAdapter da7 = new SqlDataAdapter("select (select CONVERT (VARCHAR(5), tsag, 108) 'hh:mi' ) AS Цаг,  (select ROUND(tg1, 3)) AS ТГ1, (select ROUND(tg2, 3)) AS ТГ2, (select ROUND(tg3, 3)) AS ТГ3, (select ROUND(tg4, 3)) AS ТГ4, (select ROUND(tg5, 3)) AS ТГ5, (select ROUND(tg6, 3)) AS ТГ6, (select ROUND(tg7, 3)) AS ТГ7, (select ROUND(tg8, 3)) AS ТГ8, (select ROUND(tg9, 3)) AS ТГ9, (select ROUND(t1avsan, 3)) AS Т1индуктив, (select ROUND(t1ogson, 3)) AS Т1багтаамжит, (select ROUND(t2avsan, 3)) AS Т2индуктив, (select ROUND(t2ogson, 3)) AS Т2багтаамжит, (select ROUND(BTR5, 3)) AS БТР5, (select ROUND(BTR6, 3)) AS БТР6, (select ROUND(BTR7, 3)) AS БТР7, (select ROUND(BTR8, 3)) AS БТР8, (select ROUND(BTR9, 3)) AS БТР9 from reactive1 where (select DATEPART(dd, tsag))=@unuudurreactive and (select DATEPART(mm, tsag))=@reactiveodoogiinsar  and (select DATEPART(yy, tsag))=@reactivejil ORDER BY id DESC", con);
                da7.SelectCommand.Parameters.AddWithValue("@unuudurreactive", hugatsaa.Day);
                da7.SelectCommand.Parameters.AddWithValue("@reactiveodoogiinsar", hugatsaa.Month);
                da7.SelectCommand.Parameters.AddWithValue("@reactivejil", hugatsaa.Year);
                DataSet ds7 = new DataSet();
                da7.Fill(ds7, "reactive");
                dataGridView14.DataSource = ds7.Tables[0];
            }
            if (dataGridView14.Rows.Count > 1)
            {
                dataGridView17.Rows.Clear();
                dataGridView17.Rows.Add(dataGridView14.Rows.Count);
                for (int i = 0; i < dataGridView14.Rows.Count; i++)
                {
                    dataGridView17[0, i].Value = dataGridView14[0, i].Value;
                }
                niilber[2] = 0; niilber[3] = 0; niilber[4] = 0; niilber[5] = 0; niilber[6] = 0; niilber[7] = 0; niilber[8] = 0; niilber[9] = 0; niilber[10] = 0; niilber[11] = 0; niilber[12] = 0; niilber[13] = 0; niilber[14] = 0;
                try
                {
                    for (int i = dataGridView14.Rows.Count - 1; i < dataGridView14.Rows.Count; i--)
                    {
                        dataGridView17[1, i - 1].Value = (Convert.ToDecimal(dataGridView14[1, i - 1].Value) - Convert.ToDecimal(dataGridView14[1, i].Value)) * 18;
                        dataGridView17[2, i - 1].Value = (Convert.ToDecimal(dataGridView14[2, i - 1].Value) - Convert.ToDecimal(dataGridView14[2, i].Value)) * 18;
                        dataGridView17[3, i - 1].Value = (Convert.ToDecimal(dataGridView14[3, i - 1].Value) - Convert.ToDecimal(dataGridView14[3, i].Value)) * 18;
                        dataGridView17[4, i - 1].Value = (Convert.ToDecimal(dataGridView14[4, i - 1].Value) - Convert.ToDecimal(dataGridView14[4, i].Value)) * 18;
                        dataGridView17[5, i - 1].Value = (Convert.ToDecimal(dataGridView14[5, i - 1].Value) - Convert.ToDecimal(dataGridView14[5, i].Value)) * 48;
                        dataGridView17[6, i - 1].Value = (Convert.ToDecimal(dataGridView14[6, i - 1].Value) - Convert.ToDecimal(dataGridView14[6, i].Value)) * 48;
                        dataGridView17[7, i - 1].Value = (Convert.ToDecimal(dataGridView14[7, i - 1].Value) - Convert.ToDecimal(dataGridView14[7, i].Value)) * 48;
                        dataGridView17[8, i - 1].Value = (Convert.ToDecimal(dataGridView14[8, i - 1].Value) - Convert.ToDecimal(dataGridView14[8, i].Value)) * 48;
                        dataGridView17[9, i - 1].Value = (Convert.ToDecimal(dataGridView14[9, i - 1].Value) - Convert.ToDecimal(dataGridView14[9, i].Value)) * 105;
                        dataGridView17[10, i - 1].Value = (Convert.ToDecimal(dataGridView17[1, i - 1].Value) + Convert.ToDecimal(dataGridView17[2, i - 1].Value) + Convert.ToDecimal(dataGridView17[3, i - 1].Value) + Convert.ToDecimal(dataGridView17[4, i - 1].Value));
                        dataGridView17[11, i - 1].Value = (Convert.ToDecimal(dataGridView17[5, i - 1].Value) + Convert.ToDecimal(dataGridView17[6, i - 1].Value) + Convert.ToDecimal(dataGridView17[7, i - 1].Value) + Convert.ToDecimal(dataGridView17[8, i - 1].Value) + Convert.ToDecimal(dataGridView17[9, i - 1].Value));
                        dataGridView17[12, i - 1].Value = (Convert.ToDecimal(dataGridView17[10, i - 1].Value) + Convert.ToDecimal(dataGridView17[11, i - 1].Value));
                    }
                }
                catch { }
            }
        }
        private void BTRTab(DateTime hugatsaa)
        {
            SqlConnection con1 = new SqlConnection();
            con1.ConnectionString = @"Server=192.168.20.85;Database=tootsooloh;User Id=hereglegch; Password=Passwd_123;";

            SqlDataAdapter da15 = new SqlDataAdapter("select (select CONVERT (VARCHAR(8), tsag, 108) 'hh:mi:ss' ) AS Цаг, (select ROUND(btr5p, 3)) AS БТР5_P, (select ROUND(btr5q, 3)) AS БТР5_Q, (select ROUND(btr5cos, 3)) AS БТР5_COS, (select ROUND(btr6p, 3)) AS БТР6_P, (select ROUND(btr6q, 3)) AS БТР6_Q, (select ROUND(btr6cos, 3)) AS БТР6_COS, (select ROUND(btr7p, 3)) AS БТР7_P, (select ROUND(btr7q, 3)) AS БТР7_Q,(select ROUND(btr7cos, 3)) AS БТР7_COS, (select ROUND(btr8p, 3)) AS БТР8_P, (select ROUND(btr8q, 3)) AS БТР8_Q, (select ROUND(btr8cos, 3)) AS БТР8_COS, (select ROUND(btr9p, 3)) AS БТР9_P, (select ROUND(btr9q, 3)) AS БТР9_Q, (select ROUND(btr9cos, 3)) AS БТР9_COS from btr where (select DATEPART(dd, tsag))=@unuudurundur and (select DATEPART(mm, tsag))=@odoogiinsarundur and (select DATEPART(yy, tsag))=@jilundur ORDER BY id DESC", con);
            da15.SelectCommand.Parameters.AddWithValue("@unuudurundur", hugatsaa.Day);
            da15.SelectCommand.Parameters.AddWithValue("@odoogiinsarundur", hugatsaa.Month);
            da15.SelectCommand.Parameters.AddWithValue("@jilundur", hugatsaa.Year);
            DataSet ds15 = new DataSet();
            da15.Fill(ds15, "BTR");
            dataGridView9.DataSource = ds15.Tables[0];
        }
        #region daalgavar database
        private void inserttodaalgawar(DateTime tsag, float daalgawar, float daalgawar1)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO daalgawara(tsag, daalgawar, daalgawar1) values (@datetime, @daalgawar11, @daalgawar22)", con);
            cmd.Parameters.AddWithValue("@datetime", tsag);
            cmd.Parameters.AddWithValue("@daalgawar11", daalgawar);
            cmd.Parameters.AddWithValue("@daalgawar22", daalgawar1);

            con.Open();
            if (cmd.ExecuteNonQuery() == 0)
            {
                MessageBox.Show("error");
            }
            con.Close();
            cmd = new SqlCommand("INSERT INTO daalgawar(tsag, daalgawar, daalgawar1) values (@datetime, @daalgawar11, @daalgawar22)", con);
            cmd.Parameters.AddWithValue("@datetime", tsag);
            cmd.Parameters.AddWithValue("@daalgawar11", daalgawar);
            cmd.Parameters.AddWithValue("@daalgawar22", daalgawar1);
            con.Open();
            if (cmd.ExecuteNonQuery() == 0)
            {
                MessageBox.Show("error");
            }
            con.Close();


            cmd = new SqlCommand("INSERT INTO daalgawar(tsag, daalgawar, daalgawar1) values (@datetime, @daalgawar11, @daalgawar22)", con_Az);
            cmd.Parameters.AddWithValue("@datetime", tsag);
            cmd.Parameters.AddWithValue("@daalgawar11", daalgawar);
            cmd.Parameters.AddWithValue("@daalgawar22", daalgawar1);
            con_Az.Open();
            if (cmd.ExecuteNonQuery() == 0)
            {
                MessageBox.Show("tele_daalgavar");
            }
            con_Az.Close();
        }
        private void inserttodaalgawar15(DateTime tsag, float daalgawar)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO daalgawara1(tsag, daalgawar) values (@datetime, @daalgawar11)", con);
            cmd.Parameters.AddWithValue("@datetime", tsag);
            cmd.Parameters.AddWithValue("@daalgawar11", daalgawar);
            con.Open();
            if (cmd.ExecuteNonQuery() == 0)
            {
                MessageBox.Show("error");
            }
            con.Close();
            cmd = new SqlCommand("INSERT INTO daalgawar1(tsag, daalgawar) values (@datetime, @daalgawar11)", con);
            cmd.Parameters.AddWithValue("@datetime", tsag);
            cmd.Parameters.AddWithValue("@daalgawar11", daalgawar);

            con.Open();
            if (cmd.ExecuteNonQuery() == 0)
            {
                MessageBox.Show("error");
            }
            con.Close();
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

            con.Open();
            cmd = new SqlCommand("UPDATE daalgawar SET tsag=@datetime, daalgawar=@daalgawar11, daalgawar1=@daalgawar22", con_Az);
            cmd.Parameters.AddWithValue("@datetime", tsag);
            cmd.Parameters.AddWithValue("@daalgawar11", daalgawar);
            cmd.Parameters.AddWithValue("@daalgawar22", daalgawar1);
            if (cmd.ExecuteNonQuery() == 0)
            {
                MessageBox.Show("error");
            }
            con_Az.Close();
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
            bolovsruulaltBodoh(dateTimePicker1.Value);
        }
        private void graphicTimer_Tick(object sender, EventArgs e)
        {
            graphic(dateTimePicker1.Value);
        }

        private void graphicDundTimer_Tick(object sender, EventArgs e)
        {
            graphicDund(dateTimePicker1.Value);
        }

        private void graphicUndurTimer_Tick(object sender, EventArgs e)
        {
            graphicUndur(dateTimePicker1.Value);
        }



        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                bolovsruulaltBodoh(dateTimePicker1.Value);
            }
            catch { }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //rds.Name = "Dataset18";

            client1 = new SimpleTcpClient();
            client1.StringEncoder = Encoding.UTF8;
            client1.DataReceived += Client1_DataReceived;

            client = new SimpleTcpClient();
            client.StringEncoder = Encoding.UTF8;
            comboBox26.SelectedIndex = 0;

            solidGauge1.Base.LabelsVisibility = System.Windows.Visibility.Hidden;
            solidGauge1.Base.GaugeBackground = new System.Windows.Media.LinearGradientBrush
            {
                GradientStops = new System.Windows.Media.GradientStopCollection
                {
                    new System.Windows.Media.GradientStop(System.Windows.Media.Colors.Green,0),
                    new System.Windows.Media.GradientStop(System.Windows.Media.Colors.Red,0),
                    new System.Windows.Media.GradientStop (System.Windows.Media.Colors.Blue,255)
                }
            };
            solidGauge2.Base.LabelsVisibility = System.Windows.Visibility.Hidden;
            solidGauge2.Base.GaugeBackground = new System.Windows.Media.LinearGradientBrush
            {
                GradientStops = new System.Windows.Media.GradientStopCollection
                {
                new System.Windows.Media.GradientStop(System.Windows.Media.Colors.Green,0),
                new System.Windows.Media.GradientStop(System.Windows.Media.Colors.Red,0),
                new System.Windows.Media.GradientStop (System.Windows.Media.Colors.Blue,255)
                }
            };
            solidGauge3.Base.LabelsVisibility = System.Windows.Visibility.Hidden;
            solidGauge3.Base.GaugeBackground = new System.Windows.Media.LinearGradientBrush
            {
                GradientStops = new System.Windows.Media.GradientStopCollection
                {
                new System.Windows.Media.GradientStop(System.Windows.Media.Colors.Green,0),
                new System.Windows.Media.GradientStop(System.Windows.Media.Colors.Red,0),
                new System.Windows.Media.GradientStop (System.Windows.Media.Colors.Blue,255)
                }
            };
            chart4.Series["Бол"].Points.AddY(1);
            chart4.Series["Түг"].Points.AddY(1);
            chart4.Series["ДХ"].Points.AddY(1);
            generalSchem.blDateStart = DateTime.Today.ToString();
            generalSchem.blDateStop = DateTime.Now.AddMinutes(-DateTime.Now.Minute + 1).AddSeconds(-DateTime.Now.Second + 1).ToString();
            generalSchem.BalanceBodoh += new EventHandler(Balance_Bodoh);
            graphicTimer.Stop();
            graphicDundTimer.Stop();
            graphicUndurTimer.Stop();
            generalSchemTimer.Stop();
            davtamjReadTimer.Stop();
            davtamjConnectTimer.Stop();
            tootsooTimer.Start();
            dateTimerPickerEnd.Start();
            wpfDateStoptimer.Stop();
        }

        private void chart1_MouseMove(object sender, MouseEventArgs e)
        {
            var pos = e.Location;
            //  label17.Location = new Point(pos.X + 10, pos.Y + 14);

            if (prevPosition.HasValue && pos == prevPosition.Value)
                return;
            tooltip.RemoveAll();
            prevPosition = pos;
            var results = chart1.HitTest(pos.X, pos.Y, false, ChartElementType.PlottingArea);
            foreach (var result in results)
            {
                if (result.ChartElementType == ChartElementType.PlottingArea)
                {

                    var xVal = result.ChartArea.AxisX.PixelPositionToValue(pos.X);
                    var yVal = result.ChartArea.AxisY.PixelPositionToValue(pos.Y);
                    // label33.Text = yVal.ToString();
                    //   label17.Text = Math.Round(yVal, 3).ToString();

                }

            }

        }

        private void chart2_MouseMove(object sender, MouseEventArgs e)
        {
            var pos = e.Location;
            label23.Location = new Point(pos.X + 50, pos.Y + 50);

            if (prevPosition.HasValue && pos == prevPosition.Value)
                return;
            tooltip.RemoveAll();
            prevPosition = pos;
            var results = chart2.HitTest(pos.X, pos.Y, false, ChartElementType.PlottingArea);
            foreach (var result in results)
            {
                if (result.ChartElementType == ChartElementType.PlottingArea)
                {

                    var xVal = result.ChartArea.AxisX.PixelPositionToValue(pos.X);
                    var yVal = result.ChartArea.AxisY.PixelPositionToValue(pos.Y);
                    // label33.Text = yVal.ToString();
                    label23.Text = Math.Round(yVal, 3).ToString();

                }

            }

        }

        private void chart3_MouseMove(object sender, MouseEventArgs e)
        {
            var pos = e.Location;
            label33.Location = new Point(pos.X + 50, pos.Y + 50);

            if (prevPosition.HasValue && pos == prevPosition.Value)
                return;
            tooltip.RemoveAll();
            prevPosition = pos;
            var results = chart3.HitTest(pos.X, pos.Y, false, ChartElementType.PlottingArea);
            foreach (var result in results)
            {
                if (result.ChartElementType == ChartElementType.PlottingArea)
                {

                    var xVal = result.ChartArea.AxisX.PixelPositionToValue(pos.X);
                    var yVal = result.ChartArea.AxisY.PixelPositionToValue(pos.Y);
                    // label33.Text = yVal.ToString();
                    label33.Text = Math.Round(yVal, 3).ToString();

                }

            }

        }



        #region exporttoxecel
        private void ExporttoExcel(DataGridView gridviewID, string excelfilename)
        {
            Microsoft.Office.Interop.Excel._Application objexcelapp = new Microsoft.Office.Interop.Excel.Application();
            objexcelapp.Application.Workbooks.Add();
            objexcelapp.Columns.ColumnWidth = 10;
            for (int i = 1; i < gridviewID.ColumnCount + 1; i++)
            {
                objexcelapp.Cells[1, i] = gridviewID.Columns[i - 1].HeaderText;
            }
            for (int i = 0; i < gridviewID.Rows.Count; i++)
            {
                for (int j = 0; j < gridviewID.Columns.Count; j++)
                {
                    if (gridviewID.Rows[i].Cells[j].Value != null)
                    {
                        for (int k = 1; k < gridviewID.Rows[i].Cells[j].Value.ToString().Length; k++)
                        {
                            if (gridviewID.Rows[i].Cells[j].Value.ToString().Substring(k, 1) == ",")
                            {
                                gridviewID.Rows[i].Cells[j].Value = gridviewID.Rows[i].Cells[j].Value.ToString().Substring(0, k) + "." + gridviewID.Rows[i].Cells[j].Value.ToString().Substring((k + 1), gridviewID.Rows[i].Cells[j].Value.ToString().Length - (k + 1));
                            }
                        }
                        objexcelapp.Cells[i + 2, j + 1] = gridviewID.Rows[i].Cells[j].Value.ToString();
                    }
                }
            }
            objexcelapp.ActiveWorkbook.SaveCopyAs("D:\\" + "ok\\Заалт-3" + excelfilename + ".xlsx");
            objexcelapp.ActiveWorkbook.Saved = true;
            MessageBox.Show("хадгалагдлаа D:\\" + "ok\\Заалт-3" + excelfilename + ".xlsx");
        }
        private void ExporttoExcel1(DataGridView gridviewID, string excelfilename)
        {
            Microsoft.Office.Interop.Excel._Application objexcelapp = new Microsoft.Office.Interop.Excel.Application();
            objexcelapp.Application.Workbooks.Add();
            objexcelapp.Columns.ColumnWidth = 10;
            for (int i = 1; i < gridviewID.ColumnCount + 1; i++)
            {
                objexcelapp.Cells[1, i] = gridviewID.Columns[i - 1].HeaderText;
            }
            for (int i = 0; i < gridviewID.Rows.Count; i++)
            {
                for (int j = 0; j < gridviewID.Columns.Count; j++)
                {
                    if (gridviewID.Rows[i].Cells[j].Value != null)
                    {
                        for (int k = 1; k < gridviewID.Rows[i].Cells[j].Value.ToString().Length; k++)
                        {
                            if (gridviewID.Rows[i].Cells[j].Value.ToString().Substring(k, 1) == ",")
                            {
                                gridviewID.Rows[i].Cells[j].Value = gridviewID.Rows[i].Cells[j].Value.ToString().Substring(0, k) + "." + gridviewID.Rows[i].Cells[j].Value.ToString().Substring((k + 1), gridviewID.Rows[i].Cells[j].Value.ToString().Length - (k + 1));
                            }
                        }
                        objexcelapp.Cells[i + 2, j + 1] = gridviewID.Rows[i].Cells[j].Value.ToString();
                    }
                }
            }
            objexcelapp.ActiveWorkbook.SaveCopyAs("E:\\" + "Заалт-3 энерги " + " " + excelfilename + ".xlsx");
            objexcelapp.ActiveWorkbook.Saved = true;
            MessageBox.Show("хадгалагдлаа E:\\" + "Заалт-3 энерги " + " " + excelfilename + ".xlsx");
        }
        private void ExporttoExcel2(DataGridView gridviewID, string excelfilename)
        {
            Microsoft.Office.Interop.Excel._Application objexcelapp = new Microsoft.Office.Interop.Excel.Application();
            objexcelapp.Application.Workbooks.Add();
            objexcelapp.Columns.ColumnWidth = 10;
            for (int i = 1; i < gridviewID.ColumnCount + 1; i++)
            {
                objexcelapp.Cells[1, i] = gridviewID.Columns[i - 1].HeaderText;
            }
            for (int i = 0; i < gridviewID.Rows.Count; i++)
            {
                for (int j = 0; j < gridviewID.Columns.Count; j++)
                {
                    if (gridviewID.Rows[i].Cells[j].Value != null)
                    {
                        for (int k = 1; k < gridviewID.Rows[i].Cells[j].Value.ToString().Length; k++)
                        {
                            if (gridviewID.Rows[i].Cells[j].Value.ToString().Substring(k, 1) == ",")
                            {
                                gridviewID.Rows[i].Cells[j].Value = gridviewID.Rows[i].Cells[j].Value.ToString().Substring(0, k) + "." + gridviewID.Rows[i].Cells[j].Value.ToString().Substring((k + 1), gridviewID.Rows[i].Cells[j].Value.ToString().Length - (k + 1));
                            }
                        }
                        objexcelapp.Cells[i + 2, j + 1] = gridviewID.Rows[i].Cells[j].Value.ToString();
                    }
                }
            }
            objexcelapp.ActiveWorkbook.SaveCopyAs("D:\\" + "Дунд " + " " + excelfilename + ".xlsx");
            objexcelapp.ActiveWorkbook.Saved = true;
            MessageBox.Show("хадгалагдлаа D:\\" + "Дунд " + " " + excelfilename + ".xlsx");
        }
        private void ExporttoExcel3(DataGridView gridviewID, string excelfilename)
        {
            Microsoft.Office.Interop.Excel._Application objexcelapp = new Microsoft.Office.Interop.Excel.Application();
            objexcelapp.Application.Workbooks.Add();
            objexcelapp.Columns.ColumnWidth = 10;
            for (int i = 1; i < gridviewID.ColumnCount + 1; i++)
            {
                objexcelapp.Cells[1, i] = gridviewID.Columns[i - 1].HeaderText;
            }
            for (int i = 0; i < gridviewID.Rows.Count; i++)
            {
                for (int j = 0; j < gridviewID.Columns.Count; j++)
                {
                    if (gridviewID.Rows[i].Cells[j].Value != null)
                    {
                        for (int k = 1; k < gridviewID.Rows[i].Cells[j].Value.ToString().Length; k++)
                        {
                            if (gridviewID.Rows[i].Cells[j].Value.ToString().Substring(k, 1) == ",")
                            {
                                gridviewID.Rows[i].Cells[j].Value = gridviewID.Rows[i].Cells[j].Value.ToString().Substring(0, k) + "." + gridviewID.Rows[i].Cells[j].Value.ToString().Substring((k + 1), gridviewID.Rows[i].Cells[j].Value.ToString().Length - (k + 1));
                            }
                        }
                        objexcelapp.Cells[i + 2, j + 1] = gridviewID.Rows[i].Cells[j].Value.ToString();
                    }
                }
            }
            objexcelapp.ActiveWorkbook.SaveCopyAs("D:\\" + "Өндөр " + " " + excelfilename + ".xlsx");
            objexcelapp.ActiveWorkbook.Saved = true;
            MessageBox.Show("хадгалагдлаа D:\\" + "Өндөр " + " " + excelfilename + ".xlsx");
        }
        private void ExporttoExcel4(DataGridView gridviewID, string excelfilename)
        {
            Microsoft.Office.Interop.Excel._Application objexcelapp = new Microsoft.Office.Interop.Excel.Application();
            objexcelapp.Application.Workbooks.Add();
            objexcelapp.Columns.ColumnWidth = 10;
            for (int i = 1; i < gridviewID.ColumnCount + 1; i++)
            {
                objexcelapp.Cells[1, i] = gridviewID.Columns[i - 1].HeaderText;
            }
            for (int i = 0; i < gridviewID.Rows.Count; i++)
            {
                for (int j = 0; j < gridviewID.Columns.Count; j++)
                {
                    if (gridviewID.Rows[i].Cells[j].Value != null)
                    {
                        for (int k = 1; k < gridviewID.Rows[i].Cells[j].Value.ToString().Length; k++)
                        {
                            if (gridviewID.Rows[i].Cells[j].Value.ToString().Substring(k, 1) == ",")
                            {
                                gridviewID.Rows[i].Cells[j].Value = gridviewID.Rows[i].Cells[j].Value.ToString().Substring(0, k) + "." + gridviewID.Rows[i].Cells[j].Value.ToString().Substring((k + 1), gridviewID.Rows[i].Cells[j].Value.ToString().Length - (k + 1));
                            }
                        }
                        objexcelapp.Cells[i + 2, j + 1] = gridviewID.Rows[i].Cells[j].Value.ToString();
                    }
                }
            }
            objexcelapp.ActiveWorkbook.SaveCopyAs("D:\\" + "Заалт-2 " + " " + excelfilename + ".xlsx");
            objexcelapp.ActiveWorkbook.Saved = true;
            MessageBox.Show("хадгалагдлаа D:\\" + "Заалт-2 " + " " + excelfilename + ".xlsx");
        }
        private void ExporttoExcel5(DataGridView gridviewID, string excelfilename)
        {
            Microsoft.Office.Interop.Excel._Application objexcelapp = new Microsoft.Office.Interop.Excel.Application();
            objexcelapp.Application.Workbooks.Add();
            objexcelapp.Columns.ColumnWidth = 10;
            for (int i = 1; i < gridviewID.ColumnCount + 1; i++)
            {
                objexcelapp.Cells[1, i] = gridviewID.Columns[i - 1].HeaderText;
            }
            for (int i = 0; i < gridviewID.Rows.Count; i++)
            {
                for (int j = 0; j < gridviewID.Columns.Count; j++)
                {
                    if (gridviewID.Rows[i].Cells[j].Value != null)
                    {
                        for (int k = 1; k < gridviewID.Rows[i].Cells[j].Value.ToString().Length; k++)
                        {
                            if (gridviewID.Rows[i].Cells[j].Value.ToString().Substring(k, 1) == ",")
                            {
                                gridviewID.Rows[i].Cells[j].Value = gridviewID.Rows[i].Cells[j].Value.ToString().Substring(0, k) + "." + gridviewID.Rows[i].Cells[j].Value.ToString().Substring((k + 1), gridviewID.Rows[i].Cells[j].Value.ToString().Length - (k + 1));
                            }
                        }
                        objexcelapp.Cells[i + 2, j + 1] = gridviewID.Rows[i].Cells[j].Value.ToString();
                    }
                }
            }
            objexcelapp.ActiveWorkbook.SaveCopyAs("D:\\" + "Заалт-2 энерги " + " " + excelfilename + ".xlsx");
            objexcelapp.ActiveWorkbook.Saved = true;
            MessageBox.Show("хадгалагдлаа D:\\" + "Заалт-2 энерги " + " " + excelfilename + ".xlsx");
        }



        private void ExporttoExcel6(DataGridView gridviewID, string excelfilename)
        {
            Microsoft.Office.Interop.Excel._Application objexcelapp = new Microsoft.Office.Interop.Excel.Application();
            objexcelapp.Application.Workbooks.Add();
            objexcelapp.Columns.ColumnWidth = 10;
            for (int i = 1; i < gridviewID.ColumnCount + 1; i++)
            {
                objexcelapp.Cells[1, i] = gridviewID.Columns[i - 1].HeaderText;
            }
            for (int i = 0; i < gridviewID.Rows.Count; i++)
            {
                for (int j = 0; j < gridviewID.Columns.Count; j++)
                {
                    if (gridviewID.Rows[i].Cells[j].Value != null)
                    {
                        for (int k = 1; k < gridviewID.Rows[i].Cells[j].Value.ToString().Length; k++)
                        {
                            if (gridviewID.Rows[i].Cells[j].Value.ToString().Substring(k, 1) == ",")
                            {
                                gridviewID.Rows[i].Cells[j].Value = gridviewID.Rows[i].Cells[j].Value.ToString().Substring(0, k) + "." + gridviewID.Rows[i].Cells[j].Value.ToString().Substring((k + 1), gridviewID.Rows[i].Cells[j].Value.ToString().Length - (k + 1));
                            }
                        }
                        objexcelapp.Cells[i + 2, j + 1] = gridviewID.Rows[i].Cells[j].Value.ToString();
                    }
                }
            }
            objexcelapp.ActiveWorkbook.SaveCopyAs("D:\\" + "Реактив энерги " + " " + excelfilename + ".xlsx");
            objexcelapp.ActiveWorkbook.Saved = true;
            MessageBox.Show("хадгалагдлаа D:\\" + "Реактив энерги " + " " + excelfilename + ".xlsx");
        }
        private void ExporttoExcel7(DataGridView gridviewID, string excelfilename)
        {
            Microsoft.Office.Interop.Excel._Application objexcelapp = new Microsoft.Office.Interop.Excel.Application();
            objexcelapp.Application.Workbooks.Add();
            objexcelapp.Columns.ColumnWidth = 10;
            for (int i = 1; i < gridviewID.ColumnCount + 1; i++)
            {
                objexcelapp.Cells[1, i] = gridviewID.Columns[i - 1].HeaderText;
            }
            for (int i = 0; i < gridviewID.Rows.Count; i++)
            {
                for (int j = 0; j < gridviewID.Columns.Count; j++)
                {
                    if (gridviewID.Rows[i].Cells[j].Value != null)
                    {
                        for (int k = 1; k < gridviewID.Rows[i].Cells[j].Value.ToString().Length; k++)
                        {
                            if (gridviewID.Rows[i].Cells[j].Value.ToString().Substring(k, 1) == ",")
                            {
                                gridviewID.Rows[i].Cells[j].Value = gridviewID.Rows[i].Cells[j].Value.ToString().Substring(0, k) + "." + gridviewID.Rows[i].Cells[j].Value.ToString().Substring((k + 1), gridviewID.Rows[i].Cells[j].Value.ToString().Length - (k + 1));
                            }
                        }
                        objexcelapp.Cells[i + 2, j + 1] = gridviewID.Rows[i].Cells[j].Value.ToString();
                    }
                }
            }
            objexcelapp.ActiveWorkbook.SaveCopyAs("D:\\" + "Реактив чадал " + " " + excelfilename + ".xlsx");
            objexcelapp.ActiveWorkbook.Saved = true;
            MessageBox.Show("хадгалагдлаа D:\\" + "Реактив чадал " + " " + excelfilename + ".xlsx");
        }
        private void ExporttoExcel8(DataGridView gridviewID, string excelfilename)
        {
            Microsoft.Office.Interop.Excel._Application objexcelapp = new Microsoft.Office.Interop.Excel.Application();
            objexcelapp.Application.Workbooks.Add();
            objexcelapp.Columns.ColumnWidth = 10;
            for (int i = 1; i < gridviewID.ColumnCount + 1; i++)
            {
                objexcelapp.Cells[1, i] = gridviewID.Columns[i - 1].HeaderText;
            }
            for (int i = 0; i < gridviewID.Rows.Count; i++)
            {
                for (int j = 0; j < gridviewID.Columns.Count; j++)
                {
                    if (gridviewID.Rows[i].Cells[j].Value != null)
                    {
                        for (int k = 1; k < gridviewID.Rows[i].Cells[j].Value.ToString().Length; k++)
                        {
                            if (gridviewID.Rows[i].Cells[j].Value.ToString().Substring(k, 1) == ",")
                            {
                                gridviewID.Rows[i].Cells[j].Value = gridviewID.Rows[i].Cells[j].Value.ToString().Substring(0, k) + "." + gridviewID.Rows[i].Cells[j].Value.ToString().Substring((k + 1), gridviewID.Rows[i].Cells[j].Value.ToString().Length - (k + 1));
                            }
                        }
                        objexcelapp.Cells[i + 2, j + 1] = gridviewID.Rows[i].Cells[j].Value.ToString();
                    }
                }
            }
            objexcelapp.ActiveWorkbook.SaveCopyAs("D:\\" + "Реактив заалт " + " " + excelfilename + ".xlsx");
            objexcelapp.ActiveWorkbook.Saved = true;
            MessageBox.Show("хадгалагдлаа D:\\" + "Реактив заалт " + " " + excelfilename + ".xlsx");
        }
        private void ExporttoExcel9(DataGridView gridviewID, string excelfilename)
        {
            Microsoft.Office.Interop.Excel._Application objexcelapp = new Microsoft.Office.Interop.Excel.Application();
            objexcelapp.Application.Workbooks.Add();
            objexcelapp.Columns.ColumnWidth = 10;
            for (int i = 1; i < gridviewID.ColumnCount + 1; i++)
            {
                objexcelapp.Cells[1, i] = gridviewID.Columns[i - 1].HeaderText;
            }
            for (int i = 0; i < gridviewID.Rows.Count; i++)
            {
                for (int j = 0; j < gridviewID.Columns.Count; j++)
                {
                    if (gridviewID.Rows[i].Cells[j].Value != null)
                    {
                        for (int k = 1; k < gridviewID.Rows[i].Cells[j].Value.ToString().Length; k++)
                        {
                            if (gridviewID.Rows[i].Cells[j].Value.ToString().Substring(k, 1) == ",")
                            {
                                gridviewID.Rows[i].Cells[j].Value = gridviewID.Rows[i].Cells[j].Value.ToString().Substring(0, k) + "." + gridviewID.Rows[i].Cells[j].Value.ToString().Substring((k + 1), gridviewID.Rows[i].Cells[j].Value.ToString().Length - (k + 1));
                            }
                        }
                        objexcelapp.Cells[i + 2, j + 1] = gridviewID.Rows[i].Cells[j].Value.ToString();
                    }
                }
            }
            objexcelapp.ActiveWorkbook.SaveCopyAs("E:\\" + "Чадлын коэффициент " + " " + excelfilename + ".xlsx");
            objexcelapp.ActiveWorkbook.Saved = true;
            MessageBox.Show("хадгалагдлаа E:\\" + "Чадлын коэффициент " + " " + excelfilename + ".xlsx");
        }
        #endregion

        #region button click
        private void button1_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da3 = new SqlDataAdapter("select (select CONVERT (VARCHAR(8), tsag, 108) 'hh:mi:ss' ) AS Цаг, daalgawar, daalgawar1 from daalgawara where (select DATEPART(dd, tsag))=@unuudur1 and (select DATEPART(mm, tsag))=@odoogiinsardaalg and (select DATEPART(yy, tsag))=@odoojil ORDER BY id ASC", con);
            da3.SelectCommand.Parameters.AddWithValue("@unuudur1", DateTime.Now.Day);
            da3.SelectCommand.Parameters.AddWithValue("@odoogiinsardaalg", DateTime.Now.Month);
            da3.SelectCommand.Parameters.AddWithValue("@odoojil", DateTime.Now.Year);
            DataSet ds3 = new DataSet();

            da3.Fill(ds3, "daalgawar");

            SqlDataAdapter da11 = new SqlDataAdapter("select (select CONVERT (VARCHAR(8), tsag, 108) 'hh:mi:ss' ) AS Цаг, daalgawar from daalgawara1 where (select DATEPART(dd, tsag))=@unuudur11 and (select DATEPART(mm, tsag))=@odoogiinsardaalg1 and (select DATEPART(yy, tsag))=@odoogiinjildaalg1 ORDER BY id ASC", con);
            da11.SelectCommand.Parameters.AddWithValue("@unuudur11", DateTime.Now.Day);
            da11.SelectCommand.Parameters.AddWithValue("@odoogiinsardaalg1", DateTime.Now.Month);
            da11.SelectCommand.Parameters.AddWithValue("@odoogiinjildaalg1", DateTime.Now.Year);
            DataSet ds11 = new DataSet();
            da11.Fill(ds11, "daalgawar1");
            dataGridView18.DataSource = ds11.Tables[0];

            string strDate = textBox13.Text;
            DateTime clock = DateTime.ParseExact(strDate, "HH:mm:ss", CultureInfo.InvariantCulture);
            string strDate1 = textBox14.Text;
            DateTime clock1 = DateTime.ParseExact(strDate1, "HH:mm:ss", CultureInfo.InvariantCulture);
            bool b = false;
            for (int i = 0; i < ds3.Tables[0].Rows.Count; i++)
            {
                string strDate2 = ds3.Tables[0].Rows[i]["Цаг"].ToString();
                DateTime clock3 = DateTime.ParseExact(strDate2, "HH:mm:ss", CultureInfo.InvariantCulture);
                if (clock3.Hour == clock.Hour)
                {
                    b = true;
                }
            }
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

            bool c = false;
            DateTime clock4 = DateTime.ParseExact("23:45:00", "HH:mm:ss", CultureInfo.InvariantCulture);
            clock = DateTime.ParseExact(strDate, "HH:mm:ss", CultureInfo.InvariantCulture);
            for (int i = 0; i < ds11.Tables[0].Rows.Count; i++)
            {
                string strDate5 = ds11.Tables[0].Rows[i]["Цаг"].ToString();
                DateTime clock7 = DateTime.ParseExact(strDate5, "HH:mm:ss", CultureInfo.InvariantCulture);
                if (clock7.Hour == clock.Hour)
                {
                    c = true;
                    // MessageBox.Show("cc");
                }
            }


            clock = DateTime.ParseExact(strDate, "HH:mm:ss", CultureInfo.InvariantCulture);

            if (!c)
            {
                while (clock < clock1)
                {
                    clock = clock.AddMinutes(15);
                    if (clock.Minute == clock4.Minute)
                    {
                        avsan[19] = float.Parse(textBox15.Text);
                        avsan[18] = avsan[19] / 4;
                        inserttodaalgawar15(clock, avsan[18]);
                        clock = clock.AddMinutes(14);
                        avsan[19] = float.Parse(textBox15.Text);
                        avsan[18] = avsan[19] / 4;
                        inserttodaalgawar15(clock, avsan[18]);
                    }
                    else
                    {
                        avsan[19] = float.Parse(textBox15.Text);
                        avsan[18] = avsan[19] / 4;
                        inserttodaalgawar15(clock, avsan[18]);
                    }
                }
            }
            daalgavarTab(dateTimePicker1.Value);
            MessageBox.Show("Даалгавар нэмэгдлээ");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlDataAdapter da3 = new SqlDataAdapter("select (select CONVERT (VARCHAR(8), tsag, 108) 'hh:mi:ss' ) AS Цаг, daalgawar AS Даалгавар, daalgawar1 AS Даалгавар1 from daalgawara where (select DATEPART(dd, tsag))=@unuudur1 and (select DATEPART(mm, tsag))=@odoogiinsardaalg1 and (select DATEPART(yy, tsag))=@odoogiinjildaalg1 ORDER BY id ASC", con);
            da3.SelectCommand.Parameters.AddWithValue("@unuudur1", DateTime.Now.Day);
            da3.SelectCommand.Parameters.AddWithValue("@odoogiinsardaalg1", DateTime.Now.Month);
            da3.SelectCommand.Parameters.AddWithValue("@odoogiinjildaalg1", DateTime.Now.Year);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3, "daalgawar");
            dataGridView5.DataSource = ds3.Tables[0];


            string strDate = textBox13.Text;
            DateTime clock = DateTime.ParseExact(strDate, "HH:mm:ss", CultureInfo.InvariantCulture);
            string strDate1 = textBox14.Text;
            DateTime clock1 = DateTime.ParseExact(strDate1, "HH:mm:ss", CultureInfo.InvariantCulture);

            SqlCommand cmd = new SqlCommand("DELETE from daalgawar where tsag between @ehleh and @duusah", con);
            cmd.Parameters.AddWithValue("@ehleh", clock);
            cmd.Parameters.AddWithValue("@duusah", clock1);
            con.Open();
            cmd.ExecuteNonQuery();
            cmd = new SqlCommand("DELETE from daalgawara where tsag between @ehleh and @duusah", con);
            cmd.Parameters.AddWithValue("@ehleh", clock);
            cmd.Parameters.AddWithValue("@duusah", clock1);
            cmd.ExecuteNonQuery();
            con.Close();

            SqlDataAdapter da11 = new SqlDataAdapter("select (select CONVERT (VARCHAR(8), tsag, 108) 'hh:mi:ss' ) AS Цаг, daalgawar from daalgawara1 where (select DATEPART(dd, tsag))=@unuudur11 and (select DATEPART(mm, tsag))=@odoogiinsardaalg1 and (select DATEPART(yy, tsag))=@odoogiinjildaalg1 ORDER BY id ASC", con);
            da11.SelectCommand.Parameters.AddWithValue("@unuudur11", DateTime.Now.Day);
            da11.SelectCommand.Parameters.AddWithValue("@odoogiinsardaalg1", DateTime.Now.Month);
            da11.SelectCommand.Parameters.AddWithValue("@odoogiinjildaalg1", DateTime.Now.Year);
            DataSet ds11 = new DataSet();
            da11.Fill(ds11, "daalgawar1");
            dataGridView18.DataSource = ds11.Tables[0];

            SqlCommand cmd1 = new SqlCommand("DELETE from daalgawar1 where tsag between @ehleh and @duusah", con);
            cmd1.Parameters.AddWithValue("@ehleh", clock);
            cmd1.Parameters.AddWithValue("@duusah", clock1);
            con.Open();
            cmd1.ExecuteNonQuery();
            cmd1 = new SqlCommand("DELETE from daalgawara1 where tsag between @ehleh and @duusah", con);
            cmd1.Parameters.AddWithValue("@ehleh", clock);
            cmd1.Parameters.AddWithValue("@duusah", clock1);
            cmd1.ExecuteNonQuery();
            con.Close();

            cmd = new SqlCommand("delete daalgawar1 where tsag < @tsag", con);
            con.Open();
            cmd.Parameters.AddWithValue("@tsag", DateTime.Today.AddDays(-3));
            cmd.ExecuteNonQuery();
            con.Close();
            cmd = new SqlCommand("delete daalgawara1 where tsag < @tsag", con);
            con.Open();
            cmd.Parameters.AddWithValue("@tsag", DateTime.Today.AddDays(-3));
            cmd.ExecuteNonQuery();
            con.Close();

            cmd = new SqlCommand("delete undur1 where tsag < @tsag", con);
            con.Open();
            cmd.Parameters.AddWithValue("@tsag", DateTime.Today.AddDays(-3));
            cmd.ExecuteNonQuery();
            con.Close();
            cmd = new SqlCommand("delete dund1 where tsag < @tsag", con);
            con.Open();
            cmd.Parameters.AddWithValue("@tsag", DateTime.Today.AddDays(-3));
            cmd.ExecuteNonQuery();
            con.Close();

            con_Az.Open();
            SqlCommand cmd3 = new SqlCommand("DELETE from daalgawar where tsag between @ehleh and @duusah", con_Az);
            cmd3.Parameters.AddWithValue("@ehleh", clock);
            cmd3.Parameters.AddWithValue("@duusah", clock1);
            cmd3.ExecuteNonQuery();
            con_Az.Close();
            daalgavarTab(dateTimePicker1.Value);
            MessageBox.Show("Даалгавар устгагдлаа");

        }

        private void button19_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 30; i++)
            {
                for (int g = 0; g < 30; g++)
                {
                    for (int j = 0; j < 30; j++)
                    {
                        maxmin[i, g, j] = 0;
                    }
                }
            }
            DateTime guravHonogiinUmnu = DateTime.Now.AddDays(-3);
            if (dateTimePicker2.Value > guravHonogiinUmnu)
            {

                SqlDataAdapter da4 = new SqlDataAdapter("select (select CONVERT (VARCHAR(8), tsag, 108) 'hh:mi:ss' ) AS Цаг, (select ROUND(tg1, 3)) AS ТГ1, (select ROUND(tg2, 3)) AS ТГ2, (select ROUND(tg3, 3)) AS ТГ3, (select ROUND(tg4, 3)) AS ТГ4, (select ROUND(niilber, 3)) AS Нийлбэр from dund1 where (select DATEPART(dd, tsag))=@unuudurdund and (select DATEPART(mm, tsag))=@odoogiinsardund  and (select DATEPART(yy, tsag))=@jildund ORDER BY id DESC", con);
                da4.SelectCommand.Parameters.AddWithValue("@unuudurdund", dateTimePicker2.Value.Day);
                da4.SelectCommand.Parameters.AddWithValue("@odoogiinsardund", dateTimePicker2.Value.Month);
                da4.SelectCommand.Parameters.AddWithValue("@jildund", dateTimePicker2.Value.Year);
                DataSet ds4 = new DataSet();
                da4.Fill(ds4, "dund");
                table_maxd = ds4.Tables[0];
                SqlDataAdapter da5 = new SqlDataAdapter("select (select CONVERT (VARCHAR(8), tsag, 108) 'hh:mi:ss' ) AS Цаг, (select ROUND(tg5, 3)) AS ТГ5, (select ROUND(tg6, 3)) AS ТГ6, (select ROUND(tg7, 3)) AS ТГ7, (select ROUND(tg8, 3)) AS ТГ8, (select ROUND(tg9, 3)) AS ТГ9, (select ROUND(niilber, 3)) AS Нийлбэр, (select ROUND(niit, 3)) AS Нийт from undur1 where (select DATEPART(dd, tsag))=@unuudurundur and (select DATEPART(mm, tsag))=@odoogiinsarundur and (select DATEPART(yy, tsag))=@jilundur ORDER BY id DESC", con);
                da5.SelectCommand.Parameters.AddWithValue("@unuudurundur", dateTimePicker2.Value.Day);
                da5.SelectCommand.Parameters.AddWithValue("@odoogiinsarundur", dateTimePicker2.Value.Month);
                da5.SelectCommand.Parameters.AddWithValue("@jilundur", dateTimePicker2.Value.Year);
                DataSet ds5 = new DataSet();
                da5.Fill(ds5, "undur");
                table_maxu = ds5.Tables[0];
                if (dateTimePicker2.Value.Day == DateTime.Now.Day)
                    maxminhour = DateTime.Now.Hour;
                else maxminhour = 24;
            }
            else
            {
                SqlDataAdapter da4 = new SqlDataAdapter("select (select CONVERT (VARCHAR(8), tsag, 108) 'hh:mi:ss' ) AS Цаг, (select ROUND(tg1, 3)) AS ТГ1, (select ROUND(tg2, 3)) AS ТГ2, (select ROUND(tg3, 3)) AS ТГ3, (select ROUND(tg4, 3)) AS ТГ4, (select ROUND(niilber, 3)) AS Нийлбэр from dund where (select DATEPART(dd, tsag))=@unuudurdund and (select DATEPART(mm, tsag))=@odoogiinsardund  and (select DATEPART(yy, tsag))=@jildund ORDER BY id DESC", con);
                da4.SelectCommand.Parameters.AddWithValue("@unuudurdund", dateTimePicker2.Value.Day);
                da4.SelectCommand.Parameters.AddWithValue("@odoogiinsardund", dateTimePicker2.Value.Month);
                da4.SelectCommand.Parameters.AddWithValue("@jildund", dateTimePicker2.Value.Year);
                DataSet ds4 = new DataSet();
                da4.Fill(ds4, "dund");
                table_maxd = ds4.Tables[0];
                SqlDataAdapter da5 = new SqlDataAdapter("select (select CONVERT (VARCHAR(8), tsag, 108) 'hh:mi:ss' ) AS Цаг, (select ROUND(tg5, 3)) AS ТГ5, (select ROUND(tg6, 3)) AS ТГ6, (select ROUND(tg7, 3)) AS ТГ7, (select ROUND(tg8, 3)) AS ТГ8, (select ROUND(tg9, 3)) AS ТГ9, (select ROUND(niilber, 3)) AS Нийлбэр, (select ROUND(niit, 3)) AS Нийт from undur where (select DATEPART(dd, tsag))=@unuudurundur and (select DATEPART(mm, tsag))=@odoogiinsarundur and (select DATEPART(yy, tsag))=@jilundur ORDER BY id DESC", con);
                da5.SelectCommand.Parameters.AddWithValue("@unuudurundur", dateTimePicker2.Value.Day);
                da5.SelectCommand.Parameters.AddWithValue("@odoogiinsarundur", dateTimePicker2.Value.Month);
                da5.SelectCommand.Parameters.AddWithValue("@jilundur", dateTimePicker2.Value.Year);
                DataSet ds5 = new DataSet();
                da5.Fill(ds5, "undur");
                table_maxu = ds5.Tables[0];
                maxminhour = 24;
            }

            dataGridView7.Rows.Clear();
            dataGridView7.Rows.Add(27);

            for (int i = 0; i < 25; i++)
            {
                dataGridView7.Rows[i].Cells[0].Value = i;
            }
            dataGridView7.Rows[24].Cells[0].Value = "Шөнийн";
            dataGridView7.Rows[25].Cells[0].Value = "Өдрийн";
            dataGridView7.Rows[26].Cells[0].Value = "Хоног";


            #region max min dund
            for (int i = 0; i < table_maxd.Rows.Count - 1; i++)
            {
                // tsag tsagaar max min dundaj bodoh
                for (int g = 1; g < 6; g++)
                {
                    if (maxmin[g, Convert.ToDateTime(table_maxd.Rows[i][0]).Hour, 0] < Convert.ToDouble(table_maxd.Rows[i][g]))
                    {
                        maxmin[g, Convert.ToDateTime(table_maxd.Rows[i][0]).Hour, 0] = Convert.ToDouble(table_maxd.Rows[i][g]); // max utga
                    }
                    if (maxmin[g, Convert.ToDateTime(table_maxd.Rows[i][0]).Hour, 3] == 0)
                    {
                        maxmin[g, Convert.ToDateTime(table_maxd.Rows[i][0]).Hour, 1] = Convert.ToDouble(table_maxd.Rows[i][g]);
                        maxmin[g, Convert.ToDateTime(table_maxd.Rows[i][0]).Hour, 3] = 1;
                    }

                    if (maxmin[g, Convert.ToDateTime(table_maxd.Rows[i][0]).Hour, 1] > Convert.ToDouble(table_maxd.Rows[i][g]))
                    {
                        maxmin[g, Convert.ToDateTime(table_maxd.Rows[i][0]).Hour, 1] = Convert.ToDouble(table_maxd.Rows[i][g]); // min utga
                    }
                    maxmin[g, Convert.ToDateTime(table_maxd.Rows[i][0]).Hour, 4] = maxmin[g, Convert.ToDateTime(table_maxd.Rows[i][0]).Hour, 4] + Convert.ToDouble(table_maxd.Rows[i][g]);
                    maxmin[g, Convert.ToDateTime(table_maxd.Rows[i][0]).Hour, 5]++;  // dundaj
                }

            }
            // shono udur honog
            for (int i = 0; i < maxminhour; i++)
            {
                for (int g = 1; g < 6; g++)
                {
                    maxmin[g, 1, 10] += maxmin[g, i, 4] / maxmin[g, i, 5];
                    maxmin[g, 1, 11]++;

                    if (maxmin[g, 1, 14] < maxmin[g, i, 0])
                    {
                        maxmin[g, 1, 14] = maxmin[g, i, 0];
                    }

                    if (maxmin[g, 1, 20] == 0)
                    {
                        maxmin[g, 1, 21] = maxmin[g, i, 1];
                        maxmin[g, 1, 20] = 1;
                    }
                    if (maxmin[g, 1, 21] > maxmin[g, i, 1])
                    {
                        maxmin[g, 1, 21] = maxmin[g, i, 1]; // min utga
                    }



                    if (i > 5 && i < 22)
                    {
                        maxmin[g, 0, 10] += maxmin[g, i, 4] / maxmin[g, i, 5];
                        maxmin[g, 0, 11]++;

                        if (maxmin[g, 0, 14] < maxmin[g, i, 0])
                        {
                            maxmin[g, 0, 14] = maxmin[g, i, 0];
                        }

                        if (maxmin[g, 0, 20] == 0)
                        {
                            maxmin[g, 0, 21] = maxmin[g, i, 1];
                            maxmin[g, 0, 20] = 1;
                        }
                        if (maxmin[g, 0, 21] > maxmin[g, i, 1])
                        {
                            maxmin[g, 0, 21] = maxmin[g, i, 1]; // min utga
                        }

                    }
                    else
                    {
                        maxmin[g, 0, 12] += maxmin[g, i, 4] / maxmin[g, i, 5];
                        maxmin[g, 0, 13]++;
                        if (maxmin[g, 0, 15] < maxmin[g, i, 0])
                        {
                            maxmin[g, 0, 15] = maxmin[g, i, 0];
                        }

                        if (maxmin[g, 0, 22] == 0)
                        {
                            maxmin[g, 0, 23] = maxmin[g, i, 1];
                            maxmin[g, 0, 22] = 1;
                        }
                        if (maxmin[g, 0, 23] > maxmin[g, i, 1])
                        {
                            maxmin[g, 0, 23] = maxmin[g, i, 1]; // min utga
                        }

                    }

                }

            }

            for (int i = 1; i < 5; i++)
            {

                dataGridView7.Rows[24].Cells[2 + (i - 1) * 3].Value = Math.Round(maxmin[i, 0, 12] / maxmin[i, 0, 13], 3);
                dataGridView7.Rows[24].Cells[1 + (i - 1) * 3].Value = Math.Round(maxmin[i, 0, 15], 3);
                dataGridView7.Rows[24].Cells[3 + (i - 1) * 3].Value = Math.Round(maxmin[i, 0, 23], 3);


                dataGridView7.Rows[25].Cells[1 + (i - 1) * 3].Value = Math.Round(maxmin[i, 0, 14], 3);
                dataGridView7.Rows[25].Cells[2 + (i - 1) * 3].Value = Math.Round(maxmin[i, 0, 10] / maxmin[i, 0, 11], 3);
                dataGridView7.Rows[25].Cells[3 + (i - 1) * 3].Value = Math.Round(maxmin[i, 0, 21], 3);

                dataGridView7.Rows[26].Cells[1 + (i - 1) * 3].Value = Math.Round(maxmin[i, 1, 14], 3);
                dataGridView7.Rows[26].Cells[2 + (i - 1) * 3].Value = Math.Round(maxmin[i, 1, 10] / maxmin[i, 1, 11], 3);
                dataGridView7.Rows[26].Cells[3 + (i - 1) * 3].Value = Math.Round(maxmin[i, 1, 21], 3);
            }

            dataGridView7.Rows[24].Cells[28].Value = Math.Round(maxmin[5, 0, 15], 3);
            dataGridView7.Rows[24].Cells[29].Value = Math.Round(maxmin[5, 0, 12] / maxmin[5, 0, 13], 3);
            dataGridView7.Rows[24].Cells[30].Value = Math.Round(maxmin[5, 0, 23], 3);

            dataGridView7.Rows[25].Cells[28].Value = Math.Round(maxmin[5, 0, 14], 3);
            dataGridView7.Rows[25].Cells[29].Value = Math.Round(maxmin[5, 0, 10] / maxmin[5, 0, 11], 3);
            dataGridView7.Rows[25].Cells[30].Value = Math.Round(maxmin[5, 0, 21], 3);

            dataGridView7.Rows[26].Cells[28].Value = Math.Round(maxmin[5, 1, 14], 3);
            dataGridView7.Rows[26].Cells[29].Value = Math.Round(maxmin[5, 1, 10] / maxmin[5, 1, 11], 3);
            dataGridView7.Rows[26].Cells[30].Value = Math.Round(maxmin[5, 1, 21], 3);

            for (int i = 0; i < maxminhour; i++)
            {

                for (int g = 1; g < 5; g++)
                {
                    dataGridView7.Rows[i].Cells[1 + (g - 1) * 3].Value = maxmin[g, i, 0];
                    dataGridView7.Rows[i].Cells[2 + (g - 1) * 3].Value = Math.Round(maxmin[g, i, 4] / maxmin[g, i, 5], 3);
                    dataGridView7.Rows[i].Cells[3 + (g - 1) * 3].Value = maxmin[g, i, 1];
                }
                dataGridView7.Rows[i].Cells[28].Value = maxmin[5, i, 0];
                dataGridView7.Rows[i].Cells[29].Value = Math.Round(maxmin[5, i, 4] / maxmin[5, i, 5], 3);
                dataGridView7.Rows[i].Cells[30].Value = maxmin[5, i, 1];


            }

            #endregion
            for (int i = 0; i < 30; i++)
            {
                for (int g = 0; g < 30; g++)
                {
                    for (int j = 0; j < 30; j++)
                    {
                        maxmin[i, g, j] = 0;

                    }
                }
            }

            #region max min undur

            for (int i = 0; i < table_maxu.Rows.Count - 1; i++)
            {
                // tsag tsagaar max min dundaj bodoh
                for (int g = 1; g < 8; g++)
                {
                    if (maxmin[g, Convert.ToDateTime(table_maxu.Rows[i][0]).Hour, 0] < Convert.ToDouble(table_maxu.Rows[i][g]))
                    {
                        maxmin[g, Convert.ToDateTime(table_maxu.Rows[i][0]).Hour, 0] = Convert.ToDouble(table_maxu.Rows[i][g]); // max utga
                    }
                    if (maxmin[g, Convert.ToDateTime(table_maxu.Rows[i][0]).Hour, 3] == 0)
                    {
                        maxmin[g, Convert.ToDateTime(table_maxu.Rows[i][0]).Hour, 1] = Convert.ToDouble(table_maxu.Rows[i][g]);
                        maxmin[g, Convert.ToDateTime(table_maxu.Rows[i][0]).Hour, 3] = 1;
                    }

                    if (maxmin[g, Convert.ToDateTime(table_maxu.Rows[i][0]).Hour, 1] > Convert.ToDouble(table_maxu.Rows[i][g]))
                    {
                        maxmin[g, Convert.ToDateTime(table_maxu.Rows[i][0]).Hour, 1] = Convert.ToDouble(table_maxu.Rows[i][g]); // min utga
                    }
                    maxmin[g, Convert.ToDateTime(table_maxu.Rows[i][0]).Hour, 4] = maxmin[g, Convert.ToDateTime(table_maxu.Rows[i][0]).Hour, 4] + Convert.ToDouble(table_maxu.Rows[i][g]);
                    maxmin[g, Convert.ToDateTime(table_maxu.Rows[i][0]).Hour, 5]++;  // dundaj
                }

            }
            // shono udur honog
            for (int i = 0; i < maxminhour; i++)
            {
                for (int g = 1; g < 8; g++)
                {
                    maxmin[g, 1, 10] += maxmin[g, i, 4] / maxmin[g, i, 5];
                    maxmin[g, 1, 11]++;

                    if (maxmin[g, 1, 14] < maxmin[g, i, 0])
                    {
                        maxmin[g, 1, 14] = maxmin[g, i, 0];
                    }

                    if (maxmin[g, 1, 20] == 0)
                    {
                        maxmin[g, 1, 21] = maxmin[g, i, 1];
                        maxmin[g, 1, 20] = 1;
                    }
                    if (maxmin[g, 1, 21] > maxmin[g, i, 1])
                    {
                        maxmin[g, 1, 21] = maxmin[g, i, 1]; // min utga
                    }



                    if (i > 5 && i < 22)
                    {
                        maxmin[g, 0, 10] += maxmin[g, i, 4] / maxmin[g, i, 5];
                        maxmin[g, 0, 11]++;

                        if (maxmin[g, 0, 14] < maxmin[g, i, 0])
                        {
                            maxmin[g, 0, 14] = maxmin[g, i, 0];
                        }

                        if (maxmin[g, 0, 20] == 0)
                        {
                            maxmin[g, 0, 21] = maxmin[g, i, 1];
                            maxmin[g, 0, 20] = 1;
                        }
                        if (maxmin[g, 0, 21] > maxmin[g, i, 1])
                        {
                            maxmin[g, 0, 21] = maxmin[g, i, 1]; // min utga
                        }

                    }
                    else
                    {
                        maxmin[g, 0, 12] += maxmin[g, i, 4] / maxmin[g, i, 5];
                        maxmin[g, 0, 13]++;
                        if (maxmin[g, 0, 15] < maxmin[g, i, 0])
                        {
                            maxmin[g, 0, 15] = maxmin[g, i, 0];
                        }

                        if (maxmin[g, 0, 22] == 0)
                        {
                            maxmin[g, 0, 23] = maxmin[g, i, 1];
                            maxmin[g, 0, 22] = 1;
                        }
                        if (maxmin[g, 0, 23] > maxmin[g, i, 1])
                        {
                            maxmin[g, 0, 23] = maxmin[g, i, 1]; // min utga
                        }

                    }

                }

            }



            for (int i = 1; i < 6; i++)
            {

                dataGridView7.Rows[24].Cells[14 + (i - 1) * 3].Value = Math.Round(maxmin[i, 0, 12] / maxmin[i, 0, 13], 3);
                dataGridView7.Rows[24].Cells[13 + (i - 1) * 3].Value = Math.Round(maxmin[i, 0, 15], 3);
                dataGridView7.Rows[24].Cells[15 + (i - 1) * 3].Value = Math.Round(maxmin[i, 0, 23], 3);


                dataGridView7.Rows[25].Cells[13 + (i - 1) * 3].Value = Math.Round(maxmin[i, 0, 14], 3);
                dataGridView7.Rows[25].Cells[14 + (i - 1) * 3].Value = Math.Round(maxmin[i, 0, 10] / maxmin[i, 0, 11], 3);
                dataGridView7.Rows[25].Cells[15 + (i - 1) * 3].Value = Math.Round(maxmin[i, 0, 21], 3);

                dataGridView7.Rows[26].Cells[13 + (i - 1) * 3].Value = Math.Round(maxmin[i, 1, 14], 3);
                dataGridView7.Rows[26].Cells[14 + (i - 1) * 3].Value = Math.Round(maxmin[i, 1, 10] / maxmin[i, 1, 11], 3);
                dataGridView7.Rows[26].Cells[15 + (i - 1) * 3].Value = Math.Round(maxmin[i, 1, 21], 3);
            }

            dataGridView7.Rows[24].Cells[31].Value = Math.Round(maxmin[6, 0, 15], 3);
            dataGridView7.Rows[24].Cells[32].Value = Math.Round(maxmin[6, 0, 12] / maxmin[6, 0, 13], 3);
            dataGridView7.Rows[24].Cells[33].Value = Math.Round(maxmin[6, 0, 23], 3);

            dataGridView7.Rows[25].Cells[31].Value = Math.Round(maxmin[6, 0, 14], 3);
            dataGridView7.Rows[25].Cells[32].Value = Math.Round(maxmin[6, 0, 10] / maxmin[6, 0, 11], 3);
            dataGridView7.Rows[25].Cells[33].Value = Math.Round(maxmin[6, 0, 21], 3);

            dataGridView7.Rows[26].Cells[31].Value = Math.Round(maxmin[6, 1, 14], 3);
            dataGridView7.Rows[26].Cells[32].Value = Math.Round(maxmin[6, 1, 10] / maxmin[6, 1, 11], 3);
            dataGridView7.Rows[26].Cells[33].Value = Math.Round(maxmin[6, 1, 21], 3);

            dataGridView7.Rows[24].Cells[34].Value = Math.Round(maxmin[7, 0, 15], 3);
            dataGridView7.Rows[24].Cells[35].Value = Math.Round(maxmin[7, 0, 12] / maxmin[7, 0, 13], 3);
            dataGridView7.Rows[24].Cells[36].Value = Math.Round(maxmin[7, 0, 23], 3);

            dataGridView7.Rows[25].Cells[34].Value = Math.Round(maxmin[7, 0, 14], 3);
            dataGridView7.Rows[25].Cells[35].Value = Math.Round(maxmin[7, 0, 10] / maxmin[7, 0, 11], 3);
            dataGridView7.Rows[25].Cells[36].Value = Math.Round(maxmin[7, 0, 21], 3);

            dataGridView7.Rows[26].Cells[34].Value = Math.Round(maxmin[7, 1, 14], 3);
            dataGridView7.Rows[26].Cells[35].Value = Math.Round(maxmin[7, 1, 10] / maxmin[7, 1, 11], 3);
            dataGridView7.Rows[26].Cells[36].Value = Math.Round(maxmin[7, 1, 21], 3);


            for (int i = 0; i < maxminhour; i++)
            {

                for (int g = 1; g < 6; g++)
                {
                    dataGridView7.Rows[i].Cells[13 + (g - 1) * 3].Value = maxmin[g, i, 0];
                    dataGridView7.Rows[i].Cells[14 + (g - 1) * 3].Value = Math.Round(maxmin[g, i, 4] / maxmin[g, i, 5], 3);
                    dataGridView7.Rows[i].Cells[15 + (g - 1) * 3].Value = maxmin[g, i, 1];
                }
                dataGridView7.Rows[i].Cells[31].Value = maxmin[6, i, 0];
                dataGridView7.Rows[i].Cells[32].Value = Math.Round(maxmin[6, i, 4] / maxmin[6, i, 5], 3);
                dataGridView7.Rows[i].Cells[33].Value = maxmin[6, i, 1];

                dataGridView7.Rows[i].Cells[34].Value = maxmin[7, i, 0];
                dataGridView7.Rows[i].Cells[35].Value = Math.Round(maxmin[7, i, 4] / maxmin[7, i, 5], 3);
                dataGridView7.Rows[i].Cells[36].Value = maxmin[7, i, 1];


            }





            #endregion
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (textBox17.Text == "123456")
            {
                connectionopen(cont);
                SqlDataAdapter da = new SqlDataAdapter("select  *from  yalgawar1 ORDER BY id ASC", cont);
                DataSet ds = new DataSet();
                da.Fill(ds, "neg");
                table = ds.Tables[0];

                for (int i = 0; i < table.Rows.Count; i++)
                {
                    utganemeh = 0;
                    if (Convert.ToInt16(table.Rows[i][38]) == 1)
                    {

                        /*   cmdutga = new SqlCommand("UPDATE yalgawar SET   day1=@t1,day2=@t2,day3=@t3,day4=@t4,day5=@t5,day6=@t6,day7=@t7," +
                               "day8=@t8,day9=@t9,day10=@t10,day11=@t11,day12=@t12,day13=@t13,day14=@t14,day15=@t15," +
                               "day16=@t16,day17=@t17,day18=@t18,day19=@t19,day20=@t20,day21=@t21,day22=@t22,day23=@t23,day24=@t24," +
                               "day25=@t25,day26=@t26,day27=@t27,day28=@t28,day29=@t29,day30=@t30,day30=@t30,,dayniit=@t32  WHERE id='" + Convert.ToInt16(table.Rows[i][0]) + "'", cont);
                           for (int j = 1; j < 33; j++)
                           {
                               cmdutga.Parameters.AddWithValue("@t"+j+"", 0);

                           }

                           if (cmdutga.ExecuteNonQuery() == 0)
                           {
                               MessageBox.Show("daynemeh : " + i);
                           }


                         */
                        cmdutga = new SqlCommand("UPDATE yalgawar1 SET   day1=@t1,day2=@t2,day3=@t3,day4=@t4,day5=@t5,day6=@t6,day7=@t7,day8=@t8,day9=@t9,day10=@t10,day11=@t11,day12=@t12,day13=@t13,day14=@t14,day15=@t15,day16=@t16,day17=@t17,day18=@t18,day19=@t19,day20=@t20,day21=@t21,day22=@t22,day23=@t23,day24=@t24,day25=@t25,day26=@t26,day27=@t27,day28=@t28,day29=@t29,day30=@t30,day31=@t31,dayniit=@t32    WHERE id='" + Convert.ToInt16(table.Rows[i][0]) + "'", cont);
                        for (int j = 1; j < 33; j++)
                        {
                            cmdutga.Parameters.AddWithValue("@t" + j, 0);

                        }

                        if (cmdutga.ExecuteNonQuery() == 0)
                        {
                            MessageBox.Show("daynemeh : " + i);
                        }

                    }

                }
                textBox17.Text = "";
                MessageBox.Show("Амжилттай цэвэрлэлээ");

            }
            if (textBox17.Text == "")
            {
                MessageBox.Show("Нууц үгээ оруулна уу");
            }


            else
            {
                MessageBox.Show("Нууц үг буруу байна");
            }

        }

        private void button18_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("delete maxmin where id > 0", cont);
            cmd.ExecuteNonQuery();


            for (int i = 0; i < dataGridView7.Rows.Count; i++)
            {
                //     MessageBox.Show(ds5.Tables[0].Rows[i][1].ToString());

                SqlCommand cmdn = new SqlCommand("INSERT INTO maxmin (tsag, t1max,t1dund,t1min,t2max,t2dund,t2min,t3max,t3dund,t3min,t4max,t4dund,t4min,t5max,t5dund,t5min,t6max,t6dund,t6min,t7max,t7dund,t7min,t8max,t8dund,t8min,t9max,t9dund,t9min,dmax,ddund,dmin,umax,udund,umin,nmax,ndund,nmin) values (@t50,@t1, @t2, @t3, @t4, @t5, @t6, @t7, @t8, @t9, @t10, @t11, @t12, @t13, @t14, @t15, @t16, @t17, @t18, @t19, @t20, @t21, @t22, @t23, @t24, @t25, @t26, @t27, @t28, @t29, @t30, @t31, @t32, @t33, @t34, @t35, @t36)", cont);
                if(i==25)
                cmdn.Parameters.AddWithValue("@t50", "Шөнийн");
                else if (i == 26)
                    cmdn.Parameters.AddWithValue("@t50", "Өдрийн");
                else if (i == 27)
                    cmdn.Parameters.AddWithValue("@t50", "Хоног");

                else
                    cmdn.Parameters.AddWithValue("@t50", i + 1);
                cmdn.Parameters.AddWithValue("@t1", Convert.ToDouble(dataGridView7.Rows[i].Cells[1].Value));
                cmdn.Parameters.AddWithValue("@t2", Convert.ToDouble(dataGridView7.Rows[i].Cells[2].Value));
                cmdn.Parameters.AddWithValue("@t3", Convert.ToDouble(dataGridView7.Rows[i].Cells[3].Value));
                cmdn.Parameters.AddWithValue("@t4", Convert.ToDouble(dataGridView7.Rows[i].Cells[4].Value));
                cmdn.Parameters.AddWithValue("@t5", Convert.ToDouble(dataGridView7.Rows[i].Cells[5].Value));
                cmdn.Parameters.AddWithValue("@t6", Convert.ToDouble(dataGridView7.Rows[i].Cells[6].Value));
                cmdn.Parameters.AddWithValue("@t7", Convert.ToDouble(dataGridView7.Rows[i].Cells[7].Value));
                cmdn.Parameters.AddWithValue("@t8", Convert.ToDouble(dataGridView7.Rows[i].Cells[8].Value));
                cmdn.Parameters.AddWithValue("@t9", Convert.ToDouble(dataGridView7.Rows[i].Cells[9].Value));
                cmdn.Parameters.AddWithValue("@t10", Convert.ToDouble(dataGridView7.Rows[i].Cells[10].Value));
                cmdn.Parameters.AddWithValue("@t11", Convert.ToDouble(dataGridView7.Rows[i].Cells[11].Value));
                cmdn.Parameters.AddWithValue("@t12", Convert.ToDouble(dataGridView7.Rows[i].Cells[12].Value));
                cmdn.Parameters.AddWithValue("@t13", Convert.ToDouble(dataGridView7.Rows[i].Cells[13].Value));
                cmdn.Parameters.AddWithValue("@t14", Convert.ToDouble(dataGridView7.Rows[i].Cells[14].Value));
                cmdn.Parameters.AddWithValue("@t15", Convert.ToDouble(dataGridView7.Rows[i].Cells[15].Value));
                cmdn.Parameters.AddWithValue("@t16", Convert.ToDouble(dataGridView7.Rows[i].Cells[16].Value));
                cmdn.Parameters.AddWithValue("@t17", Convert.ToDouble(dataGridView7.Rows[i].Cells[17].Value));
                cmdn.Parameters.AddWithValue("@t18", Convert.ToDouble(dataGridView7.Rows[i].Cells[18].Value));
                cmdn.Parameters.AddWithValue("@t19", Convert.ToDouble(dataGridView7.Rows[i].Cells[19].Value));
                cmdn.Parameters.AddWithValue("@t20", Convert.ToDouble(dataGridView7.Rows[i].Cells[20].Value));
                cmdn.Parameters.AddWithValue("@t21", Convert.ToDouble(dataGridView7.Rows[i].Cells[21].Value));
                cmdn.Parameters.AddWithValue("@t22", Convert.ToDouble(dataGridView7.Rows[i].Cells[22].Value));
                cmdn.Parameters.AddWithValue("@t23", Convert.ToDouble(dataGridView7.Rows[i].Cells[23].Value));
                cmdn.Parameters.AddWithValue("@t24", Convert.ToDouble(dataGridView7.Rows[i].Cells[24].Value));
                cmdn.Parameters.AddWithValue("@t25", Convert.ToDouble(dataGridView7.Rows[i].Cells[25].Value));
                cmdn.Parameters.AddWithValue("@t26", Convert.ToDouble(dataGridView7.Rows[i].Cells[26].Value));
                cmdn.Parameters.AddWithValue("@t27", Convert.ToDouble(dataGridView7.Rows[i].Cells[27].Value));
                cmdn.Parameters.AddWithValue("@t28", Convert.ToDouble(dataGridView7.Rows[i].Cells[28].Value));
                cmdn.Parameters.AddWithValue("@t29", Convert.ToDouble(dataGridView7.Rows[i].Cells[29].Value));
                cmdn.Parameters.AddWithValue("@t30", Convert.ToDouble(dataGridView7.Rows[i].Cells[30].Value));
                cmdn.Parameters.AddWithValue("@t31", Convert.ToDouble(dataGridView7.Rows[i].Cells[31].Value));
                cmdn.Parameters.AddWithValue("@t32", Convert.ToDouble(dataGridView7.Rows[i].Cells[32].Value));
                cmdn.Parameters.AddWithValue("@t33", Convert.ToDouble(dataGridView7.Rows[i].Cells[33].Value));
                cmdn.Parameters.AddWithValue("@t34", Convert.ToDouble(dataGridView7.Rows[i].Cells[34].Value));
                cmdn.Parameters.AddWithValue("@t35", Convert.ToDouble(dataGridView7.Rows[i].Cells[35].Value));
                cmdn.Parameters.AddWithValue("@t36", Convert.ToDouble(dataGridView7.Rows[i].Cells[36].Value));
                if (cmdn.ExecuteNonQuery() == 0)
                {
                    MessageBox.Show("baazupdate : ");
                }
      
            }
            System.Diagnostics.Process.Start("maxmin.rdl");


        }
        private void button2_Click(object sender, EventArgs e)
        {
            string strDate = textBox1.Text;
            DateTime clock = DateTime.ParseExact(strDate, "HH:mm:ss", CultureInfo.InvariantCulture);
            string strDate1 = textBox2.Text;
            DateTime clock1 = DateTime.ParseExact(strDate1, "HH:mm:ss", CultureInfo.InvariantCulture);

            SqlDataAdapter da3 = new SqlDataAdapter("select (select CONVERT (VARCHAR(8), tsag, 108) 'hh:mi:ss' ) AS Цаг, (select ROUND(daalgawar, 3)) AS Даалгавар, (select ROUND(daalgawar1, 3)) AS Даалгавар1 from daalgawar where (select DATEPART(dd, tsag))=@unuudur1 and (select DATEPART(mm, tsag))=@odoogiinsardaalgawar and (select DATEPART(yy, tsag))=@jildaalgawar   ORDER BY id ASC", con);
            da3.SelectCommand.Parameters.AddWithValue("@unuudur1", DateTime.Now.Day);
            da3.SelectCommand.Parameters.AddWithValue("@odoogiinsardaalgawar", DateTime.Now.Month);
            da3.SelectCommand.Parameters.AddWithValue("@jildaalgawar", DateTime.Now.Year);
            DataSet ds3 = new DataSet();
            da3.Fill(ds3, "daalgawar");
            dataGridView18.DataSource = ds3.Tables[0];
            for (int i = 0; i < dataGridView18.Rows.Count; ++i)
            {
                if (Convert.ToDateTime(dataGridView18.Rows[i].Cells[0].Value) <= clock1 && Convert.ToDateTime(dataGridView18.Rows[i].Cells[0].Value) > clock)
                {
                    shi += Convert.ToDouble(dataGridView18.Rows[i].Cells[2].Value);
                }
            }

            textBox3.Text = Math.Round(shi, 0).ToString();
            shi = 0;

        }

        private void comboBox27_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                comboBox28.Items.Clear();
                connectionopen(cont);
                SqlDataAdapter da = new SqlDataAdapter("select  *from  yalgawar1 where tolow6=" + cname[comboBox27.SelectedIndex] + " ORDER BY id ASC", cont);
                DataSet ds = new DataSet();
                da.Fill(ds, "neg");
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    comboBox28.Items.Add(ds.Tables[0].Rows[i][34].ToString());
                    cname1[i] = Convert.ToInt16(ds.Tables[0].Rows[i][0]);
                }
            }
            catch { }

        }

        private void button21_Click(object sender, EventArgs e)
        {
            

            connectionopen(cont);
            SqlCommand cmd = new SqlCommand("UPDATE yalgawar1 SET  tsag = @t2,  day" + dateTimePicker2.Value.Day + "=@t1  WHERE id=" + cname1[comboBox28.SelectedIndex] + "", cont);
            cmd.Parameters.AddWithValue("@t2", dateTimePicker2.Value);
            cmd.Parameters.AddWithValue("@t1", textBox18.Text);
            if (cmd.ExecuteNonQuery() == 0)
            {
                MessageBox.Show("1 yalgazar2");
            }
            MessageBox.Show("Амжилттай");
          
        }

        private void comboBox28_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button22_Click(object sender, EventArgs e)
        {
            SqlDataAdapter daParameter = new SqlDataAdapter("select *from Parameters order by id asc", conp);
            DataSet dsParameter = new DataSet();
            daParameter.Fill(dsParameter, "Parameter");
            tableParameter = dsParameter.Tables[0]; 
            
            Form2 frm = new Form2();
            frm.ao1 = generalSchem.R1roaP;
            frm.bo1 = generalSchem.R1robP;
            frm.ao2 = generalSchem.R2roaP;
            frm.bo2 = generalSchem.R2robP;
            frm.ao7 = generalSchem.R7raP;
            frm.bo7 = generalSchem.R7rbP;
            frm.ao8 = generalSchem.R8raP;
            frm.bo8 = generalSchem.R8rbP;
            frm.ao9 = generalSchem.R9raP;
            frm.bo9 = generalSchem.R9rbP;
            frm.ao10 = generalSchem.R10raP;
            frm.bo10 = generalSchem.R10rbP;
            frm.ao11 = generalSchem.R11raP;
            frm.bo11 = generalSchem.R11rbP;
            frm.ao12 = generalSchem.R12raP;
            frm.bo12 = generalSchem.R12rbP;
            frm.ao13 = generalSchem.R13raP;
            frm.bo13 = generalSchem.R13rbP;
//            frm.ao14 = generalSchem.R14;
 //           frm.bo14 = generalSchem.R14rbP;
            frm.sons2 = Convert.ToDouble(tableParameter.Rows[20][4]).ToString();
            frm.tungaah = generalSchem.R1roaP;
            frm.Show();
        }

        private void button23_Click(object sender, EventArgs e)
        {

            SqlDataAdapter daParameter = new SqlDataAdapter("select *from Parameters order by id asc", conp);
            DataSet dsParameter = new DataSet();
            daParameter.Fill(dsParameter, "Parameter");
            tableParameter = dsParameter.Tables[0];

            Form2 frm = new Form2();
            frm.ao1 = Convert.ToDouble(tableParameter.Rows[20][4]).ToString(); 
            frm.bo1 = Convert.ToDouble(tableParameter.Rows[21][4]).ToString();
            frm.ao2 = Convert.ToDouble(tableParameter.Rows[24][4]).ToString();
            frm.bo2 = Convert.ToDouble(tableParameter.Rows[25][4]).ToString();
            frm.ao7 = Convert.ToDouble(tableParameter.Rows[22][4]).ToString();
            frm.bo7 = Convert.ToDouble(tableParameter.Rows[23][4]).ToString();
            frm.ao8 = Convert.ToDouble(tableParameter.Rows[26][4]).ToString();
            frm.bo8 = Convert.ToDouble(tableParameter.Rows[27][4]).ToString();
            frm.ao9 = Convert.ToDouble(tableParameter.Rows[28][4]).ToString();
            frm.bo9 = Convert.ToDouble(tableParameter.Rows[29][4]).ToString();
            frm.ao10 = Convert.ToDouble(tableParameter.Rows[30][4]).ToString();
            frm.bo10 = Convert.ToDouble(tableParameter.Rows[31][4]).ToString();
            frm.ao11 = Convert.ToDouble(tableParameter.Rows[32][4]).ToString();
            frm.bo11 = Convert.ToDouble(tableParameter.Rows[33][4]).ToString();
            frm.ao12 = Convert.ToDouble(tableParameter.Rows[34][4]).ToString();
            frm.bo12 = Convert.ToDouble(tableParameter.Rows[35][4]).ToString();
            frm.ao13 = Convert.ToDouble(tableParameter.Rows[36][4]).ToString();
            frm.bo13 = Convert.ToDouble(tableParameter.Rows[72][4]).ToString();
            frm.ao14 = Convert.ToDouble(tableParameter.Rows[68][4]).ToString();
            frm.bo14 = Convert.ToDouble(tableParameter.Rows[69][4]).ToString();
            frm.sons2 = Convert.ToDouble(tableParameter.Rows[71][4]).ToString();
            frm.tungaah = Convert.ToDouble(tableParameter.Rows[73][4]).ToString();

            frm.ao1d = Convert.ToDouble(tableParameter.Rows[40][4]).ToString();
            frm.ao2d = Convert.ToDouble(tableParameter.Rows[41][4]).ToString();
            frm.ao3d = Convert.ToDouble(tableParameter.Rows[42][4]).ToString();
            frm.ao4d = Convert.ToDouble(tableParameter.Rows[43][4]).ToString();
            frm.ao5d = Convert.ToDouble(tableParameter.Rows[44][4]).ToString();
            frm.ao6d = Convert.ToDouble(tableParameter.Rows[45][4]).ToString();

            frm.sons1 = Convert.ToDouble(tableParameter.Rows[70][4]).ToString();
            frm.t11 = Convert.ToDouble(tableParameter.Rows[74][4]).ToString();
            frm.yach31 = Convert.ToDouble(tableParameter.Rows[65][4]).ToString();
           
            double dotood_h = Convert.ToDouble(tableParameter.Rows[20][4]) + Convert.ToDouble(tableParameter.Rows[21][4]) + Convert.ToDouble(tableParameter.Rows[22][4]) + Convert.ToDouble(tableParameter.Rows[23][4]) + Convert.ToDouble(tableParameter.Rows[24][4]) + Convert.ToDouble(tableParameter.Rows[25][4]) + Convert.ToDouble(tableParameter.Rows[26][4]) + Convert.ToDouble(tableParameter.Rows[27][4]) + Convert.ToDouble(tableParameter.Rows[28][4]) + Convert.ToDouble(tableParameter.Rows[29][4]) + Convert.ToDouble(tableParameter.Rows[30][4]) + Convert.ToDouble(tableParameter.Rows[31][4]) + Convert.ToDouble(tableParameter.Rows[32][4]) + Convert.ToDouble(tableParameter.Rows[33][4]) + Convert.ToDouble(tableParameter.Rows[34][4]) + Convert.ToDouble(tableParameter.Rows[35][4]) + Convert.ToDouble(tableParameter.Rows[36][4]);
            dotood_h =  Math.Round((dotood_h + Convert.ToDouble(tableParameter.Rows[68][4]) + Convert.ToDouble(tableParameter.Rows[69][4]) + Convert.ToDouble(tableParameter.Rows[71][4]) + Convert.ToDouble(tableParameter.Rows[73][4])) / 1000 ,3);
            double dotood_d = Math.Round((Convert.ToDouble(tableParameter.Rows[40][4]) + Convert.ToDouble(tableParameter.Rows[41][4]) + Convert.ToDouble(tableParameter.Rows[42][4]) + Convert.ToDouble(tableParameter.Rows[43][4]) + Convert.ToDouble(tableParameter.Rows[44][4]) + Convert.ToDouble(tableParameter.Rows[45][4]) + Convert.ToDouble(tableParameter.Rows[74][4]) + Convert.ToDouble(tableParameter.Rows[70][4]) + Convert.ToDouble(tableParameter.Rows[65][4])) / 1000, 3);

            frm.niitu = dotood_h.ToString();
            frm.niitd = dotood_d.ToString();

            frm.Show();
        }

        private void tabPage9_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ExporttoExcel(dataGridView13, dateTimePicker1.Value.ToString("dd-MM-yyyy"));
        }
        private void button5_Click(object sender, EventArgs e)
        {
            ExporttoExcel1(dataGridView16, dateTimePicker1.Value.ToString("dd-MM-yyyy"));
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ExporttoExcel2(dataGridView3, dateTimePicker1.Value.ToString("dd-MM-yyyy"));
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ExporttoExcel3(dataGridView4, dateTimePicker1.Value.ToString("dd-MM-yyyy"));
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ExporttoExcel4(dataGridView2, dateTimePicker1.Value.ToString("dd-MM-yyyy"));
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ExporttoExcel5(dataGridView1, dateTimePicker1.Value.ToString("dd-MM-yyyy"));
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ExporttoExcel6(dataGridView17, dateTimePicker1.Value.ToString("dd-MM-yyyy"));
        }

        private void button11_Click(object sender, EventArgs e)
        {
            ExporttoExcel7(dataGridView19, dateTimePicker1.Value.ToString("dd-MM-yyyy"));
        }

        private void button12_Click(object sender, EventArgs e)
        {
            ExporttoExcel8(dataGridView14, dateTimePicker1.Value.ToString("dd-MM-yyyy"));
        }

        private void button13_Click(object sender, EventArgs e)
        {
            ExporttoExcel9(dataGridView15, dateTimePicker1.Value.ToString("dd-MM-yyyy"));
        }

        private void button16_Click(object sender, EventArgs e)
        {
            tootsooTimer.Stop();
            button16.BackColor = Color.Red;
            button17.BackColor = Color.Gray;
            button16.Text = "Зогссон";
            button17.Text = "Ажиллуулах";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            tootsooTimer.Start();
            button16.BackColor = Color.Gray;
            button17.BackColor = Color.Red;
            button16.Text = "Зогсоох";
            button17.Text = "Ажиллаж байна";
        }

        #endregion

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

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TabControl.SelectedIndex == 0)
            {
                graphicTimer.Stop();
                graphicDundTimer.Stop();
                graphicUndurTimer.Stop();
                generalSchemTimer.Stop();
                davtamjReadTimer.Stop();
                davtamjConnectTimer.Stop();
                wpfDateStoptimer.Stop();
                tootsooTimer.Start();
            }
            if (TabControl.SelectedIndex == 1)
            {
                wpfDateStoptimer.Stop();
                graphicDundTimer.Stop();
                graphicUndurTimer.Stop();
                generalSchemTimer.Stop();
                tootsooTimer.Stop();

                graphicTimer.Start();
                davtamjReadTimer.Start();
                davtamjConnectTimer.Start();
                if (!backgroundWorker1.IsBusy)
                    backgroundWorker1.RunWorkerAsync();

            }
            if (TabControl.SelectedIndex == 2)
            {
                wpfDateStoptimer.Stop();
                graphicTimer.Stop();
                graphicUndurTimer.Stop();
                generalSchemTimer.Stop();
                davtamjReadTimer.Stop();
                davtamjConnectTimer.Stop();
                tootsooTimer.Stop();
                graphicDundTimer.Start();
            }
            if (TabControl.SelectedIndex == 3)
            {
                wpfDateStoptimer.Stop();
                graphicTimer.Stop();
                graphicDundTimer.Stop();
                generalSchemTimer.Stop();
                davtamjReadTimer.Stop();
                davtamjConnectTimer.Stop();
                tootsooTimer.Stop();
                graphicUndurTimer.Start();
            }
            if (TabControl.SelectedIndex == 4)
            {
                graphicTimer.Stop();
                graphicDundTimer.Stop();
                graphicUndurTimer.Stop();
                generalSchemTimer.Stop();
                davtamjReadTimer.Stop();
                davtamjConnectTimer.Stop();
                tootsooTimer.Stop();
                wpfDateStoptimer.Stop();
                daalgavarTab(dateTimePicker1.Value);
            }
            if (TabControl.SelectedIndex == 5)
            {
                wpfDateStoptimer.Stop();
                graphicTimer.Stop();
                graphicDundTimer.Stop();
                graphicUndurTimer.Stop();
                generalSchemTimer.Stop();
                davtamjReadTimer.Stop();
                davtamjConnectTimer.Stop();
                tootsooTimer.Stop();
                Reactive_CosTab(dateTimePicker1.Value);
            }
            if (TabControl.SelectedIndex == 6)
            {
                wpfDateStoptimer.Stop();
                graphicTimer.Stop();
                graphicDundTimer.Stop();
                graphicUndurTimer.Stop();
                generalSchemTimer.Stop();
                davtamjReadTimer.Stop();
                davtamjConnectTimer.Stop();
                tootsooTimer.Stop();
                BTRTab(dateTimePicker1.Value);
            }
            if (TabControl.SelectedIndex == 7)
            {
                graphicTimer.Stop();
                graphicDundTimer.Stop();
                graphicUndurTimer.Stop();
                generalSchemTimer.Stop();
                davtamjReadTimer.Stop();
                davtamjConnectTimer.Stop();
                tootsooTimer.Stop();
                wpfDateStoptimer.Stop();
                DateTime guravHonogiinUmnu = DateTime.Now.AddDays(-2);
                if (dateTimePicker2.Value < guravHonogiinUmnu)
                {
                    SqlDataAdapter da4 = new SqlDataAdapter("select (select CONVERT (VARCHAR(8), tsag, 108) 'hh:mi:ss' ) AS Цаг, (select ROUND(tg1, 3)) AS ТГ1, (select ROUND(tg2, 3)) AS ТГ2, (select ROUND(tg3, 3)) AS ТГ3, (select ROUND(tg4, 3)) AS ТГ4, (select ROUND(niilber, 3)) AS Нийлбэр from dund where (select DATEPART(dd, tsag))=@unuudurdund and (select DATEPART(mm, tsag))=@odoogiinsardund  and (select DATEPART(yy, tsag))=@jildund ORDER BY id DESC", con);
                    da4.SelectCommand.Parameters.AddWithValue("@unuudurdund", dateTimePicker2.Value.Day);
                    da4.SelectCommand.Parameters.AddWithValue("@odoogiinsardund", dateTimePicker2.Value.Month);
                    da4.SelectCommand.Parameters.AddWithValue("@jildund", dateTimePicker2.Value.Year);
                    DataSet ds4 = new DataSet();
                    da4.Fill(ds4, "dund");
                    table_maxd = ds4.Tables[0];

                    SqlDataAdapter da5 = new SqlDataAdapter("select (select CONVERT (VARCHAR(8), tsag, 108) 'hh:mi:ss' ) AS Цаг, (select ROUND(tg5, 3)) AS ТГ5, (select ROUND(tg6, 3)) AS ТГ6, (select ROUND(tg7, 3)) AS ТГ7, (select ROUND(tg8, 3)) AS ТГ8, (select ROUND(tg9, 3)) AS ТГ9, (select ROUND(niilber, 3)) AS Нийлбэр, (select ROUND(niit, 3)) AS Нийт from undur where (select DATEPART(dd, tsag))=@unuudurundur and (select DATEPART(mm, tsag))=@odoogiinsarundur and (select DATEPART(yy, tsag))=@jilundur ORDER BY id DESC", con);
                    da5.SelectCommand.Parameters.AddWithValue("@unuudurundur", dateTimePicker2.Value.Day);
                    da5.SelectCommand.Parameters.AddWithValue("@odoogiinsarundur", dateTimePicker2.Value.Month);
                    da5.SelectCommand.Parameters.AddWithValue("@jilundur", dateTimePicker2.Value.Year);
                    DataSet ds5 = new DataSet();
                    da5.Fill(ds5, "undur");
                    table_maxu = ds5.Tables[0];

                }
                else
                {
                    SqlDataAdapter da4 = new SqlDataAdapter("select (select CONVERT (VARCHAR(8), tsag, 108) 'hh:mi:ss' ) AS Цаг, (select ROUND(tg1, 3)) AS ТГ1, (select ROUND(tg2, 3)) AS ТГ2, (select ROUND(tg3, 3)) AS ТГ3, (select ROUND(tg4, 3)) AS ТГ4, (select ROUND(niilber, 3)) AS Нийлбэр from dund1 where (select DATEPART(dd, tsag))=@unuudurdund and (select DATEPART(mm, tsag))=@odoogiinsardund  and (select DATEPART(yy, tsag))=@jildund ORDER BY id DESC", con);
                    da4.SelectCommand.Parameters.AddWithValue("@unuudurdund", dateTimePicker2.Value.Day);
                    da4.SelectCommand.Parameters.AddWithValue("@odoogiinsardund", dateTimePicker2.Value.Month);
                    da4.SelectCommand.Parameters.AddWithValue("@jildund", dateTimePicker2.Value.Year);
                    DataSet ds4 = new DataSet();
                    da4.Fill(ds4, "dund");
                    table_maxd = ds4.Tables[0];

                    SqlDataAdapter da5 = new SqlDataAdapter("select (select CONVERT (VARCHAR(8), tsag, 108) 'hh:mi:ss' ) AS Цаг, (select ROUND(tg5, 3)) AS ТГ5, (select ROUND(tg6, 3)) AS ТГ6, (select ROUND(tg7, 3)) AS ТГ7, (select ROUND(tg8, 3)) AS ТГ8, (select ROUND(tg9, 3)) AS ТГ9, (select ROUND(niilber, 3)) AS Нийлбэр, (select ROUND(niit, 3)) AS Нийт from undur1 where (select DATEPART(dd, tsag))=@unuudurundur and (select DATEPART(mm, tsag))=@odoogiinsarundur and (select DATEPART(yy, tsag))=@jilundur ORDER BY id DESC", con);
                    da5.SelectCommand.Parameters.AddWithValue("@unuudurundur", dateTimePicker2.Value.Day);
                    da5.SelectCommand.Parameters.AddWithValue("@odoogiinsarundur", dateTimePicker2.Value.Month);
                    da5.SelectCommand.Parameters.AddWithValue("@jilundur", dateTimePicker2.Value.Year);
                    DataSet ds5 = new DataSet();
                    da5.Fill(ds5, "undur");
                    table_maxu = ds5.Tables[0];


                }


                try
                {
                    connectionopen(cont);

                    SqlDataAdapter da = new SqlDataAdapter("select  *from  yalgawar1 where tolow7>0 ORDER BY id ASC", cont);
                    DataSet ds = new DataSet();
                    da.Fill(ds, "neg");
                    comboBox27.Items.Clear();
                    for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                    {
                        comboBox27.Items.Add(ds.Tables[0].Rows[i][34].ToString());
                        cname[i] = Convert.ToInt16(ds.Tables[0].Rows[i][42]);
                    }

                }
                catch { }

            }
            if (TabControl.SelectedIndex == 8)
            {
                graphicTimer.Stop();
                graphicDundTimer.Stop();
                graphicUndurTimer.Stop();
                davtamjReadTimer.Stop();
                davtamjConnectTimer.Stop();
                tootsooTimer.Stop();
                generalSchemTimer.Start();
                wpfDateStoptimer.Start();
                Balance();
            }
        }

        private void chart1_MouseMove_1(object sender, MouseEventArgs e)
        {


            var pos = e.Location;
            label17.Location = new Point(pos.X + 200, pos.Y + 200);

            if (prevPosition.HasValue && pos == prevPosition.Value)
                return;
            tooltip.RemoveAll();
            prevPosition = pos;
            var results = chart1.HitTest(pos.X, pos.Y, false, ChartElementType.PlottingArea);
            foreach (var result in results)
            {
                if (result.ChartElementType == ChartElementType.PlottingArea)
                {

                    var xVal = result.ChartArea.AxisX.PixelPositionToValue(pos.X);
                    var yVal = result.ChartArea.AxisY.PixelPositionToValue(pos.Y);
                    // label33.Text = yVal.ToString();
                    label17.Text = Math.Round(yVal, 3).ToString();

                }

            }
        }

        #region combobox selected index
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con1 = new SqlConnection();
            con1.ConnectionString = @"Server=192.168.20.85;Database=UI_hyanalt;User Id=hereglegch; Password=Passwd_123;";

            SqlCommand cmd = new SqlCommand("UPDATE Parameters SET Time_Stamp=@datetime, Tuluv_no=@t1 where id =58", con1);
            cmd.Parameters.AddWithValue("@datetime", DateTime.Now);
            cmd.Parameters.AddWithValue("@t1", comboBox1.SelectedItem);
            //   cmd.Parameters.AddWithValue("@daalgawar22", daalgawar1);
            con1.Open();
            if (cmd.ExecuteNonQuery() == 0)
            {
                MessageBox.Show("error");
            }
            con1.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con1 = new SqlConnection();
            con1.ConnectionString = @"Server=192.168.20.85;Database=UI_hyanalt;User Id=hereglegch; Password=Passwd_123;";

            SqlCommand cmd = new SqlCommand("UPDATE Parameters SET Time_Stamp=@datetime, Tuluv_no=@t1 where id =59", con1);
            cmd.Parameters.AddWithValue("@datetime", DateTime.Now);
            cmd.Parameters.AddWithValue("@t1", comboBox2.SelectedItem);
            con1.Open();
            if (cmd.ExecuteNonQuery() == 0)
            {
                MessageBox.Show("error");
            }
            con1.Close();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con1 = new SqlConnection();
            con1.ConnectionString = @"Server=192.168.20.85;Database=UI_hyanalt;User Id=hereglegch; Password=Passwd_123;";

            SqlCommand cmd = new SqlCommand("UPDATE Parameters SET Time_Stamp=@datetime, Tuluv_no=@t1 where id =60", con1);
            cmd.Parameters.AddWithValue("@datetime", DateTime.Now);
            cmd.Parameters.AddWithValue("@t1", comboBox3.SelectedItem);
            con1.Open();
            if (cmd.ExecuteNonQuery() == 0)
            {
                MessageBox.Show("error");
            }
            con1.Close();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con1 = new SqlConnection();
            con1.ConnectionString = @"Server=192.168.20.85;Database=UI_hyanalt;User Id=hereglegch; Password=Passwd_123;";

            SqlCommand cmd = new SqlCommand("UPDATE Parameters SET Time_Stamp=@datetime, Tuluv_no=@t1 where id =61", con1);
            cmd.Parameters.AddWithValue("@datetime", DateTime.Now);
            cmd.Parameters.AddWithValue("@t1", comboBox4.SelectedItem);

            con1.Open();
            if (cmd.ExecuteNonQuery() == 0)
            {
                MessageBox.Show("error");
            }
            con1.Close();
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con1 = new SqlConnection();
            con1.ConnectionString = @"Server=192.168.20.85;Database=UI_hyanalt;User Id=hereglegch; Password=Passwd_123;";

            SqlCommand cmd = new SqlCommand("UPDATE Parameters SET Time_Stamp=@datetime, Tuluv_no=@t1 where id =62", con1);
            cmd.Parameters.AddWithValue("@datetime", DateTime.Now);
            cmd.Parameters.AddWithValue("@t1", comboBox5.SelectedItem);

            con1.Open();
            if (cmd.ExecuteNonQuery() == 0)
            {
                MessageBox.Show("error");
            }
            con1.Close();
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con1 = new SqlConnection();
            con1.ConnectionString = @"Server=192.168.20.85;Database=UI_hyanalt;User Id=hereglegch; Password=Passwd_123;";

            SqlCommand cmd = new SqlCommand("UPDATE Parameters SET Time_Stamp=@datetime, Tuluv_no=@t1 where id =63", con1);
            cmd.Parameters.AddWithValue("@datetime", DateTime.Now);
            cmd.Parameters.AddWithValue("@t1", comboBox6.SelectedItem);

            con1.Open();
            if (cmd.ExecuteNonQuery() == 0)
            {
                MessageBox.Show("error");
            }
            con1.Close();
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con1 = new SqlConnection();
            con1.ConnectionString = @"Server=192.168.20.85;Database=UI_hyanalt;User Id=hereglegch; Password=Passwd_123;";

            SqlCommand cmd = new SqlCommand("UPDATE Parameters SET Time_Stamp=@datetime, Tuluv_no=@t1 where id =64", con1);
            cmd.Parameters.AddWithValue("@datetime", DateTime.Now);
            cmd.Parameters.AddWithValue("@t1", comboBox7.SelectedItem);

            con1.Open();
            if (cmd.ExecuteNonQuery() == 0)
            {
                MessageBox.Show("error");
            }
            con1.Close();
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con1 = new SqlConnection();
            con1.ConnectionString = @"Server=192.168.20.85;Database=UI_hyanalt;User Id=hereglegch; Password=Passwd_123;";

            SqlCommand cmd = new SqlCommand("UPDATE Parameters SET Time_Stamp=@datetime, Tuluv_no=@t1 where id =65", con1);
            cmd.Parameters.AddWithValue("@datetime", DateTime.Now);
            cmd.Parameters.AddWithValue("@t1", comboBox8.SelectedItem);

            con1.Open();
            if (cmd.ExecuteNonQuery() == 0)
            {
                MessageBox.Show("error");
            }
            con1.Close();
        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con1 = new SqlConnection();
            con1.ConnectionString = @"Server=192.168.20.85;Database=UI_hyanalt;User Id=hereglegch; Password=Passwd_123;";

            SqlCommand cmd = new SqlCommand("UPDATE Parameters SET Time_Stamp=@datetime, Tuluv_no=@t1 where id =66", con1);
            cmd.Parameters.AddWithValue("@datetime", DateTime.Now);
            cmd.Parameters.AddWithValue("@t1", comboBox9.SelectedItem);

            con1.Open();
            if (cmd.ExecuteNonQuery() == 0)
            {
                MessageBox.Show("error");
            }
            con1.Close();
        }

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con1 = new SqlConnection();
            con1.ConnectionString = @"Server=192.168.20.85;Database=UI_hyanalt;User Id=hereglegch; Password=Passwd_123;";

            SqlCommand cmd = new SqlCommand("UPDATE Parameters SET Time_Stamp=@datetime, Tuluv_no=@t1 where id =67", con1);
            cmd.Parameters.AddWithValue("@datetime", DateTime.Now);
            cmd.Parameters.AddWithValue("@t1", comboBox10.SelectedItem);

            con1.Open();
            if (cmd.ExecuteNonQuery() == 0)
            {
                MessageBox.Show("error");
            }
            con1.Close();
        }

        private void comboBox11_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con1 = new SqlConnection();
            con1.ConnectionString = @"Server=192.168.20.85;Database=UI_hyanalt;User Id=hereglegch; Password=Passwd_123;";

            SqlCommand cmd = new SqlCommand("UPDATE Parameters SET Time_Stamp=@datetime, Tuluv_no=@t1 where id =69", con1);
            cmd.Parameters.AddWithValue("@datetime", DateTime.Now);
            cmd.Parameters.AddWithValue("@t1", comboBox11.SelectedItem);

            con1.Open();
            if (cmd.ExecuteNonQuery() == 0)
            {
                MessageBox.Show("error");
            }
            con1.Close();

        }

        private void comboBox12_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con1 = new SqlConnection();
            con1.ConnectionString = @"Server=192.168.20.85;Database=UI_hyanalt;User Id=hereglegch; Password=Passwd_123;";

            SqlCommand cmd = new SqlCommand("UPDATE Parameters SET Time_Stamp=@datetime, Tuluv_no=@t1 where id =71", con1);
            cmd.Parameters.AddWithValue("@datetime", DateTime.Now);
            cmd.Parameters.AddWithValue("@t1", comboBox12.SelectedItem);

            con1.Open();
            if (cmd.ExecuteNonQuery() == 0)
            {
                MessageBox.Show("error");
            }
            con1.Close();
        }

        private void comboBox13_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con1 = new SqlConnection();
            con1.ConnectionString = @"Server=192.168.20.85;Database=UI_hyanalt;User Id=hereglegch; Password=Passwd_123;";

            SqlCommand cmd = new SqlCommand("UPDATE Parameters SET Time_Stamp=@datetime, Tuluv_no=@t1 where id =72", con1);
            cmd.Parameters.AddWithValue("@datetime", DateTime.Now);
            cmd.Parameters.AddWithValue("@t1", comboBox13.SelectedItem);

            con1.Open();
            if (cmd.ExecuteNonQuery() == 0)
            {
                MessageBox.Show("error");
            }
            con1.Close();
        }

        private void comboBox14_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con1 = new SqlConnection();
            con1.ConnectionString = @"Server=192.168.20.85;Database=UI_hyanalt;User Id=hereglegch; Password=Passwd_123;";

            SqlCommand cmd = new SqlCommand("UPDATE Parameters SET Time_Stamp=@datetime, Tuluv_no=@t1 where id =73", con1);
            cmd.Parameters.AddWithValue("@datetime", DateTime.Now);
            cmd.Parameters.AddWithValue("@t1", comboBox14.SelectedItem);

            con1.Open();
            if (cmd.ExecuteNonQuery() == 0)
            {
                MessageBox.Show("error");
            }
            con1.Close();
        }

        private void comboBox15_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con1 = new SqlConnection();
            con1.ConnectionString = @"Server=192.168.20.85;Database=UI_hyanalt;User Id=hereglegch; Password=Passwd_123;";

            SqlCommand cmd = new SqlCommand("UPDATE Parameters SET Time_Stamp=@datetime, Tuluv_no=@t1 where id =74", con1);
            cmd.Parameters.AddWithValue("@datetime", DateTime.Now);
            cmd.Parameters.AddWithValue("@t1", comboBox15.SelectedItem);

            con1.Open();
            if (cmd.ExecuteNonQuery() == 0)
            {
                MessageBox.Show("error");
            }
            con1.Close();
        }

        private void comboBox16_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con1 = new SqlConnection();
            con1.ConnectionString = @"Server=192.168.20.85;Database=UI_hyanalt;User Id=hereglegch; Password=Passwd_123;";

            SqlCommand cmd = new SqlCommand("UPDATE Parameters SET Time_Stamp=@datetime, Tuluv_no=@t1 where id =84", con1);
            cmd.Parameters.AddWithValue("@datetime", DateTime.Now);
            cmd.Parameters.AddWithValue("@t1", comboBox16.SelectedItem);

            con1.Open();
            if (cmd.ExecuteNonQuery() == 0)
            {
                MessageBox.Show("error");
            }
            con1.Close();
        }

        private void comboBox17_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con1 = new SqlConnection();
            con1.ConnectionString = @"Server=192.168.20.85;Database=UI_hyanalt;User Id=hereglegch; Password=Passwd_123;";

            SqlCommand cmd = new SqlCommand("UPDATE Parameters SET Time_Stamp=@datetime, Tuluv_no=@t1 where id =95", con1);
            cmd.Parameters.AddWithValue("@datetime", DateTime.Now);
            cmd.Parameters.AddWithValue("@t1", comboBox17.SelectedItem);

            con1.Open();
            if (cmd.ExecuteNonQuery() == 0)
            {
                MessageBox.Show("error");
            }
            con1.Close();
        }

        private void comboBox18_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con1 = new SqlConnection();
            con1.ConnectionString = @"Server=192.168.20.85;Database=UI_hyanalt;User Id=hereglegch; Password=Passwd_123;";

            SqlCommand cmd = new SqlCommand("UPDATE Parameters SET Time_Stamp=@datetime, Tuluv_no=@t1 where id =68", con1);
            cmd.Parameters.AddWithValue("@datetime", DateTime.Now);
            cmd.Parameters.AddWithValue("@t1", comboBox18.SelectedItem);

            con1.Open();
            if (cmd.ExecuteNonQuery() == 0)
            {
                MessageBox.Show("error");
            }
            con1.Close();
        }

        private void comboBox19_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con1 = new SqlConnection();
            con1.ConnectionString = @"Server=192.168.20.85;Database=UI_hyanalt;User Id=hereglegch; Password=Passwd_123;";

            SqlCommand cmd = new SqlCommand("UPDATE Parameters SET Time_Stamp=@datetime, Tuluv_no=@t1 where id =70", con1);
            cmd.Parameters.AddWithValue("@datetime", DateTime.Now);
            cmd.Parameters.AddWithValue("@t1", comboBox19.SelectedItem);

            con1.Open();
            if (cmd.ExecuteNonQuery() == 0)
            {
                MessageBox.Show("error");
            }
            con1.Close();
        }

        private void comboBox20_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con1 = new SqlConnection();
            con1.ConnectionString = @"Server=192.168.20.85;Database=UI_hyanalt;User Id=hereglegch; Password=Passwd_123;";

            SqlCommand cmd = new SqlCommand("UPDATE Parameters SET Time_Stamp=@datetime, Tuluv_no=@t1 where id =93", con1);
            cmd.Parameters.AddWithValue("@datetime", DateTime.Now);
            cmd.Parameters.AddWithValue("@t1", comboBox20.SelectedItem);

            con1.Open();
            if (cmd.ExecuteNonQuery() == 0)
            {
                MessageBox.Show("error");
            }
            con1.Close();
        }

        private void comboBox21_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con1 = new SqlConnection();
            con1.ConnectionString = @"Server=192.168.20.85;Database=UI_hyanalt;User Id=hereglegch; Password=Passwd_123;";

            SqlCommand cmd = new SqlCommand("UPDATE Parameters SET Time_Stamp=@datetime, Tuluv_no=@t1 where id =94", con1);
            cmd.Parameters.AddWithValue("@datetime", DateTime.Now);
            cmd.Parameters.AddWithValue("@t1", comboBox21.SelectedItem);

            con1.Open();
            if (cmd.ExecuteNonQuery() == 0)
            {
                MessageBox.Show("error");
            }
            con1.Close();
        }

        private void comboBox22_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con1 = new SqlConnection();
            con1.ConnectionString = @"Server=192.168.20.85;Database=UI_hyanalt;User Id=hereglegch; Password=Passwd_123;";

            SqlCommand cmd = new SqlCommand("UPDATE Parameters SET Time_Stamp=@datetime, Tuluv_no=@t1 where id =17", con1);
            cmd.Parameters.AddWithValue("@datetime", DateTime.Now);
            cmd.Parameters.AddWithValue("@t1", comboBox22.SelectedItem);

            con1.Open();
            if (cmd.ExecuteNonQuery() == 0)
            {
                MessageBox.Show("error");
            }
            con1.Close();
        }

        private void comboBox23_SelectedValueChanged(object sender, EventArgs e)
        {
            SqlConnection con1 = new SqlConnection();
            con1.ConnectionString = @"Server=192.168.20.85;Database=UI_hyanalt;User Id=hereglegch; Password=Passwd_123;";

            SqlCommand cmd = new SqlCommand("UPDATE Parameters SET Time_Stamp=@datetime, Tuluv_no=@t1 where id =18", con1);
            cmd.Parameters.AddWithValue("@datetime", DateTime.Now);
            cmd.Parameters.AddWithValue("@t1", comboBox23.SelectedItem);

            con1.Open();
            if (cmd.ExecuteNonQuery() == 0)
            {
                MessageBox.Show("error");
            }
            con1.Close();
        }

        private void comboBox24_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con1 = new SqlConnection();
            con1.ConnectionString = @"Server=192.168.20.85;Database=UI_hyanalt;User Id=hereglegch; Password=Passwd_123;";

            SqlCommand cmd = new SqlCommand("UPDATE Parameters SET Time_Stamp=@datetime, Tuluv_no=@t1 where id =74", con1);
            cmd.Parameters.AddWithValue("@datetime", DateTime.Now);
            cmd.Parameters.AddWithValue("@t1", comboBox24.SelectedItem);

            con1.Open();
            if (cmd.ExecuteNonQuery() == 0)
            {
                MessageBox.Show("error");
            }
            con1.Close();
        }

        private void comboBox25_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con1 = new SqlConnection();
            con1.ConnectionString = @"Server=192.168.20.85;Database=UI_hyanalt;User Id=hereglegch; Password=Passwd_123;";

            SqlCommand cmd = new SqlCommand("UPDATE Parameters SET Time_Stamp=@datetime, Tuluv_no=@t1 where id =20", con1);
            cmd.Parameters.AddWithValue("@datetime", DateTime.Now);
            cmd.Parameters.AddWithValue("@t1", comboBox25.SelectedItem);

            con1.Open();
            if (cmd.ExecuteNonQuery() == 0)
            {
                MessageBox.Show("error");
            }
            con1.Close();
        }

        #endregion



        private void dateTimerPickerEnd_Tick(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
        }
        private void button20_Click(object sender, EventArgs e)
        {
            client.Connect("192.168.20.85", Convert.ToInt32("5040"));
            client.WriteLineAndGetReply("#" + comboBox26.SelectedItem.ToString() + "#*" + textBox16.Text + "*", TimeSpan.FromSeconds(0));
            MessageBox.Show("Амжилттай");
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
                client1.Connect("192.168.20.85", Convert.ToInt32("8236"));
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
                label379.Invoke((MethodInvoker)delegate()
                {
                    double u = Math.Round(Convert.ToDouble(e.MessageString.Substring(0, e.MessageString.Length - 2)), 3);
                    label379.Text = u.ToString();
                });
            }

            catch { }

        }
        #endregion

        #region report MAX MIN

        public class aa
        {
            public double p0 { get; set; }
            public string p1 { get; set; }
            public double p2 { get; set; }
            public double p3 { get; set; }
            public double p4 { get; set; }
            public double p5 { get; set; }
            public double p6 { get; set; }
            public double p7 { get; set; }
            public double p8 { get; set; }
            public double p9 { get; set; }
            public double p10 { get; set; }
            public double p11 { get; set; }
            public double p12 { get; set; }
            public double p13 { get; set; }
            public double p14 { get; set; }
            public double p15 { get; set; }
            public double p16 { get; set; }
            public double p17 { get; set; }
            public double p18 { get; set; }
            public double p19 { get; set; }
            public double p20 { get; set; }
            public double p21 { get; set; }
            public double p22 { get; set; }
            public double p23 { get; set; }
            public double p24 { get; set; }
            public double p25 { get; set; }
            public double p26 { get; set; }
            public double p27 { get; set; }
            public double p28 { get; set; }
            public double p29 { get; set; }
            public double p30 { get; set; }
            public double p31 { get; set; }
            public double p32 { get; set; }
            public double p33 { get; set; }
            public double p34 { get; set; }
            public double p35 { get; set; }
            public double p36 { get; set; }
            public double p37 { get; set; }

        }

        #endregion
        private void generalSchemTimer_Tick(object sender, EventArgs e)
        {
            Parameter_tsah();
        }

        private void Parameter_tsah()
        {
            reply85 = isping.Send("192.168.20.85");
            ping85 = reply85.Status == IPStatus.Success;
            if (ping85 == true)
            {
                try
                {
                    SqlDataAdapter daParameter = new SqlDataAdapter("select *from Parameters order by id asc", conp);
                    DataSet dsParameter = new DataSet();
                    daParameter.Fill(dsParameter, "Parameter");
                    tableParameter = dsParameter.Tables[0];
                    #region 35
                    generalSchem.zam4aP = Math.Round(Convert.ToDouble(tableParameter.Rows[64][4]), 0).ToString();
                    generalSchem.zam4bP = Math.Round(Convert.ToDouble(tableParameter.Rows[67][4]), 0).ToString();
                    generalSchem.songinoaP = Math.Round(Convert.ToDouble(tableParameter.Rows[61][4]), 0).ToString();
                    generalSchem.songinobP = Math.Round(Convert.ToDouble(tableParameter.Rows[62][4]), 0).ToString();
                    generalSchem.esgiilehaP = Math.Round(Convert.ToDouble(tableParameter.Rows[59][4]), 0).ToString();
                    generalSchem.esgiilehbP = Math.Round(Convert.ToDouble(tableParameter.Rows[60][4]), 0).ToString();

                    generalSchem.zam4aI = Math.Round(Convert.ToDouble(tableParameter.Rows[64][3]), 0).ToString();
                    generalSchem.zam4bI = Math.Round(Convert.ToDouble(tableParameter.Rows[67][3]), 0).ToString();
                    generalSchem.songinoaI = Math.Round(Convert.ToDouble(tableParameter.Rows[61][3]), 0).ToString();
                    generalSchem.songinobI = Math.Round(Convert.ToDouble(tableParameter.Rows[62][3]), 0).ToString();
                    generalSchem.esgiilehaI = Math.Round(Convert.ToDouble(tableParameter.Rows[59][3]), 0).ToString();
                    generalSchem.esgiilehbI = Math.Round(Convert.ToDouble(tableParameter.Rows[60][3]), 0).ToString();

                    #endregion
                    #region tg9

                    if (Convert.ToInt16(tableParameter.Rows[13][4]) > 0)
                    {
                        generalSchem.TG9P = Math.Round(Convert.ToDouble(tableParameter.Rows[13][4]), 2).ToString();
                        generalSchem.TG9 = 1;
                    }
                    else
                    {
                        generalSchem.TG9P = "0 ";
                        generalSchem.TG9 = 2;
                    }

                    #endregion

                    #region BTR
                    //btr5
                    generalSchem.BTR5U = Math.Round(Convert.ToDouble(tableParameter.Rows[9][2]), 2).ToString();
                    generalSchem.BTR5I = Math.Round(Convert.ToDouble(tableParameter.Rows[9][3]), 2).ToString();
                    generalSchem.BTR5P = Math.Round(Convert.ToDouble(tableParameter.Rows[9][4]), 2).ToString();
                    generalSchem.BTR5Q = Math.Round(Convert.ToDouble(tableParameter.Rows[9][5]), 2).ToString();
                    generalSchem.BTR5PF = Math.Round(Convert.ToDouble(tableParameter.Rows[9][6]), 2).ToString();

                    //btr6
                    generalSchem.BTR6U = Math.Round(Convert.ToDouble(tableParameter.Rows[10][2]), 2).ToString();
                    generalSchem.BTR6I = Math.Round(Convert.ToDouble(tableParameter.Rows[10][3]), 2).ToString();
                    generalSchem.BTR6P = Math.Round(Convert.ToDouble(tableParameter.Rows[10][4]), 2).ToString();
                    generalSchem.BTR6Q = Math.Round(Convert.ToDouble(tableParameter.Rows[10][5]), 2).ToString();
                    generalSchem.BTR6PF = Math.Round(Convert.ToDouble(tableParameter.Rows[10][6]), 2).ToString();

                    //btr7
                    generalSchem.BTR7U = Math.Round(Convert.ToDouble(tableParameter.Rows[11][2]), 2).ToString();
                    generalSchem.BTR7I = Math.Round(Convert.ToDouble(tableParameter.Rows[11][3]), 2).ToString();
                    generalSchem.BTR7P = Math.Round(Convert.ToDouble(tableParameter.Rows[11][4]), 2).ToString();
                    generalSchem.BTR7Q = Math.Round(Convert.ToDouble(tableParameter.Rows[11][5]), 2).ToString();
                    generalSchem.BTR7PF = Math.Round(Convert.ToDouble(tableParameter.Rows[11][6]), 2).ToString();

                    //btr8
                    generalSchem.BTR8U = Math.Round(Convert.ToDouble(tableParameter.Rows[12][2]), 2).ToString();
                    generalSchem.BTR8I = Math.Round(Convert.ToDouble(tableParameter.Rows[12][3]), 2).ToString();
                    generalSchem.BTR8P = Math.Round(Convert.ToDouble(tableParameter.Rows[12][4]), 2).ToString();
                    generalSchem.BTR8Q = Math.Round(Convert.ToDouble(tableParameter.Rows[12][5]), 2).ToString();
                    generalSchem.BTR8PF = Math.Round(Convert.ToDouble(tableParameter.Rows[12][6]), 2).ToString();
                    #endregion
                    #region ao bo undur


                    #region 12t
                    generalSchem.T12U = Math.Round(Convert.ToDouble(tableParameter.Rows[15][2]), 2).ToString();
                    generalSchem.T12I = Math.Round(Convert.ToDouble(tableParameter.Rows[15][3]), 2).ToString();
                    generalSchem.T12P = Math.Round(Convert.ToDouble(tableParameter.Rows[15][4]), 2).ToString();
                    generalSchem.T12Q = Math.Round(Convert.ToDouble(tableParameter.Rows[15][5]), 2).ToString();
                    generalSchem.T12PF = Math.Round(Convert.ToDouble(tableParameter.Rows[15][6]), 2).ToString();

                    #endregion


                    #region haalt
                    if (((Convert.ToDouble(tableParameter.Rows[20][7]) == 0) && (Convert.ToDouble(tableParameter.Rows[20][8]) == 1)) || ((Convert.ToDouble(tableParameter.Rows[21][7]) == 0) && (Convert.ToDouble(tableParameter.Rows[21][8]) == 1)))
                        generalSchem.P76 = 1;
                    else generalSchem.P76 = 2;

                    if (((Convert.ToDouble(tableParameter.Rows[22][7]) == 0) && (Convert.ToDouble(tableParameter.Rows[22][8]) == 1)) || ((Convert.ToDouble(tableParameter.Rows[23][7]) == 0) && (Convert.ToDouble(tableParameter.Rows[23][8]) == 1)))
                        generalSchem.P79 = 1;
                    else generalSchem.P79 = 2;

                    if (((Convert.ToDouble(tableParameter.Rows[24][7]) == 0) && (Convert.ToDouble(tableParameter.Rows[24][8]) == 1)) || ((Convert.ToDouble(tableParameter.Rows[25][7]) == 0) && (Convert.ToDouble(tableParameter.Rows[25][8]) == 1)))
                        generalSchem.P77 = 1;
                    else generalSchem.P77 = 2;



                    if (((Convert.ToDouble(tableParameter.Rows[26][7]) == 0) && (Convert.ToDouble(tableParameter.Rows[26][8]) == 1)) || ((Convert.ToDouble(tableParameter.Rows[27][7]) == 0) && (Convert.ToDouble(tableParameter.Rows[27][8]) == 1)))
                        generalSchem.P78 = 1;
                    else generalSchem.P78 = 2;



                    if (((Convert.ToDouble(tableParameter.Rows[28][7]) == 0) && (Convert.ToDouble(tableParameter.Rows[28][8]) == 1)) || ((Convert.ToDouble(tableParameter.Rows[29][7]) == 0) && (Convert.ToDouble(tableParameter.Rows[29][8]) == 1)))
                        generalSchem.P80 = 1;
                    else generalSchem.P80 = 2;


                    if (((Convert.ToDouble(tableParameter.Rows[30][7]) == 0) && (Convert.ToDouble(tableParameter.Rows[30][8]) == 1)) || ((Convert.ToDouble(tableParameter.Rows[31][7]) == 0) && (Convert.ToDouble(tableParameter.Rows[31][8]) == 1)))
                        generalSchem.P82 = 1;
                    else generalSchem.P82 = 2;



                    if (((Convert.ToDouble(tableParameter.Rows[32][7]) == 0) && (Convert.ToDouble(tableParameter.Rows[32][8]) == 1)) || ((Convert.ToDouble(tableParameter.Rows[33][7]) == 0) && (Convert.ToDouble(tableParameter.Rows[33][8]) == 1)))
                        generalSchem.P81 = 1;
                    else generalSchem.P81 = 2;


                    if (((Convert.ToDouble(tableParameter.Rows[34][7]) == 0) && (Convert.ToDouble(tableParameter.Rows[34][8]) == 1)) || ((Convert.ToDouble(tableParameter.Rows[35][7]) == 0) && (Convert.ToDouble(tableParameter.Rows[35][8]) == 1)))
                        generalSchem.P84 = 1;
                    else generalSchem.P84 = 2;

                    #endregion
                    #endregion
                    #region dund ao
                    #region 1 ao

                    generalSchem.ao1U = Math.Round(Convert.ToDouble(tableParameter.Rows[40][2]), 2).ToString();
                    generalSchem.ao1I = Math.Round(Convert.ToDouble(tableParameter.Rows[40][3]), 2).ToString();
                    generalSchem.ao1P = Math.Round(Convert.ToDouble(tableParameter.Rows[40][4]), 2).ToString();
                    generalSchem.ao1Q = Math.Round(Convert.ToDouble(tableParameter.Rows[40][5]), 2).ToString();
                    generalSchem.ao1PF = Math.Round(Convert.ToDouble(tableParameter.Rows[40][6]), 2).ToString();

                    if ((Convert.ToInt16(tableParameter.Rows[40][7]) == 0) && (Convert.ToInt16(tableParameter.Rows[40][8]) == 1))
                        generalSchem.ao1 = 1;
                    else if ((Convert.ToInt16(tableParameter.Rows[40][7]) == 1) && (Convert.ToInt16(tableParameter.Rows[40][8]) == 0))
                        generalSchem.ao1 = 2;
                    else
                        generalSchem.ao1 = 3;

                    #endregion
                    #region 2 ao

                    generalSchem.ao2U = Math.Round(Convert.ToDouble(tableParameter.Rows[41][2]), 2).ToString();
                    generalSchem.ao2I = Math.Round(Convert.ToDouble(tableParameter.Rows[41][3]), 2).ToString();
                    generalSchem.ao2P = Math.Round(Convert.ToDouble(tableParameter.Rows[41][4]), 2).ToString();
                    generalSchem.ao2Q = Math.Round(Convert.ToDouble(tableParameter.Rows[41][5]), 2).ToString();
                    generalSchem.ao2PF = Math.Round(Convert.ToDouble(tableParameter.Rows[41][6]), 2).ToString();
                    if ((Convert.ToInt16(tableParameter.Rows[41][7]) == 0) && (Convert.ToInt16(tableParameter.Rows[41][8]) == 1))
                        generalSchem.ao2 = 1;
                    else if ((Convert.ToInt16(tableParameter.Rows[41][7]) == 1) && (Convert.ToInt16(tableParameter.Rows[41][8]) == 0))
                        generalSchem.ao2 = 2;
                    else
                        generalSchem.ao2 = 3;


                    #endregion
                    #region 3 ao
                    generalSchem.ao3U = Math.Round(Convert.ToDouble(tableParameter.Rows[42][2]), 2).ToString();
                    generalSchem.ao3I = Math.Round(Convert.ToDouble(tableParameter.Rows[42][3]), 2).ToString();
                    generalSchem.ao3P = Math.Round(Convert.ToDouble(tableParameter.Rows[42][4]), 2).ToString();
                    generalSchem.ao3Q = Math.Round(Convert.ToDouble(tableParameter.Rows[42][5]), 2).ToString();
                    generalSchem.ao3PF = Math.Round(Convert.ToDouble(tableParameter.Rows[42][6]), 2).ToString();
                    if ((Convert.ToInt16(tableParameter.Rows[42][7]) == 0) && (Convert.ToInt16(tableParameter.Rows[42][8]) == 1))
                        generalSchem.ao3 = 1;
                    else if ((Convert.ToInt16(tableParameter.Rows[42][7]) == 1) && (Convert.ToInt16(tableParameter.Rows[42][8]) == 0))
                        generalSchem.ao3 = 2;
                    else
                        generalSchem.ao3 = 3;


                    #endregion
                    #region 4 ao

                    generalSchem.ao4U = Math.Round(Convert.ToDouble(tableParameter.Rows[43][2]), 2).ToString();
                    generalSchem.ao4I = Math.Round(Convert.ToDouble(tableParameter.Rows[43][3]), 2).ToString();
                    generalSchem.ao4P = Math.Round(Convert.ToDouble(tableParameter.Rows[43][4]), 2).ToString();
                    generalSchem.ao4Q = Math.Round(Convert.ToDouble(tableParameter.Rows[43][5]), 2).ToString();
                    generalSchem.ao4PF = Math.Round(Convert.ToDouble(tableParameter.Rows[43][6]), 2).ToString();
                    if ((Convert.ToInt16(tableParameter.Rows[43][7]) == 0) && (Convert.ToInt16(tableParameter.Rows[43][8]) == 1))
                        generalSchem.ao4 = 1;
                    else if ((Convert.ToInt16(tableParameter.Rows[43][7]) == 1) && (Convert.ToInt16(tableParameter.Rows[43][8]) == 0))
                        generalSchem.ao4 = 2;
                    else
                        generalSchem.ao4 = 3;

                    #endregion
                    #region 5 ao

                    generalSchem.ao5U = Math.Round(Convert.ToDouble(tableParameter.Rows[44][2]), 2).ToString();
                    generalSchem.ao5I = Math.Round(Convert.ToDouble(tableParameter.Rows[44][3]), 2).ToString();
                    generalSchem.ao5P = Math.Round(Convert.ToDouble(tableParameter.Rows[44][4]), 2).ToString();
                    generalSchem.ao5Q = Math.Round(Convert.ToDouble(tableParameter.Rows[44][5]), 2).ToString();
                    generalSchem.ao5PF = Math.Round(Convert.ToDouble(tableParameter.Rows[44][6]), 2).ToString();
                    if ((Convert.ToInt16(tableParameter.Rows[44][7]) == 0) && (Convert.ToInt16(tableParameter.Rows[44][8]) == 1))
                        generalSchem.ao5 = 1;
                    else if ((Convert.ToInt16(tableParameter.Rows[44][7]) == 1) && (Convert.ToInt16(tableParameter.Rows[44][8]) == 0))
                        generalSchem.ao5 = 2;
                    else
                        generalSchem.ao5 = 3;

                    #endregion
                    #region 6 ao

                    generalSchem.ao6U = Math.Round(Convert.ToDouble(tableParameter.Rows[45][2]), 2).ToString();
                    generalSchem.ao6I = Math.Round(Convert.ToDouble(tableParameter.Rows[45][3]), 2).ToString();
                    generalSchem.ao6P = Math.Round(Convert.ToDouble(tableParameter.Rows[45][4]), 2).ToString();
                    generalSchem.ao6Q = Math.Round(Convert.ToDouble(tableParameter.Rows[45][5]), 2).ToString();
                    generalSchem.ao6PF = Math.Round(Convert.ToDouble(tableParameter.Rows[45][6]), 2).ToString();
                    if ((Convert.ToInt16(tableParameter.Rows[45][7]) == 0) && (Convert.ToInt16(tableParameter.Rows[45][8]) == 1))
                        generalSchem.ao6 = 1;
                    else if ((Convert.ToInt16(tableParameter.Rows[45][7]) == 1) && (Convert.ToInt16(tableParameter.Rows[45][8]) == 0))
                        generalSchem.ao6 = 2;
                    else
                        generalSchem.ao6 = 3;


                    #endregion
                    #endregion
                    #region t1

                    generalSchem.T1U = Math.Round(Convert.ToDouble(tableParameter.Rows[16][2]), 2).ToString();
                    generalSchem.T1I = Math.Round(Convert.ToDouble(tableParameter.Rows[16][3]), 2).ToString();
                    generalSchem.T1P = Math.Round(Convert.ToDouble(tableParameter.Rows[16][4]) / 1000, 2).ToString();
                    generalSchem.T1Q = Math.Round(Convert.ToDouble(tableParameter.Rows[16][5]) / 1000, 2).ToString();
                    generalSchem.T1PF = Math.Round(Convert.ToDouble(tableParameter.Rows[16][6]), 2).ToString();
                    if (Convert.ToInt16(tableParameter.Rows[16][8]) == 1)
                        generalSchem.T1l = 1;
                    else
                        generalSchem.T1l = 2;

                    #endregion
                    #region t2

                    generalSchem.T2U = Math.Round(Convert.ToDouble(tableParameter.Rows[17][2]), 2).ToString();
                    generalSchem.T2I = Math.Round(Convert.ToDouble(tableParameter.Rows[17][3]), 2).ToString();
                    generalSchem.T2P = Math.Round(Convert.ToDouble(tableParameter.Rows[17][4]) / 1000, 2).ToString();
                    generalSchem.T2Q = Math.Round(Convert.ToDouble(tableParameter.Rows[17][5]) / 1000, 2).ToString();
                    generalSchem.T2PF = Math.Round(Convert.ToDouble(tableParameter.Rows[17][6]), 2).ToString();
                    if (Convert.ToInt16(tableParameter.Rows[17][8]) == 1)
                        generalSchem.T2l = 1;
                    else
                        generalSchem.T2l = 2;

                    #endregion
                    #region 110kV shugam
                    // 12t 110
                    if ((Convert.ToDouble(tableParameter.Rows[14][7].ToString()) == 1) && (Convert.ToDouble(tableParameter.Rows[14][8].ToString()) == 0))
                        generalSchem.T12_110l = 1;
                    else generalSchem.T12_110l = 2;


                    // L 105
                    if (Convert.ToDouble(tableParameter.Rows[46][8].ToString()) == 1)
                        generalSchem.L105l = 1;
                    else generalSchem.L105l = 2;

                    // btr 7



                    // 106
                    if (Convert.ToDouble(tableParameter.Rows[47][8].ToString()) == 1)
                        generalSchem.L106l = 1;
                    else generalSchem.L106l = 2;

                    //  btr 6



                    //  toirog
                    if (Convert.ToDouble(tableParameter.Rows[48][8].ToString()) == 1)
                        generalSchem.toirogl = 1;
                    else generalSchem.toirogl = 2;

                    //  btr 5



                    //  11kv holbogch
                    if (Convert.ToDouble(tableParameter.Rows[49][8].ToString()) == 1)
                        generalSchem.holbogch_11kVl = 1;
                    else generalSchem.holbogch_11kVl = 2;

                    //  uildwer
                    if (Convert.ToDouble(tableParameter.Rows[60][8].ToString()) == 1)
                        generalSchem.uildverl = 1;
                    else generalSchem.uildverl = 2;

                    //  t2 110
                    if (Convert.ToDouble(tableParameter.Rows[51][8].ToString()) == 1)
                        generalSchem.T2_110kVl = 1;
                    else generalSchem.T2_110kVl = 2;


                    //  l111
                    if (Convert.ToDouble(tableParameter.Rows[52][8].ToString()) == 1)
                        generalSchem.L111l = 1;
                    else generalSchem.L111l = 2;

                    // l112
                    if (Convert.ToDouble(tableParameter.Rows[53][8].ToString()) == 1)
                        generalSchem.L112l = 1;
                    else generalSchem.L112l = 2;

                    //  t1 110
                    if (Convert.ToDouble(tableParameter.Rows[54][8].ToString()) == 1)
                        generalSchem.T1_110kVl = 1;
                    else generalSchem.T1_110kVl = 2;

                    #endregion
                    #region 35kV

                    //  hobloo a

                    if (Convert.ToDouble(tableParameter.Rows[55][8].ToString()) == 1)
                        generalSchem.holboo_al = 1;
                    else generalSchem.holboo_al = 2;

                    //  t1 35
                    if (Convert.ToDouble(tableParameter.Rows[56][8].ToString()) == 1)
                        generalSchem.t1_35l = 1;
                    else generalSchem.t1_35l = 2;

                    //  holboo b
                    if (Convert.ToDouble(tableParameter.Rows[57][8].ToString()) == 1)
                        generalSchem.holboo_bl = 1;
                    else generalSchem.holboo_bl = 2;

                    // esgiileh  a
                    if (Convert.ToDouble(tableParameter.Rows[59][8].ToString()) == 1)
                        generalSchem.esgiileh_al = 1;
                    else generalSchem.esgiileh_al = 2;

                    // esgiileh b

                    if (Convert.ToDouble(tableParameter.Rows[60][8].ToString()) == 1)
                        generalSchem.esgiileh_bl = 1;
                    else generalSchem.esgiileh_bl = 2;

                    // t2 35
                    if (Convert.ToDouble(tableParameter.Rows[58][8].ToString()) == 1)
                        generalSchem.t2_35l = 1;
                    else generalSchem.t2_35l = 2;

                    //  songino a
                    if (Convert.ToDouble(tableParameter.Rows[61][8].ToString()) == 1)
                        generalSchem.songino_al = 1;
                    else generalSchem.songino_al = 2;

                    //  songino b
                    if (Convert.ToDouble(tableParameter.Rows[62][8].ToString()) == 1)
                        generalSchem.songino_bl = 1;
                    else generalSchem.songino_bl = 2;

                    //  4zam a
                    if (Convert.ToDouble(tableParameter.Rows[64][8].ToString()) == 1)
                        generalSchem.L4zam_al = 1;
                    else generalSchem.L4zam_al = 2;

                    //  4zam b
                    if (Convert.ToDouble(tableParameter.Rows[65][8].ToString()) == 1)
                        generalSchem.L4zam_bl = 1;
                    else generalSchem.L4zam_bl = 2;

                    //  10t 35
                    if (Convert.ToDouble(tableParameter.Rows[63][8].ToString()) == 1)
                        generalSchem.t10_35l = 1;
                    else generalSchem.t10_35l = 2;

                    // t2 6kV
                    if (Convert.ToDouble(tableParameter.Rows[17][8].ToString()) == 1)
                        generalSchem.T2_6kVl = 1;
                    else generalSchem.T2_6kVl = 2;

                    /*
                    //  gru_section_holbogch1
                    if (Convert.ToDouble(tableParameter.Rows[66][8].ToString()) == 1)
                        generalSchem.gru1l = 1;
                    else generalSchem.gru1l = 2;

                    //  gru_section_holbogch2
                    if (Convert.ToDouble(tableParameter.Rows[67][8].ToString()) == 1)
                        generalSchem.gru2l = 1;
                    else generalSchem.gru2l = 2;
                    */

                    // t1 6kV
                    if (Convert.ToDouble(tableParameter.Rows[16][8].ToString()) == 1)
                        generalSchem.T1_6kVl = 1;
                    else generalSchem.T1_6kVl = 2;


                    // t12 6kV
                    if ((Convert.ToDouble(tableParameter.Rows[15][7].ToString()) == 1) && (Convert.ToDouble(tableParameter.Rows[15][8].ToString()) == 0))
                        generalSchem.T12 = 1;
                    else generalSchem.T12 = 2;

                    #endregion
                    #region t10
                    generalSchem.T10U = Math.Round(Convert.ToDouble(tableParameter.Rows[63][2]), 2).ToString();
                    generalSchem.T10I = Math.Round(Convert.ToDouble(tableParameter.Rows[63][3]), 2).ToString();
                    generalSchem.T10P = Math.Round(Convert.ToDouble(tableParameter.Rows[63][4]), 1).ToString();
                    generalSchem.T10Q = Math.Round(Convert.ToDouble(tableParameter.Rows[63][5]), 1).ToString();
                    generalSchem.T10PF = Math.Round(Convert.ToDouble(tableParameter.Rows[63][6]), 2).ToString();
                    if (Convert.ToDouble(tableParameter.Rows[65][3]) >= 1)
                    {
                        generalSchem.T10l = 1;
                    }
                    else if (Convert.ToDouble(tableParameter.Rows[65][2]) > 0)
                    {
                        generalSchem.T10l = 2;
                    }
                    else
                    {
                        generalSchem.T10l = 3;
                    }

                    #endregion
                    #region Ych53_13BO
                    generalSchem.R13rbU = Math.Round(Convert.ToDouble(tableParameter.Rows[38][2]), 2).ToString();
                    generalSchem.R13rbI = Math.Round(Convert.ToDouble(tableParameter.Rows[38][3]), 2).ToString();
                    generalSchem.R13rbP = Math.Round(Convert.ToDouble(tableParameter.Rows[38][4]), 1).ToString();
                    generalSchem.R13rbQ = Math.Round(Convert.ToDouble(tableParameter.Rows[38][5]), 1).ToString();
                    generalSchem.R13rbPF = Math.Round(Convert.ToDouble(tableParameter.Rows[38][6]), 2).ToString();
                    if (Convert.ToDouble(tableParameter.Rows[38][3]) >= 1)
                    {
                        generalSchem.Ych53_13BO = 1;
                    }
                    else if (Convert.ToDouble(tableParameter.Rows[38][2]) > 0)
                    {
                        generalSchem.Ych53_13BO = 2;
                    }
                    else
                    {
                        generalSchem.Ych53_13BO = 3;
                    }
                    #endregion
                    #region Ych04
                    generalSchem.YCHU = Math.Round(Convert.ToDouble(tableParameter.Rows[75][2]), 2).ToString();
                    generalSchem.YCHI = Math.Round(Convert.ToDouble(tableParameter.Rows[75][3]), 2).ToString();
                    generalSchem.YCHP = Math.Round(Convert.ToDouble(tableParameter.Rows[75][4]), 1).ToString();
                    generalSchem.YCHQ = Math.Round(Convert.ToDouble(tableParameter.Rows[75][5]), 1).ToString();
                    generalSchem.YCHPF = Math.Round(Convert.ToDouble(tableParameter.Rows[75][6]), 2).ToString();
                    if (Convert.ToDouble(tableParameter.Rows[75][3]) >= 1)
                    {
                        generalSchem.Ych04 = 1;
                    }
                    else if (Convert.ToDouble(tableParameter.Rows[75][2]) > 0)
                    {
                        generalSchem.Ych04 = 2;
                    }
                    else
                    {
                        generalSchem.Ych04 = 3;
                    }
                    #endregion
                    #region gru sekts holbogch
                    generalSchem.gru1l = 1;
                    generalSchem.gru2l = 1;
                    #endregion
                    #region dotood heregtsee

                    double dotood_h = Convert.ToDouble(tableParameter.Rows[20][4]) + Convert.ToDouble(tableParameter.Rows[21][4]) + Convert.ToDouble(tableParameter.Rows[22][4]) + Convert.ToDouble(tableParameter.Rows[23][4]) + Convert.ToDouble(tableParameter.Rows[24][4]) + Convert.ToDouble(tableParameter.Rows[25][4]) + Convert.ToDouble(tableParameter.Rows[26][4]) + Convert.ToDouble(tableParameter.Rows[27][4]) + Convert.ToDouble(tableParameter.Rows[28][4]) + Convert.ToDouble(tableParameter.Rows[29][4]) + Convert.ToDouble(tableParameter.Rows[30][4]) + Convert.ToDouble(tableParameter.Rows[31][4]) + Convert.ToDouble(tableParameter.Rows[32][4]) + Convert.ToDouble(tableParameter.Rows[33][4]) + Convert.ToDouble(tableParameter.Rows[34][4]) + Convert.ToDouble(tableParameter.Rows[35][4]) + Convert.ToDouble(tableParameter.Rows[36][4]);
                    dotood_h = dotood_h + Convert.ToDouble(tableParameter.Rows[68][4]) + Convert.ToDouble(tableParameter.Rows[69][4]) + Convert.ToDouble(tableParameter.Rows[71][4]) + Convert.ToDouble(tableParameter.Rows[73][4]);
                    double dotood_d = Math.Round((Convert.ToDouble(tableParameter.Rows[40][4]) + Convert.ToDouble(tableParameter.Rows[41][4]) + Convert.ToDouble(tableParameter.Rows[42][4]) + Convert.ToDouble(tableParameter.Rows[43][4]) + Convert.ToDouble(tableParameter.Rows[44][4]) + Convert.ToDouble(tableParameter.Rows[45][4]) + Convert.ToDouble(tableParameter.Rows[74][4]) + Convert.ToDouble(tableParameter.Rows[70][4]) + Convert.ToDouble(tableParameter.Rows[65][4])) / 1000, 3);
                    generalSchem.Dund_Real_P = Math.Round(dotood_d, 3).ToString();
                    generalSchem.Undur_Real_P = Math.Round(dotood_h / 1000, 3).ToString();
                    generalSchem.Niit_Real_P = Math.Round((dotood_h / 1000 + dotood_d), 3).ToString();
                    #endregion
                }
                catch { }
            }
        }
        private void Balance()
        {
            reply85 = isping.Send("192.168.20.85");
            ping85 = reply85.Status == IPStatus.Success;
            
          
          
            reply50 = isping.Send("192.168.20.50");
            ping50 = reply50.Status == IPStatus.Success;

            #region start
            DateTime onoodor = DateTime.Now;
            DateTime ochigdor = onoodor.AddDays(-1);
            DateTime urjigdar = onoodor.AddDays(-2);
            string strDate = generalSchem.blDateStart;
            DateTime clock = DateTime.ParseExact(strDate, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            string strDate1 = generalSchem.blDateStop;
            DateTime clock1 = DateTime.ParseExact(strDate, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            SqlDataAdapter da;
            DataSet ds;
            Double a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15, a16, a17, a18;
            int odod = 0;
            if ((clock.Day == onoodor.Day) && (clock.Month == onoodor.Month) && (clock.Year == onoodor.Year))
            {
                odod = 1;
            }
            if ((clock.Day == ochigdor.Day) && (clock.Month == ochigdor.Month) && (clock.Year == ochigdor.Year))
            {
                odod = 1;
            }
            if ((clock.Day == urjigdar.Day) && (clock.Month == urjigdar.Month) && (clock.Year == urjigdar.Year))
            {
                odod = 1;
            }
            string[] hayag = new string[80];
            if (odod == 1)
            {

                hayag[1] = "neg1";
                hayag[7] = "doloo1";
                hayag[2] = "tworo1";
                hayag[8] = "naimr1";
                hayag[9] = "esr1";
                hayag[10] = "araw1";
                hayag[11] = "arawneg1";
                hayag[12] = "arawtwo1";
                hayag[13] = "arawguraw1";
                hayag[15] = "zaaltguraw1";
                hayag[27] = "doloon1";
                hayag[28] = "naimn1";
                hayag[29] = "esn1";
                hayag[30] = "arawn1";
                hayag[31] = "arawnegn1";
                hayag[32] = "arawhoyorn1";
                hayag[33] = "arawguravn1";
                hayag[14] = "zaaltguraw1";
                hayag[51] = "rusn_6_11";
                hayag[52] = "rusn_6_21";
                hayag[53] = "rusn_6_31";
                hayag[54] = "rusn_6_41";
                hayag[55] = "rusn_6_51";
                hayag[56] = "rusn_6_61";
                hayag[57] = "gru1";
                hayag[58] = "oru1";
                hayag[59] = "zaalt1";
                hayag[35] = "petzaalt";
            }
            else
            {
                hayag[1] = "neg";
                hayag[7] = "doloo";
                hayag[2] = "tworo";
                hayag[8] = "naimr";
                hayag[9] = "esr";
                hayag[10] = "araw";
                hayag[11] = "arawneg";
                hayag[12] = "arawtwo";
                hayag[13] = "arawguraw";
                hayag[15] = "zaaltguraw";
                hayag[27] = "doloon";
                hayag[28] = "naimn";
                hayag[29] = "esn";
                hayag[30] = "arawn";
                hayag[31] = "arawnegn";
                hayag[32] = "arawhoyorn";
                hayag[33] = "arawguravn";
                hayag[14] = "zaaltguraw";
                hayag[51] = "rusn_6_1";
                hayag[52] = "rusn_6_2";
                hayag[53] = "rusn_6_3";
                hayag[54] = "rusn_6_4";
                hayag[55] = "rusn_6_5";
                hayag[56] = "rusn_6_6";
                hayag[57] = "gru";
                hayag[58] = "oru";
                hayag[59] = "zaalt";
                hayag[35] = "petzaalt";

            }
            #endregion

            if (ping85 == true)
            {
            //    try               {
                    #region 1ro
                    da = new SqlDataAdapter("select  *from " + hayag[1] + "  where (tsag >= @udur1 and tsag <= @udur2) ORDER BY id DESC", con85tooluur);
                    da.SelectCommand.Parameters.AddWithValue("@udur1", generalSchem.blDateStart);
                    da.SelectCommand.Parameters.AddWithValue("@udur2", generalSchem.blDateStop);
                    ds = new DataSet();
                    da.Fill(ds, "neg");
                    table1RO = ds.Tables[0];

                    a1 = Math.Round((Convert.ToDouble(table1RO.Rows[0][2]) - Convert.ToDouble(table1RO.Rows[table1RO.Rows.Count - 1][2])) * 1800, 3);
                    a2 = Math.Round((Convert.ToDouble(table1RO.Rows[0][3]) - Convert.ToDouble(table1RO.Rows[table1RO.Rows.Count - 1][3])) * 1800, 3);
                    a3 = Math.Round((Convert.ToDouble(table1RO.Rows[0][4]) - Convert.ToDouble(table1RO.Rows[table1RO.Rows.Count - 1][4])) * 1800, 3);
                    a4 = Math.Round((Convert.ToDouble(table1RO.Rows[0][5]) - Convert.ToDouble(table1RO.Rows[table1RO.Rows.Count - 1][5])) * 1800, 3);
                    a5 = Math.Round((Convert.ToDouble(table1RO.Rows[0][6]) - Convert.ToDouble(table1RO.Rows[table1RO.Rows.Count - 1][6])) * 1800, 3);
                    a6 = Math.Round((Convert.ToDouble(table1RO.Rows[0][7]) - Convert.ToDouble(table1RO.Rows[table1RO.Rows.Count - 1][7])) * 3600, 3);
                    a7 = Math.Round((Convert.ToDouble(table1RO.Rows[0][8]) - Convert.ToDouble(table1RO.Rows[table1RO.Rows.Count - 1][8])) * 3600, 3);
                    a8 = Math.Round((Convert.ToDouble(table1RO.Rows[0][9]) - Convert.ToDouble(table1RO.Rows[table1RO.Rows.Count - 1][9])) * 7200, 3);
                    a9 = Math.Round((Convert.ToDouble(table1RO.Rows[0][10]) - Convert.ToDouble(table1RO.Rows[table1RO.Rows.Count - 1][10])) * 7200, 3);
                    a10 = (a9 + a8 - a1 - a2 - a3 - a4 - a5 - a6 - a7) / (a9 + a8) * 100;

                    generalSchem.BL1RO = Math.Round(a10, 2).ToString();
                    #endregion
                    #region 7p
                    da = new SqlDataAdapter("select  *from " + hayag[7] + "  where (tsag >= @udur1 and tsag <= @udur2) ORDER BY id DESC", con85tooluur);
                    da.SelectCommand.Parameters.AddWithValue("@udur1", generalSchem.blDateStart);
                    da.SelectCommand.Parameters.AddWithValue("@udur2", generalSchem.blDateStop);
                    ds = new DataSet();
                    da.Fill(ds, "neg");
                    table7R = ds.Tables[0];

                    a1 = Math.Round((Convert.ToDouble(table7R.Rows[0][2]) - Convert.ToDouble(table7R.Rows[table7R.Rows.Count - 1][2])) * 1800, 3);
                    a2 = Math.Round((Convert.ToDouble(table7R.Rows[0][3]) - Convert.ToDouble(table7R.Rows[table7R.Rows.Count - 1][3])) * 1800, 3);
                    a3 = Math.Round((Convert.ToDouble(table7R.Rows[0][4]) - Convert.ToDouble(table7R.Rows[table7R.Rows.Count - 1][4])) * 1800, 3);
                    a4 = Math.Round((Convert.ToDouble(table7R.Rows[0][5]) - Convert.ToDouble(table7R.Rows[table7R.Rows.Count - 1][5])) * 1800, 3);
                    a5 = Math.Round((Convert.ToDouble(table7R.Rows[0][6]) - Convert.ToDouble(table7R.Rows[table7R.Rows.Count - 1][6])) * 1800, 3);
                    a6 = Math.Round((Convert.ToDouble(table7R.Rows[0][7]) - Convert.ToDouble(table7R.Rows[table7R.Rows.Count - 1][7])) * 1800, 3);
                    a7 = Math.Round((Convert.ToDouble(table7R.Rows[0][8]) - Convert.ToDouble(table7R.Rows[table7R.Rows.Count - 1][8])) * 1800, 3);
                    a8 = Math.Round((Convert.ToDouble(table7R.Rows[0][9]) - Convert.ToDouble(table7R.Rows[table7R.Rows.Count - 1][9])) * 1800, 3);
                    a9 = Math.Round((Convert.ToDouble(table7R.Rows[0][10]) - Convert.ToDouble(table7R.Rows[table7R.Rows.Count - 1][10])) * 1800, 3);
                    a10 = Math.Round((Convert.ToDouble(table7R.Rows[0][11]) - Convert.ToDouble(table7R.Rows[table7R.Rows.Count - 1][11])) * 1800, 3);
                    a11 = Math.Round((Convert.ToDouble(table7R.Rows[0][12]) - Convert.ToDouble(table7R.Rows[table7R.Rows.Count - 1][12])) * 3600, 3);
                    a12 = Math.Round((Convert.ToDouble(table7R.Rows[0][13]) - Convert.ToDouble(table7R.Rows[table7R.Rows.Count - 1][13])) * 1800, 3);
                    a13 = Math.Round((Convert.ToDouble(table7R.Rows[0][14]) - Convert.ToDouble(table7R.Rows[table7R.Rows.Count - 1][14])) * 720, 3);
                    a14 = Math.Round((Convert.ToDouble(table7R.Rows[0][15]) - Convert.ToDouble(table7R.Rows[table7R.Rows.Count - 1][15])) * 720, 3);
                    a15 = Math.Round((Convert.ToDouble(table7R.Rows[0][16]) - Convert.ToDouble(table7R.Rows[table7R.Rows.Count - 1][16])) * 7200, 3);
                    a16 = Math.Round((Convert.ToDouble(table7R.Rows[0][17]) - Convert.ToDouble(table7R.Rows[table7R.Rows.Count - 1][17])) * 7200, 3);
                    a17 = (a16 + a15 - a1 - a2 - a3 - a4 - a5 - a6 - a7 - a8 - a9 - a10 - a11 - a12 - a13 - a14) / (a15 + a16) * 100;
                    generalSchem.BL7R = Math.Round(a17, 2).ToString();
                    #endregion
                    #region 2po

                    da = new SqlDataAdapter("select  *from " + hayag[2] + "  where (tsag >= @udur1 and tsag <= @udur2) ORDER BY id DESC", con85tooluur);
                    da.SelectCommand.Parameters.AddWithValue("@udur1", generalSchem.blDateStart);
                    da.SelectCommand.Parameters.AddWithValue("@udur2", generalSchem.blDateStop);
                    ds = new DataSet();
                    da.Fill(ds, "neg");
                    table2RO = ds.Tables[0];

                    a1 = Math.Round((Convert.ToDouble(table2RO.Rows[0][2]) - Convert.ToDouble(table2RO.Rows[table2RO.Rows.Count - 1][2])) * 7200, 3);
                    a2 = Math.Round((Convert.ToDouble(table2RO.Rows[0][3]) - Convert.ToDouble(table2RO.Rows[table2RO.Rows.Count - 1][3])) * 1800, 3);
                    a3 = Math.Round((Convert.ToDouble(table2RO.Rows[0][4]) - Convert.ToDouble(table2RO.Rows[table2RO.Rows.Count - 1][4])) * 1800, 3);
                    a4 = Math.Round((Convert.ToDouble(table2RO.Rows[0][5]) - Convert.ToDouble(table2RO.Rows[table2RO.Rows.Count - 1][5])) * 3600, 3);
                    a5 = Math.Round((Convert.ToDouble(table2RO.Rows[0][6]) - Convert.ToDouble(table2RO.Rows[table2RO.Rows.Count - 1][6])) * 3600, 3);
                    a6 = Math.Round((Convert.ToDouble(table2RO.Rows[0][7]) - Convert.ToDouble(table2RO.Rows[table2RO.Rows.Count - 1][7])) * 1800, 3);
                    a7 = Math.Round((Convert.ToDouble(table2RO.Rows[0][8]) - Convert.ToDouble(table2RO.Rows[table2RO.Rows.Count - 1][8])) * 1800, 3);
                    a8 = Math.Round((Convert.ToDouble(table2RO.Rows[0][9]) - Convert.ToDouble(table2RO.Rows[table2RO.Rows.Count - 1][9])) * 1800, 3);
                    a9 = Math.Round((Convert.ToDouble(table2RO.Rows[0][10]) - Convert.ToDouble(table2RO.Rows[table2RO.Rows.Count - 1][10])) * 1800, 3);
                    a10 = Math.Round((Convert.ToDouble(table2RO.Rows[0][11]) - Convert.ToDouble(table2RO.Rows[table2RO.Rows.Count - 1][11])) * 7200, 3);
                    a11 = (a1 + a10 - a9 - a2 - a3 - a4 - a5 - a6 - a7 - a8) / (a1 + a10) * 100;
                    generalSchem.BL2RO = Math.Round(a11, 2).ToString();
                    #endregion
                    #region 8p

                    da = new SqlDataAdapter("select  *from " + hayag[8] + "  where (tsag >= @udur1 and tsag <= @udur2) ORDER BY id DESC", con85tooluur);
                    da.SelectCommand.Parameters.AddWithValue("@udur1", generalSchem.blDateStart);
                    da.SelectCommand.Parameters.AddWithValue("@udur2", generalSchem.blDateStop);
                    ds = new DataSet();
                    da.Fill(ds, "neg");
                    table8R = ds.Tables[0];

                    a1 = Math.Round((Convert.ToDouble(table8R.Rows[0][2]) - Convert.ToDouble(table8R.Rows[table8R.Rows.Count - 1][2])) * 7200, 3);
                    a2 = Math.Round((Convert.ToDouble(table8R.Rows[0][3]) - Convert.ToDouble(table8R.Rows[table8R.Rows.Count - 1][3])) * 1800, 3);
                    a3 = Math.Round((Convert.ToDouble(table8R.Rows[0][4]) - Convert.ToDouble(table8R.Rows[table8R.Rows.Count - 1][4])) * 1800, 3);
                    a4 = Math.Round((Convert.ToDouble(table8R.Rows[0][5]) - Convert.ToDouble(table8R.Rows[table8R.Rows.Count - 1][5])) * 1800, 3);
                    a5 = Math.Round((Convert.ToDouble(table8R.Rows[0][6]) - Convert.ToDouble(table8R.Rows[table8R.Rows.Count - 1][6])) * 1800, 3);
                    a6 = Math.Round((Convert.ToDouble(table8R.Rows[0][7]) - Convert.ToDouble(table8R.Rows[table8R.Rows.Count - 1][7])) * 1800, 3);
                    a7 = Math.Round((Convert.ToDouble(table8R.Rows[0][8]) - Convert.ToDouble(table8R.Rows[table8R.Rows.Count - 1][8])) * 1800, 3);
                    a8 = Math.Round((Convert.ToDouble(table8R.Rows[0][9]) - Convert.ToDouble(table8R.Rows[table8R.Rows.Count - 1][9])) * 1800, 3);
                    a9 = Math.Round((Convert.ToDouble(table8R.Rows[0][10]) - Convert.ToDouble(table8R.Rows[table8R.Rows.Count - 1][10])) * 1800, 3);
                    a10 = Math.Round((Convert.ToDouble(table8R.Rows[0][11]) - Convert.ToDouble(table8R.Rows[table8R.Rows.Count - 1][11])) * 1800, 3);
                    a11 = Math.Round((Convert.ToDouble(table8R.Rows[0][12]) - Convert.ToDouble(table8R.Rows[table8R.Rows.Count - 1][12])) * 1800, 3);
                    a12 = Math.Round((Convert.ToDouble(table8R.Rows[0][13]) - Convert.ToDouble(table8R.Rows[table8R.Rows.Count - 1][13])) * 720, 3);
                    a13 = Math.Round((Convert.ToDouble(table8R.Rows[0][14]) - Convert.ToDouble(table8R.Rows[table8R.Rows.Count - 1][14])) * 720, 3);
                    a14 = Math.Round((Convert.ToDouble(table8R.Rows[0][15]) - Convert.ToDouble(table8R.Rows[table8R.Rows.Count - 1][15])) * 7200, 3);
                    a15 = (a14 + a1 - a13 - a2 - a3 - a4 - a5 - a6 - a7 - a8 - a9 - a10 - a11 - a12) / (a14 + a1) * 100;
                    generalSchem.BL8R = Math.Round(a15, 2).ToString();
                    #endregion
                    #region 9p
                    da = new SqlDataAdapter("select  *from " + hayag[9] + "  where (tsag >= @udur1 and tsag <= @udur2) ORDER BY id DESC", con85tooluur);
                    da.SelectCommand.Parameters.AddWithValue("@udur1", generalSchem.blDateStart);
                    da.SelectCommand.Parameters.AddWithValue("@udur2", generalSchem.blDateStop);
                    ds = new DataSet();
                    da.Fill(ds, "neg");
                    table9R = ds.Tables[0];

                    a1 = Math.Round((Convert.ToDouble(table9R.Rows[0][2]) - Convert.ToDouble(table9R.Rows[table9R.Rows.Count - 1][2])) * 1800, 3);
                    a2 = Math.Round((Convert.ToDouble(table9R.Rows[0][3]) - Convert.ToDouble(table9R.Rows[table9R.Rows.Count - 1][3])) * 1800, 3);
                    a3 = Math.Round((Convert.ToDouble(table9R.Rows[0][4]) - Convert.ToDouble(table9R.Rows[table9R.Rows.Count - 1][4])) * 1800, 3);
                    a4 = Math.Round((Convert.ToDouble(table9R.Rows[0][5]) - Convert.ToDouble(table9R.Rows[table9R.Rows.Count - 1][5])) * 1800, 3);
                    a5 = Math.Round((Convert.ToDouble(table9R.Rows[0][6]) - Convert.ToDouble(table9R.Rows[table9R.Rows.Count - 1][6])) * 1800, 3);
                    a6 = Math.Round((Convert.ToDouble(table9R.Rows[0][7]) - Convert.ToDouble(table9R.Rows[table9R.Rows.Count - 1][7])) * 1800, 3);
                    a7 = Math.Round((Convert.ToDouble(table9R.Rows[0][8]) - Convert.ToDouble(table9R.Rows[table9R.Rows.Count - 1][8])) * 1800, 3);
                    a8 = Math.Round((Convert.ToDouble(table9R.Rows[0][9]) - Convert.ToDouble(table9R.Rows[table9R.Rows.Count - 1][9])) * 7200, 3);
                    a9 = Math.Round((Convert.ToDouble(table9R.Rows[0][10]) - Convert.ToDouble(table9R.Rows[table9R.Rows.Count - 1][10])) * 7200, 3);
                    a10 = Math.Round((Convert.ToDouble(table9R.Rows[0][11]) - Convert.ToDouble(table9R.Rows[table9R.Rows.Count - 1][11])) * 3600, 3);
                    a11 = Math.Round((Convert.ToDouble(table9R.Rows[0][12]) - Convert.ToDouble(table9R.Rows[table9R.Rows.Count - 1][12])) * 1800, 3);
                    a12 = Math.Round((Convert.ToDouble(table9R.Rows[0][13]) - Convert.ToDouble(table9R.Rows[table9R.Rows.Count - 1][13])) * 1800, 3);
                    a13 = Math.Round((Convert.ToDouble(table9R.Rows[0][14]) - Convert.ToDouble(table9R.Rows[table9R.Rows.Count - 1][14])) * 3600, 3);
                    a15 = (a9 + a8 - a1 - a2 - a3 - a4 - a5 - a6 - a7 - a10 - a11 - a12 - a13) / (a9 + a8) * 100;
                    generalSchem.BL9R = Math.Round(a15, 2).ToString();
                    #endregion
                    #region 13p
                    da = new SqlDataAdapter("select  *from " + hayag[13] + "  where (tsag >= @udur1 and tsag <= @udur2) ORDER BY id DESC", con85tooluur);
                    da.SelectCommand.Parameters.AddWithValue("@udur1", generalSchem.blDateStart);
                    da.SelectCommand.Parameters.AddWithValue("@udur2", generalSchem.blDateStop);
                    ds = new DataSet();
                    da.Fill(ds, "neg");
                    table13R = ds.Tables[0];

                    a1 = Math.Round((Convert.ToDouble(table13R.Rows[0][2]) - Convert.ToDouble(table13R.Rows[table13R.Rows.Count - 1][2])) * 1800, 3);
                    a2 = Math.Round((Convert.ToDouble(table13R.Rows[0][3]) - Convert.ToDouble(table13R.Rows[table13R.Rows.Count - 1][3])) * 1800, 3);
                    a3 = Math.Round((Convert.ToDouble(table13R.Rows[0][4]) - Convert.ToDouble(table13R.Rows[table13R.Rows.Count - 1][4])) * 1800, 3);
                    a4 = Math.Round((Convert.ToDouble(table13R.Rows[0][5]) - Convert.ToDouble(table13R.Rows[table13R.Rows.Count - 1][5])) * 1800, 3);
                    a5 = Math.Round((Convert.ToDouble(table13R.Rows[0][6]) - Convert.ToDouble(table13R.Rows[table13R.Rows.Count - 1][6])) * 1800, 3);
                    a6 = Math.Round((Convert.ToDouble(table13R.Rows[0][7]) - Convert.ToDouble(table13R.Rows[table13R.Rows.Count - 1][7])) * 1800, 3);
                    a7 = Math.Round((Convert.ToDouble(table13R.Rows[0][8]) - Convert.ToDouble(table13R.Rows[table13R.Rows.Count - 1][8])) * 3600, 3);
                    a8 = Math.Round((Convert.ToDouble(table13R.Rows[0][9]) - Convert.ToDouble(table13R.Rows[table13R.Rows.Count - 1][9])) * 1800, 3);
                    a9 = Math.Round((Convert.ToDouble(table13R.Rows[0][10]) - Convert.ToDouble(table13R.Rows[table13R.Rows.Count - 1][10])) * 1800, 3);
                    a10 = Math.Round((Convert.ToDouble(table13R.Rows[0][11]) - Convert.ToDouble(table13R.Rows[table13R.Rows.Count - 1][11])) * 1800, 3);
                    a11 = Math.Round((Convert.ToDouble(table13R.Rows[0][12]) - Convert.ToDouble(table13R.Rows[table13R.Rows.Count - 1][12])) * 720, 3);
                    a12 = Math.Round((Convert.ToDouble(table13R.Rows[0][13]) - Convert.ToDouble(table13R.Rows[table13R.Rows.Count - 1][13])) * 720, 3);
                    a13 = Math.Round((Convert.ToDouble(table13R.Rows[0][14]) - Convert.ToDouble(table13R.Rows[table13R.Rows.Count - 1][14])) * 1800, 3);
                    a14 = Math.Round((Convert.ToDouble(table13R.Rows[0][15]) - Convert.ToDouble(table13R.Rows[table13R.Rows.Count - 1][15])) * 7200, 3);
                    a15 = (a14 - a1 - a2 - a3 - a4 - a5 - a6 - a7 - a8 - a9 - a10 - a11 - a12 - a13) / a14 * 100;
                    generalSchem.BL13R = Math.Round(a15, 2).ToString();
                    #endregion
              
                    #region 10p
                    da = new SqlDataAdapter("select  *from " + hayag[10] + "  where (tsag >= @udur1 and tsag <= @udur2) ORDER BY id DESC", con85tooluur);
                    da.SelectCommand.Parameters.AddWithValue("@udur1", generalSchem.blDateStart);
                    da.SelectCommand.Parameters.AddWithValue("@udur2", generalSchem.blDateStop);
                    ds = new DataSet();
                    da.Fill(ds, "neg");
                    table10R = ds.Tables[0];

                    a1 = Math.Round((Convert.ToDouble(table10R.Rows[0][2]) - Convert.ToDouble(table10R.Rows[table10R.Rows.Count - 1][2])) * 1800, 3);
                    a2 = Math.Round((Convert.ToDouble(table10R.Rows[0][3]) - Convert.ToDouble(table10R.Rows[table10R.Rows.Count - 1][3])) * 1800, 3);
                    a3 = Math.Round((Convert.ToDouble(table10R.Rows[0][4]) - Convert.ToDouble(table10R.Rows[table10R.Rows.Count - 1][4])) * 1800, 3);
                    a4 = Math.Round((Convert.ToDouble(table10R.Rows[0][5]) - Convert.ToDouble(table10R.Rows[table10R.Rows.Count - 1][5])) * 1800, 3);
                    a5 = Math.Round((Convert.ToDouble(table10R.Rows[0][6]) - Convert.ToDouble(table10R.Rows[table10R.Rows.Count - 1][6])) * 1800, 3);
                    a6 = Math.Round((Convert.ToDouble(table10R.Rows[0][7]) - Convert.ToDouble(table10R.Rows[table10R.Rows.Count - 1][7])) * 1800, 3);
                    a7 = Math.Round((Convert.ToDouble(table10R.Rows[0][8]) - Convert.ToDouble(table10R.Rows[table10R.Rows.Count - 1][8])) * 1800, 3);
                    a8 = Math.Round((Convert.ToDouble(table10R.Rows[0][9]) - Convert.ToDouble(table10R.Rows[table10R.Rows.Count - 1][9])) * 1800, 3);
                    a9 = Math.Round((Convert.ToDouble(table10R.Rows[0][10]) - Convert.ToDouble(table10R.Rows[table10R.Rows.Count - 1][10])) * 3600, 3);
                    a10 = Math.Round((Convert.ToDouble(table10R.Rows[0][11]) - Convert.ToDouble(table10R.Rows[table10R.Rows.Count - 1][11])) * 1800, 3);
                    a11 = Math.Round((Convert.ToDouble(table10R.Rows[0][12]) - Convert.ToDouble(table10R.Rows[table10R.Rows.Count - 1][12])) * 1800, 3);
                    a12 = Math.Round((Convert.ToDouble(table10R.Rows[0][13]) - Convert.ToDouble(table10R.Rows[table10R.Rows.Count - 1][13])) * 1800, 3);
                    a13 = Math.Round((Convert.ToDouble(table10R.Rows[0][14]) - Convert.ToDouble(table10R.Rows[table10R.Rows.Count - 1][14])) * 7200, 3);
                    a14 = Math.Round((Convert.ToDouble(table10R.Rows[0][15]) - Convert.ToDouble(table10R.Rows[table10R.Rows.Count - 1][15])) * 7200, 3);
                    a15 = Math.Round((Convert.ToDouble(table10R.Rows[0][16]) - Convert.ToDouble(table10R.Rows[table10R.Rows.Count - 1][16])) * 1800, 3);
                    a16 = (a14 + a13 - a1 - a2 - a3 - a4 - a5 - a6 - a7 - a8 - a9 - a10 - a11 - a12 - a15) / (a14 + a13) * 100;
                    generalSchem.BL10R = Math.Round(a16, 2).ToString();

                #endregion
                #region 11p


                da = new SqlDataAdapter("select  *from " + hayag[11] + "  where (tsag >= @udur1 and tsag <= @udur2) ORDER BY id DESC", con85tooluur);
                da.SelectCommand.Parameters.AddWithValue("@udur1", generalSchem.blDateStart);
                da.SelectCommand.Parameters.AddWithValue("@udur2", generalSchem.blDateStop);
                ds = new DataSet();
                da.Fill(ds, "neg");
                table11R = ds.Tables[0];

                a1 = Math.Round((Convert.ToDouble(table11R.Rows[0][2]) - Convert.ToDouble(table11R.Rows[table11R.Rows.Count - 1][2])) * 1800, 3);
                a2 = Math.Round((Convert.ToDouble(table11R.Rows[0][3]) - Convert.ToDouble(table11R.Rows[table11R.Rows.Count - 1][3])) * 1800, 3);
                a3 = Math.Round((Convert.ToDouble(table11R.Rows[0][4]) - Convert.ToDouble(table11R.Rows[table11R.Rows.Count - 1][4])) * 1800, 3);
                a4 = Math.Round((Convert.ToDouble(table11R.Rows[0][5]) - Convert.ToDouble(table11R.Rows[table11R.Rows.Count - 1][5])) * 1800, 3);
                a5 = Math.Round((Convert.ToDouble(table11R.Rows[0][6]) - Convert.ToDouble(table11R.Rows[table11R.Rows.Count - 1][6])) * 1800, 3);
                a6 = Math.Round((Convert.ToDouble(table11R.Rows[0][7]) - Convert.ToDouble(table11R.Rows[table11R.Rows.Count - 1][7])) * 1800, 3);
                a7 = Math.Round((Convert.ToDouble(table11R.Rows[0][8]) - Convert.ToDouble(table11R.Rows[table11R.Rows.Count - 1][8])) * 1800, 3);
                a8 = Math.Round((Convert.ToDouble(table11R.Rows[0][9]) - Convert.ToDouble(table11R.Rows[table11R.Rows.Count - 1][9])) * 1800, 3);
                a9 = Math.Round((Convert.ToDouble(table11R.Rows[0][10]) - Convert.ToDouble(table11R.Rows[table11R.Rows.Count - 1][10])) * 1800, 3);
                a10 = Math.Round((Convert.ToDouble(table11R.Rows[0][11]) - Convert.ToDouble(table11R.Rows[table11R.Rows.Count - 1][11])) * 720, 3);
                a11 = Math.Round((Convert.ToDouble(table11R.Rows[0][12]) - Convert.ToDouble(table11R.Rows[table11R.Rows.Count - 1][12])) * 720, 3);
                a12 = Math.Round((Convert.ToDouble(table11R.Rows[0][13]) - Convert.ToDouble(table11R.Rows[table11R.Rows.Count - 1][13])) * 3600, 3);
                a13 = Math.Round((Convert.ToDouble(table11R.Rows[0][14]) - Convert.ToDouble(table11R.Rows[table11R.Rows.Count - 1][14])) * 1800, 3);
                a14 = Math.Round((Convert.ToDouble(table11R.Rows[0][15]) - Convert.ToDouble(table11R.Rows[table11R.Rows.Count - 1][15])) * 7200, 3);
                a15 = Math.Round((Convert.ToDouble(table11R.Rows[0][16]) - Convert.ToDouble(table11R.Rows[table11R.Rows.Count - 1][16])) * 7200, 3);
                a17 = Math.Round((Convert.ToDouble(table11R.Rows[0][17]) - Convert.ToDouble(table11R.Rows[table11R.Rows.Count - 1][17])) * 1800, 3);
                a16 = (a15 + a14 - a1 - a2 - a3 - a4 - a5 - a6 - a7 - a8 - a9 - a10 - a11 - a12 - a13 - a17) / (a15 + a14) * 100;
                generalSchem.BL11R = Math.Round(a16, 2).ToString();
                #endregion
            
                    #region 12p
                    da = new SqlDataAdapter("select  *from " + hayag[12] + "  where (tsag >= @udur1 and tsag <= @udur2) ORDER BY id DESC", con85tooluur);
                    da.SelectCommand.Parameters.AddWithValue("@udur1", generalSchem.blDateStart);
                    da.SelectCommand.Parameters.AddWithValue("@udur2", generalSchem.blDateStop);
                    ds = new DataSet();
                    da.Fill(ds, "neg");
                    table12R = ds.Tables[0];

                    a1 = Math.Round((Convert.ToDouble(table12R.Rows[0][2]) - Convert.ToDouble(table12R.Rows[table12R.Rows.Count - 1][2])) * 1800, 3);
                    a2 = Math.Round((Convert.ToDouble(table12R.Rows[0][3]) - Convert.ToDouble(table12R.Rows[table12R.Rows.Count - 1][3])) * 1800, 3);
                    a3 = Math.Round((Convert.ToDouble(table12R.Rows[0][4]) - Convert.ToDouble(table12R.Rows[table12R.Rows.Count - 1][4])) * 1800, 3);
                    a4 = Math.Round((Convert.ToDouble(table12R.Rows[0][5]) - Convert.ToDouble(table12R.Rows[table12R.Rows.Count - 1][5])) * 1800, 3);
                    a5 = Math.Round((Convert.ToDouble(table12R.Rows[0][6]) - Convert.ToDouble(table12R.Rows[table12R.Rows.Count - 1][6])) * 1800, 3);
                    a6 = Math.Round((Convert.ToDouble(table12R.Rows[0][7]) - Convert.ToDouble(table12R.Rows[table12R.Rows.Count - 1][7])) * 1800, 3);
                    a7 = Math.Round((Convert.ToDouble(table12R.Rows[0][8]) - Convert.ToDouble(table12R.Rows[table12R.Rows.Count - 1][8])) * 1800, 3);
                    //    a8 = Math.Round((Convert.ToDouble(table12R.Rows[0][9]) - Convert.ToDouble(table12R.Rows[table12R.Rows.Count - 1][9])) * 1800, 3);
                    a9 = Math.Round((Convert.ToDouble(table12R.Rows[0][10]) - Convert.ToDouble(table12R.Rows[table12R.Rows.Count - 1][10])) * 1200, 3);
                    a10 = Math.Round((Convert.ToDouble(table12R.Rows[0][11]) - Convert.ToDouble(table12R.Rows[table12R.Rows.Count - 1][11])) * 3600, 3);
                    a11 = Math.Round((Convert.ToDouble(table12R.Rows[0][12]) - Convert.ToDouble(table12R.Rows[table12R.Rows.Count - 1][12])) * 1800, 3);
                    a12 = Math.Round((Convert.ToDouble(table12R.Rows[0][13]) - Convert.ToDouble(table12R.Rows[table12R.Rows.Count - 1][13])) * 1800, 3);
                    a13 = Math.Round((Convert.ToDouble(table12R.Rows[0][14]) - Convert.ToDouble(table12R.Rows[table12R.Rows.Count - 1][14])) * 1800, 3);
                    a14 = Math.Round((Convert.ToDouble(table12R.Rows[0][15]) - Convert.ToDouble(table12R.Rows[table12R.Rows.Count - 1][15])) * 1800, 3);
                    a15 = Math.Round((Convert.ToDouble(table12R.Rows[0][16]) - Convert.ToDouble(table12R.Rows[table12R.Rows.Count - 1][16])) * 1800, 3);
                    a16 = Math.Round((Convert.ToDouble(table12R.Rows[0][17]) - Convert.ToDouble(table12R.Rows[table12R.Rows.Count - 1][17])) * 7200, 3);
                    a17 = Math.Round((Convert.ToDouble(table12R.Rows[0][18]) - Convert.ToDouble(table12R.Rows[table12R.Rows.Count - 1][18])) * 7200, 3);
                    a18 = (a17 + a16 - a1 - a2 - a3 - a4 - a5 - a6 - a7 - a9 - a10 - a11 - a12 - a13 - a14 - a15) / (a17 + a16) * 100;
                    generalSchem.BL12R = Math.Round(a18, 2).ToString();
                    #endregion

              
                    #region ORU
                    // oru
                    da = new SqlDataAdapter("select  *from " + hayag[58] + "  where (tsag >= @udur1 and tsag <= @udur2) ORDER BY id DESC", con85dt);
                    da.SelectCommand.Parameters.AddWithValue("@udur1", generalSchem.blDateStart);
                    da.SelectCommand.Parameters.AddWithValue("@udur2", generalSchem.blDateStop);
                    ds = new DataSet();
                    da.Fill(ds, "oru");
                    tableORU = ds.Tables[0];

                    dundb[10, 1] = Math.Round((Convert.ToDouble(tableORU.Rows[0][2]) - Convert.ToDouble(tableORU.Rows[tableORU.Rows.Count - 1][2])) * 66000, 3);  //T1 UGSON
                    dundb[10, 2] = Math.Round((Convert.ToDouble(tableORU.Rows[0][3]) - Convert.ToDouble(tableORU.Rows[tableORU.Rows.Count - 1][3])) * 66000, 3);   // T1 AWSAN
                    dundb[10, 3] = Math.Round((Convert.ToDouble(tableORU.Rows[0][4]) - Convert.ToDouble(tableORU.Rows[tableORU.Rows.Count - 1][4])) * 66000, 3);  // T2 OGSON
                    dundb[10, 4] = Math.Round((Convert.ToDouble(tableORU.Rows[0][5]) - Convert.ToDouble(tableORU.Rows[tableORU.Rows.Count - 1][5])) * 66000, 3); //T2 AWSAN
                    dundb[10, 5] = Math.Round((Convert.ToDouble(tableORU.Rows[0][6]) - Convert.ToDouble(tableORU.Rows[tableORU.Rows.Count - 1][6])) * 88000, 3);  //111U
                    dundb[10, 6] = Math.Round((Convert.ToDouble(tableORU.Rows[0][7]) - Convert.ToDouble(tableORU.Rows[tableORU.Rows.Count - 1][7])) * 88000, 3);  // 111A 
                    dundb[10, 7] = Math.Round((Convert.ToDouble(tableORU.Rows[0][8]) - Convert.ToDouble(tableORU.Rows[tableORU.Rows.Count - 1][8])) * 88000, 3);  // 112U
                    dundb[10, 8] = Math.Round((Convert.ToDouble(tableORU.Rows[0][9]) - Convert.ToDouble(tableORU.Rows[tableORU.Rows.Count - 1][9])) * 88000, 3);   // 112A
                    dundb[10, 9] = Math.Round((Convert.ToDouble(tableORU.Rows[0][10]) - Convert.ToDouble(tableORU.Rows[tableORU.Rows.Count - 1][10])) * 132000, 3);  //105U
                    dundb[10, 10] = Math.Round((Convert.ToDouble(tableORU.Rows[0][11]) - Convert.ToDouble(tableORU.Rows[tableORU.Rows.Count - 1][11])) * 132000, 3);  //105A
                    dundb[10, 11] = Math.Round((Convert.ToDouble(tableORU.Rows[0][12]) - Convert.ToDouble(tableORU.Rows[tableORU.Rows.Count - 1][12])) * 132000, 3);  //106U
                    dundb[10, 12] = Math.Round((Convert.ToDouble(tableORU.Rows[0][13]) - Convert.ToDouble(tableORU.Rows[tableORU.Rows.Count - 1][13])) * 132000, 3);  //106A
                    dundb[10, 13] = Math.Round((Convert.ToDouble(tableORU.Rows[0][14]) - Convert.ToDouble(tableORU.Rows[tableORU.Rows.Count - 1][14])) * 88000, 3);  // OB U
                    dundb[10, 14] = Math.Round((Convert.ToDouble(tableORU.Rows[0][15]) - Convert.ToDouble(tableORU.Rows[tableORU.Rows.Count - 1][15])) * 88000, 3);  // OB A
                    dundb[10, 15] = Math.Round((Convert.ToDouble(tableORU.Rows[0][16]) - Convert.ToDouble(tableORU.Rows[tableORU.Rows.Count - 1][16])) * 66000, 3);   // UILD U 
                    dundb[10, 16] = Math.Round((Convert.ToDouble(tableORU.Rows[0][17]) - Convert.ToDouble(tableORU.Rows[tableORU.Rows.Count - 1][17])) * 66000, 3);  // UILD A
                    dundb[10, 17] = Math.Round((Convert.ToDouble(tableORU.Rows[0][18]) - Convert.ToDouble(tableORU.Rows[tableORU.Rows.Count - 1][18])) * 42000, 3); // T1 35 U
                    dundb[10, 18] = Math.Round((Convert.ToDouble(tableORU.Rows[0][19]) - Convert.ToDouble(tableORU.Rows[tableORU.Rows.Count - 1][19])) * 42000, 3); // T1 35 A
                    dundb[10, 19] = Math.Round((Convert.ToDouble(tableORU.Rows[0][20]) - Convert.ToDouble(tableORU.Rows[tableORU.Rows.Count - 1][20])) * 42000, 3);  // T2 35U 
                    dundb[10, 20] = Math.Round((Convert.ToDouble(tableORU.Rows[0][21]) - Convert.ToDouble(tableORU.Rows[tableORU.Rows.Count - 1][21])) * 42000, 3);  //T2 35A
                    dundb[10, 21] = Math.Round((Convert.ToDouble(tableORU.Rows[0][22]) - Convert.ToDouble(tableORU.Rows[tableORU.Rows.Count - 1][22])) * 42000, 3);  // HOLBOO A U
                    dundb[10, 22] = Math.Round((Convert.ToDouble(tableORU.Rows[0][23]) - Convert.ToDouble(tableORU.Rows[tableORU.Rows.Count - 1][23])) * 42000, 3);  // HOLBOO A A
                    dundb[10, 23] = Math.Round((Convert.ToDouble(tableORU.Rows[0][24]) - Convert.ToDouble(tableORU.Rows[tableORU.Rows.Count - 1][24])) * 42000, 3);  // HOLBOO B U
                    dundb[10, 24] = Math.Round((Convert.ToDouble(tableORU.Rows[0][25]) - Convert.ToDouble(tableORU.Rows[tableORU.Rows.Count - 1][25])) * 42000, 3);  // HOLBOO B A

                    #endregion
                    #region GRU
                    // gru
                    da = new SqlDataAdapter("select  *from " + hayag[57] + "  where (tsag >= @udur1 and tsag <= @udur2) ORDER BY id DESC", con85dt);
                    da.SelectCommand.Parameters.AddWithValue("@udur1", generalSchem.blDateStart);
                    da.SelectCommand.Parameters.AddWithValue("@udur2", generalSchem.blDateStop);
                    ds = new DataSet();
                    da.Fill(ds, "neg");
                    tableGRU = ds.Tables[0];
                    dundb[0, 1] = Math.Round((Convert.ToDouble(tableGRU.Rows[0][3]) - Convert.ToDouble(tableGRU.Rows[tableGRU.Rows.Count - 1][3])) * 7200, 3);
                    dundb[0, 2] = Math.Round((Convert.ToDouble(tableGRU.Rows[0][4]) - Convert.ToDouble(tableGRU.Rows[tableGRU.Rows.Count - 1][4])) * 7200, 3);
                    dundb[0, 3] = Math.Round((Convert.ToDouble(tableGRU.Rows[0][5]) - Convert.ToDouble(tableGRU.Rows[tableGRU.Rows.Count - 1][5])) * 4800, 3);
                    dundb[0, 4] = Math.Round((Convert.ToDouble(tableGRU.Rows[0][6]) - Convert.ToDouble(tableGRU.Rows[tableGRU.Rows.Count - 1][6])) * 3600, 3);
                    dundb[0, 5] = Math.Round((Convert.ToDouble(tableGRU.Rows[0][7]) - Convert.ToDouble(tableGRU.Rows[tableGRU.Rows.Count - 1][7])) * 3600, 3);
                    dundb[0, 6] = Math.Round((Convert.ToDouble(tableGRU.Rows[0][8]) - Convert.ToDouble(tableGRU.Rows[tableGRU.Rows.Count - 1][8])) * 7200, 3);
                    dundb[0, 7] = Math.Round((Convert.ToDouble(tableGRU.Rows[0][9]) - Convert.ToDouble(tableGRU.Rows[tableGRU.Rows.Count - 1][9])) * 18000, 3);
                    dundb[0, 8] = Math.Round((Convert.ToDouble(tableGRU.Rows[0][2]) - Convert.ToDouble(tableGRU.Rows[tableGRU.Rows.Count - 1][2])) * 1800, 3);
                    dundb[0, 9] = Math.Round((Convert.ToDouble(tableGRU.Rows[0][10]) - Convert.ToDouble(tableGRU.Rows[tableGRU.Rows.Count - 1][10])) * 1800, 3);
                    dundb[0, 10] = Math.Round((Convert.ToDouble(tableGRU.Rows[0][11]) - Convert.ToDouble(tableGRU.Rows[tableGRU.Rows.Count - 1][11])) * 1800, 3);
                    #endregion
                    #region Balance dund

                    #region rusn 1
                    da = new SqlDataAdapter("select  *from " + hayag[51] + "  where (tsag >= @udur1 and tsag <= @udur2) ORDER BY id DESC", con85dt);
                    da.SelectCommand.Parameters.AddWithValue("@udur1", generalSchem.blDateStart);
                    da.SelectCommand.Parameters.AddWithValue("@udur2", generalSchem.blDateStop);
                    ds = new DataSet();
                    da.Fill(ds, "neg");
                    table1R = ds.Tables[0];
                    dundb[1, 1] = Math.Round((Convert.ToDouble(table1R.Rows[0][2]) - Convert.ToDouble(table1R.Rows[table1R.Rows.Count - 1][2])) * 3600, 3);
                    dundb[1, 2] = Math.Round((Convert.ToDouble(table1R.Rows[0][3]) - Convert.ToDouble(table1R.Rows[table1R.Rows.Count - 1][3])) * 3600, 3);
                    dundb[1, 3] = Math.Round((Convert.ToDouble(table1R.Rows[0][4]) - Convert.ToDouble(table1R.Rows[table1R.Rows.Count - 1][4])) * 2400, 3);
                    dundb[1, 4] = Math.Round((Convert.ToDouble(table1R.Rows[0][5]) - Convert.ToDouble(table1R.Rows[table1R.Rows.Count - 1][5])) * 1800, 3);
                    dundb[1, 5] = Math.Round((Convert.ToDouble(table1R.Rows[0][6]) - Convert.ToDouble(table1R.Rows[table1R.Rows.Count - 1][6])) * 1800, 3);
                    dundb[1, 6] = Math.Round((Convert.ToDouble(table1R.Rows[0][7]) - Convert.ToDouble(table1R.Rows[table1R.Rows.Count - 1][7])) * 1800, 3);
                    dundb[1, 7] = Math.Round((Convert.ToDouble(table1R.Rows[0][8]) - Convert.ToDouble(table1R.Rows[table1R.Rows.Count - 1][8])) * 2400, 3);
                    dundb[1, 8] = Math.Round((Convert.ToDouble(table1R.Rows[0][9]) - Convert.ToDouble(table1R.Rows[table1R.Rows.Count - 1][9])) * 1800, 3);

                    dundb[1, 10] = (dundb[0, 1] - dundb[1, 1] - dundb[1, 2] - dundb[1, 3] - dundb[1, 4] - dundb[1, 5] - dundb[1, 6] - dundb[1, 7] - dundb[1, 8]) / dundb[0, 1] * 100;
                    generalSchem.BL1R = Math.Round(dundb[1, 10], 2).ToString();
                    #endregion
                    #region rusn 2
                    da = new SqlDataAdapter("select  *from " + hayag[52] + "  where (tsag >= @udur1 and tsag <= @udur2) ORDER BY id DESC", con85dt);
                    da.SelectCommand.Parameters.AddWithValue("@udur1", generalSchem.blDateStart);
                    da.SelectCommand.Parameters.AddWithValue("@udur2", generalSchem.blDateStop);
                    ds = new DataSet();
                    da.Fill(ds, "neg");
                    table2R = ds.Tables[0];
                    dundb[2, 1] = Math.Round((Convert.ToDouble(table2R.Rows[0][2]) - Convert.ToDouble(table2R.Rows[table2R.Rows.Count - 1][2])) * 2400, 3);
                    dundb[2, 2] = Math.Round((Convert.ToDouble(table2R.Rows[0][3]) - Convert.ToDouble(table2R.Rows[table2R.Rows.Count - 1][3])) * 1800, 3);
                    dundb[2, 3] = Math.Round((Convert.ToDouble(table2R.Rows[0][4]) - Convert.ToDouble(table2R.Rows[table2R.Rows.Count - 1][4])) * 3600, 3);
                    dundb[2, 4] = Math.Round((Convert.ToDouble(table2R.Rows[0][5]) - Convert.ToDouble(table2R.Rows[table2R.Rows.Count - 1][5])) * 2400, 3);
                    dundb[2, 5] = Math.Round((Convert.ToDouble(table2R.Rows[0][6]) - Convert.ToDouble(table2R.Rows[table2R.Rows.Count - 1][6])) * 1800, 3);
                    dundb[2, 6] = Math.Round((Convert.ToDouble(table2R.Rows[0][7]) - Convert.ToDouble(table2R.Rows[table2R.Rows.Count - 1][7])) * 1800, 3);
                    dundb[2, 7] = Math.Round((Convert.ToDouble(table2R.Rows[0][8]) - Convert.ToDouble(table2R.Rows[table2R.Rows.Count - 1][8])) * 1800, 3);

                    dundb[2, 10] = (dundb[0, 2] - dundb[2, 1] - dundb[2, 2] - dundb[2, 3] - dundb[2, 4] - dundb[2, 5] - dundb[2, 6] - dundb[2, 7]) / dundb[0, 2] * 100;
                    generalSchem.BL2R = Math.Round(dundb[2, 10], 2).ToString();
                    #endregion
                    #region rusn 3
                    da = new SqlDataAdapter("select  *from " + hayag[53] + "  where (tsag >= @udur1 and tsag <= @udur2) ORDER BY id DESC", con85dt);
                    da.SelectCommand.Parameters.AddWithValue("@udur1", generalSchem.blDateStart);
                    da.SelectCommand.Parameters.AddWithValue("@udur2", generalSchem.blDateStop);
                    ds = new DataSet();
                    da.Fill(ds, "neg");
                    table3R = ds.Tables[0];
                    dundb[3, 1] = Math.Round((Convert.ToDouble(table3R.Rows[0][2]) - Convert.ToDouble(table3R.Rows[table3R.Rows.Count - 1][2])) * 2400, 3);
                    dundb[3, 2] = Math.Round((Convert.ToDouble(table3R.Rows[0][3]) - Convert.ToDouble(table3R.Rows[table3R.Rows.Count - 1][3])) * 3600, 3);
                    dundb[3, 3] = Math.Round((Convert.ToDouble(table3R.Rows[0][4]) - Convert.ToDouble(table3R.Rows[table3R.Rows.Count - 1][4])) * 1800, 3);
                    dundb[3, 4] = Math.Round((Convert.ToDouble(table3R.Rows[0][5]) - Convert.ToDouble(table3R.Rows[table3R.Rows.Count - 1][5])) * 1800, 3);
                    dundb[3, 5] = Math.Round((Convert.ToDouble(table3R.Rows[0][6]) - Convert.ToDouble(table3R.Rows[table3R.Rows.Count - 1][6])) * 1800, 3);

                    dundb[3, 10] = (dundb[0, 3] - dundb[3, 1] - dundb[3, 2] - dundb[3, 3] - dundb[3, 4] - dundb[3, 5]) / dundb[0, 3] * 100;
                    generalSchem.BL3R = Math.Round(dundb[3, 10], 2).ToString();
                    #endregion
                    #region rusn 4
                    da = new SqlDataAdapter("select  *from " + hayag[54] + "  where (tsag >= @udur1 and tsag <= @udur2) ORDER BY id DESC", con85dt);
                    da.SelectCommand.Parameters.AddWithValue("@udur1", generalSchem.blDateStart);
                    da.SelectCommand.Parameters.AddWithValue("@udur2", generalSchem.blDateStop);
                    ds = new DataSet();
                    da.Fill(ds, "neg");
                    table4R = ds.Tables[0];
                    dundb[4, 1] = Math.Round((Convert.ToDouble(table4R.Rows[0][2]) - Convert.ToDouble(table4R.Rows[table4R.Rows.Count - 1][2])) * 3600, 3);
                    dundb[4, 2] = Math.Round((Convert.ToDouble(table4R.Rows[0][3]) - Convert.ToDouble(table4R.Rows[table4R.Rows.Count - 1][3])) * 3600, 3);
                    dundb[4, 3] = Math.Round((Convert.ToDouble(table4R.Rows[0][4]) - Convert.ToDouble(table4R.Rows[table4R.Rows.Count - 1][4])) * 1800, 3);
                    dundb[4, 4] = Math.Round((Convert.ToDouble(table4R.Rows[0][5]) - Convert.ToDouble(table4R.Rows[table4R.Rows.Count - 1][5])) * 1800, 3);

                    dundb[4, 10] = (dundb[0, 4] - dundb[4, 1] - dundb[4, 2] - dundb[4, 3] - dundb[4, 4]) / dundb[0, 4] * 100;
                    generalSchem.BL4R = Math.Round(dundb[4, 10], 2).ToString();
                    #endregion
                    #region rusn 5
                    da = new SqlDataAdapter("select  *from " + hayag[55] + "  where (tsag >= @udur1 and tsag <= @udur2) ORDER BY id DESC", con85dt);
                    da.SelectCommand.Parameters.AddWithValue("@udur1", generalSchem.blDateStart);
                    da.SelectCommand.Parameters.AddWithValue("@udur2", generalSchem.blDateStop);
                    ds = new DataSet();
                    da.Fill(ds, "neg");
                    table5R = ds.Tables[0];
                    dundb[5, 1] = Math.Round((Convert.ToDouble(table5R.Rows[0][2]) - Convert.ToDouble(table5R.Rows[table5R.Rows.Count - 1][2])) * 1800, 3);
                    dundb[5, 2] = Math.Round((Convert.ToDouble(table5R.Rows[0][3]) - Convert.ToDouble(table5R.Rows[table5R.Rows.Count - 1][3])) * 1800, 3);
                    dundb[5, 3] = Math.Round((Convert.ToDouble(table5R.Rows[0][4]) - Convert.ToDouble(table5R.Rows[table5R.Rows.Count - 1][4])) * 1800, 3);
                    dundb[5, 4] = Math.Round((Convert.ToDouble(table5R.Rows[0][5]) - Convert.ToDouble(table5R.Rows[table5R.Rows.Count - 1][5])) * 1800, 3);
                    dundb[5, 5] = Math.Round((Convert.ToDouble(table5R.Rows[0][6]) - Convert.ToDouble(table5R.Rows[table5R.Rows.Count - 1][6])) * 1800, 3);

                    dundb[5, 10] = (dundb[0, 5] - dundb[5, 1] - dundb[5, 2] - dundb[5, 3] - dundb[5, 4] - dundb[5, 5]) / dundb[0, 5] * 100;
                    generalSchem.BL5R = Math.Round(dundb[5, 10], 2).ToString();
                    #endregion
                    #region rusn 6
                    da = new SqlDataAdapter("select  *from " + hayag[56] + "  where (tsag >= @udur1 and tsag <= @udur2) ORDER BY id DESC", con85dt);
                    da.SelectCommand.Parameters.AddWithValue("@udur1", generalSchem.blDateStart);
                    da.SelectCommand.Parameters.AddWithValue("@udur2", generalSchem.blDateStop);
                    ds = new DataSet();
                    da.Fill(ds, "neg");
                    table6R = ds.Tables[0];
                    dundb[6, 1] = Math.Round((Convert.ToDouble(table6R.Rows[0][2]) - Convert.ToDouble(table6R.Rows[table6R.Rows.Count - 1][2])) * 3600, 3);
                    dundb[6, 2] = Math.Round((Convert.ToDouble(table6R.Rows[0][3]) - Convert.ToDouble(table6R.Rows[table6R.Rows.Count - 1][3])) * 1800, 3);
                    dundb[6, 3] = Math.Round((Convert.ToDouble(table6R.Rows[0][4]) - Convert.ToDouble(table6R.Rows[table6R.Rows.Count - 1][4])) * 1800, 3);
                    dundb[6, 4] = Math.Round((Convert.ToDouble(table6R.Rows[0][5]) - Convert.ToDouble(table6R.Rows[table6R.Rows.Count - 1][5])) * 1800, 3);
                    dundb[6, 5] = Math.Round((Convert.ToDouble(table6R.Rows[0][6]) - Convert.ToDouble(table6R.Rows[table6R.Rows.Count - 1][6])) * 1800, 3);

                    dundb[6, 10] = (dundb[0, 6] - dundb[6, 1] - dundb[6, 2] - dundb[6, 3] - dundb[6, 4] - dundb[6, 5]) / dundb[0, 6] * 100;
                    generalSchem.BL6R = Math.Round(dundb[6, 10], 2).ToString();
                    #endregion
                    #endregion
               
                    #region  14p
                    da = new SqlDataAdapter("select  *from arawduruw  where (tsag >= @udur1 and tsag <= @udur2) ORDER BY id DESC", con);
                    da.SelectCommand.Parameters.AddWithValue("@udur1", generalSchem.blDateStart);
                    da.SelectCommand.Parameters.AddWithValue("@udur2", generalSchem.blDateStop);
                    ds = new DataSet();
                    da.Fill(ds, "neg");
                    table14R = ds.Tables[0];
                    a1 = Math.Round((Convert.ToDouble(table14R.Rows[0][2]) - Convert.ToDouble(table14R.Rows[table14R.Rows.Count - 1][2])) * 1200, 3);
                    a2 = Math.Round((Convert.ToDouble(table14R.Rows[0][8]) - Convert.ToDouble(table14R.Rows[table14R.Rows.Count - 1][8])) * 1800, 3);

                    da = new SqlDataAdapter("select  *from " + hayag[14] + "  where (tsag >= @udur1 and tsag <= @udur2) ORDER BY id DESC", con);
                    da.SelectCommand.Parameters.AddWithValue("@udur1", generalSchem.blDateStart);
                    da.SelectCommand.Parameters.AddWithValue("@udur2", generalSchem.blDateStop);
                    ds = new DataSet();
                    da.Fill(ds, "neg");
                    tableZaaltGuraw = ds.Tables[0];
                    a3 = Math.Round((Convert.ToDouble(tableZaaltGuraw.Rows[0][21]) + Convert.ToDouble(tableZaaltGuraw.Rows[0][22]) - Convert.ToDouble(tableZaaltGuraw.Rows[tableZaaltGuraw.Rows.Count - 1][21]) - Convert.ToDouble(tableZaaltGuraw.Rows[tableZaaltGuraw.Rows.Count - 1][22])) * 4800, 3);
                    a4 = (a3 - a1 - a2) / a3 * 100;
                    //label59.Text = "" + Math.Round(a4, 2).ToString() + "%";
                    dundb[11, 1] = (Convert.ToDouble(tableZaaltGuraw.Rows[0][6]) - Convert.ToDouble(tableZaaltGuraw.Rows[tableZaaltGuraw.Rows.Count - 1][6])) * 44000;
                    dundb[11, 2] = (Convert.ToDouble(tableZaaltGuraw.Rows[0][7]) - Convert.ToDouble(tableZaaltGuraw.Rows[tableZaaltGuraw.Rows.Count - 1][7])) * 44000;
                    dundb[11, 3] = (Convert.ToDouble(tableZaaltGuraw.Rows[0][8]) - Convert.ToDouble(tableZaaltGuraw.Rows[tableZaaltGuraw.Rows.Count - 1][8])) * 44000;
                    dundb[11, 4] = (Convert.ToDouble(tableZaaltGuraw.Rows[0][9]) - Convert.ToDouble(tableZaaltGuraw.Rows[tableZaaltGuraw.Rows.Count - 1][9])) * 44000;
                    dundb[11, 5] = (Convert.ToDouble(tableZaaltGuraw.Rows[0][10]) - Convert.ToDouble(tableZaaltGuraw.Rows[tableZaaltGuraw.Rows.Count - 1][10])) * 132000;
                    dundb[11, 6] = (Convert.ToDouble(tableZaaltGuraw.Rows[0][2]) - Convert.ToDouble(tableZaaltGuraw.Rows[tableZaaltGuraw.Rows.Count - 1][2])) * 18000;
                    dundb[11, 7] = (Convert.ToDouble(tableZaaltGuraw.Rows[0][3]) - Convert.ToDouble(tableZaaltGuraw.Rows[tableZaaltGuraw.Rows.Count - 1][3])) * 18000;
                    dundb[11, 8] = (Convert.ToDouble(tableZaaltGuraw.Rows[0][4]) - Convert.ToDouble(tableZaaltGuraw.Rows[tableZaaltGuraw.Rows.Count - 1][4])) * 18000;
                    dundb[11, 12] = (Convert.ToDouble(tableZaaltGuraw.Rows[0][12]) - Convert.ToDouble(tableZaaltGuraw.Rows[tableZaaltGuraw.Rows.Count - 1][12])) * 48000;
                    dundb[11, 14] = (Convert.ToDouble(tableZaaltGuraw.Rows[0][14]) - Convert.ToDouble(tableZaaltGuraw.Rows[tableZaaltGuraw.Rows.Count - 1][14])) * 48000;
                    dundb[11, 11] = (Convert.ToDouble(tableZaaltGuraw.Rows[0][11]) - Convert.ToDouble(tableZaaltGuraw.Rows[tableZaaltGuraw.Rows.Count - 1][11])) * 48000;
                    dundb[11, 13] = (Convert.ToDouble(tableZaaltGuraw.Rows[0][13]) - Convert.ToDouble(tableZaaltGuraw.Rows[tableZaaltGuraw.Rows.Count - 1][13])) * 48000;
                    dundb[11, 20] = (Convert.ToDouble(tableZaaltGuraw.Rows[0][23]) - Convert.ToDouble(tableZaaltGuraw.Rows[tableZaaltGuraw.Rows.Count - 1][23])) * 165000;
                    dundb[11, 21] = (Convert.ToDouble(tableZaaltGuraw.Rows[0][15]) - Convert.ToDouble(tableZaaltGuraw.Rows[tableZaaltGuraw.Rows.Count - 1][15])) * 44000;
                    dundb[11, 22] = (Convert.ToDouble(tableZaaltGuraw.Rows[0][16]) - Convert.ToDouble(tableZaaltGuraw.Rows[tableZaaltGuraw.Rows.Count - 1][16])) * 44000;
                    dundb[11, 23] = (Convert.ToDouble(tableZaaltGuraw.Rows[0][17]) - Convert.ToDouble(tableZaaltGuraw.Rows[tableZaaltGuraw.Rows.Count - 1][17])) * 44000;
                    dundb[11, 24] = (Convert.ToDouble(tableZaaltGuraw.Rows[0][18]) - Convert.ToDouble(tableZaaltGuraw.Rows[tableZaaltGuraw.Rows.Count - 1][18])) * 44000;
                    dundb[11, 25] = (Convert.ToDouble(tableZaaltGuraw.Rows[0][19]) - Convert.ToDouble(tableZaaltGuraw.Rows[tableZaaltGuraw.Rows.Count - 1][19])) * 132000;

                    #endregion
                    #region BTR
                    if (table1RO.Rows.Count > 0 && table7R.Rows.Count > 0 && tableZaaltGuraw.Rows.Count > 0)
                    {
                        t25 = (Convert.ToDouble(table1RO.Rows[0][10]) - Convert.ToDouble(table1RO.Rows[table1RO.Rows.Count - 1][10])) * 7200;
                        t26 = (Convert.ToDouble(table7R.Rows[0][17]) - Convert.ToDouble(table7R.Rows[table7R.Rows.Count - 1][17])) * 7200;
                        t21 = (Convert.ToDouble(tableZaaltGuraw.Rows[0][6]) - Convert.ToDouble(tableZaaltGuraw.Rows[tableZaaltGuraw.Rows.Count - 1][6])) * 48000;
                        t22 = (Convert.ToDouble(tableZaaltGuraw.Rows[0][15]) - Convert.ToDouble(tableZaaltGuraw.Rows[tableZaaltGuraw.Rows.Count - 1][15])) * 44000;
                        generalSchem.BTR5BL = Math.Round((t21 - t22 - t25 - t26) / t21 * 100, 2).ToString();
                        //MessageBox.Show(t21.ToString());
                      
                    }
                    if (table2RO.Rows.Count > 0 && table8R.Rows.Count > 0 && tableZaaltGuraw.Rows.Count > 0)
                    {
                        t25 = (Convert.ToDouble(table2RO.Rows[0][2]) - Convert.ToDouble(table2RO.Rows[table2RO.Rows.Count - 1][2])) * 7200;
                        t26 = (Convert.ToDouble(table8R.Rows[0][15]) - Convert.ToDouble(table8R.Rows[table8R.Rows.Count - 1][15])) * 7200;
                        t21 = (Convert.ToDouble(tableZaaltGuraw.Rows[0][7]) - Convert.ToDouble(tableZaaltGuraw.Rows[tableZaaltGuraw.Rows.Count - 1][7])) * 48000;
                        t22 = (Convert.ToDouble(tableZaaltGuraw.Rows[0][16]) - Convert.ToDouble(tableZaaltGuraw.Rows[tableZaaltGuraw.Rows.Count - 1][16])) * 44000;
                        generalSchem.BTR6BL = Math.Round((t21 - t22 - t25 - t26) / t21 * 100, 2).ToString();
                    }
                    if (table9R.Rows.Count > 0 && table10R.Rows.Count > 0 && tableZaaltGuraw.Rows.Count > 0)
                    {
                        t25 = (Convert.ToDouble(table10R.Rows[0][14]) - Convert.ToDouble(table10R.Rows[table10R.Rows.Count - 1][14])) * 7200;
                        t26 = (Convert.ToDouble(table9R.Rows[0][10]) - Convert.ToDouble(table9R.Rows[table9R.Rows.Count - 1][10])) * 7200;
                        t21 = (Convert.ToDouble(tableZaaltGuraw.Rows[0][8]) - Convert.ToDouble(tableZaaltGuraw.Rows[tableZaaltGuraw.Rows.Count - 1][8])) * 48000;
                        t22 = (Convert.ToDouble(tableZaaltGuraw.Rows[0][17]) - Convert.ToDouble(tableZaaltGuraw.Rows[tableZaaltGuraw.Rows.Count - 1][17])) * 44000;
                        generalSchem.BTR7BL = Math.Round((t21 - t22 - t25 - t26) / t21 * 100, 2).ToString();
                    }
                    if (table11R.Rows.Count > 0 && table12R.Rows.Count > 0 && tableZaaltGuraw.Rows.Count > 0)
                    {
                        t25 = (Convert.ToDouble(table11R.Rows[0][16]) - Convert.ToDouble(table11R.Rows[table11R.Rows.Count - 1][16])) * 7200;
                        t26 = (Convert.ToDouble(table12R.Rows[0][18]) - Convert.ToDouble(table12R.Rows[table12R.Rows.Count - 1][18])) * 7200;
                        t21 = (Convert.ToDouble(tableZaaltGuraw.Rows[0][9]) - Convert.ToDouble(tableZaaltGuraw.Rows[tableZaaltGuraw.Rows.Count - 1][9])) * 48000;
                        t22 = (Convert.ToDouble(tableZaaltGuraw.Rows[0][18]) - Convert.ToDouble(tableZaaltGuraw.Rows[tableZaaltGuraw.Rows.Count - 1][18])) * 44000;
                        generalSchem.BTR8BL = Math.Round((t21 - t22 - t25 - t26) / t21 * 100, 2).ToString();
                    }
                    if (tableZaaltGuraw.Rows.Count > 0)
                    {
                        t25 = (Convert.ToDouble(tableZaaltGuraw.Rows[0][21]) - Convert.ToDouble(tableZaaltGuraw.Rows[tableZaaltGuraw.Rows.Count - 1][21])) * 4800;
                        t26 = (Convert.ToDouble(tableZaaltGuraw.Rows[0][10]) - Convert.ToDouble(tableZaaltGuraw.Rows[tableZaaltGuraw.Rows.Count - 1][10])) * 105000;
                        t21 = (Convert.ToDouble(tableZaaltGuraw.Rows[0][19]) - Convert.ToDouble(tableZaaltGuraw.Rows[tableZaaltGuraw.Rows.Count - 1][19])) * 132000;
                        generalSchem.BTR9BL = Math.Round((t26 - t25 - t21) / t26 * 100, 2).ToString();
                    }
                    if (tableZaaltGuraw.Rows.Count > 0)
                    {
                        // 12t
                        t25 = (Convert.ToDouble(tableZaaltGuraw.Rows[0][20]) - Convert.ToDouble(tableZaaltGuraw.Rows[tableZaaltGuraw.Rows.Count - 1][20])) * 150000;
                        t26 = (Convert.ToDouble(tableZaaltGuraw.Rows[0][23]) - Convert.ToDouble(tableZaaltGuraw.Rows[tableZaaltGuraw.Rows.Count - 1][23])) * 165000;
                        generalSchem.T12BL = Math.Round((t26 - t25) / t26 * 100, 2).ToString();
                    }
                    #endregion
                    #region gru
                    da = new SqlDataAdapter("select  *from " + hayag[59] + "  where (Time_Stamp >= @udur1 and Time_Stamp <= @udur2) ORDER BY id DESC", confider);
                    da.SelectCommand.Parameters.AddWithValue("@udur1", generalSchem.blDateStart);
                    da.SelectCommand.Parameters.AddWithValue("@udur2", generalSchem.blDateStop);
                    ds = new DataSet();
                    da.Fill(ds, "neg");
                    DataTable table59 = ds.Tables[0];
                    dundb[12, 2] = Math.Round((Convert.ToDouble(table59.Rows[0][2]) - Convert.ToDouble(table59.Rows[table59.Rows.Count - 1][2])) * 3600, 3); // gobi1
                    dundb[12, 3] = Math.Round((Convert.ToDouble(table59.Rows[0][3]) - Convert.ToDouble(table59.Rows[table59.Rows.Count - 1][3])) * 3600, 3); // gobi2
                    dundb[12, 4] = Math.Round((Convert.ToDouble(table59.Rows[0][4]) - Convert.ToDouble(table59.Rows[table59.Rows.Count - 1][4])) * 7200, 3);  // dsk1
                    dundb[12, 5] = Math.Round((Convert.ToDouble(table59.Rows[0][5]) - Convert.ToDouble(table59.Rows[table59.Rows.Count - 1][5])) * 7200, 3); // dsk2
                    dundb[12, 6] = Math.Round((Convert.ToDouble(table59.Rows[0][6]) - Convert.ToDouble(table59.Rows[table59.Rows.Count - 1][6])) * 7200, 3);  //sot2
                    dundb[12, 7] = Math.Round((Convert.ToDouble(table59.Rows[0][7]) - Convert.ToDouble(table59.Rows[table59.Rows.Count - 1][7])) * 3600, 3);  //sot3
                    dundb[12, 8] = Math.Round((Convert.ToDouble(table59.Rows[0][8]) - Convert.ToDouble(table59.Rows[table59.Rows.Count - 1][8])) * 3600, 3);  // graj
                    dundb[12, 9] = Math.Round((Convert.ToDouble(table59.Rows[0][9]) - Convert.ToDouble(table59.Rows[table59.Rows.Count - 1][9])) * 3600, 3);  //nasos1
                    dundb[12, 10] = Math.Round((Convert.ToDouble(table59.Rows[0][10]) - Convert.ToDouble(table59.Rows[table59.Rows.Count - 1][10])) * 3600, 3);  // nasos2
                    dundb[12, 11] = Math.Round((Convert.ToDouble(table59.Rows[0][11]) - Convert.ToDouble(table59.Rows[table59.Rows.Count - 1][11])) * 3600, 3);  // sons1
                    dundb[12, 12] = Math.Round((Convert.ToDouble(table59.Rows[0][12]) - Convert.ToDouble(table59.Rows[table59.Rows.Count - 1][12])) * 3600, 3);  // sons2
                    dundb[12, 13] = Math.Round((Convert.ToDouble(table59.Rows[0][13]) - Convert.ToDouble(table59.Rows[table59.Rows.Count - 1][13])) * 1800, 3);  // altandornod
                    dundb[12, 14] = Math.Round((Convert.ToDouble(table59.Rows[0][14]) - Convert.ToDouble(table59.Rows[table59.Rows.Count - 1][14])) * 1800, 3); // system
                    dundb[12, 15] = Math.Round((Convert.ToDouble(table59.Rows[0][15]) - Convert.ToDouble(table59.Rows[table59.Rows.Count - 1][15])) * 3600, 3); // 540
                    dundb[12, 16] = Math.Round((Convert.ToDouble(table59.Rows[0][16]) - Convert.ToDouble(table59.Rows[table59.Rows.Count - 1][16])) * 3600, 3);  // erchim

                    dundb[20, 5] = dundb[0, 10] + dundb[0, 9] + dundb[12, 11] + dundb[12, 2] + dundb[12, 3] + dundb[12, 4] + dundb[12, 5] + dundb[12, 6] + dundb[12, 7] + dundb[12, 8] + dundb[12, 9] + dundb[12, 10] + dundb[12, 12] + dundb[12, 13] + dundb[12, 14] + dundb[12, 15] + dundb[12, 16];


                    dundb[20, 1] = dundb[11, 6] + dundb[11, 7] + dundb[11, 8];  // tg
                    dundb[20, 2] = dundb[11, 11] + dundb[11, 13]; // avah
                    dundb[20, 3] = dundb[11, 12] + dundb[11, 14]; // ogoh
                    dundb[20, 4] = dundb[0, 1] + dundb[0, 2] + dundb[0, 3] + dundb[0, 4] + dundb[0, 5] + dundb[0, 6] + dundb[0, 7] + dundb[0, 8]; // fider
                    dundb[20, 6] = dundb[20, 1] + dundb[20, 2];
                    dundb[20, 7] = dundb[20, 3] + dundb[20, 4] + dundb[20, 5];

                    generalSchem.GRU6kVBL = Math.Round(((dundb[20, 1] + dundb[20, 2] - dundb[20, 3] - dundb[20, 4] - dundb[20, 5]) / (dundb[20, 1] + dundb[20, 2]) * 100), 2).ToString();
                    #endregion
            //    }
           //     catch { }
            }
            if (ping50 == true)
            {
                try
                {
                    #region 35kV

                    da = new SqlDataAdapter("select  *from " + hayag[35] + "  where (tsag >= @udur1 and tsag <= @udur2) ORDER BY id DESC", con50_pet);
                    da.SelectCommand.Parameters.AddWithValue("@udur1", generalSchem.blDateStart);
                    da.SelectCommand.Parameters.AddWithValue("@udur2", generalSchem.blDateStop);
                    ds = new DataSet();
                    da.Fill(ds, "neg");
                    DataTable table35 = ds.Tables[0];

                    dundb[21, 0] = Math.Round((Convert.ToDouble(table35.Rows[0][2]) - Convert.ToDouble(table35.Rows[table35.Rows.Count - 1][2])) * 14000, 3); // songino a
                    dundb[21, 1] = Math.Round((Convert.ToDouble(table35.Rows[0][3]) - Convert.ToDouble(table35.Rows[table35.Rows.Count - 1][3])) * 7000, 3); // songino b
                    dundb[21, 2] = Math.Round((Convert.ToDouble(table35.Rows[0][4]) - Convert.ToDouble(table35.Rows[table35.Rows.Count - 1][4])) * 42000, 3); // 4zam a
                    dundb[21, 3] = Math.Round((Convert.ToDouble(table35.Rows[0][5]) - Convert.ToDouble(table35.Rows[table35.Rows.Count - 1][5])) * 42000, 3); // 4zam b
                    dundb[21, 4] = Math.Round((Convert.ToDouble(table35.Rows[0][6]) - Convert.ToDouble(table35.Rows[table35.Rows.Count - 1][6])) * 14000, 3); // 10t
                    dundb[21, 5] = Math.Round((Convert.ToDouble(table35.Rows[0][7]) - Convert.ToDouble(table35.Rows[table35.Rows.Count - 1][7])) * 28000, 3); // tg 4 
                    dundb[21, 6] = Math.Round((Convert.ToDouble(table35.Rows[0][8]) - Convert.ToDouble(table35.Rows[table35.Rows.Count - 1][8])) * 42000, 3); // esgiileh a
                    dundb[21, 7] = Math.Round((Convert.ToDouble(table35.Rows[0][9]) - Convert.ToDouble(table35.Rows[table35.Rows.Count - 1][9])) * 42000, 3); // esgiileh b

                    dundb[21, 8] = dundb[10, 18] + dundb[10, 20] + dundb[10, 22] + dundb[10, 24] + dundb[21, 5];
                    dundb[21, 9] = dundb[10, 17] + dundb[10, 19] + dundb[10, 21] + dundb[10, 23] + dundb[21, 0] + dundb[21, 1] + dundb[21, 2] + dundb[21, 3] + dundb[21, 4] + dundb[21, 6] + dundb[21, 7];
                    dundb[21, 10] = (dundb[21, 8] - dundb[21, 9]) / dundb[21, 8] * 100;
                    generalSchem.L35BL = Math.Round(dundb[21, 10], 2).ToString();
                    #endregion
                }
                catch { }
            }
            #region beltgel
            try
            {
                if (table1RO.Rows.Count > 0) { beltgel_1RO = (Convert.ToDouble(table1RO.Rows[0][9]) - Convert.ToDouble(table1RO.Rows[table1RO.Rows.Count - 1][9])) * 7200; }
                if (table7R.Rows.Count > 0) { beltgel_7R = (Convert.ToDouble(table7R.Rows[0][16]) - Convert.ToDouble(table7R.Rows[table7R.Rows.Count - 1][16])) * 7200; }
                if (table2RO.Rows.Count > 0) { beltgel_2RO = (Convert.ToDouble(table2RO.Rows[0][11]) - Convert.ToDouble(table2RO.Rows[table2RO.Rows.Count - 1][11])) * 7200; }
                if (table8R.Rows.Count > 0) { beltgel_8R = (Convert.ToDouble(table8R.Rows[0][2]) - Convert.ToDouble(table8R.Rows[table8R.Rows.Count - 1][2])) * 7200; }
                if (table9R.Rows.Count > 0) { beltgel_9R = (Convert.ToDouble(table9R.Rows[0][9]) - Convert.ToDouble(table9R.Rows[table9R.Rows.Count - 1][9])) * 7200; }
                if (table10R.Rows.Count > 0) { beltgel_10R = (Convert.ToDouble(table10R.Rows[0][15]) - Convert.ToDouble(table10R.Rows[table10R.Rows.Count - 1][15])) * 7200; }
                if (table11R.Rows.Count > 0) { beltgel_11R = (Convert.ToDouble(table11R.Rows[0][15]) - Convert.ToDouble(table11R.Rows[table11R.Rows.Count - 1][15])) * 7200; }
                if (table12R.Rows.Count > 0) { beltgel_12R = (Convert.ToDouble(table12R.Rows[0][17]) - Convert.ToDouble(table12R.Rows[table12R.Rows.Count - 1][17])) * 7200; }
                if (table13R.Rows.Count > 0) { beltgel_13R = (Convert.ToDouble(table13R.Rows[0][15]) - Convert.ToDouble(table13R.Rows[table13R.Rows.Count - 1][15])) * 7200; }

                if (tableZaaltGuraw.Rows.Count > 0) { beltgel_t113 = (Convert.ToDouble(tableZaaltGuraw.Rows[0][22]) - Convert.ToDouble(tableZaaltGuraw.Rows[tableZaaltGuraw.Rows.Count - 1][22])) * 4800; }
                if (tableZaaltGuraw.Rows.Count > 0) { beltgel_t112 = (Convert.ToDouble(tableZaaltGuraw.Rows[0][20]) - Convert.ToDouble(tableZaaltGuraw.Rows[tableZaaltGuraw.Rows.Count - 1][20])) * 150000; }

                generalSchem.UDS_BELTGEL_SHIN_BL = Math.Round((beltgel_t112 + dundb[0, 7] - beltgel_1RO - beltgel_7R - beltgel_2RO - beltgel_8R - beltgel_10R - beltgel_9R - beltgel_11R - beltgel_12R - beltgel_13R - beltgel_t113) / (beltgel_t112 + dundb[0, 7]) * 100, 2).ToString();
            }
            catch { }
            #endregion
            dundb[0, 7] = dundb[10, 2] + dundb[10, 4] + dundb[10, 6] + dundb[10, 8] + dundb[10, 10] + dundb[10, 12] + dundb[10, 14] + dundb[10, 16] + dundb[11, 21] + dundb[11, 22] + dundb[11, 23] + dundb[11, 24] + dundb[11, 25];
            dundb[0, 8] = dundb[11, 20] + dundb[10, 1] + dundb[10, 3] + dundb[10, 5] + dundb[10, 7] + dundb[10, 9] + dundb[10, 11] + dundb[10, 13] + dundb[10, 15];

            generalSchem.L110BL = Math.Round((dundb[0, 7] - dundb[0, 8]) / dundb[0, 7] * 100, 2).ToString();

        }

        private void wpfDateStoptimer_Tick(object sender, EventArgs e)
        {
            blDateTimeEnd = DateTime.Now;
            while (blDateTimeEnd.Minute % 15 != 0)
            {
                blDateTimeEnd = blDateTimeEnd.AddMinutes(-1);
            }
            blDateTimeEnd = blDateTimeEnd.AddMinutes(1).AddSeconds(-blDateTimeEnd.Second + 1);
            generalSchem.blDateStop = blDateTimeEnd.ToString();
            Balance();
        }

        void Balance_Bodoh(object sender, EventArgs e)
        {
            Balance();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            try
            {
                reply85 = isping.Send("192.168.20.85");
                ping85 = reply85.Status == IPStatus.Success;
                if (ping85 == true)
                {
                    try
                    {

                        TcpClient client = new TcpClient();
                        client.Connect(IPAddress.Parse("192.168.20.85"), 9985);
                        data = Encoding.UTF8.GetBytes("aobo");
                        ehleh = 0;
                        ehlehtg = 0;
                        string t1 = "#$";
                        string t2 = "'*:";
                      //  string ut;

                        NetworkStream stream = client.GetStream();
                        stream.Write(data, 0, data.Length);
                        buffer = new byte[client.ReceiveBufferSize];
                        bytesRead = stream.Read(buffer, 0, client.ReceiveBufferSize);
                        response_utga = Encoding.UTF8.GetString(buffer, 0, bytesRead);


                        #region  horwuuleh  AO BO
                        for (int i = 0; i < response_utga.Length; i++)
                        {
                            if (response_utga[i] == t1[0])
                            {
                                tolow = 1;
                                r1 = i;

                            }
                            if (tolow == 1)
                            {
                                if (response_utga[i] == t1[1])
                                {
                                    r2 = i;
                                    tolow = 0;

                                    tonoglol[ehleh] = response_utga.Substring(r1, r2 - r1);
                                    ehleh++;
                                }
                            }

                        }


                        for (int i1 = 0; i1 < ehleh; i1++)
                        {
                            m = 0;
                            for (int i = 0; i < tonoglol[i1].Length; i++)
                            {
                                if (tonoglol[i1][i] == t2[0])
                                {
                                    tolow = 1;
                                    r1 = i;

                                }
                                if (tolow == 1)
                                {
                                    if (tonoglol[i1][i] == t2[1])
                                    {
                                        r2 = i;
                                        tolow = 0;

                                        tonoglolu[i1, m] = tonoglol[i1].Substring(r1, r2 - r1);
                                        m++;
                                    }
                                }

                            }
                        }

                        for (int i = 0; i < ehleh; i++)
                        {
                            for (int j = 0; j < 8; j++)
                            {
                                for (int i1 = 0; i1 < tonoglolu[i, j].Length; i1++)
                                {
                                    if (tonoglolu[i, j][i1] == t2[0])
                                    {
                                        i1++;
                                        tonoglolu1[i, j] = tonoglolu[i, j].Substring(i1, tonoglolu[i, j].Length - i1);
                                        //tonoglolutga[i, j] = Convert.ToUInt16(tonoglolu[i, j].Substring(i1, 2));
                                    }

                                    if (tonoglolu[i, j][i1] == t2[2])
                                    {
                                        i1++;
                                        tonoglolu1[i, j] = tonoglolu[i, j].Substring(i1, tonoglolu[i, j].Length - i1);
                                        tonoglolutga[i, j] = float.Parse(tonoglolu1[i, j]);
                                    }

                                }
                            }
                        }

                        #endregion
                        #region ao bo undur

                        #region 1ro ao
                        generalSchem.R1roaU = Math.Round(tonoglolutga[0, 1], 2).ToString();
                        generalSchem.R1roaI = Math.Round(tonoglolutga[0, 2], 2).ToString();
                        generalSchem.R1roaP = Math.Round(tonoglolutga[0, 3], 2).ToString();
                        generalSchem.R1roaQ = Math.Round(tonoglolutga[0, 4], 2).ToString();
                        generalSchem.R1roaPF = Math.Round(tonoglolutga[0, 5], 2).ToString();
                        if ((tonoglolutga[0, 6] == 0) && (tonoglolutga[0, 7] == 1))
                            generalSchem.R1roa = 1;
                        else
                            if ((tonoglolutga[0, 6] == 1) && (tonoglolutga[0, 7] == 0))
                                generalSchem.R1roa = 2;
                            else
                                generalSchem.R1roa = 3;

                        #endregion


                        #region 1ro bo
                        generalSchem.R1robU = Math.Round(tonoglolutga[1, 1], 2).ToString();
                        generalSchem.R1robI = Math.Round(tonoglolutga[1, 2], 2).ToString();
                        generalSchem.R1robP = Math.Round(tonoglolutga[1, 3], 2).ToString();
                        generalSchem.R1robQ = Math.Round(tonoglolutga[1, 4], 2).ToString();
                        generalSchem.R1robPF = Math.Round(tonoglolutga[1, 5], 2).ToString();
                        if ((tonoglolutga[1, 6] == 0) && (tonoglolutga[1, 7] == 1))
                            generalSchem.R1rob = 1;
                        else
                            if ((tonoglolutga[1, 6] == 1) && (tonoglolutga[1, 7] == 0))
                                generalSchem.R1rob = 2;
                            else
                                generalSchem.R1rob = 3;

                        #endregion

                        #region R7roa
                        generalSchem.R7raU = Math.Round(tonoglolutga[2, 1], 2).ToString();
                        generalSchem.R7raI = Math.Round(tonoglolutga[2, 2], 2).ToString();
                        generalSchem.R7raP = Math.Round(tonoglolutga[2, 3], 2).ToString();
                        generalSchem.R7raQ = Math.Round(tonoglolutga[2, 4], 2).ToString();
                        generalSchem.R7raPF = Math.Round(tonoglolutga[2, 5], 2).ToString();
                        if ((tonoglolutga[2, 6] == 0) && (tonoglolutga[2, 7] == 1))
                            generalSchem.R7ra = 1;
                        else
                            if ((tonoglolutga[2, 6] == 1) && (tonoglolutga[2, 7] == 0))
                                generalSchem.R7ra = 2;
                            else
                                generalSchem.R7ra = 3;

                        #endregion
                        #region R7rob
                        generalSchem.R7rbU = Math.Round(tonoglolutga[3, 1], 2).ToString();
                        generalSchem.R7rbI = Math.Round(tonoglolutga[3, 2], 2).ToString();
                        generalSchem.R7rbP = Math.Round(tonoglolutga[3, 3], 2).ToString();
                        generalSchem.R7rbQ = Math.Round(tonoglolutga[3, 4], 2).ToString();
                        generalSchem.R7rbPF = Math.Round(tonoglolutga[3, 5], 2).ToString();
                        if ((tonoglolutga[3, 6] == 0) && (tonoglolutga[3, 7] == 1))
                            generalSchem.R7rb = 1;
                        else
                            if ((tonoglolutga[3, 6] == 1) && (tonoglolutga[3, 7] == 0))
                                generalSchem.R7rb = 2;
                            else
                                generalSchem.R7rb = 3;

                        #endregion

                        #region R8ra
                        generalSchem.R8raU = Math.Round(tonoglolutga[4, 1], 2).ToString();
                        generalSchem.R8raI = Math.Round(tonoglolutga[4, 2], 2).ToString();
                        generalSchem.R8raP = Math.Round(tonoglolutga[4, 3], 2).ToString();
                        generalSchem.R8raQ = Math.Round(tonoglolutga[4, 4], 2).ToString();
                        generalSchem.R8raPF = Math.Round(tonoglolutga[4, 5], 2).ToString();
                        if ((tonoglolutga[4, 6] == 0) && (tonoglolutga[4, 7] == 1))
                            generalSchem.R8ra = 1;
                        else
                            if ((tonoglolutga[4, 6] == 1) && (tonoglolutga[4, 7] == 0))
                                generalSchem.R8ra = 2;
                            else
                                generalSchem.R8ra = 3;

                        #endregion
                        #region R8rb
                        generalSchem.R8rbU = Math.Round(tonoglolutga[5, 1], 2).ToString();
                        generalSchem.R8rbI = Math.Round(tonoglolutga[5, 2], 2).ToString();
                        generalSchem.R8rbP = Math.Round(tonoglolutga[5, 3], 2).ToString();
                        generalSchem.R8rbQ = Math.Round(tonoglolutga[5, 4], 2).ToString();
                        generalSchem.R8rbPF = Math.Round(tonoglolutga[5, 5], 2).ToString();
                        if ((tonoglolutga[5, 6] == 0) && (tonoglolutga[5, 7] == 1))
                            generalSchem.R8rb = 1;
                        else
                            if ((tonoglolutga[5, 6] == 1) && (tonoglolutga[5, 7] == 0))
                                generalSchem.R8rb = 2;
                            else
                                generalSchem.R8rb = 3;

                        #endregion

                        #region 2ro ao
                        generalSchem.R2roaU = Math.Round(tonoglolutga[6, 1], 2).ToString();
                        generalSchem.R2roaI = Math.Round(tonoglolutga[6, 2], 2).ToString();
                        generalSchem.R2roaP = Math.Round(tonoglolutga[6, 3], 2).ToString();
                        generalSchem.R2roaQ = Math.Round(tonoglolutga[6, 4], 2).ToString();
                        generalSchem.R2roaPF = Math.Round(tonoglolutga[6, 5], 2).ToString();
                        if ((tonoglolutga[6, 6] == 0) && (tonoglolutga[6, 7] == 1))
                            generalSchem.R2roa = 1;
                        else
                            if ((tonoglolutga[6, 6] == 1) && (tonoglolutga[6, 7] == 0))
                                generalSchem.R2roa = 2;
                            else
                                generalSchem.R2roa = 3;

                        #endregion

                        #region 2ro bo
                        generalSchem.R2robU = Math.Round(tonoglolutga[7, 1], 2).ToString();
                        generalSchem.R2robI = Math.Round(tonoglolutga[7, 2], 2).ToString();
                        generalSchem.R2robP = Math.Round(tonoglolutga[7, 3], 2).ToString();
                        generalSchem.R2robQ = Math.Round(tonoglolutga[7, 4], 2).ToString();
                        generalSchem.R2robPF = Math.Round(tonoglolutga[7, 5], 2).ToString();
                        if ((tonoglolutga[7, 6] == 0) && (tonoglolutga[7, 7] == 1))
                            generalSchem.R2rob = 1;
                        else
                            if ((tonoglolutga[7, 6] == 1) && (tonoglolutga[7, 7] == 0))
                                generalSchem.R2rob = 2;
                            else
                                generalSchem.R2rob = 3;

                        #endregion


                        #region R9ra
                        generalSchem.R9raU = Math.Round(tonoglolutga[8, 1], 2).ToString();
                        generalSchem.R9raI = Math.Round(tonoglolutga[8, 2], 2).ToString();
                        generalSchem.R9raP = Math.Round(tonoglolutga[8, 3], 2).ToString();
                        generalSchem.R9raQ = Math.Round(tonoglolutga[8, 4], 2).ToString();
                        generalSchem.R9raPF = Math.Round(tonoglolutga[8, 5], 2).ToString();
                        if ((tonoglolutga[8, 6] == 0) && (tonoglolutga[8, 7] == 1))
                            generalSchem.R9ra = 1;
                        else
                            if ((tonoglolutga[8, 6] == 1) && (tonoglolutga[8, 7] == 0))
                                generalSchem.R9ra = 2;
                            else
                                generalSchem.R9ra = 3;

                        #endregion
                        #region R9rb
                        generalSchem.R9rbU = Math.Round(tonoglolutga[9, 1], 2).ToString();
                        generalSchem.R9rbI = Math.Round(tonoglolutga[9, 2], 2).ToString();
                        generalSchem.R9rbP = Math.Round(tonoglolutga[9, 3], 2).ToString();
                        generalSchem.R9rbQ = Math.Round(tonoglolutga[9, 4], 2).ToString();
                        generalSchem.R9rbPF = Math.Round(tonoglolutga[9, 5], 2).ToString();
                        if ((tonoglolutga[9, 6] == 0) && (tonoglolutga[9, 7] == 1))
                            generalSchem.R9rb = 1;
                        else
                            if ((tonoglolutga[9, 6] == 1) && (tonoglolutga[9, 7] == 0))
                                generalSchem.R9rb = 2;
                            else
                                generalSchem.R9rb = 3;

                        #endregion
                        #region R10ra
                        generalSchem.R10raU = Math.Round(tonoglolutga[10, 1], 2).ToString();
                        generalSchem.R10raI = Math.Round(tonoglolutga[10, 2], 2).ToString();
                        generalSchem.R10raP = Math.Round(tonoglolutga[10, 3], 2).ToString();
                        generalSchem.R10raQ = Math.Round(tonoglolutga[10, 4], 2).ToString();
                        generalSchem.R10raPF = Math.Round(tonoglolutga[10, 5], 2).ToString();
                        if ((tonoglolutga[10, 6] == 0) && (tonoglolutga[10, 7] == 1))
                            generalSchem.R10ra = 1;
                        else
                            if ((tonoglolutga[10, 6] == 1) && (tonoglolutga[10, 7] == 0))
                                generalSchem.R10ra = 2;
                            else
                                generalSchem.R10ra = 3;

                        #endregion
                        #region R10rb
                        generalSchem.R10rbU = Math.Round(tonoglolutga[11, 1], 2).ToString();
                        generalSchem.R10rbI = Math.Round(tonoglolutga[11, 2], 2).ToString();
                        generalSchem.R10rbP = Math.Round(tonoglolutga[11, 3], 2).ToString();
                        generalSchem.R10rbQ = Math.Round(tonoglolutga[11, 4], 2).ToString();
                        generalSchem.R10rbPF = Math.Round(tonoglolutga[11, 5], 2).ToString();
                        if ((tonoglolutga[11, 6] == 0) && (tonoglolutga[11, 7] == 1))
                            generalSchem.R10rb = 1;
                        else
                            if ((tonoglolutga[11, 6] == 1) && (tonoglolutga[11, 7] == 0))
                                generalSchem.R10rb = 2;
                            else
                                generalSchem.R10rb = 3;

                        #endregion
                        #region R11ra
                        generalSchem.R11raU = Math.Round(tonoglolutga[12, 1], 2).ToString();
                        generalSchem.R11raI = Math.Round(tonoglolutga[12, 2], 2).ToString();
                        generalSchem.R11raP = Math.Round(tonoglolutga[12, 3], 2).ToString();
                        generalSchem.R11raQ = Math.Round(tonoglolutga[12, 4], 2).ToString();
                        generalSchem.R11raPF = Math.Round(tonoglolutga[12, 5], 2).ToString();
                        if ((tonoglolutga[12, 6] == 0) && (tonoglolutga[12, 7] == 1))
                            generalSchem.R11ra = 1;
                        else
                            if ((tonoglolutga[12, 6] == 1) && (tonoglolutga[12, 7] == 0))
                                generalSchem.R11ra = 2;
                            else
                                generalSchem.R11ra = 3;

                        #endregion
                        #region R11rb
                        generalSchem.R11rbU = Math.Round(tonoglolutga[13, 1], 2).ToString();
                        generalSchem.R11rbI = Math.Round(tonoglolutga[13, 2], 2).ToString();
                        generalSchem.R11rbP = Math.Round(tonoglolutga[13, 3], 2).ToString();
                        generalSchem.R11rbQ = Math.Round(tonoglolutga[13, 4], 2).ToString();
                        generalSchem.R11rbPF = Math.Round(tonoglolutga[13, 5], 2).ToString();
                        if ((tonoglolutga[13, 6] == 0) && (tonoglolutga[13, 7] == 1))
                            generalSchem.R11rb = 1;
                        else
                            if ((tonoglolutga[13, 6] == 1) && (tonoglolutga[13, 7] == 0))
                                generalSchem.R11rb = 2;
                            else
                                generalSchem.R11rb = 3;

                        #endregion

                        #region R12ra
                        generalSchem.R12raU = Math.Round(tonoglolutga[14, 1], 2).ToString();
                        generalSchem.R12raI = Math.Round(tonoglolutga[14, 2], 2).ToString();
                        generalSchem.R12raP = Math.Round(tonoglolutga[14, 3], 2).ToString();
                        generalSchem.R12raQ = Math.Round(tonoglolutga[14, 4], 2).ToString();
                        generalSchem.R12raPF = Math.Round(tonoglolutga[14, 5], 2).ToString();
                        if ((tonoglolutga[14, 6] == 0) && (tonoglolutga[14, 7] == 1))
                            generalSchem.R12ra = 1;
                        else
                            if ((tonoglolutga[14, 6] == 1) && (tonoglolutga[14, 7] == 0))
                                generalSchem.R12ra = 2;
                            else
                                generalSchem.R12ra = 3;

                        #endregion
                        #region R12rb
                        generalSchem.R12rbU = Math.Round(tonoglolutga[15, 1], 2).ToString();
                        generalSchem.R12rbI = Math.Round(tonoglolutga[15, 2], 2).ToString();
                        generalSchem.R12rbP = Math.Round(tonoglolutga[15, 3], 2).ToString();
                        generalSchem.R12rbQ = Math.Round(tonoglolutga[15, 4], 2).ToString();
                        generalSchem.R12rbPF = Math.Round(tonoglolutga[15, 5], 2).ToString();
                        if ((tonoglolutga[15, 6] == 0) && (tonoglolutga[15, 7] == 1))
                            generalSchem.R12rb = 1;
                        else
                            if ((tonoglolutga[15, 6] == 1) && (tonoglolutga[15, 7] == 0))
                                generalSchem.R12rb = 2;
                            else
                                generalSchem.R12rb = 3;

                        #endregion
                        #region R13ra
                        generalSchem.R13raU = Math.Round(tonoglolutga[16, 1], 2).ToString();
                        generalSchem.R13raI = Math.Round(tonoglolutga[16, 2], 2).ToString();
                        generalSchem.R13raP = Math.Round(tonoglolutga[16, 3], 2).ToString();
                        generalSchem.R13raQ = Math.Round(tonoglolutga[16, 4], 2).ToString();
                        generalSchem.R13raPF = Math.Round(tonoglolutga[16, 5], 2).ToString();
                        if ((tonoglolutga[16, 6] == 0) && (tonoglolutga[16, 7] == 1))
                            generalSchem.R13ra = 1;
                        else
                            if ((tonoglolutga[16, 6] == 1) && (tonoglolutga[16, 7] == 0))
                                generalSchem.R13ra = 2;
                            else
                                generalSchem.R13ra = 3;

                        #endregion


                        #endregion

                        #region TG
                        TcpClient client_tg = new TcpClient();
                        client_tg.Connect(IPAddress.Parse("192.168.20.85"), 10858);
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

                        #region TG1
                        generalSchem.TG1U = Math.Round(tonoglolutgatg[0, 1], 2).ToString();
                        generalSchem.TG1I = Math.Round(tonoglolutgatg[0, 2], 2).ToString();
                        generalSchem.TG1P = Math.Round(tonoglolutgatg[0, 3], 2).ToString();
                        generalSchem.TG1Q = Math.Round(tonoglolutgatg[0, 4], 2).ToString();
                        generalSchem.TG1PF = Math.Round(tonoglolutgatg[0, 5], 2).ToString();
                        if (tonoglolutgatg[0, 2] > 1)
                            generalSchem.TG1 = 1;
                        else generalSchem.TG1 = 2;
                        #endregion

                        #region TG2
                        generalSchem.TG2U = Math.Round(tonoglolutgatg[1, 1], 2).ToString();
                        generalSchem.TG2I = Math.Round(tonoglolutgatg[1, 2], 2).ToString();
                        generalSchem.TG2P = Math.Round(tonoglolutgatg[1, 3], 2).ToString();
                        generalSchem.TG2Q = Math.Round(tonoglolutgatg[1, 4], 2).ToString();
                        generalSchem.TG2PF = Math.Round(tonoglolutgatg[1, 5], 2).ToString();
                        if (tonoglolutgatg[1, 2] > 1)
                            generalSchem.TG2 = 1;
                        else generalSchem.TG2 = 2;
                        #endregion

                        #region TG3
                        generalSchem.TG3U = Math.Round(tonoglolutgatg[2, 1], 2).ToString();
                        generalSchem.TG3I = Math.Round(tonoglolutgatg[2, 2], 2).ToString();
                        generalSchem.TG3P = Math.Round(tonoglolutgatg[2, 3], 2).ToString();
                        generalSchem.TG3Q = Math.Round(tonoglolutgatg[2, 4], 2).ToString();
                        generalSchem.TG3PF = Math.Round(tonoglolutgatg[2, 5], 2).ToString();
                        if (tonoglolutgatg[1, 2] > 1)
                            generalSchem.TG3 = 1;
                        else generalSchem.TG3 = 2;
                        #endregion


                        #region TG4
                        generalSchem.TG4U = Math.Round(tonoglolutgatg[3, 1], 2).ToString();
                        generalSchem.TG4I = Math.Round(tonoglolutgatg[3, 2], 2).ToString();
                        generalSchem.TG4P = Math.Round(tonoglolutgatg[3, 3], 2).ToString();
                        generalSchem.TG4Q = Math.Round(tonoglolutgatg[3, 4], 2).ToString();
                        generalSchem.TG4PF = Math.Round(tonoglolutgatg[3, 5], 2).ToString();
                        if (tonoglolutgatg[3, 2] > 1)
                            generalSchem.TG4 = 1;
                        else generalSchem.TG4 = 2;
                        #endregion

                        #region TG5
                        generalSchem.TG5U = Math.Round(tonoglolutgatg[3, 1], 2).ToString();
                        generalSchem.TG5I = Math.Round(tonoglolutgatg[3, 2], 2).ToString();
                        generalSchem.TG5P = Math.Round(tonoglolutgatg[3, 3], 2).ToString();
                        generalSchem.TG5Q = Math.Round(tonoglolutgatg[3, 4], 2).ToString();
                        generalSchem.TG5PF = Math.Round(tonoglolutgatg[3, 5], 2).ToString();
                        if (tonoglolutgatg[3, 2] > 1)
                            generalSchem.TG5 = 1;
                        else generalSchem.TG5 = 2;
                        #endregion


                        #region TG5
                        generalSchem.TG5U = Math.Round(tonoglolutgatg[4, 1], 2).ToString();
                        generalSchem.TG5I = Math.Round(tonoglolutgatg[4, 2], 2).ToString();
                        generalSchem.TG5P = Math.Round(tonoglolutgatg[4, 3], 2).ToString();
                        generalSchem.TG5Q = Math.Round(tonoglolutgatg[4, 4], 2).ToString();
                        generalSchem.TG5PF = Math.Round(tonoglolutgatg[4, 5], 2).ToString();
                        if (tonoglolutgatg[4, 2] > 1)
                            generalSchem.TG5 = 1;
                        else generalSchem.TG5 = 2;
                        #endregion


                        #region TG6
                        generalSchem.TG6U = Math.Round(tonoglolutgatg[5, 1], 2).ToString();
                        generalSchem.TG6I = Math.Round(tonoglolutgatg[5, 2], 2).ToString();
                        generalSchem.TG6P = Math.Round(tonoglolutgatg[5, 3], 2).ToString();
                        generalSchem.TG6Q = Math.Round(tonoglolutgatg[5, 4], 2).ToString();
                        generalSchem.TG6PF = Math.Round(tonoglolutgatg[5, 5], 2).ToString();
                        if (tonoglolutgatg[5, 2] > 1)
                            generalSchem.TG6 = 1;
                        else generalSchem.TG6 = 2;
                        #endregion


                        #region TG7
                        generalSchem.TG7U = Math.Round(tonoglolutgatg[6, 1], 2).ToString();
                        generalSchem.TG7I = Math.Round(tonoglolutgatg[6, 2], 2).ToString();
                        generalSchem.TG7P = Math.Round(tonoglolutgatg[6, 3], 2).ToString();
                        generalSchem.TG7Q = Math.Round(tonoglolutgatg[6, 4], 2).ToString();
                        generalSchem.TG7PF = Math.Round(tonoglolutgatg[6, 5], 2).ToString();
                        if (tonoglolutgatg[6, 2] > 1)
                            generalSchem.TG7 = 1;
                        else generalSchem.TG7 = 2;
                        #endregion



                        #region TG8
                        generalSchem.TG8U = Math.Round(tonoglolutgatg[7, 1], 2).ToString();
                        generalSchem.TG8I = Math.Round(tonoglolutgatg[7, 2], 2).ToString();
                        generalSchem.TG8P = Math.Round(tonoglolutgatg[7, 3], 2).ToString();
                        generalSchem.TG8Q = Math.Round(tonoglolutgatg[7, 4], 2).ToString();
                        generalSchem.TG8PF = Math.Round(tonoglolutgatg[7, 5], 2).ToString();
                        if (tonoglolutgatg[7, 2] > 1)
                            generalSchem.TG8 = 1;
                        else generalSchem.TG8 = 2;
                        #endregion



                        #endregion




                        #endregion
                    }

                    catch
                    { }


                }
            }

            catch { }
        }



        private void Тооцоо_SizeChanged(object sender, EventArgs e)
        {

            if (this.Width > 1300)
            {
                panel11.Anchor = AnchorStyles.Bottom | AnchorStyles.Top;
                panel11.Width = this.Width - 500;

            }

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
                        reply85 = isping.Send("192.168.20.85");
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
                            client_tg.Connect(IPAddress.Parse("192.168.20.85"), 10858);
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
                                label2.Invoke(new Action(() => label2.Text = dundstring));
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
                                label13.Invoke(new Action(() => label13.Text = undurstring));

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
                                label384.Invoke(new Action(() => label384.Text = niitbolows));
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

        private void button14_Click(object sender, EventArgs e)
        {
            connectionopen(cont);
            
           /*   SqlCommand cmd = new SqlCommand("delete yalgawar3 where id > 0", cont);
                cmd.Parameters.AddWithValue("@tsag", DateTime.Today.AddDays(-7));
                cmd.ExecuteNonQuery();

                SqlDataAdapter da5 = new SqlDataAdapter("select * from yalgawar1  ORDER BY id ASC", cont);
                DataSet ds5 = new DataSet();
                da5.Fill(ds5, "neg");


                for (int i = 0; i < ds5.Tables[0].Rows.Count; i++ )
                {
               //     MessageBox.Show(ds5.Tables[0].Rows[i][1].ToString());

                    SqlCommand cmdn = new SqlCommand("INSERT INTO yalgawar3 (name, tname,segts1,cof, segts2 , tolow1, tolow2, tolow3) values (@t1, @t2, @t3, @t4, @t5, @t6, @t7, @t8)", cont);
                    cmdn.Parameters.AddWithValue("@t1", ds5.Tables[0].Rows[i][33]);
                    cmdn.Parameters.AddWithValue("@t2", ds5.Tables[0].Rows[i][34]);
                    cmdn.Parameters.AddWithValue("@t3", ds5.Tables[0].Rows[i][43]);
                    cmdn.Parameters.AddWithValue("@t4", ds5.Tables[0].Rows[i][35]);
                    cmdn.Parameters.AddWithValue("@t5", ds5.Tables[0].Rows[i][44]);
                    cmdn.Parameters.AddWithValue("@t6", ds5.Tables[0].Rows[i][36]);
                    cmdn.Parameters.AddWithValue("@t7", ds5.Tables[0].Rows[i][37]);
                    cmdn.Parameters.AddWithValue("@t8", ds5.Tables[0].Rows[i][38]);
                if (cmdn.ExecuteNonQuery() == 0)
                    {
                        MessageBox.Show("baazupdate : ");
                    }
                    //cmdn.Parameters.AddWithValue("@t" + i + "", (Math.Round((pet44d[i] - pet44_utga[i]) / pet44_inpulse[i], 0) + pet44_zaalt[i]) / Convert.ToDouble(table44.Rows[3][i + 2]));


                // yalgawar1 - ees yalgawar2 luu mor huulah

                }
           */
             
             

            #region Tooluuruud
            string[] hayag = new string[40];
            double[,] nutga7r = new double[5, 40];
            double[,] nutga8r = new double[5, 40];
            double[,] nutga1ro = new double[5, 40];
            double[,] nutga2ro = new double[5, 40];
            double[,] nutga9r = new double[5, 40];
            double[,] nutga10r = new double[5, 40];
            double[,] nutga11r = new double[5, 40];
            double[,] nutga12r = new double[5, 40];
            double[,] nutga13r = new double[5, 40];
            double[,] nutga14 = new double[5, 40];

            double[,] nutgatg5 = new double[5, 40];
            double[,] nutgatg6 = new double[5, 40];
            double[,] nutgatg7 = new double[5, 40];
            double[,] nutgatg8 = new double[5, 40];
            double[,] nutgatg9 = new double[5, 40];


            double[,] nutga7n = new double[5, 40];
            double[,] nutga8n = new double[5, 40];
            double[,] nutga9n = new double[5, 40];
            double[,] nutga10n = new double[5, 40];
            double[,] nutga11n = new double[5, 40];
            double[,] nutga12n = new double[5, 40];
            double[,] nutga13n = new double[5, 40];

            double[,] nutgagru = new double[5, 40];
            double[,] nutgaoru = new double[5, 40];
            double[,] nutgagishu04 = new double[5, 40];
            double[,] nutgarusn041 = new double[5, 40];
            double[,] nutgarusn042 = new double[5, 40];
            double[,] nutgarusn043 = new double[5, 40];
            double[,] nutgarusn044 = new double[5, 40];
            double[,] nutgarusn045 = new double[5, 40];
            double[,] nutgarusn046 = new double[5, 40];
            double[,] nutgarusn61 = new double[5, 40];
            double[,] nutgarusn62 = new double[5, 40];
            double[,] nutgarusn63 = new double[5, 40];
            double[,] nutgarusn64 = new double[5, 40];
            double[,] nutgarusn65 = new double[5, 40];
            double[,] nutgarusn66 = new double[5, 40];
            double[,] nutgatulsh = new double[5, 40];
            double[,] nutgapet = new double[5, 40];
            double[,] nutga203 = new double[5, 40];
            double[,] nutgafider = new double[5, 40];
            double[,] nutgazaaltguraw = new double[5, 40];

            string[,] sutga7r = new string[5, 40];
            string[,] sutga8r = new string[5, 40];
            string[,] sutga1ro = new string[5, 40];
            string[,] sutga2ro = new string[5, 40];
            string[,] sutga9r = new string[5, 40];
            string[,] sutga10r = new string[5, 40];
            string[,] sutga11r = new string[5, 40];
            string[,] sutga12r = new string[5, 40];
            string[,] sutga13r = new string[5, 40];
            string[,] sutga14 = new string[5, 40];

            string[,] sutgatg5 = new string[5, 40];
            string[,] sutgatg6 = new string[5, 40];
            string[,] sutgatg7 = new string[5, 40];
            string[,] sutgatg8 = new string[5, 40];
            string[,] sutgatg9 = new string[5, 40];


            string[,] sutga7n = new string[5, 40];
            string[,] sutga8n = new string[5, 40];
            string[,] sutga9n = new string[5, 40];
            string[,] sutga10n = new string[5, 40];
            string[,] sutga11n = new string[5, 40];
            string[,] sutga12n = new string[5, 40];
            string[,] sutga13n = new string[5, 40];

            string[,] sutgagru = new string[5, 40];
            string[,] sutgaoru = new string[5, 40];
            string[,] sutgagishu04 = new string[5, 40];
            string[,] sutgarusn041 = new string[5, 40];
            string[,] sutgarusn042 = new string[5, 40];
            string[,] sutgarusn043 = new string[5, 40];
            string[,] sutgarusn044 = new string[5, 40];
            string[,] sutgarusn045 = new string[5, 40];
            string[,] sutgarusn046 = new string[5, 40];
            string[,] sutgarusn61 = new string[5, 40];
            string[,] sutgarusn62 = new string[5, 40];
            string[,] sutgarusn63 = new string[5, 40];
            string[,] sutgarusn64 = new string[5, 40];
            string[,] sutgarusn65 = new string[5, 40];
            string[,] sutgarusn66 = new string[5, 40];
            string[,] sutgatulsh = new string[5, 40];
            string[,] sutgapet = new string[5, 40];
            string[,] sutga203 = new string[5, 40];
            string[,] sutgafider = new string[5, 40];
            string[,] sutgazaaltguraw = new string[5, 40];




            #endregion

            #region baaz hayag
            DateTime odor1 = DateTime.Now;
            DateTime d1 = DateTime.Now;
            DateTime d2 = dateTimePicker2.Value;
            TimeSpan d3 = d1 - d2;
            double d4 = d3.TotalDays;

            if (d4 < 31)
            {
                hayag[0] = "zaalt1";  // r8000 fider  
                hayag[1] = "zaaltguraw1";
                hayag[2] = "petzaalt1";
                hayag[3] = "rusn_04_11";
                hayag[4] = "rusn_04_21";
                hayag[5] = "rusn_04_31";
                hayag[6] = "rusn_04_41";
                hayag[7] = "rusn_04_51";
                hayag[8] = "rusn_04_61";
                hayag[9] = "rusn_6_11";
                hayag[10] = "rusn_6_21";
                hayag[11] = "rusn_6_31";
                hayag[12] = "rusn_6_41";
                hayag[13] = "rusn_6_51";
                hayag[14] = "rusn_6_61";
                hayag[15] = "gru1";
                hayag[16] = "tulsh1";
                hayag[17] = "gshu04_1";
                hayag[18] = "oru1";
                hayag[20] = "neg1";
                hayag[21] = "doloo1";
                hayag[22] = "tworo1";
                hayag[23] = "naimr1";
                hayag[24] = "esr1";
                hayag[25] = "araw1";
                hayag[26] = "arawneg1";
                hayag[27] = "arawtwo1";
                hayag[28] = "arawguraw1";
                hayag[29] = "daalgawara1";
                hayag[30] = "doloon1";
                hayag[31] = "naimn1";
                hayag[32] = "esn1";
                hayag[33] = "arawn1";
                hayag[34] = "arawnegn1";
                hayag[35] = "arawhoyorn1";
                hayag[36] = "arawguravn1";
                hayag[37] = "arawduruw";
                hayag[38] = "tooluur_garaar";

            }
            else
            {
                hayag[0] = "zaalt";
                hayag[1] = "zaaltguraw";
                hayag[2] = "petzaalt";
                hayag[3] = "rusn_04_1";
                hayag[4] = "rusn_04_2";
                hayag[5] = "rusn_04_3";
                hayag[6] = "rusn_04_4";
                hayag[7] = "rusn_04_5";
                hayag[8] = "rusn_04_6";
                hayag[9] = "rusn_6_1";
                hayag[10] = "rusn_6_2";
                hayag[11] = "rusn_6_3";
                hayag[12] = "rusn_6_4";
                hayag[13] = "rusn_6_5";
                hayag[14] = "rusn_6_6";
                hayag[15] = "gru";
                hayag[16] = "tulsh";
                hayag[17] = "gshu04";
                hayag[18] = "oru";
                hayag[20] = "neg";
                hayag[21] = "doloo";
                hayag[22] = "tworo";
                hayag[23] = "naimr";
                hayag[24] = "esr";
                hayag[25] = "araw";
                hayag[26] = "arawneg";
                hayag[27] = "arawtwo";
                hayag[28] = "arawguraw";
                hayag[29] = "daalgawar1";
                hayag[30] = "doloon";
                hayag[31] = "naimn";
                hayag[32] = "esn";
                hayag[33] = "arawn";
                hayag[34] = "arawnegn";
                hayag[35] = "arawhoyorn";
                hayag[36] = "arawguravn";
                hayag[37] = "arawduruw";
                hayag[38] = "tooluur_garaar";



            }
            #endregion


            #region new utga awah

            #region utga awah
            nutgagru = ntailan(con85dt, hayag[15], dateTimePicker2.Value, 12);
            nutgaoru = ntailan(con85dt, hayag[18], dateTimePicker2.Value, 25);
            nutgagishu04 = ntailan(con85dt, hayag[17], dateTimePicker2.Value, 3);
            nutgarusn041 = ntailan(con85dt, hayag[3], dateTimePicker2.Value, 11);
            nutgarusn042 = ntailan(con85dt, hayag[4], dateTimePicker2.Value, 10);
            nutgarusn043 = ntailan(con85dt, hayag[5], dateTimePicker2.Value, 6);
            nutgarusn044 = ntailan(con85dt, hayag[6], dateTimePicker2.Value, 8);
            nutgarusn045 = ntailan(con85dt, hayag[7], dateTimePicker2.Value, 8);
            nutgarusn046 = ntailan(con85dt, hayag[8], dateTimePicker2.Value, 8);
            nutgarusn61 = ntailan(con85dt, hayag[9], dateTimePicker2.Value, 9);
            nutgarusn62 = ntailan(con85dt, hayag[10], dateTimePicker2.Value, 10);
            nutgarusn63 = ntailan(con85dt, hayag[11], dateTimePicker2.Value, 6);
            nutgarusn64 = ntailan(con85dt, hayag[12], dateTimePicker2.Value, 5);
            nutgarusn65 = ntailan(con85dt, hayag[13], dateTimePicker2.Value, 6);
            nutgarusn66 = ntailan(con85dt, hayag[14], dateTimePicker2.Value, 6);
            nutgatulsh = ntailan(con85dt, hayag[16], dateTimePicker2.Value, 11);
            nutgapet = ntailan(con50_pet, hayag[2], dateTimePicker2.Value, 17);
            nutga7r = ntailan(con85tooluur, hayag[21], dateTimePicker2.Value, 17);
            nutga8r = ntailan(con85tooluur, hayag[23], dateTimePicker2.Value, 15);
            nutga9r = ntailan(con85tooluur, hayag[24], dateTimePicker2.Value, 14);
            nutga10r = ntailan(con85tooluur, hayag[25], dateTimePicker2.Value, 16);
            nutga11r = ntailan(con85tooluur, hayag[26], dateTimePicker2.Value, 17);
            nutga12r = ntailan(con85tooluur, hayag[27], dateTimePicker2.Value, 18);
            nutga13r = ntailan(con85tooluur, hayag[28], dateTimePicker2.Value, 15);
            nutga1ro = ntailan(con85tooluur, hayag[20], dateTimePicker2.Value, 10);
            nutga2ro = ntailan(con85tooluur, hayag[22], dateTimePicker2.Value, 11);
            nutga14 = ntailan(con, hayag[37], dateTimePicker2.Value, 8);

            nutga7n = ntailan(con85tooluur, hayag[30], dateTimePicker2.Value, 11);
            nutga8n = ntailan(con85tooluur, hayag[31], dateTimePicker2.Value, 9);
            nutga9n = ntailan(con85tooluur, hayag[32], dateTimePicker2.Value, 12);
            nutga10n = ntailan(con85tooluur, hayag[33], dateTimePicker2.Value, 8);
            nutga11n = ntailan(con85tooluur, hayag[34], dateTimePicker2.Value, 7);
            nutga12n = ntailan(con85tooluur, hayag[35], dateTimePicker2.Value, 8);
            nutga13n = ntailan(con85tooluur, hayag[36], dateTimePicker2.Value, 6);
            nutga203 = ntailan(con, hayag[38], dateTimePicker2.Value, 16);
            nutgafider = ntailanfider(confider, hayag[0], dateTimePicker2.Value, 16);
            nutgazaaltguraw = ntailan(con, hayag[1], dateTimePicker2.Value, 23);


            #endregion
            #region ner dotoodheregtsee
            sutgagru[0, 2] = "dt11";
            sutgagru[0, 3] = "drusn1";
            sutgagru[0, 4] = "drusn2";
            sutgagru[0, 5] = "drusn3";
            sutgagru[0, 6] = "drusn4";
            sutgagru[0, 7] = "drusn5";
            sutgagru[0, 8] = "drusn6";
            sutgagru[0, 9] = "dyach04";
            sutgagru[0, 10] = "dtungaah";
            sutgagru[0, 11] = "dtetsstroi";
            sutgagru[0, 12] = "dbelt_uduugch";

            sutgagishu04[0, 2] = "gerelg04";
            sutgagishu04[0, 3] = "eung04";

            sutgaoru[0, 2] = "t1_ugsun";
            sutgaoru[0, 3] = "t1_avsan";
            sutgaoru[0, 4] = "t2_ugsun";
            sutgaoru[0, 5] = "t2_avsan";
            sutgaoru[0, 6] = "sh111_ugsun";
            sutgaoru[0, 7] = "sh111_avsan";
            sutgaoru[0, 8] = "sh112_ugsun";
            sutgaoru[0, 9] = "sh112_avsan";
            sutgaoru[0, 10] = "sh105_ugsun";
            sutgaoru[0, 11] = "sh105_avsan";
            sutgaoru[0, 12] = "sh106_ugsun";
            sutgaoru[0, 13] = "sh106_avsan";
            sutgaoru[0, 14] = "ob_ugsun";
            sutgaoru[0, 15] = "ob_avsan";
            sutgaoru[0, 16] = "uildver_ugsun";
            sutgaoru[0, 17] = "uildver_avsan";
            sutgaoru[0, 18] = "t1_35_ugsun";
            sutgaoru[0, 19] = "t1_35_avsan";
            sutgaoru[0, 20] = "t2_35_ugsun";
            sutgaoru[0, 21] = "t2_35_avsan";
            sutgaoru[0, 22] = "holboo_a_ugsun";
            sutgaoru[0, 23] = "holboo_a_avsan";
            sutgaoru[0, 24] = "holboo_b_ugsun";
            sutgaoru[0, 25] = "holboo_b_avsan";

            sutgarusn041[0, 2] = "dtg1";
            sutgarusn041[0, 3] = "dcontor2";
            sutgarusn041[0, 4] = "dtun1";
            sutgarusn041[0, 5] = "dbager";
            sutgarusn041[0, 6] = "dsmiv1";
            sutgarusn041[0, 7] = "dn106";
            sutgarusn041[0, 8] = "dtsen1a";
            sutgarusn041[0, 9] = "dben1";
            sutgarusn041[0, 10] = "dmv1";
            sutgarusn041[0, 11] = "ddv1";

            sutgarusn042[0, 2] = "dtun2";
            sutgarusn042[0, 3] = "dtsen1b";
            sutgarusn042[0, 4] = "dtungaah2";
            sutgarusn042[0, 5] = "dsmiv2";
            sutgarusn042[0, 6] = "dtg2_tristor";
            sutgarusn042[0, 7] = "ddv2";
            sutgarusn042[0, 8] = "dmv2";
            sutgarusn042[0, 9] = "dcontor1";
            sutgarusn042[0, 10] = "dn207";

            sutgarusn043[0, 2] = "dtsen2a";
            sutgarusn043[0, 3] = "deun3";
            sutgarusn043[0, 4] = "dpsu3";
            sutgarusn043[0, 5] = "dtg2_sb";
            sutgarusn043[0, 6] = "dben2";

            sutgarusn044[0, 2] = "dtsen2b";
            sutgarusn044[0, 3] = "dnun4";
            sutgarusn044[0, 4] = "dben3";
            sutgarusn044[0, 5] = "dtun3";
            sutgarusn044[0, 6] = "deun1";
            sutgarusn044[0, 7] = "dgerel1";
            sutgarusn044[0, 8] = "dpsu4";

            sutgarusn045[0, 2] = "dmv5";
            sutgarusn045[0, 3] = "ddv5";
            sutgarusn045[0, 4] = "dtsen4a";
            sutgarusn045[0, 5] = "dtsen3a";
            sutgarusn045[0, 6] = "dtg3_sb";
            sutgarusn045[0, 7] = "dgagnuur1";
            sutgarusn045[0, 8] = "dgerel2";

            sutgarusn046[0, 2] = "dmv6";
            sutgarusn046[0, 3] = "dtsen3b";
            sutgarusn046[0, 4] = "ddv6";
            sutgarusn046[0, 5] = "dtg4_sb";
            sutgarusn046[0, 6] = "dgagnuur2";
            sutgarusn046[0, 7] = "dtsen4b";
            sutgarusn046[0, 8] = "dgerel3";

            sutgarusn61[0, 2] = "dt50";
            sutgarusn61[0, 3] = "dt41";
            sutgarusn61[0, 4] = "dt45";
            sutgarusn61[0, 5] = "dshbm1";
            sutgarusn61[0, 6] = "ddm1";
            sutgarusn61[0, 7] = "dpen2";
            sutgarusn61[0, 8] = "dsen1";
            sutgarusn61[0, 9] = "ddra";

            sutgarusn62[0, 2] = "dt46";
            sutgarusn62[0, 3] = "ddrb";
            sutgarusn62[0, 4] = "dt42";
            sutgarusn62[0, 5] = "dsen2";
            sutgarusn62[0, 6] = "ddm2";
            sutgarusn62[0, 7] = "dshbm2";
            sutgarusn62[0, 8] = "dpen3";
            sutgarusn62[0, 9] = "dbo13";
            sutgarusn62[0, 10] = "dt10";

            sutgarusn63[0, 2] = "dsen3";
            sutgarusn63[0, 3] = "dt43";
            sutgarusn63[0, 4] = "dpen1";
            sutgarusn63[0, 5] = "ddm3";
            sutgarusn63[0, 6] = "ddv3";

            sutgarusn64[0, 2] = "dpen6";
            sutgarusn64[0, 3] = "dt44";
            sutgarusn64[0, 4] = "ddm4";
            sutgarusn64[0, 5] = "ddv4";

            sutgarusn65[0, 2] = "dt48";
            sutgarusn65[0, 3] = "dpen5";
            sutgarusn65[0, 4] = "dbeltgel_odoogch";
            sutgarusn65[0, 5] = "dshbm5";
            sutgarusn65[0, 6] = "ddm5";

            sutgarusn66[0, 2] = "dt40";
            sutgarusn66[0, 3] = "dt49";
            sutgarusn66[0, 4] = "dpen4";
            sutgarusn66[0, 5] = "dshbm6";
            sutgarusn66[0, 6] = "ddm6";

            sutgatulsh[0, 2] = "onun1";
            sutgatulsh[0, 3] = "pekal_nasos2";
            sutgatulsh[0, 4] = "rmm";
            sutgatulsh[0, 5] = "khvo2";
            sutgatulsh[0, 6] = "nom1";
            sutgatulsh[0, 7] = "pekal_nasos1";
            sutgatulsh[0, 8] = "onun2";
            sutgatulsh[0, 9] = "khvo1";
            sutgatulsh[0, 10] = "mekhanic";
            sutgatulsh[0, 11] = "nom2";

            #endregion
            #region ner ip 50 pet
            sutgapet[0, 2] = "songino_a";
            sutgapet[0, 3] = "songino_b";
            sutgapet[0, 4] = "zam4_a";
            sutgapet[0, 5] = "zam4_b";
            sutgapet[0, 6] = "t10_35";
            sutgapet[0, 7] = "tg4_35";
            sutgapet[0, 8] = "esgiileha";
            sutgapet[0, 9] = "esgiilehb";
            sutgapet[0, 10] = "tkn1_a";
            sutgapet[0, 11] = "tkn1_b";
            sutgapet[0, 12] = "tkn2_a";
            sutgapet[0, 13] = "tkn2_b";
            sutgapet[0, 14] = "tkn3_a";
            sutgapet[0, 15] = "tkn3_b";
            sutgapet[0, 16] = "tkn4_a";
            sutgapet[0, 17] = "tkn4_b";



            #endregion
            #region ner tooluuriin zaalt
            sutga7r[0, 2] = "ben2";
            sutga7r[0, 3] = "dm71";
            sutga7r[0, 4] = "dm72";
            sutga7r[0, 5] = "dv7a1";
            sutga7r[0, 6] = "dv7a2";
            sutga7r[0, 7] = "dv7b1";
            sutga7r[0, 8] = "dv7b2";
            sutga7r[0, 9] = "shbm7a";
            sutga7r[0, 10] = "shbm7b";
            sutga7r[0, 11] = "t70";
            sutga7r[0, 12] = "pen5";
            sutga7r[0, 13] = "t51";
            sutga7r[0, 14] = "mv7a";
            sutga7r[0, 15] = "mv7b";
            sutga7r[0, 16] = "bo7";
            sutga7r[0, 17] = "ao7";

            sutga1ro[0, 2] = "ben1";
            sutga1ro[0, 3] = "dra";
            sutga1ro[0, 4] = "t201";
            sutga1ro[0, 5] = "t101";
            sutga1ro[0, 6] = "pkn1";
            sutga1ro[0, 7] = "sen8";
            sutga1ro[0, 8] = "olimp";
            sutga1ro[0, 9] = "bo1";
            sutga1ro[0, 10] = "ao1";

            sutga8r[0, 2] = "bo8";
            sutga8r[0, 3] = "dm81";
            sutga8r[0, 4] = "dm82";
            sutga8r[0, 5] = "dv8a1";
            sutga8r[0, 6] = "dv8a2";
            sutga8r[0, 7] = "dv8b1";
            sutga8r[0, 8] = "dv8b2";
            sutga8r[0, 9] = "shbm8a";
            sutga8r[0, 10] = "shbm8b";
            sutga8r[0, 11] = "bkn6b";
            sutga8r[0, 12] = "t52";
            sutga8r[0, 13] = "mv8b";
            sutga8r[0, 14] = "mv8a";
            sutga8r[0, 15] = "ao8";

            sutga2ro[0, 2] = "ao2";
            sutga2ro[0, 3] = "beltod";
            sutga2ro[0, 4] = "perk2";
            sutga2ro[0, 5] = "pen6";
            sutga2ro[0, 6] = "sen7";
            sutga2ro[0, 7] = "ben3";
            sutga2ro[0, 8] = "drb";
            sutga2ro[0, 9] = "t202";
            sutga2ro[0, 10] = "t102";
            sutga2ro[0, 11] = "bo2";

            sutga9r[0, 2] = "dm9";
            sutga9r[0, 3] = "dv9a";
            sutga9r[0, 4] = "dv9b";
            sutga9r[0, 5] = "mv9a";
            sutga9r[0, 6] = "mv9b";
            sutga9r[0, 7] = "shbm9a";
            sutga9r[0, 8] = "shbm9b";
            sutga9r[0, 9] = "bo9";
            sutga9r[0, 10] = "ao9";
            sutga9r[0, 11] = "sen6";
            sutga9r[0, 12] = "bkn7a";
            sutga9r[0, 13] = "t53";
            sutga9r[0, 14] = "pen8";

            sutga10r[0, 2] = "shbm10a";
            sutga10r[0, 3] = "shbm10b";
            sutga10r[0, 4] = "dv10a2";
            sutga10r[0, 5] = "dv10a1";
            sutga10r[0, 6] = "dv10b2";
            sutga10r[0, 7] = "dv10b1";
            sutga10r[0, 8] = "dm102";
            sutga10r[0, 9] = "dm101";
            sutga10r[0, 10] = "pen7";
            sutga10r[0, 11] = "mv10a";
            sutga10r[0, 12] = "mv10b";
            sutga10r[0, 13] = "t54";
            sutga10r[0, 14] = "ao10";
            sutga10r[0, 15] = "bo10";
            sutga10r[0, 16] = "bs01";

            sutga11r[0, 2] = "dm111";
            sutga11r[0, 3] = "dm112";
            sutga11r[0, 4] = "dv11a1";
            sutga11r[0, 5] = "dv11a2";
            sutga11r[0, 6] = "dv11b1";
            sutga11r[0, 7] = "dv11b2";
            sutga11r[0, 8] = "shbm11a";
            sutga11r[0, 9] = "shbm11b";
            sutga11r[0, 10] = "t55";
            sutga11r[0, 11] = "mv11a";
            sutga11r[0, 12] = "mv11b";
            sutga11r[0, 13] = "pen9";
            sutga11r[0, 14] = "sen10";
            sutga11r[0, 15] = "bo11";
            sutga11r[0, 16] = "ao11";
            sutga11r[0, 17] = "bs02";

            sutga12r[0, 2] = "dm121";
            sutga12r[0, 3] = "dm122";
            sutga12r[0, 4] = "dv12a1";
            sutga12r[0, 5] = "dv12a2";
            sutga12r[0, 6] = "dv12b1";
            sutga12r[0, 7] = "dv12b2";
            sutga12r[0, 8] = "shbm12a";
            sutga12r[0, 9] = "bs02_12";
            sutga12r[0, 10] = "eun";
            sutga12r[0, 11] = "sen9";
            sutga12r[0, 12] = "shbm12b";
            sutga12r[0, 13] = "tp4";
            sutga12r[0, 14] = "t56";
            sutga12r[0, 15] = "mv12a";
            sutga12r[0, 16] = "mv12b";
            sutga12r[0, 17] = "bo12";
            sutga12r[0, 18] = "ao12";

            sutga13r[0, 2] = "dm131";
            sutga13r[0, 3] = "dm132";
            sutga13r[0, 4] = "dv13a1";
            sutga13r[0, 5] = "dv13a2";
            sutga13r[0, 6] = "dv13b1";
            sutga13r[0, 7] = "dv13b2";
            sutga13r[0, 8] = "pen10";
            sutga13r[0, 9] = "shbm13a";
            sutga13r[0, 10] = "shbm13b";
            sutga13r[0, 11] = "t57";
            sutga13r[0, 12] = "mv13a";
            sutga13r[0, 13] = "mv13b";
            sutga13r[0, 14] = "t60";
            sutga13r[0, 15] = "ao13";

            sutga7n[0, 2] = "lk3a";
            sutga7n[0, 3] = "prk3";
            sutga7n[0, 4] = "nozu1";
            sutga7n[0, 5] = "tkn5a";
            sutga7n[0, 6] = "tkn6a";
            sutga7n[0, 7] = "tsen5a";
            sutga7n[0, 8] = "tsen6a";
            sutga7n[0, 9] = "n730";
            sutga7n[0, 10] = "obegrive7";
            sutga7n[0, 11] = "n723";

            sutga8n[0, 2] = "smiv1";
            sutga8n[0, 3] = "bzk1";
            sutga8n[0, 4] = "tkn5b";
            sutga8n[0, 5] = "tkn6b";
            sutga8n[0, 6] = "tsen5b";
            sutga8n[0, 7] = "tsen6b";
            sutga8n[0, 8] = "tun3";
            sutga8n[0, 9] = "nozu2";

            sutga9n[0, 2] = "pen7m";
            sutga9n[0, 3] = "bzk2";
            sutga9n[0, 4] = "tg6ud";
            sutga9n[0, 5] = "smiv2";
            sutga9n[0, 6] = "lk3b";
            sutga9n[0, 7] = "tkn7a";
            sutga9n[0, 8] = "tsen7a";
            sutga9n[0, 9] = "n830";
            sutga9n[0, 10] = "kran";
            sutga9n[0, 11] = "oru";
            sutga9n[0, 12] = "tungaah5";

            sutga10n[0, 2] = "tsen7b";
            sutga10n[0, 3] = "bkn6a";
            sutga10n[0, 4] = "tkn7b";
            sutga10n[0, 5] = "bkn8b";
            sutga10n[0, 6] = "nozu3";
            sutga10n[0, 7] = "n1029";
            sutga10n[0, 8] = "tsagaanbair";

            sutga11n[0, 2] = "vdm";
            sutga11n[0, 3] = "bkn7b";
            sutga11n[0, 4] = "tsen8a";
            sutga11n[0, 5] = "n1030";
            sutga11n[0, 6] = "bkn8a";
            sutga11n[0, 7] = "tkn8a";

            sutga12n[0, 2] = "lk4a";
            sutga12n[0, 3] = "tsen8b";
            sutga12n[0, 4] = "tkn8b";
            sutga12n[0, 5] = "bkn5ab";
            sutga12n[0, 6] = "etsl5";
            sutga12n[0, 7] = "etsl4";
            sutga12n[0, 8] = "tun6";

            sutga13n[0, 2] = "lk4b";
            sutga13n[0, 3] = "tkn93";
            sutga13n[0, 4] = "knasos92";
            sutga13n[0, 5] = "vnasos92";
            sutga13n[0, 6] = "zuuhbair";

            sutga203[0, 2] = "sons3";
            sutga203[0, 3] = "sons4";
            sutga203[0, 4] = "nasos1";
            sutga203[0, 5] = "nasos2";
            sutga203[0, 6] = "nasos3";
            sutga203[0, 7] = "lep3";
            sutga203[0, 8] = "lep4";
            sutga203[0, 9] = "tsn1";
            sutga203[0, 10] = "tsn2";
            sutga203[0, 11] = "olimp";
            sutga203[0, 12] = "emneleg";
            sutga203[0, 13] = "shts";
            sutga203[0, 14] = "horih_angi";
            sutga203[0, 15] = "erchim_hothon";
            sutga203[0, 16] = "monos";

            sutgafider[0, 2] = "gobi1";
            sutgafider[0, 3] = "gobi2";
            sutgafider[0, 4] = "dsk1";
            sutgafider[0, 5] = "dsk2";
            sutgafider[0, 6] = "sot2";
            sutgafider[0, 7] = "sot3";
            sutgafider[0, 8] = "graj";
            sutgafider[0, 9] = "nasosstants1";
            sutgafider[0, 10] = "nasosstants2";
            sutgafider[0, 11] = "sons1";
            sutgafider[0, 12] = "sons2";
            sutgafider[0, 13] = "altandornod";
            sutgafider[0, 14] = "system";
            sutgafider[0, 15] = "object540";
            sutgafider[0, 16] = "erchim";

            #endregion
            #region 14  zaaltguraw

            sutga14[0, 2] = "eun14";
            sutga14[0, 3] = "suh14";
            sutga14[0, 4] = "tkn214";
            sutga14[0, 5] = "tkn114";
            sutga14[0, 6] = "tosnasos14";
            sutga14[0, 7] = "vacum14";
            sutga14[0, 8] = "t58";

            sutgazaaltguraw[0, 2] = "ztg1";
            sutgazaaltguraw[0, 3] = "ztg2";
            sutgazaaltguraw[0, 4] = "ztg3";
            sutgazaaltguraw[0, 5] = "ztg4";
            sutgazaaltguraw[0, 6] = "ztg5";
            sutgazaaltguraw[0, 7] = "ztg6";
            sutgazaaltguraw[0, 8] = "ztg7";
            sutgazaaltguraw[0, 9] = "ztg8";
            sutgazaaltguraw[0, 10] = "ztg9";
            sutgazaaltguraw[0, 11] = "zt1avsan";
            sutgazaaltguraw[0, 12] = "zt1ogson";
            sutgazaaltguraw[0, 13] = "zt2avsan";
            sutgazaaltguraw[0, 14] = "zt2ogson";
            sutgazaaltguraw[0, 15] = "btr5";
            sutgazaaltguraw[0, 16] = "btr6";
            sutgazaaltguraw[0, 17] = "btr7";
            sutgazaaltguraw[0, 18] = "btr8";
            sutgazaaltguraw[0, 19] = "btr9";
            sutgazaaltguraw[0, 20] = "zt12_6kv";
            sutgazaaltguraw[0, 21] = "ao14";
            sutgazaaltguraw[0, 22] = "bo14";
            sutgazaaltguraw[0, 23] = "zt12_110kv";


            #endregion




            #region utga olgoh

            ugtaolgoh(cont, sutgagru, dateTimePicker2.Value, nutgagru, 11);
            ugtaolgoh(cont, sutgagishu04, dateTimePicker2.Value, nutgagishu04, 3);
            ugtaolgoh(cont, sutgaoru, dateTimePicker2.Value, nutgaoru, 25);
            ugtaolgoh(cont, sutgarusn041, dateTimePicker2.Value, nutgarusn041, 11);
            ugtaolgoh(cont, sutgarusn042, dateTimePicker2.Value, nutgarusn042, 10);
            ugtaolgoh(cont, sutgarusn043, dateTimePicker2.Value, nutgarusn043, 6);
            ugtaolgoh(cont, sutgarusn044, dateTimePicker2.Value, nutgarusn044, 8);
            ugtaolgoh(cont, sutgarusn045, dateTimePicker2.Value, nutgarusn045, 8);
            ugtaolgoh(cont, sutgarusn046, dateTimePicker2.Value, nutgarusn046, 8);
            ugtaolgoh(cont, sutgarusn61, dateTimePicker2.Value, nutgarusn61, 9);
            ugtaolgoh(cont, sutgarusn62, dateTimePicker2.Value, nutgarusn62, 10);
            ugtaolgoh(cont, sutgarusn63, dateTimePicker2.Value, nutgarusn63, 6);
            ugtaolgoh(cont, sutgarusn64, dateTimePicker2.Value, nutgarusn64, 5);
            ugtaolgoh(cont, sutgarusn65, dateTimePicker2.Value, nutgarusn65, 6);
            ugtaolgoh(cont, sutgarusn66, dateTimePicker2.Value, nutgarusn66, 6);
            ugtaolgoh(cont, sutgapet, dateTimePicker2.Value, nutgapet, 17);
            ugtaolgoh(cont, sutgatulsh, dateTimePicker2.Value, nutgatulsh, 11);
            ugtaolgoh(cont, sutga7r, dateTimePicker2.Value, nutga7r, 17);
            ugtaolgoh(cont, sutga1ro, dateTimePicker2.Value, nutga1ro, 10);
            ugtaolgoh(cont, sutga8r, dateTimePicker2.Value, nutga8r, 15);
            ugtaolgoh(cont, sutga2ro, dateTimePicker2.Value, nutga2ro, 11);
            ugtaolgoh(cont, sutga9r, dateTimePicker2.Value, nutga9r, 14);
            ugtaolgoh(cont, sutga10r, dateTimePicker2.Value, nutga10r, 16);
            ugtaolgoh(cont, sutga11r, dateTimePicker2.Value, nutga11r, 17);
            ugtaolgoh(cont, sutga12r, dateTimePicker2.Value, nutga12r, 18);
            ugtaolgoh(cont, sutga13r, dateTimePicker2.Value, nutga13r, 15);
            ugtaolgoh(cont, sutga7n, dateTimePicker2.Value, nutga7n, 11);
            ugtaolgoh(cont, sutga8n, dateTimePicker2.Value, nutga8n, 9);
            ugtaolgoh(cont, sutga9n, dateTimePicker2.Value, nutga9n, 12);
            ugtaolgoh(cont, sutga10n, dateTimePicker2.Value, nutga10n, 8);
            ugtaolgoh(cont, sutga11n, dateTimePicker2.Value, nutga11n, 7);
            ugtaolgoh(cont, sutga12n, dateTimePicker2.Value, nutga12n, 8);
            ugtaolgoh(cont, sutga13n, dateTimePicker2.Value, nutga13n, 6);
            ugtaolgoh(cont, sutga203, dateTimePicker2.Value, nutga203, 16);
            ugtaolgoh(cont, sutgafider, dateTimePicker2.Value, nutgafider, 16);
            ugtaolgoh(cont, sutga14, dateTimePicker2.Value, nutga14, 8);
            ugtaolgoh(cont, sutgazaaltguraw, dateTimePicker2.Value, nutgazaaltguraw, 23);

            #endregion
            #region tailain dund
            // zuuh1 niilber
            double nzuuh1niit;
            nzuuh1niit = nutgarusn041[2, 10] + nutgarusn041[2, 11] + nutgarusn61[2, 5] + nutgarusn61[2, 6];
          
            utganiilber(cont, dateTimePicker2.Value, "niitzuuh1", nzuuh1niit);

            // zuuh2 niilber
            double nzuuh2niit;
            nzuuh2niit = nutgarusn042[2, 7] + nutgarusn042[2, 8] + nutgarusn62[2, 6] + nutgarusn62[2, 7];
            utganiilber(cont, dateTimePicker2.Value, "niitzuuh2", nzuuh2niit);
            // zuuh3 niilber
            double nzuuh3niit;
            nzuuh3niit = nutgarusn63[2, 5] + nutgarusn63[2, 6];
            utganiilber(cont, dateTimePicker2.Value, "niitzuuh3", nzuuh3niit);

            // zuuh4 niilber
            double nzuuh4niit;
            nzuuh4niit = nutgarusn64[2, 4] + nutgarusn64[2, 5];
            utganiilber(cont, dateTimePicker2.Value, "niitzuuh4", nzuuh4niit);

            // zuuh5 niilber
            double nzuuh5niit;
            nzuuh5niit = nutgarusn045[2, 2] + nutgarusn045[2, 3] + nutgarusn65[2, 5] + nutgarusn65[2, 6];
            utganiilber(cont, dateTimePicker2.Value, "niitzuuh5", nzuuh5niit);
            // zuuh6 niilber
            double nzuuh6niit;
            nzuuh6niit = nutgarusn046[2, 2] + nutgarusn046[2, 4] + nutgarusn66[2, 5] + nutgarusn66[2, 6];
            utganiilber(cont, dateTimePicker2.Value, "niitzuuh6", nzuuh6niit);

            //zuuh dund niit 
            double nzuuhdniit;
            nzuuhdniit = nzuuh1niit + nzuuh2niit + nzuuh3niit + nzuuh4niit + nzuuh5niit + nzuuh6niit;
            utganiilber(cont, dateTimePicker2.Value, "niitzuuhd", nzuuhdniit);
            //zuuh tuslah niit
            double nzuuhtuslahniit;
            nzuuhtuslahniit = nutgatulsh[2, 6] + nutgatulsh[2, 11] + nutgarusn043[2, 4] + nutgarusn044[2, 8] + nutgarusn041[2, 6] + nutgarusn042[2, 5] + nutgarusn042[2, 4] + nutgarusn041[2, 9] + nutgarusn043[2, 6] + nutgarusn044[2, 4] + nutgarusn041[2, 5];
            utganiilber(cont, dateTimePicker2.Value, "niitzuuhtuslah", nzuuhtuslahniit);

            //tg1 niit
            double ntg1niit;
            ntg1niit = nutgarusn041[2, 8] + nutgarusn042[2, 3] + nutgapet[2, 10] + nutgapet[2, 11];
            utganiilber(cont, dateTimePicker2.Value, "niittg1", ntg1niit);
            //tg2 niit
            double ntg2niit;
            ntg2niit = nutgarusn043[2, 2] + nutgarusn044[2, 2] + nutgapet[2, 12] + nutgapet[2, 13];
            utganiilber(cont, dateTimePicker2.Value, "niittg2", ntg2niit);
            //tg3 niit
            double ntg3niit;
            ntg3niit = nutgarusn045[2, 5] + nutgarusn046[2, 3] + nutgapet[2, 14] + nutgapet[2, 15];
            utganiilber(cont, dateTimePicker2.Value, "niittg3", ntg3niit);
            //tg4 niit
            double ntg4niit;
            ntg4niit = nutgarusn045[2, 4] + nutgarusn046[2, 7] + nutgapet[2, 16] + nutgapet[2, 17];
            utganiilber(cont, dateTimePicker2.Value, "niittg4", ntg4niit);
            //tg dund niit
            double ntgdniit;
            ntgdniit = ntg1niit + ntg2niit + ntg3niit + ntg4niit;
            utganiilber(cont, dateTimePicker2.Value, "niittgdund", ntgdniit);
            // pen dund niit
            double npenniit;
            npenniit = nutgarusn63[2, 4] + nutgarusn61[2, 7] + nutgarusn62[2, 8] + nutgarusn66[2, 4] + nutgarusn65[2, 3] + nutgarusn64[2, 2];
            utganiilber(cont, dateTimePicker2.Value, "niitpendund", npenniit);
            // sen dund niit
            double nsenniit;
            nsenniit = nutgarusn61[2, 8] + nutgarusn62[2, 5] + nutgarusn63[2, 2];
            utganiilber(cont, dateTimePicker2.Value, "niitsendund", nsenniit);

            double ndds1niit;
            ndds1niit = nutgarusn044[2, 3] + nutgarusn044[2, 6] + nutgarusn043[2, 3] + nutgagishu04[2, 3];
            utganiilber(cont, dateTimePicker2.Value, "niitdds1dund", ndds1niit);
            //tun niilber
            double ntundundniit;
            ntundundniit = nutgarusn041[2, 4] + nutgarusn042[2, 2] + nutgarusn044[2, 5];
            utganiilber(cont, dateTimePicker2.Value, "niittundnun", ntundundniit);

            double niitpekal = nutgatulsh[2,10] + nutgatulsh[2,4] + nutgatulsh[2,3] + nutgatulsh[2,7];
            utganiilber(cont, dateTimePicker2.Value, "niitpekal", niitpekal);

            double niitkontor = nutgarusn042[2, 9] + nutgarusn041[2, 3];
            utganiilber(cont, dateTimePicker2.Value, "niitkontor", niitkontor);


            double t41b;
            t41b = nutgarusn61[2, 3] - nutgarusn041[2, 2] - nutgarusn041[2, 3] - nutgarusn041[2, 4] - nutgarusn041[2, 5] - nutgarusn041[2, 6] - nutgarusn041[2, 7] - nutgarusn041[2, 8] - nutgarusn041[2, 9] - nutgarusn041[2, 10] - nutgarusn041[2, 11];
            utganiilber(cont, dateTimePicker2.Value, "t41b", t41b);

            double t42b;
            t42b = nutgarusn62[2, 4] - nutgarusn042[2, 2] - nutgarusn042[2, 3] - nutgarusn042[2, 4] - nutgarusn042[2, 5] - nutgarusn042[2, 6] - nutgarusn042[2, 7] - nutgarusn042[2, 8] - nutgarusn042[2, 9] - nutgarusn042[2, 10];
            utganiilber(cont, dateTimePicker2.Value, "t42b", t42b);

            double t43b;
            t43b = nutgarusn63[2, 3] - nutgarusn043[2, 2] - nutgarusn043[2, 3] - nutgarusn043[2, 4] - nutgarusn043[2, 5] - nutgarusn043[2, 6];
            utganiilber(cont, dateTimePicker2.Value, "t43b", t43b);

            double t44b;
            t44b = nutgarusn64[2, 3] - nutgarusn044[2, 2] - nutgarusn044[2, 3] - nutgarusn044[2, 4] - nutgarusn044[2, 5] - nutgarusn044[2, 6] - nutgarusn044[2, 7] - nutgarusn044[2, 8];
            utganiilber(cont, dateTimePicker2.Value, "t44b", t44b);

            double t48b;
            t48b = nutgarusn65[2, 2] - nutgarusn045[2, 2] - nutgarusn045[2, 3] - nutgarusn045[2, 4] - nutgarusn045[2, 5] - nutgarusn045[2, 6] - nutgarusn045[2, 7] - nutgarusn045[2, 8];
            utganiilber(cont, dateTimePicker2.Value, "t48b", t48b);

            double t49b;
            t49b = nutgarusn66[2, 3] - nutgarusn046[2, 2] - nutgarusn046[2, 3] - nutgarusn046[2, 4] - nutgarusn046[2, 5] - nutgarusn046[2, 6] - nutgarusn046[2, 7] - nutgarusn046[2, 8];
            utganiilber(cont, dateTimePicker2.Value, "t49b", t49b);

            double t45b;
            t45b = nutgarusn61[2, 4] - nutgatulsh[2, 11] - nutgatulsh[2, 9] - nutgatulsh[2, 2] - nutgatulsh[2, 7] - nutgatulsh[2, 10];
            utganiilber(cont, dateTimePicker2.Value, "t45b", t45b);

            double t46b;
            t46b = nutgarusn62[2, 2] - nutgatulsh[2, 3] - nutgatulsh[2, 4] - nutgatulsh[2, 5] - nutgatulsh[2, 6] - nutgatulsh[2, 8];
            utganiilber(cont, dateTimePicker2.Value, "t46b", t46b);
            #endregion
            double niittrdund = t41b + t42b + t43b + t44b + t48b + t49b + t45b + t46b + nutgarusn61[2, 2] + nutgarusn66[2, 2];
            utganiilber(cont, dateTimePicker2.Value, "niittrdund", niittrdund);


            double dgerelniit;
            dgerelniit = nutgarusn044[2, 7] + nutgarusn045[2, 7] + nutgarusn045[2, 8] + nutgarusn046[2, 6] + nutgarusn046[2, 8] + nutgarusn042[2, 6];
            utganiilber(cont, dateTimePicker2.Value, "niittgereldund", dgerelniit);
            #endregion

            double mv7niit = nutga7r[2, 14] + nutga7r[2, 15];
            utganiilber(cont, dateTimePicker2.Value, "mv7niit", mv7niit);
            double mv8niit = nutga8r[2, 13] + nutga8r[2, 14];
            utganiilber(cont, dateTimePicker2.Value, "mv8niit", mv8niit);
            double mv9niit = nutga9r[2, 5] + nutga9r[2, 6];
            utganiilber(cont, dateTimePicker2.Value, "mv9niit", mv9niit);
            double mv10niit = nutga10r[2, 11] + nutga10r[2, 12];
            utganiilber(cont, dateTimePicker2.Value, "mv10niit", mv10niit);
            double mv11niit = nutga11r[2, 11] + nutga11r[2, 12];
            utganiilber(cont, dateTimePicker2.Value, "mv11niit", mv11niit);
            double mv12niit = nutga12r[2, 15] + nutga12r[2, 16];
            utganiilber(cont, dateTimePicker2.Value, "mv12niit", mv12niit);
            double mv13niit = nutga13r[2, 12] + nutga13r[2, 13];
            utganiilber(cont, dateTimePicker2.Value, "mv13niit", mv13niit);

            double shbm7niit = nutga7r[2, 9] + nutga7r[2, 10];
            utganiilber(cont, dateTimePicker2.Value, "shbm7niit", shbm7niit);
            double shbm8niit = nutga8r[2, 9] + nutga8r[2, 10];
            utganiilber(cont, dateTimePicker2.Value, "shbm8niit", shbm8niit);
            double shbm9niit = nutga9r[2, 7] + nutga9r[2, 8];
            utganiilber(cont, dateTimePicker2.Value, "shbm9niit", shbm9niit);
            double shbm10niit = nutga10r[2, 2] + nutga10r[2, 3];
            utganiilber(cont, dateTimePicker2.Value, "shbm10niit", shbm10niit);
            double shbm11niit = nutga11r[2, 8] + nutga11r[2, 9];
            utganiilber(cont, dateTimePicker2.Value, "shbm11niit", shbm11niit);
            double shbm12niit = nutga12r[2, 8] + nutga12r[2, 12];
            utganiilber(cont, dateTimePicker2.Value, "shbm12niit", shbm12niit);
            double shbm13niit = nutga13r[2, 9] + nutga13r[2, 10];
            utganiilber(cont, dateTimePicker2.Value, "shbm13niit", shbm13niit);

            double dm7niit = nutga7r[2, 3] + nutga7r[2, 4];
            utganiilber(cont, dateTimePicker2.Value, "dm7niit", dm7niit);
            double dm8niit = nutga8r[2, 3] + nutga8r[2, 4];
            utganiilber(cont, dateTimePicker2.Value, "dm8niit", dm8niit);
            double dm9niit = nutga9r[2, 2];
            utganiilber(cont, dateTimePicker2.Value, "dm9niit", dm9niit);
            double dm10niit = nutga10r[2, 8] + nutga10r[2, 9];
            utganiilber(cont, dateTimePicker2.Value, "dm10niit", dm10niit);
            double dm11niit = nutga11r[2, 2] + nutga11r[2, 3];
            utganiilber(cont, dateTimePicker2.Value, "dm11niit", dm11niit);
            double dm12niit = nutga12r[2, 2] + nutga12r[2, 3];
            utganiilber(cont, dateTimePicker2.Value, "dm12niit", dm12niit);
            double dm13niit = nutga13r[2, 2] + nutga13r[2, 3];
            utganiilber(cont, dateTimePicker2.Value, "dm13niit", dm13niit);

            double dv7niit = nutga7r[2, 5] + nutga7r[2, 6] + nutga7r[2, 7] + nutga7r[2, 8];
            utganiilber(cont, dateTimePicker2.Value, "dv7niit", dv7niit);
            double dv8niit = nutga8r[2, 5] + nutga8r[2, 6] + nutga8r[2, 7] + nutga8r[2, 8];
            utganiilber(cont, dateTimePicker2.Value, "dv8niit", dv8niit);
            double dv9niit = nutga9r[2, 3] + nutga9r[2, 4];
            utganiilber(cont, dateTimePicker2.Value, "dv9niit", dv9niit);
            double dv10niit = nutga10r[2, 4] + nutga10r[2, 5] + nutga10r[2, 6] + nutga10r[2, 7];
            utganiilber(cont, dateTimePicker2.Value, "dv10niit", dv10niit);
            double dv11niit = nutga11r[2, 4] + nutga11r[2, 5] + nutga11r[2, 6] + nutga11r[2, 7];
            utganiilber(cont, dateTimePicker2.Value, "dv11niit", dv11niit);
            double dv12niit = nutga12r[2, 4] + nutga12r[2, 5] + nutga12r[2, 6] + nutga12r[2, 7];
            utganiilber(cont, dateTimePicker2.Value, "dv12niit", dv12niit);
            double dv13niit = nutga13r[2, 4] + nutga13r[2, 5] + nutga13r[2, 6] + nutga13r[2, 7];
            utganiilber(cont, dateTimePicker2.Value, "dv13niit", dv13niit);

            double zuuh7niit = dv7niit + shbm7niit + dm7niit + mv7niit;
            utganiilber(cont, dateTimePicker2.Value, "zuuh7niit", zuuh7niit);

            double zuuh8niit = dv8niit + shbm8niit + dm8niit + mv8niit;
            utganiilber(cont, dateTimePicker2.Value, "zuuh8niit", zuuh8niit);

            double zuuh9niit = dv9niit + shbm9niit + dm9niit + mv9niit;
            utganiilber(cont, dateTimePicker2.Value, "zuuh9niit", zuuh9niit);
            double zuuh10niit = dv10niit + shbm10niit + dm10niit + mv10niit;
            utganiilber(cont, dateTimePicker2.Value, "zuuh10niit", zuuh10niit);
            double zuuh11niit = dv11niit + shbm11niit + dm11niit + mv11niit;
            utganiilber(cont, dateTimePicker2.Value, "zuuh11niit", zuuh11niit);
            double zuuh12niit = dv12niit + shbm12niit + dm12niit + mv12niit;
            utganiilber(cont, dateTimePicker2.Value, "zuuh12niit", zuuh12niit);
            double zuuh13niit = dv13niit + shbm13niit + dm13niit + mv13niit;
            utganiilber(cont, dateTimePicker2.Value, "zuuh13niit", zuuh13niit);

            double zuuhundurniit = zuuh7niit + zuuh8niit + zuuh9niit + zuuh10niit + zuuh11niit + zuuh12niit + zuuh13niit;
            utganiilber(cont, dateTimePicker2.Value, "zuuhundurniit", zuuhundurniit);
            // tungaah5 + tungaah6
            double tungaah56 = nutga9n[2, 12] + nutga12n[2, 8];
            utganiilber(cont, dateTimePicker2.Value, "tungaah56", tungaah56);

            double tg5niit = nutga7n[2, 5] + nutga7n[2, 7] + nutga8n[2, 4] + nutga8n[2, 6];
            utganiilber(cont, dateTimePicker2.Value, "tg5niit", tg5niit);

            double tg6niit = nutga7n[2, 6] + nutga7n[2, 8] + nutga8n[2, 5] + nutga8n[2, 7];
            utganiilber(cont, dateTimePicker2.Value, "tg6niit", tg6niit);

            double tg7niit = nutga9n[2, 7] + nutga10n[2, 4] + nutga9n[2, 8] + nutga10n[2, 2];
            utganiilber(cont, dateTimePicker2.Value, "tg7niit", tg7niit);

            double tg8niit = nutga11n[2, 7] + nutga12n[2, 4] + nutga11n[2, 4] + nutga12n[2, 3];
            utganiilber(cont, dateTimePicker2.Value, "tg8niit", tg8niit);

            double tg9niit = nutga14[2, 5] + nutga14[2, 4] + nutga13n[2, 3] + nutga14[2, 2] + nutga12r[2, 10] + nutga14[2, 7] + nutga13n[2, 5] + nutga14[2, 6];
            utganiilber(cont, dateTimePicker2.Value, "tg9niit", tg9niit);
            // TG undur niit
            double tgundurniit = tg5niit + tg6niit + tg7niit + tg8niit + tg9niit;
            utganiilber(cont, dateTimePicker2.Value, "tgundurniit", tgundurniit);
            // pen undur niit
            double niitpenundur = nutga7r[2, 12] + nutga2ro[2, 5] + nutga10r[2, 10] + nutga9r[2, 14] + nutga11r[2, 13] + nutga13r[2, 8];
            utganiilber(cont, dateTimePicker2.Value, "niitpenundur", niitpenundur);
            // sen undur niit
            double niitsenundur = nutga9r[2, 11] + nutga2ro[2, 6] + nutga1ro[2, 7] + nutga12r[2, 11] + nutga11r[2, 14];
            utganiilber(cont, dateTimePicker2.Value, "niitsenundur", niitsenundur);
            // bkn undur 
            double niitbknundur = nutga12n[2, 5] + nutga10n[2, 3] + nutga8r[2, 11] + nutga9r[2, 12] + nutga11n[2, 3] + nutga11n[2, 6] + nutga10n[2, 5] + nutga14[2, 3] + nutga13n[2, 4]; ;
            utganiilber(cont, dateTimePicker2.Value, "niitbknundur", niitbknundur);
            // bzk1 bzk2   tun3  pkn1 pkn2
            double niitbzkundur = nutga8n[2, 8] + nutga1ro[2, 6] + nutga2ro[2, 4] + nutga8n[2, 3] + nutga9n[2, 3];
            utganiilber(cont, dateTimePicker2.Value, "niitbzkundur", niitbzkundur);

            double t51b = nutga7r[2, 13] - nutga7n[2, 2] - nutga7n[2, 3] - nutga7n[2, 4] - nutga7n[2, 5] - nutga7n[2, 6] - nutga7n[2, 7] - nutga7n[2, 8] - nutga7n[2, 9] - nutga7n[2, 10] - nutga7n[2, 11];
            utganiilber(cont, dateTimePicker2.Value, "t51b", t51b);

            double t52b = nutga8r[2, 12] - nutga8n[2, 2] - nutga8n[2, 3] - nutga8n[2, 4] - nutga8n[2, 5] - nutga8n[2, 6] - nutga8n[2, 7] - nutga8n[2, 8] - nutga8n[2, 9];
            utganiilber(cont, dateTimePicker2.Value, "t52b", t52b);

            double t53b = nutga9r[2, 13] - nutga9n[2, 2] - nutga9n[2, 3] - nutga9n[2, 4] - nutga9n[2, 5] - nutga9n[2, 6] - nutga9n[2, 7] - nutga9n[2, 8] - nutga9n[2, 9] - nutga9n[2, 10] - nutga9n[2, 11] - nutga9n[2, 12];
            utganiilber(cont, dateTimePicker2.Value, "t53b", t53b);

            double t54b = nutga10r[2, 13] - nutga10n[2, 2] - nutga10n[2, 3] - nutga10n[2, 4] - nutga10n[2, 5] - nutga10n[2, 6] - nutga10n[2, 7] - nutga10n[2, 8];
            utganiilber(cont, dateTimePicker2.Value, "t54b", t54b);

            double t55b = nutga11r[2, 10] - nutga11n[2, 2] - nutga11n[2, 3] - nutga11n[2, 4] - nutga11n[2, 5] - nutga11n[2, 6] - nutga11n[2, 7] - nutga11n[2, 8] - nutga11n[2, 9] - nutga11n[2, 10];
            utganiilber(cont, dateTimePicker2.Value, "t55b", t55b);

            double t56b = nutga12r[2, 14] - nutga12n[2, 2] - nutga12n[2, 3] - nutga12n[2, 4] - nutga12n[2, 5] - nutga12n[2, 8];
            utganiilber(cont, dateTimePicker2.Value, "t56b", t56b);

            double t57b = nutga13r[2, 11] - nutga13n[2, 2] - nutga13n[2, 3] - nutga13n[2, 4] - nutga13n[2, 5] - nutga13n[2, 6];
            utganiilber(cont, dateTimePicker2.Value, "t57b", t57b);

            double t58b = nutga14[2, 18] - nutga14[2, 7] - nutga14[2, 3] - nutga14[2, 4] - nutga14[2, 5] - nutga14[2, 6];
            utganiilber(cont, dateTimePicker2.Value, "t58b", t58b);

            double niittrundur = t51b + t52b + t53b + t54b + t55b + t56b + t57b + t58b + nutga13r[2, 14] + nutga7r[2, 11];
            utganiilber(cont, dateTimePicker2.Value, "niittrundur", niittrundur);

            double niitgerelundur = nutga7n[2, 9] + nutga9n[2, 9] + nutga10n[2, 7] + nutga11n[2, 5] + nutga7n[2, 10] + nutga9n[2, 11] + nutga9n[2, 4] + nutga2ro[2, 3];
            utganiilber(cont, dateTimePicker2.Value, "niitgerelundur", niitgerelundur);
            // dund zuuh tuslah tonogololuud
            double zuuhundurtuslah = tungaah56 + nutga9n[2, 1] + nutga10n[2, 6] + nutga8n[2, 9] + nutga7n[2, 4] + nutga9n[2, 5] + nutga8n[2, 2] + nutga11r[2, 17] + nutga10r[2, 16] + nutga2ro[2, 7] + nutga7r[2, 2] + nutga1ro[2, 2]; 
            utganiilber(cont, dateTimePicker2.Value, "zuuhundurtuslah", zuuhundurtuslah);

            // dund zuuh niilber
            double zuuh1 = nzuuhdniit + nzuuhtuslahniit + nutgarusn044[2, 7] + nutgarusn045[2, 7] + niittrdund; ;
            utganiilber(cont, dateTimePicker2.Value, "zuuh1", zuuh1);
            // dund turbin niilber
            double turbin1 = nutgarusn046[2,8] + nutgarusn045[2,8] + nutgarusn046[2,6] + nutgarusn041[2,2] + nutgarusn043[2,5] + nutgarusn045[2,6] + nutgarusn046[2,5]+ nsenniit + npenniit  + ntgdniit + ndds1niit;
            utganiilber(cont, dateTimePicker2.Value, "turbin1", turbin1);

            double zuuh2 = zuuhundurniit + niittrundur + zuuhundurtuslah;
            utganiilber(cont, dateTimePicker2.Value, "zuuh2", zuuh2);

            double turbin2 = niitpenundur + niitsenundur + niitbzkundur + niitbknundur + tgundurniit+ nutga7n[2,9] + nutga9n[2,9] + nutga10n[2,7] + nutga11n[2,5]; 
            utganiilber(cont, dateTimePicker2.Value, "turbin2", turbin2);

            double ddshimi = nutgatulsh[2,2] + nutgatulsh[2,5] + nutgatulsh[2,8] + nutgatulsh[2,9];
            utganiilber(cont, dateTimePicker2.Value, "ddshimi", ddshimi);

            double ddstulsh = nutgarusn61[2, 4] + nutgarusn62[2, 2] + nutgarusn61[2, 9] + nutgarusn62[2, 3];
            utganiilber(cont, dateTimePicker2.Value, "ddstulsh", ddstulsh);

            double ddstsah = nutgarusn65[2, 4] + nutgarusn042[2, 6];
            utganiilber(cont, dateTimePicker2.Value, "ddstsah", ddstsah);
         
            double odshimi = nutga1ro[2,4] + nutga2ro[2,9];
            utganiilber(cont, dateTimePicker2.Value, "odshimi", odshimi);

            double odstulsh = nutga1ro[2,3] + nutga2ro[2,8] + nutga1ro[2,5] + nutga2ro[2,10] + nutga7n[2,2] + nutga9n[2,6]  + nutga12n[2,2] + nutga13n[2,2] + nutga7n[2,11] + nutga7n[2,3];
            utganiilber(cont, dateTimePicker2.Value, "odstulsh", odstulsh);

            double odstsah = nutga9n[2, 4] + nutga2ro[2, 3];
            utganiilber(cont, dateTimePicker2.Value, "odstsah", odstsah);

            double niitddsall = zuuh1 + turbin1 + ddshimi + ddstulsh + ddstsah + nutga203[2,3] + niitpekal + niitkontor;
            utganiilber(cont, dateTimePicker2.Value, "niitddsall", niitddsall);

            double niitunduruilbus = nutga12r[2, 13] + nutga10n[2, 8] + nutga13n[2, 6] + nutga9n[2, 11] + nutga7n[2, 10];
            double niitodsall = turbin2 + odshimi + odstsah + odstulsh + zuuh2 + nutgagru[2,10] + nutga203[2,2] + niitunduruilbus;
            utganiilber(cont, dateTimePicker2.Value, "niitodsall", niitodsall);

            double ddstooluur = nutgagru[2, 2] + nutgagru[2, 3] + nutgagru[2, 4] + nutgagru[2, 5] + nutgagru[2, 6] + nutgagru[2, 7] + nutgagru[2, 8] + nutgarusn62[2, 10] + nutga203[2, 3];
            utganiilber(cont, dateTimePicker2.Value, "ddstooluur", ddstooluur);

            double oaobo = nutga1ro[2, 9] + nutga1ro[2, 10] + nutga2ro[2, 2] + nutga2ro[2, 11] + nutga7r[2, 16] + nutga7r[2, 17] + nutga8r[2, 2] + nutga8r[2, 15] + nutga9r[2, 9] + nutga9r[2, 10] + nutga10r[2, 14] + nutga10r[2, 15] + nutga11r[2, 15] + nutga11r[2, 16] + nutga12r[2, 17] + nutga12r[2, 18] + nutga13r[2, 15];
            double odstooluur = oaobo + nutgarusn62[2,9] + nutgazaaltguraw[2,21] + nutgazaaltguraw[2,22] + nutgagru[2,10] + nutga203[2,2] + nutgagru[2,9];
            utganiilber(cont, dateTimePicker2.Value, "odstooluur", odstooluur);
            double dhtooluur = ddstooluur + odstooluur;
            utganiilber(cont, dateTimePicker2.Value, "dhtooluur", dhtooluur);

            double tonogtooluur = niitodsall + niitddsall;
            utganiilber(cont, dateTimePicker2.Value, "tonogtooluur", tonogtooluur);

            double zoruuniit = dhtooluur - tonogtooluur;
            utganiilberbr(cont, dateTimePicker2.Value, "zoruuniit", zoruuniit);

            double balansniit = Math.Round((dhtooluur - tonogtooluur) / dhtooluur * 100,3);
            utganiilberbr(cont, dateTimePicker2.Value, "balansniit", balansniit);

            connectionopen(cont);
            #region sar niit 
            SqlDataAdapter da = new SqlDataAdapter("select  *from  yalgawar1 ORDER BY id ASC", cont);
            DataSet ds = new DataSet();
            da.Fill(ds, "neg");
            table = ds.Tables[0];

            for (int i = 0; i < table.Rows.Count; i++)
            {
                utganemeh = 0;
            //    MessageBox.Show(table.Rows[i][38].ToString());
                if (Convert.ToInt16(table.Rows[i][38]) == 1)
                {



                    for (int j = 1; j < 10; j++)
                    {
                        try
                        {
                            utganemeh += Convert.ToDouble(table.Rows[i][j]);
                        }
                        catch { }
                    }

                    try  {

                        cmdutga = new SqlCommand("UPDATE yalgawar1 SET   dayniit=@t1  WHERE id='" + Convert.ToInt16(table.Rows[i][0]) + "'", cont);
                        cmdutga.Parameters.AddWithValue("@t1", utganemeh);
                        if (cmdutga.ExecuteNonQuery() == 0)
                        {
                            MessageBox.Show("daynemeh : " + i);
                        }
                    }  catch { }

                }

            }


            #endregion
            //   MessageBox.Show(nutgagru[2,2].ToString()  + "-"+ nutgagru[2, 3].ToString() + "-"+ nutgagru[2, 4].ToString() + "-");
              System.Diagnostics.Process.Start("горим.rdl");
           // MessageBox.Show("ok");

        }
        public void ugtaolgoh(SqlConnection con, string[,] hayag, DateTime odor, double[,] utga1, int too)
        {
            connectionopen(con);
            
         //   try {
                for (int i = 2; i <= too; i++)
                {

                    
                    SqlDataAdapter da = new SqlDataAdapter("select *from yalgawar1 where name = @t1", con);
                    da.SelectCommand.Parameters.AddWithValue("@t1", hayag[0, i]);
                    DataSet ds = new DataSet();
                    da.Fill(ds, hayag[0, i]);
 
                    SqlCommand cmd = new SqlCommand("UPDATE yalgawar2 SET   day" + odor.Day + "=@t1  WHERE name='" + hayag[0,i] + "'", con);
                    cmd.Parameters.AddWithValue("@t1", utga1[1,i]);
                    if (cmd.ExecuteNonQuery() == 0)
                    {
                    utga1[2, i] = 0;
                    
                    MessageBox.Show("1 yalgazar2" + hayag[0,i] + " - " + odor.Day.ToString());
                    }
                        try
                        {
                            DateTime ododshalgah = Convert.ToDateTime(ds.Tables[0].Rows[0][45]);
                       
                            if ((dateTimePicker2.Value.Day == ododshalgah.Day) && (dateTimePicker2.Value.Month == ododshalgah.Month) && (dateTimePicker2.Value.Year == ododshalgah.Year))
                            {
                                utga1[2, i] = Convert.ToDouble(ds.Tables[0].Rows[0][Convert.ToInt32(dateTimePicker2.Value.Day)]);
                       
                            }

                            else
                            {
                                if (utga1[1, i] > utga1[0, i])
                                {
                                    cmd = new SqlCommand("UPDATE yalgawar1 SET   day" + odor.Day + "=@t1  WHERE name='" + hayag[0, i] + "'", con);
                                    cmd.Parameters.AddWithValue("@t1", Math.Round((utga1[1, i] - utga1[0, i]) * Convert.ToUInt64(ds.Tables[0].Rows[0][35]), 3));
                                    if (cmd.ExecuteNonQuery() == 0)
                                    {
                                        MessageBox.Show("if yalgazar2" + hayag[0, i] + " - " + odor.Day.ToString());
                                    }

                                    utga1[2, i] = Math.Round((utga1[1, i] - utga1[0, i]) * Convert.ToUInt64(ds.Tables[0].Rows[0][35]), 3);

                                }
                                else
                                {

                                    cmd = new SqlCommand("UPDATE yalgawar1 SET   day" + odor.Day + "=@t1  WHERE name='" + hayag[0, i] + "'", con);
                                    cmd.Parameters.AddWithValue("@t1", 0);
                                    if (cmd.ExecuteNonQuery() == 0)
                                    {
                                        MessageBox.Show("else yalgazar2" + hayag[0, i] + " - " + odor.Day.ToString());
                                    }

                                    utga1[2, i] = 0;
                                }

                            }


                        }
                        catch
                             { }
           
                
                
           


            } 
          //  }  catch { }

          
        
        }
        public void utganiilber(SqlConnection con, DateTime odor, string ner, double utga)
        {
             try
             {
          
                connectionopen(con);

                SqlCommand cmd = new SqlCommand("UPDATE yalgawar1 SET   day" + odor.Day + "=@t1  WHERE name='" + ner + "'", con);
                cmd.Parameters.AddWithValue("@datetime", odor);
                    if (utga > 0)  
                        cmd.Parameters.AddWithValue("@t1", Math.Round(utga, 3));
                    else   
                        cmd.Parameters.AddWithValue("@t1", 0);
                   
                if (cmd.ExecuteNonQuery() == 0)
                {
                    MessageBox.Show("baazupdate : " + ner);
                }

                connectionclose(con);
            }

            catch { }
        }
        public void utganiilberbr(SqlConnection con, DateTime odor, string ner, double utga)
        {
            try
            {

                connectionopen(con);

                SqlCommand cmd = new SqlCommand("UPDATE yalgawar1 SET   day" + odor.Day + "=@t1  WHERE name='" + ner + "'", con);
                cmd.Parameters.AddWithValue("@datetime", odor);
                cmd.Parameters.AddWithValue("@t1", Math.Round(utga, 3));
                if (cmd.ExecuteNonQuery() == 0)
                {
                    MessageBox.Show("baazupdate : " + ner);
                }

                connectionclose(con);
            }

            catch { }
        }

        public double[,] ntailan(SqlConnection con, string hayag, DateTime odor, int too)
        {
            double[,] utga = new double[5, 30];
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select  *from  " + hayag + "  where ((select DATEPART(dd, tsag))=@udur and (select DATEPART(mm, tsag))=@sar and (select DATEPART(yy, tsag))=@jil) ORDER BY id ASC", con);
                da.SelectCommand.Parameters.AddWithValue("@udur", odor.AddDays(+1).Day);
                da.SelectCommand.Parameters.AddWithValue("@sar", odor.AddDays(+1).Month);
                da.SelectCommand.Parameters.AddWithValue("@jil", odor.AddDays(+1).Year);
                DataSet ds = new DataSet();
                da.Fill(ds, "neg");

                SqlDataAdapter da1 = new SqlDataAdapter("select  *from  " + hayag + "  where ((select DATEPART(dd, tsag))=@udur and (select DATEPART(mm, tsag))=@sar and (select DATEPART(yy, tsag))=@jil) ORDER BY id ASC", con);
                da1.SelectCommand.Parameters.AddWithValue("@udur", odor.Day);
                da1.SelectCommand.Parameters.AddWithValue("@sar", odor.Month);
                da1.SelectCommand.Parameters.AddWithValue("@jil", odor.Year);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1, "neg");

                for (int i = 2; i <= too; i++)
                {
                    utga[1, i] = Convert.ToDouble(ds.Tables[0].Rows[0][i]);
                    utga[0, i] = Convert.ToDouble(ds1.Tables[0].Rows[0][i]);

                }
                return utga;

            }
            catch
            { return utga; }

        }
        public double[,] ntailanfider(SqlConnection con, string hayag, DateTime odor, int too)
        {
            double[,] utga = new double[5, 30];
            try
            {

                SqlDataAdapter da = new SqlDataAdapter("select  *from  " + hayag + "  where ((select DATEPART(dd, Time_Stamp))=@udur and (select DATEPART(mm, Time_Stamp))=@sar and (select DATEPART(yy, Time_Stamp))=@jil) ORDER BY id ASC", con);
                da.SelectCommand.Parameters.AddWithValue("@udur", odor.AddDays(+1).Day);
                da.SelectCommand.Parameters.AddWithValue("@sar", odor.AddDays(+1).Month);
                da.SelectCommand.Parameters.AddWithValue("@jil", odor.AddDays(+1).Year);
                DataSet ds = new DataSet();
                da.Fill(ds, "neg");

                SqlDataAdapter da1 = new SqlDataAdapter("select  *from  " + hayag + "  where ((select DATEPART(dd, Time_Stamp))=@udur and (select DATEPART(mm, Time_Stamp))=@sar and (select DATEPART(yy, Time_Stamp))=@jil) ORDER BY id ASC", con);
                da1.SelectCommand.Parameters.AddWithValue("@udur", odor.Day);
                da1.SelectCommand.Parameters.AddWithValue("@sar", odor.Month);
                da1.SelectCommand.Parameters.AddWithValue("@jil", odor.Year);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1, "neg");


                for (int i = 2; i <= too; i++)
                {
                    utga[1, i] = Convert.ToDouble(ds.Tables[0].Rows[0][i]);
                    utga[0, i] = Convert.ToDouble(ds1.Tables[0].Rows[0][i]);

                }
                return utga;

            }
            catch
            { return utga; }
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
    }
}
