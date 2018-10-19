using System.Collections.Generic;

namespace Mmu.Mlazh.TfsProxy.DataAccess.Builds.Areas.DataModeling.Models
{
    public class NativeBuildChanges
    {
        public int Count { get; set; }
        public List<NativeBuildChange> Value { get; set; }
    }
}