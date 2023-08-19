using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Encore.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeRelationshipsTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HealthCondition_Person_PersonId",
                table: "HealthCondition");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_Home_HomeId",
                table: "Person");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_Microregion_MicroregionId",
                table: "Person");

            migrationBuilder.DropForeignKey(
                name: "FK_SociodemographicSituation_Person_PersonId",
                table: "SociodemographicSituation");

            migrationBuilder.DropIndex(
                name: "IX_SociodemographicSituation_PersonId",
                table: "SociodemographicSituation");

            migrationBuilder.DropIndex(
                name: "IX_HealthCondition_PersonId",
                table: "HealthCondition");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "SociodemographicSituation");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "HealthCondition");

            migrationBuilder.AddColumn<Guid>(
                name: "HealthConditionId",
                table: "Person",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "SociodemographicSituationId",
                table: "Person",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Person_HealthConditionId",
                table: "Person",
                column: "HealthConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_SociodemographicSituationId",
                table: "Person",
                column: "SociodemographicSituationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_HealthCondition_HealthConditionId",
                table: "Person",
                column: "HealthConditionId",
                principalTable: "HealthCondition",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Home_HomeId",
                table: "Person",
                column: "HomeId",
                principalTable: "Home",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Microregion_MicroregionId",
                table: "Person",
                column: "MicroregionId",
                principalTable: "Microregion",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_SociodemographicSituation_SociodemographicSituationId",
                table: "Person",
                column: "SociodemographicSituationId",
                principalTable: "SociodemographicSituation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_HealthCondition_HealthConditionId",
                table: "Person");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_Home_HomeId",
                table: "Person");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_Microregion_MicroregionId",
                table: "Person");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_SociodemographicSituation_SociodemographicSituationId",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_HealthConditionId",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_SociodemographicSituationId",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "HealthConditionId",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "SociodemographicSituationId",
                table: "Person");

            migrationBuilder.AddColumn<Guid>(
                name: "PersonId",
                table: "SociodemographicSituation",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PersonId",
                table: "HealthCondition",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_SociodemographicSituation_PersonId",
                table: "SociodemographicSituation",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthCondition_PersonId",
                table: "HealthCondition",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_HealthCondition_Person_PersonId",
                table: "HealthCondition",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Home_HomeId",
                table: "Person",
                column: "HomeId",
                principalTable: "Home",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Microregion_MicroregionId",
                table: "Person",
                column: "MicroregionId",
                principalTable: "Microregion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SociodemographicSituation_Person_PersonId",
                table: "SociodemographicSituation",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
