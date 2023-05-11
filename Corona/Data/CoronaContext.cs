using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class CoronaContext : DbContext
    {
        public CoronaContext(DbContextOptions<CoronaContext> options) : base(options)
        {
        }


        public DbSet<Employee> Employees { get; set; }

        public DbSet<CoronaDetails> CoronaDetails { get; set; }

        public DbSet<VaccineInfo> VaccinesInfo { get; set; }
    }
}
