using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class dbo_DimProduct_dbo_DimProductSubcategoryDataClass
{
    public static List<dbo_DimProduct_dbo_DimProductSubcategoryClass> List()
    {
        List<dbo_DimProduct_dbo_DimProductSubcategoryClass> dbo_DimProduct_dbo_DimProductSubcategoryList = new List<dbo_DimProduct_dbo_DimProductSubcategoryClass>();
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement 
            = "SELECT "  
            + "     [ProductSubcategoryKey] " 
            + "    ,[EnglishProductSubcategoryName] " 
            + "FROM " 
            + "     [dbo].[DimProductSubcategory] " 
            + "";
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        try
        {
            connection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            dbo_DimProduct_dbo_DimProductSubcategoryClass clsdbo_DimProduct_dbo_DimProductSubcategory = new dbo_DimProduct_dbo_DimProductSubcategoryClass();
            while (reader.Read())
            {
                clsdbo_DimProduct_dbo_DimProductSubcategory = new dbo_DimProduct_dbo_DimProductSubcategoryClass();
                clsdbo_DimProduct_dbo_DimProductSubcategory.ProductSubcategoryKey = System.Convert.ToInt32(reader["ProductSubcategoryKey"]);
                clsdbo_DimProduct_dbo_DimProductSubcategory.EnglishProductSubcategoryName = Convert.ToString(reader["EnglishProductSubcategoryName"]);
                dbo_DimProduct_dbo_DimProductSubcategoryList.Add(clsdbo_DimProduct_dbo_DimProductSubcategory);
            }
            reader.Close();
        }
        catch (SqlException)
        {
            return dbo_DimProduct_dbo_DimProductSubcategoryList;
        }
        finally
        {
            connection.Close();
        }
        return dbo_DimProduct_dbo_DimProductSubcategoryList;
    }

}


 
