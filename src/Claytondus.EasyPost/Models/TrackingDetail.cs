using System;

namespace Claytondus.EasyPost.Models {
    public class TrackingDetail  {
        public DateTime? datetime { get; set; }
        public string message { get; set; }
        public string status { get; set; }
        public TrackingLocation tracking_location { get; set; }
    }
}
