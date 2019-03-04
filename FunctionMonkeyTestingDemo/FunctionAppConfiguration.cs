using FunctionMonkey.Abstractions;
using FunctionMonkey.Abstractions.Builders;
using FunctionMonkeyTestingDemo.Commands;
using FunctionMonkeyTestingDemo.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FunctionMonkeyTestingDemo
{
    public class FunctionAppConfiguration : IFunctionAppConfiguration
    {
        public void Build(IFunctionHostBuilder builder)
        {
            builder
                .Setup((serviceCollection, commandRegistry) =>
                {
                    // register our dependencies
                    serviceCollection.AddTransient<ICalculator, Calculator>();

                    // register our commands and handlers
                    commandRegistry.Discover<FunctionAppConfiguration>();
                })
                .Functions(functions => functions
                    .HttpRoute("/calculator", route => route
                        .HttpFunction<AdditionCommand>("/add")
                    )
                )
                ;
        }
    }
}
