using System;
using System.Linq;
using AutoMapper;
using Mmu.Mlazh.TfsProxy.Application.Areas.App.Dtos;
using Mmu.Mlazh.TfsProxy.Application.Areas.App.Services.Adapters.Servants;
using Mmu.Mlazh.TfsProxy.Application.Areas.Domain.Models;

namespace Mmu.Mlazh.TfsProxy.Application.Areas.App.Services.Adapters.Implementation
{
    public class PatchWorkItemDtoAdapter : IPatchWorkItemDtoAdapter
    {
        private readonly IMapper _mapper;
        private readonly IWorkItemFieldDtoAdapter _fieldAdapter;
        private readonly IWorkItemRelationDtoAdapter _relationAdapter;

        public PatchWorkItemDtoAdapter(
            IMapper mapper,
            IWorkItemFieldDtoAdapter fieldAdapter,
            IWorkItemRelationDtoAdapter relationAdapter)
        {
            _mapper = mapper;
            _fieldAdapter = fieldAdapter;
            _relationAdapter = relationAdapter;
        }

        public PatchWorkItem Adapt(PatchWorkItemDto dto)
        {
            return new PatchWorkItem(
                dto.Id,
                _relationAdapter.Adapt(dto.Relations),
                _fieldAdapter.Adapt(dto.Fields));
        }

        public PatchWorkItemDto Adapt(PatchWorkItem model)
        {
            return _mapper.Map<PatchWorkItemDto>(model);
        }
    }
}