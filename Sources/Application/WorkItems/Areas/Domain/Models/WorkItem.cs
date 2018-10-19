using System;
using System.Collections.Generic;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Mlazh.TfsProxy.Application.WorkItems.Areas.Domain.Models
{
    public class WorkItem
    {
        public IReadOnlyCollection<WorkItemField> Fields { get; }
        public int Id { get; }
        public IReadOnlyCollection<WorkItemRelation> Relations { get; }
        public long Revision { get; }
        public Uri Url { get; }

        public WorkItem(
            int id,
            long revision,
            Uri url,
            IReadOnlyCollection<WorkItemRelation> relations,
            IReadOnlyCollection<WorkItemField> fields)
        {
            Guard.ObjectNotNull(() => relations);
            Guard.ObjectNotNull(() => fields);

            Id = id;
            Revision = revision;
            Url = url;
            Relations = relations;
            Fields = fields;
        }
    }
}