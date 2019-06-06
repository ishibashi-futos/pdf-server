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
        private IRepository repository;
        public PDFService(IRepository repository)
        {
            this.repository = repository;
        }

        public byte[] GetPDFData(string id, int serial)
        {
            // TODO: modelに合致するSerialのPathを取得するように変更する
            var filePath = this.repository.findById(id);
            using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                var bytes = new byte[fs.Length];
                fs.Read(bytes, 0, (int)fs.Length);
                return bytes;
            }
        }
    }

}
