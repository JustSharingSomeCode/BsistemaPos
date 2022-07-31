using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BsistemaPos.Models
{
    public partial class Product
    {
        public Product()
        { }

        public int ProductId { get; set; }
        public string PName { get; set; } = null!;
        public string PDescription { get; set; } = null!;
        public int Stock { get; set; }
        public string? Img { get; set; }
        public decimal Price { get; set; }
    }
}
