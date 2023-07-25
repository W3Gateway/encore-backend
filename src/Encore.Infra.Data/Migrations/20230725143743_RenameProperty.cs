using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Encore.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class RenameProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NationalHealthRegister",
                table: "Person");

            migrationBuilder.AddColumn<string>(
                name: "DocumentType",
                table: "Person",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocumentType",
                table: "Person");

            migrationBuilder.AddColumn<string>(
                name: "NationalHealthRegister",
                table: "Person",
                type: "varchar(20)",
                nullable: false,
                defaultValue: "");
        }
    }
}
