using Mmu.Mlazh.AzureApplicationExtensions.Areas.AzureFunctions.HttpRequestProxies.Services;
using Mmu.Mlh.ConsoleExtensions.Areas.Commands.Models;
using StructureMap;

namespace Mmu.Mlazh.TfsProxy.TestConsole
{
    public class TestConsoleRegistry : Registry
    {
        public TestConsoleRegistry()
        {
            Scan(
                scanner =>
                {
                    scanner.AssemblyContainingType<TestConsoleRegistry>();
                    scanner.AddAllTypesOf<IConsoleCommand>();
                    scanner.WithDefaultConventions();
                });

            For<IHttpRequestProxyFactory>().Use<HttpRequestProxyFactoryMock>().Singleton();
        }
    }
}