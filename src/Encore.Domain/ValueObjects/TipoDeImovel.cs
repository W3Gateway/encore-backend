namespace Encore.Domain.ValueObjects
{
    public class TipoDeImovel : EsusIntegrationBase<TipoDeImovel>
    {
        public static TipoDeImovel Domicilio => new TipoDeImovel { Code = 1, Description = "Domicilio" };
        public static TipoDeImovel Comercio => new TipoDeImovel { Code = 2, Description = "Comércio" };
        public static TipoDeImovel TerrenoBaldio => new TipoDeImovel { Code = 3, Description = "Terreno baldio" };
        public static TipoDeImovel PontoEstrategico => new TipoDeImovel { Code = 4, Description = "Ponto Estratégico" };
        public static TipoDeImovel Escola => new TipoDeImovel { Code = 5, Description = "Escola" };
        public static TipoDeImovel Creche => new TipoDeImovel { Code = 6, Description = "Creche" };
        public static TipoDeImovel Abrigo => new TipoDeImovel { Code = 7, Description = "Abrigo" };
        public static TipoDeImovel Asilo => new TipoDeImovel { Code = 8, Description = "Instituição de longa permanência para idosos" };
        public static TipoDeImovel UnidadePrisional => new TipoDeImovel { Code = 9, Description = "Unidade prisional" };
        public static TipoDeImovel SocioEducacional => new TipoDeImovel { Code = 10, Description = "Unidade de medida sócio educativa" };
        public static TipoDeImovel Delegacia => new TipoDeImovel { Code = 11, Description = "Delegacia" };
        public static TipoDeImovel EstabelecimentoReligioso => new TipoDeImovel { Code = 12, Description = "Estabelecimento religioso" };
        public static TipoDeImovel CASAI => new TipoDeImovel { Code = 13, Description = "CASAI" };
        public static TipoDeImovel Outros => new TipoDeImovel { Code = 99, Description = "Outros" };
    }
}
