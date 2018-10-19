using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mmu.Mlazh.TfsProxy.Application.Builds.App.DtoModeling.Dtos;
using Mmu.Mlazh.TfsProxy.Application.Builds.Domain.Models;
using Mmu.Mlazh.TfsProxy.Application.Builds.Domain.Repositories;
using Mmu.Mlh.ApplicationExtensions.Areas.Adapters.Services;

namespace Mmu.Mlazh.TfsProxy.Application.Builds.App.DtoModeling.Services.Implementation
{
    public class BuildChangeDtoDataService : IBuildChangeDtoDataService
    {
        private readonly IAdapterResolver _adapterResolver;
        private readonly IBuildChangeRepository _buildChangeRepository;

        public BuildChangeDtoDataService(IAdapterResolver adapterResolver, IBuildChangeRepository buildChangeRepository)
        {
            _adapterResolver = adapterResolver;
            _buildChangeRepository = buildChangeRepository;
        }

        public async Task<IReadOnlyCollection<BuildChangeDto>> LoadByBuildIdAsync(long buildId)
        {
            var buildChangeDtoAdapter = _adapterResolver.ResolveByAdapteeTypes<BuildChangeDto, BuildChange>();
            var buildChanges = await _buildChangeRepository.LoadByBuildIdAsync(buildId);
            return buildChanges.Select(bc => buildChangeDtoAdapter.Adapt(bc)).ToList();
        }
    }
}