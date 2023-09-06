using System.Collections;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace DataStructures
{

   
    public static class UtilityMethods
    {
        public static char? FirstNonRepeatedChar(string str) // Returns the first char in string that is not used more than once
        {
            var chars = new Dictionary<char, int>();
            str = str.ToLower();
            foreach (var c in str)
            {
                if (chars.ContainsKey(c))
                {
                    chars[c]++;
                    continue;
                }
                chars.Add(c, 1);
            }
            return chars.Keys.First(x => chars[x] == 1);
        }

        public static char? FirstRepeatedChar(string str) // Returns the first char in string that is used more than once
        {
            str = str.ToLower();
            var chars = new HashSet<char>();
            foreach (var c in str)
            {
                var notExists = chars.Add(c);
                if (notExists == false)
                {
                    return c;
                }
            }

            return null;
        }

        public static string DictionaryToString(Dictionary<char, int> dict)
        {
            return string.Join(" | ", dict.Select(x => $"{x.Key}: {x.Key}"));
        }
        public static string HashSetToString(HashSet<char> dict)
        {
            return string.Join(" | ", dict.Select(x => $"{x}"));
        }
        public static string HashSetToString(HashSet<int> dict)
        {
            return string.Join(" | ", dict.Select(x => $"{x}"));
        }
    }
}
