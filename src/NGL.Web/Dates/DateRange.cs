using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NGL.Web.Dates
{
    public class DateRange
    {
        public DateRange(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
        }

        private DateTime Start { get; set; }
        private DateTime End { get; set; }

        public bool Includes(DateTime value)
        {
            return (Start <= value) && (value <= End);
        }
    }
}