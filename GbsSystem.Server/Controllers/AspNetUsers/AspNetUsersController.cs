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
                        <!DOCTYPE html>
<html lang=""pl"">
  <head>
    <meta charset=""UTF-8"" />
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"" />
    <title>Certyfikat</title>
    <style>
      body {{
        font-family: ""Arial"", sans-serif;
        display: flex;
        justify-content: center;
        align-items: center;
        height: 100vh;
        margin: 0;
        background-color: #f4f4f4;
        position: relative;
      }}

      .certificate-container {{
        background-color: white !important;
        padding: 40px;
        padding-top: 95px; /* Adjust for the arrow space */
        border-radius: 10px;
        box-shadow: 0 0 15px rgba(0, 0, 0, 0.2);
        width: 800px;
        text-align: center;
        position: relative;
        z-index: 1;
      }}

      /* Top arrow shape */
      .top-arrow {{
        width: 0;
        height: 0;
        border-left: 100px solid transparent;
        border-right: 100px solid transparent;
        border-bottom: 50px solid #003366;
        position: absolute;
        top: 37px;
        left: 50%;

        transform: translateX(-50%) rotate(180deg);
        z-index: 2;
      }}

      .certificate-header {{
        font-size: 30px;
        font-weight: bold;
        color: white;
        margin-bottom: 20px;
        background-color: #003366;
        display: inline-block;
        padding: 10px 40px;
        position: absolute;
        top: 0;
        left: 50%;
        transform: translateX(-50%);
      }}

      .certificate-title {{
        font-size: 24px;
        font-weight: bold;
        color: #003366;
        margin: 10px 0;
      }}

      .certificate-body {{
        font-size: 20px;
        color: #333;
      }}

      .certificate-name {{
        font-size: 36px;
        font-weight: bold;
        color: #003366;
        margin: 20px 0;
      }}

      .certificate-footer {{
        font-size: 18px;
        font-weight: bold;
        color: #003366;
      }}

      .signature {{
        margin-top: 20px;
        font-family: ""Brush Script MT"", cursive;
        font-size: 40px;
        color: #333;
        margin-bottom: 50px;
      }}

      /* Left and right blue bars */

      .certificate-container::before {{
        content: """";
        position: absolute;
        width: 20px;
        height: 180px;
        background-color: #003366;
        top: 50%;
        transform: translateY(-50%);
        z-index: -1; /* Place behind the certificate */
        left: 0;
      }}

      .certificate-container::after {{
        content: """";
        position: absolute;
        width: 20px;
        height: 180px;
        background-color: #003366;
        top: 50%;
        transform: translateY(-50%);
        z-index: -1; /* Place behind the certificate */
        right: 0;
      }}

      /* Side Text */
      .side-text {{
        position: absolute;
        top: 50%;
        transform: translateY(-50%);
        color: black;
        font-size: 16px;
        font-weight: bold;
        letter-spacing: 2px;
        writing-mode: vertical-rl;
        text-orientation: mixed;
      }}

      .side-text-right {{
        right: 30px;
      }}

      .side-text-left {{
        left: 30px;
      }}
      .label-signature {{
        font-family: ""Arial"", sans-serif;
        font-size: 20px;
      }}
    </style>
  </head>
  <body>
    <div class=""certificate-container"">
      <div class=""certificate-header"">GBS & Partners</div>

      <div class=""certificate-title"">Certyfikat</div>
      <div class=""certificate-body"">Niniejszy dokument poświadcza, że</div>

      <div class=""certificate-name"">{final.FirstName + " " + final.Lastname}</div>

      <div class=""certificate-body"">
        przezwyciężył wszystkie astrofizyczne wyzwania i zdobył tytuł
        Kosmicznego Mistrza Wiedzy
      </div>

      <div class=""signature"">
        <span class=""label-signature"">Podpisano:</span> <br />GBS Company
      </div>

      <div class=""certificate-footer"">GBS Company | NASA & Partners</div>
      <!-- Left and Right Side Text -->
      
    </div>
  </body>
