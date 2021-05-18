using System.Collections.Generic;

namespace Claytondus.EasyPost.Models
{
    public class CarrierType
    {
        public string? type { get; set; }
        public string? readable { get; set; }
        public string? logo { get; set; }
        public Dictionary<string, object>? fields { get; set; }
    }
}
