using System;
using System.Collections.Generic;
using Lab3;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new OperationsForHelp().SplitOnToken(Console.ReadLine());
            Calculator differentop = new Calculator();
            Console.WriteLine(differentop.Calc(list));
        }
    }
}
