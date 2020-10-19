using System;
using System.Data;
using System.Data.SqlClient;

public class dbo_DimOrganizationDataClass
{

    public static DataTable SelectAll()
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement
            = "SELECT "  
            + "     [dbo].[DimOrganization].[OrganizationKey] "
            + "    ,[A109].[OrganizationName] "
            + "    ,[dbo].[DimOrganization].[PercentageOfOwnership] "
            + "    ,[dbo].[DimOrganization].[OrganizationName] "
            + "    ,[A112].[CurrencyName] "
            + "FROM " 
            + "     [dbo].[DimOrganization] " 
            + "LEFT JOIN [dbo].[DimOrganization] as [A109] ON [dbo].[DimOrganization].[ParentOrganizationKey] = [A109].[OrganizationKey] "
            + "LEFT JOIN [dbo].[DimCurrency] as [A112] ON [dbo].[DimOrganization].[CurrencyKey] = [A112].[CurrencyKey] "
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
            + "     [dbo].[DimOrganization].[OrganizationKey] "
            + "    ,[A109].[OrganizationName]"
            + "    ,[dbo].[DimOrganization].[PercentageOfOwnership] "
            + "    ,[dbo].[DimOrganization].[OrganizationName] "
            + "    ,[A112].[CurrencyName]"
            + "FROM " 
            + "     [dbo].[DimOrganization] " 
            + "LEFT JOIN [dbo].[DimOrganization] as [A109] ON [dbo].[DimOrganization].[ParentOrganizationKey] = [A109].[OrganizationKey] "
            + "LEFT JOIN [dbo].[DimCurrency] as [A112] ON [dbo].[DimOrganization].[CurrencyKey] = [A112].[CurrencyKey] "
                + "WHERE " 
                + "     (@OrganizationKey IS NULL OR @OrganizationKey = '' OR [DimOrganization].[OrganizationKey] LIKE '%' + LTRIM(RTRIM(@OrganizationKey)) + '%') " 
                + "AND   (@OrganizationName109 IS NULL OR @OrganizationName109 = '' OR [A109].[OrganizationName] LIKE '%' + LTRIM(RTRIM(@OrganizationName109)) + '%') " 
                + "AND   (@PercentageOfOwnership IS NULL OR @PercentageOfOwnership = '' OR [DimOrganization].[PercentageOfOwnership] LIKE '%' + LTRIM(RTRIM(@PercentageOfOwnership)) + '%') " 
                + "AND   (@OrganizationName IS NULL OR @OrganizationName = '' OR [DimOrganization].[OrganizationName] LIKE '%' + LTRIM(RTRIM(@OrganizationName)) + '%') " 
                + "AND   (@CurrencyName112 IS NULL OR @CurrencyName112 = '' OR [A112].[CurrencyName] LIKE '%' + LTRIM(RTRIM(@CurrencyName112)) + '%') " 
                + "";
        } else if (sCondition == "Equals") {
            selectStatement
                = "SELECT "
            + "     [dbo].[DimOrganization].[OrganizationKey] "
            + "    ,[A109].[OrganizationName]"
            + "    ,[dbo].[DimOrganization].[PercentageOfOwnership] "
            + "    ,[dbo].[DimOrganization].[OrganizationName] "
            + "    ,[A112].[CurrencyName]"
            + "FROM " 
            + "     [dbo].[DimOrganization] " 
            + "LEFT JOIN [dbo].[DimOrganization] as [A109] ON [dbo].[DimOrganization].[ParentOrganizationKey] = [A109].[OrganizationKey] "
            + "LEFT JOIN [dbo].[DimCurrency] as [A112] ON [dbo].[DimOrganization].[CurrencyKey] = [A112].[CurrencyKey] "
                + "WHERE " 
                + "     (@OrganizationKey IS NULL OR @OrganizationKey = '' OR [DimOrganization].[OrganizationKey] = LTRIM(RTRIM(@OrganizationKey))) " 
                + "AND   (@OrganizationName109 IS NULL OR @OrganizationName109 = '' OR [A109].[OrganizationName] = LTRIM(RTRIM(@OrganizationName109))) " 
                + "AND   (@PercentageOfOwnership IS NULL OR @PercentageOfOwnership = '' OR [DimOrganization].[PercentageOfOwnership] = LTRIM(RTRIM(@PercentageOfOwnership))) " 
                + "AND   (@OrganizationName IS NULL OR @OrganizationName = '' OR [DimOrganization].[OrganizationName] = LTRIM(RTRIM(@OrganizationName))) " 
                + "AND   (@CurrencyName112 IS NULL OR @CurrencyName112 = '' OR [A112].[CurrencyName] = LTRIM(RTRIM(@CurrencyName112))) " 
                + "";
        } else if  (sCondition == "Starts with...") {
            selectStatement
                = "SELECT "
            + "     [dbo].[DimOrganization].[OrganizationKey] "
            + "    ,[A109].[OrganizationName]"
            + "    ,[dbo].[DimOrganization].[PercentageOfOwnership] "
            + "    ,[dbo].[DimOrganization].[OrganizationName] "
            + "    ,[A112].[CurrencyName]"
            + "FROM " 
            + "     [dbo].[DimOrganization] " 
            + "LEFT JOIN [dbo].[DimOrganization] as [A109] ON [dbo].[DimOrganization].[ParentOrganizationKey] = [A109].[OrganizationKey] "
            + "LEFT JOIN [dbo].[DimCurrency] as [A112] ON [dbo].[DimOrganization].[CurrencyKey] = [A112].[CurrencyKey] "
                + "WHERE " 
                + "     (@OrganizationKey IS NULL OR @OrganizationKey = '' OR [DimOrganization].[OrganizationKey] LIKE LTRIM(RTRIM(@OrganizationKey)) + '%') " 
                + "AND   (@OrganizationName109 IS NULL OR @OrganizationName109 = '' OR [A109].[OrganizationName] LIKE LTRIM(RTRIM(@OrganizationName109)) + '%') " 
                + "AND   (@PercentageOfOwnership IS NULL OR @PercentageOfOwnership = '' OR [DimOrganization].[PercentageOfOwnership] LIKE LTRIM(RTRIM(@PercentageOfOwnership)) + '%') " 
                + "AND   (@OrganizationName IS NULL OR @OrganizationName = '' OR [DimOrganization].[OrganizationName] LIKE LTRIM(RTRIM(@OrganizationName)) + '%') " 
                + "AND   (@CurrencyName112 IS NULL OR @CurrencyName112 = '' OR [A112].[CurrencyName] LIKE LTRIM(RTRIM(@CurrencyName112)) + '%') " 
                + "";
        } else if  (sCondition == "More than...") {
            selectStatement
                = "SELECT "
            + "     [dbo].[DimOrganization].[OrganizationKey] "
            + "    ,[A109].[OrganizationName]"
            + "    ,[dbo].[DimOrganization].[PercentageOfOwnership] "
            + "    ,[dbo].[DimOrganization].[OrganizationName] "
            + "    ,[A112].[CurrencyName]"
            + "FROM " 
            + "     [dbo].[DimOrganization] " 
            + "LEFT JOIN [dbo].[DimOrganization] as [A109] ON [dbo].[DimOrganization].[ParentOrganizationKey] = [A109].[OrganizationKey] "
            + "LEFT JOIN [dbo].[DimCurrency] as [A112] ON [dbo].[DimOrganization].[CurrencyKey] = [A112].[CurrencyKey] "
                + "WHERE " 
                + "     (@OrganizationKey IS NULL OR @OrganizationKey = '' OR [DimOrganization].[OrganizationKey] > LTRIM(RTRIM(@OrganizationKey))) " 
                + "AND   (@OrganizationName109 IS NULL OR @OrganizationName109 = '' OR [A109].[OrganizationName] > LTRIM(RTRIM(@OrganizationName109))) " 
                + "AND   (@PercentageOfOwnership IS NULL OR @PercentageOfOwnership = '' OR [DimOrganization].[PercentageOfOwnership] > LTRIM(RTRIM(@PercentageOfOwnership))) " 
                + "AND   (@OrganizationName IS NULL OR @OrganizationName = '' OR [DimOrganization].[OrganizationName] > LTRIM(RTRIM(@OrganizationName))) " 
                + "AND   (@CurrencyName112 IS NULL OR @CurrencyName112 = '' OR [A112].[CurrencyName] > LTRIM(RTRIM(@CurrencyName112))) " 
                + "";
        } else if  (sCondition == "Less than...") {
            selectStatement
                = "SELECT " 
            + "     [dbo].[DimOrganization].[OrganizationKey] "
            + "    ,[A109].[OrganizationName]"
            + "    ,[dbo].[DimOrganization].[PercentageOfOwnership] "
            + "    ,[dbo].[DimOrganization].[OrganizationName] "
            + "    ,[A112].[CurrencyName]"
            + "FROM " 
            + "     [dbo].[DimOrganization] " 
            + "LEFT JOIN [dbo].[DimOrganization] as [A109] ON [dbo].[DimOrganization].[ParentOrganizationKey] = [A109].[OrganizationKey] "
            + "LEFT JOIN [dbo].[DimCurrency] as [A112] ON [dbo].[DimOrganization].[CurrencyKey] = [A112].[CurrencyKey] "
                + "WHERE " 
                + "     (@OrganizationKey IS NULL OR @OrganizationKey = '' OR [DimOrganization].[OrganizationKey] < LTRIM(RTRIM(@OrganizationKey))) " 
                + "AND   (@OrganizationName109 IS NULL OR @OrganizationName109 = '' OR [A109].[OrganizationName] < LTRIM(RTRIM(@OrganizationName109))) " 
                + "AND   (@PercentageOfOwnership IS NULL OR @PercentageOfOwnership = '' OR [DimOrganization].[PercentageOfOwnership] < LTRIM(RTRIM(@PercentageOfOwnership))) " 
                + "AND   (@OrganizationName IS NULL OR @OrganizationName = '' OR [DimOrganization].[OrganizationName] < LTRIM(RTRIM(@OrganizationName))) " 
                + "AND   (@CurrencyName112 IS NULL OR @CurrencyName112 = '' OR [A112].[CurrencyName] < LTRIM(RTRIM(@CurrencyName112))) " 
                + "";
        } else if  (sCondition == "Equal or more than...") {
            selectStatement
                = "SELECT "
            + "     [dbo].[DimOrganization].[OrganizationKey] "
            + "    ,[A109].[OrganizationName]"
            + "    ,[dbo].[DimOrganization].[PercentageOfOwnership] "
            + "    ,[dbo].[DimOrganization].[OrganizationName] "
            + "    ,[A112].[CurrencyName]"
            + "FROM " 
            + "     [dbo].[DimOrganization] " 
            + "LEFT JOIN [dbo].[DimOrganization] as [A109] ON [dbo].[DimOrganization].[ParentOrganizationKey] = [A109].[OrganizationKey] "
            + "LEFT JOIN [dbo].[DimCurrency] as [A112] ON [dbo].[DimOrganization].[CurrencyKey] = [A112].[CurrencyKey] "
                + "WHERE " 
                + "     (@OrganizationKey IS NULL OR @OrganizationKey = '' OR [DimOrganization].[OrganizationKey] >= LTRIM(RTRIM(@OrganizationKey))) " 
                + "AND   (@OrganizationName109 IS NULL OR @OrganizationName109 = '' OR [A109].[OrganizationName] >= LTRIM(RTRIM(@OrganizationName109))) " 
                + "AND   (@PercentageOfOwnership IS NULL OR @PercentageOfOwnership = '' OR [DimOrganization].[PercentageOfOwnership] >= LTRIM(RTRIM(@PercentageOfOwnership))) " 
                + "AND   (@OrganizationName IS NULL OR @OrganizationName = '' OR [DimOrganization].[OrganizationName] >= LTRIM(RTRIM(@OrganizationName))) " 
                + "AND   (@CurrencyName112 IS NULL OR @CurrencyName112 = '' OR [A112].[CurrencyName] >= LTRIM(RTRIM(@CurrencyName112))) " 
                + "";
        } else if (sCondition == "Equal or less than...") {
            selectStatement 
                = "SELECT "
            + "     [dbo].[DimOrganization].[OrganizationKey] "
            + "    ,[A109].[OrganizationName]"
            + "    ,[dbo].[DimOrganization].[PercentageOfOwnership] "
            + "    ,[dbo].[DimOrganization].[OrganizationName] "
            + "    ,[A112].[CurrencyName]"
            + "FROM " 
            + "     [dbo].[DimOrganization] " 
            + "LEFT JOIN [dbo].[DimOrganization] as [A109] ON [dbo].[DimOrganization].[ParentOrganizationKey] = [A109].[OrganizationKey] "
            + "LEFT JOIN [dbo].[DimCurrency] as [A112] ON [dbo].[DimOrganization].[CurrencyKey] = [A112].[CurrencyKey] "
                + "WHERE " 
                + "     (@OrganizationKey IS NULL OR @OrganizationKey = '' OR [DimOrganization].[OrganizationKey] <= LTRIM(RTRIM(@OrganizationKey))) " 
                + "AND   (@OrganizationName109 IS NULL OR @OrganizationName109 = '' OR [A109].[OrganizationName] <= LTRIM(RTRIM(@OrganizationName109))) " 
                + "AND   (@PercentageOfOwnership IS NULL OR @PercentageOfOwnership = '' OR [DimOrganization].[PercentageOfOwnership] <= LTRIM(RTRIM(@PercentageOfOwnership))) " 
                + "AND   (@OrganizationName IS NULL OR @OrganizationName = '' OR [DimOrganization].[OrganizationName] <= LTRIM(RTRIM(@OrganizationName))) " 
                + "AND   (@CurrencyName112 IS NULL OR @CurrencyName112 = '' OR [A112].[CurrencyName] <= LTRIM(RTRIM(@CurrencyName112))) " 
                + "";
        }
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        selectCommand.CommandType = CommandType.Text;
        if (sField == "Organization Key") {
            selectCommand.Parameters.AddWithValue("@OrganizationKey", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@OrganizationKey", DBNull.Value); }
        if (sField == "Parent Organization Key") {
            selectCommand.Parameters.AddWithValue("@OrganizationName109", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@OrganizationName109", DBNull.Value); }
        if (sField == "Percentage Of Ownership") {
            selectCommand.Parameters.AddWithValue("@PercentageOfOwnership", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@PercentageOfOwnership", DBNull.Value); }
        if (sField == "Organization Name") {
            selectCommand.Parameters.AddWithValue("@OrganizationName", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@OrganizationName", DBNull.Value); }
        if (sField == "Currency Key") {
            selectCommand.Parameters.AddWithValue("@CurrencyName112", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@CurrencyName112", DBNull.Value); }
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

    public static dbo_DimOrganizationClass Select_Record(dbo_DimOrganizationClass clsdbo_DimOrganizationPara)
    {
        dbo_DimOrganizationClass clsdbo_DimOrganization = new dbo_DimOrganizationClass();
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement
            = "SELECT " 
            + "     [OrganizationKey] "
            + "    ,[ParentOrganizationKey] "
            + "    ,[PercentageOfOwnership] "
            + "    ,[OrganizationName] "
            + "    ,[CurrencyKey] "
            + "FROM "
            + "     [dbo].[DimOrganization] "
            + "WHERE "
            + "     [OrganizationKey] = @OrganizationKey "
            + "";
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        selectCommand.CommandType = CommandType.Text;
        selectCommand.Parameters.AddWithValue("@OrganizationKey", clsdbo_DimOrganizationPara.OrganizationKey);
        try
        {
            connection.Open();
            SqlDataReader reader
                = selectCommand.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                clsdbo_DimOrganization.OrganizationKey = System.Convert.ToInt32(reader["OrganizationKey"]);
                clsdbo_DimOrganization.ParentOrganizationKey = reader["ParentOrganizationKey"] is DBNull ? null : (Int32?)reader["ParentOrganizationKey"];
                clsdbo_DimOrganization.PercentageOfOwnership = reader["PercentageOfOwnership"] is DBNull ? null : reader["PercentageOfOwnership"].ToString();
                clsdbo_DimOrganization.OrganizationName = reader["OrganizationName"] is DBNull ? null : reader["OrganizationName"].ToString();
                clsdbo_DimOrganization.CurrencyKey = reader["CurrencyKey"] is DBNull ? null : (Int32?)reader["CurrencyKey"];
            }
            else
            {
                clsdbo_DimOrganization = null;
            }
            reader.Close();
        }
        catch (SqlException)
        {
            return clsdbo_DimOrganization;
        }
        finally
        {
            connection.Close();
        }
        return clsdbo_DimOrganization;
    }

    public static bool Add(dbo_DimOrganizationClass clsdbo_DimOrganization)
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string insertStatement
            = "INSERT " 
            + "     [dbo].[DimOrganization] "
            + "     ( "
            + "     [ParentOrganizationKey] "
            + "    ,[PercentageOfOwnership] "
            + "    ,[OrganizationName] "
            + "    ,[CurrencyKey] "
            + "     ) "
            + "VALUES " 
            + "     ( "
            + "     @ParentOrganizationKey "
            + "    ,@PercentageOfOwnership "
            + "    ,@OrganizationName "
            + "    ,@CurrencyKey "
            + "     ) "
            + "";
        SqlCommand insertCommand = new SqlCommand(insertStatement, connection);
        insertCommand.CommandType = CommandType.Text;
        if (clsdbo_DimOrganization.ParentOrganizationKey.HasValue == true) {
            insertCommand.Parameters.AddWithValue("@ParentOrganizationKey", clsdbo_DimOrganization.ParentOrganizationKey);
        } else {
            insertCommand.Parameters.AddWithValue("@ParentOrganizationKey", DBNull.Value); }
        if (clsdbo_DimOrganization.PercentageOfOwnership != null) {
            insertCommand.Parameters.AddWithValue("@PercentageOfOwnership", clsdbo_DimOrganization.PercentageOfOwnership);
        } else {
            insertCommand.Parameters.AddWithValue("@PercentageOfOwnership", DBNull.Value); }
        if (clsdbo_DimOrganization.OrganizationName != null) {
            insertCommand.Parameters.AddWithValue("@OrganizationName", clsdbo_DimOrganization.OrganizationName);
        } else {
            insertCommand.Parameters.AddWithValue("@OrganizationName", DBNull.Value); }
        if (clsdbo_DimOrganization.CurrencyKey.HasValue == true) {
            insertCommand.Parameters.AddWithValue("@CurrencyKey", clsdbo_DimOrganization.CurrencyKey);
        } else {
            insertCommand.Parameters.AddWithValue("@CurrencyKey", DBNull.Value); }
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

    public static bool Update(dbo_DimOrganizationClass olddbo_DimOrganizationClass, 
           dbo_DimOrganizationClass newdbo_DimOrganizationClass)
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string updateStatement
            = "UPDATE "  
            + "     [dbo].[DimOrganization] "
            + "SET "
            + "     [ParentOrganizationKey] = @NewParentOrganizationKey "
            + "    ,[PercentageOfOwnership] = @NewPercentageOfOwnership "
            + "    ,[OrganizationName] = @NewOrganizationName "
            + "    ,[CurrencyKey] = @NewCurrencyKey "
            + "WHERE "
            + "     [OrganizationKey] = @OldOrganizationKey " 
            + " AND ((@OldParentOrganizationKey IS NULL AND [ParentOrganizationKey] IS NULL) OR [ParentOrganizationKey] = @OldParentOrganizationKey) " 
            + " AND ((@OldPercentageOfOwnership IS NULL AND [PercentageOfOwnership] IS NULL) OR [PercentageOfOwnership] = @OldPercentageOfOwnership) " 
            + " AND ((@OldOrganizationName IS NULL AND [OrganizationName] IS NULL) OR [OrganizationName] = @OldOrganizationName) " 
            + " AND ((@OldCurrencyKey IS NULL AND [CurrencyKey] IS NULL) OR [CurrencyKey] = @OldCurrencyKey) " 
            + "";
        SqlCommand updateCommand = new SqlCommand(updateStatement, connection);
        updateCommand.CommandType = CommandType.Text;
        if (newdbo_DimOrganizationClass.ParentOrganizationKey.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@NewParentOrganizationKey", newdbo_DimOrganizationClass.ParentOrganizationKey);
        } else {
            updateCommand.Parameters.AddWithValue("@NewParentOrganizationKey", DBNull.Value); }
        if (newdbo_DimOrganizationClass.PercentageOfOwnership != null) {
            updateCommand.Parameters.AddWithValue("@NewPercentageOfOwnership", newdbo_DimOrganizationClass.PercentageOfOwnership);
        } else {
            updateCommand.Parameters.AddWithValue("@NewPercentageOfOwnership", DBNull.Value); }
        if (newdbo_DimOrganizationClass.OrganizationName != null) {
            updateCommand.Parameters.AddWithValue("@NewOrganizationName", newdbo_DimOrganizationClass.OrganizationName);
        } else {
            updateCommand.Parameters.AddWithValue("@NewOrganizationName", DBNull.Value); }
        if (newdbo_DimOrganizationClass.CurrencyKey.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@NewCurrencyKey", newdbo_DimOrganizationClass.CurrencyKey);
        } else {
            updateCommand.Parameters.AddWithValue("@NewCurrencyKey", DBNull.Value); }
        updateCommand.Parameters.AddWithValue("@OldOrganizationKey", olddbo_DimOrganizationClass.OrganizationKey);
        if (olddbo_DimOrganizationClass.ParentOrganizationKey.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@OldParentOrganizationKey", olddbo_DimOrganizationClass.ParentOrganizationKey);
        } else {
            updateCommand.Parameters.AddWithValue("@OldParentOrganizationKey", DBNull.Value); }
        if (olddbo_DimOrganizationClass.PercentageOfOwnership != null) {
            updateCommand.Parameters.AddWithValue("@OldPercentageOfOwnership", olddbo_DimOrganizationClass.PercentageOfOwnership);
        } else {
            updateCommand.Parameters.AddWithValue("@OldPercentageOfOwnership", DBNull.Value); }
        if (olddbo_DimOrganizationClass.OrganizationName != null) {
            updateCommand.Parameters.AddWithValue("@OldOrganizationName", olddbo_DimOrganizationClass.OrganizationName);
        } else {
            updateCommand.Parameters.AddWithValue("@OldOrganizationName", DBNull.Value); }
        if (olddbo_DimOrganizationClass.CurrencyKey.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@OldCurrencyKey", olddbo_DimOrganizationClass.CurrencyKey);
        } else {
            updateCommand.Parameters.AddWithValue("@OldCurrencyKey", DBNull.Value); }
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

    public static bool Delete(dbo_DimOrganizationClass clsdbo_DimOrganization)
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string deleteStatement
            = "DELETE FROM "  
            + "     [dbo].[DimOrganization] "
            + "WHERE " 
            + "     [OrganizationKey] = @OldOrganizationKey " 
            + " AND ((@OldParentOrganizationKey IS NULL AND [ParentOrganizationKey] IS NULL) OR [ParentOrganizationKey] = @OldParentOrganizationKey) " 
            + " AND ((@OldPercentageOfOwnership IS NULL AND [PercentageOfOwnership] IS NULL) OR [PercentageOfOwnership] = @OldPercentageOfOwnership) " 
            + " AND ((@OldOrganizationName IS NULL AND [OrganizationName] IS NULL) OR [OrganizationName] = @OldOrganizationName) " 
            + " AND ((@OldCurrencyKey IS NULL AND [CurrencyKey] IS NULL) OR [CurrencyKey] = @OldCurrencyKey) " 
            + "";
        SqlCommand deleteCommand = new SqlCommand(deleteStatement, connection);
        deleteCommand.CommandType = CommandType.Text;
        deleteCommand.Parameters.AddWithValue("@OldOrganizationKey", clsdbo_DimOrganization.OrganizationKey);
        if (clsdbo_DimOrganization.ParentOrganizationKey.HasValue == true) {
            deleteCommand.Parameters.AddWithValue("@OldParentOrganizationKey", clsdbo_DimOrganization.ParentOrganizationKey);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldParentOrganizationKey", DBNull.Value); }
        if (clsdbo_DimOrganization.PercentageOfOwnership != null) {
            deleteCommand.Parameters.AddWithValue("@OldPercentageOfOwnership", clsdbo_DimOrganization.PercentageOfOwnership);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldPercentageOfOwnership", DBNull.Value); }
        if (clsdbo_DimOrganization.OrganizationName != null) {
            deleteCommand.Parameters.AddWithValue("@OldOrganizationName", clsdbo_DimOrganization.OrganizationName);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldOrganizationName", DBNull.Value); }
        if (clsdbo_DimOrganization.CurrencyKey.HasValue == true) {
            deleteCommand.Parameters.AddWithValue("@OldCurrencyKey", clsdbo_DimOrganization.CurrencyKey);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldCurrencyKey", DBNull.Value); }
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

 
