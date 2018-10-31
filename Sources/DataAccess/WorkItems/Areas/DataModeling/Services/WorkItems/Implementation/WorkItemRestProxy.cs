using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.Mlazh.TfsProxy.Application.Common.Infrastructure.Settings.Providers;
using Mmu.Mlazh.TfsProxy.DataAccess.Common.Areas.DataModeling.Services;
using Mmu.Mlazh.TfsProxy.DataAccess.WorkItems.Areas.DataModeling.Models.PatchDocuments;
using Mmu.Mlazh.TfsProxy.DataAccess.WorkItems.Areas.DataModeling.Models.WorkItems;
using Mmu.Mlazh.TfsProxy.DataAccess.WorkItems.Areas.DataModeling.Services.WorkItems.Adapters;
using Mmu.Mlh.RestExtensions.Areas.RestProxies;

namespace Mmu.Mlazh.TfsProxy.DataAccess.WorkItems.Areas.DataModeling.Services.WorkItems.Implementation
{
    public class WorkItemRestProxy : TfsRestProxyBase, IWorkItemRestProxy
    {
        private readonly IJsonWorkItemAdapter _jsonWorkItemAdapter;

        public WorkItemRestProxy(
            IRestProxy restProxy,
            ITfsSettingsProvider tfsSettingsProvider,
            IJsonWorkItemAdapter jsonWorkItemAdapter)
            : base(restProxy, tfsSettingsProvider)
        {
            _jsonWorkItemAdapter = jsonWorkItemAdapter;
        }

        public async Task<IReadOnlyCollection<NativeWorkItem>> LoadWorkItemsByIdsAsync(params int[] workItemIds)
        {
            var workItemList = string.Join(",", workItemIds);
            var resourcePath = $"_apis/wit/workitems?ids={workItemList}&$expand=relations";
            var str = await GetAsync(resourcePath);
            return _jsonWorkItemAdapter.AdaptWorkItems(str).Value;
        }

        public async Task<NativeWorkItem> PatchWorkItemAsync(int workItemId, IReadOnlyCollection<PatchDocument> patchDocuments)
        {
            var resourcePath = $"/_apis/wit/workitems/{workItemId}?api-version=4.1";
            var str = await PatchAsync(resourcePath, patchDocuments);
            return _jsonWorkItemAdapter.AdaptWorkItem(str);
        }

        public async Task<NativeWorkItem> PostWorkItemAsync(string workItemTypeName, IReadOnlyCollection<PatchDocument> patchDocuments)
        {
            var resourcePath = $"/_apis/wit/workitems/${workItemTypeName}?api-version=4.1";
            var str = await PostAsync(resourcePath, patchDocuments);
            return _jsonWorkItemAdapter.AdaptWorkItem(str);
        }
    }
}