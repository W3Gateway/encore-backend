using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Encore.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeMapHome : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "NumberMembers",
                table: "Home",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(3,0)");

            migrationBuilder.AlterColumn<int>(
                name: "Number",
                table: "Home",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(4,3)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "NumberMembers",
                table: "Home",
                type: "numeric(3,0)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "Number",
                table: "Home",
                type: "numeric(4,3)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
