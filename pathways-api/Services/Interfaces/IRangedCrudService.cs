namespace pathways_api.Services.Interfaces
{
    using System.Collections.Generic;
    using pathways_common.Interfaces.Services;

    public interface IRangedCrudService<T> : ICrudService<T>
    {
        void UpdateRange(IList<T> list);
    }
}