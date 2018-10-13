using Mmu.Mlazh.TfsProxy.Application.Areas.Domain.Models;
using Mmu.Mlazh.TfsProxy.Application.Infrastructure.TfsAccess.Models;

namespace Mmu.Mlazh.TfsProxy.Application.Areas.DataAccess.Adapters
{
    public interface INativeWorkItemAdapter
    {
        WorkItem Adapt(NativeWorkItem nativeWorkItem);
    }
}