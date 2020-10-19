using System;
using System.Data;
using System.Data.SqlClient;

public class dbo_DimSalesTerritoryDataClass
{

    public static DataTable SelectAll()
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement
            = "SELECT "  
            + "     [dbo].[DimSalesTerritory].[SalesTerritoryKey] "
            + "    ,[dbo].[DimSalesTerritory].[SalesTerritoryAlternateKey] "
            + "    ,[dbo].[DimSalesTerritory].[SalesTerritoryRegion] "
            + "    ,[dbo].[DimSalesTerritory].[SalesTerritoryCountry] "
            + "    ,[dbo].[DimSalesTerritory].[SalesTerritoryGroup] "
            + "FROM " 
            + "     [dbo].[DimSalesTerritory] " 
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
            + "     [dbo].[DimSalesTerritory].[SalesTerritoryKey] "
            + "    ,[dbo].[DimSalesTerritory].[SalesTerritoryAlternateKey] "
            + "    ,[dbo].[DimSalesTerritory].[SalesTerritoryRegion] "
            + "    ,[dbo].[DimSalesTerritory].[SalesTerritoryCountry] "
            + "    ,[dbo].[DimSalesTerritory].[SalesTerritoryGroup] "
            + "FROM " 
            + "     [dbo].[DimSalesTerritory] " 
                + "WHERE " 
                + "     (@SalesTerritoryKey IS NULL OR @SalesTerritoryKey = '' OR [DimSalesTerritory].[SalesTerritoryKey] LIKE '%' + LTRIM(RTRIM(@SalesTerritoryKey)) + '%') " 
                + "AND   (@SalesTerritoryAlternateKey IS NULL OR @SalesTerritoryAlternateKey = '' OR [DimSalesTerritory].[SalesTerritoryAlternateKey] LIKE '%' + LTRIM(RTRIM(@SalesTerritoryAlternateKey)) + '%') " 
                + "AND   (@SalesTerritoryRegion IS NULL OR @SalesTerritoryRegion = '' OR [DimSalesTerritory].[SalesTerritoryRegion] LIKE '%' + LTRIM(RTRIM(@SalesTerritoryRegion)) + '%') " 
                + "AND   (@SalesTerritoryCountry IS NULL OR @SalesTerritoryCountry = '' OR [DimSalesTerritory].[SalesTerritoryCountry] LIKE '%' + LTRIM(RTRIM(@SalesTerritoryCountry)) + '%') " 
                + "AND   (@SalesTerritoryGroup IS NULL OR @SalesTerritoryGroup = '' OR [DimSalesTerritory].[SalesTerritoryGroup] LIKE '%' + LTRIM(RTRIM(@SalesTerritoryGroup)) + '%') " 
                + "";
        } else if (sCondition == "Equals") {
            selectStatement
                = "SELECT "
            + "     [dbo].[DimSalesTerritory].[SalesTerritoryKey] "
            + "    ,[dbo].[DimSalesTerritory].[SalesTerritoryAlternateKey] "
            + "    ,[dbo].[DimSalesTerritory].[SalesTerritoryRegion] "
            + "    ,[dbo].[DimSalesTerritory].[SalesTerritoryCountry] "
            + "    ,[dbo].[DimSalesTerritory].[SalesTerritoryGroup] "
            + "FROM " 
            + "     [dbo].[DimSalesTerritory] " 
                + "WHERE " 
                + "     (@SalesTerritoryKey IS NULL OR @SalesTerritoryKey = '' OR [DimSalesTerritory].[SalesTerritoryKey] = LTRIM(RTRIM(@SalesTerritoryKey))) " 
                + "AND   (@SalesTerritoryAlternateKey IS NULL OR @SalesTerritoryAlternateKey = '' OR [DimSalesTerritory].[SalesTerritoryAlternateKey] = LTRIM(RTRIM(@SalesTerritoryAlternateKey))) " 
                + "AND   (@SalesTerritoryRegion IS NULL OR @SalesTerritoryRegion = '' OR [DimSalesTerritory].[SalesTerritoryRegion] = LTRIM(RTRIM(@SalesTerritoryRegion))) " 
                + "AND   (@SalesTerritoryCountry IS NULL OR @SalesTerritoryCountry = '' OR [DimSalesTerritory].[SalesTerritoryCountry] = LTRIM(RTRIM(@SalesTerritoryCountry))) " 
                + "AND   (@SalesTerritoryGroup IS NULL OR @SalesTerritoryGroup = '' OR [DimSalesTerritory].[SalesTerritoryGroup] = LTRIM(RTRIM(@SalesTerritoryGroup))) " 
                + "";
        } else if  (sCondition == "Starts with...") {
            selectStatement
                = "SELECT "
            + "     [dbo].[DimSalesTerritory].[SalesTerritoryKey] "
            + "    ,[dbo].[DimSalesTerritory].[SalesTerritoryAlternateKey] "
            + "    ,[dbo].[DimSalesTerritory].[SalesTerritoryRegion] "
            + "    ,[dbo].[DimSalesTerritory].[SalesTerritoryCountry] "
            + "    ,[dbo].[DimSalesTerritory].[SalesTerritoryGroup] "
            + "FROM " 
            + "     [dbo].[DimSalesTerritory] " 
                + "WHERE " 
                + "     (@SalesTerritoryKey IS NULL OR @SalesTerritoryKey = '' OR [DimSalesTerritory].[SalesTerritoryKey] LIKE LTRIM(RTRIM(@SalesTerritoryKey)) + '%') " 
                + "AND   (@SalesTerritoryAlternateKey IS NULL OR @SalesTerritoryAlternateKey = '' OR [DimSalesTerritory].[SalesTerritoryAlternateKey] LIKE LTRIM(RTRIM(@SalesTerritoryAlternateKey)) + '%') " 
                + "AND   (@SalesTerritoryRegion IS NULL OR @SalesTerritoryRegion = '' OR [DimSalesTerritory].[SalesTerritoryRegion] LIKE LTRIM(RTRIM(@SalesTerritoryRegion)) + '%') " 
                + "AND   (@SalesTerritoryCountry IS NULL OR @SalesTerritoryCountry = '' OR [DimSalesTerritory].[SalesTerritoryCountry] LIKE LTRIM(RTRIM(@SalesTerritoryCountry)) + '%') " 
                + "AND   (@SalesTerritoryGroup IS NULL OR @SalesTerritoryGroup = '' OR [DimSalesTerritory].[SalesTerritoryGroup] LIKE LTRIM(RTRIM(@SalesTerritoryGroup)) + '%') " 
                + "";
        } else if  (sCondition == "More than...") {
            selectStatement
                = "SELECT "
            + "     [dbo].[DimSalesTerritory].[SalesTerritoryKey] "
            + "    ,[dbo].[DimSalesTerritory].[SalesTerritoryAlternateKey] "
            + "    ,[dbo].[DimSalesTerritory].[SalesTerritoryRegion] "
            + "    ,[dbo].[DimSalesTerritory].[SalesTerritoryCountry] "
            + "    ,[dbo].[DimSalesTerritory].[SalesTerritoryGroup] "
            + "FROM " 
            + "     [dbo].[DimSalesTerritory] " 
                + "WHERE " 
                + "     (@SalesTerritoryKey IS NULL OR @SalesTerritoryKey = '' OR [DimSalesTerritory].[SalesTerritoryKey] > LTRIM(RTRIM(@SalesTerritoryKey))) " 
                + "AND   (@SalesTerritoryAlternateKey IS NULL OR @SalesTerritoryAlternateKey = '' OR [DimSalesTerritory].[SalesTerritoryAlternateKey] > LTRIM(RTRIM(@SalesTerritoryAlternateKey))) " 
                + "AND   (@SalesTerritoryRegion IS NULL OR @SalesTerritoryRegion = '' OR [DimSalesTerritory].[SalesTerritoryRegion] > LTRIM(RTRIM(@SalesTerritoryRegion))) " 
                + "AND   (@SalesTerritoryCountry IS NULL OR @SalesTerritoryCountry = '' OR [DimSalesTerritory].[SalesTerritoryCountry] > LTRIM(RTRIM(@SalesTerritoryCountry))) " 
                + "AND   (@SalesTerritoryGroup IS NULL OR @SalesTerritoryGroup = '' OR [DimSalesTerritory].[SalesTerritoryGroup] > LTRIM(RTRIM(@SalesTerritoryGroup))) " 
                + "";
        } else if  (sCondition == "Less than...") {
            selectStatement
                = "SELECT " 
            + "     [dbo].[DimSalesTerritory].[SalesTerritoryKey] "
            + "    ,[dbo].[DimSalesTerritory].[SalesTerritoryAlternateKey] "
            + "    ,[dbo].[DimSalesTerritory].[SalesTerritoryRegion] "
            + "    ,[dbo].[DimSalesTerritory].[SalesTerritoryCountry] "
            + "    ,[dbo].[DimSalesTerritory].[SalesTerritoryGroup] "
            + "FROM " 
            + "     [dbo].[DimSalesTerritory] " 
                + "WHERE " 
                + "     (@SalesTerritoryKey IS NULL OR @SalesTerritoryKey = '' OR [DimSalesTerritory].[SalesTerritoryKey] < LTRIM(RTRIM(@SalesTerritoryKey))) " 
                + "AND   (@SalesTerritoryAlternateKey IS NULL OR @SalesTerritoryAlternateKey = '' OR [DimSalesTerritory].[SalesTerritoryAlternateKey] < LTRIM(RTRIM(@SalesTerritoryAlternateKey))) " 
                + "AND   (@SalesTerritoryRegion IS NULL OR @SalesTerritoryRegion = '' OR [DimSalesTerritory].[SalesTerritoryRegion] < LTRIM(RTRIM(@SalesTerritoryRegion))) " 
                + "AND   (@SalesTerritoryCountry IS NULL OR @SalesTerritoryCountry = '' OR [DimSalesTerritory].[SalesTerritoryCountry] < LTRIM(RTRIM(@SalesTerritoryCountry))) " 
                + "AND   (@SalesTerritoryGroup IS NULL OR @SalesTerritoryGroup = '' OR [DimSalesTerritory].[SalesTerritoryGroup] < LTRIM(RTRIM(@SalesTerritoryGroup))) " 
                + "";
        } else if  (sCondition == "Equal or more than...") {
            selectStatement
                = "SELECT "
            + "     [dbo].[DimSalesTerritory].[SalesTerritoryKey] "
            + "    ,[dbo].[DimSalesTerritory].[SalesTerritoryAlternateKey] "
            + "    ,[dbo].[DimSalesTerritory].[SalesTerritoryRegion] "
            + "    ,[dbo].[DimSalesTerritory].[SalesTerritoryCountry] "
            + "    ,[dbo].[DimSalesTerritory].[SalesTerritoryGroup] "
            + "FROM " 
            + "     [dbo].[DimSalesTerritory] " 
                + "WHERE " 
                + "     (@SalesTerritoryKey IS NULL OR @SalesTerritoryKey = '' OR [DimSalesTerritory].[SalesTerritoryKey] >= LTRIM(RTRIM(@SalesTerritoryKey))) " 
                + "AND   (@SalesTerritoryAlternateKey IS NULL OR @SalesTerritoryAlternateKey = '' OR [DimSalesTerritory].[SalesTerritoryAlternateKey] >= LTRIM(RTRIM(@SalesTerritoryAlternateKey))) " 
                + "AND   (@SalesTerritoryRegion IS NULL OR @SalesTerritoryRegion = '' OR [DimSalesTerritory].[SalesTerritoryRegion] >= LTRIM(RTRIM(@SalesTerritoryRegion))) " 
                + "AND   (@SalesTerritoryCountry IS NULL OR @SalesTerritoryCountry = '' OR [DimSalesTerritory].[SalesTerritoryCountry] >= LTRIM(RTRIM(@SalesTerritoryCountry))) " 
                + "AND   (@SalesTerritoryGroup IS NULL OR @SalesTerritoryGroup = '' OR [DimSalesTerritory].[SalesTerritoryGroup] >= LTRIM(RTRIM(@SalesTerritoryGroup))) " 
                + "";
        } else if (sCondition == "Equal or less than...") {
            selectStatement 
                = "SELECT "
            + "     [dbo].[DimSalesTerritory].[SalesTerritoryKey] "
            + "    ,[dbo].[DimSalesTerritory].[SalesTerritoryAlternateKey] "
            + "    ,[dbo].[DimSalesTerritory].[SalesTerritoryRegion] "
            + "    ,[dbo].[DimSalesTerritory].[SalesTerritoryCountry] "
            + "    ,[dbo].[DimSalesTerritory].[SalesTerritoryGroup] "
            + "FROM " 
            + "     [dbo].[DimSalesTerritory] " 
                + "WHERE " 
                + "     (@SalesTerritoryKey IS NULL OR @SalesTerritoryKey = '' OR [DimSalesTerritory].[SalesTerritoryKey] <= LTRIM(RTRIM(@SalesTerritoryKey))) " 
                + "AND   (@SalesTerritoryAlternateKey IS NULL OR @SalesTerritoryAlternateKey = '' OR [DimSalesTerritory].[SalesTerritoryAlternateKey] <= LTRIM(RTRIM(@SalesTerritoryAlternateKey))) " 
                + "AND   (@SalesTerritoryRegion IS NULL OR @SalesTerritoryRegion = '' OR [DimSalesTerritory].[SalesTerritoryRegion] <= LTRIM(RTRIM(@SalesTerritoryRegion))) " 
                + "AND   (@SalesTerritoryCountry IS NULL OR @SalesTerritoryCountry = '' OR [DimSalesTerritory].[SalesTerritoryCountry] <= LTRIM(RTRIM(@SalesTerritoryCountry))) " 
                + "AND   (@SalesTerritoryGroup IS NULL OR @SalesTerritoryGroup = '' OR [DimSalesTerritory].[SalesTerritoryGroup] <= LTRIM(RTRIM(@SalesTerritoryGroup))) " 
                + "";
        }
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        selectCommand.CommandType = CommandType.Text;
        if (sField == "Sales Territory Key") {
            selectCommand.Parameters.AddWithValue("@SalesTerritoryKey", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@SalesTerritoryKey", DBNull.Value); }
        if (sField == "Sales Territory Alternate Key") {
            selectCommand.Parameters.AddWithValue("@SalesTerritoryAlternateKey", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@SalesTerritoryAlternateKey", DBNull.Value); }
        if (sField == "Sales Territory Region") {
            selectCommand.Parameters.AddWithValue("@SalesTerritoryRegion", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@SalesTerritoryRegion", DBNull.Value); }
        if (sField == "Sales Territory Country") {
            selectCommand.Parameters.AddWithValue("@SalesTerritoryCountry", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@SalesTerritoryCountry", DBNull.Value); }
        if (sField == "Sales Territory Group") {
            selectCommand.Parameters.AddWithValue("@SalesTerritoryGroup", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@SalesTerritoryGroup", DBNull.Value); }
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

    public static dbo_DimSalesTerritoryClass Select_Record(dbo_DimSalesTerritoryClass clsdbo_DimSalesTerritoryPara)
    {
        dbo_DimSalesTerritoryClass clsdbo_DimSalesTerritory = new dbo_DimSalesTerritoryClass();
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement
            = "SELECT " 
            + "     [SalesTerritoryKey] "
            + "    ,[SalesTerritoryAlternateKey] "
            + "    ,[SalesTerritoryRegion] "
            + "    ,[SalesTerritoryCountry] "
            + "    ,[SalesTerritoryGroup] "
            + "FROM "
            + "     [dbo].[DimSalesTerritory] "
            + "WHERE "
            + "     [SalesTerritoryKey] = @SalesTerritoryKey "
            + "";
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        selectCommand.CommandType = CommandType.Text;
        selectCommand.Parameters.AddWithValue("@SalesTerritoryKey", clsdbo_DimSalesTerritoryPara.SalesTerritoryKey);
        try
        {
            connection.Open();
            SqlDataReader reader
                = selectCommand.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                clsdbo_DimSalesTerritory.SalesTerritoryKey = System.Convert.ToInt32(reader["SalesTerritoryKey"]);
                clsdbo_DimSalesTerritory.SalesTerritoryAlternateKey = reader["SalesTerritoryAlternateKey"] is DBNull ? null : (Int32?)reader["SalesTerritoryAlternateKey"];
                clsdbo_DimSalesTerritory.SalesTerritoryRegion = System.Convert.ToString(reader["SalesTerritoryRegion"]);
                clsdbo_DimSalesTerritory.SalesTerritoryCountry = System.Convert.ToString(reader["SalesTerritoryCountry"]);
                clsdbo_DimSalesTerritory.SalesTerritoryGroup = reader["SalesTerritoryGroup"] is DBNull ? null : reader["SalesTerritoryGroup"].ToString();
            }
            else
            {
                clsdbo_DimSalesTerritory = null;
            }
            reader.Close();
        }
        catch (SqlException)
        {
            return clsdbo_DimSalesTerritory;
        }
        finally
        {
            connection.Close();
        }
        return clsdbo_DimSalesTerritory;
    }

    public static bool Add(dbo_DimSalesTerritoryClass clsdbo_DimSalesTerritory)
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string insertStatement
            = "INSERT " 
            + "     [dbo].[DimSalesTerritory] "
            + "     ( "
            + "     [SalesTerritoryAlternateKey] "
            + "    ,[SalesTerritoryRegion] "
            + "    ,[SalesTerritoryCountry] "
            + "    ,[SalesTerritoryGroup] "
            + "     ) "
            + "VALUES " 
            + "     ( "
            + "     @SalesTerritoryAlternateKey "
            + "    ,@SalesTerritoryRegion "
            + "    ,@SalesTerritoryCountry "
            + "    ,@SalesTerritoryGroup "
            + "     ) "
            + "";
        SqlCommand insertCommand = new SqlCommand(insertStatement, connection);
        insertCommand.CommandType = CommandType.Text;
        if (clsdbo_DimSalesTerritory.SalesTerritoryAlternateKey.HasValue == true) {
            insertCommand.Parameters.AddWithValue("@SalesTerritoryAlternateKey", clsdbo_DimSalesTerritory.SalesTerritoryAlternateKey);
        } else {
            insertCommand.Parameters.AddWithValue("@SalesTerritoryAlternateKey", DBNull.Value); }
        insertCommand.Parameters.AddWithValue("@SalesTerritoryRegion", clsdbo_DimSalesTerritory.SalesTerritoryRegion);
        insertCommand.Parameters.AddWithValue("@SalesTerritoryCountry", clsdbo_DimSalesTerritory.SalesTerritoryCountry);
        if (clsdbo_DimSalesTerritory.SalesTerritoryGroup != null) {
            insertCommand.Parameters.AddWithValue("@SalesTerritoryGroup", clsdbo_DimSalesTerritory.SalesTerritoryGroup);
        } else {
            insertCommand.Parameters.AddWithValue("@SalesTerritoryGroup", DBNull.Value); }
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

    public static bool Update(dbo_DimSalesTerritoryClass olddbo_DimSalesTerritoryClass, 
           dbo_DimSalesTerritoryClass newdbo_DimSalesTerritoryClass)
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string updateStatement
            = "UPDATE "  
            + "     [dbo].[DimSalesTerritory] "
            + "SET "
            + "     [SalesTerritoryAlternateKey] = @NewSalesTerritoryAlternateKey "
            + "    ,[SalesTerritoryRegion] = @NewSalesTerritoryRegion "
            + "    ,[SalesTerritoryCountry] = @NewSalesTerritoryCountry "
            + "    ,[SalesTerritoryGroup] = @NewSalesTerritoryGroup "
            + "WHERE "
            + "     [SalesTerritoryKey] = @OldSalesTerritoryKey " 
            + " AND ((@OldSalesTerritoryAlternateKey IS NULL AND [SalesTerritoryAlternateKey] IS NULL) OR [SalesTerritoryAlternateKey] = @OldSalesTerritoryAlternateKey) " 
            + " AND [SalesTerritoryRegion] = @OldSalesTerritoryRegion " 
            + " AND [SalesTerritoryCountry] = @OldSalesTerritoryCountry " 
            + " AND ((@OldSalesTerritoryGroup IS NULL AND [SalesTerritoryGroup] IS NULL) OR [SalesTerritoryGroup] = @OldSalesTerritoryGroup) " 
            + "";
        SqlCommand updateCommand = new SqlCommand(updateStatement, connection);
        updateCommand.CommandType = CommandType.Text;
        if (newdbo_DimSalesTerritoryClass.SalesTerritoryAlternateKey.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@NewSalesTerritoryAlternateKey", newdbo_DimSalesTerritoryClass.SalesTerritoryAlternateKey);
        } else {
            updateCommand.Parameters.AddWithValue("@NewSalesTerritoryAlternateKey", DBNull.Value); }
        updateCommand.Parameters.AddWithValue("@NewSalesTerritoryRegion", newdbo_DimSalesTerritoryClass.SalesTerritoryRegion);
        updateCommand.Parameters.AddWithValue("@NewSalesTerritoryCountry", newdbo_DimSalesTerritoryClass.SalesTerritoryCountry);
        if (newdbo_DimSalesTerritoryClass.SalesTerritoryGroup != null) {
            updateCommand.Parameters.AddWithValue("@NewSalesTerritoryGroup", newdbo_DimSalesTerritoryClass.SalesTerritoryGroup);
        } else {
            updateCommand.Parameters.AddWithValue("@NewSalesTerritoryGroup", DBNull.Value); }
        updateCommand.Parameters.AddWithValue("@OldSalesTerritoryKey", olddbo_DimSalesTerritoryClass.SalesTerritoryKey);
        if (olddbo_DimSalesTerritoryClass.SalesTerritoryAlternateKey.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@OldSalesTerritoryAlternateKey", olddbo_DimSalesTerritoryClass.SalesTerritoryAlternateKey);
        } else {
            updateCommand.Parameters.AddWithValue("@OldSalesTerritoryAlternateKey", DBNull.Value); }
        updateCommand.Parameters.AddWithValue("@OldSalesTerritoryRegion", olddbo_DimSalesTerritoryClass.SalesTerritoryRegion);
        updateCommand.Parameters.AddWithValue("@OldSalesTerritoryCountry", olddbo_DimSalesTerritoryClass.SalesTerritoryCountry);
        if (olddbo_DimSalesTerritoryClass.SalesTerritoryGroup != null) {
            updateCommand.Parameters.AddWithValue("@OldSalesTerritoryGroup", olddbo_DimSalesTerritoryClass.SalesTerritoryGroup);
        } else {
            updateCommand.Parameters.AddWithValue("@OldSalesTerritoryGroup", DBNull.Value); }
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

    public static bool Delete(dbo_DimSalesTerritoryClass clsdbo_DimSalesTerritory)
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string deleteStatement
            = "DELETE FROM "  
            + "     [dbo].[DimSalesTerritory] "
            + "WHERE " 
            + "     [SalesTerritoryKey] = @OldSalesTerritoryKey " 
            + " AND ((@OldSalesTerritoryAlternateKey IS NULL AND [SalesTerritoryAlternateKey] IS NULL) OR [SalesTerritoryAlternateKey] = @OldSalesTerritoryAlternateKey) " 
            + " AND [SalesTerritoryRegion] = @OldSalesTerritoryRegion " 
            + " AND [SalesTerritoryCountry] = @OldSalesTerritoryCountry " 
            + " AND ((@OldSalesTerritoryGroup IS NULL AND [SalesTerritoryGroup] IS NULL) OR [SalesTerritoryGroup] = @OldSalesTerritoryGroup) " 
            + "";
        SqlCommand deleteCommand = new SqlCommand(deleteStatement, connection);
        deleteCommand.CommandType = CommandType.Text;
        deleteCommand.Parameters.AddWithValue("@OldSalesTerritoryKey", clsdbo_DimSalesTerritory.SalesTerritoryKey);
        if (clsdbo_DimSalesTerritory.SalesTerritoryAlternateKey.HasValue == true) {
            deleteCommand.Parameters.AddWithValue("@OldSalesTerritoryAlternateKey", clsdbo_DimSalesTerritory.SalesTerritoryAlternateKey);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldSalesTerritoryAlternateKey", DBNull.Value); }
        deleteCommand.Parameters.AddWithValue("@OldSalesTerritoryRegion", clsdbo_DimSalesTerritory.SalesTerritoryRegion);
        deleteCommand.Parameters.AddWithValue("@OldSalesTerritoryCountry", clsdbo_DimSalesTerritory.SalesTerritoryCountry);
        if (clsdbo_DimSalesTerritory.SalesTerritoryGroup != null) {
            deleteCommand.Parameters.AddWithValue("@OldSalesTerritoryGroup", clsdbo_DimSalesTerritory.SalesTerritoryGroup);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldSalesTerritoryGroup", DBNull.Value); }
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

 
