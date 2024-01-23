using Microsoft.EntityFrameworkCore;

namespace AGgrid1.Models
{
    public class ProductDbContext1: DbContext
    {
        public ProductDbContext1(DbContextOptions<ProductDbContext1> options)
             : base(options) //database connection

    {

    }
    public DbSet<Product1> Products { get; set; }
}
}
