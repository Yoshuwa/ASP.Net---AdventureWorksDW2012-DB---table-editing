using System;
using System.Data;
using System.Data.SqlClient;

public class dbo_FactCurrencyRateDataClass
{

    public static DataTable SelectAll()
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement
            = "SELECT "  
            + "     [A223].[CurrencyName] "
            + "    ,[A224].[FullDateAlternateKey] "
            + "    ,[dbo].[FactCurrencyRate].[AverageRate] "
            + "    ,[dbo].[FactCurrencyRate].[EndOfDayRate] "
            + "    ,[dbo].[FactCurrencyRate].[Date] "
            + "FROM " 
            + "     [dbo].[FactCurrencyRate] " 
            + "INNER JOIN [dbo].[DimCurrency] as [A223] ON [dbo].[FactCurrencyRate].[CurrencyKey] = [A223].[CurrencyKey] "
            + "INNER JOIN [dbo].[DimDate] as [A224] ON [dbo].[FactCurrencyRate].[DateKey] = [A224].[DateKey] "
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
            + "     [A223].[CurrencyName]"
            + "    ,[A224].[FullDateAlternateKey]"
            + "    ,[dbo].[FactCurrencyRate].[AverageRate] "
            + "    ,[dbo].[FactCurrencyRate].[EndOfDayRate] "
            + "    ,[dbo].[FactCurrencyRate].[Date] "
            + "FROM " 
            + "     [dbo].[FactCurrencyRate] " 
            + "INNER JOIN [dbo].[DimCurrency] as [A223] ON [dbo].[FactCurrencyRate].[CurrencyKey] = [A223].[CurrencyKey] "
            + "INNER JOIN [dbo].[DimDate] as [A224] ON [dbo].[FactCurrencyRate].[DateKey] = [A224].[DateKey] "
                + "WHERE " 
                + "     (@CurrencyName223 IS NULL OR @CurrencyName223 = '' OR [A223].[CurrencyName] LIKE '%' + LTRIM(RTRIM(@CurrencyName223)) + '%') " 
                + "AND   (@FullDateAlternateKey224 IS NULL OR @FullDateAlternateKey224 = '' OR [A224].[FullDateAlternateKey] LIKE '%' + LTRIM(RTRIM(@FullDateAlternateKey224)) + '%') " 
                + "AND   (@AverageRate IS NULL OR @AverageRate = '' OR [FactCurrencyRate].[AverageRate] LIKE '%' + LTRIM(RTRIM(@AverageRate)) + '%') " 
                + "AND   (@EndOfDayRate IS NULL OR @EndOfDayRate = '' OR [FactCurrencyRate].[EndOfDayRate] LIKE '%' + LTRIM(RTRIM(@EndOfDayRate)) + '%') " 
                + "AND   (@Date IS NULL OR @Date = '' OR [FactCurrencyRate].[Date] LIKE '%' + LTRIM(RTRIM(@Date)) + '%') " 
                + "";
        } else if (sCondition == "Equals") {
            selectStatement
                = "SELECT "
            + "     [A223].[CurrencyName]"
            + "    ,[A224].[FullDateAlternateKey]"
            + "    ,[dbo].[FactCurrencyRate].[AverageRate] "
            + "    ,[dbo].[FactCurrencyRate].[EndOfDayRate] "
            + "    ,[dbo].[FactCurrencyRate].[Date] "
            + "FROM " 
            + "     [dbo].[FactCurrencyRate] " 
            + "INNER JOIN [dbo].[DimCurrency] as [A223] ON [dbo].[FactCurrencyRate].[CurrencyKey] = [A223].[CurrencyKey] "
            + "INNER JOIN [dbo].[DimDate] as [A224] ON [dbo].[FactCurrencyRate].[DateKey] = [A224].[DateKey] "
                + "WHERE " 
                + "     (@CurrencyName223 IS NULL OR @CurrencyName223 = '' OR [A223].[CurrencyName] = LTRIM(RTRIM(@CurrencyName223))) " 
                + "AND   (@FullDateAlternateKey224 IS NULL OR @FullDateAlternateKey224 = '' OR [A224].[FullDateAlternateKey] = LTRIM(RTRIM(@FullDateAlternateKey224))) " 
                + "AND   (@AverageRate IS NULL OR @AverageRate = '' OR [FactCurrencyRate].[AverageRate] = LTRIM(RTRIM(@AverageRate))) " 
                + "AND   (@EndOfDayRate IS NULL OR @EndOfDayRate = '' OR [FactCurrencyRate].[EndOfDayRate] = LTRIM(RTRIM(@EndOfDayRate))) " 
                + "AND   (@Date IS NULL OR @Date = '' OR [FactCurrencyRate].[Date] = LTRIM(RTRIM(@Date))) " 
                + "";
        } else if  (sCondition == "Starts with...") {
            selectStatement
                = "SELECT "
            + "     [A223].[CurrencyName]"
            + "    ,[A224].[FullDateAlternateKey]"
            + "    ,[dbo].[FactCurrencyRate].[AverageRate] "
            + "    ,[dbo].[FactCurrencyRate].[EndOfDayRate] "
            + "    ,[dbo].[FactCurrencyRate].[Date] "
            + "FROM " 
            + "     [dbo].[FactCurrencyRate] " 
            + "INNER JOIN [dbo].[DimCurrency] as [A223] ON [dbo].[FactCurrencyRate].[CurrencyKey] = [A223].[CurrencyKey] "
            + "INNER JOIN [dbo].[DimDate] as [A224] ON [dbo].[FactCurrencyRate].[DateKey] = [A224].[DateKey] "
                + "WHERE " 
                + "     (@CurrencyName223 IS NULL OR @CurrencyName223 = '' OR [A223].[CurrencyName] LIKE LTRIM(RTRIM(@CurrencyName223)) + '%') " 
                + "AND   (@FullDateAlternateKey224 IS NULL OR @FullDateAlternateKey224 = '' OR [A224].[FullDateAlternateKey] LIKE LTRIM(RTRIM(@FullDateAlternateKey224)) + '%') " 
                + "AND   (@AverageRate IS NULL OR @AverageRate = '' OR [FactCurrencyRate].[AverageRate] LIKE LTRIM(RTRIM(@AverageRate)) + '%') " 
                + "AND   (@EndOfDayRate IS NULL OR @EndOfDayRate = '' OR [FactCurrencyRate].[EndOfDayRate] LIKE LTRIM(RTRIM(@EndOfDayRate)) + '%') " 
                + "AND   (@Date IS NULL OR @Date = '' OR [FactCurrencyRate].[Date] LIKE LTRIM(RTRIM(@Date)) + '%') " 
                + "";
        } else if  (sCondition == "More than...") {
            selectStatement
                = "SELECT "
            + "     [A223].[CurrencyName]"
            + "    ,[A224].[FullDateAlternateKey]"
            + "    ,[dbo].[FactCurrencyRate].[AverageRate] "
            + "    ,[dbo].[FactCurrencyRate].[EndOfDayRate] "
            + "    ,[dbo].[FactCurrencyRate].[Date] "
            + "FROM " 
            + "     [dbo].[FactCurrencyRate] " 
            + "INNER JOIN [dbo].[DimCurrency] as [A223] ON [dbo].[FactCurrencyRate].[CurrencyKey] = [A223].[CurrencyKey] "
            + "INNER JOIN [dbo].[DimDate] as [A224] ON [dbo].[FactCurrencyRate].[DateKey] = [A224].[DateKey] "
                + "WHERE " 
                + "     (@CurrencyName223 IS NULL OR @CurrencyName223 = '' OR [A223].[CurrencyName] > LTRIM(RTRIM(@CurrencyName223))) " 
                + "AND   (@FullDateAlternateKey224 IS NULL OR @FullDateAlternateKey224 = '' OR [A224].[FullDateAlternateKey] > LTRIM(RTRIM(@FullDateAlternateKey224))) " 
                + "AND   (@AverageRate IS NULL OR @AverageRate = '' OR [FactCurrencyRate].[AverageRate] > LTRIM(RTRIM(@AverageRate))) " 
                + "AND   (@EndOfDayRate IS NULL OR @EndOfDayRate = '' OR [FactCurrencyRate].[EndOfDayRate] > LTRIM(RTRIM(@EndOfDayRate))) " 
                + "AND   (@Date IS NULL OR @Date = '' OR [FactCurrencyRate].[Date] > LTRIM(RTRIM(@Date))) " 
                + "";
        } else if  (sCondition == "Less than...") {
            selectStatement
                = "SELECT " 
            + "     [A223].[CurrencyName]"
            + "    ,[A224].[FullDateAlternateKey]"
            + "    ,[dbo].[FactCurrencyRate].[AverageRate] "
            + "    ,[dbo].[FactCurrencyRate].[EndOfDayRate] "
            + "    ,[dbo].[FactCurrencyRate].[Date] "
            + "FROM " 
            + "     [dbo].[FactCurrencyRate] " 
            + "INNER JOIN [dbo].[DimCurrency] as [A223] ON [dbo].[FactCurrencyRate].[CurrencyKey] = [A223].[CurrencyKey] "
            + "INNER JOIN [dbo].[DimDate] as [A224] ON [dbo].[FactCurrencyRate].[DateKey] = [A224].[DateKey] "
                + "WHERE " 
                + "     (@CurrencyName223 IS NULL OR @CurrencyName223 = '' OR [A223].[CurrencyName] < LTRIM(RTRIM(@CurrencyName223))) " 
                + "AND   (@FullDateAlternateKey224 IS NULL OR @FullDateAlternateKey224 = '' OR [A224].[FullDateAlternateKey] < LTRIM(RTRIM(@FullDateAlternateKey224))) " 
                + "AND   (@AverageRate IS NULL OR @AverageRate = '' OR [FactCurrencyRate].[AverageRate] < LTRIM(RTRIM(@AverageRate))) " 
                + "AND   (@EndOfDayRate IS NULL OR @EndOfDayRate = '' OR [FactCurrencyRate].[EndOfDayRate] < LTRIM(RTRIM(@EndOfDayRate))) " 
                + "AND   (@Date IS NULL OR @Date = '' OR [FactCurrencyRate].[Date] < LTRIM(RTRIM(@Date))) " 
                + "";
        } else if  (sCondition == "Equal or more than...") {
            selectStatement
                = "SELECT "
            + "     [A223].[CurrencyName]"
            + "    ,[A224].[FullDateAlternateKey]"
            + "    ,[dbo].[FactCurrencyRate].[AverageRate] "
            + "    ,[dbo].[FactCurrencyRate].[EndOfDayRate] "
            + "    ,[dbo].[FactCurrencyRate].[Date] "
            + "FROM " 
            + "     [dbo].[FactCurrencyRate] " 
            + "INNER JOIN [dbo].[DimCurrency] as [A223] ON [dbo].[FactCurrencyRate].[CurrencyKey] = [A223].[CurrencyKey] "
            + "INNER JOIN [dbo].[DimDate] as [A224] ON [dbo].[FactCurrencyRate].[DateKey] = [A224].[DateKey] "
                + "WHERE " 
                + "     (@CurrencyName223 IS NULL OR @CurrencyName223 = '' OR [A223].[CurrencyName] >= LTRIM(RTRIM(@CurrencyName223))) " 
                + "AND   (@FullDateAlternateKey224 IS NULL OR @FullDateAlternateKey224 = '' OR [A224].[FullDateAlternateKey] >= LTRIM(RTRIM(@FullDateAlternateKey224))) " 
                + "AND   (@AverageRate IS NULL OR @AverageRate = '' OR [FactCurrencyRate].[AverageRate] >= LTRIM(RTRIM(@AverageRate))) " 
                + "AND   (@EndOfDayRate IS NULL OR @EndOfDayRate = '' OR [FactCurrencyRate].[EndOfDayRate] >= LTRIM(RTRIM(@EndOfDayRate))) " 
                + "AND   (@Date IS NULL OR @Date = '' OR [FactCurrencyRate].[Date] >= LTRIM(RTRIM(@Date))) " 
                + "";
        } else if (sCondition == "Equal or less than...") {
            selectStatement 
                = "SELECT "
            + "     [A223].[CurrencyName]"
            + "    ,[A224].[FullDateAlternateKey]"
            + "    ,[dbo].[FactCurrencyRate].[AverageRate] "
            + "    ,[dbo].[FactCurrencyRate].[EndOfDayRate] "
            + "    ,[dbo].[FactCurrencyRate].[Date] "
            + "FROM " 
            + "     [dbo].[FactCurrencyRate] " 
            + "INNER JOIN [dbo].[DimCurrency] as [A223] ON [dbo].[FactCurrencyRate].[CurrencyKey] = [A223].[CurrencyKey] "
            + "INNER JOIN [dbo].[DimDate] as [A224] ON [dbo].[FactCurrencyRate].[DateKey] = [A224].[DateKey] "
                + "WHERE " 
                + "     (@CurrencyName223 IS NULL OR @CurrencyName223 = '' OR [A223].[CurrencyName] <= LTRIM(RTRIM(@CurrencyName223))) " 
                + "AND   (@FullDateAlternateKey224 IS NULL OR @FullDateAlternateKey224 = '' OR [A224].[FullDateAlternateKey] <= LTRIM(RTRIM(@FullDateAlternateKey224))) " 
                + "AND   (@AverageRate IS NULL OR @AverageRate = '' OR [FactCurrencyRate].[AverageRate] <= LTRIM(RTRIM(@AverageRate))) " 
                + "AND   (@EndOfDayRate IS NULL OR @EndOfDayRate = '' OR [FactCurrencyRate].[EndOfDayRate] <= LTRIM(RTRIM(@EndOfDayRate))) " 
                + "AND   (@Date IS NULL OR @Date = '' OR [FactCurrencyRate].[Date] <= LTRIM(RTRIM(@Date))) " 
                + "";
        }
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        selectCommand.CommandType = CommandType.Text;
        if (sField == "Currency Key") {
            selectCommand.Parameters.AddWithValue("@CurrencyName223", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@CurrencyName223", DBNull.Value); }
        if (sField == "Date Key") {
            selectCommand.Parameters.AddWithValue("@FullDateAlternateKey224", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@FullDateAlternateKey224", DBNull.Value); }
        if (sField == "Average Rate") {
            selectCommand.Parameters.AddWithValue("@AverageRate", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@AverageRate", DBNull.Value); }
        if (sField == "End Of Day Rate") {
            selectCommand.Parameters.AddWithValue("@EndOfDayRate", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@EndOfDayRate", DBNull.Value); }
        if (sField == "Date") {
            selectCommand.Parameters.AddWithValue("@Date", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@Date", DBNull.Value); }
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

    public static dbo_FactCurrencyRateClass Select_Record(dbo_FactCurrencyRateClass clsdbo_FactCurrencyRatePara)
    {
        dbo_FactCurrencyRateClass clsdbo_FactCurrencyRate = new dbo_FactCurrencyRateClass();
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement
            = "SELECT " 
            + "     [CurrencyKey] "
            + "    ,[DateKey] "
            + "    ,[AverageRate] "
            + "    ,[EndOfDayRate] "
            + "    ,[Date] "
            + "FROM "
            + "     [dbo].[FactCurrencyRate] "
            + "WHERE "
            + "     [CurrencyKey] = @CurrencyKey "
            + " AND [DateKey] = @DateKey "
            + "";
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        selectCommand.CommandType = CommandType.Text;
        selectCommand.Parameters.AddWithValue("@CurrencyKey", clsdbo_FactCurrencyRatePara.CurrencyKey);
        selectCommand.Parameters.AddWithValue("@DateKey", clsdbo_FactCurrencyRatePara.DateKey);
        try
        {
            connection.Open();
            SqlDataReader reader
                = selectCommand.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                clsdbo_FactCurrencyRate.CurrencyKey = System.Convert.ToInt32(reader["CurrencyKey"]);
                clsdbo_FactCurrencyRate.DateKey = System.Convert.ToInt32(reader["DateKey"]);
                clsdbo_FactCurrencyRate.AverageRate = System.Convert.ToDecimal(reader["AverageRate"]);
                clsdbo_FactCurrencyRate.EndOfDayRate = System.Convert.ToDecimal(reader["EndOfDayRate"]);
                clsdbo_FactCurrencyRate.Date = reader["Date"] is DBNull ? null : (DateTime?)reader["Date"];
            }
            else
            {
                clsdbo_FactCurrencyRate = null;
            }
            reader.Close();
        }
        catch (SqlException)
        {
            return clsdbo_FactCurrencyRate;
        }
        finally
        {
            connection.Close();
        }
        return clsdbo_FactCurrencyRate;
    }

    public static bool Add(dbo_FactCurrencyRateClass clsdbo_FactCurrencyRate)
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string insertStatement
            = "INSERT " 
            + "     [dbo].[FactCurrencyRate] "
            + "     ( "
            + "     [CurrencyKey] "
            + "    ,[DateKey] "
            + "    ,[AverageRate] "
            + "    ,[EndOfDayRate] "
            + "    ,[Date] "
            + "     ) "
            + "VALUES " 
            + "     ( "
            + "     @CurrencyKey "
            + "    ,@DateKey "
            + "    ,@AverageRate "
            + "    ,@EndOfDayRate "
            + "    ,@Date "
            + "     ) "
            + "";
        SqlCommand insertCommand = new SqlCommand(insertStatement, connection);
        insertCommand.CommandType = CommandType.Text;
        insertCommand.Parameters.AddWithValue("@CurrencyKey", clsdbo_FactCurrencyRate.CurrencyKey);
        insertCommand.Parameters.AddWithValue("@DateKey", clsdbo_FactCurrencyRate.DateKey);
        insertCommand.Parameters.AddWithValue("@AverageRate", clsdbo_FactCurrencyRate.AverageRate);
        insertCommand.Parameters.AddWithValue("@EndOfDayRate", clsdbo_FactCurrencyRate.EndOfDayRate);
        if (clsdbo_FactCurrencyRate.Date.HasValue == true) {
            insertCommand.Parameters.AddWithValue("@Date", clsdbo_FactCurrencyRate.Date);
        } else {
            insertCommand.Parameters.AddWithValue("@Date", DBNull.Value); }
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

    public static bool Update(dbo_FactCurrencyRateClass olddbo_FactCurrencyRateClass, 
           dbo_FactCurrencyRateClass newdbo_FactCurrencyRateClass)
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string updateStatement
            = "UPDATE "  
            + "     [dbo].[FactCurrencyRate] "
            + "SET "
            + "     [CurrencyKey] = @NewCurrencyKey "
            + "    ,[DateKey] = @NewDateKey "
            + "    ,[AverageRate] = @NewAverageRate "
            + "    ,[EndOfDayRate] = @NewEndOfDayRate "
            + "    ,[Date] = @NewDate "
            + "WHERE "
            + "     [CurrencyKey] = @OldCurrencyKey " 
            + " AND [DateKey] = @OldDateKey " 
            + " AND [AverageRate] = @OldAverageRate " 
            + " AND [EndOfDayRate] = @OldEndOfDayRate " 
            + " AND ((@OldDate IS NULL AND [Date] IS NULL) OR [Date] = @OldDate) " 
            + "";
        SqlCommand updateCommand = new SqlCommand(updateStatement, connection);
        updateCommand.CommandType = CommandType.Text;
        updateCommand.Parameters.AddWithValue("@NewCurrencyKey", newdbo_FactCurrencyRateClass.CurrencyKey);
        updateCommand.Parameters.AddWithValue("@NewDateKey", newdbo_FactCurrencyRateClass.DateKey);
        updateCommand.Parameters.AddWithValue("@NewAverageRate", newdbo_FactCurrencyRateClass.AverageRate);
        updateCommand.Parameters.AddWithValue("@NewEndOfDayRate", newdbo_FactCurrencyRateClass.EndOfDayRate);
        if (newdbo_FactCurrencyRateClass.Date.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@NewDate", newdbo_FactCurrencyRateClass.Date);
        } else {
            updateCommand.Parameters.AddWithValue("@NewDate", DBNull.Value); }
        updateCommand.Parameters.AddWithValue("@OldCurrencyKey", olddbo_FactCurrencyRateClass.CurrencyKey);
        updateCommand.Parameters.AddWithValue("@OldDateKey", olddbo_FactCurrencyRateClass.DateKey);
        updateCommand.Parameters.AddWithValue("@OldAverageRate", olddbo_FactCurrencyRateClass.AverageRate);
        updateCommand.Parameters.AddWithValue("@OldEndOfDayRate", olddbo_FactCurrencyRateClass.EndOfDayRate);
        if (olddbo_FactCurrencyRateClass.Date.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@OldDate", olddbo_FactCurrencyRateClass.Date);
        } else {
            updateCommand.Parameters.AddWithValue("@OldDate", DBNull.Value); }
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

    public static bool Delete(dbo_FactCurrencyRateClass clsdbo_FactCurrencyRate)
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string deleteStatement
            = "DELETE FROM "  
            + "     [dbo].[FactCurrencyRate] "
            + "WHERE " 
            + "     [CurrencyKey] = @OldCurrencyKey " 
            + " AND [DateKey] = @OldDateKey " 
            + " AND [AverageRate] = @OldAverageRate " 
            + " AND [EndOfDayRate] = @OldEndOfDayRate " 
            + " AND ((@OldDate IS NULL AND [Date] IS NULL) OR [Date] = @OldDate) " 
            + "";
        SqlCommand deleteCommand = new SqlCommand(deleteStatement, connection);
        deleteCommand.CommandType = CommandType.Text;
        deleteCommand.Parameters.AddWithValue("@OldCurrencyKey", clsdbo_FactCurrencyRate.CurrencyKey);
        deleteCommand.Parameters.AddWithValue("@OldDateKey", clsdbo_FactCurrencyRate.DateKey);
        deleteCommand.Parameters.AddWithValue("@OldAverageRate", clsdbo_FactCurrencyRate.AverageRate);
        deleteCommand.Parameters.AddWithValue("@OldEndOfDayRate", clsdbo_FactCurrencyRate.EndOfDayRate);
        if (clsdbo_FactCurrencyRate.Date.HasValue == true) {
            deleteCommand.Parameters.AddWithValue("@OldDate", clsdbo_FactCurrencyRate.Date);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldDate", DBNull.Value); }
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

 
