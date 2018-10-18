using Mmu.Mlh.ApplicationExtensions.Areas.Adapters.Services;
using StructureMap;

namespace Mmu.Mlazh.TfsProxy.Application.Infrastructure.DependencyInjection
{
    public class ApplicationRegistry : Registry
    {
        public ApplicationRegistry()
        {
            Scan(
                scanner =>
                {
                    scanner.AssemblyContainingType<ApplicationRegistry>();
                    scanner.AddAllTypesOf(typeof(IAdapter<,>));
                    scanner.WithDefaultConventions();
                });

            For(typeof(IAdapter<,>)).Singleton();
        }
    }
}