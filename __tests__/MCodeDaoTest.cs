using System;
using System.IO;
using Xunit;
using pdf_server.Dao;

namespace Tests
{
    public class MCodeDaoTest
    {
        [Fact]
        public void Test1()
        {
            using (var dao = new MCodeDao())
            {
                dao.Truncate();
                using(var sr = new StreamReader(@"/opt/pdf-server/assets/CSV/MCode.csv"))
                {
                    while(!sr.EndOfStream)
                    {
                        var line = sr.ReadLine();
                        var values = line.Split(',');
                        var vo = new MCodeVo();
                        vo.companyCode = values[0];
                        vo.codeKbn = values[1];
                        vo.codeValue = values[2];
                        vo.codeDescription = values[3];
                        vo.codeDigits = Int32.Parse(values[4]);
                        vo.codeAttribute = values[5];
                        vo.codeContents = values[6];
                        vo.codeContentsOmission = values[7];
                        vo.sortKey = Int32.Parse(values[8]);
                        vo.allowDelete = values[9];
                        vo.registerDateTime = DateTime.Parse(values[10]);
                        vo.registerUserId = values[11];
                        vo.updateDateTime = DateTime.Parse(values[12]);
                        vo.updateUserId = values[13];
                        vo.isDelete = values[14];
                        vo.deleteDateTime = DateTime.Parse(values[15]);
                        vo.deleteUserId = values[16];
                        dao.insert(vo);
                    }
                }
            }
        }
    }
}
