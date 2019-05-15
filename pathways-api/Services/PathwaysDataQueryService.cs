namespace pathways_api.Services
{
    using System.Collections.Generic;
    using Data;
    using pathways_common.Interfaces;
    using pathways_common.Services;

    
    
    public abstract class PathwaysDataQueryService<T> : DataQueryService<T, DataContext> where T : IIdEntity
    {
        protected PathwaysDataQueryService(DataContext context, IEnumerable<T> collection) : base(context, collection)
        {
        }
    }
}