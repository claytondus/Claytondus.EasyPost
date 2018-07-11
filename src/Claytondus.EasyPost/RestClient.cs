using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Claytondus.EasyPost.Logging;
using Claytondus.EasyPost.Models;
using Flurl;
using Flurl.Http;
using Newtonsoft.Json;
using NullValueHandling = Newtonsoft.Json.NullValueHandling;

namespace Claytondus.EasyPost
{
    public class RestClient
    {
        private readonly string EasyPostUrl = "https://api.easypost.com/v2";
	    private readonly string _authToken;
        private static readonly ILog Log = LogProvider.For<RestClient>();

        private static readonly JsonSerializerSettings jsonSettings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            Error = (sender, args) =>
            {
                if (System.Diagnostics.Debugger.IsAttached)
                {
                    System.Diagnostics.Debugger.Break();
                }
            }
        };

		public RestClient(string authToken)
		{
			_authToken = authToken;
		    FlurlHttp.Configure(c => {
		        c.JsonSerializer = new Flurl.Http.Configuration.NewtonsoftJsonSerializer(jsonSettings);
		    });
        }


	    protected async Task<T> GetAsync<T>(string resource, object queryParams = null) where T : class
	    {
		    try
		    {
			    var response = await new Url(EasyPostUrl)
				    .AppendPathSegment(resource)
				    .SetQueryParams(queryParams)
				    .WithDefaults()
				    .WithOAuthBearerToken(_authToken)
					.GetAsync();
                Log.Trace(response.RequestMessage.ToString);
			    var responseBody = await response.Content.ReadAsStringAsync();
			    var responseDeserialized = JsonConvert.DeserializeObject<T>(responseBody, jsonSettings);
			    return responseDeserialized;
		    }
			catch (FlurlHttpTimeoutException)
			{
				throw new EasyPostException("timeout", "Request timed out.");
			}
			catch (FlurlHttpException ex)
			{
			    var response = await ex.GetResponseStringAsync();
			    throw new EasyPostException("error", response)
			    {
			        Method = "GET",
			        Resource = resource,
			        HttpStatus = ex.Call.HttpStatus
			    };
			}
		}

		protected async Task<T> PostAsync<T>(string resource, object body)
	    {
            try
			{
				var response = await new Url(EasyPostUrl)
                    .AppendPathSegment(resource)
					.WithDefaults()
			        .WithOAuthBearerToken(_authToken)
			        .PostJsonAsync(body);
                Log.Trace(response.RequestMessage.ToString());
                //Log.Trace("Request: " + await response.RequestMessage.Content.ReadAsStringAsync());
                var responseBody = await response.Content.ReadAsStringAsync();
                Log.Trace("Response: " + responseBody);
                var responseDeserialized = JsonConvert.DeserializeObject<T>(responseBody, jsonSettings);
                return responseDeserialized;
            }
			catch (FlurlHttpTimeoutException)
			{
				throw new EasyPostException("timeout", "Request timed out.");
			}
			catch (FlurlHttpException ex)
			{
                var response = await ex.GetResponseStringAsync();
			    throw new EasyPostException("error", response)
			    {
			        Method = "POST",
			        Resource = resource,
			        HttpStatus = ex.Call.HttpStatus,
			        HttpMessage = ex.Message,
			        RequestBody = ex.Call.RequestBody
			    };
			}
			
	    }

		protected async Task<T> PutAsync<T>(string resource, object body = null)
		{
            Log.Trace("PUT " + resource);
		    try
		    {
		        var response = await new Url(EasyPostUrl)
		            .AppendPathSegment(resource)
		            .WithDefaults()
		            .WithOAuthBearerToken(_authToken)
		            .PutJsonAsync(body)
		            .ReceiveJson<T>();
		        return response;
		    }
		    catch (FlurlHttpTimeoutException)
		    {
		        throw new EasyPostException("timeout", "Request timed out.");
		    }
		    catch (FlurlHttpException ex)
		    {
		        var response = await ex.GetResponseStringAsync();
		        throw new EasyPostException("error", response)
		        {
		            Method = "PUT",
		            Resource = resource,
		            HttpStatus = ex.Call.HttpStatus,
		            HttpMessage = ex.Message,
		            RequestBody = ex.Call.RequestBody
		        };
		    }
		}

        protected async Task DeleteAsync(string resource, object queryParams = null)
        {
            Log.Trace("DELETE " + resource);
            try
            {
                await new Url(EasyPostUrl)
                    .AppendPathSegment(resource)
                    .SetQueryParams(queryParams)
                    .WithDefaults()
                    .WithOAuthBearerToken(_authToken)
                    .DeleteAsync();
            }
            catch (FlurlHttpTimeoutException)
            {
                throw new EasyPostException("timeout", "Request timed out.");
            }
            catch (FlurlHttpException ex)
            {
                var response = await ex.GetResponseStringAsync();
                throw new EasyPostException("error", response)
                {
                    Method = "DELETE",
                    Resource = resource,
                    HttpStatus = ex.Call.HttpStatus,
                    HttpMessage = ex.Message
                };
            }
        }

        protected async Task<T> DeleteAsync<T>(string resource, object queryParams = null)
		{
            Log.Trace("DELETE " + resource);
            try
            {
                var response = await new Url(EasyPostUrl)
                    .AppendPathSegment(resource)
                    .SetQueryParams(queryParams)
                    .WithDefaults()
                    .WithOAuthBearerToken(_authToken)
                    .DeleteAsync()
                    .ReceiveJson<T>();
                return response;
            }
			catch (FlurlHttpTimeoutException)
			{
				throw new EasyPostException("timeout", "Request timed out.");
			}
			catch (FlurlHttpException ex)
			{
                var response = await ex.GetResponseStringAsync();
			    throw new EasyPostException("error", response)
			    {
			        Method = "DELETE",
			        Resource = resource,
			        HttpStatus = ex.Call.HttpStatus,
			        HttpMessage = ex.Message
			    };
			}
        }
	}

	public static class UrlExtension
	{
		public static IFlurlRequest WithDefaults(this Url url)
		{
			return url
				.WithTimeout(10)
				.WithHeader("Accept", "application/json");
		}
	}
}
