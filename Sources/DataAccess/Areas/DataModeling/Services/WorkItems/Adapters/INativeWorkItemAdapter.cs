using System.Collections.Generic;
using Mmu.Mlazh.TfsProxy.DataAccess.Areas.DataModeling.Models.WorkItems;

namespace Mmu.Mlazh.TfsProxy.DataAccess.Areas.DataModeling.Services.WorkItems.Adapters
{
    public interface INativeWorkItemAdapter
    {
        List<NativeWorkItem> AdaptList(string jsonString);

        NativeWorkItem AdaptWorkItem(string jsonString);
    }
}