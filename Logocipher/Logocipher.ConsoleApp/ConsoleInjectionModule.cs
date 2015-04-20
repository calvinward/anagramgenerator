using Ninject.Modules;

namespace Logocipher.ConsoleApp
{
    public class ConsoleInjectionModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IWordDictionary>().To<WordDictionary>().InSingletonScope();
            Bind<IWordFinder>().To<WordFinder>().InSingletonScope();
            Bind<IAnagramGenerator>().To<AnagramGenerator>();
        }
    }
}