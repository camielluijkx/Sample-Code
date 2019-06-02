﻿using System;
using System.Text.RegularExpressions;

namespace LISTING_3_10_Perfect_validation
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "Rob Miles:My Way:120";

            string regexToMatch = @"^([a-z]|[A-Z]| )+:([a-z]|[A-Z]| )+:[0-9]+$";

            if (Regex.IsMatch(input, regexToMatch))
            {
                Console.WriteLine("Valid music track description");
            }
            else
            {
                Console.WriteLine("Invalid music track");
            }
            Console.ReadKey();
        }
    }
}