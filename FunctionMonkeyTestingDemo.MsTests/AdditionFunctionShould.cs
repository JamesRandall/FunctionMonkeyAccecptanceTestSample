using System.Threading.Tasks;
using FunctionMonkey.Testing;
using FunctionMonkeyTestingDemo.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FunctionMonkeyTestingDemo.MsTests
{
    [TestClass]
    public class AdditionFunctionShould
    {
        private AcceptanceTestScaffold _acceptanceTestScaffold;

        [TestInitialize]
        public void Setup()
        {
            _acceptanceTestScaffold = new AcceptanceTestScaffold();
            _acceptanceTestScaffold.Setup(typeof(FunctionAppConfiguration).Assembly);
        }

        [TestMethod]
        public async Task ReturnTheSumOfTwoValues()
        {
            int result = await _acceptanceTestScaffold.Dispatcher.DispatchAsync(new AdditionCommand
            {
                ValueOne = 5,
                ValueTwo = 4
            });

            Assert.AreEqual(9, result);
        }
    }
}
