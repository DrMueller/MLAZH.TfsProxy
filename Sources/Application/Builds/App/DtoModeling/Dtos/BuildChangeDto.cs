using System;

namespace Mmu.Mlazh.TfsProxy.Application.Builds.App.DtoModeling.Dtos
{
    public class BuildChangeDto
    {
        public string Id { get; set; }
        public string Location { get; set; }
        public string Message { get; set; }
        public DateTime Timestamp { get; set; }
    }
}