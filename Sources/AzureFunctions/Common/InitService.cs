using System.Reflection;
using Mmu.Mlazh.AzureApplicationExtensions.Areas.AzureAppInitialization.Services;
using Mmu.Mlazh.TfsProxy.Application.Common.Infrastructure.Settings.Models;
using Mmu.Mlazh.TfsProxy.Dependencies;
using Mmu.Mlh.ServiceProvisioning.Areas.Initialization.Models;

namespace Mmu.Mlazh.TfsProxy.AzureFunctions.Common
{
    public static class InitService
    {
        private static Assembly _currentAssembly = typeof(InitService).Assembly;

        public static void Init()
        {
            var containerConfig = ContainerConfiguration.CreateFromAssembly(
                _currentAssembly,
                initializeAutoMapper: true,
                logInitialization: true);

            InitializationService.AssureServicesAreInitialized(containerConfig, DependenciesProvider.ProvideDependencencies);
            InitializationService.AssureSettingsAreInitialized<AppSettings>(AppSettings.Sectionkey, _currentAssembly);
        }
    }
}