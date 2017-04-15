using System;
using System.Collections.Generic;

namespace Claytondus.EasyPost.Models {
    public class ScanForm
    {
        public string id { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public List<string> tracking_codes { get; set; }
        public Address address { get; set; }
        public string form_url { get; set; }
        public string form_file_type { get; set; }
        public string mode { get; set; }
        public string status { get; set; }
        public string message { get; set; }
        public string batch_id { get; set; }

    }
}
