using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
//using PeachApi.Models;

namespace PeachApi.Controllers {
    [ApiController]
    [Route ("[controller]")]
    public class PeachController : Controller {
        private readonly IWebHostEnvironment _hostingEnvironment;
        public PeachController (IWebHostEnvironment hostingEnvironment) {
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet ("list/{type}")]
        public ActionResult GetByType (string type) {
            string contentRootPath = _hostingEnvironment.ContentRootPath;
            string json = string.Empty;
            switch (type) {
                case "test":
                    json = System.IO.File.ReadAllText (contentRootPath + "/Assets/test_table.json");
                    break;
                case "prod":
                    json = System.IO.File.ReadAllText (contentRootPath + "/Assets/prod_table.json");
                    break;
                default:
                    throw new NotImplementedException ();
            }

            return Ok(json);
        }

        [HttpPut ("reg")]
        public IActionResult Put () {
            return NoContent ();
        }
    }
}