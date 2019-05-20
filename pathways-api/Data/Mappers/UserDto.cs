using System.Collections.Generic;

namespace pathways_api.Data.Mappers
{
    using pathways_common.Entities;

    public class UserDto : ADUserEntity
    {
        public string DomoIdentifier { get; set; }
        
        public ICollection<RoleLevelRuleDto> UserSkills { get; set; }
    }

    public class RoleLevelDto : DescriptionEntity
    {
        
    }

    public class RoleTypeDto : NamedEntity
    {
        public string Title { get; set; }
    }
}