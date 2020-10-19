using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class dbo_DimProductSubcategory_dbo_DimProductCategoryDataClass
{
    public static List<dbo_DimProductSubcategory_dbo_DimProductCategoryClass> List()
    {
        List<dbo_DimProductSubcategory_dbo_DimProductCategoryClass> dbo_DimProductSubcategory_dbo_DimProductCategoryList = new List<dbo_DimProductSubcategory_dbo_DimProductCategoryClass>();
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement 
            = "SELECT "  
            + "     [ProductCategoryKey] " 
            + "    ,[EnglishProductCategoryName] " 
            + "FROM " 
            + "     [dbo].[DimProductCategory] " 
            + "";
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        try
        {
            connection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            dbo_DimProductSubcategory_dbo_DimProductCategoryClass clsdbo_DimProductSubcategory_dbo_DimProductCategory = new dbo_DimProductSubcategory_dbo_DimProductCategoryClass();
            while (reader.Read())
            {
                clsdbo_DimProductSubcategory_dbo_DimProductCategory = new dbo_DimProductSubcategory_dbo_DimProductCategoryClass();
                clsdbo_DimProductSubcategory_dbo_DimProductCategory.ProductCategoryKey = System.Convert.ToInt32(reader["ProductCategoryKey"]);
                clsdbo_DimProductSubcategory_dbo_DimProductCategory.EnglishProductCategoryName = Convert.ToString(reader["EnglishProductCategoryName"]);
                dbo_DimProductSubcategory_dbo_DimProductCategoryList.Add(clsdbo_DimProductSubcategory_dbo_DimProductCategory);
            }
            reader.Close();
        }
        catch (SqlException)
        {
            return dbo_DimProductSubcategory_dbo_DimProductCategoryList;
        }
        finally
        {
            connection.Close();
        }
        return dbo_DimProductSubcategory_dbo_DimProductCategoryList;
    }

}


 