</html>
";
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
    
    [HttpPost("sendEmailPDF")]
    public async Task<bool> sendEmailPDF()
    {
        Models.AspNetUsers.AspNetUsers final = await GetUserInfo();
        var emailSubject = "Witaj w RentIt!";
        var emailBody = $@"
                        <!DOCTYPE html>
<html lang=""pl"">
  <head>
    <meta charset=""UTF-8"" />
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"" />
    <title>Certyfikat</title>
    <style>
      body {{
        font-family: ""Arial"", sans-serif;
        display: flex;
        justify-content: center;
        align-items: center;
        height: 100vh;
        margin: 0;
        background-color: #f4f4f4;
        position: relative;
      }}

      .certificate-container {{
        background-color: white !important;
        padding: 40px;
        padding-top: 95px; /* Adjust for the arrow space */
        border-radius: 10px;
        box-shadow: 0 0 15px rgba(0, 0, 0, 0.2);
        width: 800px;
        text-align: center;
        position: relative;
        z-index: 1;
      }}

      /* Top arrow shape */
      .top-arrow {{
        width: 0;
        height: 0;
        border-left: 100px solid transparent;
        border-right: 100px solid transparent;
        border-bottom: 50px solid #003366;
        position: absolute;
        top: 37px;
        left: 50%;

        transform: translateX(-50%) rotate(180deg);
        z-index: 2;
      }}

      .certificate-header {{
        font-size: 30px;
        font-weight: bold;
        color: white;
        margin-bottom: 20px;
        background-color: #003366;
        display: inline-block;
        padding: 10px 40px;
        position: absolute;
        top: 0;
        left: 50%;
        transform: translateX(-50%);
      }}

      .certificate-title {{
        font-size: 24px;
        font-weight: bold;
        color: #003366;
        margin: 10px 0;
      }}

      .certificate-body {{
        font-size: 20px;
        color: #333;
      }}

      .certificate-name {{
        font-size: 36px;
        font-weight: bold;
        color: #003366;
        margin: 20px 0;
      }}

      .certificate-footer {{
        font-size: 18px;
        font-weight: bold;
        color: #003366;
      }}

      .signature {{
        margin-top: 20px;
        font-family: ""Brush Script MT"", cursive;
        font-size: 40px;
        color: #333;
        margin-bottom: 50px;
      }}

      /* Left and right blue bars */

      .certificate-container::before {{
        content: """";
        position: absolute;
        width: 20px;
        height: 180px;
        background-color: #003366;
        top: 50%;
        transform: translateY(-50%);
        z-index: -1; /* Place behind the certificate */
        left: 0;
      }}

      .certificate-container::after {{
        content: """";
        position: absolute;
        width: 20px;
        height: 180px;
        background-color: #003366;
        top: 50%;
        transform: translateY(-50%);
        z-index: -1; /* Place behind the certificate */
        right: 0;
      }}

      /* Side Text */
      .side-text {{
        position: absolute;
        top: 50%;
        transform: translateY(-50%);
        color: black;
        font-size: 16px;
        font-weight: bold;
        letter-spacing: 2px;
        writing-mode: vertical-rl;
        text-orientation: mixed;
      }}

      .side-text-right {{
        right: 30px;
      }}

      .side-text-left {{
        left: 30px;
      }}
      .label-signature {{
        font-family: ""Arial"", sans-serif;
        font-size: 20px;
      }}
    </style>
  </head>
  <body>
    <div class=""certificate-container"">
      <div class=""certificate-header"">GBS & Partners</div>

      <div class=""certificate-title"">Certyfikat</div>
      <div class=""certificate-body"">Niniejszy dokument poświadcza, że</div>

      <div class=""certificate-name"">{final.FirstName + " " + final.Lastname}</div>

      <div class=""certificate-body"">
        przezwyciężył wszystkie astrofizyczne wyzwania i zdobył tytuł
        Kosmicznego Mistrza Wiedzy
      </div>

      <div class=""signature"">
        <span class=""label-signature"">Podpisano:</span> <br />GBS Company
      </div>

      <div class=""certificate-footer"">GBS Company | NASA & Partners</div>
      <!-- Left and Right Side Text -->
      
    </div>
  </body>
</html>
";
        var renderer = new IronPdf.HtmlToPdf();
        var pdfDocument = renderer.RenderHtmlAsPdf(emailBody);

        // Save PDF to byte array for attachment
        var pdfBytes = pdfDocument.BinaryData;

        try
        {
          // Send email with PDF attachment
          await _emailService.SendEmailWithAttachmentAsync(final.Email, emailSubject, emailBody, pdfBytes, "certificate.pdf");
          return true;
        }
        catch
        {
          throw new Exception("Can't send email. Email service is unavailable. Please contact support.");
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