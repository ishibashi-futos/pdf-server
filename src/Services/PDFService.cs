using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using pdf_server.Dao;

namespace pdf_server.Services
{
    public class PDFService
    {
        private IStorageStatusDao repository;
        public PDFService(IStorageStatusDao repository)
        {
            this.repository = repository;
        }

        public byte[] GetPDFData(string id, int serial)
        {
            var status = this.repository.findByCustomerCode(id)[0];
            var filePath = "";
            switch (serial)
            {
                case 1:
                    filePath = status.picturePath1;
                    break;
                case 2:
                    filePath = status.picturePath2;
                    break;
                case 3:
                    filePath = status.picturePath3;
                    break;
                case 4:
                    filePath = status.picturePath4;
                    break;
                case 5:
                    filePath = status.picturePath5;
                    break;
            }
            if (filePath == "" || !File.Exists(filePath))
            {
                throw new FileNotFoundException(filePath);
            }
            using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                var bytes = new byte[fs.Length];
                fs.Read(bytes, 0, (int)fs.Length);
                return bytes;
            }
        }
    }

}
