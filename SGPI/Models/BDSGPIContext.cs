using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SGPI.Models
{
    public partial class BDSGPIContext : DbContext
    {
        public BDSGPIContext()
        {
        }

        public BDSGPIContext(DbContextOptions<BDSGPIContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Asignatura> Asignaturas { get; set; } = null!;
        public virtual DbSet<Documento> Documentos { get; set; } = null!;
        public virtual DbSet<Entrevistum> Entrevista { get; set; } = null!;
        public virtual DbSet<Estudiante> Estudiantes { get; set; } = null!;
        public virtual DbSet<Genero> Generos { get; set; } = null!;
        public virtual DbSet<Homologacion> Homologacions { get; set; } = null!;
        public virtual DbSet<Pago> Pagos { get; set; } = null!;
        public virtual DbSet<Programa> Programas { get; set; } = null!;
        public virtual DbSet<Programacion> Programacions { get; set; } = null!;
        public virtual DbSet<Rol> Rols { get; set; } = null!;
        public virtual DbSet<TipoHomologacion> TipoHomologacions { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-ALCT8CCU\\SQLEXPRESS;Database=BDSGPI;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Asignatura>(entity =>
            {
                entity.HasKey(e => e.Idasignatura)
                    .HasName("PK__Asignatu__2E8CCF351AAB7D4F");

                entity.ToTable("Asignatura");

                entity.Property(e => e.Idasignatura).HasColumnName("IDAsignatura");

                entity.Property(e => e.Codigo)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Idprograma).HasColumnName("IDPrograma");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdprogramaNavigation)
                    .WithMany(p => p.Asignaturas)
                    .HasForeignKey(d => d.Idprograma)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Asignatur__IDPro__49C3F6B7");
            });

            modelBuilder.Entity<Documento>(entity =>
            {
                entity.HasKey(e => e.Iddoc)
                    .HasName("PK__Document__93E3A42C7A133EE9");

                entity.ToTable("Documento");

                entity.Property(e => e.Iddoc)
                    .ValueGeneratedNever()
                    .HasColumnName("IDDoc");

                entity.Property(e => e.TipoDocumento)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Entrevistum>(entity =>
            {
                entity.HasKey(e => e.Identrevista)
                    .HasName("PK__Entrevis__05824BE94AB4497D");

                entity.Property(e => e.Identrevista)
                    .ValueGeneratedNever()
                    .HasColumnName("IDEntrevista");

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.Idestudiante).HasColumnName("IDEstudiante");

                entity.Property(e => e.Idusuario).HasColumnName("IDUsuario");
            });

            modelBuilder.Entity<Estudiante>(entity =>
            {
                entity.HasKey(e => e.Idestudiante)
                    .HasName("PK__Estudian__908672BBF563E851");

                entity.ToTable("Estudiante");

                entity.Property(e => e.Idestudiante)
                    .ValueGeneratedNever()
                    .HasColumnName("IDEstudiante");

                entity.Property(e => e.Archivo)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("archivo");

                entity.Property(e => e.Idpago).HasColumnName("IDPago");

                entity.Property(e => e.Idusuario).HasColumnName("IDUsuario");
            });

            modelBuilder.Entity<Genero>(entity =>
            {
                entity.HasKey(e => e.IdGenero)
                    .HasName("PK__Genero__0F834988FC0BDC8E");

                entity.ToTable("Genero");

                entity.Property(e => e.IdGenero).ValueGeneratedNever();

                entity.Property(e => e.Genero1)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Genero");
            });

            modelBuilder.Entity<Homologacion>(entity =>
            {
                entity.HasKey(e => e.Idhomologacion)
                    .HasName("PK__Homologa__01DC9432C93021C7");

                entity.ToTable("Homologacion");

                entity.Property(e => e.Idhomologacion).HasColumnName("IDHomologacion");

                entity.Property(e => e.CodigoHomologacion)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Idasignatura).HasColumnName("IDAsignatura");

                entity.Property(e => e.Idestudiante).HasColumnName("IDEstudiante");

                entity.Property(e => e.Idprograma).HasColumnName("IDPrograma");

                entity.Property(e => e.IdtipoHomologacion).HasColumnName("IDTipoHomologacion");

                entity.Property(e => e.NomAsignHomologacion)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PeriodoAcademico)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdasignaturaNavigation)
                    .WithMany(p => p.Homologacions)
                    .HasForeignKey(d => d.Idasignatura)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Homologac__IDAsi__5535A963");

                entity.HasOne(d => d.IdestudianteNavigation)
                    .WithMany(p => p.Homologacions)
                    .HasForeignKey(d => d.Idestudiante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Homologac__IDEst__52593CB8");

                entity.HasOne(d => d.IdprogramaNavigation)
                    .WithMany(p => p.Homologacions)
                    .HasForeignKey(d => d.Idprograma)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Homologac__IDPro__534D60F1");

                entity.HasOne(d => d.IdtipoHomologacionNavigation)
                    .WithMany(p => p.Homologacions)
                    .HasForeignKey(d => d.IdtipoHomologacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Homologac__IDTip__5441852A");
            });

            modelBuilder.Entity<Pago>(entity =>
            {
                entity.HasKey(e => e.Idpago)
                    .HasName("PK__Pagos__8A5C3DEE9725C3A5");

                entity.Property(e => e.Idpago).HasColumnName("IDPago");

                entity.Property(e => e.Fecha).HasColumnType("date");
            });

            modelBuilder.Entity<Programa>(entity =>
            {
                entity.HasKey(e => e.Idprograma)
                    .HasName("PK__Programa__072DB426FAC275D0");

                entity.ToTable("Programa");

                entity.Property(e => e.Idprograma)
                    .ValueGeneratedNever()
                    .HasColumnName("IDPrograma");

                entity.Property(e => e.Programa1)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Programa");
            });

            modelBuilder.Entity<Programacion>(entity =>
            {
                entity.HasKey(e => e.Idprogramacion)
                    .HasName("PK__Programa__E8038DE4F42A2CF3");

                entity.ToTable("Programacion");

                entity.Property(e => e.Idprogramacion).HasColumnName("IDProgramacion");

                entity.Property(e => e.FechaProgramacion).HasColumnType("datetime");

                entity.Property(e => e.Idasignatura).HasColumnName("IDAsignatura");

                entity.Property(e => e.Idprograma).HasColumnName("IDPrograma");

                entity.Property(e => e.Idusuario).HasColumnName("IDUsuario");

                entity.Property(e => e.PeriodoAcademico)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Sala)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdasignaturaNavigation)
                    .WithMany(p => p.Programacions)
                    .HasForeignKey(d => d.Idasignatura)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Programac__IDAsi__571DF1D5");

                entity.HasOne(d => d.IdprogramaNavigation)
                    .WithMany(p => p.Programacions)
                    .HasForeignKey(d => d.Idprograma)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Programac__IDPro__5629CD9C");

                entity.HasOne(d => d.IdusuarioNavigation)
                    .WithMany(p => p.Programacions)
                    .HasForeignKey(d => d.Idusuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Programac__IDUsu__5812160E");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(e => e.IdRol)
                    .HasName("PK__Rol__2A49584CB9C4F651");

                entity.ToTable("Rol");

                entity.Property(e => e.Rol1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Rol");
            });

            modelBuilder.Entity<TipoHomologacion>(entity =>
            {
                entity.HasKey(e => e.IdtipoHomologacion)
                    .HasName("PK__TipoHomo__ECF4DCC35553C051");

                entity.ToTable("TipoHomologacion");

                entity.Property(e => e.IdtipoHomologacion).HasColumnName("IDTipoHomologacion");

                entity.Property(e => e.TipoHomologacion1)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TipoHomologacion");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Idusuario)
                    .HasName("PK__Usuario__5231116954C7EEBF");

                entity.ToTable("Usuario");

                entity.Property(e => e.Idusuario)
                    .ValueGeneratedNever()
                    .HasColumnName("IDUsuario");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Iddoc).HasColumnName("IDDoc");

                entity.Property(e => e.Idgenero).HasColumnName("IDGenero");

                entity.Property(e => e.Idprograma).HasColumnName("IDPrograma");

                entity.Property(e => e.Idrol).HasColumnName("IDRol");

                entity.Property(e => e.NumeroDocumento)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsFixedLength();

                entity.Property(e => e.PrimerApellido)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PrimerNombre)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SegundoApellido)
                    .HasMaxLength(255)
                    .IsUnicode(false);


                entity.HasOne(d => d.IddocNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.Iddoc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_Documento");

                entity.HasOne(d => d.IdgeneroNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.Idgenero)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_Genero");

                entity.HasOne(d => d.IdprogramaNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.Idprograma)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_Programa");

                entity.HasOne(d => d.IdrolNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.Idrol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuario_Rol");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
