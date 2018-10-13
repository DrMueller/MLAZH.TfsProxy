using System.Threading.Tasks;
using Mmu.Mlazh.TfsProxy.Application.Areas.App.Dtos;
using Mmu.Mlazh.TfsProxy.Application.Areas.App.Services.Adapters;
using Mmu.Mlazh.TfsProxy.Application.Areas.DataAccess.Repositories;

namespace Mmu.Mlazh.TfsProxy.Application.Areas.App.Services.Implementation
{
    public class WorkItemDtoDataService : IWorkItemDtoDataService
    {
        private readonly IPatchWorkItemDtoAdapter _patchWorkitemDtoAdapter;
        private readonly IWorkItemDtoAdapter _workitemDtoAdapter;
        private readonly IWorkItemRepository _workItemRepository;

        public WorkItemDtoDataService(
            IWorkItemRepository workItemRepository,
            IWorkItemDtoAdapter workitemDtoAdapter,
            IPatchWorkItemDtoAdapter patchWorkitemDtoAdapter)
        {
            _workItemRepository = workItemRepository;
            _workitemDtoAdapter = workitemDtoAdapter;
            _patchWorkitemDtoAdapter = patchWorkitemDtoAdapter;
        }

        public async Task<WorkItemDto> LoadByIdAsync(int id)
        {
            var model = await _workItemRepository.LoadByIdAsync(id);
            return _workitemDtoAdapter.Adapt(model);
        }

        public async Task<WorkItemDto> PatchAsync(PatchWorkItemDto dto)
        {
            var patchWorkitem = _patchWorkitemDtoAdapter.Adapt(dto);
            var returnedWorkitem = await _workItemRepository.PatchAsync(patchWorkitem);
            return _workitemDtoAdapter.Adapt(returnedWorkitem);
        }
    }
}