using System;
using System.Collections.Generic;
using System.Text;

namespace algorithms.CodingProblems
{
    /// <summary>
    /// Given an encoded string, return it's decoded string.

   // The encoding rule is: k[encoded_string], where the encoded_string inside the square brackets is being repeated exactly k times.Note that k is guaranteed to be a positive integer.

   //You may assume that the input string is always valid; No extra white spaces, square brackets are well-formed, etc.

   //Furthermore, you may assume that the original data does not contain any digits and that digits are only for those repeat numbers, k.For example, there won't be input like 3a or 2[4].
    /// </summary>
    public class DecodeString
    {
        public static string Decode(string str)
        {
            var decodedString = "";
            Stack<int> integerstack = new Stack<int>();
            Stack<char> charstack = new Stack<char>();

            for (int i = 0; i < str.Length; i++)
            {
                int count = 0;
                if (char.IsDigit(str[i]))
                {

                    while (char.IsDigit(str[i]))
                    {
                        count = (count * 10) + str[i] - '0';
                        i++;
                    }

                    i--;
                    integerstack.Push(count);
                }
                else if(str[i] == ']')
                {
                    //pop until you get '['

                    decodedString = "";
                    var temp = "";

                    //first get last integer stack to repeat no of times
                    if (integerstack.Count > 0)
                    {
                        count = integerstack.Peek();
                        integerstack.Pop();
                    }


                    while (charstack.Count > 0 && charstack.Peek() != '[')
                    {
                      temp = charstack.Peek() + temp;
                      charstack.Pop();

                    }
                   

                    if (charstack.Count > 0 && charstack.Peek() == '[')
                    {
                        charstack.Pop();
                    }



                    // Repeating the popped string 'temo'
                    // count number of times.
                    for (int j = 0; j < count; j++)
                    {
                        decodedString = decodedString + temp;
                    }

                    // Push it in the character stack.
                    for (int j = 0; j < decodedString.Length; j++)
                    {
                        charstack.Push(decodedString[j]);
                    }

                    decodedString = "";
                }

                else if (str[i] == '[')
                {

                    charstack.Push(str[i]);
                }
                else
                {
                    charstack.Push(str[i]);
                }
                // string and return.
              

            }
            while (charstack.Count > 0)
            {
                decodedString = charstack.Peek() + decodedString;
                charstack.Pop();
            }


            return decodedString;
        }


        public static string DecodeStr(string s)
        {

            var result = string.Empty;

            var numStack = new Stack<int>();
            var charStack = new Stack<char>();
            int count = 0;

            for (int i = 0; i < s.Length; i++)
            {
                count = 0;
                if (s[i] <= '9' && (s[i] >= '0'))
                {
                    while (s[i] <= '9' && (s[i] >= '0'))
                    {

                        count = count * 10 + s[i] - '0';
                        i++;

                    }
                    numStack.Push(count);
                    i--;
                }

                else if (s[i] == ']')
                {

                    var temp = "";
                    result = "";

                    if (numStack.Count > 0)
                    {
                        count = numStack.Peek();
                        numStack.Pop();
                    }

                    while (charStack.Count > 0 && charStack.Peek() != '[')
                    {

                        temp = charStack.Peek() + temp;
                        charStack.Pop();

                    }

                    if (charStack.Peek() == '[')
                        charStack.Pop();


                    for (int j = 0; j < count; j++)
                    {
                        result = temp + result;
                    }

                    if (result.Length > 0)
                    {
                        for (int j = 0; j < result.Length; j++)
                        {
                            charStack.Push(result[j]);
                        }
                        result = "";
                    }


                }
                else
                {
                    charStack.Push(s[i]);
                }



            }

            while (charStack.Count > 0)
            {
                result = charStack.Peek() + result;
                charStack.Pop();
            }
            return result;
        }
    }
}


    

