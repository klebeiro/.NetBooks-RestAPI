using Microsoft.EntityFrameworkCore;

namespace AspNetRest.Model.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) {}

        public DbSet<Person> Persons { get; set; }
        public DbSet<Books> Books { get; set; }
    }
}
