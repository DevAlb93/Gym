using Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Database.EF
{
    //Ne perdorim Paketen Ef Core 
    public class ApplicationDbContext : DbContext
    {
        string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Holger2;Integrated Security=True;Persist Security Info=False;Pooling=False;Multiple Active Result Sets=False;Encrypt=False;Trust Server Certificate=False;Command Timeout=0";
        public ApplicationDbContext()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
        //public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContext) 
        //    : base(dbContext)
        //{
        //}


        //Tabelat qe do te krijojme ne Databaze (jane shumes)
        public DbSet<Category> Categories { get; set; }
        public DbSet<Gym> Gyms { get; set; }
        public DbSet<Machine> Machines { get; set; }
    }
}
