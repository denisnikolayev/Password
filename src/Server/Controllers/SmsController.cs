using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Epam.Password.Server.Controllers
{
    [Route("api/[controller]")]
    public class SmsController : Controller
    {
        // POST api/Sms
        //TODO implement a method that saves phone number from registarion form
        [HttpPost]
        public void SavePhone([FromBody] string email, [FromBody] string phone)
        {
            throw new NotImplementedException();
        }

        // POST api/Sms/Send
        //TODO implement a method that sends message to phone. phone number need to take from DB
        [HttpPost("Send")]
        public string Send([FromBody] string email)
        {
            throw new NotImplementedException();
        }

        // POST api/Sms/Send
        //TODO implement a method that sends message to phone. if phone number is not known
        [HttpPost("Send")]
        public string Send([FromBody] string email, [FromBody] string phone)
        {
            throw new NotImplementedException();
        }

        // POST api/Sms/Resend
        //TODO implement a method that resends message to phone.
        [HttpPost("Resend")]
        public string Resend([FromBody] string email, [FromBody] string sessionId)
        {
            throw new NotImplementedException();
        }

        // POST api/Sms/Validate
        //TODO implement a method that validates code.
        [HttpPost("Validate")]
        public bool Validate([FromBody] string email, [FromBody] string sessionId, [FromBody] string code)
        {
            throw new NotImplementedException();
        }
    }
}
