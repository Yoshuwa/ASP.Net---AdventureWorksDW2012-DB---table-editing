using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class dbo_FactSurveyResponse_dbo_DimDateDataClass307
{
    public static List<dbo_FactSurveyResponse_dbo_DimDateClass307> List()
    {
        List<dbo_FactSurveyResponse_dbo_DimDateClass307> dbo_FactSurveyResponse_dbo_DimDateList = new List<dbo_FactSurveyResponse_dbo_DimDateClass307>();
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
            dbo_FactSurveyResponse_dbo_DimDateClass307 clsdbo_FactSurveyResponse_dbo_DimDate = new dbo_FactSurveyResponse_dbo_DimDateClass307();
            while (reader.Read())
            {
                clsdbo_FactSurveyResponse_dbo_DimDate = new dbo_FactSurveyResponse_dbo_DimDateClass307();
                clsdbo_FactSurveyResponse_dbo_DimDate.DateKey = System.Convert.ToInt32(reader["DateKey"]);
                dbo_FactSurveyResponse_dbo_DimDateList.Add(clsdbo_FactSurveyResponse_dbo_DimDate);
            }
            reader.Close();
        }
        catch (SqlException)
        {
            return dbo_FactSurveyResponse_dbo_DimDateList;
        }
        finally
        {
            connection.Close();
        }
        return dbo_FactSurveyResponse_dbo_DimDateList;
    }

}

public class dbo_FactSurveyResponse_dbo_DimCustomerDataClass308
{
    public static List<dbo_FactSurveyResponse_dbo_DimCustomerClass308> List()
    {
        List<dbo_FactSurveyResponse_dbo_DimCustomerClass308> dbo_FactSurveyResponse_dbo_DimCustomerList = new List<dbo_FactSurveyResponse_dbo_DimCustomerClass308>();
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement 
            = "SELECT "  
            + "     [CustomerKey] " 
            + "FROM " 
            + "     [dbo].[DimCustomer] " 
            + "";
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        try
        {
            connection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            dbo_FactSurveyResponse_dbo_DimCustomerClass308 clsdbo_FactSurveyResponse_dbo_DimCustomer = new dbo_FactSurveyResponse_dbo_DimCustomerClass308();
            while (reader.Read())
            {
                clsdbo_FactSurveyResponse_dbo_DimCustomer = new dbo_FactSurveyResponse_dbo_DimCustomerClass308();
                clsdbo_FactSurveyResponse_dbo_DimCustomer.CustomerKey = System.Convert.ToInt32(reader["CustomerKey"]);
                dbo_FactSurveyResponse_dbo_DimCustomerList.Add(clsdbo_FactSurveyResponse_dbo_DimCustomer);
            }
            reader.Close();
        }
        catch (SqlException)
        {
            return dbo_FactSurveyResponse_dbo_DimCustomerList;
        }
        finally
        {
            connection.Close();
        }
        return dbo_FactSurveyResponse_dbo_DimCustomerList;
    }

}


 
