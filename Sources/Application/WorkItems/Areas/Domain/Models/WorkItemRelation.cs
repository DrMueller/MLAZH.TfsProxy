using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Mlazh.TfsProxy.Application.WorkItems.Areas.Domain.Models
{
    public class WorkItemRelation
    {
        public string RelationTypeDescription { get; }
        public int TargetWorkItemId { get; }

        public WorkItemRelation(int targetWorkItemId, string relationTypeDescription)
        {
            Guard.StringNotNullOrEmpty(() => relationTypeDescription);

            TargetWorkItemId = targetWorkItemId;
            RelationTypeDescription = relationTypeDescription;
        }
    }
}