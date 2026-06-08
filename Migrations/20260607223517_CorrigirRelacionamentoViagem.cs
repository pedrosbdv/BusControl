using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusControl.Migrations
{
    /// <inheritdoc />
    public partial class CorrigirRelacionamentoViagem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Viagens_motorista",
                table: "Viagens",
                column: "motorista");

            migrationBuilder.CreateIndex(
                name: "IX_Viagens_veiculo",
                table: "Viagens",
                column: "veiculo");

            migrationBuilder.AddForeignKey(
                name: "FK_Viagens_Motoristas_motorista",
                table: "Viagens",
                column: "motorista",
                principalTable: "Motoristas",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Viagens_Veiculos_veiculo",
                table: "Viagens",
                column: "veiculo",
                principalTable: "Veiculos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Viagens_Motoristas_motorista",
                table: "Viagens");

            migrationBuilder.DropForeignKey(
                name: "FK_Viagens_Veiculos_veiculo",
                table: "Viagens");

            migrationBuilder.DropIndex(
                name: "IX_Viagens_motorista",
                table: "Viagens");

            migrationBuilder.DropIndex(
                name: "IX_Viagens_veiculo",
                table: "Viagens");
        }
    }
}
