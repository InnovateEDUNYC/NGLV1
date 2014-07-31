using System;
using System.Linq;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;

namespace NGL.Web.Data.Filters
{
    public class SessionFilter
    {
        private readonly IGenericRepository _genericRepository;

        public SessionFilter(IGenericRepository genericRepository)
        {
            _genericRepository = genericRepository;
        }


        public Session FindSession(DateTime dateTime)
        {
            var sessions = _genericRepository.GetAll<Session>();
            foreach (Session session in sessions)
            {
               if (dateIsContainedIn(dateTime, session))
                   return session;
            }
            return sessions.FirstOrDefault();

        }

        private bool dateIsContainedIn(DateTime currentDate, Session session)
        {
            var dateIsInSession = true;
            if (currentDate < session.BeginDate)
                dateIsInSession = false;
            else if (currentDate > session.EndDate)
                dateIsInSession = false;

            return dateIsInSession;
        }
    }
}