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
          this.conn = new SqlConnection(ConnectionConfig.ConnectionString);
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
