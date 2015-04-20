using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using NSubstitute.Core;

namespace Logocipher.Core.Tests
{
    [TestClass]
    public class AnagramGeneratorTests
    {
        [TestMethod]
        public void GetPhrases_PotentialWords2_AlternatingPhrases2()
        {
            const int expected = 2;

            var testPhrase = "random";

            var wordFinder = Substitute.For<IWordFinder>();
            wordFinder.GetPotentialWords(testPhrase).Returns(new List<string>
            {
                "dom",
                "ran"
            });

            var anagramGenerator = new AnagramGenerator(wordFinder);

            var results = anagramGenerator.GetPhrases(testPhrase);

            Assert.AreEqual(expected, results.Count);

        }
    }
}