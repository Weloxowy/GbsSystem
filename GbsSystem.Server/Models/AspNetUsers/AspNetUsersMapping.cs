using FluentNHibernate.Mapping;

namespace GbsSystem.Server.Models.AspNetUsers;

public class AspNetUsersMapping : ClassMap<AspNetUsers>
{
    readonly string _tablename = nameof(AspNetUsers);
    public AspNetUsersMapping()
    {
        Id(x => x.Id);
        Map(x => x.Lastname);
        Map(x => x.FirstName);
        Map(x => x.Birthday);
        Map(x => x.UserName);
        Map(x => x.NormalizedUserName);
        Map(x => x.Email);
        Map(x => x.NormalizedEmail);
        Map(x => x.EmailConfirmed);
        Map(x => x.PasswordHash);
        Map(x => x.SecurityStamp);
        Map(x => x.ConcurrencyStamp);
        Map(x => x.PhoneNumber);
        Map(x => x.PhoneNumberConfirmed);
        Map(x => x.TwoFactorEnabled);
        Map(x => x.LockoutEnd);
        Map(x => x.LockoutEnabled);
        Map(x => x.AccessFailedCount); 
        Table(_tablename);
    }
}