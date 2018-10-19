using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.Mlazh.TfsProxy.Application.Builds.App.DtoModeling.Dtos;

namespace Mmu.Mlazh.TfsProxy.Application.Builds.App.DtoModeling.Services
{
    public interface IBuildChangeDtoDataService
    {
        Task<IReadOnlyCollection<BuildChangeDto>> LoadByBuildIdAsync(long buildId);
    }
}