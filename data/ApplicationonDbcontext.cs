using ConsoleApp7.moduls;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7.data
{
    internal class ApplicationonDbcontext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server= TAMARA;database=crud;trusted_connection=true; trustservercertificate=true");
        }

        public DbSet<product> products { get; set; }
        public DbSet<order> orders { get; set; }
    }
}
