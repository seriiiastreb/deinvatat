using System;
using System.Collections.Generic;
using DAL;
using System.Collections;
using System.Data;

namespace Security
{
    public class MainModule
    {
        public static readonly string ID = "Main Module";
        public static readonly string Description = "Basic data operation (Main Module)";
        public static readonly string DBConnectionsStringKey = "mainDBConnectionString";
        private static readonly string TempDirectoryKey = "TempDirectory";
        public static DataBridge DataBridge = new DataBridge(ConfigManager.GetDbConnectionString(Module.DBConnectionsStringKey), ConfigManager.GetProviderName(Module.DBConnectionsStringKey));

        string mTempFolder = ConfigManager.GetFileDirectory(TempDirectoryKey);

        public string TempFolder
        {
            get
            {
                return mTempFolder;
            }
        }

        private string Plus = string.Empty;

        string mLastError = string.Empty;
        public string LastError
        {
            get { return mLastError; }
        }

        public static void Register()
        {
            Registrar.RegisterModule(ID, Description);
            Domains.BasicProgramAdministration.Register();     
            Domains.Emailing.Register();  
        }

        public MainModule()
        { Plus = Module.DataBridge.ConcatSimbol + " ' ' " + Module.DataBridge.ConcatSimbol; }


        #region calssifiers and Classifiers Types
             
        public System.Data.DataTable GetProvinceListByCountry(int countryID)
        {
            System.Data.DataTable result = new System.Data.DataTable();
            mLastError = string.Empty;

            try
            {                
                string query = @"SELECT Classifiers.Code "
                    + ", Classifiers.Name "
                    + " FROM Classifiers as Classifiers "
                    + " WHERE Classifiers.GroupCode = " + countryID + " "
                    //+ " OR Classifiers.Code = 0 "
                    + " ORDER BY Classifiers.Name ASC";

                result = Security.MainModule.DataBridge.ExecuteQuery(query);
                mLastError = Security.MainModule.DataBridge.LastError;
               
            }
            catch (Exception exception)
            {
                mLastError += "Error using DataBridge. " + exception.Message;
            }          

            return result;
        }

        public System.Data.DataTable GetClassifierByTypeID(int typeID)
        {
            System.Data.DataTable result = new System.Data.DataTable();
            mLastError = string.Empty;

            try
            {                
                    string query = @"SELECT Classifiers.Code "
                        + ", Classifiers.Name "
                        + ", Classifiers.Description "
                        + ", Classifiers.GroupCode "
                        + " FROM Classifiers as Classifiers "
                        + " WHERE Classifiers.TypeID = " + typeID + " "
                        //+ " OR Classifiers.Code = 0 "
                        + " ORDER BY Classifiers.Name ASC";

                    result = Security.MainModule.DataBridge.ExecuteQuery(query);
                    mLastError = Security.MainModule.DataBridge.LastError;
               
            }
            catch (Exception exception)
            {
                mLastError += "Error using DataBridge. " + exception.Message;
            }           

            return result;
        }       

        public System.Data.DataTable GetClassifierTypesList()
        {
            System.Data.DataTable classifierTypesList = new System.Data.DataTable();

            try
            {
                string commandText = "SELECT   ClassifierType.TypeID AS \"Type ID\"  \r\n "
                                                + " , ClassifierType.Name AS Name  \r\n "
                                                + "  FROM ClassifierType WHERE system = @notSystem \r\n "
                                                + " order BY Name";

                System.Collections.Hashtable parameters = new System.Collections.Hashtable();
                parameters.Add("@notSystem", false);

                classifierTypesList = Security.MainModule.DataBridge.ExecuteQuery(commandText, parameters); // PG compliant
                mLastError = Security.MainModule.DataBridge.LastError;                
            }
            catch (Exception exception)
            {
                mLastError += "Error using DataBridge. " + exception.Message;
            }

            return classifierTypesList;
        }

        public bool NewClassifierTypes(string clTypeDescription)
        {
            bool result = false;
            try
            {               
                string nonQuery = @"INSERT INTO ClassifierType (Name, system) VALUES ( @clTypeDescription, @notSystem)";

                System.Collections.Hashtable paramenetrs = new System.Collections.Hashtable();
                paramenetrs.Add("@notSystem", false);
                paramenetrs.Add("@clTypeDescription", clTypeDescription);

                result = Security.MainModule.DataBridge.ExecuteNonQuery(nonQuery, paramenetrs); // PG compliant
                mLastError = Security.MainModule.DataBridge.LastError;               
            }
            catch (Exception exception)
            {
                mLastError += "Error using DataBridge. " + exception.Message;
            }

            return result;
        }

