using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode6
{
    
    class Program
    {
        private static string FindMarker( string[] lines, int number )
        {
            string line = lines[0];
            for (var i = 0; i < line.Length; i++)
            {
                if (line.Skip( i ).Take( number ).Distinct().Count() == number)
                {
                    return ( i + number ).ToString();
                }
            }

            throw new ArgumentException();
        }

        static string A(string[] lines)
        {
            return FindMarker(lines, 4);
        }
        
        static string B(string[] lines)
        {
            return FindMarker( lines, 14 );
        }

        static void Main( string[] args )
        {
            string[] testInputLines = File.ReadAllLines("TestInput.txt");
            string[] inputLines = File.ReadAllLines( "Input.txt" );
            Console.WriteLine( A(testInputLines) );
            Console.WriteLine( A(inputLines ) );
            Console.WriteLine( B( testInputLines ) );
            Console.WriteLine( B( inputLines ) );
        }
    }
}
