using System;
using System.Collections.Generic;
using System.Linq;
using Mmu.Mlazh.TfsProxy.Application.Areas.App.Dtos;
using Mmu.Mlazh.TfsProxy.Application.Areas.Domain.Models;

namespace Mmu.Mlazh.TfsProxy.Application.Areas.App.Services.Adapters.Servants.Implementation
{
    public class WorkItemRelationDtoAdapter : IWorkItemRelationDtoAdapter
    {
        public IReadOnlyCollection<WorkItemRelation> Adapt(IReadOnlyCollection<WorkItemRelationDto> dtos)
        {
            if (dtos == null)
            {
                return new List<WorkItemRelation>();
            }

            return dtos.Select(f => new WorkItemRelation(new Uri(f.TargetWorkItemUrl), f.RelationTypeDescription)).ToList();
        }
    }
}