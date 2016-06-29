using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Epam.Password.Server.Model
{
    public class Account
    {
        [Key]
        public string Email { get; set; }

        public VerificationType VerificationType { get; set; }


    }

    public enum VerificationType
    {
        Sms,
        Questions
    }
}
