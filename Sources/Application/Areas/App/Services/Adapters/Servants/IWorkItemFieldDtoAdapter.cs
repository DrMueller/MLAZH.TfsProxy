using System.Collections.Generic;
using Mmu.Mlazh.TfsProxy.Application.Areas.App.Dtos;
using Mmu.Mlazh.TfsProxy.Application.Areas.Domain.Models;

namespace Mmu.Mlazh.TfsProxy.Application.Areas.App.Services.Adapters.Servants
{
    public interface IWorkItemFieldDtoAdapter
    {
        IReadOnlyCollection<WorkItemField> Adapt(IReadOnlyCollection<WorkItemFieldDto> dtos);
    }
}