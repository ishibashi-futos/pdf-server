using System;
using System.IO;
using System.Collections.Generic;
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

        [Fact]
        public void DaoTest()
        {
            var service = new PDFService(new StorageStatusDao());
            using (var fs = new FileStream(@"/opt/pdf-server/assets/README.pdf", FileMode.Open, FileAccess.Read))
            {
                var bytes = new byte[fs.Length];
                fs.Read(bytes, 0, (int)fs.Length);
                Assert.Equal(bytes, service.GetPDFData("115000", 1));
            }
        }

    }

    public class TestDao : IStorageStatusDao 
    {
        private StorageStatus status;
        public TestDao()
        {

        }

        public List<StorageStatus> findAll()
        {
            return new List<StorageStatus>();
        }

        public void SetStorageStatus(StorageStatus status)
        {
            this.status = status;
        }

        public List<StorageStatus> findByCustomerCode(string customerCode)
        {
            var list = new List<StorageStatus>();
            list.Add(status);
            return list;
        }

        public List<StorageStatus> findByCustomerNameLike(string customerName)
        {
            return new List<StorageStatus>();
        }
        public List<StorageStatus> findByCustomerNameKanaLike(string customerNameKana)
        {
            return new List<StorageStatus>();
        }
    }
}
