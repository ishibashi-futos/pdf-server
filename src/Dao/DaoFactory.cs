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
          builder.DataSource = "localhost";
          builder.UserID = "sa";
          builder.Password = "P@s5w0rd";
          builder.InitialCatalog = "MACARON_KS";
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
