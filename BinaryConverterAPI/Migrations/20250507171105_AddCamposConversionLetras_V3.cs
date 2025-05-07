using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BinaryConverterAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddCamposConversionLetras_V3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ClaveUsada",
                table: "LetterConversions",
                newName: "ClaveUsadaLetra");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ClaveUsadaLetra",
                table: "LetterConversions",
                newName: "ClaveUsada");
        }
    }
}
