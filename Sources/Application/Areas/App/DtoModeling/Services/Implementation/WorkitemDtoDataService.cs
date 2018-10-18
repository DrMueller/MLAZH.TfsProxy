using System.Threading.Tasks;
using Mmu.Mlazh.TfsProxy.Application.Areas.App.DtoModeling.Dtos;
using Mmu.Mlazh.TfsProxy.Application.Areas.Domain.Models;
using Mmu.Mlazh.TfsProxy.Application.Areas.Domain.Repositories;
using Mmu.Mlh.ApplicationExtensions.Areas.Adapters.Services;

namespace Mmu.Mlazh.TfsProxy.Application.Areas.App.DtoModeling.Services.Implementation
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

        public async Task<WorkItemDto> LoadByIdAsync(int id)
        {
            var model = await _workItemRepository.LoadByIdAsync(id);
            return _adapterResolver.ResolveByAdapteeTypes<WorkItemDto, WorkItem>().Adapt(model);
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