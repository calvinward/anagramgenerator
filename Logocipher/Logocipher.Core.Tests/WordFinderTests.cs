using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Logocipher.Core.Tests
{
    [TestClass]
    public class WordFinderTests
    {
        [TestMethod]
        public void GetPotentialWords_ExactCharacters_1()
        {
            const int expected = 1;

            var wordDictionary = Substitute.For<IWordDictionary>();
            wordDictionary.Dictionary.Returns(x => new List<WordEntry>
            {
                new WordEntry { Word = "fact", Alphabetized = "acft" },
                new WordEntry { Word = "act", Alphabetized = "act" },
                new WordEntry { Word = "cca", Alphabetized = "acc" }
            });
            var wordFinder = new WordFinder(wordDictionary);

            var actual = wordFinder.GetPotentialWords("cat").Count;

            Assert.AreEqual(expected,actual);

        }


        [TestMethod]
        public void GetPotentialWords_NoExactCharacters_0()
        {
            const int expected = 0;
            
            var wordDictionary = Substitute.For<IWordDictionary>();
            wordDictionary.Dictionary.Returns(x => new List<WordEntry>
            {
                new WordEntry { Word = "dog", Alphabetized = "odg" },
                new WordEntry { Word = "red", Alphabetized = "edr" },
                new WordEntry { Word = "mom", Alphabetized = "omm" }
            });
            var wordFinder = new WordFinder(wordDictionary);

            var actual = wordFinder.GetPotentialWords("dog").Count;

            Assert.AreEqual(expected, actual);

        }


        [TestMethod]
        public void GetPotentialWords_ShorterWithCandidateCharacters_1()
        {
            const int expected = 1;

            var wordDictionary = Substitute.For<IWordDictionary>();
            wordDictionary.Dictionary.Returns(x => new List<WordEntry>
            {
                new WordEntry { Word = "dog", Alphabetized = "odg" },
                new WordEntry { Word = "red", Alphabetized = "edr" },
                new WordEntry { Word = "mom", Alphabetized = "omm" }
            });
            var wordFinder = new WordFinder(wordDictionary);

            var actual = wordFinder.GetPotentialWords("random").Count;

            Assert.AreEqual(expected, actual);

        }


        [TestMethod]
        public void GetPotentialWords_PhraseMatchesWord_1()
        {
            const int expected = 1;

            var wordDictionary = Substitute.For<IWordDictionary>();
            wordDictionary.Dictionary.Returns(x => new List<WordEntry>
            {
                new WordEntry { Word = "dog", Alphabetized = "odg" },
                new WordEntry { Word = "random", Alphabetized = "admnor" }
            });
            var wordFinder = new WordFinder(wordDictionary);

            var actual = wordFinder.GetPotentialWords("dom ran").Count;

            Assert.AreEqual(expected, actual);

        }

    }
}
