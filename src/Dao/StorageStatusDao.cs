﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Linq;

namespace pdf_server.Dao
{
    public class StorageStatusDao : DaoFactory, IStorageStatusDao
    {
        public StorageStatusDao()
        {
        }

        public List<StorageStatus> findAll()
        {
            var resultList  = new List<StorageStatus>();
            StringBuilder s = new StringBuilder();
            s.Append("SELECT * ");
            s.Append("  FROM [dbo].[Q_売買契約書保管状況_雛形]");
            using(SqlCommand sql = new SqlCommand(s.ToString(), this.conn))
            {
                using(var dr = sql.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        resultList.Add(this.reader(dr));
                    }
                }
            }
            return resultList;
        }

        public List<StorageStatus> findByCustomerCode(string customerCode)
        {
            var resultList  = new List<StorageStatus>();
            StringBuilder s = new StringBuilder();
            s.Append("SELECT * ");
            s.Append("  FROM [dbo].[Q_売買契約書保管状況_雛形]");
            s.Append(" WHERE 取引先コード = @customerCode");
            using(SqlCommand sql = new SqlCommand(s.ToString(), this.conn))
            {
                // パラメータをセット
                sql.Parameters.AddWithValue("@customerCode", customerCode);
                using(var dr = sql.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        resultList.Add(this.reader(dr));
                        return resultList;
                    }
                }
                return null;
            }
        }

        public List<StorageStatus> findByCustomerNameLike(string customerName)
        {
            var resultList  = new List<StorageStatus>();
            StringBuilder s = new StringBuilder();
            s.Append("SELECT * ");
            s.Append("  FROM [dbo].[Q_売買契約書保管状況_雛形]");
            s.Append(" WHERE 取引先名 LIKE @customerName");
            using(SqlCommand sql = new SqlCommand(s.ToString(), this.conn))
            {
                // パラメータをセット
                sql.Parameters.AddWithValue("@customerName", customerName + "%");
                using(var dr = sql.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        resultList.Add(this.reader(dr));
                    }
                }
            }
            return resultList;
        }

        public List<StorageStatus> findByCustomerNameKanaLike(string customerNameKana)
        {
            var resultList  = new List<StorageStatus>();
            StringBuilder s = new StringBuilder();
            s.Append("SELECT * ");
            s.Append("  FROM [dbo].[Q_売買契約書保管状況_雛形]");
            s.Append(" WHERE 取引先名_カナ LIKE @customerNameKana");
            using(SqlCommand sql = new SqlCommand(s.ToString(), this.conn))
            {
                // パラメータをセット
                sql.Parameters.AddWithValue("@customerNameKana", customerNameKana + "%");
                using(var dr = sql.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        resultList.Add(this.reader(dr));
                    }
                }
            }
            return resultList;
        }

        private StorageStatus reader(SqlDataReader dr)
        {
            var vo = new StorageStatus();
            vo.customerCode = dr.GetString(0);
            vo.customerName = dr.GetString(1);
            vo.customerName_Kana = dr.GetString(2);
            vo.customerKbn = dr.GetString(3);
            vo.codeContents = dr.GetString(4);
            vo.picturePath1 = dr.GetString(5);
            vo.remarks1 = dr.GetString(6);
            vo.picturePath2 = dr.GetString(7);
            vo.remarks2 = dr.GetString(8);
            vo.picturePath3 = dr.GetString(9);
            vo.remarks3 = dr.GetString(10);
            vo.picturePath4 = dr.GetString(11);
            vo.remarks4 = dr.GetString(12);
            vo.picturePath5 = dr.GetString(13);
            vo.remarks5 = dr.GetString(14);
            Console.WriteLine(vo.picturePath1);
            return vo;
        }
    }

    public class StorageStatus
    {
        public string customerCode {get; set;}
        public string customerName {get; set;}
        public string customerName_Kana {get; set;}
        public string customerKbn {get; set;}
        public string codeContents {get; set;}
        public string picturePath1 {get; set;}
        public string remarks1 {get; set;}
        public string picturePath2 {get; set;}
        public string remarks2 {get; set;}
        public string picturePath3 {get; set;}
        public string remarks3 {get; set;}
        public string picturePath4 {get; set;}
        public string remarks4 {get; set;}
        public string picturePath5 {get; set;}
        public string remarks5 {get; set;}
    }

    public interface IStorageStatusDao
    {
        List<StorageStatus> findAll();
        List<StorageStatus> findByCustomerCode(string customerCode);
        List<StorageStatus> findByCustomerNameLike(string customerName);
        List<StorageStatus> findByCustomerNameKanaLike(string customerNameKana);
    }
}
