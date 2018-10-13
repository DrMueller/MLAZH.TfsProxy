using System.Collections.Generic;

namespace Mmu.Mlazh.TfsProxy.Application.Areas.App.DtoModeling.Dtos
{
    public class WorkItemDto
    {
        public List<WorkItemFieldDto> Fields { get; set; }
        public int Id { get; set; }
        public List<WorkItemRelationDto> Relations { get; set; }
        public long Revision { get; set; }
        public string Url { get; set; }
    }
}