using System.Collections.Generic;
using Mmu.Mlazh.TfsProxy.Application.Infrastructure.TfsAccess.Models;
using Newtonsoft.Json.Linq;

namespace Mmu.Mlazh.TfsProxy.Application.Infrastructure.TfsAccess.Adapters.Implementation
{
    public class JsonAdapter : IJsonAdapter
    {
        public List<NativeWorkItem> AdaptList(string jsonString)
        {
            var result = new List<NativeWorkItem>();
            var token = JToken.Parse(jsonString);
            var itemsArray = (JArray)token["value"];
            foreach (var workItem in itemsArray)
            {
                var nativeWorkItem = MapFromJtoken(workItem);
                result.Add(nativeWorkItem);
            }

            return result;
        }

        public NativeWorkItem AdaptWorkItem(string jsonString)
        {
            var jtoken = JToken.Parse(jsonString);
            return MapFromJtoken(jtoken);
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