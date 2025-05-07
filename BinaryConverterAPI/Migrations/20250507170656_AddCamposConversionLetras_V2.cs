using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BinaryConverterAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddCamposConversionLetras_V2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClaveUsada",
                table: "LetterConversions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Operador",
                table: "LetterConversions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResultadoBinarioDeLaLetra",
                table: "LetterConversions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResultadoEnFormatoLetra",
                table: "LetterConversions",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClaveUsada",
                table: "LetterConversions");

            migrationBuilder.DropColumn(
                name: "Operador",
                table: "LetterConversions");

            migrationBuilder.DropColumn(
                name: "ResultadoBinarioDeLaLetra",
                table: "LetterConversions");

            migrationBuilder.DropColumn(
                name: "ResultadoEnFormatoLetra",
                table: "LetterConversions");
        }
    }
}
