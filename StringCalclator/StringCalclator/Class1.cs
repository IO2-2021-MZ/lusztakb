using System;
using System.Collections.Generic;

namespace StringCalculator
{
    public class Calculator
    {
        public int Add(String input)
        {
            if (string.IsNullOrEmpty(input))
                return 0;

            List<String> sepList = new List<String>();
            sepList.Add(",");
            sepList.Add("\n");

            if (input.Length > 2)
            {
                if (input[0] == '/' && input[1] == '/' && input[3] == '\n')
                {
                    sepList.Add(input[2].ToString());
                    input = input.Substring(4, input.Length - 4);
                }
                else
                {
                    if (input.Length > 4)
                    {
                        if (input[0] == '/' && input[1] == '/' && input[2] == '[')
                        {

                            int i = 3;
                            while (input[i] != '\n')
                            {
                                string multiCharDelimeter = "";
                                while (input[i] != ']')
                                {
                                    multiCharDelimeter += input[i];
                                    i++;
                                }
                                sepList.Add(multiCharDelimeter);
                                i++;
                                if (input[i] == '[')
                                {
                                    i++;
                                }
                            }
                            input = input.Substring(1 + i, input.Length - (1 + i));
                        }
                    }
                }
            }

            string[] numbers = input.Split(sepList.ToArray(), StringSplitOptions.None);
            int sum = 0;
            foreach (string number in numbers)
            {
                int num = int.Parse(number);
                if (num < 0)
                {
                    throw new Exception("Negative number");
                }

                if (num > 1000)
                {
                    continue;
                }

                sum += num;
            }
            return sum;
        }

    }
}
