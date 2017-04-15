using System;
using System.Collections.Generic;

namespace Claytondus.EasyPost.Models {
    public class Webhook  {
        public string id { get; set; }
        public string mode { get; set; }
        public string url { get; set; }
        public DateTime? disabled_at { get; set; }

       
    }
}
