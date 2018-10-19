using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Mmu.Mlazh.TfsProxy.Application.WorkItems.Areas.App.DtoModeling.Services;
using Mmu.Mlh.ApplicationExtensions.Areas.ServiceProvisioning;
using Newtonsoft.Json;

namespace Mmu.Mlazh.TfsProxy.TestConsole.WorkItems
{
    public class GetWorkItems : IConsoleCommand
    {
        public string Description { get; } = "Get Workitems by IDs";
        public ConsoleKey Key { get; } = ConsoleKey.D4;

        public async Task ExecuteAsync()
        {
            try
            {
                var workItemDtoDataService = ProvisioningServiceSingleton.Instance.GetService<IWorkItemDtoDataService>();
                var itms = await workItemDtoDataService.LoadByIdsAsync(118, 156, 178);
                Console.WriteLine(JsonConvert.SerializeObject(itms));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Debugger.Break();
            }
        }
    }
}