using Mmu.Mlazh.TfsProxy.Application.WorkItems.Areas.Domain.Models;

namespace Mmu.Mlazh.TfsProxy.Application.WorkItems.Areas.Domain.Factories
{
    public interface IWorkItemFactory
    {
        WorkItem Create();
    }
}