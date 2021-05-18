using System;
using System.Collections.Generic;

namespace Claytondus.EasyPost.Models
{
    public class Batch
    {
        public string? id { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
        public string? state { get; set; }
        public int num_shipments { get; set; }
        public string? reference { get; set; }
        public List<BatchShipment>? shipments { get; set; }
        public Dictionary<string, int>? status { get; set; }
        public ScanForm? scan_form { get; set; }
        public string? label_url { get; set; }
        public string? mode { get; set; }
        public string? error { get; set; }
        public string? message { get; set; }

    }
}
