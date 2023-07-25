using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Encore.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeKeysAddProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Home_Person_ResponsiblePersonId",
                table: "Home");

            migrationBuilder.DropIndex(
                name: "IX_Home_ResponsiblePersonId",
                table: "Home");

            migrationBuilder.DropColumn(
                name: "ResponsiblePersonId",
                table: "Home");

            migrationBuilder.AddColumn<Guid>(
                name: "HomeId",
                table: "Person",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "IsHeadFamily",
                table: "Person",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Person_HomeId",
                table: "Person",
                column: "HomeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Home_HomeId",
                table: "Person",
                column: "HomeId",
                principalTable: "Home",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_Home_HomeId",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_HomeId",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "HomeId",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "IsHeadFamily",
                table: "Person");

            migrationBuilder.AddColumn<Guid>(
                name: "ResponsiblePersonId",
                table: "Home",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Home_ResponsiblePersonId",
                table: "Home",
                column: "ResponsiblePersonId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Home_Person_ResponsiblePersonId",
                table: "Home",
                column: "ResponsiblePersonId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
