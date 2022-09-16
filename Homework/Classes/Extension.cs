using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Homework.Classes
{
    static class Extension
    {
        public static LongNumber ToLongNumber (this string str)
        {
            if (str is null)
            {
                str = "";
            }
            return new LongNumber (str);
        }

        public static LongNumber ToLongNumber(this StringBuilder strBuild)
        {
            if (strBuild is null)
            {
                strBuild = new StringBuilder();
                strBuild.Append("");
            }
            return new LongNumber(Convert.ToString(strBuild));
        }
    }
}
