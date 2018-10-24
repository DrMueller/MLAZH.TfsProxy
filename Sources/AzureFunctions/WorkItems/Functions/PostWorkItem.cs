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
using Mmu.Mlazh.TfsProxy.Dependencies;
using Newtonsoft.Json;

namespace Mmu.Mlazh.TfsProxy.AzureFunctions.WorkItems.Functions
{
    public static class PostWorkItem
    {
        [FunctionName("PostWorkItem")]
        public static Task<IActionResult> PostAsync([HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req, ILogger logger)
        {
            return AzureFunctionExecutionContext.ExecuteAsync<IWorkItemDtoDataService>(
                async service =>
                {
                    var requestBody = new StreamReader(req.Body).ReadToEnd();
                    var postWorkItemDto = JsonConvert.DeserializeObject<PostWorkItemDto>(requestBody);

                    var result = await service.PostAsync(postWorkItemDto);
                    return new OkObjectResult(result);
                },
                typeof(PostWorkItem).Assembly,
                DependenciesProvider.ProvideDependencencies);
        }
    }
}