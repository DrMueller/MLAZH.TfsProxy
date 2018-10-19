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
    public static class PostWorkItem
    {
        [FunctionName("PostWorkItem")]
        public static async Task<IActionResult> PostAsync([HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req)
        {
            var requestBody = new StreamReader(req.Body).ReadToEnd();
            var postWorkItemDto = JsonConvert.DeserializeObject<PostWorkItemDto>(requestBody);
            var workItemDtoDataService = ProvisioningService.GetService<IWorkItemDtoDataService>();

            var result = await workItemDtoDataService.PostAsync(postWorkItemDto);
            return new OkObjectResult(result);
        }
    }
}