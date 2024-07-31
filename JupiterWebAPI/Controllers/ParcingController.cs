using JupiterWebAPI.Services;
using JupiterWebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace JupiterWebAPI.Controllers
{
    public class ParcingController : Controller
    {
        [EnableCors("AllowPolicy")]
        [HttpPost("/delfavcases/{id}")]
        [Authorize]
        public ActionResult DelFavCasesList([FromHeader(Name = "Authorization")] string jwt, int id)
        {
            try
            {
                JupiterContext context = new JupiterContext();
                var jwtToken = jwt.Substring(7);
                var h = ValidateToken(jwtToken).Claims.First().Value;
                var t = h;
                FavorieCase item = context.FavorieCases.FirstOrDefault(c => c.Id == id && c.UserId == h);
                context.FavorieCases.Remove(item);
                context.SaveChanges();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [EnableCors("AllowPolicy")]
        [HttpPost("/addfavcases")]
        [Authorize]
        public ActionResult AddFavCasesList([FromHeader(Name = "Authorization")] string jwt, [FromBody]FavorieCase cases)
        {
            try
            {
                JupiterContext context = new JupiterContext();
                var jwtToken = jwt.Substring(7);
                var h = ValidateToken(jwtToken).Claims.First().Value;
                var t = h;
                cases.UserId = h;
                context.FavorieCases.Add(cases);
                context.SaveChanges();
                return Created("default",new JupiterContext().FavorieCases.OrderByDescending(p => p.Id).FirstOrDefault());
            }
            catch
            {
                return BadRequest();
            }
        }

        [EnableCors("AllowPolicy")]
        [HttpPost("/favcases")]
        [Authorize]
        public ActionResult GetFavCasesList([FromHeader(Name = "Authorization")] string jwt)
        {
            try
            {
                var jwtToken = jwt.Substring(7);
                var h = ValidateToken(jwtToken).Claims.First().Value;
                var t = h;
                return Ok(new JupiterContext().FavorieCases.Where(p => p.UserId == h).ToList());
            }
            catch
            {
                return BadRequest();
            }
        }
        [NonAction]
        public ClaimsPrincipal ValidateToken(string jwtToken)
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

            ClaimsPrincipal principal = new JwtSecurityTokenHandler().ValidateToken(jwtToken, validationParameters, out validatedToken);


            return principal;
        }
        [EnableCors("AllowPolicy")]
        [HttpDelete("/delcourt/{id}")]
        [Authorize]
        public ActionResult DelCourtList(int id)
        {
            try
            {
                JupiterContext context = new JupiterContext();
                City item = context.Cities.FirstOrDefault(p => p.Id == id);
                context.Cities.Remove(item);
                context.SaveChanges();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [EnableCors("AllowPolicy")]
        [HttpPost("/addcourt")]
        [Authorize]
        public ActionResult AddCourtList([FromBody] City city)
        {
            try
            {
                JupiterContext context = new JupiterContext();
                context.Cities.Add(city);
                context.SaveChanges();
                return Created("default", new JupiterContext().Cities.OrderByDescending(p => p.Id).FirstOrDefault());
            }
            catch
            {
                return BadRequest();
            }
        }
        [EnableCors("AllowPolicy")]
        [HttpPost("/courts")]
        [Authorize]
        public ActionResult GetCtiesList()
        {
            try
            {
                return Ok(new JupiterContext().Cities.ToList());
            }
            catch
            {
                return BadRequest();
            }
        }

        [EnableCors("AllowPolicy")]
        [HttpPost("/arbitcase")]
        [Authorize]
        public ActionResult GetParcingPath(string city, int count, string datefrom, string dateto, string search, string wasm)
        {
            return Ok(Parcing.Parce(city, count, datefrom, dateto, search, wasm));
        }
    }
}
