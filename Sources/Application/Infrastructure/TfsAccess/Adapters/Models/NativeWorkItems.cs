using System.Collections.Generic;

namespace Mmu.Mlazh.TfsProxy.Application.Infrastructure.TfsAccess.Models
{
    public class NativeWorkItems
    {
        public int Count { get; set; }
        public List<NativeWorkItem> Value { get; set; }
    }
}