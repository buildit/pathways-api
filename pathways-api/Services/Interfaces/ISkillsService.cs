using System.Collections.Generic;
using pathways_api.Data.Mappers;

namespace pathways_api.Services.Interfaces
{
    public interface ISkillsService
    {
        ///<summary>
        /// get all users and user's skill data
        ///</summary>
        List<UserDto> GetUsersSkills();
        
        ///<summary>
        /// get one user and user's skill data
        ///</summary>
        UserDto GetUserSkills(int id);
    }
}