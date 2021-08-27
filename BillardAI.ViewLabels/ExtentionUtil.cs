using System;
using System.Collections.Generic;
using System.Text;

namespace BillardAI.ViewLabels
{
    public static class ExtentionUtil
    {
        private static int Parse(string value)
        {
            int.TryParse(value, out var data);
            return data;
        }

        public static int ToClass(this string[] data)
        {
            if (data == null || data.Length == 0)
                return 0;
            int.TryParse(data[0], out var index);
            return index;
        }

        public static int ToX(this string[] data)
        {
            if (data == null || data.Length <= 1)
                return 0;

            return Parse(data[1]);
        }

        public static int ToY(this string[] data)
        {
            if (data == null || data.Length <= 2)
                return 0;

            return Parse(data[2]);
        }

        public static int ToW(this string[] data)
        {
            if (data == null || data.Length <= 3)
                return 0;

            return Parse(data[3]);
        }

        public static int ToH(this string[] data)
        {
            if (data == null || data.Length <= 4)
                return 0;

            return Parse(data[4]);
        }
    }
}
