using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Epam.Password.Server.Controllers
{
    [Route("api/[controller]")]
    public class PingController : Controller
    {
        [HttpPost]
        public string Post()
        {
            return "Pong";
        }
    }
}
