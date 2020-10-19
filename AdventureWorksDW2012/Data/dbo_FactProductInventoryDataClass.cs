using System;
using System.Data;
using System.Data.SqlClient;

public class dbo_FactProductInventoryDataClass
{

    public static DataTable SelectAll()
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement
            = "SELECT "  
            + "     [A265].[ProductAlternateKey] "
            + "    ,[A266].[EnglishDayNameOfWeek] "
            + "    ,[dbo].[FactProductInventory].[MovementDate] "
            + "    ,[dbo].[FactProductInventory].[UnitCost] "
            + "    ,[dbo].[FactProductInventory].[UnitsIn] "
            + "    ,[dbo].[FactProductInventory].[UnitsOut] "
            + "    ,[dbo].[FactProductInventory].[UnitsBalance] "
            + "FROM " 
            + "     [dbo].[FactProductInventory] " 
            + "INNER JOIN [dbo].[DimProduct] as [A265] ON [dbo].[FactProductInventory].[ProductKey] = [A265].[ProductKey] "
            + "INNER JOIN [dbo].[DimDate] as [A266] ON [dbo].[FactProductInventory].[DateKey] = [A266].[DateKey] "
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
            + "     [A265].[ProductAlternateKey]"
            + "    ,[A266].[EnglishDayNameOfWeek]"
            + "    ,[dbo].[FactProductInventory].[MovementDate] "
            + "    ,[dbo].[FactProductInventory].[UnitCost] "
            + "    ,[dbo].[FactProductInventory].[UnitsIn] "
            + "    ,[dbo].[FactProductInventory].[UnitsOut] "
            + "    ,[dbo].[FactProductInventory].[UnitsBalance] "
            + "FROM " 
            + "     [dbo].[FactProductInventory] " 
            + "INNER JOIN [dbo].[DimProduct] as [A265] ON [dbo].[FactProductInventory].[ProductKey] = [A265].[ProductKey] "
            + "INNER JOIN [dbo].[DimDate] as [A266] ON [dbo].[FactProductInventory].[DateKey] = [A266].[DateKey] "
                + "WHERE " 
                + "     (@ProductAlternateKey265 IS NULL OR @ProductAlternateKey265 = '' OR [A265].[ProductAlternateKey] LIKE '%' + LTRIM(RTRIM(@ProductAlternateKey265)) + '%') " 
                + "AND   (@EnglishDayNameOfWeek266 IS NULL OR @EnglishDayNameOfWeek266 = '' OR [A266].[EnglishDayNameOfWeek] LIKE '%' + LTRIM(RTRIM(@EnglishDayNameOfWeek266)) + '%') " 
                + "AND   (@MovementDate IS NULL OR @MovementDate = '' OR [FactProductInventory].[MovementDate] LIKE '%' + LTRIM(RTRIM(@MovementDate)) + '%') " 
                + "AND   (@UnitCost IS NULL OR @UnitCost = '' OR [FactProductInventory].[UnitCost] LIKE '%' + LTRIM(RTRIM(@UnitCost)) + '%') " 
                + "AND   (@UnitsIn IS NULL OR @UnitsIn = '' OR [FactProductInventory].[UnitsIn] LIKE '%' + LTRIM(RTRIM(@UnitsIn)) + '%') " 
                + "AND   (@UnitsOut IS NULL OR @UnitsOut = '' OR [FactProductInventory].[UnitsOut] LIKE '%' + LTRIM(RTRIM(@UnitsOut)) + '%') " 
                + "AND   (@UnitsBalance IS NULL OR @UnitsBalance = '' OR [FactProductInventory].[UnitsBalance] LIKE '%' + LTRIM(RTRIM(@UnitsBalance)) + '%') " 
                + "";
        } else if (sCondition == "Equals") {
            selectStatement
                = "SELECT "
            + "     [A265].[ProductAlternateKey]"
            + "    ,[A266].[EnglishDayNameOfWeek]"
            + "    ,[dbo].[FactProductInventory].[MovementDate] "
            + "    ,[dbo].[FactProductInventory].[UnitCost] "
            + "    ,[dbo].[FactProductInventory].[UnitsIn] "
            + "    ,[dbo].[FactProductInventory].[UnitsOut] "
            + "    ,[dbo].[FactProductInventory].[UnitsBalance] "
            + "FROM " 
            + "     [dbo].[FactProductInventory] " 
            + "INNER JOIN [dbo].[DimProduct] as [A265] ON [dbo].[FactProductInventory].[ProductKey] = [A265].[ProductKey] "
            + "INNER JOIN [dbo].[DimDate] as [A266] ON [dbo].[FactProductInventory].[DateKey] = [A266].[DateKey] "
                + "WHERE " 
                + "     (@ProductAlternateKey265 IS NULL OR @ProductAlternateKey265 = '' OR [A265].[ProductAlternateKey] = LTRIM(RTRIM(@ProductAlternateKey265))) " 
                + "AND   (@EnglishDayNameOfWeek266 IS NULL OR @EnglishDayNameOfWeek266 = '' OR [A266].[EnglishDayNameOfWeek] = LTRIM(RTRIM(@EnglishDayNameOfWeek266))) " 
                + "AND   (@MovementDate IS NULL OR @MovementDate = '' OR [FactProductInventory].[MovementDate] = LTRIM(RTRIM(@MovementDate))) " 
                + "AND   (@UnitCost IS NULL OR @UnitCost = '' OR [FactProductInventory].[UnitCost] = LTRIM(RTRIM(@UnitCost))) " 
                + "AND   (@UnitsIn IS NULL OR @UnitsIn = '' OR [FactProductInventory].[UnitsIn] = LTRIM(RTRIM(@UnitsIn))) " 
                + "AND   (@UnitsOut IS NULL OR @UnitsOut = '' OR [FactProductInventory].[UnitsOut] = LTRIM(RTRIM(@UnitsOut))) " 
                + "AND   (@UnitsBalance IS NULL OR @UnitsBalance = '' OR [FactProductInventory].[UnitsBalance] = LTRIM(RTRIM(@UnitsBalance))) " 
                + "";
        } else if  (sCondition == "Starts with...") {
            selectStatement
                = "SELECT "
            + "     [A265].[ProductAlternateKey]"
            + "    ,[A266].[EnglishDayNameOfWeek]"
            + "    ,[dbo].[FactProductInventory].[MovementDate] "
            + "    ,[dbo].[FactProductInventory].[UnitCost] "
            + "    ,[dbo].[FactProductInventory].[UnitsIn] "
            + "    ,[dbo].[FactProductInventory].[UnitsOut] "
            + "    ,[dbo].[FactProductInventory].[UnitsBalance] "
            + "FROM " 
            + "     [dbo].[FactProductInventory] " 
            + "INNER JOIN [dbo].[DimProduct] as [A265] ON [dbo].[FactProductInventory].[ProductKey] = [A265].[ProductKey] "
            + "INNER JOIN [dbo].[DimDate] as [A266] ON [dbo].[FactProductInventory].[DateKey] = [A266].[DateKey] "
                + "WHERE " 
                + "     (@ProductAlternateKey265 IS NULL OR @ProductAlternateKey265 = '' OR [A265].[ProductAlternateKey] LIKE LTRIM(RTRIM(@ProductAlternateKey265)) + '%') " 
                + "AND   (@EnglishDayNameOfWeek266 IS NULL OR @EnglishDayNameOfWeek266 = '' OR [A266].[EnglishDayNameOfWeek] LIKE LTRIM(RTRIM(@EnglishDayNameOfWeek266)) + '%') " 
                + "AND   (@MovementDate IS NULL OR @MovementDate = '' OR [FactProductInventory].[MovementDate] LIKE LTRIM(RTRIM(@MovementDate)) + '%') " 
                + "AND   (@UnitCost IS NULL OR @UnitCost = '' OR [FactProductInventory].[UnitCost] LIKE LTRIM(RTRIM(@UnitCost)) + '%') " 
                + "AND   (@UnitsIn IS NULL OR @UnitsIn = '' OR [FactProductInventory].[UnitsIn] LIKE LTRIM(RTRIM(@UnitsIn)) + '%') " 
                + "AND   (@UnitsOut IS NULL OR @UnitsOut = '' OR [FactProductInventory].[UnitsOut] LIKE LTRIM(RTRIM(@UnitsOut)) + '%') " 
                + "AND   (@UnitsBalance IS NULL OR @UnitsBalance = '' OR [FactProductInventory].[UnitsBalance] LIKE LTRIM(RTRIM(@UnitsBalance)) + '%') " 
                + "";
        } else if  (sCondition == "More than...") {
            selectStatement
                = "SELECT "
            + "     [A265].[ProductAlternateKey]"
            + "    ,[A266].[EnglishDayNameOfWeek]"
            + "    ,[dbo].[FactProductInventory].[MovementDate] "
            + "    ,[dbo].[FactProductInventory].[UnitCost] "
            + "    ,[dbo].[FactProductInventory].[UnitsIn] "
            + "    ,[dbo].[FactProductInventory].[UnitsOut] "
            + "    ,[dbo].[FactProductInventory].[UnitsBalance] "
            + "FROM " 
            + "     [dbo].[FactProductInventory] " 
            + "INNER JOIN [dbo].[DimProduct] as [A265] ON [dbo].[FactProductInventory].[ProductKey] = [A265].[ProductKey] "
            + "INNER JOIN [dbo].[DimDate] as [A266] ON [dbo].[FactProductInventory].[DateKey] = [A266].[DateKey] "
                + "WHERE " 
                + "     (@ProductAlternateKey265 IS NULL OR @ProductAlternateKey265 = '' OR [A265].[ProductAlternateKey] > LTRIM(RTRIM(@ProductAlternateKey265))) " 
                + "AND   (@EnglishDayNameOfWeek266 IS NULL OR @EnglishDayNameOfWeek266 = '' OR [A266].[EnglishDayNameOfWeek] > LTRIM(RTRIM(@EnglishDayNameOfWeek266))) " 
                + "AND   (@MovementDate IS NULL OR @MovementDate = '' OR [FactProductInventory].[MovementDate] > LTRIM(RTRIM(@MovementDate))) " 
                + "AND   (@UnitCost IS NULL OR @UnitCost = '' OR [FactProductInventory].[UnitCost] > LTRIM(RTRIM(@UnitCost))) " 
                + "AND   (@UnitsIn IS NULL OR @UnitsIn = '' OR [FactProductInventory].[UnitsIn] > LTRIM(RTRIM(@UnitsIn))) " 
                + "AND   (@UnitsOut IS NULL OR @UnitsOut = '' OR [FactProductInventory].[UnitsOut] > LTRIM(RTRIM(@UnitsOut))) " 
                + "AND   (@UnitsBalance IS NULL OR @UnitsBalance = '' OR [FactProductInventory].[UnitsBalance] > LTRIM(RTRIM(@UnitsBalance))) " 
                + "";
        } else if  (sCondition == "Less than...") {
            selectStatement
                = "SELECT " 
            + "     [A265].[ProductAlternateKey]"
            + "    ,[A266].[EnglishDayNameOfWeek]"
            + "    ,[dbo].[FactProductInventory].[MovementDate] "
            + "    ,[dbo].[FactProductInventory].[UnitCost] "
            + "    ,[dbo].[FactProductInventory].[UnitsIn] "
            + "    ,[dbo].[FactProductInventory].[UnitsOut] "
            + "    ,[dbo].[FactProductInventory].[UnitsBalance] "
            + "FROM " 
            + "     [dbo].[FactProductInventory] " 
            + "INNER JOIN [dbo].[DimProduct] as [A265] ON [dbo].[FactProductInventory].[ProductKey] = [A265].[ProductKey] "
            + "INNER JOIN [dbo].[DimDate] as [A266] ON [dbo].[FactProductInventory].[DateKey] = [A266].[DateKey] "
                + "WHERE " 
                + "     (@ProductAlternateKey265 IS NULL OR @ProductAlternateKey265 = '' OR [A265].[ProductAlternateKey] < LTRIM(RTRIM(@ProductAlternateKey265))) " 
                + "AND   (@EnglishDayNameOfWeek266 IS NULL OR @EnglishDayNameOfWeek266 = '' OR [A266].[EnglishDayNameOfWeek] < LTRIM(RTRIM(@EnglishDayNameOfWeek266))) " 
                + "AND   (@MovementDate IS NULL OR @MovementDate = '' OR [FactProductInventory].[MovementDate] < LTRIM(RTRIM(@MovementDate))) " 
                + "AND   (@UnitCost IS NULL OR @UnitCost = '' OR [FactProductInventory].[UnitCost] < LTRIM(RTRIM(@UnitCost))) " 
                + "AND   (@UnitsIn IS NULL OR @UnitsIn = '' OR [FactProductInventory].[UnitsIn] < LTRIM(RTRIM(@UnitsIn))) " 
                + "AND   (@UnitsOut IS NULL OR @UnitsOut = '' OR [FactProductInventory].[UnitsOut] < LTRIM(RTRIM(@UnitsOut))) " 
                + "AND   (@UnitsBalance IS NULL OR @UnitsBalance = '' OR [FactProductInventory].[UnitsBalance] < LTRIM(RTRIM(@UnitsBalance))) " 
                + "";
        } else if  (sCondition == "Equal or more than...") {
            selectStatement
                = "SELECT "
            + "     [A265].[ProductAlternateKey]"
            + "    ,[A266].[EnglishDayNameOfWeek]"
            + "    ,[dbo].[FactProductInventory].[MovementDate] "
            + "    ,[dbo].[FactProductInventory].[UnitCost] "
            + "    ,[dbo].[FactProductInventory].[UnitsIn] "
            + "    ,[dbo].[FactProductInventory].[UnitsOut] "
            + "    ,[dbo].[FactProductInventory].[UnitsBalance] "
            + "FROM " 
            + "     [dbo].[FactProductInventory] " 
            + "INNER JOIN [dbo].[DimProduct] as [A265] ON [dbo].[FactProductInventory].[ProductKey] = [A265].[ProductKey] "
            + "INNER JOIN [dbo].[DimDate] as [A266] ON [dbo].[FactProductInventory].[DateKey] = [A266].[DateKey] "
                + "WHERE " 
                + "     (@ProductAlternateKey265 IS NULL OR @ProductAlternateKey265 = '' OR [A265].[ProductAlternateKey] >= LTRIM(RTRIM(@ProductAlternateKey265))) " 
                + "AND   (@EnglishDayNameOfWeek266 IS NULL OR @EnglishDayNameOfWeek266 = '' OR [A266].[EnglishDayNameOfWeek] >= LTRIM(RTRIM(@EnglishDayNameOfWeek266))) " 
                + "AND   (@MovementDate IS NULL OR @MovementDate = '' OR [FactProductInventory].[MovementDate] >= LTRIM(RTRIM(@MovementDate))) " 
                + "AND   (@UnitCost IS NULL OR @UnitCost = '' OR [FactProductInventory].[UnitCost] >= LTRIM(RTRIM(@UnitCost))) " 
                + "AND   (@UnitsIn IS NULL OR @UnitsIn = '' OR [FactProductInventory].[UnitsIn] >= LTRIM(RTRIM(@UnitsIn))) " 
                + "AND   (@UnitsOut IS NULL OR @UnitsOut = '' OR [FactProductInventory].[UnitsOut] >= LTRIM(RTRIM(@UnitsOut))) " 
                + "AND   (@UnitsBalance IS NULL OR @UnitsBalance = '' OR [FactProductInventory].[UnitsBalance] >= LTRIM(RTRIM(@UnitsBalance))) " 
                + "";
        } else if (sCondition == "Equal or less than...") {
            selectStatement 
                = "SELECT "
            + "     [A265].[ProductAlternateKey]"
            + "    ,[A266].[EnglishDayNameOfWeek]"
            + "    ,[dbo].[FactProductInventory].[MovementDate] "
            + "    ,[dbo].[FactProductInventory].[UnitCost] "
            + "    ,[dbo].[FactProductInventory].[UnitsIn] "
            + "    ,[dbo].[FactProductInventory].[UnitsOut] "
            + "    ,[dbo].[FactProductInventory].[UnitsBalance] "
            + "FROM " 
            + "     [dbo].[FactProductInventory] " 
            + "INNER JOIN [dbo].[DimProduct] as [A265] ON [dbo].[FactProductInventory].[ProductKey] = [A265].[ProductKey] "
            + "INNER JOIN [dbo].[DimDate] as [A266] ON [dbo].[FactProductInventory].[DateKey] = [A266].[DateKey] "
                + "WHERE " 
                + "     (@ProductAlternateKey265 IS NULL OR @ProductAlternateKey265 = '' OR [A265].[ProductAlternateKey] <= LTRIM(RTRIM(@ProductAlternateKey265))) " 
                + "AND   (@EnglishDayNameOfWeek266 IS NULL OR @EnglishDayNameOfWeek266 = '' OR [A266].[EnglishDayNameOfWeek] <= LTRIM(RTRIM(@EnglishDayNameOfWeek266))) " 
                + "AND   (@MovementDate IS NULL OR @MovementDate = '' OR [FactProductInventory].[MovementDate] <= LTRIM(RTRIM(@MovementDate))) " 
                + "AND   (@UnitCost IS NULL OR @UnitCost = '' OR [FactProductInventory].[UnitCost] <= LTRIM(RTRIM(@UnitCost))) " 
                + "AND   (@UnitsIn IS NULL OR @UnitsIn = '' OR [FactProductInventory].[UnitsIn] <= LTRIM(RTRIM(@UnitsIn))) " 
                + "AND   (@UnitsOut IS NULL OR @UnitsOut = '' OR [FactProductInventory].[UnitsOut] <= LTRIM(RTRIM(@UnitsOut))) " 
                + "AND   (@UnitsBalance IS NULL OR @UnitsBalance = '' OR [FactProductInventory].[UnitsBalance] <= LTRIM(RTRIM(@UnitsBalance))) " 
                + "";
        }
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        selectCommand.CommandType = CommandType.Text;
        if (sField == "Product Key") {
            selectCommand.Parameters.AddWithValue("@ProductAlternateKey265", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@ProductAlternateKey265", DBNull.Value); }
        if (sField == "Date Key") {
            selectCommand.Parameters.AddWithValue("@EnglishDayNameOfWeek266", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@EnglishDayNameOfWeek266", DBNull.Value); }
        if (sField == "Movement Date") {
            selectCommand.Parameters.AddWithValue("@MovementDate", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@MovementDate", DBNull.Value); }
        if (sField == "Unit Cost") {
            selectCommand.Parameters.AddWithValue("@UnitCost", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@UnitCost", DBNull.Value); }
        if (sField == "Units In") {
            selectCommand.Parameters.AddWithValue("@UnitsIn", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@UnitsIn", DBNull.Value); }
        if (sField == "Units Out") {
            selectCommand.Parameters.AddWithValue("@UnitsOut", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@UnitsOut", DBNull.Value); }
        if (sField == "Units Balance") {
            selectCommand.Parameters.AddWithValue("@UnitsBalance", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@UnitsBalance", DBNull.Value); }
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

    public static dbo_FactProductInventoryClass Select_Record(dbo_FactProductInventoryClass clsdbo_FactProductInventoryPara)
    {
        dbo_FactProductInventoryClass clsdbo_FactProductInventory = new dbo_FactProductInventoryClass();
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement
            = "SELECT " 
            + "     [ProductKey] "
            + "    ,[DateKey] "
            + "    ,[MovementDate] "
            + "    ,[UnitCost] "
            + "    ,[UnitsIn] "
            + "    ,[UnitsOut] "
            + "    ,[UnitsBalance] "
            + "FROM "
            + "     [dbo].[FactProductInventory] "
            + "WHERE "
            + "     [ProductKey] = @ProductKey "
            + " AND [DateKey] = @DateKey "
            + "";
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        selectCommand.CommandType = CommandType.Text;
        selectCommand.Parameters.AddWithValue("@ProductKey", clsdbo_FactProductInventoryPara.ProductKey);
        selectCommand.Parameters.AddWithValue("@DateKey", clsdbo_FactProductInventoryPara.DateKey);
        try
        {
            connection.Open();
            SqlDataReader reader
                = selectCommand.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                clsdbo_FactProductInventory.ProductKey = System.Convert.ToInt32(reader["ProductKey"]);
                clsdbo_FactProductInventory.DateKey = System.Convert.ToInt32(reader["DateKey"]);
                clsdbo_FactProductInventory.MovementDate = System.Convert.ToDateTime(reader["MovementDate"]);
                clsdbo_FactProductInventory.UnitCost = System.Convert.ToDecimal(reader["UnitCost"]);
                clsdbo_FactProductInventory.UnitsIn = System.Convert.ToInt32(reader["UnitsIn"]);
                clsdbo_FactProductInventory.UnitsOut = System.Convert.ToInt32(reader["UnitsOut"]);
                clsdbo_FactProductInventory.UnitsBalance = System.Convert.ToInt32(reader["UnitsBalance"]);
            }
            else
            {
                clsdbo_FactProductInventory = null;
            }
            reader.Close();
        }
        catch (SqlException)
        {
            return clsdbo_FactProductInventory;
        }
        finally
        {
            connection.Close();
        }
        return clsdbo_FactProductInventory;
    }

    public static bool Add(dbo_FactProductInventoryClass clsdbo_FactProductInventory)
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string insertStatement
            = "INSERT " 
            + "     [dbo].[FactProductInventory] "
            + "     ( "
            + "     [ProductKey] "
            + "    ,[DateKey] "
            + "    ,[MovementDate] "
            + "    ,[UnitCost] "
            + "    ,[UnitsIn] "
            + "    ,[UnitsOut] "
            + "    ,[UnitsBalance] "
            + "     ) "
            + "VALUES " 
            + "     ( "
            + "     @ProductKey "
            + "    ,@DateKey "
            + "    ,@MovementDate "
            + "    ,@UnitCost "
            + "    ,@UnitsIn "
            + "    ,@UnitsOut "
            + "    ,@UnitsBalance "
            + "     ) "
            + "";
        SqlCommand insertCommand = new SqlCommand(insertStatement, connection);
        insertCommand.CommandType = CommandType.Text;
        insertCommand.Parameters.AddWithValue("@ProductKey", clsdbo_FactProductInventory.ProductKey);
        insertCommand.Parameters.AddWithValue("@DateKey", clsdbo_FactProductInventory.DateKey);
        insertCommand.Parameters.AddWithValue("@MovementDate", clsdbo_FactProductInventory.MovementDate);
        insertCommand.Parameters.AddWithValue("@UnitCost", clsdbo_FactProductInventory.UnitCost);
        insertCommand.Parameters.AddWithValue("@UnitsIn", clsdbo_FactProductInventory.UnitsIn);
        insertCommand.Parameters.AddWithValue("@UnitsOut", clsdbo_FactProductInventory.UnitsOut);
        insertCommand.Parameters.AddWithValue("@UnitsBalance", clsdbo_FactProductInventory.UnitsBalance);
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

    public static bool Update(dbo_FactProductInventoryClass olddbo_FactProductInventoryClass, 
           dbo_FactProductInventoryClass newdbo_FactProductInventoryClass)
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string updateStatement
            = "UPDATE "  
            + "     [dbo].[FactProductInventory] "
            + "SET "
            + "     [ProductKey] = @NewProductKey "
            + "    ,[DateKey] = @NewDateKey "
            + "    ,[MovementDate] = @NewMovementDate "
            + "    ,[UnitCost] = @NewUnitCost "
            + "    ,[UnitsIn] = @NewUnitsIn "
            + "    ,[UnitsOut] = @NewUnitsOut "
            + "    ,[UnitsBalance] = @NewUnitsBalance "
            + "WHERE "
            + "     [ProductKey] = @OldProductKey " 
            + " AND [DateKey] = @OldDateKey " 
            + " AND [MovementDate] = @OldMovementDate " 
            + " AND [UnitCost] = @OldUnitCost " 
            + " AND [UnitsIn] = @OldUnitsIn " 
            + " AND [UnitsOut] = @OldUnitsOut " 
            + " AND [UnitsBalance] = @OldUnitsBalance " 
            + "";
        SqlCommand updateCommand = new SqlCommand(updateStatement, connection);
        updateCommand.CommandType = CommandType.Text;
        updateCommand.Parameters.AddWithValue("@NewProductKey", newdbo_FactProductInventoryClass.ProductKey);
        updateCommand.Parameters.AddWithValue("@NewDateKey", newdbo_FactProductInventoryClass.DateKey);
        updateCommand.Parameters.AddWithValue("@NewMovementDate", newdbo_FactProductInventoryClass.MovementDate);
        updateCommand.Parameters.AddWithValue("@NewUnitCost", newdbo_FactProductInventoryClass.UnitCost);
        updateCommand.Parameters.AddWithValue("@NewUnitsIn", newdbo_FactProductInventoryClass.UnitsIn);
        updateCommand.Parameters.AddWithValue("@NewUnitsOut", newdbo_FactProductInventoryClass.UnitsOut);
        updateCommand.Parameters.AddWithValue("@NewUnitsBalance", newdbo_FactProductInventoryClass.UnitsBalance);
        updateCommand.Parameters.AddWithValue("@OldProductKey", olddbo_FactProductInventoryClass.ProductKey);
        updateCommand.Parameters.AddWithValue("@OldDateKey", olddbo_FactProductInventoryClass.DateKey);
        updateCommand.Parameters.AddWithValue("@OldMovementDate", olddbo_FactProductInventoryClass.MovementDate);
        updateCommand.Parameters.AddWithValue("@OldUnitCost", olddbo_FactProductInventoryClass.UnitCost);
        updateCommand.Parameters.AddWithValue("@OldUnitsIn", olddbo_FactProductInventoryClass.UnitsIn);
        updateCommand.Parameters.AddWithValue("@OldUnitsOut", olddbo_FactProductInventoryClass.UnitsOut);
        updateCommand.Parameters.AddWithValue("@OldUnitsBalance", olddbo_FactProductInventoryClass.UnitsBalance);
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

    public static bool Delete(dbo_FactProductInventoryClass clsdbo_FactProductInventory)
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string deleteStatement
            = "DELETE FROM "  
            + "     [dbo].[FactProductInventory] "
            + "WHERE " 
            + "     [ProductKey] = @OldProductKey " 
            + " AND [DateKey] = @OldDateKey " 
            + " AND [MovementDate] = @OldMovementDate " 
            + " AND [UnitCost] = @OldUnitCost " 
            + " AND [UnitsIn] = @OldUnitsIn " 
            + " AND [UnitsOut] = @OldUnitsOut " 
            + " AND [UnitsBalance] = @OldUnitsBalance " 
            + "";
        SqlCommand deleteCommand = new SqlCommand(deleteStatement, connection);
        deleteCommand.CommandType = CommandType.Text;
        deleteCommand.Parameters.AddWithValue("@OldProductKey", clsdbo_FactProductInventory.ProductKey);
        deleteCommand.Parameters.AddWithValue("@OldDateKey", clsdbo_FactProductInventory.DateKey);
        deleteCommand.Parameters.AddWithValue("@OldMovementDate", clsdbo_FactProductInventory.MovementDate);
        deleteCommand.Parameters.AddWithValue("@OldUnitCost", clsdbo_FactProductInventory.UnitCost);
        deleteCommand.Parameters.AddWithValue("@OldUnitsIn", clsdbo_FactProductInventory.UnitsIn);
        deleteCommand.Parameters.AddWithValue("@OldUnitsOut", clsdbo_FactProductInventory.UnitsOut);
        deleteCommand.Parameters.AddWithValue("@OldUnitsBalance", clsdbo_FactProductInventory.UnitsBalance);
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

 
