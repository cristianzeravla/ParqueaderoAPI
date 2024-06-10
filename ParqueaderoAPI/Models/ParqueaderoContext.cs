using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ParqueaderoAPI.Models;

public partial class ParqueaderoContext : DbContext
{
    public ParqueaderoContext()
    {
    }

    public ParqueaderoContext(DbContextOptions<ParqueaderoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cierre> Cierres { get; set; }

    public virtual DbSet<Factura> Facturas { get; set; }

    public virtual DbSet<Ingreso> Ingresos { get; set; }

    public virtual DbSet<Inicio> Inicios { get; set; }

    public virtual DbSet<Salida> Salidas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { 
/*warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=parqueadero;user=root;password=admin", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.30-mysql"));*/
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Cierre>(entity =>
        {
            entity.HasKey(e => e.IdCierre).HasName("PRIMARY");

            entity.ToTable("cierres");

            entity.HasIndex(e => e.IdInicio, "id_inicio");

            entity.Property(e => e.IdCierre).HasColumnName("id_cierre");
            entity.Property(e => e.FechaCierre)
                .HasColumnType("datetime")
                .HasColumnName("fecha_cierre");
            entity.Property(e => e.IdInicio).HasColumnName("id_inicio");
            entity.Property(e => e.TotalFacturas).HasColumnName("total_facturas");

            entity.HasOne(d => d.IdInicioNavigation).WithMany(p => p.Cierres)
                .HasForeignKey(d => d.IdInicio)
                .HasConstraintName("cierres_ibfk_1");
        });

        modelBuilder.Entity<Factura>(entity =>
        {
            entity.HasKey(e => e.IdFactura).HasName("PRIMARY");

            entity.ToTable("facturas");

            entity.HasIndex(e => e.IdIngreso, "id_ingreso");

            entity.Property(e => e.IdFactura).HasColumnName("id_factura");
            entity.Property(e => e.FechaFactura)
                .HasColumnType("datetime")
                .HasColumnName("fecha_factura");
            entity.Property(e => e.IdIngreso).HasColumnName("id_ingreso");
            entity.Property(e => e.ValorFactura).HasColumnName("valor_factura");

            entity.HasOne(d => d.IdIngresoNavigation).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.IdIngreso)
                .HasConstraintName("facturas_ibfk_1");
        });

        modelBuilder.Entity<Ingreso>(entity =>
        {
            entity.HasKey(e => e.IdIngreso).HasName("PRIMARY");

            entity.ToTable("ingresos");

            entity.HasIndex(e => e.IdInicio, "id_inicio");

            entity.Property(e => e.IdIngreso).HasColumnName("id_ingreso");
            entity.Property(e => e.FechaIngreso)
                .HasColumnType("datetime")
                .HasColumnName("fecha_ingreso");
            entity.Property(e => e.IdInicio).HasColumnName("id_inicio");
            entity.Property(e => e.Placa)
                .HasMaxLength(5)
                .HasColumnName("placa");

            entity.HasOne(d => d.IdInicioNavigation).WithMany(p => p.Ingresos)
                .HasForeignKey(d => d.IdInicio)
                .HasConstraintName("ingresos_ibfk_1");
        });

        modelBuilder.Entity<Inicio>(entity =>
        {
            entity.HasKey(e => e.IdInicio).HasName("PRIMARY");

            entity.ToTable("inicio");

            entity.Property(e => e.IdInicio).HasColumnName("id_inicio");
            entity.Property(e => e.FechaInicio)
                .HasColumnType("datetime")
                .HasColumnName("fecha_inicio");
        });

        modelBuilder.Entity<Salida>(entity =>
        {
            entity.HasKey(e => e.IdSalida).HasName("PRIMARY");

            entity.ToTable("salidas");

            entity.HasIndex(e => e.IdFactura, "id_factura");

            entity.Property(e => e.IdSalida).HasColumnName("id_salida");
            entity.Property(e => e.FechaSalida)
                .HasColumnType("datetime")
                .HasColumnName("fecha_salida");
            entity.Property(e => e.IdFactura).HasColumnName("id_factura");

            entity.HasOne(d => d.IdFacturaNavigation).WithMany(p => p.Salida)
                .HasForeignKey(d => d.IdFactura)
                .HasConstraintName("salidas_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
