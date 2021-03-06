using System.Collections.Generic;

namespace pathways_api.Data.Mappers
{
    using pathways_common.Entities;

    public class UserSkilledDto : PathwaysUser
    {
        public string DomoIdentifier { get; set; }

        public bool IsActive { get; set; }

        public ICollection<UserSkilledSkillDto> UserSkills { get; set; }
    }
}