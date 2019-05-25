namespace pathways_api.Services
{
    using System;
    using Data;
    using Data.Entities;
    using Interfaces;

    public class SkillTypeService : PathwaysDataQueryService<SkillType>, ISkillTypeService
    {
        public SkillTypeService(DataContext context) : base(context, context.SkillTypes)
        {
        }

        protected override Func<SkillType, object> UpdateKey
        {
            get { return s => s.Name; }
        }

        public SkillType Create(SkillType entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public SkillType GetByIdWithIncludes(int id)
        {
            throw new NotImplementedException();
        }

        protected override void MapUpdateFields(SkillType targetObject, SkillType sourceObject)
        {
            throw new NotImplementedException();
        }
    }
}