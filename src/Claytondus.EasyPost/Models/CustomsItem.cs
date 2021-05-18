using System;

namespace Claytondus.EasyPost.Models
{
    public class CustomsItem
    {
        public string? id { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public string? description { get; set; }
        public string? hs_tariff_number { get; set; }
        public string? origin_country { get; set; }
        public int quantity { get; set; }
        public double value { get; set; }
        public double weight { get; set; }
        public string? code { get; set; }
        public string? mode { get; set; }
        public string? currency { get; set; }
    }
}
