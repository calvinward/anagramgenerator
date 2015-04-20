using Ninject.Modules;
using Ninject.Web.Common;

namespace Logocipher.Web.App_Start
{
    public class WebInjectionModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IWordDictionary>().To<WordDictionary>().InSingletonScope();
            Bind<IWordFinder>().To<WordFinder>().InSingletonScope();
            Bind<IAnagramGenerator>().To<AnagramGenerator>().InRequestScope();
        }
    }
}