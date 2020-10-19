using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class dbo_FactResellerSales_dbo_DimProductDataClass274
{
    public static List<dbo_FactResellerSales_dbo_DimProductClass274> List()
    {
        List<dbo_FactResellerSales_dbo_DimProductClass274> dbo_FactResellerSales_dbo_DimProductList = new List<dbo_FactResellerSales_dbo_DimProductClass274>();
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
            dbo_FactResellerSales_dbo_DimProductClass274 clsdbo_FactResellerSales_dbo_DimProduct = new dbo_FactResellerSales_dbo_DimProductClass274();
            while (reader.Read())
            {
                clsdbo_FactResellerSales_dbo_DimProduct = new dbo_FactResellerSales_dbo_DimProductClass274();
                clsdbo_FactResellerSales_dbo_DimProduct.ProductKey = System.Convert.ToInt32(reader["ProductKey"]);
                clsdbo_FactResellerSales_dbo_DimProduct.ProductAlternateKey = Convert.ToString(reader["ProductAlternateKey"]);
                dbo_FactResellerSales_dbo_DimProductList.Add(clsdbo_FactResellerSales_dbo_DimProduct);
            }
            reader.Close();
        }
        catch (SqlException)
        {
            return dbo_FactResellerSales_dbo_DimProductList;
        }
        finally
        {
            connection.Close();
        }
        return dbo_FactResellerSales_dbo_DimProductList;
    }

}

public class dbo_FactResellerSales_dbo_DimDateDataClass275
{
    public static List<dbo_FactResellerSales_dbo_DimDateClass275> List()
    {
        List<dbo_FactResellerSales_dbo_DimDateClass275> dbo_FactResellerSales_dbo_DimDateList = new List<dbo_FactResellerSales_dbo_DimDateClass275>();
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
            dbo_FactResellerSales_dbo_DimDateClass275 clsdbo_FactResellerSales_dbo_DimDate = new dbo_FactResellerSales_dbo_DimDateClass275();
            while (reader.Read())
            {
                clsdbo_FactResellerSales_dbo_DimDate = new dbo_FactResellerSales_dbo_DimDateClass275();
                clsdbo_FactResellerSales_dbo_DimDate.DateKey = System.Convert.ToInt32(reader["DateKey"]);
                dbo_FactResellerSales_dbo_DimDateList.Add(clsdbo_FactResellerSales_dbo_DimDate);
            }
            reader.Close();
        }
        catch (SqlException)
        {
            return dbo_FactResellerSales_dbo_DimDateList;
        }
        finally
        {
            connection.Close();
        }
        return dbo_FactResellerSales_dbo_DimDateList;
    }

}

public class dbo_FactResellerSales_dbo_DimDateDataClass276
{
    public static List<dbo_FactResellerSales_dbo_DimDateClass276> List()
    {
        List<dbo_FactResellerSales_dbo_DimDateClass276> dbo_FactResellerSales_dbo_DimDateList = new List<dbo_FactResellerSales_dbo_DimDateClass276>();
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
            dbo_FactResellerSales_dbo_DimDateClass276 clsdbo_FactResellerSales_dbo_DimDate = new dbo_FactResellerSales_dbo_DimDateClass276();
            while (reader.Read())
            {
                clsdbo_FactResellerSales_dbo_DimDate = new dbo_FactResellerSales_dbo_DimDateClass276();
                clsdbo_FactResellerSales_dbo_DimDate.DateKey = System.Convert.ToInt32(reader["DateKey"]);
                dbo_FactResellerSales_dbo_DimDateList.Add(clsdbo_FactResellerSales_dbo_DimDate);
            }
            reader.Close();
        }
        catch (SqlException)
        {
            return dbo_FactResellerSales_dbo_DimDateList;
        }
        finally
        {
            connection.Close();
        }
        return dbo_FactResellerSales_dbo_DimDateList;
    }

}

