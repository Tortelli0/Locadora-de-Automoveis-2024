using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocadoraAutomoveis.Infra.Orm.Migrations
{
    /// <inheritdoc />
    public partial class colunarenomeada : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBAutomoveis_TBGrupoAutomoveis_FK_TbAutomovel_TbGrupoAutomovel",
                table: "TBAutomoveis");

            migrationBuilder.RenameColumn(
                name: "FK_TbAutomovel_TbGrupoAutomovel",
                table: "TBAutomoveis",
                newName: "GrupoAutomoveisId");

            migrationBuilder.RenameIndex(
                name: "IX_TBAutomoveis_FK_TbAutomovel_TbGrupoAutomovel",
                table: "TBAutomoveis",
                newName: "IX_TBAutomoveis_GrupoAutomoveisId");

            migrationBuilder.AddForeignKey(
                name: "FK_TbAutomovel_TbGrupoAutomovel",
                table: "TBAutomoveis",
                column: "GrupoAutomoveisId",
                principalTable: "TBGrupoAutomoveis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbAutomovel_TbGrupoAutomovel",
                table: "TBAutomoveis");

            migrationBuilder.RenameColumn(
                name: "GrupoAutomoveisId",
                table: "TBAutomoveis",
                newName: "FK_TbAutomovel_TbGrupoAutomovel");

            migrationBuilder.RenameIndex(
                name: "IX_TBAutomoveis_GrupoAutomoveisId",
                table: "TBAutomoveis",
                newName: "IX_TBAutomoveis_FK_TbAutomovel_TbGrupoAutomovel");

            migrationBuilder.AddForeignKey(
                name: "FK_TBAutomoveis_TBGrupoAutomoveis_FK_TbAutomovel_TbGrupoAutomovel",
                table: "TBAutomoveis",
                column: "FK_TbAutomovel_TbGrupoAutomovel",
                principalTable: "TBGrupoAutomoveis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
