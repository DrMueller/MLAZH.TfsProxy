using System;
using System.Linq;
using Mmu.Mlazh.TfsProxy.Application.Areas.Domain.Models;
using Mmu.Mlazh.TfsProxy.DataAccess.Areas.DataModeling.Models.WorkItems;

namespace Mmu.Mlazh.TfsProxy.DataAccess.Areas.Repositories.Adapters.Implementation
{
    public class WorkItemAdapter : IWorkItemAdapter
    {
        public WorkItem Adapt(NativeWorkItem nativeWorkItem)
        {
            return new WorkItem(
                nativeWorkItem.Id,
                nativeWorkItem.Rev,
                new Uri(nativeWorkItem.Url),
                nativeWorkItem.Relations.Select(f => new WorkItemRelation(new Uri(f.Url), f.Rel)).ToList(),
                nativeWorkItem.Fields.Select(f => new WorkItemField(f.Namespace, f.Value)).ToList());
        }
    }
}