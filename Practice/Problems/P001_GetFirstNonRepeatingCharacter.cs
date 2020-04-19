using System;
using System.Collections.Generic;
using System.Text;

namespace Problems
{
    public class P001_GetFirstNonRepeatingCharacter
    {
        public char? NonRepeatingCharacter(String characters)
        {
            var dictionary = new Dictionary<char, int>();

            String alt_characters = "";
            foreach (char c in characters)
            {
                if (dictionary.ContainsKey(c))
                {
                    int value = dictionary[c];
                    dictionary[c] = ++value;
                }
                else
                {
                    dictionary.Add(c, 1);
                    alt_characters += c;
                }
            }
            StringBuilder sb = new StringBuilder();

            foreach (char c in alt_characters)
            {
                if (dictionary[c] == 1)
                {
                    return c;
                }
            }

            return null;
        }

        /* This is how tuples workds
         *  https://docs.microsoft.com/en-us/dotnet/csharp/tuples
        */
        public IEnumerable<(string value, char? expected)> TestVector()
        {
            //(int Id, string FirstName, string LastName) person = (1, "Bill", "Gates");

            yield return ("aabcb", 'c');
            yield return ("xxyz", 'y');
            yield return ("aabb", null);
        }
    }
}
