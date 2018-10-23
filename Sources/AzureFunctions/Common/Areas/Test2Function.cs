using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;

namespace Mmu.Mlazh.TfsProxy.AzureFunctions.Common.Areas
{
    public static class Test2Function
    {
        [FunctionName("Test2Function")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = "Hello")] HttpRequest req, TraceWriter log)
        {
            return new OkObjectResult("Hello, World");
        }
    }
}