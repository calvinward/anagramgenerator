using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Logocipher
{
    public interface IWordDictionary
    {
        IList<WordEntry> Dictionary { get; }
        IList<string> GetLetters();
        IList<string> GetWords(string letter);
    }

    public class WordDictionary : IWordDictionary
    {
        private const string DictionaryPath = "Logocipher.Resources.sowpods_wordlist.txt";

        public WordDictionary()
        {
            Dictionary = new List<WordEntry>();

            List<string> results;

            var dictionaryBag = new ConcurrentBag<WordEntry>();

            var assembly = Assembly.GetExecutingAssembly();

            using (var stream = assembly.GetManifestResourceStream(DictionaryPath))
            // ReSharper disable once AssignNullToNotNullAttribute
            using (var reader = new StreamReader(stream))
            {
                results =
                    reader.ReadToEnd()
                        .Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                        .ToList();
            }

            Parallel.ForEach(results, word =>
            {
                dictionaryBag.Add(new WordEntry
                {
                    Word = word,
                    Alphabetized = word.Alphabetize()
                });
            });

            Dictionary = dictionaryBag.ToList();

        }

        public IList<string> GetLetters()
        {
            return Dictionary.Select(w => w.Word.Substring(0, 1)).Distinct().OrderBy(l => l).ToList();
        }

        public IList<string> GetWords(string letter)
        {
            return Dictionary.Where(w => w.Word.StartsWith(letter)).Select(w => w.Word).ToList();
        }

        public IList<WordEntry> Dictionary { get; private set; }
    }
}