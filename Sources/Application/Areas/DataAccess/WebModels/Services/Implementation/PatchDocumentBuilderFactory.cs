namespace Mmu.Mlazh.TfsProxy.Application.Areas.DataAccess.WebModels.Services.Implementation
{
    public class PatchDocumentBuilderFactory : IPatchDocumentBuilderFactory
    {
        public IPatchDocumentBuilder CreateBuilder()
        {
            return new PatchDocumentBuilder();
        }
    }
}