namespace GbsSystem.Server.Models.AspNetUsers;

public class AspNetUsersRegisterDto
{
    public virtual string Password { get; set; }
    public virtual string Email { get; set; }
    public virtual string FirstName { get; set; }
    public virtual string LastName { get; set; }
    public virtual DateTime Bithday { get; set; }
}