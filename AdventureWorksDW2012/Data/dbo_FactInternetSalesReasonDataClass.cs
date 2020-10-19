using System;
using System.Data;
using System.Data.SqlClient;

public class dbo_FactInternetSalesReasonDataClass
{

    public static DataTable SelectAll()
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement
            = "SELECT "  
            + "     [A262].[ProductKey] "
            + "    ,[A263].[ProductKey] "
            + "    ,[A264].[SalesReasonName] "
            + "FROM " 
            + "     [dbo].[FactInternetSalesReason] " 
            + "INNER JOIN [dbo].[FactInternetSales] as [A262] ON [dbo].[FactInternetSalesReason].[SalesOrderNumber] = [A262].[SalesOrderNumber] "
            + "INNER JOIN [dbo].[FactInternetSales] as [A263] ON [dbo].[FactInternetSalesReason].[SalesOrderLineNumber] = [A263].[SalesOrderLineNumber] "
            + "INNER JOIN [dbo].[DimSalesReason] as [A264] ON [dbo].[FactInternetSalesReason].[SalesReasonKey] = [A264].[SalesReasonKey] "
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
            + "     [A262].[ProductKey]"
            + "    ,[A263].[ProductKey]"
            + "    ,[A264].[SalesReasonName]"
            + "FROM " 
            + "     [dbo].[FactInternetSalesReason] " 
            + "INNER JOIN [dbo].[FactInternetSales] as [A262] ON [dbo].[FactInternetSalesReason].[SalesOrderNumber] = [A262].[SalesOrderNumber] "
            + "INNER JOIN [dbo].[FactInternetSales] as [A263] ON [dbo].[FactInternetSalesReason].[SalesOrderLineNumber] = [A263].[SalesOrderLineNumber] "
            + "INNER JOIN [dbo].[DimSalesReason] as [A264] ON [dbo].[FactInternetSalesReason].[SalesReasonKey] = [A264].[SalesReasonKey] "
                + "WHERE " 
                + "     (@ProductKey262 IS NULL OR @ProductKey262 = '' OR [A262].[ProductKey] LIKE '%' + LTRIM(RTRIM(@ProductKey262)) + '%') " 
                + "AND   (@ProductKey263 IS NULL OR @ProductKey263 = '' OR [A263].[ProductKey] LIKE '%' + LTRIM(RTRIM(@ProductKey263)) + '%') " 
                + "AND   (@SalesReasonName264 IS NULL OR @SalesReasonName264 = '' OR [A264].[SalesReasonName] LIKE '%' + LTRIM(RTRIM(@SalesReasonName264)) + '%') " 
                + "";
        } else if (sCondition == "Equals") {
            selectStatement
                = "SELECT "
            + "     [A262].[ProductKey]"
            + "    ,[A263].[ProductKey]"
            + "    ,[A264].[SalesReasonName]"
            + "FROM " 
            + "     [dbo].[FactInternetSalesReason] " 
            + "INNER JOIN [dbo].[FactInternetSales] as [A262] ON [dbo].[FactInternetSalesReason].[SalesOrderNumber] = [A262].[SalesOrderNumber] "
            + "INNER JOIN [dbo].[FactInternetSales] as [A263] ON [dbo].[FactInternetSalesReason].[SalesOrderLineNumber] = [A263].[SalesOrderLineNumber] "
            + "INNER JOIN [dbo].[DimSalesReason] as [A264] ON [dbo].[FactInternetSalesReason].[SalesReasonKey] = [A264].[SalesReasonKey] "
                + "WHERE " 
                + "     (@ProductKey262 IS NULL OR @ProductKey262 = '' OR [A262].[ProductKey] = LTRIM(RTRIM(@ProductKey262))) " 
                + "AND   (@ProductKey263 IS NULL OR @ProductKey263 = '' OR [A263].[ProductKey] = LTRIM(RTRIM(@ProductKey263))) " 
                + "AND   (@SalesReasonName264 IS NULL OR @SalesReasonName264 = '' OR [A264].[SalesReasonName] = LTRIM(RTRIM(@SalesReasonName264))) " 
                + "";
        } else if  (sCondition == "Starts with...") {
            selectStatement
                = "SELECT "
            + "     [A262].[ProductKey]"
            + "    ,[A263].[ProductKey]"
            + "    ,[A264].[SalesReasonName]"
            + "FROM " 
            + "     [dbo].[FactInternetSalesReason] " 
            + "INNER JOIN [dbo].[FactInternetSales] as [A262] ON [dbo].[FactInternetSalesReason].[SalesOrderNumber] = [A262].[SalesOrderNumber] "
            + "INNER JOIN [dbo].[FactInternetSales] as [A263] ON [dbo].[FactInternetSalesReason].[SalesOrderLineNumber] = [A263].[SalesOrderLineNumber] "
            + "INNER JOIN [dbo].[DimSalesReason] as [A264] ON [dbo].[FactInternetSalesReason].[SalesReasonKey] = [A264].[SalesReasonKey] "
                + "WHERE " 
                + "     (@ProductKey262 IS NULL OR @ProductKey262 = '' OR [A262].[ProductKey] LIKE LTRIM(RTRIM(@ProductKey262)) + '%') " 
                + "AND   (@ProductKey263 IS NULL OR @ProductKey263 = '' OR [A263].[ProductKey] LIKE LTRIM(RTRIM(@ProductKey263)) + '%') " 
                + "AND   (@SalesReasonName264 IS NULL OR @SalesReasonName264 = '' OR [A264].[SalesReasonName] LIKE LTRIM(RTRIM(@SalesReasonName264)) + '%') " 
                + "";
        } else if  (sCondition == "More than...") {
            selectStatement
                = "SELECT "
            + "     [A262].[ProductKey]"
            + "    ,[A263].[ProductKey]"
            + "    ,[A264].[SalesReasonName]"
            + "FROM " 
            + "     [dbo].[FactInternetSalesReason] " 
            + "INNER JOIN [dbo].[FactInternetSales] as [A262] ON [dbo].[FactInternetSalesReason].[SalesOrderNumber] = [A262].[SalesOrderNumber] "
            + "INNER JOIN [dbo].[FactInternetSales] as [A263] ON [dbo].[FactInternetSalesReason].[SalesOrderLineNumber] = [A263].[SalesOrderLineNumber] "
            + "INNER JOIN [dbo].[DimSalesReason] as [A264] ON [dbo].[FactInternetSalesReason].[SalesReasonKey] = [A264].[SalesReasonKey] "
                + "WHERE " 
                + "     (@ProductKey262 IS NULL OR @ProductKey262 = '' OR [A262].[ProductKey] > LTRIM(RTRIM(@ProductKey262))) " 
                + "AND   (@ProductKey263 IS NULL OR @ProductKey263 = '' OR [A263].[ProductKey] > LTRIM(RTRIM(@ProductKey263))) " 
                + "AND   (@SalesReasonName264 IS NULL OR @SalesReasonName264 = '' OR [A264].[SalesReasonName] > LTRIM(RTRIM(@SalesReasonName264))) " 
                + "";
        } else if  (sCondition == "Less than...") {
            selectStatement
                = "SELECT " 
            + "     [A262].[ProductKey]"
            + "    ,[A263].[ProductKey]"
            + "    ,[A264].[SalesReasonName]"
            + "FROM " 
            + "     [dbo].[FactInternetSalesReason] " 
            + "INNER JOIN [dbo].[FactInternetSales] as [A262] ON [dbo].[FactInternetSalesReason].[SalesOrderNumber] = [A262].[SalesOrderNumber] "
            + "INNER JOIN [dbo].[FactInternetSales] as [A263] ON [dbo].[FactInternetSalesReason].[SalesOrderLineNumber] = [A263].[SalesOrderLineNumber] "
            + "INNER JOIN [dbo].[DimSalesReason] as [A264] ON [dbo].[FactInternetSalesReason].[SalesReasonKey] = [A264].[SalesReasonKey] "
                + "WHERE " 
                + "     (@ProductKey262 IS NULL OR @ProductKey262 = '' OR [A262].[ProductKey] < LTRIM(RTRIM(@ProductKey262))) " 
                + "AND   (@ProductKey263 IS NULL OR @ProductKey263 = '' OR [A263].[ProductKey] < LTRIM(RTRIM(@ProductKey263))) " 
                + "AND   (@SalesReasonName264 IS NULL OR @SalesReasonName264 = '' OR [A264].[SalesReasonName] < LTRIM(RTRIM(@SalesReasonName264))) " 
                + "";
        } else if  (sCondition == "Equal or more than...") {
            selectStatement
                = "SELECT "
            + "     [A262].[ProductKey]"
            + "    ,[A263].[ProductKey]"
            + "    ,[A264].[SalesReasonName]"
            + "FROM " 
            + "     [dbo].[FactInternetSalesReason] " 
            + "INNER JOIN [dbo].[FactInternetSales] as [A262] ON [dbo].[FactInternetSalesReason].[SalesOrderNumber] = [A262].[SalesOrderNumber] "
            + "INNER JOIN [dbo].[FactInternetSales] as [A263] ON [dbo].[FactInternetSalesReason].[SalesOrderLineNumber] = [A263].[SalesOrderLineNumber] "
            + "INNER JOIN [dbo].[DimSalesReason] as [A264] ON [dbo].[FactInternetSalesReason].[SalesReasonKey] = [A264].[SalesReasonKey] "
                + "WHERE " 
                + "     (@ProductKey262 IS NULL OR @ProductKey262 = '' OR [A262].[ProductKey] >= LTRIM(RTRIM(@ProductKey262))) " 
                + "AND   (@ProductKey263 IS NULL OR @ProductKey263 = '' OR [A263].[ProductKey] >= LTRIM(RTRIM(@ProductKey263))) " 
                + "AND   (@SalesReasonName264 IS NULL OR @SalesReasonName264 = '' OR [A264].[SalesReasonName] >= LTRIM(RTRIM(@SalesReasonName264))) " 
                + "";
        } else if (sCondition == "Equal or less than...") {
            selectStatement 
                = "SELECT "
            + "     [A262].[ProductKey]"
            + "    ,[A263].[ProductKey]"
            + "    ,[A264].[SalesReasonName]"
            + "FROM " 
            + "     [dbo].[FactInternetSalesReason] " 
            + "INNER JOIN [dbo].[FactInternetSales] as [A262] ON [dbo].[FactInternetSalesReason].[SalesOrderNumber] = [A262].[SalesOrderNumber] "
            + "INNER JOIN [dbo].[FactInternetSales] as [A263] ON [dbo].[FactInternetSalesReason].[SalesOrderLineNumber] = [A263].[SalesOrderLineNumber] "
            + "INNER JOIN [dbo].[DimSalesReason] as [A264] ON [dbo].[FactInternetSalesReason].[SalesReasonKey] = [A264].[SalesReasonKey] "
                + "WHERE " 
                + "     (@ProductKey262 IS NULL OR @ProductKey262 = '' OR [A262].[ProductKey] <= LTRIM(RTRIM(@ProductKey262))) " 
                + "AND   (@ProductKey263 IS NULL OR @ProductKey263 = '' OR [A263].[ProductKey] <= LTRIM(RTRIM(@ProductKey263))) " 
                + "AND   (@SalesReasonName264 IS NULL OR @SalesReasonName264 = '' OR [A264].[SalesReasonName] <= LTRIM(RTRIM(@SalesReasonName264))) " 
                + "";
        }
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        selectCommand.CommandType = CommandType.Text;
        if (sField == "Sales Order Number") {
            selectCommand.Parameters.AddWithValue("@ProductKey262", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@ProductKey262", DBNull.Value); }
        if (sField == "Sales Order Line Number") {
            selectCommand.Parameters.AddWithValue("@ProductKey263", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@ProductKey263", DBNull.Value); }
        if (sField == "Sales Reason Key") {
            selectCommand.Parameters.AddWithValue("@SalesReasonName264", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@SalesReasonName264", DBNull.Value); }
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

    public static dbo_FactInternetSalesReasonClass Select_Record(dbo_FactInternetSalesReasonClass clsdbo_FactInternetSalesReasonPara)
    {
        dbo_FactInternetSalesReasonClass clsdbo_FactInternetSalesReason = new dbo_FactInternetSalesReasonClass();
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement
            = "SELECT " 
            + "     [SalesOrderNumber] "
            + "    ,[SalesOrderLineNumber] "
            + "    ,[SalesReasonKey] "
            + "FROM "
            + "     [dbo].[FactInternetSalesReason] "
            + "WHERE "
            + "     [SalesOrderNumber] = @SalesOrderNumber "
            + " AND [SalesOrderLineNumber] = @SalesOrderLineNumber "
            + " AND [SalesReasonKey] = @SalesReasonKey "
            + "";
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        selectCommand.CommandType = CommandType.Text;
        selectCommand.Parameters.AddWithValue("@SalesOrderNumber", clsdbo_FactInternetSalesReasonPara.SalesOrderNumber);
        selectCommand.Parameters.AddWithValue("@SalesOrderLineNumber", clsdbo_FactInternetSalesReasonPara.SalesOrderLineNumber);
        selectCommand.Parameters.AddWithValue("@SalesReasonKey", clsdbo_FactInternetSalesReasonPara.SalesReasonKey);
        try
        {
            connection.Open();
            SqlDataReader reader
                = selectCommand.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                clsdbo_FactInternetSalesReason.SalesOrderNumber = System.Convert.ToString(reader["SalesOrderNumber"]);
                clsdbo_FactInternetSalesReason.SalesOrderLineNumber = System.Convert.ToByte(reader["SalesOrderLineNumber"]);
                clsdbo_FactInternetSalesReason.SalesReasonKey = System.Convert.ToInt32(reader["SalesReasonKey"]);
            }
            else
            {
                clsdbo_FactInternetSalesReason = null;
            }
            reader.Close();
        }
        catch (SqlException)
        {
            return clsdbo_FactInternetSalesReason;
        }
        finally
        {
            connection.Close();
        }
        return clsdbo_FactInternetSalesReason;
    }

    public static bool Add(dbo_FactInternetSalesReasonClass clsdbo_FactInternetSalesReason)
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string insertStatement
            = "INSERT " 
            + "     [dbo].[FactInternetSalesReason] "
            + "     ( "
            + "     [SalesOrderNumber] "
            + "    ,[SalesOrderLineNumber] "
            + "    ,[SalesReasonKey] "
            + "     ) "
            + "VALUES " 
            + "     ( "
            + "     @SalesOrderNumber "
            + "    ,@SalesOrderLineNumber "
            + "    ,@SalesReasonKey "
            + "     ) "
            + "";
        SqlCommand insertCommand = new SqlCommand(insertStatement, connection);
        insertCommand.CommandType = CommandType.Text;
        insertCommand.Parameters.AddWithValue("@SalesOrderNumber", clsdbo_FactInternetSalesReason.SalesOrderNumber);
        insertCommand.Parameters.AddWithValue("@SalesOrderLineNumber", clsdbo_FactInternetSalesReason.SalesOrderLineNumber);
        insertCommand.Parameters.AddWithValue("@SalesReasonKey", clsdbo_FactInternetSalesReason.SalesReasonKey);
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

    public static bool Update(dbo_FactInternetSalesReasonClass olddbo_FactInternetSalesReasonClass, 
           dbo_FactInternetSalesReasonClass newdbo_FactInternetSalesReasonClass)
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string updateStatement
            = "UPDATE "  
            + "     [dbo].[FactInternetSalesReason] "
            + "SET "
            + "     [SalesOrderNumber] = @NewSalesOrderNumber "
            + "    ,[SalesOrderLineNumber] = @NewSalesOrderLineNumber "
            + "    ,[SalesReasonKey] = @NewSalesReasonKey "
            + "WHERE "
            + "     [SalesOrderNumber] = @OldSalesOrderNumber " 
            + " AND [SalesOrderLineNumber] = @OldSalesOrderLineNumber " 
            + " AND [SalesReasonKey] = @OldSalesReasonKey " 
            + "";
        SqlCommand updateCommand = new SqlCommand(updateStatement, connection);
        updateCommand.CommandType = CommandType.Text;
        updateCommand.Parameters.AddWithValue("@NewSalesOrderNumber", newdbo_FactInternetSalesReasonClass.SalesOrderNumber);
        updateCommand.Parameters.AddWithValue("@NewSalesOrderLineNumber", newdbo_FactInternetSalesReasonClass.SalesOrderLineNumber);
        updateCommand.Parameters.AddWithValue("@NewSalesReasonKey", newdbo_FactInternetSalesReasonClass.SalesReasonKey);
        updateCommand.Parameters.AddWithValue("@OldSalesOrderNumber", olddbo_FactInternetSalesReasonClass.SalesOrderNumber);
        updateCommand.Parameters.AddWithValue("@OldSalesOrderLineNumber", olddbo_FactInternetSalesReasonClass.SalesOrderLineNumber);
        updateCommand.Parameters.AddWithValue("@OldSalesReasonKey", olddbo_FactInternetSalesReasonClass.SalesReasonKey);
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

    public static bool Delete(dbo_FactInternetSalesReasonClass clsdbo_FactInternetSalesReason)
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string deleteStatement
            = "DELETE FROM "  
            + "     [dbo].[FactInternetSalesReason] "
            + "WHERE " 
            + "     [SalesOrderNumber] = @OldSalesOrderNumber " 
            + " AND [SalesOrderLineNumber] = @OldSalesOrderLineNumber " 
            + " AND [SalesReasonKey] = @OldSalesReasonKey " 
            + "";
        SqlCommand deleteCommand = new SqlCommand(deleteStatement, connection);
        deleteCommand.CommandType = CommandType.Text;
        deleteCommand.Parameters.AddWithValue("@OldSalesOrderNumber", clsdbo_FactInternetSalesReason.SalesOrderNumber);
        deleteCommand.Parameters.AddWithValue("@OldSalesOrderLineNumber", clsdbo_FactInternetSalesReason.SalesOrderLineNumber);
        deleteCommand.Parameters.AddWithValue("@OldSalesReasonKey", clsdbo_FactInternetSalesReason.SalesReasonKey);
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

 
