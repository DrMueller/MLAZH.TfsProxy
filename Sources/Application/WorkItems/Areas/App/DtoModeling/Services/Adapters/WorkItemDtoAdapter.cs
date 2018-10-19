using System;
using AutoMapper;
using Mmu.Mlazh.TfsProxy.Application.WorkItems.Areas.App.DtoModeling.Dtos;
using Mmu.Mlazh.TfsProxy.Application.WorkItems.Areas.App.DtoModeling.Services.Adapters.Servants;
using Mmu.Mlazh.TfsProxy.Application.WorkItems.Areas.Domain.Models;
using Mmu.Mlh.ApplicationExtensions.Areas.Adapters.Services;

namespace Mmu.Mlazh.TfsProxy.Application.WorkItems.Areas.App.DtoModeling.Services.Adapters
{
    public class WorkItemDtoAdapter : AdapterBase<WorkItemDto, WorkItem>
    {
        private readonly IAdapterResolver _adapterResolver;

        public WorkItemDtoAdapter(IMapper mapper, IAdapterResolver adapterResolver) : base(mapper)
        {
            _adapterResolver = adapterResolver;
        }

        public override WorkItem Adapt(WorkItemDto dto)
        {
            var relationAdapter = _adapterResolver.ResolveByAdapterType<IWorkItemRelationDtoAdapter>();
            var fieldAdapter = _adapterResolver.ResolveByAdapterType<IWorkItemFieldDtoAdapter>();

            return new WorkItem(
                dto.Id,
                dto.Revision,
                new Uri(dto.Url),
                relationAdapter.Adapt(dto.Relations),
                fieldAdapter.Adapt(dto.Fields));
        }
    }
}