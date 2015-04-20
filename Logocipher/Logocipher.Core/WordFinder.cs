using System;
using System.Collections.Generic;
using System.Linq;

namespace Logocipher
{
    public interface IWordFinder
    {
        List<string> GetPotentialWords(string providedPhrase);
    }

    public class WordFinder : IWordFinder
    {
        private const string Alphabet = "abcdefghijklmnopqrstuvwxyz";
        private readonly IWordDictionary _wordDictionary;
        private readonly char[] _alphabetCharacters;
        public WordFinder(IWordDictionary wordDictionary)
        {
            _wordDictionary = wordDictionary;
            _alphabetCharacters = Alphabet.ToCharArray();
        }
        public List<string> GetPotentialWords(string providedPhrase)
        {
            var comparableProvidedPhrase = providedPhrase.CleanForCompare();

            var uniqueCharacters = comparableProvidedPhrase.ToCharArray().Distinct();

            var unusedCharacters = _alphabetCharacters.Where(ac => uniqueCharacters.All(uc => ac != uc));

            var comparableProvidedPhraseLength = comparableProvidedPhrase.Length;

            var availableWords = _wordDictionary.Dictionary
                .Where(s => s.Word.Length <= comparableProvidedPhraseLength)
                .Where(s => !unusedCharacters.Any(s.Word.Contains))
                .Where(s => s.Word != providedPhrase)
                .Where(HasExactSameCharacters(comparableProvidedPhrase, comparableProvidedPhraseLength))
                .OrderByDescending(s => s.Word.Length)
                .Select(w=>w.Word)
                .ToList();
            return availableWords;
        }
        private static Func<WordEntry, bool> HasExactSameCharacters(string comparableProvidedPhrase,  int comparableProvidedPhraseLength)
        {
            return s => (s.Word.Length == comparableProvidedPhraseLength && s.Alphabetized == comparableProvidedPhrase) ||
                        s.Word.Length != comparableProvidedPhraseLength;
        }
    }
}