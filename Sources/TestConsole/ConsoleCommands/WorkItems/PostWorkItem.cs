using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.Mlazh.TfsProxy.Application.WorkItems.Areas.App.DtoModeling.Dtos;
using Mmu.Mlazh.TfsProxy.Application.WorkItems.Areas.App.DtoModeling.Services;
using Mmu.Mlh.ConsoleExtensions.Areas.Commands.Models;
using Newtonsoft.Json;

namespace Mmu.Mlazh.TfsProxy.TestConsole.ConsoleCommands.WorkItems
{
    public class PostWorkItem : IConsoleCommand
    {
        private readonly IWorkItemDtoDataService _workItemDtoDataService;
        public string Description { get; } = "Post Workitem";
        public ConsoleKey Key { get; } = ConsoleKey.D2;

        public PostWorkItem(IWorkItemDtoDataService workItemDtoDataService)
        {
            _workItemDtoDataService = workItemDtoDataService;
        }

        public async Task ExecuteAsync()
        {
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

            var itm = await _workItemDtoDataService.PostAsync(dto);
            Console.WriteLine(JsonConvert.SerializeObject(itm));
        }
    }
}