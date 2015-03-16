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
        SystemUserRecordStatus = 6,
        Province = 7,
        Permissions = 8,

    }

    public enum Classifiers
    {              
        Romanian_Language = 1,
        Russian_Language = 2,
        English_Language = 3,

        PasswordStatus_Active = 6,
        PasswordStatus_NeedChange = 7,

        UserRecord_Active = 8,
        UserRecord_Blocked = 9,
        UserRecord_NotActivated = 10,    

        Permissions_View = 267,
        Permissions_Edit = 268,
        Permissions_Deny = 269,       
    }

    public enum NumberWordMode
    {
        Money = 1,
        Percent = 2,
        SimpleNumber = 3
    }
    
    public class InfoBoxMessageType
    {
        public const int Info = 0;
        public const int Warning = 1;
        public const int Error = 2;
        public const int Ok = 3;
        public const int Important = 4;
        public const int Question = 5;
        public const int Cancel = 6;
    }

    public class ConfirmationDialogResponseType
    {
        public const int Yes = 1;
        public const int No = 2;
        public const int Cancel = 3;
    }

    public class DaysOfWeek
    {
        public const int Monday = 1;
        public const int Tuesday = 2;
        public const int Wednesday = 3;
        public const int Thursday = 4;
        public const int Friday = 5;
        public const int Saturday = 6;
        public const int Sunday = 7;
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

    public class UserOperation
    {
        public const string Edit = "Edit";
        public const string New = "New";
        public const string Delete = "Delete";
    }

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

