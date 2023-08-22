using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Encore.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class RenameColumnsHealthCondition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReacentlyHospitalization",
                table: "HealthCondition",
                newName: "RecentlyHospitalization");

            migrationBuilder.RenameColumn(
                name: "CauseHospotalization",
                table: "HealthCondition",
                newName: "CauseHospitalization");

            migrationBuilder.AddColumn<string>(
                name: "HomeContact",
                table: "Home",
                type: "varchar(15)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "KidneyProblem",
                table: "HealthCondition",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HomeContact",
                table: "Home");

            migrationBuilder.DropColumn(
                name: "KidneyProblem",
                table: "HealthCondition");

            migrationBuilder.RenameColumn(
                name: "RecentlyHospitalization",
                table: "HealthCondition",
                newName: "ReacentlyHospitalization");

            migrationBuilder.RenameColumn(
                name: "CauseHospitalization",
                table: "HealthCondition",
                newName: "CauseHospotalization");
        }
    }
}
