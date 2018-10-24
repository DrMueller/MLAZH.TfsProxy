using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Mmu.Mlazh.AzureApplicationExtensions.Areas.AzureFunctionExecution.Services;
using Mmu.Mlazh.TfsProxy.Application.Builds.App.DtoModeling.Services;
using Mmu.Mlazh.TfsProxy.Dependencies;

namespace Mmu.Mlazh.TfsProxy.AzureFunctions.Builds.Functions
{
    public static class GetBuildChangesByBuildId
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", Justification = "Needed by the Framework")]
        [FunctionName("GetBuildChangesByBuildId")]
        public static Task<IActionResult> GetAsync([HttpTrigger(AuthorizationLevel.Function, "get", Route = "GetBuildChangesByBuildId/{buildId}")] HttpRequest req, ILogger logger, long buildId)
        {
            return AzureFunctionExecutionContext.ExecuteAsync<IBuildChangeDtoDataService>(
                async service =>
                {
                    var result = await service.LoadByBuildIdAsync(buildId);
                    return new OkObjectResult(result);
                },
                typeof(GetBuildChangesByBuildId).Assembly,
                DependenciesProvider.ProvideDependencencies);
        }
    }
}