﻿using System;

namespace ExtensionMethods
{
    public static class StringExtension
    {
        public static int CountCharacteres(this String st)
        {
            return st.Length;
        }

        //It is incomplet
        public static bool IsValid(this String st, Func<bool> predicate)
        {
            return predicate();
        }
    }
}
