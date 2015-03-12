using System;
using System.Collections;
using System.Data;
using System.Collections.Generic;
using DAL;

namespace Security
{
    public class Module
    {
        public static readonly string ID = "Main Security Module";
        public static readonly string Description = "Creating And Processing Security Functions";
        public static readonly string DBConnectionsStringKey = "mainDBConnectionString";
        public static DataBridge DataBridge = new DataBridge(ConfigManager.GetDbConnectionString(Module.DBConnectionsStringKey), ConfigManager.GetProviderName(Module.DBConnectionsStringKey));

        private string Plus = string.Empty;

        string mLastError = string.Empty;
        public string LastError
        {
            get { return mLastError; }
        }

        public Module()
        {
            Plus = Module.DataBridge.ConcatSimbol + " ' ' " + Module.DataBridge.ConcatSimbol;
        }

        public DataTable GetGroupsList()
        {
            DataTable modules = new DataTable();

            try
            {
                string query = "SELECT role_id FROM st_roles order by role_id ";
                modules = Module.DataBridge.ExecuteQuery(query);
                mLastError = Module.DataBridge.LastError;
            }
            catch
            {
                throw;
            }
            
            return modules;
        }

        public bool AddGroup(string group_id)
        {
            bool result = false;

            try
            {
                string query = "INSERT INTO st_roles (role_id) VALUES (@group_id) ";

                Hashtable parameters = new Hashtable();
                parameters.Add("@group_id", group_id);

                result = Module.DataBridge.ExecuteNonQuery(query, parameters);
                mLastError = Module.DataBridge.LastError;
            }
            catch
            {
                throw;
            }

            return result;
        }

        public bool DeleteGroup(string group_id)
        {
            bool result = false;

            try
            {
                string query = "DELETE FROM st_roles WHERE role_id = @group_id ";

                Hashtable parameters = new Hashtable();
                parameters.Add("@group_id", group_id);

                result = Module.DataBridge.ExecuteNonQuery(query, parameters);
                mLastError = Module.DataBridge.LastError;
            }
            catch
            {
                throw;
            }

            return result;
        }
        
        public DataTable GetModulesList()
        {
            DataTable modules = new DataTable();

            try
            {
                string query = "SELECT module_id, description FROM st_modules order by description ";
                modules = Module.DataBridge.ExecuteQuery(query);
                mLastError = Module.DataBridge.LastError;
            }
            catch
            {
                throw;
            }           

            return modules;
        }

        public string GetModuleDescriptionById(string moduleId)
        {
            string description = string.Empty;

            try
            {
                string query = "SELECT description FROM st_modules WHERE module_id = @moduleId  ";

                Hashtable parameters = new Hashtable();
                parameters.Add("@moduleId", moduleId);


                DataTable modules = Module.DataBridge.ExecuteQuery(query, parameters);
                mLastError = Module.DataBridge.LastError;

                if (modules != null && modules.Rows.Count == 1)
                {
                    description = modules.Rows[0]["description"].ToString();
                }
            }
            catch
            {
                throw;
            }

            return description;
        }

        public DataTable GetDomainsListInModule(string moduleID)
        {
            DataTable modules = new DataTable();

            try
            {
                string query = "SELECT module_id, domain_id, description FROM st_domains WHERE module_id = @moduleID ";

                Hashtable parameters = new Hashtable();
                parameters.Add("@moduleID", moduleID);

                modules = Module.DataBridge.ExecuteQuery(query, parameters);
                mLastError = Module.DataBridge.LastError;
            }
            catch
            {
                throw;
            }

            return modules;
        }

        public DataTable GetPermissionsForGroup(string groupID)
        {
            DataTable permissions = new DataTable();

            try
            {
                string query = "SELECT "
                                + "    module_id "
                                + "   , role_id "
                                + "   , domain_id "                                
                                + "   , permissions "
                                + "   , module_id " + Module.DataBridge.ConcatSimbol + " '~' " + Module.DataBridge.ConcatSimbol + " role_id " + Module.DataBridge.ConcatSimbol + " '~' " + Module.DataBridge.ConcatSimbol + " domain_id " + Module.DataBridge.ConcatSimbol + " '~' " + Module.DataBridge.ConcatSimbol + " CAST(permissions as varchar)  as \"key\" "
                                + "   , module_id " + Module.DataBridge.ConcatSimbol + " '~' " + Module.DataBridge.ConcatSimbol + " role_id " + Module.DataBridge.ConcatSimbol + " '~' " + Module.DataBridge.ConcatSimbol + " domain_id  as \"display_key\" "
                                + " FROM  "
                                + "   st_roles_permissions "
                                + " WHERE role_id = @groupID ";

                Hashtable parameters = new Hashtable();
                parameters.Add("@groupID", groupID);

                permissions = Module.DataBridge.ExecuteQuery(query, parameters);
                mLastError = Module.DataBridge.LastError;
            }
            catch
            {
                throw;
            }

            return permissions;
        }

