using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Encore.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewColunmQuestionTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OtherQuestion_Question_QuestionId",
                table: "OtherQuestion");

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Question",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SlugProperty",
                table: "Question",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "SubQuestionId",
                table: "OtherQuestion",
                type: "uniqueidentifier",
                nullable: true,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Form",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_OtherQuestion_SubQuestionId",
                table: "OtherQuestion",
                column: "SubQuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_OtherQuestion_Question_QuestionId",
                table: "OtherQuestion",
                column: "QuestionId",
                principalTable: "Question",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OtherQuestion_Question_SubQuestionId",
                table: "OtherQuestion",
                column: "SubQuestionId",
                principalTable: "Question",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OtherQuestion_Question_QuestionId",
                table: "OtherQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_OtherQuestion_Question_SubQuestionId",
                table: "OtherQuestion");

            migrationBuilder.DropIndex(
                name: "IX_OtherQuestion_SubQuestionId",
                table: "OtherQuestion");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "SlugProperty",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "SubQuestionId",
                table: "OtherQuestion");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Form");

            migrationBuilder.AddForeignKey(
                name: "FK_OtherQuestion_Question_QuestionId",
                table: "OtherQuestion",
                column: "QuestionId",
                principalTable: "Question",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
