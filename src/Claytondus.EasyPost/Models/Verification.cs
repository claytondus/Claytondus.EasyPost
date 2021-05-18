using System.Collections.Generic;

namespace Claytondus.EasyPost.Models
{
    public class Verification
    {
        public bool success { get; set; }
        public List<FieldError>? errors { get; set; }
        public VerificationDetails? details { get; set; }
    }

    public class Verifications
    {
        public Verification? zip4 { get; set; }
        public Verification? delivery { get; set; }
    }

    public class VerificationDetails
    {
        public string? latitude { get; set; }
        public string? longitude { get; set; }
    }
}
