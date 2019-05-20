namespace pathways_api.Services.Interfaces
{
    using System.Collections.Generic;
    using Data.Entities;
    using pathways_common.Interfaces.Services;

    public interface IUserService : IADUserService<User>
    {
        void UpdateRange(IList<User> userList);
    }

    public interface IRoleLevelService : ICrudService<RoleLevel>
    {
        void UpdateRange(IList<RoleLevel> list);
    }
    
    public interface IRoleTypeService : ICrudService<RoleType>
    {
        void UpdateRange(IList<RoleType> list);
    }
}