using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Mmu.Mlazh.AzureApplicationExtensions.Areas.AzureFunctions.Context;
using Mmu.Mlazh.TfsProxy.Application.WorkItems.Areas.App.DtoModeling.Dtos;
using Mmu.Mlazh.TfsProxy.Application.WorkItems.Areas.App.DtoModeling.Services;
using Mmu.Mlazh.TfsProxy.AzureFunctions.Common;

namespace Mmu.Mlazh.TfsProxy.AzureFunctions.WorkItems.Functions
{
    public static class PatckWorkItem
    {
        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", Justification = "Needed by the Framework")]
        [FunctionName("PatchWorkItem")]
        public static Task<IActionResult> PatchAsync([HttpTrigger(AuthorizationLevel.Function, "patch", Route = null)] HttpRequest req, ILogger logger)
        {
            FunctionsInitializationService.Initialize();

            return AzureFunctionExecutionContext.ExecuteAsync<IWorkItemDtoDataService>(
                req,
                async (service, httpRequestProxy) =>
                {
                    var patchWorkItemDto = httpRequestProxy.ReadBody<PatchWorkItemDto>();
                    var result = await service.PatchAsync(patchWorkItemDto);
                    return new OkObjectResult(result);
                });
        }
    }
}