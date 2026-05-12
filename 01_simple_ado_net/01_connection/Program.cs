using System.Data;
using Microsoft.Data.SqlClient;


const string connString = @"Server=.\SQLEXPRESS;Database=p42_insta_db;Trusted_Connection=True;Encrypt=False;";

#region Connection
//using SqlConnection conn = new SqlConnection(connString);

//try
//{
//    conn.Open();

//    Console.WriteLine("Connection OK");
//    Console.WriteLine(conn.ConnectionString);
//    Console.WriteLine(conn.State);
//    Console.WriteLine(conn.ServerVersion);

//    string query = @"CREATE TABLE roles(
//                        id int PRIMARY KEY IDENTITY(1,1) NOT NULL,
//                        title varchar(32) NOT NULL
//                    );";

//    SqlCommand cmd = new SqlCommand(query, conn);
//    cmd.ExecuteNonQuery();
//}
//catch (Exception ex)
//{
//    Console.WriteLine($"ERROR: {ex.Message}");
//}
//finally
//{
//    if (conn.State == System.Data.ConnectionState.Open)
//    {
//        conn.Close();
//        Console.WriteLine("Connection closed");
//    }
//}
#endregion


#region Command

// --- ExecuteNonQuery

//using SqlConnection conn = new SqlConnection(connString);

//try
//{
//    conn.Open();
//    Console.WriteLine("Connection OK");

//    string query = @"CREATE TABLE roles(
//                            id int PRIMARY KEY IDENTITY(1,1) NOT NULL,
//                            title varchar(32) NOT NULL
//                        );";

//    SqlCommand cmd = new SqlCommand()
//    {
//        Connection = conn,
//        CommandText = query,
//        CommandType = System.Data.CommandType.Text
//    };

//    cmd.ExecuteNonQuery();

//    conn.ChangeDatabase("p42_logbook_db");

//    cmd.CommandText = @"CREATE TABLE logs(
//                            id int PRIMARY KEY IDENTITY(1,1) NOT NULL,
//                            date datetime NOT NULL,
//                            message varchar(1024) NOT NULL
//                        );";
//    cmd.ExecuteNonQuery();

//}
//catch (Exception ex)
//{
//    Console.WriteLine($"ERROR: {ex.Message}");
//}
//finally
//{
//    if (conn.State == System.Data.ConnectionState.Open)
//    {
//        conn.Close();
//        Console.WriteLine("Connection closed");
//    }
//}



// --- ExecuteReader

//using SqlConnection conn = new SqlConnection(connString);

//try
//{
//    conn.Open();
//    Console.WriteLine("Connection OK");

//    string query = @"SELECT id, email, password FROM users;";

//    SqlCommand cmd = new SqlCommand(query, conn);

//    using (SqlDataReader reader = cmd.ExecuteReader())
//    {
//        Console.WriteLine($"{reader.GetName(0)}\t{reader.GetName(1)}\t{reader.GetName(2)}");

//        //while(reader.Read())
//        //{
//        //    int id = reader.GetFieldValue<int>(0);
//        //    string email = reader.GetFieldValue<string>(1);
//        //    string password = reader.GetFieldValue<string>(2);

//        //    Console.WriteLine($"{id}\t{email}\t{password}");
//        //}



//        DataTable dt = new DataTable();
//        dt.Load(reader);

//        foreach (DataRow row in dt.Rows)
//            Console.WriteLine($"{row["id"]}\t{row["email"]}\t{row["password"]}");
//    }
//}
//catch (Exception ex)
//{
//    Console.WriteLine($"ERROR: {ex.Message}");
//}
//finally
//{
//    if (conn.State == System.Data.ConnectionState.Open)
//    {
//        conn.Close();
//        Console.WriteLine("Connection closed");
//    }
//}



// --- ExecuteScalar

using SqlConnection conn = new SqlConnection(connString);

try
{
    conn.Open();
    Console.WriteLine("Connection OK");

    string query = @"SELECT MAX(id) FROM users;";

    SqlCommand cmd = new SqlCommand(query, conn);

    int maxId = (int)cmd.ExecuteScalar();

    Console.WriteLine($"MAX ID: {maxId}");

}
catch (Exception ex)
{
    Console.WriteLine($"ERROR: {ex.Message}");
}
finally
{
    if (conn.State == System.Data.ConnectionState.Open)
    {
        conn.Close();
        Console.WriteLine("Connection closed");
    }
}
#endregion
