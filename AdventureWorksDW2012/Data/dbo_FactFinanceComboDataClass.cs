using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class dbo_FactFinance_dbo_DimDateDataClass229
{
    public static List<dbo_FactFinance_dbo_DimDateClass229> List()
    {
        List<dbo_FactFinance_dbo_DimDateClass229> dbo_FactFinance_dbo_DimDateList = new List<dbo_FactFinance_dbo_DimDateClass229>();
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement 
            = "SELECT "  
            + "     [DateKey] " 
            + "FROM " 
            + "     [dbo].[DimDate] " 
            + "";
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        try
        {
            connection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            dbo_FactFinance_dbo_DimDateClass229 clsdbo_FactFinance_dbo_DimDate = new dbo_FactFinance_dbo_DimDateClass229();
            while (reader.Read())
            {
                clsdbo_FactFinance_dbo_DimDate = new dbo_FactFinance_dbo_DimDateClass229();
                clsdbo_FactFinance_dbo_DimDate.DateKey = System.Convert.ToInt32(reader["DateKey"]);
                dbo_FactFinance_dbo_DimDateList.Add(clsdbo_FactFinance_dbo_DimDate);
            }
            reader.Close();
        }
        catch (SqlException)
        {
            return dbo_FactFinance_dbo_DimDateList;
        }
        finally
        {
            connection.Close();
        }
        return dbo_FactFinance_dbo_DimDateList;
    }

}

public class dbo_FactFinance_dbo_DimOrganizationDataClass230
{
    public static List<dbo_FactFinance_dbo_DimOrganizationClass230> List()
    {
        List<dbo_FactFinance_dbo_DimOrganizationClass230> dbo_FactFinance_dbo_DimOrganizationList = new List<dbo_FactFinance_dbo_DimOrganizationClass230>();
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
            dbo_FactFinance_dbo_DimOrganizationClass230 clsdbo_FactFinance_dbo_DimOrganization = new dbo_FactFinance_dbo_DimOrganizationClass230();
            while (reader.Read())
            {
                clsdbo_FactFinance_dbo_DimOrganization = new dbo_FactFinance_dbo_DimOrganizationClass230();
                clsdbo_FactFinance_dbo_DimOrganization.OrganizationKey = System.Convert.ToInt32(reader["OrganizationKey"]);
                clsdbo_FactFinance_dbo_DimOrganization.OrganizationName = Convert.ToString(reader["OrganizationName"]);
                dbo_FactFinance_dbo_DimOrganizationList.Add(clsdbo_FactFinance_dbo_DimOrganization);
            }
            reader.Close();
        }
        catch (SqlException)
        {
            return dbo_FactFinance_dbo_DimOrganizationList;
        }
        finally
        {
            connection.Close();
        }
        return dbo_FactFinance_dbo_DimOrganizationList;
    }

}

public class dbo_FactFinance_dbo_DimDepartmentGroupDataClass231
{
    public static List<dbo_FactFinance_dbo_DimDepartmentGroupClass231> List()
    {
        List<dbo_FactFinance_dbo_DimDepartmentGroupClass231> dbo_FactFinance_dbo_DimDepartmentGroupList = new List<dbo_FactFinance_dbo_DimDepartmentGroupClass231>();
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement 
            = "SELECT "  
            + "     [DepartmentGroupKey] " 
            + "    ,[DepartmentGroupName] " 
            + "FROM " 
            + "     [dbo].[DimDepartmentGroup] " 
            + "";
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        try
        {
            connection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            dbo_FactFinance_dbo_DimDepartmentGroupClass231 clsdbo_FactFinance_dbo_DimDepartmentGroup = new dbo_FactFinance_dbo_DimDepartmentGroupClass231();
            while (reader.Read())
            {
                clsdbo_FactFinance_dbo_DimDepartmentGroup = new dbo_FactFinance_dbo_DimDepartmentGroupClass231();
                clsdbo_FactFinance_dbo_DimDepartmentGroup.DepartmentGroupKey = System.Convert.ToInt32(reader["DepartmentGroupKey"]);
                clsdbo_FactFinance_dbo_DimDepartmentGroup.DepartmentGroupName = Convert.ToString(reader["DepartmentGroupName"]);
                dbo_FactFinance_dbo_DimDepartmentGroupList.Add(clsdbo_FactFinance_dbo_DimDepartmentGroup);
            }
            reader.Close();
        }
        catch (SqlException)
        {
            return dbo_FactFinance_dbo_DimDepartmentGroupList;
        }
        finally
        {
            connection.Close();
        }
        return dbo_FactFinance_dbo_DimDepartmentGroupList;
    }

}

