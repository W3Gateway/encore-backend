using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Encore.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class TableVisit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChecklistQuestion");

            migrationBuilder.AddColumn<Guid>(
                name: "VisitId",
                table: "QuestionAnswer",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "OtherQuestion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", nullable: false),
                    QuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherQuestion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OtherQuestion_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Visit",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AgentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HomeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MicroregionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Visit_Agent_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Visit_Home_HomeId",
                        column: x => x.HomeId,
                        principalTable: "Home",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Visit_Microregion_MicroregionId",
                        column: x => x.MicroregionId,
                        principalTable: "Microregion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Visit_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuestionAnswer_VisitId",
                table: "QuestionAnswer",
                column: "VisitId");

            migrationBuilder.CreateIndex(
                name: "IX_OtherQuestion_QuestionId",
                table: "OtherQuestion",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Visit_AgentId",
                table: "Visit",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Visit_HomeId",
                table: "Visit",
                column: "HomeId");

            migrationBuilder.CreateIndex(
                name: "IX_Visit_MicroregionId",
                table: "Visit",
                column: "MicroregionId");

            migrationBuilder.CreateIndex(
                name: "IX_Visit_PersonId",
                table: "Visit",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionAnswer_Visit_VisitId",
                table: "QuestionAnswer",
                column: "VisitId",
                principalTable: "Visit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionAnswer_Visit_VisitId",
                table: "QuestionAnswer");

            migrationBuilder.DropTable(
                name: "OtherQuestion");

            migrationBuilder.DropTable(
                name: "Visit");

            migrationBuilder.DropIndex(
                name: "IX_QuestionAnswer_VisitId",
                table: "QuestionAnswer");

            migrationBuilder.DropColumn(
                name: "VisitId",
                table: "QuestionAnswer");

            migrationBuilder.CreateTable(
                name: "ChecklistQuestion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChecklistQuestion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChecklistQuestion_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChecklistQuestion_QuestionId",
                table: "ChecklistQuestion",
                column: "QuestionId");
        }
    }
}
