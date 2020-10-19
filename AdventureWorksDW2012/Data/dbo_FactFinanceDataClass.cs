using System;
using System.Data;
using System.Data.SqlClient;

public class dbo_FactFinanceDataClass
{

    public static DataTable SelectAll()
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement
            = "SELECT "  
            + "     [dbo].[FactFinance].[FinanceKey] "
            + "    ,[A229].[DateKey] "
            + "    ,[A230].[OrganizationName] "
            + "    ,[A231].[DepartmentGroupName] "
            + "    ,[A232].[ScenarioName] "
            + "    ,[A233].[ParentAccountKey] "
            + "    ,[dbo].[FactFinance].[Amount] "
            + "    ,[dbo].[FactFinance].[Date] "
            + "FROM " 
            + "     [dbo].[FactFinance] " 
            + "INNER JOIN [dbo].[DimDate] as [A229] ON [dbo].[FactFinance].[DateKey] = [A229].[DateKey] "
            + "INNER JOIN [dbo].[DimOrganization] as [A230] ON [dbo].[FactFinance].[OrganizationKey] = [A230].[OrganizationKey] "
            + "INNER JOIN [dbo].[DimDepartmentGroup] as [A231] ON [dbo].[FactFinance].[DepartmentGroupKey] = [A231].[DepartmentGroupKey] "
            + "INNER JOIN [dbo].[DimScenario] as [A232] ON [dbo].[FactFinance].[ScenarioKey] = [A232].[ScenarioKey] "
            + "INNER JOIN [dbo].[DimAccount] as [A233] ON [dbo].[FactFinance].[AccountKey] = [A233].[AccountKey] "
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
            + "     [dbo].[FactFinance].[FinanceKey] "
            + "    ,[A229].[DateKey]"
            + "    ,[A230].[OrganizationName]"
            + "    ,[A231].[DepartmentGroupName]"
            + "    ,[A232].[ScenarioName]"
            + "    ,[A233].[ParentAccountKey]"
            + "    ,[dbo].[FactFinance].[Amount] "
            + "    ,[dbo].[FactFinance].[Date] "
            + "FROM " 
            + "     [dbo].[FactFinance] " 
            + "INNER JOIN [dbo].[DimDate] as [A229] ON [dbo].[FactFinance].[DateKey] = [A229].[DateKey] "
            + "INNER JOIN [dbo].[DimOrganization] as [A230] ON [dbo].[FactFinance].[OrganizationKey] = [A230].[OrganizationKey] "
            + "INNER JOIN [dbo].[DimDepartmentGroup] as [A231] ON [dbo].[FactFinance].[DepartmentGroupKey] = [A231].[DepartmentGroupKey] "
            + "INNER JOIN [dbo].[DimScenario] as [A232] ON [dbo].[FactFinance].[ScenarioKey] = [A232].[ScenarioKey] "
            + "INNER JOIN [dbo].[DimAccount] as [A233] ON [dbo].[FactFinance].[AccountKey] = [A233].[AccountKey] "
                + "WHERE " 
                + "     (@FinanceKey IS NULL OR @FinanceKey = '' OR [FactFinance].[FinanceKey] LIKE '%' + LTRIM(RTRIM(@FinanceKey)) + '%') " 
                + "AND   (@DateKey229 IS NULL OR @DateKey229 = '' OR [A229].[DateKey] LIKE '%' + LTRIM(RTRIM(@DateKey229)) + '%') " 
                + "AND   (@OrganizationName230 IS NULL OR @OrganizationName230 = '' OR [A230].[OrganizationName] LIKE '%' + LTRIM(RTRIM(@OrganizationName230)) + '%') " 
                + "AND   (@DepartmentGroupName231 IS NULL OR @DepartmentGroupName231 = '' OR [A231].[DepartmentGroupName] LIKE '%' + LTRIM(RTRIM(@DepartmentGroupName231)) + '%') " 
                + "AND   (@ScenarioName232 IS NULL OR @ScenarioName232 = '' OR [A232].[ScenarioName] LIKE '%' + LTRIM(RTRIM(@ScenarioName232)) + '%') " 
                + "AND   (@ParentAccountKey233 IS NULL OR @ParentAccountKey233 = '' OR [A233].[ParentAccountKey] LIKE '%' + LTRIM(RTRIM(@ParentAccountKey233)) + '%') " 
                + "AND   (@Amount IS NULL OR @Amount = '' OR [FactFinance].[Amount] LIKE '%' + LTRIM(RTRIM(@Amount)) + '%') " 
                + "AND   (@Date IS NULL OR @Date = '' OR [FactFinance].[Date] LIKE '%' + LTRIM(RTRIM(@Date)) + '%') " 
                + "";
        } else if (sCondition == "Equals") {
            selectStatement
                = "SELECT "
            + "     [dbo].[FactFinance].[FinanceKey] "
            + "    ,[A229].[DateKey]"
            + "    ,[A230].[OrganizationName]"
            + "    ,[A231].[DepartmentGroupName]"
            + "    ,[A232].[ScenarioName]"
            + "    ,[A233].[ParentAccountKey]"
            + "    ,[dbo].[FactFinance].[Amount] "
            + "    ,[dbo].[FactFinance].[Date] "
            + "FROM " 
            + "     [dbo].[FactFinance] " 
            + "INNER JOIN [dbo].[DimDate] as [A229] ON [dbo].[FactFinance].[DateKey] = [A229].[DateKey] "
            + "INNER JOIN [dbo].[DimOrganization] as [A230] ON [dbo].[FactFinance].[OrganizationKey] = [A230].[OrganizationKey] "
            + "INNER JOIN [dbo].[DimDepartmentGroup] as [A231] ON [dbo].[FactFinance].[DepartmentGroupKey] = [A231].[DepartmentGroupKey] "
            + "INNER JOIN [dbo].[DimScenario] as [A232] ON [dbo].[FactFinance].[ScenarioKey] = [A232].[ScenarioKey] "
            + "INNER JOIN [dbo].[DimAccount] as [A233] ON [dbo].[FactFinance].[AccountKey] = [A233].[AccountKey] "
                + "WHERE " 
                + "     (@FinanceKey IS NULL OR @FinanceKey = '' OR [FactFinance].[FinanceKey] = LTRIM(RTRIM(@FinanceKey))) " 
                + "AND   (@DateKey229 IS NULL OR @DateKey229 = '' OR [A229].[DateKey] = LTRIM(RTRIM(@DateKey229))) " 
                + "AND   (@OrganizationName230 IS NULL OR @OrganizationName230 = '' OR [A230].[OrganizationName] = LTRIM(RTRIM(@OrganizationName230))) " 
                + "AND   (@DepartmentGroupName231 IS NULL OR @DepartmentGroupName231 = '' OR [A231].[DepartmentGroupName] = LTRIM(RTRIM(@DepartmentGroupName231))) " 
                + "AND   (@ScenarioName232 IS NULL OR @ScenarioName232 = '' OR [A232].[ScenarioName] = LTRIM(RTRIM(@ScenarioName232))) " 
                + "AND   (@ParentAccountKey233 IS NULL OR @ParentAccountKey233 = '' OR [A233].[ParentAccountKey] = LTRIM(RTRIM(@ParentAccountKey233))) " 
                + "AND   (@Amount IS NULL OR @Amount = '' OR [FactFinance].[Amount] = LTRIM(RTRIM(@Amount))) " 
                + "AND   (@Date IS NULL OR @Date = '' OR [FactFinance].[Date] = LTRIM(RTRIM(@Date))) " 
                + "";
        } else if  (sCondition == "Starts with...") {
            selectStatement
                = "SELECT "
            + "     [dbo].[FactFinance].[FinanceKey] "
            + "    ,[A229].[DateKey]"
            + "    ,[A230].[OrganizationName]"
            + "    ,[A231].[DepartmentGroupName]"
            + "    ,[A232].[ScenarioName]"
            + "    ,[A233].[ParentAccountKey]"
            + "    ,[dbo].[FactFinance].[Amount] "
            + "    ,[dbo].[FactFinance].[Date] "
            + "FROM " 
            + "     [dbo].[FactFinance] " 
            + "INNER JOIN [dbo].[DimDate] as [A229] ON [dbo].[FactFinance].[DateKey] = [A229].[DateKey] "
            + "INNER JOIN [dbo].[DimOrganization] as [A230] ON [dbo].[FactFinance].[OrganizationKey] = [A230].[OrganizationKey] "
            + "INNER JOIN [dbo].[DimDepartmentGroup] as [A231] ON [dbo].[FactFinance].[DepartmentGroupKey] = [A231].[DepartmentGroupKey] "
            + "INNER JOIN [dbo].[DimScenario] as [A232] ON [dbo].[FactFinance].[ScenarioKey] = [A232].[ScenarioKey] "
            + "INNER JOIN [dbo].[DimAccount] as [A233] ON [dbo].[FactFinance].[AccountKey] = [A233].[AccountKey] "
                + "WHERE " 
                + "     (@FinanceKey IS NULL OR @FinanceKey = '' OR [FactFinance].[FinanceKey] LIKE LTRIM(RTRIM(@FinanceKey)) + '%') " 
                + "AND   (@DateKey229 IS NULL OR @DateKey229 = '' OR [A229].[DateKey] LIKE LTRIM(RTRIM(@DateKey229)) + '%') " 
                + "AND   (@OrganizationName230 IS NULL OR @OrganizationName230 = '' OR [A230].[OrganizationName] LIKE LTRIM(RTRIM(@OrganizationName230)) + '%') " 
                + "AND   (@DepartmentGroupName231 IS NULL OR @DepartmentGroupName231 = '' OR [A231].[DepartmentGroupName] LIKE LTRIM(RTRIM(@DepartmentGroupName231)) + '%') " 
                + "AND   (@ScenarioName232 IS NULL OR @ScenarioName232 = '' OR [A232].[ScenarioName] LIKE LTRIM(RTRIM(@ScenarioName232)) + '%') " 
                + "AND   (@ParentAccountKey233 IS NULL OR @ParentAccountKey233 = '' OR [A233].[ParentAccountKey] LIKE LTRIM(RTRIM(@ParentAccountKey233)) + '%') " 
                + "AND   (@Amount IS NULL OR @Amount = '' OR [FactFinance].[Amount] LIKE LTRIM(RTRIM(@Amount)) + '%') " 
                + "AND   (@Date IS NULL OR @Date = '' OR [FactFinance].[Date] LIKE LTRIM(RTRIM(@Date)) + '%') " 
                + "";
        } else if  (sCondition == "More than...") {
            selectStatement
                = "SELECT "
            + "     [dbo].[FactFinance].[FinanceKey] "
            + "    ,[A229].[DateKey]"
            + "    ,[A230].[OrganizationName]"
            + "    ,[A231].[DepartmentGroupName]"
            + "    ,[A232].[ScenarioName]"
            + "    ,[A233].[ParentAccountKey]"
            + "    ,[dbo].[FactFinance].[Amount] "
            + "    ,[dbo].[FactFinance].[Date] "
            + "FROM " 
            + "     [dbo].[FactFinance] " 
            + "INNER JOIN [dbo].[DimDate] as [A229] ON [dbo].[FactFinance].[DateKey] = [A229].[DateKey] "
            + "INNER JOIN [dbo].[DimOrganization] as [A230] ON [dbo].[FactFinance].[OrganizationKey] = [A230].[OrganizationKey] "
            + "INNER JOIN [dbo].[DimDepartmentGroup] as [A231] ON [dbo].[FactFinance].[DepartmentGroupKey] = [A231].[DepartmentGroupKey] "
            + "INNER JOIN [dbo].[DimScenario] as [A232] ON [dbo].[FactFinance].[ScenarioKey] = [A232].[ScenarioKey] "
            + "INNER JOIN [dbo].[DimAccount] as [A233] ON [dbo].[FactFinance].[AccountKey] = [A233].[AccountKey] "
                + "WHERE " 
                + "     (@FinanceKey IS NULL OR @FinanceKey = '' OR [FactFinance].[FinanceKey] > LTRIM(RTRIM(@FinanceKey))) " 
                + "AND   (@DateKey229 IS NULL OR @DateKey229 = '' OR [A229].[DateKey] > LTRIM(RTRIM(@DateKey229))) " 
                + "AND   (@OrganizationName230 IS NULL OR @OrganizationName230 = '' OR [A230].[OrganizationName] > LTRIM(RTRIM(@OrganizationName230))) " 
                + "AND   (@DepartmentGroupName231 IS NULL OR @DepartmentGroupName231 = '' OR [A231].[DepartmentGroupName] > LTRIM(RTRIM(@DepartmentGroupName231))) " 
                + "AND   (@ScenarioName232 IS NULL OR @ScenarioName232 = '' OR [A232].[ScenarioName] > LTRIM(RTRIM(@ScenarioName232))) " 
                + "AND   (@ParentAccountKey233 IS NULL OR @ParentAccountKey233 = '' OR [A233].[ParentAccountKey] > LTRIM(RTRIM(@ParentAccountKey233))) " 
                + "AND   (@Amount IS NULL OR @Amount = '' OR [FactFinance].[Amount] > LTRIM(RTRIM(@Amount))) " 
                + "AND   (@Date IS NULL OR @Date = '' OR [FactFinance].[Date] > LTRIM(RTRIM(@Date))) " 
                + "";
        } else if  (sCondition == "Less than...") {
            selectStatement
                = "SELECT " 
            + "     [dbo].[FactFinance].[FinanceKey] "
            + "    ,[A229].[DateKey]"
            + "    ,[A230].[OrganizationName]"
            + "    ,[A231].[DepartmentGroupName]"
            + "    ,[A232].[ScenarioName]"
            + "    ,[A233].[ParentAccountKey]"
            + "    ,[dbo].[FactFinance].[Amount] "
            + "    ,[dbo].[FactFinance].[Date] "
            + "FROM " 
            + "     [dbo].[FactFinance] " 
            + "INNER JOIN [dbo].[DimDate] as [A229] ON [dbo].[FactFinance].[DateKey] = [A229].[DateKey] "
            + "INNER JOIN [dbo].[DimOrganization] as [A230] ON [dbo].[FactFinance].[OrganizationKey] = [A230].[OrganizationKey] "
            + "INNER JOIN [dbo].[DimDepartmentGroup] as [A231] ON [dbo].[FactFinance].[DepartmentGroupKey] = [A231].[DepartmentGroupKey] "
            + "INNER JOIN [dbo].[DimScenario] as [A232] ON [dbo].[FactFinance].[ScenarioKey] = [A232].[ScenarioKey] "
            + "INNER JOIN [dbo].[DimAccount] as [A233] ON [dbo].[FactFinance].[AccountKey] = [A233].[AccountKey] "
                + "WHERE " 
                + "     (@FinanceKey IS NULL OR @FinanceKey = '' OR [FactFinance].[FinanceKey] < LTRIM(RTRIM(@FinanceKey))) " 
                + "AND   (@DateKey229 IS NULL OR @DateKey229 = '' OR [A229].[DateKey] < LTRIM(RTRIM(@DateKey229))) " 
                + "AND   (@OrganizationName230 IS NULL OR @OrganizationName230 = '' OR [A230].[OrganizationName] < LTRIM(RTRIM(@OrganizationName230))) " 
                + "AND   (@DepartmentGroupName231 IS NULL OR @DepartmentGroupName231 = '' OR [A231].[DepartmentGroupName] < LTRIM(RTRIM(@DepartmentGroupName231))) " 
                + "AND   (@ScenarioName232 IS NULL OR @ScenarioName232 = '' OR [A232].[ScenarioName] < LTRIM(RTRIM(@ScenarioName232))) " 
                + "AND   (@ParentAccountKey233 IS NULL OR @ParentAccountKey233 = '' OR [A233].[ParentAccountKey] < LTRIM(RTRIM(@ParentAccountKey233))) " 
                + "AND   (@Amount IS NULL OR @Amount = '' OR [FactFinance].[Amount] < LTRIM(RTRIM(@Amount))) " 
                + "AND   (@Date IS NULL OR @Date = '' OR [FactFinance].[Date] < LTRIM(RTRIM(@Date))) " 
                + "";
        } else if  (sCondition == "Equal or more than...") {
            selectStatement
                = "SELECT "
            + "     [dbo].[FactFinance].[FinanceKey] "
            + "    ,[A229].[DateKey]"
            + "    ,[A230].[OrganizationName]"
            + "    ,[A231].[DepartmentGroupName]"
            + "    ,[A232].[ScenarioName]"
            + "    ,[A233].[ParentAccountKey]"
            + "    ,[dbo].[FactFinance].[Amount] "
            + "    ,[dbo].[FactFinance].[Date] "
            + "FROM " 
            + "     [dbo].[FactFinance] " 
            + "INNER JOIN [dbo].[DimDate] as [A229] ON [dbo].[FactFinance].[DateKey] = [A229].[DateKey] "
            + "INNER JOIN [dbo].[DimOrganization] as [A230] ON [dbo].[FactFinance].[OrganizationKey] = [A230].[OrganizationKey] "
            + "INNER JOIN [dbo].[DimDepartmentGroup] as [A231] ON [dbo].[FactFinance].[DepartmentGroupKey] = [A231].[DepartmentGroupKey] "
            + "INNER JOIN [dbo].[DimScenario] as [A232] ON [dbo].[FactFinance].[ScenarioKey] = [A232].[ScenarioKey] "
            + "INNER JOIN [dbo].[DimAccount] as [A233] ON [dbo].[FactFinance].[AccountKey] = [A233].[AccountKey] "
                + "WHERE " 
                + "     (@FinanceKey IS NULL OR @FinanceKey = '' OR [FactFinance].[FinanceKey] >= LTRIM(RTRIM(@FinanceKey))) " 
                + "AND   (@DateKey229 IS NULL OR @DateKey229 = '' OR [A229].[DateKey] >= LTRIM(RTRIM(@DateKey229))) " 
                + "AND   (@OrganizationName230 IS NULL OR @OrganizationName230 = '' OR [A230].[OrganizationName] >= LTRIM(RTRIM(@OrganizationName230))) " 
                + "AND   (@DepartmentGroupName231 IS NULL OR @DepartmentGroupName231 = '' OR [A231].[DepartmentGroupName] >= LTRIM(RTRIM(@DepartmentGroupName231))) " 
                + "AND   (@ScenarioName232 IS NULL OR @ScenarioName232 = '' OR [A232].[ScenarioName] >= LTRIM(RTRIM(@ScenarioName232))) " 
                + "AND   (@ParentAccountKey233 IS NULL OR @ParentAccountKey233 = '' OR [A233].[ParentAccountKey] >= LTRIM(RTRIM(@ParentAccountKey233))) " 
                + "AND   (@Amount IS NULL OR @Amount = '' OR [FactFinance].[Amount] >= LTRIM(RTRIM(@Amount))) " 
                + "AND   (@Date IS NULL OR @Date = '' OR [FactFinance].[Date] >= LTRIM(RTRIM(@Date))) " 
                + "";
        } else if (sCondition == "Equal or less than...") {
            selectStatement 
                = "SELECT "
            + "     [dbo].[FactFinance].[FinanceKey] "
            + "    ,[A229].[DateKey]"
            + "    ,[A230].[OrganizationName]"
            + "    ,[A231].[DepartmentGroupName]"
            + "    ,[A232].[ScenarioName]"
            + "    ,[A233].[ParentAccountKey]"
            + "    ,[dbo].[FactFinance].[Amount] "
            + "    ,[dbo].[FactFinance].[Date] "
            + "FROM " 
            + "     [dbo].[FactFinance] " 
            + "INNER JOIN [dbo].[DimDate] as [A229] ON [dbo].[FactFinance].[DateKey] = [A229].[DateKey] "
            + "INNER JOIN [dbo].[DimOrganization] as [A230] ON [dbo].[FactFinance].[OrganizationKey] = [A230].[OrganizationKey] "
            + "INNER JOIN [dbo].[DimDepartmentGroup] as [A231] ON [dbo].[FactFinance].[DepartmentGroupKey] = [A231].[DepartmentGroupKey] "
            + "INNER JOIN [dbo].[DimScenario] as [A232] ON [dbo].[FactFinance].[ScenarioKey] = [A232].[ScenarioKey] "
            + "INNER JOIN [dbo].[DimAccount] as [A233] ON [dbo].[FactFinance].[AccountKey] = [A233].[AccountKey] "
                + "WHERE " 
                + "     (@FinanceKey IS NULL OR @FinanceKey = '' OR [FactFinance].[FinanceKey] <= LTRIM(RTRIM(@FinanceKey))) " 
                + "AND   (@DateKey229 IS NULL OR @DateKey229 = '' OR [A229].[DateKey] <= LTRIM(RTRIM(@DateKey229))) " 
                + "AND   (@OrganizationName230 IS NULL OR @OrganizationName230 = '' OR [A230].[OrganizationName] <= LTRIM(RTRIM(@OrganizationName230))) " 
                + "AND   (@DepartmentGroupName231 IS NULL OR @DepartmentGroupName231 = '' OR [A231].[DepartmentGroupName] <= LTRIM(RTRIM(@DepartmentGroupName231))) " 
                + "AND   (@ScenarioName232 IS NULL OR @ScenarioName232 = '' OR [A232].[ScenarioName] <= LTRIM(RTRIM(@ScenarioName232))) " 
                + "AND   (@ParentAccountKey233 IS NULL OR @ParentAccountKey233 = '' OR [A233].[ParentAccountKey] <= LTRIM(RTRIM(@ParentAccountKey233))) " 
                + "AND   (@Amount IS NULL OR @Amount = '' OR [FactFinance].[Amount] <= LTRIM(RTRIM(@Amount))) " 
                + "AND   (@Date IS NULL OR @Date = '' OR [FactFinance].[Date] <= LTRIM(RTRIM(@Date))) " 
                + "";
        }
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        selectCommand.CommandType = CommandType.Text;
        if (sField == "Finance Key") {
            selectCommand.Parameters.AddWithValue("@FinanceKey", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@FinanceKey", DBNull.Value); }
        if (sField == "Date Key") {
            selectCommand.Parameters.AddWithValue("@DateKey229", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@DateKey229", DBNull.Value); }
        if (sField == "Organization Key") {
            selectCommand.Parameters.AddWithValue("@OrganizationName230", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@OrganizationName230", DBNull.Value); }
        if (sField == "Department Group Key") {
            selectCommand.Parameters.AddWithValue("@DepartmentGroupName231", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@DepartmentGroupName231", DBNull.Value); }
        if (sField == "Scenario Key") {
            selectCommand.Parameters.AddWithValue("@ScenarioName232", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@ScenarioName232", DBNull.Value); }
        if (sField == "Account Key") {
            selectCommand.Parameters.AddWithValue("@ParentAccountKey233", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@ParentAccountKey233", DBNull.Value); }
        if (sField == "Amount") {
            selectCommand.Parameters.AddWithValue("@Amount", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@Amount", DBNull.Value); }
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

    public static dbo_FactFinanceClass Select_Record(dbo_FactFinanceClass clsdbo_FactFinancePara)
    {
        dbo_FactFinanceClass clsdbo_FactFinance = new dbo_FactFinanceClass();
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement
            = "SELECT " 
            + "     [FinanceKey] "
            + "    ,[DateKey] "
            + "    ,[OrganizationKey] "
            + "    ,[DepartmentGroupKey] "
            + "    ,[ScenarioKey] "
            + "    ,[AccountKey] "
            + "    ,[Amount] "
            + "    ,[Date] "
            + "FROM "
            + "     [dbo].[FactFinance] "
            + "WHERE "
            + "    [FinanceKey] = @FinanceKey "
            + "";
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        selectCommand.CommandType = CommandType.Text;
        selectCommand.Parameters.AddWithValue("@FinanceKey", clsdbo_FactFinancePara.FinanceKey);
        try
        {
            connection.Open();
            SqlDataReader reader
                = selectCommand.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                clsdbo_FactFinance.FinanceKey = System.Convert.ToInt32(reader["FinanceKey"]);
                clsdbo_FactFinance.DateKey = System.Convert.ToInt32(reader["DateKey"]);
                clsdbo_FactFinance.OrganizationKey = System.Convert.ToInt32(reader["OrganizationKey"]);
                clsdbo_FactFinance.DepartmentGroupKey = System.Convert.ToInt32(reader["DepartmentGroupKey"]);
                clsdbo_FactFinance.ScenarioKey = System.Convert.ToInt32(reader["ScenarioKey"]);
                clsdbo_FactFinance.AccountKey = System.Convert.ToInt32(reader["AccountKey"]);
                clsdbo_FactFinance.Amount = System.Convert.ToDecimal(reader["Amount"]);
                clsdbo_FactFinance.Date = reader["Date"] is DBNull ? null : (DateTime?)reader["Date"];
            }
            else
            {
                clsdbo_FactFinance = null;
            }
            reader.Close();
        }
        catch (SqlException)
        {
            return clsdbo_FactFinance;
        }
        finally
        {
            connection.Close();
        }
        return clsdbo_FactFinance;
    }

    public static bool Add(dbo_FactFinanceClass clsdbo_FactFinance)
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string insertStatement
            = "INSERT " 
            + "     [dbo].[FactFinance] "
            + "     ( "
            + "     [DateKey] "
            + "    ,[OrganizationKey] "
            + "    ,[DepartmentGroupKey] "
            + "    ,[ScenarioKey] "
            + "    ,[AccountKey] "
            + "    ,[Amount] "
            + "    ,[Date] "
            + "     ) "
            + "VALUES " 
            + "     ( "
            + "     @DateKey "
            + "    ,@OrganizationKey "
            + "    ,@DepartmentGroupKey "
            + "    ,@ScenarioKey "
            + "    ,@AccountKey "
            + "    ,@Amount "
            + "    ,@Date "
            + "     ) "
            + "";
        SqlCommand insertCommand = new SqlCommand(insertStatement, connection);
        insertCommand.CommandType = CommandType.Text;
        insertCommand.Parameters.AddWithValue("@DateKey", clsdbo_FactFinance.DateKey);
        insertCommand.Parameters.AddWithValue("@OrganizationKey", clsdbo_FactFinance.OrganizationKey);
        insertCommand.Parameters.AddWithValue("@DepartmentGroupKey", clsdbo_FactFinance.DepartmentGroupKey);
        insertCommand.Parameters.AddWithValue("@ScenarioKey", clsdbo_FactFinance.ScenarioKey);
        insertCommand.Parameters.AddWithValue("@AccountKey", clsdbo_FactFinance.AccountKey);
        insertCommand.Parameters.AddWithValue("@Amount", clsdbo_FactFinance.Amount);
        if (clsdbo_FactFinance.Date.HasValue == true) {
            insertCommand.Parameters.AddWithValue("@Date", clsdbo_FactFinance.Date);
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

    public static bool Update(dbo_FactFinanceClass olddbo_FactFinanceClass, 
           dbo_FactFinanceClass newdbo_FactFinanceClass)
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string updateStatement
            = "UPDATE "  
            + "     [dbo].[FactFinance] "
            + "SET "
            + "     [DateKey] = @NewDateKey "
            + "    ,[OrganizationKey] = @NewOrganizationKey "
            + "    ,[DepartmentGroupKey] = @NewDepartmentGroupKey "
            + "    ,[ScenarioKey] = @NewScenarioKey "
            + "    ,[AccountKey] = @NewAccountKey "
            + "    ,[Amount] = @NewAmount "
            + "    ,[Date] = @NewDate "
            + "WHERE "
            + "     [FinanceKey] = @OldFinanceKey " 
            + " AND [DateKey] = @OldDateKey " 
            + " AND [OrganizationKey] = @OldOrganizationKey " 
            + " AND [DepartmentGroupKey] = @OldDepartmentGroupKey " 
            + " AND [ScenarioKey] = @OldScenarioKey " 
            + " AND [AccountKey] = @OldAccountKey " 
            + " AND [Amount] = @OldAmount " 
            + " AND ((@OldDate IS NULL AND [Date] IS NULL) OR [Date] = @OldDate) " 
            + "";
        SqlCommand updateCommand = new SqlCommand(updateStatement, connection);
        updateCommand.CommandType = CommandType.Text;
        updateCommand.Parameters.AddWithValue("@NewDateKey", newdbo_FactFinanceClass.DateKey);
        updateCommand.Parameters.AddWithValue("@NewOrganizationKey", newdbo_FactFinanceClass.OrganizationKey);
        updateCommand.Parameters.AddWithValue("@NewDepartmentGroupKey", newdbo_FactFinanceClass.DepartmentGroupKey);
        updateCommand.Parameters.AddWithValue("@NewScenarioKey", newdbo_FactFinanceClass.ScenarioKey);
        updateCommand.Parameters.AddWithValue("@NewAccountKey", newdbo_FactFinanceClass.AccountKey);
        updateCommand.Parameters.AddWithValue("@NewAmount", newdbo_FactFinanceClass.Amount);
        if (newdbo_FactFinanceClass.Date.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@NewDate", newdbo_FactFinanceClass.Date);
        } else {
            updateCommand.Parameters.AddWithValue("@NewDate", DBNull.Value); }
        updateCommand.Parameters.AddWithValue("@OldFinanceKey", olddbo_FactFinanceClass.FinanceKey);
        updateCommand.Parameters.AddWithValue("@OldDateKey", olddbo_FactFinanceClass.DateKey);
        updateCommand.Parameters.AddWithValue("@OldOrganizationKey", olddbo_FactFinanceClass.OrganizationKey);
        updateCommand.Parameters.AddWithValue("@OldDepartmentGroupKey", olddbo_FactFinanceClass.DepartmentGroupKey);
        updateCommand.Parameters.AddWithValue("@OldScenarioKey", olddbo_FactFinanceClass.ScenarioKey);
        updateCommand.Parameters.AddWithValue("@OldAccountKey", olddbo_FactFinanceClass.AccountKey);
        updateCommand.Parameters.AddWithValue("@OldAmount", olddbo_FactFinanceClass.Amount);
        if (olddbo_FactFinanceClass.Date.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@OldDate", olddbo_FactFinanceClass.Date);
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

    public static bool Delete(dbo_FactFinanceClass clsdbo_FactFinance)
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string deleteStatement
            = "DELETE FROM "  
            + "     [dbo].[FactFinance] "
            + "WHERE " 
            + "     [FinanceKey] = @OldFinanceKey " 
            + " AND [DateKey] = @OldDateKey " 
            + " AND [OrganizationKey] = @OldOrganizationKey " 
            + " AND [DepartmentGroupKey] = @OldDepartmentGroupKey " 
            + " AND [ScenarioKey] = @OldScenarioKey " 
            + " AND [AccountKey] = @OldAccountKey " 
            + " AND [Amount] = @OldAmount " 
            + " AND ((@OldDate IS NULL AND [Date] IS NULL) OR [Date] = @OldDate) " 
            + "";
        SqlCommand deleteCommand = new SqlCommand(deleteStatement, connection);
        deleteCommand.CommandType = CommandType.Text;
        deleteCommand.Parameters.AddWithValue("@OldFinanceKey", clsdbo_FactFinance.FinanceKey);
        deleteCommand.Parameters.AddWithValue("@OldDateKey", clsdbo_FactFinance.DateKey);
        deleteCommand.Parameters.AddWithValue("@OldOrganizationKey", clsdbo_FactFinance.OrganizationKey);
        deleteCommand.Parameters.AddWithValue("@OldDepartmentGroupKey", clsdbo_FactFinance.DepartmentGroupKey);
        deleteCommand.Parameters.AddWithValue("@OldScenarioKey", clsdbo_FactFinance.ScenarioKey);
        deleteCommand.Parameters.AddWithValue("@OldAccountKey", clsdbo_FactFinance.AccountKey);
        deleteCommand.Parameters.AddWithValue("@OldAmount", clsdbo_FactFinance.Amount);
        if (clsdbo_FactFinance.Date.HasValue == true) {
            deleteCommand.Parameters.AddWithValue("@OldDate", clsdbo_FactFinance.Date);
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

 
