
using System;
using System.Collections.Generic;

namespace Claytondus.EasyPost.Models {
    public class CarrierAccount {
        public string id { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public string type { get; set; }
        public string description { get; set; }
        public string reference { get; set; }
        public string readable { get; set; }
        public Dictionary<string, dynamic> credentials { get; set; }
        public Dictionary<string, dynamic> test_credentials { get; set; }

    }
}
