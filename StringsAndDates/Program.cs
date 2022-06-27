using System;
using System.Text;

namespace StringsAndDates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            string s1 = "";
            string s2 = "I am a string";
            string s3 = new string("i am a string");

            int a = 10;
            string s4 = $"I am an interpolated string {s1} {a}";
            a = 5;
            s4 = $"I am an interpolated string {s1} {a}";

            string s5 = string.Format("I am an interpolated string {0} {1}", s1, a);
            Console.WriteLine("I am an interpolated string {0} {1}", s1, a);
            string s6 = $@"i am a
                    verbatim string {s1}. everything
                    is a string inside: \n \t \  \\\\\ \\ \\ \\\";
            string s7 = "I am a standard \\string.\t pippo\n.";
            Console.WriteLine(s6);
            Console.WriteLine(s7);


            //Le stringhe sono oggetti immutabili
            string s8 = "i am a string";
            s8 = "i am a new string";
            s8 += "_extended";

            //string str = string.Empty;
            //for(int i = 0; i < 500000; i++)
            //{
            //    str += $" {i}";
            //}
            //Console.WriteLine(str);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 1000000; i++)
            {
                sb.Append($" {i}");
                
            }
            //Console.WriteLine(sb.ToString());


            string input = "The       quick brown fox jumps over the lazy dog";
            int pos = input.IndexOf("fox");
            Console.Write($"'fox' is inside '{input}' at position: {pos}");
            pos = input.IndexOf("pippo");
            Console.Write($"'pippo' is inside '{input}' at position: {pos}");       //-1

            // Write a program in C# Sharp to count a total number of alphabets, digits and special characters in a string
            Console.Write("Input a string:   ");
            input = Console.ReadLine();
           
            CountCharacterTypes(input,out int alpha, out int digit, out int special);
            Console.WriteLine($"The string '{input}' has {alpha} alphabetic chars, {digit} numeric chars, {special} special chars");

            string s = "10,0";
       
            if(decimal.TryParse(s,out decimal dv))
            {
                Console.WriteLine("Valore corretto: " + dv);
            }
            decimal d;
            try
            {
                d = decimal.Parse(s);
            }catch(ArgumentNullException e1)
            {
                Console.WriteLine("Hai inserito null");
                d = 0;
            }catch(FormatException e2)
            {
                Console.WriteLine("Formato stringa non corretto");

            }catch(OverflowException e3)
            {
                Console.WriteLine("Overflow");
                d = decimal.MaxValue;
            }
            

            Console.ReadLine();
        }

        static bool TryParse(string s, out decimal v)
        {
            v = 0;
            try
            {
                v = decimal.Parse(s);
                return true;
            }
           
            catch(Exception e3)
            {
                return false;
            }
        }
        private static void CountCharacterTypes(string input, out int alpha, out int digit, out int special)
        {
            alpha = 0;
            digit = 0;
            special = 0;

            for(int i = 0; i < input.Length; i++)
            {
                char c = input[i];

                //if (c >= 48 && c <= 57)   //[0-9]
                //    digit++;
                //else if (c >= 65 && c <= 90)   //[A-Z]
                //    alpha++;
                //else if (c >= 97 && c <= 122)  //[a-z]
                //    alpha++;
                //else
                //    special++;
                if (c >= '0' && c <= '9')   //[0-9]
                    digit++;
                else if (  (c >= 'A' && c <= 'Z')   ||   (c >= 'a' && c <= 'z'))   //[A-Z]
                    alpha++;
                else
                    special++;
            }
            
            //return new CountResult(.......);
        }
    }
}
