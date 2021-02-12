using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MakeJobWell.DAL.Extensions
{
    public static class StringExtensions
    {
        public static bool IsInt(this string value)
        {
            if (string.IsNullOrEmpty(value)) return false;

            Int32 tmp;
            return Int32.TryParse(value, out tmp);
        }
        public static bool IsInt64(this string value)
        {
            if (string.IsNullOrEmpty(value)) return false;

            Int64 tmp;
            return Int64.TryParse(value, out tmp);
        }
        public static bool IsDateTime(this string value)
        {
            if (string.IsNullOrEmpty(value)) return false;

            DateTime tmp;
            return DateTime.TryParse(value, out tmp);
        }
        public static bool IsNumeric(this string value)
        {
            if (string.IsNullOrEmpty(value)) { return false; }

            decimal convert;
            return decimal.TryParse(value, out convert);
        }
        public static bool IsBoolean(this string value)
        {
            var val = value.ToLower().Trim();

            if (val == "1" || val == "0") return true;
            if (val == "true" || val == "false") return true;

            return false;
        }

        public static string RemoveRepeatedWhiteSpace(this string value)
        {
            if (value.IsNull()) return string.Empty;

            string[] tmp = value.ToString().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            StringBuilder sb = new StringBuilder();
            foreach (string word in tmp)
            {
                sb.Append(word.Replace("\r", "").Replace("\n", "").Replace("\t", "")/*.Replace("\\" , "")*/ + " ");
            }

            return sb.ToString().TrimEnd();
        }

        public static bool IsNotNullOrEmpty<T>(this IEnumerable<T> value)
        {
            return !value.IsNullOrEmpty();
        }
        public static bool IsNullOrEmpty(this string text)
        {
            return text == null || text.Trim().Length == 0;
        }


        public static bool IsNotNullOrEmpty(this string text)
        {
            return !IsNullOrEmpty(text);
        }

        public static bool IsNullOrEmpty<T>(this IEnumerable<T> value)
        {
            return value.IsNull() || !value.Any();
        }

        public static bool IsNull(this object objectToCall)
        {
            return objectToCall == null || Convert.IsDBNull(objectToCall);
        }

        public static bool IsNotNull(this object objectToCall)
        {
            return !(objectToCall == null || Convert.IsDBNull(objectToCall));
        }

        public static string UpperCaseToFirstLette(this string value)
        {
            if (value.Length > 0)
            {
                char[] arr = value.ToCharArray();
                arr[0] = char.ToUpper(arr[0]);
                for (int i = 1; i < arr.Length; i++)
                {
                    arr[i] = char.ToLower(arr[i]);
                }
                return new string(arr);
            }
            return value;
        }
    }
}
