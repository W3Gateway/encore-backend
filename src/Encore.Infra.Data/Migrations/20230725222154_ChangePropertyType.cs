using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Encore.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangePropertyType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Number",
                table: "HealthCenter",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(4,3)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Number",
                table: "HealthCenter",
                type: "numeric(4,3)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
