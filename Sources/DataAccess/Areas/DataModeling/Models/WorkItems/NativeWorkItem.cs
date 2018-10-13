using System.Collections.Generic;

namespace Mmu.Mlazh.TfsProxy.DataAccess.Areas.DataModeling.Models.WorkItems
{
    public class NativeWorkItem
    {
        public List<NativeWorkItemField> Fields { get; set; }
        public int Id { get; set; }
        public List<NativeWorkItemRelation> Relations { get; set; }
        public long Rev { get; set; }
        public string Url { get; set; }
    }
}