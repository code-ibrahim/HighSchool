using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HighSchool.DataAccessLayer.Models
{
    public partial class HighSchoolContext : DbContext
    {
        public HighSchoolContext()
        {
        }

        public HighSchoolContext(DbContextOptions<HighSchoolContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<CourseInstructor> CourseInstructor { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<StudentGrade> StudentGrade { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlite("Data Source=C:/Users/INDIAN/Documents/DB/HighSchool;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(e => e.CourseId)
                    .HasColumnName("CourseID")
                    .HasColumnType("int")
                    .ValueGeneratedNever();

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnType("nvarchar");
            });

            modelBuilder.Entity<CourseInstructor>(entity =>
            {
                entity.HasKey(e => new { e.CourseId, e.PersonId });

                entity.Property(e => e.CourseId)
                    .HasColumnName("CourseID")
                    .HasColumnType("int");

                entity.Property(e => e.PersonId)
                    .HasColumnName("PersonID")
                    .HasColumnType("int");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.CourseInstructor)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.CourseInstructor)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasIndex(e => e.RoleId)
                    .HasName("ix_RoleId");

                entity.Property(e => e.PersonId)
                    .HasColumnName("PersonID")
                    .HasColumnType("int")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnType("VARCHAR(200)");

                entity.Property(e => e.DateOfBirth)
                    .IsRequired()
                    .HasColumnType("DATE");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnType("nvarchar");

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasColumnType("CHAR");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnType("nvarchar");

                entity.Property(e => e.RoleId).HasColumnType("TINYINT");

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasColumnType("VARCHAR(15)");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Person)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.RoleId);

                entity.HasIndex(e => e.RoleName)
                    .IsUnique();

                entity.Property(e => e.RoleId)
                    .HasColumnType("TINYINT")
                    .ValueGeneratedNever();

                entity.Property(e => e.RoleName).HasColumnType("VARCHAR(20)");
            });

            modelBuilder.Entity<StudentGrade>(entity =>
            {
                entity.HasKey(e => new { e.PersonId, e.CourseId });

                entity.Property(e => e.PersonId)
                    .HasColumnName("PersonID")
                    .HasColumnType("int");

                entity.Property(e => e.CourseId)
                    .HasColumnName("CourseID")
                    .HasColumnType("int");

                entity.Property(e => e.Grade).HasColumnType("decimal");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.StudentGrade)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.StudentGrade)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
