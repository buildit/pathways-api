namespace pathways_api
{
    public class DomoClient
    {
        /// <summary>
        /// A secret code that proves to the authentication server that the client program is authorized to make a request on behalf of the user
        /// Client Secrets are required for OAuth 2.0.
        /// //ex. to use  byte[] key = Encoding.ASCII.GetBytes(appSettings.Secret);
        /// </summary>
        public string ClientSecret { get; set; }
        
        /// <summary>
        /// Url used to access domo dataset (needs unique id appended to the end of the url) 
        /// </summary>
        public string DataSetsUrl { get; set; }
        
        /// <summary>
        /// Data set ID for Bench data, to retrieve from domo
        /// Can be used append to the DomoDataSetsUrl
        /// </summary>
        public string BenchDataSetId { get; set; }
        
        /// <summary>
        /// Client Id for Domo; An ID used to uniquely identify a third-party client.
        /// </summary>
        public string ClientId { get; set; }
        
        /// <summary>
        /// append to get the dataset data
        /// ex: DomoDatasetsUrl + BenchDatasetId + DataSetDataUrl
        /// </summary>
        public string DataSetDataUrl { get; set; }
        
        /// <summary>
        /// Api key for domo
        /// </summary>
        public string ApiId { get; set; }
        
        /// <summary>
        /// Domo access token url to get domo access token for user
        /// ex. DomoAccessTokenDataUrl + DomoAccessTokenUserUrl
        /// </summary>
        public string AccessTokenUserUrl { get; set; }
        
        /// <summary>
        /// Domo access token url to get domo access token for data
        /// </summary>
        public string AccessTokenDataUrl { get; set; }
    }
}