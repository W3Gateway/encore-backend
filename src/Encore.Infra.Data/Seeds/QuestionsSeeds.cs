using Encore.Domain.Enum;
using Encore.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Encore.Infra.Data.Seeds
{
    public static class QuestionsSeeds
    {
        public static void CreateSeedQuestion(ModelBuilder modelBuilder)
        {
            var listQuestions = new List<Question>()
            {
                    new Question("Visita compatilhada com outro profissional",
                                responseType: (int)EQuestionType.RADIO,
                                mandatory: false,
                                new DateTime(2023, 07, 25)),
                    new Question("Motivo da visita",
                                responseType: (int)EQuestionType.CHECKLIST,
                                mandatory: false,
                                new DateTime(2023, 07, 25)),
                    new Question("Busca ativa",
                                responseType: (int)EQuestionType.CHECKLIST,
                                mandatory: false,
                                new DateTime(2023, 07, 25)),
                    new Question("Acompanhamento",
                                responseType: (int)EQuestionType.CHECKLIST,
                                mandatory: false,
                                new DateTime(2023, 07, 25)),
                    new Question("Controle ambiental/vetorial",
                                responseType: (int)EQuestionType.CHECKLIST,
                                mandatory: false,
                                new DateTime(2023, 07, 25)),
                    new Question("Altura(cm)",
                                responseType: (int)EQuestionType.NUMERIC,
                                mandatory: false,
                                new DateTime(2023, 07, 25)),
                    new Question("Peso(kg)",
                                responseType: (int)EQuestionType.NUMERIC,
                                mandatory: false,
                                new DateTime(2023, 07, 25)),
                    new Question("Desfecho",
                                responseType: (int)EQuestionType.CHECKLIST,
                                mandatory: false,
                                new DateTime(2023, 07, 25))
            };

            modelBuilder.Entity<Question>().HasData(listQuestions);

            var listOtherQuestions = new List<OtherQuestion>()
            {
                new OtherQuestion(
                        name: "Sim",
                        questionId: listQuestions.First(x => x.Name.Equals("Visita compatilhada com outro profissional")).Id,
                        addedData: new DateTime(2023,07,25)
                    ),
                new OtherQuestion(
                        name: "Não",
                        questionId: listQuestions.First(x => x.Name.Equals("Visita compatilhada com outro profissional")).Id,
                        addedData: new DateTime(2023,07,25)
                    ),
                new OtherQuestion(
                        name: "Cadastramento/Atualização",
                        questionId: listQuestions.First(x => x.Name.Equals("Motivo da visita")).Id,
                        addedData: new DateTime(2023,07,25)
                    ),
                new OtherQuestion(
                        name: "Visita periódica",
                        questionId: listQuestions.First(x => x.Name.Equals("Motivo da visita")).Id,
                        addedData: new DateTime(2023,07,25)
                    ),
                new OtherQuestion(
                        name: "Egresso de internação",
                        questionId: listQuestions.First(x => x.Name.Equals("Motivo da visita")).Id,
                        addedData: new DateTime(2023,07,25)
                    ),
                new OtherQuestion(
                        name: "Convite para atividades coletivas/campanha de saúde",
                        questionId: listQuestions.First(x => x.Name.Equals("Motivo da visita")).Id,
                        addedData: new DateTime(2023,07,25)
                    ),
                new OtherQuestion(
                        name: "Orientação/Prevenção",
                        questionId: listQuestions.First(x => x.Name.Equals("Motivo da visita")).Id,
                        addedData: new DateTime(2023,07,25)
                    ),
                new OtherQuestion(
                        name: "Outros",
                        questionId: listQuestions.First(x => x.Name.Equals("Motivo da visita")).Id,
                        addedData: new DateTime(2023,07,25)
                    ),
                new OtherQuestion(
                        name: "Consulta",
                        questionId: listQuestions.First(x => x.Name.Equals("Busca ativa")).Id,
                        addedData: new DateTime(2023,07,25)
                    ),
                new OtherQuestion(
                        name: "Exame",
                        questionId: listQuestions.First(x => x.Name.Equals("Busca ativa")).Id,
                        addedData: new DateTime(2023,07,25)
                    ),
                new OtherQuestion(
                        name: "Vacina",
                        questionId: listQuestions.First(x => x.Name.Equals("Busca ativa")).Id,
                        addedData: new DateTime(2023,07,25)
                    ),
                new OtherQuestion(
                        name: "Condicionalidades do bolsa família",
                        questionId: listQuestions.First(x => x.Name.Equals("Busca ativa")).Id,
                        addedData: new DateTime(2023,07,25)
                    ),
                new OtherQuestion(
                        name: "Gestante",
                        questionId: listQuestions.First(x => x.Name.Equals("Acompanhamento")).Id,
                        addedData: new DateTime(2023,07,25)
                    ),
                new OtherQuestion(
                        name: "Puérpera",
                        questionId: listQuestions.First(x => x.Name.Equals("Acompanhamento")).Id,
                        addedData: new DateTime(2023,07,25)
                    ),
                new OtherQuestion(
                        name: "Recém-nascido",
                        questionId: listQuestions.First(x => x.Name.Equals("Acompanhamento")).Id,
                        addedData: new DateTime(2023,07,25)
                    ),
                new OtherQuestion(
                        name: "Criança",
                        questionId: listQuestions.First(x => x.Name.Equals("Acompanhamento")).Id,
                        addedData: new DateTime(2023,07,25)
                    ),
                new OtherQuestion(
                        name: "Pessoa com desnutrição",
                        questionId: listQuestions.First(x => x.Name.Equals("Acompanhamento")).Id,
                        addedData: new DateTime(2023,07,25)
                    ),
                new OtherQuestion(
                        name: "Pessoa em reabilitação ou com deficiência",
                        questionId: listQuestions.First(x => x.Name.Equals("Acompanhamento")).Id,
                        addedData: new DateTime(2023,07,25)
                    ),
                new OtherQuestion(
                        name: "Pessoa com hipertensão",
                        questionId: listQuestions.First(x => x.Name.Equals("Acompanhamento")).Id,
                        addedData: new DateTime(2023,07,25)
                    ),
                new OtherQuestion(
                        name: "Pessoa com diabetes",
                        questionId: listQuestions.First(x => x.Name.Equals("Acompanhamento")).Id,
                        addedData: new DateTime(2023,07,25)
                    ),
                new OtherQuestion(
                        name:"Pessoa com asma", questionId:
                        listQuestions.First(x => x.Name.Equals("Acompanhamento")).Id,
                        addedData: new DateTime(2023,07,25)
                    ),
                new OtherQuestion(
                        name:"Pessoa com DPOC/enfisema", questionId:
                        listQuestions.First(x => x.Name.Equals("Acompanhamento")).Id,
                        addedData: new DateTime(2023,07,25)
                    ),
                new OtherQuestion(
                        name:"Pessoa com câncer", questionId:
                        listQuestions.First(x => x.Name.Equals("Acompanhamento")).Id,
                        addedData: new DateTime(2023,07,25)
                    ),
                new OtherQuestion(
                        name:"Pessoa com outras doenças crônicas", questionId:
                        listQuestions.First(x => x.Name.Equals("Acompanhamento")).Id,
                        addedData: new DateTime(2023,07,25)
                    ),
                new OtherQuestion(
                        name:"Pessoa com hanseníase", questionId:
                        listQuestions.First(x => x.Name.Equals("Acompanhamento")).Id,
                        addedData: new DateTime(2023,07,25)
                    ),
                new OtherQuestion(
                        name:"Pessoa com tuberculose", questionId:
                        listQuestions.First(x => x.Name.Equals("Acompanhamento")).Id,
                        addedData: new DateTime(2023,07,25)
                    ),
                new OtherQuestion(
                        name:"Sintomáticos respiratórios", questionId:
                        listQuestions.First(x => x.Name.Equals("Acompanhamento")).Id,
                        addedData: new DateTime(2023,07,25)
                    ),
                new OtherQuestion(
                        name:"Tabagista", questionId:
                        listQuestions.First(x => x.Name.Equals("Acompanhamento")).Id,
                        addedData: new DateTime(2023,07,25)
                    ),
                new OtherQuestion(
                        name:"Domiciliados/Acamados", questionId:
                        listQuestions.First(x => x.Name.Equals("Acompanhamento")).Id,
                        addedData: new DateTime(2023,07,25)
                    ),
                new OtherQuestion(
                        name:"Condições de vulnerabilidade social", questionId:
                        listQuestions.First(x => x.Name.Equals("Acompanhamento")).Id,
                        addedData: new DateTime(2023,07,25)
                    ),
                new OtherQuestion(
                        name:"Saúde mental", questionId:
                        listQuestions.First(x => x.Name.Equals("Acompanhamento")).Id,
                        addedData: new DateTime(2023,07,25)
                    ),
                new OtherQuestion(
                        name:"Usuário de álcool", questionId:
                        listQuestions.First(x => x.Name.Equals("Acompanhamento")).Id,
                        addedData: new DateTime(2023,07,25)
                    ),
                new OtherQuestion(
                        name:"Usuário de outras drogas", questionId:
                        listQuestions.First(x => x.Name.Equals("Acompanhamento")).Id,
                        addedData: new DateTime(2023,07,25)
                    ),
                new OtherQuestion(
                        name:"Ação educativa", questionId:
                        listQuestions.First(x => x.Name.Equals("Controle ambiental/vetorial")).Id,
                        addedData: new DateTime(2023,07,25)
                    ),
                new OtherQuestion(
                        name:"Imóvel com foco", questionId:
                        listQuestions.First(x => x.Name.Equals("Controle ambiental/vetorial")).Id,
                        addedData: new DateTime(2023,07,25)
                    ),
                new OtherQuestion(
                        name:"Ação mecânica", questionId:
                        listQuestions.First(x => x.Name.Equals("Controle ambiental/vetorial")).Id,
                        addedData: new DateTime(2023,07,25)
                    ),
                new OtherQuestion(
                        name:"Tratamento focal", questionId:
                        listQuestions.First(x => x.Name.Equals("Controle ambiental/vetorial")).Id,
                        addedData: new DateTime(2023,07,25)
                    ),
                new OtherQuestion(
                        name:"Visita realizada", questionId:
                        listQuestions.First(x => x.Name.Equals("Desfecho")).Id,
                        addedData: new DateTime(2023,07,25)
                    ),
                new OtherQuestion(
                        name:"Visita recusada", questionId:
                        listQuestions.First(x => x.Name.Equals("Desfecho")).Id,
                        addedData: new DateTime(2023,07,25)
                    ),
                new OtherQuestion(
                        name:"Ausente", questionId:
                        listQuestions.First(x => x.Name.Equals("Desfecho")).Id,
                        addedData: new DateTime(2023,07,25)
                    ),
            };
        }
    }
}
