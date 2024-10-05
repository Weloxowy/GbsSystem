using FluentNHibernate.Mapping;

namespace GbsSystem.Server.Models.Planets;

public class PlanetsMapping : ClassMap<Planets>
{
    PlanetsMapping()
    {
        Id(x => x.Id);
        Map(x => x.Diameter);
        Map(x => x.Name);
        Map(x => x.Description1);
        Map(x => x.Description2);
        Map(x => x.Description3);
        Map(x => x.Type);
    }
}