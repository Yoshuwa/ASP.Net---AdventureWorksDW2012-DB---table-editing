using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class dbo_FactInternetSalesReason_dbo_FactInternetSalesDataClass262
{
    public static List<dbo_FactInternetSalesReason_dbo_FactInternetSalesClass262> List()
    {
        List<dbo_FactInternetSalesReason_dbo_FactInternetSalesClass262> dbo_FactInternetSalesReason_dbo_FactInternetSalesList = new List<dbo_FactInternetSalesReason_dbo_FactInternetSalesClass262>();
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement 
            = "SELECT "  
            + "     [SalesOrderNumber] " 
            + "    ,[ProductKey] " 
            + "FROM " 
            + "     [dbo].[FactInternetSales] " 
            + "";
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        try
        {
            connection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            dbo_FactInternetSalesReason_dbo_FactInternetSalesClass262 clsdbo_FactInternetSalesReason_dbo_FactInternetSales = new dbo_FactInternetSalesReason_dbo_FactInternetSalesClass262();
            while (reader.Read())
            {
                clsdbo_FactInternetSalesReason_dbo_FactInternetSales = new dbo_FactInternetSalesReason_dbo_FactInternetSalesClass262();
                clsdbo_FactInternetSalesReason_dbo_FactInternetSales.SalesOrderNumber = System.Convert.ToString(reader["SalesOrderNumber"]);
                clsdbo_FactInternetSalesReason_dbo_FactInternetSales.ProductKey = Convert.ToString(reader["ProductKey"]);
                dbo_FactInternetSalesReason_dbo_FactInternetSalesList.Add(clsdbo_FactInternetSalesReason_dbo_FactInternetSales);
            }
            reader.Close();
        }
        catch (SqlException)
        {
            return dbo_FactInternetSalesReason_dbo_FactInternetSalesList;
        }
        finally
        {
            connection.Close();
        }
        return dbo_FactInternetSalesReason_dbo_FactInternetSalesList;
    }

}

public class dbo_FactInternetSalesReason_dbo_FactInternetSalesDataClass263
{
    public static List<dbo_FactInternetSalesReason_dbo_FactInternetSalesClass263> List()
    {
        List<dbo_FactInternetSalesReason_dbo_FactInternetSalesClass263> dbo_FactInternetSalesReason_dbo_FactInternetSalesList = new List<dbo_FactInternetSalesReason_dbo_FactInternetSalesClass263>();
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement 
            = "SELECT "  
            + "     [SalesOrderLineNumber] " 
            + "    ,[ProductKey] " 
            + "FROM " 
            + "     [dbo].[FactInternetSales] " 
            + "";
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        try
        {
            connection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            dbo_FactInternetSalesReason_dbo_FactInternetSalesClass263 clsdbo_FactInternetSalesReason_dbo_FactInternetSales = new dbo_FactInternetSalesReason_dbo_FactInternetSalesClass263();
            while (reader.Read())
            {
                clsdbo_FactInternetSalesReason_dbo_FactInternetSales = new dbo_FactInternetSalesReason_dbo_FactInternetSalesClass263();
                clsdbo_FactInternetSalesReason_dbo_FactInternetSales.SalesOrderLineNumber = System.Convert.ToByte(reader["SalesOrderLineNumber"]);
                clsdbo_FactInternetSalesReason_dbo_FactInternetSales.ProductKey = Convert.ToString(reader["ProductKey"]);
                dbo_FactInternetSalesReason_dbo_FactInternetSalesList.Add(clsdbo_FactInternetSalesReason_dbo_FactInternetSales);
            }
            reader.Close();
        }
        catch (SqlException)
        {
            return dbo_FactInternetSalesReason_dbo_FactInternetSalesList;
        }
        finally
        {
            connection.Close();
        }
        return dbo_FactInternetSalesReason_dbo_FactInternetSalesList;
    }

}

public class dbo_FactInternetSalesReason_dbo_DimSalesReasonDataClass264
{
    public static List<dbo_FactInternetSalesReason_dbo_DimSalesReasonClass264> List()
    {
        List<dbo_FactInternetSalesReason_dbo_DimSalesReasonClass264> dbo_FactInternetSalesReason_dbo_DimSalesReasonList = new List<dbo_FactInternetSalesReason_dbo_DimSalesReasonClass264>();
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement 
            = "SELECT "  
            + "     [SalesReasonKey] " 
            + "    ,[SalesReasonName] " 
            + "FROM " 
            + "     [dbo].[DimSalesReason] " 
            + "";
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        try
        {
            connection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            dbo_FactInternetSalesReason_dbo_DimSalesReasonClass264 clsdbo_FactInternetSalesReason_dbo_DimSalesReason = new dbo_FactInternetSalesReason_dbo_DimSalesReasonClass264();
            while (reader.Read())
            {
                clsdbo_FactInternetSalesReason_dbo_DimSalesReason = new dbo_FactInternetSalesReason_dbo_DimSalesReasonClass264();
                clsdbo_FactInternetSalesReason_dbo_DimSalesReason.SalesReasonKey = System.Convert.ToInt32(reader["SalesReasonKey"]);
                clsdbo_FactInternetSalesReason_dbo_DimSalesReason.SalesReasonName = Convert.ToString(reader["SalesReasonName"]);
                dbo_FactInternetSalesReason_dbo_DimSalesReasonList.Add(clsdbo_FactInternetSalesReason_dbo_DimSalesReason);
            }
            reader.Close();
        }
        catch (SqlException)
        {
            return dbo_FactInternetSalesReason_dbo_DimSalesReasonList;
        }
        finally
        {
            connection.Close();
        }
        return dbo_FactInternetSalesReason_dbo_DimSalesReasonList;
    }

}


 
