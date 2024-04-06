namespace Encore.Domain.ValueObjects
{
    public class TypeHouse : EsusIntegrationBase<TypeHouse>
    {
        public static TypeHouse Residence => new TypeHouse { Code = 1, Description = "Domicilio" };
        public static TypeHouse Business => new TypeHouse { Code = 2, Description = "Comércio" };
        public static TypeHouse Wasteland => new TypeHouse { Code = 3, Description = "Terreno baldio" };
        public static TypeHouse StrategicPoint => new TypeHouse { Code = 4, Description = "Ponto Estratégico" };
        public static TypeHouse School => new TypeHouse { Code = 5, Description = "Escola" };
        public static TypeHouse Nursery => new TypeHouse { Code = 6, Description = "Creche" };
        public static TypeHouse Shelter => new TypeHouse { Code = 7, Description = "Abrigo" };
        public static TypeHouse Asylum => new TypeHouse { Code = 8, Description = "Instituição de longa permanência para idosos" };
        public static TypeHouse Prison => new TypeHouse { Code = 9, Description = "Unidade prisional" };
        public static TypeHouse SocioEducational => new TypeHouse { Code = 10, Description = "Unidade de medida sócio educativa" };
        public static TypeHouse PoliceStation => new TypeHouse { Code = 11, Description = "Delegacia" };
        public static TypeHouse Establishment => new TypeHouse { Code = 12, Description = "Estabelecimento religioso" };
        public static TypeHouse Other => new TypeHouse { Code = 99, Description = "Outros" };
    }
}
