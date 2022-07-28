using System;
using System.Collections.Generic;

namespace BsistemaPos.Models
{
    public partial class Sale
    {
        public int SaleId { get; set; }
        public int InvoiceIdFk { get; set; }
        public int ProductIdFk { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal SubTotal { get; set; }

        //public virtual Invoice InvoiceIdFkNavigation { get; set; } = null!;
        //public virtual Product ProductIdFkNavigation { get; set; } = null!;
    }
}
