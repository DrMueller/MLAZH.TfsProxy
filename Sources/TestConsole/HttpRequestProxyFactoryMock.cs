using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Mmu.Mlazh.AzureApplicationExtensions.Areas.AzureFunctions.HttpRequestProxies.Models;
using Mmu.Mlazh.AzureApplicationExtensions.Areas.AzureFunctions.HttpRequestProxies.Services;
using Mmu.Mlazh.TfsProxy.Application.WorkItems.Areas.App.DtoModeling.Dtos;

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

            return new HttpRequestProxy(new QueryParameters(new Dictionary<string, string>()), dto);
        }
    }
}