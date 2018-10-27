namespace Mmu.Mlazh.TfsProxy.DataAccess.WorkItems.Areas.DataModeling.Services.PatchDocuments.Implementation
{
    public class PatchDocumentBuilderFactory : IPatchDocumentBuilderFactory
    {
        private readonly IPatchDocumentBuilder _provisioningService;

        public PatchDocumentBuilderFactory(IPatchDocumentBuilder provisioningService)
        {
            _provisioningService = provisioningService;
        }

        public IPatchDocumentBuilder CreateBuilder()
        {
            return _provisioningService;
        }
    }
}