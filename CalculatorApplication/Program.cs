using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApplication
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Calculator cal = new Calculator();

            cal.Add(3, 5);
            cal.Substract(3, 5);

            Console.ReadLine();
        }
    }
}
