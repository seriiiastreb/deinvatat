using System;


public class Constants
{
    public enum ClassifierTypes
    {
        Undefined = 0,
        SystemRoleType = 1,
        PasswordStatus = 2,
        CountryList = 3,
        GenderList = 4,
        LanguageList = 5,
        SystemUserRecordStatus = 6
        //EconomicActivity = 7,
        //Province = 8,
        //HomeType = 9,
        //ProffesionalSituation = 10,
        //ProffesionalExperience = 11,
        //StudyLevel = 12,
        //HousingSituation = 13,
        //CivilStatus = 14,
        //SocialStatus = 15,
        //Biserica = 16,
        //SectorAfaceri = 17,
        //FormaDeInregistrareItreprindere = 18,
        //ModDeCalculDobinda = 19,
        //SursaDeVenit = 20,
        //LocDeMunca = 21,
        //TipDeInstruire = 22,
        //PayPeriod = 23,
        //roundType = 24,
        //typeOfCalculation = 25,
        //contractCategory = 26,
        //TipEvaluareConsultare = 27,
        //StareaAfacerii = 28,
        //Permissions = 29,
        //Programs = 30,
        //CalculatePenaltyFrom = 31,
        //SuprafataTerenAgricol = 32,
        //SituatiaMateriala = 33,
        //ClientCategories = 50,
        //PledgeType = 53,
        //LoanAproveStatus = 55,
        //MinimProcentPeriod = 56,
        //CreditState = 60
    }

    public enum Classifiers
    {              
        Romanian_Language = 1,
        Russian_Language = 2,
        English_Language = 3,

        UserRecord_Active = 8,
        UserRecord_Blocked = 9,
        UserRecord__NotActivated = 10,

        //OdataLaDouaSaptamini = 291,
        //OdataLaDouaLuni = 292,
        //MonthlyPayment = 293,
        //QuarterlyPaymnet = 294,
        //Half_yearPaymnet = 295,
        //AnnuallyPayment = 296,
        //RoundTypeDeFacto = 297,
        //RoundTypeOnFirstPayment = 299,
        //RoundTypeOnLastPaymnet = 300,
        //Percent_DinSumaInitiala = 301,
        //Percent_DinSumaRamasa = 302,
        //SumaFixa = 303,
        //ContractCategory_Normal = 306,
        //ContractCategory_Bad = 307,

        //ContractProgram_StartUp = 320,
        //ContractProgram_AIA = 321,
        //ContractProgram_DAP = 322,

        //CalculatePenalty_DeLaSumaIntirzierii = 323,
        //CalculatePenalty_DinSumaInitiala = 324,
        //CalculatePenalty_SumaFixa = 325,

        Permissions_View = 344,
        Permissions_Edit = 345,
        Permissions_Deny = 346,
        //AproveStatus_NotAproved = 400,
        //AproveStatus_Aprove = 401,
        //AproveStatus_NeedAdditinalInfo = 402,

        //Persoana_Juridica = 415,

        //CreditState_InAsteptareAprobare = 421,
        //CreditState_Renuntat = 422,
        //CreditState_Refuzat = 423,
        //CreditState_Achitat = 424,
        //CreditState_Activ = 425,
        //CreditState_InchisRestructurat = 432,
        //CreditState_InchisAnticipat = 433,
        //CreditState_SpreEliberareNumerer = 434
    }

    public enum NumberWordMode
    {
        Money = 1,
        Percent = 2,
        SimpleNumber = 3
    }

    public class InfoBoxMessageType
    {
        public const int Error = 2;
        public const int Important = 4;
        public const int Info = 0;
        public const int Ok = 3;
        public const int Question = 5;
        public const int Warning = 1;
    }

    public class EmailMessageStatus
    {
        public const int Readed = 1;
        public const int UnReaded = 2;
        public const int Draft = 3;
    }

    public class EmailScope
    {
        public const int InBox = 1;
        public const int OutBox = 2;
        public const int Deleted = 3;
    }

    public class EmailMessageTypes
    {
        public const int SystemMessage = 1;
        public const int Email = 2;
    }

    //public class UserOperation
    //{
    //    public const string Edit = "Edit";
    //    public const string New = "New";
    //    public const string Delete = "Delete";
    //}

    //public class ReportNames
    //{
    //    public const string LoanPartOfCreditsReportName = "loanPartOfCreditsReport";
    //    public const string ListOfPaymentsInSelectedPeriodReportName = "listOfPaymentsInSelPer";
    //    public const string ParReportName = "PAR";
    //    public const string ClientPersonalDataReportName = "clientPersonalReport";
    //    public const string ImprumuturiAcordateReportName = "imprumuturiAcordateReport";
    //    public const string ConsultariEvaluariReportName = "ConsultariEvaluari";
    //}

