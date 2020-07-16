﻿// <auto-generated />
using System;
using EnglishCourse1._1.Modelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EnglishCourse1._1.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EnglishCourse1._1.Modelos.curso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("curso");
                });

            modelBuilder.Entity("EnglishCourse1._1.Modelos.estudiantes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("apellido")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("correo")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int>("edad")
                        .HasColumnType("int");

                    b.Property<int>("idsecciones")
                        .HasColumnType("int");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("seccionesId")
                        .HasColumnType("int");

                    b.Property<string>("telefono")
                        .HasColumnType("varchar(25)");

                    b.HasKey("Id");

                    b.HasIndex("seccionesId");

                    b.ToTable("estudiantes");
                });

            modelBuilder.Entity("EnglishCourse1._1.Modelos.profesores", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<string>("apellido")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("profesores");
                });

            modelBuilder.Entity("EnglishCourse1._1.Modelos.secciones", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Aula")
                        .HasColumnType("varchar(10)");

                    b.Property<int?>("cursoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("hora")
                        .HasColumnType("datetime2");

                    b.Property<int>("idcurso")
                        .HasColumnType("int");

                    b.Property<int>("idprofesores")
                        .HasColumnType("int");

                    b.Property<int?>("profesoresId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("cursoId");

                    b.HasIndex("profesoresId");

                    b.ToTable("secciones");
                });

            modelBuilder.Entity("EnglishCourse1._1.Modelos.estudiantes", b =>
                {
                    b.HasOne("EnglishCourse1._1.Modelos.secciones", null)
                        .WithMany("estudiantes")
                        .HasForeignKey("seccionesId");
                });

            modelBuilder.Entity("EnglishCourse1._1.Modelos.secciones", b =>
                {
                    b.HasOne("EnglishCourse1._1.Modelos.curso", null)
                        .WithMany("secciones")
                        .HasForeignKey("cursoId");

                    b.HasOne("EnglishCourse1._1.Modelos.profesores", null)
                        .WithMany("secciones")
                        .HasForeignKey("profesoresId");
                });
#pragma warning restore 612, 618
        }
    }
}