using MCCDTS_Web.Models;
using Microsoft.EntityFrameworkCore;

namespace MCCDTS_Web.Context
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
