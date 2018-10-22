using System.Collections.Generic;
using Mmu.Mlazh.TfsProxy.Dependencies;
using Mmu.Mlh.ApplicationExtensions.Areas.DependencyInjection.Models;
using Mmu.Mlh.ApplicationExtensions.Areas.DependencyInjection.Services;
using Mmu.Mlh.ApplicationExtensions.Areas.ServiceProvisioning;

namespace Mmu.Mlazh.TfsProxy.TestConsole.Common.Infrastructure.ServiceProvisioning
{
    public static class AppProvisioningService
    {
        private static bool _isInitialized;
        private static object _lock = new object();

        public static IReadOnlyCollection<T> GetAllServices<T>()
        {
            AssureInitialization();
            return ProvisioningServiceSingleton.Instance.GetAllServices<T>();
        }

        public static T GetService<T>()
        {
            AssureInitialization();
            return ProvisioningServiceSingleton.Instance.GetService<T>();
        }

        private static void AssureInitialization()
        {
            if (!_isInitialized)
            {
                lock (_lock)
                {
                    if (!_isInitialized)
                    {
                        DependenciesProvider.ProvideDependencencies();
                        ContainerInitializationService.CreateInitializedContainer(new AssemblyParameters(typeof(AppProvisioningService).Assembly, "Mmu.Mlazh"));
                        _isInitialized = true;
                    }
                }
            }
        }
    }
}