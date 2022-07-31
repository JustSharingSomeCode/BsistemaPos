using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BsistemaPos.Models
{
    public partial class Invoice
    {
        public Invoice()
        { }

        public int InvoiceId { get; set; }
        public string ClientIdFk { get; set; } = null!;
        public decimal Total { get; set; }
        public DateTime InvoiceDate { get; set; }
    }
}
