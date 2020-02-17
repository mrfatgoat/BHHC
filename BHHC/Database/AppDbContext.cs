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

            entity.Property(fr => fr.Description)
                .IsRequired()
                .HasMaxLength(1000);

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
                    Id = 4,
                    CandidateId = djCandidateId,
                    DisplayOrder = 3,
                    Reason = "Desire to return to a full-stack development position",
                    Description = "I've spent most of my career as a full-stack dev using AngularJS and C#." +
                        " Most recently I have held a primarily back-end role and since then I have had a strong desire to learn more modern front-end web technologies." +
                        " While my expertise today is in AngularJS, I have exposure to both React and Angular 7+ and a strong desire to work with a team to deepen my knowledge."
                },
                new FantasticReason()
                {
                    Id = 5,
                    CandidateId = djCandidateId,
                    DisplayOrder = 2,
                    Reason = "Eager to continue working with .NET Core",
                    Description = "I have used .NET Core since before version 1.0 and each iteration has been a joy to code with." +
                        " I am excited to bring my experience to the table and offer ideas on how best to leverage .NET Core as BHHC moves toward a microservice architecture."
                },
                new FantasticReason()
                {
                    Id = 6,
                    CandidateId = djCandidateId,
                    DisplayOrder = 1,
                    Reason = "Excited to be a part of a collaborative, cohesive, and open-minded team",
                    Description = "In my experience, the best and most productive teams are filled with people who are always ready to learn and improve." +
                        " There's no room for ego when it comes to finding the best solution to a problem, and I look forward to working with people who are ready to learn, teach, and grow together." +
                        " From the interactions I've had with BHHC so far, I feel that's exactly the culture I'd find and would enjoy being part of."
                });
        }
    }
}
