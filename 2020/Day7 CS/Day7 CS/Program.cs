using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Day7_CS
{
    class Program
    {
        static Dictionary<string, string[]> bagDict = new Dictionary<string, string[]>();
        static void Main(string[] args)
        {
            Stopwatch sw = Stopwatch.StartNew();
            var input = File.ReadAllText("input.txt");
            foreach (var str in input.Split("\r\n"))
            {
                int pos = str.IndexOf("bags");
                bagDict.Add(str.Substring(0, pos - 1), str.Substring(pos + 13).Replace(".", "").Replace(" bags", "").Replace(" bag", "").Split(", "));
            }
            Console.WriteLine("7.1: " + (bagDict.Where(item => lookForBag("1 " + item.Key)).Count() - 1));
            Console.WriteLine("7.2: " + (howManyBags("1 shiny gold") - 1));
            Console.WriteLine(sw.ElapsedMilliseconds);
            Console.ReadKey();
        }

        static bool lookForBag(string bagToLookInside)
        {
            if (bagToLookInside == "no other") return false;
            string name = bagToLookInside.Substring(2);
            if (name == "shiny gold") return true;
            return bagDict[name].Any(lookForBag);
        }

        static long howManyBags(string bag)
        {
            if (bag == "no other") return 0;
            string name = bag.Substring(2);
            int count = int.Parse(bag.Substring(0, 1));
            return count + count * bagDict[name].Select(howManyBags).Sum();

        }

        static HashSet<string> GeneráltRészGráf(string csúcs, Dictionary<string, List<Hova>> élnyilvántartás)
        {
            HashSet<string> gráf = new HashSet<string>() { csúcs };
            foreach (Hova él in élnyilvántartás[csúcs])
                gráf.UnionWith(GeneráltRészGráf(él.hova, élnyilvántartás));
            return gráf;
        }

        static int Részfaösszeg(string csúcs, Dictionary<string, List<Hova>> élnyilvántartás) // fa, mert az összefutó éleket többször kell számolni. (Unraveling...)
        {
            int sum = 1; // mert ez a táska már 1.
            foreach (Hova él in élnyilvántartás[csúcs])
                sum += él.db * Részfaösszeg(él.hova, élnyilvántartás);
            return sum;
        }

        class Hova
        {
            public int db;
            public string hova;

            public Hova(string hová, int szám)
            {
                this.hova = hová;
                this.db = szám;
            }
        }
        static Dictionary<string, List<Hova>> BeFelfele(string fájlnév)
        {
            Dictionary<string, List<Hova>> élnyilvántartás = new Dictionary<string, List<Hova>>();
            using (StreamReader f = new StreamReader(fájlnév))
            {
                string sor;
                string tartalmazó;
                string honnan;
                Hova él;
                while (!f.EndOfStream)
                {
                    sor = f.ReadLine();
                    tartalmazó = Regex.Match(sor, @"^(.*) bags contain").Groups[1].ToString();
                    foreach (Match tartalmazott in Regex.Matches(sor, @"(\d) (\w+ \w+) bag"))
                    {
                        honnan = tartalmazott.Groups[2].ToString();
                        él = new Hova(tartalmazó, int.Parse(tartalmazott.Groups[1].ToString()));
                        if (!élnyilvántartás.ContainsKey(él.hova))
                            élnyilvántartás.Add(él.hova, new List<Hova> { });
                        if (élnyilvántartás.ContainsKey(honnan))
                            élnyilvántartás[honnan].Add(él);
                        else
                            élnyilvántartás.Add(honnan, new List<Hova> { él });
                    }
                }
            }
            return élnyilvántartás;
        }
        static Dictionary<string, List<Hova>> BeLefele(string fájlnév)
        {
            Dictionary<string, List<Hova>> élnyilvántartás = new Dictionary<string, List<Hova>>();
            using (StreamReader f = new StreamReader(fájlnév))
            {
                string sor;
                string tartalmazó;
                while (!f.EndOfStream)
                {
                    sor = f.ReadLine();
                    tartalmazó = Regex.Match(sor, @"^(.*) bags contain").Groups[1].ToString();
                    if (Regex.Match(sor, @"^.*? bags contain no other bags.$").Success)
                        élnyilvántartás.Add(tartalmazó, new List<Hova> { });
                    else
                    {
                        Hova él;
                        foreach (Match tartalmazott in Regex.Matches(sor, @"(\d) (\w+ \w+) bag"))
                        {
                            él = new Hova(tartalmazott.Groups[2].ToString(), int.Parse(tartalmazott.Groups[1].ToString()));
                            if (élnyilvántartás.ContainsKey(tartalmazó))
                                élnyilvántartás[tartalmazó].Add(él);
                            else
                                élnyilvántartás.Add(tartalmazó, new List<Hova> { él });
                        }
                    }
                }
            }
            return élnyilvántartás;
        }


    }

}
