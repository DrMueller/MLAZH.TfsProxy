using System.Collections.Generic;

namespace Mmu.Mlazh.TfsProxy.Application.WorkItems.Areas.App.DtoModeling.Dtos
{
    public class PostWorkItemDto
    {
        public List<WorkItemFieldDto> Fields { get; set; }
        public List<WorkItemRelationDto> Relations { get; set; }
        public string WorkItemTypeName { get; set; }
    }
}