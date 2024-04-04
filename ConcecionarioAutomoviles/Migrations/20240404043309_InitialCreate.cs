using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConcecionarioAutomoviles.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Concesionarios",
                columns: table => new
                {
                    idConcesionario = table.Column<int>(type: "int", nullable: false),
                    nombreConcesionario = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    domicilioConcesionario = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    NIF = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Concesio__FC81165354A1C0E6", x => x.idConcesionario);
                });

            migrationBuilder.CreateTable(
                name: "Extras",
                columns: table => new
                {
                    idExtra = table.Column<int>(type: "int", nullable: false),
                    nombreExtra = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    precioExtra = table.Column<decimal>(type: "decimal(8,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Extras__E06E1F50F01F5A75", x => x.idExtra);
                });

            migrationBuilder.CreateTable(
                name: "Marcas",
                columns: table => new
                {
                    idMarca = table.Column<int>(type: "int", nullable: false),
                    nombreMarca = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Marcas__70331812B2A04BDB", x => x.idMarca);
                });

            migrationBuilder.CreateTable(
                name: "Vendedores",
                columns: table => new
                {
                    idVendedor = table.Column<int>(type: "int", nullable: false),
                    nombreVendedor = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    NIF = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    domicilioVendedor = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Vendedor__A6693F93DB822305", x => x.idVendedor);
                });

            migrationBuilder.CreateTable(
                name: "Servicios_Oficiales",
                columns: table => new
                {
                    idServicioOficial = table.Column<int>(type: "int", nullable: false),
                    nombreServicioOficial = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    domicilioServicioOficial = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    NIF = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    idConcesionario = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Servicio__37EDAE8CE282B7D3", x => x.idServicioOficial);
                    table.ForeignKey(
                        name: "FK__Servicios__idCon__59FA5E80",
                        column: x => x.idConcesionario,
                        principalTable: "Concesionarios",
                        principalColumn: "idConcesionario");
                });

            migrationBuilder.CreateTable(
                name: "Modelos",
                columns: table => new
                {
                    idModelo = table.Column<int>(type: "int", nullable: false),
                    idMarca = table.Column<int>(type: "int", nullable: true),
                    nombreModelo = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    precio = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    descuento = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    potenciaFiscal = table.Column<int>(type: "int", nullable: true),
                    cilindrada = table.Column<decimal>(type: "decimal(6,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Modelos__13A52CD12B7D1175", x => x.idModelo);
                    table.ForeignKey(
                        name: "FK__Modelos__idMarca__4BAC3F29",
                        column: x => x.idMarca,
                        principalTable: "Marcas",
                        principalColumn: "idMarca");
                });

            migrationBuilder.CreateTable(
                name: "Automoviles_Stock",
                columns: table => new
                {
                    numeroBastidor = table.Column<int>(type: "int", nullable: false),
                    idModelo = table.Column<int>(type: "int", nullable: true),
                    idConcesionario = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Automovi__21098CFB3F7D52EC", x => x.numeroBastidor);
                    table.ForeignKey(
                        name: "FK__Automovil__idCon__571DF1D5",
                        column: x => x.idConcesionario,
                        principalTable: "Concesionarios",
                        principalColumn: "idConcesionario");
                    table.ForeignKey(
                        name: "FK__Automovil__idMod__5629CD9C",
                        column: x => x.idModelo,
                        principalTable: "Modelos",
                        principalColumn: "idModelo");
                });

            migrationBuilder.CreateTable(
                name: "Modelo_Extras",
                columns: table => new
                {
                    idModelo = table.Column<int>(type: "int", nullable: false),
                    idExtra = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Modelo_E__0DA3CD24706C4FA9", x => new { x.idModelo, x.idExtra });
                    table.ForeignKey(
                        name: "FK__Modelo_Ex__idExt__5165187F",
                        column: x => x.idExtra,
                        principalTable: "Extras",
                        principalColumn: "idExtra");
                    table.ForeignKey(
                        name: "FK__Modelo_Ex__idMod__5070F446",
                        column: x => x.idModelo,
                        principalTable: "Modelos",
                        principalColumn: "idModelo");
                });

            migrationBuilder.CreateTable(
                name: "Ventas",
                columns: table => new
                {
                    idVenta = table.Column<int>(type: "int", nullable: false),
                    idAutomovil = table.Column<int>(type: "int", nullable: true),
                    idVendedor = table.Column<int>(type: "int", nullable: true),
                    idServicioOficial = table.Column<int>(type: "int", nullable: true),
                    precioVenta = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    modoPago = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    fechaEntrega = table.Column<DateOnly>(type: "date", nullable: false),
                    matricula = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    esDeStock = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Ventas__077D5614991E0635", x => x.idVenta);
                    table.ForeignKey(
                        name: "FK__Ventas__idAutomo__5EBF139D",
                        column: x => x.idAutomovil,
                        principalTable: "Automoviles_Stock",
                        principalColumn: "numeroBastidor");
                    table.ForeignKey(
                        name: "FK__Ventas__idServic__60A75C0F",
                        column: x => x.idServicioOficial,
                        principalTable: "Servicios_Oficiales",
                        principalColumn: "idServicioOficial");
                    table.ForeignKey(
                        name: "FK__Ventas__idVended__5FB337D6",
                        column: x => x.idVendedor,
                        principalTable: "Vendedores",
                        principalColumn: "idVendedor");
                });

            migrationBuilder.CreateTable(
                name: "Extras_Venta",
                columns: table => new
                {
                    idVenta = table.Column<int>(type: "int", nullable: true),
                    idExtra = table.Column<int>(type: "int", nullable: true),
                    precioExtra = table.Column<decimal>(type: "decimal(8,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK__Extras_Ve__idExt__6383C8BA",
                        column: x => x.idExtra,
                        principalTable: "Extras",
                        principalColumn: "idExtra");
                    table.ForeignKey(
                        name: "FK__Extras_Ve__idVen__628FA481",
                        column: x => x.idVenta,
                        principalTable: "Ventas",
                        principalColumn: "idVenta");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Automoviles_Stock_idConcesionario",
                table: "Automoviles_Stock",
                column: "idConcesionario");

            migrationBuilder.CreateIndex(
                name: "IX_Automoviles_Stock_idModelo",
                table: "Automoviles_Stock",
                column: "idModelo");

            migrationBuilder.CreateIndex(
                name: "IX_Extras_Venta_idExtra",
                table: "Extras_Venta",
                column: "idExtra");

            migrationBuilder.CreateIndex(
                name: "IX_Extras_Venta_idVenta",
                table: "Extras_Venta",
                column: "idVenta");

            migrationBuilder.CreateIndex(
                name: "IX_Modelo_Extras_idExtra",
                table: "Modelo_Extras",
                column: "idExtra");

            migrationBuilder.CreateIndex(
                name: "IX_Modelos_idMarca",
                table: "Modelos",
                column: "idMarca");

            migrationBuilder.CreateIndex(
                name: "IX_Servicios_Oficiales_idConcesionario",
                table: "Servicios_Oficiales",
                column: "idConcesionario");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_idAutomovil",
                table: "Ventas",
                column: "idAutomovil");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_idServicioOficial",
                table: "Ventas",
                column: "idServicioOficial");

            migrationBuilder.CreateIndex(
                name: "IX_Ventas_idVendedor",
                table: "Ventas",
                column: "idVendedor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Extras_Venta");

            migrationBuilder.DropTable(
                name: "Modelo_Extras");

            migrationBuilder.DropTable(
                name: "Ventas");

            migrationBuilder.DropTable(
                name: "Extras");

            migrationBuilder.DropTable(
                name: "Automoviles_Stock");

            migrationBuilder.DropTable(
                name: "Servicios_Oficiales");

            migrationBuilder.DropTable(
                name: "Vendedores");

            migrationBuilder.DropTable(
                name: "Modelos");

            migrationBuilder.DropTable(
                name: "Concesionarios");

            migrationBuilder.DropTable(
                name: "Marcas");
        }
    }
}
