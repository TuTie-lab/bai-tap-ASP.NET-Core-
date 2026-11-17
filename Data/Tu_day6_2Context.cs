using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tu_day6_2.Models;

namespace Tu_day6_2.Data
{
    public class Tu_day6_2Context : DbContext
    {
        public Tu_day6_2Context (DbContextOptions<Tu_day6_2Context> options)
            : base(options)
        {
        }

        public DbSet<Tu_day6_2.Models.Genrecs> Genrecs { get; set; } = default!;
        public DbSet<Tu_day6_2.Models.Movie> Movie { get; set; } = default!;
    }
}
