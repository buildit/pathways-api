namespace pathways_api.Services
{
    using System;
    using Data;
    using Data.Entities;
    using Interfaces;

    public class UserSkillService : PathwaysDataQueryService<UserSkill>, IUserSkillService
    {
        public UserSkillService(DataContext context) : base(context, context.UserSkills)
        {
        }

        protected override Func<UserSkill, object> UpdateKey
        {
            get { return u => $"{u.UserId}|{u.SkillTypeId}|{u.SkillLevelId}"; }
        }

        public UserSkill Create(UserSkill entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public UserSkill GetByIdWithIncludes(int id)
        {
            throw new NotImplementedException();
        }

        protected override void MapUpdateFields(UserSkill targetObject, UserSkill sourceObject)
        {
            targetObject.SkillLevelId = sourceObject.SkillLevelId;
        }
    }
}