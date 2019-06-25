namespace pathways_api.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Data;
    using Data.Entities;
    using Interfaces;
    using Microsoft.EntityFrameworkCore;

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

        public IEnumerable<RoleLevelRule> GetAllLoaded()
        {
            return this.GetAll().AsQueryable()
                .Include(l => l.RoleLevel)
                .Include(l => l.RoleType)
                .Include(l => l.SkillLevel)
                .Include(l => l.SkillType);
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