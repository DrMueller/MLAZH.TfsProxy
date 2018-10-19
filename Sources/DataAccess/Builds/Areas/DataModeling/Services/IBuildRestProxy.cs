using System.Threading.Tasks;
using Mmu.Mlazh.TfsProxy.DataAccess.Builds.Areas.DataModeling.Models;

namespace Mmu.Mlazh.TfsProxy.DataAccess.Builds.Areas.DataModeling.Services
{
    public interface IBuildRestProxy
    {
        Task<NativeBuildChanges> LoadChangesByBuildIdAsync(long buildId);
    }
}