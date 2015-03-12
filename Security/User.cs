using System;
using System.Collections;
using System.Data;
using System.Collections.Generic;
using DAL;

namespace Security
{   
    public class User
    {
        int mUserID = 0;
        string mLogin = string.Empty;
        bool mIsSysadmin = false;
        string mEncryptedPassword = string.Empty;

        string mFirstName = string.Empty;
        string mLastName = string.Empty;
        string mEmailAddress = string.Empty;
        string mPersonalFolderName = string.Empty;

        // key: module - value: bool for AccessOwnLegalEntity
        List<string> mAllowedModules = null;

        // key: module - value: ModulePermissions
        Hashtable mModulePermissions = null;


        public bool IsSysadmin
        {
            get { return mIsSysadmin; }
        }

        public string UserLogin
        {
            get { return mLogin; }
        }    

        public string FirstName
        {
            get { return mFirstName; }
        }

        public string LastName
        {
            get { return mLastName; }
        }

        public int UserID
        {
            get { return mUserID; }
        }

        public string EncryptedPassword
        {
            get { return mEncryptedPassword; }
        }

        public string EmailAddress
        {
            get { return mEmailAddress; }
        }

        public User(int userID, string firstName, string lastName, string loghin, string encriptedPassword, string emailAddes, bool isSysAdmin)
        {
            mUserID = userID;
            mFirstName = firstName;
            mLastName = lastName;
            mEncryptedPassword = encriptedPassword;
            mEmailAddress = emailAddes;
            mIsSysadmin = isSysAdmin;
            LoadPermissions();
        }

        private void LoadPermissions()
        {
            // No need to load for sysadmin as he has access to all modules
            if (mIsSysadmin) return;

            string registredGroupsQuery = "Select * FROM st_users_roles WHERE user_id = " + mUserID;
            DataTable registredGroupsDT = Module.DataBridge.ExecuteQuery(registredGroupsQuery); // PG compliant

            if (registredGroupsDT != null && registredGroupsDT.Rows.Count > 0)
            {
                for (int g = 0; g < registredGroupsDT.Rows.Count; g++)
                {
                    string mGroupID = string.Empty;
                    if (registredGroupsDT.Rows[g]["role_id"] != System.DBNull.Value) mGroupID = registredGroupsDT.Rows[g]["role_id"].ToString();

                    string commandText = "SELECT * FROM st_roles_permissions WHERE role_id = '" + mGroupID + "' AND (permissions = " + (int)Constants.Classifiers.Permissions_View + " OR permissions = " + (int)Constants.Classifiers.Permissions_Edit + " ) ";

                    System.Data.DataTable resultTable = Module.DataBridge.ExecuteQuery(commandText); // PG compliant
                    string lastError = Module.DataBridge.LastError;

                    if (resultTable != null)
                    {
                        mAllowedModules = new List<string>();
                        mModulePermissions = new Hashtable();
                        for (int i = 0; i < resultTable.Rows.Count; i++)
                        {
                            if (resultTable.Rows[i]["module_id"] != DBNull.Value)
                            {
                                string moduleid = resultTable.Rows[i]["module_id"].ToString();
                                string domainid = resultTable.Rows[i]["domain_id"].ToString();

                                if (!mAllowedModules.Contains(moduleid))
                                { mAllowedModules.Add(moduleid); }

                                string permissionsKey = moduleid + "_" + domainid;
                                if (!mModulePermissions.Contains(permissionsKey))
                                { mModulePermissions.Add(permissionsKey, (int)resultTable.Rows[i]["permissions"]); }
                            }
                        }
                    }
                }
            }
        }
 

        public static User Login(string login, string password)
        {
            User user = null;

            string lastError = string.Empty;
            string loginResultMessage = "Authentication request from user \"" + login + "\" - ";

            try
            {
                if (login.Contains("'") || login.Contains(" ") || password.Contains("'") || password.Contains(" "))
                {
                    throw new Exception("Invalid characters in login or password");
                }

                string encryptedPassword = Crypt.Module.ComputeHash(password);

                string selectQuery = "SELECT * FROM users WHERE login = '" + login + "' AND password = '" + encryptedPassword + "' AND recordstatus = " + (int)Constants.Classifiers.UserRecord_Active + " ";

                DataTable userData =  Module.DataBridge.ExecuteQuery(selectQuery);

                if (userData != null && userData.Rows.Count == 1)
                {
                    loginResultMessage += "Success ";

                    int userID = 0;
                    bool isSysadmin = false;
                    string firstName = string.Empty;
                    string lastName = string.Empty;
                    string emailAddress = string.Empty;
                    string personlaFolder = string.Empty;

                    userID = int.Parse(userData.Rows[0]["UserID"].ToString());
                    firstName = userData.Rows[0]["nume"] != DBNull.Value ? userData.Rows[0]["nume"].ToString() : string.Empty;
                    lastName = userData.Rows[0]["prenume"] != DBNull.Value ? userData.Rows[0]["prenume"].ToString() : string.Empty;
                    emailAddress = userData.Rows[0]["email"] != DBNull.Value ? userData.Rows[0]["email"].ToString() : string.Empty;
                    isSysadmin = userData.Rows[0]["sysadmin"] != DBNull.Value ? (bool)userData.Rows[0]["sysadmin"] : false;

                    user = new User(userID, firstName, lastName, login, encryptedPassword, emailAddress, isSysadmin);
                }
                else
                {
                    loginResultMessage += "Failure.";

                    if (userData != null && userData.Rows.Count > 1)
                    {
                        throw new Exception("FATAL Failure. MULTIPLE ROWS RETURNED.");
                    }
                }
            }
            catch (Exception e)
            {
                lastError = e.Message;
                loginResultMessage += lastError;
            }

            return user;
        }
     
        public bool PermissionAllowed(string module, string domain,  int permission)
        {
            bool result = false;

            if (!ModuleAllowed(module))
                throw new Exception("Module access not allowed");

            if (!mIsSysadmin)
            {
                if (mModulePermissions != null)
                {
                    string moduleKey = module + "_" + domain;

                    if (mModulePermissions.Contains(moduleKey))
                    {
                        int registredPermission = (int)mModulePermissions[moduleKey];

                        if (registredPermission != (int)Constants.Classifiers.Permissions_Deny)
                            if ((registredPermission == (int)Constants.Classifiers.Permissions_Edit && permission == (int)Constants.Classifiers.Permissions_View) ||
                                registredPermission == permission)
                            {
                                result = true;
                            }
                    }                        
                }
            }
            else
            {
                result = true;
            }

            return result;
        }

        public bool ModuleAllowed(string module)
        {
            bool result = false;

            if ((mAllowedModules != null
                && mAllowedModules.Contains(module))
                || mIsSysadmin
            )
            {
                result = true;
            }

            return result;
        }      
    }
}
