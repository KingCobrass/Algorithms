using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Utilities;

namespace Problems.Strings
{
    // CTCI 1.1
    [TestClass]
    public class IsUnique
    {
        [TestMethod]
        public void IsUniqueTest()
        {
            Func<string, bool>[] functions = new Func<string, bool>[]
            {
                IsUnique.BruteForce,
                IsUnique.Flags
            };

            for(int i = 0; i < 10; i++)
            {
                string s = StringUtilities.CreateRandomString(20);
                Tests.TestFunctions(s, functions);
            }
        }

        private static bool BruteForce(string s)
        {
            for(int i = 0; i < s.Length; i++)
            {
                for(int j = i + 1; j < s.Length; j++)
                {
                    if (s[i] == s[j])
                        return false;
                }
            }

            return true;
        }

        private static bool Flags(string s)
        {
            bool[] flags = new bool[26];

            foreach(char c in s)
            {
                int index = c - 'a';
                if (flags[index])
                    return false;

                flags[index] = true;
            }

            return true;
        }
    }
}
