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
    public interface IColorsApi
    {
        
        /// <summary>
        /// Analyze image and extract its dominant colors
        /// </summary>
        /// <remarks>
        /// Extract colors
        /// </remarks>
        /// <param name="url">url</param>
        /// <param name="content">content</param>
        /// <param name="extractOverallColors">extract_overall_colors</param>
        /// <param name="extractObjectColors">extract_object_colors</param>
        /// <returns>ColorsResponse</returns>
        ColorsResponse ExtractColors (string url, string content, string extractOverallColors, string extractObjectColors);
  
        /// <summary>
        /// Analyze image and extract its dominant colors
        /// </summary>
        /// <remarks>
        /// Extract colors
        /// </remarks>
        /// <param name="url">url</param>
        /// <param name="content">content</param>
        /// <param name="extractOverallColors">extract_overall_colors</param>
        /// <param name="extractObjectColors">extract_object_colors</param>
        /// <returns>ColorsResponse</returns>
        System.Threading.Tasks.Task<ColorsResponse> ExtractColorsAsync (string url, string content, string extractOverallColors, string extractObjectColors);
        
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class ColorsApi : IColorsApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ColorsApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public ColorsApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient; 
            else
                this.ApiClient = apiClient;
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="ColorsApi"/> class.
        /// </summary>
        /// <returns></returns>
        public ColorsApi(String basePath)
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
        /// Analyze image and extract its dominant colors Extract colors
        /// </summary>
        /// <param name="url">url</param> 
        /// <param name="content">content</param> 
        /// <param name="extractOverallColors">extract_overall_colors</param> 
        /// <param name="extractObjectColors">extract_object_colors</param> 
        /// <returns>ColorsResponse</returns>            
        public ColorsResponse ExtractColors (string url, string content, string extractOverallColors, string extractObjectColors)
        {
            
    
            var path_ = "/colors";
    
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
            if (extractOverallColors != null) queryParams.Add("extract_overall_colors", ApiClient.ParameterToString(extractOverallColors)); // query parameter
            if (extractObjectColors != null) queryParams.Add("extract_object_colors", ApiClient.ParameterToString(extractObjectColors)); // query parameter
            
            
            
            
    
            // authentication setting, if any
            String[] authSettings = new String[] { "Default" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path_, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, pathParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling ExtractColors: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling ExtractColors: " + response.ErrorMessage, response.ErrorMessage);
    
            return (ColorsResponse) ApiClient.Deserialize(response, typeof(ColorsResponse));
        }
    
        /// <summary>
        /// Analyze image and extract its dominant colors Extract colors
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="content">content</param>
        /// <param name="extractOverallColors">extract_overall_colors</param>
        /// <param name="extractObjectColors">extract_object_colors</param>
        /// <returns>ColorsResponse</returns>
        public async System.Threading.Tasks.Task<ColorsResponse> ExtractColorsAsync (string url, string content, string extractOverallColors, string extractObjectColors)
        {
            
    
            var path_ = "/colors";
    
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
            if (extractOverallColors != null) queryParams.Add("extract_overall_colors", ApiClient.ParameterToString(extractOverallColors)); // query parameter
            if (extractObjectColors != null) queryParams.Add("extract_object_colors", ApiClient.ParameterToString(extractObjectColors)); // query parameter
            
            
            
            
    
            // authentication setting, if any
            String[] authSettings = new String[] { "Default" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) await ApiClient.CallApiAsync(path_, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, pathParams, authSettings);
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling ExtractColors: " + response.Content, response.Content);

            return (ColorsResponse) ApiClient.Deserialize(response, typeof(ColorsResponse));
        }
        
    }
    
}
