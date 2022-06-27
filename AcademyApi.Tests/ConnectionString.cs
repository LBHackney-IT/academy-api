using System;

namespace AcademyApi.Tests
{
    public static class ConnectionString
    {
        public static string TestDatabase()
        {
            // "Server=localhost,1433;Database=testdb;User Id=sa;Password=MyP@w0rd;"
            return $"Server={Environment.GetEnvironmentVariable("DB_HOST") ?? "127.0.0.1"},{Environment.GetEnvironmentVariable("DB_PORT") ?? "1433"};" +
                   $"User Id={Environment.GetEnvironmentVariable("DB_USERNAME") ?? "sa"};" +
                   $"Password={Environment.GetEnvironmentVariable("DB_PASSWORD") ?? "MyP@w0rd"};" +
                   $"Database={Environment.GetEnvironmentVariable("DB_DATABASE") ?? "core"}";
        }
    }
}
