using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Mmu.Mlazh.TfsProxy.Application.Builds.App.DtoModeling.Services;
using Mmu.Mlazh.TfsProxy.AzureFunctions.Common.Infrastructure.ServiceProvisioning;

namespace Mmu.Mlazh.TfsProxy.AzureFunctions.Builds.Functions
{
    public static class GetBuildChangesByBuildId
    {
        [FunctionName("GetBuildChangesByBuildId")]
        public static async Task<IActionResult> GetAsync([HttpTrigger(AuthorizationLevel.Function, "get", Route = "GetBuildChangesByBuildId/{buildId}")] HttpRequest req, ILogger logger, long buildId)
        {
            try
            {
                var workItemDtoDataService = ProvisioningService.GetService<IBuildChangeDtoDataService>();
                var result = await workItemDtoDataService.LoadByBuildIdAsync(buildId);

                return new OkObjectResult(result);
            }
            catch (Exception ex)
            {
                return new ObjectResult(ex);
            }
        }
    }
}