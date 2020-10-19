using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class dbo_FactCallCenter_dbo_DimDateDataClass
{
    public static List<dbo_FactCallCenter_dbo_DimDateClass> List()
    {
        List<dbo_FactCallCenter_dbo_DimDateClass> dbo_FactCallCenter_dbo_DimDateList = new List<dbo_FactCallCenter_dbo_DimDateClass>();
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
            dbo_FactCallCenter_dbo_DimDateClass clsdbo_FactCallCenter_dbo_DimDate = new dbo_FactCallCenter_dbo_DimDateClass();
            while (reader.Read())
            {
                clsdbo_FactCallCenter_dbo_DimDate = new dbo_FactCallCenter_dbo_DimDateClass();
                clsdbo_FactCallCenter_dbo_DimDate.DateKey = System.Convert.ToInt32(reader["DateKey"]);
                clsdbo_FactCallCenter_dbo_DimDate.FullDateAlternateKey = Convert.ToString(reader["FullDateAlternateKey"]);
                dbo_FactCallCenter_dbo_DimDateList.Add(clsdbo_FactCallCenter_dbo_DimDate);
            }
            reader.Close();
        }
        catch (SqlException)
        {
            return dbo_FactCallCenter_dbo_DimDateList;
        }
        finally
        {
            connection.Close();
        }
        return dbo_FactCallCenter_dbo_DimDateList;
    }

}


 
