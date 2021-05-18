using System;
using System.Collections.Generic;
using System.Linq;

namespace Claytondus.EasyPost.Models
{
    public class ShipmentList
    {
        public List<Shipment>? shipments { get; set; }
        public bool has_more { get; set; }

        public Dictionary<string, object>? filters { get; set; }

    }

    public class RetrieveShipmentList
    {
        public string? before_id { get; set; }
        public string? after_id { get; set; }
        public DateTime? start_datetime { get; set; }
        public DateTime? end_datetime { get; set; }
        public byte? page_size { get; set; }
        public bool? purchased { get; set; }
        public bool? include_children { get; set; }
    }
}
