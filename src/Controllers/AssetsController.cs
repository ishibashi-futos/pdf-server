using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pdf_server.Services;
using pdf_server.Dao;

namespace pdf_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetsController : ControllerBase
    {
        private PDFService service;
        public AssetsController()
        {
            this.service = new PDFService(new TestRepository());
        }

        // GET api/values/5
        [HttpGet("{id}/pdf.pdf")]
        public ActionResult Get(string id, [FromQuery]int serial)
        {
            var bytes = this.service.GetPDFData(id, serial);
            return this.File(bytes, "application/octet-stream");
        }
    }

}
