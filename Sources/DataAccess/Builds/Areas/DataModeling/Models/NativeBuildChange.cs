using System;

namespace Mmu.Mlazh.TfsProxy.DataAccess.Builds.Areas.DataModeling.Models
{
    public class NativeBuildChange
    {
        public NativeAuthor Author { get; set; }
        public string DisplayUri { get; set; }
        public string Id { get; set; }
        public string Location { get; set; }
        public string Message { get; set; }
        public DateTime Timestamp { get; set; }
        public string Type { get; set; }
    }
}