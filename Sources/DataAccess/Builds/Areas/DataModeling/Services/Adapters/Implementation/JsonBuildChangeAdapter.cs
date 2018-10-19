using Mmu.Mlazh.TfsProxy.DataAccess.Builds.Areas.DataModeling.Models;
using Newtonsoft.Json;

namespace Mmu.Mlazh.TfsProxy.DataAccess.Builds.Areas.DataModeling.Services.Adapters.Implementation
{
    public class JsonBuildChangeAdapter : IJsonBuildChangeAdapter
    {
        public NativeBuildChanges Adapt(string jsonString)
        {
            return JsonConvert.DeserializeObject<NativeBuildChanges>(jsonString);
        }
    }
}