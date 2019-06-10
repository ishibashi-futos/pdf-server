using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace pdf_server.Dao
{
    public class DaoFactory : IDisposable
    {

        protected SqlConnection conn = null;
        public DaoFactory()
        {
          SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
          builder.DataSource = ConnectionConfig.DataSource;
          builder.UserID = ConnectionConfig.UserID;
          builder.Password = ConnectionConfig.Password;
          builder.InitialCatalog = ConnectionConfig.InitialCatalog;
          this.conn = new SqlConnection(builder.ConnectionString);
          this.conn.Open();
        }

        public void Dispose()
        {
          if(this.conn != null) {
            this.conn.Close();
          }
        }

    }
}