        public bool UpdateClassifierTypes(int clTypeID, string clTypeDescription)
        {
            bool result = false;
            try
            {
                string nonQuery = @"Update ClassifierType Set "
                    + " Name = @clTypeDescription "
                    + " WHERE TypeID = @clTypeID ";

                Hashtable parameters = new Hashtable();
                parameters.Add("@clTypeDescription", clTypeDescription);
                parameters.Add("@clTypeID", clTypeID);

                result = Security.MainModule.DataBridge.ExecuteNonQuery(nonQuery, parameters); // PG compliant
                mLastError = Security.MainModule.DataBridge.LastError;
            }
            catch (Exception exception)
            {
                mLastError += "Error using DataBridge. " + exception.Message;
            }

            return result;
        }

        public bool DeleteClassifierType(int classifierTypeID)
        {
            bool result = false;
            try
            {
                if (classifierTypeID != 0)
                {
                    string nonQuery = @"Delete From Classifiers WHERE TypeID = " + classifierTypeID;

                    result = Security.MainModule.DataBridge.ExecuteNonQuery(nonQuery); // PG compliant
                    mLastError = Security.MainModule.DataBridge.LastError;

                    if (result)
                    {
                        nonQuery = @"Delete From ClassifierType WHERE TypeID = " + classifierTypeID;

                        result = Security.MainModule.DataBridge.ExecuteNonQuery(nonQuery); // PG compliant
                        mLastError = Security.MainModule.DataBridge.LastError;
                    }
                }
            }
            catch (Exception exception)
            {
                mLastError += "Error using DataBridge. " + exception.Message;
            }

            return result;
        }

        public System.Data.DataTable GetAllClassifiers(int clTypeID)
        {
            System.Data.DataTable classifiersList = new System.Data.DataTable();

            try
            {          
                string commandText = "SELECT Classifiers.TypeID AS \"Type ID\" "
                                        + ", Classifiers.Code AS Code "
                                        + ", Classifiers.Name as \"Name\" "
                                        + ", GroupCode "
                                        + " FROM Classifiers as Classifiers "
                                        + " WHERE Classifiers.TypeID = " + clTypeID + " "
                                        + " ORDER BY Classifiers.TypeID, Classifiers.Code "
                                        + " ";

                classifiersList = Security.MainModule.DataBridge.ExecuteQuery(commandText); // PG compliant
                mLastError = Security.MainModule.DataBridge.LastError;               
            }
            catch (Exception exception)
            {
                mLastError += "Error using DataBridge. " + exception.Message;
            }

            return classifiersList;
        }
        
        public string GetClassifierNameByCode(int clCode)
        {
            string result = string.Empty;

            try
            {
                string commandText = "SELECT Classifiers.Name  "                                        
                                        + " FROM Classifiers as Classifiers "
                                        + " WHERE Classifiers.code = " + clCode + " "; 

                System.Data.DataTable classifiersList = Security.MainModule.DataBridge.ExecuteQuery(commandText); // PG compliant
                mLastError = Security.MainModule.DataBridge.LastError;

                if (classifiersList != null && classifiersList.Rows.Count == 1 && classifiersList.Rows[0][0] != System.DBNull.Value)
                {
                    result = (string)classifiersList.Rows[0][0];
                }
            }
            catch (Exception exception)
            {
                mLastError += "Error using DataBridge. " + exception.Message;
            }

            return result;
        }

        public bool UpdateClassifier(int classifierCode, string clTypeDescription, int groupCode)
        {
            bool result = false;
            try
            {
                string nonQuery = @"Update Classifiers Set Name = @clTypeDescription , groupCode = " + (groupCode == 0 ? "NULL" : groupCode.ToString()) + "  WHERE Code = " + classifierCode;

                Hashtable parameters = new Hashtable();
                parameters.Add("@clTypeDescription", clTypeDescription);

                result = Security.MainModule.DataBridge.ExecuteNonQuery(nonQuery, parameters); // PG compliant
                mLastError = Security.MainModule.DataBridge.LastError;                
            }
            catch (Exception exception)
            {
                mLastError += "Error using DataBridge. " + exception.Message;
            }

            return result;
        }

