using GbsSystem.Server.Models.AspNetUsers;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace GbsSystem.Server.Controllers.AspNetUsers;
[EnableCors("AllowAllOrigins")]
[Route("api/[controller]")]
[ApiController]
public class AspNetUsersController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Models.AspNetUsers.AspNetUsersDto>> GetAll()
    {
        using (var session = NHibernateHelper.OpenSession())
        {
            var aspNetUsers = session.Query<Models.AspNetUsers.AspNetUsers>().ToList();
            var result = new List<AspNetUsersDto>();
            foreach (var x in aspNetUsers)
            {
                result.Add(new AspNetUsersDto(x.FirstName, x.Lastname, x.Birthday, x.Email));
            }
            return Ok(result);
        }
        
    }
    [HttpGet("id/{id}")]
    public ActionResult<Models.AspNetUsers.AspNetUsersDto> GetById(string id)
    {
        using (var session = NHibernateHelper.OpenSession())
        {
            var aspNetUsers = session.Get<Models.AspNetUsers.AspNetUsers>(id);
            if (aspNetUsers == null)
            {
                return NotFound();
            }

            return Ok(new AspNetUsersDto(aspNetUsers.FirstName, aspNetUsers.Lastname, aspNetUsers.Birthday,
                aspNetUsers.Email));
        }
    }
    
}