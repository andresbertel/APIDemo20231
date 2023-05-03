using APIDemo.Context;
using APIDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonasController : ControllerBase
    {
        private readonly AppDbContext context;

        public PersonasController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<PersonasController>
        [HttpGet]
        public IEnumerable<Personasdb> Get()
        {
            return context.Personasdb.ToList();

           
        }

        // GET api/<PersonasController>/5
        [HttpGet("{id}")]
        public Personasdb Get(int id)
        {
          //  var personasdb = context.Personasdb.FirstOrDefault(x => x.Id == id);
            Personasdb personasdb = null;

            //Procedimientos almacenados

            SqlConnection connection = (SqlConnection)context.Database.GetDbConnection();
            SqlCommand command = connection.CreateCommand();

            connection.Open();

            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "SPBuscarTodos";         
            command.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                personasdb = new Personasdb();

                personasdb.Id = (Int64)reader["id"];
                personasdb.Nombres = reader["nombres"].ToString();
                personasdb.Apellidos = reader["apellidos"].ToString();

            }

            connection.Close();

            return personasdb;
        }

        // POST api/<PersonasController>
        [HttpPost]
        public void Post([FromBody] Personasdb personasdb)
        {
            int result = context.Personasdb.Add(personasdb).Context.SaveChanges();
          
        }

        // PUT api/<PersonasController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Personasdb personaCatualizada)
        {
            Personasdb? personaBuscada = context.Personasdb.FirstOrDefault(x => x.Id == id);
            if (personaBuscada == null) { return; }
            personaBuscada.Nombres = personaCatualizada?.Apellidos;
            personaBuscada.Apellidos = personaCatualizada?.Apellidos;
            context.SaveChanges();

        }

        // DELETE api/<PersonasController>/5
        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            int response = 0;

            var personaBuscada = context.Personasdb.FirstOrDefault(x => x.Id == id);

            if (personaBuscada != null)
            {
                response = context.Personasdb.Remove(personaBuscada).Context.SaveChanges();
            }

            return response;
        }
    }
}
