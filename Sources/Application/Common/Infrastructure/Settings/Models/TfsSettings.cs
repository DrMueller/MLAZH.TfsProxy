using System;

namespace Mmu.Mlazh.TfsProxy.Application.Common.Infrastructure.Settings.Models
{
    public class TfsSettings
    {
        public string BasicAuthToken { get; set; }
        public string TfsBaseOrganisationPath { get; set; }
        public string TfsProjectName { get; set; }

        public Uri GetTfsBaseProjectPath()
        {
            return new Uri(new Uri(TfsBaseOrganisationPath), TfsProjectName);
        }
    }
}