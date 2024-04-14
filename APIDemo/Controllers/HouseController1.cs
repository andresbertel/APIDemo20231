using APIDemo.Context;
using APIDemo.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HouseController1 : ControllerBase
    {

        private readonly AppDbContext context;

        public HouseController1(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<HouseController1>
        [HttpGet]
        public IEnumerable<Housedb> Get()
        {
            return this.context.Housedb.ToList();
        }

        // GET api/<HouseController1>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<HouseController1>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<HouseController1>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<HouseController1>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
