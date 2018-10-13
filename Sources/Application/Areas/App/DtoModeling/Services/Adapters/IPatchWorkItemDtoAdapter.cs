using Mmu.Mlazh.TfsProxy.Application.Areas.App.DtoModeling.Dtos;
using Mmu.Mlazh.TfsProxy.Application.Areas.Domain.Models;

namespace Mmu.Mlazh.TfsProxy.Application.Areas.App.DtoModeling.Services.Adapters
{
    public interface IPatchWorkItemDtoAdapter
    {
        PatchWorkItem Adapt(PatchWorkItemDto dto);

        PatchWorkItemDto Adapt(PatchWorkItem model);
    }
}