﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectManager.Context;

#nullable disable

namespace ProjectManager.Migrations
{
    [DbContext(typeof(ProjectContext))]
    [Migration("20230915150147_initialCommit")]
    partial class initialCommit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ProjectManager.Models.Issue", b =>
                {
                    b.Property<int>("IssueId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IssueId"), 1L, 1);

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("CREATED");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(280)
                        .HasColumnType("nvarchar(280)")
                        .HasColumnName("DESCRIPTION");

                    b.Property<DateTime>("Due")
                        .HasColumnType("datetime2")
                        .HasColumnName("DUE");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int")
                        .HasColumnName("PROJECT_ID");

                    b.Property<int>("ReporterId")
                        .HasColumnType("int")
                        .HasColumnName("REPORTER_ID");

                    b.Property<string>("Summary")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("SUMMARY");

                    b.Property<DateTime>("Updated")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("UPDATED");

                    b.HasKey("IssueId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("ReporterId");

                    b.ToTable("Issues");
                });

            modelBuilder.Entity("ProjectManager.Models.Project", b =>
                {
                    b.Property<int>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjectId"), 1L, 1);

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("CREATED");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int")
                        .HasColumnName("OWNER_ID");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)")
                        .HasColumnName("TITLE");

                    b.Property<DateTime>("Updated")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("UPDATED");

                    b.HasKey("ProjectId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("ProjectManager.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("EMAIL");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("FIRSTNAME");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("LASTNAME");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("PASSWORD");

                    b.Property<DateTime>("UserCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("USER_CREATED");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("USERNAME");

                    b.HasKey("UserId");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ProjectManager.Models.Issue", b =>
                {
                    b.HasOne("ProjectManager.Models.Project", "Project")
                        .WithMany("Issues")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectManager.Models.User", "Reporter")
                        .WithMany("ReportedIssues")
                        .HasForeignKey("ReporterId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Project");

                    b.Navigation("Reporter");
                });

            modelBuilder.Entity("ProjectManager.Models.Project", b =>
                {
                    b.HasOne("ProjectManager.Models.User", "Owner")
                        .WithMany("OwnedProjects")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("ProjectManager.Models.Project", b =>
                {
                    b.Navigation("Issues");
                });

            modelBuilder.Entity("ProjectManager.Models.User", b =>
                {
                    b.Navigation("OwnedProjects");

                    b.Navigation("ReportedIssues");
                });
#pragma warning restore 612, 618
        }
    }
}