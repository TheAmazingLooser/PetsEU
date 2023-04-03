using Microsoft.AspNetCore.Mvc;

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
            if(id.HasValue)
            {
                
            } else
            {
                List<Pets> pets = connection.Query<Pets>("Select * from post").ToList();
                foreach(var pet in pets)
                {
                    
                }
            }
        }
    }
}
