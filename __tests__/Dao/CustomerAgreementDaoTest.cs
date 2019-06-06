using System;
using Xunit;
using pdf_server.Dao;

namespace Tests.Dao
{
    public class CustomerAgreementDaoTest
    {
        [Fact]
        public void Test1()
        {
            using (var dao = new CustomerAgreementDao())
            {
                var list = dao.findToPrimaryKey("xxx", "yyy");
                foreach (CustomerAgreementVo vo in list)
                {
                    Console.WriteLine(vo.companyCode);
                }
            }
        }
    }
}
