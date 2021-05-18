using System;

namespace Claytondus.EasyPost.Models
{
    public class Container
    {
        public string? id { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public string? name { get; set; }
        public string? type { get; set; }
        public string? reference { get; set; }
        public double length { get; set; }
        public double width { get; set; }
        public double height { get; set; }
        public double max_weight { get; set; }
    }
}
