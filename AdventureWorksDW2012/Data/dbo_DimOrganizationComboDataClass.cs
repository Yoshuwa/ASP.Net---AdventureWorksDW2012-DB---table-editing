using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class dbo_DimOrganization_dbo_DimOrganizationDataClass109
{
    public static List<dbo_DimOrganization_dbo_DimOrganizationClass109> List()
    {
        List<dbo_DimOrganization_dbo_DimOrganizationClass109> dbo_DimOrganization_dbo_DimOrganizationList = new List<dbo_DimOrganization_dbo_DimOrganizationClass109>();
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement 
            = "SELECT "  
            + "     [OrganizationKey] " 
            + "    ,[OrganizationName] " 
            + "FROM " 
            + "     [dbo].[DimOrganization] " 
            + "";
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        try
        {
            connection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            dbo_DimOrganization_dbo_DimOrganizationClass109 clsdbo_DimOrganization_dbo_DimOrganization = new dbo_DimOrganization_dbo_DimOrganizationClass109();
            while (reader.Read())
            {
                clsdbo_DimOrganization_dbo_DimOrganization = new dbo_DimOrganization_dbo_DimOrganizationClass109();
                clsdbo_DimOrganization_dbo_DimOrganization.OrganizationKey = System.Convert.ToInt32(reader["OrganizationKey"]);
                clsdbo_DimOrganization_dbo_DimOrganization.OrganizationName = Convert.ToString(reader["OrganizationName"]);
                dbo_DimOrganization_dbo_DimOrganizationList.Add(clsdbo_DimOrganization_dbo_DimOrganization);
            }
            reader.Close();
        }
        catch (SqlException)
        {
            return dbo_DimOrganization_dbo_DimOrganizationList;
        }
        finally
        {
            connection.Close();
        }
        return dbo_DimOrganization_dbo_DimOrganizationList;
    }

}

public class dbo_DimOrganization_dbo_DimCurrencyDataClass112
{
    public static List<dbo_DimOrganization_dbo_DimCurrencyClass112> List()
    {
        List<dbo_DimOrganization_dbo_DimCurrencyClass112> dbo_DimOrganization_dbo_DimCurrencyList = new List<dbo_DimOrganization_dbo_DimCurrencyClass112>();
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement 
            = "SELECT "  
            + "     [CurrencyKey] " 
            + "    ,[CurrencyName] " 
            + "FROM " 
            + "     [dbo].[DimCurrency] " 
            + "";
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        try
        {
            connection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            dbo_DimOrganization_dbo_DimCurrencyClass112 clsdbo_DimOrganization_dbo_DimCurrency = new dbo_DimOrganization_dbo_DimCurrencyClass112();
            while (reader.Read())
            {
                clsdbo_DimOrganization_dbo_DimCurrency = new dbo_DimOrganization_dbo_DimCurrencyClass112();
                clsdbo_DimOrganization_dbo_DimCurrency.CurrencyKey = System.Convert.ToInt32(reader["CurrencyKey"]);
                clsdbo_DimOrganization_dbo_DimCurrency.CurrencyName = Convert.ToString(reader["CurrencyName"]);
                dbo_DimOrganization_dbo_DimCurrencyList.Add(clsdbo_DimOrganization_dbo_DimCurrency);
            }
            reader.Close();
        }
        catch (SqlException)
        {
            return dbo_DimOrganization_dbo_DimCurrencyList;
        }
        finally
        {
            connection.Close();
        }
        return dbo_DimOrganization_dbo_DimCurrencyList;
    }

}


 
