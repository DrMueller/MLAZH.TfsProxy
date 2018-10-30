using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Mmu.Mlazh.AzureApplicationExtensions.Areas.AzureFunctions.Context;
using Mmu.Mlazh.TfsProxy.Application.WorkItems.Areas.App.DtoModeling.Services;
using Mmu.Mlazh.TfsProxy.AzureFunctions.Common;

namespace Mmu.Mlazh.TfsProxy.AzureFunctions.WorkItems.Functions
{
    public static class GetWorkItemsByIds
    {
        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", Justification = "Needed by the Framework")]
        [FunctionName("GetWorkItemsByIds")]
        public static Task<IActionResult> GetAsync([HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequest req, ILogger logger)
        {
            FunctionsInitializationService.Initialize();

            return AzureFunctionExecutionContext.ExecuteAsync<IWorkItemDtoDataService>(
                req,
                async (service, httpRequestProxy) =>
                {
                    var workItemIds = httpRequestProxy.QueryParameters["workItemIds"];

                    var workitemIdsSplitted = workItemIds
                        .Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();

                    var result = await service.LoadByIdsAsync(workitemIdsSplitted);
                    return new OkObjectResult(result);
                });
        }
    }
}