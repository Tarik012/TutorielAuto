﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TutorielAuto.TutorielAuto.Models;

#nullable disable

namespace TutorielAuto.Migrations
{
    [DbContext(typeof(TutorielAutoContext))]
    [Migration("20220602143804_MyfirstMigration")]
    partial class MyfirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TutorielAuto.TutorielAuto.Models.Categorie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Categorie", (string)null);
                });

            modelBuilder.Entity("TutorielAuto.TutorielAuto.Models.Tutoriel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategorieId")
                        .HasColumnType("int");

                    b.Property<string>("Contenu")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("Dcc")
                        .HasColumnType("datetime")
                        .HasColumnName("DCC");

                    b.Property<DateTime>("Dml")
                        .HasColumnType("datetime")
                        .HasColumnName("DML");

                    b.Property<string>("Titre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<string>("VideoLink")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CategorieId");

                    b.ToTable("Tutoriel", (string)null);
                });

            modelBuilder.Entity("TutorielAuto.TutorielAuto.Models.Tutoriel", b =>
                {
                    b.HasOne("TutorielAuto.TutorielAuto.Models.Categorie", "Categorie")
                        .WithMany("Tutoriels")
                        .HasForeignKey("CategorieId")
                        .IsRequired()
                        .HasConstraintName("FK_Tutoriel_Categorie");

                    b.Navigation("Categorie");
                });

            modelBuilder.Entity("TutorielAuto.TutorielAuto.Models.Categorie", b =>
                {
                    b.Navigation("Tutoriels");
                });
#pragma warning restore 612, 618
        }
    }
}