public class dbo_FactFinance_dbo_DimScenarioDataClass232
{
    public static List<dbo_FactFinance_dbo_DimScenarioClass232> List()
    {
        List<dbo_FactFinance_dbo_DimScenarioClass232> dbo_FactFinance_dbo_DimScenarioList = new List<dbo_FactFinance_dbo_DimScenarioClass232>();
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement 
            = "SELECT "  
            + "     [ScenarioKey] " 
            + "    ,[ScenarioName] " 
            + "FROM " 
            + "     [dbo].[DimScenario] " 
            + "";
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        try
        {
            connection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            dbo_FactFinance_dbo_DimScenarioClass232 clsdbo_FactFinance_dbo_DimScenario = new dbo_FactFinance_dbo_DimScenarioClass232();
            while (reader.Read())
            {
                clsdbo_FactFinance_dbo_DimScenario = new dbo_FactFinance_dbo_DimScenarioClass232();
                clsdbo_FactFinance_dbo_DimScenario.ScenarioKey = System.Convert.ToInt32(reader["ScenarioKey"]);
                clsdbo_FactFinance_dbo_DimScenario.ScenarioName = Convert.ToString(reader["ScenarioName"]);
                dbo_FactFinance_dbo_DimScenarioList.Add(clsdbo_FactFinance_dbo_DimScenario);
            }
            reader.Close();
        }
        catch (SqlException)
        {
            return dbo_FactFinance_dbo_DimScenarioList;
        }
        finally
        {
            connection.Close();
        }
        return dbo_FactFinance_dbo_DimScenarioList;
    }

}

public class dbo_FactFinance_dbo_DimAccountDataClass233
{
    public static List<dbo_FactFinance_dbo_DimAccountClass233> List()
    {
        List<dbo_FactFinance_dbo_DimAccountClass233> dbo_FactFinance_dbo_DimAccountList = new List<dbo_FactFinance_dbo_DimAccountClass233>();
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement 
            = "SELECT "  
            + "     [AccountKey] " 
            + "    ,[ParentAccountKey] " 
            + "FROM " 
            + "     [dbo].[DimAccount] " 
            + "";
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        try
        {
            connection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            dbo_FactFinance_dbo_DimAccountClass233 clsdbo_FactFinance_dbo_DimAccount = new dbo_FactFinance_dbo_DimAccountClass233();
            while (reader.Read())
            {
                clsdbo_FactFinance_dbo_DimAccount = new dbo_FactFinance_dbo_DimAccountClass233();
                clsdbo_FactFinance_dbo_DimAccount.AccountKey = System.Convert.ToInt32(reader["AccountKey"]);
                clsdbo_FactFinance_dbo_DimAccount.ParentAccountKey = Convert.ToString(reader["ParentAccountKey"]);
                dbo_FactFinance_dbo_DimAccountList.Add(clsdbo_FactFinance_dbo_DimAccount);
            }
            reader.Close();
        }
        catch (SqlException)
        {
            return dbo_FactFinance_dbo_DimAccountList;
        }
        finally
        {
            connection.Close();
        }
        return dbo_FactFinance_dbo_DimAccountList;
    }

}


 
