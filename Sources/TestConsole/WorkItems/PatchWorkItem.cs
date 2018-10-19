using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Mmu.Mlazh.TfsProxy.Application.WorkItems.Areas.App.DtoModeling.Dtos;
using Mmu.Mlazh.TfsProxy.Application.WorkItems.Areas.App.DtoModeling.Services;
using Mmu.Mlh.ApplicationExtensions.Areas.ServiceProvisioning;
using Newtonsoft.Json;

namespace Mmu.Mlazh.TfsProxy.TestConsole.WorkItems
{
    public class PatchWorkItem : IConsoleCommand
    {
        public string Description { get; } = "Patch WorkItem";
        public ConsoleKey Key { get; } = ConsoleKey.D1;

        public async Task ExecuteAsync()
        {
            try
            {
                var workItemDtoDataService = ProvisioningServiceSingleton.Instance.GetService<IWorkItemDtoDataService>();
                var dto = new PatchWorkItemDto
                {
                    Id = 156,
                    Fields = new List<WorkItemFieldDto>
                    {
                        new WorkItemFieldDto
                        {
                            Name = "Title",
                            Value = "Hello test " + DateTime.Now.ToLongDateString()
                        }
                    }
                };

                var itm = await workItemDtoDataService.PatchAsync(dto);
                Console.WriteLine(JsonConvert.SerializeObject(itm));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Debugger.Break();
            }
        }
    }
}