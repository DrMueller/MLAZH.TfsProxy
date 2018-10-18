using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.Mlazh.TfsProxy.DataAccess.Areas.DataModeling.Models.PatchDocuments;
using Mmu.Mlazh.TfsProxy.DataAccess.Areas.DataModeling.Models.WorkItems;

namespace Mmu.Mlazh.TfsProxy.DataAccess.Areas.DataModeling.Services.WorkItems
{
    public interface ITfsWorkItemRestProxy
    {
        Task<NativeWorkItem> LoadByIdAsync(int workItemId);

        Task<NativeWorkItem> PatchAsync(int workItemId, IReadOnlyCollection<PatchDocument> patchDocuments);

        Task<NativeWorkItem> PostASync(string workItemTypeName, IReadOnlyCollection<PatchDocument> patchDocuments);
    }
}