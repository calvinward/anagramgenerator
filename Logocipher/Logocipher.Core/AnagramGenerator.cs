using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Logocipher
{
    public interface IAnagramGenerator
    {
        IList<string> GetPhrases(string providedPhrase);
    }

    public class AnagramGenerator : IAnagramGenerator
    {
        private readonly IWordFinder _wordFinder;
        private const int MaxMilliseconds = 2000;
        private readonly Stopwatch _stopwatch;

        public AnagramGenerator(IWordFinder wordFinder)
        {
            _wordFinder = wordFinder;
            _stopwatch = new Stopwatch();
        }

        public IList<string> GetPhrases(string providedPhrase)
        {
            var comparableProvidedPhrase = providedPhrase.CleanForCompare();

            var potentialWords = _wordFinder.GetPotentialWords(providedPhrase);

            var validPhrases = new ConcurrentBag<string>();

            _stopwatch.Restart();

            Parallel.ForEach(potentialWords, availableWord =>
            {
                FindGaps(comparableProvidedPhrase, availableWord, validPhrases, potentialWords);
            });

            _stopwatch.Stop();
            return validPhrases.Distinct().OrderBy(vp => vp).ToList();
        }

        private void FindGaps(string comparableProvidedPhrase, string potentialPhrase, ConcurrentBag<string> validPhrases,
            IEnumerable<string> potentialWords)
        {
            if (_stopwatch.ElapsedMilliseconds >= MaxMilliseconds)
            {
                return;
            }

            if (comparableProvidedPhrase == potentialPhrase.CleanForCompare())
            {
                validPhrases.Add(potentialPhrase);
                return;
            }

            var gapLength = comparableProvidedPhrase.Length - potentialPhrase.CleanForCompare().Length;

            // ReSharper disable once PossibleMultipleEnumeration
            var gapWords = potentialWords.Where(aw => aw.Length <= gapLength).ToList();

            if (!gapWords.Any())
            {
                return;
            }

            foreach (var gapWord in gapWords)
            {
                var newPotentialPhrase = string.Format("{0} {1}", potentialPhrase, gapWord);

                // ReSharper disable once PossibleMultipleEnumeration
                FindGaps(comparableProvidedPhrase, newPotentialPhrase, validPhrases, potentialWords);
            }
        }
    }
}