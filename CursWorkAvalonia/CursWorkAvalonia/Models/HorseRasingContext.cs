using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CursWorkAvalonia
{
    public partial class HorseRasingContext : DbContext
    {
        public HorseRasingContext()
        {
        }

        public HorseRasingContext(DbContextOptions<HorseRasingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bookmaker> Bookmakers { get; set; } = null!;
        public virtual DbSet<Horse> Horses { get; set; } = null!;
        public virtual DbSet<Jockey> Jockeys { get; set; } = null!;
        public virtual DbSet<Location> Locations { get; set; } = null!;
        public virtual DbSet<Owner> Owners { get; set; } = null!;
        public virtual DbSet<Run> Runs { get; set; } = null!;
        public virtual DbSet<Trainer> Trainers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlite("Data Source=C:\\Users\\SeveralCamper\\Desktop\\Вера\\CursWorkAvalonia\\HorseRasing.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bookmaker>(entity =>
            {
                entity.HasKey(e => e.OrganizationSName);

                entity.ToTable("BOOKMAKER");

                entity.Property(e => e.OrganizationSName).HasColumnName("Organization's Name");

                entity.Property(e => e.LeadTheRase)
                    .HasColumnType("BOOLEAN")
                    .HasColumnName("Lead the rase");

                entity.Property(e => e.RunId).HasColumnName("RunID");

                entity.HasOne(d => d.Run)
                    .WithMany(p => p.Bookmakers)
                    .HasForeignKey(d => d.RunId);
            });

            modelBuilder.Entity<Horse>(entity =>
            {
                entity.ToTable("HORSE");

                entity.HasIndex(e => e.HorseId, "IX_HORSE_HorseID")
                    .IsUnique();

                entity.Property(e => e.HorseId)
                    .ValueGeneratedNever()
                    .HasColumnName("HorseID");

                entity.Property(e => e.JockeyId).HasColumnName("JockeyID");

                entity.Property(e => e.OwnerId).HasColumnName("OwnerID");

                entity.Property(e => e.Rating).HasColumnType("DOUBLE");

                entity.Property(e => e.TrainerId).HasColumnName("TrainerID");

                entity.Property(e => e.Weight).HasColumnType("DOUBLE");

                entity.HasOne(d => d.Jockey)
                    .WithMany(p => p.Horses)
                    .HasForeignKey(d => d.JockeyId);

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.Horses)
                    .HasForeignKey(d => d.OwnerId);

                entity.HasOne(d => d.Trainer)
                    .WithMany(p => p.Horses)
                    .HasForeignKey(d => d.TrainerId);
            });

            modelBuilder.Entity<Jockey>(entity =>
            {
                entity.ToTable("JOCKEY");

                entity.HasIndex(e => e.JockeyId, "IX_JOCKEY_JockeyID")
                    .IsUnique();

                entity.Property(e => e.JockeyId)
                    .ValueGeneratedNever()
                    .HasColumnName("JockeyID");

                entity.Property(e => e.Weight).HasColumnType("DOUBLE");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("LOCATION");

                entity.HasIndex(e => e.LocationId, "IX_LOCATION_LocationID")
                    .IsUnique();

                entity.Property(e => e.LocationId)
                    .ValueGeneratedNever()
                    .HasColumnName("LocationID");
            });

            modelBuilder.Entity<Owner>(entity =>
            {
                entity.ToTable("OWNER");

                entity.Property(e => e.OwnerId)
                    .ValueGeneratedNever()
                    .HasColumnName("OwnerID");
            });

            modelBuilder.Entity<Run>(entity =>
            {
                entity.ToTable("RUN");

                entity.HasIndex(e => e.RunId, "IX_RUN_RunID")
                    .IsUnique();

                entity.Property(e => e.RunId)
                    .ValueGeneratedNever()
                    .HasColumnName("RunID");

                entity.Property(e => e.DistanceFur).HasColumnName("Distance (fur)");

                entity.Property(e => e.ListOfHorseId).HasColumnName("List of HorseID");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.TypeOfRace).HasColumnName("Type of race");

                entity.HasOne(d => d.ListOfHorse)
                    .WithMany(p => p.Runs)
                    .HasForeignKey(d => d.ListOfHorseId);

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Runs)
                    .HasForeignKey(d => d.LocationId);
            });

            modelBuilder.Entity<Trainer>(entity =>
            {
                entity.ToTable("TRAINER");

                entity.HasIndex(e => e.TrainerId, "IX_TRAINER_TrainerID")
                    .IsUnique();

                entity.Property(e => e.TrainerId)
                    .ValueGeneratedNever()
                    .HasColumnName("TrainerID");

                entity.Property(e => e.Rating).HasColumnType("DOUBLE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
