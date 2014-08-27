using System;
using System.Collections.Generic;
using System.Linq;
using NGL.Web.Data.Entities;
using NGL.Web.Data.Infrastructure;

namespace NGL.Web.Data.Filters
{
    public class SessionFilter : ISessionFilter
    {
        private readonly IGenericRepository _genericRepository;

        public SessionFilter(IGenericRepository genericRepository)
        {
            _genericRepository = genericRepository;
        }


        public Session FindSession(DateTime dateToCheck)
        {
            var sessions = _genericRepository.GetAll<Session>().ToList();
            var sessionToChecks = sessions as IList<Session> ?? sessions.ToList();
            var closestSession = GetAnyFutureSession(sessionToChecks, dateToCheck);

            if (closestSession == null)
                return null;

            var closestDifference = Difference(dateToCheck, closestSession.EndDate);

            foreach (Session sessionToCheck in sessionToChecks)
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
            var enumerable = sessions as IList<Session> ?? sessions.ToList();
            foreach (Session session in enumerable)
            {
                if (Difference(dateToCheck, session.EndDate) > 0)
                {
                    return session;
                }
            }
            return enumerable.FirstOrDefault();
        }

        private int Difference(DateTime dateToCheck, DateTime endDate)
        {
            return (int) (endDate - dateToCheck).TotalDays;

        }
    }
}