using Microsoft.AspNetCore.Mvc;

namespace PetsEU_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PetsController : Controller
    {
        [HttpGet(Name = "GetPets")]
        public IEnumerable<Pets> Get(int? id)
        {
            // TODO: Implement
            return null;
        }
    }
}
