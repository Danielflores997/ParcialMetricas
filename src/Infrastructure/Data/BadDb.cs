using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;

namespace Infrastructure.Data;

public static class BadDb
{
    public static string ConnectionString { get; private set; }

    public static void Initialize(IConfiguration configuration)
    {
        ConnectionString = configuration.GetConnectionString("Sql");
    }

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