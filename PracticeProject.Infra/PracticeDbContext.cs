using Microsoft.EntityFrameworkCore;
using PracticeProject.Infra.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProject.Infra
{
    public class PracticeDbContext :DbContext
    {
        public PracticeDbContext(DbContextOptions<PracticeDbContext>options):base(options)
        {
            
        }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Mapping> Mapping { get; set; }

    }
}
