using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FurbAPICore.Models;

namespace FurbAPICore.Models
{
    public class FurbAPICoreContext : DbContext
    {
        public FurbAPICoreContext (DbContextOptions<FurbAPICoreContext> options)
            : base(options)
        {
        }

        public DbSet<FurbAPICore.Models.Usuario> Usuario { get; set; }

        public DbSet<FurbAPICore.Models.Comanda> Comanda { get; set; }
    }
}
