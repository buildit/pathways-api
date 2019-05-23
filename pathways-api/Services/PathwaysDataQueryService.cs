namespace pathways_api.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Data;
    using pathways_common.Interfaces.Entities;
    using pathways_common.Services;

    public abstract class PathwaysDataQueryService<T> : DataQueryService<T, DataContext> where T : class, IIdEntity
    {
        protected PathwaysDataQueryService(DataContext context, IEnumerable<T> collection) : base(context, collection)
        {
        }

        public void Update(T entity)
        {
            this.context.Update(entity);
            this.context.SaveChanges();
        }

        public void UpdateRange(IList<T> list)
        {
            foreach (T item in list)
            {
                T dbItem = this.collection.FirstOrDefault(i => UpdateKey(i) == UpdateKey(item));
                if (dbItem == null)
                {
                    dbItem = item;
                    this.context.Add(dbItem);
                }
                else
                {
                    this.MapUpdateFields(dbItem, item);
                    this.context.Update(dbItem);
                }
            }

            this.context.SaveChanges();
        }

        protected abstract Func<T, object> UpdateKey { get; }

        protected abstract void MapUpdateFields(T targetObject, T sourceObject);
    }
}