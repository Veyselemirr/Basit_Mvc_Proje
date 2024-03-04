using Microsoft.EntityFrameworkCore;
using OOP_Project.Entity;

namespace OOP_Project.ProjeContext
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-2K9PCLA;database=DbNewOOPCore;integrated security=true;Trust Server Certificate=True");
        }

        internal Product Find(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public object Customer { get; internal set; }
    }
}
