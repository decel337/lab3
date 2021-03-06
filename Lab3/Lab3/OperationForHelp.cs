using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab3
{
    public class OperationForHelp
    {
        public static List<string> SplitOnToken(string str)
        {
            string TempString = "";
            str = str.Replace(" ", "");
            str += "-";
            List<string> ListOfToken = new List<string>();

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '*' || str[i] == '/' || str[i] == '+' || str[i] == '-' || str[i] == '(' ||
                    str[i] == ')' || str[i] == '^')
                {
                    if (TempString != "")
                        ListOfToken.Add(TempString);
                    ListOfToken.Add(str[i].ToString());
                    TempString = "";
                }

                else if (Char.IsDigit(str[i]))
                    TempString += str[i];
                else
                {
                    throw new InvalidOperationException("UNVAILABLE OPERATION");
                }
            }
            if(ListOfToken.Count != 0)
                ListOfToken.RemoveAt(ListOfToken.Count - 1);
            FixedInput(ListOfToken);
            return ListOfToken;
        }

        public static void FixedInput(List<string> ListOfToken)
        {
            string[] Operation = new string[]{"+", "-", "/", "*"};
            for (int i = 1; i < ListOfToken.Count; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    for (int k = 0; k < 4; k++)
                    {
                        if (ListOfToken[i-1] == Operation[j] && ListOfToken[i] == Operation[k])
                        {
                            throw new InvalidOperationException("UNVAILABLE OPERATION");
                        }
                    }
                }
            }

            int count = 0;
            for (int i = 0; i < ListOfToken.Count; i++)
            {
                if (ListOfToken[i] == "(")
                    count++;

                if (ListOfToken[i] == ")")
                    count--;

                if (count < 0)
                    throw new InvalidOperationException("UNVAILABLE OPERATION");
            }

            if (count != 0)
                throw new InvalidOperationException("UNVAILABLE OPERATION");
        }

        public int RankedOperation(string op)
        {
            int a = 0;
            if (op == "+" || op == "-" ) a = 1;
            if (op == "*" || op == "/") a = 2;
            if (op == "^") a = 3;
            return a;
        }
        public void DefaultSteps(Stack<int> StackDigit, Stack<string> StackOperation, string b)
        {
            while (StackOperation.Length != 0 && RankedOperation(b) <=
                RankedOperation(StackOperation.Peek()))
            {
                if (b == ")" && StackOperation.Peek() == "(")
                {
                    DefineOperation(StackOperation.Pop(), StackDigit);
                    break;
                }
                DefineOperation(StackOperation.Pop(), StackDigit);
            }
        }
        public static void DefineOperation(string op, Stack<int> StackDigit)


        {
            if (op == "+")
                StackDigit.Push(StackDigit.Pop() + StackDigit.Pop());
            if (op == "-")
                StackDigit.Push(-StackDigit.Pop() + StackDigit.Pop());
            if (op == "/")
            {
                var a = StackDigit.Pop();
                var b = StackDigit.Pop();
                StackDigit.Push(b / a);
            }

            if (op == "*")
                StackDigit.Push(StackDigit.Pop() * StackDigit.Pop());
            if (op == "^")
            {
                var a = StackDigit.Pop();
                var b = StackDigit.Pop();
                StackDigit.Push(Convert.ToInt32(Math.Pow(b, a)));
            }
        }
    }
}