using System;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Xunit;

namespace ConsoleDependencyInjection.Test
{
    public class ProgramTests
    {
        private readonly IServiceProvider _serviceProvider;

        public ProgramTests()
        {
            var serviceProvider = new Mock<IServiceProvider>();
            serviceProvider.Setup(x => x.GetService(typeof(IGreeter))).Returns(new ConsoleGreeter(Mock.Of<IFooService>()));

            // https://stackoverflow.com/questions/44336489/moq-iserviceprovider-iservicescope
            var serviceScope = new Mock<IServiceScope>();
            serviceScope.Setup(x => x.ServiceProvider).Returns(serviceProvider.Object);

            var serviceScopeFactory = new Mock<IServiceScopeFactory>();
            serviceScopeFactory.Setup(x => x.CreateScope()).Returns(serviceScope.Object);

            serviceProvider.Setup(x => x.GetService(typeof(IServiceScopeFactory))).Returns(serviceScopeFactory.Object);

            _serviceProvider = serviceProvider.Object;
        }

        [Fact]
        public void GreetWithDependencyInjection_ShouldReturnGreetingMessage()
        {
            var result = Program.GreetWithDependencyInjection(_serviceProvider);

            result.Should().Be("Hello World from the Console Greeter");
        }
    }
}