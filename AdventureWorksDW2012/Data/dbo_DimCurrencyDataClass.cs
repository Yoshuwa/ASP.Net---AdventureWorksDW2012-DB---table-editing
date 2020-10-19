using System;
using System.Data;
using System.Data.SqlClient;

public class dbo_DimCurrencyDataClass
{

    public static DataTable SelectAll()
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement
            = "SELECT "  
            + "     [dbo].[DimCurrency].[CurrencyKey] "
            + "    ,[dbo].[DimCurrency].[CurrencyAlternateKey] "
            + "    ,[dbo].[DimCurrency].[CurrencyName] "
            + "FROM " 
            + "     [dbo].[DimCurrency] " 
            + "";
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        selectCommand.CommandType = CommandType.Text;
        DataTable dt = new DataTable();
        try
        {
            connection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            if (reader.HasRows) {
                dt.Load(reader); }
            reader.Close();
        }
        catch (SqlException)
        {
            return dt;
        }
        finally
        {
            connection.Close();
        }
        return dt;
    }

    public static DataTable Search(string sField, string sCondition, string sValue)
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement = "";
        if (sCondition == "Contains") {
            selectStatement
                = "SELECT "
            + "     [dbo].[DimCurrency].[CurrencyKey] "
            + "    ,[dbo].[DimCurrency].[CurrencyAlternateKey] "
            + "    ,[dbo].[DimCurrency].[CurrencyName] "
            + "FROM " 
            + "     [dbo].[DimCurrency] " 
                + "WHERE " 
                + "     (@CurrencyKey IS NULL OR @CurrencyKey = '' OR [DimCurrency].[CurrencyKey] LIKE '%' + LTRIM(RTRIM(@CurrencyKey)) + '%') " 
                + "AND   (@CurrencyAlternateKey IS NULL OR @CurrencyAlternateKey = '' OR [DimCurrency].[CurrencyAlternateKey] LIKE '%' + LTRIM(RTRIM(@CurrencyAlternateKey)) + '%') " 
                + "AND   (@CurrencyName IS NULL OR @CurrencyName = '' OR [DimCurrency].[CurrencyName] LIKE '%' + LTRIM(RTRIM(@CurrencyName)) + '%') " 
                + "";
        } else if (sCondition == "Equals") {
            selectStatement
                = "SELECT "
            + "     [dbo].[DimCurrency].[CurrencyKey] "
            + "    ,[dbo].[DimCurrency].[CurrencyAlternateKey] "
            + "    ,[dbo].[DimCurrency].[CurrencyName] "
            + "FROM " 
            + "     [dbo].[DimCurrency] " 
                + "WHERE " 
                + "     (@CurrencyKey IS NULL OR @CurrencyKey = '' OR [DimCurrency].[CurrencyKey] = LTRIM(RTRIM(@CurrencyKey))) " 
                + "AND   (@CurrencyAlternateKey IS NULL OR @CurrencyAlternateKey = '' OR [DimCurrency].[CurrencyAlternateKey] = LTRIM(RTRIM(@CurrencyAlternateKey))) " 
                + "AND   (@CurrencyName IS NULL OR @CurrencyName = '' OR [DimCurrency].[CurrencyName] = LTRIM(RTRIM(@CurrencyName))) " 
                + "";
        } else if  (sCondition == "Starts with...") {
            selectStatement
                = "SELECT "
            + "     [dbo].[DimCurrency].[CurrencyKey] "
            + "    ,[dbo].[DimCurrency].[CurrencyAlternateKey] "
            + "    ,[dbo].[DimCurrency].[CurrencyName] "
            + "FROM " 
            + "     [dbo].[DimCurrency] " 
                + "WHERE " 
                + "     (@CurrencyKey IS NULL OR @CurrencyKey = '' OR [DimCurrency].[CurrencyKey] LIKE LTRIM(RTRIM(@CurrencyKey)) + '%') " 
                + "AND   (@CurrencyAlternateKey IS NULL OR @CurrencyAlternateKey = '' OR [DimCurrency].[CurrencyAlternateKey] LIKE LTRIM(RTRIM(@CurrencyAlternateKey)) + '%') " 
                + "AND   (@CurrencyName IS NULL OR @CurrencyName = '' OR [DimCurrency].[CurrencyName] LIKE LTRIM(RTRIM(@CurrencyName)) + '%') " 
                + "";
        } else if  (sCondition == "More than...") {
            selectStatement
                = "SELECT "
            + "     [dbo].[DimCurrency].[CurrencyKey] "
            + "    ,[dbo].[DimCurrency].[CurrencyAlternateKey] "
            + "    ,[dbo].[DimCurrency].[CurrencyName] "
            + "FROM " 
            + "     [dbo].[DimCurrency] " 
                + "WHERE " 
                + "     (@CurrencyKey IS NULL OR @CurrencyKey = '' OR [DimCurrency].[CurrencyKey] > LTRIM(RTRIM(@CurrencyKey))) " 
                + "AND   (@CurrencyAlternateKey IS NULL OR @CurrencyAlternateKey = '' OR [DimCurrency].[CurrencyAlternateKey] > LTRIM(RTRIM(@CurrencyAlternateKey))) " 
                + "AND   (@CurrencyName IS NULL OR @CurrencyName = '' OR [DimCurrency].[CurrencyName] > LTRIM(RTRIM(@CurrencyName))) " 
                + "";
        } else if  (sCondition == "Less than...") {
            selectStatement
                = "SELECT " 
            + "     [dbo].[DimCurrency].[CurrencyKey] "
            + "    ,[dbo].[DimCurrency].[CurrencyAlternateKey] "
            + "    ,[dbo].[DimCurrency].[CurrencyName] "
            + "FROM " 
            + "     [dbo].[DimCurrency] " 
                + "WHERE " 
                + "     (@CurrencyKey IS NULL OR @CurrencyKey = '' OR [DimCurrency].[CurrencyKey] < LTRIM(RTRIM(@CurrencyKey))) " 
                + "AND   (@CurrencyAlternateKey IS NULL OR @CurrencyAlternateKey = '' OR [DimCurrency].[CurrencyAlternateKey] < LTRIM(RTRIM(@CurrencyAlternateKey))) " 
                + "AND   (@CurrencyName IS NULL OR @CurrencyName = '' OR [DimCurrency].[CurrencyName] < LTRIM(RTRIM(@CurrencyName))) " 
                + "";
        } else if  (sCondition == "Equal or more than...") {
            selectStatement
                = "SELECT "
            + "     [dbo].[DimCurrency].[CurrencyKey] "
            + "    ,[dbo].[DimCurrency].[CurrencyAlternateKey] "
            + "    ,[dbo].[DimCurrency].[CurrencyName] "
            + "FROM " 
            + "     [dbo].[DimCurrency] " 
                + "WHERE " 
                + "     (@CurrencyKey IS NULL OR @CurrencyKey = '' OR [DimCurrency].[CurrencyKey] >= LTRIM(RTRIM(@CurrencyKey))) " 
                + "AND   (@CurrencyAlternateKey IS NULL OR @CurrencyAlternateKey = '' OR [DimCurrency].[CurrencyAlternateKey] >= LTRIM(RTRIM(@CurrencyAlternateKey))) " 
                + "AND   (@CurrencyName IS NULL OR @CurrencyName = '' OR [DimCurrency].[CurrencyName] >= LTRIM(RTRIM(@CurrencyName))) " 
                + "";
        } else if (sCondition == "Equal or less than...") {
            selectStatement 
                = "SELECT "
            + "     [dbo].[DimCurrency].[CurrencyKey] "
            + "    ,[dbo].[DimCurrency].[CurrencyAlternateKey] "
            + "    ,[dbo].[DimCurrency].[CurrencyName] "
            + "FROM " 
            + "     [dbo].[DimCurrency] " 
                + "WHERE " 
                + "     (@CurrencyKey IS NULL OR @CurrencyKey = '' OR [DimCurrency].[CurrencyKey] <= LTRIM(RTRIM(@CurrencyKey))) " 
                + "AND   (@CurrencyAlternateKey IS NULL OR @CurrencyAlternateKey = '' OR [DimCurrency].[CurrencyAlternateKey] <= LTRIM(RTRIM(@CurrencyAlternateKey))) " 
                + "AND   (@CurrencyName IS NULL OR @CurrencyName = '' OR [DimCurrency].[CurrencyName] <= LTRIM(RTRIM(@CurrencyName))) " 
                + "";
        }
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        selectCommand.CommandType = CommandType.Text;
        if (sField == "Currency Key") {
            selectCommand.Parameters.AddWithValue("@CurrencyKey", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@CurrencyKey", DBNull.Value); }
        if (sField == "Currency Alternate Key") {
            selectCommand.Parameters.AddWithValue("@CurrencyAlternateKey", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@CurrencyAlternateKey", DBNull.Value); }
        if (sField == "Currency Name") {
            selectCommand.Parameters.AddWithValue("@CurrencyName", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@CurrencyName", DBNull.Value); }
        DataTable dt = new DataTable();
        try
        {
            connection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            if (reader.HasRows) {
                dt.Load(reader); }
            reader.Close();
        }
        catch (SqlException)
        {
            return dt;
        }
        finally
        {
            connection.Close();
        }
        return dt;
    }

    public static dbo_DimCurrencyClass Select_Record(dbo_DimCurrencyClass clsdbo_DimCurrencyPara)
    {
        dbo_DimCurrencyClass clsdbo_DimCurrency = new dbo_DimCurrencyClass();
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement
            = "SELECT " 
            + "     [CurrencyKey] "
            + "    ,[CurrencyAlternateKey] "
            + "    ,[CurrencyName] "
            + "FROM "
            + "     [dbo].[DimCurrency] "
            + "WHERE "
            + "     [CurrencyKey] = @CurrencyKey "
            + "";
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        selectCommand.CommandType = CommandType.Text;
        selectCommand.Parameters.AddWithValue("@CurrencyKey", clsdbo_DimCurrencyPara.CurrencyKey);
        try
        {
            connection.Open();
            SqlDataReader reader
                = selectCommand.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                clsdbo_DimCurrency.CurrencyKey = System.Convert.ToInt32(reader["CurrencyKey"]);
                clsdbo_DimCurrency.CurrencyAlternateKey = System.Convert.ToString(reader["CurrencyAlternateKey"]);
                clsdbo_DimCurrency.CurrencyName = System.Convert.ToString(reader["CurrencyName"]);
            }
            else
            {
                clsdbo_DimCurrency = null;
            }
            reader.Close();
        }
        catch (SqlException)
        {
            return clsdbo_DimCurrency;
        }
        finally
        {
            connection.Close();
        }
        return clsdbo_DimCurrency;
    }

    public static bool Add(dbo_DimCurrencyClass clsdbo_DimCurrency)
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string insertStatement
            = "INSERT " 
            + "     [dbo].[DimCurrency] "
            + "     ( "
            + "     [CurrencyAlternateKey] "
            + "    ,[CurrencyName] "
            + "     ) "
            + "VALUES " 
            + "     ( "
            + "     @CurrencyAlternateKey "
            + "    ,@CurrencyName "
            + "     ) "
            + "";
        SqlCommand insertCommand = new SqlCommand(insertStatement, connection);
        insertCommand.CommandType = CommandType.Text;
        insertCommand.Parameters.AddWithValue("@CurrencyAlternateKey", clsdbo_DimCurrency.CurrencyAlternateKey);
        insertCommand.Parameters.AddWithValue("@CurrencyName", clsdbo_DimCurrency.CurrencyName);
        try
        {
            connection.Open();
            int count = insertCommand.ExecuteNonQuery();
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (SqlException)
        {
            return false;
        }
        finally
        {
            connection.Close();
        }
    }

    public static bool Update(dbo_DimCurrencyClass olddbo_DimCurrencyClass, 
           dbo_DimCurrencyClass newdbo_DimCurrencyClass)
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string updateStatement
            = "UPDATE "  
            + "     [dbo].[DimCurrency] "
            + "SET "
            + "     [CurrencyAlternateKey] = @NewCurrencyAlternateKey "
            + "    ,[CurrencyName] = @NewCurrencyName "
            + "WHERE "
            + "     [CurrencyKey] = @OldCurrencyKey " 
            + " AND [CurrencyAlternateKey] = @OldCurrencyAlternateKey " 
            + " AND [CurrencyName] = @OldCurrencyName " 
            + "";
        SqlCommand updateCommand = new SqlCommand(updateStatement, connection);
        updateCommand.CommandType = CommandType.Text;
        updateCommand.Parameters.AddWithValue("@NewCurrencyAlternateKey", newdbo_DimCurrencyClass.CurrencyAlternateKey);
        updateCommand.Parameters.AddWithValue("@NewCurrencyName", newdbo_DimCurrencyClass.CurrencyName);
        updateCommand.Parameters.AddWithValue("@OldCurrencyKey", olddbo_DimCurrencyClass.CurrencyKey);
        updateCommand.Parameters.AddWithValue("@OldCurrencyAlternateKey", olddbo_DimCurrencyClass.CurrencyAlternateKey);
        updateCommand.Parameters.AddWithValue("@OldCurrencyName", olddbo_DimCurrencyClass.CurrencyName);
        try
        {
            connection.Open();
            int count = updateCommand.ExecuteNonQuery();
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (SqlException)
        {
            return false;
        }
        finally
        {
            connection.Close();
        }
    }

    public static bool Delete(dbo_DimCurrencyClass clsdbo_DimCurrency)
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string deleteStatement
            = "DELETE FROM "  
            + "     [dbo].[DimCurrency] "
            + "WHERE " 
            + "     [CurrencyKey] = @OldCurrencyKey " 
            + " AND [CurrencyAlternateKey] = @OldCurrencyAlternateKey " 
            + " AND [CurrencyName] = @OldCurrencyName " 
            + "";
        SqlCommand deleteCommand = new SqlCommand(deleteStatement, connection);
        deleteCommand.CommandType = CommandType.Text;
        deleteCommand.Parameters.AddWithValue("@OldCurrencyKey", clsdbo_DimCurrency.CurrencyKey);
        deleteCommand.Parameters.AddWithValue("@OldCurrencyAlternateKey", clsdbo_DimCurrency.CurrencyAlternateKey);
        deleteCommand.Parameters.AddWithValue("@OldCurrencyName", clsdbo_DimCurrency.CurrencyName);
        try
        {
            connection.Open();
            int count = deleteCommand.ExecuteNonQuery();
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (SqlException)
        {
            return false;
        }
        finally
        {
            connection.Close();
        }
    }

}

 
