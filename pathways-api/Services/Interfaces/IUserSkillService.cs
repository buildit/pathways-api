namespace pathways_api.Services.Interfaces
{
    using Data.Entities;

    public interface IUserSkillService : IRangedCrudService<UserSkill>
    {
        UserSkill Retrieve(int userSkillUserId, int userSkillSkillTypeId);
    }
}