using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Encore.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class DownAddFormTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_Form_FormId",
                table: "Question");

            migrationBuilder.DropTable(
                name: "Form");

            migrationBuilder.DropIndex(
                name: "IX_Question_FormId",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "FormId",
                table: "Question");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Form",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Form", x => x.Id);
                });

            var newId = new Guid();

            var formVisit = migrationBuilder.InsertData(
                table: "Form",
                columns: new[] { "Id", "Slug", "Ativo", "AddedDate", "ModifiedDate" },
                values: new object[] { newId, "Visit", true, new DateTime(2023, 08, 03), DateTime.MinValue });

            migrationBuilder.AddColumn<Guid>(
                name: "FormId",
                table: "Question",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: newId);

            migrationBuilder.CreateIndex(
                name: "IX_Question_FormId",
                table: "Question",
                column: "FormId");

            migrationBuilder.CreateIndex(
                name: "IX_Form_Slug",
                table: "Form",
                column: "Slug",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Form_FormId",
                table: "Question",
                column: "FormId",
                principalTable: "Form",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