        public bool NewClassifier(int clTypeID, string clTypeDescription, int groupCode)
        {
            bool result = false;
            try
            {               
                string nonQuery = @"INSERT INTO Classifiers (TypeID, Name, groupCode)"
                                        + " VALUES ( " + clTypeID + ", @clTypeDescription , " + (groupCode == 0 ? "NULL" : groupCode.ToString()) + " )";

                Hashtable parameters = new Hashtable();
                parameters.Add("@clTypeDescription", clTypeDescription);

                result = Security.MainModule.DataBridge.ExecuteNonQuery(nonQuery, parameters); // PG compliant
                mLastError = Security.MainModule.DataBridge.LastError;                
            }
            catch (Exception exception)
            {
                mLastError += "Error using DataBridge. " + exception.Message;
            }

            return result;
        }

        public bool DeleteClassifier(int classifierCode)
        {
            bool result = false;
            try
            {
                if (classifierCode != 0)
                {
                    string nonQuery = @"Delete From Classifiers WHERE Code = " + classifierCode;

                    result = Security.MainModule.DataBridge.ExecuteNonQuery(nonQuery); // PG compliant
                    mLastError = Security.MainModule.DataBridge.LastError;
                }
            }
            catch (Exception exception)
            {
                mLastError += "Error using DataBridge. " + exception.Message;
            }

            return result;
        }

        #endregion calssifiers and Classifiers Types

        #region Currency

        public System.Data.DataTable GetCurrencyList()
        {
            System.Data.DataTable resultTable = new System.Data.DataTable();

            try
            {
                string commandText = @"SELECT * "
                                     + " , (select Name From Classifiers Where Code = countryID) as country "
                                     + " FROM Currency ";

                resultTable = Security.MainModule.DataBridge.ExecuteQuery(commandText); // PG compliant

                mLastError = Security.MainModule.DataBridge.LastError;
            }
            catch (Exception exception)
            {
                mLastError += "Error using DataBridge. " + exception.Message;
            }

            return resultTable;
        }

        public System.Data.DataTable GetCurrencyById(int currencyID)
        {
            System.Data.DataTable resultDataTable = new System.Data.DataTable();

            try
            {
                string commandText = @"SELECT * "
                                     + " , (select Name From Classifiers Where Code = countryID) as country "
                                     + " FROM Currency "
                                     + " WHERE CurrencyID = " + currencyID;

                resultDataTable = Security.MainModule.DataBridge.ExecuteQuery(commandText); // PG compliant
                mLastError = Security.MainModule.DataBridge.LastError;
            }
            catch (Exception exception)
            {
                mLastError += "Error using DataBridge. " + exception.Message;
            }

            return resultDataTable;
        }

        public bool AddCurrency(string name, string code, int countryID, string symbol)
        {
            bool result = false;
            try
            {               
                string nonQuery = @"INSERT INTO Currency (name, code, countryID, symbol) VALUES ( @name ,@code, @countryID, @symbol)";

                Hashtable parameters = new Hashtable();
                parameters.Add("@name", name);
                parameters.Add("@code", code);
                parameters.Add("@countryID", countryID);
                parameters.Add("@symbol", symbol);

                result = Security.MainModule.DataBridge.ExecuteNonQuery(nonQuery, parameters); // PG compliant
                mLastError = Security.MainModule.DataBridge.LastError;                
            }
            catch (Exception exception)
            {
                mLastError += "Error using DataBridge. " + exception.Message;
            }

            return result;
        }

        public bool UpdateCurrency(int currencyID, string name, string code, int countryID, string symbol)
        {
            bool result = false;
            try
            {                
                string nonQuery = @"Update Currency "
                    + " SET Name = @name "
                    + ", Code = @code "
                    + ", CountryID = @countryID "
                    + ", Symbol = @symbol "
                    + " WHERE CurrencyID = @currencyID ";

                Hashtable parameters = new Hashtable();
                parameters.Add("@name", name);
                parameters.Add("@code", code);
                parameters.Add("@countryID", countryID);
                parameters.Add("@symbol", symbol);
                parameters.Add("@currencyID", currencyID);

                result = Security.MainModule.DataBridge.ExecuteNonQuery(nonQuery, parameters); // PG compliant
                mLastError = Security.MainModule.DataBridge.LastError;                
            }
            catch (Exception exception)
            {
                mLastError += "Error using DataBridge. " + exception.Message;
            }

            return result;
        }

