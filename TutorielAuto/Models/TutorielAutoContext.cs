using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TutorielAuto.TutorielAuto.Models
{
    public partial class TutorielAutoContext : DbContext
    {
        public TutorielAutoContext()
        {
        }

        public TutorielAutoContext(DbContextOptions<TutorielAutoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categorie> Categories { get; set; } = null!;
        public virtual DbSet<Tutoriel> Tutoriels { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorie>(entity =>
            {
                entity.ToTable("Categorie");

                entity.Property(e => e.Label)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tutoriel>(entity =>
            {
                entity.ToTable("Tutoriel");

                entity.Property(e => e.Contenu).HasColumnType("text");

                entity.Property(e => e.Dcc)
                    .HasColumnType("datetime")
                    .HasColumnName("DCC");

                entity.Property(e => e.Dml)
                    .HasColumnType("datetime")
                    .HasColumnName("DML");

                entity.Property(e => e.Titre)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.VideoLink)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Categorie)
                    .WithMany(p => p.Tutoriels)
                    .HasForeignKey(d => d.CategorieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tutoriel_Categorie");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
