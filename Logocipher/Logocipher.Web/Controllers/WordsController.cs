using System.Collections.Generic;
using System.Web.Http;

namespace Logocipher.Web.Controllers
{
    public class WordsController : ApiController
    {
        private readonly IWordDictionary _wordDictionary;

        public WordsController(IWordDictionary wordDictionary)
        {
            _wordDictionary = wordDictionary;
        }

        public IList<string> Get(string letter)
        {
            return _wordDictionary.GetWords(letter);
        }
    }
}