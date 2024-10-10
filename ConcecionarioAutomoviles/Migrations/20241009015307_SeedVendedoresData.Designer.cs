﻿// <auto-generated />
using System;
using ConcecionarioAutomoviles.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ConcecionarioAutomoviles.Migrations
{
    [DbContext(typeof(ConcecionarioContext))]
    [Migration("20241009015307_SeedVendedoresData")]
    partial class SeedVendedoresData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ConcecionarioAutomoviles.Models.AutomovilesStock", b =>
                {
                    b.Property<int>("NumeroBastidor")
                        .HasColumnType("int")
                        .HasColumnName("numeroBastidor");

                    b.Property<int?>("IdConcesionario")
                        .HasColumnType("int")
                        .HasColumnName("idConcesionario");

                    b.Property<int?>("IdModelo")
                        .HasColumnType("int")
                        .HasColumnName("idModelo");

                    b.HasKey("NumeroBastidor")
                        .HasName("PK__Automovi__21098CFB3F7D52EC");

                    b.HasIndex("IdConcesionario");

                    b.HasIndex("IdModelo");

                    b.ToTable("Automoviles_Stock", (string)null);
                });

            modelBuilder.Entity("ConcecionarioAutomoviles.Models.Concesionario", b =>
                {
                    b.Property<int>("IdConcesionario")
                        .HasColumnType("int")
                        .HasColumnName("idConcesionario");

                    b.Property<string>("DomicilioConcesionario")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("domicilioConcesionario");

                    b.Property<string>("Nif")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("NIF");

                    b.Property<string>("NombreConcesionario")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("nombreConcesionario");

                    b.HasKey("IdConcesionario")
                        .HasName("PK__Concesio__FC81165354A1C0E6");

                    b.ToTable("Concesionarios");
                });

            modelBuilder.Entity("ConcecionarioAutomoviles.Models.Extra", b =>
                {
                    b.Property<int>("IdExtra")
                        .HasColumnType("int")
                        .HasColumnName("idExtra");

                    b.Property<string>("NombreExtra")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("nombreExtra");

                    b.Property<decimal>("PrecioExtra")
                        .HasColumnType("decimal(8, 2)")
                        .HasColumnName("precioExtra");

                    b.HasKey("IdExtra")
                        .HasName("PK__Extras__E06E1F50F01F5A75");

                    b.ToTable("Extras");
                });

            modelBuilder.Entity("ConcecionarioAutomoviles.Models.ExtrasVenta", b =>
                {
                    b.Property<int?>("IdExtra")
                        .HasColumnType("int")
                        .HasColumnName("idExtra");

                    b.Property<int?>("IdVenta")
                        .HasColumnType("int")
                        .HasColumnName("idVenta");

                    b.Property<decimal>("PrecioExtra")
                        .HasColumnType("decimal(8, 2)")
                        .HasColumnName("precioExtra");

                    b.HasIndex("IdExtra");

                    b.HasIndex("IdVenta");

                    b.ToTable("Extras_Venta", (string)null);
                });

            modelBuilder.Entity("ConcecionarioAutomoviles.Models.Marca", b =>
                {
                    b.Property<int>("IdMarca")
                        .HasColumnType("int")
                        .HasColumnName("idMarca");

                    b.Property<string>("NombreMarca")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("nombreMarca");

                    b.HasKey("IdMarca")
                        .HasName("PK__Marcas__70331812B2A04BDB");

                    b.ToTable("Marcas");
                });

            modelBuilder.Entity("ConcecionarioAutomoviles.Models.Modelo", b =>
                {
                    b.Property<int>("IdModelo")
                        .HasColumnType("int")
                        .HasColumnName("idModelo");

                    b.Property<decimal?>("Cilindrada")
                        .HasColumnType("decimal(6, 2)")
                        .HasColumnName("cilindrada");

                    b.Property<decimal?>("Descuento")
                        .HasColumnType("decimal(5, 2)")
                        .HasColumnName("descuento");

                    b.Property<int?>("IdMarca")
                        .HasColumnType("int")
                        .HasColumnName("idMarca");

                    b.Property<string>("NombreModelo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("nombreModelo");

                    b.Property<int?>("PotenciaFiscal")
                        .HasColumnType("int")
                        .HasColumnName("potenciaFiscal");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("precio");

                    b.HasKey("IdModelo")
                        .HasName("PK__Modelos__13A52CD12B7D1175");

                    b.HasIndex("IdMarca");

                    b.ToTable("Modelos");
                });

            modelBuilder.Entity("ConcecionarioAutomoviles.Models.ServiciosOficiales", b =>
                {
                    b.Property<int>("IdServicioOficial")
                        .HasColumnType("int")
                        .HasColumnName("idServicioOficial");

                    b.Property<string>("DomicilioServicioOficial")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("domicilioServicioOficial");

                    b.Property<int?>("IdConcesionario")
                        .HasColumnType("int")
                        .HasColumnName("idConcesionario");

                    b.Property<string>("Nif")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("NIF");

                    b.Property<string>("NombreServicioOficial")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("nombreServicioOficial");

                    b.HasKey("IdServicioOficial")
                        .HasName("PK__Servicio__37EDAE8CE282B7D3");

                    b.HasIndex("IdConcesionario");

                    b.ToTable("Servicios_Oficiales", (string)null);
                });

            modelBuilder.Entity("ConcecionarioAutomoviles.Models.Vendedore", b =>
                {
                    b.Property<int>("IdVendedor")
                        .HasColumnType("int")
                        .HasColumnName("idVendedor");

                    b.Property<string>("DomicilioVendedor")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("domicilioVendedor");

                    b.Property<string>("Nif")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("NIF");

                    b.Property<string>("NombreVendedor")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("nombreVendedor");

                    b.HasKey("IdVendedor")
                        .HasName("PK__Vendedor__A6693F93DB822305");

                    b.ToTable("Vendedores");

                    b.HasData(
                        new
                        {
                            IdVendedor = 1,
                            DomicilioVendedor = "Calle Principal #123",
                            Nif = "001-1234567-8",
                            NombreVendedor = "Juan Pérez"
                        },
                        new
                        {
                            IdVendedor = 2,
                            DomicilioVendedor = "Avenida Central #456",
                            Nif = "002-2345678-9",
                            NombreVendedor = "María Gómez"
                        },
                        new
                        {
                            IdVendedor = 3,
                            DomicilioVendedor = "Calle Secundaria #789",
                            Nif = "003-3456789-0",
                            NombreVendedor = "Carlos Ramírez"
                        });
                });

            modelBuilder.Entity("ConcecionarioAutomoviles.Models.Venta", b =>
                {
                    b.Property<int>("IdVenta")
                        .HasColumnType("int")
                        .HasColumnName("idVenta");

                    b.Property<bool>("EsDeStock")
                        .HasColumnType("bit")
                        .HasColumnName("esDeStock");

                    b.Property<DateOnly>("FechaEntrega")
                        .HasColumnType("date")
                        .HasColumnName("fechaEntrega");

                    b.Property<int?>("IdAutomovil")
                        .HasColumnType("int")
                        .HasColumnName("idAutomovil");

                    b.Property<int?>("IdServicioOficial")
                        .HasColumnType("int")
                        .HasColumnName("idServicioOficial");

                    b.Property<int?>("IdVendedor")
                        .HasColumnType("int")
                        .HasColumnName("idVendedor");

                    b.Property<string>("Matricula")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("matricula");

                    b.Property<string>("ModoPago")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("modoPago");

                    b.Property<decimal>("PrecioVenta")
                        .HasColumnType("decimal(10, 2)")
                        .HasColumnName("precioVenta");

                    b.HasKey("IdVenta")
                        .HasName("PK__Ventas__077D5614991E0635");

                    b.HasIndex("IdAutomovil");

                    b.HasIndex("IdServicioOficial");

                    b.HasIndex("IdVendedor");

                    b.ToTable("Ventas");
                });

            modelBuilder.Entity("ModeloExtra", b =>
                {
                    b.Property<int>("IdModelo")
                        .HasColumnType("int")
                        .HasColumnName("idModelo");

                    b.Property<int>("IdExtra")
                        .HasColumnType("int")
                        .HasColumnName("idExtra");

                    b.HasKey("IdModelo", "IdExtra")
                        .HasName("PK__Modelo_E__0DA3CD24706C4FA9");

                    b.HasIndex("IdExtra");

                    b.ToTable("Modelo_Extras", (string)null);
                });

            modelBuilder.Entity("ConcecionarioAutomoviles.Models.AutomovilesStock", b =>
                {
                    b.HasOne("ConcecionarioAutomoviles.Models.Concesionario", "IdConcesionarioNavigation")
                        .WithMany("AutomovilesStocks")
                        .HasForeignKey("IdConcesionario")
                        .HasConstraintName("FK__Automovil__idCon__571DF1D5");

                    b.HasOne("ConcecionarioAutomoviles.Models.Modelo", "IdModeloNavigation")
                        .WithMany("AutomovilesStocks")
                        .HasForeignKey("IdModelo")
                        .HasConstraintName("FK__Automovil__idMod__5629CD9C");

                    b.Navigation("IdConcesionarioNavigation");

                    b.Navigation("IdModeloNavigation");
                });

            modelBuilder.Entity("ConcecionarioAutomoviles.Models.ExtrasVenta", b =>
                {
                    b.HasOne("ConcecionarioAutomoviles.Models.Extra", "IdExtraNavigation")
                        .WithMany()
                        .HasForeignKey("IdExtra")
                        .HasConstraintName("FK__Extras_Ve__idExt__6383C8BA");

                    b.HasOne("ConcecionarioAutomoviles.Models.Venta", "IdVentaNavigation")
                        .WithMany()
                        .HasForeignKey("IdVenta")
                        .HasConstraintName("FK__Extras_Ve__idVen__628FA481");

                    b.Navigation("IdExtraNavigation");

                    b.Navigation("IdVentaNavigation");
                });

            modelBuilder.Entity("ConcecionarioAutomoviles.Models.Modelo", b =>
                {
                    b.HasOne("ConcecionarioAutomoviles.Models.Marca", "IdMarcaNavigation")
                        .WithMany("Modelos")
                        .HasForeignKey("IdMarca")
                        .HasConstraintName("FK__Modelos__idMarca__4BAC3F29");

                    b.Navigation("IdMarcaNavigation");
                });

            modelBuilder.Entity("ConcecionarioAutomoviles.Models.ServiciosOficiales", b =>
                {
                    b.HasOne("ConcecionarioAutomoviles.Models.Concesionario", "IdConcesionarioNavigation")
                        .WithMany("ServiciosOficiales")
                        .HasForeignKey("IdConcesionario")
                        .HasConstraintName("FK__Servicios__idCon__59FA5E80");

                    b.Navigation("IdConcesionarioNavigation");
                });

            modelBuilder.Entity("ConcecionarioAutomoviles.Models.Venta", b =>
                {
                    b.HasOne("ConcecionarioAutomoviles.Models.AutomovilesStock", "IdAutomovilNavigation")
                        .WithMany("Venta")
                        .HasForeignKey("IdAutomovil")
                        .HasConstraintName("FK__Ventas__idAutomo__5EBF139D");

                    b.HasOne("ConcecionarioAutomoviles.Models.ServiciosOficiales", "IdServicioOficialNavigation")
                        .WithMany("Venta")
                        .HasForeignKey("IdServicioOficial")
                        .HasConstraintName("FK__Ventas__idServic__60A75C0F");

                    b.HasOne("ConcecionarioAutomoviles.Models.Vendedore", "IdVendedorNavigation")
                        .WithMany("Venta")
                        .HasForeignKey("IdVendedor")
                        .HasConstraintName("FK__Ventas__idVended__5FB337D6");

                    b.Navigation("IdAutomovilNavigation");

                    b.Navigation("IdServicioOficialNavigation");

                    b.Navigation("IdVendedorNavigation");
                });

            modelBuilder.Entity("ModeloExtra", b =>
                {
                    b.HasOne("ConcecionarioAutomoviles.Models.Extra", null)
                        .WithMany()
                        .HasForeignKey("IdExtra")
                        .IsRequired()
                        .HasConstraintName("FK__Modelo_Ex__idExt__5165187F");

                    b.HasOne("ConcecionarioAutomoviles.Models.Modelo", null)
                        .WithMany()
                        .HasForeignKey("IdModelo")
                        .IsRequired()
                        .HasConstraintName("FK__Modelo_Ex__idMod__5070F446");
                });

            modelBuilder.Entity("ConcecionarioAutomoviles.Models.AutomovilesStock", b =>
                {
                    b.Navigation("Venta");
                });

            modelBuilder.Entity("ConcecionarioAutomoviles.Models.Concesionario", b =>
                {
                    b.Navigation("AutomovilesStocks");

                    b.Navigation("ServiciosOficiales");
                });

            modelBuilder.Entity("ConcecionarioAutomoviles.Models.Marca", b =>
                {
                    b.Navigation("Modelos");
                });

            modelBuilder.Entity("ConcecionarioAutomoviles.Models.Modelo", b =>
                {
                    b.Navigation("AutomovilesStocks");
                });

            modelBuilder.Entity("ConcecionarioAutomoviles.Models.ServiciosOficiales", b =>
                {
                    b.Navigation("Venta");
                });

            modelBuilder.Entity("ConcecionarioAutomoviles.Models.Vendedore", b =>
                {
                    b.Navigation("Venta");
                });
#pragma warning restore 612, 618
        }
    }
}
