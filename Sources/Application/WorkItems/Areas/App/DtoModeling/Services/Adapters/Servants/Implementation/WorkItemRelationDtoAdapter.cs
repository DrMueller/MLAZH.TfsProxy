using System.Collections.Generic;
using System.Linq;
using Mmu.Mlazh.TfsProxy.Application.WorkItems.Areas.App.DtoModeling.Dtos;
using Mmu.Mlazh.TfsProxy.Application.WorkItems.Areas.Domain.Models;

namespace Mmu.Mlazh.TfsProxy.Application.WorkItems.Areas.App.DtoModeling.Services.Adapters.Servants.Implementation
{
    public class WorkItemRelationDtoAdapter : IWorkItemRelationDtoAdapter
    {
        public IReadOnlyCollection<WorkItemRelation> Adapt(IReadOnlyCollection<WorkItemRelationDto> dtos)
        {
            if (dtos == null)
            {
                return new List<WorkItemRelation>();
            }

            return dtos.Select(f => new WorkItemRelation(f.TargetWorkItemId, f.RelationTypeDescription)).ToList();
        }
    }
}