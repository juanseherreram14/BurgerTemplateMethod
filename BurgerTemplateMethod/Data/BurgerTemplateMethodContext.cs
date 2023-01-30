using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BurgerTemplateMethod.Models;

namespace BurgerTemplateMethod.Data
{
    public class BurgerTemplateMethodContext : DbContext
    {
        public BurgerTemplateMethodContext (DbContextOptions<BurgerTemplateMethodContext> options)
            : base(options)
        {
        }

        public DbSet<BurgerTemplateMethod.Models.Burger> Burger { get; set; } = default!;

        public DbSet<BurgerTemplateMethod.Models.Americana> Americana { get; set; }

        public DbSet<BurgerTemplateMethod.Models.Hawaiana> Hawaiana { get; set; }

        public DbSet<BurgerTemplateMethod.Models.Ranchera> Ranchera { get; set; }
    }
}
