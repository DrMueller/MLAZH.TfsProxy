using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Mmu.Mlazh.AzureApplicationExtensions.Areas.AzureFunctionExecution.Services;
using Mmu.Mlazh.TfsProxy.Application.WorkItems.Areas.App.DtoModeling.Dtos;
using Mmu.Mlazh.TfsProxy.Application.WorkItems.Areas.App.DtoModeling.Services;
using Mmu.Mlazh.TfsProxy.Application.WorkItems.Areas.Domain.Models;
using Mmu.Mlazh.TfsProxy.Dependencies;
using Newtonsoft.Json;

namespace Mmu.Mlazh.TfsProxy.AzureFunctions.WorkItems.Functions
{
    public static class PatckWorkItem
    {
        [FunctionName("PatchWorkItem")]
        public static Task<IActionResult> PatchAsync([HttpTrigger(AuthorizationLevel.Function, "patch", Route = null)] HttpRequest req, ILogger logger)
        {
            return AzureFunctionExecutionContext.ExecuteAsync<IWorkItemDtoDataService>(
                async service =>
                {
                    var requestBody = new StreamReader(req.Body).ReadToEnd();
                    var patchWorkItemDto = JsonConvert.DeserializeObject<PatchWorkItemDto>(requestBody);

                    var result = await service.PatchAsync(patchWorkItemDto);
                    return new OkObjectResult(result);
                },
                typeof(PatchWorkItem).Assembly,
                DependenciesProvider.ProvideDependencencies);
        }
    }
}