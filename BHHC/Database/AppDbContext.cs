using BHHC.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BHHC.Database
{
    public class AppDbContext : DbContext
    {
        //public DbSet<FantasticReason> FantasticReasons { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions)
            : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //this.ConfigureFantasticReasons(modelBuilder.Entity<FantasticReason>());
        }

        private void ConfigureFantasticReasons(EntityTypeBuilder<FantasticReason> entity)
        {
            entity.ToTable("FantasticReasons");

            entity.HasKey(fr => fr.Id);

            entity.Property(fr => fr.DisplayOrder)
                .IsRequired()
                .HasDefaultValue(1);
        }
    }
}
