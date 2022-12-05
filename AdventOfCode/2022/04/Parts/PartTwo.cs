using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _04.Models;

namespace _04.Parts
{
    public static class PartTwo
    {
        public static int Run(string[] assignments)
        {
            Console.WriteLine("===== PART TWO =====");

            var count = (from assignment in assignments
                         let sections = assignment.Split(',')
                         let firstSection = Shared.ParseRangeFromSection(sections[0])
                         let secondSection = Shared.ParseRangeFromSection(sections[1])
                         let anyOverlap = HasAnyOverlap(firstSection, secondSection) || HasAnyOverlap(secondSection, firstSection)
                         select anyOverlap
                     ).Count(a => a);

            return count;
        }

        static bool HasAnyOverlap(Range firstSection, Range secondSection)
        {
            return firstSection.Start.Value >= secondSection.Start.Value && firstSection.Start.Value <= secondSection.End.Value ||
                   firstSection.End.Value >= secondSection.Start.Value && firstSection.End.Value <= secondSection.End.Value;
        }
    }
}
