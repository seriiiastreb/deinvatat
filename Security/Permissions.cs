using System;
using System.Data;

namespace Security
{
    public class Permissions
    {
        public static void UpdateModulesDomains()
        {
            //ModuleInfo.Hrpm.Module.Register();
            //ModuleInfo.Ta.Module.Register();
            //ModuleInfo.Te.Module.Register();
            //ModuleInfo.Cl.Module.Register();
            //ModuleInfo.Arch.Module.Register();
            //ModuleInfo.Ahr.Module.Register();
        }



        //public static DataTable GetAllowedModules()
        //{
        //    DataTable allowedModules = new DataTable();

        //    DataBridge dataBridge = new DataBridge(HRPM.Config.ConfigManager.DbConnectionString, HRPM.Config.ConfigManager.DbProvider);

        //    try
        //    {
        //        if (dataBridge.Connect() == true)
        //        {
        //            string query = "SELECT * FROM le_modules order by le_id, module_id ";

        //            allowedModules = dataBridge.ExecuteQuery(query);
        //        }
        //        else
        //        {
        //            throw new Exception(dataBridge.LastError);
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        // TODO: Decide what to do
        //    }
        //    finally
        //    {
        //    }

        //    return allowedModules;
        //}

        //public static DataTable GetAllowedModules(string legalEntityId)
        //{
        //    DataTable allowedModules = new DataTable();

        //    DataBridge dataBridge = new DataBridge(HRPM.Config.ConfigManager.DbConnectionString, HRPM.Config.ConfigManager.DbProvider);

        //    try
        //    {
        //        if (dataBridge.Connect() == true)
        //        {
        //            string query = "SELECT * FROM le_modules "
        //                + "WHERE le_id = '" + legalEntityId + "' "
        //                + "order by le_id, module_id ";

        //            allowedModules = dataBridge.ExecuteQuery(query);
        //        }
        //        else
        //        {
        //            throw new Exception(dataBridge.LastError);
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        // TODO: Decide what to do
        //    }
        //    finally
        //    {
        //    }

        //    return allowedModules;
        //}

        public static bool AllowedModule(DAL.DataBridge mDataBridge, string moduleId, Security.User mUser)
        {
            bool result = false;

            try
            {
                if(mUser != null)
                {
                    //string query = "SELECT * FROM le_modules WHERE le_id = '" + legalEntityId + "' AND module_id = '" + moduleId + "' order by le_id, module_id ";

                    //DataTable allowedModules = mDataBridge.ExecuteQuery(query);

                    //if (allowedModules != null && allowedModules.Rows.Count == 1)
                    //{
                    //    result = true;
                    //}
                }
                else
                {
                    throw new Exception("Not Autentificated user");
                }
            }
            catch 
            {
                // TODO: Decide what to do
            }
           
            return result;
        }

        //public static bool AllowModule(string legalEntityId, string moduleId)
        //{
        //    DataBridge dataBridge = new DataBridge(HRPM.Config.ConfigManager.DbConnectionString, HRPM.Config.ConfigManager.DbProvider);

        //    bool result = false;
        //    try
        //    {
        //        if (dataBridge.Connect() == true)
        //        {
        //            Logger.LogInfo("Allowing module " + moduleId + " for " + legalEntityId);

        //            string commandInsertModule = "INSERT INTO le_modules ( le_id, module_id) "
        //            + "VALUES ( "
        //            + " '" + legalEntityId + "' "
        //            + ", '" + moduleId + "' "
        //            + ") ";

        //            result = dataBridge.ExecuteNonQuery(commandInsertModule); // PG compliant

        //            if (result)
        //            {
        //                Logger.LogInfo("AllowED module " + moduleId + " for " + legalEntityId);
        //            }
        //            else
        //            {
        //                throw new Exception("Failure allowing module " + moduleId + " for " + legalEntityId + ". " + dataBridge.LastError);
        //            }
        //        }
        //        else
        //        {
        //            throw new Exception(dataBridge.LastError);
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //    }

        //    return result;
        //}

        //public static bool ProhibitModule(string legalEntityId, string moduleId)
        //{
        //    DataBridge dataBridge = new DataBridge(HRPM.Config.ConfigManager.DbConnectionString, HRPM.Config.ConfigManager.DbProvider);

