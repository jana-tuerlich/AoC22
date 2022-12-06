using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2
{
    enum Gesture
    {
        Rock = 1,
        Paper = 2,
        Scissors = 3
    }
    enum Outcome
    {
        Lose = 1,
        Draw = 2,
        Win = 3
    }

    class Program
    {
        static Dictionary<(Gesture, Gesture), int> rules = new Dictionary<(Gesture, Gesture), int>
        {
            { (Gesture.Rock, Gesture.Rock), 3 },
            { (Gesture.Paper, Gesture.Paper), 3 },
            { (Gesture.Scissors, Gesture.Scissors), 3 },
            { (Gesture.Rock, Gesture.Paper), 6 },
            { (Gesture.Paper, Gesture.Rock), 0 },
            { (Gesture.Paper, Gesture.Scissors), 6 },
            { (Gesture.Scissors, Gesture.Paper), 0 },
            { (Gesture.Scissors, Gesture.Rock), 6 },
            { (Gesture.Rock, Gesture.Scissors), 0 },
        };

        static string A( string[] lines )
        {
            Dictionary<char, Gesture> gestures = new Dictionary<char, Gesture>
            {
                { 'A', Gesture.Rock },
                { 'X', Gesture.Rock },
                { 'B', Gesture.Paper },
                { 'Y', Gesture.Paper },
                { 'C', Gesture.Scissors },
                { 'Z', Gesture.Scissors },
            };
            List<(Gesture, Gesture)> rounds = lines.Select(line =>
                (gestures[line[0]], gestures[line[2]])).ToList();

            
            int sum = rounds.Sum(round => rules[round] + (int)round.Item2);
            return sum.ToString();
        }
        
        static string B( string[] lines )
        {
            Dictionary<char, Gesture> gestures = new Dictionary<char, Gesture>
            {
                { 'A', Gesture.Rock },
                { 'B', Gesture.Paper },
                { 'C', Gesture.Scissors },
            };
            Dictionary<char, Outcome> outcomes = new Dictionary<char, Outcome>
            {
                { 'X', Outcome.Lose},
                { 'Y', Outcome.Draw },
                { 'Z', Outcome.Win },
            };

            List<(Gesture, Outcome)> rounds = lines.Select( line =>
                (gestures[line[0]], outcomes[line[2]]) ).ToList();
            
            Dictionary<(Gesture, Outcome), Gesture> neededMoves = new Dictionary<(Gesture, Outcome), Gesture>
            {
                { (Gesture.Rock, Outcome.Lose), Gesture.Scissors },
                { (Gesture.Paper, Outcome.Draw), Gesture.Paper },
                { (Gesture.Scissors, Outcome.Win), Gesture.Rock },
                { (Gesture.Rock, Outcome.Draw), Gesture.Rock },
                { (Gesture.Paper, Outcome.Lose), Gesture.Rock },
                { (Gesture.Scissors, Outcome.Draw), Gesture.Scissors },
                { (Gesture.Paper, Outcome.Win), Gesture.Scissors },
                { (Gesture.Scissors, Outcome.Lose), Gesture.Paper },
                { (Gesture.Rock, Outcome.Win), Gesture.Paper },
            };

            int sum = rounds.Sum( round =>
            {
                var move = (round.Item1, neededMoves[round]);
                return rules[move] + (int)move.Item2;
            });
            return sum.ToString();
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
