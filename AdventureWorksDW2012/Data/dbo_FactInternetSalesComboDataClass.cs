using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class dbo_FactInternetSales_dbo_DimProductDataClass238
{
    public static List<dbo_FactInternetSales_dbo_DimProductClass238> List()
    {
        List<dbo_FactInternetSales_dbo_DimProductClass238> dbo_FactInternetSales_dbo_DimProductList = new List<dbo_FactInternetSales_dbo_DimProductClass238>();
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement 
            = "SELECT "  
            + "     [ProductKey] " 
            + "    ,[EnglishProductName] " 
            + "FROM " 
            + "     [dbo].[DimProduct] " 
            + "";
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        try
        {
            connection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            dbo_FactInternetSales_dbo_DimProductClass238 clsdbo_FactInternetSales_dbo_DimProduct = new dbo_FactInternetSales_dbo_DimProductClass238();
            while (reader.Read())
            {
                clsdbo_FactInternetSales_dbo_DimProduct = new dbo_FactInternetSales_dbo_DimProductClass238();
                clsdbo_FactInternetSales_dbo_DimProduct.ProductKey = System.Convert.ToInt32(reader["ProductKey"]);
                clsdbo_FactInternetSales_dbo_DimProduct.EnglishProductName = Convert.ToString(reader["EnglishProductName"]);
                dbo_FactInternetSales_dbo_DimProductList.Add(clsdbo_FactInternetSales_dbo_DimProduct);
            }
            reader.Close();
        }
        catch (SqlException)
        {
            return dbo_FactInternetSales_dbo_DimProductList;
        }
        finally
        {
            connection.Close();
        }
        return dbo_FactInternetSales_dbo_DimProductList;
    }

}

public class dbo_FactInternetSales_dbo_DimDateDataClass239
{
    public static List<dbo_FactInternetSales_dbo_DimDateClass239> List()
    {
        List<dbo_FactInternetSales_dbo_DimDateClass239> dbo_FactInternetSales_dbo_DimDateList = new List<dbo_FactInternetSales_dbo_DimDateClass239>();
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement 
            = "SELECT "  
            + "     [DateKey] " 
            + "    ,[FullDateAlternateKey] " 
            + "FROM " 
            + "     [dbo].[DimDate] " 
            + "";
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        try
        {
            connection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            dbo_FactInternetSales_dbo_DimDateClass239 clsdbo_FactInternetSales_dbo_DimDate = new dbo_FactInternetSales_dbo_DimDateClass239();
            while (reader.Read())
            {
                clsdbo_FactInternetSales_dbo_DimDate = new dbo_FactInternetSales_dbo_DimDateClass239();
                clsdbo_FactInternetSales_dbo_DimDate.DateKey = System.Convert.ToInt32(reader["DateKey"]);
                clsdbo_FactInternetSales_dbo_DimDate.FullDateAlternateKey = Convert.ToString(reader["FullDateAlternateKey"]);
                dbo_FactInternetSales_dbo_DimDateList.Add(clsdbo_FactInternetSales_dbo_DimDate);
            }
            reader.Close();
        }
        catch (SqlException)
        {
            return dbo_FactInternetSales_dbo_DimDateList;
        }
        finally
        {
            connection.Close();
        }
        return dbo_FactInternetSales_dbo_DimDateList;
    }

}

public class dbo_FactInternetSales_dbo_DimDateDataClass240
{
    public static List<dbo_FactInternetSales_dbo_DimDateClass240> List()
    {
        List<dbo_FactInternetSales_dbo_DimDateClass240> dbo_FactInternetSales_dbo_DimDateList = new List<dbo_FactInternetSales_dbo_DimDateClass240>();
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement 
            = "SELECT "  
            + "     [DateKey] " 
            + "    ,[FullDateAlternateKey] " 
            + "FROM " 
            + "     [dbo].[DimDate] " 
            + "";
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        try
        {
            connection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            dbo_FactInternetSales_dbo_DimDateClass240 clsdbo_FactInternetSales_dbo_DimDate = new dbo_FactInternetSales_dbo_DimDateClass240();
            while (reader.Read())
            {
                clsdbo_FactInternetSales_dbo_DimDate = new dbo_FactInternetSales_dbo_DimDateClass240();
                clsdbo_FactInternetSales_dbo_DimDate.DateKey = System.Convert.ToInt32(reader["DateKey"]);
                clsdbo_FactInternetSales_dbo_DimDate.FullDateAlternateKey = Convert.ToString(reader["FullDateAlternateKey"]);
                dbo_FactInternetSales_dbo_DimDateList.Add(clsdbo_FactInternetSales_dbo_DimDate);
            }
            reader.Close();
        }
        catch (SqlException)
        {
            return dbo_FactInternetSales_dbo_DimDateList;
        }
        finally
        {
            connection.Close();
        }
        return dbo_FactInternetSales_dbo_DimDateList;
    }

}

