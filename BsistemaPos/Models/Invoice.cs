using System;
using System.Collections.Generic;

namespace BsistemaPos.Models
{
    public partial class Invoice
    {
        public Invoice()
        {
            Sales = new HashSet<Sale>();
        }

        public int InvoiceId { get; set; }
        public string ClientIdFk { get; set; } = null!;
        public decimal Total { get; set; }
        public double Iva { get; set; }
        public DateTime InvoiceDate { get; set; }

        public virtual Client ClientIdFkNavigation { get; set; } = null!;
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
