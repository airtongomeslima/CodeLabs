using CreateProjectDDDUoW._0___Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CustomExtensions
{
    public static class Extension
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

        public static Guid GetEnumGuid(this Enum e)
        {
            Type type = e.GetType();

            MemberInfo[] memInfo = type.GetMember(e.ToString());

            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(EnumGuid), false);
                if (attrs != null && attrs.Length > 0)
                    return ((EnumGuid)attrs[0]).Guid;
            }

            throw new ArgumentException("Enum " + e.ToString() + " has no EnumGuid defined!");
        }
    }
}
