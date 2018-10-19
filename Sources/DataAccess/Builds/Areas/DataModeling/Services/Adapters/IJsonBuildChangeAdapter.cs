using Mmu.Mlazh.TfsProxy.DataAccess.Builds.Areas.DataModeling.Models;

namespace Mmu.Mlazh.TfsProxy.DataAccess.Builds.Areas.DataModeling.Services.Adapters
{
    public interface IJsonBuildChangeAdapter
    {
        NativeBuildChanges Adapt(string jsonString);
    }
}