        //    string lastError = string.Empty;
        //    bool result = false;
        //    try
        //    {
        //        Logger.LogInfo("Deleting module " + moduleId + " for " + legalEntityId);

        //        string commandDeleteModule = "DELETE FROM le_modules "
        //        + "WHERE le_id = '" + legalEntityId + "' "
        //        + "AND module_id = '" + moduleId + "' ";

        //        result = dataBridge.ExecuteNonQuery(commandDeleteModule); // PG compliant
        //        lastError = dataBridge.LastError;

        //        if (result)
        //        {
        //            Logger.LogInfo("DeletED module " + moduleId + " for " + legalEntityId);
        //        }
        //        else
        //        {
        //            throw new Exception("Failure deleting module " + moduleId + " for " + legalEntityId + ". " + lastError);
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //    }

        //    return result;
        //}

        //public static DataTable GetRoles(string legalEntity, string moduleId)
        //{
        //    DataTable definedRoles = new DataTable();

        //    DataBridge dataBridge = new DataBridge(HRPM.Config.ConfigManager.DbConnectionString, HRPM.Config.ConfigManager.DbProvider);

        //    try
        //    {
        //        string query = "SELECT * FROM roles WHERE le_id = '" + legalEntity + "' AND module_id = '" + moduleId + "' order by le_id, module_id, role_id ";

        //        definedRoles = dataBridge.ExecuteQuery(query);
        //    }
        //    catch (Exception e)
        //    {
        //        // TODO: Decide what to do
        //    }
        //    finally
        //    {
        //    }

        //    return definedRoles;
        //}

        //public static bool AddRole(string legalEntityId, string roleId, string moduleId, bool isPredefined)
        //{
        //    bool isModuleAllowed = ModuleAllowed(legalEntityId, moduleId);
        //    DataBridge dataBridge = new DataBridge(HRPM.Config.ConfigManager.DbConnectionString, HRPM.Config.ConfigManager.DbProvider);

        //    bool result = false;
        //    try
        //    {
        //        if (isModuleAllowed)
        //        {
        //            Logger.LogInfo("Adding role " + roleId + " in " + moduleId + " for " + legalEntityId);

        //            string commandInsertModule = "INSERT INTO roles ( le_id, module_id, role_id, is_predefined) "
        //            + "VALUES ( "
        //            + " '" + legalEntityId + "' "
        //            + ", '" + moduleId + "' "
        //            + ", '" + roleId + "' "
        //            + ", " + dataBridge.BoolString(isPredefined) + " "
        //            + ") ";

        //            result = dataBridge.ExecuteNonQuery(commandInsertModule); // PG compliant

        //            if (result)
        //            {
        //                Logger.LogInfo("AddED role " + roleId + " in " + moduleId + " for " + legalEntityId);
        //            }
        //            else
        //            {
        //                throw new Exception("Failure adding role " + roleId + " in " + moduleId + " for " + legalEntityId + ". " + dataBridge.LastError);
        //            }
        //        }
        //        else
        //        {
        //            Logger.LogInfo("Not allowed module " + moduleId + " for " + legalEntityId);
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //    }

        //    return result;
        //}

        //public static bool DeleteRole(string legalEntityId, string moduleId, string roleId)
        //{
        //    DataBridge dataBridge = new DataBridge(HRPM.Config.ConfigManager.DbConnectionString, HRPM.Config.ConfigManager.DbProvider);

        //    string lastError = string.Empty;
        //    bool result = false;
        //    try
        //    {
        //        Logger.LogInfo("Deleting role " + roleId + " in " + moduleId + " for " + legalEntityId);

        //        string commandDeleteModule = "DELETE FROM roles "
        //        + "WHERE le_id = '" + legalEntityId + "' "
        //        + "AND module_id = '" + moduleId + "' "
        //        + "AND role_id = '" + roleId + "' ";

        //        result = dataBridge.ExecuteNonQuery(commandDeleteModule); // PG compliant
        //        lastError = dataBridge.LastError;

        //        if (result)
        //        {
        //            Logger.LogInfo("DeletED role " + roleId + " in " + moduleId + " for " + legalEntityId);
        //        }
        //        else
        //        {
        //            throw new Exception("Failure deleting role " + roleId + " in " + moduleId + " for " + legalEntityId + ". " + lastError);
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //    }

        //    return result;
        //}

