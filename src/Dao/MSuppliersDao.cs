using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Linq;

namespace pdf_server.Dao
{
    public class MSuppliersDao : DaoFactory
    {

        public MSuppliersDao()
        {
        }

        public void Truncate()
        {
            StringBuilder s = new StringBuilder();
            s.Append("TRUNCATE TABLE [dbo].[M_取引先]");
            using(var sql = new SqlCommand(s.ToString(), this.conn))
            {
                sql.ExecuteNonQuery();
            }
        }

        public void insert(MSuppliers vo)
        {
            StringBuilder s = new StringBuilder();
            s.Append("INSERT INTO [dbo].[M_取引先] VALUES(");
            s.Append("@companyCode,");
            s.Append("@customerCode,");
            s.Append("@customerInternalCode,");
            s.Append("@customerAggregationCode,");
            s.Append("@higherCustomerCode,");
            s.Append("@customerClassification,");
            s.Append("@classificationCode,");
            s.Append("@tradingDivision,");
            s.Append("@customerName,");
            s.Append("@customerName_Kana,");
            s.Append("@tradingPartnersAlmost,");
            s.Append("@honorific,");
            s.Append("@postalCode,");
            s.Append("@address_1,");
            s.Append("@address_2,");
            s.Append("@phoneNumber,");
            s.Append("@faxNumber,");
            s.Append("@summary,");
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
                sql.Parameters.AddWithValue("@customerCode", vo.customerCode);
                sql.Parameters.AddWithValue("@customerInternalCode", vo.customerInternalCode);
                sql.Parameters.AddWithValue("@customerAggregationCode", vo.customerAggregationCode);
                sql.Parameters.AddWithValue("@higherCustomerCode", vo.higherCustomerCode);
                sql.Parameters.AddWithValue("@customerClassification", vo.customerClassification);
                sql.Parameters.AddWithValue("@classificationCode", vo.classificationCode);
                sql.Parameters.AddWithValue("@tradingDivision", vo.tradingDivision);
                sql.Parameters.AddWithValue("@customerName", vo.customerName);
                sql.Parameters.AddWithValue("@customerName_Kana", vo.customerName_Kana);
                sql.Parameters.AddWithValue("@tradingPartnersAlmost", vo.tradingPartnersAlmost);
                sql.Parameters.AddWithValue("@honorific", vo.honorific);
                sql.Parameters.AddWithValue("@postalCode", vo.postalCode);
                sql.Parameters.AddWithValue("@address_1", vo.address_1);
                sql.Parameters.AddWithValue("@address_2", vo.address_2);
                sql.Parameters.AddWithValue("@phoneNumber", vo.phoneNumber);
                sql.Parameters.AddWithValue("@faxNumber", vo.faxNumber);
                sql.Parameters.AddWithValue("@summary", vo.summary);
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

    public class MSuppliers
    {
        public string companyCode {get; set;}
        public string customerCode {get; set;}
        public string customerInternalCode {get; set;}
        public string customerAggregationCode {get; set;}
        public string higherCustomerCode {get; set;}
        public string customerClassification {get; set;}
        public string classificationCode {get; set;}
        public string tradingDivision {get; set;}
        public string customerName {get; set;}
        public string customerName_Kana {get; set;}
        public string tradingPartnersAlmost {get; set;}
        public string honorific {get; set;}
        public string postalCode {get; set;}
        public string address_1 {get; set;}
        public string address_2 {get; set;}
        public string phoneNumber {get; set;}
        public string faxNumber {get; set;}
        public string summary {get; set;}
        public DateTime registerDateTime {get; set;}
        public string registerUserId {get; set;}
        public DateTime updateDateTime {get; set;}
        public string updateUserId {get; set;}
        public string isDelete {get; set;}
        public DateTime deleteDateTime {get; set;}
        public string deleteUserId {get; set;}

    }
}
