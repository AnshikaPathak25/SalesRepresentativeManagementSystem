using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols;

namespace DataAccessLayer
{
    public class SalesRepDbContext: DbContext
    {
        public SalesRepDbContext() { 
        }
        public SalesRepDbContext(DbContextOptions options) : base(options) {
          
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionstring = "Data Source=DESKTOP-K1S6SQU\\SQLEXPRESS; Initial Catalog=SalesRepDB;Integrated Security=true;TrustServerCertificate=true;";
                optionsBuilder.UseSqlServer(connectionstring);
                base.OnConfiguring(optionsBuilder);
            }
        }

        public DbSet<SalesRepresentativeEntity> SalesRepresentatives { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<RegionEntity> Regions { get; set; }
        public DbSet<SalesPerformanceEntity> SalesPerformances { get; set; }
        public DbSet<PlatformEntity> Platforms { get; set; }
        public DbSet<UserEntity> Users { get; set; }

    }
}
