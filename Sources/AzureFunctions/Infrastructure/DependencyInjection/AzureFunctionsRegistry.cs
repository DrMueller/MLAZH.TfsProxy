using StructureMap;

namespace Mmu.Mlazh.TfsProxy.AzureFunctions.Infrastructure.DependencyInjection
{
    public class AzureFunctionsRegistry : Registry
    {
        public AzureFunctionsRegistry()
        {
            Scan(
                scanner =>
                {
                    scanner.AssemblyContainingType<AzureFunctionsRegistry>();
                    scanner.WithDefaultConventions();
                });
        }
    }
}