        //public static DataTable GetPermissions(string legalEntity, string module, string role)
        //{
        //    DataTable domains = new DataTable();

        //    DataBridge dataBridge = new DataBridge(HRPM.Config.ConfigManager.DbConnectionString, HRPM.Config.ConfigManager.DbProvider);

        //    try
        //    {
        //        string query = "SELECT le_id, module_id, role_id, domain_id, permission FROM role_permissions  WHERE le_id = '" + legalEntity + "' AND module_id = '" + module + "' AND role_id = '" + role + "' order by le_id, module_id, role_id, domain_id";

        //        domains = dataBridge.ExecuteQuery(query);
        //    }
        //    catch (Exception e)
        //    {
        //        // TODO: Decide what to do
        //    }
        //    finally
        //    {
        //    }

        //    return domains;
        //}

        //public static int GetPermission(string legalEntity, string module, string role, string domain)
        //{
        //    int permission = 0;

        //    DataTable permissions = new DataTable();

        //    DataBridge dataBridge = new DataBridge(HRPM.Config.ConfigManager.DbConnectionString, HRPM.Config.ConfigManager.DbProvider);

        //    try
        //    {
        //        string query = "SELECT le_id, module_id, role_id, domain_id, permission FROM permission_domains  WHERE le_id = '" + legalEntity + "' AND module_id = '" + module + "' AND role_id = '" + role + "' AND domain_id = '" + domain + "' order by le_id, module_id, role_id, domain_id, permission ";

        //        permissions = dataBridge.ExecuteQuery(query);

        //        if (permissions != null && permissions.Rows.Count == 1)
        //        {
        //            int.TryParse(permissions.Rows[0]["permissino"].ToString(), out permission);
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        // TODO: Decide what to do
        //    }
        //    finally
        //    {
        //    }

        //    return permission;
        //}

        //public static bool AddPermission(string legalEntityId, string moduleId, string roleId, string domainId, int permission)
        //{
        //    bool isModuleAllowed = ModuleAllowed(legalEntityId, moduleId);
        //    DataBridge dataBridge = new DataBridge(HRPM.Config.ConfigManager.DbConnectionString, HRPM.Config.ConfigManager.DbProvider);

        //    bool result = false;
        //    try
        //    {
        //        if (isModuleAllowed)
        //        {
        //            Logger.LogInfo("Adding permission " + permission + " in " + domainId + " for " + roleId + " in " + moduleId + " for " + legalEntityId);

        //            string commandInsertModule = "INSERT INTO role_permissions ( le_id, module_id, role_id, domain_id, permission) "
        //            + "VALUES ( "
        //            + " '" + legalEntityId + "' "
        //            + ", '" + moduleId + "' "
        //            + ", '" + roleId + "' "
        //            + ", '" + domainId + "' "
        //            + ", " + permission + " "
        //            + ") ";

        //            result = dataBridge.ExecuteNonQuery(commandInsertModule); // PG compliant

        //            if (result)
        //            {
        //                Logger.LogInfo("AddED permission " + permission + " in " + domainId + " for " + roleId + " in " + moduleId + " for " + legalEntityId);
        //            }
        //            else
        //            {
        //                throw new Exception("Failure adding permission " + permission + " in " + domainId + " for " + roleId + " in " + moduleId + " for " + legalEntityId + ". " + dataBridge.LastError);
        //            }
        //        }
        //        else { Logger.LogInfo("Not allowed module " + moduleId + " for " + legalEntityId); }
        //    }
        //    catch (Exception e)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //    }

        //    return result;
        //}

        //public static bool DeletePermission(string legalEntityId, string moduleId, string roleId, string domainId, int permission)
        //{
        //    DataBridge dataBridge = new DataBridge(HRPM.Config.ConfigManager.DbConnectionString, HRPM.Config.ConfigManager.DbProvider);

        //    bool result = false;
        //    try
        //    {
        //        Logger.LogInfo("Deleting permission " + permission + " in " + domainId + " for " + roleId + " in " + moduleId + " for " + legalEntityId);

        //        string nonQuery = "DELETE FROM role_permissions  "
        //        + "WHERE le_id = '" + legalEntityId + "' "
        //        + "AND module_id = '" + moduleId + "' "
        //        + "AND role_id = '" + roleId + "' "
        //        + "AND domain_id = '" + domainId + "'  ";

