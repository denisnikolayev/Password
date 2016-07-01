using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Epam.Password.Server.Controllers
{
    [Route("api/[controller]")]
    public class QuestionsController : Controller
    {
        // GET: api/Questions
        //TODO implement a method that returns a collection of questions for registarion form
        [HttpGet]
        public IEnumerable<string> GetQuestions()
        {
            throw new NotImplementedException();
        }

        // POST api/Questions
        //TODO implement a method that saves data from registarion form
        [HttpPost]
        public void SaveAnswer([FromBody] string email, [FromBody] string question, [FromBody] string answer)
        {
            throw new NotImplementedException();
        }

        // GET api/Questions/User?email={email}
        //TODO implement a method that returns question for person
        [HttpGet("User")]
        public string GetQuestion([FromQuery] string email)
        {
            throw new NotImplementedException();
        }

        // POST api/Questions/User
        //TODO implement a method that verifies answer to the security question
        [HttpPost("User")]
        public bool VerifyAnswer([FromBody] string email, [FromBody] string answer)
        {
            throw new NotImplementedException();
        }
    }
}
