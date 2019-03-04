using System;
using System.Collections.Generic;
using System.Text;
using AzureFromTheTrenches.Commanding.Abstractions;

namespace FunctionMonkeyTestingDemo.Commands
{
    public class AdditionCommand : ICommand<int>
    {
        public int ValueOne { get; set; }

        public int ValueTwo { get; set; }
    }
}
