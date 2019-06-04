using System;
using System.IO;
using Xunit;
using pdf_server.Dao;

namespace Tests
{
    public class MSuppliersDaoTest
    {
        [Fact]
        public void Test1()
        {
            using (var dao = new MSuppliersDao())
            {
                dao.Truncate();
                using(var sr = new StreamReader(@"/opt/pdf-server/assets/CSV/MSuppliers.csv"))
                {
                    while(!sr.EndOfStream)
                    {
                        var line = sr.ReadLine();
                        var values = line.Split(',');
                        var vo = new MSuppliers();
                        vo.companyCode = values[0];
                        vo.customerCode = values[1];
                        vo.customerInternalCode = values[2];
                        vo.customerAggregationCode = values[3];
                        vo.higherCustomerCode = values[4];
                        vo.customerClassification = values[5];
                        vo.classificationCode = values[6];
                        vo.tradingDivision = values[7];
                        vo.customerName = values[8];
                        vo.customerName_Kana = values[9];
                        vo.tradingPartnersAlmost = values[10];
                        vo.honorific = values[11];
                        vo.postalCode = values[12];
                        vo.address_1 = values[13];
                        vo.address_2 = values[14];
                        vo.phoneNumber = values[15];
                        vo.faxNumber = values[16];
                        vo.summary = values[17];
                        vo.registerDateTime = DateTime.Parse(values[18]);
                        vo.registerUserId = values[19];
                        vo.updateDateTime = DateTime.Parse(values[20]);
                        vo.updateUserId = values[21];
                        vo.isDelete = values[22];
                        vo.deleteDateTime = DateTime.Parse(values[23]);
                        vo.deleteUserId = values[24];
                        dao.insert(vo);
                    }
                }
            }
        }
    }
}
