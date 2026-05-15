using System.Data;
using Microsoft.Data.SqlClient;

const string connString = @"Server=.\SQLEXPRESS;Database=p42_logbook_db;Trusted_Connection=True;Encrypt=False;";

//using SqlConnection conn = new SqlConnection(connString);

//// string title = "C++";

//string title = "my_title');INSERT INTO subjects (title) VALUES('ADMIN LOOSER!!!";

//try
//{
//    conn.Open();
//    Console.WriteLine("Connection OK");

//    string query = $@"INSERT INTO subjects (title) VALUES ('{title}')";
//    Console.WriteLine(query);

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








//using SqlConnection conn = new SqlConnection(connString);

//// string title = "C++";

//string title = "my_title');INSERT INTO subjects (title) VALUES('ADMIN LOOSER!!!";

//try
//{
//    conn.Open();
//    Console.WriteLine("Connection OK");

//    string query = $@"INSERT INTO subjects (title) VALUES (@title)";
//    Console.WriteLine(query);

//    SqlCommand cmd = new SqlCommand(query, conn);

//    SqlParameter prm = new SqlParameter("@title", title)
//    {
//        SqlDbType = SqlDbType.NVarChar,
//        Size = 256
//    };
//    cmd.Parameters.Add(prm);

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
















using SqlConnection conn = new SqlConnection(connString);

string title = "P42";
int status = 3;

try
{
    conn.Open();
    Console.WriteLine("Connection OK");

    string query = @"
            INSERT INTO groups (title, status)
            VALUES (@title, @status);
            SET @last_id = SCOPE_IDENTITY();
        ";

    SqlCommand cmd = new SqlCommand(query, conn);

    cmd.Parameters.Add(new SqlParameter("@title", title)
    {
        SqlDbType = SqlDbType.NVarChar,
        Size = 128,
    });

    cmd.Parameters.Add(new SqlParameter("@status", status)
    {
        SqlDbType = SqlDbType.TinyInt,
    });

    SqlParameter idPrm = new SqlParameter()
    {
        ParameterName = "@last_id",
        SqlDbType = SqlDbType.Int,
        Direction = ParameterDirection.Output,
    };
    cmd.Parameters.Add(idPrm);

    cmd.ExecuteNonQuery();

    Console.WriteLine($"last_id = {idPrm.Value}");
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
