using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Calculator.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {


        private readonly IConfiguration _config;

        public AuthController( IConfiguration config)
        {
            _config = config;
  
        }




        /// <summary>
        /// The Main Login function to authenticate user
        /// </summary>
        /// <param name="id">user id of the user</param>
        /// <param name="password">password of the user</param>
        /// <returns></returns>
        [HttpPost("Login")]
        public IActionResult Login(string id, string password)
        {
            if (!id.Equals("admin") || !password.Equals("admin"))
                return Unauthorized();

            //Create a JWT Token and Return
            var claims = new[]
           {
                //can be multipe claims but right now only id we are setting
              new Claim(ClaimTypes.NameIdentifier,id) 
    
            };

            //The private key for the hash
            var key = new SymmetricSecurityKey(Encoding.UTF8
                    .GetBytes(_config.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds

            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new { token = tokenHandler.WriteToken(token) });

        }
    }
}