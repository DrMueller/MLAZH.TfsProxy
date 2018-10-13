using System;
using System.Collections.Generic;
using System.Text;
using Mmu.Mlazh.TfsProxy.Application.Areas.App.Dtos;
using Mmu.Mlazh.TfsProxy.Application.Areas.Domain.Models;

namespace Mmu.Mlazh.TfsProxy.Application.Areas.App.Services.Adapters.Servants
{
    public interface IWorkItemRelationDtoAdapter
    {
        IReadOnlyCollection<WorkItemRelation> Adapt(IReadOnlyCollection<WorkItemRelationDto> dtos);
    }
}
