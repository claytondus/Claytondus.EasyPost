using System;
using System.Collections.Generic;

namespace Claytondus.EasyPost.Models {
    public class Tracker  {
        public string id { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime tracking_updated_at { get; set; }
        public DateTime? updated_at { get; set; }
        public DateTime? est_delivery_date { get; set; }
        public string mode { get; set; }
        public string shipment_id { get; set; }
        public string status { get; set; }
        public string carrier { get; set; }
        public string tracking_code { get; set; }
        public string signed_by { get; set; }
        public double? weight { get; set; }
        public string public_url { get; set; }
        public List<TrackingDetail> tracking_details { get; set; }
        public CarrierDetail carrier_detail { get; set; }
        }
}
