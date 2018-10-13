using Mmu.Mlazh.TfsProxy.Application.Areas.Domain.Models;
using Mmu.Mlazh.TfsProxy.DataAccess.Areas.DataModeling.Models.WorkItems;

namespace Mmu.Mlazh.TfsProxy.DataAccess.Areas.Repositories.Adapters
{
    public interface IWorkItemAdapter
    {
        WorkItem Adapt(NativeWorkItem nativeWorkItem);
    }
}