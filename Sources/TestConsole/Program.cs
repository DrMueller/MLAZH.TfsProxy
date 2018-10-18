using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Mmu.Mlazh.TfsProxy.Application.Areas.App.DtoModeling.Dtos;
using Mmu.Mlazh.TfsProxy.Application.Areas.App.DtoModeling.Services;
using Mmu.Mlazh.TfsProxy.Dependencies;
using Mmu.Mlh.ApplicationExtensions.Areas.DependencyInjection.Models;
using Mmu.Mlh.ApplicationExtensions.Areas.DependencyInjection.Services;
using Mmu.Mlh.ApplicationExtensions.Areas.ServiceProvisioning;
using Newtonsoft.Json;

namespace Mmu.Mlazh.TfsProxy.TestConsole
{
    internal class Program
    {
        private static void Main()
        {
            DependenciesProvider.ProvideDependencencies();
            ContainerInitializationService.CreateInitializedContainer(
                new AssemblyParameters(
                    typeof(Program).Assembly,
                    "Mmu.Mlazh"));

            var workItemDtoDataService = ProvisioningServiceSingleton.Instance.GetService<IWorkItemDtoDataService>();

            Task.Run(
                async () =>
                {
                    try
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
                        Console.WriteLine(JsonConvert.SerializeObject(itm));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Debugger.Break();
                    }
                });

            Task.Run(
                async () =>
                {
                    try
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

                        var itm = await workItemDtoDataService.PostAsync(dto);
                        Console.WriteLine(JsonConvert.SerializeObject(itm));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Debugger.Break();
                    }
                });

            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}