using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BinaryConverterAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddCamposConversionLetras : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClaveUsada",
                table: "ConversionLetras",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Operador",
                table: "ConversionLetras",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResultadoBinario",
                table: "ConversionLetras",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClaveUsada",
                table: "ConversionLetras");

            migrationBuilder.DropColumn(
                name: "Operador",
                table: "ConversionLetras");

            migrationBuilder.DropColumn(
                name: "ResultadoBinario",
                table: "ConversionLetras");
        }
    }
}
