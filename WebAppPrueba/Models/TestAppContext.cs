using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebAppPrueba.Models;

public partial class TestAppContext : DbContext
{
    public TestAppContext()
    {
    }

    public TestAppContext(DbContextOptions<TestAppContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Operario> Operarios { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-CJQAJ2C;Database=TestApp;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.ToTable("Client");

            entity.HasIndex(e => e.IdClient, "IX_Client").IsUnique();

            entity.Property(e => e.Apellidos)
                .HasMaxLength(75)
                .IsUnicode(false);
            entity.Property(e => e.Departamento)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaIngreso).HasColumnType("datetime");
            entity.Property(e => e.IdClient)
                .HasMaxLength(75)
                .IsUnicode(false)
                .HasColumnName("idClient");
            entity.Property(e => e.Nombres)
                .HasMaxLength(75)
                .IsUnicode(false);
            entity.Property(e => e.Pais)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Operario>(entity =>
        {
            entity.ToTable("Operario");

            entity.HasIndex(e => e.IdOperario, "IX_Operario").IsUnique();

            entity.Property(e => e.Apellidos)
                .HasMaxLength(75)
                .IsUnicode(false);
            entity.Property(e => e.Departamento)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaIngreso).HasColumnType("datetime");
            entity.Property(e => e.IdOperario)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("idOperario");
            entity.Property(e => e.Nombres)
                .HasMaxLength(75)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Incidencias");

            entity.ToTable("Ticket");

            entity.HasIndex(e => e.IdClient, "IX_Incidencias");

            entity.Property(e => e.FechaIngreso).HasColumnType("datetime");
            entity.Property(e => e.IdClient)
                .HasMaxLength(75)
                .IsUnicode(false)
                .HasColumnName("idClient");
            entity.Property(e => e.Incidencia)
                .IsUnicode(false)
                .HasColumnName("incidencia");
            entity.Property(e => e.Operador)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
