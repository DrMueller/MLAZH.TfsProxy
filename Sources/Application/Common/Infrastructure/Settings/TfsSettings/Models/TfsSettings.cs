using System;

namespace Mmu.Mlazh.TfsProxy.Application.Common.Infrastructure.Settings.TfsSettings.Models
{
    public class TfsSettings
    {
        public string BasicAuthToken { get; set; }
        public Uri TfsBaseOrganisationPath { get; set; }
        public Uri TfsBaseProjectPath => new Uri(TfsBaseOrganisationPath, TfsProjectName);
        public string TfsProjectName { get; set; }
    }
}