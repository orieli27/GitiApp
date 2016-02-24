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
    public interface IContentApi
    {
        
        /// <summary>
        /// Upload an image file to the API and get content id for processing it using one of the other endpoint methods.
        /// </summary>
        /// <remarks>
        /// Upload an image file to the API and get content id for processing it using one of the other endpoint method.
        /// </remarks>
        /// <param name="image">image</param>
        /// <returns>UploadsResponse</returns>
        UploadsResponse Upload (Stream image);
  
        /// <summary>
        /// Upload an image file to the API and get content id for processing it using one of the other endpoint methods.
        /// </summary>
        /// <remarks>
        /// Upload an image file to the API and get content id for processing it using one of the other endpoint method.
        /// </remarks>
        /// <param name="image">image</param>
        /// <returns>UploadsResponse</returns>
        System.Threading.Tasks.Task<UploadsResponse> UploadAsync (Stream image);
        
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class ContentApi : IContentApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContentApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public ContentApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient; 
            else
                this.ApiClient = apiClient;
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="ContentApi"/> class.
        /// </summary>
        /// <returns></returns>
        public ContentApi(String basePath)
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
        /// Upload an image file to the API and get content id for processing it using one of the other endpoint methods. Upload an image file to the API and get content id for processing it using one of the other endpoint method.
        /// </summary>
        /// <param name="image">image</param> 
        /// <returns>UploadsResponse</returns>            
        public UploadsResponse Upload (Stream image)
        {
            
            // verify the required parameter 'image' is set
            if (image == null) throw new ApiException(400, "Missing required parameter 'image' when calling Upload");
            
    
            var path_ = "/content";
    
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
            
            
            
            if (image != null) fileParams.Add("image", ApiClient.ParameterToFile("image", image));
            
            
    
            // authentication setting, if any
            String[] authSettings = new String[] { "Default" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) ApiClient.CallApi(path_, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, pathParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling Upload: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling Upload: " + response.ErrorMessage, response.ErrorMessage);
    
            return (UploadsResponse) ApiClient.Deserialize(response, typeof(UploadsResponse));
        }
    
        /// <summary>
        /// Upload an image file to the API and get content id for processing it using one of the other endpoint methods. Upload an image file to the API and get content id for processing it using one of the other endpoint method.
        /// </summary>
        /// <param name="image">image</param>
        /// <returns>UploadsResponse</returns>
        public async System.Threading.Tasks.Task<UploadsResponse> UploadAsync (Stream image)
        {
            // verify the required parameter 'image' is set
            if (image == null) throw new ApiException(400, "Missing required parameter 'image' when calling Upload");
            
    
            var path_ = "/content";
    
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
            
            
            
            if (image != null) fileParams.Add("image", ApiClient.ParameterToFile("image", image));
            
            
    
            // authentication setting, if any
            String[] authSettings = new String[] { "Default" };
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) await ApiClient.CallApiAsync(path_, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, pathParams, authSettings);
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling Upload: " + response.Content, response.Content);

            return (UploadsResponse) ApiClient.Deserialize(response, typeof(UploadsResponse));
        }
        
    }
    
}
