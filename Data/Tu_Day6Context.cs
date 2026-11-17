using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tu_Day6.Models;

namespace Tu_Day6.Data
{
    public class Tu_Day6Context : DbContext
    {
        public Tu_Day6Context (DbContextOptions<Tu_Day6Context> options)
            : base(options)
        {
        }

        public DbSet<Tu_Day6.Models.Product> Product { get; set; } = default!;
    }
}
