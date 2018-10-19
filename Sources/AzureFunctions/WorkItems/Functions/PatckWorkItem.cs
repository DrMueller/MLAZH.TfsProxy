using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Mmu.Mlazh.TfsProxy.Application.WorkItems.Areas.App.DtoModeling.Dtos;
using Mmu.Mlazh.TfsProxy.Application.WorkItems.Areas.App.DtoModeling.Services;
using Mmu.Mlazh.TfsProxy.AzureFunctions.Common.Infrastructure.ServiceProvisioning;
using Newtonsoft.Json;

namespace Mmu.Mlazh.TfsProxy.AzureFunctions.WorkItems.Functions
{
    public static class PatckWorkItem
    {
        [FunctionName("PatchWorkItem")]
        public static async Task<IActionResult> PatchAsync([HttpTrigger(AuthorizationLevel.Function, "patch", Route = null)] HttpRequest req)
        {
            var requestBody = new StreamReader(req.Body).ReadToEnd();
            var patchWorkItemDto = JsonConvert.DeserializeObject<PatchWorkItemDto>(requestBody);
            var workItemDtoDataService = ProvisioningService.GetService<IWorkItemDtoDataService>();

            var result = await workItemDtoDataService.PatchAsync(patchWorkItemDto);
            return new OkObjectResult(result);
        }
    }
}