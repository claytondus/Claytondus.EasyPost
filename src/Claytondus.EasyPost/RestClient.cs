using System;
using System.Threading.Tasks;
using Claytondus.EasyPost.Models;
using Flurl;
using Flurl.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NullValueHandling = Newtonsoft.Json.NullValueHandling;

namespace Claytondus.EasyPost
{
    public class RestClient
    {
        private readonly Url EasyPostUrl = "https://api.easypost.com/v2";
	    private readonly string _authToken;
	    private readonly ILogger? _logger;

        private static readonly JsonSerializerSettings jsonSettings = new()
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

	    public RestClient(string authToken, TimeSpan? timeout = null, ILogger? logger = null)
	    {
		    _authToken = authToken;
		    _logger = logger;
		    FlurlHttp.Configure(c => {
			    c.JsonSerializer = new Flurl.Http.Configuration.NewtonsoftJsonSerializer(jsonSettings);
			    c.Timeout = timeout ?? TimeSpan.FromSeconds(10);
		    });
	    }


	    protected async Task<T> GetAsync<T>(string resource, object? queryParams = null) where T : class
	    {
		    try
		    {
			    var response = await new Url(EasyPostUrl)
				    .AppendPathSegment(resource)
				    .SetQueryParams(queryParams)
				    .WithDefaults()
				    .WithOAuthBearerToken(_authToken)
					.GetAsync();
                _logger?.LogTrace(response.ResponseMessage.RequestMessage.ToString());
			    var responseBody = await response.GetStringAsync();
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
			        HttpStatus = ex.Call.HttpResponseMessage.StatusCode
			    };
			}
		}

		protected async Task<T> PostAsync<T>(string resource, object? body)
	    {
            try
			{
				var response = await new Url(EasyPostUrl)
                    .AppendPathSegment(resource)
					.WithDefaults()
			        .WithOAuthBearerToken(_authToken)
			        .PostJsonAsync(body);
                _logger?.LogTrace("{0}",response.ResponseMessage.RequestMessage.ToString());
                var responseBody = await response.GetStringAsync();
                _logger?.LogTrace("Response: {0}", responseBody);
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
			        HttpStatus = ex.Call.HttpResponseMessage.StatusCode,
			        HttpMessage = ex.Message,
			        RequestBody = ex.Call.RequestBody
			    };
			}

	    }

		protected async Task<T> PutAsync<T>(string resource, object? body = null)
		{
            _logger?.LogTrace("PUT {0}", resource);
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
		            HttpStatus = ex.Call.HttpResponseMessage.StatusCode,
		            HttpMessage = ex.Message,
		            RequestBody = ex.Call.RequestBody
		        };
		    }
		}

        protected async Task DeleteAsync(string resource, object? queryParams = null)
        {
            _logger?.LogTrace("DELETE {0}", resource);
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
                    HttpStatus = ex.Call.HttpResponseMessage.StatusCode,
                    HttpMessage = ex.Message
                };
            }
        }

        protected async Task<T> DeleteAsync<T>(string resource, object? queryParams = null)
		{
            _logger?.LogTrace("DELETE {0}", resource);
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
			        HttpStatus = ex.Call.HttpResponseMessage.StatusCode,
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
				.WithHeader("Accept", "application/json");
		}
	}
}
