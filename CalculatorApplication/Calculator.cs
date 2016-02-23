using AOPAttribute;
using System;

namespace CalculatorApplication
{
    [MonitorAOP]
    [LogAOP]
    public class Calculator : ContextBoundObject
    {
        public int Add(int x, int y)
        {
            return x + y;
        }
        public int Substract(int x, int y)
        {
            return x - y;
        }
    }
}
