using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Encore.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateNewTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agent_HealthCenter_HealthCenterId",
                table: "Agent");

            migrationBuilder.DropForeignKey(
                name: "FK_Agent_User_UserId",
                table: "Agent");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionAnswer_Question_QuestionId",
                table: "QuestionAnswer");

            migrationBuilder.DropForeignKey(
                name: "FK_Visit_Agent_AgentId",
                table: "Visit");

            migrationBuilder.DropForeignKey(
                name: "FK_Visit_Home_HomeId",
                table: "Visit");

            migrationBuilder.DropForeignKey(
                name: "FK_Visit_Microregion_MicroregionId",
                table: "Visit");

            migrationBuilder.DropForeignKey(
                name: "FK_Visit_Person_PersonId",
                table: "Visit");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Home");

            migrationBuilder.DropColumn(
                name: "Landmark",
                table: "Home");

            migrationBuilder.DropColumn(
                name: "Neighborhood",
                table: "Home");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "Home");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Home");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "Home");

            migrationBuilder.DropColumn(
                name: "StreetComplement",
                table: "Home");

            migrationBuilder.DropColumn(
                name: "City",
                table: "HealthCenter");

            migrationBuilder.DropColumn(
                name: "Landmark",
                table: "HealthCenter");

            migrationBuilder.DropColumn(
                name: "Neighborhood",
                table: "HealthCenter");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "HealthCenter");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "HealthCenter");

            migrationBuilder.DropColumn(
                name: "State",
                table: "HealthCenter");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "HealthCenter");

            migrationBuilder.DropColumn(
                name: "StreetComplement",
                table: "HealthCenter");

            migrationBuilder.RenameColumn(
                name: "Number",
                table: "Home",
                newName: "NumberRooms");

            migrationBuilder.AddColumn<Guid>(
                name: "AddressId",
                table: "Home",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "AmountAnimals",
                table: "Home",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Animals",
                table: "Home",
                type: "varchar(200)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Electricity",
                table: "Home",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "GarbageDestination",
                table: "Home",
                type: "varchar(60)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LocationType",
                table: "Home",
                type: "varchar(20)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PredominantMaterial",
                table: "Home",
                type: "varchar(60)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RuralProductionArea",
                table: "Home",
                type: "varchar(60)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SanitaryDrainage",
                table: "Home",
                type: "varchar(60)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Situation",
                table: "Home",
                type: "varchar(60)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TypeAccess",
                table: "Home",
                type: "varchar(60)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TypeDomicile",
                table: "Home",
                type: "varchar(60)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WaterConsumption",
                table: "Home",
                type: "varchar(60)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WaterSupply",
                table: "Home",
                type: "varchar(60)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "AddressId",
                table: "HealthCenter",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PostalCode = table.Column<string>(type: "varchar(8)", nullable: false),
                    State = table.Column<string>(type: "varchar(50)", nullable: false),
                    City = table.Column<string>(type: "varchar(50)", nullable: false),
                    Neighborhood = table.Column<string>(type: "varchar(50)", nullable: false),
                    Street = table.Column<string>(type: "varchar(100)", nullable: false),
                    StreetType = table.Column<string>(type: "varchar(50)", nullable: false),
                    StreetComplement = table.Column<string>(type: "varchar(20)", nullable: true),
                    Landmark = table.Column<string>(type: "varchar(200)", nullable: true),
                    Number = table.Column<int>(type: "int", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HealthCondition",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WeightCondition = table.Column<string>(type: "varchar(100)", nullable: false),
                    IsSmoker = table.Column<bool>(type: "bit", nullable: false),
                    UseAlcohol = table.Column<bool>(type: "bit", nullable: false),
                    UsesOtherDrugs = table.Column<bool>(type: "bit", nullable: false),
                    HasHypertension = table.Column<bool>(type: "bit", nullable: false),
                    HasDiabetes = table.Column<bool>(type: "bit", nullable: false),
                    HadStroke = table.Column<bool>(type: "bit", nullable: false),
                    HadHeartAttack = table.Column<bool>(type: "bit", nullable: false),
                    HasHeartDisease = table.Column<bool>(type: "bit", nullable: false),
                    HeartDisease = table.Column<string>(type: "varchar(100)", nullable: false),
                    HasRespiratoryDisease = table.Column<bool>(type: "bit", nullable: false),
                    RespiratoryDisease = table.Column<string>(type: "varchar(100)", nullable: false),
                    HasLeprosy = table.Column<bool>(type: "bit", nullable: false),
                    HadCanser = table.Column<bool>(type: "bit", nullable: false),
                    ReacentlyHospitalization = table.Column<bool>(type: "bit", nullable: false),
                    CauseHospotalization = table.Column<string>(type: "varchar(100)", nullable: false),
                    DiagnoseMentalHealthProblem = table.Column<bool>(type: "bit", nullable: false),
                    IsBedridden = table.Column<bool>(type: "bit", nullable: false),
                    IsDomiciled = table.Column<bool>(type: "bit", nullable: false),
                    UseMedicinalPlants = table.Column<bool>(type: "bit", nullable: false),
                    MedicinalPlants = table.Column<string>(type: "varchar(100)", nullable: false),
                    OtherHealthConditions = table.Column<string>(type: "varchar(250)", nullable: false),
                    StreetSituation = table.Column<bool>(type: "bit", nullable: false),
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthCondition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HealthCondition_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SociodemographicSituation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AttendSchool = table.Column<bool>(type: "bit", nullable: false),
                    LevelEducation = table.Column<string>(type: "varchar(100)", nullable: false),
                    LaborMarketSituation = table.Column<string>(type: "varchar(60)", nullable: true),
                    Occupation = table.Column<string>(type: "varchar(100)", nullable: true),
                    HasTraditionalCaregiver = table.Column<bool>(type: "bit", nullable: true),
                    IsMemberCommunityGroup = table.Column<bool>(type: "bit", nullable: true),
                    HasPrivateHealthPlan = table.Column<bool>(type: "bit", nullable: true),
                    IsMemberTraditionalCommunity = table.Column<bool>(type: "bit", nullable: true),
                    TraditionalCommunity = table.Column<string>(type: "varchar(100)", nullable: true),
                    HasSexualOrientation = table.Column<bool>(type: "bit", nullable: false),
                    SexualOrientation = table.Column<string>(type: "varchar(100)", nullable: false),
                    HasGenderIdentity = table.Column<bool>(type: "bit", nullable: false),
                    GenderIdentity = table.Column<string>(type: "varchar(100)", nullable: false),
                    HasDisability = table.Column<bool>(type: "bit", nullable: false),
                    Disability = table.Column<string>(type: "varchar(100)", nullable: false),
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SociodemographicSituation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SociodemographicSituation_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Home_AddressId",
                table: "Home",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthCenter_AddressId",
                table: "HealthCenter",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthCondition_PersonId",
                table: "HealthCondition",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_SociodemographicSituation_PersonId",
                table: "SociodemographicSituation",
                column: "PersonId");


            migrationBuilder.AddForeignKey(
                name: "FK_Visit_Agent_AgentId",
                table: "Visit",
                column: "AgentId",
                principalTable: "Agent",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Visit_Home_HomeId",
                table: "Visit",
                column: "HomeId",
                principalTable: "Home",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Visit_Microregion_MicroregionId",
                table: "Visit",
                column: "MicroregionId",
                principalTable: "Microregion",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Visit_Person_PersonId",
                table: "Visit",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Agent_HealthCenter_HealthCenterId",
                table: "Agent",
                column: "HealthCenterId",
                principalTable: "HealthCenter",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Agent_User_UserId",
                table: "Agent",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Home_Address_AddressId",
                table: "Home",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionAnswer_Question_QuestionId",
                table: "QuestionAnswer",
                column: "QuestionId",
                principalTable: "Question",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HealthCenter_Address_AddressId",
                table: "HealthCenter",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agent_HealthCenter_HealthCenterId",
                table: "Agent");

            migrationBuilder.DropForeignKey(
                name: "FK_Agent_User_UserId",
                table: "Agent");

            migrationBuilder.DropForeignKey(
                name: "FK_HealthCenter_Address_AddressId",
                table: "HealthCenter");

            migrationBuilder.DropForeignKey(
                name: "FK_Home_Address_AddressId",
                table: "Home");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionAnswer_Question_QuestionId",
                table: "QuestionAnswer");

            migrationBuilder.DropForeignKey(
                name: "FK_Visit_Agent_AgentId",
                table: "Visit");

            migrationBuilder.DropForeignKey(
                name: "FK_Visit_Home_HomeId",
                table: "Visit");

            migrationBuilder.DropForeignKey(
                name: "FK_Visit_Microregion_MicroregionId",
                table: "Visit");

            migrationBuilder.DropForeignKey(
                name: "FK_Visit_Person_PersonId",
                table: "Visit");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "HealthCondition");

            migrationBuilder.DropTable(
                name: "SociodemographicSituation");

            migrationBuilder.DropIndex(
                name: "IX_Home_AddressId",
                table: "Home");

            migrationBuilder.DropIndex(
                name: "IX_HealthCenter_AddressId",
                table: "HealthCenter");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Home");

            migrationBuilder.DropColumn(
                name: "AmountAnimals",
                table: "Home");

            migrationBuilder.DropColumn(
                name: "Animals",
                table: "Home");

            migrationBuilder.DropColumn(
                name: "Electricity",
                table: "Home");

            migrationBuilder.DropColumn(
                name: "GarbageDestination",
                table: "Home");

            migrationBuilder.DropColumn(
                name: "LocationType",
                table: "Home");

            migrationBuilder.DropColumn(
                name: "PredominantMaterial",
                table: "Home");

            migrationBuilder.DropColumn(
                name: "RuralProductionArea",
                table: "Home");

            migrationBuilder.DropColumn(
                name: "SanitaryDrainage",
                table: "Home");

            migrationBuilder.DropColumn(
                name: "Situation",
                table: "Home");

            migrationBuilder.DropColumn(
                name: "TypeAccess",
                table: "Home");

            migrationBuilder.DropColumn(
                name: "TypeDomicile",
                table: "Home");

            migrationBuilder.DropColumn(
                name: "WaterConsumption",
                table: "Home");

            migrationBuilder.DropColumn(
                name: "WaterSupply",
                table: "Home");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "HealthCenter");

            migrationBuilder.RenameColumn(
                name: "NumberRooms",
                table: "Home",
                newName: "Number");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Home",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Landmark",
                table: "Home",
                type: "varchar(200)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Neighborhood",
                table: "Home",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "Home",
                type: "varchar(8)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Home",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "Home",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StreetComplement",
                table: "Home",
                type: "varchar(20)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "HealthCenter",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Landmark",
                table: "HealthCenter",
                type: "varchar(200)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Neighborhood",
                table: "HealthCenter",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "HealthCenter",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "HealthCenter",
                type: "varchar(8)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "HealthCenter",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "HealthCenter",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StreetComplement",
                table: "HealthCenter",
                type: "varchar(20)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Agent_HealthCenter_HealthCenterId",
                table: "Agent",
                column: "HealthCenterId",
                principalTable: "HealthCenter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Agent_User_UserId",
                table: "Agent",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionAnswer_Question_QuestionId",
                table: "QuestionAnswer",
                column: "QuestionId",
                principalTable: "Question",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Visit_Agent_AgentId",
                table: "Visit",
                column: "AgentId",
                principalTable: "Agent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Visit_Home_HomeId",
                table: "Visit",
                column: "HomeId",
                principalTable: "Home",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Visit_Microregion_MicroregionId",
                table: "Visit",
                column: "MicroregionId",
                principalTable: "Microregion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Visit_Person_PersonId",
                table: "Visit",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
