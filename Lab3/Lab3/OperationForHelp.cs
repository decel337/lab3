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
            return ListOfToken;
        }
    }
}