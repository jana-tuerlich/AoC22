using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode1
{
    class Program
    {
        static IEnumerable<int> TotalCalories(IEnumerable<string> input)
        {
            int sum = 0;
            foreach (string str in input)
            {
                if (string.IsNullOrEmpty(str))
                {
                    yield return sum;
                    sum = 0;
                    continue;
                }
                sum += int.Parse(str);
            }
            yield return sum;
        }
        
        static string A(string[] lines)
        {
            IEnumerable<int> calories = TotalCalories( lines );
            int max = calories.OrderByDescending( c => c ).First();
            return max.ToString();
        }

        static string B(string[] lines)
        {
            IEnumerable<int> calories = TotalCalories( lines );
            int max = calories.OrderByDescending( c => c ).Take( 3 ).Sum();
            return max.ToString();
        }

        static void Main( string[] args )
        {
            string[] testInputLines = File.ReadAllLines( "TestInput.txt" );
            string[] inputLines = File.ReadAllLines( "Input.txt" );
            Console.WriteLine( A( testInputLines ) );
            Console.WriteLine( A( inputLines ) );
            Console.WriteLine( B( testInputLines ) );
            Console.WriteLine( B( inputLines ) );
        }
    }
}
