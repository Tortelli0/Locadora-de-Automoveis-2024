using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocadoraAutomoveis.Infra.Orm.Migrations
{
    /// <inheritdoc />
    public partial class add_automoveis : Migration
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
                    FK_TbAutomovel_TbGrupoAutomovel = table.Column<int>(type: "int", nullable: false),
                    Modelo = table.Column<string>(type: "varchar(50)", nullable: false),
                    Marca = table.Column<string>(type: "varchar(50)", nullable: false),
                    Cor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoCombustivel = table.Column<string>(type: "varchar(50)", nullable: false),
                    CapacidadeLitros = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBAutomoveis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBAutomoveis_TBGrupoAutomoveis_FK_TbAutomovel_TbGrupoAutomovel",
                        column: x => x.FK_TbAutomovel_TbGrupoAutomovel,
                        principalTable: "TBGrupoAutomoveis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBAutomoveis_FK_TbAutomovel_TbGrupoAutomovel",
                table: "TBAutomoveis",
                column: "FK_TbAutomovel_TbGrupoAutomovel");
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
