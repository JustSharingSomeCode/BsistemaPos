using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BsistemaPos.Models
{
    public partial class Product
    {
        public Product()
        {
            //Sales = new HashSet<Sale>();
        }

        public int ProductId { get; set; }
        public string PName { get; set; } = null!;
        public string PDescription { get; set; } = null!;
        public int Stock { get; set; }
        public string? Img { get; set; }
        /*
        [JsonIgnore]
        public virtual ICollection<Sale> Sales { get; set; }*/
    }
}
