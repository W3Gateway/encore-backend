namespace Encore.Domain.ValueObjects
{
    public class SituacaoMoradia : EsusIntegrationBase<SituacaoMoradia>
    {
        public static SituacaoMoradia Proprio => new SituacaoMoradia { Code = 75, Description = "Próprio" };
        public static SituacaoMoradia Financiado => new SituacaoMoradia { Code = 76, Description = "Financiado" };
        public static SituacaoMoradia Alugado => new SituacaoMoradia { Code = 77, Description = "Alugado" };
        public static SituacaoMoradia Arrendado => new SituacaoMoradia { Code = 78, Description = "Arrendado" };
        public static SituacaoMoradia Cedido => new SituacaoMoradia { Code = 79, Description = "Cedido" };
        public static SituacaoMoradia Ocupacao => new SituacaoMoradia { Code = 80, Description = "Ocupação" };
        public static SituacaoMoradia SituacaoRua => new SituacaoMoradia { Code = 81, Description = "Situação de rua" };
        public static SituacaoMoradia Temporaria => new SituacaoMoradia { Code = 204, Description = "Temporaria" };
        public static SituacaoMoradia Outro => new SituacaoMoradia { Code = 82, Description = "Outra" };
    }
}
