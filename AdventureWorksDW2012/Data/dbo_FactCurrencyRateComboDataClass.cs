using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class dbo_FactCurrencyRate_dbo_DimCurrencyDataClass223
{
    public static List<dbo_FactCurrencyRate_dbo_DimCurrencyClass223> List()
    {
        List<dbo_FactCurrencyRate_dbo_DimCurrencyClass223> dbo_FactCurrencyRate_dbo_DimCurrencyList = new List<dbo_FactCurrencyRate_dbo_DimCurrencyClass223>();
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
            dbo_FactCurrencyRate_dbo_DimCurrencyClass223 clsdbo_FactCurrencyRate_dbo_DimCurrency = new dbo_FactCurrencyRate_dbo_DimCurrencyClass223();
            while (reader.Read())
            {
                clsdbo_FactCurrencyRate_dbo_DimCurrency = new dbo_FactCurrencyRate_dbo_DimCurrencyClass223();
                clsdbo_FactCurrencyRate_dbo_DimCurrency.CurrencyKey = System.Convert.ToInt32(reader["CurrencyKey"]);
                clsdbo_FactCurrencyRate_dbo_DimCurrency.CurrencyName = Convert.ToString(reader["CurrencyName"]);
                dbo_FactCurrencyRate_dbo_DimCurrencyList.Add(clsdbo_FactCurrencyRate_dbo_DimCurrency);
            }
            reader.Close();
        }
        catch (SqlException)
        {
            return dbo_FactCurrencyRate_dbo_DimCurrencyList;
        }
        finally
        {
            connection.Close();
        }
        return dbo_FactCurrencyRate_dbo_DimCurrencyList;
    }

}

public class dbo_FactCurrencyRate_dbo_DimDateDataClass224
{
    public static List<dbo_FactCurrencyRate_dbo_DimDateClass224> List()
    {
        List<dbo_FactCurrencyRate_dbo_DimDateClass224> dbo_FactCurrencyRate_dbo_DimDateList = new List<dbo_FactCurrencyRate_dbo_DimDateClass224>();
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
            dbo_FactCurrencyRate_dbo_DimDateClass224 clsdbo_FactCurrencyRate_dbo_DimDate = new dbo_FactCurrencyRate_dbo_DimDateClass224();
            while (reader.Read())
            {
                clsdbo_FactCurrencyRate_dbo_DimDate = new dbo_FactCurrencyRate_dbo_DimDateClass224();
                clsdbo_FactCurrencyRate_dbo_DimDate.DateKey = System.Convert.ToInt32(reader["DateKey"]);
                clsdbo_FactCurrencyRate_dbo_DimDate.FullDateAlternateKey = Convert.ToString(reader["FullDateAlternateKey"]);
                dbo_FactCurrencyRate_dbo_DimDateList.Add(clsdbo_FactCurrencyRate_dbo_DimDate);
            }
            reader.Close();
        }
        catch (SqlException)
        {
            return dbo_FactCurrencyRate_dbo_DimDateList;
        }
        finally
        {
            connection.Close();
        }
        return dbo_FactCurrencyRate_dbo_DimDateList;
    }

}


 
