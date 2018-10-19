using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.Mlazh.TfsProxy.DataAccess.WorkItems.Areas.DataModeling.Models.PatchDocuments;
using Mmu.Mlazh.TfsProxy.DataAccess.WorkItems.Areas.DataModeling.Models.WorkItems;

namespace Mmu.Mlazh.TfsProxy.DataAccess.WorkItems.Areas.DataModeling.Services.WorkItems
{
    public interface IWorkItemRestProxy
    {
        Task<IReadOnlyCollection<NativeWorkItem>> LoadWorkItemsByIdsAsync(params int[] workItemIds);

        Task<NativeWorkItem> PatchWorkItemAsync(int workItemId, IReadOnlyCollection<PatchDocument> patchDocuments);

        Task<NativeWorkItem> PostWorkItemAsync(string workItemTypeName, IReadOnlyCollection<PatchDocument> patchDocuments);
    }
}