using BCAvanade_design_patterns.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCAvanade_design_patterns.Infra.Repository.EF
{
    public class FrotaContext : DbContext
    {
        public FrotaContext(DbContextOptions<FrotaContext> options)
           : base(options)
        {
        }

        public DbSet<Veiculo> Veiculos { get; set; }
    }
}
