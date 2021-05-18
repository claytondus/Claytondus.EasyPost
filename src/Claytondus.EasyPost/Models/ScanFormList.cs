using System;
using System.Collections.Generic;
using System.Linq;

namespace Claytondus.EasyPost.Models
{
    public class ScanFormList
    {
        public List<ScanForm>? scanForms { get; set; }
        public bool has_more { get; set; }

        public Dictionary<string, object>? filters { get; set; }
    }
}
