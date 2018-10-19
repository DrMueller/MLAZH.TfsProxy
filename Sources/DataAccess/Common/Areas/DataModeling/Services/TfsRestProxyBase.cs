using System.Threading.Tasks;
using Mmu.Mlazh.TfsProxy.Application.Common.Infrastructure.Settings.TfsSettings.Models;
using Mmu.Mlazh.TfsProxy.Application.Common.Infrastructure.Settings.TfsSettings.Services;
using Mmu.Mlh.RestExtensions.Areas.Models;
using Mmu.Mlh.RestExtensions.Areas.Models.Security;
using Mmu.Mlh.RestExtensions.Areas.RestProxies;

namespace Mmu.Mlazh.TfsProxy.DataAccess.Common.Areas.DataModeling.Services
{
    public abstract class TfsRestProxyBase
    {
        private readonly IRestProxy _restProxy;
        private readonly TfsSettings _tfsSettings;

        protected TfsRestProxyBase(
            IRestProxy restProxy,
            ITfsSettingsProvider tfsSettingsProvider)
        {
            _restProxy = restProxy;
            _tfsSettings = tfsSettingsProvider.ProvideTfsSettings();
        }

        public async Task<string> PostAsync(string resourcePath, object payload)
        {
            var str = await _restProxy.PerformCallAsync<string>(
                cb => cb.StartBuilding(_tfsSettings.TfsBaseProjectPath, RestCallMethodType.Post)
                    .WithResourcePath(resourcePath)
                    .WithBody(new RestCallBody(payload, "application/json-patch+json"))
                    .WithSecurity(RestSecurity.CreateBasicAuthentication(string.Empty, _tfsSettings.BasicAuthToken))
                    .Build());

            return str;
        }

        protected async Task<string> GetAsync(string resourcePath)
        {
            var str = await _restProxy.PerformCallAsync<string>(
                cb => cb.StartBuilding(_tfsSettings.TfsBaseProjectPath)
                    .WithResourcePath(resourcePath)
                    .WithSecurity(RestSecurity.CreateBasicAuthentication(string.Empty, _tfsSettings.BasicAuthToken))
                    .Build());

            return str;
        }

        protected async Task<string> PatchAsync(string resourcePath, object payload)
        {
            var str = await _restProxy.PerformCallAsync<string>(
                cb => cb.StartBuilding(_tfsSettings.TfsBaseProjectPath, RestCallMethodType.Patch)
                    .WithResourcePath(resourcePath)
                    .WithBody(new RestCallBody(payload, "application/json-patch+json"))
                    .WithSecurity(RestSecurity.CreateBasicAuthentication(string.Empty, _tfsSettings.BasicAuthToken))
                    .Build());

            return str;
        }
    }
}