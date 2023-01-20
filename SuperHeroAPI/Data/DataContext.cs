using Microsoft.EntityFrameworkCore;
namespace SuperHeroAPI.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<SuperHero> SuperHeros => Set<SuperHero>();
        //creates table for query  & save instances of superhero 
    }
}
