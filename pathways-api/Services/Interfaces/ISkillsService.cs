namespace pathways_api.Services.Interfaces
{
    using Data.Mappers;

    public interface ISkillsService
    {
        /// <summary>
        ///     get one user and user's skill data
        /// </summary>
        UserDto GetUserSkills(int id);
    }
}