using System;
using System.Text;

namespace Framework.Utils
{
    public static class StringUtil
    {
        public static double ExtractNumberFromString(string message)
        {
            StringBuilder cost = new StringBuilder();

            foreach (char c in message)
            {
                if (char.IsDigit(c) || c == '.')
                {
                    cost.Append(c);
                }
            }

            return Math.Round(double.Parse(cost.ToString()), 2);
        }
    }
}
