﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mmu.Mlazh.TfsProxy.Application.Infrastructure.Settings.TfsSettings.Models;
using Mmu.Mlazh.TfsProxy.Application.Infrastructure.Settings.TfsSettings.Services;
using Mmu.Mlazh.TfsProxy.DataAccess.Areas.DataModeling.Models.PatchDocuments;
using Mmu.Mlazh.TfsProxy.DataAccess.Areas.DataModeling.Models.WorkItems;
using Mmu.Mlazh.TfsProxy.DataAccess.Areas.DataModeling.Services.WorkItems.Adapters;
using Mmu.Mlh.RestExtensions.Areas.Models;
using Mmu.Mlh.RestExtensions.Areas.Models.Security;
using Mmu.Mlh.RestExtensions.Areas.RestProxies;

namespace Mmu.Mlazh.TfsProxy.DataAccess.Areas.DataModeling.Services.WorkItems.Implementation
{
    public class TfsWorkItemRestProxy : ITfsWorkItemRestProxy
    {
        private readonly INativeWorkItemAdapter _nativeWorkItemAdapter;
        private readonly IRestProxy _restProxy;
        private readonly TfsSettings _tfsSettings;

        public TfsWorkItemRestProxy(
            IRestProxy restProxy,
            ITfsSettingsProvider tfsSettingsProvider,
            INativeWorkItemAdapter nativeWorkItemAdapter)
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
            var resourcePath = $"/_apis/wit/workitems/{workItemId}?api-version=4.1";

            var str = await _restProxy.PerformCallAsync<string>(
                cb => cb.StartBuilding(_tfsSettings.TfsBaseProjectPath, RestCallMethodType.Patch)
                    .WithResourcePath(resourcePath)
                    .WithBody(new RestCallBody(patchDocuments, "application/json-patch+json"))
                    .WithSecurity(RestSecurity.CreateBasicAuthentication(string.Empty, _tfsSettings.BasicAuthToken))
                    .Build());

            return _nativeWorkItemAdapter.AdaptWorkItem(str);
        }

        public async Task<NativeWorkItem> PostASync(string workItemTypeName, IReadOnlyCollection<PatchDocument> patchDocuments)
        {
            var resourcePath = $"/_apis/wit/workitems/${workItemTypeName}?api-version=4.1";

            var str = await _restProxy.PerformCallAsync<string>(
                cb => cb.StartBuilding(_tfsSettings.TfsBaseProjectPath, RestCallMethodType.Post)
                    .WithResourcePath(resourcePath)
                    .WithBody(new RestCallBody(patchDocuments, "application/json-patch+json"))
                    .WithSecurity(RestSecurity.CreateBasicAuthentication(string.Empty, _tfsSettings.BasicAuthToken))
                    .Build());

            return _nativeWorkItemAdapter.AdaptWorkItem(str);
        }

        ////private async Task ListWorkItemRelationTypes()
        ////{
        ////    const string ResourcePath = "_apis/wit/workitemrelationtypes?api-version=4.1";

        ////    var str = await _restProxy.PerformCallAsync<string>(
        ////        cb => cb.StartBuilding(_tfsSettings.TfsBaseOrganisationPath)
        ////            .WithResourcePath(ResourcePath)
        ////            .WithSecurity(RestSecurity.CreateBasicAuthentication(string.Empty, _tfsSettings.BasicAuthToken))
        ////            .Build());

        ////    Debug.WriteLine(str);
        ////}
    }
}