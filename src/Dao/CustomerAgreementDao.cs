using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Linq;

namespace pdf_server.Dao
{
    public class CustomerAgreementDao : DaoFactory
    {

        public CustomerAgreementDao()
        {
        }

        public List<CustomerAgreementVo> findToPrimaryKey(string companyCode, string customerCode)
        {
            var resultList  = new List<CustomerAgreementVo>();
            StringBuilder s = new StringBuilder();
            s.Append("SELECT * FROM [dbo].[M_取引先契約書]");
            using(SqlCommand sql = new SqlCommand(s.ToString(), this.conn))
            {
                using(SqlDataReader dr = sql.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        var vo = new CustomerAgreementVo();
                        vo.companyCode = dr.GetString(0);
                        resultList.Add(vo);
                    }
                }
            }
            return resultList;
        }

        public void insert(CustomerAgreementVo vo)
        {
            StringBuilder s = new StringBuilder();
            s.Append("INSERT INTO [dbo].[M_取引先契約書] VALUES(");
            s.Append("@companyCode,");
            s.Append("@customerCode,");
            s.Append("@customerKbn,");
            s.Append("@picturePath1,");
            s.Append("@picturePath2,");
            s.Append("@picturePath3,");
            s.Append("@picturePath4,");
            s.Append("@picturePath5,");
            s.Append("@remarks1,");
            s.Append("@remarks2,");
            s.Append("@remarks3,");
            s.Append("@remarks4,");
            s.Append("@remarks5,");
            s.Append("@registerDateTime,");
            s.Append("@registerUserId,");
            s.Append("@update,");
            s.Append("@updateUserId,");
            s.Append("@isDelete,");
            s.Append("@delete,");
            s.Append("@deleteUserId");
            s.Append(")");
            using(var tran = conn.BeginTransaction())
            using(var sql = new SqlCommand(s.ToString(), this.conn))
            {
                sql.Parameters.AddWithValue("@companyCode", vo.companyCode);
                sql.Parameters.AddWithValue("@customerCode", vo.customerCode);
                sql.Parameters.AddWithValue("@customerKbn", vo.customerKbn);
                sql.Parameters.AddWithValue("@picturePath1", vo.picturePath1);
                sql.Parameters.AddWithValue("@picturePath2", vo.picturePath2);
                sql.Parameters.AddWithValue("@picturePath3", vo.picturePath3);
                sql.Parameters.AddWithValue("@picturePath4", vo.picturePath4);
                sql.Parameters.AddWithValue("@picturePath5", vo.picturePath5);
                sql.Parameters.AddWithValue("@remarks1", vo.remarks1);
                sql.Parameters.AddWithValue("@remarks2", vo.remarks2);
                sql.Parameters.AddWithValue("@remarks3", vo.remarks3);
                sql.Parameters.AddWithValue("@remarks4", vo.remarks4);
                sql.Parameters.AddWithValue("@remarks5", vo.remarks5);
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
                catch
                {
                    tran.Rollback();
                    throw;
                }
                finally
                {
                } 
            }
        }
    }

    public class CustomerAgreementVo
    {
        public string companyCode {get;  set;}
        public string customerCode {get; set;}
        public string customerKbn {get; set;}
        public string picturePath1 {get; set;}
        public string picturePath2 {get; set;}
        public string picturePath3 {get; set;}
        public string picturePath4 {get; set;}
        public string picturePath5 {get; set;}
        public string remarks1 {get; set;}
        public string remarks2 {get; set;}
        public string remarks3 {get; set;}
        public string remarks4 {get; set;}
        public string remarks5 {get; set;}
        public DateTime registerDateTime {get; set;}
        public string registerUserId {get; set;}
        public DateTime updateDateTime {get; set;}
        public string updateUserId {get; set;}
        public Boolean isDelete {get; set;}
        public DateTime deleteDateTime {get; set;}
        public string deleteUserId {get; set;}

    }
}
