using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocadoraAutomoveis.Infra.Orm.Migrations
{
    /// <inheritdoc />
    public partial class AddMultiTenancy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Empresa_Id",
                table: "TBTaxa",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Empresa_Id",
                table: "TBPlanoCobranca",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Empresa_Id",
                table: "TBLocacao",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Empresa_Id",
                table: "TBGrupoAutomoveis",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Empresa_Id",
                table: "TBConfiguracaoCombustivel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Empresa_Id",
                table: "TBCondutor",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Empresa_Id",
                table: "TBCliente",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Empresa_Id",
                table: "TBAutomoveis",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TBTaxa_Empresa_Id",
                table: "TBTaxa",
                column: "Empresa_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TBPlanoCobranca_Empresa_Id",
                table: "TBPlanoCobranca",
                column: "Empresa_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TBLocacao_Empresa_Id",
                table: "TBLocacao",
                column: "Empresa_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TBGrupoAutomoveis_Empresa_Id",
                table: "TBGrupoAutomoveis",
                column: "Empresa_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TBConfiguracaoCombustivel_Empresa_Id",
                table: "TBConfiguracaoCombustivel",
                column: "Empresa_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TBCondutor_Empresa_Id",
                table: "TBCondutor",
                column: "Empresa_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TBCliente_Empresa_Id",
                table: "TBCliente",
                column: "Empresa_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TBAutomoveis_Empresa_Id",
                table: "TBAutomoveis",
                column: "Empresa_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TBAutomoveis_AspNetUsers_Empresa_Id",
                table: "TBAutomoveis",
                column: "Empresa_Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TBCliente_AspNetUsers_Empresa_Id",
                table: "TBCliente",
                column: "Empresa_Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TBCondutor_AspNetUsers_Empresa_Id",
                table: "TBCondutor",
                column: "Empresa_Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TBConfiguracaoCombustivel_AspNetUsers_Empresa_Id",
                table: "TBConfiguracaoCombustivel",
                column: "Empresa_Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TBGrupoAutomoveis_AspNetUsers_Empresa_Id",
                table: "TBGrupoAutomoveis",
                column: "Empresa_Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TBLocacao_AspNetUsers_Empresa_Id",
                table: "TBLocacao",
                column: "Empresa_Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TBPlanoCobranca_AspNetUsers_Empresa_Id",
                table: "TBPlanoCobranca",
                column: "Empresa_Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TBTaxa_AspNetUsers_Empresa_Id",
                table: "TBTaxa",
                column: "Empresa_Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBAutomoveis_AspNetUsers_Empresa_Id",
                table: "TBAutomoveis");

            migrationBuilder.DropForeignKey(
                name: "FK_TBCliente_AspNetUsers_Empresa_Id",
                table: "TBCliente");

            migrationBuilder.DropForeignKey(
                name: "FK_TBCondutor_AspNetUsers_Empresa_Id",
                table: "TBCondutor");

            migrationBuilder.DropForeignKey(
                name: "FK_TBConfiguracaoCombustivel_AspNetUsers_Empresa_Id",
                table: "TBConfiguracaoCombustivel");

            migrationBuilder.DropForeignKey(
                name: "FK_TBGrupoAutomoveis_AspNetUsers_Empresa_Id",
                table: "TBGrupoAutomoveis");

            migrationBuilder.DropForeignKey(
                name: "FK_TBLocacao_AspNetUsers_Empresa_Id",
                table: "TBLocacao");

            migrationBuilder.DropForeignKey(
                name: "FK_TBPlanoCobranca_AspNetUsers_Empresa_Id",
                table: "TBPlanoCobranca");

            migrationBuilder.DropForeignKey(
                name: "FK_TBTaxa_AspNetUsers_Empresa_Id",
                table: "TBTaxa");

            migrationBuilder.DropIndex(
                name: "IX_TBTaxa_Empresa_Id",
                table: "TBTaxa");

            migrationBuilder.DropIndex(
                name: "IX_TBPlanoCobranca_Empresa_Id",
                table: "TBPlanoCobranca");

            migrationBuilder.DropIndex(
                name: "IX_TBLocacao_Empresa_Id",
                table: "TBLocacao");

            migrationBuilder.DropIndex(
                name: "IX_TBGrupoAutomoveis_Empresa_Id",
                table: "TBGrupoAutomoveis");

            migrationBuilder.DropIndex(
                name: "IX_TBConfiguracaoCombustivel_Empresa_Id",
                table: "TBConfiguracaoCombustivel");

            migrationBuilder.DropIndex(
                name: "IX_TBCondutor_Empresa_Id",
                table: "TBCondutor");

            migrationBuilder.DropIndex(
                name: "IX_TBCliente_Empresa_Id",
                table: "TBCliente");

            migrationBuilder.DropIndex(
                name: "IX_TBAutomoveis_Empresa_Id",
                table: "TBAutomoveis");

            migrationBuilder.DropColumn(
                name: "Empresa_Id",
                table: "TBTaxa");

            migrationBuilder.DropColumn(
                name: "Empresa_Id",
                table: "TBPlanoCobranca");

            migrationBuilder.DropColumn(
                name: "Empresa_Id",
                table: "TBLocacao");

            migrationBuilder.DropColumn(
                name: "Empresa_Id",
                table: "TBGrupoAutomoveis");

            migrationBuilder.DropColumn(
                name: "Empresa_Id",
                table: "TBConfiguracaoCombustivel");

            migrationBuilder.DropColumn(
                name: "Empresa_Id",
                table: "TBCondutor");

            migrationBuilder.DropColumn(
                name: "Empresa_Id",
                table: "TBCliente");

            migrationBuilder.DropColumn(
                name: "Empresa_Id",
                table: "TBAutomoveis");
        }
    }
}
