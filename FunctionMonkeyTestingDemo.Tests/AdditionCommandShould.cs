using System.Threading.Tasks;
using FunctionMonkey.Testing;
using FunctionMonkeyTestingDemo.Commands;
using Xunit;

namespace FunctionMonkeyTestingDemo.Tests
{
    public class AdditionFunctionShould : AbstractAcceptanceTest
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
