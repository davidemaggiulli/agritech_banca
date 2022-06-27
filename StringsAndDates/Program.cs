using System;
using System.Diagnostics;
using System.Globalization;
using System.Text;

namespace StringsAndDates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region String Examples
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
           // input = Console.ReadLine();
           
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

            //Given a non-empty string, write a method that returns it in compressed format
            //kkkktttrrrrrrrrrr --> k4t3r10


            input = "        I am a string       ";
            string sbs = input.Substring(5);
            Console.WriteLine(sbs);

            sbs = input.Substring(5,3);
            Debug.WriteLine(sbs);
            Debug.WriteLine(input.ToUpper());
            Debug.WriteLine(input.ToLower());
            Debug.WriteLine(input.TrimStart());
            Debug.WriteLine(input.TrimEnd());
            Debug.WriteLine(input.Trim());
            Debug.WriteLine(input.Replace("  ","-"));
            Debug.WriteLine(input.Replace(' ','-'));

            //Write a C# Sharp program to convert the first character of each word of a given string to uppercase
            //i am a string -->I Am A String
            input = "i am  a     string";
            Debug.WriteLine($"'{input}' --> '{CamelCase(input)}'");

            Debug.WriteLine(input.StartsWith("i am"));
            Debug.WriteLine(input.StartsWith("pippo"));
            Debug.WriteLine(input.EndsWith("ing"));
            Debug.WriteLine(input.EndsWith("pippo"));
            Debug.WriteLine(input.Contains("pippo"));
            Debug.WriteLine(input.Contains("am"));
            Debug.WriteLine(input.Contains("a  "));


            //Esercizio 1
            //Scrivere una funzione booleana per determinare se una string è PALINDROMA
            //aabaa --> true
            bool isP1 = IsPalindrome("aabaa");
            //aabcc --> false
            //aabbbaa --> true
            //aabbbbaa --> true
            //aabbbbcc --> false
            bool isP2 = IsPalindrome("aabbbbcc");

            bool isP3= IsPalindrome("     a  abb        bbcc     ".Replace(" ",""));




            //Esercizio 2
            //Scrivere una funzione che data una stringa, ne restituisca la sua versione reverse
            //aabaa --> aabaa
            //aabAA --> AAbaa
            //casa --> asac

            #endregion

            #region DateTimes Examples
            DateTime d1 = new DateTime(2022, 12, 1);
            
            DateTime d2 = new DateTime(2022, 12, 1,10,12,59, DateTimeKind.Local);
            DateTime d3 = new DateTime(2022, 12, 1,10,12,59,100, DateTimeKind.Local);

            DateTime now = DateTime.Now;
            DateTime utcNow = DateTime.UtcNow;

            DateTime nowToUtc = now.ToUniversalTime();
            

            //Se in locale sono le 15, che ore sono a Londra?
            DateTime d4 = new DateTime(2022, 6, 27, 15, 0, 0, DateTimeKind.Local);
            DateTime d4Utc = d4.ToUniversalTime();   //W. Europe Standard Time


            //Che ore sono in UTC le 9 di mattina a Tokio?
            DateTime d5 = new DateTime(2022, 6, 27, 9, 0, 0);
            TimeZoneInfo tokyoTz = TimeZoneInfo.FindSystemTimeZoneById("Tokyo Standard Time");
            DateTime d5Utc = TimeZoneInfo.ConvertTimeToUtc(d5, tokyoTz);

            //Che ore sono in Canada se in Kuwait sono le 10PM ?
            DateTime d6 = new DateTime(2022, 6, 27, 22, 0, 0);
            var kuwaitTz = TimeZoneInfo.FindSystemTimeZoneById("Arab Standard Time");
            DateTime d6Utc = TimeZoneInfo.ConvertTimeToUtc(d6, kuwaitTz);
            var canadaTz = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
            DateTime d6Canada = TimeZoneInfo.ConvertTimeFromUtc(d6Utc, canadaTz);
            DateTime d6Canada1 = TimeZoneInfo.ConvertTime(d6, kuwaitTz, canadaTz);


            //Aggiungi 25 ore e 55 secondi alla data corrente
            now = DateTime.Now;
            DateTime result = now.AddHours(25).AddSeconds(55);

            TimeSpan ts = new TimeSpan(25, 0, 55);
            result = DateTime.Now.Add(ts);   //DateTime.Now + ts


            //Che ora era 10 ore, 2 minuti e 3 secondi fa?
            result = DateTime.Now.AddHours(-10).AddMinutes(-2).AddSeconds(-3);
            ts = new TimeSpan(10, 2, 3);
            var result1 = DateTime.Now.Subtract(ts);//DateTime.Now - ts

            //Quanta è passato da quando sono nato?
            DateTime birthDate = new DateTime(1987, 6, 27, 12, 0, 0, 0);
            var diff = DateTime.Now - birthDate;

            DateTime dt1 = new DateTime(2020, 12, 20);
            DateTime dt2 = new DateTime(2021, 12, 31, 5, 10, 20);
            Console.WriteLine(dt1 > dt2);
            Console.WriteLine(dt1 >= dt2);
            Console.WriteLine(dt1 < dt2);
            Console.WriteLine(dt1 <= dt2);
            Console.WriteLine(dt1 = dt2);
            Console.WriteLine(dt1 != dt2);

            //Stampa data ora corrente
            Debug.WriteLine(DateTime.Now.ToString());
            Debug.WriteLine(DateTime.Now.ToLongDateString());
            Debug.WriteLine(DateTime.Now.ToLongTimeString());
            Debug.WriteLine(DateTime.Now.ToShortTimeString());
            Debug.WriteLine(DateTime.Now.ToShortDateString());

            Debug.WriteLine(DateTime.Now.ToString("d"));
            Debug.WriteLine(DateTime.Now.ToString("D"));
            Debug.WriteLine(DateTime.Now.ToString("f"));
            Debug.WriteLine(DateTime.Now.ToString("F"));
            Debug.WriteLine(DateTime.Now.ToString("g"));
            Debug.WriteLine(DateTime.Now.ToString("G"));
            Debug.WriteLine(DateTime.Now.ToString("o"));
            Debug.WriteLine(DateTime.Now.ToString("O"));
            Debug.WriteLine(DateTime.UtcNow.ToString("o"));
            Debug.WriteLine(DateTime.UtcNow.ToString("O"));
            Debug.WriteLine(DateTime.Now.ToString("s"));
            Debug.WriteLine(DateTime.Now.ToString("T"));
            Debug.WriteLine(DateTime.Now.ToString("t"));
            Debug.WriteLine(DateTime.Now.ToString("u"));
            Debug.WriteLine(DateTime.Now.ToString("U"));

            //Stampare la data e l'ora corrente nel formato    Lun 1 gen 20 - 7|45|12
            string day = DateTime.Now.ToString("dddd").Substring(0, 1);
            Debug.WriteLine(DateTime.Now.ToString(@"ddd d MMM \'yy - H|m|s|fff"));

            var ukCulture = new CultureInfo("en-UK");
            var usCulture = new CultureInfo("en-US");
            var jpCulture = new CultureInfo("jp-JP");

            Debug.WriteLine(DateTime.Now.ToString("G", ukCulture));
            Debug.WriteLine(DateTime.Now.ToString("G", usCulture));
            Debug.WriteLine(DateTime.Now.ToString("G", jpCulture));

            Debug.WriteLine(DateTime.Now.ToString(@"ddd d MMM \'yy - H|m|s|fff", ukCulture));

            string dateS = "31/10/2020";
            try
            {
                DateTime convertedDate = DateTime.Parse(dateS);
            }
            catch (Exception)
            {

            }

            bool convResult = DateTime.TryParse(dateS, out DateTime convDate);

            dateS = "10/31/2020";
            convDate = DateTime.Parse(dateS,ukCulture);

            dateS = "31|10|2020";
            convDate = DateTime.ParseExact(dateS, "dd|MM|yyyy", CultureInfo.InvariantCulture);

            dateS = "sab|31|10|2020";
            convDate = DateTime.ParseExact(dateS, "ddd|dd|MM|yyyy", new CultureInfo("it-IT"));

            //foreach (CultureInfo ci in CultureInfo.GetCultures(CultureTypes.NeutralCultures))
            //{
            //    Console.Write("{0,-7}", ci.Name);
            //    Console.Write(" {0,-3}", ci.TwoLetterISOLanguageName);
            //    Console.Write(" {0,-3}", ci.ThreeLetterISOLanguageName);
            //    Console.Write(" {0,-3}", ci.ThreeLetterWindowsLanguageName);
            //    Console.Write(" {0,-40}", ci.DisplayName);
            //    Console.WriteLine(" {0,-40}", ci.EnglishName);
            //}


            //Write a C# Sharp program to calculate what day of the week is 40 days from this moment
            Debug.WriteLine($"{DateTime.Now.AddDays(40):dddd}");

            //Write C# Sharp Program to add one millisecond and 2.5 milliseconds to a given date value and display
            DateTime d7 = DateTime.Now;
            d7 = d7.AddMilliseconds(1000000).AddMilliseconds(2.5);

            Debug.WriteLine($"{d7:O}");


            //Quanti giorni sono passati dalla caduta del muro di Berlino?
            DateTime d8 = new DateTime(1989, 8, 19);
            var diff1 = DateTime.Now.Date - d8;
            Debug.WriteLine($"{diff1.TotalDays}");
            #endregion

            double numd = Math.PI;
            Debug.WriteLine(numd);
            Debug.WriteLine(numd);
            Debug.WriteLine(numd.ToString("F"));
            Debug.WriteLine(numd.ToString("F0"));
            Debug.WriteLine(numd.ToString("F1"));
            Debug.WriteLine(numd.ToString("F4"));
            Debug.WriteLine(numd.ToString("F9"));
            Debug.WriteLine(numd.ToString("F15"));
            Debug.WriteLine(numd.ToString("F25"));
            Debug.WriteLine(numd.ToString("F50"));

            numd = 1110121.3131198765;
            Debug.WriteLine(numd.ToString("E"));
            Debug.WriteLine(numd.ToString("E10"));
            Debug.WriteLine(numd.ToString("E20"));

            int numI = 123456;
            Debug.WriteLine(numI.ToString("D"));
            Debug.WriteLine(numI.ToString("D2"));
            Debug.WriteLine(numI.ToString("D3"));
            Debug.WriteLine(numI.ToString("D4"));
            Debug.WriteLine(numI.ToString("D10"));
            Debug.WriteLine(numI.ToString("D",ukCulture));

            numd = 100.4564;
            Debug.WriteLine(numd.ToString("C"));
            Debug.WriteLine(numd.ToString("C2"));
            Debug.WriteLine(numd.ToString("C4"));
            Debug.WriteLine(numd.ToString("C10"));
            Debug.WriteLine(numd.ToString("C10",ukCulture));
            Debug.WriteLine(numd.ToString("C10",usCulture));
            Debug.WriteLine(numd.ToString("C10",jpCulture));

            Debug.WriteLine(numd.ToString("G"));
            Debug.WriteLine(numd.ToString("G2"));
            Debug.WriteLine(numd.ToString("G4"));
            Debug.WriteLine(numd.ToString("G10"));
            Debug.WriteLine(numd.ToString("G10", ukCulture));
            Debug.WriteLine(numd.ToString("G10", usCulture));
            Debug.WriteLine(numd.ToString("G10", jpCulture));

            Debug.WriteLine(numd.ToString("N"));
            Debug.WriteLine(numd.ToString("N2"));
            Debug.WriteLine(numd.ToString("N4"));
            Debug.WriteLine(numd.ToString("N10"));
            Debug.WriteLine(numd.ToString("N10", ukCulture));
            Debug.WriteLine(numd.ToString("N10", usCulture));
            Debug.WriteLine(numd.ToString("N10", jpCulture));
            numd = 1234.56;
            Debug.WriteLine(numd.ToString("N10", usCulture));
            Debug.WriteLine(numd.ToString("N10"));

            numd = 1;
            Debug.WriteLine(numd.ToString("P"));
            numd = 0.5;
            Debug.WriteLine(numd.ToString("P"));
            Debug.WriteLine(numd.ToString("P2"));
            Debug.WriteLine(numd.ToString("P6"));
            Debug.WriteLine(numd.ToString("P6",ukCulture));
            Debug.WriteLine(numd.ToString("P6",usCulture));

            byte r = 255;
            byte g = 0;
            byte b = 0;
            Debug.WriteLine($"{r:X2}{g:X2}{b:X2}");

            numd = 12345.6789;
            Debug.WriteLine(numd.ToString("00.0"));
            Debug.WriteLine(numd.ToString("00.00"));
            Debug.WriteLine(numd.ToString("0000000.000"));
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


        static string CamelCase(string input)
        {
            if (string.IsNullOrEmpty(input))
                return "";

            var inputParts = input.Split(" ");
            StringBuilder sb = new StringBuilder();
            foreach(string part in inputParts)
            {
                if (string.IsNullOrEmpty(part))
                    sb.Append("");
                else
                {
                    sb.Append(part.Substring(0,1).ToUpper() + part.Substring(1) + " ");
                }
            }
            return sb.ToString().TrimEnd();
        }

        private static bool IsPalindrome(string input)
        {
            for(int i = 0; i < input.Length / 2; i++)
            {
                if (input[i] != input[input.Length - 1 - i])
                    return false;
            }
            return true;
        }
    }
}
