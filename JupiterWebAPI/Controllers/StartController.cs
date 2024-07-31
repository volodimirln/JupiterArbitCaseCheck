using JupiterWebAPI.Models;
using JupiterWebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JupiterWebAPI.Controllers
{
    public class StartController : Controller
    {
        [EnableCors("AllowPolicy")]
        [HttpPost("/init")]
        public ActionResult InitDB()
        {
          
            new JupiterContext().Database.EnsureCreated();
            return Ok();
        }

        [EnableCors("AllowPolicy")]
        [HttpPost("/repository")]
        public ActionResult Repository()
        {

            new Repository();
            return Ok();
        }
    }
}
