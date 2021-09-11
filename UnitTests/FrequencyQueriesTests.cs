using System;
using System.Collections.Generic;
using ConsoleApp1;
using Xunit;

namespace UnitTests
{
    public class FrequencyQueriesTests
    {
        [Fact]
        public void TestMethod1()
        {
            var result = FrequencyQueries.Execute(new List<List<int>>()
            {
                new List<int>(){ 3, 4},
                new List<int>(){ 2, 1003},
                new List<int>(){ 1, 16},
                new List<int>(){ 3, 1}
            });
            var expected = new List<int>() { 0, 1 };
            Assert.Equal(expected, result);
        }
    }
}
