using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
         
            string expression = "-5i^2+3^2+sin(pi/6)";
            Parse paser = new Parse(expression);
            paser.parseAndCalc();
            Console.WriteLine(paser.complexStack.Peek());
            Console.ReadLine();


        }
    }
}
