using Mmu.Mlazh.TfsProxy.Application.Infrastructure.TfsAccess.Settings.Models;

namespace Mmu.Mlazh.TfsProxy.Application.Infrastructure.TfsAccess.Settings.Services
{
    public interface ITfsSettingsProvider
    {
        TfsSettings ProvideTfsSettings();
    }
}