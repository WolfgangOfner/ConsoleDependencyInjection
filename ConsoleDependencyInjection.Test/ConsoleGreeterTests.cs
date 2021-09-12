using FluentAssertions;
using Moq;
using Xunit;

namespace ConsoleDependencyInjection.Test
{
    public class ConsoleGreeterTests
    {
        private readonly ConsoleGreeter _testee;

        public ConsoleGreeterTests()
        {
            _testee = new ConsoleGreeter(Mock.Of<IFooService>());
        }

        [Fact]
        public void Greet_ShouldReturnGreetingMessage()
        {
            var result = _testee.Greet();

            result.Should().Be("Hello World from the Console Greeter");
        }
    }
}