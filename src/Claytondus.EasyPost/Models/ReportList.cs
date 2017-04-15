using System.Collections.Generic;
using System.Linq;

namespace Claytondus.EasyPost.Models {
    public class ReportList {
        public List<Report> reports { get; set; }
        public bool has_more { get; set; }

        public Dictionary<string, object> filters { get; set;  }
        public string type { get; set; }

    }
}
