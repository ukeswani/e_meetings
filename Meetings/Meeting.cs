using System;

namespace Meetings
{
    public class Meeting
    {
        public Meeting(DateTime start, DateTime end, Guid identifier)
        {
            Start = start;
            End = end;
            Identifier = identifier;
        }

        public DateTime Start { get;}

        public Guid Identifier { get; }

        public DateTime End { get; }
    }
}