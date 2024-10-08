﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocadoraAutomoveis.Infra.Orm.Migrations
{
    /// <inheritdoc />
    public partial class addconfiguracaoCombustivel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TipoCombustivel",
                table: "TBAutomoveis",
                newName: "TipoCombustivelEnum");

            migrationBuilder.CreateTable(
                name: "TBConfiguracaoCombustivel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValorGasolina = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorGas = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorDiesel = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorAlcool = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBConfiguracaoCombustivel", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBConfiguracaoCombustivel");

            migrationBuilder.RenameColumn(
                name: "TipoCombustivelEnum",
                table: "TBAutomoveis",
                newName: "TipoCombustivel");
        }
    }
}
