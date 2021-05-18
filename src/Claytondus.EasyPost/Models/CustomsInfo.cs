using System;
using System.Collections.Generic;

namespace Claytondus.EasyPost.Models
{
    public class CustomsInfo
    {
        public string? id { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public string? contents_type { get; set; }
        public string? contents_explanation { get; set; }
        public string? customs_certify { get; set; }
        public string? customs_signer { get; set; }
        public string? eel_pfc { get; set; }
        public string? non_delivery_option { get; set; }
        public string? restriction_type { get; set; }
        public string? restriction_comments { get; set; }
        public List<CustomsItem>? customs_items { get; set; }
        public string? mode { get; set; }
    }
}
