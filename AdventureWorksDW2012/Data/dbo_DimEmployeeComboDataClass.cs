using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class dbo_DimEmployee_dbo_DimEmployeeDataClass68
{
    public static List<dbo_DimEmployee_dbo_DimEmployeeClass68> List()
    {
        List<dbo_DimEmployee_dbo_DimEmployeeClass68> dbo_DimEmployee_dbo_DimEmployeeList = new List<dbo_DimEmployee_dbo_DimEmployeeClass68>();
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement 
            = "SELECT "  
            + "     [ParentEmployeeKey] " 
            + "    ,[FirstName] " 
            + "FROM " 
            + "     [dbo].[DimEmployee] " 
            + "";
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        try
        {
            connection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            dbo_DimEmployee_dbo_DimEmployeeClass68 clsdbo_DimEmployee_dbo_DimEmployee = new dbo_DimEmployee_dbo_DimEmployeeClass68();
            while (reader.Read())
            {
                clsdbo_DimEmployee_dbo_DimEmployee = new dbo_DimEmployee_dbo_DimEmployeeClass68();
                clsdbo_DimEmployee_dbo_DimEmployee.ParentEmployeeKey = System.Convert.ToInt32(reader["ParentEmployeeKey"]);
                clsdbo_DimEmployee_dbo_DimEmployee.FirstName = Convert.ToString(reader["FirstName"]);
                dbo_DimEmployee_dbo_DimEmployeeList.Add(clsdbo_DimEmployee_dbo_DimEmployee);
            }
            reader.Close();
        }
        catch (SqlException)
        {
            return dbo_DimEmployee_dbo_DimEmployeeList;
        }
        finally
        {
            connection.Close();
        }
        return dbo_DimEmployee_dbo_DimEmployeeList;
    }

}

public class dbo_DimEmployee_dbo_DimSalesTerritoryDataClass71
{
    public static List<dbo_DimEmployee_dbo_DimSalesTerritoryClass71> List()
    {
        List<dbo_DimEmployee_dbo_DimSalesTerritoryClass71> dbo_DimEmployee_dbo_DimSalesTerritoryList = new List<dbo_DimEmployee_dbo_DimSalesTerritoryClass71>();
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement 
            = "SELECT "  
            + "     [SalesTerritoryAlternateKey] " 
            + "FROM " 
            + "     [dbo].[DimSalesTerritory] " 
            + "";
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        try
        {
            connection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            dbo_DimEmployee_dbo_DimSalesTerritoryClass71 clsdbo_DimEmployee_dbo_DimSalesTerritory = new dbo_DimEmployee_dbo_DimSalesTerritoryClass71();
            while (reader.Read())
            {
                clsdbo_DimEmployee_dbo_DimSalesTerritory = new dbo_DimEmployee_dbo_DimSalesTerritoryClass71();
                clsdbo_DimEmployee_dbo_DimSalesTerritory.SalesTerritoryAlternateKey = System.Convert.ToInt32(reader["SalesTerritoryAlternateKey"]);
                dbo_DimEmployee_dbo_DimSalesTerritoryList.Add(clsdbo_DimEmployee_dbo_DimSalesTerritory);
            }
            reader.Close();
        }
        catch (SqlException)
        {
            return dbo_DimEmployee_dbo_DimSalesTerritoryList;
        }
        finally
        {
            connection.Close();
        }
        return dbo_DimEmployee_dbo_DimSalesTerritoryList;
    }

}


 
