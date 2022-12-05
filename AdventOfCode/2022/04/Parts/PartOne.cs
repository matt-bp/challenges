using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _04.Models;

namespace _04.Parts
{
    public static class PartOne
    {
        public static void Run(string[] assignments)
        {
            Console.WriteLine("===== PART ONE =====");

            var count = (from assignment in assignments
                         let sections = assignment.Split(',')
                         let firstSection = Shared.ParseRangeFromSection(sections[0])
                         let secondSection = Shared.ParseRangeFromSection(sections[1])
                         let fullyContained = DoesFirstSectionFullyContainTheOther(firstSection, secondSection) || DoesFirstSectionFullyContainTheOther(secondSection, firstSection)
                         select fullyContained
                         ).Count(a => a);

            Console.WriteLine("The number of assignment pairs where one fully contains the other is: {0}", count);

        }

        static bool DoesFirstSectionFullyContainTheOther(Range firstSection, Range secondSection)
        {
            return firstSection.Start.Value <= secondSection.Start.Value && firstSection.End.Value >= secondSection.End.Value;
        }
    }
}
