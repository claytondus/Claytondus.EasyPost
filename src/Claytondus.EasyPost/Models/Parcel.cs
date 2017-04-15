using System;

namespace Claytondus.EasyPost.Models
{
    public class Parcel
    {
        public string id { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public string mode { get; set; }
        public float? length { get; set; }
        public float? width { get; set; }
        public float? height { get; set; }
        public string predefined_package { get; set; }
        public float weight { get; set; }
    }
}
