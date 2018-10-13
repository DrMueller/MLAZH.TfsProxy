using System.Threading.Tasks;
using Mmu.Mlazh.TfsProxy.Application.Areas.App.Dtos;

namespace Mmu.Mlazh.TfsProxy.Application.Areas.App.Services
{
    public interface IWorkItemDtoDataService
    {
        Task<WorkItemDto> LoadByIdAsync(int id);

        Task<WorkItemDto> PatchAsync(PatchWorkItemDto dto);
    }
}