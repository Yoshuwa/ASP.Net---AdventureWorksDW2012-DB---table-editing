using System;
using System.Data;
using System.Data.SqlClient;

public class dbo_DimDateDataClass
{

    public static DataTable SelectAll()
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement
            = "SELECT "  
            + "     [dbo].[DimDate].[DateKey] "
            + "    ,[dbo].[DimDate].[FullDateAlternateKey] "
            + "    ,[dbo].[DimDate].[DayNumberOfWeek] "
            + "    ,[dbo].[DimDate].[EnglishDayNameOfWeek] "
            + "    ,[dbo].[DimDate].[SpanishDayNameOfWeek] "
            + "    ,[dbo].[DimDate].[FrenchDayNameOfWeek] "
            + "    ,[dbo].[DimDate].[DayNumberOfMonth] "
            + "    ,[dbo].[DimDate].[DayNumberOfYear] "
            + "    ,[dbo].[DimDate].[WeekNumberOfYear] "
            + "    ,[dbo].[DimDate].[EnglishMonthName] "
            + "    ,[dbo].[DimDate].[SpanishMonthName] "
            + "    ,[dbo].[DimDate].[FrenchMonthName] "
            + "    ,[dbo].[DimDate].[MonthNumberOfYear] "
            + "    ,[dbo].[DimDate].[CalendarQuarter] "
            + "    ,[dbo].[DimDate].[CalendarYear] "
            + "    ,[dbo].[DimDate].[CalendarSemester] "
            + "    ,[dbo].[DimDate].[FiscalQuarter] "
            + "    ,[dbo].[DimDate].[FiscalYear] "
            + "    ,[dbo].[DimDate].[FiscalSemester] "
            + "FROM " 
            + "     [dbo].[DimDate] " 
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
            + "     [dbo].[DimDate].[DateKey] "
            + "    ,[dbo].[DimDate].[FullDateAlternateKey] "
            + "    ,[dbo].[DimDate].[DayNumberOfWeek] "
            + "    ,[dbo].[DimDate].[EnglishDayNameOfWeek] "
            + "    ,[dbo].[DimDate].[SpanishDayNameOfWeek] "
            + "    ,[dbo].[DimDate].[FrenchDayNameOfWeek] "
            + "    ,[dbo].[DimDate].[DayNumberOfMonth] "
            + "    ,[dbo].[DimDate].[DayNumberOfYear] "
            + "    ,[dbo].[DimDate].[WeekNumberOfYear] "
            + "    ,[dbo].[DimDate].[EnglishMonthName] "
            + "    ,[dbo].[DimDate].[SpanishMonthName] "
            + "    ,[dbo].[DimDate].[FrenchMonthName] "
            + "    ,[dbo].[DimDate].[MonthNumberOfYear] "
            + "    ,[dbo].[DimDate].[CalendarQuarter] "
            + "    ,[dbo].[DimDate].[CalendarYear] "
            + "    ,[dbo].[DimDate].[CalendarSemester] "
            + "    ,[dbo].[DimDate].[FiscalQuarter] "
            + "    ,[dbo].[DimDate].[FiscalYear] "
            + "    ,[dbo].[DimDate].[FiscalSemester] "
            + "FROM " 
            + "     [dbo].[DimDate] " 
                + "WHERE " 
                + "     (@DateKey IS NULL OR @DateKey = '' OR [DimDate].[DateKey] LIKE '%' + LTRIM(RTRIM(@DateKey)) + '%') " 
                + "AND   (@FullDateAlternateKey IS NULL OR @FullDateAlternateKey = '' OR [DimDate].[FullDateAlternateKey] LIKE '%' + LTRIM(RTRIM(@FullDateAlternateKey)) + '%') " 
                + "AND   (@DayNumberOfWeek IS NULL OR @DayNumberOfWeek = '' OR [DimDate].[DayNumberOfWeek] LIKE '%' + LTRIM(RTRIM(@DayNumberOfWeek)) + '%') " 
                + "AND   (@EnglishDayNameOfWeek IS NULL OR @EnglishDayNameOfWeek = '' OR [DimDate].[EnglishDayNameOfWeek] LIKE '%' + LTRIM(RTRIM(@EnglishDayNameOfWeek)) + '%') " 
                + "AND   (@SpanishDayNameOfWeek IS NULL OR @SpanishDayNameOfWeek = '' OR [DimDate].[SpanishDayNameOfWeek] LIKE '%' + LTRIM(RTRIM(@SpanishDayNameOfWeek)) + '%') " 
                + "AND   (@FrenchDayNameOfWeek IS NULL OR @FrenchDayNameOfWeek = '' OR [DimDate].[FrenchDayNameOfWeek] LIKE '%' + LTRIM(RTRIM(@FrenchDayNameOfWeek)) + '%') " 
                + "AND   (@DayNumberOfMonth IS NULL OR @DayNumberOfMonth = '' OR [DimDate].[DayNumberOfMonth] LIKE '%' + LTRIM(RTRIM(@DayNumberOfMonth)) + '%') " 
                + "AND   (@DayNumberOfYear IS NULL OR @DayNumberOfYear = '' OR [DimDate].[DayNumberOfYear] LIKE '%' + LTRIM(RTRIM(@DayNumberOfYear)) + '%') " 
                + "AND   (@WeekNumberOfYear IS NULL OR @WeekNumberOfYear = '' OR [DimDate].[WeekNumberOfYear] LIKE '%' + LTRIM(RTRIM(@WeekNumberOfYear)) + '%') " 
                + "AND   (@EnglishMonthName IS NULL OR @EnglishMonthName = '' OR [DimDate].[EnglishMonthName] LIKE '%' + LTRIM(RTRIM(@EnglishMonthName)) + '%') " 
                + "AND   (@SpanishMonthName IS NULL OR @SpanishMonthName = '' OR [DimDate].[SpanishMonthName] LIKE '%' + LTRIM(RTRIM(@SpanishMonthName)) + '%') " 
                + "AND   (@FrenchMonthName IS NULL OR @FrenchMonthName = '' OR [DimDate].[FrenchMonthName] LIKE '%' + LTRIM(RTRIM(@FrenchMonthName)) + '%') " 
                + "AND   (@MonthNumberOfYear IS NULL OR @MonthNumberOfYear = '' OR [DimDate].[MonthNumberOfYear] LIKE '%' + LTRIM(RTRIM(@MonthNumberOfYear)) + '%') " 
                + "AND   (@CalendarQuarter IS NULL OR @CalendarQuarter = '' OR [DimDate].[CalendarQuarter] LIKE '%' + LTRIM(RTRIM(@CalendarQuarter)) + '%') " 
                + "AND   (@CalendarYear IS NULL OR @CalendarYear = '' OR [DimDate].[CalendarYear] LIKE '%' + LTRIM(RTRIM(@CalendarYear)) + '%') " 
                + "AND   (@CalendarSemester IS NULL OR @CalendarSemester = '' OR [DimDate].[CalendarSemester] LIKE '%' + LTRIM(RTRIM(@CalendarSemester)) + '%') " 
                + "AND   (@FiscalQuarter IS NULL OR @FiscalQuarter = '' OR [DimDate].[FiscalQuarter] LIKE '%' + LTRIM(RTRIM(@FiscalQuarter)) + '%') " 
                + "AND   (@FiscalYear IS NULL OR @FiscalYear = '' OR [DimDate].[FiscalYear] LIKE '%' + LTRIM(RTRIM(@FiscalYear)) + '%') " 
                + "AND   (@FiscalSemester IS NULL OR @FiscalSemester = '' OR [DimDate].[FiscalSemester] LIKE '%' + LTRIM(RTRIM(@FiscalSemester)) + '%') " 
                + "";
        } else if (sCondition == "Equals") {
            selectStatement
                = "SELECT "
            + "     [dbo].[DimDate].[DateKey] "
            + "    ,[dbo].[DimDate].[FullDateAlternateKey] "
            + "    ,[dbo].[DimDate].[DayNumberOfWeek] "
            + "    ,[dbo].[DimDate].[EnglishDayNameOfWeek] "
            + "    ,[dbo].[DimDate].[SpanishDayNameOfWeek] "
            + "    ,[dbo].[DimDate].[FrenchDayNameOfWeek] "
            + "    ,[dbo].[DimDate].[DayNumberOfMonth] "
            + "    ,[dbo].[DimDate].[DayNumberOfYear] "
            + "    ,[dbo].[DimDate].[WeekNumberOfYear] "
            + "    ,[dbo].[DimDate].[EnglishMonthName] "
            + "    ,[dbo].[DimDate].[SpanishMonthName] "
            + "    ,[dbo].[DimDate].[FrenchMonthName] "
            + "    ,[dbo].[DimDate].[MonthNumberOfYear] "
            + "    ,[dbo].[DimDate].[CalendarQuarter] "
            + "    ,[dbo].[DimDate].[CalendarYear] "
            + "    ,[dbo].[DimDate].[CalendarSemester] "
            + "    ,[dbo].[DimDate].[FiscalQuarter] "
            + "    ,[dbo].[DimDate].[FiscalYear] "
            + "    ,[dbo].[DimDate].[FiscalSemester] "
            + "FROM " 
            + "     [dbo].[DimDate] " 
                + "WHERE " 
                + "     (@DateKey IS NULL OR @DateKey = '' OR [DimDate].[DateKey] = LTRIM(RTRIM(@DateKey))) " 
                + "AND   (@FullDateAlternateKey IS NULL OR @FullDateAlternateKey = '' OR [DimDate].[FullDateAlternateKey] = LTRIM(RTRIM(@FullDateAlternateKey))) " 
                + "AND   (@DayNumberOfWeek IS NULL OR @DayNumberOfWeek = '' OR [DimDate].[DayNumberOfWeek] = LTRIM(RTRIM(@DayNumberOfWeek))) " 
                + "AND   (@EnglishDayNameOfWeek IS NULL OR @EnglishDayNameOfWeek = '' OR [DimDate].[EnglishDayNameOfWeek] = LTRIM(RTRIM(@EnglishDayNameOfWeek))) " 
                + "AND   (@SpanishDayNameOfWeek IS NULL OR @SpanishDayNameOfWeek = '' OR [DimDate].[SpanishDayNameOfWeek] = LTRIM(RTRIM(@SpanishDayNameOfWeek))) " 
                + "AND   (@FrenchDayNameOfWeek IS NULL OR @FrenchDayNameOfWeek = '' OR [DimDate].[FrenchDayNameOfWeek] = LTRIM(RTRIM(@FrenchDayNameOfWeek))) " 
                + "AND   (@DayNumberOfMonth IS NULL OR @DayNumberOfMonth = '' OR [DimDate].[DayNumberOfMonth] = LTRIM(RTRIM(@DayNumberOfMonth))) " 
                + "AND   (@DayNumberOfYear IS NULL OR @DayNumberOfYear = '' OR [DimDate].[DayNumberOfYear] = LTRIM(RTRIM(@DayNumberOfYear))) " 
                + "AND   (@WeekNumberOfYear IS NULL OR @WeekNumberOfYear = '' OR [DimDate].[WeekNumberOfYear] = LTRIM(RTRIM(@WeekNumberOfYear))) " 
                + "AND   (@EnglishMonthName IS NULL OR @EnglishMonthName = '' OR [DimDate].[EnglishMonthName] = LTRIM(RTRIM(@EnglishMonthName))) " 
                + "AND   (@SpanishMonthName IS NULL OR @SpanishMonthName = '' OR [DimDate].[SpanishMonthName] = LTRIM(RTRIM(@SpanishMonthName))) " 
                + "AND   (@FrenchMonthName IS NULL OR @FrenchMonthName = '' OR [DimDate].[FrenchMonthName] = LTRIM(RTRIM(@FrenchMonthName))) " 
                + "AND   (@MonthNumberOfYear IS NULL OR @MonthNumberOfYear = '' OR [DimDate].[MonthNumberOfYear] = LTRIM(RTRIM(@MonthNumberOfYear))) " 
                + "AND   (@CalendarQuarter IS NULL OR @CalendarQuarter = '' OR [DimDate].[CalendarQuarter] = LTRIM(RTRIM(@CalendarQuarter))) " 
                + "AND   (@CalendarYear IS NULL OR @CalendarYear = '' OR [DimDate].[CalendarYear] = LTRIM(RTRIM(@CalendarYear))) " 
                + "AND   (@CalendarSemester IS NULL OR @CalendarSemester = '' OR [DimDate].[CalendarSemester] = LTRIM(RTRIM(@CalendarSemester))) " 
                + "AND   (@FiscalQuarter IS NULL OR @FiscalQuarter = '' OR [DimDate].[FiscalQuarter] = LTRIM(RTRIM(@FiscalQuarter))) " 
                + "AND   (@FiscalYear IS NULL OR @FiscalYear = '' OR [DimDate].[FiscalYear] = LTRIM(RTRIM(@FiscalYear))) " 
                + "AND   (@FiscalSemester IS NULL OR @FiscalSemester = '' OR [DimDate].[FiscalSemester] = LTRIM(RTRIM(@FiscalSemester))) " 
                + "";
        } else if  (sCondition == "Starts with...") {
            selectStatement
                = "SELECT "
            + "     [dbo].[DimDate].[DateKey] "
            + "    ,[dbo].[DimDate].[FullDateAlternateKey] "
            + "    ,[dbo].[DimDate].[DayNumberOfWeek] "
            + "    ,[dbo].[DimDate].[EnglishDayNameOfWeek] "
            + "    ,[dbo].[DimDate].[SpanishDayNameOfWeek] "
            + "    ,[dbo].[DimDate].[FrenchDayNameOfWeek] "
            + "    ,[dbo].[DimDate].[DayNumberOfMonth] "
            + "    ,[dbo].[DimDate].[DayNumberOfYear] "
            + "    ,[dbo].[DimDate].[WeekNumberOfYear] "
            + "    ,[dbo].[DimDate].[EnglishMonthName] "
            + "    ,[dbo].[DimDate].[SpanishMonthName] "
            + "    ,[dbo].[DimDate].[FrenchMonthName] "
            + "    ,[dbo].[DimDate].[MonthNumberOfYear] "
            + "    ,[dbo].[DimDate].[CalendarQuarter] "
            + "    ,[dbo].[DimDate].[CalendarYear] "
            + "    ,[dbo].[DimDate].[CalendarSemester] "
            + "    ,[dbo].[DimDate].[FiscalQuarter] "
            + "    ,[dbo].[DimDate].[FiscalYear] "
            + "    ,[dbo].[DimDate].[FiscalSemester] "
            + "FROM " 
            + "     [dbo].[DimDate] " 
                + "WHERE " 
                + "     (@DateKey IS NULL OR @DateKey = '' OR [DimDate].[DateKey] LIKE LTRIM(RTRIM(@DateKey)) + '%') " 
                + "AND   (@FullDateAlternateKey IS NULL OR @FullDateAlternateKey = '' OR [DimDate].[FullDateAlternateKey] LIKE LTRIM(RTRIM(@FullDateAlternateKey)) + '%') " 
                + "AND   (@DayNumberOfWeek IS NULL OR @DayNumberOfWeek = '' OR [DimDate].[DayNumberOfWeek] LIKE LTRIM(RTRIM(@DayNumberOfWeek)) + '%') " 
                + "AND   (@EnglishDayNameOfWeek IS NULL OR @EnglishDayNameOfWeek = '' OR [DimDate].[EnglishDayNameOfWeek] LIKE LTRIM(RTRIM(@EnglishDayNameOfWeek)) + '%') " 
                + "AND   (@SpanishDayNameOfWeek IS NULL OR @SpanishDayNameOfWeek = '' OR [DimDate].[SpanishDayNameOfWeek] LIKE LTRIM(RTRIM(@SpanishDayNameOfWeek)) + '%') " 
                + "AND   (@FrenchDayNameOfWeek IS NULL OR @FrenchDayNameOfWeek = '' OR [DimDate].[FrenchDayNameOfWeek] LIKE LTRIM(RTRIM(@FrenchDayNameOfWeek)) + '%') " 
                + "AND   (@DayNumberOfMonth IS NULL OR @DayNumberOfMonth = '' OR [DimDate].[DayNumberOfMonth] LIKE LTRIM(RTRIM(@DayNumberOfMonth)) + '%') " 
                + "AND   (@DayNumberOfYear IS NULL OR @DayNumberOfYear = '' OR [DimDate].[DayNumberOfYear] LIKE LTRIM(RTRIM(@DayNumberOfYear)) + '%') " 
                + "AND   (@WeekNumberOfYear IS NULL OR @WeekNumberOfYear = '' OR [DimDate].[WeekNumberOfYear] LIKE LTRIM(RTRIM(@WeekNumberOfYear)) + '%') " 
                + "AND   (@EnglishMonthName IS NULL OR @EnglishMonthName = '' OR [DimDate].[EnglishMonthName] LIKE LTRIM(RTRIM(@EnglishMonthName)) + '%') " 
                + "AND   (@SpanishMonthName IS NULL OR @SpanishMonthName = '' OR [DimDate].[SpanishMonthName] LIKE LTRIM(RTRIM(@SpanishMonthName)) + '%') " 
                + "AND   (@FrenchMonthName IS NULL OR @FrenchMonthName = '' OR [DimDate].[FrenchMonthName] LIKE LTRIM(RTRIM(@FrenchMonthName)) + '%') " 
                + "AND   (@MonthNumberOfYear IS NULL OR @MonthNumberOfYear = '' OR [DimDate].[MonthNumberOfYear] LIKE LTRIM(RTRIM(@MonthNumberOfYear)) + '%') " 
                + "AND   (@CalendarQuarter IS NULL OR @CalendarQuarter = '' OR [DimDate].[CalendarQuarter] LIKE LTRIM(RTRIM(@CalendarQuarter)) + '%') " 
                + "AND   (@CalendarYear IS NULL OR @CalendarYear = '' OR [DimDate].[CalendarYear] LIKE LTRIM(RTRIM(@CalendarYear)) + '%') " 
                + "AND   (@CalendarSemester IS NULL OR @CalendarSemester = '' OR [DimDate].[CalendarSemester] LIKE LTRIM(RTRIM(@CalendarSemester)) + '%') " 
                + "AND   (@FiscalQuarter IS NULL OR @FiscalQuarter = '' OR [DimDate].[FiscalQuarter] LIKE LTRIM(RTRIM(@FiscalQuarter)) + '%') " 
                + "AND   (@FiscalYear IS NULL OR @FiscalYear = '' OR [DimDate].[FiscalYear] LIKE LTRIM(RTRIM(@FiscalYear)) + '%') " 
                + "AND   (@FiscalSemester IS NULL OR @FiscalSemester = '' OR [DimDate].[FiscalSemester] LIKE LTRIM(RTRIM(@FiscalSemester)) + '%') " 
                + "";
        } else if  (sCondition == "More than...") {
            selectStatement
                = "SELECT "
            + "     [dbo].[DimDate].[DateKey] "
            + "    ,[dbo].[DimDate].[FullDateAlternateKey] "
            + "    ,[dbo].[DimDate].[DayNumberOfWeek] "
            + "    ,[dbo].[DimDate].[EnglishDayNameOfWeek] "
            + "    ,[dbo].[DimDate].[SpanishDayNameOfWeek] "
            + "    ,[dbo].[DimDate].[FrenchDayNameOfWeek] "
            + "    ,[dbo].[DimDate].[DayNumberOfMonth] "
            + "    ,[dbo].[DimDate].[DayNumberOfYear] "
            + "    ,[dbo].[DimDate].[WeekNumberOfYear] "
            + "    ,[dbo].[DimDate].[EnglishMonthName] "
            + "    ,[dbo].[DimDate].[SpanishMonthName] "
            + "    ,[dbo].[DimDate].[FrenchMonthName] "
            + "    ,[dbo].[DimDate].[MonthNumberOfYear] "
            + "    ,[dbo].[DimDate].[CalendarQuarter] "
            + "    ,[dbo].[DimDate].[CalendarYear] "
            + "    ,[dbo].[DimDate].[CalendarSemester] "
            + "    ,[dbo].[DimDate].[FiscalQuarter] "
            + "    ,[dbo].[DimDate].[FiscalYear] "
            + "    ,[dbo].[DimDate].[FiscalSemester] "
            + "FROM " 
            + "     [dbo].[DimDate] " 
                + "WHERE " 
                + "     (@DateKey IS NULL OR @DateKey = '' OR [DimDate].[DateKey] > LTRIM(RTRIM(@DateKey))) " 
                + "AND   (@FullDateAlternateKey IS NULL OR @FullDateAlternateKey = '' OR [DimDate].[FullDateAlternateKey] > LTRIM(RTRIM(@FullDateAlternateKey))) " 
                + "AND   (@DayNumberOfWeek IS NULL OR @DayNumberOfWeek = '' OR [DimDate].[DayNumberOfWeek] > LTRIM(RTRIM(@DayNumberOfWeek))) " 
                + "AND   (@EnglishDayNameOfWeek IS NULL OR @EnglishDayNameOfWeek = '' OR [DimDate].[EnglishDayNameOfWeek] > LTRIM(RTRIM(@EnglishDayNameOfWeek))) " 
                + "AND   (@SpanishDayNameOfWeek IS NULL OR @SpanishDayNameOfWeek = '' OR [DimDate].[SpanishDayNameOfWeek] > LTRIM(RTRIM(@SpanishDayNameOfWeek))) " 
                + "AND   (@FrenchDayNameOfWeek IS NULL OR @FrenchDayNameOfWeek = '' OR [DimDate].[FrenchDayNameOfWeek] > LTRIM(RTRIM(@FrenchDayNameOfWeek))) " 
                + "AND   (@DayNumberOfMonth IS NULL OR @DayNumberOfMonth = '' OR [DimDate].[DayNumberOfMonth] > LTRIM(RTRIM(@DayNumberOfMonth))) " 
                + "AND   (@DayNumberOfYear IS NULL OR @DayNumberOfYear = '' OR [DimDate].[DayNumberOfYear] > LTRIM(RTRIM(@DayNumberOfYear))) " 
                + "AND   (@WeekNumberOfYear IS NULL OR @WeekNumberOfYear = '' OR [DimDate].[WeekNumberOfYear] > LTRIM(RTRIM(@WeekNumberOfYear))) " 
                + "AND   (@EnglishMonthName IS NULL OR @EnglishMonthName = '' OR [DimDate].[EnglishMonthName] > LTRIM(RTRIM(@EnglishMonthName))) " 
                + "AND   (@SpanishMonthName IS NULL OR @SpanishMonthName = '' OR [DimDate].[SpanishMonthName] > LTRIM(RTRIM(@SpanishMonthName))) " 
                + "AND   (@FrenchMonthName IS NULL OR @FrenchMonthName = '' OR [DimDate].[FrenchMonthName] > LTRIM(RTRIM(@FrenchMonthName))) " 
                + "AND   (@MonthNumberOfYear IS NULL OR @MonthNumberOfYear = '' OR [DimDate].[MonthNumberOfYear] > LTRIM(RTRIM(@MonthNumberOfYear))) " 
                + "AND   (@CalendarQuarter IS NULL OR @CalendarQuarter = '' OR [DimDate].[CalendarQuarter] > LTRIM(RTRIM(@CalendarQuarter))) " 
                + "AND   (@CalendarYear IS NULL OR @CalendarYear = '' OR [DimDate].[CalendarYear] > LTRIM(RTRIM(@CalendarYear))) " 
                + "AND   (@CalendarSemester IS NULL OR @CalendarSemester = '' OR [DimDate].[CalendarSemester] > LTRIM(RTRIM(@CalendarSemester))) " 
                + "AND   (@FiscalQuarter IS NULL OR @FiscalQuarter = '' OR [DimDate].[FiscalQuarter] > LTRIM(RTRIM(@FiscalQuarter))) " 
                + "AND   (@FiscalYear IS NULL OR @FiscalYear = '' OR [DimDate].[FiscalYear] > LTRIM(RTRIM(@FiscalYear))) " 
                + "AND   (@FiscalSemester IS NULL OR @FiscalSemester = '' OR [DimDate].[FiscalSemester] > LTRIM(RTRIM(@FiscalSemester))) " 
                + "";
        } else if  (sCondition == "Less than...") {
            selectStatement
                = "SELECT " 
            + "     [dbo].[DimDate].[DateKey] "
            + "    ,[dbo].[DimDate].[FullDateAlternateKey] "
            + "    ,[dbo].[DimDate].[DayNumberOfWeek] "
            + "    ,[dbo].[DimDate].[EnglishDayNameOfWeek] "
            + "    ,[dbo].[DimDate].[SpanishDayNameOfWeek] "
            + "    ,[dbo].[DimDate].[FrenchDayNameOfWeek] "
            + "    ,[dbo].[DimDate].[DayNumberOfMonth] "
            + "    ,[dbo].[DimDate].[DayNumberOfYear] "
            + "    ,[dbo].[DimDate].[WeekNumberOfYear] "
            + "    ,[dbo].[DimDate].[EnglishMonthName] "
            + "    ,[dbo].[DimDate].[SpanishMonthName] "
            + "    ,[dbo].[DimDate].[FrenchMonthName] "
            + "    ,[dbo].[DimDate].[MonthNumberOfYear] "
            + "    ,[dbo].[DimDate].[CalendarQuarter] "
            + "    ,[dbo].[DimDate].[CalendarYear] "
            + "    ,[dbo].[DimDate].[CalendarSemester] "
            + "    ,[dbo].[DimDate].[FiscalQuarter] "
            + "    ,[dbo].[DimDate].[FiscalYear] "
            + "    ,[dbo].[DimDate].[FiscalSemester] "
            + "FROM " 
            + "     [dbo].[DimDate] " 
                + "WHERE " 
                + "     (@DateKey IS NULL OR @DateKey = '' OR [DimDate].[DateKey] < LTRIM(RTRIM(@DateKey))) " 
                + "AND   (@FullDateAlternateKey IS NULL OR @FullDateAlternateKey = '' OR [DimDate].[FullDateAlternateKey] < LTRIM(RTRIM(@FullDateAlternateKey))) " 
                + "AND   (@DayNumberOfWeek IS NULL OR @DayNumberOfWeek = '' OR [DimDate].[DayNumberOfWeek] < LTRIM(RTRIM(@DayNumberOfWeek))) " 
                + "AND   (@EnglishDayNameOfWeek IS NULL OR @EnglishDayNameOfWeek = '' OR [DimDate].[EnglishDayNameOfWeek] < LTRIM(RTRIM(@EnglishDayNameOfWeek))) " 
                + "AND   (@SpanishDayNameOfWeek IS NULL OR @SpanishDayNameOfWeek = '' OR [DimDate].[SpanishDayNameOfWeek] < LTRIM(RTRIM(@SpanishDayNameOfWeek))) " 
                + "AND   (@FrenchDayNameOfWeek IS NULL OR @FrenchDayNameOfWeek = '' OR [DimDate].[FrenchDayNameOfWeek] < LTRIM(RTRIM(@FrenchDayNameOfWeek))) " 
                + "AND   (@DayNumberOfMonth IS NULL OR @DayNumberOfMonth = '' OR [DimDate].[DayNumberOfMonth] < LTRIM(RTRIM(@DayNumberOfMonth))) " 
                + "AND   (@DayNumberOfYear IS NULL OR @DayNumberOfYear = '' OR [DimDate].[DayNumberOfYear] < LTRIM(RTRIM(@DayNumberOfYear))) " 
                + "AND   (@WeekNumberOfYear IS NULL OR @WeekNumberOfYear = '' OR [DimDate].[WeekNumberOfYear] < LTRIM(RTRIM(@WeekNumberOfYear))) " 
                + "AND   (@EnglishMonthName IS NULL OR @EnglishMonthName = '' OR [DimDate].[EnglishMonthName] < LTRIM(RTRIM(@EnglishMonthName))) " 
                + "AND   (@SpanishMonthName IS NULL OR @SpanishMonthName = '' OR [DimDate].[SpanishMonthName] < LTRIM(RTRIM(@SpanishMonthName))) " 
                + "AND   (@FrenchMonthName IS NULL OR @FrenchMonthName = '' OR [DimDate].[FrenchMonthName] < LTRIM(RTRIM(@FrenchMonthName))) " 
                + "AND   (@MonthNumberOfYear IS NULL OR @MonthNumberOfYear = '' OR [DimDate].[MonthNumberOfYear] < LTRIM(RTRIM(@MonthNumberOfYear))) " 
                + "AND   (@CalendarQuarter IS NULL OR @CalendarQuarter = '' OR [DimDate].[CalendarQuarter] < LTRIM(RTRIM(@CalendarQuarter))) " 
                + "AND   (@CalendarYear IS NULL OR @CalendarYear = '' OR [DimDate].[CalendarYear] < LTRIM(RTRIM(@CalendarYear))) " 
                + "AND   (@CalendarSemester IS NULL OR @CalendarSemester = '' OR [DimDate].[CalendarSemester] < LTRIM(RTRIM(@CalendarSemester))) " 
                + "AND   (@FiscalQuarter IS NULL OR @FiscalQuarter = '' OR [DimDate].[FiscalQuarter] < LTRIM(RTRIM(@FiscalQuarter))) " 
                + "AND   (@FiscalYear IS NULL OR @FiscalYear = '' OR [DimDate].[FiscalYear] < LTRIM(RTRIM(@FiscalYear))) " 
                + "AND   (@FiscalSemester IS NULL OR @FiscalSemester = '' OR [DimDate].[FiscalSemester] < LTRIM(RTRIM(@FiscalSemester))) " 
                + "";
        } else if  (sCondition == "Equal or more than...") {
            selectStatement
                = "SELECT "
            + "     [dbo].[DimDate].[DateKey] "
            + "    ,[dbo].[DimDate].[FullDateAlternateKey] "
            + "    ,[dbo].[DimDate].[DayNumberOfWeek] "
            + "    ,[dbo].[DimDate].[EnglishDayNameOfWeek] "
            + "    ,[dbo].[DimDate].[SpanishDayNameOfWeek] "
            + "    ,[dbo].[DimDate].[FrenchDayNameOfWeek] "
            + "    ,[dbo].[DimDate].[DayNumberOfMonth] "
            + "    ,[dbo].[DimDate].[DayNumberOfYear] "
            + "    ,[dbo].[DimDate].[WeekNumberOfYear] "
            + "    ,[dbo].[DimDate].[EnglishMonthName] "
            + "    ,[dbo].[DimDate].[SpanishMonthName] "
            + "    ,[dbo].[DimDate].[FrenchMonthName] "
            + "    ,[dbo].[DimDate].[MonthNumberOfYear] "
            + "    ,[dbo].[DimDate].[CalendarQuarter] "
            + "    ,[dbo].[DimDate].[CalendarYear] "
            + "    ,[dbo].[DimDate].[CalendarSemester] "
            + "    ,[dbo].[DimDate].[FiscalQuarter] "
            + "    ,[dbo].[DimDate].[FiscalYear] "
            + "    ,[dbo].[DimDate].[FiscalSemester] "
            + "FROM " 
            + "     [dbo].[DimDate] " 
                + "WHERE " 
                + "     (@DateKey IS NULL OR @DateKey = '' OR [DimDate].[DateKey] >= LTRIM(RTRIM(@DateKey))) " 
                + "AND   (@FullDateAlternateKey IS NULL OR @FullDateAlternateKey = '' OR [DimDate].[FullDateAlternateKey] >= LTRIM(RTRIM(@FullDateAlternateKey))) " 
                + "AND   (@DayNumberOfWeek IS NULL OR @DayNumberOfWeek = '' OR [DimDate].[DayNumberOfWeek] >= LTRIM(RTRIM(@DayNumberOfWeek))) " 
                + "AND   (@EnglishDayNameOfWeek IS NULL OR @EnglishDayNameOfWeek = '' OR [DimDate].[EnglishDayNameOfWeek] >= LTRIM(RTRIM(@EnglishDayNameOfWeek))) " 
                + "AND   (@SpanishDayNameOfWeek IS NULL OR @SpanishDayNameOfWeek = '' OR [DimDate].[SpanishDayNameOfWeek] >= LTRIM(RTRIM(@SpanishDayNameOfWeek))) " 
                + "AND   (@FrenchDayNameOfWeek IS NULL OR @FrenchDayNameOfWeek = '' OR [DimDate].[FrenchDayNameOfWeek] >= LTRIM(RTRIM(@FrenchDayNameOfWeek))) " 
                + "AND   (@DayNumberOfMonth IS NULL OR @DayNumberOfMonth = '' OR [DimDate].[DayNumberOfMonth] >= LTRIM(RTRIM(@DayNumberOfMonth))) " 
                + "AND   (@DayNumberOfYear IS NULL OR @DayNumberOfYear = '' OR [DimDate].[DayNumberOfYear] >= LTRIM(RTRIM(@DayNumberOfYear))) " 
                + "AND   (@WeekNumberOfYear IS NULL OR @WeekNumberOfYear = '' OR [DimDate].[WeekNumberOfYear] >= LTRIM(RTRIM(@WeekNumberOfYear))) " 
                + "AND   (@EnglishMonthName IS NULL OR @EnglishMonthName = '' OR [DimDate].[EnglishMonthName] >= LTRIM(RTRIM(@EnglishMonthName))) " 
                + "AND   (@SpanishMonthName IS NULL OR @SpanishMonthName = '' OR [DimDate].[SpanishMonthName] >= LTRIM(RTRIM(@SpanishMonthName))) " 
                + "AND   (@FrenchMonthName IS NULL OR @FrenchMonthName = '' OR [DimDate].[FrenchMonthName] >= LTRIM(RTRIM(@FrenchMonthName))) " 
                + "AND   (@MonthNumberOfYear IS NULL OR @MonthNumberOfYear = '' OR [DimDate].[MonthNumberOfYear] >= LTRIM(RTRIM(@MonthNumberOfYear))) " 
                + "AND   (@CalendarQuarter IS NULL OR @CalendarQuarter = '' OR [DimDate].[CalendarQuarter] >= LTRIM(RTRIM(@CalendarQuarter))) " 
                + "AND   (@CalendarYear IS NULL OR @CalendarYear = '' OR [DimDate].[CalendarYear] >= LTRIM(RTRIM(@CalendarYear))) " 
                + "AND   (@CalendarSemester IS NULL OR @CalendarSemester = '' OR [DimDate].[CalendarSemester] >= LTRIM(RTRIM(@CalendarSemester))) " 
                + "AND   (@FiscalQuarter IS NULL OR @FiscalQuarter = '' OR [DimDate].[FiscalQuarter] >= LTRIM(RTRIM(@FiscalQuarter))) " 
                + "AND   (@FiscalYear IS NULL OR @FiscalYear = '' OR [DimDate].[FiscalYear] >= LTRIM(RTRIM(@FiscalYear))) " 
                + "AND   (@FiscalSemester IS NULL OR @FiscalSemester = '' OR [DimDate].[FiscalSemester] >= LTRIM(RTRIM(@FiscalSemester))) " 
                + "";
        } else if (sCondition == "Equal or less than...") {
            selectStatement 
                = "SELECT "
            + "     [dbo].[DimDate].[DateKey] "
            + "    ,[dbo].[DimDate].[FullDateAlternateKey] "
            + "    ,[dbo].[DimDate].[DayNumberOfWeek] "
            + "    ,[dbo].[DimDate].[EnglishDayNameOfWeek] "
            + "    ,[dbo].[DimDate].[SpanishDayNameOfWeek] "
            + "    ,[dbo].[DimDate].[FrenchDayNameOfWeek] "
            + "    ,[dbo].[DimDate].[DayNumberOfMonth] "
            + "    ,[dbo].[DimDate].[DayNumberOfYear] "
            + "    ,[dbo].[DimDate].[WeekNumberOfYear] "
            + "    ,[dbo].[DimDate].[EnglishMonthName] "
            + "    ,[dbo].[DimDate].[SpanishMonthName] "
            + "    ,[dbo].[DimDate].[FrenchMonthName] "
            + "    ,[dbo].[DimDate].[MonthNumberOfYear] "
            + "    ,[dbo].[DimDate].[CalendarQuarter] "
            + "    ,[dbo].[DimDate].[CalendarYear] "
            + "    ,[dbo].[DimDate].[CalendarSemester] "
            + "    ,[dbo].[DimDate].[FiscalQuarter] "
            + "    ,[dbo].[DimDate].[FiscalYear] "
            + "    ,[dbo].[DimDate].[FiscalSemester] "
            + "FROM " 
            + "     [dbo].[DimDate] " 
                + "WHERE " 
                + "     (@DateKey IS NULL OR @DateKey = '' OR [DimDate].[DateKey] <= LTRIM(RTRIM(@DateKey))) " 
                + "AND   (@FullDateAlternateKey IS NULL OR @FullDateAlternateKey = '' OR [DimDate].[FullDateAlternateKey] <= LTRIM(RTRIM(@FullDateAlternateKey))) " 
                + "AND   (@DayNumberOfWeek IS NULL OR @DayNumberOfWeek = '' OR [DimDate].[DayNumberOfWeek] <= LTRIM(RTRIM(@DayNumberOfWeek))) " 
                + "AND   (@EnglishDayNameOfWeek IS NULL OR @EnglishDayNameOfWeek = '' OR [DimDate].[EnglishDayNameOfWeek] <= LTRIM(RTRIM(@EnglishDayNameOfWeek))) " 
                + "AND   (@SpanishDayNameOfWeek IS NULL OR @SpanishDayNameOfWeek = '' OR [DimDate].[SpanishDayNameOfWeek] <= LTRIM(RTRIM(@SpanishDayNameOfWeek))) " 
                + "AND   (@FrenchDayNameOfWeek IS NULL OR @FrenchDayNameOfWeek = '' OR [DimDate].[FrenchDayNameOfWeek] <= LTRIM(RTRIM(@FrenchDayNameOfWeek))) " 
                + "AND   (@DayNumberOfMonth IS NULL OR @DayNumberOfMonth = '' OR [DimDate].[DayNumberOfMonth] <= LTRIM(RTRIM(@DayNumberOfMonth))) " 
                + "AND   (@DayNumberOfYear IS NULL OR @DayNumberOfYear = '' OR [DimDate].[DayNumberOfYear] <= LTRIM(RTRIM(@DayNumberOfYear))) " 
                + "AND   (@WeekNumberOfYear IS NULL OR @WeekNumberOfYear = '' OR [DimDate].[WeekNumberOfYear] <= LTRIM(RTRIM(@WeekNumberOfYear))) " 
                + "AND   (@EnglishMonthName IS NULL OR @EnglishMonthName = '' OR [DimDate].[EnglishMonthName] <= LTRIM(RTRIM(@EnglishMonthName))) " 
                + "AND   (@SpanishMonthName IS NULL OR @SpanishMonthName = '' OR [DimDate].[SpanishMonthName] <= LTRIM(RTRIM(@SpanishMonthName))) " 
                + "AND   (@FrenchMonthName IS NULL OR @FrenchMonthName = '' OR [DimDate].[FrenchMonthName] <= LTRIM(RTRIM(@FrenchMonthName))) " 
                + "AND   (@MonthNumberOfYear IS NULL OR @MonthNumberOfYear = '' OR [DimDate].[MonthNumberOfYear] <= LTRIM(RTRIM(@MonthNumberOfYear))) " 
                + "AND   (@CalendarQuarter IS NULL OR @CalendarQuarter = '' OR [DimDate].[CalendarQuarter] <= LTRIM(RTRIM(@CalendarQuarter))) " 
                + "AND   (@CalendarYear IS NULL OR @CalendarYear = '' OR [DimDate].[CalendarYear] <= LTRIM(RTRIM(@CalendarYear))) " 
                + "AND   (@CalendarSemester IS NULL OR @CalendarSemester = '' OR [DimDate].[CalendarSemester] <= LTRIM(RTRIM(@CalendarSemester))) " 
                + "AND   (@FiscalQuarter IS NULL OR @FiscalQuarter = '' OR [DimDate].[FiscalQuarter] <= LTRIM(RTRIM(@FiscalQuarter))) " 
                + "AND   (@FiscalYear IS NULL OR @FiscalYear = '' OR [DimDate].[FiscalYear] <= LTRIM(RTRIM(@FiscalYear))) " 
                + "AND   (@FiscalSemester IS NULL OR @FiscalSemester = '' OR [DimDate].[FiscalSemester] <= LTRIM(RTRIM(@FiscalSemester))) " 
                + "";
        }
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        selectCommand.CommandType = CommandType.Text;
        if (sField == "Date Key") {
            selectCommand.Parameters.AddWithValue("@DateKey", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@DateKey", DBNull.Value); }
        if (sField == "Full Date Alternate Key") {
            selectCommand.Parameters.AddWithValue("@FullDateAlternateKey", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@FullDateAlternateKey", DBNull.Value); }
        if (sField == "Day Number Of Week") {
            selectCommand.Parameters.AddWithValue("@DayNumberOfWeek", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@DayNumberOfWeek", DBNull.Value); }
        if (sField == "English Day Name Of Week") {
            selectCommand.Parameters.AddWithValue("@EnglishDayNameOfWeek", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@EnglishDayNameOfWeek", DBNull.Value); }
        if (sField == "Spanish Day Name Of Week") {
            selectCommand.Parameters.AddWithValue("@SpanishDayNameOfWeek", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@SpanishDayNameOfWeek", DBNull.Value); }
        if (sField == "French Day Name Of Week") {
            selectCommand.Parameters.AddWithValue("@FrenchDayNameOfWeek", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@FrenchDayNameOfWeek", DBNull.Value); }
        if (sField == "Day Number Of Month") {
            selectCommand.Parameters.AddWithValue("@DayNumberOfMonth", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@DayNumberOfMonth", DBNull.Value); }
        if (sField == "Day Number Of Year") {
            selectCommand.Parameters.AddWithValue("@DayNumberOfYear", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@DayNumberOfYear", DBNull.Value); }
        if (sField == "Week Number Of Year") {
            selectCommand.Parameters.AddWithValue("@WeekNumberOfYear", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@WeekNumberOfYear", DBNull.Value); }
        if (sField == "English Month Name") {
            selectCommand.Parameters.AddWithValue("@EnglishMonthName", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@EnglishMonthName", DBNull.Value); }
        if (sField == "Spanish Month Name") {
            selectCommand.Parameters.AddWithValue("@SpanishMonthName", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@SpanishMonthName", DBNull.Value); }
        if (sField == "French Month Name") {
            selectCommand.Parameters.AddWithValue("@FrenchMonthName", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@FrenchMonthName", DBNull.Value); }
        if (sField == "Month Number Of Year") {
            selectCommand.Parameters.AddWithValue("@MonthNumberOfYear", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@MonthNumberOfYear", DBNull.Value); }
        if (sField == "Calendar Quarter") {
            selectCommand.Parameters.AddWithValue("@CalendarQuarter", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@CalendarQuarter", DBNull.Value); }
        if (sField == "Calendar Year") {
            selectCommand.Parameters.AddWithValue("@CalendarYear", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@CalendarYear", DBNull.Value); }
        if (sField == "Calendar Semester") {
            selectCommand.Parameters.AddWithValue("@CalendarSemester", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@CalendarSemester", DBNull.Value); }
        if (sField == "Fiscal Quarter") {
            selectCommand.Parameters.AddWithValue("@FiscalQuarter", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@FiscalQuarter", DBNull.Value); }
        if (sField == "Fiscal Year") {
            selectCommand.Parameters.AddWithValue("@FiscalYear", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@FiscalYear", DBNull.Value); }
        if (sField == "Fiscal Semester") {
            selectCommand.Parameters.AddWithValue("@FiscalSemester", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@FiscalSemester", DBNull.Value); }
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

    public static dbo_DimDateClass Select_Record(dbo_DimDateClass clsdbo_DimDatePara)
    {
        dbo_DimDateClass clsdbo_DimDate = new dbo_DimDateClass();
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement
            = "SELECT " 
            + "     [DateKey] "
            + "    ,[FullDateAlternateKey] "
            + "    ,[DayNumberOfWeek] "
            + "    ,[EnglishDayNameOfWeek] "
            + "    ,[SpanishDayNameOfWeek] "
            + "    ,[FrenchDayNameOfWeek] "
            + "    ,[DayNumberOfMonth] "
            + "    ,[DayNumberOfYear] "
            + "    ,[WeekNumberOfYear] "
            + "    ,[EnglishMonthName] "
            + "    ,[SpanishMonthName] "
            + "    ,[FrenchMonthName] "
            + "    ,[MonthNumberOfYear] "
            + "    ,[CalendarQuarter] "
            + "    ,[CalendarYear] "
            + "    ,[CalendarSemester] "
            + "    ,[FiscalQuarter] "
            + "    ,[FiscalYear] "
            + "    ,[FiscalSemester] "
            + "FROM "
            + "     [dbo].[DimDate] "
            + "WHERE "
            + "     [DateKey] = @DateKey "
            + "";
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        selectCommand.CommandType = CommandType.Text;
        selectCommand.Parameters.AddWithValue("@DateKey", clsdbo_DimDatePara.DateKey);
        try
        {
            connection.Open();
            SqlDataReader reader
                = selectCommand.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                clsdbo_DimDate.DateKey = System.Convert.ToInt32(reader["DateKey"]);
                clsdbo_DimDate.FullDateAlternateKey = System.Convert.ToDateTime(reader["FullDateAlternateKey"]);
                clsdbo_DimDate.DayNumberOfWeek = System.Convert.ToByte(reader["DayNumberOfWeek"]);
                clsdbo_DimDate.EnglishDayNameOfWeek = System.Convert.ToString(reader["EnglishDayNameOfWeek"]);
                clsdbo_DimDate.SpanishDayNameOfWeek = System.Convert.ToString(reader["SpanishDayNameOfWeek"]);
                clsdbo_DimDate.FrenchDayNameOfWeek = System.Convert.ToString(reader["FrenchDayNameOfWeek"]);
                clsdbo_DimDate.DayNumberOfMonth = System.Convert.ToByte(reader["DayNumberOfMonth"]);
                clsdbo_DimDate.DayNumberOfYear = System.Convert.ToInt16(reader["DayNumberOfYear"]);
                clsdbo_DimDate.WeekNumberOfYear = System.Convert.ToByte(reader["WeekNumberOfYear"]);
                clsdbo_DimDate.EnglishMonthName = System.Convert.ToString(reader["EnglishMonthName"]);
                clsdbo_DimDate.SpanishMonthName = System.Convert.ToString(reader["SpanishMonthName"]);
                clsdbo_DimDate.FrenchMonthName = System.Convert.ToString(reader["FrenchMonthName"]);
                clsdbo_DimDate.MonthNumberOfYear = System.Convert.ToByte(reader["MonthNumberOfYear"]);
                clsdbo_DimDate.CalendarQuarter = System.Convert.ToByte(reader["CalendarQuarter"]);
                clsdbo_DimDate.CalendarYear = System.Convert.ToInt16(reader["CalendarYear"]);
                clsdbo_DimDate.CalendarSemester = System.Convert.ToByte(reader["CalendarSemester"]);
                clsdbo_DimDate.FiscalQuarter = System.Convert.ToByte(reader["FiscalQuarter"]);
                clsdbo_DimDate.FiscalYear = System.Convert.ToInt16(reader["FiscalYear"]);
                clsdbo_DimDate.FiscalSemester = System.Convert.ToByte(reader["FiscalSemester"]);
            }
            else
            {
                clsdbo_DimDate = null;
            }
            reader.Close();
        }
        catch (SqlException)
        {
            return clsdbo_DimDate;
        }
        finally
        {
            connection.Close();
        }
        return clsdbo_DimDate;
    }

    public static bool Add(dbo_DimDateClass clsdbo_DimDate)
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string insertStatement
            = "INSERT " 
            + "     [dbo].[DimDate] "
            + "     ( "
            + "     [DateKey] "
            + "    ,[FullDateAlternateKey] "
            + "    ,[DayNumberOfWeek] "
            + "    ,[EnglishDayNameOfWeek] "
            + "    ,[SpanishDayNameOfWeek] "
            + "    ,[FrenchDayNameOfWeek] "
            + "    ,[DayNumberOfMonth] "
            + "    ,[DayNumberOfYear] "
            + "    ,[WeekNumberOfYear] "
            + "    ,[EnglishMonthName] "
            + "    ,[SpanishMonthName] "
            + "    ,[FrenchMonthName] "
            + "    ,[MonthNumberOfYear] "
            + "    ,[CalendarQuarter] "
            + "    ,[CalendarYear] "
            + "    ,[CalendarSemester] "
            + "    ,[FiscalQuarter] "
            + "    ,[FiscalYear] "
            + "    ,[FiscalSemester] "
            + "     ) "
            + "VALUES " 
            + "     ( "
            + "     @DateKey "
            + "    ,@FullDateAlternateKey "
            + "    ,@DayNumberOfWeek "
            + "    ,@EnglishDayNameOfWeek "
            + "    ,@SpanishDayNameOfWeek "
            + "    ,@FrenchDayNameOfWeek "
            + "    ,@DayNumberOfMonth "
            + "    ,@DayNumberOfYear "
            + "    ,@WeekNumberOfYear "
            + "    ,@EnglishMonthName "
            + "    ,@SpanishMonthName "
            + "    ,@FrenchMonthName "
            + "    ,@MonthNumberOfYear "
            + "    ,@CalendarQuarter "
            + "    ,@CalendarYear "
            + "    ,@CalendarSemester "
            + "    ,@FiscalQuarter "
            + "    ,@FiscalYear "
            + "    ,@FiscalSemester "
            + "     ) "
            + "";
        SqlCommand insertCommand = new SqlCommand(insertStatement, connection);
        insertCommand.CommandType = CommandType.Text;
        insertCommand.Parameters.AddWithValue("@DateKey", clsdbo_DimDate.DateKey);
        insertCommand.Parameters.AddWithValue("@FullDateAlternateKey", clsdbo_DimDate.FullDateAlternateKey);
        insertCommand.Parameters.AddWithValue("@DayNumberOfWeek", clsdbo_DimDate.DayNumberOfWeek);
        insertCommand.Parameters.AddWithValue("@EnglishDayNameOfWeek", clsdbo_DimDate.EnglishDayNameOfWeek);
        insertCommand.Parameters.AddWithValue("@SpanishDayNameOfWeek", clsdbo_DimDate.SpanishDayNameOfWeek);
        insertCommand.Parameters.AddWithValue("@FrenchDayNameOfWeek", clsdbo_DimDate.FrenchDayNameOfWeek);
        insertCommand.Parameters.AddWithValue("@DayNumberOfMonth", clsdbo_DimDate.DayNumberOfMonth);
        insertCommand.Parameters.AddWithValue("@DayNumberOfYear", clsdbo_DimDate.DayNumberOfYear);
        insertCommand.Parameters.AddWithValue("@WeekNumberOfYear", clsdbo_DimDate.WeekNumberOfYear);
        insertCommand.Parameters.AddWithValue("@EnglishMonthName", clsdbo_DimDate.EnglishMonthName);
        insertCommand.Parameters.AddWithValue("@SpanishMonthName", clsdbo_DimDate.SpanishMonthName);
        insertCommand.Parameters.AddWithValue("@FrenchMonthName", clsdbo_DimDate.FrenchMonthName);
        insertCommand.Parameters.AddWithValue("@MonthNumberOfYear", clsdbo_DimDate.MonthNumberOfYear);
        insertCommand.Parameters.AddWithValue("@CalendarQuarter", clsdbo_DimDate.CalendarQuarter);
        insertCommand.Parameters.AddWithValue("@CalendarYear", clsdbo_DimDate.CalendarYear);
        insertCommand.Parameters.AddWithValue("@CalendarSemester", clsdbo_DimDate.CalendarSemester);
        insertCommand.Parameters.AddWithValue("@FiscalQuarter", clsdbo_DimDate.FiscalQuarter);
        insertCommand.Parameters.AddWithValue("@FiscalYear", clsdbo_DimDate.FiscalYear);
        insertCommand.Parameters.AddWithValue("@FiscalSemester", clsdbo_DimDate.FiscalSemester);
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

    public static bool Update(dbo_DimDateClass olddbo_DimDateClass, 
           dbo_DimDateClass newdbo_DimDateClass)
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string updateStatement
            = "UPDATE "  
            + "     [dbo].[DimDate] "
            + "SET "
            + "     [DateKey] = @NewDateKey "
            + "    ,[FullDateAlternateKey] = @NewFullDateAlternateKey "
            + "    ,[DayNumberOfWeek] = @NewDayNumberOfWeek "
            + "    ,[EnglishDayNameOfWeek] = @NewEnglishDayNameOfWeek "
            + "    ,[SpanishDayNameOfWeek] = @NewSpanishDayNameOfWeek "
            + "    ,[FrenchDayNameOfWeek] = @NewFrenchDayNameOfWeek "
            + "    ,[DayNumberOfMonth] = @NewDayNumberOfMonth "
            + "    ,[DayNumberOfYear] = @NewDayNumberOfYear "
            + "    ,[WeekNumberOfYear] = @NewWeekNumberOfYear "
            + "    ,[EnglishMonthName] = @NewEnglishMonthName "
            + "    ,[SpanishMonthName] = @NewSpanishMonthName "
            + "    ,[FrenchMonthName] = @NewFrenchMonthName "
            + "    ,[MonthNumberOfYear] = @NewMonthNumberOfYear "
            + "    ,[CalendarQuarter] = @NewCalendarQuarter "
            + "    ,[CalendarYear] = @NewCalendarYear "
            + "    ,[CalendarSemester] = @NewCalendarSemester "
            + "    ,[FiscalQuarter] = @NewFiscalQuarter "
            + "    ,[FiscalYear] = @NewFiscalYear "
            + "    ,[FiscalSemester] = @NewFiscalSemester "
            + "WHERE "
            + "     [DateKey] = @OldDateKey " 
            + " AND [FullDateAlternateKey] = @OldFullDateAlternateKey " 
            + " AND [DayNumberOfWeek] = @OldDayNumberOfWeek " 
            + " AND [EnglishDayNameOfWeek] = @OldEnglishDayNameOfWeek " 
            + " AND [SpanishDayNameOfWeek] = @OldSpanishDayNameOfWeek " 
            + " AND [FrenchDayNameOfWeek] = @OldFrenchDayNameOfWeek " 
            + " AND [DayNumberOfMonth] = @OldDayNumberOfMonth " 
            + " AND [DayNumberOfYear] = @OldDayNumberOfYear " 
            + " AND [WeekNumberOfYear] = @OldWeekNumberOfYear " 
            + " AND [EnglishMonthName] = @OldEnglishMonthName " 
            + " AND [SpanishMonthName] = @OldSpanishMonthName " 
            + " AND [FrenchMonthName] = @OldFrenchMonthName " 
            + " AND [MonthNumberOfYear] = @OldMonthNumberOfYear " 
            + " AND [CalendarQuarter] = @OldCalendarQuarter " 
            + " AND [CalendarYear] = @OldCalendarYear " 
            + " AND [CalendarSemester] = @OldCalendarSemester " 
            + " AND [FiscalQuarter] = @OldFiscalQuarter " 
            + " AND [FiscalYear] = @OldFiscalYear " 
            + " AND [FiscalSemester] = @OldFiscalSemester " 
            + "";
        SqlCommand updateCommand = new SqlCommand(updateStatement, connection);
        updateCommand.CommandType = CommandType.Text;
        updateCommand.Parameters.AddWithValue("@NewDateKey", newdbo_DimDateClass.DateKey);
        updateCommand.Parameters.AddWithValue("@NewFullDateAlternateKey", newdbo_DimDateClass.FullDateAlternateKey);
        updateCommand.Parameters.AddWithValue("@NewDayNumberOfWeek", newdbo_DimDateClass.DayNumberOfWeek);
        updateCommand.Parameters.AddWithValue("@NewEnglishDayNameOfWeek", newdbo_DimDateClass.EnglishDayNameOfWeek);
        updateCommand.Parameters.AddWithValue("@NewSpanishDayNameOfWeek", newdbo_DimDateClass.SpanishDayNameOfWeek);
        updateCommand.Parameters.AddWithValue("@NewFrenchDayNameOfWeek", newdbo_DimDateClass.FrenchDayNameOfWeek);
        updateCommand.Parameters.AddWithValue("@NewDayNumberOfMonth", newdbo_DimDateClass.DayNumberOfMonth);
        updateCommand.Parameters.AddWithValue("@NewDayNumberOfYear", newdbo_DimDateClass.DayNumberOfYear);
        updateCommand.Parameters.AddWithValue("@NewWeekNumberOfYear", newdbo_DimDateClass.WeekNumberOfYear);
        updateCommand.Parameters.AddWithValue("@NewEnglishMonthName", newdbo_DimDateClass.EnglishMonthName);
        updateCommand.Parameters.AddWithValue("@NewSpanishMonthName", newdbo_DimDateClass.SpanishMonthName);
        updateCommand.Parameters.AddWithValue("@NewFrenchMonthName", newdbo_DimDateClass.FrenchMonthName);
        updateCommand.Parameters.AddWithValue("@NewMonthNumberOfYear", newdbo_DimDateClass.MonthNumberOfYear);
        updateCommand.Parameters.AddWithValue("@NewCalendarQuarter", newdbo_DimDateClass.CalendarQuarter);
        updateCommand.Parameters.AddWithValue("@NewCalendarYear", newdbo_DimDateClass.CalendarYear);
        updateCommand.Parameters.AddWithValue("@NewCalendarSemester", newdbo_DimDateClass.CalendarSemester);
        updateCommand.Parameters.AddWithValue("@NewFiscalQuarter", newdbo_DimDateClass.FiscalQuarter);
        updateCommand.Parameters.AddWithValue("@NewFiscalYear", newdbo_DimDateClass.FiscalYear);
        updateCommand.Parameters.AddWithValue("@NewFiscalSemester", newdbo_DimDateClass.FiscalSemester);
        updateCommand.Parameters.AddWithValue("@OldDateKey", olddbo_DimDateClass.DateKey);
        updateCommand.Parameters.AddWithValue("@OldFullDateAlternateKey", olddbo_DimDateClass.FullDateAlternateKey);
        updateCommand.Parameters.AddWithValue("@OldDayNumberOfWeek", olddbo_DimDateClass.DayNumberOfWeek);
        updateCommand.Parameters.AddWithValue("@OldEnglishDayNameOfWeek", olddbo_DimDateClass.EnglishDayNameOfWeek);
        updateCommand.Parameters.AddWithValue("@OldSpanishDayNameOfWeek", olddbo_DimDateClass.SpanishDayNameOfWeek);
        updateCommand.Parameters.AddWithValue("@OldFrenchDayNameOfWeek", olddbo_DimDateClass.FrenchDayNameOfWeek);
        updateCommand.Parameters.AddWithValue("@OldDayNumberOfMonth", olddbo_DimDateClass.DayNumberOfMonth);
        updateCommand.Parameters.AddWithValue("@OldDayNumberOfYear", olddbo_DimDateClass.DayNumberOfYear);
        updateCommand.Parameters.AddWithValue("@OldWeekNumberOfYear", olddbo_DimDateClass.WeekNumberOfYear);
        updateCommand.Parameters.AddWithValue("@OldEnglishMonthName", olddbo_DimDateClass.EnglishMonthName);
        updateCommand.Parameters.AddWithValue("@OldSpanishMonthName", olddbo_DimDateClass.SpanishMonthName);
        updateCommand.Parameters.AddWithValue("@OldFrenchMonthName", olddbo_DimDateClass.FrenchMonthName);
        updateCommand.Parameters.AddWithValue("@OldMonthNumberOfYear", olddbo_DimDateClass.MonthNumberOfYear);
        updateCommand.Parameters.AddWithValue("@OldCalendarQuarter", olddbo_DimDateClass.CalendarQuarter);
        updateCommand.Parameters.AddWithValue("@OldCalendarYear", olddbo_DimDateClass.CalendarYear);
        updateCommand.Parameters.AddWithValue("@OldCalendarSemester", olddbo_DimDateClass.CalendarSemester);
        updateCommand.Parameters.AddWithValue("@OldFiscalQuarter", olddbo_DimDateClass.FiscalQuarter);
        updateCommand.Parameters.AddWithValue("@OldFiscalYear", olddbo_DimDateClass.FiscalYear);
        updateCommand.Parameters.AddWithValue("@OldFiscalSemester", olddbo_DimDateClass.FiscalSemester);
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

    public static bool Delete(dbo_DimDateClass clsdbo_DimDate)
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string deleteStatement
            = "DELETE FROM "  
            + "     [dbo].[DimDate] "
            + "WHERE " 
            + "     [DateKey] = @OldDateKey " 
            + " AND [FullDateAlternateKey] = @OldFullDateAlternateKey " 
            + " AND [DayNumberOfWeek] = @OldDayNumberOfWeek " 
            + " AND [EnglishDayNameOfWeek] = @OldEnglishDayNameOfWeek " 
            + " AND [SpanishDayNameOfWeek] = @OldSpanishDayNameOfWeek " 
            + " AND [FrenchDayNameOfWeek] = @OldFrenchDayNameOfWeek " 
            + " AND [DayNumberOfMonth] = @OldDayNumberOfMonth " 
            + " AND [DayNumberOfYear] = @OldDayNumberOfYear " 
            + " AND [WeekNumberOfYear] = @OldWeekNumberOfYear " 
            + " AND [EnglishMonthName] = @OldEnglishMonthName " 
            + " AND [SpanishMonthName] = @OldSpanishMonthName " 
            + " AND [FrenchMonthName] = @OldFrenchMonthName " 
            + " AND [MonthNumberOfYear] = @OldMonthNumberOfYear " 
            + " AND [CalendarQuarter] = @OldCalendarQuarter " 
            + " AND [CalendarYear] = @OldCalendarYear " 
            + " AND [CalendarSemester] = @OldCalendarSemester " 
            + " AND [FiscalQuarter] = @OldFiscalQuarter " 
            + " AND [FiscalYear] = @OldFiscalYear " 
            + " AND [FiscalSemester] = @OldFiscalSemester " 
            + "";
        SqlCommand deleteCommand = new SqlCommand(deleteStatement, connection);
        deleteCommand.CommandType = CommandType.Text;
        deleteCommand.Parameters.AddWithValue("@OldDateKey", clsdbo_DimDate.DateKey);
        deleteCommand.Parameters.AddWithValue("@OldFullDateAlternateKey", clsdbo_DimDate.FullDateAlternateKey);
        deleteCommand.Parameters.AddWithValue("@OldDayNumberOfWeek", clsdbo_DimDate.DayNumberOfWeek);
        deleteCommand.Parameters.AddWithValue("@OldEnglishDayNameOfWeek", clsdbo_DimDate.EnglishDayNameOfWeek);
        deleteCommand.Parameters.AddWithValue("@OldSpanishDayNameOfWeek", clsdbo_DimDate.SpanishDayNameOfWeek);
        deleteCommand.Parameters.AddWithValue("@OldFrenchDayNameOfWeek", clsdbo_DimDate.FrenchDayNameOfWeek);
        deleteCommand.Parameters.AddWithValue("@OldDayNumberOfMonth", clsdbo_DimDate.DayNumberOfMonth);
        deleteCommand.Parameters.AddWithValue("@OldDayNumberOfYear", clsdbo_DimDate.DayNumberOfYear);
        deleteCommand.Parameters.AddWithValue("@OldWeekNumberOfYear", clsdbo_DimDate.WeekNumberOfYear);
        deleteCommand.Parameters.AddWithValue("@OldEnglishMonthName", clsdbo_DimDate.EnglishMonthName);
        deleteCommand.Parameters.AddWithValue("@OldSpanishMonthName", clsdbo_DimDate.SpanishMonthName);
        deleteCommand.Parameters.AddWithValue("@OldFrenchMonthName", clsdbo_DimDate.FrenchMonthName);
        deleteCommand.Parameters.AddWithValue("@OldMonthNumberOfYear", clsdbo_DimDate.MonthNumberOfYear);
        deleteCommand.Parameters.AddWithValue("@OldCalendarQuarter", clsdbo_DimDate.CalendarQuarter);
        deleteCommand.Parameters.AddWithValue("@OldCalendarYear", clsdbo_DimDate.CalendarYear);
        deleteCommand.Parameters.AddWithValue("@OldCalendarSemester", clsdbo_DimDate.CalendarSemester);
        deleteCommand.Parameters.AddWithValue("@OldFiscalQuarter", clsdbo_DimDate.FiscalQuarter);
        deleteCommand.Parameters.AddWithValue("@OldFiscalYear", clsdbo_DimDate.FiscalYear);
        deleteCommand.Parameters.AddWithValue("@OldFiscalSemester", clsdbo_DimDate.FiscalSemester);
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

 
