using System;
using System.Configuration;

public class ConfigManager
{
    public static string GetDbConnectionString(string connectionStringKey)
    {
        string result = System.Configuration.ConfigurationManager.ConnectionStrings[connectionStringKey].ConnectionString;
        return result;
    }

    public static string GetProviderName(string providerNameKey)
    {
        string result = System.Configuration.ConfigurationManager.ConnectionStrings[providerNameKey].ProviderName;
        return result;
    }

    public static string GetFileDirectory(string fileDirectoryKey)
    {
        string result = System.Configuration.ConfigurationManager.AppSettings[fileDirectoryKey];
        return result;
    }   

}

