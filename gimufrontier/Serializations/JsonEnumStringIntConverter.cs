using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace gimufrontier.Serializations
{
    /// <summary>
    /// This class converts the inner T enumerator into a string by using it's value (and not it's name)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class JsonEnumStringIntConvertInner<T> : JsonConverter<T>
    {
        public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.String)
                throw new JsonException("Unable to read enum string");

            var str = reader.GetString();
            if (str == null)
                throw new JsonException("Cannot read enum string");

            return (T?)Enum.Parse(typeToConvert, str);
        }

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            if (value == null)
                throw new JsonException("Target value is null");

            var newInt = Convert.ToInt32(value);
            writer.WriteStringValue(newInt.ToString());
        }
    }

    /// <summary>
    /// Converts an enumerator into a string by using it's value (and not it's name)
    /// </summary>
    public class JsonEnumStringIntConverter : JsonConverterFactory
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return typeToConvert.IsEnum;
        }

        public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            return (JsonConverter?)Activator.CreateInstance(typeof(JsonEnumStringIntConvertInner<>).MakeGenericType(new Type[1] { typeToConvert }), BindingFlags.Instance | BindingFlags.Public, binder: null, args: null, culture: null);
        }
    }
}
