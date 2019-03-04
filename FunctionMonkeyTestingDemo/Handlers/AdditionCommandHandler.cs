using System.Threading.Tasks;
using AzureFromTheTrenches.Commanding.Abstractions;
using FunctionMonkeyTestingDemo.Commands;
using FunctionMonkeyTestingDemo.Services;

namespace FunctionMonkeyTestingDemo.Handlers
{
    internal class AdditionCommandHandler : ICommandHandler<AdditionCommand, int>
    {
        private readonly ICalculator _calculator;

        public AdditionCommandHandler(ICalculator calculator)
        {
            _calculator = calculator;
        }

        public Task<int> ExecuteAsync(AdditionCommand command, int previousResult)
        {
            return Task.FromResult(_calculator.Add(command.ValueOne, command.ValueTwo));
        }
    }
}
