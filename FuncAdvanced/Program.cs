using System;

namespace FuncAdvanced
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            int a = 10;
            Console.WriteLine(a);
            Inc(a);
            Console.WriteLine(a);

            int[] array = new int[] { 1, 2, 3, 4 };
            Console.WriteLine();
            foreach (int i in array)
                Console.Write($" {i}");
            Inc(array);
            Console.WriteLine();

            foreach (int i in array)
                Console.Write($" {i}");

            Reset(array);
            Console.WriteLine();

            foreach (int i in array)
                Console.Write($" {i}");

           
            a = 10;
          //  a = Inc2(a);
            IncRef(ref a);
            //a = 11

            ResetRef(ref array);
            Console.WriteLine();

            foreach (int i in array)
                Console.Write($" {i}");

            Console.ReadLine();

        }

        static void Inc(int v)
        {
            v++;
        }
        static int Inc2(int v)
        {
            v++;
            return v;
        }

        static void IncRef(ref int v)
        {
            v++;
        }

        static void Inc(int[] v)
        {
            for (int i = 0; i < v.Length; i++)
                v[i] = v[i] + 1;
        }

        static void Reset(int[] v)
        {
            v = new int[] { 0,0,0 };
        }

        static void ResetRef(ref int[] v)
        {
            v = new int[] { 0, 0, 0 };
        }
    }
}
