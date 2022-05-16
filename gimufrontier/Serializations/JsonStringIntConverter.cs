using System.Text.Json;
using System.Text.Json.Serialization;

namespace gimufrontier.Serializations
{
    /// <summary>
    /// Converts an int into a string
    /// </summary>
    public class JsonStringIntConverter : JsonConverter<int>
    {
        public override int Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.String)
                throw new JsonException("Unable to read string");

            var str = reader.GetString();
            if (str == null)
                throw new JsonException("Cannot read string");

            return int.Parse(str);
        }

        public override void Write(Utf8JsonWriter writer, int value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }

    /// <summary>
    /// Converts an uint into a string
    /// </summary>
    public class JsonStringUIntConverter : JsonConverter<uint>
    {
        public override uint Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.String)
                throw new JsonException("Unable to read string");

            var str = reader.GetString();
            if (str == null)
                throw new JsonException("Cannot read string");

            return uint.Parse(str);
        }

        public override void Write(Utf8JsonWriter writer, uint value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }

    /// <summary>
    /// Converts an bool into a string
    /// </summary>
    public class JsonStringBoolConverter : JsonConverter<bool>
    {
        public override bool Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.String)
                throw new JsonException("Unable to read string");

            var str = reader.GetString();
            if (str == null)
                throw new JsonException("Cannot read string");

            return uint.Parse(str) > 0;
        }

        public override void Write(Utf8JsonWriter writer, bool value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value ? "1" : "0");
        }
    }

    /// <summary>
    /// Converts an bool into a int
    /// </summary>
    public class JsonIntBoolConverter : JsonConverter<bool>
    {
        public override bool Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.Number)
                throw new JsonException("Unable to read number");

            return reader.GetInt32() > 0;
        }

        public override void Write(Utf8JsonWriter writer, bool value, JsonSerializerOptions options)
        {
            writer.WriteNumberValue(value ? 1 : 0);
        }
    }

    /// <summary>
    /// Converts an ulong into a string
    /// </summary>
    public class JsonStringULongConverter : JsonConverter<ulong>
    {
        public override ulong Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.String)
                throw new JsonException("Unable to read enum string");

            var str = reader.GetString();
            if (str == null)
                throw new JsonException("Cannot read enum string");

            return ulong.Parse(str);
        }

        public override void Write(Utf8JsonWriter writer, ulong value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}
