using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode4
{
    class Program
    {
        static IEnumerable<(int from0, int to0, int from1, int to1)> Limits( IEnumerable<string> input )
        {
            foreach (string str in input)
            {
                var match = Regex.Match( str, @"(\d+)-(\d+),(\d+)-(\d+)" );
                var from0 = int.Parse( match.Groups[1].Value );
                var to0 = int.Parse( match.Groups[2].Value );
                var from1 = int.Parse( match.Groups[3].Value );
                var to1 = int.Parse( match.Groups[4].Value );

                yield return (from0, to0, from1, to1);
            }
        }

        static string A(string[] lines)
        {
            return Limits(lines).Count( tuple => ( tuple.from0 <= tuple.from1 && tuple.to0 >= tuple.to1 ) || 
                                                 ( tuple.from0 >= tuple.from1 && tuple.to0 <= tuple.to1 )).ToString();
        }

        static string B(string[] lines)
        {
            return Limits(lines).Count( tuple => ( tuple.from0 <= tuple.from1 && tuple.to0 >= tuple.from1 ) || 
                                                 ( tuple.from1 <= tuple.from0 && tuple.to1 >= tuple.from0 )).ToString();
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
