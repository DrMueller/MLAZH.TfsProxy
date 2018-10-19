using System.Collections.Generic;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Mlazh.TfsProxy.Application.WorkItems.Areas.Domain.Models
{
    public class PostWorkItem
    {
        public IReadOnlyCollection<WorkItemField> Fields { get; }
        public IReadOnlyCollection<WorkItemRelation> Relations { get; }
        public string WorkItemTypeName { get; }

        public PostWorkItem(
            string workItemTypeName,
            IReadOnlyCollection<WorkItemRelation> relations,
            IReadOnlyCollection<WorkItemField> fields)
        {
            Guard.ObjectNotNull(() => workItemTypeName);
            Guard.ObjectNotNull(() => fields);
            Guard.ObjectNotNull(() => relations);

            WorkItemTypeName = workItemTypeName;
            Fields = fields;
            Relations = relations;
        }
    }
}