using System.Collections.Generic;
using System;
using Lab3;
namespace Lab3

{
    public class Calculator
    {
        public int Calc(List<string> list)
        {
            Stack<int> StackDigit = new Stack<int>();
            Stack<string> StackOperation = new Stack<string>();
            for (int i = 0; i < list.Count; i++)
            {
                if (int.TryParse(list[i], out int a))
                {
                    StackDigit.Push(a);
                }
                else
                {
                    if (StackOperation.Length == 0)
                    {
                        StackOperation.Push(list[i]);
                    }
                    else
                    {
                        if (OperationForHelp.RankedOperation(list[i]) >
                              OperationForHelp.RankedOperation(StackOperation.Peek()))
                        {
                            StackOperation.Push(list[i]);
                        }
                        else
                        {
                            while (StackOperation.Length!= 0 && OperationForHelp.RankedOperation(list[i]) <=
                                OperationForHelp.RankedOperation(StackOperation.Peek()))
                            {
                                DefineOperation(StackOperation.Pop(), StackDigit);
                            }
                            StackOperation.Push(list[i]);
                        }
                    }
                }
            }
            LastSteps(StackDigit, StackOperation);
            return StackDigit.Pop();
        }

        public static void DefineOperation(string op, Stack<int> StackDigit)
        {
            if (op == "+")
                StackDigit.Push(StackDigit.Pop() + StackDigit.Pop());
            if (op == "-")
            {
                StackDigit.Push(-StackDigit.Pop() + StackDigit.Pop());
            }
            if (op == "/")
            {
                int a = StackDigit.Pop();
                int b = StackDigit.Pop();
                StackDigit.Push(b/a);
            }

            if (op == "*")
                StackDigit.Push(StackDigit.Pop() * StackDigit.Pop());
            if (op == "^")
            {
                
            }
        }

        public static void LastSteps(Stack<int> StackDigit, Stack<string> StackOperation)
        {
            while (StackOperation.Length != 0)
            {
                DefineOperation(StackOperation.Pop(), StackDigit);
            }
        }
    }
}