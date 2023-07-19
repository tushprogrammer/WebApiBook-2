
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApiBook_2.AuthPersonApp;
using WebApIBook_2;


namespace WebApiBook_2.ContextFolder
{
    public class PersonDbContext : IdentityDbContext<User>
    {
        public PersonDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Person> Persons { get; set; }
    }
}
