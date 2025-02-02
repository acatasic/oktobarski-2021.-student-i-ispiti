﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Template.Models;

namespace Template.Migrations
{
    [DbContext(typeof(IspitDbContext))]
    [Migration("20220530172236_v1")]
    partial class v1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Template.Models.IspitniRok", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.ToTable("IspitniRok");
                });

            modelBuilder.Entity("Template.Models.Predmet", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Godina")
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.ToTable("Predmet");
                });

            modelBuilder.Entity("Template.Models.Student", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Indeks")
                        .HasColumnType("int");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("Template.Models.StudentPredmet", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("IspitniRokID")
                        .HasColumnType("int");

                    b.Property<int>("Ocena")
                        .HasColumnType("int");

                    b.Property<int?>("PredmetID")
                        .HasColumnType("int");

                    b.Property<int?>("StudentID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("IspitniRokID");

                    b.HasIndex("PredmetID");

                    b.HasIndex("StudentID");

                    b.ToTable("StudentPredmet");
                });

            modelBuilder.Entity("Template.Models.StudentPredmet", b =>
                {
                    b.HasOne("Template.Models.IspitniRok", "IspitniRok")
                        .WithMany("StudentPredmet")
                        .HasForeignKey("IspitniRokID");

                    b.HasOne("Template.Models.Predmet", "Predmet")
                        .WithMany("StudentPredmet")
                        .HasForeignKey("PredmetID");

                    b.HasOne("Template.Models.Student", "Student")
                        .WithMany("StudentPredmet")
                        .HasForeignKey("StudentID");

                    b.Navigation("IspitniRok");

                    b.Navigation("Predmet");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Template.Models.IspitniRok", b =>
                {
                    b.Navigation("StudentPredmet");
                });

            modelBuilder.Entity("Template.Models.Predmet", b =>
                {
                    b.Navigation("StudentPredmet");
                });

            modelBuilder.Entity("Template.Models.Student", b =>
                {
                    b.Navigation("StudentPredmet");
                });
#pragma warning restore 612, 618
        }
    }
}
