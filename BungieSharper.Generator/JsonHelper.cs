using Newtonsoft.Json.Linq;
using System.Linq;

namespace BungieSharper.Generator
{
    public static class JsonHelper
    {
        public static object Deserialize(string json)
        {
            return ToObject(JToken.Parse(json));
        }

        private static object ToObject(JToken jToken)
        {
            return jToken.Type switch
            {
                JTokenType.Object => jToken.Children<JProperty>()
                    .ToDictionary(prop => prop.Name, prop => ToObject(prop.Value)),

                JTokenType.Array => jToken.Select(ToObject).ToList(),

                _ => ((JValue)jToken).Value!
            };
        }
    }
}