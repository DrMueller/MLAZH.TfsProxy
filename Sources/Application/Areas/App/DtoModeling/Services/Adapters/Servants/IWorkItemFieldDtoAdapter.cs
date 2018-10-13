using System.Collections.Generic;
using Mmu.Mlazh.TfsProxy.Application.Areas.App.DtoModeling.Dtos;
using Mmu.Mlazh.TfsProxy.Application.Areas.Domain.Models;

namespace Mmu.Mlazh.TfsProxy.Application.Areas.App.DtoModeling.Services.Adapters.Servants
{
    public interface IWorkItemFieldDtoAdapter
    {
        IReadOnlyCollection<WorkItemField> Adapt(IReadOnlyCollection<WorkItemFieldDto> dtos);
    }
}