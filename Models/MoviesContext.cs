using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace crud.Models
{
    public partial class MoviesContext : DbContext
    {
        public MoviesContext()
        {
        }

        public MoviesContext(DbContextOptions<MoviesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actor> Actors { get; set; }
        public virtual DbSet<Casting> Castings { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=madbase2.clskmfl4l7hm.us-east-1.rds.amazonaws.com;Database=Movies;user id=admin;pwd=firefox09;Trusted_Connection=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>(entity =>
            {
                entity.HasKey(e => e.Actorno)
                    .HasName("PK__ACTOR__1C2DB4F4CC241DAD");

                entity.ToTable("ACTOR");

                entity.Property(e => e.Actorno)
                    .ValueGeneratedNever()
                    .HasColumnName("ACTORNO");

                entity.Property(e => e.Fullname)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("FULLNAME");

                entity.Property(e => e.Givenname)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("GIVENNAME");

                entity.Property(e => e.Surname)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SURNAME");
            });

            modelBuilder.Entity<Casting>(entity =>
            {
                entity.HasKey(e => e.Castid)
                    .HasName("PK__CASTING__D3F444367FE44911");

                entity.ToTable("CASTING");

                entity.Property(e => e.Castid)
                    .ValueGeneratedNever()
                    .HasColumnName("CASTID");

                entity.Property(e => e.Actorno).HasColumnName("ACTORNO");

                entity.Property(e => e.Movieno).HasColumnName("MOVIENO");

                entity.HasOne(d => d.ActornoNavigation)
                    .WithMany(p => p.Castings)
                    .HasForeignKey(d => d.Actorno)
                    .HasConstraintName("FK__CASTING__ACTORNO__3A81B327");

                entity.HasOne(d => d.MovienoNavigation)
                    .WithMany(p => p.Castings)
                    .HasForeignKey(d => d.Movieno)
                    .HasConstraintName("FK__CASTING__MOVIENO__3B75D760");
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.HasKey(e => e.Movieno)
                    .HasName("PK__MOVIE__7CA06A6DCADF4F80");

                entity.ToTable("MOVIE");

                entity.Property(e => e.Movieno)
                    .ValueGeneratedNever()
                    .HasColumnName("MOVIENO");

                entity.Property(e => e.Relyear).HasColumnName("RELYEAR");

                entity.Property(e => e.Runtime).HasColumnName("RUNTIME");

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TITLE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
