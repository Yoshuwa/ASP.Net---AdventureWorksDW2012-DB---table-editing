using System;
using System.Data;
using System.Data.SqlClient;

public class dbo_AdventureWorksDWBuildVersionDataClass
{

    public static DataTable SelectAll()
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement
            = "SELECT "  
            + "     [dbo].[AdventureWorksDWBuildVersion].[DBVersion] "
            + "    ,[dbo].[AdventureWorksDWBuildVersion].[VersionDate] "
            + "FROM " 
            + "     [dbo].[AdventureWorksDWBuildVersion] " 
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
            + "     [dbo].[AdventureWorksDWBuildVersion].[DBVersion] "
            + "    ,[dbo].[AdventureWorksDWBuildVersion].[VersionDate] "
            + "FROM " 
            + "     [dbo].[AdventureWorksDWBuildVersion] " 
                + "WHERE " 
                + "     (@DBVersion IS NULL OR @DBVersion = '' OR [AdventureWorksDWBuildVersion].[DBVersion] LIKE '%' + LTRIM(RTRIM(@DBVersion)) + '%') " 
                + "AND   (@VersionDate IS NULL OR @VersionDate = '' OR [AdventureWorksDWBuildVersion].[VersionDate] LIKE '%' + LTRIM(RTRIM(@VersionDate)) + '%') " 
                + "";
        } else if (sCondition == "Equals") {
            selectStatement
                = "SELECT "
            + "     [dbo].[AdventureWorksDWBuildVersion].[DBVersion] "
            + "    ,[dbo].[AdventureWorksDWBuildVersion].[VersionDate] "
            + "FROM " 
            + "     [dbo].[AdventureWorksDWBuildVersion] " 
                + "WHERE " 
                + "     (@DBVersion IS NULL OR @DBVersion = '' OR [AdventureWorksDWBuildVersion].[DBVersion] = LTRIM(RTRIM(@DBVersion))) " 
                + "AND   (@VersionDate IS NULL OR @VersionDate = '' OR [AdventureWorksDWBuildVersion].[VersionDate] = LTRIM(RTRIM(@VersionDate))) " 
                + "";
        } else if  (sCondition == "Starts with...") {
            selectStatement
                = "SELECT "
            + "     [dbo].[AdventureWorksDWBuildVersion].[DBVersion] "
            + "    ,[dbo].[AdventureWorksDWBuildVersion].[VersionDate] "
            + "FROM " 
            + "     [dbo].[AdventureWorksDWBuildVersion] " 
                + "WHERE " 
                + "     (@DBVersion IS NULL OR @DBVersion = '' OR [AdventureWorksDWBuildVersion].[DBVersion] LIKE LTRIM(RTRIM(@DBVersion)) + '%') " 
                + "AND   (@VersionDate IS NULL OR @VersionDate = '' OR [AdventureWorksDWBuildVersion].[VersionDate] LIKE LTRIM(RTRIM(@VersionDate)) + '%') " 
                + "";
        } else if  (sCondition == "More than...") {
            selectStatement
                = "SELECT "
            + "     [dbo].[AdventureWorksDWBuildVersion].[DBVersion] "
            + "    ,[dbo].[AdventureWorksDWBuildVersion].[VersionDate] "
            + "FROM " 
            + "     [dbo].[AdventureWorksDWBuildVersion] " 
                + "WHERE " 
                + "     (@DBVersion IS NULL OR @DBVersion = '' OR [AdventureWorksDWBuildVersion].[DBVersion] > LTRIM(RTRIM(@DBVersion))) " 
                + "AND   (@VersionDate IS NULL OR @VersionDate = '' OR [AdventureWorksDWBuildVersion].[VersionDate] > LTRIM(RTRIM(@VersionDate))) " 
                + "";
        } else if  (sCondition == "Less than...") {
            selectStatement
                = "SELECT " 
            + "     [dbo].[AdventureWorksDWBuildVersion].[DBVersion] "
            + "    ,[dbo].[AdventureWorksDWBuildVersion].[VersionDate] "
            + "FROM " 
            + "     [dbo].[AdventureWorksDWBuildVersion] " 
                + "WHERE " 
                + "     (@DBVersion IS NULL OR @DBVersion = '' OR [AdventureWorksDWBuildVersion].[DBVersion] < LTRIM(RTRIM(@DBVersion))) " 
                + "AND   (@VersionDate IS NULL OR @VersionDate = '' OR [AdventureWorksDWBuildVersion].[VersionDate] < LTRIM(RTRIM(@VersionDate))) " 
                + "";
        } else if  (sCondition == "Equal or more than...") {
            selectStatement
                = "SELECT "
            + "     [dbo].[AdventureWorksDWBuildVersion].[DBVersion] "
            + "    ,[dbo].[AdventureWorksDWBuildVersion].[VersionDate] "
            + "FROM " 
            + "     [dbo].[AdventureWorksDWBuildVersion] " 
                + "WHERE " 
                + "     (@DBVersion IS NULL OR @DBVersion = '' OR [AdventureWorksDWBuildVersion].[DBVersion] >= LTRIM(RTRIM(@DBVersion))) " 
                + "AND   (@VersionDate IS NULL OR @VersionDate = '' OR [AdventureWorksDWBuildVersion].[VersionDate] >= LTRIM(RTRIM(@VersionDate))) " 
                + "";
        } else if (sCondition == "Equal or less than...") {
            selectStatement 
                = "SELECT "
            + "     [dbo].[AdventureWorksDWBuildVersion].[DBVersion] "
            + "    ,[dbo].[AdventureWorksDWBuildVersion].[VersionDate] "
            + "FROM " 
            + "     [dbo].[AdventureWorksDWBuildVersion] " 
                + "WHERE " 
                + "     (@DBVersion IS NULL OR @DBVersion = '' OR [AdventureWorksDWBuildVersion].[DBVersion] <= LTRIM(RTRIM(@DBVersion))) " 
                + "AND   (@VersionDate IS NULL OR @VersionDate = '' OR [AdventureWorksDWBuildVersion].[VersionDate] <= LTRIM(RTRIM(@VersionDate))) " 
                + "";
        }
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        selectCommand.CommandType = CommandType.Text;
        if (sField == "D B Version") {
            selectCommand.Parameters.AddWithValue("@DBVersion", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@DBVersion", DBNull.Value); }
        if (sField == "Version Date") {
            selectCommand.Parameters.AddWithValue("@VersionDate", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@VersionDate", DBNull.Value); }
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

    public static dbo_AdventureWorksDWBuildVersionClass Select_Record(dbo_AdventureWorksDWBuildVersionClass clsdbo_AdventureWorksDWBuildVersionPara)
    {
        dbo_AdventureWorksDWBuildVersionClass clsdbo_AdventureWorksDWBuildVersion = new dbo_AdventureWorksDWBuildVersionClass();
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement
            = "SELECT " 
            + "     [DBVersion] "
            + "    ,[VersionDate] "
            + "FROM "
            + "     [dbo].[AdventureWorksDWBuildVersion] "
            + "WHERE "
            + "    [DBVersion] = @DBVersion "
            + "";
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        selectCommand.CommandType = CommandType.Text;
        selectCommand.Parameters.AddWithValue("@DBVersion", clsdbo_AdventureWorksDWBuildVersionPara.DBVersion);
        try
        {
            connection.Open();
            SqlDataReader reader
                = selectCommand.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                clsdbo_AdventureWorksDWBuildVersion.DBVersion = reader["DBVersion"] is DBNull ? null : reader["DBVersion"].ToString();
                clsdbo_AdventureWorksDWBuildVersion.VersionDate = reader["VersionDate"] is DBNull ? null : (DateTime?)reader["VersionDate"];
            }
            else
            {
                clsdbo_AdventureWorksDWBuildVersion = null;
            }
            reader.Close();
        }
        catch (SqlException)
        {
            return clsdbo_AdventureWorksDWBuildVersion;
        }
        finally
        {
            connection.Close();
        }
        return clsdbo_AdventureWorksDWBuildVersion;
    }

    public static bool Add(dbo_AdventureWorksDWBuildVersionClass clsdbo_AdventureWorksDWBuildVersion)
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string insertStatement
            = "INSERT " 
            + "     [dbo].[AdventureWorksDWBuildVersion] "
            + "     ( "
            + "     [DBVersion] "
            + "    ,[VersionDate] "
            + "     ) "
            + "VALUES " 
            + "     ( "
            + "     @DBVersion "
            + "    ,@VersionDate "
            + "     ) "
            + "";
        SqlCommand insertCommand = new SqlCommand(insertStatement, connection);
        insertCommand.CommandType = CommandType.Text;
        if (clsdbo_AdventureWorksDWBuildVersion.DBVersion != null) {
            insertCommand.Parameters.AddWithValue("@DBVersion", clsdbo_AdventureWorksDWBuildVersion.DBVersion);
        } else {
            insertCommand.Parameters.AddWithValue("@DBVersion", DBNull.Value); }
        if (clsdbo_AdventureWorksDWBuildVersion.VersionDate.HasValue == true) {
            insertCommand.Parameters.AddWithValue("@VersionDate", clsdbo_AdventureWorksDWBuildVersion.VersionDate);
        } else {
            insertCommand.Parameters.AddWithValue("@VersionDate", DBNull.Value); }
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

    public static bool Update(dbo_AdventureWorksDWBuildVersionClass olddbo_AdventureWorksDWBuildVersionClass, 
           dbo_AdventureWorksDWBuildVersionClass newdbo_AdventureWorksDWBuildVersionClass)
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string updateStatement
            = "UPDATE "  
            + "     [dbo].[AdventureWorksDWBuildVersion] "
            + "SET "
            + "     [DBVersion] = @NewDBVersion "
            + "    ,[VersionDate] = @NewVersionDate "
            + "WHERE "
            + "     ((@OldDBVersion IS NULL AND [DBVersion] IS NULL) OR [DBVersion] = @OldDBVersion) " 
            + " AND ((@OldVersionDate IS NULL AND [VersionDate] IS NULL) OR [VersionDate] = @OldVersionDate) " 
            + "";
        SqlCommand updateCommand = new SqlCommand(updateStatement, connection);
        updateCommand.CommandType = CommandType.Text;
        if (newdbo_AdventureWorksDWBuildVersionClass.DBVersion != null) {
            updateCommand.Parameters.AddWithValue("@NewDBVersion", newdbo_AdventureWorksDWBuildVersionClass.DBVersion);
        } else {
            updateCommand.Parameters.AddWithValue("@NewDBVersion", DBNull.Value); }
        if (newdbo_AdventureWorksDWBuildVersionClass.VersionDate.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@NewVersionDate", newdbo_AdventureWorksDWBuildVersionClass.VersionDate);
        } else {
            updateCommand.Parameters.AddWithValue("@NewVersionDate", DBNull.Value); }
        if (olddbo_AdventureWorksDWBuildVersionClass.DBVersion != null) {
            updateCommand.Parameters.AddWithValue("@OldDBVersion", olddbo_AdventureWorksDWBuildVersionClass.DBVersion);
        } else {
            updateCommand.Parameters.AddWithValue("@OldDBVersion", DBNull.Value); }
        if (olddbo_AdventureWorksDWBuildVersionClass.VersionDate.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@OldVersionDate", olddbo_AdventureWorksDWBuildVersionClass.VersionDate);
        } else {
            updateCommand.Parameters.AddWithValue("@OldVersionDate", DBNull.Value); }
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

    public static bool Delete(dbo_AdventureWorksDWBuildVersionClass clsdbo_AdventureWorksDWBuildVersion)
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string deleteStatement
            = "DELETE FROM "  
            + "     [dbo].[AdventureWorksDWBuildVersion] "
            + "WHERE " 
            + "     ((@OldDBVersion IS NULL AND [DBVersion] IS NULL) OR [DBVersion] = @OldDBVersion) " 
            + " AND ((@OldVersionDate IS NULL AND [VersionDate] IS NULL) OR [VersionDate] = @OldVersionDate) " 
            + "";
        SqlCommand deleteCommand = new SqlCommand(deleteStatement, connection);
        deleteCommand.CommandType = CommandType.Text;
        if (clsdbo_AdventureWorksDWBuildVersion.DBVersion != null) {
            deleteCommand.Parameters.AddWithValue("@OldDBVersion", clsdbo_AdventureWorksDWBuildVersion.DBVersion);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldDBVersion", DBNull.Value); }
        if (clsdbo_AdventureWorksDWBuildVersion.VersionDate.HasValue == true) {
            deleteCommand.Parameters.AddWithValue("@OldVersionDate", clsdbo_AdventureWorksDWBuildVersion.VersionDate);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldVersionDate", DBNull.Value); }
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

 
