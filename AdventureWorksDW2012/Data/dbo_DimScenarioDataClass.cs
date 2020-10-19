using System;
using System.Data;
using System.Data.SqlClient;

public class dbo_DimScenarioDataClass
{

    public static DataTable SelectAll()
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement
            = "SELECT "  
            + "     [dbo].[DimScenario].[ScenarioKey] "
            + "    ,[dbo].[DimScenario].[ScenarioName] "
            + "FROM " 
            + "     [dbo].[DimScenario] " 
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
            + "     [dbo].[DimScenario].[ScenarioKey] "
            + "    ,[dbo].[DimScenario].[ScenarioName] "
            + "FROM " 
            + "     [dbo].[DimScenario] " 
                + "WHERE " 
                + "     (@ScenarioKey IS NULL OR @ScenarioKey = '' OR [DimScenario].[ScenarioKey] LIKE '%' + LTRIM(RTRIM(@ScenarioKey)) + '%') " 
                + "AND   (@ScenarioName IS NULL OR @ScenarioName = '' OR [DimScenario].[ScenarioName] LIKE '%' + LTRIM(RTRIM(@ScenarioName)) + '%') " 
                + "";
        } else if (sCondition == "Equals") {
            selectStatement
                = "SELECT "
            + "     [dbo].[DimScenario].[ScenarioKey] "
            + "    ,[dbo].[DimScenario].[ScenarioName] "
            + "FROM " 
            + "     [dbo].[DimScenario] " 
                + "WHERE " 
                + "     (@ScenarioKey IS NULL OR @ScenarioKey = '' OR [DimScenario].[ScenarioKey] = LTRIM(RTRIM(@ScenarioKey))) " 
                + "AND   (@ScenarioName IS NULL OR @ScenarioName = '' OR [DimScenario].[ScenarioName] = LTRIM(RTRIM(@ScenarioName))) " 
                + "";
        } else if  (sCondition == "Starts with...") {
            selectStatement
                = "SELECT "
            + "     [dbo].[DimScenario].[ScenarioKey] "
            + "    ,[dbo].[DimScenario].[ScenarioName] "
            + "FROM " 
            + "     [dbo].[DimScenario] " 
                + "WHERE " 
                + "     (@ScenarioKey IS NULL OR @ScenarioKey = '' OR [DimScenario].[ScenarioKey] LIKE LTRIM(RTRIM(@ScenarioKey)) + '%') " 
                + "AND   (@ScenarioName IS NULL OR @ScenarioName = '' OR [DimScenario].[ScenarioName] LIKE LTRIM(RTRIM(@ScenarioName)) + '%') " 
                + "";
        } else if  (sCondition == "More than...") {
            selectStatement
                = "SELECT "
            + "     [dbo].[DimScenario].[ScenarioKey] "
            + "    ,[dbo].[DimScenario].[ScenarioName] "
            + "FROM " 
            + "     [dbo].[DimScenario] " 
                + "WHERE " 
                + "     (@ScenarioKey IS NULL OR @ScenarioKey = '' OR [DimScenario].[ScenarioKey] > LTRIM(RTRIM(@ScenarioKey))) " 
                + "AND   (@ScenarioName IS NULL OR @ScenarioName = '' OR [DimScenario].[ScenarioName] > LTRIM(RTRIM(@ScenarioName))) " 
                + "";
        } else if  (sCondition == "Less than...") {
            selectStatement
                = "SELECT " 
            + "     [dbo].[DimScenario].[ScenarioKey] "
            + "    ,[dbo].[DimScenario].[ScenarioName] "
            + "FROM " 
            + "     [dbo].[DimScenario] " 
                + "WHERE " 
                + "     (@ScenarioKey IS NULL OR @ScenarioKey = '' OR [DimScenario].[ScenarioKey] < LTRIM(RTRIM(@ScenarioKey))) " 
                + "AND   (@ScenarioName IS NULL OR @ScenarioName = '' OR [DimScenario].[ScenarioName] < LTRIM(RTRIM(@ScenarioName))) " 
                + "";
        } else if  (sCondition == "Equal or more than...") {
            selectStatement
                = "SELECT "
            + "     [dbo].[DimScenario].[ScenarioKey] "
            + "    ,[dbo].[DimScenario].[ScenarioName] "
            + "FROM " 
            + "     [dbo].[DimScenario] " 
                + "WHERE " 
                + "     (@ScenarioKey IS NULL OR @ScenarioKey = '' OR [DimScenario].[ScenarioKey] >= LTRIM(RTRIM(@ScenarioKey))) " 
                + "AND   (@ScenarioName IS NULL OR @ScenarioName = '' OR [DimScenario].[ScenarioName] >= LTRIM(RTRIM(@ScenarioName))) " 
                + "";
        } else if (sCondition == "Equal or less than...") {
            selectStatement 
                = "SELECT "
            + "     [dbo].[DimScenario].[ScenarioKey] "
            + "    ,[dbo].[DimScenario].[ScenarioName] "
            + "FROM " 
            + "     [dbo].[DimScenario] " 
                + "WHERE " 
                + "     (@ScenarioKey IS NULL OR @ScenarioKey = '' OR [DimScenario].[ScenarioKey] <= LTRIM(RTRIM(@ScenarioKey))) " 
                + "AND   (@ScenarioName IS NULL OR @ScenarioName = '' OR [DimScenario].[ScenarioName] <= LTRIM(RTRIM(@ScenarioName))) " 
                + "";
        }
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        selectCommand.CommandType = CommandType.Text;
        if (sField == "Scenario Key") {
            selectCommand.Parameters.AddWithValue("@ScenarioKey", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@ScenarioKey", DBNull.Value); }
        if (sField == "Scenario Name") {
            selectCommand.Parameters.AddWithValue("@ScenarioName", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@ScenarioName", DBNull.Value); }
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

    public static dbo_DimScenarioClass Select_Record(dbo_DimScenarioClass clsdbo_DimScenarioPara)
    {
        dbo_DimScenarioClass clsdbo_DimScenario = new dbo_DimScenarioClass();
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement
            = "SELECT " 
            + "     [ScenarioKey] "
            + "    ,[ScenarioName] "
            + "FROM "
            + "     [dbo].[DimScenario] "
            + "WHERE "
            + "     [ScenarioKey] = @ScenarioKey "
            + "";
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        selectCommand.CommandType = CommandType.Text;
        selectCommand.Parameters.AddWithValue("@ScenarioKey", clsdbo_DimScenarioPara.ScenarioKey);
        try
        {
            connection.Open();
            SqlDataReader reader
                = selectCommand.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                clsdbo_DimScenario.ScenarioKey = System.Convert.ToInt32(reader["ScenarioKey"]);
                clsdbo_DimScenario.ScenarioName = reader["ScenarioName"] is DBNull ? null : reader["ScenarioName"].ToString();
            }
            else
            {
                clsdbo_DimScenario = null;
            }
            reader.Close();
        }
        catch (SqlException)
        {
            return clsdbo_DimScenario;
        }
        finally
        {
            connection.Close();
        }
        return clsdbo_DimScenario;
    }

    public static bool Add(dbo_DimScenarioClass clsdbo_DimScenario)
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string insertStatement
            = "INSERT " 
            + "     [dbo].[DimScenario] "
            + "     ( "
            + "     [ScenarioName] "
            + "     ) "
            + "VALUES " 
            + "     ( "
            + "     @ScenarioName "
            + "     ) "
            + "";
        SqlCommand insertCommand = new SqlCommand(insertStatement, connection);
        insertCommand.CommandType = CommandType.Text;
        if (clsdbo_DimScenario.ScenarioName != null) {
            insertCommand.Parameters.AddWithValue("@ScenarioName", clsdbo_DimScenario.ScenarioName);
        } else {
            insertCommand.Parameters.AddWithValue("@ScenarioName", DBNull.Value); }
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

    public static bool Update(dbo_DimScenarioClass olddbo_DimScenarioClass, 
           dbo_DimScenarioClass newdbo_DimScenarioClass)
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string updateStatement
            = "UPDATE "  
            + "     [dbo].[DimScenario] "
            + "SET "
            + "     [ScenarioName] = @NewScenarioName "
            + "WHERE "
            + "     [ScenarioKey] = @OldScenarioKey " 
            + " AND ((@OldScenarioName IS NULL AND [ScenarioName] IS NULL) OR [ScenarioName] = @OldScenarioName) " 
            + "";
        SqlCommand updateCommand = new SqlCommand(updateStatement, connection);
        updateCommand.CommandType = CommandType.Text;
        if (newdbo_DimScenarioClass.ScenarioName != null) {
            updateCommand.Parameters.AddWithValue("@NewScenarioName", newdbo_DimScenarioClass.ScenarioName);
        } else {
            updateCommand.Parameters.AddWithValue("@NewScenarioName", DBNull.Value); }
        updateCommand.Parameters.AddWithValue("@OldScenarioKey", olddbo_DimScenarioClass.ScenarioKey);
        if (olddbo_DimScenarioClass.ScenarioName != null) {
            updateCommand.Parameters.AddWithValue("@OldScenarioName", olddbo_DimScenarioClass.ScenarioName);
        } else {
            updateCommand.Parameters.AddWithValue("@OldScenarioName", DBNull.Value); }
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

    public static bool Delete(dbo_DimScenarioClass clsdbo_DimScenario)
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string deleteStatement
            = "DELETE FROM "  
            + "     [dbo].[DimScenario] "
            + "WHERE " 
            + "     [ScenarioKey] = @OldScenarioKey " 
            + " AND ((@OldScenarioName IS NULL AND [ScenarioName] IS NULL) OR [ScenarioName] = @OldScenarioName) " 
            + "";
        SqlCommand deleteCommand = new SqlCommand(deleteStatement, connection);
        deleteCommand.CommandType = CommandType.Text;
        deleteCommand.Parameters.AddWithValue("@OldScenarioKey", clsdbo_DimScenario.ScenarioKey);
        if (clsdbo_DimScenario.ScenarioName != null) {
            deleteCommand.Parameters.AddWithValue("@OldScenarioName", clsdbo_DimScenario.ScenarioName);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldScenarioName", DBNull.Value); }
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

 
