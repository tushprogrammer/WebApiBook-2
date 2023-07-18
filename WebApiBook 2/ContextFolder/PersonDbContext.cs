
using Microsoft.AspNetCore.Identity;
using System.Data.Entity;
using WebApIBook_2;


namespace WebApiBook_2.ContextFolder
{
    public class PersonDbContext : DbContext
    {
        public PersonDbContext() : base("ApiDBPerson") { }
        public DbSet<Person> Persons { get; set; }
    }
}
