using System;
using System.Data;
using System.Data.SqlClient;

public class dbo_DimDepartmentGroupDataClass
{

    public static DataTable SelectAll()
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement
            = "SELECT "  
            + "     [dbo].[DimDepartmentGroup].[DepartmentGroupKey] "
            + "    ,[A65].[DepartmentGroupName] "
            + "    ,[dbo].[DimDepartmentGroup].[DepartmentGroupName] "
            + "FROM " 
            + "     [dbo].[DimDepartmentGroup] " 
            + "LEFT JOIN [dbo].[DimDepartmentGroup] as [A65] ON [dbo].[DimDepartmentGroup].[ParentDepartmentGroupKey] = [A65].[DepartmentGroupKey] "
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
            + "     [dbo].[DimDepartmentGroup].[DepartmentGroupKey] "
            + "    ,[A65].[DepartmentGroupName]"
            + "    ,[dbo].[DimDepartmentGroup].[DepartmentGroupName] "
            + "FROM " 
            + "     [dbo].[DimDepartmentGroup] " 
            + "LEFT JOIN [dbo].[DimDepartmentGroup] as [A65] ON [dbo].[DimDepartmentGroup].[ParentDepartmentGroupKey] = [A65].[DepartmentGroupKey] "
                + "WHERE " 
                + "     (@DepartmentGroupKey IS NULL OR @DepartmentGroupKey = '' OR [DimDepartmentGroup].[DepartmentGroupKey] LIKE '%' + LTRIM(RTRIM(@DepartmentGroupKey)) + '%') " 
                + "AND   (@DepartmentGroupName65 IS NULL OR @DepartmentGroupName65 = '' OR [A65].[DepartmentGroupName] LIKE '%' + LTRIM(RTRIM(@DepartmentGroupName65)) + '%') " 
                + "AND   (@DepartmentGroupName IS NULL OR @DepartmentGroupName = '' OR [DimDepartmentGroup].[DepartmentGroupName] LIKE '%' + LTRIM(RTRIM(@DepartmentGroupName)) + '%') " 
                + "";
        } else if (sCondition == "Equals") {
            selectStatement
                = "SELECT "
            + "     [dbo].[DimDepartmentGroup].[DepartmentGroupKey] "
            + "    ,[A65].[DepartmentGroupName]"
            + "    ,[dbo].[DimDepartmentGroup].[DepartmentGroupName] "
            + "FROM " 
            + "     [dbo].[DimDepartmentGroup] " 
            + "LEFT JOIN [dbo].[DimDepartmentGroup] as [A65] ON [dbo].[DimDepartmentGroup].[ParentDepartmentGroupKey] = [A65].[DepartmentGroupKey] "
                + "WHERE " 
                + "     (@DepartmentGroupKey IS NULL OR @DepartmentGroupKey = '' OR [DimDepartmentGroup].[DepartmentGroupKey] = LTRIM(RTRIM(@DepartmentGroupKey))) " 
                + "AND   (@DepartmentGroupName65 IS NULL OR @DepartmentGroupName65 = '' OR [A65].[DepartmentGroupName] = LTRIM(RTRIM(@DepartmentGroupName65))) " 
                + "AND   (@DepartmentGroupName IS NULL OR @DepartmentGroupName = '' OR [DimDepartmentGroup].[DepartmentGroupName] = LTRIM(RTRIM(@DepartmentGroupName))) " 
                + "";
        } else if  (sCondition == "Starts with...") {
            selectStatement
                = "SELECT "
            + "     [dbo].[DimDepartmentGroup].[DepartmentGroupKey] "
            + "    ,[A65].[DepartmentGroupName]"
            + "    ,[dbo].[DimDepartmentGroup].[DepartmentGroupName] "
            + "FROM " 
            + "     [dbo].[DimDepartmentGroup] " 
            + "LEFT JOIN [dbo].[DimDepartmentGroup] as [A65] ON [dbo].[DimDepartmentGroup].[ParentDepartmentGroupKey] = [A65].[DepartmentGroupKey] "
                + "WHERE " 
                + "     (@DepartmentGroupKey IS NULL OR @DepartmentGroupKey = '' OR [DimDepartmentGroup].[DepartmentGroupKey] LIKE LTRIM(RTRIM(@DepartmentGroupKey)) + '%') " 
                + "AND   (@DepartmentGroupName65 IS NULL OR @DepartmentGroupName65 = '' OR [A65].[DepartmentGroupName] LIKE LTRIM(RTRIM(@DepartmentGroupName65)) + '%') " 
                + "AND   (@DepartmentGroupName IS NULL OR @DepartmentGroupName = '' OR [DimDepartmentGroup].[DepartmentGroupName] LIKE LTRIM(RTRIM(@DepartmentGroupName)) + '%') " 
                + "";
        } else if  (sCondition == "More than...") {
            selectStatement
                = "SELECT "
            + "     [dbo].[DimDepartmentGroup].[DepartmentGroupKey] "
            + "    ,[A65].[DepartmentGroupName]"
            + "    ,[dbo].[DimDepartmentGroup].[DepartmentGroupName] "
            + "FROM " 
            + "     [dbo].[DimDepartmentGroup] " 
            + "LEFT JOIN [dbo].[DimDepartmentGroup] as [A65] ON [dbo].[DimDepartmentGroup].[ParentDepartmentGroupKey] = [A65].[DepartmentGroupKey] "
                + "WHERE " 
                + "     (@DepartmentGroupKey IS NULL OR @DepartmentGroupKey = '' OR [DimDepartmentGroup].[DepartmentGroupKey] > LTRIM(RTRIM(@DepartmentGroupKey))) " 
                + "AND   (@DepartmentGroupName65 IS NULL OR @DepartmentGroupName65 = '' OR [A65].[DepartmentGroupName] > LTRIM(RTRIM(@DepartmentGroupName65))) " 
                + "AND   (@DepartmentGroupName IS NULL OR @DepartmentGroupName = '' OR [DimDepartmentGroup].[DepartmentGroupName] > LTRIM(RTRIM(@DepartmentGroupName))) " 
                + "";
        } else if  (sCondition == "Less than...") {
            selectStatement
                = "SELECT " 
            + "     [dbo].[DimDepartmentGroup].[DepartmentGroupKey] "
            + "    ,[A65].[DepartmentGroupName]"
            + "    ,[dbo].[DimDepartmentGroup].[DepartmentGroupName] "
            + "FROM " 
            + "     [dbo].[DimDepartmentGroup] " 
            + "LEFT JOIN [dbo].[DimDepartmentGroup] as [A65] ON [dbo].[DimDepartmentGroup].[ParentDepartmentGroupKey] = [A65].[DepartmentGroupKey] "
                + "WHERE " 
                + "     (@DepartmentGroupKey IS NULL OR @DepartmentGroupKey = '' OR [DimDepartmentGroup].[DepartmentGroupKey] < LTRIM(RTRIM(@DepartmentGroupKey))) " 
                + "AND   (@DepartmentGroupName65 IS NULL OR @DepartmentGroupName65 = '' OR [A65].[DepartmentGroupName] < LTRIM(RTRIM(@DepartmentGroupName65))) " 
                + "AND   (@DepartmentGroupName IS NULL OR @DepartmentGroupName = '' OR [DimDepartmentGroup].[DepartmentGroupName] < LTRIM(RTRIM(@DepartmentGroupName))) " 
                + "";
        } else if  (sCondition == "Equal or more than...") {
            selectStatement
                = "SELECT "
            + "     [dbo].[DimDepartmentGroup].[DepartmentGroupKey] "
            + "    ,[A65].[DepartmentGroupName]"
            + "    ,[dbo].[DimDepartmentGroup].[DepartmentGroupName] "
            + "FROM " 
            + "     [dbo].[DimDepartmentGroup] " 
            + "LEFT JOIN [dbo].[DimDepartmentGroup] as [A65] ON [dbo].[DimDepartmentGroup].[ParentDepartmentGroupKey] = [A65].[DepartmentGroupKey] "
                + "WHERE " 
                + "     (@DepartmentGroupKey IS NULL OR @DepartmentGroupKey = '' OR [DimDepartmentGroup].[DepartmentGroupKey] >= LTRIM(RTRIM(@DepartmentGroupKey))) " 
                + "AND   (@DepartmentGroupName65 IS NULL OR @DepartmentGroupName65 = '' OR [A65].[DepartmentGroupName] >= LTRIM(RTRIM(@DepartmentGroupName65))) " 
                + "AND   (@DepartmentGroupName IS NULL OR @DepartmentGroupName = '' OR [DimDepartmentGroup].[DepartmentGroupName] >= LTRIM(RTRIM(@DepartmentGroupName))) " 
                + "";
        } else if (sCondition == "Equal or less than...") {
            selectStatement 
                = "SELECT "
            + "     [dbo].[DimDepartmentGroup].[DepartmentGroupKey] "
            + "    ,[A65].[DepartmentGroupName]"
            + "    ,[dbo].[DimDepartmentGroup].[DepartmentGroupName] "
            + "FROM " 
            + "     [dbo].[DimDepartmentGroup] " 
            + "LEFT JOIN [dbo].[DimDepartmentGroup] as [A65] ON [dbo].[DimDepartmentGroup].[ParentDepartmentGroupKey] = [A65].[DepartmentGroupKey] "
                + "WHERE " 
                + "     (@DepartmentGroupKey IS NULL OR @DepartmentGroupKey = '' OR [DimDepartmentGroup].[DepartmentGroupKey] <= LTRIM(RTRIM(@DepartmentGroupKey))) " 
                + "AND   (@DepartmentGroupName65 IS NULL OR @DepartmentGroupName65 = '' OR [A65].[DepartmentGroupName] <= LTRIM(RTRIM(@DepartmentGroupName65))) " 
                + "AND   (@DepartmentGroupName IS NULL OR @DepartmentGroupName = '' OR [DimDepartmentGroup].[DepartmentGroupName] <= LTRIM(RTRIM(@DepartmentGroupName))) " 
                + "";
        }
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        selectCommand.CommandType = CommandType.Text;
        if (sField == "Department Group Key") {
            selectCommand.Parameters.AddWithValue("@DepartmentGroupKey", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@DepartmentGroupKey", DBNull.Value); }
        if (sField == "Parent Department Group Key") {
            selectCommand.Parameters.AddWithValue("@DepartmentGroupName65", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@DepartmentGroupName65", DBNull.Value); }
        if (sField == "Department Group Name") {
            selectCommand.Parameters.AddWithValue("@DepartmentGroupName", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@DepartmentGroupName", DBNull.Value); }
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

    public static dbo_DimDepartmentGroupClass Select_Record(dbo_DimDepartmentGroupClass clsdbo_DimDepartmentGroupPara)
    {
        dbo_DimDepartmentGroupClass clsdbo_DimDepartmentGroup = new dbo_DimDepartmentGroupClass();
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement
            = "SELECT " 
            + "     [DepartmentGroupKey] "
            + "    ,[ParentDepartmentGroupKey] "
            + "    ,[DepartmentGroupName] "
            + "FROM "
            + "     [dbo].[DimDepartmentGroup] "
            + "WHERE "
            + "     [DepartmentGroupKey] = @DepartmentGroupKey "
            + "";
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        selectCommand.CommandType = CommandType.Text;
        selectCommand.Parameters.AddWithValue("@DepartmentGroupKey", clsdbo_DimDepartmentGroupPara.DepartmentGroupKey);
        try
        {
            connection.Open();
            SqlDataReader reader
                = selectCommand.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                clsdbo_DimDepartmentGroup.DepartmentGroupKey = System.Convert.ToInt32(reader["DepartmentGroupKey"]);
                clsdbo_DimDepartmentGroup.ParentDepartmentGroupKey = reader["ParentDepartmentGroupKey"] is DBNull ? null : (Int32?)reader["ParentDepartmentGroupKey"];
                clsdbo_DimDepartmentGroup.DepartmentGroupName = reader["DepartmentGroupName"] is DBNull ? null : reader["DepartmentGroupName"].ToString();
            }
            else
            {
                clsdbo_DimDepartmentGroup = null;
            }
            reader.Close();
        }
        catch (SqlException)
        {
            return clsdbo_DimDepartmentGroup;
        }
        finally
        {
            connection.Close();
        }
        return clsdbo_DimDepartmentGroup;
    }

    public static bool Add(dbo_DimDepartmentGroupClass clsdbo_DimDepartmentGroup)
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string insertStatement
            = "INSERT " 
            + "     [dbo].[DimDepartmentGroup] "
            + "     ( "
            + "     [ParentDepartmentGroupKey] "
            + "    ,[DepartmentGroupName] "
            + "     ) "
            + "VALUES " 
            + "     ( "
            + "     @ParentDepartmentGroupKey "
            + "    ,@DepartmentGroupName "
            + "     ) "
            + "";
        SqlCommand insertCommand = new SqlCommand(insertStatement, connection);
        insertCommand.CommandType = CommandType.Text;
        if (clsdbo_DimDepartmentGroup.ParentDepartmentGroupKey.HasValue == true) {
            insertCommand.Parameters.AddWithValue("@ParentDepartmentGroupKey", clsdbo_DimDepartmentGroup.ParentDepartmentGroupKey);
        } else {
            insertCommand.Parameters.AddWithValue("@ParentDepartmentGroupKey", DBNull.Value); }
        if (clsdbo_DimDepartmentGroup.DepartmentGroupName != null) {
            insertCommand.Parameters.AddWithValue("@DepartmentGroupName", clsdbo_DimDepartmentGroup.DepartmentGroupName);
        } else {
            insertCommand.Parameters.AddWithValue("@DepartmentGroupName", DBNull.Value); }
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

    public static bool Update(dbo_DimDepartmentGroupClass olddbo_DimDepartmentGroupClass, 
           dbo_DimDepartmentGroupClass newdbo_DimDepartmentGroupClass)
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string updateStatement
            = "UPDATE "  
            + "     [dbo].[DimDepartmentGroup] "
            + "SET "
            + "     [ParentDepartmentGroupKey] = @NewParentDepartmentGroupKey "
            + "    ,[DepartmentGroupName] = @NewDepartmentGroupName "
            + "WHERE "
            + "     [DepartmentGroupKey] = @OldDepartmentGroupKey " 
            + " AND ((@OldParentDepartmentGroupKey IS NULL AND [ParentDepartmentGroupKey] IS NULL) OR [ParentDepartmentGroupKey] = @OldParentDepartmentGroupKey) " 
            + " AND ((@OldDepartmentGroupName IS NULL AND [DepartmentGroupName] IS NULL) OR [DepartmentGroupName] = @OldDepartmentGroupName) " 
            + "";
        SqlCommand updateCommand = new SqlCommand(updateStatement, connection);
        updateCommand.CommandType = CommandType.Text;
        if (newdbo_DimDepartmentGroupClass.ParentDepartmentGroupKey.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@NewParentDepartmentGroupKey", newdbo_DimDepartmentGroupClass.ParentDepartmentGroupKey);
        } else {
            updateCommand.Parameters.AddWithValue("@NewParentDepartmentGroupKey", DBNull.Value); }
        if (newdbo_DimDepartmentGroupClass.DepartmentGroupName != null) {
            updateCommand.Parameters.AddWithValue("@NewDepartmentGroupName", newdbo_DimDepartmentGroupClass.DepartmentGroupName);
        } else {
            updateCommand.Parameters.AddWithValue("@NewDepartmentGroupName", DBNull.Value); }
        updateCommand.Parameters.AddWithValue("@OldDepartmentGroupKey", olddbo_DimDepartmentGroupClass.DepartmentGroupKey);
        if (olddbo_DimDepartmentGroupClass.ParentDepartmentGroupKey.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@OldParentDepartmentGroupKey", olddbo_DimDepartmentGroupClass.ParentDepartmentGroupKey);
        } else {
            updateCommand.Parameters.AddWithValue("@OldParentDepartmentGroupKey", DBNull.Value); }
        if (olddbo_DimDepartmentGroupClass.DepartmentGroupName != null) {
            updateCommand.Parameters.AddWithValue("@OldDepartmentGroupName", olddbo_DimDepartmentGroupClass.DepartmentGroupName);
        } else {
            updateCommand.Parameters.AddWithValue("@OldDepartmentGroupName", DBNull.Value); }
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

    public static bool Delete(dbo_DimDepartmentGroupClass clsdbo_DimDepartmentGroup)
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string deleteStatement
            = "DELETE FROM "  
            + "     [dbo].[DimDepartmentGroup] "
            + "WHERE " 
            + "     [DepartmentGroupKey] = @OldDepartmentGroupKey " 
            + " AND ((@OldParentDepartmentGroupKey IS NULL AND [ParentDepartmentGroupKey] IS NULL) OR [ParentDepartmentGroupKey] = @OldParentDepartmentGroupKey) " 
            + " AND ((@OldDepartmentGroupName IS NULL AND [DepartmentGroupName] IS NULL) OR [DepartmentGroupName] = @OldDepartmentGroupName) " 
            + "";
        SqlCommand deleteCommand = new SqlCommand(deleteStatement, connection);
        deleteCommand.CommandType = CommandType.Text;
        deleteCommand.Parameters.AddWithValue("@OldDepartmentGroupKey", clsdbo_DimDepartmentGroup.DepartmentGroupKey);
        if (clsdbo_DimDepartmentGroup.ParentDepartmentGroupKey.HasValue == true) {
            deleteCommand.Parameters.AddWithValue("@OldParentDepartmentGroupKey", clsdbo_DimDepartmentGroup.ParentDepartmentGroupKey);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldParentDepartmentGroupKey", DBNull.Value); }
        if (clsdbo_DimDepartmentGroup.DepartmentGroupName != null) {
            deleteCommand.Parameters.AddWithValue("@OldDepartmentGroupName", clsdbo_DimDepartmentGroup.DepartmentGroupName);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldDepartmentGroupName", DBNull.Value); }
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

 
