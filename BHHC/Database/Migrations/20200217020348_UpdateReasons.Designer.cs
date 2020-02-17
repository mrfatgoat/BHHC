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
    [Migration("20200217020348_UpdateReasons")]
    partial class UpdateReasons
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
                            Id = 4,
                            CandidateId = 1,
                            Description = "I've spent most of my career as a full-stack dev using AngularJS and C#. Most recently I have held a primarily back-end role and since then I have had a strong desire to learn more modern front-end web technologies. While my expertise today is in AngularJS, I have exposure to both React and Angular 7+ and a strong desire to work with a team to deepen my knowledge.",
                            DisplayOrder = 3,
                            Reason = "Desire to return to a full-stack development position"
                        },
                        new
                        {
                            Id = 5,
                            CandidateId = 1,
                            Description = "I have used .NET Core since before version 1.0 and each iteration has been a joy to code with. I am excited to bring my experience to the table and offer ideas on how best to leverage .NET Core as BHHC moves toward a microservice architecture.",
                            DisplayOrder = 2,
                            Reason = "Eager to continue working with .NET Core"
                        },
                        new
                        {
                            Id = 6,
                            CandidateId = 1,
                            Description = "In my experience, the best and most productive teams are filled with people who are always ready to learn and improve. There's no room for ego when it comes to finding the best solution to a problem, and I look forward to working with people who are ready to learn, teach, and grow together. From the interactions I've had with BHHC so far, I feel that's exactly the culture I'd find and would enjoy being part of.",
                            DisplayOrder = 1,
                            Reason = "Excited to be a part of a collaborative, cohesive, and open-minded team"
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
