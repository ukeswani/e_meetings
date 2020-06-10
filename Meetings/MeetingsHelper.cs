
using System.Collections.Generic;
using System.Linq;

namespace Meetings
{
    public class MeetingsHelper
    {
        public static bool HasAClash(List<Meeting> meetings)
        {
            var meetingTimes = new List<MeetingTime>();

            foreach (var meeting in meetings)
            {
                meetingTimes.Add(new MeetingTime(meeting.Start, MeetingTimeType.Start, meeting.Identifier));
                meetingTimes.Add(new MeetingTime(meeting.End, MeetingTimeType.End, meeting.Identifier));
            }

            var meetingTimesOrderedByTime = meetingTimes.OrderBy(mt => mt.Time);

            MeetingTime seen = null;

            foreach (var meetingTime in meetingTimesOrderedByTime)
            {
                if (meetingTime.Type == MeetingTimeType.Start)
                {
                    if (seen != null)
                    {
                        return true;
                    }

                    seen = meetingTime;
                }
                else
                {
                    if (seen == null 
                        ||
                        meetingTime.Identifier != seen.Identifier)
                    {
                        return true;
                    }

                    seen = null;
                }
            }

            return false;
        }
    }
}