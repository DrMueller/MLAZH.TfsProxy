using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.Mlazh.TfsProxy.Application.WorkItems.Areas.App.DtoModeling.Dtos;

namespace Mmu.Mlazh.TfsProxy.Application.WorkItems.Areas.App.DtoModeling.Services
{
    public interface IWorkItemDtoDataService
    {
        Task<IReadOnlyCollection<WorkItemDto>> LoadByIdsAsync(params int[] ids);

        Task<WorkItemDto> PatchAsync(PatchWorkItemDto dto);

        Task<WorkItemDto> PostAsync(PostWorkItemDto dto);
    }
}