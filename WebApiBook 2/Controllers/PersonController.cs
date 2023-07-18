using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApIBook_2.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class PersonController : Controller
    {

        // GET: api/Person
        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return Repository.GetPeople();
        }

        //GET: api/Person/4
        [HttpGet("{id}")]
        public Person GetPerson(int id)
        {
            return Repository.GetPerson(id);
        }

        // Put: api/Person/5
        [HttpPut("{id}")]
        public void Edit(int id, [FromBody] Person value)
        {
            Repository.EditPerson(id, value);
        }

        //Delete : api/Person/6
        [HttpDelete("{id}")]
        public void Remove(int id)
        {
            Repository.RemovePerson(id);
        }

        //Post : api/Person
        [HttpPost]
        public void AddPerson([FromBody] Person value)
        {
            Repository.AddPerson(value);
        } 
    }
}
