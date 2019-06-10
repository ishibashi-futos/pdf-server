using System;
using System.IO;
using Xunit;
using pdf_server.Dao;

namespace Tests.Dao
{
    public class ConnectionConfigTest
    {
        [Fact]
        public void Test1()
        {
            Assert.Equal("localhost", ConnectionConfig.DataSource);
            Assert.Equal("sa", ConnectionConfig.UserID);
            Assert.Equal("P@s5w0rd", ConnectionConfig.Password);
            Assert.Equal("MACARON_KS", ConnectionConfig.InitialCatalog);
        }
    }
}
