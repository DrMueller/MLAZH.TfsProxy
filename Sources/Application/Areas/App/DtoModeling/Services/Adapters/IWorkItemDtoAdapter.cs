using Mmu.Mlazh.TfsProxy.Application.Areas.App.DtoModeling.Dtos;
using Mmu.Mlazh.TfsProxy.Application.Areas.Domain.Models;

namespace Mmu.Mlazh.TfsProxy.Application.Areas.App.DtoModeling.Services.Adapters
{
    public interface IWorkItemDtoAdapter
    {
        WorkItem Adapt(WorkItemDto dto);

        WorkItemDto Adapt(WorkItem model);
    }
}