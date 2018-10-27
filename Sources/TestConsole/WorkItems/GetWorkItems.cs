using System;
using System.Threading.Tasks;
using Mmu.Mlazh.TfsProxy.Application.WorkItems.Areas.App.DtoModeling.Services;
using Mmu.Mlh.ConsoleExtensions.Areas.Commands.Models;
using Newtonsoft.Json;

namespace Mmu.Mlazh.TfsProxy.TestConsole.WorkItems
{
    public class GetWorkItems : IConsoleCommand
    {
        private readonly IWorkItemDtoDataService _workItemDtoDataService;
        public string Description { get; } = "Get Workitems by IDs";
        public ConsoleKey Key { get; } = ConsoleKey.D4;

        public GetWorkItems(IWorkItemDtoDataService workItemDtoDataService)
        {
            _workItemDtoDataService = workItemDtoDataService;
        }

        public async Task ExecuteAsync()
        {
            var itms = await _workItemDtoDataService.LoadByIdsAsync(118, 156, 178);
            Console.WriteLine(JsonConvert.SerializeObject(itms));
        }
    }
}