//--------------------------------------------------------------------------------------
// <copyright file="Product.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//---------------------------------------------------------------------------------------

using System.Text.Json;
using System.Text.Json.Serialization;

namespace Recipies
{
    public class Product : IJsonConvertible
    {
        [JsonConstructor]
        public Product(string description, double unitCost)
        {
            this.Description = description;
            this.UnitCost = unitCost;
        }

        public Product(string json)
        {
            this.LoadFromJson(json);
        }
        public string Description { get; set; }

        public double UnitCost { get; set; }

        public void LoadFromJson(string json)
        {
            Product readProduct = JsonSerializer.Deserialize<Product>(json);
            this.Description = readProduct.Description;
            this.UnitCost = readProduct.UnitCost;
        }

        public string ConvertToJson()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}