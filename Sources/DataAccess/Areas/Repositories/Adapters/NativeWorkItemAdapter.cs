using System;
using System.Linq;
using AutoMapper;
using Mmu.Mlazh.TfsProxy.Application.Areas.Domain.Models;
using Mmu.Mlazh.TfsProxy.DataAccess.Areas.DataModeling.Models.WorkItems;
using Mmu.Mlh.ApplicationExtensions.Areas.Adapters.Services;

namespace Mmu.Mlazh.TfsProxy.DataAccess.Areas.Repositories.Adapters
{
    public class NativeWorkItemAdapter : AdapterBase<NativeWorkItem, WorkItem>
    {
        public NativeWorkItemAdapter(IMapper mapper) : base(mapper)
        {
        }

        public override WorkItem Adapt(NativeWorkItem nativeWorkItem)
        {
            return new WorkItem(
                nativeWorkItem.Id,
                nativeWorkItem.Rev,
                new Uri(nativeWorkItem.Url),
                nativeWorkItem.Relations.Select(f => new WorkItemRelation(ParseTargetWorkItemId(f.Url), f.Rel)).ToList(),
                nativeWorkItem.Fields.Select(f => new WorkItemField(f.Namespace, f.Value)).ToList());
        }

        private static int ParseTargetWorkItemId(string targetPath)
        {
            var idPart = targetPath.Split('/').Last();
            return int.Parse(idPart);
        }
    }
}