using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day8
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt").Select(str => new KeyValuePair<string, int>(str.Substring(0, 3), int.Parse(str.Substring(4)))).ToArray();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i].Key != "jmp" && input[i].Key != "nop") continue;
                var modified = new KeyValuePair<string, int>[input.Length];
                input.CopyTo(modified, 0);
                modified[i] = modified[i].Key == "jmp" ? new KeyValuePair<string, int>("nop", modified[i].Value) : new KeyValuePair<string, int>("jmp", modified[i].Value);
                GameBoy gb = new GameBoy(modified);
                if (gb.run())
                {
                    Console.WriteLine(gb.getAcc());
                    Console.ReadKey();
                    return;
                }
            }
            Console.WriteLine("no solution found");
            Console.ReadKey();
        }
    }


    class GameBoy
    {
        private int nextLine;
        private int acc;

        private KeyValuePair<string, int>[] instructions;
        public GameBoy(KeyValuePair<string, int>[] instructions)
        {
            this.instructions = instructions;
        }
        public bool run()
        {
            nextLine = 0;
            acc = 0;
            HashSet<int> visitedLines = new HashSet<int>();
            while (true)
            {
                if (nextLine >= instructions.Length) return true;
                if (visitedLines.Contains(nextLine)) return false;
                visitedLines.Add(nextLine);
                var x = instructions[nextLine];
                switch (x.Key)
                {
                    case "jmp":
                        nextLine += x.Value;
                        break;
                    case "acc":
                        acc += x.Value;
                        nextLine++;
                        break;
                    case "nop":
                        nextLine++;
                        break;
                }
            }
        }
        public int getAcc()
        {
            return acc;
        }
    }
}
