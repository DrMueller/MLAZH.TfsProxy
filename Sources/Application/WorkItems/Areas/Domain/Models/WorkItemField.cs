using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Mlazh.TfsProxy.Application.WorkItems.Areas.Domain.Models
{
    public class WorkItemField
    {
        public string Name { get; }
        public object Value { get; }

        public WorkItemField(string name, object value)
        {
            Guard.StringNotNullOrEmpty(() => name);

            Name = name;
            Value = value;
        }
    }
}