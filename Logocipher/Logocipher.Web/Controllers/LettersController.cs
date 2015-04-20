using System.Collections.Generic;
using System.Web.Http;

namespace Logocipher.Web.Controllers
{
    public class LettersController : ApiController
    {
        private readonly IWordDictionary _wordDictionary;

        public LettersController(IWordDictionary wordDictionary)
        {
            _wordDictionary = wordDictionary;
        }

        public IList<string> Get()
        {
            return _wordDictionary.GetLetters();
        }
    }
}