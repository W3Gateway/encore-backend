using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Encore.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixesColumnNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HadCanser",
                table: "HealthCondition",
                newName: "HasTuberculosis");

            migrationBuilder.AddColumn<bool>(
                name: "HadCancer",
                table: "HealthCondition",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HadKidneyProblem",
                table: "HealthCondition",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HadCancer",
                table: "HealthCondition");

            migrationBuilder.DropColumn(
                name: "HadKidneyProblem",
                table: "HealthCondition");

            migrationBuilder.RenameColumn(
                name: "HasTuberculosis",
                table: "HealthCondition",
                newName: "HadCanser");
        }
    }
}
