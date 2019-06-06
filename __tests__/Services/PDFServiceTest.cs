using System;
using System.IO;
using Xunit;
using pdf_server.Dao;
using pdf_server.Services;

namespace Tests.Services
{
    public class PDFServiceTest
    {
        [Fact]
        public void FileNotFound()
        {
            // IStorageStatusを作成
            var testDao = new TestDao();
            var status = new StorageStatus();
            // 存在しないパスを指定
            status.picturePath1 = @"D:\test\test.pdf";
            testDao.SetStorageStatus(status);
            var service = new PDFService(testDao);
            var ex = Assert.Throws<FileNotFoundException>(() => 
            {
                service.GetPDFData("", 1);
            });
        }

        [Fact]
        public void  Pass()
        {
            // IStorageStatusを作成
            var testDao = new TestDao();
            var status = new StorageStatus();
            // 存在しないパスを指定
            status.picturePath1 = @"D:\test\test.pdf";
            // 存在するパスを指定
            var filePath = @"/opt/pdf-server/.gitignore";
            status.picturePath2 = @"/opt/pdf-server/.gitignore";
            testDao.SetStorageStatus(status);
            var service = new PDFService(testDao);
            // 成功するはず
            using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                var bytes = new byte[fs.Length];
                fs.Read(bytes, 0, (int)fs.Length);
                Assert.Equal(bytes, service.GetPDFData("", 2));
            }
        }

    }

    public class TestDao : IStorageStatusDao 
    {
        private StorageStatus status;
        public TestDao()
        {

        }

        public void SetStorageStatus(StorageStatus status)
        {
            this.status = status;
        }

        public StorageStatus findByCustomerCode(string customerCode)
        {
            return this.status;
        }
    }
}
