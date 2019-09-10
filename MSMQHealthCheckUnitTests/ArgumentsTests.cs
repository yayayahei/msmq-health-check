using System;
using MSMQHealthCheck;
using MSMQHealthCheck.Cli;
using Xunit;

namespace MSMQHealthCheckUnitTests
{
    public class ArgumentsTests
    {
        [Fact]
        public void pathName_should_be_input_pathName()
        {
            var pathName = @".\private$\default";
            Arguments arguments = new Arguments(new[] {"--pathName",pathName});
            Assert.True(pathName.Equals(arguments.PathName));
        }
    }
}