using System;
using System.Collections.Generic;
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


        public Session FindSession(DateTime dateToCheck)
        {
            var sessions = _genericRepository.GetAll<Session>();
            var closestSession = GetAnyFutureSession(sessions, dateToCheck);
            
            var closestDifference = Difference(dateToCheck, closestSession.EndDate);

            foreach (Session sessionToCheck in sessions)
            {
                var differenceToCheck = Difference(dateToCheck, sessionToCheck.EndDate);

                if (0 <= differenceToCheck && differenceToCheck < closestDifference)
                {
                    closestSession = sessionToCheck;
                    closestDifference = differenceToCheck;
                }
            }
            return closestSession;
        }

        private Session GetAnyFutureSession(IEnumerable<Session> sessions, DateTime dateToCheck)
        {
            foreach (Session session in sessions)
            {
                if (Difference(dateToCheck, session.EndDate) > 0)
                {
                    return session;
                }
            }
            return sessions.FirstOrDefault();
        }

        private int Difference(DateTime dateToCheck, DateTime endDate)
        {
            return (int) (endDate - dateToCheck).TotalDays;

        }
    }
}