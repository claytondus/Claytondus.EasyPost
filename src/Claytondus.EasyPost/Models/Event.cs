﻿using System;
using System.Collections.Generic;

namespace Claytondus.EasyPost.Models {
    public class Event  {
        public string id { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public Dictionary<string, object> result { get; set; }
        public string description { get; set; }
        public string mode { get; set; }
        public Dictionary<string, object> previous_attributes { get; set; }
        public List<string> pending_urls { get; set; }
        public List<string> completed_urls { get; set; }
        public string status { get; set; }

        
    }
}