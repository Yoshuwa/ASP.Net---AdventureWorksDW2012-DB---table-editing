using System;
using System.Data;
using System.Data.SqlClient;

public class dbo_FactSurveyResponseDataClass
{

    public static DataTable SelectAll()
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement
            = "SELECT "  
            + "     [dbo].[FactSurveyResponse].[SurveyResponseKey] "
            + "    ,[A307].[DateKey] "
            + "    ,[A308].[CustomerKey] "
            + "    ,[dbo].[FactSurveyResponse].[ProductCategoryKey] "
            + "    ,[dbo].[FactSurveyResponse].[EnglishProductCategoryName] "
            + "    ,[dbo].[FactSurveyResponse].[ProductSubcategoryKey] "
            + "    ,[dbo].[FactSurveyResponse].[EnglishProductSubcategoryName] "
            + "    ,[dbo].[FactSurveyResponse].[Date] "
            + "FROM " 
            + "     [dbo].[FactSurveyResponse] " 
            + "INNER JOIN [dbo].[DimDate] as [A307] ON [dbo].[FactSurveyResponse].[DateKey] = [A307].[DateKey] "
            + "INNER JOIN [dbo].[DimCustomer] as [A308] ON [dbo].[FactSurveyResponse].[CustomerKey] = [A308].[CustomerKey] "
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
            + "     [dbo].[FactSurveyResponse].[SurveyResponseKey] "
            + "    ,[A307].[DateKey]"
            + "    ,[A308].[CustomerKey]"
            + "    ,[dbo].[FactSurveyResponse].[ProductCategoryKey] "
            + "    ,[dbo].[FactSurveyResponse].[EnglishProductCategoryName] "
            + "    ,[dbo].[FactSurveyResponse].[ProductSubcategoryKey] "
            + "    ,[dbo].[FactSurveyResponse].[EnglishProductSubcategoryName] "
            + "    ,[dbo].[FactSurveyResponse].[Date] "
            + "FROM " 
            + "     [dbo].[FactSurveyResponse] " 
            + "INNER JOIN [dbo].[DimDate] as [A307] ON [dbo].[FactSurveyResponse].[DateKey] = [A307].[DateKey] "
            + "INNER JOIN [dbo].[DimCustomer] as [A308] ON [dbo].[FactSurveyResponse].[CustomerKey] = [A308].[CustomerKey] "
                + "WHERE " 
                + "     (@SurveyResponseKey IS NULL OR @SurveyResponseKey = '' OR [FactSurveyResponse].[SurveyResponseKey] LIKE '%' + LTRIM(RTRIM(@SurveyResponseKey)) + '%') " 
                + "AND   (@DateKey307 IS NULL OR @DateKey307 = '' OR [A307].[DateKey] LIKE '%' + LTRIM(RTRIM(@DateKey307)) + '%') " 
                + "AND   (@CustomerKey308 IS NULL OR @CustomerKey308 = '' OR [A308].[CustomerKey] LIKE '%' + LTRIM(RTRIM(@CustomerKey308)) + '%') " 
                + "AND   (@ProductCategoryKey IS NULL OR @ProductCategoryKey = '' OR [FactSurveyResponse].[ProductCategoryKey] LIKE '%' + LTRIM(RTRIM(@ProductCategoryKey)) + '%') " 
                + "AND   (@EnglishProductCategoryName IS NULL OR @EnglishProductCategoryName = '' OR [FactSurveyResponse].[EnglishProductCategoryName] LIKE '%' + LTRIM(RTRIM(@EnglishProductCategoryName)) + '%') " 
                + "AND   (@ProductSubcategoryKey IS NULL OR @ProductSubcategoryKey = '' OR [FactSurveyResponse].[ProductSubcategoryKey] LIKE '%' + LTRIM(RTRIM(@ProductSubcategoryKey)) + '%') " 
                + "AND   (@EnglishProductSubcategoryName IS NULL OR @EnglishProductSubcategoryName = '' OR [FactSurveyResponse].[EnglishProductSubcategoryName] LIKE '%' + LTRIM(RTRIM(@EnglishProductSubcategoryName)) + '%') " 
                + "AND   (@Date IS NULL OR @Date = '' OR [FactSurveyResponse].[Date] LIKE '%' + LTRIM(RTRIM(@Date)) + '%') " 
                + "";
        } else if (sCondition == "Equals") {
            selectStatement
                = "SELECT "
            + "     [dbo].[FactSurveyResponse].[SurveyResponseKey] "
            + "    ,[A307].[DateKey]"
            + "    ,[A308].[CustomerKey]"
            + "    ,[dbo].[FactSurveyResponse].[ProductCategoryKey] "
            + "    ,[dbo].[FactSurveyResponse].[EnglishProductCategoryName] "
            + "    ,[dbo].[FactSurveyResponse].[ProductSubcategoryKey] "
            + "    ,[dbo].[FactSurveyResponse].[EnglishProductSubcategoryName] "
            + "    ,[dbo].[FactSurveyResponse].[Date] "
            + "FROM " 
            + "     [dbo].[FactSurveyResponse] " 
            + "INNER JOIN [dbo].[DimDate] as [A307] ON [dbo].[FactSurveyResponse].[DateKey] = [A307].[DateKey] "
            + "INNER JOIN [dbo].[DimCustomer] as [A308] ON [dbo].[FactSurveyResponse].[CustomerKey] = [A308].[CustomerKey] "
                + "WHERE " 
                + "     (@SurveyResponseKey IS NULL OR @SurveyResponseKey = '' OR [FactSurveyResponse].[SurveyResponseKey] = LTRIM(RTRIM(@SurveyResponseKey))) " 
                + "AND   (@DateKey307 IS NULL OR @DateKey307 = '' OR [A307].[DateKey] = LTRIM(RTRIM(@DateKey307))) " 
                + "AND   (@CustomerKey308 IS NULL OR @CustomerKey308 = '' OR [A308].[CustomerKey] = LTRIM(RTRIM(@CustomerKey308))) " 
                + "AND   (@ProductCategoryKey IS NULL OR @ProductCategoryKey = '' OR [FactSurveyResponse].[ProductCategoryKey] = LTRIM(RTRIM(@ProductCategoryKey))) " 
                + "AND   (@EnglishProductCategoryName IS NULL OR @EnglishProductCategoryName = '' OR [FactSurveyResponse].[EnglishProductCategoryName] = LTRIM(RTRIM(@EnglishProductCategoryName))) " 
                + "AND   (@ProductSubcategoryKey IS NULL OR @ProductSubcategoryKey = '' OR [FactSurveyResponse].[ProductSubcategoryKey] = LTRIM(RTRIM(@ProductSubcategoryKey))) " 
                + "AND   (@EnglishProductSubcategoryName IS NULL OR @EnglishProductSubcategoryName = '' OR [FactSurveyResponse].[EnglishProductSubcategoryName] = LTRIM(RTRIM(@EnglishProductSubcategoryName))) " 
                + "AND   (@Date IS NULL OR @Date = '' OR [FactSurveyResponse].[Date] = LTRIM(RTRIM(@Date))) " 
                + "";
        } else if  (sCondition == "Starts with...") {
            selectStatement
                = "SELECT "
            + "     [dbo].[FactSurveyResponse].[SurveyResponseKey] "
            + "    ,[A307].[DateKey]"
            + "    ,[A308].[CustomerKey]"
            + "    ,[dbo].[FactSurveyResponse].[ProductCategoryKey] "
            + "    ,[dbo].[FactSurveyResponse].[EnglishProductCategoryName] "
            + "    ,[dbo].[FactSurveyResponse].[ProductSubcategoryKey] "
            + "    ,[dbo].[FactSurveyResponse].[EnglishProductSubcategoryName] "
            + "    ,[dbo].[FactSurveyResponse].[Date] "
            + "FROM " 
            + "     [dbo].[FactSurveyResponse] " 
            + "INNER JOIN [dbo].[DimDate] as [A307] ON [dbo].[FactSurveyResponse].[DateKey] = [A307].[DateKey] "
            + "INNER JOIN [dbo].[DimCustomer] as [A308] ON [dbo].[FactSurveyResponse].[CustomerKey] = [A308].[CustomerKey] "
                + "WHERE " 
                + "     (@SurveyResponseKey IS NULL OR @SurveyResponseKey = '' OR [FactSurveyResponse].[SurveyResponseKey] LIKE LTRIM(RTRIM(@SurveyResponseKey)) + '%') " 
                + "AND   (@DateKey307 IS NULL OR @DateKey307 = '' OR [A307].[DateKey] LIKE LTRIM(RTRIM(@DateKey307)) + '%') " 
                + "AND   (@CustomerKey308 IS NULL OR @CustomerKey308 = '' OR [A308].[CustomerKey] LIKE LTRIM(RTRIM(@CustomerKey308)) + '%') " 
                + "AND   (@ProductCategoryKey IS NULL OR @ProductCategoryKey = '' OR [FactSurveyResponse].[ProductCategoryKey] LIKE LTRIM(RTRIM(@ProductCategoryKey)) + '%') " 
                + "AND   (@EnglishProductCategoryName IS NULL OR @EnglishProductCategoryName = '' OR [FactSurveyResponse].[EnglishProductCategoryName] LIKE LTRIM(RTRIM(@EnglishProductCategoryName)) + '%') " 
                + "AND   (@ProductSubcategoryKey IS NULL OR @ProductSubcategoryKey = '' OR [FactSurveyResponse].[ProductSubcategoryKey] LIKE LTRIM(RTRIM(@ProductSubcategoryKey)) + '%') " 
                + "AND   (@EnglishProductSubcategoryName IS NULL OR @EnglishProductSubcategoryName = '' OR [FactSurveyResponse].[EnglishProductSubcategoryName] LIKE LTRIM(RTRIM(@EnglishProductSubcategoryName)) + '%') " 
                + "AND   (@Date IS NULL OR @Date = '' OR [FactSurveyResponse].[Date] LIKE LTRIM(RTRIM(@Date)) + '%') " 
                + "";
        } else if  (sCondition == "More than...") {
            selectStatement
                = "SELECT "
            + "     [dbo].[FactSurveyResponse].[SurveyResponseKey] "
            + "    ,[A307].[DateKey]"
            + "    ,[A308].[CustomerKey]"
            + "    ,[dbo].[FactSurveyResponse].[ProductCategoryKey] "
            + "    ,[dbo].[FactSurveyResponse].[EnglishProductCategoryName] "
            + "    ,[dbo].[FactSurveyResponse].[ProductSubcategoryKey] "
            + "    ,[dbo].[FactSurveyResponse].[EnglishProductSubcategoryName] "
            + "    ,[dbo].[FactSurveyResponse].[Date] "
            + "FROM " 
            + "     [dbo].[FactSurveyResponse] " 
            + "INNER JOIN [dbo].[DimDate] as [A307] ON [dbo].[FactSurveyResponse].[DateKey] = [A307].[DateKey] "
            + "INNER JOIN [dbo].[DimCustomer] as [A308] ON [dbo].[FactSurveyResponse].[CustomerKey] = [A308].[CustomerKey] "
                + "WHERE " 
                + "     (@SurveyResponseKey IS NULL OR @SurveyResponseKey = '' OR [FactSurveyResponse].[SurveyResponseKey] > LTRIM(RTRIM(@SurveyResponseKey))) " 
                + "AND   (@DateKey307 IS NULL OR @DateKey307 = '' OR [A307].[DateKey] > LTRIM(RTRIM(@DateKey307))) " 
                + "AND   (@CustomerKey308 IS NULL OR @CustomerKey308 = '' OR [A308].[CustomerKey] > LTRIM(RTRIM(@CustomerKey308))) " 
                + "AND   (@ProductCategoryKey IS NULL OR @ProductCategoryKey = '' OR [FactSurveyResponse].[ProductCategoryKey] > LTRIM(RTRIM(@ProductCategoryKey))) " 
                + "AND   (@EnglishProductCategoryName IS NULL OR @EnglishProductCategoryName = '' OR [FactSurveyResponse].[EnglishProductCategoryName] > LTRIM(RTRIM(@EnglishProductCategoryName))) " 
                + "AND   (@ProductSubcategoryKey IS NULL OR @ProductSubcategoryKey = '' OR [FactSurveyResponse].[ProductSubcategoryKey] > LTRIM(RTRIM(@ProductSubcategoryKey))) " 
                + "AND   (@EnglishProductSubcategoryName IS NULL OR @EnglishProductSubcategoryName = '' OR [FactSurveyResponse].[EnglishProductSubcategoryName] > LTRIM(RTRIM(@EnglishProductSubcategoryName))) " 
                + "AND   (@Date IS NULL OR @Date = '' OR [FactSurveyResponse].[Date] > LTRIM(RTRIM(@Date))) " 
                + "";
        } else if  (sCondition == "Less than...") {
            selectStatement
                = "SELECT " 
            + "     [dbo].[FactSurveyResponse].[SurveyResponseKey] "
            + "    ,[A307].[DateKey]"
            + "    ,[A308].[CustomerKey]"
            + "    ,[dbo].[FactSurveyResponse].[ProductCategoryKey] "
            + "    ,[dbo].[FactSurveyResponse].[EnglishProductCategoryName] "
            + "    ,[dbo].[FactSurveyResponse].[ProductSubcategoryKey] "
            + "    ,[dbo].[FactSurveyResponse].[EnglishProductSubcategoryName] "
            + "    ,[dbo].[FactSurveyResponse].[Date] "
            + "FROM " 
            + "     [dbo].[FactSurveyResponse] " 
            + "INNER JOIN [dbo].[DimDate] as [A307] ON [dbo].[FactSurveyResponse].[DateKey] = [A307].[DateKey] "
            + "INNER JOIN [dbo].[DimCustomer] as [A308] ON [dbo].[FactSurveyResponse].[CustomerKey] = [A308].[CustomerKey] "
                + "WHERE " 
                + "     (@SurveyResponseKey IS NULL OR @SurveyResponseKey = '' OR [FactSurveyResponse].[SurveyResponseKey] < LTRIM(RTRIM(@SurveyResponseKey))) " 
                + "AND   (@DateKey307 IS NULL OR @DateKey307 = '' OR [A307].[DateKey] < LTRIM(RTRIM(@DateKey307))) " 
                + "AND   (@CustomerKey308 IS NULL OR @CustomerKey308 = '' OR [A308].[CustomerKey] < LTRIM(RTRIM(@CustomerKey308))) " 
                + "AND   (@ProductCategoryKey IS NULL OR @ProductCategoryKey = '' OR [FactSurveyResponse].[ProductCategoryKey] < LTRIM(RTRIM(@ProductCategoryKey))) " 
                + "AND   (@EnglishProductCategoryName IS NULL OR @EnglishProductCategoryName = '' OR [FactSurveyResponse].[EnglishProductCategoryName] < LTRIM(RTRIM(@EnglishProductCategoryName))) " 
                + "AND   (@ProductSubcategoryKey IS NULL OR @ProductSubcategoryKey = '' OR [FactSurveyResponse].[ProductSubcategoryKey] < LTRIM(RTRIM(@ProductSubcategoryKey))) " 
                + "AND   (@EnglishProductSubcategoryName IS NULL OR @EnglishProductSubcategoryName = '' OR [FactSurveyResponse].[EnglishProductSubcategoryName] < LTRIM(RTRIM(@EnglishProductSubcategoryName))) " 
                + "AND   (@Date IS NULL OR @Date = '' OR [FactSurveyResponse].[Date] < LTRIM(RTRIM(@Date))) " 
                + "";
        } else if  (sCondition == "Equal or more than...") {
            selectStatement
                = "SELECT "
            + "     [dbo].[FactSurveyResponse].[SurveyResponseKey] "
            + "    ,[A307].[DateKey]"
            + "    ,[A308].[CustomerKey]"
            + "    ,[dbo].[FactSurveyResponse].[ProductCategoryKey] "
            + "    ,[dbo].[FactSurveyResponse].[EnglishProductCategoryName] "
            + "    ,[dbo].[FactSurveyResponse].[ProductSubcategoryKey] "
            + "    ,[dbo].[FactSurveyResponse].[EnglishProductSubcategoryName] "
            + "    ,[dbo].[FactSurveyResponse].[Date] "
            + "FROM " 
            + "     [dbo].[FactSurveyResponse] " 
            + "INNER JOIN [dbo].[DimDate] as [A307] ON [dbo].[FactSurveyResponse].[DateKey] = [A307].[DateKey] "
            + "INNER JOIN [dbo].[DimCustomer] as [A308] ON [dbo].[FactSurveyResponse].[CustomerKey] = [A308].[CustomerKey] "
                + "WHERE " 
                + "     (@SurveyResponseKey IS NULL OR @SurveyResponseKey = '' OR [FactSurveyResponse].[SurveyResponseKey] >= LTRIM(RTRIM(@SurveyResponseKey))) " 
                + "AND   (@DateKey307 IS NULL OR @DateKey307 = '' OR [A307].[DateKey] >= LTRIM(RTRIM(@DateKey307))) " 
                + "AND   (@CustomerKey308 IS NULL OR @CustomerKey308 = '' OR [A308].[CustomerKey] >= LTRIM(RTRIM(@CustomerKey308))) " 
                + "AND   (@ProductCategoryKey IS NULL OR @ProductCategoryKey = '' OR [FactSurveyResponse].[ProductCategoryKey] >= LTRIM(RTRIM(@ProductCategoryKey))) " 
                + "AND   (@EnglishProductCategoryName IS NULL OR @EnglishProductCategoryName = '' OR [FactSurveyResponse].[EnglishProductCategoryName] >= LTRIM(RTRIM(@EnglishProductCategoryName))) " 
                + "AND   (@ProductSubcategoryKey IS NULL OR @ProductSubcategoryKey = '' OR [FactSurveyResponse].[ProductSubcategoryKey] >= LTRIM(RTRIM(@ProductSubcategoryKey))) " 
                + "AND   (@EnglishProductSubcategoryName IS NULL OR @EnglishProductSubcategoryName = '' OR [FactSurveyResponse].[EnglishProductSubcategoryName] >= LTRIM(RTRIM(@EnglishProductSubcategoryName))) " 
                + "AND   (@Date IS NULL OR @Date = '' OR [FactSurveyResponse].[Date] >= LTRIM(RTRIM(@Date))) " 
                + "";
        } else if (sCondition == "Equal or less than...") {
            selectStatement 
                = "SELECT "
            + "     [dbo].[FactSurveyResponse].[SurveyResponseKey] "
            + "    ,[A307].[DateKey]"
            + "    ,[A308].[CustomerKey]"
            + "    ,[dbo].[FactSurveyResponse].[ProductCategoryKey] "
            + "    ,[dbo].[FactSurveyResponse].[EnglishProductCategoryName] "
            + "    ,[dbo].[FactSurveyResponse].[ProductSubcategoryKey] "
            + "    ,[dbo].[FactSurveyResponse].[EnglishProductSubcategoryName] "
            + "    ,[dbo].[FactSurveyResponse].[Date] "
            + "FROM " 
            + "     [dbo].[FactSurveyResponse] " 
            + "INNER JOIN [dbo].[DimDate] as [A307] ON [dbo].[FactSurveyResponse].[DateKey] = [A307].[DateKey] "
            + "INNER JOIN [dbo].[DimCustomer] as [A308] ON [dbo].[FactSurveyResponse].[CustomerKey] = [A308].[CustomerKey] "
                + "WHERE " 
                + "     (@SurveyResponseKey IS NULL OR @SurveyResponseKey = '' OR [FactSurveyResponse].[SurveyResponseKey] <= LTRIM(RTRIM(@SurveyResponseKey))) " 
                + "AND   (@DateKey307 IS NULL OR @DateKey307 = '' OR [A307].[DateKey] <= LTRIM(RTRIM(@DateKey307))) " 
                + "AND   (@CustomerKey308 IS NULL OR @CustomerKey308 = '' OR [A308].[CustomerKey] <= LTRIM(RTRIM(@CustomerKey308))) " 
                + "AND   (@ProductCategoryKey IS NULL OR @ProductCategoryKey = '' OR [FactSurveyResponse].[ProductCategoryKey] <= LTRIM(RTRIM(@ProductCategoryKey))) " 
                + "AND   (@EnglishProductCategoryName IS NULL OR @EnglishProductCategoryName = '' OR [FactSurveyResponse].[EnglishProductCategoryName] <= LTRIM(RTRIM(@EnglishProductCategoryName))) " 
                + "AND   (@ProductSubcategoryKey IS NULL OR @ProductSubcategoryKey = '' OR [FactSurveyResponse].[ProductSubcategoryKey] <= LTRIM(RTRIM(@ProductSubcategoryKey))) " 
                + "AND   (@EnglishProductSubcategoryName IS NULL OR @EnglishProductSubcategoryName = '' OR [FactSurveyResponse].[EnglishProductSubcategoryName] <= LTRIM(RTRIM(@EnglishProductSubcategoryName))) " 
                + "AND   (@Date IS NULL OR @Date = '' OR [FactSurveyResponse].[Date] <= LTRIM(RTRIM(@Date))) " 
                + "";
        }
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        selectCommand.CommandType = CommandType.Text;
        if (sField == "Survey Response Key") {
            selectCommand.Parameters.AddWithValue("@SurveyResponseKey", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@SurveyResponseKey", DBNull.Value); }
        if (sField == "Date Key") {
            selectCommand.Parameters.AddWithValue("@DateKey307", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@DateKey307", DBNull.Value); }
        if (sField == "Customer Key") {
            selectCommand.Parameters.AddWithValue("@CustomerKey308", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@CustomerKey308", DBNull.Value); }
        if (sField == "Product Category Key") {
            selectCommand.Parameters.AddWithValue("@ProductCategoryKey", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@ProductCategoryKey", DBNull.Value); }
        if (sField == "English Product Category Name") {
            selectCommand.Parameters.AddWithValue("@EnglishProductCategoryName", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@EnglishProductCategoryName", DBNull.Value); }
        if (sField == "Product Subcategory Key") {
            selectCommand.Parameters.AddWithValue("@ProductSubcategoryKey", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@ProductSubcategoryKey", DBNull.Value); }
        if (sField == "English Product Subcategory Name") {
            selectCommand.Parameters.AddWithValue("@EnglishProductSubcategoryName", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@EnglishProductSubcategoryName", DBNull.Value); }
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

    public static dbo_FactSurveyResponseClass Select_Record(dbo_FactSurveyResponseClass clsdbo_FactSurveyResponsePara)
    {
        dbo_FactSurveyResponseClass clsdbo_FactSurveyResponse = new dbo_FactSurveyResponseClass();
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement
            = "SELECT " 
            + "     [SurveyResponseKey] "
            + "    ,[DateKey] "
            + "    ,[CustomerKey] "
            + "    ,[ProductCategoryKey] "
            + "    ,[EnglishProductCategoryName] "
            + "    ,[ProductSubcategoryKey] "
            + "    ,[EnglishProductSubcategoryName] "
            + "    ,[Date] "
            + "FROM "
            + "     [dbo].[FactSurveyResponse] "
            + "WHERE "
            + "     [SurveyResponseKey] = @SurveyResponseKey "
            + "";
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        selectCommand.CommandType = CommandType.Text;
        selectCommand.Parameters.AddWithValue("@SurveyResponseKey", clsdbo_FactSurveyResponsePara.SurveyResponseKey);
        try
        {
            connection.Open();
            SqlDataReader reader
                = selectCommand.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                clsdbo_FactSurveyResponse.SurveyResponseKey = System.Convert.ToInt32(reader["SurveyResponseKey"]);
                clsdbo_FactSurveyResponse.DateKey = System.Convert.ToInt32(reader["DateKey"]);
                clsdbo_FactSurveyResponse.CustomerKey = System.Convert.ToInt32(reader["CustomerKey"]);
                clsdbo_FactSurveyResponse.ProductCategoryKey = System.Convert.ToInt32(reader["ProductCategoryKey"]);
                clsdbo_FactSurveyResponse.EnglishProductCategoryName = System.Convert.ToString(reader["EnglishProductCategoryName"]);
                clsdbo_FactSurveyResponse.ProductSubcategoryKey = System.Convert.ToInt32(reader["ProductSubcategoryKey"]);
                clsdbo_FactSurveyResponse.EnglishProductSubcategoryName = System.Convert.ToString(reader["EnglishProductSubcategoryName"]);
                clsdbo_FactSurveyResponse.Date = reader["Date"] is DBNull ? null : (DateTime?)reader["Date"];
            }
            else
            {
                clsdbo_FactSurveyResponse = null;
            }
            reader.Close();
        }
        catch (SqlException)
        {
            return clsdbo_FactSurveyResponse;
        }
        finally
        {
            connection.Close();
        }
        return clsdbo_FactSurveyResponse;
    }

    public static bool Add(dbo_FactSurveyResponseClass clsdbo_FactSurveyResponse)
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string insertStatement
            = "INSERT " 
            + "     [dbo].[FactSurveyResponse] "
            + "     ( "
            + "     [DateKey] "
            + "    ,[CustomerKey] "
            + "    ,[ProductCategoryKey] "
            + "    ,[EnglishProductCategoryName] "
            + "    ,[ProductSubcategoryKey] "
            + "    ,[EnglishProductSubcategoryName] "
            + "    ,[Date] "
            + "     ) "
            + "VALUES " 
            + "     ( "
            + "     @DateKey "
            + "    ,@CustomerKey "
            + "    ,@ProductCategoryKey "
            + "    ,@EnglishProductCategoryName "
            + "    ,@ProductSubcategoryKey "
            + "    ,@EnglishProductSubcategoryName "
            + "    ,@Date "
            + "     ) "
            + "";
        SqlCommand insertCommand = new SqlCommand(insertStatement, connection);
        insertCommand.CommandType = CommandType.Text;
        insertCommand.Parameters.AddWithValue("@DateKey", clsdbo_FactSurveyResponse.DateKey);
        insertCommand.Parameters.AddWithValue("@CustomerKey", clsdbo_FactSurveyResponse.CustomerKey);
        insertCommand.Parameters.AddWithValue("@ProductCategoryKey", clsdbo_FactSurveyResponse.ProductCategoryKey);
        insertCommand.Parameters.AddWithValue("@EnglishProductCategoryName", clsdbo_FactSurveyResponse.EnglishProductCategoryName);
        insertCommand.Parameters.AddWithValue("@ProductSubcategoryKey", clsdbo_FactSurveyResponse.ProductSubcategoryKey);
        insertCommand.Parameters.AddWithValue("@EnglishProductSubcategoryName", clsdbo_FactSurveyResponse.EnglishProductSubcategoryName);
        if (clsdbo_FactSurveyResponse.Date.HasValue == true) {
            insertCommand.Parameters.AddWithValue("@Date", clsdbo_FactSurveyResponse.Date);
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

    public static bool Update(dbo_FactSurveyResponseClass olddbo_FactSurveyResponseClass, 
           dbo_FactSurveyResponseClass newdbo_FactSurveyResponseClass)
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string updateStatement
            = "UPDATE "  
            + "     [dbo].[FactSurveyResponse] "
            + "SET "
            + "     [DateKey] = @NewDateKey "
            + "    ,[CustomerKey] = @NewCustomerKey "
            + "    ,[ProductCategoryKey] = @NewProductCategoryKey "
            + "    ,[EnglishProductCategoryName] = @NewEnglishProductCategoryName "
            + "    ,[ProductSubcategoryKey] = @NewProductSubcategoryKey "
            + "    ,[EnglishProductSubcategoryName] = @NewEnglishProductSubcategoryName "
            + "    ,[Date] = @NewDate "
            + "WHERE "
            + "     [SurveyResponseKey] = @OldSurveyResponseKey " 
            + " AND [DateKey] = @OldDateKey " 
            + " AND [CustomerKey] = @OldCustomerKey " 
            + " AND [ProductCategoryKey] = @OldProductCategoryKey " 
            + " AND [EnglishProductCategoryName] = @OldEnglishProductCategoryName " 
            + " AND [ProductSubcategoryKey] = @OldProductSubcategoryKey " 
            + " AND [EnglishProductSubcategoryName] = @OldEnglishProductSubcategoryName " 
            + " AND ((@OldDate IS NULL AND [Date] IS NULL) OR [Date] = @OldDate) " 
            + "";
        SqlCommand updateCommand = new SqlCommand(updateStatement, connection);
        updateCommand.CommandType = CommandType.Text;
        updateCommand.Parameters.AddWithValue("@NewDateKey", newdbo_FactSurveyResponseClass.DateKey);
        updateCommand.Parameters.AddWithValue("@NewCustomerKey", newdbo_FactSurveyResponseClass.CustomerKey);
        updateCommand.Parameters.AddWithValue("@NewProductCategoryKey", newdbo_FactSurveyResponseClass.ProductCategoryKey);
        updateCommand.Parameters.AddWithValue("@NewEnglishProductCategoryName", newdbo_FactSurveyResponseClass.EnglishProductCategoryName);
        updateCommand.Parameters.AddWithValue("@NewProductSubcategoryKey", newdbo_FactSurveyResponseClass.ProductSubcategoryKey);
        updateCommand.Parameters.AddWithValue("@NewEnglishProductSubcategoryName", newdbo_FactSurveyResponseClass.EnglishProductSubcategoryName);
        if (newdbo_FactSurveyResponseClass.Date.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@NewDate", newdbo_FactSurveyResponseClass.Date);
        } else {
            updateCommand.Parameters.AddWithValue("@NewDate", DBNull.Value); }
        updateCommand.Parameters.AddWithValue("@OldSurveyResponseKey", olddbo_FactSurveyResponseClass.SurveyResponseKey);
        updateCommand.Parameters.AddWithValue("@OldDateKey", olddbo_FactSurveyResponseClass.DateKey);
        updateCommand.Parameters.AddWithValue("@OldCustomerKey", olddbo_FactSurveyResponseClass.CustomerKey);
        updateCommand.Parameters.AddWithValue("@OldProductCategoryKey", olddbo_FactSurveyResponseClass.ProductCategoryKey);
        updateCommand.Parameters.AddWithValue("@OldEnglishProductCategoryName", olddbo_FactSurveyResponseClass.EnglishProductCategoryName);
        updateCommand.Parameters.AddWithValue("@OldProductSubcategoryKey", olddbo_FactSurveyResponseClass.ProductSubcategoryKey);
        updateCommand.Parameters.AddWithValue("@OldEnglishProductSubcategoryName", olddbo_FactSurveyResponseClass.EnglishProductSubcategoryName);
        if (olddbo_FactSurveyResponseClass.Date.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@OldDate", olddbo_FactSurveyResponseClass.Date);
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

    public static bool Delete(dbo_FactSurveyResponseClass clsdbo_FactSurveyResponse)
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string deleteStatement
            = "DELETE FROM "  
            + "     [dbo].[FactSurveyResponse] "
            + "WHERE " 
            + "     [SurveyResponseKey] = @OldSurveyResponseKey " 
            + " AND [DateKey] = @OldDateKey " 
            + " AND [CustomerKey] = @OldCustomerKey " 
            + " AND [ProductCategoryKey] = @OldProductCategoryKey " 
            + " AND [EnglishProductCategoryName] = @OldEnglishProductCategoryName " 
            + " AND [ProductSubcategoryKey] = @OldProductSubcategoryKey " 
            + " AND [EnglishProductSubcategoryName] = @OldEnglishProductSubcategoryName " 
            + " AND ((@OldDate IS NULL AND [Date] IS NULL) OR [Date] = @OldDate) " 
            + "";
        SqlCommand deleteCommand = new SqlCommand(deleteStatement, connection);
        deleteCommand.CommandType = CommandType.Text;
        deleteCommand.Parameters.AddWithValue("@OldSurveyResponseKey", clsdbo_FactSurveyResponse.SurveyResponseKey);
        deleteCommand.Parameters.AddWithValue("@OldDateKey", clsdbo_FactSurveyResponse.DateKey);
        deleteCommand.Parameters.AddWithValue("@OldCustomerKey", clsdbo_FactSurveyResponse.CustomerKey);
        deleteCommand.Parameters.AddWithValue("@OldProductCategoryKey", clsdbo_FactSurveyResponse.ProductCategoryKey);
        deleteCommand.Parameters.AddWithValue("@OldEnglishProductCategoryName", clsdbo_FactSurveyResponse.EnglishProductCategoryName);
        deleteCommand.Parameters.AddWithValue("@OldProductSubcategoryKey", clsdbo_FactSurveyResponse.ProductSubcategoryKey);
        deleteCommand.Parameters.AddWithValue("@OldEnglishProductSubcategoryName", clsdbo_FactSurveyResponse.EnglishProductSubcategoryName);
        if (clsdbo_FactSurveyResponse.Date.HasValue == true) {
            deleteCommand.Parameters.AddWithValue("@OldDate", clsdbo_FactSurveyResponse.Date);
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

 
