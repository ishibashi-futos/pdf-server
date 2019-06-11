using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace pdf_server.Dao
{
    public static class ConnectionConfig
    {
        public static readonly string DataSource;
        public static readonly string UserID;
        public static readonly string Password;
        public static readonly string InitialCatalog;

        static ConnectionConfig()
        {
            var configBuilder = new ConfigurationBuilder();
            configBuilder.SetBasePath(Directory.GetCurrentDirectory());
            configBuilder.AddJsonFile(@"appsettings.json");
            var config = configBuilder.Build();
            DataSource = config["connectionConfig:DataSource"];
            UserID = config["connectionConfig:UserID"];
            Password = config["connectionConfig:Password"];
            InitialCatalog = config["connectionConfig:InitialCatalog"];
        }

    }
}
