using _11.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _11.Helpers
{
    internal class Parser
    {
        private List<Monkey> monkeyList = new();

        public IEnumerable<Monkey> GetMonkeys(string[] lines)
        {
            //return Enumerable.Empty<Monkey>();
            var currentMonkey = -1;

            int getLastOfStrAsInt(string str)
            {
                var split = str.Split(' ').Where(s => !string.IsNullOrEmpty(s)).ToList();
                return int.Parse(split.Last());
            }

            for(var i = 0; i < lines.Length; i++)
            {
                var line = lines[i];

                if (line.StartsWith("Monkey"))
                {
                    currentMonkey++;
                    monkeyList.Add(new Monkey());
                    continue;
                }

                if (line.Contains("Starting"))
                {
                    var split = line.Replace(",", "").Split(' ').Where(s => !string.IsNullOrEmpty(s)).ToList();
                    var ints = split.Skip(2).Select(i => int.Parse(i)).ToList();
                    monkeyList[currentMonkey].ItemWorryLevels = ints;
                    continue;
                }

                if (line.Contains("Operation"))
                {
                    var split = line.Split(' ').Where(s => !string.IsNullOrEmpty(s)).ToList();
                    var operation = split.Skip(3).ToList();
                    var first = operation[0];
                    var op = operation[1];
                    var second = operation[2];

                    int mult(int x, int y) => x * y;
                    int add(int x, int y) => x + y;

                    if (first == "old" && second == "old")
                    {
                        monkeyList[currentMonkey].Operation = x => op == "*" ? mult(x, x) : add(x, x);
                    }
                    else if (first == "old" && second != "old")
                    {
                        var intSecond = int.Parse(second);
                        monkeyList[currentMonkey].Operation = x => op == "*" ? mult(x, intSecond) : add(x, intSecond);
                    }
                    else
                    {
                        var intFirst = int.Parse(second);
                        var intSecond = int.Parse(second);
                        monkeyList[currentMonkey].Operation = x => op == "*" ? mult(intFirst, intSecond) : add(intFirst, intSecond);
                    }

                    continue;
                }

                if (line.Contains("Test"))
                {
                    var divBy = getLastOfStrAsInt(line);
                    i++;
                    var ifTrue = getLastOfStrAsInt(lines[i]);
                    i++;
                    var ifFalse = getLastOfStrAsInt(lines[i]);

                    monkeyList[currentMonkey].GetMonkeyToThrowTo = x => x % divBy == 0 ? ifTrue : ifFalse;
                    continue;
                }

            }

            return monkeyList;
        }
    }
}
