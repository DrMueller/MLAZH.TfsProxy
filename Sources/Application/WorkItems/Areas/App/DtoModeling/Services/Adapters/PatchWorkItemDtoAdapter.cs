using AutoMapper;
using Mmu.Mlazh.TfsProxy.Application.WorkItems.Areas.App.DtoModeling.Dtos;
using Mmu.Mlazh.TfsProxy.Application.WorkItems.Areas.App.DtoModeling.Services.Adapters.Servants;
using Mmu.Mlazh.TfsProxy.Application.WorkItems.Areas.Domain.Models;
using Mmu.Mlh.ApplicationExtensions.Areas.Adapters.Services;

namespace Mmu.Mlazh.TfsProxy.Application.WorkItems.Areas.App.DtoModeling.Services.Adapters
{
    public class PatchWorkItemDtoAdapter : AdapterBase<PatchWorkItemDto, PatchWorkItem>
    {
        private readonly IAdapterResolver _adapterResolver;

        public PatchWorkItemDtoAdapter(IMapper mapper, IAdapterResolver adapterResolver) : base(mapper)
        {
            _adapterResolver = adapterResolver;
        }

        public override PatchWorkItem Adapt(PatchWorkItemDto dto)
        {
            var relationAdapter = _adapterResolver.ResolveByAdapterType<IWorkItemRelationDtoAdapter>();
            var fieldAdapter = _adapterResolver.ResolveByAdapterType<IWorkItemFieldDtoAdapter>();

            return new PatchWorkItem(
                dto.Id,
                relationAdapter.Adapt(dto.Relations),
                fieldAdapter.Adapt(dto.Fields));
        }
    }
}