﻿// <auto-generated />
using BHHC.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BHHC.Database.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20200217011001_AddReasonDescription")]
    partial class AddReasonDescription
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BHHC.Database.Models.Candidate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Blurb")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Candidates");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Blurb = "DJ is a CSUS Computer Science graduate with 9 years of experience in C#, Javascript, and Relational Databases.",
                            FirstName = "DJ",
                            LastName = "Hubka"
                        });
                });

            modelBuilder.Entity("BHHC.Database.Models.FantasticReason", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CandidateId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)")
                        .HasMaxLength(1000);

                    b.Property<int>("DisplayOrder")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("CandidateId", "DisplayOrder")
                        .IsUnique();

                    b.ToTable("FantasticReasons");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CandidateId = 1,
                            Description = "",
                            DisplayOrder = 1,
                            Reason = "Reason 1"
                        },
                        new
                        {
                            Id = 2,
                            CandidateId = 1,
                            Description = "",
                            DisplayOrder = 2,
                            Reason = "Reason 2"
                        },
                        new
                        {
                            Id = 3,
                            CandidateId = 1,
                            Description = "",
                            DisplayOrder = 3,
                            Reason = "Reason 3"
                        });
                });

            modelBuilder.Entity("BHHC.Database.Models.FantasticReason", b =>
                {
                    b.HasOne("BHHC.Database.Models.Candidate", "Candidate")
                        .WithMany("FantasticReasons")
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}