using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Extensions.Configuration;
using pathways_api.Services.Interfaces;
using Remotion.Linq.Clauses;

namespace pathways_api.Services
{
    public class GetUserDataService : IGetUserDataService
    {
        //get data in domo        
        
        public void RequestAccessToken()
        {
             
        }

        public void GetDatasetList()
        {

            //get access token

        }

        public void GetDataset(int id)
        {
            //get access token
            
            
        }
        
        public void GetDatasetData(int id)
        {
            
                    
        }

        public void CallDomoApi()
        {

        }
        
        public void GetAccessToken()
        {
        
        }    
    }
}