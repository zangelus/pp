using System;
using System.Collections.Generic;
using System.Text;

namespace Problems
{
    public class P002_one_away_string
    {
        public bool AreOneAway(String s1, String s2)
        {
            if ((s1.Length - s2.Length >= 2) ||
                (s2.Length - s1.Length >= 2))
            {
                return false;
            }
            else if(s1.Length == s2.Length)
            {
                return AreEqualStringsOneAway(s1, s2);
            }
            else if (s1.Length > s2.Length)
            {
                return AreDiffLenghtStringOneAway(s1, s2);
            }
            else
            {
                return AreDiffLenghtStringOneAway(s2, s1);
            }
       }

        private bool AreDiffLenghtStringOneAway(string larger, string shorter)
        {
            char[] larger_array = larger.ToCharArray();
            char[] shorter_array = shorter.ToCharArray();

            int padding = 0;
            for (int i = 0; i < shorter.Length;)
            {
                if (shorter_array[i] != larger_array[i + padding])
                {
                    padding++;
                    if (padding > 1) return false;
                }
                else
                {
                    i++;
                }
            }

            return true;
        }

        private bool AreEqualStringsOneAway(string s1, string s2)
        {
            char[] c1 = s1.ToCharArray();
            char[] c2 = s2.ToCharArray();

            int diff_amount = 0;
            for (int i=0; i < s1.Length; i++)
            {
                if(c1[i] != c2[i])
                {
                    diff_amount++;
                }

                if (diff_amount > 1) return false;
            }

            return true;
        }
    }
}
