using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab3
{
    public class OperationsForHelp
    {
        private Dictionary<string, (int precedence, bool isLeftAssociative)> operators = 
            new Dictionary<string, (int precedence, bool isLeftAssociative)>()
            {
                { "+", (1, true)},
                { "-", (1, true)},
                { "/", (2, true)},
                { "*", (2, true)},
                { "#", (3, true)}, // unary minus
                { "^", (4, false)},
            };
        public List<string> SplitOnToken(string str)
        {
            string tempString = "";
            str = str.Replace(" ", "");
            List<string> listOfTokens = new List<string>();

            for (int i = 0; i < str.Length; i++)
            {
                string curChar = str[i].ToString();
                if (curChar == "(" || curChar == "[" || curChar == ")" || curChar == "]" || operators.ContainsKey(curChar))
                {
                    if (tempString != "")
                    {
                        listOfTokens.Add(tempString);
                    }
                    listOfTokens.Add(str[i].ToString());
                    tempString = "";
                }
                else if (Char.IsDigit(str[i]))
                {
                    tempString += str[i];
                }
                else
                {
                    throw new InvalidOperationException("UNAVAILABLE OPERATION");
                }
            }
            if(tempString != "")
            {
                listOfTokens.Add(tempString);
            }
            FixedInput(listOfTokens);
            return listOfTokens;
        }

        public void FixedInput(List<string> ListOfToken)
        {
            string[] operations = new string[operators.Count];
            operators.Keys.CopyTo(operations, 0);
            for (int i = 1; i < ListOfToken.Count; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    for (int k = 0; k < 4; k++)
                    {
                        if (ListOfToken[i-1] == operations[j] && ListOfToken[i] == operations[k])
                        {
                            throw new InvalidOperationException("UNAVAILABLE OPERATION");
                        }
                    }
                }
            }

            int count1 = 0;
            int count2 = 0;
            for (int i = 0; i < ListOfToken.Count; i++)
            {
                if (ListOfToken[i] == "(")
                    count1++;
                if (ListOfToken[i] == "[")
                    count2++;
                if (ListOfToken[i] == ")")
                    count1--;
                if (ListOfToken[i] == "]")
                    count2--;
                if (count1 < 0 && count2 < 0 || count1 > 0 && ListOfToken[i] == "[")
                    throw new InvalidOperationException("UNAVAILABLE OPERATION");
            }


            if (count1 != 0)
                throw new InvalidOperationException("UNAVAILABLE OPERATION");
        }

        public int RankedOperation(string op)
        {
            return !operators.ContainsKey(op) ? 0 : operators[op].precedence;
        }

        public bool IsLeftAssociative(string op)
        {
            return operators[op].isLeftAssociative;
        }

        public void DefaultSteps(Stack<float> StackDigit, Stack<string> StackOperation, string b)
        {
            while (StackOperation.Length != 0 && RankedOperation(b) <=
                RankedOperation(StackOperation.Peek()))
            {
                if (b == ")" && StackOperation.Peek() == "(" || b == "]" && StackOperation.Peek() == "[")
                {
                    DefineOperation(StackOperation.Pop(), StackDigit);
                    break;
                }
                DefineOperation(StackOperation.Pop(), StackDigit);
            }
        }

        public void DefineOperation(string op, Stack<float> StackDigit)
        {
            if (op == "+")
                StackDigit.Push(StackDigit.Pop() + StackDigit.Pop());
            else if (op == "-")
            {
                StackDigit.Push(-StackDigit.Pop() + StackDigit.Pop());
            }
            else if (op == "#")
            {
                StackDigit.Push(-StackDigit.Pop());
            }
            else if (op == "/")
            {
                float a = StackDigit.Pop();
                float b = StackDigit.Pop();
                StackDigit.Push(b / a);
            }

            else if (op == "*")
                StackDigit.Push(StackDigit.Pop() * StackDigit.Pop());
            else if (op == "^")
            {
                var a = StackDigit.Pop();
                var b = StackDigit.Pop();
                StackDigit.Push(Convert.ToSingle(Math.Pow(b, a)));
            }
        }
    }
}