using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]     //controller viene sostituito con qualsiasi sia la classe controller che utilizziamo
    public class BaseApiController : ControllerBase
    {
        
    }
}