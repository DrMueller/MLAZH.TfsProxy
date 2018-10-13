using Mmu.Mlazh.TfsProxy.Application.Areas.App.Dtos;
using Mmu.Mlazh.TfsProxy.Application.Areas.Domain.Models;

namespace Mmu.Mlazh.TfsProxy.Application.Areas.App.Services.Adapters
{
    public interface IPatchWorkItemDtoAdapter
    {
        PatchWorkItem Adapt(PatchWorkItemDto dto);

        PatchWorkItemDto Adapt(PatchWorkItem model);
    }
}