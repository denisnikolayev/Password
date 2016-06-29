using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Epam.Password.Server.Model
{
    public class Event
    {
        public int Id { get; set; }

        [Required]
        public Account Account { get; set; }

        public DateTime EventDate { get; set; }

        public EventType EventType { get; set; }

        public bool IsSuccess { get; set; }

        //TODO: log some extended information, maybe ip adress or something else
        //maybe once we have to find hacker
    }


    public enum EventType
    {
        Register,
        Reset,
        Unlock,
        Send,
        Sms,
        InputAnswer
    }
}
