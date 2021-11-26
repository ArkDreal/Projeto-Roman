using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using roman_webapi.Domains;

namespace roman_webapi.Contexts
{
    public partial class RomanContext : DbContext
    {
        public RomanContext()
        {
        }

        public RomanContext(DbContextOptions<RomanContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Professor> Professors { get; set; } = null!;
        public virtual DbSet<Projeto> Projetos { get; set; } = null!;
        public virtual DbSet<Tema> Temas { get; set; } = null!;
        public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=tcp:roman-tarde.database.windows.net,1433;Initial Catalog=roman_tarde;Persist Security Info=False;User ID=senai-tarde;Password=Roman@132;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Professor>(entity =>
            {
                entity.HasKey(e => e.IdProfessor)
                    .HasName("PK__professo__4E7C3C6D9B66F69D");

                entity.ToTable("professor");

                entity.HasIndex(e => e.Cpf, "UQ__professo__D836E71FF5A7EECD")
                    .IsUnique();

                entity.Property(e => e.IdProfessor).HasColumnName("idProfessor");

                entity.Property(e => e.Cpf)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("cpf");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Nome)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("nome");

                entity.Property(e => e.Sobrenome)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("sobrenome");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Professors)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__professor__idUsu__778AC167");
            });

            modelBuilder.Entity<Projeto>(entity =>
            {
                entity.HasKey(e => e.IdProjeto)
                    .HasName("PK__projeto__8FCCED76AC79A3C1");

                entity.ToTable("projeto");

                entity.Property(e => e.IdProjeto).HasColumnName("idProjeto");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(512)
                    .IsUnicode(false)
                    .HasColumnName("descricao");

                entity.Property(e => e.IdTema).HasColumnName("idTema");

                entity.Property(e => e.Titulo)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("titulo");

                entity.HasOne(d => d.IdTemaNavigation)
                    .WithMany(p => p.Projetos)
                    .HasForeignKey(d => d.IdTema)
                    .HasConstraintName("FK__projeto__idTema__7D439ABD");
            });

            modelBuilder.Entity<Tema>(entity =>
            {
                entity.HasKey(e => e.IdTema)
                    .HasName("PK__tema__BCD9EB48408A4CD2");

                entity.ToTable("tema");

                entity.HasIndex(e => e.NomeTema, "UQ__tema__59ABCB130112483D")
                    .IsUnique();

                entity.Property(e => e.IdTema).HasColumnName("idTema");

                entity.Property(e => e.NomeTema)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("nomeTema");
            });

            modelBuilder.Entity<TipoUsuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__tipoUsua__03006BFF18E4D692");

                entity.ToTable("tipoUsuario");

                entity.HasIndex(e => e.NomeTipo, "UQ__tipoUsua__46BB8260FEE992A2")
                    .IsUnique();

                entity.Property(e => e.IdTipoUsuario)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idTipoUsuario");

                entity.Property(e => e.NomeTipo)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("nomeTipo");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__usuario__645723A6B06050E6");

                entity.ToTable("usuario");

                entity.HasIndex(e => e.Email, "UQ__usuario__AB6E616401046373")
                    .IsUnique();

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Email)
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.Senha)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("senha");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__usuario__idTipoU__73BA3083");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
