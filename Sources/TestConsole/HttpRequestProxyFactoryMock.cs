using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Mmu.Mlazh.AzureApplicationExtensions.Areas.AzureFunctions.HttpRequestProxies.Models;
using Mmu.Mlazh.AzureApplicationExtensions.Areas.AzureFunctions.HttpRequestProxies.Services;
using Mmu.Mlazh.TfsProxy.Application.WorkItems.Areas.App.DtoModeling.Dtos;
using Newtonsoft.Json;

namespace Mmu.Mlazh.TfsProxy.TestConsole
{
    public class HttpRequestProxyFactoryMock : IHttpRequestProxyFactory
    {
        public HttpRequestProxy CreateFromHttpRequest(HttpRequest httpRequest)
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

            var dtoString = JsonConvert.SerializeObject(dto);
            return new HttpRequestProxy(new QueryParameters(new Dictionary<string, string>()), dtoString);
        }
    }
}