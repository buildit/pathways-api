namespace pathways_api.Services
{
    using System;
    using Data;
    using Data.Entities;
    using Interfaces;

    public class RoleLevelService : PathwaysDataQueryService<RoleLevel>, IRoleLevelService
    {
        public RoleLevelService(DataContext context) : base(context, context.RoleLevels)
        {
        }

        public RoleLevel Create(RoleLevel entity)
        {
            throw new NotImplementedException();
        }

        public void Update(RoleLevel entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public RoleLevel GetByIdWithIncludes(int id)
        {
            throw new NotImplementedException();
        }

        protected override Func<RoleLevel, object> UpdateKey
        {
            get { return r => r.Name; }
        }

        protected override void MapUpdateFields(RoleLevel targetObject, RoleLevel sourceObject)
        {
            targetObject.Name = sourceObject.Name;
            targetObject.Level = sourceObject.Level;
            targetObject.Description = sourceObject.Description;
        }
    }
}