using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Mmu.Mlazh.TfsProxy.Application.Areas.App.DtoModeling.Dtos;
using Mmu.Mlazh.TfsProxy.Application.Areas.App.DtoModeling.Services;
using Mmu.Mlazh.TfsProxy.AzureFunctions.Infrastructure.ServiceProvisioning;
using Newtonsoft.Json;

namespace Mmu.Mlazh.TfsProxy.AzureFunctions.Areas.Functions
{
    public static class WorkItemFunctions
    {
        [FunctionName("GetWorkItemById")]
        public static async Task<IActionResult> GetWorkItemAsync([HttpTrigger(AuthorizationLevel.Function, "get", Route = "GetWorkItemById/{workItemId}")] HttpRequest req, ILogger logger, int workItemId)
        {
            var workItemDtoDataService = ProvisioningService.GetService<IWorkItemDtoDataService>();
            var result = await workItemDtoDataService.LoadByIdAsync(workItemId);

            return new OkObjectResult(result);
        }

        [FunctionName("PatchWorkItem")]
        public static async Task<IActionResult> PatchWorkItemsAsync([HttpTrigger(AuthorizationLevel.Function, "patch", Route = null)] HttpRequest req)
        {
            var requestBody = new StreamReader(req.Body).ReadToEnd();
            var patchWorkItemDto = JsonConvert.DeserializeObject<PatchWorkItemDto>(requestBody);
            var workItemDtoDataService = ProvisioningService.GetService<IWorkItemDtoDataService>();

            var result = await workItemDtoDataService.PatchAsync(patchWorkItemDto);
            return new OkObjectResult(result);
        }
    }
}