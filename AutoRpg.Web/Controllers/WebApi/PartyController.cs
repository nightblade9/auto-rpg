using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AutoRpg.Web.Controllers.WebApi
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PartyController : ControllerBase
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public PartyController(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
            var user = httpContextAccessor.HttpContext.User;

        }

        // GET: api/Party
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var currentUserId = this.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return new string[] { currentUserId };
        }
    }
}
