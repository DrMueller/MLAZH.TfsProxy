using Mmu.Mlazh.TfsProxy.Application.Common.Infrastructure.Settings.Models;

namespace Mmu.Mlazh.TfsProxy.Application.Common.Infrastructure.Settings.Providers
{
    public interface ITfsSettingsProvider
    {
        TfsSettings ProvideTfsSettings();
    }
}