using FluentAssertions;
using MSMQHealthCheck.Cli;
using MSMQHealthCheck.Extensions;
using Xunit;

namespace MSMQHealthCheckUnitTests
{
    public class OptionItemTest
    {
        [Fact]
        public void OptionsEnum_PathName_toString_should_be_pathName()
        {
            string pathName = OptionsEnum.PathName.ToString().ToCamelCase();
            pathName.Should().Be("pathName");
        }
    }
}