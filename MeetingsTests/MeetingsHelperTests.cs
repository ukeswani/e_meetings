using Meetings;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace MeetingsTests
{
    [TestFixture]
    class MeetingsHelperTests
    {
        [TestCaseSource(nameof(TestCasesWithNoClashes))]
        public void GivenListOfNonClashingMeetings_WhenHasClashCalled_ReturnsFalse(List<Meeting> meetings)
        {
            var hasClash = MeetingsHelper.HasAClash(meetings);

            Assert.IsFalse(hasClash);
        }

        [TestCaseSource(nameof(TestCasesWithClashes))]
        public void GivenListOfClashingMeetings_WhenHasClashCalled_ReturnsTrue(List<Meeting> meetings)
        {
            var hasClash = MeetingsHelper.HasAClash(meetings);

            Assert.IsTrue(hasClash);
        }

        private static IEnumerable<List<Meeting>> TestCasesWithNoClashes
        {
            get
            {
                yield return new List<Meeting>
                {
                    new Meeting(
                        new DateTime(2020, 06, 09, 10, 0, 0),
                        new DateTime(2020, 06, 09, 11, 0, 0),
                        Guid.NewGuid()),
                    new Meeting(
                        new DateTime(2020, 06, 09, 13, 30, 0),
                        new DateTime(2020, 06, 09, 14, 30, 0),
                        Guid.NewGuid()),
                };

                yield return new List<Meeting>
                {
                    new Meeting(
                        new DateTime(2020, 06, 09, 10, 0, 0),
                        new DateTime(2020, 06, 09, 12, 0, 0),
                        Guid.NewGuid()),
                    new Meeting(
                        new DateTime(2020, 06, 09, 12, 0, 0),
                        new DateTime(2020, 06, 09, 16, 0, 0),
                        Guid.NewGuid()),
                };
            }
        }

        private static IEnumerable<List<Meeting>> TestCasesWithClashes
        {
            get
            {
                yield return new List<Meeting>
                {
                    new Meeting(
                        new DateTime(2020, 06, 09, 10, 0, 0),
                        new DateTime(2020, 06, 09, 11, 0, 0),
                        Guid.NewGuid()),
                    new Meeting(
                        new DateTime(2020, 06, 09, 10, 30, 0),
                        new DateTime(2020, 06, 09, 14, 30, 0),
                        Guid.NewGuid()),
                };

                yield return new List<Meeting>
                {
                    new Meeting(
                        new DateTime(2020, 06, 09, 10, 0, 0),
                        new DateTime(2021, 06, 09, 11, 0, 0),
                        Guid.NewGuid()),
                    new Meeting(
                        new DateTime(2020, 06, 19, 15, 0, 0),
                        new DateTime(2020, 06, 19, 16, 0, 0),
                        Guid.NewGuid()),
                };
            }
        }
    }
}
