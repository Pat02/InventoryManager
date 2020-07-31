using InventoryManager.DnD5eAPI.Models;
using InventoryManager.DnD5eAPI.Results;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace InventoryManager.DnD5eAPI.Converters
{
    class EquipmentListResultConverter : JsonConverter<EquipmentListResult>
    {
        public override EquipmentListResult Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string mycount = string.Empty;
            List<EquipmentListLineItem> mylist = new List<EquipmentListLineItem>();
            if (reader.TokenType == JsonTokenType.String)
            {
                mycount = reader.GetString();
            }
            while (reader.TokenType != JsonTokenType.EndArray)
            {
                JsonSerializer.Deserialize<EquipmentListLineItem>("butts");
            }

            return new EquipmentListResult();
        }

        public override void Write(Utf8JsonWriter writer, EquipmentListResult value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
