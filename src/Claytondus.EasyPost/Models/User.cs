
using System;
using System.Collections.Generic;

namespace Claytondus.EasyPost.Models {
    public class User  {
        public string id { get; set; }
        public string parent_id { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public string password { get; set; }
        public string password_confirmation { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone_number { get; set; }
        public string balance { get; set; }
        public string price_per_shipment { get; set; }
        public string recharge_amount { get; set; }
        public string secondary_recharge_amount { get; set; }
        public string recharge_threshold { get; set; }
        public List<User> children { get; set; }
        public List<ApiKey> api_keys { get; set; }

        
    }
}