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
                    throw new ArgumentException("UNVAILABLE OPERATION");
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
                            throw new ArgumentException("UNVAILABLE OPERATION");
                        }
                    }
                }
            }
        }
    }
}