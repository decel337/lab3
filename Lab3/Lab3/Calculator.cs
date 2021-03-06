using System.Collections.Generic;
using System;
namespace Lab3

{
    public class Calculator
    {
        public int Calc(List<string> list)
        {
            Stack<int> StackDigit = new Stack<int>();
            Stack<string> StackOperation = new Stack<string>();
            OperationsForHelp Helpcommands = new OperationsForHelp();
            for (int i = 0; i < list.Count; i++)
            {
                if (int.TryParse(list[i], out int a))
                {
                    StackDigit.Push(a);
                }
                else
                {
                    if (StackOperation.Length == 0 || list[i] == "(" || Helpcommands.RankedOperation(list[i]) >
                        Helpcommands.RankedOperation(StackOperation.Peek()))
                    {
                        StackOperation.Push(list[i]);
                    }
                    else
                    {
                        Helpcommands.DefaultSteps(StackDigit, StackOperation, list[i]);
                        if (list[i] != ")")
                        {
                            StackOperation.Push(list[i]);
                        }
                    }
                }

                if (i == list.Count - 1) 

                    Helpcommands.DefaultSteps(StackDigit, StackOperation, list[i]);
            }

            return StackDigit.Pop();
        }
    }
}