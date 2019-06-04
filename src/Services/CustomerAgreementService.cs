using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pdf_server.Dao;

namespace pdf_server.Services
{
    public class CustomerAgreementService
    {
        private CustomerAgreementDao customerAgreementDao;
        public CustomerAgreementService()
        {
            this.customerAgreementDao  = new CustomerAgreementDao();
        }

        public void insert()
        {
            
        }
    }
}
