namespace pathways_api.Services.Interfaces
{
    using System.Collections.Generic;
    using Data.Entities;

    public interface IRoleLevelRuleService : IRangedCrudService<RoleLevelRule>
    {
        IEnumerable<RoleLevelRule> GetAllLoaded();
    }
}