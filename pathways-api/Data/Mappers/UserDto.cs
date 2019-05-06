using System.Collections.Generic;
using pathways_api.Data.Entities;

namespace pathways_api.Data.Mappers
{
  public class UserDto
  {
    public int Id { get; set; }
    
    public int UserLoginId { get; set; }

    public UserLoginDto UserLogin { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public ICollection<RoleLevelRuleDto> UserSkills { get; set; }
  }
}