using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Mmu.Mlazh.AzureApplicationExtensions.Areas.AzureFunctionExecution.Services;
using Mmu.Mlazh.TfsProxy.Application.WorkItems.Areas.App.DtoModeling.Services;
using Mmu.Mlazh.TfsProxy.Dependencies;

namespace Mmu.Mlazh.TfsProxy.AzureFunctions.WorkItems.Functions
{
    public static class GetWorkItemsByIds
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", Justification = "Needed by the Framework")]
        [FunctionName("GetWorkItemsByIds")]
        public static Task<IActionResult> GetAsync([HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequest req, ILogger logger)
        {
            return AzureFunctionExecutionContext.ExecuteAsync<IWorkItemDtoDataService>(
                async service =>
                {
                    var workItemIds = req.Query["workitemIds"].First();

                    var workitemIdsSplitted = workItemIds
                        .Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();

                    var result = await service.LoadByIdsAsync(workitemIdsSplitted);
                    return new OkObjectResult(result);
                },
                typeof(GetWorkItemsByIds).Assembly,
                DependenciesProvider.ProvideDependencencies);
        }
    }
}