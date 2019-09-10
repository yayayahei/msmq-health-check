using System;
using FluentAssertions;
using MSMQHealthCheck.Extensions;
using Xunit;

namespace MSMQHealthCheckUnitTests.Extensions
{
    public class StringExtensionTest
    {
        [Fact]
        public void ToCamelCase_should_return_s_when_str_is_S()
        {
            "S".ToCamelCase().Should().Be("s");
        }
    }
}