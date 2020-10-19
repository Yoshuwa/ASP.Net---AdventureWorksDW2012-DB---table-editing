using System;
using System.Data;
using System.Data.SqlClient;

public class dbo_DimProductSubcategoryDataClass
{

    public static DataTable SelectAll()
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement
            = "SELECT "  
            + "     [dbo].[DimProductSubcategory].[ProductSubcategoryKey] "
            + "    ,[dbo].[DimProductSubcategory].[ProductSubcategoryAlternateKey] "
            + "    ,[dbo].[DimProductSubcategory].[EnglishProductSubcategoryName] "
            + "    ,[dbo].[DimProductSubcategory].[SpanishProductSubcategoryName] "
            + "    ,[dbo].[DimProductSubcategory].[FrenchProductSubcategoryName] "
            + "    ,[dbo].[DimProductCategory].[EnglishProductCategoryName] "
            + "FROM " 
            + "     [dbo].[DimProductSubcategory] " 
            + "LEFT JOIN [dbo].[DimProductCategory] ON [dbo].[DimProductSubcategory].[ProductCategoryKey] = [dbo].[DimProductCategory].[ProductCategoryKey] "
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
            + "     [dbo].[DimProductSubcategory].[ProductSubcategoryKey] "
            + "    ,[dbo].[DimProductSubcategory].[ProductSubcategoryAlternateKey] "
            + "    ,[dbo].[DimProductSubcategory].[EnglishProductSubcategoryName] "
            + "    ,[dbo].[DimProductSubcategory].[SpanishProductSubcategoryName] "
            + "    ,[dbo].[DimProductSubcategory].[FrenchProductSubcategoryName] "
            + "    ,[dbo].[DimProductCategory].[EnglishProductCategoryName] "
            + "FROM " 
            + "     [dbo].[DimProductSubcategory] " 
            + "LEFT JOIN [dbo].[DimProductCategory] ON [dbo].[DimProductSubcategory].[ProductCategoryKey] = [dbo].[DimProductCategory].[ProductCategoryKey] "
                + "WHERE " 
                + "     (@ProductSubcategoryKey IS NULL OR @ProductSubcategoryKey = '' OR [DimProductSubcategory].[ProductSubcategoryKey] LIKE '%' + LTRIM(RTRIM(@ProductSubcategoryKey)) + '%') " 
                + "AND   (@ProductSubcategoryAlternateKey IS NULL OR @ProductSubcategoryAlternateKey = '' OR [DimProductSubcategory].[ProductSubcategoryAlternateKey] LIKE '%' + LTRIM(RTRIM(@ProductSubcategoryAlternateKey)) + '%') " 
                + "AND   (@EnglishProductSubcategoryName IS NULL OR @EnglishProductSubcategoryName = '' OR [DimProductSubcategory].[EnglishProductSubcategoryName] LIKE '%' + LTRIM(RTRIM(@EnglishProductSubcategoryName)) + '%') " 
                + "AND   (@SpanishProductSubcategoryName IS NULL OR @SpanishProductSubcategoryName = '' OR [DimProductSubcategory].[SpanishProductSubcategoryName] LIKE '%' + LTRIM(RTRIM(@SpanishProductSubcategoryName)) + '%') " 
                + "AND   (@FrenchProductSubcategoryName IS NULL OR @FrenchProductSubcategoryName = '' OR [DimProductSubcategory].[FrenchProductSubcategoryName] LIKE '%' + LTRIM(RTRIM(@FrenchProductSubcategoryName)) + '%') " 
                + "AND   (@EnglishProductCategoryName IS NULL OR @EnglishProductCategoryName = '' OR [dbo].[DimProductCategory].[EnglishProductCategoryName] LIKE '%' + LTRIM(RTRIM(@EnglishProductCategoryName)) + '%') " 
                + "";
        } else if (sCondition == "Equals") {
            selectStatement
                = "SELECT "
            + "     [dbo].[DimProductSubcategory].[ProductSubcategoryKey] "
            + "    ,[dbo].[DimProductSubcategory].[ProductSubcategoryAlternateKey] "
            + "    ,[dbo].[DimProductSubcategory].[EnglishProductSubcategoryName] "
            + "    ,[dbo].[DimProductSubcategory].[SpanishProductSubcategoryName] "
            + "    ,[dbo].[DimProductSubcategory].[FrenchProductSubcategoryName] "
            + "    ,[dbo].[DimProductCategory].[EnglishProductCategoryName] "
            + "FROM " 
            + "     [dbo].[DimProductSubcategory] " 
            + "LEFT JOIN [dbo].[DimProductCategory] ON [dbo].[DimProductSubcategory].[ProductCategoryKey] = [dbo].[DimProductCategory].[ProductCategoryKey] "
                + "WHERE " 
                + "     (@ProductSubcategoryKey IS NULL OR @ProductSubcategoryKey = '' OR [DimProductSubcategory].[ProductSubcategoryKey] = LTRIM(RTRIM(@ProductSubcategoryKey))) " 
                + "AND   (@ProductSubcategoryAlternateKey IS NULL OR @ProductSubcategoryAlternateKey = '' OR [DimProductSubcategory].[ProductSubcategoryAlternateKey] = LTRIM(RTRIM(@ProductSubcategoryAlternateKey))) " 
                + "AND   (@EnglishProductSubcategoryName IS NULL OR @EnglishProductSubcategoryName = '' OR [DimProductSubcategory].[EnglishProductSubcategoryName] = LTRIM(RTRIM(@EnglishProductSubcategoryName))) " 
                + "AND   (@SpanishProductSubcategoryName IS NULL OR @SpanishProductSubcategoryName = '' OR [DimProductSubcategory].[SpanishProductSubcategoryName] = LTRIM(RTRIM(@SpanishProductSubcategoryName))) " 
                + "AND   (@FrenchProductSubcategoryName IS NULL OR @FrenchProductSubcategoryName = '' OR [DimProductSubcategory].[FrenchProductSubcategoryName] = LTRIM(RTRIM(@FrenchProductSubcategoryName))) " 
                + "AND   (@EnglishProductCategoryName IS NULL OR @EnglishProductCategoryName = '' OR [dbo].[DimProductCategory].[EnglishProductCategoryName] = LTRIM(RTRIM(@EnglishProductCategoryName))) " 
                + "";
        } else if  (sCondition == "Starts with...") {
            selectStatement
                = "SELECT "
            + "     [dbo].[DimProductSubcategory].[ProductSubcategoryKey] "
            + "    ,[dbo].[DimProductSubcategory].[ProductSubcategoryAlternateKey] "
            + "    ,[dbo].[DimProductSubcategory].[EnglishProductSubcategoryName] "
            + "    ,[dbo].[DimProductSubcategory].[SpanishProductSubcategoryName] "
            + "    ,[dbo].[DimProductSubcategory].[FrenchProductSubcategoryName] "
            + "    ,[dbo].[DimProductCategory].[EnglishProductCategoryName] "
            + "FROM " 
            + "     [dbo].[DimProductSubcategory] " 
            + "LEFT JOIN [dbo].[DimProductCategory] ON [dbo].[DimProductSubcategory].[ProductCategoryKey] = [dbo].[DimProductCategory].[ProductCategoryKey] "
                + "WHERE " 
                + "     (@ProductSubcategoryKey IS NULL OR @ProductSubcategoryKey = '' OR [DimProductSubcategory].[ProductSubcategoryKey] LIKE LTRIM(RTRIM(@ProductSubcategoryKey)) + '%') " 
                + "AND   (@ProductSubcategoryAlternateKey IS NULL OR @ProductSubcategoryAlternateKey = '' OR [DimProductSubcategory].[ProductSubcategoryAlternateKey] LIKE LTRIM(RTRIM(@ProductSubcategoryAlternateKey)) + '%') " 
                + "AND   (@EnglishProductSubcategoryName IS NULL OR @EnglishProductSubcategoryName = '' OR [DimProductSubcategory].[EnglishProductSubcategoryName] LIKE LTRIM(RTRIM(@EnglishProductSubcategoryName)) + '%') " 
                + "AND   (@SpanishProductSubcategoryName IS NULL OR @SpanishProductSubcategoryName = '' OR [DimProductSubcategory].[SpanishProductSubcategoryName] LIKE LTRIM(RTRIM(@SpanishProductSubcategoryName)) + '%') " 
                + "AND   (@FrenchProductSubcategoryName IS NULL OR @FrenchProductSubcategoryName = '' OR [DimProductSubcategory].[FrenchProductSubcategoryName] LIKE LTRIM(RTRIM(@FrenchProductSubcategoryName)) + '%') " 
                + "AND   (@EnglishProductCategoryName IS NULL OR @EnglishProductCategoryName = '' OR [dbo].[DimProductCategory].[EnglishProductCategoryName] LIKE LTRIM(RTRIM(@EnglishProductCategoryName)) + '%') " 
                + "";
        } else if  (sCondition == "More than...") {
            selectStatement
                = "SELECT "
            + "     [dbo].[DimProductSubcategory].[ProductSubcategoryKey] "
            + "    ,[dbo].[DimProductSubcategory].[ProductSubcategoryAlternateKey] "
            + "    ,[dbo].[DimProductSubcategory].[EnglishProductSubcategoryName] "
            + "    ,[dbo].[DimProductSubcategory].[SpanishProductSubcategoryName] "
            + "    ,[dbo].[DimProductSubcategory].[FrenchProductSubcategoryName] "
            + "    ,[dbo].[DimProductCategory].[EnglishProductCategoryName] "
            + "FROM " 
            + "     [dbo].[DimProductSubcategory] " 
            + "LEFT JOIN [dbo].[DimProductCategory] ON [dbo].[DimProductSubcategory].[ProductCategoryKey] = [dbo].[DimProductCategory].[ProductCategoryKey] "
                + "WHERE " 
                + "     (@ProductSubcategoryKey IS NULL OR @ProductSubcategoryKey = '' OR [DimProductSubcategory].[ProductSubcategoryKey] > LTRIM(RTRIM(@ProductSubcategoryKey))) " 
                + "AND   (@ProductSubcategoryAlternateKey IS NULL OR @ProductSubcategoryAlternateKey = '' OR [DimProductSubcategory].[ProductSubcategoryAlternateKey] > LTRIM(RTRIM(@ProductSubcategoryAlternateKey))) " 
                + "AND   (@EnglishProductSubcategoryName IS NULL OR @EnglishProductSubcategoryName = '' OR [DimProductSubcategory].[EnglishProductSubcategoryName] > LTRIM(RTRIM(@EnglishProductSubcategoryName))) " 
                + "AND   (@SpanishProductSubcategoryName IS NULL OR @SpanishProductSubcategoryName = '' OR [DimProductSubcategory].[SpanishProductSubcategoryName] > LTRIM(RTRIM(@SpanishProductSubcategoryName))) " 
                + "AND   (@FrenchProductSubcategoryName IS NULL OR @FrenchProductSubcategoryName = '' OR [DimProductSubcategory].[FrenchProductSubcategoryName] > LTRIM(RTRIM(@FrenchProductSubcategoryName))) " 
                + "AND   (@EnglishProductCategoryName IS NULL OR @EnglishProductCategoryName = '' OR [dbo].[DimProductCategory].[EnglishProductCategoryName] > LTRIM(RTRIM(@EnglishProductCategoryName))) " 
                + "";
        } else if  (sCondition == "Less than...") {
            selectStatement
                = "SELECT " 
            + "     [dbo].[DimProductSubcategory].[ProductSubcategoryKey] "
            + "    ,[dbo].[DimProductSubcategory].[ProductSubcategoryAlternateKey] "
            + "    ,[dbo].[DimProductSubcategory].[EnglishProductSubcategoryName] "
            + "    ,[dbo].[DimProductSubcategory].[SpanishProductSubcategoryName] "
            + "    ,[dbo].[DimProductSubcategory].[FrenchProductSubcategoryName] "
            + "    ,[dbo].[DimProductCategory].[EnglishProductCategoryName] "
            + "FROM " 
            + "     [dbo].[DimProductSubcategory] " 
            + "LEFT JOIN [dbo].[DimProductCategory] ON [dbo].[DimProductSubcategory].[ProductCategoryKey] = [dbo].[DimProductCategory].[ProductCategoryKey] "
                + "WHERE " 
                + "     (@ProductSubcategoryKey IS NULL OR @ProductSubcategoryKey = '' OR [DimProductSubcategory].[ProductSubcategoryKey] < LTRIM(RTRIM(@ProductSubcategoryKey))) " 
                + "AND   (@ProductSubcategoryAlternateKey IS NULL OR @ProductSubcategoryAlternateKey = '' OR [DimProductSubcategory].[ProductSubcategoryAlternateKey] < LTRIM(RTRIM(@ProductSubcategoryAlternateKey))) " 
                + "AND   (@EnglishProductSubcategoryName IS NULL OR @EnglishProductSubcategoryName = '' OR [DimProductSubcategory].[EnglishProductSubcategoryName] < LTRIM(RTRIM(@EnglishProductSubcategoryName))) " 
                + "AND   (@SpanishProductSubcategoryName IS NULL OR @SpanishProductSubcategoryName = '' OR [DimProductSubcategory].[SpanishProductSubcategoryName] < LTRIM(RTRIM(@SpanishProductSubcategoryName))) " 
                + "AND   (@FrenchProductSubcategoryName IS NULL OR @FrenchProductSubcategoryName = '' OR [DimProductSubcategory].[FrenchProductSubcategoryName] < LTRIM(RTRIM(@FrenchProductSubcategoryName))) " 
                + "AND   (@EnglishProductCategoryName IS NULL OR @EnglishProductCategoryName = '' OR [dbo].[DimProductCategory].[EnglishProductCategoryName] < LTRIM(RTRIM(@EnglishProductCategoryName))) " 
                + "";
        } else if  (sCondition == "Equal or more than...") {
            selectStatement
                = "SELECT "
            + "     [dbo].[DimProductSubcategory].[ProductSubcategoryKey] "
            + "    ,[dbo].[DimProductSubcategory].[ProductSubcategoryAlternateKey] "
            + "    ,[dbo].[DimProductSubcategory].[EnglishProductSubcategoryName] "
            + "    ,[dbo].[DimProductSubcategory].[SpanishProductSubcategoryName] "
            + "    ,[dbo].[DimProductSubcategory].[FrenchProductSubcategoryName] "
            + "    ,[dbo].[DimProductCategory].[EnglishProductCategoryName] "
            + "FROM " 
            + "     [dbo].[DimProductSubcategory] " 
            + "LEFT JOIN [dbo].[DimProductCategory] ON [dbo].[DimProductSubcategory].[ProductCategoryKey] = [dbo].[DimProductCategory].[ProductCategoryKey] "
                + "WHERE " 
                + "     (@ProductSubcategoryKey IS NULL OR @ProductSubcategoryKey = '' OR [DimProductSubcategory].[ProductSubcategoryKey] >= LTRIM(RTRIM(@ProductSubcategoryKey))) " 
                + "AND   (@ProductSubcategoryAlternateKey IS NULL OR @ProductSubcategoryAlternateKey = '' OR [DimProductSubcategory].[ProductSubcategoryAlternateKey] >= LTRIM(RTRIM(@ProductSubcategoryAlternateKey))) " 
                + "AND   (@EnglishProductSubcategoryName IS NULL OR @EnglishProductSubcategoryName = '' OR [DimProductSubcategory].[EnglishProductSubcategoryName] >= LTRIM(RTRIM(@EnglishProductSubcategoryName))) " 
                + "AND   (@SpanishProductSubcategoryName IS NULL OR @SpanishProductSubcategoryName = '' OR [DimProductSubcategory].[SpanishProductSubcategoryName] >= LTRIM(RTRIM(@SpanishProductSubcategoryName))) " 
                + "AND   (@FrenchProductSubcategoryName IS NULL OR @FrenchProductSubcategoryName = '' OR [DimProductSubcategory].[FrenchProductSubcategoryName] >= LTRIM(RTRIM(@FrenchProductSubcategoryName))) " 
                + "AND   (@EnglishProductCategoryName IS NULL OR @EnglishProductCategoryName = '' OR [dbo].[DimProductCategory].[EnglishProductCategoryName] >= LTRIM(RTRIM(@EnglishProductCategoryName))) " 
                + "";
        } else if (sCondition == "Equal or less than...") {
            selectStatement 
                = "SELECT "
            + "     [dbo].[DimProductSubcategory].[ProductSubcategoryKey] "
            + "    ,[dbo].[DimProductSubcategory].[ProductSubcategoryAlternateKey] "
            + "    ,[dbo].[DimProductSubcategory].[EnglishProductSubcategoryName] "
            + "    ,[dbo].[DimProductSubcategory].[SpanishProductSubcategoryName] "
            + "    ,[dbo].[DimProductSubcategory].[FrenchProductSubcategoryName] "
            + "    ,[dbo].[DimProductCategory].[EnglishProductCategoryName] "
            + "FROM " 
            + "     [dbo].[DimProductSubcategory] " 
            + "LEFT JOIN [dbo].[DimProductCategory] ON [dbo].[DimProductSubcategory].[ProductCategoryKey] = [dbo].[DimProductCategory].[ProductCategoryKey] "
                + "WHERE " 
                + "     (@ProductSubcategoryKey IS NULL OR @ProductSubcategoryKey = '' OR [DimProductSubcategory].[ProductSubcategoryKey] <= LTRIM(RTRIM(@ProductSubcategoryKey))) " 
                + "AND   (@ProductSubcategoryAlternateKey IS NULL OR @ProductSubcategoryAlternateKey = '' OR [DimProductSubcategory].[ProductSubcategoryAlternateKey] <= LTRIM(RTRIM(@ProductSubcategoryAlternateKey))) " 
                + "AND   (@EnglishProductSubcategoryName IS NULL OR @EnglishProductSubcategoryName = '' OR [DimProductSubcategory].[EnglishProductSubcategoryName] <= LTRIM(RTRIM(@EnglishProductSubcategoryName))) " 
                + "AND   (@SpanishProductSubcategoryName IS NULL OR @SpanishProductSubcategoryName = '' OR [DimProductSubcategory].[SpanishProductSubcategoryName] <= LTRIM(RTRIM(@SpanishProductSubcategoryName))) " 
                + "AND   (@FrenchProductSubcategoryName IS NULL OR @FrenchProductSubcategoryName = '' OR [DimProductSubcategory].[FrenchProductSubcategoryName] <= LTRIM(RTRIM(@FrenchProductSubcategoryName))) " 
                + "AND   (@EnglishProductCategoryName IS NULL OR @EnglishProductCategoryName = '' OR [dbo].[DimProductCategory].[EnglishProductCategoryName] <= LTRIM(RTRIM(@EnglishProductCategoryName))) " 
                + "";
        }
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        selectCommand.CommandType = CommandType.Text;
        if (sField == "Product Subcategory Key") {
            selectCommand.Parameters.AddWithValue("@ProductSubcategoryKey", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@ProductSubcategoryKey", DBNull.Value); }
        if (sField == "Product Subcategory Alternate Key") {
            selectCommand.Parameters.AddWithValue("@ProductSubcategoryAlternateKey", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@ProductSubcategoryAlternateKey", DBNull.Value); }
        if (sField == "English Product Subcategory Name") {
            selectCommand.Parameters.AddWithValue("@EnglishProductSubcategoryName", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@EnglishProductSubcategoryName", DBNull.Value); }
        if (sField == "Spanish Product Subcategory Name") {
            selectCommand.Parameters.AddWithValue("@SpanishProductSubcategoryName", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@SpanishProductSubcategoryName", DBNull.Value); }
        if (sField == "French Product Subcategory Name") {
            selectCommand.Parameters.AddWithValue("@FrenchProductSubcategoryName", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@FrenchProductSubcategoryName", DBNull.Value); }
        if (sField == "Product Category Key") {
            selectCommand.Parameters.AddWithValue("@EnglishProductCategoryName", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@EnglishProductCategoryName", DBNull.Value); }
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

    public static dbo_DimProductSubcategoryClass Select_Record(dbo_DimProductSubcategoryClass clsdbo_DimProductSubcategoryPara)
    {
        dbo_DimProductSubcategoryClass clsdbo_DimProductSubcategory = new dbo_DimProductSubcategoryClass();
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement
            = "SELECT " 
            + "     [ProductSubcategoryKey] "
            + "    ,[ProductSubcategoryAlternateKey] "
            + "    ,[EnglishProductSubcategoryName] "
            + "    ,[SpanishProductSubcategoryName] "
            + "    ,[FrenchProductSubcategoryName] "
            + "    ,[ProductCategoryKey] "
            + "FROM "
            + "     [dbo].[DimProductSubcategory] "
            + "WHERE "
            + "     [ProductSubcategoryKey] = @ProductSubcategoryKey "
            + "";
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        selectCommand.CommandType = CommandType.Text;
        selectCommand.Parameters.AddWithValue("@ProductSubcategoryKey", clsdbo_DimProductSubcategoryPara.ProductSubcategoryKey);
        try
        {
            connection.Open();
            SqlDataReader reader
                = selectCommand.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                clsdbo_DimProductSubcategory.ProductSubcategoryKey = System.Convert.ToInt32(reader["ProductSubcategoryKey"]);
                clsdbo_DimProductSubcategory.ProductSubcategoryAlternateKey = reader["ProductSubcategoryAlternateKey"] is DBNull ? null : (Int32?)reader["ProductSubcategoryAlternateKey"];
                clsdbo_DimProductSubcategory.EnglishProductSubcategoryName = System.Convert.ToString(reader["EnglishProductSubcategoryName"]);
                clsdbo_DimProductSubcategory.SpanishProductSubcategoryName = System.Convert.ToString(reader["SpanishProductSubcategoryName"]);
                clsdbo_DimProductSubcategory.FrenchProductSubcategoryName = System.Convert.ToString(reader["FrenchProductSubcategoryName"]);
                clsdbo_DimProductSubcategory.ProductCategoryKey = reader["ProductCategoryKey"] is DBNull ? null : (Int32?)reader["ProductCategoryKey"];
            }
            else
            {
                clsdbo_DimProductSubcategory = null;
            }
            reader.Close();
        }
        catch (SqlException)
        {
            return clsdbo_DimProductSubcategory;
        }
        finally
        {
            connection.Close();
        }
        return clsdbo_DimProductSubcategory;
    }

    public static bool Add(dbo_DimProductSubcategoryClass clsdbo_DimProductSubcategory)
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string insertStatement
            = "INSERT " 
            + "     [dbo].[DimProductSubcategory] "
            + "     ( "
            + "     [ProductSubcategoryAlternateKey] "
            + "    ,[EnglishProductSubcategoryName] "
            + "    ,[SpanishProductSubcategoryName] "
            + "    ,[FrenchProductSubcategoryName] "
            + "    ,[ProductCategoryKey] "
            + "     ) "
            + "VALUES " 
            + "     ( "
            + "     @ProductSubcategoryAlternateKey "
            + "    ,@EnglishProductSubcategoryName "
            + "    ,@SpanishProductSubcategoryName "
            + "    ,@FrenchProductSubcategoryName "
            + "    ,@ProductCategoryKey "
            + "     ) "
            + "";
        SqlCommand insertCommand = new SqlCommand(insertStatement, connection);
        insertCommand.CommandType = CommandType.Text;
        if (clsdbo_DimProductSubcategory.ProductSubcategoryAlternateKey.HasValue == true) {
            insertCommand.Parameters.AddWithValue("@ProductSubcategoryAlternateKey", clsdbo_DimProductSubcategory.ProductSubcategoryAlternateKey);
        } else {
            insertCommand.Parameters.AddWithValue("@ProductSubcategoryAlternateKey", DBNull.Value); }
        insertCommand.Parameters.AddWithValue("@EnglishProductSubcategoryName", clsdbo_DimProductSubcategory.EnglishProductSubcategoryName);
        insertCommand.Parameters.AddWithValue("@SpanishProductSubcategoryName", clsdbo_DimProductSubcategory.SpanishProductSubcategoryName);
        insertCommand.Parameters.AddWithValue("@FrenchProductSubcategoryName", clsdbo_DimProductSubcategory.FrenchProductSubcategoryName);
        if (clsdbo_DimProductSubcategory.ProductCategoryKey.HasValue == true) {
            insertCommand.Parameters.AddWithValue("@ProductCategoryKey", clsdbo_DimProductSubcategory.ProductCategoryKey);
        } else {
            insertCommand.Parameters.AddWithValue("@ProductCategoryKey", DBNull.Value); }
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

    public static bool Update(dbo_DimProductSubcategoryClass olddbo_DimProductSubcategoryClass, 
           dbo_DimProductSubcategoryClass newdbo_DimProductSubcategoryClass)
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string updateStatement
            = "UPDATE "  
            + "     [dbo].[DimProductSubcategory] "
            + "SET "
            + "     [ProductSubcategoryAlternateKey] = @NewProductSubcategoryAlternateKey "
            + "    ,[EnglishProductSubcategoryName] = @NewEnglishProductSubcategoryName "
            + "    ,[SpanishProductSubcategoryName] = @NewSpanishProductSubcategoryName "
            + "    ,[FrenchProductSubcategoryName] = @NewFrenchProductSubcategoryName "
            + "    ,[ProductCategoryKey] = @NewProductCategoryKey "
            + "WHERE "
            + "     [ProductSubcategoryKey] = @OldProductSubcategoryKey " 
            + " AND ((@OldProductSubcategoryAlternateKey IS NULL AND [ProductSubcategoryAlternateKey] IS NULL) OR [ProductSubcategoryAlternateKey] = @OldProductSubcategoryAlternateKey) " 
            + " AND [EnglishProductSubcategoryName] = @OldEnglishProductSubcategoryName " 
            + " AND [SpanishProductSubcategoryName] = @OldSpanishProductSubcategoryName " 
            + " AND [FrenchProductSubcategoryName] = @OldFrenchProductSubcategoryName " 
            + " AND ((@OldProductCategoryKey IS NULL AND [ProductCategoryKey] IS NULL) OR [ProductCategoryKey] = @OldProductCategoryKey) " 
            + "";
        SqlCommand updateCommand = new SqlCommand(updateStatement, connection);
        updateCommand.CommandType = CommandType.Text;
        if (newdbo_DimProductSubcategoryClass.ProductSubcategoryAlternateKey.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@NewProductSubcategoryAlternateKey", newdbo_DimProductSubcategoryClass.ProductSubcategoryAlternateKey);
        } else {
            updateCommand.Parameters.AddWithValue("@NewProductSubcategoryAlternateKey", DBNull.Value); }
        updateCommand.Parameters.AddWithValue("@NewEnglishProductSubcategoryName", newdbo_DimProductSubcategoryClass.EnglishProductSubcategoryName);
        updateCommand.Parameters.AddWithValue("@NewSpanishProductSubcategoryName", newdbo_DimProductSubcategoryClass.SpanishProductSubcategoryName);
        updateCommand.Parameters.AddWithValue("@NewFrenchProductSubcategoryName", newdbo_DimProductSubcategoryClass.FrenchProductSubcategoryName);
        if (newdbo_DimProductSubcategoryClass.ProductCategoryKey.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@NewProductCategoryKey", newdbo_DimProductSubcategoryClass.ProductCategoryKey);
        } else {
            updateCommand.Parameters.AddWithValue("@NewProductCategoryKey", DBNull.Value); }
        updateCommand.Parameters.AddWithValue("@OldProductSubcategoryKey", olddbo_DimProductSubcategoryClass.ProductSubcategoryKey);
        if (olddbo_DimProductSubcategoryClass.ProductSubcategoryAlternateKey.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@OldProductSubcategoryAlternateKey", olddbo_DimProductSubcategoryClass.ProductSubcategoryAlternateKey);
        } else {
            updateCommand.Parameters.AddWithValue("@OldProductSubcategoryAlternateKey", DBNull.Value); }
        updateCommand.Parameters.AddWithValue("@OldEnglishProductSubcategoryName", olddbo_DimProductSubcategoryClass.EnglishProductSubcategoryName);
        updateCommand.Parameters.AddWithValue("@OldSpanishProductSubcategoryName", olddbo_DimProductSubcategoryClass.SpanishProductSubcategoryName);
        updateCommand.Parameters.AddWithValue("@OldFrenchProductSubcategoryName", olddbo_DimProductSubcategoryClass.FrenchProductSubcategoryName);
        if (olddbo_DimProductSubcategoryClass.ProductCategoryKey.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@OldProductCategoryKey", olddbo_DimProductSubcategoryClass.ProductCategoryKey);
        } else {
            updateCommand.Parameters.AddWithValue("@OldProductCategoryKey", DBNull.Value); }
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

    public static bool Delete(dbo_DimProductSubcategoryClass clsdbo_DimProductSubcategory)
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string deleteStatement
            = "DELETE FROM "  
            + "     [dbo].[DimProductSubcategory] "
            + "WHERE " 
            + "     [ProductSubcategoryKey] = @OldProductSubcategoryKey " 
            + " AND ((@OldProductSubcategoryAlternateKey IS NULL AND [ProductSubcategoryAlternateKey] IS NULL) OR [ProductSubcategoryAlternateKey] = @OldProductSubcategoryAlternateKey) " 
            + " AND [EnglishProductSubcategoryName] = @OldEnglishProductSubcategoryName " 
            + " AND [SpanishProductSubcategoryName] = @OldSpanishProductSubcategoryName " 
            + " AND [FrenchProductSubcategoryName] = @OldFrenchProductSubcategoryName " 
            + " AND ((@OldProductCategoryKey IS NULL AND [ProductCategoryKey] IS NULL) OR [ProductCategoryKey] = @OldProductCategoryKey) " 
            + "";
        SqlCommand deleteCommand = new SqlCommand(deleteStatement, connection);
        deleteCommand.CommandType = CommandType.Text;
        deleteCommand.Parameters.AddWithValue("@OldProductSubcategoryKey", clsdbo_DimProductSubcategory.ProductSubcategoryKey);
        if (clsdbo_DimProductSubcategory.ProductSubcategoryAlternateKey.HasValue == true) {
            deleteCommand.Parameters.AddWithValue("@OldProductSubcategoryAlternateKey", clsdbo_DimProductSubcategory.ProductSubcategoryAlternateKey);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldProductSubcategoryAlternateKey", DBNull.Value); }
        deleteCommand.Parameters.AddWithValue("@OldEnglishProductSubcategoryName", clsdbo_DimProductSubcategory.EnglishProductSubcategoryName);
        deleteCommand.Parameters.AddWithValue("@OldSpanishProductSubcategoryName", clsdbo_DimProductSubcategory.SpanishProductSubcategoryName);
        deleteCommand.Parameters.AddWithValue("@OldFrenchProductSubcategoryName", clsdbo_DimProductSubcategory.FrenchProductSubcategoryName);
        if (clsdbo_DimProductSubcategory.ProductCategoryKey.HasValue == true) {
            deleteCommand.Parameters.AddWithValue("@OldProductCategoryKey", clsdbo_DimProductSubcategory.ProductCategoryKey);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldProductCategoryKey", DBNull.Value); }
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

 