public class dbo_FactInternetSales_dbo_DimDateDataClass241
{
    public static List<dbo_FactInternetSales_dbo_DimDateClass241> List()
    {
        List<dbo_FactInternetSales_dbo_DimDateClass241> dbo_FactInternetSales_dbo_DimDateList = new List<dbo_FactInternetSales_dbo_DimDateClass241>();
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement 
            = "SELECT "  
            + "     [DateKey] " 
            + "    ,[FullDateAlternateKey] " 
            + "FROM " 
            + "     [dbo].[DimDate] " 
            + "";
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        try
        {
            connection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            dbo_FactInternetSales_dbo_DimDateClass241 clsdbo_FactInternetSales_dbo_DimDate = new dbo_FactInternetSales_dbo_DimDateClass241();
            while (reader.Read())
            {
                clsdbo_FactInternetSales_dbo_DimDate = new dbo_FactInternetSales_dbo_DimDateClass241();
                clsdbo_FactInternetSales_dbo_DimDate.DateKey = System.Convert.ToInt32(reader["DateKey"]);
                clsdbo_FactInternetSales_dbo_DimDate.FullDateAlternateKey = Convert.ToString(reader["FullDateAlternateKey"]);
                dbo_FactInternetSales_dbo_DimDateList.Add(clsdbo_FactInternetSales_dbo_DimDate);
            }
            reader.Close();
        }
        catch (SqlException)
        {
            return dbo_FactInternetSales_dbo_DimDateList;
        }
        finally
        {
            connection.Close();
        }
        return dbo_FactInternetSales_dbo_DimDateList;
    }

}

public class dbo_FactInternetSales_dbo_DimCustomerDataClass242
{
    public static List<dbo_FactInternetSales_dbo_DimCustomerClass242> List()
    {
        List<dbo_FactInternetSales_dbo_DimCustomerClass242> dbo_FactInternetSales_dbo_DimCustomerList = new List<dbo_FactInternetSales_dbo_DimCustomerClass242>();
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement 
            = "SELECT "  
            + "     [CustomerKey] " 
            + "    ,[FirstName] " 
            + "FROM " 
            + "     [dbo].[DimCustomer] " 
            + "";
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        try
        {
            connection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            dbo_FactInternetSales_dbo_DimCustomerClass242 clsdbo_FactInternetSales_dbo_DimCustomer = new dbo_FactInternetSales_dbo_DimCustomerClass242();
            while (reader.Read())
            {
                clsdbo_FactInternetSales_dbo_DimCustomer = new dbo_FactInternetSales_dbo_DimCustomerClass242();
                clsdbo_FactInternetSales_dbo_DimCustomer.CustomerKey = System.Convert.ToInt32(reader["CustomerKey"]);
                clsdbo_FactInternetSales_dbo_DimCustomer.FirstName = Convert.ToString(reader["FirstName"]);
                dbo_FactInternetSales_dbo_DimCustomerList.Add(clsdbo_FactInternetSales_dbo_DimCustomer);
            }
            reader.Close();
        }
        catch (SqlException)
        {
            return dbo_FactInternetSales_dbo_DimCustomerList;
        }
        finally
        {
            connection.Close();
        }
        return dbo_FactInternetSales_dbo_DimCustomerList;
    }

}

