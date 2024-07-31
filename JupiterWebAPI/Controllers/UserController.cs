using JupiterWebAPI.Models;
using JupiterWebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace JupiterWebAPI.Controllers
{
    public class UserController : Controller
    {
        [NonAction]
        public static string CreateMD5(string s)
        {
            using (var provider = System.Security.Cryptography.MD5.Create())
            {
                StringBuilder builder = new StringBuilder();

                foreach (byte b in provider.ComputeHash(Encoding.UTF8.GetBytes(s)))
                    builder.Append(b.ToString("x2").ToLower());

                return builder.ToString();
            }

        }
        [EnableCors("AllowPolicy")]
        [HttpPost]
        [Route("/userslist")]
        [Authorize]
        public ActionResult GetUsersList()
        {
            return Ok(new JupiterContext().Users.ToList());
        }


        [EnableCors("AllowPolicy")]
        [HttpPatch]
        [Route("/passwordChange")]
        [Authorize]
        public ActionResult AddPassword([FromBody] Password password)
        {
            try
            {

                JupiterContext jupiter = new JupiterContext();
                Password psw = jupiter.Passwords.Where(p => p.UserId == password.UserId).ToList().LastOrDefault();
                if (psw != null)
                {
                    psw.Status = false;
                    jupiter.Update(psw);
                    jupiter.SaveChanges();
                }
                JupiterContext jupiter1 = new JupiterContext();
                password.HashPassword = CreateMD5(password.HashPassword + "ids78dn");
                password.DateAdd = DateOnly.FromDateTime(DateTime.Now);
                jupiter1.Passwords.Add(password);
                jupiter1.SaveChanges();
                return Ok(password);
            }
            catch
            {
                return BadRequest();
            }
            
        }


        [EnableCors("AllowPolicy")]
        [HttpPatch]
        [Route("/userapdate/{id}")]
        [Authorize]
        public ActionResult UpdateUser([FromBody] User user, int id)
        {
            try
            {
                JupiterContext jupiter = new JupiterContext();
                user.Id = id;
                jupiter.Users.Update(user);
                jupiter.SaveChanges();
                return Ok(user);
            }
            catch
            {
                return BadRequest();
            }
        }


        [EnableCors("AllowPolicy")]
        [HttpPost]
        [Route("/auth/checktoken")]
        [Authorize]
        public ActionResult CheckToken()
        {
            return Ok("true");
        }

        [EnableCors("AllowPolicy")]
        [HttpPost]
        [Route("/auth/signup")]
        public ActionResult AddUser([FromBody] User user)
        {
            try
            {
                JupiterContext jupiter = new JupiterContext();

                user.RoleId = 2;
                DateTime date = DateTime.Now;
                user.DateRegistration = DateOnly.FromDateTime(date);
                user.DataChange = DateOnly.FromDateTime(date);
                jupiter.Users.Add(user);
                jupiter.SaveChanges();

                return Created("", new JupiterContext().Users.OrderByDescending(p => p.Id).FirstOrDefault());
            }
            catch
            {
                return BadRequest();
            }
            
        }

        [NonAction]
        public  ClaimsPrincipal ValidateToken(string jwtToken)
        {
            IdentityModelEventSource.ShowPII = true;

            SecurityToken validatedToken;
            TokenValidationParameters validationParameters = new TokenValidationParameters();

            validationParameters.ValidateLifetime = true;

            validationParameters.ValidAudience = AuthOptions.AUDIENCE;
            validationParameters.ValidateAudience = true;
            validationParameters.ValidIssuer = AuthOptions.ISSUER;
            validationParameters.IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey();
            validationParameters.ValidateIssuerSigningKey = true;

            /*
            ValidateIssuerSigningKey = true,*/

            ClaimsPrincipal principal = new JwtSecurityTokenHandler().ValidateToken(jwtToken, validationParameters, out validatedToken);


            return principal;
        }

        [EnableCors("AllowPolicy")]
        [HttpPost]
        [Route("/auth/userinfo")]
      
        public ActionResult GetUserInfo([FromHeader(Name = "Authorization")] string jwt)
        {
            try
            {
                var jwtToken = jwt.Substring(7);
                var h = ValidateToken(jwtToken).Claims.First().Value;
                return Ok(new JupiterContext().Users.FirstOrDefault(p => p.Id == Convert.ToInt32(h)));
            }
            catch
            {
                return BadRequest();
            }
            
        }

        [EnableCors("AllowPolicy")]
        [HttpPost]
        [Route("/auth/login")]
        public ActionResult Authorization([FromBody] UserAuth user)
        {
            try
            {
                User userset = new JupiterContext().Users.FirstOrDefault(p => p.Email == user.username);
                if (userset != null)
                {
                    Password password = new JupiterContext().Passwords.FirstOrDefault(p => p.HashPassword == CreateMD5(user.password + "ids78dn") && p.Status == true);
                    if (password != null)
                    {
                        var claims = new List<Claim> { new Claim(ClaimValueTypes.Sid, userset.Id.ToString()) };
                        var jwt = new JwtSecurityToken(
                                issuer: AuthOptions.ISSUER,
                                audience: AuthOptions.AUDIENCE,
                                claims: claims,
                                expires: DateTime.UtcNow.Add(TimeSpan.FromDays(365)),
                                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

                        return Ok(new JwtSecurityTokenHandler().WriteToken(jwt));
                    }
                    else
                    {
                        return Unauthorized();
                    }
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch
            {
                return BadRequest();
            }      
        }
    }
}
