using System;
using System.Data;
using System.Data.SqlClient;

public class dbo_DimSalesReasonDataClass
{

    public static DataTable SelectAll()
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement
            = "SELECT "  
            + "     [dbo].[DimSalesReason].[SalesReasonKey] "
            + "    ,[dbo].[DimSalesReason].[SalesReasonAlternateKey] "
            + "    ,[dbo].[DimSalesReason].[SalesReasonName] "
            + "    ,[dbo].[DimSalesReason].[SalesReasonReasonType] "
            + "FROM " 
            + "     [dbo].[DimSalesReason] " 
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
            + "     [dbo].[DimSalesReason].[SalesReasonKey] "
            + "    ,[dbo].[DimSalesReason].[SalesReasonAlternateKey] "
            + "    ,[dbo].[DimSalesReason].[SalesReasonName] "
            + "    ,[dbo].[DimSalesReason].[SalesReasonReasonType] "
            + "FROM " 
            + "     [dbo].[DimSalesReason] " 
                + "WHERE " 
                + "     (@SalesReasonKey IS NULL OR @SalesReasonKey = '' OR [DimSalesReason].[SalesReasonKey] LIKE '%' + LTRIM(RTRIM(@SalesReasonKey)) + '%') " 
                + "AND   (@SalesReasonAlternateKey IS NULL OR @SalesReasonAlternateKey = '' OR [DimSalesReason].[SalesReasonAlternateKey] LIKE '%' + LTRIM(RTRIM(@SalesReasonAlternateKey)) + '%') " 
                + "AND   (@SalesReasonName IS NULL OR @SalesReasonName = '' OR [DimSalesReason].[SalesReasonName] LIKE '%' + LTRIM(RTRIM(@SalesReasonName)) + '%') " 
                + "AND   (@SalesReasonReasonType IS NULL OR @SalesReasonReasonType = '' OR [DimSalesReason].[SalesReasonReasonType] LIKE '%' + LTRIM(RTRIM(@SalesReasonReasonType)) + '%') " 
                + "";
        } else if (sCondition == "Equals") {
            selectStatement
                = "SELECT "
            + "     [dbo].[DimSalesReason].[SalesReasonKey] "
            + "    ,[dbo].[DimSalesReason].[SalesReasonAlternateKey] "
            + "    ,[dbo].[DimSalesReason].[SalesReasonName] "
            + "    ,[dbo].[DimSalesReason].[SalesReasonReasonType] "
            + "FROM " 
            + "     [dbo].[DimSalesReason] " 
                + "WHERE " 
                + "     (@SalesReasonKey IS NULL OR @SalesReasonKey = '' OR [DimSalesReason].[SalesReasonKey] = LTRIM(RTRIM(@SalesReasonKey))) " 
                + "AND   (@SalesReasonAlternateKey IS NULL OR @SalesReasonAlternateKey = '' OR [DimSalesReason].[SalesReasonAlternateKey] = LTRIM(RTRIM(@SalesReasonAlternateKey))) " 
                + "AND   (@SalesReasonName IS NULL OR @SalesReasonName = '' OR [DimSalesReason].[SalesReasonName] = LTRIM(RTRIM(@SalesReasonName))) " 
                + "AND   (@SalesReasonReasonType IS NULL OR @SalesReasonReasonType = '' OR [DimSalesReason].[SalesReasonReasonType] = LTRIM(RTRIM(@SalesReasonReasonType))) " 
                + "";
        } else if  (sCondition == "Starts with...") {
            selectStatement
                = "SELECT "
            + "     [dbo].[DimSalesReason].[SalesReasonKey] "
            + "    ,[dbo].[DimSalesReason].[SalesReasonAlternateKey] "
            + "    ,[dbo].[DimSalesReason].[SalesReasonName] "
            + "    ,[dbo].[DimSalesReason].[SalesReasonReasonType] "
            + "FROM " 
            + "     [dbo].[DimSalesReason] " 
                + "WHERE " 
                + "     (@SalesReasonKey IS NULL OR @SalesReasonKey = '' OR [DimSalesReason].[SalesReasonKey] LIKE LTRIM(RTRIM(@SalesReasonKey)) + '%') " 
                + "AND   (@SalesReasonAlternateKey IS NULL OR @SalesReasonAlternateKey = '' OR [DimSalesReason].[SalesReasonAlternateKey] LIKE LTRIM(RTRIM(@SalesReasonAlternateKey)) + '%') " 
                + "AND   (@SalesReasonName IS NULL OR @SalesReasonName = '' OR [DimSalesReason].[SalesReasonName] LIKE LTRIM(RTRIM(@SalesReasonName)) + '%') " 
                + "AND   (@SalesReasonReasonType IS NULL OR @SalesReasonReasonType = '' OR [DimSalesReason].[SalesReasonReasonType] LIKE LTRIM(RTRIM(@SalesReasonReasonType)) + '%') " 
                + "";
        } else if  (sCondition == "More than...") {
            selectStatement
                = "SELECT "
            + "     [dbo].[DimSalesReason].[SalesReasonKey] "
            + "    ,[dbo].[DimSalesReason].[SalesReasonAlternateKey] "
            + "    ,[dbo].[DimSalesReason].[SalesReasonName] "
            + "    ,[dbo].[DimSalesReason].[SalesReasonReasonType] "
            + "FROM " 
            + "     [dbo].[DimSalesReason] " 
                + "WHERE " 
                + "     (@SalesReasonKey IS NULL OR @SalesReasonKey = '' OR [DimSalesReason].[SalesReasonKey] > LTRIM(RTRIM(@SalesReasonKey))) " 
                + "AND   (@SalesReasonAlternateKey IS NULL OR @SalesReasonAlternateKey = '' OR [DimSalesReason].[SalesReasonAlternateKey] > LTRIM(RTRIM(@SalesReasonAlternateKey))) " 
                + "AND   (@SalesReasonName IS NULL OR @SalesReasonName = '' OR [DimSalesReason].[SalesReasonName] > LTRIM(RTRIM(@SalesReasonName))) " 
                + "AND   (@SalesReasonReasonType IS NULL OR @SalesReasonReasonType = '' OR [DimSalesReason].[SalesReasonReasonType] > LTRIM(RTRIM(@SalesReasonReasonType))) " 
                + "";
        } else if  (sCondition == "Less than...") {
            selectStatement
                = "SELECT " 
            + "     [dbo].[DimSalesReason].[SalesReasonKey] "
            + "    ,[dbo].[DimSalesReason].[SalesReasonAlternateKey] "
            + "    ,[dbo].[DimSalesReason].[SalesReasonName] "
            + "    ,[dbo].[DimSalesReason].[SalesReasonReasonType] "
            + "FROM " 
            + "     [dbo].[DimSalesReason] " 
                + "WHERE " 
                + "     (@SalesReasonKey IS NULL OR @SalesReasonKey = '' OR [DimSalesReason].[SalesReasonKey] < LTRIM(RTRIM(@SalesReasonKey))) " 
                + "AND   (@SalesReasonAlternateKey IS NULL OR @SalesReasonAlternateKey = '' OR [DimSalesReason].[SalesReasonAlternateKey] < LTRIM(RTRIM(@SalesReasonAlternateKey))) " 
                + "AND   (@SalesReasonName IS NULL OR @SalesReasonName = '' OR [DimSalesReason].[SalesReasonName] < LTRIM(RTRIM(@SalesReasonName))) " 
                + "AND   (@SalesReasonReasonType IS NULL OR @SalesReasonReasonType = '' OR [DimSalesReason].[SalesReasonReasonType] < LTRIM(RTRIM(@SalesReasonReasonType))) " 
                + "";
        } else if  (sCondition == "Equal or more than...") {
            selectStatement
                = "SELECT "
            + "     [dbo].[DimSalesReason].[SalesReasonKey] "
            + "    ,[dbo].[DimSalesReason].[SalesReasonAlternateKey] "
            + "    ,[dbo].[DimSalesReason].[SalesReasonName] "
            + "    ,[dbo].[DimSalesReason].[SalesReasonReasonType] "
            + "FROM " 
            + "     [dbo].[DimSalesReason] " 
                + "WHERE " 
                + "     (@SalesReasonKey IS NULL OR @SalesReasonKey = '' OR [DimSalesReason].[SalesReasonKey] >= LTRIM(RTRIM(@SalesReasonKey))) " 
                + "AND   (@SalesReasonAlternateKey IS NULL OR @SalesReasonAlternateKey = '' OR [DimSalesReason].[SalesReasonAlternateKey] >= LTRIM(RTRIM(@SalesReasonAlternateKey))) " 
                + "AND   (@SalesReasonName IS NULL OR @SalesReasonName = '' OR [DimSalesReason].[SalesReasonName] >= LTRIM(RTRIM(@SalesReasonName))) " 
                + "AND   (@SalesReasonReasonType IS NULL OR @SalesReasonReasonType = '' OR [DimSalesReason].[SalesReasonReasonType] >= LTRIM(RTRIM(@SalesReasonReasonType))) " 
                + "";
        } else if (sCondition == "Equal or less than...") {
            selectStatement 
                = "SELECT "
            + "     [dbo].[DimSalesReason].[SalesReasonKey] "
            + "    ,[dbo].[DimSalesReason].[SalesReasonAlternateKey] "
            + "    ,[dbo].[DimSalesReason].[SalesReasonName] "
            + "    ,[dbo].[DimSalesReason].[SalesReasonReasonType] "
            + "FROM " 
            + "     [dbo].[DimSalesReason] " 
                + "WHERE " 
                + "     (@SalesReasonKey IS NULL OR @SalesReasonKey = '' OR [DimSalesReason].[SalesReasonKey] <= LTRIM(RTRIM(@SalesReasonKey))) " 
                + "AND   (@SalesReasonAlternateKey IS NULL OR @SalesReasonAlternateKey = '' OR [DimSalesReason].[SalesReasonAlternateKey] <= LTRIM(RTRIM(@SalesReasonAlternateKey))) " 
                + "AND   (@SalesReasonName IS NULL OR @SalesReasonName = '' OR [DimSalesReason].[SalesReasonName] <= LTRIM(RTRIM(@SalesReasonName))) " 
                + "AND   (@SalesReasonReasonType IS NULL OR @SalesReasonReasonType = '' OR [DimSalesReason].[SalesReasonReasonType] <= LTRIM(RTRIM(@SalesReasonReasonType))) " 
                + "";
        }
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        selectCommand.CommandType = CommandType.Text;
        if (sField == "Sales Reason Key") {
            selectCommand.Parameters.AddWithValue("@SalesReasonKey", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@SalesReasonKey", DBNull.Value); }
        if (sField == "Sales Reason Alternate Key") {
            selectCommand.Parameters.AddWithValue("@SalesReasonAlternateKey", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@SalesReasonAlternateKey", DBNull.Value); }
        if (sField == "Sales Reason Name") {
            selectCommand.Parameters.AddWithValue("@SalesReasonName", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@SalesReasonName", DBNull.Value); }
        if (sField == "Sales Reason Reason Type") {
            selectCommand.Parameters.AddWithValue("@SalesReasonReasonType", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@SalesReasonReasonType", DBNull.Value); }
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

    public static dbo_DimSalesReasonClass Select_Record(dbo_DimSalesReasonClass clsdbo_DimSalesReasonPara)
    {
        dbo_DimSalesReasonClass clsdbo_DimSalesReason = new dbo_DimSalesReasonClass();
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement
            = "SELECT " 
            + "     [SalesReasonKey] "
            + "    ,[SalesReasonAlternateKey] "
            + "    ,[SalesReasonName] "
            + "    ,[SalesReasonReasonType] "
            + "FROM "
            + "     [dbo].[DimSalesReason] "
            + "WHERE "
            + "     [SalesReasonKey] = @SalesReasonKey "
            + "";
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        selectCommand.CommandType = CommandType.Text;
        selectCommand.Parameters.AddWithValue("@SalesReasonKey", clsdbo_DimSalesReasonPara.SalesReasonKey);
        try
        {
            connection.Open();
            SqlDataReader reader
                = selectCommand.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                clsdbo_DimSalesReason.SalesReasonKey = System.Convert.ToInt32(reader["SalesReasonKey"]);
                clsdbo_DimSalesReason.SalesReasonAlternateKey = System.Convert.ToInt32(reader["SalesReasonAlternateKey"]);
                clsdbo_DimSalesReason.SalesReasonName = System.Convert.ToString(reader["SalesReasonName"]);
                clsdbo_DimSalesReason.SalesReasonReasonType = System.Convert.ToString(reader["SalesReasonReasonType"]);
            }
            else
            {
                clsdbo_DimSalesReason = null;
            }
            reader.Close();
        }
        catch (SqlException)
        {
            return clsdbo_DimSalesReason;
        }
        finally
        {
            connection.Close();
        }
        return clsdbo_DimSalesReason;
    }

    public static bool Add(dbo_DimSalesReasonClass clsdbo_DimSalesReason)
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string insertStatement
            = "INSERT " 
            + "     [dbo].[DimSalesReason] "
            + "     ( "
            + "     [SalesReasonAlternateKey] "
            + "    ,[SalesReasonName] "
            + "    ,[SalesReasonReasonType] "
            + "     ) "
            + "VALUES " 
            + "     ( "
            + "     @SalesReasonAlternateKey "
            + "    ,@SalesReasonName "
            + "    ,@SalesReasonReasonType "
            + "     ) "
            + "";
        SqlCommand insertCommand = new SqlCommand(insertStatement, connection);
        insertCommand.CommandType = CommandType.Text;
        insertCommand.Parameters.AddWithValue("@SalesReasonAlternateKey", clsdbo_DimSalesReason.SalesReasonAlternateKey);
        insertCommand.Parameters.AddWithValue("@SalesReasonName", clsdbo_DimSalesReason.SalesReasonName);
        insertCommand.Parameters.AddWithValue("@SalesReasonReasonType", clsdbo_DimSalesReason.SalesReasonReasonType);
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

    public static bool Update(dbo_DimSalesReasonClass olddbo_DimSalesReasonClass, 
           dbo_DimSalesReasonClass newdbo_DimSalesReasonClass)
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string updateStatement
            = "UPDATE "  
            + "     [dbo].[DimSalesReason] "
            + "SET "
            + "     [SalesReasonAlternateKey] = @NewSalesReasonAlternateKey "
            + "    ,[SalesReasonName] = @NewSalesReasonName "
            + "    ,[SalesReasonReasonType] = @NewSalesReasonReasonType "
            + "WHERE "
            + "     [SalesReasonKey] = @OldSalesReasonKey " 
            + " AND [SalesReasonAlternateKey] = @OldSalesReasonAlternateKey " 
            + " AND [SalesReasonName] = @OldSalesReasonName " 
            + " AND [SalesReasonReasonType] = @OldSalesReasonReasonType " 
            + "";
        SqlCommand updateCommand = new SqlCommand(updateStatement, connection);
        updateCommand.CommandType = CommandType.Text;
        updateCommand.Parameters.AddWithValue("@NewSalesReasonAlternateKey", newdbo_DimSalesReasonClass.SalesReasonAlternateKey);
        updateCommand.Parameters.AddWithValue("@NewSalesReasonName", newdbo_DimSalesReasonClass.SalesReasonName);
        updateCommand.Parameters.AddWithValue("@NewSalesReasonReasonType", newdbo_DimSalesReasonClass.SalesReasonReasonType);
        updateCommand.Parameters.AddWithValue("@OldSalesReasonKey", olddbo_DimSalesReasonClass.SalesReasonKey);
        updateCommand.Parameters.AddWithValue("@OldSalesReasonAlternateKey", olddbo_DimSalesReasonClass.SalesReasonAlternateKey);
        updateCommand.Parameters.AddWithValue("@OldSalesReasonName", olddbo_DimSalesReasonClass.SalesReasonName);
        updateCommand.Parameters.AddWithValue("@OldSalesReasonReasonType", olddbo_DimSalesReasonClass.SalesReasonReasonType);
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

    public static bool Delete(dbo_DimSalesReasonClass clsdbo_DimSalesReason)
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string deleteStatement
            = "DELETE FROM "  
            + "     [dbo].[DimSalesReason] "
            + "WHERE " 
            + "     [SalesReasonKey] = @OldSalesReasonKey " 
            + " AND [SalesReasonAlternateKey] = @OldSalesReasonAlternateKey " 
            + " AND [SalesReasonName] = @OldSalesReasonName " 
            + " AND [SalesReasonReasonType] = @OldSalesReasonReasonType " 
            + "";
        SqlCommand deleteCommand = new SqlCommand(deleteStatement, connection);
        deleteCommand.CommandType = CommandType.Text;
        deleteCommand.Parameters.AddWithValue("@OldSalesReasonKey", clsdbo_DimSalesReason.SalesReasonKey);
        deleteCommand.Parameters.AddWithValue("@OldSalesReasonAlternateKey", clsdbo_DimSalesReason.SalesReasonAlternateKey);
        deleteCommand.Parameters.AddWithValue("@OldSalesReasonName", clsdbo_DimSalesReason.SalesReasonName);
        deleteCommand.Parameters.AddWithValue("@OldSalesReasonReasonType", clsdbo_DimSalesReason.SalesReasonReasonType);
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

 
