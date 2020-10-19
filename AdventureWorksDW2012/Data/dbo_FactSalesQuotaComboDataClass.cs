using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class dbo_FactSalesQuota_dbo_DimEmployeeDataClass300
{
    public static List<dbo_FactSalesQuota_dbo_DimEmployeeClass300> List()
    {
        List<dbo_FactSalesQuota_dbo_DimEmployeeClass300> dbo_FactSalesQuota_dbo_DimEmployeeList = new List<dbo_FactSalesQuota_dbo_DimEmployeeClass300>();
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement 
            = "SELECT "  
            + "     [EmployeeKey] " 
            + "FROM " 
            + "     [dbo].[DimEmployee] " 
            + "";
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        try
        {
            connection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            dbo_FactSalesQuota_dbo_DimEmployeeClass300 clsdbo_FactSalesQuota_dbo_DimEmployee = new dbo_FactSalesQuota_dbo_DimEmployeeClass300();
            while (reader.Read())
            {
                clsdbo_FactSalesQuota_dbo_DimEmployee = new dbo_FactSalesQuota_dbo_DimEmployeeClass300();
                clsdbo_FactSalesQuota_dbo_DimEmployee.EmployeeKey = System.Convert.ToInt32(reader["EmployeeKey"]);
                dbo_FactSalesQuota_dbo_DimEmployeeList.Add(clsdbo_FactSalesQuota_dbo_DimEmployee);
            }
            reader.Close();
        }
        catch (SqlException)
        {
            return dbo_FactSalesQuota_dbo_DimEmployeeList;
        }
        finally
        {
            connection.Close();
        }
        return dbo_FactSalesQuota_dbo_DimEmployeeList;
    }

}

public class dbo_FactSalesQuota_dbo_DimDateDataClass301
{
    public static List<dbo_FactSalesQuota_dbo_DimDateClass301> List()
    {
        List<dbo_FactSalesQuota_dbo_DimDateClass301> dbo_FactSalesQuota_dbo_DimDateList = new List<dbo_FactSalesQuota_dbo_DimDateClass301>();
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
            dbo_FactSalesQuota_dbo_DimDateClass301 clsdbo_FactSalesQuota_dbo_DimDate = new dbo_FactSalesQuota_dbo_DimDateClass301();
            while (reader.Read())
            {
                clsdbo_FactSalesQuota_dbo_DimDate = new dbo_FactSalesQuota_dbo_DimDateClass301();
                clsdbo_FactSalesQuota_dbo_DimDate.DateKey = System.Convert.ToInt32(reader["DateKey"]);
                dbo_FactSalesQuota_dbo_DimDateList.Add(clsdbo_FactSalesQuota_dbo_DimDate);
            }
            reader.Close();
        }
        catch (SqlException)
        {
            return dbo_FactSalesQuota_dbo_DimDateList;
        }
        finally
        {
            connection.Close();
        }
        return dbo_FactSalesQuota_dbo_DimDateList;
    }

}


 
