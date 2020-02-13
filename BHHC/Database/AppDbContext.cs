using BHHC.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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

            // 1-to-many relationship
            entity.HasMany<FantasticReason>()
                .WithOne(fr => fr.Candidate)
                .OnDelete(DeleteBehavior.Cascade)
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
            entity.HasIndex(fr => new
                {
                    fr.CandidateId,
                    fr.DisplayOrder
                })
                .IsUnique();
        }
    }
}
