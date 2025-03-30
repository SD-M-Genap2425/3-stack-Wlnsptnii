using System;
using System.Collections.Generic;
using System.Linq;

namespace Solution.Palindrome
{
    public static class PalindromeChecker
    {
        public static bool CekPalindrom(string input)
        {
            string normalized = new string(input.Where(char.IsLetterOrDigit).ToArray()).ToLower();

            Stack<char> stack = new Stack<char>();

            foreach (char ch in normalized)
            {
                stack.Push(ch);
            }

            foreach (char ch in normalized)
            {
                if (stack.Pop() != ch)
                {
                    return false;
                }
            }

            return true;
        }
    }
}

