namespace pathways_api.Services
{
    using System;
    using System.Linq;
    using Data;
    using Data.Entities;
    using Interfaces;

    public class RoleTypeService : PathwaysDataQueryService<RoleType>, IRoleTypeService
    {
        public RoleTypeService(DataContext context) : base(context, context.RoleTypes)
        {
        }

        public RoleType Create(RoleType entity)
        {
            throw new NotImplementedException();
        }

        public void Update(RoleType entity)
        {
            this.context.RoleTypes.Update(entity);
        }

        public void Delete(int id)
        {
            this.context.RoleTypes.Remove(this.collection.First(e => e.Id == id));
        }

        public RoleType GetByIdWithIncludes(int id)
        {
            throw new NotImplementedException();
        }

        protected override Func<RoleType, object> UpdateKey
        {
            get { return r => r.Name; }
        }

        protected override void MapUpdateFields(RoleType targetObject, RoleType sourceObject)
        {
            targetObject.Name = sourceObject.Name;
            targetObject.Title = sourceObject.Title;
        }
    }
}