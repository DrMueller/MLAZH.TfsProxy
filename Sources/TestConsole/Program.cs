using Mmu.Mlazh.AzureApplicationExtensions.Areas.AzureAppInitialization.Services;
using Mmu.Mlazh.TfsProxy.Application.Common.Infrastructure.Settings.Models;
using Mmu.Mlazh.TfsProxy.Dependencies;
using Mmu.Mlh.ConsoleExtensions.Areas.Commands.Services;
using Mmu.Mlh.ServiceProvisioning.Areas.Initialization.Models;
using Mmu.Mlh.ServiceProvisioning.Areas.Provisioning.Services;

namespace Mmu.Mlazh.TfsProxy.TestConsole
{
    internal class Program
    {
        private static void Main()
        {
            var currentAssembly = typeof(Program).Assembly;
            var containerConfig = ContainerConfiguration.CreateFromAssembly(
                currentAssembly,
                initializeAutoMapper: true,
                logInitialization: true);

            InitializationService.AssureServicesAreInitialized(containerConfig, DependenciesProvider.ProvideDependencencies);
            InitializationService.AssureSettingsAreInitialized<AppSettings>(
                AppSettings.Sectionkey,
                string.Empty,
                currentAssembly);

            ServiceLocatorSingleton
                .Instance
                .GetService<IConsoleCommandsStartupService>()
                .Start();
        }
    }
}