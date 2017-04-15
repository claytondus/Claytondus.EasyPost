using System;
using System.Collections.Generic;

namespace Claytondus.EasyPost.Models
{
    public class Address
    {
        public string id { get; set; }
        public string mode { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public string name { get; set; }
        public string company { get; set; }
        public string street1 { get; set; }
        public string street2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public string country { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public bool? residential { get; set; }
        public string carrier_facility { get; set; }
        public string federal_tax_id { get; set; }
        public string state_tax_id { get; set; }
        public List<string> verify { get; set; }
        public List<string> verify_strict { get; set; }
        public Verifications verifications { get; set; }
    }
}