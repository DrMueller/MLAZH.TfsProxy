using System.Collections.Generic;

namespace Mmu.Mlazh.TfsProxy.DataAccess.Areas.DataModeling.Models.WorkItems
{
    public class NativeWorkItems
    {
        public int Count { get; set; }
        public List<NativeWorkItem> Value { get; set; }
    }
}