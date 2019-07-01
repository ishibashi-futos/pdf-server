using System;
using System.Data.SqlClient;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace pdf_server.Dao
{
    public static class ConnectionConfig
    {
        public static readonly string ConnectionString;

        static ConnectionConfig()
        {
            var configBuilder = new ConfigurationBuilder();
            configBuilder.SetBasePath(Directory.GetCurrentDirectory());
            configBuilder.AddJsonFile(@"appsettings.json");
            var config = configBuilder.Build();
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = config["connectionConfig:DataSource"];
            builder.UserID = config["connectionConfig:UserID"];
            builder.Password = config["connectionConfig:Password"];
            builder.InitialCatalog = config["connectionConfig:InitialCatalog"];
            ConnectionString = builder.ConnectionString;
            ConnectionTest();
        }

        private static void ConnectionTest()
        {
            try
            {
                using (var conn = new SqlConnection(ConnectionString))
                {

                }
            }
            catch (Exception e)
            {
                var writer = Console.Error;
                writer.WriteLine(e.Message);
            }
        }

    }
}
