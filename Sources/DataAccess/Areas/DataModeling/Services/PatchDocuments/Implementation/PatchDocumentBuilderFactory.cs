namespace Mmu.Mlazh.TfsProxy.DataAccess.Areas.DataModeling.Services.PatchDocuments.Implementation
{
    public class PatchDocumentBuilderFactory : IPatchDocumentBuilderFactory
    {
        public IPatchDocumentBuilder CreateBuilder()
        {
            return new PatchDocumentBuilder();
        }
    }
}