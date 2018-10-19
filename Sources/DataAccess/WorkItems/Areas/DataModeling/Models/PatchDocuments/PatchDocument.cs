namespace Mmu.Mlazh.TfsProxy.DataAccess.WorkItems.Areas.DataModeling.Models.PatchDocuments
{
    public class PatchDocument
    {
        public PatchDocumentOperationType Op { get; set; }
        public string Path { get; set; }
        public object Value { get; set; }
    }
}