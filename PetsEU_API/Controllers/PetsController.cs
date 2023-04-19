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
            }
            else
            {
                return pets;
            }
        }

        [HttpPost(Name = "InsertPets")]
        public int Post(string title, string description, int pool_id)
        {
            int a = connection.Execute("insert into post (title, description, image_pool_id) values (@title, @description, @pool_id)", new
            {
                title,
                description,
                pool_id
            });

            List<int> pets = connection.Query<int>("Select max(id) from post").ToList();

            return pets.First();
        }

        [HttpPut(Name = "UpdatePets")]
        public int Post(int id, string description)
        {
            int a = connection.Execute("update post set description = @description where id = @id", new
            {
                id,
                description
            });            

            return id;
        }

        [HttpDelete(Name = "DeletePets")]
        public int Delete(int id)
        {
            int a = connection.Execute("delete from post where id = @id", new
            {
                id
            });

            return id;
        }
    }
}
