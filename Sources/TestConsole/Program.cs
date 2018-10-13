using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.Mlazh.TfsProxy.Application.Areas.App.DtoModeling.Dtos;
using Mmu.Mlazh.TfsProxy.Application.Areas.App.DtoModeling.Services;
using Mmu.Mlh.ApplicationExtensions.Areas.DependencyInjection.Models;
using Mmu.Mlh.ApplicationExtensions.Areas.DependencyInjection.Services;
using Mmu.Mlh.ApplicationExtensions.Areas.ServiceProvisioning;

namespace Mmu.Mlazh.TfsProxy.TestConsole
{
    internal class Program
    {
        private static void Main()
        {
            ContainerInitializationService.CreateInitializedContainer(
                new AssemblyParameters(
                    typeof(Program).Assembly,
                    "Mmu.Mlazh"));

            var workItemDtoDataService = ProvisioningServiceSingleton.Instance.GetService<IWorkItemDtoDataService>();

            Task.Run(
                async () =>
                {
                    var dto = new PatchWorkItemDto
                    {
                        Id = 156,
                        Fields = new List<WorkItemFieldDto>
                        {
                            new WorkItemFieldDto
                            {
                                Name = "Title",
                                Value = "Hello test"
                            }
                        }
                    };

                    var itm = await workItemDtoDataService.PatchAsync(dto);
                    Console.WriteLine(itm);
                });

            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}