        //        result = dataBridge.ExecuteNonQuery(nonQuery); // PG compliant

        //        if (result)
        //        {
        //            Logger.LogInfo("AddED permission " + permission + " in " + domainId + " for " + roleId + " in " + moduleId + " for " + legalEntityId);
        //        }
        //        else
        //        {
        //            throw new Exception("Failure adding permission " + permission + " in " + domainId + " for " + roleId + " in " + moduleId + " for " + legalEntityId + ". " + dataBridge.LastError);
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //    }

        //    return result;
        //}

        //public static DataTable GetLEAccessTable()
        //{
        //    DataTable leAccessTable = new DataTable();

        //    DataBridge dataBridge = new DataBridge(HRPM.Config.ConfigManager.DbConnectionString, HRPM.Config.ConfigManager.DbProvider);

        //    try
        //    {
        //        string query = "SELECT * "
        //            + ", (Select users.login FROM users WHERE users.userid = le_access.userid) AS \"login\" "
        //            + ", (Select users.firstname FROM users WHERE le_access.userid=users.userid) AS \"firstname\" "
        //            + ", (Select users.lastname FROM users WHERE le_access.userid=users.userid) AS \"lastname\" "
        //            + " FROM le_access  "
        //            + " ORDER BY le_access.le_id, le_access.module_id ";

        //        leAccessTable = dataBridge.ExecuteQuery(query);
        //    }
        //    catch (Exception e)
        //    {
        //        // TODO: Decide what to do
        //    }
        //    finally
        //    {
        //        dataBridge.Disconnect();
        //    }

        //    return leAccessTable;
        //}

        //public static DataTable GetLEAccessTable(string moduleId)
        //{
        //    DataTable leAccessTable = new DataTable();

        //    DataBridge dataBridge = new DataBridge(HRPM.Config.ConfigManager.DbConnectionString, HRPM.Config.ConfigManager.DbProvider);

        //    try
        //    {
        //        string query = "SELECT * "
        //            + ", (Select users.login FROM users WHERE users.userid = le_access.userid) AS \"login\" "
        //            + ", (Select users.firstname FROM users WHERE le_access.userid=users.userid) AS \"firstname\" "
        //            + ", (Select users.lastname FROM users WHERE le_access.userid=users.userid) AS \"lastname\" "
        //            + " FROM le_access  "
        //            + " WHERE le_access.module_id = '" + moduleId + "' "
        //            + " ORDER BY le_access.le_id, le_access.module_id ";

        //        leAccessTable = dataBridge.ExecuteQuery(query);
        //    }
        //    catch (Exception e)
        //    {
        //        // TODO: Decide what to do
        //    }
        //    finally
        //    {
        //    }

        //    return leAccessTable;
        //}

        //public static DataTable GetLEAccessTable(List<string> legalEntities, string moduleId)
        //{
        //    DataTable leAccessTable = new DataTable();

        //    DataBridge dataBridge = new DataBridge(HRPM.Config.ConfigManager.DbConnectionString, HRPM.Config.ConfigManager.DbProvider);

        //    string leCSV = string.Empty;

        //    try
        //    {
        //        for (int i = 0; i < legalEntities.Count; i++)
        //        {
        //            if (i == 0)
        //            {
        //                leCSV = " '" + legalEntities[i] + "' ";
        //            }
        //            else
        //            {
        //                leCSV += ", '" + legalEntities[i] + "' ";
        //            }
        //        }

        //        string query = "SELECT * "
        //            + ", (Select users.login FROM users WHERE users.userid = le_access.userid) AS \"login\" "
        //            + ", (Select users.firstname FROM users WHERE le_access.userid=users.userid) AS \"firstname\" "
        //            + ", (Select users.lastname FROM users WHERE le_access.userid=users.userid) AS \"lastname\" "
        //            + " FROM le_access  "
        //            + " WHERE le_access.le_id IN (" + leCSV + ") "
        //            + " AND le_access.module_id = '" + moduleId + "' "
        //            + " ORDER BY le_access.le_id, le_access.module_id ";

        //        leAccessTable = dataBridge.ExecuteQuery(query);
        //    }
        //    catch (Exception e)
        //    {
        //        // TODO: Decide what to do
        //    }
        //    finally
        //    {
        //    }

        //    return leAccessTable;
        //}

