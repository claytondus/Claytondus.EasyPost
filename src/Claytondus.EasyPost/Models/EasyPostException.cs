using System;
using System.Net;
using Newtonsoft.Json;

namespace Claytondus.EasyPost.Models
{
	public class EasyPostException : Exception
	{
		[JsonConstructor]
		public EasyPostException(string type, string message) : base(message)
		{
			EasyPostType = type;
		    ResponseBody = message;
		}

		public string EasyPostType { get; set; }
        public string RequestBody { get; set; }
        public string ResponseBody { get; set; }

		public HttpStatusCode? HttpStatus { get; set; }

        public string Method { get; set; }
        public string Resource { get; set; }
        public string HttpMessage { get; set; }


	}
}
