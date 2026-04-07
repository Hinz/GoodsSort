using System.Text;

namespace GameTemplate.Utils
{
    public static class NumberHelper
    {
        static readonly string[] suffixes =
        {
            "", "K", "M", "B", "T",
            "aa", "bb", "cc", "dd", "ee", "ff", "gg", "hh", "ii", "jj",
            "kk", "ll", "mm", "nn", "oo", "pp", "qq", "rr", "ss", "tt"
        };

        static readonly string[] cached;

        static NumberHelper()
        {
            cached = new string[1000];
            for (int i = 0; i < 1000; i++)
                cached[i] = i.ToString();
        }

        public static string ToStringScientific(float value)
        {
            return FormatNumber(value);
        }

        public static string ToStringScientific(int value)
        {
            return FormatNumber(value);
        }

        public static string FormatNumber(float value)
        {
            if (value < 1000f)
                return value < 1000 && value >= 0 ? cached[(int)value] : value.ToString("0");

            int suffixIndex = 0;
            while (value >= 1000f && suffixIndex < suffixes.Length - 1)
            {
                value /= 1000f;
                suffixIndex++;
            }

            var sb = new StringBuilder();
            sb.Append(value.ToString("0.##"));
            sb.Append(suffixes[suffixIndex]);
            return sb.ToString();
        }
    }
}
