using System.Collections.Generic;
using System;
namespace Lab3

{
    public class Calculator
    {
        public float Calc(List<string> list)
        {
            Stack<float> StackDigit = new Stack<float>();
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
                    //// handling unary minus
                    //if (list[i] == "-" && (i == 0 || list[i-1] == "("))
                    //{
                    //    int.TryParse(list[i + 1], out int negative);
                    //    StackDigit.Push(-negative);
                    //    i++;
                    //    continue;
                    //}

                    // handling unary minus
                    if(list[i] == "-" && (i == 0 || list[i - 1] == "("))
                    {
                        list[i] = "#";
                    }
                    if (StackOperation.Length == 0 || list[i] == "(" || Helpcommands.RankedOperation(list[i]) >
                        Helpcommands.RankedOperation(StackOperation.Peek())
                        || (Helpcommands.RankedOperation(list[i]) == Helpcommands.RankedOperation(StackOperation.Peek()) &&
                        !Helpcommands.IsLeftAssociative(list[i])))
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
            }
            while (StackOperation.Length != 0)
            {
                Helpcommands.DefineOperation(StackOperation.Pop(), StackDigit);
            }
            return StackDigit.Pop();
        }
    }
}