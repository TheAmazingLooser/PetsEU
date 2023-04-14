using Dapper;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;

namespace PetsEU_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PetsController : Controller
    {
        private readonly MySqlConnection connection;

        public PetsController(MySqlConnection connection)
        {
            this.connection = connection;
        }

        [HttpGet(Name = "GetPets")]
        public IEnumerable<Pets> Get(int? id)
        {
            List<Pets> pets = connection.Query<Pets>("Select * from post").ToList();
            if (id.HasValue)
            {
                return pets.Where(p => p.Id == id.Value);
            } else
            {
                return pets;
            }
        }
    }
}
