
using Microsoft.EntityFrameworkCore;

namespace cheftDishes.Models
{
    public class MyContext : DbContext
    {   
        public DbSet<Chef> chef {get; set;}

        public DbSet<Dish> dishes {get; set;}
        public MyContext(DbContextOptions options) : base(options) { }
        
    }
}