        public bool UpdatePermissions(string moduleID, string roleID, string domainID, int permission)
        {
            bool result = false;

            try
            {
                string selectString = "SELECT * FROM st_roles_permissions WHERE module_id = @moduleID AND role_id = @roleID AND domain_id = @domainID ";

                Hashtable parameters = new Hashtable();
                parameters.Add("@moduleID", moduleID);
                parameters.Add("@roleID", roleID);
                parameters.Add("@domainID", domainID);
                parameters.Add("@permission", permission);

                DataTable existPermisssionDT = Module.DataBridge.ExecuteQuery(selectString, parameters);
                mLastError = Module.DataBridge.LastError;

                if (existPermisssionDT != null && existPermisssionDT.Rows.Count == 1)
                {
                    string updatestrig = "UPDATE st_roles_permissions SET "
                                + " permissions = @permission " 
                                + " WHERE "
                                + " module_id = @moduleID "
                                + " AND role_id = @roleID "
                                + " AND domain_id = @domainID ";

                    result = Module.DataBridge.ExecuteNonQuery(updatestrig, parameters);
                    mLastError = Module.DataBridge.LastError;
                }
                else
                {
                    string insertString = "INSERT INTO st_roles_permissions (module_id, role_id , domain_id , permissions) "
                                + "  VALUES ( @moduleID, @roleID, @domainID, @permission )  ";

                    result = Module.DataBridge.ExecuteNonQuery(insertString, parameters);
                    mLastError = Module.DataBridge.LastError;
                }        
            }
            catch
            {
                throw;
            }

            return result;
        }

        public bool DeletePermissions(string moduleID, string roleID, string domainID)
        {
            bool result = false;

            try
            {              
                string updatestrig = "DELETE FROM st_roles_permissions  "                                
                            + " WHERE "
                            + " module_id = @moduleID "
                            + " AND role_id = @roleID "
                            + " AND domain_id = @domainID ";

                Hashtable parameters = new Hashtable();
                parameters.Add("@moduleID", moduleID);
                parameters.Add("@roleID", roleID);
                parameters.Add("@domainID", domainID);

                result = Module.DataBridge.ExecuteNonQuery(updatestrig, parameters);
                mLastError = Module.DataBridge.LastError;
            }
            catch
            {
                throw;
            }

            return result;
        }
        
        #region Users Region

        public DataTable GetUserInfoByID(int userID)
        {
            DataTable usersList = new DataTable();

            try
            {
                string commandText = "SELECT  *  "
                                    + " , (SELECT name FROM Classifiers WHERE Code = passwordstatus) as passwordstatus_string "
                                    + " , (SELECT name FROM Classifiers WHERE Code = recordstatus) as recordstatus_string "
                                    + " , nume " + Plus + " Prenume as UserFullName"

                                    + "  FROM Users WHERE userID = " + userID;

                usersList = Module.DataBridge.ExecuteQuery(commandText); // PG compliant
                mLastError = Module.DataBridge.LastError;
            }
            catch
            {
                throw;
            }

            return usersList;
        }

        public DataTable UsersList()
        {
            DataTable usersList = new DataTable();

            try
            {
                string commandText = "SELECT  *  "
                                    + " , (SELECT name FROM Classifiers WHERE Code = passwordstatus) as passwordstatus_string "
                                    + " , (SELECT name FROM Classifiers WHERE Code = recordstatus) as recordstatus_string "
                                    + " , nume " + Plus + " Prenume as UserFullName"

                                    + "  FROM Users  order BY Nume, Prenume";

                usersList = Module.DataBridge.ExecuteQuery(commandText); // PG compliant
                mLastError = Module.DataBridge.LastError;
            }
            catch
            {
                throw;
            }

            return usersList;
        }

        public DataTable GetUserGroupsList(int userID)
        {
            DataTable usersList = new DataTable();

            try
            {
                string commandText = "SELECT  *  FROM st_users_roles WHERE user_id = " + userID;

                usersList = Module.DataBridge.ExecuteQuery(commandText); // PG compliant
                mLastError = Module.DataBridge.LastError;
            }
            catch
            {
                throw;
            }

            return usersList;
        }

        public bool UpdateUserPasswordByLoginAndEmail(string login, string email, string newPassword)
        {
            bool result = false;

            try
            {                
                string encryptPassword = Crypt.Module.ComputeHash(newPassword);

                string nonQuery = @"Update Users Set password = @encryptPassword  WHERE login = @login and email = @email ";

                Hashtable parameters = new Hashtable();
                parameters.Add("@encryptPassword", encryptPassword);
                parameters.Add("@login", login);
                parameters.Add("@email", email);

                result = Module.DataBridge.ExecuteNonQuery(nonQuery, parameters); // PG compliant
                mLastError = Module.DataBridge.LastError;                
            }
            catch
            {
                throw;
            }

            return result;
        }
        
