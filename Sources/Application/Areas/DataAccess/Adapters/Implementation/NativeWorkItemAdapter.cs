using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mmu.Mlazh.TfsProxy.Application.Areas.Domain.Models;
using Mmu.Mlazh.TfsProxy.Application.Infrastructure.TfsAccess.Models;

namespace Mmu.Mlazh.TfsProxy.Application.Areas.DataAccess.Adapters.Implementation
{
    public class NativeWorkItemAdapter : INativeWorkItemAdapter
    {
        public WorkItem Adapt(NativeWorkItem nativeWorkItem)
        {
            return new WorkItem(
                nativeWorkItem.Id,
                nativeWorkItem.Rev,
                new Uri(nativeWorkItem.Url),
                AdaptRelations(nativeWorkItem.Relations),
                AdaptFields(nativeWorkItem.Fields));

        }

        private static List<WorkItemRelation> AdaptRelations(IEnumerable<NativeWorkItemRelation> nativeRelations)
        {
            return nativeRelations.Select(f => new WorkItemRelation(new Uri(f.Url), f.Rel)).ToList();
        }

        private static List<WorkItemField> AdaptFields(IEnumerable<NativeWorkItemField> nativeFields)
        {
            return nativeFields.Select(f => new WorkItemField(f.Namespace, f.Value)).ToList();
        }
    }
}
