using System;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Mlazh.TfsProxy.Application.Builds.Domain.Models
{
    public class BuildChange
    {
        public string Id { get; }
        public string Location { get; }
        public string Message { get; }
        public DateTime Timestamp { get; }

        public BuildChange(string id, string location, string message, DateTime timestamp)
        {
            Guard.ObjectNotNull(() => id);
            Guard.ObjectNotNull(() => location);
            Guard.ObjectNotNull(() => message);

            Id = id;
            Location = location;
            Message = message;
            Timestamp = timestamp;
        }
    }
}