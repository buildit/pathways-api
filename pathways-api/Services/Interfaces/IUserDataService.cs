using System.Collections.Generic;
using System.Threading.Tasks;
using pathways_api.Data.Mappers;

namespace pathways_api.Services.Interfaces
{
    public interface IUserDataService
    {
        ///<summary>
        /// get access token from domo
        ///</summary>
        Task<string> GetAccessTokenAsync();
        
        ///<summary>
        /// get dataset list from domo (ex. the list of data sets in domo)
        ///</summary>
        Task<List<DataSetDto>> GetDataSetsAsync(string accessToken);
        
        ///<summary>
        /// get user Data from domo
        ///</summary>
        Task<List<UserDataDto>> GetUsersDataAsync(string accessToken);
    }
}