        //public static DataTable GetLEAccessTable(string moduleId, int userId)
        //{
        //    DataTable leAccessTable = new DataTable();

        //    DataBridge dataBridge = new DataBridge(HRPM.Config.ConfigManager.DbConnectionString, HRPM.Config.ConfigManager.DbProvider);

        //    try
        //    {
        //        string query = "SELECT * "
        //            + ", (Select users.login FROM users WHERE users.userid = le_access.userid) AS \"login\" "
        //            + ", (Select users.firstname FROM users WHERE le_access.userid=users.userid) AS \"firstname\" "
        //            + ", (Select users.lastname FROM users WHERE le_access.userid=users.userid) AS \"lastname\" "
        //            + " FROM le_access  "
        //            + " WHERE le_access.userid = " + userId + " "
        //            + " AND le_access.module_id = '" + moduleId + "' "
        //            + " ORDER BY le_access.le_id, le_access.module_id ";

        //        leAccessTable = dataBridge.ExecuteQuery(query);
        //    }
        //    catch (Exception e)
        //    {
        //        // TODO: Decide what to do
        //    }
        //    finally
        //    {
        //    }

        //    return leAccessTable;
        //}

        //public static bool AddLEAccess(string legalEntityId, string moduleId, int userId)
        //{
        //    DataBridge dataBridge = new DataBridge(HRPM.Config.ConfigManager.DbConnectionString, HRPM.Config.ConfigManager.DbProvider);

        //    bool result = false;
        //    try
        //    {
        //        Logger.LogInfo("Adding le_access " + legalEntityId + " in " + moduleId + " for " + userId);

        //        string commandInsertEntry = "INSERT INTO le_access ( le_id, module_id, userid) "
        //        + "VALUES ( "
        //        + " '" + legalEntityId + "' "
        //        + ", '" + moduleId + "' "
        //        + ", " + userId + " "
        //        + ") ";

        //        result = dataBridge.ExecuteNonQuery(commandInsertEntry); // PG compliant

        //        if (result)
        //        {
        //            Logger.LogInfo("AddED le_access " + legalEntityId + " in " + moduleId + " for " + userId);
        //        }
        //        else
        //        {
        //            throw new Exception("Failure adding le_access " + legalEntityId + " in " + moduleId + " for " + userId + ". " + dataBridge.LastError);
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //    }

        //    return result;
        //}

        //public static bool DeleteLEAccess(string legalEntityId, string moduleId, int userId)
        //{
        //    DataBridge dataBridge = new DataBridge(HRPM.Config.ConfigManager.DbConnectionString, HRPM.Config.ConfigManager.DbProvider);

        //    bool result = false;
        //    try
        //    {
        //        Logger.LogInfo("Deleting le_access " + legalEntityId + " in " + moduleId + " for " + userId);

        //        string nonQuery = "DELETE FROM le_access  "
        //        + "WHERE le_id = '" + legalEntityId + "' "
        //        + "AND module_id = '" + moduleId + "' "
        //        + "AND userid = " + userId + " ";

        //        result = dataBridge.ExecuteNonQuery(nonQuery); // PG compliant

        //        if (result)
        //        {
        //            Logger.LogInfo("Deleted le_access " + legalEntityId + " in " + moduleId + " for " + userId);
        //        }
        //        else
        //        {
        //            throw new Exception("Failure deleting le_access " + legalEntityId + " in " + moduleId + " for " + userId + ". " + dataBridge.LastError);
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //    }

        //    return result;
        //}

        //#region UserRoles
        //public static DataTable GetUserRoles(string legalEntity, string moduleId)
        //{
        //    DataTable userRolesTable = new DataTable();

        //    DataBridge dataBridge = new DataBridge(HRPM.Config.ConfigManager.DbConnectionString, HRPM.Config.ConfigManager.DbProvider);

        //    try
        //    {
        //        string query = @"SELECT * "
        //            + ", (Select tu.login FROM users tu WHERE tu.userid=tur.user_id) AS \"login\" "
        //            + " FROM user_roles tur "
        //            + " WHERE tur.le_id = '" + legalEntity + "' "
        //            + " AND tur.module_id = '" + moduleId + "' "
        //            + " ORDER BY tur.le_id, tur.module_id, tur.role_id ";

