using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Mmu.Mlazh.TfsProxy.Application.WorkItems.Areas.App.DtoModeling.Services;
using Mmu.Mlazh.TfsProxy.AzureFunctions.Common.Infrastructure.ServiceProvisioning;

namespace Mmu.Mlazh.TfsProxy.AzureFunctions.WorkItems.Functions
{
    public static class GetWorkItemsByIds
    {
        [FunctionName("GetWorkItemsByIds")]
        public static async Task<IActionResult> GetAsync([HttpTrigger(AuthorizationLevel.Function, "post", Route = "GetWorkItemsById/workItemIds")] HttpRequest req, ILogger logger, string workItemIds)
        {
            var workItemDtoDataService = ProvisioningService.GetService<IWorkItemDtoDataService>();

            var workitemIdsSplitted = workItemIds
                .Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var result = await workItemDtoDataService.LoadByIdsAsync(workitemIdsSplitted);

            return new OkObjectResult(result);
        }
    }
}