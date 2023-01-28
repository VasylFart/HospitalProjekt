using System;
using V_Project.Application;
using Xunit;

namespace V_Project.Tests
{
    public class DateOnlyTests
    {

        public static object[][] dateOfBirth =
            {
                new object[] {(1996,08,23), 26 },
                new object[] {(1994,03,28), 28 },
                new object[] {(1996,20,01), 27 }
            };

        [Theory]
        [MemberData(nameof(dateOfBirth))]
        public void CountAge_AddDateOfBirth_OldAreYou(DateOnly dateOfBirth, int age)
        {
            DateOnly dOnly = new DateOnly();

            var result = dOnly.CountAge(dateOfBirth); 

            Assert.Equal(age, result);

        }
    }
}
