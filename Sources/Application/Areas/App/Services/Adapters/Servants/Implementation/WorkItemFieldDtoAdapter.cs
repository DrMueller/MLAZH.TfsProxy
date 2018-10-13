using System.Collections.Generic;
using System.Linq;
using Mmu.Mlazh.TfsProxy.Application.Areas.App.Dtos;
using Mmu.Mlazh.TfsProxy.Application.Areas.Domain.Models;

namespace Mmu.Mlazh.TfsProxy.Application.Areas.App.Services.Adapters.Servants.Implementation
{
    public class WorkItemFieldDtoAdapter : IWorkItemFieldDtoAdapter
    {
        public IReadOnlyCollection<WorkItemField> Adapt(IReadOnlyCollection<WorkItemFieldDto> dtos)
        {
            if (dtos == null)
            {
                return new List<WorkItemField>();
            }

            return dtos.Select(f => new WorkItemField(f.Name, f.Value)).ToList();
        }
    }
}