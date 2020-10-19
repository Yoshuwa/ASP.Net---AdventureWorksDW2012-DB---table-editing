using System;
using System.Data;
using System.Data.SqlClient;

public class dbo_DimAccountDataClass
{

    public static DataTable SelectAll()
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement
            = "SELECT "  
            + "     [dbo].[DimAccount].[AccountKey] "
            + "    ,[A4].[ParentAccountKey] "
            + "    ,[dbo].[DimAccount].[AccountCodeAlternateKey] "
            + "    ,[dbo].[DimAccount].[ParentAccountCodeAlternateKey] "
            + "    ,[dbo].[DimAccount].[AccountDescription] "
            + "    ,[dbo].[DimAccount].[AccountType] "
            + "    ,[dbo].[DimAccount].[Operator] "
            + "    ,[dbo].[DimAccount].[CustomMembers] "
            + "    ,[dbo].[DimAccount].[ValueType] "
            + "    ,[dbo].[DimAccount].[CustomMemberOptions] "
            + "FROM " 
            + "     [dbo].[DimAccount] " 
            + "LEFT JOIN [dbo].[DimAccount] as [A4] ON [dbo].[DimAccount].[ParentAccountKey] = [A4].[AccountKey] "
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
            + "     [dbo].[DimAccount].[AccountKey] "
            + "    ,[A4].[ParentAccountKey]"
            + "    ,[dbo].[DimAccount].[AccountCodeAlternateKey] "
            + "    ,[dbo].[DimAccount].[ParentAccountCodeAlternateKey] "
            + "    ,[dbo].[DimAccount].[AccountDescription] "
            + "    ,[dbo].[DimAccount].[AccountType] "
            + "    ,[dbo].[DimAccount].[Operator] "
            + "    ,[dbo].[DimAccount].[CustomMembers] "
            + "    ,[dbo].[DimAccount].[ValueType] "
            + "    ,[dbo].[DimAccount].[CustomMemberOptions] "
            + "FROM " 
            + "     [dbo].[DimAccount] " 
            + "LEFT JOIN [dbo].[DimAccount] as [A4] ON [dbo].[DimAccount].[ParentAccountKey] = [A4].[AccountKey] "
                + "WHERE " 
                + "     (@AccountKey IS NULL OR @AccountKey = '' OR [DimAccount].[AccountKey] LIKE '%' + LTRIM(RTRIM(@AccountKey)) + '%') " 
                + "AND   (@ParentAccountKey4 IS NULL OR @ParentAccountKey4 = '' OR [A4].[ParentAccountKey] LIKE '%' + LTRIM(RTRIM(@ParentAccountKey4)) + '%') " 
                + "AND   (@AccountCodeAlternateKey IS NULL OR @AccountCodeAlternateKey = '' OR [DimAccount].[AccountCodeAlternateKey] LIKE '%' + LTRIM(RTRIM(@AccountCodeAlternateKey)) + '%') " 
                + "AND   (@ParentAccountCodeAlternateKey IS NULL OR @ParentAccountCodeAlternateKey = '' OR [DimAccount].[ParentAccountCodeAlternateKey] LIKE '%' + LTRIM(RTRIM(@ParentAccountCodeAlternateKey)) + '%') " 
                + "AND   (@AccountDescription IS NULL OR @AccountDescription = '' OR [DimAccount].[AccountDescription] LIKE '%' + LTRIM(RTRIM(@AccountDescription)) + '%') " 
                + "AND   (@AccountType IS NULL OR @AccountType = '' OR [DimAccount].[AccountType] LIKE '%' + LTRIM(RTRIM(@AccountType)) + '%') " 
                + "AND   (@Operator IS NULL OR @Operator = '' OR [DimAccount].[Operator] LIKE '%' + LTRIM(RTRIM(@Operator)) + '%') " 
                + "AND   (@CustomMembers IS NULL OR @CustomMembers = '' OR [DimAccount].[CustomMembers] LIKE '%' + LTRIM(RTRIM(@CustomMembers)) + '%') " 
                + "AND   (@ValueType IS NULL OR @ValueType = '' OR [DimAccount].[ValueType] LIKE '%' + LTRIM(RTRIM(@ValueType)) + '%') " 
                + "AND   (@CustomMemberOptions IS NULL OR @CustomMemberOptions = '' OR [DimAccount].[CustomMemberOptions] LIKE '%' + LTRIM(RTRIM(@CustomMemberOptions)) + '%') " 
                + "";
        } else if (sCondition == "Equals") {
            selectStatement
                = "SELECT "
            + "     [dbo].[DimAccount].[AccountKey] "
            + "    ,[A4].[ParentAccountKey]"
            + "    ,[dbo].[DimAccount].[AccountCodeAlternateKey] "
            + "    ,[dbo].[DimAccount].[ParentAccountCodeAlternateKey] "
            + "    ,[dbo].[DimAccount].[AccountDescription] "
            + "    ,[dbo].[DimAccount].[AccountType] "
            + "    ,[dbo].[DimAccount].[Operator] "
            + "    ,[dbo].[DimAccount].[CustomMembers] "
            + "    ,[dbo].[DimAccount].[ValueType] "
            + "    ,[dbo].[DimAccount].[CustomMemberOptions] "
            + "FROM " 
            + "     [dbo].[DimAccount] " 
            + "LEFT JOIN [dbo].[DimAccount] as [A4] ON [dbo].[DimAccount].[ParentAccountKey] = [A4].[AccountKey] "
                + "WHERE " 
                + "     (@AccountKey IS NULL OR @AccountKey = '' OR [DimAccount].[AccountKey] = LTRIM(RTRIM(@AccountKey))) " 
                + "AND   (@ParentAccountKey4 IS NULL OR @ParentAccountKey4 = '' OR [A4].[ParentAccountKey] = LTRIM(RTRIM(@ParentAccountKey4))) " 
                + "AND   (@AccountCodeAlternateKey IS NULL OR @AccountCodeAlternateKey = '' OR [DimAccount].[AccountCodeAlternateKey] = LTRIM(RTRIM(@AccountCodeAlternateKey))) " 
                + "AND   (@ParentAccountCodeAlternateKey IS NULL OR @ParentAccountCodeAlternateKey = '' OR [DimAccount].[ParentAccountCodeAlternateKey] = LTRIM(RTRIM(@ParentAccountCodeAlternateKey))) " 
                + "AND   (@AccountDescription IS NULL OR @AccountDescription = '' OR [DimAccount].[AccountDescription] = LTRIM(RTRIM(@AccountDescription))) " 
                + "AND   (@AccountType IS NULL OR @AccountType = '' OR [DimAccount].[AccountType] = LTRIM(RTRIM(@AccountType))) " 
                + "AND   (@Operator IS NULL OR @Operator = '' OR [DimAccount].[Operator] = LTRIM(RTRIM(@Operator))) " 
                + "AND   (@CustomMembers IS NULL OR @CustomMembers = '' OR [DimAccount].[CustomMembers] = LTRIM(RTRIM(@CustomMembers))) " 
                + "AND   (@ValueType IS NULL OR @ValueType = '' OR [DimAccount].[ValueType] = LTRIM(RTRIM(@ValueType))) " 
                + "AND   (@CustomMemberOptions IS NULL OR @CustomMemberOptions = '' OR [DimAccount].[CustomMemberOptions] = LTRIM(RTRIM(@CustomMemberOptions))) " 
                + "";
        } else if  (sCondition == "Starts with...") {
            selectStatement
                = "SELECT "
            + "     [dbo].[DimAccount].[AccountKey] "
            + "    ,[A4].[ParentAccountKey]"
            + "    ,[dbo].[DimAccount].[AccountCodeAlternateKey] "
            + "    ,[dbo].[DimAccount].[ParentAccountCodeAlternateKey] "
            + "    ,[dbo].[DimAccount].[AccountDescription] "
            + "    ,[dbo].[DimAccount].[AccountType] "
            + "    ,[dbo].[DimAccount].[Operator] "
            + "    ,[dbo].[DimAccount].[CustomMembers] "
            + "    ,[dbo].[DimAccount].[ValueType] "
            + "    ,[dbo].[DimAccount].[CustomMemberOptions] "
            + "FROM " 
            + "     [dbo].[DimAccount] " 
            + "LEFT JOIN [dbo].[DimAccount] as [A4] ON [dbo].[DimAccount].[ParentAccountKey] = [A4].[AccountKey] "
                + "WHERE " 
                + "     (@AccountKey IS NULL OR @AccountKey = '' OR [DimAccount].[AccountKey] LIKE LTRIM(RTRIM(@AccountKey)) + '%') " 
                + "AND   (@ParentAccountKey4 IS NULL OR @ParentAccountKey4 = '' OR [A4].[ParentAccountKey] LIKE LTRIM(RTRIM(@ParentAccountKey4)) + '%') " 
                + "AND   (@AccountCodeAlternateKey IS NULL OR @AccountCodeAlternateKey = '' OR [DimAccount].[AccountCodeAlternateKey] LIKE LTRIM(RTRIM(@AccountCodeAlternateKey)) + '%') " 
                + "AND   (@ParentAccountCodeAlternateKey IS NULL OR @ParentAccountCodeAlternateKey = '' OR [DimAccount].[ParentAccountCodeAlternateKey] LIKE LTRIM(RTRIM(@ParentAccountCodeAlternateKey)) + '%') " 
                + "AND   (@AccountDescription IS NULL OR @AccountDescription = '' OR [DimAccount].[AccountDescription] LIKE LTRIM(RTRIM(@AccountDescription)) + '%') " 
                + "AND   (@AccountType IS NULL OR @AccountType = '' OR [DimAccount].[AccountType] LIKE LTRIM(RTRIM(@AccountType)) + '%') " 
                + "AND   (@Operator IS NULL OR @Operator = '' OR [DimAccount].[Operator] LIKE LTRIM(RTRIM(@Operator)) + '%') " 
                + "AND   (@CustomMembers IS NULL OR @CustomMembers = '' OR [DimAccount].[CustomMembers] LIKE LTRIM(RTRIM(@CustomMembers)) + '%') " 
                + "AND   (@ValueType IS NULL OR @ValueType = '' OR [DimAccount].[ValueType] LIKE LTRIM(RTRIM(@ValueType)) + '%') " 
                + "AND   (@CustomMemberOptions IS NULL OR @CustomMemberOptions = '' OR [DimAccount].[CustomMemberOptions] LIKE LTRIM(RTRIM(@CustomMemberOptions)) + '%') " 
                + "";
        } else if  (sCondition == "More than...") {
            selectStatement
                = "SELECT "
            + "     [dbo].[DimAccount].[AccountKey] "
            + "    ,[A4].[ParentAccountKey]"
            + "    ,[dbo].[DimAccount].[AccountCodeAlternateKey] "
            + "    ,[dbo].[DimAccount].[ParentAccountCodeAlternateKey] "
            + "    ,[dbo].[DimAccount].[AccountDescription] "
            + "    ,[dbo].[DimAccount].[AccountType] "
            + "    ,[dbo].[DimAccount].[Operator] "
            + "    ,[dbo].[DimAccount].[CustomMembers] "
            + "    ,[dbo].[DimAccount].[ValueType] "
            + "    ,[dbo].[DimAccount].[CustomMemberOptions] "
            + "FROM " 
            + "     [dbo].[DimAccount] " 
            + "LEFT JOIN [dbo].[DimAccount] as [A4] ON [dbo].[DimAccount].[ParentAccountKey] = [A4].[AccountKey] "
                + "WHERE " 
                + "     (@AccountKey IS NULL OR @AccountKey = '' OR [DimAccount].[AccountKey] > LTRIM(RTRIM(@AccountKey))) " 
                + "AND   (@ParentAccountKey4 IS NULL OR @ParentAccountKey4 = '' OR [A4].[ParentAccountKey] > LTRIM(RTRIM(@ParentAccountKey4))) " 
                + "AND   (@AccountCodeAlternateKey IS NULL OR @AccountCodeAlternateKey = '' OR [DimAccount].[AccountCodeAlternateKey] > LTRIM(RTRIM(@AccountCodeAlternateKey))) " 
                + "AND   (@ParentAccountCodeAlternateKey IS NULL OR @ParentAccountCodeAlternateKey = '' OR [DimAccount].[ParentAccountCodeAlternateKey] > LTRIM(RTRIM(@ParentAccountCodeAlternateKey))) " 
                + "AND   (@AccountDescription IS NULL OR @AccountDescription = '' OR [DimAccount].[AccountDescription] > LTRIM(RTRIM(@AccountDescription))) " 
                + "AND   (@AccountType IS NULL OR @AccountType = '' OR [DimAccount].[AccountType] > LTRIM(RTRIM(@AccountType))) " 
                + "AND   (@Operator IS NULL OR @Operator = '' OR [DimAccount].[Operator] > LTRIM(RTRIM(@Operator))) " 
                + "AND   (@CustomMembers IS NULL OR @CustomMembers = '' OR [DimAccount].[CustomMembers] > LTRIM(RTRIM(@CustomMembers))) " 
                + "AND   (@ValueType IS NULL OR @ValueType = '' OR [DimAccount].[ValueType] > LTRIM(RTRIM(@ValueType))) " 
                + "AND   (@CustomMemberOptions IS NULL OR @CustomMemberOptions = '' OR [DimAccount].[CustomMemberOptions] > LTRIM(RTRIM(@CustomMemberOptions))) " 
                + "";
        } else if  (sCondition == "Less than...") {
            selectStatement
                = "SELECT " 
            + "     [dbo].[DimAccount].[AccountKey] "
            + "    ,[A4].[ParentAccountKey]"
            + "    ,[dbo].[DimAccount].[AccountCodeAlternateKey] "
            + "    ,[dbo].[DimAccount].[ParentAccountCodeAlternateKey] "
            + "    ,[dbo].[DimAccount].[AccountDescription] "
            + "    ,[dbo].[DimAccount].[AccountType] "
            + "    ,[dbo].[DimAccount].[Operator] "
            + "    ,[dbo].[DimAccount].[CustomMembers] "
            + "    ,[dbo].[DimAccount].[ValueType] "
            + "    ,[dbo].[DimAccount].[CustomMemberOptions] "
            + "FROM " 
            + "     [dbo].[DimAccount] " 
            + "LEFT JOIN [dbo].[DimAccount] as [A4] ON [dbo].[DimAccount].[ParentAccountKey] = [A4].[AccountKey] "
                + "WHERE " 
                + "     (@AccountKey IS NULL OR @AccountKey = '' OR [DimAccount].[AccountKey] < LTRIM(RTRIM(@AccountKey))) " 
                + "AND   (@ParentAccountKey4 IS NULL OR @ParentAccountKey4 = '' OR [A4].[ParentAccountKey] < LTRIM(RTRIM(@ParentAccountKey4))) " 
                + "AND   (@AccountCodeAlternateKey IS NULL OR @AccountCodeAlternateKey = '' OR [DimAccount].[AccountCodeAlternateKey] < LTRIM(RTRIM(@AccountCodeAlternateKey))) " 
                + "AND   (@ParentAccountCodeAlternateKey IS NULL OR @ParentAccountCodeAlternateKey = '' OR [DimAccount].[ParentAccountCodeAlternateKey] < LTRIM(RTRIM(@ParentAccountCodeAlternateKey))) " 
                + "AND   (@AccountDescription IS NULL OR @AccountDescription = '' OR [DimAccount].[AccountDescription] < LTRIM(RTRIM(@AccountDescription))) " 
                + "AND   (@AccountType IS NULL OR @AccountType = '' OR [DimAccount].[AccountType] < LTRIM(RTRIM(@AccountType))) " 
                + "AND   (@Operator IS NULL OR @Operator = '' OR [DimAccount].[Operator] < LTRIM(RTRIM(@Operator))) " 
                + "AND   (@CustomMembers IS NULL OR @CustomMembers = '' OR [DimAccount].[CustomMembers] < LTRIM(RTRIM(@CustomMembers))) " 
                + "AND   (@ValueType IS NULL OR @ValueType = '' OR [DimAccount].[ValueType] < LTRIM(RTRIM(@ValueType))) " 
                + "AND   (@CustomMemberOptions IS NULL OR @CustomMemberOptions = '' OR [DimAccount].[CustomMemberOptions] < LTRIM(RTRIM(@CustomMemberOptions))) " 
                + "";
        } else if  (sCondition == "Equal or more than...") {
            selectStatement
                = "SELECT "
            + "     [dbo].[DimAccount].[AccountKey] "
            + "    ,[A4].[ParentAccountKey]"
            + "    ,[dbo].[DimAccount].[AccountCodeAlternateKey] "
            + "    ,[dbo].[DimAccount].[ParentAccountCodeAlternateKey] "
            + "    ,[dbo].[DimAccount].[AccountDescription] "
            + "    ,[dbo].[DimAccount].[AccountType] "
            + "    ,[dbo].[DimAccount].[Operator] "
            + "    ,[dbo].[DimAccount].[CustomMembers] "
            + "    ,[dbo].[DimAccount].[ValueType] "
            + "    ,[dbo].[DimAccount].[CustomMemberOptions] "
            + "FROM " 
            + "     [dbo].[DimAccount] " 
            + "LEFT JOIN [dbo].[DimAccount] as [A4] ON [dbo].[DimAccount].[ParentAccountKey] = [A4].[AccountKey] "
                + "WHERE " 
                + "     (@AccountKey IS NULL OR @AccountKey = '' OR [DimAccount].[AccountKey] >= LTRIM(RTRIM(@AccountKey))) " 
                + "AND   (@ParentAccountKey4 IS NULL OR @ParentAccountKey4 = '' OR [A4].[ParentAccountKey] >= LTRIM(RTRIM(@ParentAccountKey4))) " 
                + "AND   (@AccountCodeAlternateKey IS NULL OR @AccountCodeAlternateKey = '' OR [DimAccount].[AccountCodeAlternateKey] >= LTRIM(RTRIM(@AccountCodeAlternateKey))) " 
                + "AND   (@ParentAccountCodeAlternateKey IS NULL OR @ParentAccountCodeAlternateKey = '' OR [DimAccount].[ParentAccountCodeAlternateKey] >= LTRIM(RTRIM(@ParentAccountCodeAlternateKey))) " 
                + "AND   (@AccountDescription IS NULL OR @AccountDescription = '' OR [DimAccount].[AccountDescription] >= LTRIM(RTRIM(@AccountDescription))) " 
                + "AND   (@AccountType IS NULL OR @AccountType = '' OR [DimAccount].[AccountType] >= LTRIM(RTRIM(@AccountType))) " 
                + "AND   (@Operator IS NULL OR @Operator = '' OR [DimAccount].[Operator] >= LTRIM(RTRIM(@Operator))) " 
                + "AND   (@CustomMembers IS NULL OR @CustomMembers = '' OR [DimAccount].[CustomMembers] >= LTRIM(RTRIM(@CustomMembers))) " 
                + "AND   (@ValueType IS NULL OR @ValueType = '' OR [DimAccount].[ValueType] >= LTRIM(RTRIM(@ValueType))) " 
                + "AND   (@CustomMemberOptions IS NULL OR @CustomMemberOptions = '' OR [DimAccount].[CustomMemberOptions] >= LTRIM(RTRIM(@CustomMemberOptions))) " 
                + "";
        } else if (sCondition == "Equal or less than...") {
            selectStatement 
                = "SELECT "
            + "     [dbo].[DimAccount].[AccountKey] "
            + "    ,[A4].[ParentAccountKey]"
            + "    ,[dbo].[DimAccount].[AccountCodeAlternateKey] "
            + "    ,[dbo].[DimAccount].[ParentAccountCodeAlternateKey] "
            + "    ,[dbo].[DimAccount].[AccountDescription] "
            + "    ,[dbo].[DimAccount].[AccountType] "
            + "    ,[dbo].[DimAccount].[Operator] "
            + "    ,[dbo].[DimAccount].[CustomMembers] "
            + "    ,[dbo].[DimAccount].[ValueType] "
            + "    ,[dbo].[DimAccount].[CustomMemberOptions] "
            + "FROM " 
            + "     [dbo].[DimAccount] " 
            + "LEFT JOIN [dbo].[DimAccount] as [A4] ON [dbo].[DimAccount].[ParentAccountKey] = [A4].[AccountKey] "
                + "WHERE " 
                + "     (@AccountKey IS NULL OR @AccountKey = '' OR [DimAccount].[AccountKey] <= LTRIM(RTRIM(@AccountKey))) " 
                + "AND   (@ParentAccountKey4 IS NULL OR @ParentAccountKey4 = '' OR [A4].[ParentAccountKey] <= LTRIM(RTRIM(@ParentAccountKey4))) " 
                + "AND   (@AccountCodeAlternateKey IS NULL OR @AccountCodeAlternateKey = '' OR [DimAccount].[AccountCodeAlternateKey] <= LTRIM(RTRIM(@AccountCodeAlternateKey))) " 
                + "AND   (@ParentAccountCodeAlternateKey IS NULL OR @ParentAccountCodeAlternateKey = '' OR [DimAccount].[ParentAccountCodeAlternateKey] <= LTRIM(RTRIM(@ParentAccountCodeAlternateKey))) " 
                + "AND   (@AccountDescription IS NULL OR @AccountDescription = '' OR [DimAccount].[AccountDescription] <= LTRIM(RTRIM(@AccountDescription))) " 
                + "AND   (@AccountType IS NULL OR @AccountType = '' OR [DimAccount].[AccountType] <= LTRIM(RTRIM(@AccountType))) " 
                + "AND   (@Operator IS NULL OR @Operator = '' OR [DimAccount].[Operator] <= LTRIM(RTRIM(@Operator))) " 
                + "AND   (@CustomMembers IS NULL OR @CustomMembers = '' OR [DimAccount].[CustomMembers] <= LTRIM(RTRIM(@CustomMembers))) " 
                + "AND   (@ValueType IS NULL OR @ValueType = '' OR [DimAccount].[ValueType] <= LTRIM(RTRIM(@ValueType))) " 
                + "AND   (@CustomMemberOptions IS NULL OR @CustomMemberOptions = '' OR [DimAccount].[CustomMemberOptions] <= LTRIM(RTRIM(@CustomMemberOptions))) " 
                + "";
        }
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        selectCommand.CommandType = CommandType.Text;
        if (sField == "Account Key") {
            selectCommand.Parameters.AddWithValue("@AccountKey", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@AccountKey", DBNull.Value); }
        if (sField == "Parent Account Key") {
            selectCommand.Parameters.AddWithValue("@ParentAccountKey4", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@ParentAccountKey4", DBNull.Value); }
        if (sField == "Account Code Alternate Key") {
            selectCommand.Parameters.AddWithValue("@AccountCodeAlternateKey", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@AccountCodeAlternateKey", DBNull.Value); }
        if (sField == "Parent Account Code Alternate Key") {
            selectCommand.Parameters.AddWithValue("@ParentAccountCodeAlternateKey", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@ParentAccountCodeAlternateKey", DBNull.Value); }
        if (sField == "Account Description") {
            selectCommand.Parameters.AddWithValue("@AccountDescription", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@AccountDescription", DBNull.Value); }
        if (sField == "Account Type") {
            selectCommand.Parameters.AddWithValue("@AccountType", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@AccountType", DBNull.Value); }
        if (sField == "Operator") {
            selectCommand.Parameters.AddWithValue("@Operator", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@Operator", DBNull.Value); }
        if (sField == "Custom Members") {
            selectCommand.Parameters.AddWithValue("@CustomMembers", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@CustomMembers", DBNull.Value); }
        if (sField == "Value Type") {
            selectCommand.Parameters.AddWithValue("@ValueType", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@ValueType", DBNull.Value); }
        if (sField == "Custom Member Options") {
            selectCommand.Parameters.AddWithValue("@CustomMemberOptions", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@CustomMemberOptions", DBNull.Value); }
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

    public static dbo_DimAccountClass Select_Record(dbo_DimAccountClass clsdbo_DimAccountPara)
    {
        dbo_DimAccountClass clsdbo_DimAccount = new dbo_DimAccountClass();
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement
            = "SELECT " 
            + "     [AccountKey] "
            + "    ,[ParentAccountKey] "
            + "    ,[AccountCodeAlternateKey] "
            + "    ,[ParentAccountCodeAlternateKey] "
            + "    ,[AccountDescription] "
            + "    ,[AccountType] "
            + "    ,[Operator] "
            + "    ,[CustomMembers] "
            + "    ,[ValueType] "
            + "    ,[CustomMemberOptions] "
            + "FROM "
            + "     [dbo].[DimAccount] "
            + "WHERE "
            + "     [AccountKey] = @AccountKey "
            + "";
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        selectCommand.CommandType = CommandType.Text;
        selectCommand.Parameters.AddWithValue("@AccountKey", clsdbo_DimAccountPara.AccountKey);
        try
        {
            connection.Open();
            SqlDataReader reader
                = selectCommand.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                clsdbo_DimAccount.AccountKey = System.Convert.ToInt32(reader["AccountKey"]);
                clsdbo_DimAccount.ParentAccountKey = reader["ParentAccountKey"] is DBNull ? null : (Int32?)reader["ParentAccountKey"];
                clsdbo_DimAccount.AccountCodeAlternateKey = reader["AccountCodeAlternateKey"] is DBNull ? null : (Int32?)reader["AccountCodeAlternateKey"];
                clsdbo_DimAccount.ParentAccountCodeAlternateKey = reader["ParentAccountCodeAlternateKey"] is DBNull ? null : (Int32?)reader["ParentAccountCodeAlternateKey"];
                clsdbo_DimAccount.AccountDescription = reader["AccountDescription"] is DBNull ? null : reader["AccountDescription"].ToString();
                clsdbo_DimAccount.AccountType = reader["AccountType"] is DBNull ? null : reader["AccountType"].ToString();
                clsdbo_DimAccount.Operator = reader["Operator"] is DBNull ? null : reader["Operator"].ToString();
                clsdbo_DimAccount.CustomMembers = reader["CustomMembers"] is DBNull ? null : reader["CustomMembers"].ToString();
                clsdbo_DimAccount.ValueType = reader["ValueType"] is DBNull ? null : reader["ValueType"].ToString();
                clsdbo_DimAccount.CustomMemberOptions = reader["CustomMemberOptions"] is DBNull ? null : reader["CustomMemberOptions"].ToString();
            }
            else
            {
                clsdbo_DimAccount = null;
            }
            reader.Close();
        }
        catch (SqlException)
        {
            return clsdbo_DimAccount;
        }
        finally
        {
            connection.Close();
        }
        return clsdbo_DimAccount;
    }

    public static bool Add(dbo_DimAccountClass clsdbo_DimAccount)
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string insertStatement
            = "INSERT " 
            + "     [dbo].[DimAccount] "
            + "     ( "
            + "     [ParentAccountKey] "
            + "    ,[AccountCodeAlternateKey] "
            + "    ,[ParentAccountCodeAlternateKey] "
            + "    ,[AccountDescription] "
            + "    ,[AccountType] "
            + "    ,[Operator] "
            + "    ,[CustomMembers] "
            + "    ,[ValueType] "
            + "    ,[CustomMemberOptions] "
            + "     ) "
            + "VALUES " 
            + "     ( "
            + "     @ParentAccountKey "
            + "    ,@AccountCodeAlternateKey "
            + "    ,@ParentAccountCodeAlternateKey "
            + "    ,@AccountDescription "
            + "    ,@AccountType "
            + "    ,@Operator "
            + "    ,@CustomMembers "
            + "    ,@ValueType "
            + "    ,@CustomMemberOptions "
            + "     ) "
            + "";
        SqlCommand insertCommand = new SqlCommand(insertStatement, connection);
        insertCommand.CommandType = CommandType.Text;
        if (clsdbo_DimAccount.ParentAccountKey.HasValue == true) {
            insertCommand.Parameters.AddWithValue("@ParentAccountKey", clsdbo_DimAccount.ParentAccountKey);
        } else {
            insertCommand.Parameters.AddWithValue("@ParentAccountKey", DBNull.Value); }
        if (clsdbo_DimAccount.AccountCodeAlternateKey.HasValue == true) {
            insertCommand.Parameters.AddWithValue("@AccountCodeAlternateKey", clsdbo_DimAccount.AccountCodeAlternateKey);
        } else {
            insertCommand.Parameters.AddWithValue("@AccountCodeAlternateKey", DBNull.Value); }
        if (clsdbo_DimAccount.ParentAccountCodeAlternateKey.HasValue == true) {
            insertCommand.Parameters.AddWithValue("@ParentAccountCodeAlternateKey", clsdbo_DimAccount.ParentAccountCodeAlternateKey);
        } else {
            insertCommand.Parameters.AddWithValue("@ParentAccountCodeAlternateKey", DBNull.Value); }
        if (clsdbo_DimAccount.AccountDescription != null) {
            insertCommand.Parameters.AddWithValue("@AccountDescription", clsdbo_DimAccount.AccountDescription);
        } else {
            insertCommand.Parameters.AddWithValue("@AccountDescription", DBNull.Value); }
        if (clsdbo_DimAccount.AccountType != null) {
            insertCommand.Parameters.AddWithValue("@AccountType", clsdbo_DimAccount.AccountType);
        } else {
            insertCommand.Parameters.AddWithValue("@AccountType", DBNull.Value); }
        if (clsdbo_DimAccount.Operator != null) {
            insertCommand.Parameters.AddWithValue("@Operator", clsdbo_DimAccount.Operator);
        } else {
            insertCommand.Parameters.AddWithValue("@Operator", DBNull.Value); }
        if (clsdbo_DimAccount.CustomMembers != null) {
            insertCommand.Parameters.AddWithValue("@CustomMembers", clsdbo_DimAccount.CustomMembers);
        } else {
            insertCommand.Parameters.AddWithValue("@CustomMembers", DBNull.Value); }
        if (clsdbo_DimAccount.ValueType != null) {
            insertCommand.Parameters.AddWithValue("@ValueType", clsdbo_DimAccount.ValueType);
        } else {
            insertCommand.Parameters.AddWithValue("@ValueType", DBNull.Value); }
        if (clsdbo_DimAccount.CustomMemberOptions != null) {
            insertCommand.Parameters.AddWithValue("@CustomMemberOptions", clsdbo_DimAccount.CustomMemberOptions);
        } else {
            insertCommand.Parameters.AddWithValue("@CustomMemberOptions", DBNull.Value); }
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

    public static bool Update(dbo_DimAccountClass olddbo_DimAccountClass, 
           dbo_DimAccountClass newdbo_DimAccountClass)
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string updateStatement
            = "UPDATE "  
            + "     [dbo].[DimAccount] "
            + "SET "
            + "     [ParentAccountKey] = @NewParentAccountKey "
            + "    ,[AccountCodeAlternateKey] = @NewAccountCodeAlternateKey "
            + "    ,[ParentAccountCodeAlternateKey] = @NewParentAccountCodeAlternateKey "
            + "    ,[AccountDescription] = @NewAccountDescription "
            + "    ,[AccountType] = @NewAccountType "
            + "    ,[Operator] = @NewOperator "
            + "    ,[CustomMembers] = @NewCustomMembers "
            + "    ,[ValueType] = @NewValueType "
            + "    ,[CustomMemberOptions] = @NewCustomMemberOptions "
            + "WHERE "
            + "     [AccountKey] = @OldAccountKey " 
            + " AND ((@OldParentAccountKey IS NULL AND [ParentAccountKey] IS NULL) OR [ParentAccountKey] = @OldParentAccountKey) " 
            + " AND ((@OldAccountCodeAlternateKey IS NULL AND [AccountCodeAlternateKey] IS NULL) OR [AccountCodeAlternateKey] = @OldAccountCodeAlternateKey) " 
            + " AND ((@OldParentAccountCodeAlternateKey IS NULL AND [ParentAccountCodeAlternateKey] IS NULL) OR [ParentAccountCodeAlternateKey] = @OldParentAccountCodeAlternateKey) " 
            + " AND ((@OldAccountDescription IS NULL AND [AccountDescription] IS NULL) OR [AccountDescription] = @OldAccountDescription) " 
            + " AND ((@OldAccountType IS NULL AND [AccountType] IS NULL) OR [AccountType] = @OldAccountType) " 
            + " AND ((@OldOperator IS NULL AND [Operator] IS NULL) OR [Operator] = @OldOperator) " 
            + " AND ((@OldCustomMembers IS NULL AND [CustomMembers] IS NULL) OR [CustomMembers] = @OldCustomMembers) " 
            + " AND ((@OldValueType IS NULL AND [ValueType] IS NULL) OR [ValueType] = @OldValueType) " 
            + " AND ((@OldCustomMemberOptions IS NULL AND [CustomMemberOptions] IS NULL) OR [CustomMemberOptions] = @OldCustomMemberOptions) " 
            + "";
        SqlCommand updateCommand = new SqlCommand(updateStatement, connection);
        updateCommand.CommandType = CommandType.Text;
        if (newdbo_DimAccountClass.ParentAccountKey.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@NewParentAccountKey", newdbo_DimAccountClass.ParentAccountKey);
        } else {
            updateCommand.Parameters.AddWithValue("@NewParentAccountKey", DBNull.Value); }
        if (newdbo_DimAccountClass.AccountCodeAlternateKey.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@NewAccountCodeAlternateKey", newdbo_DimAccountClass.AccountCodeAlternateKey);
        } else {
            updateCommand.Parameters.AddWithValue("@NewAccountCodeAlternateKey", DBNull.Value); }
        if (newdbo_DimAccountClass.ParentAccountCodeAlternateKey.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@NewParentAccountCodeAlternateKey", newdbo_DimAccountClass.ParentAccountCodeAlternateKey);
        } else {
            updateCommand.Parameters.AddWithValue("@NewParentAccountCodeAlternateKey", DBNull.Value); }
        if (newdbo_DimAccountClass.AccountDescription != null) {
            updateCommand.Parameters.AddWithValue("@NewAccountDescription", newdbo_DimAccountClass.AccountDescription);
        } else {
            updateCommand.Parameters.AddWithValue("@NewAccountDescription", DBNull.Value); }
        if (newdbo_DimAccountClass.AccountType != null) {
            updateCommand.Parameters.AddWithValue("@NewAccountType", newdbo_DimAccountClass.AccountType);
        } else {
            updateCommand.Parameters.AddWithValue("@NewAccountType", DBNull.Value); }
        if (newdbo_DimAccountClass.Operator != null) {
            updateCommand.Parameters.AddWithValue("@NewOperator", newdbo_DimAccountClass.Operator);
        } else {
            updateCommand.Parameters.AddWithValue("@NewOperator", DBNull.Value); }
        if (newdbo_DimAccountClass.CustomMembers != null) {
            updateCommand.Parameters.AddWithValue("@NewCustomMembers", newdbo_DimAccountClass.CustomMembers);
        } else {
            updateCommand.Parameters.AddWithValue("@NewCustomMembers", DBNull.Value); }
        if (newdbo_DimAccountClass.ValueType != null) {
            updateCommand.Parameters.AddWithValue("@NewValueType", newdbo_DimAccountClass.ValueType);
        } else {
            updateCommand.Parameters.AddWithValue("@NewValueType", DBNull.Value); }
        if (newdbo_DimAccountClass.CustomMemberOptions != null) {
            updateCommand.Parameters.AddWithValue("@NewCustomMemberOptions", newdbo_DimAccountClass.CustomMemberOptions);
        } else {
            updateCommand.Parameters.AddWithValue("@NewCustomMemberOptions", DBNull.Value); }
        updateCommand.Parameters.AddWithValue("@OldAccountKey", olddbo_DimAccountClass.AccountKey);
        if (olddbo_DimAccountClass.ParentAccountKey.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@OldParentAccountKey", olddbo_DimAccountClass.ParentAccountKey);
        } else {
            updateCommand.Parameters.AddWithValue("@OldParentAccountKey", DBNull.Value); }
        if (olddbo_DimAccountClass.AccountCodeAlternateKey.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@OldAccountCodeAlternateKey", olddbo_DimAccountClass.AccountCodeAlternateKey);
        } else {
            updateCommand.Parameters.AddWithValue("@OldAccountCodeAlternateKey", DBNull.Value); }
        if (olddbo_DimAccountClass.ParentAccountCodeAlternateKey.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@OldParentAccountCodeAlternateKey", olddbo_DimAccountClass.ParentAccountCodeAlternateKey);
        } else {
            updateCommand.Parameters.AddWithValue("@OldParentAccountCodeAlternateKey", DBNull.Value); }
        if (olddbo_DimAccountClass.AccountDescription != null) {
            updateCommand.Parameters.AddWithValue("@OldAccountDescription", olddbo_DimAccountClass.AccountDescription);
        } else {
            updateCommand.Parameters.AddWithValue("@OldAccountDescription", DBNull.Value); }
        if (olddbo_DimAccountClass.AccountType != null) {
            updateCommand.Parameters.AddWithValue("@OldAccountType", olddbo_DimAccountClass.AccountType);
        } else {
            updateCommand.Parameters.AddWithValue("@OldAccountType", DBNull.Value); }
        if (olddbo_DimAccountClass.Operator != null) {
            updateCommand.Parameters.AddWithValue("@OldOperator", olddbo_DimAccountClass.Operator);
        } else {
            updateCommand.Parameters.AddWithValue("@OldOperator", DBNull.Value); }
        if (olddbo_DimAccountClass.CustomMembers != null) {
            updateCommand.Parameters.AddWithValue("@OldCustomMembers", olddbo_DimAccountClass.CustomMembers);
        } else {
            updateCommand.Parameters.AddWithValue("@OldCustomMembers", DBNull.Value); }
        if (olddbo_DimAccountClass.ValueType != null) {
            updateCommand.Parameters.AddWithValue("@OldValueType", olddbo_DimAccountClass.ValueType);
        } else {
            updateCommand.Parameters.AddWithValue("@OldValueType", DBNull.Value); }
        if (olddbo_DimAccountClass.CustomMemberOptions != null) {
            updateCommand.Parameters.AddWithValue("@OldCustomMemberOptions", olddbo_DimAccountClass.CustomMemberOptions);
        } else {
            updateCommand.Parameters.AddWithValue("@OldCustomMemberOptions", DBNull.Value); }
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

    public static bool Delete(dbo_DimAccountClass clsdbo_DimAccount)
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string deleteStatement
            = "DELETE FROM "  
            + "     [dbo].[DimAccount] "
            + "WHERE " 
            + "     [AccountKey] = @OldAccountKey " 
            + " AND ((@OldParentAccountKey IS NULL AND [ParentAccountKey] IS NULL) OR [ParentAccountKey] = @OldParentAccountKey) " 
            + " AND ((@OldAccountCodeAlternateKey IS NULL AND [AccountCodeAlternateKey] IS NULL) OR [AccountCodeAlternateKey] = @OldAccountCodeAlternateKey) " 
            + " AND ((@OldParentAccountCodeAlternateKey IS NULL AND [ParentAccountCodeAlternateKey] IS NULL) OR [ParentAccountCodeAlternateKey] = @OldParentAccountCodeAlternateKey) " 
            + " AND ((@OldAccountDescription IS NULL AND [AccountDescription] IS NULL) OR [AccountDescription] = @OldAccountDescription) " 
            + " AND ((@OldAccountType IS NULL AND [AccountType] IS NULL) OR [AccountType] = @OldAccountType) " 
            + " AND ((@OldOperator IS NULL AND [Operator] IS NULL) OR [Operator] = @OldOperator) " 
            + " AND ((@OldCustomMembers IS NULL AND [CustomMembers] IS NULL) OR [CustomMembers] = @OldCustomMembers) " 
            + " AND ((@OldValueType IS NULL AND [ValueType] IS NULL) OR [ValueType] = @OldValueType) " 
            + " AND ((@OldCustomMemberOptions IS NULL AND [CustomMemberOptions] IS NULL) OR [CustomMemberOptions] = @OldCustomMemberOptions) " 
            + "";
        SqlCommand deleteCommand = new SqlCommand(deleteStatement, connection);
        deleteCommand.CommandType = CommandType.Text;
        deleteCommand.Parameters.AddWithValue("@OldAccountKey", clsdbo_DimAccount.AccountKey);
        if (clsdbo_DimAccount.ParentAccountKey.HasValue == true) {
            deleteCommand.Parameters.AddWithValue("@OldParentAccountKey", clsdbo_DimAccount.ParentAccountKey);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldParentAccountKey", DBNull.Value); }
        if (clsdbo_DimAccount.AccountCodeAlternateKey.HasValue == true) {
            deleteCommand.Parameters.AddWithValue("@OldAccountCodeAlternateKey", clsdbo_DimAccount.AccountCodeAlternateKey);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldAccountCodeAlternateKey", DBNull.Value); }
        if (clsdbo_DimAccount.ParentAccountCodeAlternateKey.HasValue == true) {
            deleteCommand.Parameters.AddWithValue("@OldParentAccountCodeAlternateKey", clsdbo_DimAccount.ParentAccountCodeAlternateKey);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldParentAccountCodeAlternateKey", DBNull.Value); }
        if (clsdbo_DimAccount.AccountDescription != null) {
            deleteCommand.Parameters.AddWithValue("@OldAccountDescription", clsdbo_DimAccount.AccountDescription);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldAccountDescription", DBNull.Value); }
        if (clsdbo_DimAccount.AccountType != null) {
            deleteCommand.Parameters.AddWithValue("@OldAccountType", clsdbo_DimAccount.AccountType);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldAccountType", DBNull.Value); }
        if (clsdbo_DimAccount.Operator != null) {
            deleteCommand.Parameters.AddWithValue("@OldOperator", clsdbo_DimAccount.Operator);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldOperator", DBNull.Value); }
        if (clsdbo_DimAccount.CustomMembers != null) {
            deleteCommand.Parameters.AddWithValue("@OldCustomMembers", clsdbo_DimAccount.CustomMembers);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldCustomMembers", DBNull.Value); }
        if (clsdbo_DimAccount.ValueType != null) {
            deleteCommand.Parameters.AddWithValue("@OldValueType", clsdbo_DimAccount.ValueType);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldValueType", DBNull.Value); }
        if (clsdbo_DimAccount.CustomMemberOptions != null) {
            deleteCommand.Parameters.AddWithValue("@OldCustomMemberOptions", clsdbo_DimAccount.CustomMemberOptions);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldCustomMemberOptions", DBNull.Value); }
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

 
