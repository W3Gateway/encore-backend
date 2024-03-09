namespace Encore.Domain.ValueObjects.Person
{
    public class CitizenCaregiver : EsusIntegrationBase<CitizenCaregiver>
    {
        public static CitizenCaregiver None => new CitizenCaregiver { Code = 1, Description = "Não possui" };
        public static CitizenCaregiver SpousePartner => new CitizenCaregiver { Code = 2, Description = "Cônjuge/Companheiro" };
        public static CitizenCaregiver ChildStepchild => new CitizenCaregiver { Code = 3, Description = "Filho/Enteado" };
        public static CitizenCaregiver Parent => new CitizenCaregiver { Code = 4, Description = "Pai/Mãe" };
        public static CitizenCaregiver Grandparent => new CitizenCaregiver { Code = 5, Description = "Avô(ó)" };
        public static CitizenCaregiver Grandchild => new CitizenCaregiver { Code = 6, Description = "Neto" };
        public static CitizenCaregiver Sibling => new CitizenCaregiver { Code = 7, Description = "Irmão(ã)" };
        public static CitizenCaregiver Other => new CitizenCaregiver { Code = 8, Description = "Outro" };
    }


}
