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
    public interface ITaggingApi
    {
        
        /// <summary>
        /// Analyze an image and return keywords describing it
        /// </summary>
        /// <remarks>
        /// Analyze an image and return keywords describing it
        /// </remarks>
        /// <param name="url">url</param>
        /// <param name="content">Content id received by uploading an image to the content endpoint</param>
        /// <returns>TaggingResponse</returns>
        TaggingResponse Tagging (string url, string content);
  
        /// <summary>
        /// Analyze an image and return keywords describing it
        /// </summary>
        /// <remarks>
        /// Analyze an image and return keywords describing it
        /// </remarks>
        /// <param name="url">url</param>
        /// <param name="content">Content id received by uploading an image to the content endpoint</param>
        /// <returns>TaggingResponse</returns>
        System.Threading.Tasks.Task<TaggingResponse> TaggingAsync (string url, string content);
        
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class TaggingApi : ITaggingApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TaggingApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public TaggingApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient; 
            else
                this.ApiClient = apiClient;
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="TaggingApi"/> class.
        /// </summary>
        /// <returns></returns>
        public TaggingApi(String basePath)
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
        /// Analyze an image and return keywords describing it Analyze an image and return keywords describing it
        /// </summary>
        /// <param name="url">url</param> 
        /// <param name="content">Content id received by uploading an image to the content endpoint</param> 
        /// <returns>TaggingResponse</returns>            
        public TaggingResponse Tagging (string url, string content)
        {
            
    
            var path_ = "/tagging";
    
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
            
            
            
            
    
            // authentication setting, if any
            String[] authSettings = new String[] { "Default" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path_, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, pathParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling Tagging: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling Tagging: " + response.ErrorMessage, response.ErrorMessage);
    
            return (TaggingResponse) ApiClient.Deserialize(response, typeof(TaggingResponse));
        }
    
        /// <summary>
        /// Analyze an image and return keywords describing it Analyze an image and return keywords describing it
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="content">Content id received by uploading an image to the content endpoint</param>
        /// <returns>TaggingResponse</returns>
        public async System.Threading.Tasks.Task<TaggingResponse> TaggingAsync (string url, string content)
        {
            
    
            var path_ = "/tagging";
    
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
            
            
            
            
    
            // authentication setting, if any
            String[] authSettings = new String[] { "Default" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) await ApiClient.CallApiAsync(path_, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, pathParams, authSettings);
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling Tagging: " + response.Content, response.Content);

            return (TaggingResponse) ApiClient.Deserialize(response, typeof(TaggingResponse));
        }
        
    }
    
}
