using System;
using System.Collections.Generic;

namespace Claytondus.EasyPost.Models {
    public class Item  {
        public string id { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public string mode { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string reference { get; set; }
        public string harmonized_code { get; set; }
        public string country_of_origin { get; set; }
        public string warehouse_location { get; set; }
        public double value { get; set; }
        public double length { get; set; }
        public double width { get; set; }
        public double height { get; set; }
        public double weight { get; set; }
        // ADD CUSTOM REFERENCES (e.g. sku, upc)

        
    }
}
