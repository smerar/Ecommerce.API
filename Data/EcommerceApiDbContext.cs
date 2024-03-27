using Microsoft.CodeAnalysis.Editing;
using Microsoft.EntityFrameworkCore;


namespace Ecommerce.API.Data
{
    public class EcommerceApiDbContext : DbContext
    {
        public EcommerceApiDbContext(DbContextOptions options) : base(options) { }

        //public DbSet<model class name> <<intented database table name>> {get; set;}
        //DbSet is used to query and save the instances
        public DbSet<User> User { get; set; }
      

    }

  
}
