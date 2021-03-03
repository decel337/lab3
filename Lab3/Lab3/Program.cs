using System;
using System.Collections.Generic;
using Lab3;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = OperationForHelp.SplitOnToken(Console.ReadLine());
            foreach (var VARIABLE in list)
            {
                Console.WriteLine(VARIABLE);
            }
        }
    }
}
