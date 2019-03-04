using System.Threading.Tasks;
using FunctionMonkey.Testing;
using FunctionMonkeyTestingDemo.Commands;
using Xunit;

namespace FunctionMonkeyTestingDemo.Tests
{
    public abstract class CommonAcceptanceTest : AbstractAcceptanceTest
    {
        protected CommonAcceptanceTest()
        {
            AddEnvironmentVariables("./test.settings.json");
        }
    }

    public class AdditionCommandShouldWithEnvironmentVariables : CommonAcceptanceTest
    {
        [Fact]
        public async Task ReturnTheSumOfTwoValues()
        {
            int result = await Dispatcher.DispatchAsync(new AdditionCommand
            {
                ValueOne = 5,
                ValueTwo = 4
            });

            Assert.Equal(9, result);
        }
    }
}
