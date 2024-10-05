namespace GbsSystem.Server.Models.Planets;

public class Planets
{
    public virtual Guid Id { get; set; }
    public virtual string Name { get; set; }
    public virtual double Diameter { get; set; }
    public virtual string Description1 { get; set; }
    public virtual string Description2 { get; set; }
    public virtual string Description3 { get; set; }
    public virtual string Type { get; set; }
}