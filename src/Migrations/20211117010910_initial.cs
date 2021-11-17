using Microsoft.EntityFrameworkCore.Migrations;

namespace TCC.Agenda.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agenda_Prestador_PrestadorId",
                table: "Agenda");

            migrationBuilder.DropForeignKey(
                name: "FK_Agenda_TipoDeServico_TipoDeServicoId",
                table: "Agenda");

            migrationBuilder.DropForeignKey(
                name: "FK_Agenda_Usuario_UsuarioId",
                table: "Agenda");

            migrationBuilder.DropForeignKey(
                name: "FK_PrestadorTipoDeServico_Prestador_PrestadorId",
                table: "PrestadorTipoDeServico");

            migrationBuilder.DropForeignKey(
                name: "FK_PrestadorTipoDeServico_TipoDeServico_TipoDeServicoId",
                table: "PrestadorTipoDeServico");

            migrationBuilder.AddForeignKey(
                name: "FK_Agenda_Prestador_PrestadorId",
                table: "Agenda",
                column: "PrestadorId",
                principalTable: "Prestador",
                principalColumn: "PrestadorId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Agenda_TipoDeServico_TipoDeServicoId",
                table: "Agenda",
                column: "TipoDeServicoId",
                principalTable: "TipoDeServico",
                principalColumn: "TipoDeServicoId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Agenda_Usuario_UsuarioId",
                table: "Agenda",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PrestadorTipoDeServico_Prestador_PrestadorId",
                table: "PrestadorTipoDeServico",
                column: "PrestadorId",
                principalTable: "Prestador",
                principalColumn: "PrestadorId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PrestadorTipoDeServico_TipoDeServico_TipoDeServicoId",
                table: "PrestadorTipoDeServico",
                column: "TipoDeServicoId",
                principalTable: "TipoDeServico",
                principalColumn: "TipoDeServicoId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agenda_Prestador_PrestadorId",
                table: "Agenda");

            migrationBuilder.DropForeignKey(
                name: "FK_Agenda_TipoDeServico_TipoDeServicoId",
                table: "Agenda");

            migrationBuilder.DropForeignKey(
                name: "FK_Agenda_Usuario_UsuarioId",
                table: "Agenda");

            migrationBuilder.DropForeignKey(
                name: "FK_PrestadorTipoDeServico_Prestador_PrestadorId",
                table: "PrestadorTipoDeServico");

            migrationBuilder.DropForeignKey(
                name: "FK_PrestadorTipoDeServico_TipoDeServico_TipoDeServicoId",
                table: "PrestadorTipoDeServico");

            migrationBuilder.AddForeignKey(
                name: "FK_Agenda_Prestador_PrestadorId",
                table: "Agenda",
                column: "PrestadorId",
                principalTable: "Prestador",
                principalColumn: "PrestadorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Agenda_TipoDeServico_TipoDeServicoId",
                table: "Agenda",
                column: "TipoDeServicoId",
                principalTable: "TipoDeServico",
                principalColumn: "TipoDeServicoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Agenda_Usuario_UsuarioId",
                table: "Agenda",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PrestadorTipoDeServico_Prestador_PrestadorId",
                table: "PrestadorTipoDeServico",
                column: "PrestadorId",
                principalTable: "Prestador",
                principalColumn: "PrestadorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PrestadorTipoDeServico_TipoDeServico_TipoDeServicoId",
                table: "PrestadorTipoDeServico",
                column: "TipoDeServicoId",
                principalTable: "TipoDeServico",
                principalColumn: "TipoDeServicoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
