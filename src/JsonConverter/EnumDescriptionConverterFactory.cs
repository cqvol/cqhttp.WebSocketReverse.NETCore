using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace cqhttp.WebSocketReverse.NETCore.JsonConverter
{
    public class EnumDescriptionConverterFactory : JsonConverterFactory
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return typeToConvert.IsEnum;
        }

        public override System.Text.Json.Serialization.JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            System.Text.Json.Serialization.JsonConverter converter = (System.Text.Json.Serialization.JsonConverter)Activator.CreateInstance(
                typeof(EnumDescriptionConverterInner<>).MakeGenericType(typeToConvert),
                BindingFlags.Instance | BindingFlags.Public,binder: null,null,culture: null);
            return converter;
        }

        public class EnumDescriptionConverterInner<T> : JsonConverter<T>
        {
            public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                JsonTokenType token = reader.TokenType;

                if (token == JsonTokenType.String)
                {
                    string enumText = reader.ValueSpan.ToString();

                    FieldInfo fi = typeToConvert.GetField(enumText);
                    DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
                    if (attributes.Length > 0)
                    {
                        var description = (T)Convert.ChangeType(attributes[0].Description, typeof(T));
                        return description;
                    }
                }
                return default;
            }

            public override void Write(Utf8JsonWriter writer, [DisallowNull] T value, JsonSerializerOptions options)
            {
                FieldInfo fi = value.GetType().GetField(value.ToString());
                DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attributes.Length > 0)
                {
                    writer.WriteStringValue(attributes[0].Description);
                }
            }
        }
    }
}
