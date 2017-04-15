using System.Collections.Generic;
using System.Linq;

namespace Claytondus.EasyPost.Models {
    public class TrackerList {
        public List<Tracker> trackers { get; set; }
        public bool has_more { get; set; }

        public Dictionary<string, object> filters { get; set; }

    }
}
