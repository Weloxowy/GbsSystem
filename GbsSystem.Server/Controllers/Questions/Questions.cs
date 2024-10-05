using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using NHibernate.Criterion;

namespace GbsSystem.Server.Controllers.Questions;

[Route("api/[controller]")]
[ApiController]
public class Questions : ControllerBase
{
    [HttpGet]
    public List<Models.Questions.Questions> GetAll()
    {
        using (var session = NHibernateHelper.OpenSession())
        {
            var result = session.Query<Models.Questions.Questions>().ToList();
            return result;
        }
    }
    [HttpGet("QuestionsByPlanetAndLevel")]
    public List<Models.Questions.Questions> GetByLevelAndPlanet(string name, int level)
    {
        using (var session = NHibernateHelper.OpenSession())
        {
            var planet = session.Query<Models.Planets.Planets>().First(x => x.Name == name);
            var result = session.Query<Models.Questions.Questions>().Where(x => x.PlanetId == planet.Id && x.Level == level).ToList();
            return result;
        }
    }
}