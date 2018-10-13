using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.Mlazh.TfsProxy.Application.Areas.DataAccess.WebModels.Models;
using Mmu.Mlazh.TfsProxy.Application.Infrastructure.TfsAccess.Adapters;
using Mmu.Mlazh.TfsProxy.Application.Infrastructure.TfsAccess.Models;
using Mmu.Mlazh.TfsProxy.Application.Infrastructure.TfsAccess.Settings.Models;
using Mmu.Mlazh.TfsProxy.Application.Infrastructure.TfsAccess.Settings.Services;
using Mmu.Mlh.ApplicationExtensions.Areas.Rest.Models;
using Mmu.Mlh.ApplicationExtensions.Areas.Rest.Models.Security;
using Mmu.Mlh.ApplicationExtensions.Areas.Rest.RestProxies;
using System.Linq;

namespace Mmu.Mlazh.TfsProxy.Application.Infrastructure.TfsAccess.Services.Implementation
{
    public class TfsWorkItemRestProxy : ITfsWorkItemRestProxy
    {
        private readonly IRestProxy _restProxy;
        private readonly IJsonAdapter _nativeWorkItemAdapter;
        private readonly TfsSettings _tfsSettings;

        public TfsWorkItemRestProxy(
            IRestProxy restProxy,
            ITfsSettingsProvider tfsSettingsProvider,
            IJsonAdapter nativeWorkItemAdapter)
        {
            _restProxy = restProxy;
            _nativeWorkItemAdapter = nativeWorkItemAdapter;
            _tfsSettings = tfsSettingsProvider.ProvideTfsSettings();
        }

        public async Task<NativeWorkItem> LoadByIdAsync(int workItemId)
        {
            var resourcePath = $"_apis/wit/workitems?ids={workItemId}&$expand=relations";

            var str = await _restProxy.PerformCallAsync<string>(
                cb => cb.StartBuilding(_tfsSettings.TfsBaseProjectPath)
                    .WithResourcePath(resourcePath)
                    .WithSecurity(RestSecurity.CreateBasicAuthentication(string.Empty, _tfsSettings.BasicAuthToken))
                    .Build());

            return _nativeWorkItemAdapter.AdaptList(str).FirstOrDefault();
        }

        public async Task<NativeWorkItem> PatchAsync(int workItemId, IReadOnlyCollection<PatchDocument> patchDocuments)
        {
            var resourcePath = $"_apis/wit/workitems/{workItemId}?api-version=4.1";

            var str = await _restProxy.PerformCallAsync<string>(
                cb => cb.StartBuilding(_tfsSettings.TfsBaseProjectPath, RestCallMethodType.Patch)
                    .WithResourcePath(resourcePath)
                    .WithBody(new RestCallBody(patchDocuments, "application/json-patch+json"))
                    .WithSecurity(RestSecurity.CreateBasicAuthentication(string.Empty, _tfsSettings.BasicAuthToken))
                    .Build());

            return _nativeWorkItemAdapter.AdaptWorkItem(str);
        }
    }
}