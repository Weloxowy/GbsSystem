using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace GbsSystem.Server.Controllers.Planets;
[EnableCors("AllowAllOrigins")]
[Route("api/[controller]")]
[ApiController]

public class Planets : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Models.AspNetUsers.AspNetUsersDto>> GetAll()
    {
        using (var session = NHibernateHelper.OpenSession())
        {
            var result = session.Query<Models.Planets.Planets>().ToList();
            return Ok(result);
        }
        
    }
}