using System.Collections.Generic;
using Mmu.Mlazh.TfsProxy.Application.Areas.App.DtoModeling.Dtos;
using Mmu.Mlazh.TfsProxy.Application.Areas.Domain.Models;

namespace Mmu.Mlazh.TfsProxy.Application.Areas.App.DtoModeling.Services.Adapters.Servants
{
    public interface IWorkItemRelationDtoAdapter
    {
        IReadOnlyCollection<WorkItemRelation> Adapt(IReadOnlyCollection<WorkItemRelationDto> dtos);
    }
}