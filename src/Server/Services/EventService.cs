using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Epam.Password.Server.Model;
using Microsoft.Extensions.Logging;

namespace Epam.Password.Server.Services
{
    public class EventService
    {
        private readonly Db _db;
        private readonly ILogger _logger;

        public EventService(Db db, ILogger logger)
        {
            _db = db;
            _logger = logger;
        }

        public void LogInformationAboutChangingAccount(Account account, EventType eventType)
        {
            //TODO: save to db
            //TODO: log in _logger
            throw new NotImplementedException();
        }
    }
}
