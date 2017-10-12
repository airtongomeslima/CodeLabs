using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomExtensions
{
    public static class StringExtension
    {
        //public static void AppendLine(this StringBuilder str, string newline)
        //{
        //    str.Append($"{newline}\r\n");
        //}

        public static void AppendLine(this StringBuilder str, string newline, int numofTabs = 0)
        {
            string tabs = "";
            for (int i = 0; i < numofTabs; i++)
            {
                tabs += "\t";
            }
            str.Append($"{tabs}{newline}\r\n");
        }
    }
}
