using System.Collections.Generic;
using System.Linq;
using Epam.Password.Server.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Epam.Password.Server.Controllers
{
    [Route("api/[controller]")]
    public class InfoController : Controller
    {
        private readonly Db _db;

        public InfoController(Db db)
        {
            _db = db;
        }

      
        [HttpGet("{email}")]
        public Account Get(string email)
        {
            return _db.Accounts.AsNoTracking().FirstOrDefault(a=>a.Email == email);
        }
    }
}
