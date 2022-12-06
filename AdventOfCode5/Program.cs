using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode5
{
    class Program
    {
        static string ProcessCrates(string[] lines, Action<List<Stack<char>>, int, int, int> craneFunc)
        {
            int numStacks = lines[0].Length / 4 + 1;
            List<Stack<char>> stacks = Enumerable.Range(0, numStacks).Select(i => new Stack<char>()).ToList();

            List<string> stackLines = lines.TakeWhile(line => !string.IsNullOrEmpty(line)).ToList();
            List<string> moveLines = lines.Skip(stackLines.Count + 1).ToList();

            foreach (string stackLine in stackLines.AsEnumerable().Reverse().Skip(1))
            {
                for (int i = 0; i < numStacks; i++)
                {
                    int index = i * 4 + 1;
                    char c = stackLine[index];
                    if (c == ' ')
                    {
                        continue;
                    }
                    stacks[i].Push(c);
                }
            }

            foreach (string moveLine in moveLines)
            {
                var match = Regex.Match( moveLine, @"move (\d+) from (\d+) to (\d+)" );
                int amount = int.Parse(match.Groups[1].Value);
                int from = int.Parse(match.Groups[2].Value) - 1;
                int to = int.Parse(match.Groups[3].Value) - 1;

                craneFunc(stacks, amount, from, to);
            }

            string result = "";
            foreach (Stack<char> stack in stacks)
            {
                if (!stack.Any())
                {
                    continue;
                }
                result += stack.Peek();
            }
            return result;
        }

        static void MoveFromToA(List<Stack<char>> stacks, int amount, int from, int to)
        {
            for (int i = 0; i < amount; i++)
            {
                stacks[to].Push(stacks[from].Pop());
            }
        }
        
        static void MoveFromToB( List<Stack<char>> stacks, int amount, int from, int to )
        {
            Stack<char> temp = new Stack<char>();
            for (int i = 0; i < amount; i++)
            {
                temp.Push( stacks[from].Pop() );
            }
            for (int i = 0; i < amount; i++)
            {
                stacks[to].Push( temp.Pop() );
            }
        }

        static string A(string[] lines)
        {
            return ProcessCrates(lines, MoveFromToA );
        }

        static string B( string[] lines )
        {
            return ProcessCrates( lines, MoveFromToB );
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
