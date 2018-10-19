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
    public class PostWorkItem : IConsoleCommand
    {
        public string Description { get; } = "Post Workitem";
        public ConsoleKey Key { get; } = ConsoleKey.D2;

        public async Task ExecuteAsync()
        {
            try
            {
                var workItemDtoDataService = ProvisioningServiceSingleton.Instance.GetService<IWorkItemDtoDataService>();
                var dto = new PostWorkItemDto
                {
                    WorkItemTypeName = "Release",
                    Fields = new List<WorkItemFieldDto>
                    {
                        new WorkItemFieldDto
                        {
                            Name = "Title",
                            Value = "Hello Release"
                        },
                        new WorkItemFieldDto
                        {
                            Name = "Custom.Version",
                            Value = "1.2.3"
                        }
                    },
                    Relations = new List<WorkItemRelationDto>
                    {
                        new WorkItemRelationDto
                        {
                            RelationTypeDescription = "System.LinkTypes.Hierarchy-Reverse",
                            TargetWorkItemId = 150
                        }
                    }
                };

                var itm = await workItemDtoDataService.PostAsync(dto);
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