using System.Collections.Generic;
using System.Linq;
using Mmu.Mlazh.TfsProxy.DataAccess.WorkItems.Areas.DataModeling.Models.WorkItems;
using Newtonsoft.Json.Linq;

namespace Mmu.Mlazh.TfsProxy.DataAccess.WorkItems.Areas.DataModeling.Services.WorkItems.Adapters.Implementation
{
    public class JsonWorkItemAdapter : IJsonWorkItemAdapter
    {
        public NativeWorkItem AdaptWorkItem(string jsonString)
        {
            var jtoken = JToken.Parse(jsonString);
            return MapFromJtoken(jtoken);
        }

        public NativeWorkItems AdaptWorkItems(string jsonString)
        {
            var token = JToken.Parse(jsonString);
            var itemTokens = (JArray)token["value"];
            var count = token["count"].Value<int>();
            var workItems = itemTokens.Select(MapFromJtoken).ToList();

            return new NativeWorkItems
            {
                Count = count,
                Value = workItems
            };
        }

        private static NativeWorkItem MapFromJtoken(JToken jtoken)
        {
            var nativeWorkItem = new NativeWorkItem
            {
                Relations = new List<NativeWorkItemRelation>(),
                Fields = new List<NativeWorkItemField>(),
                Id = jtoken["id"].Value<int>(),
                Rev = jtoken["rev"].Value<long>(),
                Url = jtoken["url"].Value<string>()
            };

            var fields = jtoken["fields"].ToObject<Dictionary<string, object>>();
            var relations = (JArray)jtoken["relations"];

            foreach (var field in fields)
            {
                var nativeField = new NativeWorkItemField
                {
                    Namespace = field.Key,
                    Value = field.Value
                };
                nativeWorkItem.Fields.Add(nativeField);
            }

            if (relations != null)
            {
                foreach (var rel in relations)
                {
                    var relationDto = new NativeWorkItemRelation
                    {
                        Rel = rel["rel"].Value<string>(),
                        Url = rel["url"].Value<string>()
                    };

                    nativeWorkItem.Relations.Add(relationDto);
                }
            }

            return nativeWorkItem;
        }
    }
}