        public bool DeleteCurrency(int currencyID)
        {
            bool result = false;
            try
            {               
                string nonQuery = @"Delete From Currency WHERE CurrencyID = " + currencyID;

                result = Security.MainModule.DataBridge.ExecuteNonQuery(nonQuery); // PG compliant
                mLastError = Security.MainModule.DataBridge.LastError;                
            }
            catch (Exception exception)
            {
                mLastError += "Error using DataBridge. " + exception.Message;
            }

            return result;
        }

        #endregion Currency

        #region Email 

        public System.Data.DataTable GetMessagesListByUserID(int userID, List<int> messagesStatusesList, int scope)
        {
            System.Data.DataTable resultTable = new System.Data.DataTable();
            string statusesLIst = Crypt.Utils.ConvertListToString(messagesStatusesList);

            try
            {
                string commandText = "SELECT \r\n "
                                     + "   id, \r\n "
                                     + "  (SELECT NUME " + Plus + " ' ' " + Plus + " Prenume From users WHERE users.userid = mail_Messages.from_userid ) as FromUser,         \r\n "
                                     + "  CASE WHEN message_type = " + Constants.EmailMessageTypes.Email  + " \r\n "
                                     + "    THEN message_reciver \r\n "
                                     + "    ELSE (SELECT NUME " + Plus + " ' ' " + Plus + " Prenume From users WHERE users.userid = cast(mail_Messages.message_reciver as int) ) \r\n "
                                     + "   END as ToUser,         \r\n "     
                                     + "   message_type, \r\n "
                                     + "   message_reciver, \r\n "
                                     + "   subject, \r\n "
                                     + "   date, \r\n "
                                     + "   status \r\n "
                                     + "   FROM mail_Messages  \r\n "
                                     + " WHERE  ownerMailBoxUserID = " + userID
                                     + " AND status in (" + statusesLIst + ") \r\n "
                                     + " AND messageScope = " + scope;

                resultTable = Security.MainModule.DataBridge.ExecuteQuery(commandText); // PG compliant
                mLastError = Security.MainModule.DataBridge.LastError;
            }
            catch (Exception exception)
            {
                mLastError += "Error using DataBridge. " + exception.Message;
            }

            return resultTable;
        }      

        public bool SaveMessage(int ownerMailBoxID, int fromUser, string messageReciver, int messageType, string subject, DateTime date, int status, string medsageBody, int messageScope)
        {
            bool result = false;
            try
            {
                string nonQuery = @"INSERT INTO mail_Messages(ownerMailBoxUserID, from_userid, message_reciver, message_type, subject, date, status, messageScope)  "
                    + "OUTPUT INSERTED.id "
                    + " VALUES (" + ownerMailBoxID + ", " + fromUser + ", @messageReciver, " + messageType + ", @subject, @date, " + status + ", " + messageScope + ");";

                Hashtable parameters = new Hashtable();
                parameters.Add("@messageReciver", messageReciver);
                parameters.Add("@subject", subject);
                parameters.Add("@date", date);

                object insertedID = Security.MainModule.DataBridge.ExecuteScalarQuery(nonQuery, parameters); // PG compliant
                mLastError += Security.MainModule.DataBridge.LastError;

                if (insertedID != null && !insertedID.ToString().Equals(string.Empty))
                {
                    int messageID = (int)insertedID;

                    nonQuery = "INSERT INTO mail_bodyes(id, messagebody) "
                       + " VALUES (" + messageID + ", @messagebody);";

                    Hashtable param2 = new Hashtable();
                    param2.Add("@messagebody", medsageBody);

                    result = Security.MainModule.DataBridge.ExecuteNonQuery(nonQuery, param2); // PG compliant
                    mLastError += Security.MainModule.DataBridge.LastError;

                    if (!result)
                    {
                        string deleteMM = "DELETE FROM mail_Messages WHERE id = " + messageID;
                        bool deleteResult = Security.MainModule.DataBridge.ExecuteNonQuery(nonQuery); // PG compliant
                        mLastError += Security.MainModule.DataBridge.LastError;
                    }
                }
            }
            catch (Exception exception)
            {
                mLastError += "Error using DataBridge. " + exception.Message;
            }

            return result;
        }

