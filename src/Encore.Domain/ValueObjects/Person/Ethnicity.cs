namespace Encore.Domain.ValueObjects.Person
{
    public class Ethnicity : EsusIntegrationBase<Ethnicity>
    {
        public string CADSUSCode { get; set; }

        public static Ethnicity Acona => new Ethnicity { Code = 1, Description = "ACONA (WAKONAS, NACONAS, JAKONA, ACORANES)", CADSUSCode = "0001" };
        public static Ethnicity Aikana => new Ethnicity { Code = 2, Description = "AIKANA (AIKANA, MAS SAKA, TUBARAO)", CADSUSCode = "0002" };
        public static Ethnicity Ajuru => new Ethnicity { Code = 3, Description = "AJURU", CADSUSCode = "0003" };
        public static Ethnicity Akunsu => new Ethnicity { Code = 4, Description = "AKUNSU (AKUNT''SU)", CADSUSCode = "0004" };
        public static Ethnicity Amanaye => new Ethnicity { Code = 5, Description = "AMANAYE", CADSUSCode = "0005" };
        public static Ethnicity Amondawa => new Ethnicity { Code = 6, Description = "AMONDAWA", CADSUSCode = "0006" };
        public static Ethnicity Anambe => new Ethnicity { Code = 7, Description = "ANAMBE", CADSUSCode = "0007" };
        public static Ethnicity Aparai => new Ethnicity { Code = 8, Description = "APARAI (APALAI)", CADSUSCode = "0008" };
        public static Ethnicity Apiaka => new Ethnicity { Code = 9, Description = "APIAKA (APIACA)", CADSUSCode = "0009" };
        public static Ethnicity Apinaye => new Ethnicity { Code = 10, Description = "APINAYE (APINAJE/APINAIE/APINAGE)", CADSUSCode = "0010" };
        public static Ethnicity Apurina => new Ethnicity { Code = 11, Description = "APURINA (APORINA, IPURINA, IPURINA, IPURINAN)", CADSUSCode = "0011" };
        public static Ethnicity Arana => new Ethnicity { Code = 12, Description = "ARANA (ARACUAI DO VALE DO JEQUITINHONHA)", CADSUSCode = "0012" };
        public static Ethnicity Arapaso => new Ethnicity { Code = 13, Description = "ARAPASO (ARAPACO)", CADSUSCode = "0013" };
        public static Ethnicity AraraRondonia => new Ethnicity { Code = 14, Description = "ARARA DE RONDONIA (KARO, URUCU, URUKU)", CADSUSCode = "0014" };
        public static Ethnicity AraraAcre => new Ethnicity { Code = 15, Description = "ARARA DO ACRE (SHAWANAUA, AMAWAKA)", CADSUSCode = "0015" };
        public static Ethnicity AraraAripuana => new Ethnicity { Code = 16, Description = "ARARA DO ARIPUANA (ARARA DO BEIRADAO/ARI-PUANA)", CADSUSCode = "0016" };
        public static Ethnicity AraraPara => new Ethnicity { Code = 17, Description = "ARARA DO PARA (UKARAGMA, UKARAMMA)", CADSUSCode = "0017" };
        public static Ethnicity Arawete => new Ethnicity { Code = 18, Description = "ARAWETE (ARAUETE)", CADSUSCode = "0018" };
        public static Ethnicity Arikapu => new Ethnicity { Code = 19, Description = "ARIKAPU (ARICAPU, ARIKAPO, MASUBI, MAXUBI)", CADSUSCode = "0019" };
        public static Ethnicity Arikem => new Ethnicity { Code = 20, Description = "ARIKEM (ARIQUEN, ARIQUEME, ARIKEME)", CADSUSCode = "0020" };
        public static Ethnicity Arikose => new Ethnicity { Code = 21, Description = "ARIKOSE (ARICOBE)", CADSUSCode = "0021" };
        public static Ethnicity Arua => new Ethnicity { Code = 22, Description = "ARUA", CADSUSCode = "0022" };
        public static Ethnicity Aruak => new Ethnicity { Code = 23, Description = "ARUAK (ARAWAK)", CADSUSCode = "0023" };
        public static Ethnicity Ashaninka => new Ethnicity { Code = 24, Description = "ASHANINKA (KAMPA)", CADSUSCode = "0024" };
        public static Ethnicity AsuriniTocantins => new Ethnicity { Code = 25, Description = "ASURINI DO TOCANTINS (AKUAWA/AKWAWA)", CADSUSCode = "0025" };
        public static Ethnicity AsuriniXingu => new Ethnicity { Code = 26, Description = "ASURINI DO XINGU (AWAETE)", CADSUSCode = "0026" };
        public static Ethnicity Atikum => new Ethnicity { Code = 27, Description = "ATIKUM (ATICUM)", CADSUSCode = "0027" };
        public static Ethnicity AvaCanoeiro => new Ethnicity { Code = 28, Description = "AVA - CANOEIRO", CADSUSCode = "0028" };
        public static Ethnicity Aweti => new Ethnicity { Code = 29, Description = "AWETI (AUETI/AUETO)", CADSUSCode = "0029" };
        public static Ethnicity Bakairi => new Ethnicity { Code = 30, Description = "BAKAIRI (KURA, BACAIRI)", CADSUSCode = "0030" };
        public static Ethnicity BanawaYafi => new Ethnicity { Code = 31, Description = "BANAWA YAFI (BANAWA, BANAWA-JAFI)", CADSUSCode = "0031" };
        public static Ethnicity Baniwa => new Ethnicity { Code = 32, Description = "BANIWA (BANIUA, BANIVA, WALIMANAI, WAKUENAI)", CADSUSCode = "0032" };
        public static Ethnicity Bara => new Ethnicity { Code = 33, Description = "BARA (WAIPINOMAKA)", CADSUSCode = "0033" };
        public static Ethnicity Barasana => new Ethnicity { Code = 34, Description = "BARASANA (HANERA)", CADSUSCode = "0034" };
        public static Ethnicity Bare => new Ethnicity { Code = 35, Description = "BARE", CADSUSCode = "0035" };
        public static Ethnicity Bororo => new Ethnicity { Code = 36, Description = "BORORO (BOE)", CADSUSCode = "0036" };
        public static Ethnicity Botocudo => new Ethnicity { Code = 37, Description = "BOTOCUDO (GEREN)", CADSUSCode = "0037" };
        public static Ethnicity Canoe => new Ethnicity { Code = 38, Description = "CANOE", CADSUSCode = "0038" };
        public static Ethnicity Cassupa => new Ethnicity { Code = 39, Description = "CASSUPA", CADSUSCode = "0039" };
        public static Ethnicity Chamacoco => new Ethnicity { Code = 40, Description = "CHAMACOCO", CADSUSCode = "0040" };
        public static Ethnicity Chiquitano => new Ethnicity { Code = 41, Description = "CHIQUITANO (XIQUITANO)", CADSUSCode = "0041" };
        public static Ethnicity Cikiyana => new Ethnicity { Code = 42, Description = "CIKIYANA (SIKIANA)", CADSUSCode = "0042" };
        public static Ethnicity CintaLarga => new Ethnicity { Code = 43, Description = "CINTA LARGA (MATETAMAE)", CADSUSCode = "0043" };
        public static Ethnicity Columbiara => new Ethnicity { Code = 44, Description = "COLUMBIARA (CORUMBIARA)", CADSUSCode = "0044" };
        public static Ethnicity Deni => new Ethnicity { Code = 45, Description = "DENI", CADSUSCode = "0045" };
        public static Ethnicity Desana => new Ethnicity { Code = 46, Description = "DESANA (DESANA, DESANO, DESSANO, WIRA, UMUKOMASA)", CADSUSCode = "0046" };
        public static Ethnicity Diahui => new Ethnicity { Code = 47, Description = "DIAHUI (JAHOI, JAHUI, DIARROI)", CADSUSCode = "0047" };
        public static Ethnicity EnaweneNawe => new Ethnicity { Code = 48, Description = "ENAWENE-NAWE (SALUMA)", CADSUSCode = "0048" };
        public static Ethnicity FulniO => new Ethnicity { Code = 49, Description = "FULNI-O", CADSUSCode = "0049" };
        public static Ethnicity Galibi => new Ethnicity { Code = 50, Description = "GALIBI (GALIBI DO OIAPOQUE, KARINHA)", CADSUSCode = "0050" };
        public static Ethnicity GalibiMarworno => new Ethnicity { Code = 51, Description = "GALIBI MARWORNO (GALIBI DO UACA, ARUA)", CADSUSCode = "0051" };
        public static Ethnicity GaviaoRondonia => new Ethnicity { Code = 52, Description = "GAVIAO DE RONDONIA (DIGUT)", CADSUSCode = "0052" };
        public static Ethnicity GaviaoKrikateje => new Ethnicity { Code = 53, Description = "GAVIAO KRIKATEJE", CADSUSCode = "0053" };
        public static Ethnicity GaviaoParkateje => new Ethnicity { Code = 54, Description = "GAVIAO PARKATEJE (PARKATEJE)", CADSUSCode = "0054" };
        public static Ethnicity GaviaoPukobie => new Ethnicity { Code = 55, Description = "GAVIAO PUKOBIE (PUKOBIE, PYKOPJE, GAVIAO DO MARANHAO)", CADSUSCode = "0055" };
        public static Ethnicity Guaja => new Ethnicity { Code = 56, Description = "GUAJA (AWA, AVA)", CADSUSCode = "0056" };
        public static Ethnicity Guajajara => new Ethnicity { Code = 57, Description = "GUAJAJARA (TENETEHARA)", CADSUSCode = "0057" };
        public static Ethnicity GuaraniKaiowa => new Ethnicity { Code = 58, Description = "GUARANI KAIOWA (PAI TAVYTERA)", CADSUSCode = "0058" };


    }
}
