namespace FunctionMonkeyTestingDemo.Services
{
    internal class Calculator : ICalculator
    {
        public int Add(int valueOne, int valueTwo)
        {
            return valueOne + valueTwo;
        }
    }
}
