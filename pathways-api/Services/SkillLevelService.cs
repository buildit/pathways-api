namespace pathways_api.Services
{
    using System;
    using Data;
    using Data.Entities;
    using Interfaces;

    public class SkillLevelService : PathwaysDataQueryService<SkillLevel>, ISkillLevelService
    {
        public SkillLevelService(DataContext context) : base(context, context.SkillLevels)
        {
        }

        protected override Func<SkillLevel, object> UpdateKey { get; }

        protected override void MapUpdateFields(SkillLevel targetObject, SkillLevel sourceObject)
        {
            throw new NotImplementedException();
        }

        public SkillLevel Create(SkillLevel entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public SkillLevel GetByIdWithIncludes(int id)
        {
            throw new NotImplementedException();
        }
    }
}