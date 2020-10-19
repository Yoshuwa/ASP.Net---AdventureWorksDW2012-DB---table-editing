using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class dbo_FactProductInventory_dbo_DimProductDataClass265
{
    public static List<dbo_FactProductInventory_dbo_DimProductClass265> List()
    {
        List<dbo_FactProductInventory_dbo_DimProductClass265> dbo_FactProductInventory_dbo_DimProductList = new List<dbo_FactProductInventory_dbo_DimProductClass265>();
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement 
            = "SELECT "  
            + "     [ProductKey] " 
            + "    ,[ProductAlternateKey] " 
            + "FROM " 
            + "     [dbo].[DimProduct] " 
            + "";
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        try
        {
            connection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            dbo_FactProductInventory_dbo_DimProductClass265 clsdbo_FactProductInventory_dbo_DimProduct = new dbo_FactProductInventory_dbo_DimProductClass265();
            while (reader.Read())
            {
                clsdbo_FactProductInventory_dbo_DimProduct = new dbo_FactProductInventory_dbo_DimProductClass265();
                clsdbo_FactProductInventory_dbo_DimProduct.ProductKey = System.Convert.ToInt32(reader["ProductKey"]);
                clsdbo_FactProductInventory_dbo_DimProduct.ProductAlternateKey = Convert.ToString(reader["ProductAlternateKey"]);
                dbo_FactProductInventory_dbo_DimProductList.Add(clsdbo_FactProductInventory_dbo_DimProduct);
            }
            reader.Close();
        }
        catch (SqlException)
        {
            return dbo_FactProductInventory_dbo_DimProductList;
        }
        finally
        {
            connection.Close();
        }
        return dbo_FactProductInventory_dbo_DimProductList;
    }

}

public class dbo_FactProductInventory_dbo_DimDateDataClass266
{
    public static List<dbo_FactProductInventory_dbo_DimDateClass266> List()
    {
        List<dbo_FactProductInventory_dbo_DimDateClass266> dbo_FactProductInventory_dbo_DimDateList = new List<dbo_FactProductInventory_dbo_DimDateClass266>();
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement 
            = "SELECT "  
            + "     [DateKey] " 
            + "    ,[EnglishDayNameOfWeek] " 
            + "FROM " 
            + "     [dbo].[DimDate] " 
            + "";
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        try
        {
            connection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            dbo_FactProductInventory_dbo_DimDateClass266 clsdbo_FactProductInventory_dbo_DimDate = new dbo_FactProductInventory_dbo_DimDateClass266();
            while (reader.Read())
            {
                clsdbo_FactProductInventory_dbo_DimDate = new dbo_FactProductInventory_dbo_DimDateClass266();
                clsdbo_FactProductInventory_dbo_DimDate.DateKey = System.Convert.ToInt32(reader["DateKey"]);
                clsdbo_FactProductInventory_dbo_DimDate.EnglishDayNameOfWeek = Convert.ToString(reader["EnglishDayNameOfWeek"]);
                dbo_FactProductInventory_dbo_DimDateList.Add(clsdbo_FactProductInventory_dbo_DimDate);
            }
            reader.Close();
        }
        catch (SqlException)
        {
            return dbo_FactProductInventory_dbo_DimDateList;
        }
        finally
        {
            connection.Close();
        }
        return dbo_FactProductInventory_dbo_DimDateList;
    }

}


 
