using System;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Mlazh.TfsProxy.Application.Areas.Domain.Models
{
    public class WorkItemRelation
    {
        public string RelationTypeDescription { get; }
        public Uri TargetWorkItemUrl { get; }

        public WorkItemRelation(Uri targetWorkItemUrl, string relationTypeDescription)
        {
            Guard.ObjectNotNull(() => targetWorkItemUrl);
            Guard.StringNotNullOrEmpty(() => relationTypeDescription);

            TargetWorkItemUrl = targetWorkItemUrl;
            RelationTypeDescription = relationTypeDescription;
        }
    }
}