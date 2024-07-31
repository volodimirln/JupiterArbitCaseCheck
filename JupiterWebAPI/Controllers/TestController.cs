using JupiterWebAPI.Models;
using JupiterWebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;
using System.Net;

namespace JupiterWebAPI.Controllers
{
    public class TestController : Controller
    {
        [EnableCors("AllowPolicy")]
        [HttpPost("/arbitcasetest")]
        [Authorize]
        public ActionResult GetParcingPath(string city, int count, string datefrom, string dateto, string search)
        {
            IEnumerable<TestCaseArbit> testCases = new List<TestCaseArbit>();
            WebClient wb = new();
            string data = wb.DownloadString("http://127.110.110.33:7000/data/testdata.json");
           
                testCases = JsonConvert.DeserializeObject<List<TestCaseArbit>>(data);
            
            List<City> cityList = JupiterContext.GetContext().Cities.ToList();
            
            if (!string.IsNullOrEmpty(city))
            {
                try
                {
                    string courtname = JupiterContext.GetContext().Cities.FirstOrDefault(p => p.Name == city).Court;
                    testCases = testCases.Where(p => p.Court.Contains(courtname)).ToList();
                }catch { }
            }
            if (!string.IsNullOrEmpty(datefrom))
            {
                try
                {
                    DateTime dt = DateTime.Parse(datefrom);
                    testCases = testCases.Where(p => DateTime.Compare(DateTime.Parse(p.DateCase), dt) > 0).ToList();
                }
                catch { }
            }
            if (!string.IsNullOrEmpty(dateto))
            {
                try
                {
                    testCases = testCases.Where(p => DateTime.Compare(DateTime.Parse(p.DateCase), DateTime.Parse(dateto)) < 0).ToList();
                }
                catch { }
            }
            if (!string.IsNullOrEmpty(search))
            {
                try
                {
                    testCases = testCases.Where(p => p.Plaintiff.Contains(search)).ToList();
                }
                catch { }
            }
            if (count != 0)
            {
                try
                {
                    testCases = testCases.Take(count).ToList();
                }
                catch { }
            }
            List<ArbitrationCaseShort> shortcase = new List<ArbitrationCaseShort>();

            foreach (TestCaseArbit c in testCases)
            {

                shortcase.Add( new ArbitrationCaseShort
                {
                    Court = c.Court,
                    CaseNumber = c.CaseNumber,
                    Plaintiff = c.Plaintiff,
                    Respondent = c.Respondent
                });
               
            }
            return Ok(JsonConvert.SerializeObject(shortcase));
        }
    }
}
