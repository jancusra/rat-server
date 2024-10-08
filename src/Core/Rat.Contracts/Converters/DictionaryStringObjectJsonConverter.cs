﻿using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Rat.Contracts.Converters
{
    public class DictionaryStringObjectJsonConverter : JsonConverter<Dictionary<string, object>>
    {
        /// <summary>
        /// Will deserialize JSON object to dictionary model string/object
        /// </summary>
        /// <param name="reader">JSON reader</param>
        /// <param name="typeToConvert">type of converter</param>
        /// <param name="options">serializer options</param>
        /// <returns>final string/object dictionary</returns>
        /// <exception cref="JsonException"></exception>
        public override Dictionary<string, object> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException($"JsonTokenType was of type {reader.TokenType}, only objects are supported");
            }

            var dictionary = new Dictionary<string, object>();

            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject)
                {
                    return dictionary;
                }

                if (reader.TokenType != JsonTokenType.PropertyName)
                {
                    throw new JsonException("JsonTokenType was not PropertyName");
                }

                var propertyName = reader.GetString();

                if (string.IsNullOrWhiteSpace(propertyName))
                {
                    throw new JsonException("Failed to get property name");
                }

                reader.Read();

                dictionary.Add(propertyName, ExtractValue(ref reader, options));
            }

            return dictionary;
        }

        /// <summary>
        /// Will serialize string/object dictionary to the JSON
        /// </summary>
        /// <param name="writer">JSON writer</param>
        /// <param name="value">input dictionary</param>
        /// <param name="options">serializer options</param>
        public override void Write(Utf8JsonWriter writer, Dictionary<string, object> value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, options);
        }

        /// <summary>
        /// Get object value by reader token type
        /// </summary>
        /// <param name="reader">JSON reader</param>
        /// <param name="options">serializer options</param>
        /// <returns>result object</returns>
        /// <exception cref="JsonException"></exception>
        private object ExtractValue(ref Utf8JsonReader reader, JsonSerializerOptions options)
        {
            switch (reader.TokenType)
            {
                case JsonTokenType.String:
                    if (reader.TryGetDateTime(out var date))
                    {
                        return date;
                    }

                    return reader.GetString();

                case JsonTokenType.False:
                    return false;

                case JsonTokenType.True:
                    return true;

                case JsonTokenType.Null:
                    return null;

                case JsonTokenType.Number:
                    if (reader.TryGetInt32(out var result))
                    {
                        return result;
                    }

                    return reader.GetDecimal();

                case JsonTokenType.StartObject:
                    return Read(ref reader, null, options);

                case JsonTokenType.StartArray:
                    var list = new List<object>();

                    while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
                    {
                        list.Add(ExtractValue(ref reader, options));
                    }

                    return list;

                default:
                    throw new JsonException($"'{reader.TokenType}' is not supported");
            }
        }
    }
}
