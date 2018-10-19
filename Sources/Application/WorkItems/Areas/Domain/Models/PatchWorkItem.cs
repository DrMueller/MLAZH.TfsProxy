using System.Collections.Generic;
using Mmu.Mlh.DomainExtensions.Areas.DomainModeling;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Mlazh.TfsProxy.Application.WorkItems.Areas.Domain.Models
{
    public class PatchWorkItem : AggregateRoot<int>
    {
        public IReadOnlyCollection<WorkItemField> Fields { get; }
        public IReadOnlyCollection<WorkItemRelation> Relations { get; }

        public PatchWorkItem(
            int id,
            IReadOnlyCollection<WorkItemRelation> relations,
            IReadOnlyCollection<WorkItemField> fields) : base(id)
        {
            Guard.ObjectNotNull(() => fields);
            Guard.ObjectNotNull(() => relations);

            Fields = fields;
            Relations = relations;
        }
    }
}