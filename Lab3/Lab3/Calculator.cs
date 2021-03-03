using System.Collections.Generic;
using System;
using Lab3;
namespace Lab3

{
    public class Calculator
    {
        public static int Calc(List<string> list)
        {
            Stack<int> StackDigit = new Stack<int>();
            Stack<string> StackOperation = new Stack<string>();
            for (int i = 0; i < list.Count; i++)
            {
                if (int.TryParse(list[i], out int a))
                    StackDigit.Push(a);
                else
                {    
                    if(StackOperation.Length == 0)
                        StackOperation.Push(list[i]);
                    else
                    {
                        
                    }
                }
            }
            
        }
    }
}