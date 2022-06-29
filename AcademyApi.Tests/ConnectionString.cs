using System;

namespace AcademyApi.Tests
{
    public static class ConnectionString
    {
        public static string TestDatabase()
        {
            return $"Server={Environment.GetEnvironmentVariable("DB_HOST") ?? "localhost"},{Environment.GetEnvironmentVariable("DB_PORT") ?? "1433"};" +
                   $"User Id={Environment.GetEnvironmentVariable("DB_USERNAME") ?? "sa"};" +
                   $"Password={Environment.GetEnvironmentVariable("DB_PASSWORD") ?? "MyP@w0rd"};" +
                   $"Database={Environment.GetEnvironmentVariable("DB_DATABASE") ?? "core"}";
        }
    }
}
