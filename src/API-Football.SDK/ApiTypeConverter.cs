using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace API_Football.SDK
{
    internal class ApiTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(List<Dictionary<string, string>>));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            Dictionary<string, string> errors = new Dictionary<string, string>();
            JToken token = JToken.Load(reader);

            if (token.Type == JTokenType.Object)
            {
                foreach (var property in ((JObject)token).Properties())
                {
                    errors.Add(property.Name, property.Value.ToString());
                }
            }
            else if (token.Type == JTokenType.Array)
            {
                foreach (var obj in (JArray)token)
                {
                    foreach (var property in ((JObject)obj).Properties())
                    {
                        errors.Add(property.Name, property.Value.ToString());
                    }
                }
            }
            else
                return null;

            return errors;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}