        public bool DeleteMessage(List<int> messageIDList)
        {
            bool result = false;
            try
            {
                string idSTR = Crypt.Utils.ConvertListToString(messageIDList);

                string[] nonQuery = new string[2];
                nonQuery[0] = "DELETE FROM mail_bodyes WHERE id in (" + idSTR + ")";
                nonQuery[1] = "DELETE FROM mail_Messages WHERE id in (" + idSTR + ")";                  

                int intResult = Security.MainModule.DataBridge.ExecuteNonQueryBatch(nonQuery); // PG compliant
                mLastError += Security.MainModule.DataBridge.LastError;

                if (intResult > 0)
                {
                    result = true;
                }                
            }
            catch (Exception exception)
            {
                mLastError += "Error using DataBridge. " + exception.Message;
            }

            return result;
        }

        public System.Data.DataTable GetMessageUsersList()
        {
            System.Data.DataTable result = new System.Data.DataTable();

            try
            {
                string nonQuery = @"SELECT userid, Nume " + Plus + " ' ' " + Plus + " Prenume as Name FROM users ";

                result = Security.MainModule.DataBridge.ExecuteQuery(nonQuery); // PG compliant
                mLastError += Security.MainModule.DataBridge.LastError;               
            }
            catch (Exception exception)
            {
                mLastError += "Error using DataBridge. " + exception.Message;
            }

            return result;
        }

        public string GetMessageBody(int messageID)
        {
            string result = string.Empty;

            try
            {
                string nonQuery = @"Select messagebody FROM mail_bodyes WHERE id = " + messageID;

                System.Data.DataTable dtResult = Security.MainModule.DataBridge.ExecuteQuery(nonQuery); // PG compliant
                mLastError = Security.MainModule.DataBridge.LastError;

                if (dtResult != null && dtResult.Rows.Count == 1 && dtResult.Rows[0][0] != System.DBNull.Value)
                {
                    result = (string)dtResult.Rows[0][0];
                }
            }
            catch (Exception exception)
            {
                mLastError += "Error using DataBridge. " + exception.Message;
            }

            return result;
        }

        public bool MakeLocalMessageAsSpecificStatus(List<int> messageID, int status)
        {
            bool result = false;
            try
            {
                string idSTR = Crypt.Utils.ConvertListToString(messageID);

                string nonQuery = @"UPDATE mail_Messages SET status = " + status + " WHERE id in ( " + idSTR + ") ";

                result = Security.MainModule.DataBridge.ExecuteNonQuery(nonQuery); // PG compliant
                mLastError = Security.MainModule.DataBridge.LastError;
            }
            catch (Exception exception)
            {
                mLastError += "Error using DataBridge. " + exception.Message;
            }

            return result;
        }

        public bool MoveLocalMessageInSpecificFolder(List<int> messageID, int messageScope)
        {
            bool result = false;
            try
            {
                string idSTR = Crypt.Utils.ConvertListToString(messageID);

                string nonQuery = @"UPDATE mail_Messages SET messageScope = " + messageScope + " WHERE id in ( " + idSTR + ") ";

                result = Security.MainModule.DataBridge.ExecuteNonQuery(nonQuery); // PG compliant
                mLastError = Security.MainModule.DataBridge.LastError;
            }
            catch (Exception exception)
            {
                mLastError += "Error using DataBridge. " + exception.Message;
            }

            return result;
        }

        public bool CheckNewEmailForUser(int userID)
        {
            bool result = false;

            try
            {
                if (userID != 0)
                {
                    string nonQuery = @"SELECT * FROM mail_Messages WHERE ownerMailBoxUserID = " + userID + " and status = " + Constants.EmailMessageStatus.UnReaded + " and messageScope = " + Constants.EmailScope.InBox;

                    DataTable resultDT = Security.MainModule.DataBridge.ExecuteQuery(nonQuery); // PG compliant
                    mLastError = Security.MainModule.DataBridge.LastError;

                    if (resultDT != null && resultDT.Rows.Count > 0)
                    {
                        result = true;
                    }
                }
            }
            catch (Exception exception)
            {
                mLastError += "Error using DataBridge. " + exception.Message;
            }            

            return result;
        }

        #endregion Email       
    }

    namespace Domains
    {
        /// <summary>
        /// Default domain. 
        /// </summary>
        public class BasicProgramAdministration
        {
            public static readonly string Name = "Basic Program Administration";
            public static readonly string Description = "Allow View/Edit Basic Data";

            public static void Register()
            {
                Registrar.RegisterDomain(Security.MainModule.ID, Name, Description);
            }
        }

        public class Emailing
        {
            public static readonly string Name = "Emailing";
            public static readonly string Description = "Allow View/Create Emails and send it.";

            public static void Register()
            {
                Registrar.RegisterDomain(Security.MainModule.ID, Name, Description);
            }
        }

    }
}
