using System.Collections.Generic;

namespace pathways_api.Data.Mappers
{
    using pathways_common.Entities;

    public class UserDto : PathwaysUser
    {
        public string DomoIdentifier { get; set; }

        public ICollection<UserSkillDto> UserSkills { get; set; }
    }
}