using E_Library.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace E_Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DangNhapLeadership : ControllerBase
    {
        public static LeadershipRegister leadership = new LeadershipRegister();
        private readonly IConfiguration _configuration;


        public DangNhapLeadership(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<ActionResult<LeadershipRegister>> Register(LeadershipDto request)
        {
            CreatePasswordHash(request.leadership_password, out byte[] leadership_passwordHash, out byte[] leadership_passwordSalt);

            leadership.leadership_username = request.leadership_username;
            leadership.leadership_passwordHash = leadership_passwordHash;
            leadership.leadership_passwordSalt = leadership_passwordSalt;

            return Ok(leadership);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(LeadershipDto request)
        {
            if (leadership.leadership_username != request.leadership_username)
            {
                return BadRequest("Username not found.");
            }

            if (!VerifyPasswordHash(request.leadership_password, leadership.leadership_passwordHash, leadership.leadership_passwordSalt))
            {
                return BadRequest("Wrong password.");
            }

            string token = CreateToken(leadership);
            return Ok(token);
        }

        private string CreateToken(LeadershipRegister leadership)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, leadership.leadership_username),
                new Claim(ClaimTypes.Role, "Leadership")
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}
