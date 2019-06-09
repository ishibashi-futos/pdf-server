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
    [Route("api/[controller]")]
    [ApiController]
    public class AssetsController : ControllerBase
    {
        private PDFService service;
        public AssetsController()
        {
            this.service = new PDFService(new StorageStatusDao());
        }

        // GET api/values/5
        [HttpGet("{id}/pdf.pdf")]
        public ActionResult Get(string id, [FromQuery]int serial)
        {
            try
            {
                var bytes = this.service.GetPDFData(id, serial);
                return this.File(bytes, "application/octet-stream");
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }

}
