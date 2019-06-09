using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using pdf_server.Dao;

namespace pdf_server.Services
{
    public class StorageStatusService
    {
        private IStorageStatusDao repository;
        public StorageStatusService(IStorageStatusDao repository)
        {
            this.repository = repository;
        }

        public List<StorageStatus> GetData(string customerCode, string customerName, string customerNameKana)
        {
            if (!string.IsNullOrEmpty(customerCode))
                return this.repository.findByCustomerCode(customerCode);
            if (!string.IsNullOrEmpty(customerName))
                return this.repository.findByCustomerNameLike(customerName);
            if (!string.IsNullOrEmpty(customerNameKana))
                return this.repository.findByCustomerNameLike(customerNameKana);
            return this.repository.findAll();
        }

    }

}