    //public class SessionPhotoTable
    //{
    //    //public static string newConsultPhotoFiles = "newConsultPhotoFiles";
    //    public static string ConsultEvalPhotoFiles = "editConsultPhotoFiles";
    //}

    //public class ConsultEvalPhoto_ColumnNames
    //{
    //    public static string photoID = "photoID";
    //    public static string clevID = "clevID";
    //    public static string PhotoLink = "PhotoLink";
    //    public static string SmallPhotoLink = "SmallPhotoLink";
    //    public static string OriginalFileName = "OriginalFileName";
    //    public static string GlobalPahtFile = "GlobalPahtFile";
    //    public static string StoredInDB = "StoredInDB";
    //}     

    public enum CurrencyList
    {
        MDL = 1,
        USD = 2,
        EURO = 3
    }

    public class ContentType
    {
        public static readonly string TXT = "text/plain";
        public static readonly string CSV = "text/csv";
        public static readonly string RTF = "application/msword";
        public static readonly string DOC = "application/msword";
        public static readonly string DOCX = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
        public static readonly string XLS = "application/vnd.ms-excel";
        public static readonly string XLSX = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        public static readonly string ODT = "application/vnd.oasis.opendocument.text";
        public static readonly string ODS = "application/vnd.oasis.opendocument.spreadsheet";
        public static readonly string PPT = "application/vnd.ms-powerpoint";
        public static readonly string VSD = "application/vnd.visio";
        public static readonly string PDF = "application/pdf";
        public static readonly string PNG = "image/png";
        public static readonly string JPG = "image/jpg";
        public static readonly string JPEG = "image/jpeg";
        public static readonly string JPEGP = "image/pjpeg";
        public static readonly string ZIP = "application/zip";
        public static readonly string ZIPX = "application/x-zip";
        public static readonly string ZIPCompressed = "application/zip-compressed";
        public static readonly string ZIPCompressedX = "application/x-zip-compressed";
        public static readonly string ZIPMultipartX = "multipart/x-zip";
        public static readonly string ZIPMultipart = "multipart/zip";
        public static readonly string DownloadX = "application/x-download";
        public static readonly string Download = "application/download";
    }      

    public Constants()
    {
    }

    //public class ConfigPanel
    //{
    //    public static string csvObjects = "csvObject";
    //    public static string csvAlias = "csvAlias";
    //    public const string csvSelect = "csvSelect";
    //    public const string csvInsert = "csvInsert";
    //    public static string column_name = "column_name";
    //    public static string newFormContainer = "newFormContainer";
    //}

    //public enum ToolBox
    //{
    //    Classifiers = -1,
    //    TextBox = 0,
    //    CheckBox = 1,
    //    DateTime = 2,
    //    Table = 3,
    //    SQL = 4
    //}

    //public class ToolBoxConst
    //{
    //    public const string tbClassifiers = "Classifiers";
    //    public const string tbTextBox = "TextBox";
    //    public const string tbCheckBox = "CheckBox";
    //    public const string tbDateTime = "DateTime";
    //    public const string tbTable = "Table";
    ////    public const string tbSql = "SQL";
    //}

    //public const string objectDelimiter = ":";

    //public const int DefaultCountry = 133;

    public static readonly string ISODateYearFormat = "yyyy";
    public static readonly string ISODateFormat = "yyyy-MM-dd";
    public static readonly string ISODateSlashesFormat = "yyyy/MM/dd";
    public static readonly string ISODateDotsFormat = "yyyy.MM.dd";
    public static readonly string ISODateBackwardFormat = "dd-MM-yyyy";
    public static readonly string ISODateBackwardSlashesFormat = "dd/MM/yyyy";
    public static readonly string ISODateBackwardDotsFormat = "dd.MM.yyyy";

    public static readonly string ISODateTimeMinutesFormat = "yyyy-MM-dd HH:mm";
    public static readonly string ISODateTimeSecondsFormat = "yyyy-MM-dd HH:mm:ss";
    public static readonly string ISODateTimeMillisec1DecimalsFormat = "yyyy-MM-dd HH:mm:ss.f";
    public static readonly string ISODateTimeMillisec2DecimalsFormat = "yyyy-MM-dd HH:mm:ss.ff";
    public static readonly string ISODateTimeMillisec3DecimalsFormat = "yyyy-MM-dd HH:mm:ss.fff";
    public static readonly string ISODateTimeMillisec4DecimalsFormat = "yyyy-MM-dd HH:mm:ss.ffff";
    public static readonly string ISODateTimeMillisec5DecimalsFormat = "yyyy-MM-dd HH:mm:ss.fffff";
    public static readonly string ISODateTimeMillisec6DecimalsFormat = "yyyy-MM-dd HH:mm:ss.ffffff";
    public static readonly string ISOHoursMinutesFormat = "HH:mm";
}

