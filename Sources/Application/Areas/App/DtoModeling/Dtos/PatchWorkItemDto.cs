using System.Collections.Generic;

namespace Mmu.Mlazh.TfsProxy.Application.Areas.App.DtoModeling.Dtos
{
    public class PatchWorkItemDto
    {
        public List<WorkItemFieldDto> Fields { get; set; }
        public int Id { get; set; }
        public List<WorkItemRelationDto> Relations { get; set; }
    }
}