using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Library
{
    public static class Palindrome
    {
        public static bool IsPalindrome(string palindromeCandidate)
        {
            var normalized = Regex.Replace(palindromeCandidate.Trim().ToLower(), @"\s+", string.Empty);

            return normalized.Equals(String.Concat(normalized.Reverse()));
        }
    }
}
