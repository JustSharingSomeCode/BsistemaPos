using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BsistemaPos.Models
{
    public partial class Client
    {
        public Client()
        { }

        public string ClientId { get; set; } = null!;
        public string CName { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string CAddress { get; set; } = null!;
    }
}
