using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.Mlazh.TfsProxy.Application.WorkItems.Areas.Domain.Models;

namespace Mmu.Mlazh.TfsProxy.Application.WorkItems.Areas.Domain.Repositories
{
    public interface IWorkItemRepository
    {
        Task<IReadOnlyCollection<WorkItem>> LoadByIdsAsync(params int[] ids);

        Task<WorkItem> PatchAsync(PatchWorkItem patchWorkItem);

        Task<WorkItem> PostAsync(PostWorkItem postWorkItem);
    }
}