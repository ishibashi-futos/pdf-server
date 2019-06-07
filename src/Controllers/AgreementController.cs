using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace pdf_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgreementController : ControllerBase
    {
        public AgreementController()
        {
            // 
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<AgreementData>> Get()
        {
            //TODO: Service&Daoを使うようにする。
            var result = new List<AgreementData>();
            var agreementData = new AgreementData();
            agreementData.customerCode = "0001";
            agreementData.customerName = "yamada.taro";
            agreementData.customerName_Kana = "ヤマダ タロウ";
            var remarks = new Dictionary<int, string>();
            remarks.Add(1, "備考1");
            remarks.Add(2, "備考2");
            remarks.Add(3, "備考3");
            remarks.Add(4, "備考4");
            remarks.Add(5, "備考5");
            agreementData.remarks = remarks;
            agreementData.pictures = new int[4] {1, 2, 3, 5};
            result.Add(agreementData);
            return result;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

    public class AgreementData
    {
        public string customerCode {get; set;}
        public string customerName {get; set;}
        public string customerName_Kana {get; set;}
        public IDictionary<int, string> remarks {get; set;}
        public int[] pictures {get; set;}
    }
}
