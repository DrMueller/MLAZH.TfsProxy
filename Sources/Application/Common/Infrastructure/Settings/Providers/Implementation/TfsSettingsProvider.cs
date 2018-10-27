using Mmu.Mlazh.TfsProxy.Application.Common.Infrastructure.Settings.Models;

namespace Mmu.Mlazh.TfsProxy.Application.Common.Infrastructure.Settings.Providers.Implementation
{
    public class TfsSettingsProvider : ITfsSettingsProvider
    {
        private readonly AppSettings _appSettings;

        public TfsSettingsProvider(AppSettings appSettings)
        {
            _appSettings = appSettings;
        }

        public TfsSettings ProvideTfsSettings()
        {
            return _appSettings.TfsSettings;
        }
    }
}