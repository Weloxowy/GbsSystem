using Microsoft.AspNetCore.Identity;
using NHibernate.Mapping;

namespace GbsSystem.Server.Models.AspNetUsers;

public class AspNetUsers : IdentityUser
{
    public virtual string FirstName { get; set; }
    public virtual string? Lastname { get; set; }
    public virtual DateTime? Birthday { get; set; }
}
