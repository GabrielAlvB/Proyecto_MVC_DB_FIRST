using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Proyecto_MVC_DB_FIRST.Models
{
    public partial class db_escuelaContext : DbContext
    {
        public db_escuelaContext()
        {
        }

        public db_escuelaContext(DbContextOptions<db_escuelaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AlumnoCurso> AlumnoCurso { get; set; }
        public virtual DbSet<Alumnos> Alumnos { get; set; }
        public virtual DbSet<Cursos> Cursos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("server=192.168.10.89\\TEST04; user=sa; password=}w6)hKWezp-A; database=db_escuela; integrated security=false;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlumnoCurso>(entity =>
            {
                entity.ToTable("Alumno_Curso");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdAlumno).HasColumnName("id_Alumno");

                entity.Property(e => e.IdCurso).HasColumnName("id_Curso");

                entity.HasOne(d => d.IdAlumnoNavigation)
                    .WithMany(p => p.AlumnoCurso)
                    .HasForeignKey(d => d.IdAlumno)
                    .HasConstraintName("FK__Alumno_Cu__id_Al__3A81B327");

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.AlumnoCurso)
                    .HasForeignKey(d => d.IdCurso)
                    .HasConstraintName("FK__Alumno_Cu__id_Cu__3B75D760");
            });

            modelBuilder.Entity<Alumnos>(entity =>
            {
                entity.HasKey(e => e.IdAlumno)
                    .HasName("PK__Alumnos__6D77A7F101A61516");

                entity.Property(e => e.IdAlumno).HasColumnName("id_alumno");

                entity.Property(e => e.Edad).HasColumnName("edad");

                entity.Property(e => e.Grado).HasColumnName("grado");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Cursos>(entity =>
            {
                entity.HasKey(e => e.IdCurso)
                    .HasName("PK__Cursos__5D3F75022B19BD1B");

                entity.Property(e => e.IdCurso).HasColumnName("id_curso");

                entity.Property(e => e.Disponible).HasColumnName("disponible");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
