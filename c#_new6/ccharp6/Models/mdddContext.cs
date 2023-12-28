using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ccharp6.Models
{
    public partial class mdddContext : DbContext
    {
        public mdddContext()
        {
        }

        public mdddContext(DbContextOptions<mdddContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Colacion> Colacions { get; set; } = null!;
        public virtual DbSet<ColacionIngrediente> ColacionIngredientes { get; set; } = null!;
        public virtual DbSet<Comentario> Comentarios { get; set; } = null!;
        public virtual DbSet<DietaColacion> DietaColacions { get; set; } = null!;
        public virtual DbSet<IngredientesImagen> IngredientesImagens { get; set; } = null!;
        public virtual DbSet<Paciente> Pacientes { get; set; } = null!;
        public virtual DbSet<Profesional> Profesionals { get; set; } = null!;
        public virtual DbSet<SeguimientoCitum> SeguimientoCita { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;database=mddd;port=3306;user id=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.19-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Colacion>(entity =>
            {
                entity.ToTable("colacion");

                entity.HasIndex(e => e.DietaColacionId, "FK_dieta_colacion");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.DietaColacionId)
                    .HasColumnType("int(11)")
                    .HasColumnName("dieta_colacion_id");

                entity.Property(e => e.TipoComida)
                    .HasMaxLength(50)
                    .HasColumnName("tipo_comida");

                entity.HasOne(d => d.DietaColacion)
                    .WithMany(p => p.Colacions)
                    .HasForeignKey(d => d.DietaColacionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dieta_colacion");
            });

            modelBuilder.Entity<ColacionIngrediente>(entity =>
            {
                entity.ToTable("colacion_ingredientes");

                entity.HasIndex(e => e.IdColacion, "FK_colacion");

                entity.HasIndex(e => e.IdIngredientesImagen, "FK_ingredientes_imagen");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Cantidad)
                    .HasMaxLength(100)
                    .HasColumnName("cantidad");

                entity.Property(e => e.IdColacion)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_colacion");

                entity.Property(e => e.IdIngredientesImagen)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_ingredientes_imagen");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .HasColumnName("nombre");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(100)
                    .HasColumnName("tipo");

                entity.HasOne(d => d.IdColacionNavigation)
                    .WithMany(p => p.ColacionIngredientes)
                    .HasForeignKey(d => d.IdColacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_colacion");

                entity.HasOne(d => d.IdIngredientesImagenNavigation)
                    .WithMany(p => p.ColacionIngredientes)
                    .HasForeignKey(d => d.IdIngredientesImagen)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ingredientes_imagen");
            });

            modelBuilder.Entity<Comentario>(entity =>
            {
                entity.ToTable("comentario");

                entity.HasIndex(e => e.IdDietaColacion, "id_dieta_colacion");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(200)
                    .HasColumnName("descripcion");

                entity.Property(e => e.IdDietaColacion)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_dieta_colacion");

                entity.HasOne(d => d.IdDietaColacionNavigation)
                    .WithMany(p => p.Comentarios)
                    .HasForeignKey(d => d.IdDietaColacion)
                    .HasConstraintName("FK_id_dieta_colacion");
            });

            modelBuilder.Entity<DietaColacion>(entity =>
            {
                entity.ToTable("dieta_colacion");

                entity.HasIndex(e => e.PacienteId, "FK_paciente_id");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .HasColumnName("nombre");

                entity.Property(e => e.PacienteId)
                    .HasColumnType("int(100)")
                    .HasColumnName("paciente_id");

                entity.Property(e => e.TipoComida)
                    .HasMaxLength(50)
                    .HasColumnName("tipo_comida");

                entity.Property(e => e.TipoVegan)
                    .HasMaxLength(50)
                    .HasColumnName("tipo_vegan");

                entity.HasOne(d => d.Paciente)
                    .WithMany(p => p.DietaColacions)
                    .HasForeignKey(d => d.PacienteId)
                    .HasConstraintName("FK_paciente_id");
            });

            modelBuilder.Entity<IngredientesImagen>(entity =>
            {
                entity.ToTable("ingredientes_imagen");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.ImagenUrl)
                    .HasMaxLength(255)
                    .HasColumnName("imagen_url");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .HasColumnName("nombre");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(100)
                    .HasColumnName("tipo");
            });

            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.ToTable("paciente");

                entity.Property(e => e.Id)
                    .HasColumnType("int(12)")
                    .HasColumnName("id");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(100)
                    .HasColumnName("apellidos");

                entity.Property(e => e.Correo)
                    .HasMaxLength(100)
                    .HasColumnName("correo");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(200)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Edad)
                    .HasColumnType("int(11)")
                    .HasColumnName("edad");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.FechaNac)
                    .HasMaxLength(20)
                    .HasColumnName("fecha_nac");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .HasColumnName("nombre");

                entity.Property(e => e.Peso).HasColumnName("peso");

                entity.Property(e => e.Rut)
                    .HasMaxLength(100)
                    .HasColumnName("rut");

                entity.Property(e => e.Sexo)
                    .HasMaxLength(20)
                    .HasColumnName("sexo");

                entity.Property(e => e.Telefono)
                    .HasColumnType("int(11)")
                    .HasColumnName("telefono");
            });

            modelBuilder.Entity<Profesional>(entity =>
            {
                entity.ToTable("profesional");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Especialidad)
                    .HasMaxLength(100)
                    .HasColumnName("especialidad");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .HasColumnName("nombre");

                entity.Property(e => e.Rut)
                    .HasMaxLength(100)
                    .HasColumnName("rut");
            });

            modelBuilder.Entity<SeguimientoCitum>(entity =>
            {
                entity.ToTable("seguimiento_cita");

                entity.HasIndex(e => e.IdPaciente, "FK_paciente_seguimiento");

                entity.HasIndex(e => e.IdProfesional, "FK_profesional_seguimiento");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Estatura)
                    .HasMaxLength(30)
                    .HasColumnName("estatura");

                entity.Property(e => e.Fecha).HasColumnName("fecha");

                entity.Property(e => e.IdPaciente)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_paciente");

                entity.Property(e => e.IdProfesional)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_profesional");

                entity.Property(e => e.Observacion)
                    .HasMaxLength(200)
                    .HasColumnName("observacion");

                entity.Property(e => e.Peso)
                    .HasMaxLength(30)
                    .HasColumnName("peso");

                entity.HasOne(d => d.IdPacienteNavigation)
                    .WithMany(p => p.SeguimientoCita)
                    .HasForeignKey(d => d.IdPaciente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_paciente_seguimiento");

                entity.HasOne(d => d.IdProfesionalNavigation)
                    .WithMany(p => p.SeguimientoCita)
                    .HasForeignKey(d => d.IdProfesional)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_profesional_seguimiento");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
