using System.Threading.Tasks;
using Mmu.Mlazh.TfsProxy.Application.Areas.App.DtoModeling.Dtos;

namespace Mmu.Mlazh.TfsProxy.Application.Areas.App.DtoModeling.Services
{
    public interface IWorkItemDtoDataService
    {
        Task<WorkItemDto> LoadByIdAsync(int id);

        Task<WorkItemDto> PatchAsync(PatchWorkItemDto dto);
    }
}