public class dbo_FactResellerSales_dbo_DimDateDataClass277
{
    public static List<dbo_FactResellerSales_dbo_DimDateClass277> List()
    {
        List<dbo_FactResellerSales_dbo_DimDateClass277> dbo_FactResellerSales_dbo_DimDateList = new List<dbo_FactResellerSales_dbo_DimDateClass277>();
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
            dbo_FactResellerSales_dbo_DimDateClass277 clsdbo_FactResellerSales_dbo_DimDate = new dbo_FactResellerSales_dbo_DimDateClass277();
            while (reader.Read())
            {
                clsdbo_FactResellerSales_dbo_DimDate = new dbo_FactResellerSales_dbo_DimDateClass277();
                clsdbo_FactResellerSales_dbo_DimDate.DateKey = System.Convert.ToInt32(reader["DateKey"]);
                dbo_FactResellerSales_dbo_DimDateList.Add(clsdbo_FactResellerSales_dbo_DimDate);
            }
            reader.Close();
        }
        catch (SqlException)
        {
            return dbo_FactResellerSales_dbo_DimDateList;
        }
        finally
        {
            connection.Close();
        }
        return dbo_FactResellerSales_dbo_DimDateList;
    }

}

public class dbo_FactResellerSales_dbo_DimResellerDataClass278
{
    public static List<dbo_FactResellerSales_dbo_DimResellerClass278> List()
    {
        List<dbo_FactResellerSales_dbo_DimResellerClass278> dbo_FactResellerSales_dbo_DimResellerList = new List<dbo_FactResellerSales_dbo_DimResellerClass278>();
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement 
            = "SELECT "  
            + "     [ResellerKey] " 
            + "FROM " 
            + "     [dbo].[DimReseller] " 
            + "";
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        try
        {
            connection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            dbo_FactResellerSales_dbo_DimResellerClass278 clsdbo_FactResellerSales_dbo_DimReseller = new dbo_FactResellerSales_dbo_DimResellerClass278();
            while (reader.Read())
            {
                clsdbo_FactResellerSales_dbo_DimReseller = new dbo_FactResellerSales_dbo_DimResellerClass278();
                clsdbo_FactResellerSales_dbo_DimReseller.ResellerKey = System.Convert.ToInt32(reader["ResellerKey"]);
                dbo_FactResellerSales_dbo_DimResellerList.Add(clsdbo_FactResellerSales_dbo_DimReseller);
            }
            reader.Close();
        }
        catch (SqlException)
        {
            return dbo_FactResellerSales_dbo_DimResellerList;
        }
        finally
        {
            connection.Close();
        }
        return dbo_FactResellerSales_dbo_DimResellerList;
    }

}

public class dbo_FactResellerSales_dbo_DimEmployeeDataClass279
{
    public static List<dbo_FactResellerSales_dbo_DimEmployeeClass279> List()
    {
        List<dbo_FactResellerSales_dbo_DimEmployeeClass279> dbo_FactResellerSales_dbo_DimEmployeeList = new List<dbo_FactResellerSales_dbo_DimEmployeeClass279>();
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
            dbo_FactResellerSales_dbo_DimEmployeeClass279 clsdbo_FactResellerSales_dbo_DimEmployee = new dbo_FactResellerSales_dbo_DimEmployeeClass279();
            while (reader.Read())
            {
                clsdbo_FactResellerSales_dbo_DimEmployee = new dbo_FactResellerSales_dbo_DimEmployeeClass279();
                clsdbo_FactResellerSales_dbo_DimEmployee.EmployeeKey = System.Convert.ToInt32(reader["EmployeeKey"]);
                dbo_FactResellerSales_dbo_DimEmployeeList.Add(clsdbo_FactResellerSales_dbo_DimEmployee);
            }
            reader.Close();
        }
        catch (SqlException)
        {
            return dbo_FactResellerSales_dbo_DimEmployeeList;
        }
        finally
        {
            connection.Close();
        }
        return dbo_FactResellerSales_dbo_DimEmployeeList;
    }

}

