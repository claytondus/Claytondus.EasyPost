using System;
using System.Collections.Generic;

namespace Claytondus.EasyPost.Models {
    public class Report  {
        public string id { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public DateTime? start_date { get; set; }
        public DateTime? end_date { get; set; }
        public string mode { get; set; }
        public string status { get; set; }
        public Boolean include_children { get; set; }
        public string url { get; set; }
        public DateTime? url_expires_at { get; set; }

       
    }
}
