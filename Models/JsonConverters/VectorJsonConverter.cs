using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
using CounterStrikeSharp.API.Modules.Utils;

namespace ExecutesPlugin.Models.JsonConverters;

public class VectorJsonConverter : JsonConverter<Vector>
{
    public override Vector Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.String)
        {
            throw new JsonException("Expected a string value.");
        }

        var stringValue = reader.GetString();
        if (stringValue == null)
        {
            throw new JsonException("String value is null.");
        }

        var values = stringValue.Split(' '); // Split by semicolon

        Console.WriteLine($"[Executes] Vector values: {stringValue}");

        if (values.Length != 3)
        {
            throw new JsonException("String value is not in the correct format (X Y Z).");
        }

        if (!float.TryParse(values[0], NumberStyles.Any, CultureInfo.InvariantCulture, out var x) ||
            !float.TryParse(values[1], NumberStyles.Any, CultureInfo.InvariantCulture, out var y) ||
            !float.TryParse(values[2], NumberStyles.Any, CultureInfo.InvariantCulture, out var z))
        {
            Console.WriteLine($"[Executes] Unable to parse Vector float values for: {stringValue}");
            throw new JsonException("Unable to parse Vector float values.");
        }

        return new Vector(x, y, z);
    }

    public override void Write(Utf8JsonWriter writer, Vector value, JsonSerializerOptions options)
    {
        // Convert Vector object to string representation (example assumes ToString() returns desired format)
        var vectorString = value.ToString();
        writer.WriteStringValue(vectorString);
    }
}