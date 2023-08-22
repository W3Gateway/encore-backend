using Encore.Domain.Enum;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Encore.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedFormHomeAddressQuestions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var formHomeAddressId = Guid.NewGuid();

            migrationBuilder.InsertData(
                table: "Form",
                columns: new[] { "Id", "Slug", "Title", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { formHomeAddressId, "HomeAddress", "Endereço", new DateTime(2023, 08, 07), DateTime.MinValue, true });

            var immobileTypeId = Guid.NewGuid();

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "Name", "ResponseType", "Mandatory", "FormId", "AddedDate", "ModifiedDate", "Ativo", "Order" },
                values: new object[] { immobileTypeId, "Tipo de Imóvel", (int)EQuestionType.DROPLIST, true, formHomeAddressId, new DateTime(2023, 08, 07), DateTime.MinValue, true, 1 });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Domicílio", immobileTypeId, null, new DateTime(2023, 08, 07), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Comércio", immobileTypeId, null, new DateTime(2023, 08, 07), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Terreno baldio", immobileTypeId, null, new DateTime(2023, 08, 07), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Ponto estratégico", immobileTypeId, null, new DateTime(2023, 08, 07), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Escola", immobileTypeId, null, new DateTime(2023, 08, 07), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Creche", immobileTypeId, null, new DateTime(2023, 08, 07), DateTime.MinValue, true });
            
            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Abrigo", immobileTypeId, null, new DateTime(2023, 08, 07), DateTime.MinValue, true });
            
            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Instituição de longa permanência para idosos", immobileTypeId, null, new DateTime(2023, 08, 07), DateTime.MinValue, true });
            
            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Unidade prisional", immobileTypeId, null, new DateTime(2023, 08, 07), DateTime.MinValue, true });
            
            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Unidade de medida sócio educativa", immobileTypeId, null, new DateTime(2023, 08, 07), DateTime.MinValue, true });
    
            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Delegacia", immobileTypeId, null, new DateTime(2023, 08, 07), DateTime.MinValue, true });
            
            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Estabelecimento religioso", immobileTypeId, null, new DateTime(2023, 08, 07), DateTime.MinValue, true });
            
            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Outros", immobileTypeId, null, new DateTime(2023, 08, 07), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "Name", "ResponseType", "Mandatory", "FormId", "AddedDate", "ModifiedDate", "Ativo", "Order" },
                values: new object[] { Guid.NewGuid(), "Microregião", (int)EQuestionType.STRING, true, formHomeAddressId, new DateTime(2023, 08, 07), DateTime.MinValue, true, 2 });

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "Name", "ResponseType", "Mandatory", "FormId", "AddedDate", "ModifiedDate", "Ativo", "Order" },
                values: new object[] { Guid.NewGuid(), "CEP", (int)EQuestionType.STRING, true, formHomeAddressId, new DateTime(2023, 08, 07), DateTime.MinValue, true, 3 });

            var publicPlaceQuestionId = Guid.NewGuid();

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "Name", "ResponseType", "Mandatory", "FormId", "AddedDate", "ModifiedDate", "Ativo", "Order" },
                values: new object[] { publicPlaceQuestionId, "Logradouro", (int)EQuestionType.DROPLIST, true, formHomeAddressId, new DateTime(2023, 08, 07), DateTime.MinValue, true, 4 });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Avenida", publicPlaceQuestionId, null, new DateTime(2023, 08, 07), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Rua", publicPlaceQuestionId, null, new DateTime(2023, 08, 07), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Via", publicPlaceQuestionId, null, new DateTime(2023, 08, 07), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Rodovia", publicPlaceQuestionId, null, new DateTime(2023, 08, 07), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Vila", publicPlaceQuestionId, null, new DateTime(2023, 08, 07), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Alameda", publicPlaceQuestionId, null, new DateTime(2023, 08, 07), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Campo", publicPlaceQuestionId, null, new DateTime(2023, 08, 07), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Chácara", publicPlaceQuestionId, null, new DateTime(2023, 08, 07), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Colônia", publicPlaceQuestionId, null, new DateTime(2023, 08, 07), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Condomínio", publicPlaceQuestionId, null, new DateTime(2023, 08, 07), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Conjunto", publicPlaceQuestionId, null, new DateTime(2023, 08, 07), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Distrito", publicPlaceQuestionId, null, new DateTime(2023, 08, 07), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Esplanada", publicPlaceQuestionId, null, new DateTime(2023, 08, 07), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Estação", publicPlaceQuestionId, null, new DateTime(2023, 08, 07), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Estrada", publicPlaceQuestionId, null, new DateTime(2023, 08, 07), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Favela", publicPlaceQuestionId, null, new DateTime(2023, 08, 07), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Fazenda", publicPlaceQuestionId, null, new DateTime(2023, 08, 07), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Ladeira", publicPlaceQuestionId, null, new DateTime(2023, 08, 07), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Loteamento", publicPlaceQuestionId, null, new DateTime(2023, 08, 07), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Morro", publicPlaceQuestionId, null, new DateTime(2023, 08, 07), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Núcleo", publicPlaceQuestionId, null, new DateTime(2023, 08, 07), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Parque", publicPlaceQuestionId, null, new DateTime(2023, 08, 07), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Passarela", publicPlaceQuestionId, null, new DateTime(2023, 08, 07), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Praça", publicPlaceQuestionId, null, new DateTime(2023, 08, 07), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Quadra", publicPlaceQuestionId, null, new DateTime(2023, 08, 07), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Recanto", publicPlaceQuestionId, null, new DateTime(2023, 08, 07), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Residencial", publicPlaceQuestionId, null, new DateTime(2023, 08, 07), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Setor", publicPlaceQuestionId, null, new DateTime(2023, 08, 07), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Sítio", publicPlaceQuestionId, null, new DateTime(2023, 08, 07), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Travessa", publicPlaceQuestionId, null, new DateTime(2023, 08, 07), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Trecho", publicPlaceQuestionId, null, new DateTime(2023, 08, 07), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Trevo", publicPlaceQuestionId, null, new DateTime(2023, 08, 07), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Vale", publicPlaceQuestionId, null, new DateTime(2023, 08, 07), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Viaduto", publicPlaceQuestionId, null, new DateTime(2023, 08, 07), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "OtherQuestion",
                columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
                values: new object[] { Guid.NewGuid(), "Viela", publicPlaceQuestionId, null, new DateTime(2023, 08, 07), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "Name", "ResponseType", "Mandatory", "FormId", "AddedDate", "ModifiedDate", "Ativo", "Order" },
                values: new object[] { Guid.NewGuid(), "Nome do logradouro", (int)EQuestionType.STRING, true, formHomeAddressId, new DateTime(2023, 08, 07), DateTime.MinValue, true, 5 });

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "Name", "ResponseType", "Mandatory", "FormId", "AddedDate", "ModifiedDate", "Ativo", "Order" },
                values: new object[] { Guid.NewGuid(), "Número", (int)EQuestionType.STRING, true, formHomeAddressId, new DateTime(2023, 08, 07), DateTime.MinValue, true, 6 });

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "Name", "ResponseType", "Mandatory", "FormId", "AddedDate", "ModifiedDate", "Ativo", "Order" },
                values: new object[] { Guid.NewGuid(), "Bairro", (int)EQuestionType.STRING, true, formHomeAddressId, new DateTime(2023, 08, 07), DateTime.MinValue, true, 7 });

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "Name", "ResponseType", "Mandatory", "FormId", "AddedDate", "ModifiedDate", "Ativo", "Order" },
                values: new object[] { Guid.NewGuid(), "Município", (int)EQuestionType.STRING, true, formHomeAddressId, new DateTime(2023, 08, 07), DateTime.MinValue, true, 8 });

            var stateQuestionId = Guid.NewGuid();

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "Name", "ResponseType", "Mandatory", "FormId", "AddedDate", "ModifiedDate", "Ativo", "Order" },
                values: new object[] { stateQuestionId, "Estado", (int)EQuestionType.DROPLIST, true, formHomeAddressId, new DateTime(2023, 08, 07), DateTime.MinValue, true, 9 });

            migrationBuilder.InsertData(
               table: "OtherQuestion",
               columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
               values: new object[] { Guid.NewGuid(), "Acre", stateQuestionId, null, new DateTime(2023, 08, 07), DateTime.MinValue, true });

            migrationBuilder.InsertData(
               table: "OtherQuestion",
               columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
               values: new object[] { Guid.NewGuid(), "Alagoas", stateQuestionId, null, new DateTime(2023, 08, 07), DateTime.MinValue, true });

            migrationBuilder.InsertData(
               table: "OtherQuestion",
               columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
               values: new object[] { Guid.NewGuid(), "Amapá", stateQuestionId, null, new DateTime(2023, 08, 07), DateTime.MinValue, true });

            migrationBuilder.InsertData(
               table: "OtherQuestion",
               columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
               values: new object[] { Guid.NewGuid(), "Amazonas", stateQuestionId, null, new DateTime(2023, 08, 07), DateTime.MinValue, true });

            migrationBuilder.InsertData(
               table: "OtherQuestion",
               columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
               values: new object[] { Guid.NewGuid(), "Bahia", stateQuestionId, null, new DateTime(2023, 08, 07), DateTime.MinValue, true });

            migrationBuilder.InsertData(
               table: "OtherQuestion",
               columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
               values: new object[] { Guid.NewGuid(), "Ceará", stateQuestionId, null, new DateTime(2023, 08, 07), DateTime.MinValue, true });

            migrationBuilder.InsertData(
               table: "OtherQuestion",
               columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
               values: new object[] { Guid.NewGuid(), "Distrito Federal", stateQuestionId, null, new DateTime(2023, 08, 07), DateTime.MinValue, true });

            migrationBuilder.InsertData(
               table: "OtherQuestion",
               columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
               values: new object[] { Guid.NewGuid(), "Espírito Santo", stateQuestionId, null, new DateTime(2023, 08, 07), DateTime.MinValue, true });

            migrationBuilder.InsertData(
               table: "OtherQuestion",
               columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
               values: new object[] { Guid.NewGuid(), "Goiás", stateQuestionId, null, new DateTime(2023, 08, 07), DateTime.MinValue, true });

            migrationBuilder.InsertData(
               table: "OtherQuestion",
               columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
               values: new object[] { Guid.NewGuid(), "Maranhão", stateQuestionId, null, new DateTime(2023, 08, 07), DateTime.MinValue, true });

            migrationBuilder.InsertData(
               table: "OtherQuestion",
               columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
               values: new object[] { Guid.NewGuid(), "Mato Grosso", stateQuestionId, null, new DateTime(2023, 08, 07), DateTime.MinValue, true });

            migrationBuilder.InsertData(
               table: "OtherQuestion",
               columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
               values: new object[] { Guid.NewGuid(), "Mato Grosso do Sul", stateQuestionId, null, new DateTime(2023, 08, 07), DateTime.MinValue, true });

            migrationBuilder.InsertData(
               table: "OtherQuestion",
               columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
               values: new object[] { Guid.NewGuid(), "Minas Gerais", stateQuestionId, null, new DateTime(2023, 08, 07), DateTime.MinValue, true });

            migrationBuilder.InsertData(
               table: "OtherQuestion",
               columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
               values: new object[] { Guid.NewGuid(), "Pará", stateQuestionId, null, new DateTime(2023, 08, 07), DateTime.MinValue, true });

            migrationBuilder.InsertData(
               table: "OtherQuestion",
               columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
               values: new object[] { Guid.NewGuid(), "Paraíba", stateQuestionId, null, new DateTime(2023, 08, 07), DateTime.MinValue, true });

            migrationBuilder.InsertData(
               table: "OtherQuestion",
               columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
               values: new object[] { Guid.NewGuid(), "Paraná", stateQuestionId, null, new DateTime(2023, 08, 07), DateTime.MinValue, true });

            migrationBuilder.InsertData(
               table: "OtherQuestion",
               columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
               values: new object[] { Guid.NewGuid(), "Pernambuco", stateQuestionId, null, new DateTime(2023, 08, 07), DateTime.MinValue, true });

            migrationBuilder.InsertData(
               table: "OtherQuestion",
               columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
               values: new object[] { Guid.NewGuid(), "Piauí", stateQuestionId, null, new DateTime(2023, 08, 07), DateTime.MinValue, true });

            migrationBuilder.InsertData(
               table: "OtherQuestion",
               columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
               values: new object[] { Guid.NewGuid(), "Rio de Janeiro", stateQuestionId, null, new DateTime(2023, 08, 07), DateTime.MinValue, true });

            migrationBuilder.InsertData(
               table: "OtherQuestion",
               columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
               values: new object[] { Guid.NewGuid(), "Rio Grande do Norte", stateQuestionId, null, new DateTime(2023, 08, 07), DateTime.MinValue, true });

            migrationBuilder.InsertData(
               table: "OtherQuestion",
               columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
               values: new object[] { Guid.NewGuid(), "Rio Grande do Sul", stateQuestionId, null, new DateTime(2023, 08, 07), DateTime.MinValue, true });

            migrationBuilder.InsertData(
               table: "OtherQuestion",
               columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
               values: new object[] { Guid.NewGuid(), "Rondônia", stateQuestionId, null, new DateTime(2023, 08, 07), DateTime.MinValue, true });

            migrationBuilder.InsertData(
               table: "OtherQuestion",
               columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
               values: new object[] { Guid.NewGuid(), "Roraima", stateQuestionId, null, new DateTime(2023, 08, 07), DateTime.MinValue, true });

            migrationBuilder.InsertData(
               table: "OtherQuestion",
               columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
               values: new object[] { Guid.NewGuid(), "Santa Catarina", stateQuestionId, null, new DateTime(2023, 08, 07), DateTime.MinValue, true });

            migrationBuilder.InsertData(
               table: "OtherQuestion",
               columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
               values: new object[] { Guid.NewGuid(), "São Paulo", stateQuestionId, null, new DateTime(2023, 08, 07), DateTime.MinValue, true });

            migrationBuilder.InsertData(
               table: "OtherQuestion",
               columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
               values: new object[] { Guid.NewGuid(), "Sergipe", stateQuestionId, null, new DateTime(2023, 08, 07), DateTime.MinValue, true });

            migrationBuilder.InsertData(
               table: "OtherQuestion",
               columns: new[] { "Id", "Name", "QuestionId", "SubQuestionId", "AddedDate", "ModifiedDate", "Ativo" },
               values: new object[] { Guid.NewGuid(), "Tocantins", stateQuestionId, null, new DateTime(2023, 08, 07), DateTime.MinValue, true });

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "Name", "ResponseType", "Mandatory", "FormId", "AddedDate", "ModifiedDate", "Ativo", "Order" },
                values: new object[] { Guid.NewGuid(), "Complemento", (int)EQuestionType.STRING, false, formHomeAddressId, new DateTime(2023, 08, 07), DateTime.MinValue, true, 10 });

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "Name", "ResponseType", "Mandatory", "FormId", "AddedDate", "ModifiedDate", "Ativo", "Order" },
                values: new object[] { Guid.NewGuid(), "Ponto de referência", (int)EQuestionType.STRING, false, formHomeAddressId, new DateTime(2023, 08, 07), DateTime.MinValue, true, 11 });

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "Name", "ResponseType", "Mandatory", "FormId", "AddedDate", "ModifiedDate", "Ativo", "Order" },
                values: new object[] { Guid.NewGuid(), "Telefone residencial", (int)EQuestionType.STRING, false, formHomeAddressId, new DateTime(2023, 08, 07), DateTime.MinValue, true, 12 });

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "Name", "ResponseType", "Mandatory", "FormId", "AddedDate", "ModifiedDate", "Ativo", "Order" },
                values: new object[] { Guid.NewGuid(), "Telefone contato", (int)EQuestionType.STRING, false, formHomeAddressId, new DateTime(2023, 08, 07), DateTime.MinValue, true, 13 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"DELETE FROM dbo.OtherQuestion WHERE AddedDate = {new DateTime(2023, 08, 07)}");
            migrationBuilder.Sql($"DELETE FROM dbo.Question WHERE AddedDate = {new DateTime(2023, 08, 07)}");
            migrationBuilder.Sql($"DELETE FROM dbo.Form WHERE AddedDate = {new DateTime(2023, 08, 07)}");
        }
    }
}
