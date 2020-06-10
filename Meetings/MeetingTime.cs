using System;

namespace Meetings
{
    internal class MeetingTime
    {
        public DateTime Time { get; }

        public MeetingTimeType Type { get; }

        public Guid Identifier { get; }

        public MeetingTime(DateTime time, MeetingTimeType type, Guid identifier)
        {
            Time = time;
            Type = type;
            Identifier = identifier;
        }
    }
}