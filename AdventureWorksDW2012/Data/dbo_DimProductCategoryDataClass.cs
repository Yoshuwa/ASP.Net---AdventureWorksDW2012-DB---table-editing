using System;
using System.Data;
using System.Data.SqlClient;

public class dbo_DimProductCategoryDataClass
{

    public static DataTable SelectAll()
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement
            = "SELECT "  
            + "     [dbo].[DimProductCategory].[ProductCategoryKey] "
            + "    ,[dbo].[DimProductCategory].[ProductCategoryAlternateKey] "
            + "    ,[dbo].[DimProductCategory].[EnglishProductCategoryName] "
            + "    ,[dbo].[DimProductCategory].[SpanishProductCategoryName] "
            + "    ,[dbo].[DimProductCategory].[FrenchProductCategoryName] "
            + "FROM " 
            + "     [dbo].[DimProductCategory] " 
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
            + "     [dbo].[DimProductCategory].[ProductCategoryKey] "
            + "    ,[dbo].[DimProductCategory].[ProductCategoryAlternateKey] "
            + "    ,[dbo].[DimProductCategory].[EnglishProductCategoryName] "
            + "    ,[dbo].[DimProductCategory].[SpanishProductCategoryName] "
            + "    ,[dbo].[DimProductCategory].[FrenchProductCategoryName] "
            + "FROM " 
            + "     [dbo].[DimProductCategory] " 
                + "WHERE " 
                + "     (@ProductCategoryKey IS NULL OR @ProductCategoryKey = '' OR [DimProductCategory].[ProductCategoryKey] LIKE '%' + LTRIM(RTRIM(@ProductCategoryKey)) + '%') " 
                + "AND   (@ProductCategoryAlternateKey IS NULL OR @ProductCategoryAlternateKey = '' OR [DimProductCategory].[ProductCategoryAlternateKey] LIKE '%' + LTRIM(RTRIM(@ProductCategoryAlternateKey)) + '%') " 
                + "AND   (@EnglishProductCategoryName IS NULL OR @EnglishProductCategoryName = '' OR [DimProductCategory].[EnglishProductCategoryName] LIKE '%' + LTRIM(RTRIM(@EnglishProductCategoryName)) + '%') " 
                + "AND   (@SpanishProductCategoryName IS NULL OR @SpanishProductCategoryName = '' OR [DimProductCategory].[SpanishProductCategoryName] LIKE '%' + LTRIM(RTRIM(@SpanishProductCategoryName)) + '%') " 
                + "AND   (@FrenchProductCategoryName IS NULL OR @FrenchProductCategoryName = '' OR [DimProductCategory].[FrenchProductCategoryName] LIKE '%' + LTRIM(RTRIM(@FrenchProductCategoryName)) + '%') " 
                + "";
        } else if (sCondition == "Equals") {
            selectStatement
                = "SELECT "
            + "     [dbo].[DimProductCategory].[ProductCategoryKey] "
            + "    ,[dbo].[DimProductCategory].[ProductCategoryAlternateKey] "
            + "    ,[dbo].[DimProductCategory].[EnglishProductCategoryName] "
            + "    ,[dbo].[DimProductCategory].[SpanishProductCategoryName] "
            + "    ,[dbo].[DimProductCategory].[FrenchProductCategoryName] "
            + "FROM " 
            + "     [dbo].[DimProductCategory] " 
                + "WHERE " 
                + "     (@ProductCategoryKey IS NULL OR @ProductCategoryKey = '' OR [DimProductCategory].[ProductCategoryKey] = LTRIM(RTRIM(@ProductCategoryKey))) " 
                + "AND   (@ProductCategoryAlternateKey IS NULL OR @ProductCategoryAlternateKey = '' OR [DimProductCategory].[ProductCategoryAlternateKey] = LTRIM(RTRIM(@ProductCategoryAlternateKey))) " 
                + "AND   (@EnglishProductCategoryName IS NULL OR @EnglishProductCategoryName = '' OR [DimProductCategory].[EnglishProductCategoryName] = LTRIM(RTRIM(@EnglishProductCategoryName))) " 
                + "AND   (@SpanishProductCategoryName IS NULL OR @SpanishProductCategoryName = '' OR [DimProductCategory].[SpanishProductCategoryName] = LTRIM(RTRIM(@SpanishProductCategoryName))) " 
                + "AND   (@FrenchProductCategoryName IS NULL OR @FrenchProductCategoryName = '' OR [DimProductCategory].[FrenchProductCategoryName] = LTRIM(RTRIM(@FrenchProductCategoryName))) " 
                + "";
        } else if  (sCondition == "Starts with...") {
            selectStatement
                = "SELECT "
            + "     [dbo].[DimProductCategory].[ProductCategoryKey] "
            + "    ,[dbo].[DimProductCategory].[ProductCategoryAlternateKey] "
            + "    ,[dbo].[DimProductCategory].[EnglishProductCategoryName] "
            + "    ,[dbo].[DimProductCategory].[SpanishProductCategoryName] "
            + "    ,[dbo].[DimProductCategory].[FrenchProductCategoryName] "
            + "FROM " 
            + "     [dbo].[DimProductCategory] " 
                + "WHERE " 
                + "     (@ProductCategoryKey IS NULL OR @ProductCategoryKey = '' OR [DimProductCategory].[ProductCategoryKey] LIKE LTRIM(RTRIM(@ProductCategoryKey)) + '%') " 
                + "AND   (@ProductCategoryAlternateKey IS NULL OR @ProductCategoryAlternateKey = '' OR [DimProductCategory].[ProductCategoryAlternateKey] LIKE LTRIM(RTRIM(@ProductCategoryAlternateKey)) + '%') " 
                + "AND   (@EnglishProductCategoryName IS NULL OR @EnglishProductCategoryName = '' OR [DimProductCategory].[EnglishProductCategoryName] LIKE LTRIM(RTRIM(@EnglishProductCategoryName)) + '%') " 
                + "AND   (@SpanishProductCategoryName IS NULL OR @SpanishProductCategoryName = '' OR [DimProductCategory].[SpanishProductCategoryName] LIKE LTRIM(RTRIM(@SpanishProductCategoryName)) + '%') " 
                + "AND   (@FrenchProductCategoryName IS NULL OR @FrenchProductCategoryName = '' OR [DimProductCategory].[FrenchProductCategoryName] LIKE LTRIM(RTRIM(@FrenchProductCategoryName)) + '%') " 
                + "";
        } else if  (sCondition == "More than...") {
            selectStatement
                = "SELECT "
            + "     [dbo].[DimProductCategory].[ProductCategoryKey] "
            + "    ,[dbo].[DimProductCategory].[ProductCategoryAlternateKey] "
            + "    ,[dbo].[DimProductCategory].[EnglishProductCategoryName] "
            + "    ,[dbo].[DimProductCategory].[SpanishProductCategoryName] "
            + "    ,[dbo].[DimProductCategory].[FrenchProductCategoryName] "
            + "FROM " 
            + "     [dbo].[DimProductCategory] " 
                + "WHERE " 
                + "     (@ProductCategoryKey IS NULL OR @ProductCategoryKey = '' OR [DimProductCategory].[ProductCategoryKey] > LTRIM(RTRIM(@ProductCategoryKey))) " 
                + "AND   (@ProductCategoryAlternateKey IS NULL OR @ProductCategoryAlternateKey = '' OR [DimProductCategory].[ProductCategoryAlternateKey] > LTRIM(RTRIM(@ProductCategoryAlternateKey))) " 
                + "AND   (@EnglishProductCategoryName IS NULL OR @EnglishProductCategoryName = '' OR [DimProductCategory].[EnglishProductCategoryName] > LTRIM(RTRIM(@EnglishProductCategoryName))) " 
                + "AND   (@SpanishProductCategoryName IS NULL OR @SpanishProductCategoryName = '' OR [DimProductCategory].[SpanishProductCategoryName] > LTRIM(RTRIM(@SpanishProductCategoryName))) " 
                + "AND   (@FrenchProductCategoryName IS NULL OR @FrenchProductCategoryName = '' OR [DimProductCategory].[FrenchProductCategoryName] > LTRIM(RTRIM(@FrenchProductCategoryName))) " 
                + "";
        } else if  (sCondition == "Less than...") {
            selectStatement
                = "SELECT " 
            + "     [dbo].[DimProductCategory].[ProductCategoryKey] "
            + "    ,[dbo].[DimProductCategory].[ProductCategoryAlternateKey] "
            + "    ,[dbo].[DimProductCategory].[EnglishProductCategoryName] "
            + "    ,[dbo].[DimProductCategory].[SpanishProductCategoryName] "
            + "    ,[dbo].[DimProductCategory].[FrenchProductCategoryName] "
            + "FROM " 
            + "     [dbo].[DimProductCategory] " 
                + "WHERE " 
                + "     (@ProductCategoryKey IS NULL OR @ProductCategoryKey = '' OR [DimProductCategory].[ProductCategoryKey] < LTRIM(RTRIM(@ProductCategoryKey))) " 
                + "AND   (@ProductCategoryAlternateKey IS NULL OR @ProductCategoryAlternateKey = '' OR [DimProductCategory].[ProductCategoryAlternateKey] < LTRIM(RTRIM(@ProductCategoryAlternateKey))) " 
                + "AND   (@EnglishProductCategoryName IS NULL OR @EnglishProductCategoryName = '' OR [DimProductCategory].[EnglishProductCategoryName] < LTRIM(RTRIM(@EnglishProductCategoryName))) " 
                + "AND   (@SpanishProductCategoryName IS NULL OR @SpanishProductCategoryName = '' OR [DimProductCategory].[SpanishProductCategoryName] < LTRIM(RTRIM(@SpanishProductCategoryName))) " 
                + "AND   (@FrenchProductCategoryName IS NULL OR @FrenchProductCategoryName = '' OR [DimProductCategory].[FrenchProductCategoryName] < LTRIM(RTRIM(@FrenchProductCategoryName))) " 
                + "";
        } else if  (sCondition == "Equal or more than...") {
            selectStatement
                = "SELECT "
            + "     [dbo].[DimProductCategory].[ProductCategoryKey] "
            + "    ,[dbo].[DimProductCategory].[ProductCategoryAlternateKey] "
            + "    ,[dbo].[DimProductCategory].[EnglishProductCategoryName] "
            + "    ,[dbo].[DimProductCategory].[SpanishProductCategoryName] "
            + "    ,[dbo].[DimProductCategory].[FrenchProductCategoryName] "
            + "FROM " 
            + "     [dbo].[DimProductCategory] " 
                + "WHERE " 
                + "     (@ProductCategoryKey IS NULL OR @ProductCategoryKey = '' OR [DimProductCategory].[ProductCategoryKey] >= LTRIM(RTRIM(@ProductCategoryKey))) " 
                + "AND   (@ProductCategoryAlternateKey IS NULL OR @ProductCategoryAlternateKey = '' OR [DimProductCategory].[ProductCategoryAlternateKey] >= LTRIM(RTRIM(@ProductCategoryAlternateKey))) " 
                + "AND   (@EnglishProductCategoryName IS NULL OR @EnglishProductCategoryName = '' OR [DimProductCategory].[EnglishProductCategoryName] >= LTRIM(RTRIM(@EnglishProductCategoryName))) " 
                + "AND   (@SpanishProductCategoryName IS NULL OR @SpanishProductCategoryName = '' OR [DimProductCategory].[SpanishProductCategoryName] >= LTRIM(RTRIM(@SpanishProductCategoryName))) " 
                + "AND   (@FrenchProductCategoryName IS NULL OR @FrenchProductCategoryName = '' OR [DimProductCategory].[FrenchProductCategoryName] >= LTRIM(RTRIM(@FrenchProductCategoryName))) " 
                + "";
        } else if (sCondition == "Equal or less than...") {
            selectStatement 
                = "SELECT "
            + "     [dbo].[DimProductCategory].[ProductCategoryKey] "
            + "    ,[dbo].[DimProductCategory].[ProductCategoryAlternateKey] "
            + "    ,[dbo].[DimProductCategory].[EnglishProductCategoryName] "
            + "    ,[dbo].[DimProductCategory].[SpanishProductCategoryName] "
            + "    ,[dbo].[DimProductCategory].[FrenchProductCategoryName] "
            + "FROM " 
            + "     [dbo].[DimProductCategory] " 
                + "WHERE " 
                + "     (@ProductCategoryKey IS NULL OR @ProductCategoryKey = '' OR [DimProductCategory].[ProductCategoryKey] <= LTRIM(RTRIM(@ProductCategoryKey))) " 
                + "AND   (@ProductCategoryAlternateKey IS NULL OR @ProductCategoryAlternateKey = '' OR [DimProductCategory].[ProductCategoryAlternateKey] <= LTRIM(RTRIM(@ProductCategoryAlternateKey))) " 
                + "AND   (@EnglishProductCategoryName IS NULL OR @EnglishProductCategoryName = '' OR [DimProductCategory].[EnglishProductCategoryName] <= LTRIM(RTRIM(@EnglishProductCategoryName))) " 
                + "AND   (@SpanishProductCategoryName IS NULL OR @SpanishProductCategoryName = '' OR [DimProductCategory].[SpanishProductCategoryName] <= LTRIM(RTRIM(@SpanishProductCategoryName))) " 
                + "AND   (@FrenchProductCategoryName IS NULL OR @FrenchProductCategoryName = '' OR [DimProductCategory].[FrenchProductCategoryName] <= LTRIM(RTRIM(@FrenchProductCategoryName))) " 
                + "";
        }
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        selectCommand.CommandType = CommandType.Text;
        if (sField == "Product Category Key") {
            selectCommand.Parameters.AddWithValue("@ProductCategoryKey", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@ProductCategoryKey", DBNull.Value); }
        if (sField == "Product Category Alternate Key") {
            selectCommand.Parameters.AddWithValue("@ProductCategoryAlternateKey", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@ProductCategoryAlternateKey", DBNull.Value); }
        if (sField == "English Product Category Name") {
            selectCommand.Parameters.AddWithValue("@EnglishProductCategoryName", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@EnglishProductCategoryName", DBNull.Value); }
        if (sField == "Spanish Product Category Name") {
            selectCommand.Parameters.AddWithValue("@SpanishProductCategoryName", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@SpanishProductCategoryName", DBNull.Value); }
        if (sField == "French Product Category Name") {
            selectCommand.Parameters.AddWithValue("@FrenchProductCategoryName", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@FrenchProductCategoryName", DBNull.Value); }
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

    public static dbo_DimProductCategoryClass Select_Record(dbo_DimProductCategoryClass clsdbo_DimProductCategoryPara)
    {
        dbo_DimProductCategoryClass clsdbo_DimProductCategory = new dbo_DimProductCategoryClass();
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement
            = "SELECT " 
            + "     [ProductCategoryKey] "
            + "    ,[ProductCategoryAlternateKey] "
            + "    ,[EnglishProductCategoryName] "
            + "    ,[SpanishProductCategoryName] "
            + "    ,[FrenchProductCategoryName] "
            + "FROM "
            + "     [dbo].[DimProductCategory] "
            + "WHERE "
            + "     [ProductCategoryKey] = @ProductCategoryKey "
            + "";
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        selectCommand.CommandType = CommandType.Text;
        selectCommand.Parameters.AddWithValue("@ProductCategoryKey", clsdbo_DimProductCategoryPara.ProductCategoryKey);
        try
        {
            connection.Open();
            SqlDataReader reader
                = selectCommand.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                clsdbo_DimProductCategory.ProductCategoryKey = System.Convert.ToInt32(reader["ProductCategoryKey"]);
                clsdbo_DimProductCategory.ProductCategoryAlternateKey = reader["ProductCategoryAlternateKey"] is DBNull ? null : (Int32?)reader["ProductCategoryAlternateKey"];
                clsdbo_DimProductCategory.EnglishProductCategoryName = System.Convert.ToString(reader["EnglishProductCategoryName"]);
                clsdbo_DimProductCategory.SpanishProductCategoryName = System.Convert.ToString(reader["SpanishProductCategoryName"]);
                clsdbo_DimProductCategory.FrenchProductCategoryName = System.Convert.ToString(reader["FrenchProductCategoryName"]);
            }
            else
            {
                clsdbo_DimProductCategory = null;
            }
            reader.Close();
        }
        catch (SqlException)
        {
            return clsdbo_DimProductCategory;
        }
        finally
        {
            connection.Close();
        }
        return clsdbo_DimProductCategory;
    }

    public static bool Add(dbo_DimProductCategoryClass clsdbo_DimProductCategory)
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string insertStatement
            = "INSERT " 
            + "     [dbo].[DimProductCategory] "
            + "     ( "
            + "     [ProductCategoryAlternateKey] "
            + "    ,[EnglishProductCategoryName] "
            + "    ,[SpanishProductCategoryName] "
            + "    ,[FrenchProductCategoryName] "
            + "     ) "
            + "VALUES " 
            + "     ( "
            + "     @ProductCategoryAlternateKey "
            + "    ,@EnglishProductCategoryName "
            + "    ,@SpanishProductCategoryName "
            + "    ,@FrenchProductCategoryName "
            + "     ) "
            + "";
        SqlCommand insertCommand = new SqlCommand(insertStatement, connection);
        insertCommand.CommandType = CommandType.Text;
        if (clsdbo_DimProductCategory.ProductCategoryAlternateKey.HasValue == true) {
            insertCommand.Parameters.AddWithValue("@ProductCategoryAlternateKey", clsdbo_DimProductCategory.ProductCategoryAlternateKey);
        } else {
            insertCommand.Parameters.AddWithValue("@ProductCategoryAlternateKey", DBNull.Value); }
        insertCommand.Parameters.AddWithValue("@EnglishProductCategoryName", clsdbo_DimProductCategory.EnglishProductCategoryName);
        insertCommand.Parameters.AddWithValue("@SpanishProductCategoryName", clsdbo_DimProductCategory.SpanishProductCategoryName);
        insertCommand.Parameters.AddWithValue("@FrenchProductCategoryName", clsdbo_DimProductCategory.FrenchProductCategoryName);
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

    public static bool Update(dbo_DimProductCategoryClass olddbo_DimProductCategoryClass, 
           dbo_DimProductCategoryClass newdbo_DimProductCategoryClass)
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string updateStatement
            = "UPDATE "  
            + "     [dbo].[DimProductCategory] "
            + "SET "
            + "     [ProductCategoryAlternateKey] = @NewProductCategoryAlternateKey "
            + "    ,[EnglishProductCategoryName] = @NewEnglishProductCategoryName "
            + "    ,[SpanishProductCategoryName] = @NewSpanishProductCategoryName "
            + "    ,[FrenchProductCategoryName] = @NewFrenchProductCategoryName "
            + "WHERE "
            + "     [ProductCategoryKey] = @OldProductCategoryKey " 
            + " AND ((@OldProductCategoryAlternateKey IS NULL AND [ProductCategoryAlternateKey] IS NULL) OR [ProductCategoryAlternateKey] = @OldProductCategoryAlternateKey) " 
            + " AND [EnglishProductCategoryName] = @OldEnglishProductCategoryName " 
            + " AND [SpanishProductCategoryName] = @OldSpanishProductCategoryName " 
            + " AND [FrenchProductCategoryName] = @OldFrenchProductCategoryName " 
            + "";
        SqlCommand updateCommand = new SqlCommand(updateStatement, connection);
        updateCommand.CommandType = CommandType.Text;
        if (newdbo_DimProductCategoryClass.ProductCategoryAlternateKey.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@NewProductCategoryAlternateKey", newdbo_DimProductCategoryClass.ProductCategoryAlternateKey);
        } else {
            updateCommand.Parameters.AddWithValue("@NewProductCategoryAlternateKey", DBNull.Value); }
        updateCommand.Parameters.AddWithValue("@NewEnglishProductCategoryName", newdbo_DimProductCategoryClass.EnglishProductCategoryName);
        updateCommand.Parameters.AddWithValue("@NewSpanishProductCategoryName", newdbo_DimProductCategoryClass.SpanishProductCategoryName);
        updateCommand.Parameters.AddWithValue("@NewFrenchProductCategoryName", newdbo_DimProductCategoryClass.FrenchProductCategoryName);
        updateCommand.Parameters.AddWithValue("@OldProductCategoryKey", olddbo_DimProductCategoryClass.ProductCategoryKey);
        if (olddbo_DimProductCategoryClass.ProductCategoryAlternateKey.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@OldProductCategoryAlternateKey", olddbo_DimProductCategoryClass.ProductCategoryAlternateKey);
        } else {
            updateCommand.Parameters.AddWithValue("@OldProductCategoryAlternateKey", DBNull.Value); }
        updateCommand.Parameters.AddWithValue("@OldEnglishProductCategoryName", olddbo_DimProductCategoryClass.EnglishProductCategoryName);
        updateCommand.Parameters.AddWithValue("@OldSpanishProductCategoryName", olddbo_DimProductCategoryClass.SpanishProductCategoryName);
        updateCommand.Parameters.AddWithValue("@OldFrenchProductCategoryName", olddbo_DimProductCategoryClass.FrenchProductCategoryName);
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

    public static bool Delete(dbo_DimProductCategoryClass clsdbo_DimProductCategory)
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string deleteStatement
            = "DELETE FROM "  
            + "     [dbo].[DimProductCategory] "
            + "WHERE " 
            + "     [ProductCategoryKey] = @OldProductCategoryKey " 
            + " AND ((@OldProductCategoryAlternateKey IS NULL AND [ProductCategoryAlternateKey] IS NULL) OR [ProductCategoryAlternateKey] = @OldProductCategoryAlternateKey) " 
            + " AND [EnglishProductCategoryName] = @OldEnglishProductCategoryName " 
            + " AND [SpanishProductCategoryName] = @OldSpanishProductCategoryName " 
            + " AND [FrenchProductCategoryName] = @OldFrenchProductCategoryName " 
            + "";
        SqlCommand deleteCommand = new SqlCommand(deleteStatement, connection);
        deleteCommand.CommandType = CommandType.Text;
        deleteCommand.Parameters.AddWithValue("@OldProductCategoryKey", clsdbo_DimProductCategory.ProductCategoryKey);
        if (clsdbo_DimProductCategory.ProductCategoryAlternateKey.HasValue == true) {
            deleteCommand.Parameters.AddWithValue("@OldProductCategoryAlternateKey", clsdbo_DimProductCategory.ProductCategoryAlternateKey);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldProductCategoryAlternateKey", DBNull.Value); }
        deleteCommand.Parameters.AddWithValue("@OldEnglishProductCategoryName", clsdbo_DimProductCategory.EnglishProductCategoryName);
        deleteCommand.Parameters.AddWithValue("@OldSpanishProductCategoryName", clsdbo_DimProductCategory.SpanishProductCategoryName);
        deleteCommand.Parameters.AddWithValue("@OldFrenchProductCategoryName", clsdbo_DimProductCategory.FrenchProductCategoryName);
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

 
