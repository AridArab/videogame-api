using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace videogame_api.Data
{
    public class DataContext : DbContext
    {
        /* Data context class that implements the database,
        the database was implemented doing code first. */
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            /*Options go in here*/
        }


        public DbSet<Videogame> Videogames => Set<Videogame>();
    }
}