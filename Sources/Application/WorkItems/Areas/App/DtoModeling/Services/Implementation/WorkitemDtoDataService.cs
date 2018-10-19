using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mmu.Mlazh.TfsProxy.Application.WorkItems.Areas.App.DtoModeling.Dtos;
using Mmu.Mlazh.TfsProxy.Application.WorkItems.Areas.Domain.Models;
using Mmu.Mlazh.TfsProxy.Application.WorkItems.Areas.Domain.Repositories;
using Mmu.Mlh.ApplicationExtensions.Areas.Adapters.Services;

namespace Mmu.Mlazh.TfsProxy.Application.WorkItems.Areas.App.DtoModeling.Services.Implementation
{
    public class WorkItemDtoDataService : IWorkItemDtoDataService
    {
        private readonly IAdapterResolver _adapterResolver;
        private readonly IWorkItemRepository _workItemRepository;

        public WorkItemDtoDataService(
            IWorkItemRepository workItemRepository,
            IAdapterResolver adapterResolver)
        {
            _workItemRepository = workItemRepository;
            _adapterResolver = adapterResolver;
        }

        public async Task<IReadOnlyCollection<WorkItemDto>> LoadByIdsAsync(params int[] ids)
        {
            var models = await _workItemRepository.LoadByIdsAsync(ids);
            var adapter = _adapterResolver.ResolveByAdapteeTypes<WorkItemDto, WorkItem>();
            return models.Select(model => adapter.Adapt(model)).ToList();
        }

        public async Task<WorkItemDto> PatchAsync(PatchWorkItemDto dto)
        {
            var patchWorkitem = _adapterResolver.ResolveByAdapteeTypes<PatchWorkItemDto, PatchWorkItem>().Adapt(dto);
            var returnedWorkitem = await _workItemRepository.PatchAsync(patchWorkitem);
            return _adapterResolver.ResolveByAdapteeTypes<WorkItemDto, WorkItem>().Adapt(returnedWorkitem);
        }

        public async Task<WorkItemDto> PostAsync(PostWorkItemDto dto)
        {
            var postWorkItem = _adapterResolver.ResolveByAdapteeTypes<PostWorkItemDto, PostWorkItem>().Adapt(dto);
            var returnedWorkItem = await _workItemRepository.PostAsync(postWorkItem);
            return _adapterResolver.ResolveByAdapteeTypes<WorkItemDto, WorkItem>().Adapt(returnedWorkItem);
        }
    }
}