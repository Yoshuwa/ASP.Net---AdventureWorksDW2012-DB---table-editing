using System;
using System.Data;
using System.Data.SqlClient;

public class dbo_FactCallCenterDataClass
{

    public static DataTable SelectAll()
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement
            = "SELECT "  
            + "     [dbo].[FactCallCenter].[FactCallCenterID] "
            + "    ,[dbo].[DimDate].[FullDateAlternateKey] "
            + "    ,[dbo].[FactCallCenter].[WageType] "
            + "    ,[dbo].[FactCallCenter].[Shift] "
            + "    ,[dbo].[FactCallCenter].[LevelOneOperators] "
            + "    ,[dbo].[FactCallCenter].[LevelTwoOperators] "
            + "    ,[dbo].[FactCallCenter].[TotalOperators] "
            + "    ,[dbo].[FactCallCenter].[Calls] "
            + "    ,[dbo].[FactCallCenter].[AutomaticResponses] "
            + "    ,[dbo].[FactCallCenter].[Orders] "
            + "    ,[dbo].[FactCallCenter].[IssuesRaised] "
            + "    ,[dbo].[FactCallCenter].[AverageTimePerIssue] "
            + "    ,[dbo].[FactCallCenter].[ServiceGrade] "
            + "    ,[dbo].[FactCallCenter].[Date] "
            + "FROM " 
            + "     [dbo].[FactCallCenter] " 
            + "INNER JOIN [dbo].[DimDate] ON [dbo].[FactCallCenter].[DateKey] = [dbo].[DimDate].[DateKey] "
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
            + "     [dbo].[FactCallCenter].[FactCallCenterID] "
            + "    ,[dbo].[DimDate].[FullDateAlternateKey] "
            + "    ,[dbo].[FactCallCenter].[WageType] "
            + "    ,[dbo].[FactCallCenter].[Shift] "
            + "    ,[dbo].[FactCallCenter].[LevelOneOperators] "
            + "    ,[dbo].[FactCallCenter].[LevelTwoOperators] "
            + "    ,[dbo].[FactCallCenter].[TotalOperators] "
            + "    ,[dbo].[FactCallCenter].[Calls] "
            + "    ,[dbo].[FactCallCenter].[AutomaticResponses] "
            + "    ,[dbo].[FactCallCenter].[Orders] "
            + "    ,[dbo].[FactCallCenter].[IssuesRaised] "
            + "    ,[dbo].[FactCallCenter].[AverageTimePerIssue] "
            + "    ,[dbo].[FactCallCenter].[ServiceGrade] "
            + "    ,[dbo].[FactCallCenter].[Date] "
            + "FROM " 
            + "     [dbo].[FactCallCenter] " 
            + "INNER JOIN [dbo].[DimDate] ON [dbo].[FactCallCenter].[DateKey] = [dbo].[DimDate].[DateKey] "
                + "WHERE " 
                + "     (@FactCallCenterID IS NULL OR @FactCallCenterID = '' OR [FactCallCenter].[FactCallCenterID] LIKE '%' + LTRIM(RTRIM(@FactCallCenterID)) + '%') " 
                + "AND   (@FullDateAlternateKey IS NULL OR @FullDateAlternateKey = '' OR [dbo].[DimDate].[FullDateAlternateKey] LIKE '%' + LTRIM(RTRIM(@FullDateAlternateKey)) + '%') " 
                + "AND   (@WageType IS NULL OR @WageType = '' OR [FactCallCenter].[WageType] LIKE '%' + LTRIM(RTRIM(@WageType)) + '%') " 
                + "AND   (@Shift IS NULL OR @Shift = '' OR [FactCallCenter].[Shift] LIKE '%' + LTRIM(RTRIM(@Shift)) + '%') " 
                + "AND   (@LevelOneOperators IS NULL OR @LevelOneOperators = '' OR [FactCallCenter].[LevelOneOperators] LIKE '%' + LTRIM(RTRIM(@LevelOneOperators)) + '%') " 
                + "AND   (@LevelTwoOperators IS NULL OR @LevelTwoOperators = '' OR [FactCallCenter].[LevelTwoOperators] LIKE '%' + LTRIM(RTRIM(@LevelTwoOperators)) + '%') " 
                + "AND   (@TotalOperators IS NULL OR @TotalOperators = '' OR [FactCallCenter].[TotalOperators] LIKE '%' + LTRIM(RTRIM(@TotalOperators)) + '%') " 
                + "AND   (@Calls IS NULL OR @Calls = '' OR [FactCallCenter].[Calls] LIKE '%' + LTRIM(RTRIM(@Calls)) + '%') " 
                + "AND   (@AutomaticResponses IS NULL OR @AutomaticResponses = '' OR [FactCallCenter].[AutomaticResponses] LIKE '%' + LTRIM(RTRIM(@AutomaticResponses)) + '%') " 
                + "AND   (@Orders IS NULL OR @Orders = '' OR [FactCallCenter].[Orders] LIKE '%' + LTRIM(RTRIM(@Orders)) + '%') " 
                + "AND   (@IssuesRaised IS NULL OR @IssuesRaised = '' OR [FactCallCenter].[IssuesRaised] LIKE '%' + LTRIM(RTRIM(@IssuesRaised)) + '%') " 
                + "AND   (@AverageTimePerIssue IS NULL OR @AverageTimePerIssue = '' OR [FactCallCenter].[AverageTimePerIssue] LIKE '%' + LTRIM(RTRIM(@AverageTimePerIssue)) + '%') " 
                + "AND   (@ServiceGrade IS NULL OR @ServiceGrade = '' OR [FactCallCenter].[ServiceGrade] LIKE '%' + LTRIM(RTRIM(@ServiceGrade)) + '%') " 
                + "AND   (@Date IS NULL OR @Date = '' OR [FactCallCenter].[Date] LIKE '%' + LTRIM(RTRIM(@Date)) + '%') " 
                + "";
        } else if (sCondition == "Equals") {
            selectStatement
                = "SELECT "
            + "     [dbo].[FactCallCenter].[FactCallCenterID] "
            + "    ,[dbo].[DimDate].[FullDateAlternateKey] "
            + "    ,[dbo].[FactCallCenter].[WageType] "
            + "    ,[dbo].[FactCallCenter].[Shift] "
            + "    ,[dbo].[FactCallCenter].[LevelOneOperators] "
            + "    ,[dbo].[FactCallCenter].[LevelTwoOperators] "
            + "    ,[dbo].[FactCallCenter].[TotalOperators] "
            + "    ,[dbo].[FactCallCenter].[Calls] "
            + "    ,[dbo].[FactCallCenter].[AutomaticResponses] "
            + "    ,[dbo].[FactCallCenter].[Orders] "
            + "    ,[dbo].[FactCallCenter].[IssuesRaised] "
            + "    ,[dbo].[FactCallCenter].[AverageTimePerIssue] "
            + "    ,[dbo].[FactCallCenter].[ServiceGrade] "
            + "    ,[dbo].[FactCallCenter].[Date] "
            + "FROM " 
            + "     [dbo].[FactCallCenter] " 
            + "INNER JOIN [dbo].[DimDate] ON [dbo].[FactCallCenter].[DateKey] = [dbo].[DimDate].[DateKey] "
                + "WHERE " 
                + "     (@FactCallCenterID IS NULL OR @FactCallCenterID = '' OR [FactCallCenter].[FactCallCenterID] = LTRIM(RTRIM(@FactCallCenterID))) " 
                + "AND   (@FullDateAlternateKey IS NULL OR @FullDateAlternateKey = '' OR [dbo].[DimDate].[FullDateAlternateKey] = LTRIM(RTRIM(@FullDateAlternateKey))) " 
                + "AND   (@WageType IS NULL OR @WageType = '' OR [FactCallCenter].[WageType] = LTRIM(RTRIM(@WageType))) " 
                + "AND   (@Shift IS NULL OR @Shift = '' OR [FactCallCenter].[Shift] = LTRIM(RTRIM(@Shift))) " 
                + "AND   (@LevelOneOperators IS NULL OR @LevelOneOperators = '' OR [FactCallCenter].[LevelOneOperators] = LTRIM(RTRIM(@LevelOneOperators))) " 
                + "AND   (@LevelTwoOperators IS NULL OR @LevelTwoOperators = '' OR [FactCallCenter].[LevelTwoOperators] = LTRIM(RTRIM(@LevelTwoOperators))) " 
                + "AND   (@TotalOperators IS NULL OR @TotalOperators = '' OR [FactCallCenter].[TotalOperators] = LTRIM(RTRIM(@TotalOperators))) " 
                + "AND   (@Calls IS NULL OR @Calls = '' OR [FactCallCenter].[Calls] = LTRIM(RTRIM(@Calls))) " 
                + "AND   (@AutomaticResponses IS NULL OR @AutomaticResponses = '' OR [FactCallCenter].[AutomaticResponses] = LTRIM(RTRIM(@AutomaticResponses))) " 
                + "AND   (@Orders IS NULL OR @Orders = '' OR [FactCallCenter].[Orders] = LTRIM(RTRIM(@Orders))) " 
                + "AND   (@IssuesRaised IS NULL OR @IssuesRaised = '' OR [FactCallCenter].[IssuesRaised] = LTRIM(RTRIM(@IssuesRaised))) " 
                + "AND   (@AverageTimePerIssue IS NULL OR @AverageTimePerIssue = '' OR [FactCallCenter].[AverageTimePerIssue] = LTRIM(RTRIM(@AverageTimePerIssue))) " 
                + "AND   (@ServiceGrade IS NULL OR @ServiceGrade = '' OR [FactCallCenter].[ServiceGrade] = LTRIM(RTRIM(@ServiceGrade))) " 
                + "AND   (@Date IS NULL OR @Date = '' OR [FactCallCenter].[Date] = LTRIM(RTRIM(@Date))) " 
                + "";
        } else if  (sCondition == "Starts with...") {
            selectStatement
                = "SELECT "
            + "     [dbo].[FactCallCenter].[FactCallCenterID] "
            + "    ,[dbo].[DimDate].[FullDateAlternateKey] "
            + "    ,[dbo].[FactCallCenter].[WageType] "
            + "    ,[dbo].[FactCallCenter].[Shift] "
            + "    ,[dbo].[FactCallCenter].[LevelOneOperators] "
            + "    ,[dbo].[FactCallCenter].[LevelTwoOperators] "
            + "    ,[dbo].[FactCallCenter].[TotalOperators] "
            + "    ,[dbo].[FactCallCenter].[Calls] "
            + "    ,[dbo].[FactCallCenter].[AutomaticResponses] "
            + "    ,[dbo].[FactCallCenter].[Orders] "
            + "    ,[dbo].[FactCallCenter].[IssuesRaised] "
            + "    ,[dbo].[FactCallCenter].[AverageTimePerIssue] "
            + "    ,[dbo].[FactCallCenter].[ServiceGrade] "
            + "    ,[dbo].[FactCallCenter].[Date] "
            + "FROM " 
            + "     [dbo].[FactCallCenter] " 
            + "INNER JOIN [dbo].[DimDate] ON [dbo].[FactCallCenter].[DateKey] = [dbo].[DimDate].[DateKey] "
                + "WHERE " 
                + "     (@FactCallCenterID IS NULL OR @FactCallCenterID = '' OR [FactCallCenter].[FactCallCenterID] LIKE LTRIM(RTRIM(@FactCallCenterID)) + '%') " 
                + "AND   (@FullDateAlternateKey IS NULL OR @FullDateAlternateKey = '' OR [dbo].[DimDate].[FullDateAlternateKey] LIKE LTRIM(RTRIM(@FullDateAlternateKey)) + '%') " 
                + "AND   (@WageType IS NULL OR @WageType = '' OR [FactCallCenter].[WageType] LIKE LTRIM(RTRIM(@WageType)) + '%') " 
                + "AND   (@Shift IS NULL OR @Shift = '' OR [FactCallCenter].[Shift] LIKE LTRIM(RTRIM(@Shift)) + '%') " 
                + "AND   (@LevelOneOperators IS NULL OR @LevelOneOperators = '' OR [FactCallCenter].[LevelOneOperators] LIKE LTRIM(RTRIM(@LevelOneOperators)) + '%') " 
                + "AND   (@LevelTwoOperators IS NULL OR @LevelTwoOperators = '' OR [FactCallCenter].[LevelTwoOperators] LIKE LTRIM(RTRIM(@LevelTwoOperators)) + '%') " 
                + "AND   (@TotalOperators IS NULL OR @TotalOperators = '' OR [FactCallCenter].[TotalOperators] LIKE LTRIM(RTRIM(@TotalOperators)) + '%') " 
                + "AND   (@Calls IS NULL OR @Calls = '' OR [FactCallCenter].[Calls] LIKE LTRIM(RTRIM(@Calls)) + '%') " 
                + "AND   (@AutomaticResponses IS NULL OR @AutomaticResponses = '' OR [FactCallCenter].[AutomaticResponses] LIKE LTRIM(RTRIM(@AutomaticResponses)) + '%') " 
                + "AND   (@Orders IS NULL OR @Orders = '' OR [FactCallCenter].[Orders] LIKE LTRIM(RTRIM(@Orders)) + '%') " 
                + "AND   (@IssuesRaised IS NULL OR @IssuesRaised = '' OR [FactCallCenter].[IssuesRaised] LIKE LTRIM(RTRIM(@IssuesRaised)) + '%') " 
                + "AND   (@AverageTimePerIssue IS NULL OR @AverageTimePerIssue = '' OR [FactCallCenter].[AverageTimePerIssue] LIKE LTRIM(RTRIM(@AverageTimePerIssue)) + '%') " 
                + "AND   (@ServiceGrade IS NULL OR @ServiceGrade = '' OR [FactCallCenter].[ServiceGrade] LIKE LTRIM(RTRIM(@ServiceGrade)) + '%') " 
                + "AND   (@Date IS NULL OR @Date = '' OR [FactCallCenter].[Date] LIKE LTRIM(RTRIM(@Date)) + '%') " 
                + "";
        } else if  (sCondition == "More than...") {
            selectStatement
                = "SELECT "
            + "     [dbo].[FactCallCenter].[FactCallCenterID] "
            + "    ,[dbo].[DimDate].[FullDateAlternateKey] "
            + "    ,[dbo].[FactCallCenter].[WageType] "
            + "    ,[dbo].[FactCallCenter].[Shift] "
            + "    ,[dbo].[FactCallCenter].[LevelOneOperators] "
            + "    ,[dbo].[FactCallCenter].[LevelTwoOperators] "
            + "    ,[dbo].[FactCallCenter].[TotalOperators] "
            + "    ,[dbo].[FactCallCenter].[Calls] "
            + "    ,[dbo].[FactCallCenter].[AutomaticResponses] "
            + "    ,[dbo].[FactCallCenter].[Orders] "
            + "    ,[dbo].[FactCallCenter].[IssuesRaised] "
            + "    ,[dbo].[FactCallCenter].[AverageTimePerIssue] "
            + "    ,[dbo].[FactCallCenter].[ServiceGrade] "
            + "    ,[dbo].[FactCallCenter].[Date] "
            + "FROM " 
            + "     [dbo].[FactCallCenter] " 
            + "INNER JOIN [dbo].[DimDate] ON [dbo].[FactCallCenter].[DateKey] = [dbo].[DimDate].[DateKey] "
                + "WHERE " 
                + "     (@FactCallCenterID IS NULL OR @FactCallCenterID = '' OR [FactCallCenter].[FactCallCenterID] > LTRIM(RTRIM(@FactCallCenterID))) " 
                + "AND   (@FullDateAlternateKey IS NULL OR @FullDateAlternateKey = '' OR [dbo].[DimDate].[FullDateAlternateKey] > LTRIM(RTRIM(@FullDateAlternateKey))) " 
                + "AND   (@WageType IS NULL OR @WageType = '' OR [FactCallCenter].[WageType] > LTRIM(RTRIM(@WageType))) " 
                + "AND   (@Shift IS NULL OR @Shift = '' OR [FactCallCenter].[Shift] > LTRIM(RTRIM(@Shift))) " 
                + "AND   (@LevelOneOperators IS NULL OR @LevelOneOperators = '' OR [FactCallCenter].[LevelOneOperators] > LTRIM(RTRIM(@LevelOneOperators))) " 
                + "AND   (@LevelTwoOperators IS NULL OR @LevelTwoOperators = '' OR [FactCallCenter].[LevelTwoOperators] > LTRIM(RTRIM(@LevelTwoOperators))) " 
                + "AND   (@TotalOperators IS NULL OR @TotalOperators = '' OR [FactCallCenter].[TotalOperators] > LTRIM(RTRIM(@TotalOperators))) " 
                + "AND   (@Calls IS NULL OR @Calls = '' OR [FactCallCenter].[Calls] > LTRIM(RTRIM(@Calls))) " 
                + "AND   (@AutomaticResponses IS NULL OR @AutomaticResponses = '' OR [FactCallCenter].[AutomaticResponses] > LTRIM(RTRIM(@AutomaticResponses))) " 
                + "AND   (@Orders IS NULL OR @Orders = '' OR [FactCallCenter].[Orders] > LTRIM(RTRIM(@Orders))) " 
                + "AND   (@IssuesRaised IS NULL OR @IssuesRaised = '' OR [FactCallCenter].[IssuesRaised] > LTRIM(RTRIM(@IssuesRaised))) " 
                + "AND   (@AverageTimePerIssue IS NULL OR @AverageTimePerIssue = '' OR [FactCallCenter].[AverageTimePerIssue] > LTRIM(RTRIM(@AverageTimePerIssue))) " 
                + "AND   (@ServiceGrade IS NULL OR @ServiceGrade = '' OR [FactCallCenter].[ServiceGrade] > LTRIM(RTRIM(@ServiceGrade))) " 
                + "AND   (@Date IS NULL OR @Date = '' OR [FactCallCenter].[Date] > LTRIM(RTRIM(@Date))) " 
                + "";
        } else if  (sCondition == "Less than...") {
            selectStatement
                = "SELECT " 
            + "     [dbo].[FactCallCenter].[FactCallCenterID] "
            + "    ,[dbo].[DimDate].[FullDateAlternateKey] "
            + "    ,[dbo].[FactCallCenter].[WageType] "
            + "    ,[dbo].[FactCallCenter].[Shift] "
            + "    ,[dbo].[FactCallCenter].[LevelOneOperators] "
            + "    ,[dbo].[FactCallCenter].[LevelTwoOperators] "
            + "    ,[dbo].[FactCallCenter].[TotalOperators] "
            + "    ,[dbo].[FactCallCenter].[Calls] "
            + "    ,[dbo].[FactCallCenter].[AutomaticResponses] "
            + "    ,[dbo].[FactCallCenter].[Orders] "
            + "    ,[dbo].[FactCallCenter].[IssuesRaised] "
            + "    ,[dbo].[FactCallCenter].[AverageTimePerIssue] "
            + "    ,[dbo].[FactCallCenter].[ServiceGrade] "
            + "    ,[dbo].[FactCallCenter].[Date] "
            + "FROM " 
            + "     [dbo].[FactCallCenter] " 
            + "INNER JOIN [dbo].[DimDate] ON [dbo].[FactCallCenter].[DateKey] = [dbo].[DimDate].[DateKey] "
                + "WHERE " 
                + "     (@FactCallCenterID IS NULL OR @FactCallCenterID = '' OR [FactCallCenter].[FactCallCenterID] < LTRIM(RTRIM(@FactCallCenterID))) " 
                + "AND   (@FullDateAlternateKey IS NULL OR @FullDateAlternateKey = '' OR [dbo].[DimDate].[FullDateAlternateKey] < LTRIM(RTRIM(@FullDateAlternateKey))) " 
                + "AND   (@WageType IS NULL OR @WageType = '' OR [FactCallCenter].[WageType] < LTRIM(RTRIM(@WageType))) " 
                + "AND   (@Shift IS NULL OR @Shift = '' OR [FactCallCenter].[Shift] < LTRIM(RTRIM(@Shift))) " 
                + "AND   (@LevelOneOperators IS NULL OR @LevelOneOperators = '' OR [FactCallCenter].[LevelOneOperators] < LTRIM(RTRIM(@LevelOneOperators))) " 
                + "AND   (@LevelTwoOperators IS NULL OR @LevelTwoOperators = '' OR [FactCallCenter].[LevelTwoOperators] < LTRIM(RTRIM(@LevelTwoOperators))) " 
                + "AND   (@TotalOperators IS NULL OR @TotalOperators = '' OR [FactCallCenter].[TotalOperators] < LTRIM(RTRIM(@TotalOperators))) " 
                + "AND   (@Calls IS NULL OR @Calls = '' OR [FactCallCenter].[Calls] < LTRIM(RTRIM(@Calls))) " 
                + "AND   (@AutomaticResponses IS NULL OR @AutomaticResponses = '' OR [FactCallCenter].[AutomaticResponses] < LTRIM(RTRIM(@AutomaticResponses))) " 
                + "AND   (@Orders IS NULL OR @Orders = '' OR [FactCallCenter].[Orders] < LTRIM(RTRIM(@Orders))) " 
                + "AND   (@IssuesRaised IS NULL OR @IssuesRaised = '' OR [FactCallCenter].[IssuesRaised] < LTRIM(RTRIM(@IssuesRaised))) " 
                + "AND   (@AverageTimePerIssue IS NULL OR @AverageTimePerIssue = '' OR [FactCallCenter].[AverageTimePerIssue] < LTRIM(RTRIM(@AverageTimePerIssue))) " 
                + "AND   (@ServiceGrade IS NULL OR @ServiceGrade = '' OR [FactCallCenter].[ServiceGrade] < LTRIM(RTRIM(@ServiceGrade))) " 
                + "AND   (@Date IS NULL OR @Date = '' OR [FactCallCenter].[Date] < LTRIM(RTRIM(@Date))) " 
                + "";
        } else if  (sCondition == "Equal or more than...") {
            selectStatement
                = "SELECT "
            + "     [dbo].[FactCallCenter].[FactCallCenterID] "
            + "    ,[dbo].[DimDate].[FullDateAlternateKey] "
            + "    ,[dbo].[FactCallCenter].[WageType] "
            + "    ,[dbo].[FactCallCenter].[Shift] "
            + "    ,[dbo].[FactCallCenter].[LevelOneOperators] "
            + "    ,[dbo].[FactCallCenter].[LevelTwoOperators] "
            + "    ,[dbo].[FactCallCenter].[TotalOperators] "
            + "    ,[dbo].[FactCallCenter].[Calls] "
            + "    ,[dbo].[FactCallCenter].[AutomaticResponses] "
            + "    ,[dbo].[FactCallCenter].[Orders] "
            + "    ,[dbo].[FactCallCenter].[IssuesRaised] "
            + "    ,[dbo].[FactCallCenter].[AverageTimePerIssue] "
            + "    ,[dbo].[FactCallCenter].[ServiceGrade] "
            + "    ,[dbo].[FactCallCenter].[Date] "
            + "FROM " 
            + "     [dbo].[FactCallCenter] " 
            + "INNER JOIN [dbo].[DimDate] ON [dbo].[FactCallCenter].[DateKey] = [dbo].[DimDate].[DateKey] "
                + "WHERE " 
                + "     (@FactCallCenterID IS NULL OR @FactCallCenterID = '' OR [FactCallCenter].[FactCallCenterID] >= LTRIM(RTRIM(@FactCallCenterID))) " 
                + "AND   (@FullDateAlternateKey IS NULL OR @FullDateAlternateKey = '' OR [dbo].[DimDate].[FullDateAlternateKey] >= LTRIM(RTRIM(@FullDateAlternateKey))) " 
                + "AND   (@WageType IS NULL OR @WageType = '' OR [FactCallCenter].[WageType] >= LTRIM(RTRIM(@WageType))) " 
                + "AND   (@Shift IS NULL OR @Shift = '' OR [FactCallCenter].[Shift] >= LTRIM(RTRIM(@Shift))) " 
                + "AND   (@LevelOneOperators IS NULL OR @LevelOneOperators = '' OR [FactCallCenter].[LevelOneOperators] >= LTRIM(RTRIM(@LevelOneOperators))) " 
                + "AND   (@LevelTwoOperators IS NULL OR @LevelTwoOperators = '' OR [FactCallCenter].[LevelTwoOperators] >= LTRIM(RTRIM(@LevelTwoOperators))) " 
                + "AND   (@TotalOperators IS NULL OR @TotalOperators = '' OR [FactCallCenter].[TotalOperators] >= LTRIM(RTRIM(@TotalOperators))) " 
                + "AND   (@Calls IS NULL OR @Calls = '' OR [FactCallCenter].[Calls] >= LTRIM(RTRIM(@Calls))) " 
                + "AND   (@AutomaticResponses IS NULL OR @AutomaticResponses = '' OR [FactCallCenter].[AutomaticResponses] >= LTRIM(RTRIM(@AutomaticResponses))) " 
                + "AND   (@Orders IS NULL OR @Orders = '' OR [FactCallCenter].[Orders] >= LTRIM(RTRIM(@Orders))) " 
                + "AND   (@IssuesRaised IS NULL OR @IssuesRaised = '' OR [FactCallCenter].[IssuesRaised] >= LTRIM(RTRIM(@IssuesRaised))) " 
                + "AND   (@AverageTimePerIssue IS NULL OR @AverageTimePerIssue = '' OR [FactCallCenter].[AverageTimePerIssue] >= LTRIM(RTRIM(@AverageTimePerIssue))) " 
                + "AND   (@ServiceGrade IS NULL OR @ServiceGrade = '' OR [FactCallCenter].[ServiceGrade] >= LTRIM(RTRIM(@ServiceGrade))) " 
                + "AND   (@Date IS NULL OR @Date = '' OR [FactCallCenter].[Date] >= LTRIM(RTRIM(@Date))) " 
                + "";
        } else if (sCondition == "Equal or less than...") {
            selectStatement 
                = "SELECT "
            + "     [dbo].[FactCallCenter].[FactCallCenterID] "
            + "    ,[dbo].[DimDate].[FullDateAlternateKey] "
            + "    ,[dbo].[FactCallCenter].[WageType] "
            + "    ,[dbo].[FactCallCenter].[Shift] "
            + "    ,[dbo].[FactCallCenter].[LevelOneOperators] "
            + "    ,[dbo].[FactCallCenter].[LevelTwoOperators] "
            + "    ,[dbo].[FactCallCenter].[TotalOperators] "
            + "    ,[dbo].[FactCallCenter].[Calls] "
            + "    ,[dbo].[FactCallCenter].[AutomaticResponses] "
            + "    ,[dbo].[FactCallCenter].[Orders] "
            + "    ,[dbo].[FactCallCenter].[IssuesRaised] "
            + "    ,[dbo].[FactCallCenter].[AverageTimePerIssue] "
            + "    ,[dbo].[FactCallCenter].[ServiceGrade] "
            + "    ,[dbo].[FactCallCenter].[Date] "
            + "FROM " 
            + "     [dbo].[FactCallCenter] " 
            + "INNER JOIN [dbo].[DimDate] ON [dbo].[FactCallCenter].[DateKey] = [dbo].[DimDate].[DateKey] "
                + "WHERE " 
                + "     (@FactCallCenterID IS NULL OR @FactCallCenterID = '' OR [FactCallCenter].[FactCallCenterID] <= LTRIM(RTRIM(@FactCallCenterID))) " 
                + "AND   (@FullDateAlternateKey IS NULL OR @FullDateAlternateKey = '' OR [dbo].[DimDate].[FullDateAlternateKey] <= LTRIM(RTRIM(@FullDateAlternateKey))) " 
                + "AND   (@WageType IS NULL OR @WageType = '' OR [FactCallCenter].[WageType] <= LTRIM(RTRIM(@WageType))) " 
                + "AND   (@Shift IS NULL OR @Shift = '' OR [FactCallCenter].[Shift] <= LTRIM(RTRIM(@Shift))) " 
                + "AND   (@LevelOneOperators IS NULL OR @LevelOneOperators = '' OR [FactCallCenter].[LevelOneOperators] <= LTRIM(RTRIM(@LevelOneOperators))) " 
                + "AND   (@LevelTwoOperators IS NULL OR @LevelTwoOperators = '' OR [FactCallCenter].[LevelTwoOperators] <= LTRIM(RTRIM(@LevelTwoOperators))) " 
                + "AND   (@TotalOperators IS NULL OR @TotalOperators = '' OR [FactCallCenter].[TotalOperators] <= LTRIM(RTRIM(@TotalOperators))) " 
                + "AND   (@Calls IS NULL OR @Calls = '' OR [FactCallCenter].[Calls] <= LTRIM(RTRIM(@Calls))) " 
                + "AND   (@AutomaticResponses IS NULL OR @AutomaticResponses = '' OR [FactCallCenter].[AutomaticResponses] <= LTRIM(RTRIM(@AutomaticResponses))) " 
                + "AND   (@Orders IS NULL OR @Orders = '' OR [FactCallCenter].[Orders] <= LTRIM(RTRIM(@Orders))) " 
                + "AND   (@IssuesRaised IS NULL OR @IssuesRaised = '' OR [FactCallCenter].[IssuesRaised] <= LTRIM(RTRIM(@IssuesRaised))) " 
                + "AND   (@AverageTimePerIssue IS NULL OR @AverageTimePerIssue = '' OR [FactCallCenter].[AverageTimePerIssue] <= LTRIM(RTRIM(@AverageTimePerIssue))) " 
                + "AND   (@ServiceGrade IS NULL OR @ServiceGrade = '' OR [FactCallCenter].[ServiceGrade] <= LTRIM(RTRIM(@ServiceGrade))) " 
                + "AND   (@Date IS NULL OR @Date = '' OR [FactCallCenter].[Date] <= LTRIM(RTRIM(@Date))) " 
                + "";
        }
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        selectCommand.CommandType = CommandType.Text;
        if (sField == "Fact Call Center I D") {
            selectCommand.Parameters.AddWithValue("@FactCallCenterID", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@FactCallCenterID", DBNull.Value); }
        if (sField == "Date Key") {
            selectCommand.Parameters.AddWithValue("@FullDateAlternateKey", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@FullDateAlternateKey", DBNull.Value); }
        if (sField == "Wage Type") {
            selectCommand.Parameters.AddWithValue("@WageType", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@WageType", DBNull.Value); }
        if (sField == "Shift") {
            selectCommand.Parameters.AddWithValue("@Shift", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@Shift", DBNull.Value); }
        if (sField == "Level One Operators") {
            selectCommand.Parameters.AddWithValue("@LevelOneOperators", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@LevelOneOperators", DBNull.Value); }
        if (sField == "Level Two Operators") {
            selectCommand.Parameters.AddWithValue("@LevelTwoOperators", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@LevelTwoOperators", DBNull.Value); }
        if (sField == "Total Operators") {
            selectCommand.Parameters.AddWithValue("@TotalOperators", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@TotalOperators", DBNull.Value); }
        if (sField == "Calls") {
            selectCommand.Parameters.AddWithValue("@Calls", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@Calls", DBNull.Value); }
        if (sField == "Automatic Responses") {
            selectCommand.Parameters.AddWithValue("@AutomaticResponses", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@AutomaticResponses", DBNull.Value); }
        if (sField == "Orders") {
            selectCommand.Parameters.AddWithValue("@Orders", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@Orders", DBNull.Value); }
        if (sField == "Issues Raised") {
            selectCommand.Parameters.AddWithValue("@IssuesRaised", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@IssuesRaised", DBNull.Value); }
        if (sField == "Average Time Per Issue") {
            selectCommand.Parameters.AddWithValue("@AverageTimePerIssue", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@AverageTimePerIssue", DBNull.Value); }
        if (sField == "Service Grade") {
            selectCommand.Parameters.AddWithValue("@ServiceGrade", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@ServiceGrade", DBNull.Value); }
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

    public static dbo_FactCallCenterClass Select_Record(dbo_FactCallCenterClass clsdbo_FactCallCenterPara)
    {
        dbo_FactCallCenterClass clsdbo_FactCallCenter = new dbo_FactCallCenterClass();
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement
            = "SELECT " 
            + "     [FactCallCenterID] "
            + "    ,[DateKey] "
            + "    ,[WageType] "
            + "    ,[Shift] "
            + "    ,[LevelOneOperators] "
            + "    ,[LevelTwoOperators] "
            + "    ,[TotalOperators] "
            + "    ,[Calls] "
            + "    ,[AutomaticResponses] "
            + "    ,[Orders] "
            + "    ,[IssuesRaised] "
            + "    ,[AverageTimePerIssue] "
            + "    ,[ServiceGrade] "
            + "    ,[Date] "
            + "FROM "
            + "     [dbo].[FactCallCenter] "
            + "WHERE "
            + "     [FactCallCenterID] = @FactCallCenterID "
            + "";
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        selectCommand.CommandType = CommandType.Text;
        selectCommand.Parameters.AddWithValue("@FactCallCenterID", clsdbo_FactCallCenterPara.FactCallCenterID);
        try
        {
            connection.Open();
            SqlDataReader reader
                = selectCommand.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                clsdbo_FactCallCenter.FactCallCenterID = System.Convert.ToInt32(reader["FactCallCenterID"]);
                clsdbo_FactCallCenter.DateKey = System.Convert.ToInt32(reader["DateKey"]);
                clsdbo_FactCallCenter.WageType = System.Convert.ToString(reader["WageType"]);
                clsdbo_FactCallCenter.Shift = System.Convert.ToString(reader["Shift"]);
                clsdbo_FactCallCenter.LevelOneOperators = System.Convert.ToInt16(reader["LevelOneOperators"]);
                clsdbo_FactCallCenter.LevelTwoOperators = System.Convert.ToInt16(reader["LevelTwoOperators"]);
                clsdbo_FactCallCenter.TotalOperators = System.Convert.ToInt16(reader["TotalOperators"]);
                clsdbo_FactCallCenter.Calls = System.Convert.ToInt32(reader["Calls"]);
                clsdbo_FactCallCenter.AutomaticResponses = System.Convert.ToInt32(reader["AutomaticResponses"]);
                clsdbo_FactCallCenter.Orders = System.Convert.ToInt32(reader["Orders"]);
                clsdbo_FactCallCenter.IssuesRaised = System.Convert.ToInt16(reader["IssuesRaised"]);
                clsdbo_FactCallCenter.AverageTimePerIssue = System.Convert.ToInt16(reader["AverageTimePerIssue"]);
                clsdbo_FactCallCenter.ServiceGrade = System.Convert.ToDecimal(reader["ServiceGrade"]);
                clsdbo_FactCallCenter.Date = reader["Date"] is DBNull ? null : (DateTime?)reader["Date"];
            }
            else
            {
                clsdbo_FactCallCenter = null;
            }
            reader.Close();
        }
        catch (SqlException)
        {
            return clsdbo_FactCallCenter;
        }
        finally
        {
            connection.Close();
        }
        return clsdbo_FactCallCenter;
    }

    public static bool Add(dbo_FactCallCenterClass clsdbo_FactCallCenter)
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string insertStatement
            = "INSERT " 
            + "     [dbo].[FactCallCenter] "
            + "     ( "
            + "     [DateKey] "
            + "    ,[WageType] "
            + "    ,[Shift] "
            + "    ,[LevelOneOperators] "
            + "    ,[LevelTwoOperators] "
            + "    ,[TotalOperators] "
            + "    ,[Calls] "
            + "    ,[AutomaticResponses] "
            + "    ,[Orders] "
            + "    ,[IssuesRaised] "
            + "    ,[AverageTimePerIssue] "
            + "    ,[ServiceGrade] "
            + "    ,[Date] "
            + "     ) "
            + "VALUES " 
            + "     ( "
            + "     @DateKey "
            + "    ,@WageType "
            + "    ,@Shift "
            + "    ,@LevelOneOperators "
            + "    ,@LevelTwoOperators "
            + "    ,@TotalOperators "
            + "    ,@Calls "
            + "    ,@AutomaticResponses "
            + "    ,@Orders "
            + "    ,@IssuesRaised "
            + "    ,@AverageTimePerIssue "
            + "    ,@ServiceGrade "
            + "    ,@Date "
            + "     ) "
            + "";
        SqlCommand insertCommand = new SqlCommand(insertStatement, connection);
        insertCommand.CommandType = CommandType.Text;
        insertCommand.Parameters.AddWithValue("@DateKey", clsdbo_FactCallCenter.DateKey);
        insertCommand.Parameters.AddWithValue("@WageType", clsdbo_FactCallCenter.WageType);
        insertCommand.Parameters.AddWithValue("@Shift", clsdbo_FactCallCenter.Shift);
        insertCommand.Parameters.AddWithValue("@LevelOneOperators", clsdbo_FactCallCenter.LevelOneOperators);
        insertCommand.Parameters.AddWithValue("@LevelTwoOperators", clsdbo_FactCallCenter.LevelTwoOperators);
        insertCommand.Parameters.AddWithValue("@TotalOperators", clsdbo_FactCallCenter.TotalOperators);
        insertCommand.Parameters.AddWithValue("@Calls", clsdbo_FactCallCenter.Calls);
        insertCommand.Parameters.AddWithValue("@AutomaticResponses", clsdbo_FactCallCenter.AutomaticResponses);
        insertCommand.Parameters.AddWithValue("@Orders", clsdbo_FactCallCenter.Orders);
        insertCommand.Parameters.AddWithValue("@IssuesRaised", clsdbo_FactCallCenter.IssuesRaised);
        insertCommand.Parameters.AddWithValue("@AverageTimePerIssue", clsdbo_FactCallCenter.AverageTimePerIssue);
        insertCommand.Parameters.AddWithValue("@ServiceGrade", clsdbo_FactCallCenter.ServiceGrade);
        if (clsdbo_FactCallCenter.Date.HasValue == true) {
            insertCommand.Parameters.AddWithValue("@Date", clsdbo_FactCallCenter.Date);
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

    public static bool Update(dbo_FactCallCenterClass olddbo_FactCallCenterClass, 
           dbo_FactCallCenterClass newdbo_FactCallCenterClass)
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string updateStatement
            = "UPDATE "  
            + "     [dbo].[FactCallCenter] "
            + "SET "
            + "     [DateKey] = @NewDateKey "
            + "    ,[WageType] = @NewWageType "
            + "    ,[Shift] = @NewShift "
            + "    ,[LevelOneOperators] = @NewLevelOneOperators "
            + "    ,[LevelTwoOperators] = @NewLevelTwoOperators "
            + "    ,[TotalOperators] = @NewTotalOperators "
            + "    ,[Calls] = @NewCalls "
            + "    ,[AutomaticResponses] = @NewAutomaticResponses "
            + "    ,[Orders] = @NewOrders "
            + "    ,[IssuesRaised] = @NewIssuesRaised "
            + "    ,[AverageTimePerIssue] = @NewAverageTimePerIssue "
            + "    ,[ServiceGrade] = @NewServiceGrade "
            + "    ,[Date] = @NewDate "
            + "WHERE "
            + "     [FactCallCenterID] = @OldFactCallCenterID " 
            + " AND [DateKey] = @OldDateKey " 
            + " AND [WageType] = @OldWageType " 
            + " AND [Shift] = @OldShift " 
            + " AND [LevelOneOperators] = @OldLevelOneOperators " 
            + " AND [LevelTwoOperators] = @OldLevelTwoOperators " 
            + " AND [TotalOperators] = @OldTotalOperators " 
            + " AND [Calls] = @OldCalls " 
            + " AND [AutomaticResponses] = @OldAutomaticResponses " 
            + " AND [Orders] = @OldOrders " 
            + " AND [IssuesRaised] = @OldIssuesRaised " 
            + " AND [AverageTimePerIssue] = @OldAverageTimePerIssue " 
            + " AND [ServiceGrade] = @OldServiceGrade " 
            + " AND ((@OldDate IS NULL AND [Date] IS NULL) OR [Date] = @OldDate) " 
            + "";
        SqlCommand updateCommand = new SqlCommand(updateStatement, connection);
        updateCommand.CommandType = CommandType.Text;
        updateCommand.Parameters.AddWithValue("@NewDateKey", newdbo_FactCallCenterClass.DateKey);
        updateCommand.Parameters.AddWithValue("@NewWageType", newdbo_FactCallCenterClass.WageType);
        updateCommand.Parameters.AddWithValue("@NewShift", newdbo_FactCallCenterClass.Shift);
        updateCommand.Parameters.AddWithValue("@NewLevelOneOperators", newdbo_FactCallCenterClass.LevelOneOperators);
        updateCommand.Parameters.AddWithValue("@NewLevelTwoOperators", newdbo_FactCallCenterClass.LevelTwoOperators);
        updateCommand.Parameters.AddWithValue("@NewTotalOperators", newdbo_FactCallCenterClass.TotalOperators);
        updateCommand.Parameters.AddWithValue("@NewCalls", newdbo_FactCallCenterClass.Calls);
        updateCommand.Parameters.AddWithValue("@NewAutomaticResponses", newdbo_FactCallCenterClass.AutomaticResponses);
        updateCommand.Parameters.AddWithValue("@NewOrders", newdbo_FactCallCenterClass.Orders);
        updateCommand.Parameters.AddWithValue("@NewIssuesRaised", newdbo_FactCallCenterClass.IssuesRaised);
        updateCommand.Parameters.AddWithValue("@NewAverageTimePerIssue", newdbo_FactCallCenterClass.AverageTimePerIssue);
        updateCommand.Parameters.AddWithValue("@NewServiceGrade", newdbo_FactCallCenterClass.ServiceGrade);
        if (newdbo_FactCallCenterClass.Date.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@NewDate", newdbo_FactCallCenterClass.Date);
        } else {
            updateCommand.Parameters.AddWithValue("@NewDate", DBNull.Value); }
        updateCommand.Parameters.AddWithValue("@OldFactCallCenterID", olddbo_FactCallCenterClass.FactCallCenterID);
        updateCommand.Parameters.AddWithValue("@OldDateKey", olddbo_FactCallCenterClass.DateKey);
        updateCommand.Parameters.AddWithValue("@OldWageType", olddbo_FactCallCenterClass.WageType);
        updateCommand.Parameters.AddWithValue("@OldShift", olddbo_FactCallCenterClass.Shift);
        updateCommand.Parameters.AddWithValue("@OldLevelOneOperators", olddbo_FactCallCenterClass.LevelOneOperators);
        updateCommand.Parameters.AddWithValue("@OldLevelTwoOperators", olddbo_FactCallCenterClass.LevelTwoOperators);
        updateCommand.Parameters.AddWithValue("@OldTotalOperators", olddbo_FactCallCenterClass.TotalOperators);
        updateCommand.Parameters.AddWithValue("@OldCalls", olddbo_FactCallCenterClass.Calls);
        updateCommand.Parameters.AddWithValue("@OldAutomaticResponses", olddbo_FactCallCenterClass.AutomaticResponses);
        updateCommand.Parameters.AddWithValue("@OldOrders", olddbo_FactCallCenterClass.Orders);
        updateCommand.Parameters.AddWithValue("@OldIssuesRaised", olddbo_FactCallCenterClass.IssuesRaised);
        updateCommand.Parameters.AddWithValue("@OldAverageTimePerIssue", olddbo_FactCallCenterClass.AverageTimePerIssue);
        updateCommand.Parameters.AddWithValue("@OldServiceGrade", olddbo_FactCallCenterClass.ServiceGrade);
        if (olddbo_FactCallCenterClass.Date.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@OldDate", olddbo_FactCallCenterClass.Date);
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

    public static bool Delete(dbo_FactCallCenterClass clsdbo_FactCallCenter)
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string deleteStatement
            = "DELETE FROM "  
            + "     [dbo].[FactCallCenter] "
            + "WHERE " 
            + "     [FactCallCenterID] = @OldFactCallCenterID " 
            + " AND [DateKey] = @OldDateKey " 
            + " AND [WageType] = @OldWageType " 
            + " AND [Shift] = @OldShift " 
            + " AND [LevelOneOperators] = @OldLevelOneOperators " 
            + " AND [LevelTwoOperators] = @OldLevelTwoOperators " 
            + " AND [TotalOperators] = @OldTotalOperators " 
            + " AND [Calls] = @OldCalls " 
            + " AND [AutomaticResponses] = @OldAutomaticResponses " 
            + " AND [Orders] = @OldOrders " 
            + " AND [IssuesRaised] = @OldIssuesRaised " 
            + " AND [AverageTimePerIssue] = @OldAverageTimePerIssue " 
            + " AND [ServiceGrade] = @OldServiceGrade " 
            + " AND ((@OldDate IS NULL AND [Date] IS NULL) OR [Date] = @OldDate) " 
            + "";
        SqlCommand deleteCommand = new SqlCommand(deleteStatement, connection);
        deleteCommand.CommandType = CommandType.Text;
        deleteCommand.Parameters.AddWithValue("@OldFactCallCenterID", clsdbo_FactCallCenter.FactCallCenterID);
        deleteCommand.Parameters.AddWithValue("@OldDateKey", clsdbo_FactCallCenter.DateKey);
        deleteCommand.Parameters.AddWithValue("@OldWageType", clsdbo_FactCallCenter.WageType);
        deleteCommand.Parameters.AddWithValue("@OldShift", clsdbo_FactCallCenter.Shift);
        deleteCommand.Parameters.AddWithValue("@OldLevelOneOperators", clsdbo_FactCallCenter.LevelOneOperators);
        deleteCommand.Parameters.AddWithValue("@OldLevelTwoOperators", clsdbo_FactCallCenter.LevelTwoOperators);
        deleteCommand.Parameters.AddWithValue("@OldTotalOperators", clsdbo_FactCallCenter.TotalOperators);
        deleteCommand.Parameters.AddWithValue("@OldCalls", clsdbo_FactCallCenter.Calls);
        deleteCommand.Parameters.AddWithValue("@OldAutomaticResponses", clsdbo_FactCallCenter.AutomaticResponses);
        deleteCommand.Parameters.AddWithValue("@OldOrders", clsdbo_FactCallCenter.Orders);
        deleteCommand.Parameters.AddWithValue("@OldIssuesRaised", clsdbo_FactCallCenter.IssuesRaised);
        deleteCommand.Parameters.AddWithValue("@OldAverageTimePerIssue", clsdbo_FactCallCenter.AverageTimePerIssue);
        deleteCommand.Parameters.AddWithValue("@OldServiceGrade", clsdbo_FactCallCenter.ServiceGrade);
        if (clsdbo_FactCallCenter.Date.HasValue == true) {
            deleteCommand.Parameters.AddWithValue("@OldDate", clsdbo_FactCallCenter.Date);
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

 
