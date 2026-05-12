


using Microsoft.Data.SqlClient;

const string connString = @"Server=.\SQLEXPRESS;Database=p42_insta_db;Trusted_Connection=True;Encrypt=False;";

string procQuery = @"
    CREATE PROCEDURE uspGetUserOf2000
    AS
    BEGIN
        SELECT id, email
        FROM users
        WHERE YEAR(birthday) = 2000;
    END
";

using SqlConnection conn = new SqlConnection(connString);

try
{
    conn.Open();

    Console.WriteLine("Connection OK");

    SqlCommand cmd = new SqlCommand(procQuery, conn);
    cmd.ExecuteNonQuery();


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
