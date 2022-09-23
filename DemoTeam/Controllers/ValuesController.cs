using DemoTeam.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoTeam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpGet]
        [Route("{a}/{b}")]
        public decimal Calculate(int a,int b)
        {
            if (b != 0)
                return a/b;

            return 0;
        }

        [HttpGet]
        [Route("GetParty")]
        public ActionResult GetParty(int id)
        {
            if (id == 0)
                return NotFound("Invalid");

            var res = new List<Party>() { new Party() { Id = 1, Name = "abc" }, new Party() { Id = 2, Name = "asd" } };

            var searilizedRes = JsonConvert.SerializeObject(res,Formatting.Indented);
            
            return Ok(searilizedRes);
                
        }

        [HttpGet]
        [Route("Validate")]
        public ActionResult Validate()
        {

            var searilizedRes = GetParty(1);

            List<Party> output = null;

            if (searilizedRes != null)
            {
                var res = searilizedRes as OkObjectResult;
                 var result = res.Value;

                output = JsonConvert.DeserializeObject<List<Party>>(result.ToString());
            }

            return Ok(output);

        }
    }
}
