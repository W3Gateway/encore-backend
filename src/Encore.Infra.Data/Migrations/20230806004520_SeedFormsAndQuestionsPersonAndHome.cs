using Encore.Domain.Enum;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Encore.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedFormsAndQuestionsPersonAndHome : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var formHomeId = Guid.NewGuid();

            migrationBuilder.InsertData(
                table: "Form",
                columns: new[] { "Id", "Slug", "Title", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { formHomeId, "HomeHome", "Moradia", new DateTime(2023, 08, 05), DateTime.MinValue, true });

            var localQuestionId = Guid.NewGuid();

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "Name", "ResponseType", "Mandatory", "FormId", "AddedDate", "ModifiedDate", "Ativo", "Order" },
                values: new object[] { localQuestionId, "Localização", (int)EQuestionType.RADIO, true, formHomeId, new DateTime(2023, 08, 05), DateTime.MinValue, true, 1 });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Rural", localQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Urbana", localQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            var homeStateQuestionId = Guid.NewGuid();

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "Name", "ResponseType", "Mandatory", "FormId", "AddedDate", "ModifiedDate", "Ativo", "Order" },
                values: new object[] { homeStateQuestionId, "Situação da moradia", (int)EQuestionType.DROPLIST, true, formHomeId, new DateTime(2023, 08, 05), DateTime.MinValue, true, 2 });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Próprio", homeStateQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Financiado", homeStateQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Alugado", homeStateQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Arrendado", homeStateQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Cedido", homeStateQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Ocupação", homeStateQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Situação de rua", homeStateQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Outra", homeStateQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            var accessTypeQuestionId = Guid.NewGuid();

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "Name", "ResponseType", "Mandatory", "FormId", "AddedDate", "ModifiedDate", "Ativo", "Order" },
                values: new object[] { accessTypeQuestionId, "Tipo de acesso", (int)EQuestionType.DROPLIST, true, formHomeId, new DateTime(2023, 08, 05), DateTime.MinValue, true, 3 });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Pavimento", accessTypeQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Chão batido", accessTypeQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Fluvial", accessTypeQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Outro", accessTypeQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            var homeTypeQuestionId = Guid.NewGuid();

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "Name", "ResponseType", "Mandatory", "FormId", "AddedDate", "ModifiedDate", "Ativo", "Order" },
                values: new object[] { homeTypeQuestionId, "Tipo de domicílio", (int)EQuestionType.DROPLIST, true, formHomeId, new DateTime(2023, 08, 05), DateTime.MinValue, true, 4 });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Casa", homeTypeQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Apartamento", homeTypeQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Cômodo", homeTypeQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Outro", homeTypeQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            var predominantMaterialQuestionId = Guid.NewGuid();

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "Name", "ResponseType", "Mandatory", "FormId", "AddedDate", "ModifiedDate", "Ativo", "Order" },
                values: new object[] { predominantMaterialQuestionId, "Material predominante", (int)EQuestionType.DROPLIST, false, formHomeId, new DateTime(2023, 08, 05), DateTime.MinValue, true, 5 });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Alvenaria com revestimento", predominantMaterialQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Alvenaria sem revestimento", predominantMaterialQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Taipa com revestimento", predominantMaterialQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Taipa sem revestimento", predominantMaterialQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Madeira emparelhada", predominantMaterialQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Madeira aproveitado", predominantMaterialQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Palha", predominantMaterialQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Outro material", predominantMaterialQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            var numberRoomsQuestionId = Guid.NewGuid();

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "Name", "ResponseType", "Mandatory", "FormId", "AddedDate", "ModifiedDate", "Ativo", "Order" },
                values: new object[] { numberRoomsQuestionId, "Número de cômodos", (int)EQuestionType.NUMERIC, true, formHomeId, new DateTime(2023, 08, 05), DateTime.MinValue, true, 6 });

            var numberResidentsQuestionId = Guid.NewGuid();

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "Name", "ResponseType", "Mandatory", "FormId", "AddedDate", "ModifiedDate", "Ativo", "Order" },
                values: new object[] { numberResidentsQuestionId, "Número de moradores", (int)EQuestionType.NUMERIC, true, formHomeId, new DateTime(2023, 08, 05), DateTime.MinValue, true, 7 });

            var ruralProductionAreaId = Guid.NewGuid();

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "Name", "ResponseType", "Mandatory", "FormId", "AddedDate", "ModifiedDate", "Ativo", "Order" },
                values: new object[] { ruralProductionAreaId, "Área de produção rural", (int)EQuestionType.DROPLIST, false, formHomeId, new DateTime(2023, 08, 05), DateTime.MinValue, false, 8 });

            var waterSupplyQuestionId = Guid.NewGuid();

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "Name", "ResponseType", "Mandatory", "FormId", "AddedDate", "ModifiedDate", "Ativo", "Order" },
                values: new object[] { waterSupplyQuestionId, "Abastecimento de água", (int)EQuestionType.DROPLIST, true, formHomeId, new DateTime(2023, 08, 05), DateTime.MinValue, true, 9 });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Rede encanada até o domicílio", waterSupplyQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Poço/Nascente no domicílio", waterSupplyQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Cisterna", waterSupplyQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Carro pipa", waterSupplyQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            var waterComsumptionQuestionId = Guid.NewGuid();

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "Name", "ResponseType", "Mandatory", "FormId", "AddedDate", "ModifiedDate", "Ativo", "Order" },
                values: new object[] { waterComsumptionQuestionId, "Consumo de água", (int)EQuestionType.DROPLIST, false, formHomeId, new DateTime(2023, 08, 05), DateTime.MinValue, true, 10 });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Filtrada", waterComsumptionQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Fervida", waterComsumptionQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Clorada", waterComsumptionQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Mineral", waterComsumptionQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Sem tratamento", waterComsumptionQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            var sanitaryDrainageQuestionId = Guid.NewGuid();

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "Name", "ResponseType", "Mandatory", "FormId", "AddedDate", "ModifiedDate", "Ativo", "Order" },
                values: new object[] { sanitaryDrainageQuestionId, "Escoamento sanitário", (int)EQuestionType.DROPLIST, true, formHomeId, new DateTime(2023, 08, 05), DateTime.MinValue, true, 11 });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Rede coletora de esgoto ou pluvial", sanitaryDrainageQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Fossa séptica", sanitaryDrainageQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Fossa rudimentar", sanitaryDrainageQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Direto para um rio, lago ou mar", sanitaryDrainageQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Céu aberto", sanitaryDrainageQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Outra forma", sanitaryDrainageQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            var garbageDisposalQuestionId = Guid.NewGuid();

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "Name", "ResponseType", "Mandatory", "FormId", "AddedDate", "ModifiedDate", "Ativo", "Order" },
                values: new object[] { garbageDisposalQuestionId, "Destino do lixo", (int)EQuestionType.DROPLIST, true, formHomeId, new DateTime(2023, 08, 05), DateTime.MinValue, true, 12 });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Coletado", garbageDisposalQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Queimado/Enterrado", garbageDisposalQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Céu aberto", garbageDisposalQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Outro", garbageDisposalQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            var eletricityQuestionId = Guid.NewGuid();

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "Name", "ResponseType", "Mandatory", "FormId", "AddedDate", "ModifiedDate", "Ativo", "Order" },
                values: new object[] { eletricityQuestionId, "Destino do lixo", (int)EQuestionType.RADIO, true, formHomeId, new DateTime(2023, 08, 05), DateTime.MinValue, true, 13 });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Possui", eletricityQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Não possui", eletricityQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            var animalsAtHomeQuestionId = Guid.NewGuid();

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "Name", "ResponseType", "Mandatory", "FormId", "AddedDate", "ModifiedDate", "Ativo", "Order" },
                values: new object[] { animalsAtHomeQuestionId, "Animais no domicílio", (int)EQuestionType.RADIO, true, formHomeId, new DateTime(2023, 08, 05), DateTime.MinValue, false, 14 });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Não possui", animalsAtHomeQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Cachorro", animalsAtHomeQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Gato", animalsAtHomeQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Pássaro", animalsAtHomeQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Outros", animalsAtHomeQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            var howManyAnimalsQuestionId = Guid.NewGuid();

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "Name", "ResponseType", "Mandatory", "FormId", "AddedDate", "ModifiedDate", "Ativo", "Order" },
                values: new object[] { howManyAnimalsQuestionId, "Quantos animais no domicílio", (int)EQuestionType.NUMERIC, true, formHomeId, new DateTime(2023, 08, 05), DateTime.MinValue, false, 15 });

            var formPersonInfDemoId = Guid.NewGuid();

            migrationBuilder.InsertData(
                table: "Form",
                columns: new[] { "Id", "Slug", "Title", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { formPersonInfDemoId, "PersonSocioDemographicInformation", "Inf. Sociodemográficas", new DateTime(2023, 08, 05), DateTime.MinValue, true });

            var attendSchoolQuestionId = Guid.NewGuid();

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "Name", "ResponseType", "Mandatory", "FormId", "AddedDate", "ModifiedDate", "Ativo", "Order" },
                values: new object[] { attendSchoolQuestionId, "Frequenta escola", (int)EQuestionType.RADIO, true, formPersonInfDemoId, new DateTime(2023, 08, 05), DateTime.MinValue, true, 1 });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Sim", attendSchoolQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Não", attendSchoolQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            var levelEducationQuestionId = Guid.NewGuid();

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "Name", "ResponseType", "Mandatory", "FormId", "AddedDate", "ModifiedDate", "Ativo", "Order" },
                values: new object[] { levelEducationQuestionId, "Grau de instrução", (int)EQuestionType.DROPLIST, true, formPersonInfDemoId, new DateTime(2023, 08, 05), DateTime.MinValue, true, 2 });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Creche", levelEducationQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Pré-escola(exceto CA)", levelEducationQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Classe de alfabetização - CA", levelEducationQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Ensino fundamental 1ª a 4ª série", levelEducationQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Ensino fundamental 5ª a 8ª série", levelEducationQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Ensino fundamental completo", levelEducationQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Ensino fundamental especial", levelEducationQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Ensino fundamenta EJA/séries iniciais(supletivo 1ª a 4ª)", levelEducationQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Ensino fundamental EJA/séries finais(supletivo 5ª a 8ª)", levelEducationQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Ensino médio, medio 2º ciclo(científico, técnico e etc)", levelEducationQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Ensino médio especial", levelEducationQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Ensino médio EJA(supletivo)", levelEducationQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Superior, aperfeiçoamento, especialização, mestrado, doutorado", levelEducationQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Alfabetização para adultos(Mobral, etc)", levelEducationQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Nenhum", levelEducationQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            var laborMarketSituationQuestionId = Guid.NewGuid();

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "Name", "ResponseType", "Mandatory", "FormId", "AddedDate", "ModifiedDate", "Ativo", "Order" },
                values: new object[] { laborMarketSituationQuestionId, "Situação mercado de trabalho", (int)EQuestionType.DROPLIST, false, formPersonInfDemoId, new DateTime(2023, 08, 05), DateTime.MinValue, true, 3 });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Empregador", laborMarketSituationQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Assalariado com carteira de trabalho", laborMarketSituationQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Assalariado sem carteira de trabalho", laborMarketSituationQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Autônomo com previdência social", laborMarketSituationQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Autônomo sem previdência social", laborMarketSituationQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Aposentado/Pensionista", laborMarketSituationQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Desempregado", laborMarketSituationQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Não trabalha", laborMarketSituationQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Servidor público/Militar", laborMarketSituationQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Outro", laborMarketSituationQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            var occupationQuestionId = Guid.NewGuid();

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "Name", "ResponseType", "Mandatory", "FormId", "AddedDate", "ModifiedDate", "Ativo", "Order" },
                values: new object[] { occupationQuestionId, "Ocupação", (int)EQuestionType.STRING, false, formPersonInfDemoId, new DateTime(2023, 08, 05), DateTime.MinValue, true, 4 });

            var attendsTraditionalCaregiverQuestionId = Guid.NewGuid();

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "Name", "ResponseType", "Mandatory", "FormId", "AddedDate", "ModifiedDate", "Ativo", "Order" },
                values: new object[] { attendsTraditionalCaregiverQuestionId, "Frequenta cuidador tradicional", (int)EQuestionType.RADIO, false, formPersonInfDemoId, new DateTime(2023, 08, 05), DateTime.MinValue, true, 5 });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Sim", attendsTraditionalCaregiverQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Não", attendsTraditionalCaregiverQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            var participateCommunityGroupQuestionId = Guid.NewGuid();

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "Name", "ResponseType", "Mandatory", "FormId", "AddedDate", "ModifiedDate", "Ativo", "Order" },
                values: new object[] { participateCommunityGroupQuestionId, "Participa de algum grupo comunitário", (int)EQuestionType.RADIO, false, formPersonInfDemoId, new DateTime(2023, 08, 05), DateTime.MinValue, true, 6 });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Sim", participateCommunityGroupQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Não", participateCommunityGroupQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            var privateHealthPlanQuestionId = Guid.NewGuid();

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "Name", "ResponseType", "Mandatory", "FormId", "AddedDate", "ModifiedDate", "Ativo", "Order" },
                values: new object[] { privateHealthPlanQuestionId, "Possui plano de saúde privado", (int)EQuestionType.RADIO, false, formPersonInfDemoId, new DateTime(2023, 08, 05), DateTime.MinValue, true, 7 });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Sim", privateHealthPlanQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Não", privateHealthPlanQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            var memberTraditionalCommunityQuestionId = Guid.NewGuid();

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "Name", "ResponseType", "Mandatory", "FormId", "AddedDate", "ModifiedDate", "Ativo", "Order" },
                values: new object[] { memberTraditionalCommunityQuestionId, "É membro de povo ou comunidade tradicional", (int)EQuestionType.RADIO, false, formPersonInfDemoId, new DateTime(2023, 08, 05), DateTime.MinValue, true, 8 });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Não", memberTraditionalCommunityQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            var memberTraditionalCommunitySubQuestionId = Guid.NewGuid();

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "Name", "ResponseType", "Mandatory", "FormId", "AddedDate", "ModifiedDate", "Ativo", "Order" },
                values: new object[] { memberTraditionalCommunitySubQuestionId, "Qual?", (int)EQuestionType.DROPLIST, true, null, new DateTime(2023, 08, 05), DateTime.MinValue, true, 0 });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Sim", memberTraditionalCommunityQuestionId, memberTraditionalCommunitySubQuestionId, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Agroextrativistas", memberTraditionalCommunitySubQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Caatingueiros", memberTraditionalCommunitySubQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Caiçaras", memberTraditionalCommunitySubQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Cerrado", memberTraditionalCommunitySubQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Ciganos", memberTraditionalCommunitySubQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Comunidades de fundo e fecho de pasto", memberTraditionalCommunitySubQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Extrativistas", memberTraditionalCommunitySubQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Faxinalenses", memberTraditionalCommunitySubQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Geraizeiros", memberTraditionalCommunitySubQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Marisqueiros", memberTraditionalCommunitySubQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Pantaneiros", memberTraditionalCommunitySubQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Pescadores artesanais", memberTraditionalCommunitySubQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Pomeranos", memberTraditionalCommunitySubQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Povos indígenas", memberTraditionalCommunitySubQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Povos quilombolas", memberTraditionalCommunitySubQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Quebradeiras de coco babaçu", memberTraditionalCommunitySubQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Retireiros", memberTraditionalCommunitySubQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Ribeirinhos", memberTraditionalCommunitySubQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Seringueiros", memberTraditionalCommunitySubQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Povos de terreiro/Matriz africana", memberTraditionalCommunitySubQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Vazanteiros", memberTraditionalCommunitySubQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Outros", memberTraditionalCommunitySubQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Acampada", memberTraditionalCommunitySubQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Andirobeiras", memberTraditionalCommunitySubQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Apátridas", memberTraditionalCommunitySubQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Assentada", memberTraditionalCommunitySubQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Camponeses", memberTraditionalCommunitySubQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Castanheiras", memberTraditionalCommunitySubQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Catadores de mangaba", memberTraditionalCommunitySubQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Isqueiros", memberTraditionalCommunitySubQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Jangadeiros", memberTraditionalCommunitySubQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Migrantes", memberTraditionalCommunitySubQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Morroquianos", memberTraditionalCommunitySubQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "População circense", memberTraditionalCommunitySubQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Refugiados", memberTraditionalCommunitySubQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Trabalhadores rurais assalariados", memberTraditionalCommunitySubQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Trabalhadores rurais temporários", memberTraditionalCommunitySubQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Varjeiros", memberTraditionalCommunitySubQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            var sexualOrientationQuestionId = Guid.NewGuid();

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "Name", "ResponseType", "Mandatory", "FormId", "AddedDate", "ModifiedDate", "Ativo", "Order" },
                values: new object[] { sexualOrientationQuestionId, "Deseja informar orientação sexual", (int)EQuestionType.RADIO, true, formPersonInfDemoId, new DateTime(2023, 08, 05), DateTime.MinValue, true, 9 });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Não", sexualOrientationQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            var sexualOrientationSubQuestionId = Guid.NewGuid();

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "Name", "ResponseType", "Mandatory", "FormId", "AddedDate", "ModifiedDate", "Ativo", "Order" },
                values: new object[] { sexualOrientationSubQuestionId, "Qual?", (int)EQuestionType.DROPLIST, true, null, new DateTime(2023, 08, 05), DateTime.MinValue, true, 0 });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Sim", sexualOrientationQuestionId, sexualOrientationSubQuestionId, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Heterossexual", sexualOrientationSubQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Homossexual(gay/lésbica)", sexualOrientationSubQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Bissexual", sexualOrientationSubQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Outro", sexualOrientationSubQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            var genderIdentityQuestionId = Guid.NewGuid();

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "Name", "ResponseType", "Mandatory", "FormId", "AddedDate", "ModifiedDate", "Ativo", "Order" },
                values: new object[] { genderIdentityQuestionId, "Deseja informar orientação sexual", (int)EQuestionType.RADIO, true, formPersonInfDemoId, new DateTime(2023, 08, 05), DateTime.MinValue, true, 10 });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Não", genderIdentityQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            var genderIdentitySubQuestionId = Guid.NewGuid();

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "Name", "ResponseType", "Mandatory", "FormId", "AddedDate", "ModifiedDate", "Ativo", "Order" },
                values: new object[] { genderIdentitySubQuestionId, "Qual?", (int)EQuestionType.DROPLIST, true, null, new DateTime(2023, 08, 05), DateTime.MinValue, true, 0 });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Sim", genderIdentityQuestionId, genderIdentitySubQuestionId, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Homem Transexual", genderIdentitySubQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Mulher Transexual", genderIdentitySubQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Travesti", genderIdentitySubQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Outro", genderIdentitySubQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            var hasDeficiencyQuestionId = Guid.NewGuid();

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "Name", "ResponseType", "Mandatory", "FormId", "AddedDate", "ModifiedDate", "Ativo", "Order" },
                values: new object[] { hasDeficiencyQuestionId, "Tem alguma deficiência", (int)EQuestionType.RADIO, true, formPersonInfDemoId, new DateTime(2023, 08, 05), DateTime.MinValue, true, 11 });

            var hasDeficiencySubQuestionId = Guid.NewGuid();

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Não", hasDeficiencyQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "Name", "ResponseType", "Mandatory", "FormId", "AddedDate", "ModifiedDate", "Ativo", "Order" },
                values: new object[] { hasDeficiencySubQuestionId, "Qual(is)?", (int)EQuestionType.CHECKLIST, true, null, new DateTime(2023, 08, 05), DateTime.MinValue, true, 0 });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Sim", hasDeficiencyQuestionId, hasDeficiencySubQuestionId, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Auditiva", hasDeficiencySubQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Visual", hasDeficiencySubQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Física", hasDeficiencySubQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Intelectual/Cognitiva", hasDeficiencySubQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Outra", hasDeficiencySubQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            var formPersonHealthConditionId = Guid.NewGuid();

            migrationBuilder.InsertData(
                table: "Form",
                columns: new[] { "Id", "Slug", "Title", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { formPersonHealthConditionId, "PersonHealthCondition", "Condições de saúde", new DateTime(2023, 08, 05), DateTime.MinValue, true });

            var weightQuestionId = Guid.NewGuid();

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "Name", "ResponseType", "Mandatory", "FormId", "AddedDate", "ModifiedDate", "Ativo", "Order" },
                values: new object[] { weightQuestionId, "Sobre seu peso, você se considera", (int)EQuestionType.DROPLIST, true, formPersonHealthConditionId, new DateTime(2023, 08, 05), DateTime.MinValue, true, 1 });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Abaixo do peso", weightQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Peso adequado", weightQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Acima do peso", weightQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            var smokeQuestionId = Guid.NewGuid();

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "Name", "ResponseType", "Mandatory", "FormId", "AddedDate", "ModifiedDate", "Ativo", "Order" },
                values: new object[] { smokeQuestionId, "É fumante", (int)EQuestionType.RADIO, true, formPersonHealthConditionId, new DateTime(2023, 08, 05), DateTime.MinValue, true, 2 });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Sim", smokeQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Não", smokeQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            var alcoholicQuestionId = Guid.NewGuid();

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "Name", "ResponseType", "Mandatory", "FormId", "AddedDate", "ModifiedDate", "Ativo", "Order" },
                values: new object[] { alcoholicQuestionId, "Faz uso de bebidas alcoólicas", (int)EQuestionType.RADIO, true, formPersonHealthConditionId, new DateTime(2023, 08, 05), DateTime.MinValue, true, 3 });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Sim", alcoholicQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Não", alcoholicQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            var drugsQuestionId = Guid.NewGuid();

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "Name", "ResponseType", "Mandatory", "FormId", "AddedDate", "ModifiedDate", "Ativo", "Order" },
                values: new object[] { drugsQuestionId, "Faz uso de outras drogas", (int)EQuestionType.RADIO, true, formPersonHealthConditionId, new DateTime(2023, 08, 05), DateTime.MinValue, true, 4 });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Sim", drugsQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Não", drugsQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            var arterialHypertensionQuestionId = Guid.NewGuid();

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "Name", "ResponseType", "Mandatory", "FormId", "AddedDate", "ModifiedDate", "Ativo", "Order" },
                values: new object[] { arterialHypertensionQuestionId, "Tem hipertensão arterial", (int)EQuestionType.RADIO, true, formPersonHealthConditionId, new DateTime(2023, 08, 05), DateTime.MinValue, true, 5 });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Sim", arterialHypertensionQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Não", arterialHypertensionQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            var diabetesQuestionId = Guid.NewGuid();

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "Name", "ResponseType", "Mandatory", "FormId", "AddedDate", "ModifiedDate", "Ativo", "Order" },
                values: new object[] { diabetesQuestionId, "Tem diabetes", (int)EQuestionType.RADIO, true, formPersonHealthConditionId, new DateTime(2023, 08, 05), DateTime.MinValue, true, 6 });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Sim", diabetesQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Não", diabetesQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            var avcQuestionId = Guid.NewGuid();

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "Name", "ResponseType", "Mandatory", "FormId", "AddedDate", "ModifiedDate", "Ativo", "Order" },
                values: new object[] { avcQuestionId, "Teve AVC/Derrame", (int)EQuestionType.RADIO, true, formPersonHealthConditionId, new DateTime(2023, 08, 05), DateTime.MinValue, true, 7 });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Sim", avcQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Não", avcQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            var heartAttackQuestionId = Guid.NewGuid();

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "Name", "ResponseType", "Mandatory", "FormId", "AddedDate", "ModifiedDate", "Ativo", "Order" },
                values: new object[] { heartAttackQuestionId, "Teve infarto", (int)EQuestionType.RADIO, true, formPersonHealthConditionId, new DateTime(2023, 08, 05), DateTime.MinValue, true, 8 });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Sim", heartAttackQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Não", heartAttackQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            var heartDiseaseQuestionId = Guid.NewGuid();

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "Name", "ResponseType", "Mandatory", "FormId", "AddedDate", "ModifiedDate", "Ativo", "Order" },
                values: new object[] { heartDiseaseQuestionId, "Tem doença cardíaca/coração", (int)EQuestionType.RADIO, true, formPersonHealthConditionId, new DateTime(2023, 08, 05), DateTime.MinValue, true, 9 });

            var heartDiseaseSubQuestionId = Guid.NewGuid();

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "Name", "ResponseType", "Mandatory", "FormId", "AddedDate", "ModifiedDate", "Ativo", "Order" },
                values: new object[] { heartDiseaseSubQuestionId, "Qual(is)?", (int)EQuestionType.CHECKLIST, true, null, new DateTime(2023, 08, 05), DateTime.MinValue, true, 0 });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Sim", heartDiseaseQuestionId, heartDiseaseSubQuestionId, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Não", heartDiseaseQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Insificiência cardíaca", heartDiseaseSubQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Não sabe", heartDiseaseSubQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Outro", heartDiseaseSubQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            var kidneyProblemQuestionId = Guid.NewGuid();

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "Name", "ResponseType", "Mandatory", "FormId", "AddedDate", "ModifiedDate", "Ativo", "Order" },
                values: new object[] { kidneyProblemQuestionId, "Tem ou teve problemas nos rins", (int)EQuestionType.RADIO, true, formPersonHealthConditionId, new DateTime(2023, 08, 05), DateTime.MinValue, true, 10 });

            var kidneyProblemSubQuestionId = Guid.NewGuid();

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "Name", "ResponseType", "Mandatory", "FormId", "AddedDate", "ModifiedDate", "Ativo", "Order" },
                values: new object[] { kidneyProblemSubQuestionId, "Qual(is)?", (int)EQuestionType.CHECKLIST, true, null, new DateTime(2023, 08, 05), DateTime.MinValue, true, 0 });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Sim", kidneyProblemQuestionId, kidneyProblemSubQuestionId, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Não", kidneyProblemQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Insificiência renal", kidneyProblemSubQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Não sabe", kidneyProblemSubQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Outro", kidneyProblemSubQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            var respiratoryDiseaseQuestionId = Guid.NewGuid();

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "Name", "ResponseType", "Mandatory", "FormId", "AddedDate", "ModifiedDate", "Ativo", "Order" },
                values: new object[] { respiratoryDiseaseQuestionId, "Tem doença respiratória/no pulmão", (int)EQuestionType.RADIO, true, formPersonHealthConditionId, new DateTime(2023, 08, 05), DateTime.MinValue, true, 11 });

            var respiratoryDiseaseSubQuestionId = Guid.NewGuid();

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "Name", "ResponseType", "Mandatory", "FormId", "AddedDate", "ModifiedDate", "Ativo", "Order" },
                values: new object[] { respiratoryDiseaseSubQuestionId, "Qual(is)?", (int)EQuestionType.CHECKLIST, true, null, new DateTime(2023, 08, 05), DateTime.MinValue, true, 0 });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Sim", respiratoryDiseaseQuestionId, respiratoryDiseaseSubQuestionId, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Não", respiratoryDiseaseQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Asma", respiratoryDiseaseSubQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "DPOC/Enfisema", respiratoryDiseaseSubQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Não sabe", respiratoryDiseaseSubQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Outro", respiratoryDiseaseSubQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            var leprosyQuestionId = Guid.NewGuid();

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "Name", "ResponseType", "Mandatory", "FormId", "AddedDate", "ModifiedDate", "Ativo", "Order" },
                values: new object[] { leprosyQuestionId, "Está com hanseníase", (int)EQuestionType.RADIO, true, formPersonHealthConditionId, new DateTime(2023, 08, 05), DateTime.MinValue, true, 12 });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Sim", leprosyQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Não", leprosyQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            var tuberculosisQuestionId = Guid.NewGuid();

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "Name", "ResponseType", "Mandatory", "FormId", "AddedDate", "ModifiedDate", "Ativo", "Order" },
                values: new object[] { tuberculosisQuestionId, "Está com tuberculose", (int)EQuestionType.RADIO, true, formPersonHealthConditionId, new DateTime(2023, 08, 05), DateTime.MinValue, true, 13 });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Sim", tuberculosisQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Não", tuberculosisQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            var cancerQuestionId = Guid.NewGuid();

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "Name", "ResponseType", "Mandatory", "FormId", "AddedDate", "ModifiedDate", "Ativo", "Order" },
                values: new object[] { cancerQuestionId, "Tem ou teve câncer", (int)EQuestionType.RADIO, true, formPersonHealthConditionId, new DateTime(2023, 08, 05), DateTime.MinValue, true, 14 });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Sim", cancerQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Não", cancerQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            var hospitalizationQuestionId = Guid.NewGuid();

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "Name", "ResponseType", "Mandatory", "FormId", "AddedDate", "ModifiedDate", "Ativo", "Order" },
                values: new object[] { hospitalizationQuestionId, "Teve alguma internação nos últimos 12 meses", (int)EQuestionType.RADIO, true, formPersonHealthConditionId, new DateTime(2023, 08, 05), DateTime.MinValue, true, 15 });

            var hospitalizationSubQuestionId = Guid.NewGuid();

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "Name", "ResponseType", "Mandatory", "FormId", "AddedDate", "ModifiedDate", "Ativo", "Order" },
                values: new object[] { hospitalizationSubQuestionId, "Qual a causa?", (int)EQuestionType.STRING, true, null, new DateTime(2023, 08, 05), DateTime.MinValue, true, 0 });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Sim", hospitalizationQuestionId, hospitalizationSubQuestionId, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Não", hospitalizationQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            var mentalHealthDiagnosisQuestionId = Guid.NewGuid();

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "Name", "ResponseType", "Mandatory", "FormId", "AddedDate", "ModifiedDate", "Ativo", "Order" },
                values: new object[] { mentalHealthDiagnosisQuestionId, "Teve diagnóstico de algum problema de saúde mental por profissional de saúde", (int)EQuestionType.RADIO, true, formPersonHealthConditionId, new DateTime(2023, 08, 05), DateTime.MinValue, true, 16 });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Sim", mentalHealthDiagnosisQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Não", mentalHealthDiagnosisQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            var hasBedriddenQuestionId = Guid.NewGuid();

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "Name", "ResponseType", "Mandatory", "FormId", "AddedDate", "ModifiedDate", "Ativo", "Order" },
                values: new object[] { hasBedriddenQuestionId, "Está acamado", (int)EQuestionType.RADIO, true, formPersonHealthConditionId, new DateTime(2023, 08, 05), DateTime.MinValue, true, 17 });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Sim", hasBedriddenQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Não", hasBedriddenQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            var hasDomiciledQuestionId = Guid.NewGuid();

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "Name", "ResponseType", "Mandatory", "FormId", "AddedDate", "ModifiedDate", "Ativo", "Order" },
                values: new object[] { hasDomiciledQuestionId, "Está domiciliado", (int)EQuestionType.RADIO, true, formPersonHealthConditionId, new DateTime(2023, 08, 05), DateTime.MinValue, true, 18 });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Sim", hasDomiciledQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Não", hasDomiciledQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            var useMedicinalPlantQuestionId = Guid.NewGuid();

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "Name", "ResponseType", "Mandatory", "FormId", "AddedDate", "ModifiedDate", "Ativo", "Order" },
                values: new object[] { useMedicinalPlantQuestionId, "Usa plantas medicinais", (int)EQuestionType.RADIO, true, formPersonHealthConditionId, new DateTime(2023, 08, 05), DateTime.MinValue, true, 19 });

            var useMedicinalPlantSubQuestionId = Guid.NewGuid();

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "Name", "ResponseType", "Mandatory", "FormId", "AddedDate", "ModifiedDate", "Ativo", "Order" },
                values: new object[] { useMedicinalPlantSubQuestionId, "Qual(is)", (int)EQuestionType.STRING, true, null, new DateTime(2023, 08, 05), DateTime.MinValue, true, 0 });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Sim", useMedicinalPlantQuestionId, useMedicinalPlantSubQuestionId, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Não", useMedicinalPlantQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            var otherPratictQuestionId = Guid.NewGuid();

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "Name", "ResponseType", "Mandatory", "FormId", "AddedDate", "ModifiedDate", "Ativo", "Order" },
                values: new object[] { otherPratictQuestionId, "Usa outras práticas integrativas e complmentares", (int)EQuestionType.RADIO, true, formPersonHealthConditionId, new DateTime(2023, 08, 05), DateTime.MinValue, true, 20 });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Sim", otherPratictQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Não", otherPratictQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "Name", "ResponseType", "Mandatory", "FormId", "AddedDate", "ModifiedDate", "Ativo", "Order" },
                values: new object[] { Guid.NewGuid(), "Outras condições de saúde", (int)EQuestionType.STRING, true, formPersonHealthConditionId, new DateTime(2023, 08, 05), DateTime.MinValue, true, 21 });

            var streetSituationQuestionId = Guid.NewGuid();

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "Name", "ResponseType", "Mandatory", "FormId", "AddedDate", "ModifiedDate", "Ativo", "Order" },
                values: new object[] { streetSituationQuestionId, "Usa outras práticas integrativas e complmentares", (int)EQuestionType.RADIO, true, formPersonHealthConditionId, new DateTime(2023, 08, 05), DateTime.MinValue, true, 22 });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Sim", streetSituationQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Não", streetSituationQuestionId, null, new DateTime(2023, 08, 05), DateTime.MinValue, true });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"DELETE FROM dbo.OtherQuestion WHERE AddedDate = {new DateTime(2023, 08, 05)}");
            migrationBuilder.Sql($"DELETE FROM dbo.Question WHERE AddedDate = {new DateTime(2023, 08, 05)}");
            migrationBuilder.Sql($"DELETE FROM dbo.Form WHERE AddedDate = {new DateTime(2023, 08, 05)}");
        }
    }
}
