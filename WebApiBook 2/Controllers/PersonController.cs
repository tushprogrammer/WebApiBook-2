using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApIBook_2.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    //Контроллер для доступа к данным телефонной книги
    public class PersonController : Controller
    {
        private readonly IRepository Rep;
        public PersonController(IRepository repository)
        {
            Rep = repository;
        }
        
        // GET: api/Person
        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return Rep.GetPeople();
        }

        //GET: api/Person/4
        [HttpGet("{id}")]
        public Person GetPerson(int id)
        {
            return Rep.GetPerson(id);
        }

        // Put: api/Person/5
        [HttpPut("{id}")]
        public void Edit(int id, [FromBody] Person value)
        {
            Rep.EditPerson(id, value);
        }

        //Delete : api/Person/6
        [HttpDelete("{id}")]
        public void Remove(int id)
        {
            Rep.RemovePerson(id);
        }

        //Post : api/Person
        [HttpPost]
        public void AddPerson([FromBody] Person value)
        {
            Rep.AddPerson(value);
        } 
    }
}
