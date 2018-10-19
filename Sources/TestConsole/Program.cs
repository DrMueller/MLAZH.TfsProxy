using Mmu.Mlazh.TfsProxy.Dependencies;
using Mmu.Mlh.ApplicationExtensions.Areas.DependencyInjection.Models;
using Mmu.Mlh.ApplicationExtensions.Areas.DependencyInjection.Services;

namespace Mmu.Mlazh.TfsProxy.TestConsole
{
    internal class Program
    {
        private static void Main()
        {
            DependenciesProvider.ProvideDependencencies();
            ContainerInitializationService.CreateInitializedContainer(
                new AssemblyParameters(
                    typeof(Program).Assembly,
                    "Mmu.Mlazh"));

            ConsoleCommansContainer.Start();
        }
    }
}