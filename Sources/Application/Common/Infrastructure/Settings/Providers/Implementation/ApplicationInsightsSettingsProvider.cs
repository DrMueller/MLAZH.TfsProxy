using Mmu.Mlazh.AzureApplicationExtensions.Infrastructure.Settings.Models;
using Mmu.Mlazh.AzureApplicationExtensions.Infrastructure.Settings.Services;
using Mmu.Mlazh.TfsProxy.Application.Common.Infrastructure.Settings.Models;

namespace Mmu.Mlazh.TfsProxy.Application.Common.Infrastructure.Settings.Providers.Implementation
{
    public class ApplicationInsightsSettingsProvider : IApplicationInsightsSettingsProvider
    {
        private readonly AppSettings _appSettings;

        public ApplicationInsightsSettingsProvider(AppSettings appSettings)
        {
            _appSettings = appSettings;
        }

        public ApplicationInsightsSettings ProvideApplicationInsightsSettings()
        {
            return _appSettings.ApplicationInsightsSettings;
        }
    }
}