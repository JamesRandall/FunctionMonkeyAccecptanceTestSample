using System.Threading.Tasks;
using AzureFromTheTrenches.Commanding.Abstractions;
using FunctionMonkey.Testing;
using FunctionMonkeyTestingDemo.Commands;
using FunctionMonkeyTestingDemo.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using NSubstitute;
using Xunit;

namespace FunctionMonkeyTestingDemo.Tests
{
    public class AdditionCommandShouldIncludingDependencyReplacement : AbstractAcceptanceTest
    {
        public override void AfterBuild(IServiceCollection serviceCollection, ICommandRegistry commandRegistry)
        {
            base.AfterBuild(serviceCollection, commandRegistry);
            ICalculator calculator = Substitute.For<ICalculator>();
            calculator.Add(Arg.Any<int>(), Arg.Any<int>()).Returns(8);
            serviceCollection.Replace(new ServiceDescriptor(typeof(ICalculator), calculator));
        }

        [Fact]
        public async Task ReturnSubstitutedDependencyResult()
        {
            int result = await Dispatcher.DispatchAsync(new AdditionCommand
            {
                ValueOne = 2,
                ValueTwo = 2
            });

            Assert.Equal(8, result);
        }
    }
}
