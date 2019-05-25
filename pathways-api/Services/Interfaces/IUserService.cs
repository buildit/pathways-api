namespace pathways_api.Services.Interfaces
{
    using Data.Entities;
    using pathways_common.Interfaces.Services;

    public interface IUserService : IADUserService<User>, IRangedCrudService<User>
    {
    }
}