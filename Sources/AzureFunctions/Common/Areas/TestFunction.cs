using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Build.Framework;

namespace Mmu.Mlazh.TfsProxy.AzureFunctions.Common.Areas
{
    public static class TestFunction
    {
        [FunctionName("TestFunction")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req, ILogger log)
        {
            return new OkObjectResult($"Hello, World");
        }
    }
}