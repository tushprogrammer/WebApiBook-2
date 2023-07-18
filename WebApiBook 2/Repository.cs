using Newtonsoft.Json;
using System.Xml.Linq;
using WebApiBook_2.ContextFolder;

namespace WebApIBook_2
{
    public static class Repository
    {
        //static List<Person> Data;
        static PersonDbContext context;

        static Repository()
        {
            context = new PersonDbContext();
            //string jsonFilePath = Path.Combine(|Directory.GetCurrentDirectory(), "People.json");
            //string jsonContent = File.ReadAllText(jsonFilePath);
            //Data = JsonConvert.DeserializeObject<List<Person>>(jsonContent);            
        }

        ///// <summary>
        ///// Метод сохранения БД
        ///// </summary>
        //private static void Save()
        //{
        //    string json = JsonConvert.SerializeObject(Data);
        //    File.WriteAllText(Path.Combine(Directory.GetCurrentDirectory(), "People.json"), json);
        //}

        /// <summary>
        /// Метод добавления нового контакта
        /// </summary>
        /// <param name="person">Новый контакт</param>
        public static void AddPerson(Person person)
        {
            int idmax = context.Persons.Max(x => x.Id);
            person.Id = idmax+1;
            context.Persons.Add(person);
            context.SaveChanges();
        }

        /// <summary>
        /// Метод удаления контакта
        /// </summary>
        /// <param name="id">Id удаляемого контакта</param>
        public static void RemovePerson(int id)
        {
            Person person = context.Persons.Find(id);
            context.Persons.Remove(person);
            context.SaveChanges();
        }

        /// <summary>
        /// Метод получения контакта
        /// </summary>
        /// <param name="id">Id нужного контакта</param>
        /// <returns></returns>
        public static Person GetPerson(int id)
        {
            return context.Persons.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Метод получения списка контактов
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Person> GetPeople()
        {
            return context.Persons;
        }

        /// <summary>
        /// Метод изменения контакта
        /// </summary>
        /// <param name="id">Id контакта</param>
        /// <param name="person">Измененный контакт</param>
        public static void EditPerson(int id, Person value) 
        {
            //насчёт id спорно, надо ли его передавать, если он есть в value?
            //Person person = JsonConvert.DeserializeObject<Person>(value);
            Person PersonNow = context.Persons.Find(id);
            PersonNow.Name = value.Name;
            PersonNow.LastName = value.LastName;
            PersonNow.MiddleName = value.MiddleName;
            PersonNow.Address = value.Address;
            PersonNow.Description = value.Description;
            context.SaveChanges();
        }
        private static void Initialize()
        {
            string jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "People.json");
            string jsonContent = File.ReadAllText(jsonFilePath);
            List<Person> Data = JsonConvert.DeserializeObject<List<Person>>(jsonContent);
            foreach (Person item in Data)
            {
                context.Persons.Add(item);
            }
            var r = context.Database.ExecuteSqlCommand($"SET IDENTITY_INSERT [People] OFF");
            context.SaveChanges();
            r = context.Database.ExecuteSqlCommand($"SET IDENTITY_INSERT [People] ON");
        }
    }
}
