using System;
using System.Data;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace Security
{
    public class Registrar
    {
        public static void RegisterModule(string moduleId, string description)
        {
            string lastError = string.Empty;
            try
            {
                string commandUpdateModule = "UPDATE st_modules "
                    + "SET description = '" + description + "' "
                    + "WHERE module_id = '" + moduleId + "' "
                    + " ";

                bool result = Security.Module.DataBridge.ExecuteNonQuery(commandUpdateModule); // PG compliant
                lastError = Security.Module.DataBridge.LastError;

                // failed to update, then register
                if (!result)
                {
                    string commandInsertModule = "INSERT INTO st_modules (module_id, description) "
                    + "VALUES ( "
                    + " '" + moduleId + "' "
                    + ", '" + description + "' "
                    + ") ";

                    bool resultOfInsert = Security.Module.DataBridge.ExecuteNonQuery(commandInsertModule); // PG compliant
                    lastError = Security.Module.DataBridge.LastError;

                    if (!resultOfInsert)                    
                    {
                        throw new Exception("Failure registering module " + moduleId + ". " + lastError);
                    }
                }               
            }
            catch
            {
                throw;
            }            
        }

        public static bool RegisterDomain(string moduleId, string domainId, string description)
        {
            string lastError = string.Empty;
            bool result = false;
            try
            {
                string selectQuery = "SELECT * FROM st_domains WHERE module_id = '" + moduleId + "' AND domain_id = '" + domainId + "'  ";
                DataTable existDomainDT = Module.DataBridge.ExecuteQuery(selectQuery);
                lastError = Module.DataBridge.LastError;

                if (existDomainDT != null && existDomainDT.Rows.Count == 1)
                {
                    string updateCommand = "UPDATE st_domains SET description = '" + description + "' WHERE module_id = '" + moduleId + "' AND domain_id = '" + domainId + "' ";
                    result = Security.Module.DataBridge.ExecuteNonQuery(updateCommand); // PG compliant
                    lastError = Module.DataBridge.LastError;      
                }
                else
                {
                    string commandInsertDomain = "INSERT INTO st_domains (module_id, domain_id, description) "
                        + "VALUES ( "
                        + " '" + moduleId + "' "
                        + ", '" + domainId + "' "
                        + ", '" + description + "' "
                        + ") ";

                    result = Security.Module.DataBridge.ExecuteNonQuery(commandInsertDomain); // PG compliant
                    lastError = Module.DataBridge.LastError;                    
                }
            }
            catch 
            {
                throw new Exception("Failure registering domain \"" + domainId + "\"  in \"" + moduleId + "\". " + lastError);
            }
            
            return result;
        }
    }
}
