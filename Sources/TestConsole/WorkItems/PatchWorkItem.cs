using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.Mlazh.TfsProxy.Application.WorkItems.Areas.App.DtoModeling.Dtos;
using Mmu.Mlazh.TfsProxy.Application.WorkItems.Areas.App.DtoModeling.Services;
using Mmu.Mlh.ConsoleExtensions.Areas.Commands.Models;
using Newtonsoft.Json;

namespace Mmu.Mlazh.TfsProxy.TestConsole.WorkItems
{
    public class PatchWorkItem : IConsoleCommand
    {
        private readonly IWorkItemDtoDataService _workItemDtoDataService;
        public string Description { get; } = "Patch WorkItem";
        public ConsoleKey Key { get; } = ConsoleKey.D1;

        public PatchWorkItem(IWorkItemDtoDataService workItemDtoDataService)
        {
            _workItemDtoDataService = workItemDtoDataService;
        }

        public async Task ExecuteAsync()
        {
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

            var itm = await _workItemDtoDataService.PatchAsync(dto);
            Console.WriteLine(JsonConvert.SerializeObject(itm));
        }
    }
}