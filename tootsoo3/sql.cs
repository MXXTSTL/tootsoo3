using System.Data;
using System.Data.SqlClient;

public static class SqlHelper
{
    public static SqlConnection[] connectionlist = new SqlConnection[100];

    private static readonly string mainConnectionString = @"Server=192.168.3.245;Database=config;User Id=hereglegch;Password=Passwd_123";

    public static void LoadConnections()
    {
        using (SqlConnection conconfig = new SqlConnection(mainConnectionString))
        {
            conconfig.Open();

            SqlDataAdapter daIPaddress = new SqlDataAdapter("SELECT * FROM IPaddress ORDER BY id ASC", conconfig);
            DataSet dsIPaddress = new DataSet();
            daIPaddress.Fill(dsIPaddress, "IPaddress");

            SqlDataAdapter dausers = new SqlDataAdapter("SELECT * FROM users ORDER BY id ASC", conconfig);
            DataSet dsusers = new DataSet();
            dausers.Fill(dsusers, "users");

            SqlDataAdapter dadatabasename = new SqlDataAdapter("SELECT * FROM databasename ORDER BY id ASC", conconfig);
            DataSet dsdatabasename = new DataSet();
            dadatabasename.Fill(dsdatabasename, "databasename");

            for (int i = 0; i < dsdatabasename.Tables[0].Rows.Count; i++)
            {
                int ipIndex, userIndex;

                bool isIpOk = int.TryParse(dsdatabasename.Tables[0].Rows[i][2].ToString(), out ipIndex);
                bool isUserOk = int.TryParse(dsdatabasename.Tables[0].Rows[i][3].ToString(), out userIndex);

                if (isIpOk && ipIndex >= 0 && ipIndex < dsIPaddress.Tables[0].Rows.Count &&
                    isUserOk && userIndex >= 0 && userIndex < dsusers.Tables[0].Rows.Count)
                {
                    string ipText = dsIPaddress.Tables[0].Rows[ipIndex][1].ToString();
                    string dbName = dsdatabasename.Tables[0].Rows[i][1].ToString();
                    string userText = dsusers.Tables[0].Rows[userIndex][1].ToString();
                    string userPass = dsusers.Tables[0].Rows[userIndex][2].ToString();

                    SqlConnection conn = new SqlConnection();
                    conn.ConnectionString = $"Server={ipText};Database={dbName};User Id={userText};Password={userPass};TrustServerCertificate=True;";
                    connectionlist[i] = conn;
                }
            }

            conconfig.Close();
        }
    }
}
