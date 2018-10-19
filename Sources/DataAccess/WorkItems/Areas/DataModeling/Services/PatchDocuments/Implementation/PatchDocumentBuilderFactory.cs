using Mmu.Mlh.ApplicationExtensions.Areas.ServiceProvisioning;

namespace Mmu.Mlazh.TfsProxy.DataAccess.WorkItems.Areas.DataModeling.Services.PatchDocuments.Implementation
{
    public class PatchDocumentBuilderFactory : IPatchDocumentBuilderFactory
    {
        private readonly IProvisioningService _provisioningService;

        public PatchDocumentBuilderFactory(IProvisioningService provisioningService)
        {
            _provisioningService = provisioningService;
        }

        public IPatchDocumentBuilder CreateBuilder()
        {
            return _provisioningService.GetService<IPatchDocumentBuilder>();
        }
    }
}