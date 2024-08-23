using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocadoraAutomoveis.Infra.Orm.Migrations
{
    /// <inheritdoc />
    public partial class AddAutomovel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBGrupoAutomoveis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBGrupoAutomoveis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBAutomoveis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Modelo = table.Column<string>(type: "varchar(100)", nullable: false),
                    Marca = table.Column<string>(type: "varchar(100)", nullable: false),
                    Cor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoCombustivel = table.Column<int>(type: "int", nullable: false),
                    CapacidadeLitros = table.Column<int>(type: "int", nullable: false),
                    GrupoAutomoveisId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBAutomoveis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TbAutomovel_TbGrupoAutomovel",
                        column: x => x.GrupoAutomoveisId,
                        principalTable: "TBGrupoAutomoveis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBAutomoveis_GrupoAutomoveisId",
                table: "TBAutomoveis",
                column: "GrupoAutomoveisId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBAutomoveis");

            migrationBuilder.DropTable(
                name: "TBGrupoAutomoveis");
        }
    }
}
