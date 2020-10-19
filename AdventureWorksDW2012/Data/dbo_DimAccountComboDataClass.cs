using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class dbo_DimAccount_dbo_DimAccountDataClass4
{
    public static List<dbo_DimAccount_dbo_DimAccountClass4> List()
    {
        List<dbo_DimAccount_dbo_DimAccountClass4> dbo_DimAccount_dbo_DimAccountList = new List<dbo_DimAccount_dbo_DimAccountClass4>();
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement 
            = "SELECT "  
            + "     [AccountKey] " 
            + "    ,[ParentAccountKey] " 
            + "FROM " 
            + "     [dbo].[DimAccount] " 
            + "";
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        try
        {
            connection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            dbo_DimAccount_dbo_DimAccountClass4 clsdbo_DimAccount_dbo_DimAccount = new dbo_DimAccount_dbo_DimAccountClass4();
            while (reader.Read())
            {
                clsdbo_DimAccount_dbo_DimAccount = new dbo_DimAccount_dbo_DimAccountClass4();
                clsdbo_DimAccount_dbo_DimAccount.AccountKey = System.Convert.ToInt32(reader["AccountKey"]);
                clsdbo_DimAccount_dbo_DimAccount.ParentAccountKey = Convert.ToString(reader["ParentAccountKey"]);
                dbo_DimAccount_dbo_DimAccountList.Add(clsdbo_DimAccount_dbo_DimAccount);
            }
            reader.Close();
        }
        catch (SqlException)
        {
            return dbo_DimAccount_dbo_DimAccountList;
        }
        finally
        {
            connection.Close();
        }
        return dbo_DimAccount_dbo_DimAccountList;
    }

}


 
