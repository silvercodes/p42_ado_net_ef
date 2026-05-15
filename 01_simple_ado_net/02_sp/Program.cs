
using System.Data;
using Microsoft.Data.SqlClient;

const string connString = @"Server=.\SQLEXPRESS;Database=p42_insta_db;Trusted_Connection=True;Encrypt=False;";




//string procQuery = @"
//    CREATE PROCEDURE uspGetUserOf2000
//    AS
//    BEGIN
//        SELECT id, email
//        FROM users
//        WHERE YEAR(birthday) = 2000;
//    END
//";

//using SqlConnection conn = new SqlConnection(connString);

//try
//{
//    conn.Open();

//    Console.WriteLine("Connection OK");

//    //SqlCommand cmd = new SqlCommand(procQuery, conn);
//    //cmd.ExecuteNonQuery();

//    SqlDataReader reader = GetProcReader("uspGetUserOf2000");
//    RenderResult(reader);
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





string procQuery = @"
    CREATE PROCEDURE uspGetUsersCountByEmailPattern
        @pattern nvarchar(50),
        @count int OUT
    AS
    BEGIN
        SET @count = (
            SELECT COUNT(email)
            FROM users
            WHERE email LIKE @pattern
        );
    END
";

using SqlConnection conn = new SqlConnection(connString);

try
{
    conn.Open();

    Console.WriteLine("Connection OK");

    //SqlCommand cmd = new SqlCommand(procQuery, conn);
    //cmd.ExecuteNonQuery();

    int result = CountByEmail("a%");
    Console.WriteLine($"Count = {result}");
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

int CountByEmail(string pattern)
{
    string procName = "uspGetUsersCountByEmailPattern";

    SqlCommand cmd = new SqlCommand(procName, conn)
    {
        CommandType = CommandType.StoredProcedure,
    };

    cmd.Parameters.Add(new SqlParameter()
    {
        ParameterName = "@pattern",
        SqlDbType = SqlDbType.NVarChar,
        Size = 50,
        Value = pattern,
    });

    SqlParameter countPrm = new SqlParameter()
    {
        ParameterName = "@count",
        SqlDbType = SqlDbType.Int,
        Direction = ParameterDirection.Output,
    };

    cmd.Parameters.Add(countPrm);

    cmd.ExecuteNonQuery();

    return (int)countPrm.Value;
}



SqlDataReader GetProcReader(string procName)
{
    SqlCommand cmd = new SqlCommand()
    {
        Connection = conn,
        CommandType = System.Data.CommandType.StoredProcedure,      // <<< !!!
        CommandText = procName
    };

    return cmd.ExecuteReader();
}

void RenderResult(SqlDataReader reader)
{
    DataTable dt = new DataTable();
    dt.Load(reader);

    int columnsCount = dt.Columns.Count;

    Console.Write($"#\t\t");
    foreach(DataColumn col in dt.Columns)
        Console.Write($"{col.ColumnName}\t\t");
    Console.WriteLine();

    for(int i = 0; i < dt.Rows.Count; ++i)
    {
        Console.Write($"{i + 1}\t\t");

        DataRow row = dt.Rows[i];

        for (int j = 0; j < columnsCount; j++)
        {
            Console.Write($"{row[j]}\t\t");
        }

        Console.WriteLine();
    }
    
}

