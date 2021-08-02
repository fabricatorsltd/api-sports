using Newtonsoft.Json;
using System;
using System.ComponentModel;

namespace API_Football.SDK
{
    public class ApiTupleConverter<T> : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(Tuple<T, T>) == objectType;
        }

        public override object ReadJson(
            JsonReader reader,
            Type objectType,
            object existingValue,
            JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return (default(T), default(T));

            var jObject = Newtonsoft.Json.Linq.JObject.Load(reader);
            T first = default;
            T second = default;

            int counter = 0;

            foreach (var property in (jObject).Properties())
            {
                TypeConverter conv = TypeDescriptor.GetConverter(typeof(T));

                if (reader.TokenType == JsonToken.EndObject)
                {
                    if (counter == 0)
                        first = JsonConvert.DeserializeObject<T>(property.Value.ToString());
                    else if (counter == 1)
                        second = JsonConvert.DeserializeObject<T>(property.Value.ToString());
                    else
                        break;
                }
                else
                {
                    if (counter == 0)
                        first = (T)conv.ConvertFrom(property.Value.ToString());
                    else if (counter == 1)
                        second = (T)conv.ConvertFrom(property.Value.ToString());
                    else
                        break;
                }

                counter++;
            }

            return (first, second);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
    public class ApiTupleConverter<T1, T2> : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(Tuple<T1, T2>) == objectType;
        }

        public override object ReadJson(
            JsonReader reader,
            Type objectType,
            object existingValue,
            JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return (default(T1), default(T2));

            var jObject = Newtonsoft.Json.Linq.JObject.Load(reader);
            T1 first = default;
            T2 second = default;

            int counter = 0;

            foreach (var property in (jObject).Properties())
            {
                if (reader.TokenType == JsonToken.EndObject)
                {
                    if (counter == 0)
                        first = JsonConvert.DeserializeObject<T1>(property.Value.ToString());
                    else if (counter == 1)
                        second = JsonConvert.DeserializeObject<T2>(property.Value.ToString());
                    else
                        break;
                }
                else
                {
                    if (counter == 0)
                    {
                        var conv = TypeDescriptor.GetConverter(typeof(T1));
                        first = (T1)conv.ConvertFrom(property.Value.ToString());
                    }
                    else if (counter == 1)
                    {
                        var conv = TypeDescriptor.GetConverter(typeof(T2));
                        second = (T2)conv.ConvertFrom(property.Value.ToString());
                    }
                    else
                        break;
                }

                counter++;
            }

            return (first, second);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}
