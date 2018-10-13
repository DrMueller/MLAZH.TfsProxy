using System;
using AutoMapper;
using Mmu.Mlazh.TfsProxy.Application.Areas.App.DtoModeling.Dtos;
using Mmu.Mlazh.TfsProxy.Application.Areas.App.DtoModeling.Services.Adapters.Servants;
using Mmu.Mlazh.TfsProxy.Application.Areas.Domain.Models;

namespace Mmu.Mlazh.TfsProxy.Application.Areas.App.DtoModeling.Services.Adapters.Implementation
{
    public class WorkItemDtoAdapter : IWorkItemDtoAdapter
    {
        private readonly IWorkItemFieldDtoAdapter _fieldAdapter;
        private readonly IMapper _mapper;
        private readonly IWorkItemRelationDtoAdapter _relationAdapter;

        public WorkItemDtoAdapter(
            IMapper mapper,
            IWorkItemFieldDtoAdapter fieldAdapter,
            IWorkItemRelationDtoAdapter relationAdapter)
        {
            _fieldAdapter = fieldAdapter;
            _relationAdapter = relationAdapter;
            _mapper = mapper;
        }

        public WorkItem Adapt(WorkItemDto dto)
        {
            return new WorkItem(
                dto.Id,
                dto.Revision,
                new Uri(dto.Url),
                _relationAdapter.Adapt(dto.Relations),
                _fieldAdapter.Adapt(dto.Fields)
            );
        }

        public WorkItemDto Adapt(WorkItem model)
        {
            return _mapper.Map<WorkItemDto>(model);
        }
    }
}