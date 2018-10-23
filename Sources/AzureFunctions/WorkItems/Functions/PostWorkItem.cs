using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Mmu.Mlazh.TfsProxy.Application.WorkItems.Areas.App.DtoModeling.Dtos;
using Mmu.Mlazh.TfsProxy.Application.WorkItems.Areas.App.DtoModeling.Services;
using Mmu.Mlazh.TfsProxy.AzureFunctions.Common.Infrastructure.ServiceProvisioning;
using Mmu.Mlazh.TfsProxy.Dependencies;
using Newtonsoft.Json;

namespace Mmu.Mlazh.TfsProxy.AzureFunctions.WorkItems.Functions
{
    public static class PostWorkItem
    {
        [FunctionName("PostWorkItem")]
        public static async Task<IActionResult> PostAsync([HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req, ILogger logger)
        {
            DependenciesProvider.ProvideDependencencies();

            var requestBody = new StreamReader(req.Body).ReadToEnd();
            var postWorkItemDto = JsonConvert.DeserializeObject<PostWorkItemDto>(requestBody);

            var workItemDtoDataService = AppProvisioningService.GetService<IWorkItemDtoDataService>();

            var result = await workItemDtoDataService.PostAsync(postWorkItemDto);
            return new OkObjectResult(result);
        }
    }
}