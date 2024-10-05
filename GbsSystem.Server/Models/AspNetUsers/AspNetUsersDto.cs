namespace GbsSystem.Server.Models.AspNetUsers;

public class AspNetUsersDto
{
    public virtual string FirstName { get; set; }
    public virtual string? LastName { get; set; }
    public virtual DateTime? Birthday { get; set; }
    public virtual string Email { get; set; }

    public AspNetUsersDto(string firstName, string? lastName, DateTime? birthday, string email)
    {
        FirstName = firstName;
        LastName = lastName;
        Birthday = birthday;
        Email = email;
    }
}