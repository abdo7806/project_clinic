using Microsoft.EntityFrameworkCore;

namespace project_clinic.Models.Repositories
{
    public class DBContext : DbContext
    {
        public DBContext()
        {
        }

        public DBContext(DbContextOptions<DBContext> options) : base(options) { }

       /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=Clinic;User Id=sa;Password=123456;Trusted_Connection=true;TrustServerCertificate=True;");

        }*/

        public DbSet<Person> Person { get; set; }
        // أضف DbSets أخرى حسب الحاجة
    }
}
