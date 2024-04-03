using Microsoft.EntityFrameworkCore;

namespace CrudOperations.Models
{
    public class BrandContext : DbContext
    {
        public BrandContext(DbContextOptions<BrandContext> options) : base(options)
        {

        }
        public DbSet<Brand> Brands { get; set; }

        //internal IList<Brand> CreatedAtAction(string v, object value, Brand brand)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
