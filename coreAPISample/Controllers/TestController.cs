using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coreAPISample.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace coreAPISample.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private IConfiguration _configuration;
        private IloggingProvider logger;

        public TestController(IConfiguration config, IloggingProvider log)
        {
            this._configuration = config;
            this.logger = log;
        }
        /// <summary>
        /// test method to check the service
        /// </summary>
        /// <returns>retun test if success</returns>
        [HttpGet]
        public ActionResult<string> Get()
        {
            return Ok("test v12:"+ _configuration["test"]);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id">int id, any number</param>
        /// <returns>id parameter with value:</returns>
        [Authorize]
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value:" + id.ToString() ;
        }

        

       
    }
}
