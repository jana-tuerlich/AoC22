using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode3
{
    class Program
    {
        static int GetPriority(char c)
        {
            if (c <= 'Z')
            {
                return c - 'A' + 27;
            }
            return c - 'a' + 1;
        }

        static IEnumerable<(string, string, string)> GetThreeLines( string[] lines )
        {
            for (var i = 0; i < lines.Length; i += 3)
            {
                yield return (lines[i], lines[i + 1], lines[i + 2]);
            }
        }

        static string A(string[] lines)
        {
            return lines.Sum(line =>
            { 
                IEnumerable<char> firstCompartment = line.Take(line.Length / 2);
                IEnumerable<char> secondCompartment = line.Skip( line.Length / 2 ).Take(line.Length / 2);
                char duplicate = firstCompartment.First(c => secondCompartment.Contains(c));
                return GetPriority(duplicate);
            }).ToString();
        }
        
        static string B(string[] lines)
        {
            return GetThreeLines(lines).Sum(tuple =>
            {
                var badge = tuple.Item1.First(c => tuple.Item2.Contains(c) && tuple.Item3.Contains(c));

                return GetPriority(badge);
            }).ToString();
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
