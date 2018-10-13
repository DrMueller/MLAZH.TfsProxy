using Mmu.Mlh.ApplicationExtensions.Areas.DependencyInjection.Models;
using Mmu.Mlh.ApplicationExtensions.Areas.DependencyInjection.Services;
using Mmu.Mlh.ApplicationExtensions.Areas.ServiceProvisioning;

namespace Mmu.Mlazh.TfsProxy.AzureFunctions.Infrastructure.ServiceProvisioning
{
    internal static class ProvisioningService
    {
        private static bool _isInitialized;
        private static object _lock = new object();

        internal static T GetService<T>()
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
                        ContainerInitializationService.CreateInitializedContainer(new AssemblyParameters(typeof(ProvisioningService).Assembly, "Mmu.Mlazh"));
                        _isInitialized = true;
                    }
                }
            }
        }
    }
}