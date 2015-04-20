using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Ninject;

namespace Logocipher.ConsoleApp
{
    internal class Program
    {
        private static Stopwatch _stopwatch;
        private static StandardKernel _kernel;
        private static List<string> _validPhrases;
        private static void Main()
        {
            _validPhrases = new List<string>();

            _stopwatch = new Stopwatch();

            _kernel = new StandardKernel(new ConsoleInjectionModule());

            string line;
            PrintInstructions();
            do
            {
                line = Console.ReadLine();
                if (line == null)
                {
                    continue;
                }
                if (line == "e")
                {
                    Environment.Exit(0);
                }
                else if (line == "y")
                {
                    ShowAnagrams();
                }
                else
                {
                    Process(line);
                }
                PrintInstructions();

            } while (line != null);

        }

        private static void ShowAnagrams()
        {
            Console.WriteLine("");
            Console.WriteLine("Anagrams:");
            foreach (var validPhrase in _validPhrases)
            {
                Console.WriteLine("--{0}", validPhrase);
            }
            Console.WriteLine("Anagram Count: {0}", _validPhrases.Count);
            Console.WriteLine("");
        }

        private static void PrintInstructions()
        {
            Console.WriteLine("* Enter (e) to exit");
            Console.WriteLine("* Enter word to generate new anagrams:");
        }

        public static void Process(string providedPhrase)
        {
            _validPhrases = new List<string>();
            Console.WriteLine("");
            Console.WriteLine("Started: {0}", providedPhrase);

            _stopwatch.Start();

            var anagramGenerator = _kernel.Get<IAnagramGenerator>();

            _validPhrases = anagramGenerator.GetPhrases(providedPhrase).ToList();

            _stopwatch.Stop();

            Console.WriteLine("Completed: {0}", providedPhrase);
            Console.WriteLine("Anagram Count: {0}", _validPhrases.Count);
            Console.WriteLine("Milliseconds: {0}", _stopwatch.ElapsedMilliseconds);
            Console.WriteLine("");

            if (_validPhrases.Count == 0)
            {
                Console.WriteLine("No Anagrams found");
            }
            else
            {
                Console.WriteLine("* Enter (y) to see anagrams for {0}:", providedPhrase);
            }
            _stopwatch.Reset();
        }
    }
}