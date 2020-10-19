using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class dbo_DimGeography_dbo_DimSalesTerritoryDataClass
{
    public static List<dbo_DimGeography_dbo_DimSalesTerritoryClass> List()
    {
        List<dbo_DimGeography_dbo_DimSalesTerritoryClass> dbo_DimGeography_dbo_DimSalesTerritoryList = new List<dbo_DimGeography_dbo_DimSalesTerritoryClass>();
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement 
            = "SELECT "  
            + "     [SalesTerritoryKey] " 
            + "    ,[SalesTerritoryAlternateKey] " 
            + "FROM " 
            + "     [dbo].[DimSalesTerritory] " 
            + "";
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        try
        {
            connection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            dbo_DimGeography_dbo_DimSalesTerritoryClass clsdbo_DimGeography_dbo_DimSalesTerritory = new dbo_DimGeography_dbo_DimSalesTerritoryClass();
            while (reader.Read())
            {
                clsdbo_DimGeography_dbo_DimSalesTerritory = new dbo_DimGeography_dbo_DimSalesTerritoryClass();
                clsdbo_DimGeography_dbo_DimSalesTerritory.SalesTerritoryKey = System.Convert.ToInt32(reader["SalesTerritoryKey"]);
                clsdbo_DimGeography_dbo_DimSalesTerritory.SalesTerritoryAlternateKey = Convert.ToString(reader["SalesTerritoryAlternateKey"]);
                dbo_DimGeography_dbo_DimSalesTerritoryList.Add(clsdbo_DimGeography_dbo_DimSalesTerritory);
            }
            reader.Close();
        }
        catch (SqlException)
        {
            return dbo_DimGeography_dbo_DimSalesTerritoryList;
        }
        finally
        {
            connection.Close();
        }
        return dbo_DimGeography_dbo_DimSalesTerritoryList;
    }

}


 
