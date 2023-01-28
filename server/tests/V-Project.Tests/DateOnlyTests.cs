using System;
using V_Project.Application;
using Xunit;

namespace V_Project.Tests
{
    public class DateOnlyTests
    {

        public static object[][] date =
        {
            new object[] {new DateOnly(1996, 08, 23), 26 },
            new object[] {new DateOnly(1994, 03, 27), 28 },
            new object[] {new DateOnly(1996, 01, 20), 27 }
        };

        [Theory]
        [MemberData(nameof(date))]
        public void CountAge_AddDateOfBirth_OldAreYou(DateOnly dateOfBirth, int age)
        {
            var result = dateOfBirth.CountAge();

            Assert.Equal(age, result);
        }
    }
}
