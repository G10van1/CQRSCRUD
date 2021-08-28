using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRSCRUD.Models;

namespace CQRSCRUD.Database
{
    public class CQRSCRUDContext : DbContext
    {
        public CQRSCRUDContext()
        {
        }

        public CQRSCRUDContext(DbContextOptions<CQRSCRUDContext> options)
            : base(options)
        {
        }

        //public virtual DbSet<Cliente> Cliente { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Data Source = MYLAPTOP\SQLEXPRESS; Initial Catalog = cqrscrud; Persist Security Info = True; User ID = cqrs; Password = CQRSCRUD123");                            
        }

        //public virtual DbSet<Cliente> Cliente { get; set; }

        public DbSet<Cliente> Cliente { get; set; }
    }
}