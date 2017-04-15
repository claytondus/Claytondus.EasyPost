using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Claytondus.EasyPost.Models
{
    public class Error
    {
        public string code { get; set; }
        public string message { get; set; }
        public List<FieldError> errors { get; set; }
    }

    public class FieldError
    {
        public string field { get; set; }
        public string message { get; set; }
    }
}
