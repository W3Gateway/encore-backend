using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Encore.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class RefactorRelationQuestionWithOtherQuestion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OtherQuestion_Question_QuestionId",
                table: "OtherQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_OtherQuestion_Question_SubQuestionId",
                table: "OtherQuestion");

            migrationBuilder.AlterColumn<Guid>(
                name: "SubQuestionId",
                table: "OtherQuestion",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_OtherQuestion_Question_QuestionId",
                table: "OtherQuestion",
                column: "QuestionId",
                principalTable: "Question",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OtherQuestion_Question_SubQuestionId",
                table: "OtherQuestion",
                column: "SubQuestionId",
                principalTable: "Question",
                principalColumn: "Id");
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

            migrationBuilder.AlterColumn<Guid>(
                name: "SubQuestionId",
                table: "OtherQuestion",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

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
    }
}
