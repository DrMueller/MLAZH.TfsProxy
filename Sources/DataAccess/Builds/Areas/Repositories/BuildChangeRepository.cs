using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mmu.Mlazh.TfsProxy.Application.Builds.Domain.Models;
using Mmu.Mlazh.TfsProxy.Application.Builds.Domain.Repositories;
using Mmu.Mlazh.TfsProxy.DataAccess.Builds.Areas.DataModeling.Models;
using Mmu.Mlazh.TfsProxy.DataAccess.Builds.Areas.DataModeling.Services;
using Mmu.Mlh.Adapters.Areas.Services;

namespace Mmu.Mlazh.TfsProxy.DataAccess.Builds.Areas.Repositories
{
    public class BuildChangeRepository : IBuildChangeRepository
    {
        private readonly IAdapterResolver _adapterResolver;
        private readonly IBuildRestProxy _restProxy;

        public BuildChangeRepository(
            IAdapterResolver adapterResolver,
            IBuildRestProxy restProxy)
        {
            _adapterResolver = adapterResolver;
            _restProxy = restProxy;
        }

        public async Task<IReadOnlyCollection<BuildChange>> LoadByBuildIdAsync(long buildId)
        {
            var nativeBuildChanges = await _restProxy.LoadChangesByBuildIdAsync(buildId);

            if (nativeBuildChanges.Value?.Any() == false)
            {
                return new List<BuildChange>();
            }

            var adapter = _adapterResolver.ResolveByAdapteeTypes<NativeBuildChange, BuildChange>();
            var result = nativeBuildChanges.Value.Select(bc => adapter.Adapt(bc)).ToList();
            return result;
        }
    }
}