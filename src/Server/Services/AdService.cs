using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Epam.Password.Server.Services
{
    public class AdService
    {
        private readonly EventService _eventService;

        public AdService(EventService eventService)
        {
            _eventService = eventService;
        }

        public void Unlock(string account)
        {
            //TODO: log action to eventService
            throw new NotImplementedException();
        }

        public void ResetPassword(string account)
        {
            //TODO: log action to eventService
            throw new NotImplementedException();
        }
    }
}
