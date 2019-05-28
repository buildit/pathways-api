namespace pathways_api.Services
{
    using System;
    using Data;
    using Data.Entities;
    using Interfaces;

    public class RoleLevelRuleService : PathwaysDataQueryService<RoleLevelRule>, IRoleLevelRuleService
    {
        public RoleLevelRuleService(DataContext context) : base(context, context.RoleLevelRules)
        {
        }

        protected override Func<RoleLevelRule, object> UpdateKey
        {
            get { return u => $"{u.RoleTypeId}|{u.SkillTypeId}|{u.SkillLevelId}|{u.SkillTypeId}"; }
        }

        public RoleLevelRule Create(RoleLevelRule entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public RoleLevelRule GetByIdWithIncludes(int id)
        {
            throw new NotImplementedException();
        }

        protected override void MapUpdateFields(RoleLevelRule targetObject, RoleLevelRule sourceObject)
        {
            targetObject.RoleLevelId = sourceObject.RoleLevelId;
            targetObject.SkillLevelId = sourceObject.SkillLevelId;
            targetObject.RoleTypeId = sourceObject.RoleTypeId;
            targetObject.SkillTypeId = sourceObject.SkillTypeId;
        }
    }
}