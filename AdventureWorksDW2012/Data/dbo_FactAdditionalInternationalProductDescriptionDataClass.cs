using System;
using System.Data;
using System.Data.SqlClient;

public class dbo_FactAdditionalInternationalProductDescriptionDataClass
{

    public static DataTable SelectAll()
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement
            = "SELECT "  
            + "     [dbo].[FactAdditionalInternationalProductDescription].[ProductKey] "
            + "    ,[dbo].[FactAdditionalInternationalProductDescription].[CultureName] "
            + "    ,[dbo].[FactAdditionalInternationalProductDescription].[ProductDescription] "
            + "FROM " 
            + "     [dbo].[FactAdditionalInternationalProductDescription] " 
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
            + "     [dbo].[FactAdditionalInternationalProductDescription].[ProductKey] "
            + "    ,[dbo].[FactAdditionalInternationalProductDescription].[CultureName] "
            + "    ,[dbo].[FactAdditionalInternationalProductDescription].[ProductDescription] "
            + "FROM " 
            + "     [dbo].[FactAdditionalInternationalProductDescription] " 
                + "WHERE " 
                + "     (@ProductKey IS NULL OR @ProductKey = '' OR [FactAdditionalInternationalProductDescription].[ProductKey] LIKE '%' + LTRIM(RTRIM(@ProductKey)) + '%') " 
                + "AND   (@CultureName IS NULL OR @CultureName = '' OR [FactAdditionalInternationalProductDescription].[CultureName] LIKE '%' + LTRIM(RTRIM(@CultureName)) + '%') " 
                + "AND   (@ProductDescription IS NULL OR @ProductDescription = '' OR [FactAdditionalInternationalProductDescription].[ProductDescription] LIKE '%' + LTRIM(RTRIM(@ProductDescription)) + '%') " 
                + "";
        } else if (sCondition == "Equals") {
            selectStatement
                = "SELECT "
            + "     [dbo].[FactAdditionalInternationalProductDescription].[ProductKey] "
            + "    ,[dbo].[FactAdditionalInternationalProductDescription].[CultureName] "
            + "    ,[dbo].[FactAdditionalInternationalProductDescription].[ProductDescription] "
            + "FROM " 
            + "     [dbo].[FactAdditionalInternationalProductDescription] " 
                + "WHERE " 
                + "     (@ProductKey IS NULL OR @ProductKey = '' OR [FactAdditionalInternationalProductDescription].[ProductKey] = LTRIM(RTRIM(@ProductKey))) " 
                + "AND   (@CultureName IS NULL OR @CultureName = '' OR [FactAdditionalInternationalProductDescription].[CultureName] = LTRIM(RTRIM(@CultureName))) " 
                + "AND   (@ProductDescription IS NULL OR @ProductDescription = '' OR [FactAdditionalInternationalProductDescription].[ProductDescription] = LTRIM(RTRIM(@ProductDescription))) " 
                + "";
        } else if  (sCondition == "Starts with...") {
            selectStatement
                = "SELECT "
            + "     [dbo].[FactAdditionalInternationalProductDescription].[ProductKey] "
            + "    ,[dbo].[FactAdditionalInternationalProductDescription].[CultureName] "
            + "    ,[dbo].[FactAdditionalInternationalProductDescription].[ProductDescription] "
            + "FROM " 
            + "     [dbo].[FactAdditionalInternationalProductDescription] " 
                + "WHERE " 
                + "     (@ProductKey IS NULL OR @ProductKey = '' OR [FactAdditionalInternationalProductDescription].[ProductKey] LIKE LTRIM(RTRIM(@ProductKey)) + '%') " 
                + "AND   (@CultureName IS NULL OR @CultureName = '' OR [FactAdditionalInternationalProductDescription].[CultureName] LIKE LTRIM(RTRIM(@CultureName)) + '%') " 
                + "AND   (@ProductDescription IS NULL OR @ProductDescription = '' OR [FactAdditionalInternationalProductDescription].[ProductDescription] LIKE LTRIM(RTRIM(@ProductDescription)) + '%') " 
                + "";
        } else if  (sCondition == "More than...") {
            selectStatement
                = "SELECT "
            + "     [dbo].[FactAdditionalInternationalProductDescription].[ProductKey] "
            + "    ,[dbo].[FactAdditionalInternationalProductDescription].[CultureName] "
            + "    ,[dbo].[FactAdditionalInternationalProductDescription].[ProductDescription] "
            + "FROM " 
            + "     [dbo].[FactAdditionalInternationalProductDescription] " 
                + "WHERE " 
                + "     (@ProductKey IS NULL OR @ProductKey = '' OR [FactAdditionalInternationalProductDescription].[ProductKey] > LTRIM(RTRIM(@ProductKey))) " 
                + "AND   (@CultureName IS NULL OR @CultureName = '' OR [FactAdditionalInternationalProductDescription].[CultureName] > LTRIM(RTRIM(@CultureName))) " 
                + "AND   (@ProductDescription IS NULL OR @ProductDescription = '' OR [FactAdditionalInternationalProductDescription].[ProductDescription] > LTRIM(RTRIM(@ProductDescription))) " 
                + "";
        } else if  (sCondition == "Less than...") {
            selectStatement
                = "SELECT " 
            + "     [dbo].[FactAdditionalInternationalProductDescription].[ProductKey] "
            + "    ,[dbo].[FactAdditionalInternationalProductDescription].[CultureName] "
            + "    ,[dbo].[FactAdditionalInternationalProductDescription].[ProductDescription] "
            + "FROM " 
            + "     [dbo].[FactAdditionalInternationalProductDescription] " 
                + "WHERE " 
                + "     (@ProductKey IS NULL OR @ProductKey = '' OR [FactAdditionalInternationalProductDescription].[ProductKey] < LTRIM(RTRIM(@ProductKey))) " 
                + "AND   (@CultureName IS NULL OR @CultureName = '' OR [FactAdditionalInternationalProductDescription].[CultureName] < LTRIM(RTRIM(@CultureName))) " 
                + "AND   (@ProductDescription IS NULL OR @ProductDescription = '' OR [FactAdditionalInternationalProductDescription].[ProductDescription] < LTRIM(RTRIM(@ProductDescription))) " 
                + "";
        } else if  (sCondition == "Equal or more than...") {
            selectStatement
                = "SELECT "
            + "     [dbo].[FactAdditionalInternationalProductDescription].[ProductKey] "
            + "    ,[dbo].[FactAdditionalInternationalProductDescription].[CultureName] "
            + "    ,[dbo].[FactAdditionalInternationalProductDescription].[ProductDescription] "
            + "FROM " 
            + "     [dbo].[FactAdditionalInternationalProductDescription] " 
                + "WHERE " 
                + "     (@ProductKey IS NULL OR @ProductKey = '' OR [FactAdditionalInternationalProductDescription].[ProductKey] >= LTRIM(RTRIM(@ProductKey))) " 
                + "AND   (@CultureName IS NULL OR @CultureName = '' OR [FactAdditionalInternationalProductDescription].[CultureName] >= LTRIM(RTRIM(@CultureName))) " 
                + "AND   (@ProductDescription IS NULL OR @ProductDescription = '' OR [FactAdditionalInternationalProductDescription].[ProductDescription] >= LTRIM(RTRIM(@ProductDescription))) " 
                + "";
        } else if (sCondition == "Equal or less than...") {
            selectStatement 
                = "SELECT "
            + "     [dbo].[FactAdditionalInternationalProductDescription].[ProductKey] "
            + "    ,[dbo].[FactAdditionalInternationalProductDescription].[CultureName] "
            + "    ,[dbo].[FactAdditionalInternationalProductDescription].[ProductDescription] "
            + "FROM " 
            + "     [dbo].[FactAdditionalInternationalProductDescription] " 
                + "WHERE " 
                + "     (@ProductKey IS NULL OR @ProductKey = '' OR [FactAdditionalInternationalProductDescription].[ProductKey] <= LTRIM(RTRIM(@ProductKey))) " 
                + "AND   (@CultureName IS NULL OR @CultureName = '' OR [FactAdditionalInternationalProductDescription].[CultureName] <= LTRIM(RTRIM(@CultureName))) " 
                + "AND   (@ProductDescription IS NULL OR @ProductDescription = '' OR [FactAdditionalInternationalProductDescription].[ProductDescription] <= LTRIM(RTRIM(@ProductDescription))) " 
                + "";
        }
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        selectCommand.CommandType = CommandType.Text;
        if (sField == "Product Key") {
            selectCommand.Parameters.AddWithValue("@ProductKey", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@ProductKey", DBNull.Value); }
        if (sField == "Culture Name") {
            selectCommand.Parameters.AddWithValue("@CultureName", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@CultureName", DBNull.Value); }
        if (sField == "Product Description") {
            selectCommand.Parameters.AddWithValue("@ProductDescription", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@ProductDescription", DBNull.Value); }
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

    public static dbo_FactAdditionalInternationalProductDescriptionClass Select_Record(dbo_FactAdditionalInternationalProductDescriptionClass clsdbo_FactAdditionalInternationalProductDescriptionPara)
    {
        dbo_FactAdditionalInternationalProductDescriptionClass clsdbo_FactAdditionalInternationalProductDescription = new dbo_FactAdditionalInternationalProductDescriptionClass();
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement
            = "SELECT " 
            + "     [ProductKey] "
            + "    ,[CultureName] "
            + "    ,[ProductDescription] "
            + "FROM "
            + "     [dbo].[FactAdditionalInternationalProductDescription] "
            + "WHERE "
            + "     [ProductKey] = @ProductKey "
            + " AND [CultureName] = @CultureName "
            + "";
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        selectCommand.CommandType = CommandType.Text;
        selectCommand.Parameters.AddWithValue("@ProductKey", clsdbo_FactAdditionalInternationalProductDescriptionPara.ProductKey);
        selectCommand.Parameters.AddWithValue("@CultureName", clsdbo_FactAdditionalInternationalProductDescriptionPara.CultureName);
        try
        {
            connection.Open();
            SqlDataReader reader
                = selectCommand.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                clsdbo_FactAdditionalInternationalProductDescription.ProductKey = System.Convert.ToInt32(reader["ProductKey"]);
                clsdbo_FactAdditionalInternationalProductDescription.CultureName = System.Convert.ToString(reader["CultureName"]);
                clsdbo_FactAdditionalInternationalProductDescription.ProductDescription = System.Convert.ToString(reader["ProductDescription"]);
            }
            else
            {
                clsdbo_FactAdditionalInternationalProductDescription = null;
            }
            reader.Close();
        }
        catch (SqlException)
        {
            return clsdbo_FactAdditionalInternationalProductDescription;
        }
        finally
        {
            connection.Close();
        }
        return clsdbo_FactAdditionalInternationalProductDescription;
    }

    public static bool Add(dbo_FactAdditionalInternationalProductDescriptionClass clsdbo_FactAdditionalInternationalProductDescription)
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string insertStatement
            = "INSERT " 
            + "     [dbo].[FactAdditionalInternationalProductDescription] "
            + "     ( "
            + "     [ProductKey] "
            + "    ,[CultureName] "
            + "    ,[ProductDescription] "
            + "     ) "
            + "VALUES " 
            + "     ( "
            + "     @ProductKey "
            + "    ,@CultureName "
            + "    ,@ProductDescription "
            + "     ) "
            + "";
        SqlCommand insertCommand = new SqlCommand(insertStatement, connection);
        insertCommand.CommandType = CommandType.Text;
        insertCommand.Parameters.AddWithValue("@ProductKey", clsdbo_FactAdditionalInternationalProductDescription.ProductKey);
        insertCommand.Parameters.AddWithValue("@CultureName", clsdbo_FactAdditionalInternationalProductDescription.CultureName);
        insertCommand.Parameters.AddWithValue("@ProductDescription", clsdbo_FactAdditionalInternationalProductDescription.ProductDescription);
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

    public static bool Update(dbo_FactAdditionalInternationalProductDescriptionClass olddbo_FactAdditionalInternationalProductDescriptionClass, 
           dbo_FactAdditionalInternationalProductDescriptionClass newdbo_FactAdditionalInternationalProductDescriptionClass)
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string updateStatement
            = "UPDATE "  
            + "     [dbo].[FactAdditionalInternationalProductDescription] "
            + "SET "
            + "     [ProductKey] = @NewProductKey "
            + "    ,[CultureName] = @NewCultureName "
            + "    ,[ProductDescription] = @NewProductDescription "
            + "WHERE "
            + "     [ProductKey] = @OldProductKey " 
            + " AND [CultureName] = @OldCultureName " 
            + " AND [ProductDescription] = @OldProductDescription " 
            + "";
        SqlCommand updateCommand = new SqlCommand(updateStatement, connection);
        updateCommand.CommandType = CommandType.Text;
        updateCommand.Parameters.AddWithValue("@NewProductKey", newdbo_FactAdditionalInternationalProductDescriptionClass.ProductKey);
        updateCommand.Parameters.AddWithValue("@NewCultureName", newdbo_FactAdditionalInternationalProductDescriptionClass.CultureName);
        updateCommand.Parameters.AddWithValue("@NewProductDescription", newdbo_FactAdditionalInternationalProductDescriptionClass.ProductDescription);
        updateCommand.Parameters.AddWithValue("@OldProductKey", olddbo_FactAdditionalInternationalProductDescriptionClass.ProductKey);
        updateCommand.Parameters.AddWithValue("@OldCultureName", olddbo_FactAdditionalInternationalProductDescriptionClass.CultureName);
        updateCommand.Parameters.AddWithValue("@OldProductDescription", olddbo_FactAdditionalInternationalProductDescriptionClass.ProductDescription);
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

    public static bool Delete(dbo_FactAdditionalInternationalProductDescriptionClass clsdbo_FactAdditionalInternationalProductDescription)
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string deleteStatement
            = "DELETE FROM "  
            + "     [dbo].[FactAdditionalInternationalProductDescription] "
            + "WHERE " 
            + "     [ProductKey] = @OldProductKey " 
            + " AND [CultureName] = @OldCultureName " 
            + " AND [ProductDescription] = @OldProductDescription " 
            + "";
        SqlCommand deleteCommand = new SqlCommand(deleteStatement, connection);
        deleteCommand.CommandType = CommandType.Text;
        deleteCommand.Parameters.AddWithValue("@OldProductKey", clsdbo_FactAdditionalInternationalProductDescription.ProductKey);
        deleteCommand.Parameters.AddWithValue("@OldCultureName", clsdbo_FactAdditionalInternationalProductDescription.CultureName);
        deleteCommand.Parameters.AddWithValue("@OldProductDescription", clsdbo_FactAdditionalInternationalProductDescription.ProductDescription);
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

 
