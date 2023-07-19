
namespace WebApIBook_2
{
    public interface IRepository
    {
        public void AddPerson(Person person);
        public void RemovePerson(int id);
        public Person GetPerson(int id);
        public IEnumerable<Person> GetPeople();
        public void EditPerson(int id, Person value);
    }
}
