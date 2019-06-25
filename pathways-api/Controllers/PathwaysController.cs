using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace pathways_api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public abstract class PathwaysController : ControllerBase
    {
        
    }
}