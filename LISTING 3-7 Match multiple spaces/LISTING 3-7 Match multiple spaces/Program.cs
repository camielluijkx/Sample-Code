using System;
using System.Text.RegularExpressions;

namespace LISTING_3_7_Match_multiple_spaces
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "Rob    Mary David   Jenny  Chris   Imogen       Rodney";

            string regularExpressionToMatch = " +";
            string patternToReplace = ",";

            string replaced = Regex.Replace(input, regularExpressionToMatch, patternToReplace);

            Console.WriteLine(replaced);
            Console.ReadKey();
        }
    }
}