using System;
using System.Collections.Generic;

namespace BsistemaPos.Models
{
    public partial class Client
    {
        public Client()
        {
            Invoices = new HashSet<Invoice>();
        }

        public string ClientId { get; set; } = null!;
        public string CName { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string CAddress { get; set; } = null!;

        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
