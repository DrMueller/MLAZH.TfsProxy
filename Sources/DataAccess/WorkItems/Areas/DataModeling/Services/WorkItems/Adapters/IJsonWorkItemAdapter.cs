using Mmu.Mlazh.TfsProxy.DataAccess.WorkItems.Areas.DataModeling.Models.WorkItems;

namespace Mmu.Mlazh.TfsProxy.DataAccess.WorkItems.Areas.DataModeling.Services.WorkItems.Adapters
{
    public interface IJsonWorkItemAdapter
    {
        NativeWorkItem AdaptWorkItem(string jsonString);

        NativeWorkItems AdaptWorkItems(string jsonString);
    }
}