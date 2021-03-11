using System.Data.Entity;

namespace Model.Data
{
    public class Context : DbContext
    {
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

        public Context():base(@"CodeFirstDb")
        {

        }
        
    }
}
