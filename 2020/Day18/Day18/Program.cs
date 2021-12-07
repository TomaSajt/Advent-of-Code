using System;
using System.IO;

namespace Day18
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("input.txt");
            string line = sr.ReadLine();
            Console.WriteLine(line);
            Console.ReadKey();
        }
    }

    class Expression
    {
        int? left = null;
        int? right = null;
        char? operation = null;
        public Expression(int num)
        {
            this.left = num;
        }
        public Expression(int left, int right, char operation)
        {
            this.left = left;
            this.right = right;
            this.operation = operation;
        }
    }
}
