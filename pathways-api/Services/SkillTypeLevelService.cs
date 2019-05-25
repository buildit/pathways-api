namespace pathways_api.Services
{
    using System;
    using Data;
    using Data.Entities;
    using Interfaces;

    public class SkillTypeLevelService : PathwaysDataQueryService<SkillTypeLevel>, ISkillTypeLevelService
    {
        public SkillTypeLevelService(DataContext context) : base(context, context.SkillTypeLevels)
        {
        }

        protected override Func<SkillTypeLevel, object> UpdateKey
        {
            get { return st => $"{st.SkillLevelId}|{st.SkillTypeId}"; }
        }

        public SkillTypeLevel Create(SkillTypeLevel entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public SkillTypeLevel GetByIdWithIncludes(int id)
        {
            throw new NotImplementedException();
        }

        protected override void MapUpdateFields(SkillTypeLevel targetObject, SkillTypeLevel sourceObject)
        {
            throw new NotImplementedException();
        }
    }
}