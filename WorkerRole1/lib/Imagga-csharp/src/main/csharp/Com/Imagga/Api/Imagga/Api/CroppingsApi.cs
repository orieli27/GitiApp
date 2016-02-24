using System;
using System.IO;
using System.Collections.Generic;
using RestSharp;
using Com.Imagga.Api.Imagga.Client;
using Com.Imagga.Api.Imagga.Model;

namespace Com.Imagga.Api.Imagga.Api
{
    
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface ICroppingsApi
    {
        
        /// <summary>
        /// Analyze an image and return the best coordinates for cropping it
        /// </summary>
        /// <remarks>
        /// Analyze an image and return the best coordinates for cropping it in a specific size
        /// </remarks>
        /// <param name="url">url</param>
        /// <param name="content">Content id received by uploading an image to the content endpoint</param>
        /// <param name="resolution">Resolution pair in the form (width)x(height) where &#39;x&#39; is just the small letter x.</param>
        /// <param name="noScaling">Whether to apply any scaling to the smart-cropping output results or not.</param>
        /// <returns>CroppingsResponse</returns>
        CroppingsResponse Croppings (string url, string content, string resolution, string noScaling);
  
        /// <summary>
        /// Analyze an image and return the best coordinates for cropping it
        /// </summary>
        /// <remarks>
        /// Analyze an image and return the best coordinates for cropping it in a specific size
        /// </remarks>
        /// <param name="url">url</param>
        /// <param name="content">Content id received by uploading an image to the content endpoint</param>
        /// <param name="resolution">Resolution pair in the form (width)x(height) where &#39;x&#39; is just the small letter x.</param>
        /// <param name="noScaling">Whether to apply any scaling to the smart-cropping output results or not.</param>
        /// <returns>CroppingsResponse</returns>
        System.Threading.Tasks.Task<CroppingsResponse> CroppingsAsync (string url, string content, string resolution, string noScaling);
        
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class CroppingsApi : ICroppingsApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CroppingsApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public CroppingsApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient; 
            else
                this.ApiClient = apiClient;
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="CroppingsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public CroppingsApi(String basePath)
        {
            this.ApiClient = new ApiClient(basePath);
        }
    
        /// <summary>
        /// Sets the base path of the API client.
        /// </summary>
        /// <param name="basePath">The base path</param>
        /// <value>The base path</value>
        public void SetBasePath(String basePath)
        {
            this.ApiClient.BasePath = basePath;
        }
    
        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        public String GetBasePath()
        {
            return this.ApiClient.BasePath;
        }
    
        /// <summary>
        /// Gets or sets the API client.
        /// </summary>
        /// <value>An instance of the ApiClient</value>
        public ApiClient ApiClient {get; set;}
    
        
        /// <summary>
        /// Analyze an image and return the best coordinates for cropping it Analyze an image and return the best coordinates for cropping it in a specific size
        /// </summary>
        /// <param name="url">url</param> 
        /// <param name="content">Content id received by uploading an image to the content endpoint</param> 
        /// <param name="resolution">Resolution pair in the form (width)x(height) where &#39;x&#39; is just the small letter x.</param> 
        /// <param name="noScaling">Whether to apply any scaling to the smart-cropping output results or not.</param> 
        /// <returns>CroppingsResponse</returns>            
        public CroppingsResponse Croppings (string url, string content, string resolution, string noScaling)
        {
            
    
            var path_ = "/croppings";
    
            var pathParams = new Dictionary<String, String>();
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            // to determine the Accept header
            String[] http_header_accepts = new String[] {
                "application/json"
            };
            String http_header_accept = ApiClient.SelectHeaderAccept(http_header_accepts);
            if (http_header_accept != null)
                headerParams.Add("Accept", ApiClient.SelectHeaderAccept(http_header_accepts));

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            pathParams.Add("format", "json");
            
            if (url != null) queryParams.Add("url", ApiClient.ParameterToString(url)); // query parameter
            if (content != null) queryParams.Add("content", ApiClient.ParameterToString(content)); // query parameter
            if (resolution != null) queryParams.Add("resolution", ApiClient.ParameterToString(resolution)); // query parameter
            if (noScaling != null) queryParams.Add("no_scaling", ApiClient.ParameterToString(noScaling)); // query parameter
            
            
            
            
    
            // authentication setting, if any
            String[] authSettings = new String[] { "Default" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path_, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, pathParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling Croppings: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling Croppings: " + response.ErrorMessage, response.ErrorMessage);
    
            return (CroppingsResponse) ApiClient.Deserialize(response, typeof(CroppingsResponse));
        }
    
        /// <summary>
        /// Analyze an image and return the best coordinates for cropping it Analyze an image and return the best coordinates for cropping it in a specific size
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="content">Content id received by uploading an image to the content endpoint</param>
        /// <param name="resolution">Resolution pair in the form (width)x(height) where &#39;x&#39; is just the small letter x.</param>
        /// <param name="noScaling">Whether to apply any scaling to the smart-cropping output results or not.</param>
        /// <returns>CroppingsResponse</returns>
        public async System.Threading.Tasks.Task<CroppingsResponse> CroppingsAsync (string url, string content, string resolution, string noScaling)
        {
            
    
            var path_ = "/croppings";
    
            var pathParams = new Dictionary<String, String>();
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            // to determine the Accept header
            String[] http_header_accepts = new String[] {
                "application/json"
            };
            String http_header_accept = ApiClient.SelectHeaderAccept(http_header_accepts);
            if (http_header_accept != null)
                headerParams.Add("Accept", ApiClient.SelectHeaderAccept(http_header_accepts));

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            pathParams.Add("format", "json");
            
            if (url != null) queryParams.Add("url", ApiClient.ParameterToString(url)); // query parameter
            if (content != null) queryParams.Add("content", ApiClient.ParameterToString(content)); // query parameter
            if (resolution != null) queryParams.Add("resolution", ApiClient.ParameterToString(resolution)); // query parameter
            if (noScaling != null) queryParams.Add("no_scaling", ApiClient.ParameterToString(noScaling)); // query parameter
            
            
            
            
    
            // authentication setting, if any
            String[] authSettings = new String[] { "Default" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) await ApiClient.CallApiAsync(path_, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, pathParams, authSettings);
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling Croppings: " + response.Content, response.Content);

            return (CroppingsResponse) ApiClient.Deserialize(response, typeof(CroppingsResponse));
        }
        
    }
    
}
