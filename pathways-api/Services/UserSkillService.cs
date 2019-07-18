namespace pathways_api.Services
{
    using System;
    using System.Linq;
    using Data;
    using Data.Entities;
    using Interfaces;
    using Microsoft.EntityFrameworkCore.Internal;

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

        public UserSkill Retrieve(int userSkillUserId, int userSkillSkillTypeId)
        {
            return this.collection.FirstOrDefault(s => s.UserId == userSkillUserId && s.SkillTypeId == userSkillSkillTypeId);
        }

        protected override void MapUpdateFields(UserSkill targetObject, UserSkill sourceObject)
        {
            targetObject.SkillLevelId = sourceObject.SkillLevelId;
        }
    }
}