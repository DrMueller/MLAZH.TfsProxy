using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.Mlazh.TfsProxy.Application.Areas.DataAccess.WebModels.Models;
using Mmu.Mlazh.TfsProxy.Application.Infrastructure.TfsAccess.Models;

namespace Mmu.Mlazh.TfsProxy.Application.Infrastructure.TfsAccess.Services
{
    public interface ITfsWorkItemRestProxy
    {
        Task<NativeWorkItem> PatchAsync(int workItemId, IReadOnlyCollection<PatchDocument> patchDocuments);

        Task<NativeWorkItem> LoadByIdAsync(int workItemId);
    }
}