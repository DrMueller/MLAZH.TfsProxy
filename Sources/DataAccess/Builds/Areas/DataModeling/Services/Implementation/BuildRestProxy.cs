using System.Threading.Tasks;
using Mmu.Mlazh.TfsProxy.Application.Common.Infrastructure.Settings.TfsSettings.Services;
using Mmu.Mlazh.TfsProxy.DataAccess.Builds.Areas.DataModeling.Models;
using Mmu.Mlazh.TfsProxy.DataAccess.Builds.Areas.DataModeling.Services.Adapters;
using Mmu.Mlazh.TfsProxy.DataAccess.Common.Areas.DataModeling.Services;
using Mmu.Mlh.RestExtensions.Areas.RestProxies;

namespace Mmu.Mlazh.TfsProxy.DataAccess.Builds.Areas.DataModeling.Services.Implementation
{
    public class BuildRestProxy : TfsRestProxyBase, IBuildRestProxy
    {
        private readonly IJsonBuildChangeAdapter _jsonBuildChangeAdapter;

        public BuildRestProxy(
            IRestProxy restProxy,
            ITfsSettingsProvider tfsSettingsProvider,
            IJsonBuildChangeAdapter jsonBuildChangeAdapter) : base(restProxy, tfsSettingsProvider)
        {
            _jsonBuildChangeAdapter = jsonBuildChangeAdapter;
        }

        public async Task<NativeBuildChanges> LoadChangesByBuildIdAsync(long buildId)
        {
            var resourcePath = $"_apis/build/builds/{buildId}/changes?api-version=4.1";
            var str = await GetAsync(resourcePath);
            return _jsonBuildChangeAdapter.Adapt(str);
        }
    }
}