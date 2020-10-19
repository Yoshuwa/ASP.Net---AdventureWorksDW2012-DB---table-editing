using System;
using System.Data;
using System.Data.SqlClient;

public class dbo_NewFactCurrencyRateDataClass
{

    public static DataTable SelectAll()
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement
            = "SELECT "  
            + "     [dbo].[NewFactCurrencyRate].[AverageRate] "
            + "    ,[dbo].[NewFactCurrencyRate].[CurrencyID] "
            + "    ,[dbo].[NewFactCurrencyRate].[CurrencyDate] "
            + "    ,[dbo].[NewFactCurrencyRate].[EndOfDayRate] "
            + "    ,[dbo].[NewFactCurrencyRate].[CurrencyKey] "
            + "    ,[dbo].[NewFactCurrencyRate].[DateKey] "
            + "FROM " 
            + "     [dbo].[NewFactCurrencyRate] " 
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
            + "     [dbo].[NewFactCurrencyRate].[AverageRate] "
            + "    ,[dbo].[NewFactCurrencyRate].[CurrencyID] "
            + "    ,[dbo].[NewFactCurrencyRate].[CurrencyDate] "
            + "    ,[dbo].[NewFactCurrencyRate].[EndOfDayRate] "
            + "    ,[dbo].[NewFactCurrencyRate].[CurrencyKey] "
            + "    ,[dbo].[NewFactCurrencyRate].[DateKey] "
            + "FROM " 
            + "     [dbo].[NewFactCurrencyRate] " 
                + "WHERE " 
                + "     (@AverageRate IS NULL OR @AverageRate = '' OR [NewFactCurrencyRate].[AverageRate] LIKE '%' + LTRIM(RTRIM(@AverageRate)) + '%') " 
                + "AND   (@CurrencyID IS NULL OR @CurrencyID = '' OR [NewFactCurrencyRate].[CurrencyID] LIKE '%' + LTRIM(RTRIM(@CurrencyID)) + '%') " 
                + "AND   (@CurrencyDate IS NULL OR @CurrencyDate = '' OR [NewFactCurrencyRate].[CurrencyDate] LIKE '%' + LTRIM(RTRIM(@CurrencyDate)) + '%') " 
                + "AND   (@EndOfDayRate IS NULL OR @EndOfDayRate = '' OR [NewFactCurrencyRate].[EndOfDayRate] LIKE '%' + LTRIM(RTRIM(@EndOfDayRate)) + '%') " 
                + "AND   (@CurrencyKey IS NULL OR @CurrencyKey = '' OR [NewFactCurrencyRate].[CurrencyKey] LIKE '%' + LTRIM(RTRIM(@CurrencyKey)) + '%') " 
                + "AND   (@DateKey IS NULL OR @DateKey = '' OR [NewFactCurrencyRate].[DateKey] LIKE '%' + LTRIM(RTRIM(@DateKey)) + '%') " 
                + "";
        } else if (sCondition == "Equals") {
            selectStatement
                = "SELECT "
            + "     [dbo].[NewFactCurrencyRate].[AverageRate] "
            + "    ,[dbo].[NewFactCurrencyRate].[CurrencyID] "
            + "    ,[dbo].[NewFactCurrencyRate].[CurrencyDate] "
            + "    ,[dbo].[NewFactCurrencyRate].[EndOfDayRate] "
            + "    ,[dbo].[NewFactCurrencyRate].[CurrencyKey] "
            + "    ,[dbo].[NewFactCurrencyRate].[DateKey] "
            + "FROM " 
            + "     [dbo].[NewFactCurrencyRate] " 
                + "WHERE " 
                + "     (@AverageRate IS NULL OR @AverageRate = '' OR [NewFactCurrencyRate].[AverageRate] = LTRIM(RTRIM(@AverageRate))) " 
                + "AND   (@CurrencyID IS NULL OR @CurrencyID = '' OR [NewFactCurrencyRate].[CurrencyID] = LTRIM(RTRIM(@CurrencyID))) " 
                + "AND   (@CurrencyDate IS NULL OR @CurrencyDate = '' OR [NewFactCurrencyRate].[CurrencyDate] = LTRIM(RTRIM(@CurrencyDate))) " 
                + "AND   (@EndOfDayRate IS NULL OR @EndOfDayRate = '' OR [NewFactCurrencyRate].[EndOfDayRate] = LTRIM(RTRIM(@EndOfDayRate))) " 
                + "AND   (@CurrencyKey IS NULL OR @CurrencyKey = '' OR [NewFactCurrencyRate].[CurrencyKey] = LTRIM(RTRIM(@CurrencyKey))) " 
                + "AND   (@DateKey IS NULL OR @DateKey = '' OR [NewFactCurrencyRate].[DateKey] = LTRIM(RTRIM(@DateKey))) " 
                + "";
        } else if  (sCondition == "Starts with...") {
            selectStatement
                = "SELECT "
            + "     [dbo].[NewFactCurrencyRate].[AverageRate] "
            + "    ,[dbo].[NewFactCurrencyRate].[CurrencyID] "
            + "    ,[dbo].[NewFactCurrencyRate].[CurrencyDate] "
            + "    ,[dbo].[NewFactCurrencyRate].[EndOfDayRate] "
            + "    ,[dbo].[NewFactCurrencyRate].[CurrencyKey] "
            + "    ,[dbo].[NewFactCurrencyRate].[DateKey] "
            + "FROM " 
            + "     [dbo].[NewFactCurrencyRate] " 
                + "WHERE " 
                + "     (@AverageRate IS NULL OR @AverageRate = '' OR [NewFactCurrencyRate].[AverageRate] LIKE LTRIM(RTRIM(@AverageRate)) + '%') " 
                + "AND   (@CurrencyID IS NULL OR @CurrencyID = '' OR [NewFactCurrencyRate].[CurrencyID] LIKE LTRIM(RTRIM(@CurrencyID)) + '%') " 
                + "AND   (@CurrencyDate IS NULL OR @CurrencyDate = '' OR [NewFactCurrencyRate].[CurrencyDate] LIKE LTRIM(RTRIM(@CurrencyDate)) + '%') " 
                + "AND   (@EndOfDayRate IS NULL OR @EndOfDayRate = '' OR [NewFactCurrencyRate].[EndOfDayRate] LIKE LTRIM(RTRIM(@EndOfDayRate)) + '%') " 
                + "AND   (@CurrencyKey IS NULL OR @CurrencyKey = '' OR [NewFactCurrencyRate].[CurrencyKey] LIKE LTRIM(RTRIM(@CurrencyKey)) + '%') " 
                + "AND   (@DateKey IS NULL OR @DateKey = '' OR [NewFactCurrencyRate].[DateKey] LIKE LTRIM(RTRIM(@DateKey)) + '%') " 
                + "";
        } else if  (sCondition == "More than...") {
            selectStatement
                = "SELECT "
            + "     [dbo].[NewFactCurrencyRate].[AverageRate] "
            + "    ,[dbo].[NewFactCurrencyRate].[CurrencyID] "
            + "    ,[dbo].[NewFactCurrencyRate].[CurrencyDate] "
            + "    ,[dbo].[NewFactCurrencyRate].[EndOfDayRate] "
            + "    ,[dbo].[NewFactCurrencyRate].[CurrencyKey] "
            + "    ,[dbo].[NewFactCurrencyRate].[DateKey] "
            + "FROM " 
            + "     [dbo].[NewFactCurrencyRate] " 
                + "WHERE " 
                + "     (@AverageRate IS NULL OR @AverageRate = '' OR [NewFactCurrencyRate].[AverageRate] > LTRIM(RTRIM(@AverageRate))) " 
                + "AND   (@CurrencyID IS NULL OR @CurrencyID = '' OR [NewFactCurrencyRate].[CurrencyID] > LTRIM(RTRIM(@CurrencyID))) " 
                + "AND   (@CurrencyDate IS NULL OR @CurrencyDate = '' OR [NewFactCurrencyRate].[CurrencyDate] > LTRIM(RTRIM(@CurrencyDate))) " 
                + "AND   (@EndOfDayRate IS NULL OR @EndOfDayRate = '' OR [NewFactCurrencyRate].[EndOfDayRate] > LTRIM(RTRIM(@EndOfDayRate))) " 
                + "AND   (@CurrencyKey IS NULL OR @CurrencyKey = '' OR [NewFactCurrencyRate].[CurrencyKey] > LTRIM(RTRIM(@CurrencyKey))) " 
                + "AND   (@DateKey IS NULL OR @DateKey = '' OR [NewFactCurrencyRate].[DateKey] > LTRIM(RTRIM(@DateKey))) " 
                + "";
        } else if  (sCondition == "Less than...") {
            selectStatement
                = "SELECT " 
            + "     [dbo].[NewFactCurrencyRate].[AverageRate] "
            + "    ,[dbo].[NewFactCurrencyRate].[CurrencyID] "
            + "    ,[dbo].[NewFactCurrencyRate].[CurrencyDate] "
            + "    ,[dbo].[NewFactCurrencyRate].[EndOfDayRate] "
            + "    ,[dbo].[NewFactCurrencyRate].[CurrencyKey] "
            + "    ,[dbo].[NewFactCurrencyRate].[DateKey] "
            + "FROM " 
            + "     [dbo].[NewFactCurrencyRate] " 
                + "WHERE " 
                + "     (@AverageRate IS NULL OR @AverageRate = '' OR [NewFactCurrencyRate].[AverageRate] < LTRIM(RTRIM(@AverageRate))) " 
                + "AND   (@CurrencyID IS NULL OR @CurrencyID = '' OR [NewFactCurrencyRate].[CurrencyID] < LTRIM(RTRIM(@CurrencyID))) " 
                + "AND   (@CurrencyDate IS NULL OR @CurrencyDate = '' OR [NewFactCurrencyRate].[CurrencyDate] < LTRIM(RTRIM(@CurrencyDate))) " 
                + "AND   (@EndOfDayRate IS NULL OR @EndOfDayRate = '' OR [NewFactCurrencyRate].[EndOfDayRate] < LTRIM(RTRIM(@EndOfDayRate))) " 
                + "AND   (@CurrencyKey IS NULL OR @CurrencyKey = '' OR [NewFactCurrencyRate].[CurrencyKey] < LTRIM(RTRIM(@CurrencyKey))) " 
                + "AND   (@DateKey IS NULL OR @DateKey = '' OR [NewFactCurrencyRate].[DateKey] < LTRIM(RTRIM(@DateKey))) " 
                + "";
        } else if  (sCondition == "Equal or more than...") {
            selectStatement
                = "SELECT "
            + "     [dbo].[NewFactCurrencyRate].[AverageRate] "
            + "    ,[dbo].[NewFactCurrencyRate].[CurrencyID] "
            + "    ,[dbo].[NewFactCurrencyRate].[CurrencyDate] "
            + "    ,[dbo].[NewFactCurrencyRate].[EndOfDayRate] "
            + "    ,[dbo].[NewFactCurrencyRate].[CurrencyKey] "
            + "    ,[dbo].[NewFactCurrencyRate].[DateKey] "
            + "FROM " 
            + "     [dbo].[NewFactCurrencyRate] " 
                + "WHERE " 
                + "     (@AverageRate IS NULL OR @AverageRate = '' OR [NewFactCurrencyRate].[AverageRate] >= LTRIM(RTRIM(@AverageRate))) " 
                + "AND   (@CurrencyID IS NULL OR @CurrencyID = '' OR [NewFactCurrencyRate].[CurrencyID] >= LTRIM(RTRIM(@CurrencyID))) " 
                + "AND   (@CurrencyDate IS NULL OR @CurrencyDate = '' OR [NewFactCurrencyRate].[CurrencyDate] >= LTRIM(RTRIM(@CurrencyDate))) " 
                + "AND   (@EndOfDayRate IS NULL OR @EndOfDayRate = '' OR [NewFactCurrencyRate].[EndOfDayRate] >= LTRIM(RTRIM(@EndOfDayRate))) " 
                + "AND   (@CurrencyKey IS NULL OR @CurrencyKey = '' OR [NewFactCurrencyRate].[CurrencyKey] >= LTRIM(RTRIM(@CurrencyKey))) " 
                + "AND   (@DateKey IS NULL OR @DateKey = '' OR [NewFactCurrencyRate].[DateKey] >= LTRIM(RTRIM(@DateKey))) " 
                + "";
        } else if (sCondition == "Equal or less than...") {
            selectStatement 
                = "SELECT "
            + "     [dbo].[NewFactCurrencyRate].[AverageRate] "
            + "    ,[dbo].[NewFactCurrencyRate].[CurrencyID] "
            + "    ,[dbo].[NewFactCurrencyRate].[CurrencyDate] "
            + "    ,[dbo].[NewFactCurrencyRate].[EndOfDayRate] "
            + "    ,[dbo].[NewFactCurrencyRate].[CurrencyKey] "
            + "    ,[dbo].[NewFactCurrencyRate].[DateKey] "
            + "FROM " 
            + "     [dbo].[NewFactCurrencyRate] " 
                + "WHERE " 
                + "     (@AverageRate IS NULL OR @AverageRate = '' OR [NewFactCurrencyRate].[AverageRate] <= LTRIM(RTRIM(@AverageRate))) " 
                + "AND   (@CurrencyID IS NULL OR @CurrencyID = '' OR [NewFactCurrencyRate].[CurrencyID] <= LTRIM(RTRIM(@CurrencyID))) " 
                + "AND   (@CurrencyDate IS NULL OR @CurrencyDate = '' OR [NewFactCurrencyRate].[CurrencyDate] <= LTRIM(RTRIM(@CurrencyDate))) " 
                + "AND   (@EndOfDayRate IS NULL OR @EndOfDayRate = '' OR [NewFactCurrencyRate].[EndOfDayRate] <= LTRIM(RTRIM(@EndOfDayRate))) " 
                + "AND   (@CurrencyKey IS NULL OR @CurrencyKey = '' OR [NewFactCurrencyRate].[CurrencyKey] <= LTRIM(RTRIM(@CurrencyKey))) " 
                + "AND   (@DateKey IS NULL OR @DateKey = '' OR [NewFactCurrencyRate].[DateKey] <= LTRIM(RTRIM(@DateKey))) " 
                + "";
        }
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        selectCommand.CommandType = CommandType.Text;
        if (sField == "Average Rate") {
            selectCommand.Parameters.AddWithValue("@AverageRate", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@AverageRate", DBNull.Value); }
        if (sField == "Currency I D") {
            selectCommand.Parameters.AddWithValue("@CurrencyID", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@CurrencyID", DBNull.Value); }
        if (sField == "Currency Date") {
            selectCommand.Parameters.AddWithValue("@CurrencyDate", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@CurrencyDate", DBNull.Value); }
        if (sField == "End Of Day Rate") {
            selectCommand.Parameters.AddWithValue("@EndOfDayRate", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@EndOfDayRate", DBNull.Value); }
        if (sField == "Currency Key") {
            selectCommand.Parameters.AddWithValue("@CurrencyKey", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@CurrencyKey", DBNull.Value); }
        if (sField == "Date Key") {
            selectCommand.Parameters.AddWithValue("@DateKey", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@DateKey", DBNull.Value); }
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

    public static dbo_NewFactCurrencyRateClass Select_Record(dbo_NewFactCurrencyRateClass clsdbo_NewFactCurrencyRatePara)
    {
        dbo_NewFactCurrencyRateClass clsdbo_NewFactCurrencyRate = new dbo_NewFactCurrencyRateClass();
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement
            = "SELECT " 
            + "     [AverageRate] "
            + "    ,[CurrencyID] "
            + "    ,[CurrencyDate] "
            + "    ,[EndOfDayRate] "
            + "    ,[CurrencyKey] "
            + "    ,[DateKey] "
            + "FROM "
            + "     [dbo].[NewFactCurrencyRate] "
            + "WHERE "
            + "    [AverageRate] = @AverageRate "
            + "";
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        selectCommand.CommandType = CommandType.Text;
        selectCommand.Parameters.AddWithValue("@AverageRate", clsdbo_NewFactCurrencyRatePara.AverageRate);
        try
        {
            connection.Open();
            SqlDataReader reader
                = selectCommand.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                clsdbo_NewFactCurrencyRate.AverageRate = reader["AverageRate"] is DBNull ? null : (Decimal?)(Single?)reader["AverageRate"];
                clsdbo_NewFactCurrencyRate.CurrencyID = reader["CurrencyID"] is DBNull ? null : reader["CurrencyID"].ToString();
                clsdbo_NewFactCurrencyRate.CurrencyDate = reader["CurrencyDate"] is DBNull ? null : (DateTime?)reader["CurrencyDate"];
                clsdbo_NewFactCurrencyRate.EndOfDayRate = reader["EndOfDayRate"] is DBNull ? null : (Decimal?)(Single?)reader["EndOfDayRate"];
                clsdbo_NewFactCurrencyRate.CurrencyKey = reader["CurrencyKey"] is DBNull ? null : (Int32?)reader["CurrencyKey"];
                clsdbo_NewFactCurrencyRate.DateKey = reader["DateKey"] is DBNull ? null : (Int32?)reader["DateKey"];
            }
            else
            {
                clsdbo_NewFactCurrencyRate = null;
            }
            reader.Close();
        }
        catch (SqlException)
        {
            return clsdbo_NewFactCurrencyRate;
        }
        finally
        {
            connection.Close();
        }
        return clsdbo_NewFactCurrencyRate;
    }

    public static bool Add(dbo_NewFactCurrencyRateClass clsdbo_NewFactCurrencyRate)
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string insertStatement
            = "INSERT " 
            + "     [dbo].[NewFactCurrencyRate] "
            + "     ( "
            + "     [AverageRate] "
            + "    ,[CurrencyID] "
            + "    ,[CurrencyDate] "
            + "    ,[EndOfDayRate] "
            + "    ,[CurrencyKey] "
            + "    ,[DateKey] "
            + "     ) "
            + "VALUES " 
            + "     ( "
            + "     @AverageRate "
            + "    ,@CurrencyID "
            + "    ,@CurrencyDate "
            + "    ,@EndOfDayRate "
            + "    ,@CurrencyKey "
            + "    ,@DateKey "
            + "     ) "
            + "";
        SqlCommand insertCommand = new SqlCommand(insertStatement, connection);
        insertCommand.CommandType = CommandType.Text;
        if (clsdbo_NewFactCurrencyRate.AverageRate.HasValue == true) {
            insertCommand.Parameters.AddWithValue("@AverageRate", clsdbo_NewFactCurrencyRate.AverageRate);
        } else {
            insertCommand.Parameters.AddWithValue("@AverageRate", DBNull.Value); }
        if (clsdbo_NewFactCurrencyRate.CurrencyID != null) {
            insertCommand.Parameters.AddWithValue("@CurrencyID", clsdbo_NewFactCurrencyRate.CurrencyID);
        } else {
            insertCommand.Parameters.AddWithValue("@CurrencyID", DBNull.Value); }
        if (clsdbo_NewFactCurrencyRate.CurrencyDate.HasValue == true) {
            insertCommand.Parameters.AddWithValue("@CurrencyDate", clsdbo_NewFactCurrencyRate.CurrencyDate);
        } else {
            insertCommand.Parameters.AddWithValue("@CurrencyDate", DBNull.Value); }
        if (clsdbo_NewFactCurrencyRate.EndOfDayRate.HasValue == true) {
            insertCommand.Parameters.AddWithValue("@EndOfDayRate", clsdbo_NewFactCurrencyRate.EndOfDayRate);
        } else {
            insertCommand.Parameters.AddWithValue("@EndOfDayRate", DBNull.Value); }
        if (clsdbo_NewFactCurrencyRate.CurrencyKey.HasValue == true) {
            insertCommand.Parameters.AddWithValue("@CurrencyKey", clsdbo_NewFactCurrencyRate.CurrencyKey);
        } else {
            insertCommand.Parameters.AddWithValue("@CurrencyKey", DBNull.Value); }
        if (clsdbo_NewFactCurrencyRate.DateKey.HasValue == true) {
            insertCommand.Parameters.AddWithValue("@DateKey", clsdbo_NewFactCurrencyRate.DateKey);
        } else {
            insertCommand.Parameters.AddWithValue("@DateKey", DBNull.Value); }
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

    public static bool Update(dbo_NewFactCurrencyRateClass olddbo_NewFactCurrencyRateClass, 
           dbo_NewFactCurrencyRateClass newdbo_NewFactCurrencyRateClass)
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string updateStatement
            = "UPDATE "  
            + "     [dbo].[NewFactCurrencyRate] "
            + "SET "
            + "     [AverageRate] = @NewAverageRate "
            + "    ,[CurrencyID] = @NewCurrencyID "
            + "    ,[CurrencyDate] = @NewCurrencyDate "
            + "    ,[EndOfDayRate] = @NewEndOfDayRate "
            + "    ,[CurrencyKey] = @NewCurrencyKey "
            + "    ,[DateKey] = @NewDateKey "
            + "WHERE "
            + "     ((@OldAverageRate IS NULL AND [AverageRate] IS NULL) OR [AverageRate] = @OldAverageRate) " 
            + " AND ((@OldCurrencyID IS NULL AND [CurrencyID] IS NULL) OR [CurrencyID] = @OldCurrencyID) " 
            + " AND ((@OldCurrencyDate IS NULL AND [CurrencyDate] IS NULL) OR [CurrencyDate] = @OldCurrencyDate) " 
            + " AND ((@OldEndOfDayRate IS NULL AND [EndOfDayRate] IS NULL) OR [EndOfDayRate] = @OldEndOfDayRate) " 
            + " AND ((@OldCurrencyKey IS NULL AND [CurrencyKey] IS NULL) OR [CurrencyKey] = @OldCurrencyKey) " 
            + " AND ((@OldDateKey IS NULL AND [DateKey] IS NULL) OR [DateKey] = @OldDateKey) " 
            + "";
        SqlCommand updateCommand = new SqlCommand(updateStatement, connection);
        updateCommand.CommandType = CommandType.Text;
        if (newdbo_NewFactCurrencyRateClass.AverageRate.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@NewAverageRate", newdbo_NewFactCurrencyRateClass.AverageRate);
        } else {
            updateCommand.Parameters.AddWithValue("@NewAverageRate", DBNull.Value); }
        if (newdbo_NewFactCurrencyRateClass.CurrencyID != null) {
            updateCommand.Parameters.AddWithValue("@NewCurrencyID", newdbo_NewFactCurrencyRateClass.CurrencyID);
        } else {
            updateCommand.Parameters.AddWithValue("@NewCurrencyID", DBNull.Value); }
        if (newdbo_NewFactCurrencyRateClass.CurrencyDate.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@NewCurrencyDate", newdbo_NewFactCurrencyRateClass.CurrencyDate);
        } else {
            updateCommand.Parameters.AddWithValue("@NewCurrencyDate", DBNull.Value); }
        if (newdbo_NewFactCurrencyRateClass.EndOfDayRate.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@NewEndOfDayRate", newdbo_NewFactCurrencyRateClass.EndOfDayRate);
        } else {
            updateCommand.Parameters.AddWithValue("@NewEndOfDayRate", DBNull.Value); }
        if (newdbo_NewFactCurrencyRateClass.CurrencyKey.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@NewCurrencyKey", newdbo_NewFactCurrencyRateClass.CurrencyKey);
        } else {
            updateCommand.Parameters.AddWithValue("@NewCurrencyKey", DBNull.Value); }
        if (newdbo_NewFactCurrencyRateClass.DateKey.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@NewDateKey", newdbo_NewFactCurrencyRateClass.DateKey);
        } else {
            updateCommand.Parameters.AddWithValue("@NewDateKey", DBNull.Value); }
        if (olddbo_NewFactCurrencyRateClass.AverageRate.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@OldAverageRate", olddbo_NewFactCurrencyRateClass.AverageRate);
        } else {
            updateCommand.Parameters.AddWithValue("@OldAverageRate", DBNull.Value); }
        if (olddbo_NewFactCurrencyRateClass.CurrencyID != null) {
            updateCommand.Parameters.AddWithValue("@OldCurrencyID", olddbo_NewFactCurrencyRateClass.CurrencyID);
        } else {
            updateCommand.Parameters.AddWithValue("@OldCurrencyID", DBNull.Value); }
        if (olddbo_NewFactCurrencyRateClass.CurrencyDate.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@OldCurrencyDate", olddbo_NewFactCurrencyRateClass.CurrencyDate);
        } else {
            updateCommand.Parameters.AddWithValue("@OldCurrencyDate", DBNull.Value); }
        if (olddbo_NewFactCurrencyRateClass.EndOfDayRate.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@OldEndOfDayRate", olddbo_NewFactCurrencyRateClass.EndOfDayRate);
        } else {
            updateCommand.Parameters.AddWithValue("@OldEndOfDayRate", DBNull.Value); }
        if (olddbo_NewFactCurrencyRateClass.CurrencyKey.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@OldCurrencyKey", olddbo_NewFactCurrencyRateClass.CurrencyKey);
        } else {
            updateCommand.Parameters.AddWithValue("@OldCurrencyKey", DBNull.Value); }
        if (olddbo_NewFactCurrencyRateClass.DateKey.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@OldDateKey", olddbo_NewFactCurrencyRateClass.DateKey);
        } else {
            updateCommand.Parameters.AddWithValue("@OldDateKey", DBNull.Value); }
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

    public static bool Delete(dbo_NewFactCurrencyRateClass clsdbo_NewFactCurrencyRate)
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string deleteStatement
            = "DELETE FROM "  
            + "     [dbo].[NewFactCurrencyRate] "
            + "WHERE " 
            + "     ((@OldAverageRate IS NULL AND [AverageRate] IS NULL) OR [AverageRate] = @OldAverageRate) " 
            + " AND ((@OldCurrencyID IS NULL AND [CurrencyID] IS NULL) OR [CurrencyID] = @OldCurrencyID) " 
            + " AND ((@OldCurrencyDate IS NULL AND [CurrencyDate] IS NULL) OR [CurrencyDate] = @OldCurrencyDate) " 
            + " AND ((@OldEndOfDayRate IS NULL AND [EndOfDayRate] IS NULL) OR [EndOfDayRate] = @OldEndOfDayRate) " 
            + " AND ((@OldCurrencyKey IS NULL AND [CurrencyKey] IS NULL) OR [CurrencyKey] = @OldCurrencyKey) " 
            + " AND ((@OldDateKey IS NULL AND [DateKey] IS NULL) OR [DateKey] = @OldDateKey) " 
            + "";
        SqlCommand deleteCommand = new SqlCommand(deleteStatement, connection);
        deleteCommand.CommandType = CommandType.Text;
        if (clsdbo_NewFactCurrencyRate.AverageRate.HasValue == true) {
            deleteCommand.Parameters.AddWithValue("@OldAverageRate", clsdbo_NewFactCurrencyRate.AverageRate);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldAverageRate", DBNull.Value); }
        if (clsdbo_NewFactCurrencyRate.CurrencyID != null) {
            deleteCommand.Parameters.AddWithValue("@OldCurrencyID", clsdbo_NewFactCurrencyRate.CurrencyID);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldCurrencyID", DBNull.Value); }
        if (clsdbo_NewFactCurrencyRate.CurrencyDate.HasValue == true) {
            deleteCommand.Parameters.AddWithValue("@OldCurrencyDate", clsdbo_NewFactCurrencyRate.CurrencyDate);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldCurrencyDate", DBNull.Value); }
        if (clsdbo_NewFactCurrencyRate.EndOfDayRate.HasValue == true) {
            deleteCommand.Parameters.AddWithValue("@OldEndOfDayRate", clsdbo_NewFactCurrencyRate.EndOfDayRate);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldEndOfDayRate", DBNull.Value); }
        if (clsdbo_NewFactCurrencyRate.CurrencyKey.HasValue == true) {
            deleteCommand.Parameters.AddWithValue("@OldCurrencyKey", clsdbo_NewFactCurrencyRate.CurrencyKey);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldCurrencyKey", DBNull.Value); }
        if (clsdbo_NewFactCurrencyRate.DateKey.HasValue == true) {
            deleteCommand.Parameters.AddWithValue("@OldDateKey", clsdbo_NewFactCurrencyRate.DateKey);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldDateKey", DBNull.Value); }
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

 