public class dbo_FactResellerSales_dbo_DimPromotionDataClass280
{
    public static List<dbo_FactResellerSales_dbo_DimPromotionClass280> List()
    {
        List<dbo_FactResellerSales_dbo_DimPromotionClass280> dbo_FactResellerSales_dbo_DimPromotionList = new List<dbo_FactResellerSales_dbo_DimPromotionClass280>();
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement 
            = "SELECT "  
            + "     [PromotionKey] " 
            + "FROM " 
            + "     [dbo].[DimPromotion] " 
            + "";
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        try
        {
            connection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            dbo_FactResellerSales_dbo_DimPromotionClass280 clsdbo_FactResellerSales_dbo_DimPromotion = new dbo_FactResellerSales_dbo_DimPromotionClass280();
            while (reader.Read())
            {
                clsdbo_FactResellerSales_dbo_DimPromotion = new dbo_FactResellerSales_dbo_DimPromotionClass280();
                clsdbo_FactResellerSales_dbo_DimPromotion.PromotionKey = System.Convert.ToInt32(reader["PromotionKey"]);
                dbo_FactResellerSales_dbo_DimPromotionList.Add(clsdbo_FactResellerSales_dbo_DimPromotion);
            }
            reader.Close();
        }
        catch (SqlException)
        {
            return dbo_FactResellerSales_dbo_DimPromotionList;
        }
        finally
        {
            connection.Close();
        }
        return dbo_FactResellerSales_dbo_DimPromotionList;
    }

}

public class dbo_FactResellerSales_dbo_DimCurrencyDataClass281
{
    public static List<dbo_FactResellerSales_dbo_DimCurrencyClass281> List()
    {
        List<dbo_FactResellerSales_dbo_DimCurrencyClass281> dbo_FactResellerSales_dbo_DimCurrencyList = new List<dbo_FactResellerSales_dbo_DimCurrencyClass281>();
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement 
            = "SELECT "  
            + "     [CurrencyKey] " 
            + "FROM " 
            + "     [dbo].[DimCurrency] " 
            + "";
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        try
        {
            connection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            dbo_FactResellerSales_dbo_DimCurrencyClass281 clsdbo_FactResellerSales_dbo_DimCurrency = new dbo_FactResellerSales_dbo_DimCurrencyClass281();
            while (reader.Read())
            {
                clsdbo_FactResellerSales_dbo_DimCurrency = new dbo_FactResellerSales_dbo_DimCurrencyClass281();
                clsdbo_FactResellerSales_dbo_DimCurrency.CurrencyKey = System.Convert.ToInt32(reader["CurrencyKey"]);
                dbo_FactResellerSales_dbo_DimCurrencyList.Add(clsdbo_FactResellerSales_dbo_DimCurrency);
            }
            reader.Close();
        }
        catch (SqlException)
        {
            return dbo_FactResellerSales_dbo_DimCurrencyList;
        }
        finally
        {
            connection.Close();
        }
        return dbo_FactResellerSales_dbo_DimCurrencyList;
    }

}

public class dbo_FactResellerSales_dbo_DimSalesTerritoryDataClass282
{
    public static List<dbo_FactResellerSales_dbo_DimSalesTerritoryClass282> List()
    {
        List<dbo_FactResellerSales_dbo_DimSalesTerritoryClass282> dbo_FactResellerSales_dbo_DimSalesTerritoryList = new List<dbo_FactResellerSales_dbo_DimSalesTerritoryClass282>();
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement 
            = "SELECT "  
            + "     [SalesTerritoryKey] " 
            + "FROM " 
            + "     [dbo].[DimSalesTerritory] " 
            + "";
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        try
        {
            connection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            dbo_FactResellerSales_dbo_DimSalesTerritoryClass282 clsdbo_FactResellerSales_dbo_DimSalesTerritory = new dbo_FactResellerSales_dbo_DimSalesTerritoryClass282();
            while (reader.Read())
            {
                clsdbo_FactResellerSales_dbo_DimSalesTerritory = new dbo_FactResellerSales_dbo_DimSalesTerritoryClass282();
                clsdbo_FactResellerSales_dbo_DimSalesTerritory.SalesTerritoryKey = System.Convert.ToInt32(reader["SalesTerritoryKey"]);
                dbo_FactResellerSales_dbo_DimSalesTerritoryList.Add(clsdbo_FactResellerSales_dbo_DimSalesTerritory);
            }
            reader.Close();
        }
        catch (SqlException)
        {
            return dbo_FactResellerSales_dbo_DimSalesTerritoryList;
        }
        finally
        {
            connection.Close();
        }
        return dbo_FactResellerSales_dbo_DimSalesTerritoryList;
    }

}


 
