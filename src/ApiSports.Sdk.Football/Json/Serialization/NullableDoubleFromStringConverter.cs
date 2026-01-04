using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ApiSports.Sdk.Football.Json.Serialization;

public sealed class NullableDoubleFromStringOrNumberConverter : JsonConverter<double?>
{
    public override double? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        switch (reader.TokenType)
        {
            case JsonTokenType.Null:
                return null;
            case JsonTokenType.Number:
                return reader.GetDouble();
            case JsonTokenType.String:
                {
                    string? s = reader.GetString();
                    if (string.IsNullOrWhiteSpace(s))
                    {
                        return null;
                    }

                    // Common “non-values”
                    if (s == "-" || s.Equals("N/A", StringComparison.OrdinalIgnoreCase))
                    {
                        return null;
                    }

                    if (double.TryParse(s, NumberStyles.Float, CultureInfo.InvariantCulture, out double value))
                    {
                        return value;
                    }

                    return null; // or throw, depending on strictness
                }
            default:
                throw new JsonException($"Unexpected token {reader.TokenType} when parsing nullable double.");
        }
    }

    public override void Write(Utf8JsonWriter writer, double? value, JsonSerializerOptions options)
    {
        if (value is null)
        {
            writer.WriteNullValue();
            return;
        }

        writer.WriteNumberValue(value.Value);
    }
}
