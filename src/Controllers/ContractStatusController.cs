using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using pdf_server.Services;
using pdf_server.Dao;

namespace pdf_server.Controllers
{
    [Route("api/contracts")]
    [ApiController]
    public class ContractStatusController : ControllerBase
    {

        // GET api/values/5
        [HttpGet]
        public ActionResult<IEnumerable<StorageStatus>> Get([FromQuery]string customerCode, [FromQuery]string customerName, [FromQuery]string customerNameKana)
        {
            try
            {
                using(var dao = new StorageStatusDao())
                {
                    var service = new StorageStatusService(dao);
                    var data = service.GetData(customerCode, customerName, customerNameKana);
                    return data;
                }
             }
            catch (Exception)
            {
                return NotFound();
            }
        }

    }

}
