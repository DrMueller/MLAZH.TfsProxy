using System.Threading.Tasks;
using Mmu.Mlazh.TfsProxy.Application.Areas.Domain.Models;

namespace Mmu.Mlazh.TfsProxy.Application.Areas.Domain.Repositories
{
    public interface IWorkItemRepository
    {
        Task<WorkItem> LoadByIdAsync(int id);

        Task<WorkItem> PatchAsync(PatchWorkItem patchWorkItem);

        Task<WorkItem> PostAsync(PostWorkItem postWorkItem);
    }
}