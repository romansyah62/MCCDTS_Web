using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> dbContext) : base(dbContext)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Departemen> Departemens { get; set; }
        public DbSet<Absensi> Absensis { get; set; }
    }
}
