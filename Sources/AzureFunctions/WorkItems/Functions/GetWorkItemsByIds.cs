//using System;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Azure.WebJobs;
//using Microsoft.Azure.WebJobs.Extensions.Http;
//using Microsoft.Extensions.Logging;
//using Mmu.Mlazh.TfsProxy.Application.Common.Infrastructure.AzureFiles.Services;
//using Mmu.Mlazh.TfsProxy.Application.WorkItems.Areas.App.DtoModeling.Services;
//using Mmu.Mlazh.TfsProxy.AzureFunctions.Common.Infrastructure.ServiceProvisioning;
//using Mmu.Mlazh.TfsProxy.Dependencies;

//namespace Mmu.Mlazh.TfsProxy.AzureFunctions.WorkItems.Functions
//{
//    public static class GetWorkItemsByIds
//    {
//        [FunctionName("GetWorkItemsByIds")]
//        public static async Task<IActionResult> GetAsync([HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequest req, ILogger logger)
//        {
//            try
//            {
//                DependenciesProvider.ProvideDependencencies();
//                var workItemDtoDataService = AppProvisioningService.GetService<IWorkItemDtoDataService>();

//                var workItemIds = req.Query["workitemIds"].First();

//                var workitemIdsSplitted = workItemIds
//                    .Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
//                    .Select(int.Parse)
//                    .ToArray();

//                var result = await workItemDtoDataService.LoadByIdsAsync(workitemIdsSplitted);

//                return new OkObjectResult(result);
//            }
//            catch (Exception ex)
//            {
//                var fileService = AppProvisioningService.GetService<IFileService>();
//                await fileService.AppendAsync(ex.Message + ex.StackTrace);
//                return new BadRequestObjectResult(ex.Message);
//            }
//        }
//    }
//}