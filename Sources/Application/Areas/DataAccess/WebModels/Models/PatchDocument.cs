namespace Mmu.Mlazh.TfsProxy.Application.Areas.DataAccess.WebModels.Models
{
    public class PatchDocument
    {
        public PatchDocumentOperationType Op { get; set; }

        public string Path { get; set; }

        public object Value { get; set; }
    }
}
