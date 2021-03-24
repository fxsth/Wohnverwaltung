using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Wohnverwaltung.Models;

namespace Wohnverwaltung.Data
{
    public class WohnungsContext : DbContext
    {
        public WohnungsContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Wohnung> Wohnungen { get; set; }
    }
}
