using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoRpg.Web.Controllers.WebApi
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PartyController : ControllerBase
    {
        private static Random random = new Random();

        // GET: api/Party
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value" + random.Next(1, 100), "value" + random.Next(1, 100) };
        }
    }
}
