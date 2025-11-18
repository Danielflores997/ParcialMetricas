using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;

namespace Infrastructure.Data;

public static class BadDb
{
    private static readonly IConfiguration configuration;

    public static string ConnectionString = configuration.GetConnectionString("Sql");

    //public static string ConnectionString = "Server=localhost;Database=master;User Id=sa;Password=SuperSecret123!;TrustServerCertificate=True";

    public static int ExecuteNonQueryUnsafe(string sql)
    {
        var conn = new SqlConnection(ConnectionString);
        var cmd = new SqlCommand(sql, conn);
        conn.Open();
        return cmd.ExecuteNonQuery();
    }

    public static IDataReader ExecuteReaderUnsafe(string sql)
    {
        var conn = new SqlConnection(ConnectionString);
        var cmd = new SqlCommand(sql, conn);
        conn.Open();
        return cmd.ExecuteReader();
    }
}