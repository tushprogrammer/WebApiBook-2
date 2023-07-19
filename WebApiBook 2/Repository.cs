using Newtonsoft.Json;
using System.Xml.Linq;
using WebApiBook_2.ContextFolder;

namespace WebApIBook_2
{
    public class Repository : IRepository
    {
        //static List<Person> Data;
        private readonly PersonDbContext Context;

        public Repository(PersonDbContext context)
        {
            Context = context;        
        }


        /// <summary>
        /// Метод добавления нового контакта
        /// </summary>
        /// <param name="person">Новый контакт</param>
        public void AddPerson(Person person)
        {
            int idmax = Context.Persons.Max(x => x.Id);
            person.Id = idmax+1;
            Context.Persons.Add(person);
            Context.SaveChanges();
        }

        /// <summary>
        /// Метод удаления контакта
        /// </summary>
        /// <param name="id">Id удаляемого контакта</param>
        public void RemovePerson(int id)
        {
            Person person = Context.Persons.Find(id);
            Context.Persons.Remove(person);
            Context.SaveChanges();
        }

        /// <summary>
        /// Метод получения контакта
        /// </summary>
        /// <param name="id">Id нужного контакта</param>
        /// <returns></returns>
        public Person GetPerson(int id)
        {
            return Context.Persons.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Метод получения списка контактов
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Person> GetPeople()
        {
            return Context.Persons;
        }

        /// <summary>
        /// Метод изменения контакта
        /// </summary>
        /// <param name="id">Id контакта</param>
        /// <param name="person">Измененный контакт</param>
        public void EditPerson(int id, Person value) 
        {
            //насчёт id спорно, надо ли его передавать, если он есть в value?
            //Person person = JsonConvert.DeserializeObject<Person>(value);
            Person PersonNow = Context.Persons.Find(id);
            PersonNow.Name = value.Name;
            PersonNow.LastName = value.LastName;
            PersonNow.MiddleName = value.MiddleName;
            PersonNow.Address = value.Address;
            PersonNow.Description = value.Description;
            Context.SaveChanges();
        }
        //private static void Initialize()
        //{
        //    string jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "People.json");
        //    string jsonContent = File.ReadAllText(jsonFilePath);
        //    List<Person> Data = JsonConvert.DeserializeObject<List<Person>>(jsonContent);
        //    foreach (Person item in Data)
        //    {
        //        context.Persons.Add(item);
        //    }
        //    var r = context.Database.ExecuteSqlCommand($"SET IDENTITY_INSERT [People] OFF");
        //    context.SaveChanges();
        //    r = context.Database.ExecuteSqlCommand($"SET IDENTITY_INSERT [People] ON");
        //}
    }
}