        //        userRolesTable = dataBridge.ExecuteQuery(query);
        //    }
        //    catch (Exception e)
        //    {
        //        // TODO: Decide what to do
        //    }
        //    finally
        //    {
        //    }

        //    return userRolesTable;
        //}

        //public static bool DeleteUserRoles(string legalEntityId, string moduleId, string role_id, int userId)
        //{
        //    DataBridge dataBridge = new DataBridge(HRPM.Config.ConfigManager.DbConnectionString, HRPM.Config.ConfigManager.DbProvider);

        //    bool result = false;
        //    try
        //    {
        //        Logger.LogInfo("Deleting user roles " + legalEntityId + " in " + moduleId + " for " + userId + " and roleid " + role_id);

        //        string nonQuery = "DELETE FROM user_roles  "
        //        + " WHERE le_id = '" + legalEntityId + "' "
        //        + " AND module_id = '" + moduleId + "' "
        //        + " AND role_id = '" + role_id + "' "
        //        + " AND user_id = " + userId + " ";

        //        result = dataBridge.ExecuteNonQuery(nonQuery); // PG compliant

        //        if (result)
        //        {
        //            Logger.LogInfo("Deleted user_roles " + legalEntityId + " in " + moduleId + " for " + userId + " and roleid " + role_id);
        //        }
        //        else
        //        {
        //            throw new Exception("Failure deleted user_roles " + legalEntityId + " in " + moduleId + " for " + userId + " and roleid " + role_id + ". " + dataBridge.LastError);
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //    }

        //    return result;
        //}

        //public static bool AddUserRoles(string legalEntityId, string moduleId, string role_id, int userId)
        //{

        //    bool isModuleAllowed = ModuleAllowed(legalEntityId, moduleId);

        //    DataBridge dataBridge = new DataBridge(HRPM.Config.ConfigManager.DbConnectionString, HRPM.Config.ConfigManager.DbProvider);

        //    bool result = false;
        //    try
        //    {
        //        bool isDuplicate = IsDuplicateUserRoles(legalEntityId, moduleId, userId);

        //        Logger.LogInfo("Adding user_roles " + legalEntityId + " in " + moduleId + " for " + userId + "  and role " + role_id);
        //        if (isModuleAllowed)
        //        {
        //            if (isDuplicate)
        //            {
        //                string commandUpdateEntry = @"UPDATE user_roles SET "
        //                    + " role_id = '" + role_id + "' "
        //                    + " WHERE le_id = '" + legalEntityId + "' "
        //                    + " AND module_id ='" + moduleId + "' "
        //                    + " AND user_id = " + userId + " "
        //                    + " ";
        //                result = dataBridge.ExecuteNonQuery(commandUpdateEntry);
        //            }
        //            else
        //            {
        //                string commandInsertEntry = "INSERT INTO user_roles (le_id, module_id, role_id, user_id) "
        //                + "VALUES ( "
        //                + " '" + legalEntityId + "' "
        //                + ", '" + moduleId + "' "
        //                + ", '" + role_id + "' "
        //                + ", " + userId + " "
        //                + ") ";

        //                result = dataBridge.ExecuteNonQuery(commandInsertEntry); // PG compliant
        //            }
        //            if (result)
        //            {
        //                Logger.LogInfo("Added user_roles " + legalEntityId + " in " + moduleId + " for " + userId + "  and role " + role_id);
        //            }
        //            else
        //            {
        //                throw new Exception("Failure adding user_roles " + legalEntityId + " in " + moduleId + " for " + userId + "  and role " + role_id + ". " + dataBridge.LastError);
        //            }
        //        }
        //        else
        //        {
        //            Logger.LogInfo("Not allowed module " + moduleId + " for " + legalEntityId);
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //    }

        //    return result;
        //}

        //public static bool IsDuplicateUserRoles(string legalEntityId, string moduleId, int userId)
        //{
        //    bool result = false;

        //    try
        //    {
        //        DataTable sourceTable = GetUserRoles(legalEntityId, moduleId);
        //        if (sourceTable != null && sourceTable.Rows.Count > 0)
        //        {
        //            DataRow[] selectedRow = sourceTable.Select("user_id = " + userId);
        //            if (selectedRow != null && selectedRow.Length > 0)
        //            {
        //                result = true;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //
        //    }
        //    return result;
        //}
        //#endregion UserRoles
    }
}
