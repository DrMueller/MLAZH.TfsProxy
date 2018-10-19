using AutoMapper;
using Mmu.Mlazh.TfsProxy.Application.WorkItems.Areas.App.DtoModeling.Dtos;
using Mmu.Mlazh.TfsProxy.Application.WorkItems.Areas.App.DtoModeling.Services.Adapters.Servants;
using Mmu.Mlazh.TfsProxy.Application.WorkItems.Areas.Domain.Models;
using Mmu.Mlh.ApplicationExtensions.Areas.Adapters.Services;

namespace Mmu.Mlazh.TfsProxy.Application.WorkItems.Areas.App.DtoModeling.Services.Adapters
{
    public class PostWorkItemDtoAdapter : AdapterBase<PostWorkItemDto, PostWorkItem>
    {
        private readonly IAdapterResolver _adapterResolver;

        public PostWorkItemDtoAdapter(IMapper mapper, IAdapterResolver adapterResolver) : base(mapper)
        {
            _adapterResolver = adapterResolver;
        }

        public override PostWorkItem Adapt(PostWorkItemDto dto)
        {
            var relationAdapter = _adapterResolver.ResolveByAdapterType<IWorkItemRelationDtoAdapter>();
            var fieldAdapter = _adapterResolver.ResolveByAdapterType<IWorkItemFieldDtoAdapter>();

            return new PostWorkItem(
                dto.WorkItemTypeName,
                relationAdapter.Adapt(dto.Relations),
                fieldAdapter.Adapt(dto.Fields));
        }
    }
}