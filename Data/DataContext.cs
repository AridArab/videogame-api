using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace videogame_api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Videogame> Videogames => Set<Videogame>();
    }
}