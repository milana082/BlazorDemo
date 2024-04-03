using CrudOperations.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Models
{
    public class ItemContext : DbContext
    {
        public ItemContext(DbContextOptions<ItemContext> options) : base(options)
        {

        }
        public DbSet<Item> Items { get; set; }
    }
}
