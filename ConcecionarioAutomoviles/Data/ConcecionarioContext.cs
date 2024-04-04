using System;
using System.Collections.Generic;
using ConcecionarioAutomoviles.Models;
using Microsoft.EntityFrameworkCore;

namespace ConcecionarioAutomoviles.Data;

public partial class ConcecionarioContext : DbContext
{
    public ConcecionarioContext()
    {
    }

    public ConcecionarioContext(DbContextOptions<ConcecionarioContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AutomovilesStock> AutomovilesStocks { get; set; }

    public virtual DbSet<Concesionario> Concesionarios { get; set; }

    public virtual DbSet<Extra> Extras { get; set; }

    public virtual DbSet<ExtrasVenta> ExtrasVenta { get; set; }

    public virtual DbSet<Marca> Marcas { get; set; }

    public virtual DbSet<Modelo> Modelos { get; set; }

    public virtual DbSet<ServiciosOficiales> ServiciosOficiales { get; set; }

    public virtual DbSet<Vendedore> Vendedores { get; set; }

    public virtual DbSet<Venta> Ventas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-1BFPKHS\\SQLEXPRESS;Database=Concecionario;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AutomovilesStock>(entity =>
        {
            entity.HasKey(e => e.NumeroBastidor).HasName("PK__Automovi__21098CFB3F7D52EC");

            entity.ToTable("Automoviles_Stock");

            entity.Property(e => e.NumeroBastidor)
                .ValueGeneratedNever()
                .HasColumnName("numeroBastidor");
            entity.Property(e => e.IdConcesionario).HasColumnName("idConcesionario");
            entity.Property(e => e.IdModelo).HasColumnName("idModelo");

            entity.HasOne(d => d.IdConcesionarioNavigation).WithMany(p => p.AutomovilesStocks)
                .HasForeignKey(d => d.IdConcesionario)
                .HasConstraintName("FK__Automovil__idCon__571DF1D5");

            entity.HasOne(d => d.IdModeloNavigation).WithMany(p => p.AutomovilesStocks)
                .HasForeignKey(d => d.IdModelo)
                .HasConstraintName("FK__Automovil__idMod__5629CD9C");
        });

        modelBuilder.Entity<Concesionario>(entity =>
        {
            entity.HasKey(e => e.IdConcesionario).HasName("PK__Concesio__FC81165354A1C0E6");

            entity.Property(e => e.IdConcesionario)
                .ValueGeneratedNever()
                .HasColumnName("idConcesionario");
            entity.Property(e => e.DomicilioConcesionario)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("domicilioConcesionario");
            entity.Property(e => e.Nif)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("NIF");
            entity.Property(e => e.NombreConcesionario)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombreConcesionario");
        });

        modelBuilder.Entity<Extra>(entity =>
        {
            entity.HasKey(e => e.IdExtra).HasName("PK__Extras__E06E1F50F01F5A75");

            entity.Property(e => e.IdExtra)
                .ValueGeneratedNever()
                .HasColumnName("idExtra");
            entity.Property(e => e.NombreExtra)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombreExtra");
            entity.Property(e => e.PrecioExtra)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("precioExtra");
        });

        modelBuilder.Entity<ExtrasVenta>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Extras_Venta");

            entity.Property(e => e.IdExtra).HasColumnName("idExtra");
            entity.Property(e => e.IdVenta).HasColumnName("idVenta");
            entity.Property(e => e.PrecioExtra)
                .HasColumnType("decimal(8, 2)")
                .HasColumnName("precioExtra");

            entity.HasOne(d => d.IdExtraNavigation).WithMany()
                .HasForeignKey(d => d.IdExtra)
                .HasConstraintName("FK__Extras_Ve__idExt__6383C8BA");

            entity.HasOne(d => d.IdVentaNavigation).WithMany()
                .HasForeignKey(d => d.IdVenta)
                .HasConstraintName("FK__Extras_Ve__idVen__628FA481");
        });

        modelBuilder.Entity<Marca>(entity =>
        {
            entity.HasKey(e => e.IdMarca).HasName("PK__Marcas__70331812B2A04BDB");

            entity.Property(e => e.IdMarca)
                .ValueGeneratedNever()
                .HasColumnName("idMarca");
            entity.Property(e => e.NombreMarca)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombreMarca");
        });

        modelBuilder.Entity<Modelo>(entity =>
        {
            entity.HasKey(e => e.IdModelo).HasName("PK__Modelos__13A52CD12B7D1175");

            entity.Property(e => e.IdModelo)
                .ValueGeneratedNever()
                .HasColumnName("idModelo");
            entity.Property(e => e.Cilindrada)
                .HasColumnType("decimal(6, 2)")
                .HasColumnName("cilindrada");
            entity.Property(e => e.Descuento)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("descuento");
            entity.Property(e => e.IdMarca).HasColumnName("idMarca");
            entity.Property(e => e.NombreModelo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombreModelo");
            entity.Property(e => e.PotenciaFiscal).HasColumnName("potenciaFiscal");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precio");

            entity.HasOne(d => d.IdMarcaNavigation).WithMany(p => p.Modelos)
                .HasForeignKey(d => d.IdMarca)
                .HasConstraintName("FK__Modelos__idMarca__4BAC3F29");

            entity.HasMany(d => d.IdExtras).WithMany(p => p.IdModelos)
                .UsingEntity<Dictionary<string, object>>(
                    "ModeloExtra",
                    r => r.HasOne<Extra>().WithMany()
                        .HasForeignKey("IdExtra")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Modelo_Ex__idExt__5165187F"),
                    l => l.HasOne<Modelo>().WithMany()
                        .HasForeignKey("IdModelo")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Modelo_Ex__idMod__5070F446"),
                    j =>
                    {
                        j.HasKey("IdModelo", "IdExtra").HasName("PK__Modelo_E__0DA3CD24706C4FA9");
                        j.ToTable("Modelo_Extras");
                        j.IndexerProperty<int>("IdModelo").HasColumnName("idModelo");
                        j.IndexerProperty<int>("IdExtra").HasColumnName("idExtra");
                    });
        });

        modelBuilder.Entity<ServiciosOficiales>(entity =>
        {
            entity.HasKey(e => e.IdServicioOficial).HasName("PK__Servicio__37EDAE8CE282B7D3");

            entity.ToTable("Servicios_Oficiales");

            entity.Property(e => e.IdServicioOficial)
                .ValueGeneratedNever()
                .HasColumnName("idServicioOficial");
            entity.Property(e => e.DomicilioServicioOficial)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("domicilioServicioOficial");
            entity.Property(e => e.IdConcesionario).HasColumnName("idConcesionario");
            entity.Property(e => e.Nif)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("NIF");
            entity.Property(e => e.NombreServicioOficial)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombreServicioOficial");

            entity.HasOne(d => d.IdConcesionarioNavigation).WithMany(p => p.ServiciosOficiales)
                .HasForeignKey(d => d.IdConcesionario)
                .HasConstraintName("FK__Servicios__idCon__59FA5E80");
        });

        modelBuilder.Entity<Vendedore>(entity =>
        {
            entity.HasKey(e => e.IdVendedor).HasName("PK__Vendedor__A6693F93DB822305");

            entity.Property(e => e.IdVendedor)
                .ValueGeneratedNever()
                .HasColumnName("idVendedor");
            entity.Property(e => e.DomicilioVendedor)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("domicilioVendedor");
            entity.Property(e => e.Nif)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("NIF");
            entity.Property(e => e.NombreVendedor)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombreVendedor");
        });

        modelBuilder.Entity<Venta>(entity =>
        {
            entity.HasKey(e => e.IdVenta).HasName("PK__Ventas__077D5614991E0635");

            entity.Property(e => e.IdVenta)
                .ValueGeneratedNever()
                .HasColumnName("idVenta");
            entity.Property(e => e.EsDeStock).HasColumnName("esDeStock");
            entity.Property(e => e.FechaEntrega).HasColumnName("fechaEntrega");
            entity.Property(e => e.IdAutomovil).HasColumnName("idAutomovil");
            entity.Property(e => e.IdServicioOficial).HasColumnName("idServicioOficial");
            entity.Property(e => e.IdVendedor).HasColumnName("idVendedor");
            entity.Property(e => e.Matricula)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("matricula");
            entity.Property(e => e.ModoPago)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("modoPago");
            entity.Property(e => e.PrecioVenta)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precioVenta");

            entity.HasOne(d => d.IdAutomovilNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdAutomovil)
                .HasConstraintName("FK__Ventas__idAutomo__5EBF139D");

            entity.HasOne(d => d.IdServicioOficialNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdServicioOficial)
                .HasConstraintName("FK__Ventas__idServic__60A75C0F");

            entity.HasOne(d => d.IdVendedorNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdVendedor)
                .HasConstraintName("FK__Ventas__idVended__5FB337D6");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