        public bool DeleteUser(int userID)
        {
            bool result = false;

            try
            {                
                string nonQuery = @"Delete From Users WHERE userID = " + userID;

                result = Module.DataBridge.ExecuteNonQuery(nonQuery); // PG compliant
                mLastError = Module.DataBridge.LastError;               
            }
            catch
            {
                throw;
            }

            return result;
        }

        public bool NewUser(string Nume, string Prenume, string login, string password, string email, List<string> groupList, int passwordstatusID, int recordstatusID)
        {
            bool result = false;

            try
            {                
                string encryptPassword = Crypt.Module.ComputeHash(password);

                string nonQuery = @"INSERT INTO Users (Nume,              Prenume,           login,             password,                email,          passwordstatus,            recordstatus)"
                                        + " OUTPUT INSERTED.UserID "
                                        + " VALUES ( @Nume, @Prenume, @login, @encryptPassword, @email, @passwordstatusID, @recordstatusID)";

                Hashtable parameters = new Hashtable();
                parameters.Add("@Nume", Nume);
                parameters.Add("@Prenume", Prenume);
                parameters.Add("@login", login);
                parameters.Add("@encryptPassword", encryptPassword);
                parameters.Add("@email", email);
                parameters.Add("@passwordstatusID", passwordstatusID);
                parameters.Add("@recordstatusID", recordstatusID);

                object newUserID = Module.DataBridge.ExecuteScalarQuery(nonQuery, parameters); // PG compliant
                mLastError = Module.DataBridge.LastError;
                int userID = 0;
                if (newUserID != null)
                {
                    userID = (int)newUserID;
                }

                if (userID != 0)
                {
                    for (int i = 0; i < groupList.Count; i++)
                    {
                        string groupID = groupList[i];
                        if (!groupID.Equals(string.Empty))
                        {
                            string inserQuery = "INSERT INTO st_users_roles(user_id, role_id) VALUES (" + userID + ",'" + groupID + "')";
                            bool insertResult = Module.DataBridge.ExecuteNonQuery(inserQuery); // PG compliant
                            mLastError += Module.DataBridge.LastError;
                        }
                    }
                }                
            }
            catch
            {
                throw;
            }

            return result;
        }
        
        public bool UpdateUser(int userID, string Nume, string Prenume, string login, string password, string email, List<string> groupList, int passwordstatusID, int recordstatusID, bool updatePassword)
        {
            bool result = false;

            try
            {
                string encryptPassword = Crypt.Module.ComputeHash(password);

                string nonQuery = @"Update Users Set "
                        + " Nume = @Nume  "
                        + " , Prenume = @Prenume  "
                        + " , login = @login  "
                        + (updatePassword ? " , password = @encryptPassword  " : string.Empty)
                        + " , email = @email  "
                        //+ " , role_id = @groupID "
                        + " , passwordstatus = @passwordstatusID "
                        + " , recordstatus = @recordstatusID "

                        + " WHERE userID = " + userID;

                Hashtable parameters = new Hashtable();
                parameters.Add("@Nume", Nume);
                parameters.Add("@Prenume", Prenume);
                parameters.Add("@login", login);
                parameters.Add("@encryptPassword", encryptPassword);
                parameters.Add("@email", email);
                parameters.Add("@passwordstatusID", passwordstatusID);
                parameters.Add("@recordstatusID", recordstatusID);


                result = Module.DataBridge.ExecuteNonQuery(nonQuery, parameters); // PG compliant
                mLastError += Module.DataBridge.LastError;

                if (result)
                {
                    string deleteQuery = "DELETE FROM st_users_roles WHERE user_id = " + userID;
                    bool deleteresult = Module.DataBridge.ExecuteNonQuery(deleteQuery); // PG compliant
                    mLastError += Module.DataBridge.LastError;

                    for (int i = 0; i < groupList.Count; i++)
                    {
                        string groupID = groupList[i];
                        if (!groupID.Equals(string.Empty))
                        {
                            string inserQuery = "INSERT INTO st_users_roles(user_id, role_id) VALUES (" + userID + ",'" + groupID + "')";
                            bool insertResult = Module.DataBridge.ExecuteNonQuery(inserQuery); // PG compliant
                            mLastError += Module.DataBridge.LastError;
                        }
                    }
                }
            }
            catch
            {
                throw;
            }

            return result;
        }
        
        #endregion Users Region        
    }

    namespace Domains
    {
        /// <summary>
        /// Default domain. Calculations.
        /// </summary>
        public class Administration
        {
            public static readonly string Name = "Administration";            
        }
    }
}
