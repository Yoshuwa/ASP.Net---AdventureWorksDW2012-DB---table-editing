using System;
using System.Data;
using System.Data.SqlClient;

public class dbo_FactSalesQuotaDataClass
{

    public static DataTable SelectAll()
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement
            = "SELECT "  
            + "     [dbo].[FactSalesQuota].[SalesQuotaKey] "
            + "    ,[A300].[EmployeeKey] "
            + "    ,[A301].[DateKey] "
            + "    ,[dbo].[FactSalesQuota].[CalendarYear] "
            + "    ,[dbo].[FactSalesQuota].[CalendarQuarter] "
            + "    ,[dbo].[FactSalesQuota].[SalesAmountQuota] "
            + "    ,[dbo].[FactSalesQuota].[Date] "
            + "FROM " 
            + "     [dbo].[FactSalesQuota] " 
            + "INNER JOIN [dbo].[DimEmployee] as [A300] ON [dbo].[FactSalesQuota].[EmployeeKey] = [A300].[EmployeeKey] "
            + "INNER JOIN [dbo].[DimDate] as [A301] ON [dbo].[FactSalesQuota].[DateKey] = [A301].[DateKey] "
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
            + "     [dbo].[FactSalesQuota].[SalesQuotaKey] "
            + "    ,[A300].[EmployeeKey]"
            + "    ,[A301].[DateKey]"
            + "    ,[dbo].[FactSalesQuota].[CalendarYear] "
            + "    ,[dbo].[FactSalesQuota].[CalendarQuarter] "
            + "    ,[dbo].[FactSalesQuota].[SalesAmountQuota] "
            + "    ,[dbo].[FactSalesQuota].[Date] "
            + "FROM " 
            + "     [dbo].[FactSalesQuota] " 
            + "INNER JOIN [dbo].[DimEmployee] as [A300] ON [dbo].[FactSalesQuota].[EmployeeKey] = [A300].[EmployeeKey] "
            + "INNER JOIN [dbo].[DimDate] as [A301] ON [dbo].[FactSalesQuota].[DateKey] = [A301].[DateKey] "
                + "WHERE " 
                + "     (@SalesQuotaKey IS NULL OR @SalesQuotaKey = '' OR [FactSalesQuota].[SalesQuotaKey] LIKE '%' + LTRIM(RTRIM(@SalesQuotaKey)) + '%') " 
                + "AND   (@EmployeeKey300 IS NULL OR @EmployeeKey300 = '' OR [A300].[EmployeeKey] LIKE '%' + LTRIM(RTRIM(@EmployeeKey300)) + '%') " 
                + "AND   (@DateKey301 IS NULL OR @DateKey301 = '' OR [A301].[DateKey] LIKE '%' + LTRIM(RTRIM(@DateKey301)) + '%') " 
                + "AND   (@CalendarYear IS NULL OR @CalendarYear = '' OR [FactSalesQuota].[CalendarYear] LIKE '%' + LTRIM(RTRIM(@CalendarYear)) + '%') " 
                + "AND   (@CalendarQuarter IS NULL OR @CalendarQuarter = '' OR [FactSalesQuota].[CalendarQuarter] LIKE '%' + LTRIM(RTRIM(@CalendarQuarter)) + '%') " 
                + "AND   (@SalesAmountQuota IS NULL OR @SalesAmountQuota = '' OR [FactSalesQuota].[SalesAmountQuota] LIKE '%' + LTRIM(RTRIM(@SalesAmountQuota)) + '%') " 
                + "AND   (@Date IS NULL OR @Date = '' OR [FactSalesQuota].[Date] LIKE '%' + LTRIM(RTRIM(@Date)) + '%') " 
                + "";
        } else if (sCondition == "Equals") {
            selectStatement
                = "SELECT "
            + "     [dbo].[FactSalesQuota].[SalesQuotaKey] "
            + "    ,[A300].[EmployeeKey]"
            + "    ,[A301].[DateKey]"
            + "    ,[dbo].[FactSalesQuota].[CalendarYear] "
            + "    ,[dbo].[FactSalesQuota].[CalendarQuarter] "
            + "    ,[dbo].[FactSalesQuota].[SalesAmountQuota] "
            + "    ,[dbo].[FactSalesQuota].[Date] "
            + "FROM " 
            + "     [dbo].[FactSalesQuota] " 
            + "INNER JOIN [dbo].[DimEmployee] as [A300] ON [dbo].[FactSalesQuota].[EmployeeKey] = [A300].[EmployeeKey] "
            + "INNER JOIN [dbo].[DimDate] as [A301] ON [dbo].[FactSalesQuota].[DateKey] = [A301].[DateKey] "
                + "WHERE " 
                + "     (@SalesQuotaKey IS NULL OR @SalesQuotaKey = '' OR [FactSalesQuota].[SalesQuotaKey] = LTRIM(RTRIM(@SalesQuotaKey))) " 
                + "AND   (@EmployeeKey300 IS NULL OR @EmployeeKey300 = '' OR [A300].[EmployeeKey] = LTRIM(RTRIM(@EmployeeKey300))) " 
                + "AND   (@DateKey301 IS NULL OR @DateKey301 = '' OR [A301].[DateKey] = LTRIM(RTRIM(@DateKey301))) " 
                + "AND   (@CalendarYear IS NULL OR @CalendarYear = '' OR [FactSalesQuota].[CalendarYear] = LTRIM(RTRIM(@CalendarYear))) " 
                + "AND   (@CalendarQuarter IS NULL OR @CalendarQuarter = '' OR [FactSalesQuota].[CalendarQuarter] = LTRIM(RTRIM(@CalendarQuarter))) " 
                + "AND   (@SalesAmountQuota IS NULL OR @SalesAmountQuota = '' OR [FactSalesQuota].[SalesAmountQuota] = LTRIM(RTRIM(@SalesAmountQuota))) " 
                + "AND   (@Date IS NULL OR @Date = '' OR [FactSalesQuota].[Date] = LTRIM(RTRIM(@Date))) " 
                + "";
        } else if  (sCondition == "Starts with...") {
            selectStatement
                = "SELECT "
            + "     [dbo].[FactSalesQuota].[SalesQuotaKey] "
            + "    ,[A300].[EmployeeKey]"
            + "    ,[A301].[DateKey]"
            + "    ,[dbo].[FactSalesQuota].[CalendarYear] "
            + "    ,[dbo].[FactSalesQuota].[CalendarQuarter] "
            + "    ,[dbo].[FactSalesQuota].[SalesAmountQuota] "
            + "    ,[dbo].[FactSalesQuota].[Date] "
            + "FROM " 
            + "     [dbo].[FactSalesQuota] " 
            + "INNER JOIN [dbo].[DimEmployee] as [A300] ON [dbo].[FactSalesQuota].[EmployeeKey] = [A300].[EmployeeKey] "
            + "INNER JOIN [dbo].[DimDate] as [A301] ON [dbo].[FactSalesQuota].[DateKey] = [A301].[DateKey] "
                + "WHERE " 
                + "     (@SalesQuotaKey IS NULL OR @SalesQuotaKey = '' OR [FactSalesQuota].[SalesQuotaKey] LIKE LTRIM(RTRIM(@SalesQuotaKey)) + '%') " 
                + "AND   (@EmployeeKey300 IS NULL OR @EmployeeKey300 = '' OR [A300].[EmployeeKey] LIKE LTRIM(RTRIM(@EmployeeKey300)) + '%') " 
                + "AND   (@DateKey301 IS NULL OR @DateKey301 = '' OR [A301].[DateKey] LIKE LTRIM(RTRIM(@DateKey301)) + '%') " 
                + "AND   (@CalendarYear IS NULL OR @CalendarYear = '' OR [FactSalesQuota].[CalendarYear] LIKE LTRIM(RTRIM(@CalendarYear)) + '%') " 
                + "AND   (@CalendarQuarter IS NULL OR @CalendarQuarter = '' OR [FactSalesQuota].[CalendarQuarter] LIKE LTRIM(RTRIM(@CalendarQuarter)) + '%') " 
                + "AND   (@SalesAmountQuota IS NULL OR @SalesAmountQuota = '' OR [FactSalesQuota].[SalesAmountQuota] LIKE LTRIM(RTRIM(@SalesAmountQuota)) + '%') " 
                + "AND   (@Date IS NULL OR @Date = '' OR [FactSalesQuota].[Date] LIKE LTRIM(RTRIM(@Date)) + '%') " 
                + "";
        } else if  (sCondition == "More than...") {
            selectStatement
                = "SELECT "
            + "     [dbo].[FactSalesQuota].[SalesQuotaKey] "
            + "    ,[A300].[EmployeeKey]"
            + "    ,[A301].[DateKey]"
            + "    ,[dbo].[FactSalesQuota].[CalendarYear] "
            + "    ,[dbo].[FactSalesQuota].[CalendarQuarter] "
            + "    ,[dbo].[FactSalesQuota].[SalesAmountQuota] "
            + "    ,[dbo].[FactSalesQuota].[Date] "
            + "FROM " 
            + "     [dbo].[FactSalesQuota] " 
            + "INNER JOIN [dbo].[DimEmployee] as [A300] ON [dbo].[FactSalesQuota].[EmployeeKey] = [A300].[EmployeeKey] "
            + "INNER JOIN [dbo].[DimDate] as [A301] ON [dbo].[FactSalesQuota].[DateKey] = [A301].[DateKey] "
                + "WHERE " 
                + "     (@SalesQuotaKey IS NULL OR @SalesQuotaKey = '' OR [FactSalesQuota].[SalesQuotaKey] > LTRIM(RTRIM(@SalesQuotaKey))) " 
                + "AND   (@EmployeeKey300 IS NULL OR @EmployeeKey300 = '' OR [A300].[EmployeeKey] > LTRIM(RTRIM(@EmployeeKey300))) " 
                + "AND   (@DateKey301 IS NULL OR @DateKey301 = '' OR [A301].[DateKey] > LTRIM(RTRIM(@DateKey301))) " 
                + "AND   (@CalendarYear IS NULL OR @CalendarYear = '' OR [FactSalesQuota].[CalendarYear] > LTRIM(RTRIM(@CalendarYear))) " 
                + "AND   (@CalendarQuarter IS NULL OR @CalendarQuarter = '' OR [FactSalesQuota].[CalendarQuarter] > LTRIM(RTRIM(@CalendarQuarter))) " 
                + "AND   (@SalesAmountQuota IS NULL OR @SalesAmountQuota = '' OR [FactSalesQuota].[SalesAmountQuota] > LTRIM(RTRIM(@SalesAmountQuota))) " 
                + "AND   (@Date IS NULL OR @Date = '' OR [FactSalesQuota].[Date] > LTRIM(RTRIM(@Date))) " 
                + "";
        } else if  (sCondition == "Less than...") {
            selectStatement
                = "SELECT " 
            + "     [dbo].[FactSalesQuota].[SalesQuotaKey] "
            + "    ,[A300].[EmployeeKey]"
            + "    ,[A301].[DateKey]"
            + "    ,[dbo].[FactSalesQuota].[CalendarYear] "
            + "    ,[dbo].[FactSalesQuota].[CalendarQuarter] "
            + "    ,[dbo].[FactSalesQuota].[SalesAmountQuota] "
            + "    ,[dbo].[FactSalesQuota].[Date] "
            + "FROM " 
            + "     [dbo].[FactSalesQuota] " 
            + "INNER JOIN [dbo].[DimEmployee] as [A300] ON [dbo].[FactSalesQuota].[EmployeeKey] = [A300].[EmployeeKey] "
            + "INNER JOIN [dbo].[DimDate] as [A301] ON [dbo].[FactSalesQuota].[DateKey] = [A301].[DateKey] "
                + "WHERE " 
                + "     (@SalesQuotaKey IS NULL OR @SalesQuotaKey = '' OR [FactSalesQuota].[SalesQuotaKey] < LTRIM(RTRIM(@SalesQuotaKey))) " 
                + "AND   (@EmployeeKey300 IS NULL OR @EmployeeKey300 = '' OR [A300].[EmployeeKey] < LTRIM(RTRIM(@EmployeeKey300))) " 
                + "AND   (@DateKey301 IS NULL OR @DateKey301 = '' OR [A301].[DateKey] < LTRIM(RTRIM(@DateKey301))) " 
                + "AND   (@CalendarYear IS NULL OR @CalendarYear = '' OR [FactSalesQuota].[CalendarYear] < LTRIM(RTRIM(@CalendarYear))) " 
                + "AND   (@CalendarQuarter IS NULL OR @CalendarQuarter = '' OR [FactSalesQuota].[CalendarQuarter] < LTRIM(RTRIM(@CalendarQuarter))) " 
                + "AND   (@SalesAmountQuota IS NULL OR @SalesAmountQuota = '' OR [FactSalesQuota].[SalesAmountQuota] < LTRIM(RTRIM(@SalesAmountQuota))) " 
                + "AND   (@Date IS NULL OR @Date = '' OR [FactSalesQuota].[Date] < LTRIM(RTRIM(@Date))) " 
                + "";
        } else if  (sCondition == "Equal or more than...") {
            selectStatement
                = "SELECT "
            + "     [dbo].[FactSalesQuota].[SalesQuotaKey] "
            + "    ,[A300].[EmployeeKey]"
            + "    ,[A301].[DateKey]"
            + "    ,[dbo].[FactSalesQuota].[CalendarYear] "
            + "    ,[dbo].[FactSalesQuota].[CalendarQuarter] "
            + "    ,[dbo].[FactSalesQuota].[SalesAmountQuota] "
            + "    ,[dbo].[FactSalesQuota].[Date] "
            + "FROM " 
            + "     [dbo].[FactSalesQuota] " 
            + "INNER JOIN [dbo].[DimEmployee] as [A300] ON [dbo].[FactSalesQuota].[EmployeeKey] = [A300].[EmployeeKey] "
            + "INNER JOIN [dbo].[DimDate] as [A301] ON [dbo].[FactSalesQuota].[DateKey] = [A301].[DateKey] "
                + "WHERE " 
                + "     (@SalesQuotaKey IS NULL OR @SalesQuotaKey = '' OR [FactSalesQuota].[SalesQuotaKey] >= LTRIM(RTRIM(@SalesQuotaKey))) " 
                + "AND   (@EmployeeKey300 IS NULL OR @EmployeeKey300 = '' OR [A300].[EmployeeKey] >= LTRIM(RTRIM(@EmployeeKey300))) " 
                + "AND   (@DateKey301 IS NULL OR @DateKey301 = '' OR [A301].[DateKey] >= LTRIM(RTRIM(@DateKey301))) " 
                + "AND   (@CalendarYear IS NULL OR @CalendarYear = '' OR [FactSalesQuota].[CalendarYear] >= LTRIM(RTRIM(@CalendarYear))) " 
                + "AND   (@CalendarQuarter IS NULL OR @CalendarQuarter = '' OR [FactSalesQuota].[CalendarQuarter] >= LTRIM(RTRIM(@CalendarQuarter))) " 
                + "AND   (@SalesAmountQuota IS NULL OR @SalesAmountQuota = '' OR [FactSalesQuota].[SalesAmountQuota] >= LTRIM(RTRIM(@SalesAmountQuota))) " 
                + "AND   (@Date IS NULL OR @Date = '' OR [FactSalesQuota].[Date] >= LTRIM(RTRIM(@Date))) " 
                + "";
        } else if (sCondition == "Equal or less than...") {
            selectStatement 
                = "SELECT "
            + "     [dbo].[FactSalesQuota].[SalesQuotaKey] "
            + "    ,[A300].[EmployeeKey]"
            + "    ,[A301].[DateKey]"
            + "    ,[dbo].[FactSalesQuota].[CalendarYear] "
            + "    ,[dbo].[FactSalesQuota].[CalendarQuarter] "
            + "    ,[dbo].[FactSalesQuota].[SalesAmountQuota] "
            + "    ,[dbo].[FactSalesQuota].[Date] "
            + "FROM " 
            + "     [dbo].[FactSalesQuota] " 
            + "INNER JOIN [dbo].[DimEmployee] as [A300] ON [dbo].[FactSalesQuota].[EmployeeKey] = [A300].[EmployeeKey] "
            + "INNER JOIN [dbo].[DimDate] as [A301] ON [dbo].[FactSalesQuota].[DateKey] = [A301].[DateKey] "
                + "WHERE " 
                + "     (@SalesQuotaKey IS NULL OR @SalesQuotaKey = '' OR [FactSalesQuota].[SalesQuotaKey] <= LTRIM(RTRIM(@SalesQuotaKey))) " 
                + "AND   (@EmployeeKey300 IS NULL OR @EmployeeKey300 = '' OR [A300].[EmployeeKey] <= LTRIM(RTRIM(@EmployeeKey300))) " 
                + "AND   (@DateKey301 IS NULL OR @DateKey301 = '' OR [A301].[DateKey] <= LTRIM(RTRIM(@DateKey301))) " 
                + "AND   (@CalendarYear IS NULL OR @CalendarYear = '' OR [FactSalesQuota].[CalendarYear] <= LTRIM(RTRIM(@CalendarYear))) " 
                + "AND   (@CalendarQuarter IS NULL OR @CalendarQuarter = '' OR [FactSalesQuota].[CalendarQuarter] <= LTRIM(RTRIM(@CalendarQuarter))) " 
                + "AND   (@SalesAmountQuota IS NULL OR @SalesAmountQuota = '' OR [FactSalesQuota].[SalesAmountQuota] <= LTRIM(RTRIM(@SalesAmountQuota))) " 
                + "AND   (@Date IS NULL OR @Date = '' OR [FactSalesQuota].[Date] <= LTRIM(RTRIM(@Date))) " 
                + "";
        }
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        selectCommand.CommandType = CommandType.Text;
        if (sField == "Sales Quota Key") {
            selectCommand.Parameters.AddWithValue("@SalesQuotaKey", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@SalesQuotaKey", DBNull.Value); }
        if (sField == "Employee Key") {
            selectCommand.Parameters.AddWithValue("@EmployeeKey300", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@EmployeeKey300", DBNull.Value); }
        if (sField == "Date Key") {
            selectCommand.Parameters.AddWithValue("@DateKey301", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@DateKey301", DBNull.Value); }
        if (sField == "Calendar Year") {
            selectCommand.Parameters.AddWithValue("@CalendarYear", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@CalendarYear", DBNull.Value); }
        if (sField == "Calendar Quarter") {
            selectCommand.Parameters.AddWithValue("@CalendarQuarter", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@CalendarQuarter", DBNull.Value); }
        if (sField == "Sales Amount Quota") {
            selectCommand.Parameters.AddWithValue("@SalesAmountQuota", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@SalesAmountQuota", DBNull.Value); }
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

    public static dbo_FactSalesQuotaClass Select_Record(dbo_FactSalesQuotaClass clsdbo_FactSalesQuotaPara)
    {
        dbo_FactSalesQuotaClass clsdbo_FactSalesQuota = new dbo_FactSalesQuotaClass();
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement
            = "SELECT " 
            + "     [SalesQuotaKey] "
            + "    ,[EmployeeKey] "
            + "    ,[DateKey] "
            + "    ,[CalendarYear] "
            + "    ,[CalendarQuarter] "
            + "    ,[SalesAmountQuota] "
            + "    ,[Date] "
            + "FROM "
            + "     [dbo].[FactSalesQuota] "
            + "WHERE "
            + "     [SalesQuotaKey] = @SalesQuotaKey "
            + "";
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        selectCommand.CommandType = CommandType.Text;
        selectCommand.Parameters.AddWithValue("@SalesQuotaKey", clsdbo_FactSalesQuotaPara.SalesQuotaKey);
        try
        {
            connection.Open();
            SqlDataReader reader
                = selectCommand.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                clsdbo_FactSalesQuota.SalesQuotaKey = System.Convert.ToInt32(reader["SalesQuotaKey"]);
                clsdbo_FactSalesQuota.EmployeeKey = System.Convert.ToInt32(reader["EmployeeKey"]);
                clsdbo_FactSalesQuota.DateKey = System.Convert.ToInt32(reader["DateKey"]);
                clsdbo_FactSalesQuota.CalendarYear = System.Convert.ToInt16(reader["CalendarYear"]);
                clsdbo_FactSalesQuota.CalendarQuarter = System.Convert.ToByte(reader["CalendarQuarter"]);
                clsdbo_FactSalesQuota.SalesAmountQuota = System.Convert.ToDecimal(reader["SalesAmountQuota"]);
                clsdbo_FactSalesQuota.Date = reader["Date"] is DBNull ? null : (DateTime?)reader["Date"];
            }
            else
            {
                clsdbo_FactSalesQuota = null;
            }
            reader.Close();
        }
        catch (SqlException)
        {
            return clsdbo_FactSalesQuota;
        }
        finally
        {
            connection.Close();
        }
        return clsdbo_FactSalesQuota;
    }

    public static bool Add(dbo_FactSalesQuotaClass clsdbo_FactSalesQuota)
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string insertStatement
            = "INSERT " 
            + "     [dbo].[FactSalesQuota] "
            + "     ( "
            + "     [EmployeeKey] "
            + "    ,[DateKey] "
            + "    ,[CalendarYear] "
            + "    ,[CalendarQuarter] "
            + "    ,[SalesAmountQuota] "
            + "    ,[Date] "
            + "     ) "
            + "VALUES " 
            + "     ( "
            + "     @EmployeeKey "
            + "    ,@DateKey "
            + "    ,@CalendarYear "
            + "    ,@CalendarQuarter "
            + "    ,@SalesAmountQuota "
            + "    ,@Date "
            + "     ) "
            + "";
        SqlCommand insertCommand = new SqlCommand(insertStatement, connection);
        insertCommand.CommandType = CommandType.Text;
        insertCommand.Parameters.AddWithValue("@EmployeeKey", clsdbo_FactSalesQuota.EmployeeKey);
        insertCommand.Parameters.AddWithValue("@DateKey", clsdbo_FactSalesQuota.DateKey);
        insertCommand.Parameters.AddWithValue("@CalendarYear", clsdbo_FactSalesQuota.CalendarYear);
        insertCommand.Parameters.AddWithValue("@CalendarQuarter", clsdbo_FactSalesQuota.CalendarQuarter);
        insertCommand.Parameters.AddWithValue("@SalesAmountQuota", clsdbo_FactSalesQuota.SalesAmountQuota);
        if (clsdbo_FactSalesQuota.Date.HasValue == true) {
            insertCommand.Parameters.AddWithValue("@Date", clsdbo_FactSalesQuota.Date);
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

    public static bool Update(dbo_FactSalesQuotaClass olddbo_FactSalesQuotaClass, 
           dbo_FactSalesQuotaClass newdbo_FactSalesQuotaClass)
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string updateStatement
            = "UPDATE "  
            + "     [dbo].[FactSalesQuota] "
            + "SET "
            + "     [EmployeeKey] = @NewEmployeeKey "
            + "    ,[DateKey] = @NewDateKey "
            + "    ,[CalendarYear] = @NewCalendarYear "
            + "    ,[CalendarQuarter] = @NewCalendarQuarter "
            + "    ,[SalesAmountQuota] = @NewSalesAmountQuota "
            + "    ,[Date] = @NewDate "
            + "WHERE "
            + "     [SalesQuotaKey] = @OldSalesQuotaKey " 
            + " AND [EmployeeKey] = @OldEmployeeKey " 
            + " AND [DateKey] = @OldDateKey " 
            + " AND [CalendarYear] = @OldCalendarYear " 
            + " AND [CalendarQuarter] = @OldCalendarQuarter " 
            + " AND [SalesAmountQuota] = @OldSalesAmountQuota " 
            + " AND ((@OldDate IS NULL AND [Date] IS NULL) OR [Date] = @OldDate) " 
            + "";
        SqlCommand updateCommand = new SqlCommand(updateStatement, connection);
        updateCommand.CommandType = CommandType.Text;
        updateCommand.Parameters.AddWithValue("@NewEmployeeKey", newdbo_FactSalesQuotaClass.EmployeeKey);
        updateCommand.Parameters.AddWithValue("@NewDateKey", newdbo_FactSalesQuotaClass.DateKey);
        updateCommand.Parameters.AddWithValue("@NewCalendarYear", newdbo_FactSalesQuotaClass.CalendarYear);
        updateCommand.Parameters.AddWithValue("@NewCalendarQuarter", newdbo_FactSalesQuotaClass.CalendarQuarter);
        updateCommand.Parameters.AddWithValue("@NewSalesAmountQuota", newdbo_FactSalesQuotaClass.SalesAmountQuota);
        if (newdbo_FactSalesQuotaClass.Date.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@NewDate", newdbo_FactSalesQuotaClass.Date);
        } else {
            updateCommand.Parameters.AddWithValue("@NewDate", DBNull.Value); }
        updateCommand.Parameters.AddWithValue("@OldSalesQuotaKey", olddbo_FactSalesQuotaClass.SalesQuotaKey);
        updateCommand.Parameters.AddWithValue("@OldEmployeeKey", olddbo_FactSalesQuotaClass.EmployeeKey);
        updateCommand.Parameters.AddWithValue("@OldDateKey", olddbo_FactSalesQuotaClass.DateKey);
        updateCommand.Parameters.AddWithValue("@OldCalendarYear", olddbo_FactSalesQuotaClass.CalendarYear);
        updateCommand.Parameters.AddWithValue("@OldCalendarQuarter", olddbo_FactSalesQuotaClass.CalendarQuarter);
        updateCommand.Parameters.AddWithValue("@OldSalesAmountQuota", olddbo_FactSalesQuotaClass.SalesAmountQuota);
        if (olddbo_FactSalesQuotaClass.Date.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@OldDate", olddbo_FactSalesQuotaClass.Date);
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

    public static bool Delete(dbo_FactSalesQuotaClass clsdbo_FactSalesQuota)
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string deleteStatement
            = "DELETE FROM "  
            + "     [dbo].[FactSalesQuota] "
            + "WHERE " 
            + "     [SalesQuotaKey] = @OldSalesQuotaKey " 
            + " AND [EmployeeKey] = @OldEmployeeKey " 
            + " AND [DateKey] = @OldDateKey " 
            + " AND [CalendarYear] = @OldCalendarYear " 
            + " AND [CalendarQuarter] = @OldCalendarQuarter " 
            + " AND [SalesAmountQuota] = @OldSalesAmountQuota " 
            + " AND ((@OldDate IS NULL AND [Date] IS NULL) OR [Date] = @OldDate) " 
            + "";
        SqlCommand deleteCommand = new SqlCommand(deleteStatement, connection);
        deleteCommand.CommandType = CommandType.Text;
        deleteCommand.Parameters.AddWithValue("@OldSalesQuotaKey", clsdbo_FactSalesQuota.SalesQuotaKey);
        deleteCommand.Parameters.AddWithValue("@OldEmployeeKey", clsdbo_FactSalesQuota.EmployeeKey);
        deleteCommand.Parameters.AddWithValue("@OldDateKey", clsdbo_FactSalesQuota.DateKey);
        deleteCommand.Parameters.AddWithValue("@OldCalendarYear", clsdbo_FactSalesQuota.CalendarYear);
        deleteCommand.Parameters.AddWithValue("@OldCalendarQuarter", clsdbo_FactSalesQuota.CalendarQuarter);
        deleteCommand.Parameters.AddWithValue("@OldSalesAmountQuota", clsdbo_FactSalesQuota.SalesAmountQuota);
        if (clsdbo_FactSalesQuota.Date.HasValue == true) {
            deleteCommand.Parameters.AddWithValue("@OldDate", clsdbo_FactSalesQuota.Date);
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

 
