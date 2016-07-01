using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Epam.Password.Server.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        [HttpGet]
        public object GetInfo([FromQuery] string email)
        {
            throw new NotImplementedException();
        }

        [HttpGet("isLocked")]
        public bool IsLocked([FromQuery] string email)
        {
            throw new NotImplementedException();
        }

        [HttpPost("Unlock")]
        public bool Unlock([FromBody] string email)
        {
            throw new NotImplementedException();
        }

        [HttpPost("Reset")]
        public bool Reset([FromBody] string email, [FromBody] string password)
        {
            throw new NotImplementedException();
        }
    }
}
