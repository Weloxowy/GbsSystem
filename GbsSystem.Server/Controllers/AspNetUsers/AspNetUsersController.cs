using System.Security.Claims;
using GbsSystem.Server.Models.AspNetUsers;
using GbsSystem.Server.Models.EmailService;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GbsSystem.Server.Controllers.AspNetUsers;
[EnableCors("AllowAllOrigins")]
[Route("api/[controller]")]
[ApiController]
public class AspNetUsersController : ControllerBase
{
    
    private readonly EmailService _emailService;

    public AspNetUsersController(EmailService emailService)
    {
        _emailService = emailService;
    }
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

    [HttpGet("info")]
    public async Task<Models.AspNetUsers.AspNetUsers> GetUserInfo()
    {
        // Check if user is authenticated
        var user = HttpContext.User;
        if (user.Identity != null && user.Identity.IsAuthenticated)
        {
            // Retrieve user ID from claims
            var userIdClaim = user.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
            {
                throw new Exception("User ID claim not found.");
            }

            // Parse user ID
            if (!Guid.TryParse(userIdClaim.Value, out Guid userId))
            {
                throw new Exception("Invalid user ID format.");
            }

            // Retrieve user entity by ID
            using (var session = NHibernateHelper.OpenSession())
            {
                var userEntity = session.Get<Models.AspNetUsers.AspNetUsers>(userIdClaim.Value);
                if (userEntity == null)
                {
                    throw new Exception("User not found.");
                }

                return userEntity;
            }
        }
        else
        {
            // User is not authenticated
            throw new Exception("Unauthorized");
        }
    }

    
    [HttpPost]
    public async Task<bool> sendEmail()
    {
        Models.AspNetUsers.AspNetUsers final = await GetUserInfo();
        var emailSubject = "Witaj w RentIt!";
        var emailBody = $@"
                        <html>
                        <body style='font-family: Arial, sans-serif; text-align: center; color: #333;'>
                            <div style='max-width: 600px; margin: 0 auto; padding: 20px; border: 1px solid #ddd; border-radius: 10px;'>
                                <h2 style='color: #4CAF50;'>Witaj w RentIt {final.FirstName},</h2>
                                <p>Pomyślnie zarejestrowałeś się w serwisie RentIt.:</p>
                                <p style='margin-top: 30px;'>Twoim następnym krokiem jest znalezienie nowych współlokatorów, z którymi mamy nadzieję spędzisz niezapomniane momenty.</p>
                                <p style='margin-top: 30px;'>Życzymy ci wszystkiego dobrego. Zespół RentIt!</p>
                                <p style='margin-top: 30px; font-size: 12px; color: #999;'>© 2024 RentIt. All rights reserved.</p>
                            </div>
                        </body>
                        </html>";
        try
        {
            await _emailService.SendEmailAsync(final.Email, emailSubject, emailBody);
            return true;
        }
        catch
        {
            throw new Exception("Can't send email. Email service is unavaible. Please contanct with support.");
        }
    }
       [HttpPost("registerCustom")]
        public ActionResult<Models.AspNetUsers.AspNetUsersDto> Register([FromBody] AspNetUsersRegisterDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Invalid data");
            }

            Models.AspNetUsers.AspNetUsers testEntity = new Models.AspNetUsers.AspNetUsers();
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        if (dto.Password.Length <= 8)
                        {
                            return Conflict("Password is too short");
                        }
                        var passwordHasher = new PasswordHasher<Models.AspNetUsers.AspNetUsers>();
                        string hashedPassword = passwordHasher.HashPassword(null, dto.Password);
                        testEntity.PasswordHash = hashedPassword;
                        if (dto.Email != null)
                        {
                            testEntity.Email = dto.Email;
                            testEntity.NormalizedEmail = testEntity.Email.ToUpper();
                            testEntity.UserName = testEntity.Email;
                            testEntity.NormalizedUserName = testEntity.UserName.ToUpper();
                            
                        }

                        testEntity.FirstName = dto.FirstName;
                        testEntity.Lastname = dto.LastName;
                        testEntity.Birthday = dto.Bithday;
                        session.Save(testEntity);
                        transaction.Commit();
                        return CreatedAtAction(nameof(GetById), new { id = testEntity.Id }, testEntity);
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
                    }
                }
            }

        }

    
}