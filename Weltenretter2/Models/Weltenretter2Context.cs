using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Weltenretter2.Models;


namespace Weltenretter2.Models
{
    public partial class Weltenretter2Context : DbContext
    {

        public virtual DbSet<Agressor> Agressor { get; set; }
        public virtual DbSet<Bedrohung> Bedrohung { get; set; }
        public virtual DbSet<Held> Held { get; set; }

        public Weltenretter2Context(DbContextOptions<Weltenretter2Context> options) : base (options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agressor>(entity =>
            {
                entity.Property(e => e.AgressorId).HasColumnName("agressor_id");

                entity.Property(e => e.Nachname)
                    .IsRequired()
                    .HasColumnName("nachname")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Spezialitaet)
                    .HasColumnName("spezialitaet")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Vorname)
                    .IsRequired()
                    .HasColumnName("vorname")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Bedrohung>(entity =>
            {
                entity.Property(e => e.BedrohungId).HasColumnName("bedrohung_id");

                entity.Property(e => e.AgressorId).HasColumnName("agressor_id");

                entity.Property(e => e.Existent).HasColumnName("existent");

                entity.Property(e => e.HeldId).HasColumnName("held_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Agressor)
                    .WithMany(p => p.Bedrohung)
                    .HasForeignKey(d => d.AgressorId)
                    .HasConstraintName("fk_bedrohung_agressor");

                entity.HasOne(d => d.Held)
                    .WithMany(p => p.Bedrohung)
                    .HasForeignKey(d => d.HeldId)
                    .HasConstraintName("fk_bedrohung_held");
            });

            modelBuilder.Entity<Held>(entity =>
            {
                entity.Property(e => e.HeldId).HasColumnName("held_id");

                entity.Property(e => e.Beruf)
                    .HasColumnName("beruf")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nachname)
                    .IsRequired()
                    .HasColumnName("nachname")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Vorname)
                    .IsRequired()
                    .HasColumnName("vorname")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
