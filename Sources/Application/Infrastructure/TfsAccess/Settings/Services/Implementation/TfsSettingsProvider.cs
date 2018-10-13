using System;
using Mmu.Mlazh.TfsProxy.Application.Infrastructure.TfsAccess.Settings.Models;

namespace Mmu.Mlazh.TfsProxy.Application.Infrastructure.TfsAccess.Settings.Services.Implementation
{
    public class TfsSettingsProvider : ITfsSettingsProvider
    {
        public TfsSettings ProvideTfsSettings()
        {
            return new TfsSettings
            {
                TfsBaseProjectPath = new Uri("https://drmueller.visualstudio.com/Fun%20Project/"),
                BasicAuthToken = "fmhkiljkf4ytev5werumffujgs7ofczm7x5kinwghta7kddpdlpq"
            };
        }
    }
}