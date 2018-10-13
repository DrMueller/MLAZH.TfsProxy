using System;

namespace Mmu.Mlazh.TfsProxy.Application.Infrastructure.TfsAccess.Settings.Models
{
    public class TfsSettings
    {
        public Uri TfsBaseProjectPath { get; set; }

        public string BasicAuthToken { get; set; }
    }
}