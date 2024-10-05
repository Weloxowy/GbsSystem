using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace GbsSystem.Server.Controllers.AspNetUsers;
[EnableCors("AllowAllOrigins")]
[Route("api/[controller]")]
[ApiController]
public class AspNetUsersController : ControllerBase
{
    
}