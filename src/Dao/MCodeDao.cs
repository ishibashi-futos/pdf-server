using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Linq;

namespace pdf_server.Dao
{
    public class MCodeDao : DaoFactory
    {

        public MCodeDao()
        {
        }

        public void Truncate()
        {
            StringBuilder s = new StringBuilder();
            s.Append("TRUNCATE TABLE [dbo].[M_コード定義]");
            using(var sql = new SqlCommand(s.ToString(), this.conn))
            {
                sql.ExecuteNonQuery();
            }
        }

        public void insert(MCodeVo vo)
        {
            StringBuilder s = new StringBuilder();
            s.Append("INSERT INTO [dbo].[M_コード定義] VALUES(");
            s.Append("@companyCode,");
            s.Append("@codeKbn,");
            s.Append("@codeValue,");
            s.Append("@codeDescription,");
            s.Append("@codeDigits,");
            s.Append("@codeAttribute,");
            s.Append("@codeContents,");
            s.Append("@codeContentsOmission,");
            s.Append("@sortKey,");
            s.Append("@allowDelete,");
            s.Append("@registerDateTime,");
            s.Append("@registerUserId,");
            s.Append("@updateDateTime,");
            s.Append("@updateUserId,");
            s.Append("@isDelete,");
            s.Append("@deleteDateTime,");
            s.Append("@deleteUserId");
            s.Append(")");
            using(var tran = conn.BeginTransaction())
            using(var sql = new SqlCommand(s.ToString(), this.conn, tran))
            {
                sql.Parameters.AddWithValue("@companyCode", vo.companyCode);
                sql.Parameters.AddWithValue("@codeKbn", vo.codeKbn);
                sql.Parameters.AddWithValue("@codeValue", vo.codeValue);
                sql.Parameters.AddWithValue("@codeDescription", vo.codeDescription);
                sql.Parameters.AddWithValue("@codeDigits", vo.codeDigits);
                sql.Parameters.AddWithValue("@codeAttribute", vo.codeAttribute);
                sql.Parameters.AddWithValue("@codeContents", vo.codeContents);
                sql.Parameters.AddWithValue("@codeContentsOmission", vo.codeContentsOmission);
                sql.Parameters.AddWithValue("@sortKey", vo.sortKey);
                sql.Parameters.AddWithValue("@allowDelete", vo.allowDelete);
                sql.Parameters.AddWithValue("@registerDateTime", vo.registerDateTime);
                sql.Parameters.AddWithValue("@registerUserId", vo.registerUserId);
                sql.Parameters.AddWithValue("@updateDateTime", vo.updateDateTime);
                sql.Parameters.AddWithValue("@updateUserId", vo.updateUserId);
                sql.Parameters.AddWithValue("@isDelete", vo.isDelete);
                sql.Parameters.AddWithValue("@deleteDateTime", vo.deleteDateTime);
                sql.Parameters.AddWithValue("@deleteUserId", vo.deleteUserId);
                try
                {
                    sql.ExecuteNonQuery();
                    tran.Commit();
                }
                catch (Exception e)
                {
                    tran.Rollback();
                    Console.WriteLine(e.Message, sql.ToString());
                    throw;
                }
            }
        }
    }

    public class MCodeVo
    {
        public string companyCode {get;  set;}
        public string codeKbn {get; set;}
        public string codeValue {get; set;}
        public string codeDescription {get; set;}
        public int codeDigits {get; set;}
        public string codeAttribute {get; set;}
        public string codeContents {get; set;}
        public string codeContentsOmission {get; set;}
        public int sortKey {get; set;}
        public string allowDelete {get; set;}
        public DateTime registerDateTime {get; set;}
        public string registerUserId {get; set;}
        public DateTime updateDateTime {get; set;}
        public string updateUserId {get; set;}
        public string isDelete {get; set;}
        public DateTime deleteDateTime {get; set;}
        public string deleteUserId {get; set;}

    }
}
