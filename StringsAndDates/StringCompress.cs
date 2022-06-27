using System;
using System.Collections.Generic;
using System.Text;

namespace StringsAndDates
{
    public class StringCompress
    {
        public string Compress(string input)
        {
            if(input == null)
                throw new ArgumentNullException(nameof(input),"Input is null");

            if (input == "")
                return "";

            char lastChar = input[0];
            int count = 0;
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                if(c == lastChar)
                {
                    count++;
                }
                else
                {
                    sb.Append($"{lastChar}{count}");
                    lastChar = c;
                    count = 1;
                }
            }
            sb.Append($"{lastChar}{count}");

            return sb.ToString();
        }
    }
}