public class dbo_FactInternetSales_dbo_DimPromotionDataClass243
{
    public static List<dbo_FactInternetSales_dbo_DimPromotionClass243> List()
    {
        List<dbo_FactInternetSales_dbo_DimPromotionClass243> dbo_FactInternetSales_dbo_DimPromotionList = new List<dbo_FactInternetSales_dbo_DimPromotionClass243>();
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement 
            = "SELECT "  
            + "     [PromotionKey] " 
            + "    ,[EnglishPromotionName] " 
            + "FROM " 
            + "     [dbo].[DimPromotion] " 
            + "";
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        try
        {
            connection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            dbo_FactInternetSales_dbo_DimPromotionClass243 clsdbo_FactInternetSales_dbo_DimPromotion = new dbo_FactInternetSales_dbo_DimPromotionClass243();
            while (reader.Read())
            {
                clsdbo_FactInternetSales_dbo_DimPromotion = new dbo_FactInternetSales_dbo_DimPromotionClass243();
                clsdbo_FactInternetSales_dbo_DimPromotion.PromotionKey = System.Convert.ToInt32(reader["PromotionKey"]);
                clsdbo_FactInternetSales_dbo_DimPromotion.EnglishPromotionName = Convert.ToString(reader["EnglishPromotionName"]);
                dbo_FactInternetSales_dbo_DimPromotionList.Add(clsdbo_FactInternetSales_dbo_DimPromotion);
            }
            reader.Close();
        }
        catch (SqlException)
        {
            return dbo_FactInternetSales_dbo_DimPromotionList;
        }
        finally
        {
            connection.Close();
        }
        return dbo_FactInternetSales_dbo_DimPromotionList;
    }

}

public class dbo_FactInternetSales_dbo_DimCurrencyDataClass244
{
    public static List<dbo_FactInternetSales_dbo_DimCurrencyClass244> List()
    {
        List<dbo_FactInternetSales_dbo_DimCurrencyClass244> dbo_FactInternetSales_dbo_DimCurrencyList = new List<dbo_FactInternetSales_dbo_DimCurrencyClass244>();
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
            dbo_FactInternetSales_dbo_DimCurrencyClass244 clsdbo_FactInternetSales_dbo_DimCurrency = new dbo_FactInternetSales_dbo_DimCurrencyClass244();
            while (reader.Read())
            {
                clsdbo_FactInternetSales_dbo_DimCurrency = new dbo_FactInternetSales_dbo_DimCurrencyClass244();
                clsdbo_FactInternetSales_dbo_DimCurrency.CurrencyKey = System.Convert.ToInt32(reader["CurrencyKey"]);
                clsdbo_FactInternetSales_dbo_DimCurrency.CurrencyName = Convert.ToString(reader["CurrencyName"]);
                dbo_FactInternetSales_dbo_DimCurrencyList.Add(clsdbo_FactInternetSales_dbo_DimCurrency);
            }
            reader.Close();
        }
        catch (SqlException)
        {
            return dbo_FactInternetSales_dbo_DimCurrencyList;
        }
        finally
        {
            connection.Close();
        }
        return dbo_FactInternetSales_dbo_DimCurrencyList;
    }

}

public class dbo_FactInternetSales_dbo_DimSalesTerritoryDataClass245
{
    public static List<dbo_FactInternetSales_dbo_DimSalesTerritoryClass245> List()
    {
        List<dbo_FactInternetSales_dbo_DimSalesTerritoryClass245> dbo_FactInternetSales_dbo_DimSalesTerritoryList = new List<dbo_FactInternetSales_dbo_DimSalesTerritoryClass245>();
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
            dbo_FactInternetSales_dbo_DimSalesTerritoryClass245 clsdbo_FactInternetSales_dbo_DimSalesTerritory = new dbo_FactInternetSales_dbo_DimSalesTerritoryClass245();
            while (reader.Read())
            {
                clsdbo_FactInternetSales_dbo_DimSalesTerritory = new dbo_FactInternetSales_dbo_DimSalesTerritoryClass245();
                clsdbo_FactInternetSales_dbo_DimSalesTerritory.SalesTerritoryKey = System.Convert.ToInt32(reader["SalesTerritoryKey"]);
                clsdbo_FactInternetSales_dbo_DimSalesTerritory.SalesTerritoryAlternateKey = Convert.ToString(reader["SalesTerritoryAlternateKey"]);
                dbo_FactInternetSales_dbo_DimSalesTerritoryList.Add(clsdbo_FactInternetSales_dbo_DimSalesTerritory);
            }
            reader.Close();
        }
        catch (SqlException)
        {
            return dbo_FactInternetSales_dbo_DimSalesTerritoryList;
        }
        finally
        {
            connection.Close();
        }
        return dbo_FactInternetSales_dbo_DimSalesTerritoryList;
    }

}


 
