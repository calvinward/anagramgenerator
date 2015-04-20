using System.Collections.Generic;
using System.Web.Http;

namespace Logocipher.Web.Controllers
{
    public class AnagramsController : ApiController
    {
        private readonly IAnagramGenerator _anagramGenerator;

        public AnagramsController(IAnagramGenerator anagramGenerator)
        {
            _anagramGenerator = anagramGenerator;
        }
        public IList<string> Get(string text)
        {
            return _anagramGenerator.GetPhrases(text);
        }
    }
}
