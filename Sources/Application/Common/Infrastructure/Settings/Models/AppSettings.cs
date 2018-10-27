using Mmu.Mlazh.AzureApplicationExtensions.Infrastructure.Settings.Models;

namespace Mmu.Mlazh.TfsProxy.Application.Common.Infrastructure.Settings.Models
{
    public class AppSettings
    {
        public const string Sectionkey = "AppSettings";
        public ApplicationInsightsSettings ApplicationInsightsSettings { get; set; }
        public TfsSettings TfsSettings { get; set; }
    }
}