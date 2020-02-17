using BHHC.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace BHHC.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<Candidate> Candidates { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions)
            : base(dbContextOptions)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            this.ConfigureCandidates(modelBuilder.Entity<Candidate>());
            this.ConfigureFantasticReasons(modelBuilder.Entity<FantasticReason>());

            this.SeedData(modelBuilder);
        }

        private void ConfigureCandidates(EntityTypeBuilder<Candidate> entity)
        {
            // Table name
            entity.ToTable("Candidates");

            // Primary key
            entity.HasKey(c => c.Id);

            // Column constraints
            entity.Property(c => c.FirstName)
                .HasMaxLength(30)
                .IsRequired();

            entity.Property(c => c.LastName)
                .HasMaxLength(50)
                .IsRequired();

            entity.Property(c => c.Blurb)
                .HasMaxLength(500)
                .IsRequired();

            // 1-to-many relationship
            entity.HasMany(c => c.FantasticReasons)
                .WithOne(fr => fr.Candidate)
                .HasForeignKey(fr => fr.CandidateId);
        }

        private void ConfigureFantasticReasons(EntityTypeBuilder<FantasticReason> entity)
        {
            entity.ToTable("FantasticReasons");

            entity.HasKey(fr => fr.Id);

            entity.Property(fr => fr.DisplayOrder)
                .IsRequired()
                .HasDefaultValue(1);

            entity.Property(fr => fr.Reason)
                .IsRequired()
                .HasMaxLength(255);

            // Unique composite key (don't allow the a duplicate display order value for a single candidate)
            entity
                .HasIndex(fr => new
                {
                    fr.CandidateId,
                    fr.DisplayOrder
                })
                .IsUnique();
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            const int djCandidateId = 1;

            modelBuilder.Entity<Candidate>().HasData(
                new Candidate()
                {
                    Id = djCandidateId,
                    FirstName = "DJ",
                    LastName = "Hubka",
                    Blurb = "DJ is a CSUS Computer Science graduate with 9 years of experience in C#, Javascript, and Relational Databases."
                });

            modelBuilder.Entity<FantasticReason>().HasData(
                new FantasticReason()
                {
                    Id = 1,
                    CandidateId = djCandidateId,
                    DisplayOrder = 1,
                    Reason = "Reason 1"
                },
                new FantasticReason()
                {
                    Id = 2,
                    CandidateId = djCandidateId,
                    DisplayOrder = 2,
                    Reason = "Reason 2"
                },
                new FantasticReason()
                {
                    Id = 3,
                    CandidateId = djCandidateId,
                    DisplayOrder = 3,
                    Reason = "Reason 3"
                });
        }
    }
}
