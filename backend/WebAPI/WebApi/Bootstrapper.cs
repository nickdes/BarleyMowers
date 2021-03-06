using GraphQL;
using GraphQL.Http;
using GraphQL.Types;
using IoC;
using StarWars;
using StarWars.Mutations;
using StarWars.Types;

namespace WebApi
{
    public class Bootstrapper
    {
        public System.Web.Http.Dependencies.IDependencyResolver Resolver()
        {
            var container = BuildContainer();
            var resolver = new SimpleContainerDependencyResolver(container);
            return resolver;
        }

        private ISimpleContainer BuildContainer()
        {
            var container = new SimpleContainer();
            container.Singleton<IDocumentExecuter>(new DocumentExecuter());
            container.Singleton<IDocumentWriter>(new DocumentWriter(true));

            container.Singleton(new StarWarsData());
            container.Register<StarWarsQuery>();
            container.Register<StarWarsMutation>();
            container.Register<EditCharacterMutation>();
            container.Register<HumanType>();
            container.Register<HumanInputType>();
            container.Register<DroidType>();
            container.Register<DroidInputType>();
            container.Register<CharacterInterface>();
            container.Singleton<ISchema>(new StarWarsSchema(new FuncServiceProvider(type => container.Get(type))));

            return container;
        }
    }
}
