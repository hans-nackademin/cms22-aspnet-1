using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApi.Models;
using WebApi.Models.Contexts;
using WebApi.Models.Entitites;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly SqlContext _sql;
        private readonly IConfiguration _configuration;

        public AuthenticationController(SqlContext sql, IConfiguration configuration)
        {
            _sql = sql;
            _configuration = configuration;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp(SignUp form)
        {
            UserEntity userEntity = form;
            
            _sql.Users.Add(userEntity);
            try 
            { 
                await _sql.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("signin")]
        public async Task<IActionResult> SignIn(SignIn form)
        {
            var userEntity = await _sql.Users.FirstOrDefaultAsync(x => x.Email == form.Email);
            if (userEntity == null) return NotFound();

            var result = userEntity.ValidateSecurePassword(form.Password);
            if (result == false) return BadRequest();

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("id", userEntity.Id.ToString()),
                    new Claim(ClaimTypes.Name, userEntity.Email)
                }),

                Expires = DateTime.Now.AddHours(1),

                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("SecretKey")!)),
                    SecurityAlgorithms.HmacSha512Signature
                )
            };

            var token = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
            return Ok(token);
        }
    }
}
