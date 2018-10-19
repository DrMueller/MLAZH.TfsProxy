using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.Mlazh.TfsProxy.Application.Builds.Domain.Models;

namespace Mmu.Mlazh.TfsProxy.Application.Builds.Domain.Repositories
{
    public interface IBuildChangeRepository
    {
        Task<IReadOnlyCollection<BuildChange>> LoadByBuildIdAsync(long buildId);
    }
}