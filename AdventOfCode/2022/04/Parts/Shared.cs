using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Parts
{
    public class Shared
    {
        public static Range ParseRangeFromSection(string section)
        {
            var endpoints = section.Split('-');
            var start = int.Parse(endpoints[0]);
            var end = int.Parse(endpoints[1]);
            return start..end;
        }
    }
}
