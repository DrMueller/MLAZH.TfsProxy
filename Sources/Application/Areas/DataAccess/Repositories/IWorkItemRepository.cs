using System.Threading.Tasks;
using Mmu.Mlazh.TfsProxy.Application.Areas.Domain.Models;

namespace Mmu.Mlazh.TfsProxy.Application.Areas.DataAccess.Repositories
{
    public interface IWorkItemRepository
    {
        Task<WorkItem> LoadByIdAsync(int id);

        Task<WorkItem> PatchAsync(PatchWorkItem patchWorkItem);
    }
}