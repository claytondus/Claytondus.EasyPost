
using System;
using System.Collections.Generic;

namespace Claytondus.EasyPost.Models {
    public class Order  {
        public string id { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public string mode { get; set; }
        public string reference { get; set; }
        public bool? is_return { get; set; }
        public List<Message> messages { get; set; }
        public Address from_address { get; set; }
        public Address return_address { get; set; }
        public Address to_address { get; set; }
        public Address buyer_address { get; set; }
        public CustomsInfo customs_info { get; set; }
        public List<Shipment> shipments { get; set; }
        public List<CarrierAccount> carrier_accounts { get; set; }
        public List<Rate> rates { get; set; }
        public List<Container> containers { get; set; }
        public List<Item> items { get; set; }

        
    }
}
