using System;
using System.Data;
using System.Data.SqlClient;

public class dbo_DimProductDataClass
{

    public static DataTable SelectAll()
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement
            = "SELECT "  
            + "     [dbo].[DimProduct].[ProductKey] "
            + "    ,[dbo].[DimProduct].[ProductAlternateKey] "
            + "    ,[dbo].[DimProductSubcategory].[EnglishProductSubcategoryName] "
            + "    ,[dbo].[DimProduct].[WeightUnitMeasureCode] "
            + "    ,[dbo].[DimProduct].[SizeUnitMeasureCode] "
            + "    ,[dbo].[DimProduct].[EnglishProductName] "
            + "    ,[dbo].[DimProduct].[SpanishProductName] "
            + "    ,[dbo].[DimProduct].[FrenchProductName] "
            + "    ,[dbo].[DimProduct].[StandardCost] "
            + "    ,[dbo].[DimProduct].[FinishedGoodsFlag] "
            + "    ,[dbo].[DimProduct].[Color] "
            + "    ,[dbo].[DimProduct].[SafetyStockLevel] "
            + "    ,[dbo].[DimProduct].[ReorderPoint] "
            + "    ,[dbo].[DimProduct].[ListPrice] "
            + "    ,[dbo].[DimProduct].[Size] "
            + "    ,[dbo].[DimProduct].[SizeRange] "
            + "    ,[dbo].[DimProduct].[Weight] "
            + "    ,[dbo].[DimProduct].[DaysToManufacture] "
            + "    ,[dbo].[DimProduct].[ProductLine] "
            + "    ,[dbo].[DimProduct].[DealerPrice] "
            + "    ,[dbo].[DimProduct].[Class] "
            + "    ,[dbo].[DimProduct].[Style] "
            + "    ,[dbo].[DimProduct].[ModelName] "
            + "    ,[dbo].[DimProduct].[EnglishDescription] "
            + "    ,[dbo].[DimProduct].[FrenchDescription] "
            + "    ,[dbo].[DimProduct].[ChineseDescription] "
            + "    ,[dbo].[DimProduct].[ArabicDescription] "
            + "    ,[dbo].[DimProduct].[HebrewDescription] "
            + "    ,[dbo].[DimProduct].[ThaiDescription] "
            + "    ,[dbo].[DimProduct].[GermanDescription] "
            + "    ,[dbo].[DimProduct].[JapaneseDescription] "
            + "    ,[dbo].[DimProduct].[TurkishDescription] "
            + "    ,[dbo].[DimProduct].[StartDate] "
            + "    ,[dbo].[DimProduct].[EndDate] "
            + "    ,[dbo].[DimProduct].[Status] "
            + "FROM " 
            + "     [dbo].[DimProduct] " 
            + "LEFT JOIN [dbo].[DimProductSubcategory] ON [dbo].[DimProduct].[ProductSubcategoryKey] = [dbo].[DimProductSubcategory].[ProductSubcategoryKey] "
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
            + "     [dbo].[DimProduct].[ProductKey] "
            + "    ,[dbo].[DimProduct].[ProductAlternateKey] "
            + "    ,[dbo].[DimProductSubcategory].[EnglishProductSubcategoryName] "
            + "    ,[dbo].[DimProduct].[WeightUnitMeasureCode] "
            + "    ,[dbo].[DimProduct].[SizeUnitMeasureCode] "
            + "    ,[dbo].[DimProduct].[EnglishProductName] "
            + "    ,[dbo].[DimProduct].[SpanishProductName] "
            + "    ,[dbo].[DimProduct].[FrenchProductName] "
            + "    ,[dbo].[DimProduct].[StandardCost] "
            + "    ,[dbo].[DimProduct].[FinishedGoodsFlag] "
            + "    ,[dbo].[DimProduct].[Color] "
            + "    ,[dbo].[DimProduct].[SafetyStockLevel] "
            + "    ,[dbo].[DimProduct].[ReorderPoint] "
            + "    ,[dbo].[DimProduct].[ListPrice] "
            + "    ,[dbo].[DimProduct].[Size] "
            + "    ,[dbo].[DimProduct].[SizeRange] "
            + "    ,[dbo].[DimProduct].[Weight] "
            + "    ,[dbo].[DimProduct].[DaysToManufacture] "
            + "    ,[dbo].[DimProduct].[ProductLine] "
            + "    ,[dbo].[DimProduct].[DealerPrice] "
            + "    ,[dbo].[DimProduct].[Class] "
            + "    ,[dbo].[DimProduct].[Style] "
            + "    ,[dbo].[DimProduct].[ModelName] "
            + "    ,[dbo].[DimProduct].[EnglishDescription] "
            + "    ,[dbo].[DimProduct].[FrenchDescription] "
            + "    ,[dbo].[DimProduct].[ChineseDescription] "
            + "    ,[dbo].[DimProduct].[ArabicDescription] "
            + "    ,[dbo].[DimProduct].[HebrewDescription] "
            + "    ,[dbo].[DimProduct].[ThaiDescription] "
            + "    ,[dbo].[DimProduct].[GermanDescription] "
            + "    ,[dbo].[DimProduct].[JapaneseDescription] "
            + "    ,[dbo].[DimProduct].[TurkishDescription] "
            + "    ,[dbo].[DimProduct].[StartDate] "
            + "    ,[dbo].[DimProduct].[EndDate] "
            + "    ,[dbo].[DimProduct].[Status] "
            + "FROM " 
            + "     [dbo].[DimProduct] " 
            + "LEFT JOIN [dbo].[DimProductSubcategory] ON [dbo].[DimProduct].[ProductSubcategoryKey] = [dbo].[DimProductSubcategory].[ProductSubcategoryKey] "
                + "WHERE " 
                + "     (@ProductKey IS NULL OR @ProductKey = '' OR [DimProduct].[ProductKey] LIKE '%' + LTRIM(RTRIM(@ProductKey)) + '%') " 
                + "AND   (@ProductAlternateKey IS NULL OR @ProductAlternateKey = '' OR [DimProduct].[ProductAlternateKey] LIKE '%' + LTRIM(RTRIM(@ProductAlternateKey)) + '%') " 
                + "AND   (@EnglishProductSubcategoryName IS NULL OR @EnglishProductSubcategoryName = '' OR [dbo].[DimProductSubcategory].[EnglishProductSubcategoryName] LIKE '%' + LTRIM(RTRIM(@EnglishProductSubcategoryName)) + '%') " 
                + "AND   (@WeightUnitMeasureCode IS NULL OR @WeightUnitMeasureCode = '' OR [DimProduct].[WeightUnitMeasureCode] LIKE '%' + LTRIM(RTRIM(@WeightUnitMeasureCode)) + '%') " 
                + "AND   (@SizeUnitMeasureCode IS NULL OR @SizeUnitMeasureCode = '' OR [DimProduct].[SizeUnitMeasureCode] LIKE '%' + LTRIM(RTRIM(@SizeUnitMeasureCode)) + '%') " 
                + "AND   (@EnglishProductName IS NULL OR @EnglishProductName = '' OR [DimProduct].[EnglishProductName] LIKE '%' + LTRIM(RTRIM(@EnglishProductName)) + '%') " 
                + "AND   (@SpanishProductName IS NULL OR @SpanishProductName = '' OR [DimProduct].[SpanishProductName] LIKE '%' + LTRIM(RTRIM(@SpanishProductName)) + '%') " 
                + "AND   (@FrenchProductName IS NULL OR @FrenchProductName = '' OR [DimProduct].[FrenchProductName] LIKE '%' + LTRIM(RTRIM(@FrenchProductName)) + '%') " 
                + "AND   (@StandardCost IS NULL OR @StandardCost = '' OR [DimProduct].[StandardCost] LIKE '%' + LTRIM(RTRIM(@StandardCost)) + '%') " 
                + "AND   (@FinishedGoodsFlag IS NULL OR @FinishedGoodsFlag = '' OR [DimProduct].[FinishedGoodsFlag] LIKE '%' + LTRIM(RTRIM(@FinishedGoodsFlag)) + '%') " 
                + "AND   (@Color IS NULL OR @Color = '' OR [DimProduct].[Color] LIKE '%' + LTRIM(RTRIM(@Color)) + '%') " 
                + "AND   (@SafetyStockLevel IS NULL OR @SafetyStockLevel = '' OR [DimProduct].[SafetyStockLevel] LIKE '%' + LTRIM(RTRIM(@SafetyStockLevel)) + '%') " 
                + "AND   (@ReorderPoint IS NULL OR @ReorderPoint = '' OR [DimProduct].[ReorderPoint] LIKE '%' + LTRIM(RTRIM(@ReorderPoint)) + '%') " 
                + "AND   (@ListPrice IS NULL OR @ListPrice = '' OR [DimProduct].[ListPrice] LIKE '%' + LTRIM(RTRIM(@ListPrice)) + '%') " 
                + "AND   (@Size IS NULL OR @Size = '' OR [DimProduct].[Size] LIKE '%' + LTRIM(RTRIM(@Size)) + '%') " 
                + "AND   (@SizeRange IS NULL OR @SizeRange = '' OR [DimProduct].[SizeRange] LIKE '%' + LTRIM(RTRIM(@SizeRange)) + '%') " 
                + "AND   (@Weight IS NULL OR @Weight = '' OR [DimProduct].[Weight] LIKE '%' + LTRIM(RTRIM(@Weight)) + '%') " 
                + "AND   (@DaysToManufacture IS NULL OR @DaysToManufacture = '' OR [DimProduct].[DaysToManufacture] LIKE '%' + LTRIM(RTRIM(@DaysToManufacture)) + '%') " 
                + "AND   (@ProductLine IS NULL OR @ProductLine = '' OR [DimProduct].[ProductLine] LIKE '%' + LTRIM(RTRIM(@ProductLine)) + '%') " 
                + "AND   (@DealerPrice IS NULL OR @DealerPrice = '' OR [DimProduct].[DealerPrice] LIKE '%' + LTRIM(RTRIM(@DealerPrice)) + '%') " 
                + "AND   (@Class IS NULL OR @Class = '' OR [DimProduct].[Class] LIKE '%' + LTRIM(RTRIM(@Class)) + '%') " 
                + "AND   (@Style IS NULL OR @Style = '' OR [DimProduct].[Style] LIKE '%' + LTRIM(RTRIM(@Style)) + '%') " 
                + "AND   (@ModelName IS NULL OR @ModelName = '' OR [DimProduct].[ModelName] LIKE '%' + LTRIM(RTRIM(@ModelName)) + '%') " 
                + "AND   (@EnglishDescription IS NULL OR @EnglishDescription = '' OR [DimProduct].[EnglishDescription] LIKE '%' + LTRIM(RTRIM(@EnglishDescription)) + '%') " 
                + "AND   (@FrenchDescription IS NULL OR @FrenchDescription = '' OR [DimProduct].[FrenchDescription] LIKE '%' + LTRIM(RTRIM(@FrenchDescription)) + '%') " 
                + "AND   (@ChineseDescription IS NULL OR @ChineseDescription = '' OR [DimProduct].[ChineseDescription] LIKE '%' + LTRIM(RTRIM(@ChineseDescription)) + '%') " 
                + "AND   (@ArabicDescription IS NULL OR @ArabicDescription = '' OR [DimProduct].[ArabicDescription] LIKE '%' + LTRIM(RTRIM(@ArabicDescription)) + '%') " 
                + "AND   (@HebrewDescription IS NULL OR @HebrewDescription = '' OR [DimProduct].[HebrewDescription] LIKE '%' + LTRIM(RTRIM(@HebrewDescription)) + '%') " 
                + "AND   (@ThaiDescription IS NULL OR @ThaiDescription = '' OR [DimProduct].[ThaiDescription] LIKE '%' + LTRIM(RTRIM(@ThaiDescription)) + '%') " 
                + "AND   (@GermanDescription IS NULL OR @GermanDescription = '' OR [DimProduct].[GermanDescription] LIKE '%' + LTRIM(RTRIM(@GermanDescription)) + '%') " 
                + "AND   (@JapaneseDescription IS NULL OR @JapaneseDescription = '' OR [DimProduct].[JapaneseDescription] LIKE '%' + LTRIM(RTRIM(@JapaneseDescription)) + '%') " 
                + "AND   (@TurkishDescription IS NULL OR @TurkishDescription = '' OR [DimProduct].[TurkishDescription] LIKE '%' + LTRIM(RTRIM(@TurkishDescription)) + '%') " 
                + "AND   (@StartDate IS NULL OR @StartDate = '' OR [DimProduct].[StartDate] LIKE '%' + LTRIM(RTRIM(@StartDate)) + '%') " 
                + "AND   (@EndDate IS NULL OR @EndDate = '' OR [DimProduct].[EndDate] LIKE '%' + LTRIM(RTRIM(@EndDate)) + '%') " 
                + "AND   (@Status IS NULL OR @Status = '' OR [DimProduct].[Status] LIKE '%' + LTRIM(RTRIM(@Status)) + '%') " 
                + "";
        } else if (sCondition == "Equals") {
            selectStatement
                = "SELECT "
            + "     [dbo].[DimProduct].[ProductKey] "
            + "    ,[dbo].[DimProduct].[ProductAlternateKey] "
            + "    ,[dbo].[DimProductSubcategory].[EnglishProductSubcategoryName] "
            + "    ,[dbo].[DimProduct].[WeightUnitMeasureCode] "
            + "    ,[dbo].[DimProduct].[SizeUnitMeasureCode] "
            + "    ,[dbo].[DimProduct].[EnglishProductName] "
            + "    ,[dbo].[DimProduct].[SpanishProductName] "
            + "    ,[dbo].[DimProduct].[FrenchProductName] "
            + "    ,[dbo].[DimProduct].[StandardCost] "
            + "    ,[dbo].[DimProduct].[FinishedGoodsFlag] "
            + "    ,[dbo].[DimProduct].[Color] "
            + "    ,[dbo].[DimProduct].[SafetyStockLevel] "
            + "    ,[dbo].[DimProduct].[ReorderPoint] "
            + "    ,[dbo].[DimProduct].[ListPrice] "
            + "    ,[dbo].[DimProduct].[Size] "
            + "    ,[dbo].[DimProduct].[SizeRange] "
            + "    ,[dbo].[DimProduct].[Weight] "
            + "    ,[dbo].[DimProduct].[DaysToManufacture] "
            + "    ,[dbo].[DimProduct].[ProductLine] "
            + "    ,[dbo].[DimProduct].[DealerPrice] "
            + "    ,[dbo].[DimProduct].[Class] "
            + "    ,[dbo].[DimProduct].[Style] "
            + "    ,[dbo].[DimProduct].[ModelName] "
            + "    ,[dbo].[DimProduct].[EnglishDescription] "
            + "    ,[dbo].[DimProduct].[FrenchDescription] "
            + "    ,[dbo].[DimProduct].[ChineseDescription] "
            + "    ,[dbo].[DimProduct].[ArabicDescription] "
            + "    ,[dbo].[DimProduct].[HebrewDescription] "
            + "    ,[dbo].[DimProduct].[ThaiDescription] "
            + "    ,[dbo].[DimProduct].[GermanDescription] "
            + "    ,[dbo].[DimProduct].[JapaneseDescription] "
            + "    ,[dbo].[DimProduct].[TurkishDescription] "
            + "    ,[dbo].[DimProduct].[StartDate] "
            + "    ,[dbo].[DimProduct].[EndDate] "
            + "    ,[dbo].[DimProduct].[Status] "
            + "FROM " 
            + "     [dbo].[DimProduct] " 
            + "LEFT JOIN [dbo].[DimProductSubcategory] ON [dbo].[DimProduct].[ProductSubcategoryKey] = [dbo].[DimProductSubcategory].[ProductSubcategoryKey] "
                + "WHERE " 
                + "     (@ProductKey IS NULL OR @ProductKey = '' OR [DimProduct].[ProductKey] = LTRIM(RTRIM(@ProductKey))) " 
                + "AND   (@ProductAlternateKey IS NULL OR @ProductAlternateKey = '' OR [DimProduct].[ProductAlternateKey] = LTRIM(RTRIM(@ProductAlternateKey))) " 
                + "AND   (@EnglishProductSubcategoryName IS NULL OR @EnglishProductSubcategoryName = '' OR [dbo].[DimProductSubcategory].[EnglishProductSubcategoryName] = LTRIM(RTRIM(@EnglishProductSubcategoryName))) " 
                + "AND   (@WeightUnitMeasureCode IS NULL OR @WeightUnitMeasureCode = '' OR [DimProduct].[WeightUnitMeasureCode] = LTRIM(RTRIM(@WeightUnitMeasureCode))) " 
                + "AND   (@SizeUnitMeasureCode IS NULL OR @SizeUnitMeasureCode = '' OR [DimProduct].[SizeUnitMeasureCode] = LTRIM(RTRIM(@SizeUnitMeasureCode))) " 
                + "AND   (@EnglishProductName IS NULL OR @EnglishProductName = '' OR [DimProduct].[EnglishProductName] = LTRIM(RTRIM(@EnglishProductName))) " 
                + "AND   (@SpanishProductName IS NULL OR @SpanishProductName = '' OR [DimProduct].[SpanishProductName] = LTRIM(RTRIM(@SpanishProductName))) " 
                + "AND   (@FrenchProductName IS NULL OR @FrenchProductName = '' OR [DimProduct].[FrenchProductName] = LTRIM(RTRIM(@FrenchProductName))) " 
                + "AND   (@StandardCost IS NULL OR @StandardCost = '' OR [DimProduct].[StandardCost] = LTRIM(RTRIM(@StandardCost))) " 
                + "AND   (@FinishedGoodsFlag IS NULL OR @FinishedGoodsFlag = '' OR [DimProduct].[FinishedGoodsFlag] = LTRIM(RTRIM(@FinishedGoodsFlag))) " 
                + "AND   (@Color IS NULL OR @Color = '' OR [DimProduct].[Color] = LTRIM(RTRIM(@Color))) " 
                + "AND   (@SafetyStockLevel IS NULL OR @SafetyStockLevel = '' OR [DimProduct].[SafetyStockLevel] = LTRIM(RTRIM(@SafetyStockLevel))) " 
                + "AND   (@ReorderPoint IS NULL OR @ReorderPoint = '' OR [DimProduct].[ReorderPoint] = LTRIM(RTRIM(@ReorderPoint))) " 
                + "AND   (@ListPrice IS NULL OR @ListPrice = '' OR [DimProduct].[ListPrice] = LTRIM(RTRIM(@ListPrice))) " 
                + "AND   (@Size IS NULL OR @Size = '' OR [DimProduct].[Size] = LTRIM(RTRIM(@Size))) " 
                + "AND   (@SizeRange IS NULL OR @SizeRange = '' OR [DimProduct].[SizeRange] = LTRIM(RTRIM(@SizeRange))) " 
                + "AND   (@Weight IS NULL OR @Weight = '' OR [DimProduct].[Weight] = LTRIM(RTRIM(@Weight))) " 
                + "AND   (@DaysToManufacture IS NULL OR @DaysToManufacture = '' OR [DimProduct].[DaysToManufacture] = LTRIM(RTRIM(@DaysToManufacture))) " 
                + "AND   (@ProductLine IS NULL OR @ProductLine = '' OR [DimProduct].[ProductLine] = LTRIM(RTRIM(@ProductLine))) " 
                + "AND   (@DealerPrice IS NULL OR @DealerPrice = '' OR [DimProduct].[DealerPrice] = LTRIM(RTRIM(@DealerPrice))) " 
                + "AND   (@Class IS NULL OR @Class = '' OR [DimProduct].[Class] = LTRIM(RTRIM(@Class))) " 
                + "AND   (@Style IS NULL OR @Style = '' OR [DimProduct].[Style] = LTRIM(RTRIM(@Style))) " 
                + "AND   (@ModelName IS NULL OR @ModelName = '' OR [DimProduct].[ModelName] = LTRIM(RTRIM(@ModelName))) " 
                + "AND   (@EnglishDescription IS NULL OR @EnglishDescription = '' OR [DimProduct].[EnglishDescription] = LTRIM(RTRIM(@EnglishDescription))) " 
                + "AND   (@FrenchDescription IS NULL OR @FrenchDescription = '' OR [DimProduct].[FrenchDescription] = LTRIM(RTRIM(@FrenchDescription))) " 
                + "AND   (@ChineseDescription IS NULL OR @ChineseDescription = '' OR [DimProduct].[ChineseDescription] = LTRIM(RTRIM(@ChineseDescription))) " 
                + "AND   (@ArabicDescription IS NULL OR @ArabicDescription = '' OR [DimProduct].[ArabicDescription] = LTRIM(RTRIM(@ArabicDescription))) " 
                + "AND   (@HebrewDescription IS NULL OR @HebrewDescription = '' OR [DimProduct].[HebrewDescription] = LTRIM(RTRIM(@HebrewDescription))) " 
                + "AND   (@ThaiDescription IS NULL OR @ThaiDescription = '' OR [DimProduct].[ThaiDescription] = LTRIM(RTRIM(@ThaiDescription))) " 
                + "AND   (@GermanDescription IS NULL OR @GermanDescription = '' OR [DimProduct].[GermanDescription] = LTRIM(RTRIM(@GermanDescription))) " 
                + "AND   (@JapaneseDescription IS NULL OR @JapaneseDescription = '' OR [DimProduct].[JapaneseDescription] = LTRIM(RTRIM(@JapaneseDescription))) " 
                + "AND   (@TurkishDescription IS NULL OR @TurkishDescription = '' OR [DimProduct].[TurkishDescription] = LTRIM(RTRIM(@TurkishDescription))) " 
                + "AND   (@StartDate IS NULL OR @StartDate = '' OR [DimProduct].[StartDate] = LTRIM(RTRIM(@StartDate))) " 
                + "AND   (@EndDate IS NULL OR @EndDate = '' OR [DimProduct].[EndDate] = LTRIM(RTRIM(@EndDate))) " 
                + "AND   (@Status IS NULL OR @Status = '' OR [DimProduct].[Status] = LTRIM(RTRIM(@Status))) " 
                + "";
        } else if  (sCondition == "Starts with...") {
            selectStatement
                = "SELECT "
            + "     [dbo].[DimProduct].[ProductKey] "
            + "    ,[dbo].[DimProduct].[ProductAlternateKey] "
            + "    ,[dbo].[DimProductSubcategory].[EnglishProductSubcategoryName] "
            + "    ,[dbo].[DimProduct].[WeightUnitMeasureCode] "
            + "    ,[dbo].[DimProduct].[SizeUnitMeasureCode] "
            + "    ,[dbo].[DimProduct].[EnglishProductName] "
            + "    ,[dbo].[DimProduct].[SpanishProductName] "
            + "    ,[dbo].[DimProduct].[FrenchProductName] "
            + "    ,[dbo].[DimProduct].[StandardCost] "
            + "    ,[dbo].[DimProduct].[FinishedGoodsFlag] "
            + "    ,[dbo].[DimProduct].[Color] "
            + "    ,[dbo].[DimProduct].[SafetyStockLevel] "
            + "    ,[dbo].[DimProduct].[ReorderPoint] "
            + "    ,[dbo].[DimProduct].[ListPrice] "
            + "    ,[dbo].[DimProduct].[Size] "
            + "    ,[dbo].[DimProduct].[SizeRange] "
            + "    ,[dbo].[DimProduct].[Weight] "
            + "    ,[dbo].[DimProduct].[DaysToManufacture] "
            + "    ,[dbo].[DimProduct].[ProductLine] "
            + "    ,[dbo].[DimProduct].[DealerPrice] "
            + "    ,[dbo].[DimProduct].[Class] "
            + "    ,[dbo].[DimProduct].[Style] "
            + "    ,[dbo].[DimProduct].[ModelName] "
            + "    ,[dbo].[DimProduct].[EnglishDescription] "
            + "    ,[dbo].[DimProduct].[FrenchDescription] "
            + "    ,[dbo].[DimProduct].[ChineseDescription] "
            + "    ,[dbo].[DimProduct].[ArabicDescription] "
            + "    ,[dbo].[DimProduct].[HebrewDescription] "
            + "    ,[dbo].[DimProduct].[ThaiDescription] "
            + "    ,[dbo].[DimProduct].[GermanDescription] "
            + "    ,[dbo].[DimProduct].[JapaneseDescription] "
            + "    ,[dbo].[DimProduct].[TurkishDescription] "
            + "    ,[dbo].[DimProduct].[StartDate] "
            + "    ,[dbo].[DimProduct].[EndDate] "
            + "    ,[dbo].[DimProduct].[Status] "
            + "FROM " 
            + "     [dbo].[DimProduct] " 
            + "LEFT JOIN [dbo].[DimProductSubcategory] ON [dbo].[DimProduct].[ProductSubcategoryKey] = [dbo].[DimProductSubcategory].[ProductSubcategoryKey] "
                + "WHERE " 
                + "     (@ProductKey IS NULL OR @ProductKey = '' OR [DimProduct].[ProductKey] LIKE LTRIM(RTRIM(@ProductKey)) + '%') " 
                + "AND   (@ProductAlternateKey IS NULL OR @ProductAlternateKey = '' OR [DimProduct].[ProductAlternateKey] LIKE LTRIM(RTRIM(@ProductAlternateKey)) + '%') " 
                + "AND   (@EnglishProductSubcategoryName IS NULL OR @EnglishProductSubcategoryName = '' OR [dbo].[DimProductSubcategory].[EnglishProductSubcategoryName] LIKE LTRIM(RTRIM(@EnglishProductSubcategoryName)) + '%') " 
                + "AND   (@WeightUnitMeasureCode IS NULL OR @WeightUnitMeasureCode = '' OR [DimProduct].[WeightUnitMeasureCode] LIKE LTRIM(RTRIM(@WeightUnitMeasureCode)) + '%') " 
                + "AND   (@SizeUnitMeasureCode IS NULL OR @SizeUnitMeasureCode = '' OR [DimProduct].[SizeUnitMeasureCode] LIKE LTRIM(RTRIM(@SizeUnitMeasureCode)) + '%') " 
                + "AND   (@EnglishProductName IS NULL OR @EnglishProductName = '' OR [DimProduct].[EnglishProductName] LIKE LTRIM(RTRIM(@EnglishProductName)) + '%') " 
                + "AND   (@SpanishProductName IS NULL OR @SpanishProductName = '' OR [DimProduct].[SpanishProductName] LIKE LTRIM(RTRIM(@SpanishProductName)) + '%') " 
                + "AND   (@FrenchProductName IS NULL OR @FrenchProductName = '' OR [DimProduct].[FrenchProductName] LIKE LTRIM(RTRIM(@FrenchProductName)) + '%') " 
                + "AND   (@StandardCost IS NULL OR @StandardCost = '' OR [DimProduct].[StandardCost] LIKE LTRIM(RTRIM(@StandardCost)) + '%') " 
                + "AND   (@FinishedGoodsFlag IS NULL OR @FinishedGoodsFlag = '' OR [DimProduct].[FinishedGoodsFlag] LIKE LTRIM(RTRIM(@FinishedGoodsFlag)) + '%') " 
                + "AND   (@Color IS NULL OR @Color = '' OR [DimProduct].[Color] LIKE LTRIM(RTRIM(@Color)) + '%') " 
                + "AND   (@SafetyStockLevel IS NULL OR @SafetyStockLevel = '' OR [DimProduct].[SafetyStockLevel] LIKE LTRIM(RTRIM(@SafetyStockLevel)) + '%') " 
                + "AND   (@ReorderPoint IS NULL OR @ReorderPoint = '' OR [DimProduct].[ReorderPoint] LIKE LTRIM(RTRIM(@ReorderPoint)) + '%') " 
                + "AND   (@ListPrice IS NULL OR @ListPrice = '' OR [DimProduct].[ListPrice] LIKE LTRIM(RTRIM(@ListPrice)) + '%') " 
                + "AND   (@Size IS NULL OR @Size = '' OR [DimProduct].[Size] LIKE LTRIM(RTRIM(@Size)) + '%') " 
                + "AND   (@SizeRange IS NULL OR @SizeRange = '' OR [DimProduct].[SizeRange] LIKE LTRIM(RTRIM(@SizeRange)) + '%') " 
                + "AND   (@Weight IS NULL OR @Weight = '' OR [DimProduct].[Weight] LIKE LTRIM(RTRIM(@Weight)) + '%') " 
                + "AND   (@DaysToManufacture IS NULL OR @DaysToManufacture = '' OR [DimProduct].[DaysToManufacture] LIKE LTRIM(RTRIM(@DaysToManufacture)) + '%') " 
                + "AND   (@ProductLine IS NULL OR @ProductLine = '' OR [DimProduct].[ProductLine] LIKE LTRIM(RTRIM(@ProductLine)) + '%') " 
                + "AND   (@DealerPrice IS NULL OR @DealerPrice = '' OR [DimProduct].[DealerPrice] LIKE LTRIM(RTRIM(@DealerPrice)) + '%') " 
                + "AND   (@Class IS NULL OR @Class = '' OR [DimProduct].[Class] LIKE LTRIM(RTRIM(@Class)) + '%') " 
                + "AND   (@Style IS NULL OR @Style = '' OR [DimProduct].[Style] LIKE LTRIM(RTRIM(@Style)) + '%') " 
                + "AND   (@ModelName IS NULL OR @ModelName = '' OR [DimProduct].[ModelName] LIKE LTRIM(RTRIM(@ModelName)) + '%') " 
                + "AND   (@EnglishDescription IS NULL OR @EnglishDescription = '' OR [DimProduct].[EnglishDescription] LIKE LTRIM(RTRIM(@EnglishDescription)) + '%') " 
                + "AND   (@FrenchDescription IS NULL OR @FrenchDescription = '' OR [DimProduct].[FrenchDescription] LIKE LTRIM(RTRIM(@FrenchDescription)) + '%') " 
                + "AND   (@ChineseDescription IS NULL OR @ChineseDescription = '' OR [DimProduct].[ChineseDescription] LIKE LTRIM(RTRIM(@ChineseDescription)) + '%') " 
                + "AND   (@ArabicDescription IS NULL OR @ArabicDescription = '' OR [DimProduct].[ArabicDescription] LIKE LTRIM(RTRIM(@ArabicDescription)) + '%') " 
                + "AND   (@HebrewDescription IS NULL OR @HebrewDescription = '' OR [DimProduct].[HebrewDescription] LIKE LTRIM(RTRIM(@HebrewDescription)) + '%') " 
                + "AND   (@ThaiDescription IS NULL OR @ThaiDescription = '' OR [DimProduct].[ThaiDescription] LIKE LTRIM(RTRIM(@ThaiDescription)) + '%') " 
                + "AND   (@GermanDescription IS NULL OR @GermanDescription = '' OR [DimProduct].[GermanDescription] LIKE LTRIM(RTRIM(@GermanDescription)) + '%') " 
                + "AND   (@JapaneseDescription IS NULL OR @JapaneseDescription = '' OR [DimProduct].[JapaneseDescription] LIKE LTRIM(RTRIM(@JapaneseDescription)) + '%') " 
                + "AND   (@TurkishDescription IS NULL OR @TurkishDescription = '' OR [DimProduct].[TurkishDescription] LIKE LTRIM(RTRIM(@TurkishDescription)) + '%') " 
                + "AND   (@StartDate IS NULL OR @StartDate = '' OR [DimProduct].[StartDate] LIKE LTRIM(RTRIM(@StartDate)) + '%') " 
                + "AND   (@EndDate IS NULL OR @EndDate = '' OR [DimProduct].[EndDate] LIKE LTRIM(RTRIM(@EndDate)) + '%') " 
                + "AND   (@Status IS NULL OR @Status = '' OR [DimProduct].[Status] LIKE LTRIM(RTRIM(@Status)) + '%') " 
                + "";
        } else if  (sCondition == "More than...") {
            selectStatement
                = "SELECT "
            + "     [dbo].[DimProduct].[ProductKey] "
            + "    ,[dbo].[DimProduct].[ProductAlternateKey] "
            + "    ,[dbo].[DimProductSubcategory].[EnglishProductSubcategoryName] "
            + "    ,[dbo].[DimProduct].[WeightUnitMeasureCode] "
            + "    ,[dbo].[DimProduct].[SizeUnitMeasureCode] "
            + "    ,[dbo].[DimProduct].[EnglishProductName] "
            + "    ,[dbo].[DimProduct].[SpanishProductName] "
            + "    ,[dbo].[DimProduct].[FrenchProductName] "
            + "    ,[dbo].[DimProduct].[StandardCost] "
            + "    ,[dbo].[DimProduct].[FinishedGoodsFlag] "
            + "    ,[dbo].[DimProduct].[Color] "
            + "    ,[dbo].[DimProduct].[SafetyStockLevel] "
            + "    ,[dbo].[DimProduct].[ReorderPoint] "
            + "    ,[dbo].[DimProduct].[ListPrice] "
            + "    ,[dbo].[DimProduct].[Size] "
            + "    ,[dbo].[DimProduct].[SizeRange] "
            + "    ,[dbo].[DimProduct].[Weight] "
            + "    ,[dbo].[DimProduct].[DaysToManufacture] "
            + "    ,[dbo].[DimProduct].[ProductLine] "
            + "    ,[dbo].[DimProduct].[DealerPrice] "
            + "    ,[dbo].[DimProduct].[Class] "
            + "    ,[dbo].[DimProduct].[Style] "
            + "    ,[dbo].[DimProduct].[ModelName] "
            + "    ,[dbo].[DimProduct].[EnglishDescription] "
            + "    ,[dbo].[DimProduct].[FrenchDescription] "
            + "    ,[dbo].[DimProduct].[ChineseDescription] "
            + "    ,[dbo].[DimProduct].[ArabicDescription] "
            + "    ,[dbo].[DimProduct].[HebrewDescription] "
            + "    ,[dbo].[DimProduct].[ThaiDescription] "
            + "    ,[dbo].[DimProduct].[GermanDescription] "
            + "    ,[dbo].[DimProduct].[JapaneseDescription] "
            + "    ,[dbo].[DimProduct].[TurkishDescription] "
            + "    ,[dbo].[DimProduct].[StartDate] "
            + "    ,[dbo].[DimProduct].[EndDate] "
            + "    ,[dbo].[DimProduct].[Status] "
            + "FROM " 
            + "     [dbo].[DimProduct] " 
            + "LEFT JOIN [dbo].[DimProductSubcategory] ON [dbo].[DimProduct].[ProductSubcategoryKey] = [dbo].[DimProductSubcategory].[ProductSubcategoryKey] "
                + "WHERE " 
                + "     (@ProductKey IS NULL OR @ProductKey = '' OR [DimProduct].[ProductKey] > LTRIM(RTRIM(@ProductKey))) " 
                + "AND   (@ProductAlternateKey IS NULL OR @ProductAlternateKey = '' OR [DimProduct].[ProductAlternateKey] > LTRIM(RTRIM(@ProductAlternateKey))) " 
                + "AND   (@EnglishProductSubcategoryName IS NULL OR @EnglishProductSubcategoryName = '' OR [dbo].[DimProductSubcategory].[EnglishProductSubcategoryName] > LTRIM(RTRIM(@EnglishProductSubcategoryName))) " 
                + "AND   (@WeightUnitMeasureCode IS NULL OR @WeightUnitMeasureCode = '' OR [DimProduct].[WeightUnitMeasureCode] > LTRIM(RTRIM(@WeightUnitMeasureCode))) " 
                + "AND   (@SizeUnitMeasureCode IS NULL OR @SizeUnitMeasureCode = '' OR [DimProduct].[SizeUnitMeasureCode] > LTRIM(RTRIM(@SizeUnitMeasureCode))) " 
                + "AND   (@EnglishProductName IS NULL OR @EnglishProductName = '' OR [DimProduct].[EnglishProductName] > LTRIM(RTRIM(@EnglishProductName))) " 
                + "AND   (@SpanishProductName IS NULL OR @SpanishProductName = '' OR [DimProduct].[SpanishProductName] > LTRIM(RTRIM(@SpanishProductName))) " 
                + "AND   (@FrenchProductName IS NULL OR @FrenchProductName = '' OR [DimProduct].[FrenchProductName] > LTRIM(RTRIM(@FrenchProductName))) " 
                + "AND   (@StandardCost IS NULL OR @StandardCost = '' OR [DimProduct].[StandardCost] > LTRIM(RTRIM(@StandardCost))) " 
                + "AND   (@FinishedGoodsFlag IS NULL OR @FinishedGoodsFlag = '' OR [DimProduct].[FinishedGoodsFlag] > LTRIM(RTRIM(@FinishedGoodsFlag))) " 
                + "AND   (@Color IS NULL OR @Color = '' OR [DimProduct].[Color] > LTRIM(RTRIM(@Color))) " 
                + "AND   (@SafetyStockLevel IS NULL OR @SafetyStockLevel = '' OR [DimProduct].[SafetyStockLevel] > LTRIM(RTRIM(@SafetyStockLevel))) " 
                + "AND   (@ReorderPoint IS NULL OR @ReorderPoint = '' OR [DimProduct].[ReorderPoint] > LTRIM(RTRIM(@ReorderPoint))) " 
                + "AND   (@ListPrice IS NULL OR @ListPrice = '' OR [DimProduct].[ListPrice] > LTRIM(RTRIM(@ListPrice))) " 
                + "AND   (@Size IS NULL OR @Size = '' OR [DimProduct].[Size] > LTRIM(RTRIM(@Size))) " 
                + "AND   (@SizeRange IS NULL OR @SizeRange = '' OR [DimProduct].[SizeRange] > LTRIM(RTRIM(@SizeRange))) " 
                + "AND   (@Weight IS NULL OR @Weight = '' OR [DimProduct].[Weight] > LTRIM(RTRIM(@Weight))) " 
                + "AND   (@DaysToManufacture IS NULL OR @DaysToManufacture = '' OR [DimProduct].[DaysToManufacture] > LTRIM(RTRIM(@DaysToManufacture))) " 
                + "AND   (@ProductLine IS NULL OR @ProductLine = '' OR [DimProduct].[ProductLine] > LTRIM(RTRIM(@ProductLine))) " 
                + "AND   (@DealerPrice IS NULL OR @DealerPrice = '' OR [DimProduct].[DealerPrice] > LTRIM(RTRIM(@DealerPrice))) " 
                + "AND   (@Class IS NULL OR @Class = '' OR [DimProduct].[Class] > LTRIM(RTRIM(@Class))) " 
                + "AND   (@Style IS NULL OR @Style = '' OR [DimProduct].[Style] > LTRIM(RTRIM(@Style))) " 
                + "AND   (@ModelName IS NULL OR @ModelName = '' OR [DimProduct].[ModelName] > LTRIM(RTRIM(@ModelName))) " 
                + "AND   (@EnglishDescription IS NULL OR @EnglishDescription = '' OR [DimProduct].[EnglishDescription] > LTRIM(RTRIM(@EnglishDescription))) " 
                + "AND   (@FrenchDescription IS NULL OR @FrenchDescription = '' OR [DimProduct].[FrenchDescription] > LTRIM(RTRIM(@FrenchDescription))) " 
                + "AND   (@ChineseDescription IS NULL OR @ChineseDescription = '' OR [DimProduct].[ChineseDescription] > LTRIM(RTRIM(@ChineseDescription))) " 
                + "AND   (@ArabicDescription IS NULL OR @ArabicDescription = '' OR [DimProduct].[ArabicDescription] > LTRIM(RTRIM(@ArabicDescription))) " 
                + "AND   (@HebrewDescription IS NULL OR @HebrewDescription = '' OR [DimProduct].[HebrewDescription] > LTRIM(RTRIM(@HebrewDescription))) " 
                + "AND   (@ThaiDescription IS NULL OR @ThaiDescription = '' OR [DimProduct].[ThaiDescription] > LTRIM(RTRIM(@ThaiDescription))) " 
                + "AND   (@GermanDescription IS NULL OR @GermanDescription = '' OR [DimProduct].[GermanDescription] > LTRIM(RTRIM(@GermanDescription))) " 
                + "AND   (@JapaneseDescription IS NULL OR @JapaneseDescription = '' OR [DimProduct].[JapaneseDescription] > LTRIM(RTRIM(@JapaneseDescription))) " 
                + "AND   (@TurkishDescription IS NULL OR @TurkishDescription = '' OR [DimProduct].[TurkishDescription] > LTRIM(RTRIM(@TurkishDescription))) " 
                + "AND   (@StartDate IS NULL OR @StartDate = '' OR [DimProduct].[StartDate] > LTRIM(RTRIM(@StartDate))) " 
                + "AND   (@EndDate IS NULL OR @EndDate = '' OR [DimProduct].[EndDate] > LTRIM(RTRIM(@EndDate))) " 
                + "AND   (@Status IS NULL OR @Status = '' OR [DimProduct].[Status] > LTRIM(RTRIM(@Status))) " 
                + "";
        } else if  (sCondition == "Less than...") {
            selectStatement
                = "SELECT " 
            + "     [dbo].[DimProduct].[ProductKey] "
            + "    ,[dbo].[DimProduct].[ProductAlternateKey] "
            + "    ,[dbo].[DimProductSubcategory].[EnglishProductSubcategoryName] "
            + "    ,[dbo].[DimProduct].[WeightUnitMeasureCode] "
            + "    ,[dbo].[DimProduct].[SizeUnitMeasureCode] "
            + "    ,[dbo].[DimProduct].[EnglishProductName] "
            + "    ,[dbo].[DimProduct].[SpanishProductName] "
            + "    ,[dbo].[DimProduct].[FrenchProductName] "
            + "    ,[dbo].[DimProduct].[StandardCost] "
            + "    ,[dbo].[DimProduct].[FinishedGoodsFlag] "
            + "    ,[dbo].[DimProduct].[Color] "
            + "    ,[dbo].[DimProduct].[SafetyStockLevel] "
            + "    ,[dbo].[DimProduct].[ReorderPoint] "
            + "    ,[dbo].[DimProduct].[ListPrice] "
            + "    ,[dbo].[DimProduct].[Size] "
            + "    ,[dbo].[DimProduct].[SizeRange] "
            + "    ,[dbo].[DimProduct].[Weight] "
            + "    ,[dbo].[DimProduct].[DaysToManufacture] "
            + "    ,[dbo].[DimProduct].[ProductLine] "
            + "    ,[dbo].[DimProduct].[DealerPrice] "
            + "    ,[dbo].[DimProduct].[Class] "
            + "    ,[dbo].[DimProduct].[Style] "
            + "    ,[dbo].[DimProduct].[ModelName] "
            + "    ,[dbo].[DimProduct].[EnglishDescription] "
            + "    ,[dbo].[DimProduct].[FrenchDescription] "
            + "    ,[dbo].[DimProduct].[ChineseDescription] "
            + "    ,[dbo].[DimProduct].[ArabicDescription] "
            + "    ,[dbo].[DimProduct].[HebrewDescription] "
            + "    ,[dbo].[DimProduct].[ThaiDescription] "
            + "    ,[dbo].[DimProduct].[GermanDescription] "
            + "    ,[dbo].[DimProduct].[JapaneseDescription] "
            + "    ,[dbo].[DimProduct].[TurkishDescription] "
            + "    ,[dbo].[DimProduct].[StartDate] "
            + "    ,[dbo].[DimProduct].[EndDate] "
            + "    ,[dbo].[DimProduct].[Status] "
            + "FROM " 
            + "     [dbo].[DimProduct] " 
            + "LEFT JOIN [dbo].[DimProductSubcategory] ON [dbo].[DimProduct].[ProductSubcategoryKey] = [dbo].[DimProductSubcategory].[ProductSubcategoryKey] "
                + "WHERE " 
                + "     (@ProductKey IS NULL OR @ProductKey = '' OR [DimProduct].[ProductKey] < LTRIM(RTRIM(@ProductKey))) " 
                + "AND   (@ProductAlternateKey IS NULL OR @ProductAlternateKey = '' OR [DimProduct].[ProductAlternateKey] < LTRIM(RTRIM(@ProductAlternateKey))) " 
                + "AND   (@EnglishProductSubcategoryName IS NULL OR @EnglishProductSubcategoryName = '' OR [dbo].[DimProductSubcategory].[EnglishProductSubcategoryName] < LTRIM(RTRIM(@EnglishProductSubcategoryName))) " 
                + "AND   (@WeightUnitMeasureCode IS NULL OR @WeightUnitMeasureCode = '' OR [DimProduct].[WeightUnitMeasureCode] < LTRIM(RTRIM(@WeightUnitMeasureCode))) " 
                + "AND   (@SizeUnitMeasureCode IS NULL OR @SizeUnitMeasureCode = '' OR [DimProduct].[SizeUnitMeasureCode] < LTRIM(RTRIM(@SizeUnitMeasureCode))) " 
                + "AND   (@EnglishProductName IS NULL OR @EnglishProductName = '' OR [DimProduct].[EnglishProductName] < LTRIM(RTRIM(@EnglishProductName))) " 
                + "AND   (@SpanishProductName IS NULL OR @SpanishProductName = '' OR [DimProduct].[SpanishProductName] < LTRIM(RTRIM(@SpanishProductName))) " 
                + "AND   (@FrenchProductName IS NULL OR @FrenchProductName = '' OR [DimProduct].[FrenchProductName] < LTRIM(RTRIM(@FrenchProductName))) " 
                + "AND   (@StandardCost IS NULL OR @StandardCost = '' OR [DimProduct].[StandardCost] < LTRIM(RTRIM(@StandardCost))) " 
                + "AND   (@FinishedGoodsFlag IS NULL OR @FinishedGoodsFlag = '' OR [DimProduct].[FinishedGoodsFlag] < LTRIM(RTRIM(@FinishedGoodsFlag))) " 
                + "AND   (@Color IS NULL OR @Color = '' OR [DimProduct].[Color] < LTRIM(RTRIM(@Color))) " 
                + "AND   (@SafetyStockLevel IS NULL OR @SafetyStockLevel = '' OR [DimProduct].[SafetyStockLevel] < LTRIM(RTRIM(@SafetyStockLevel))) " 
                + "AND   (@ReorderPoint IS NULL OR @ReorderPoint = '' OR [DimProduct].[ReorderPoint] < LTRIM(RTRIM(@ReorderPoint))) " 
                + "AND   (@ListPrice IS NULL OR @ListPrice = '' OR [DimProduct].[ListPrice] < LTRIM(RTRIM(@ListPrice))) " 
                + "AND   (@Size IS NULL OR @Size = '' OR [DimProduct].[Size] < LTRIM(RTRIM(@Size))) " 
                + "AND   (@SizeRange IS NULL OR @SizeRange = '' OR [DimProduct].[SizeRange] < LTRIM(RTRIM(@SizeRange))) " 
                + "AND   (@Weight IS NULL OR @Weight = '' OR [DimProduct].[Weight] < LTRIM(RTRIM(@Weight))) " 
                + "AND   (@DaysToManufacture IS NULL OR @DaysToManufacture = '' OR [DimProduct].[DaysToManufacture] < LTRIM(RTRIM(@DaysToManufacture))) " 
                + "AND   (@ProductLine IS NULL OR @ProductLine = '' OR [DimProduct].[ProductLine] < LTRIM(RTRIM(@ProductLine))) " 
                + "AND   (@DealerPrice IS NULL OR @DealerPrice = '' OR [DimProduct].[DealerPrice] < LTRIM(RTRIM(@DealerPrice))) " 
                + "AND   (@Class IS NULL OR @Class = '' OR [DimProduct].[Class] < LTRIM(RTRIM(@Class))) " 
                + "AND   (@Style IS NULL OR @Style = '' OR [DimProduct].[Style] < LTRIM(RTRIM(@Style))) " 
                + "AND   (@ModelName IS NULL OR @ModelName = '' OR [DimProduct].[ModelName] < LTRIM(RTRIM(@ModelName))) " 
                + "AND   (@EnglishDescription IS NULL OR @EnglishDescription = '' OR [DimProduct].[EnglishDescription] < LTRIM(RTRIM(@EnglishDescription))) " 
                + "AND   (@FrenchDescription IS NULL OR @FrenchDescription = '' OR [DimProduct].[FrenchDescription] < LTRIM(RTRIM(@FrenchDescription))) " 
                + "AND   (@ChineseDescription IS NULL OR @ChineseDescription = '' OR [DimProduct].[ChineseDescription] < LTRIM(RTRIM(@ChineseDescription))) " 
                + "AND   (@ArabicDescription IS NULL OR @ArabicDescription = '' OR [DimProduct].[ArabicDescription] < LTRIM(RTRIM(@ArabicDescription))) " 
                + "AND   (@HebrewDescription IS NULL OR @HebrewDescription = '' OR [DimProduct].[HebrewDescription] < LTRIM(RTRIM(@HebrewDescription))) " 
                + "AND   (@ThaiDescription IS NULL OR @ThaiDescription = '' OR [DimProduct].[ThaiDescription] < LTRIM(RTRIM(@ThaiDescription))) " 
                + "AND   (@GermanDescription IS NULL OR @GermanDescription = '' OR [DimProduct].[GermanDescription] < LTRIM(RTRIM(@GermanDescription))) " 
                + "AND   (@JapaneseDescription IS NULL OR @JapaneseDescription = '' OR [DimProduct].[JapaneseDescription] < LTRIM(RTRIM(@JapaneseDescription))) " 
                + "AND   (@TurkishDescription IS NULL OR @TurkishDescription = '' OR [DimProduct].[TurkishDescription] < LTRIM(RTRIM(@TurkishDescription))) " 
                + "AND   (@StartDate IS NULL OR @StartDate = '' OR [DimProduct].[StartDate] < LTRIM(RTRIM(@StartDate))) " 
                + "AND   (@EndDate IS NULL OR @EndDate = '' OR [DimProduct].[EndDate] < LTRIM(RTRIM(@EndDate))) " 
                + "AND   (@Status IS NULL OR @Status = '' OR [DimProduct].[Status] < LTRIM(RTRIM(@Status))) " 
                + "";
        } else if  (sCondition == "Equal or more than...") {
            selectStatement
                = "SELECT "
            + "     [dbo].[DimProduct].[ProductKey] "
            + "    ,[dbo].[DimProduct].[ProductAlternateKey] "
            + "    ,[dbo].[DimProductSubcategory].[EnglishProductSubcategoryName] "
            + "    ,[dbo].[DimProduct].[WeightUnitMeasureCode] "
            + "    ,[dbo].[DimProduct].[SizeUnitMeasureCode] "
            + "    ,[dbo].[DimProduct].[EnglishProductName] "
            + "    ,[dbo].[DimProduct].[SpanishProductName] "
            + "    ,[dbo].[DimProduct].[FrenchProductName] "
            + "    ,[dbo].[DimProduct].[StandardCost] "
            + "    ,[dbo].[DimProduct].[FinishedGoodsFlag] "
            + "    ,[dbo].[DimProduct].[Color] "
            + "    ,[dbo].[DimProduct].[SafetyStockLevel] "
            + "    ,[dbo].[DimProduct].[ReorderPoint] "
            + "    ,[dbo].[DimProduct].[ListPrice] "
            + "    ,[dbo].[DimProduct].[Size] "
            + "    ,[dbo].[DimProduct].[SizeRange] "
            + "    ,[dbo].[DimProduct].[Weight] "
            + "    ,[dbo].[DimProduct].[DaysToManufacture] "
            + "    ,[dbo].[DimProduct].[ProductLine] "
            + "    ,[dbo].[DimProduct].[DealerPrice] "
            + "    ,[dbo].[DimProduct].[Class] "
            + "    ,[dbo].[DimProduct].[Style] "
            + "    ,[dbo].[DimProduct].[ModelName] "
            + "    ,[dbo].[DimProduct].[EnglishDescription] "
            + "    ,[dbo].[DimProduct].[FrenchDescription] "
            + "    ,[dbo].[DimProduct].[ChineseDescription] "
            + "    ,[dbo].[DimProduct].[ArabicDescription] "
            + "    ,[dbo].[DimProduct].[HebrewDescription] "
            + "    ,[dbo].[DimProduct].[ThaiDescription] "
            + "    ,[dbo].[DimProduct].[GermanDescription] "
            + "    ,[dbo].[DimProduct].[JapaneseDescription] "
            + "    ,[dbo].[DimProduct].[TurkishDescription] "
            + "    ,[dbo].[DimProduct].[StartDate] "
            + "    ,[dbo].[DimProduct].[EndDate] "
            + "    ,[dbo].[DimProduct].[Status] "
            + "FROM " 
            + "     [dbo].[DimProduct] " 
            + "LEFT JOIN [dbo].[DimProductSubcategory] ON [dbo].[DimProduct].[ProductSubcategoryKey] = [dbo].[DimProductSubcategory].[ProductSubcategoryKey] "
                + "WHERE " 
                + "     (@ProductKey IS NULL OR @ProductKey = '' OR [DimProduct].[ProductKey] >= LTRIM(RTRIM(@ProductKey))) " 
                + "AND   (@ProductAlternateKey IS NULL OR @ProductAlternateKey = '' OR [DimProduct].[ProductAlternateKey] >= LTRIM(RTRIM(@ProductAlternateKey))) " 
                + "AND   (@EnglishProductSubcategoryName IS NULL OR @EnglishProductSubcategoryName = '' OR [dbo].[DimProductSubcategory].[EnglishProductSubcategoryName] >= LTRIM(RTRIM(@EnglishProductSubcategoryName))) " 
                + "AND   (@WeightUnitMeasureCode IS NULL OR @WeightUnitMeasureCode = '' OR [DimProduct].[WeightUnitMeasureCode] >= LTRIM(RTRIM(@WeightUnitMeasureCode))) " 
                + "AND   (@SizeUnitMeasureCode IS NULL OR @SizeUnitMeasureCode = '' OR [DimProduct].[SizeUnitMeasureCode] >= LTRIM(RTRIM(@SizeUnitMeasureCode))) " 
                + "AND   (@EnglishProductName IS NULL OR @EnglishProductName = '' OR [DimProduct].[EnglishProductName] >= LTRIM(RTRIM(@EnglishProductName))) " 
                + "AND   (@SpanishProductName IS NULL OR @SpanishProductName = '' OR [DimProduct].[SpanishProductName] >= LTRIM(RTRIM(@SpanishProductName))) " 
                + "AND   (@FrenchProductName IS NULL OR @FrenchProductName = '' OR [DimProduct].[FrenchProductName] >= LTRIM(RTRIM(@FrenchProductName))) " 
                + "AND   (@StandardCost IS NULL OR @StandardCost = '' OR [DimProduct].[StandardCost] >= LTRIM(RTRIM(@StandardCost))) " 
                + "AND   (@FinishedGoodsFlag IS NULL OR @FinishedGoodsFlag = '' OR [DimProduct].[FinishedGoodsFlag] >= LTRIM(RTRIM(@FinishedGoodsFlag))) " 
                + "AND   (@Color IS NULL OR @Color = '' OR [DimProduct].[Color] >= LTRIM(RTRIM(@Color))) " 
                + "AND   (@SafetyStockLevel IS NULL OR @SafetyStockLevel = '' OR [DimProduct].[SafetyStockLevel] >= LTRIM(RTRIM(@SafetyStockLevel))) " 
                + "AND   (@ReorderPoint IS NULL OR @ReorderPoint = '' OR [DimProduct].[ReorderPoint] >= LTRIM(RTRIM(@ReorderPoint))) " 
                + "AND   (@ListPrice IS NULL OR @ListPrice = '' OR [DimProduct].[ListPrice] >= LTRIM(RTRIM(@ListPrice))) " 
                + "AND   (@Size IS NULL OR @Size = '' OR [DimProduct].[Size] >= LTRIM(RTRIM(@Size))) " 
                + "AND   (@SizeRange IS NULL OR @SizeRange = '' OR [DimProduct].[SizeRange] >= LTRIM(RTRIM(@SizeRange))) " 
                + "AND   (@Weight IS NULL OR @Weight = '' OR [DimProduct].[Weight] >= LTRIM(RTRIM(@Weight))) " 
                + "AND   (@DaysToManufacture IS NULL OR @DaysToManufacture = '' OR [DimProduct].[DaysToManufacture] >= LTRIM(RTRIM(@DaysToManufacture))) " 
                + "AND   (@ProductLine IS NULL OR @ProductLine = '' OR [DimProduct].[ProductLine] >= LTRIM(RTRIM(@ProductLine))) " 
                + "AND   (@DealerPrice IS NULL OR @DealerPrice = '' OR [DimProduct].[DealerPrice] >= LTRIM(RTRIM(@DealerPrice))) " 
                + "AND   (@Class IS NULL OR @Class = '' OR [DimProduct].[Class] >= LTRIM(RTRIM(@Class))) " 
                + "AND   (@Style IS NULL OR @Style = '' OR [DimProduct].[Style] >= LTRIM(RTRIM(@Style))) " 
                + "AND   (@ModelName IS NULL OR @ModelName = '' OR [DimProduct].[ModelName] >= LTRIM(RTRIM(@ModelName))) " 
                + "AND   (@EnglishDescription IS NULL OR @EnglishDescription = '' OR [DimProduct].[EnglishDescription] >= LTRIM(RTRIM(@EnglishDescription))) " 
                + "AND   (@FrenchDescription IS NULL OR @FrenchDescription = '' OR [DimProduct].[FrenchDescription] >= LTRIM(RTRIM(@FrenchDescription))) " 
                + "AND   (@ChineseDescription IS NULL OR @ChineseDescription = '' OR [DimProduct].[ChineseDescription] >= LTRIM(RTRIM(@ChineseDescription))) " 
                + "AND   (@ArabicDescription IS NULL OR @ArabicDescription = '' OR [DimProduct].[ArabicDescription] >= LTRIM(RTRIM(@ArabicDescription))) " 
                + "AND   (@HebrewDescription IS NULL OR @HebrewDescription = '' OR [DimProduct].[HebrewDescription] >= LTRIM(RTRIM(@HebrewDescription))) " 
                + "AND   (@ThaiDescription IS NULL OR @ThaiDescription = '' OR [DimProduct].[ThaiDescription] >= LTRIM(RTRIM(@ThaiDescription))) " 
                + "AND   (@GermanDescription IS NULL OR @GermanDescription = '' OR [DimProduct].[GermanDescription] >= LTRIM(RTRIM(@GermanDescription))) " 
                + "AND   (@JapaneseDescription IS NULL OR @JapaneseDescription = '' OR [DimProduct].[JapaneseDescription] >= LTRIM(RTRIM(@JapaneseDescription))) " 
                + "AND   (@TurkishDescription IS NULL OR @TurkishDescription = '' OR [DimProduct].[TurkishDescription] >= LTRIM(RTRIM(@TurkishDescription))) " 
                + "AND   (@StartDate IS NULL OR @StartDate = '' OR [DimProduct].[StartDate] >= LTRIM(RTRIM(@StartDate))) " 
                + "AND   (@EndDate IS NULL OR @EndDate = '' OR [DimProduct].[EndDate] >= LTRIM(RTRIM(@EndDate))) " 
                + "AND   (@Status IS NULL OR @Status = '' OR [DimProduct].[Status] >= LTRIM(RTRIM(@Status))) " 
                + "";
        } else if (sCondition == "Equal or less than...") {
            selectStatement 
                = "SELECT "
            + "     [dbo].[DimProduct].[ProductKey] "
            + "    ,[dbo].[DimProduct].[ProductAlternateKey] "
            + "    ,[dbo].[DimProductSubcategory].[EnglishProductSubcategoryName] "
            + "    ,[dbo].[DimProduct].[WeightUnitMeasureCode] "
            + "    ,[dbo].[DimProduct].[SizeUnitMeasureCode] "
            + "    ,[dbo].[DimProduct].[EnglishProductName] "
            + "    ,[dbo].[DimProduct].[SpanishProductName] "
            + "    ,[dbo].[DimProduct].[FrenchProductName] "
            + "    ,[dbo].[DimProduct].[StandardCost] "
            + "    ,[dbo].[DimProduct].[FinishedGoodsFlag] "
            + "    ,[dbo].[DimProduct].[Color] "
            + "    ,[dbo].[DimProduct].[SafetyStockLevel] "
            + "    ,[dbo].[DimProduct].[ReorderPoint] "
            + "    ,[dbo].[DimProduct].[ListPrice] "
            + "    ,[dbo].[DimProduct].[Size] "
            + "    ,[dbo].[DimProduct].[SizeRange] "
            + "    ,[dbo].[DimProduct].[Weight] "
            + "    ,[dbo].[DimProduct].[DaysToManufacture] "
            + "    ,[dbo].[DimProduct].[ProductLine] "
            + "    ,[dbo].[DimProduct].[DealerPrice] "
            + "    ,[dbo].[DimProduct].[Class] "
            + "    ,[dbo].[DimProduct].[Style] "
            + "    ,[dbo].[DimProduct].[ModelName] "
            + "    ,[dbo].[DimProduct].[EnglishDescription] "
            + "    ,[dbo].[DimProduct].[FrenchDescription] "
            + "    ,[dbo].[DimProduct].[ChineseDescription] "
            + "    ,[dbo].[DimProduct].[ArabicDescription] "
            + "    ,[dbo].[DimProduct].[HebrewDescription] "
            + "    ,[dbo].[DimProduct].[ThaiDescription] "
            + "    ,[dbo].[DimProduct].[GermanDescription] "
            + "    ,[dbo].[DimProduct].[JapaneseDescription] "
            + "    ,[dbo].[DimProduct].[TurkishDescription] "
            + "    ,[dbo].[DimProduct].[StartDate] "
            + "    ,[dbo].[DimProduct].[EndDate] "
            + "    ,[dbo].[DimProduct].[Status] "
            + "FROM " 
            + "     [dbo].[DimProduct] " 
            + "LEFT JOIN [dbo].[DimProductSubcategory] ON [dbo].[DimProduct].[ProductSubcategoryKey] = [dbo].[DimProductSubcategory].[ProductSubcategoryKey] "
                + "WHERE " 
                + "     (@ProductKey IS NULL OR @ProductKey = '' OR [DimProduct].[ProductKey] <= LTRIM(RTRIM(@ProductKey))) " 
                + "AND   (@ProductAlternateKey IS NULL OR @ProductAlternateKey = '' OR [DimProduct].[ProductAlternateKey] <= LTRIM(RTRIM(@ProductAlternateKey))) " 
                + "AND   (@EnglishProductSubcategoryName IS NULL OR @EnglishProductSubcategoryName = '' OR [dbo].[DimProductSubcategory].[EnglishProductSubcategoryName] <= LTRIM(RTRIM(@EnglishProductSubcategoryName))) " 
                + "AND   (@WeightUnitMeasureCode IS NULL OR @WeightUnitMeasureCode = '' OR [DimProduct].[WeightUnitMeasureCode] <= LTRIM(RTRIM(@WeightUnitMeasureCode))) " 
                + "AND   (@SizeUnitMeasureCode IS NULL OR @SizeUnitMeasureCode = '' OR [DimProduct].[SizeUnitMeasureCode] <= LTRIM(RTRIM(@SizeUnitMeasureCode))) " 
                + "AND   (@EnglishProductName IS NULL OR @EnglishProductName = '' OR [DimProduct].[EnglishProductName] <= LTRIM(RTRIM(@EnglishProductName))) " 
                + "AND   (@SpanishProductName IS NULL OR @SpanishProductName = '' OR [DimProduct].[SpanishProductName] <= LTRIM(RTRIM(@SpanishProductName))) " 
                + "AND   (@FrenchProductName IS NULL OR @FrenchProductName = '' OR [DimProduct].[FrenchProductName] <= LTRIM(RTRIM(@FrenchProductName))) " 
                + "AND   (@StandardCost IS NULL OR @StandardCost = '' OR [DimProduct].[StandardCost] <= LTRIM(RTRIM(@StandardCost))) " 
                + "AND   (@FinishedGoodsFlag IS NULL OR @FinishedGoodsFlag = '' OR [DimProduct].[FinishedGoodsFlag] <= LTRIM(RTRIM(@FinishedGoodsFlag))) " 
                + "AND   (@Color IS NULL OR @Color = '' OR [DimProduct].[Color] <= LTRIM(RTRIM(@Color))) " 
                + "AND   (@SafetyStockLevel IS NULL OR @SafetyStockLevel = '' OR [DimProduct].[SafetyStockLevel] <= LTRIM(RTRIM(@SafetyStockLevel))) " 
                + "AND   (@ReorderPoint IS NULL OR @ReorderPoint = '' OR [DimProduct].[ReorderPoint] <= LTRIM(RTRIM(@ReorderPoint))) " 
                + "AND   (@ListPrice IS NULL OR @ListPrice = '' OR [DimProduct].[ListPrice] <= LTRIM(RTRIM(@ListPrice))) " 
                + "AND   (@Size IS NULL OR @Size = '' OR [DimProduct].[Size] <= LTRIM(RTRIM(@Size))) " 
                + "AND   (@SizeRange IS NULL OR @SizeRange = '' OR [DimProduct].[SizeRange] <= LTRIM(RTRIM(@SizeRange))) " 
                + "AND   (@Weight IS NULL OR @Weight = '' OR [DimProduct].[Weight] <= LTRIM(RTRIM(@Weight))) " 
                + "AND   (@DaysToManufacture IS NULL OR @DaysToManufacture = '' OR [DimProduct].[DaysToManufacture] <= LTRIM(RTRIM(@DaysToManufacture))) " 
                + "AND   (@ProductLine IS NULL OR @ProductLine = '' OR [DimProduct].[ProductLine] <= LTRIM(RTRIM(@ProductLine))) " 
                + "AND   (@DealerPrice IS NULL OR @DealerPrice = '' OR [DimProduct].[DealerPrice] <= LTRIM(RTRIM(@DealerPrice))) " 
                + "AND   (@Class IS NULL OR @Class = '' OR [DimProduct].[Class] <= LTRIM(RTRIM(@Class))) " 
                + "AND   (@Style IS NULL OR @Style = '' OR [DimProduct].[Style] <= LTRIM(RTRIM(@Style))) " 
                + "AND   (@ModelName IS NULL OR @ModelName = '' OR [DimProduct].[ModelName] <= LTRIM(RTRIM(@ModelName))) " 
                + "AND   (@EnglishDescription IS NULL OR @EnglishDescription = '' OR [DimProduct].[EnglishDescription] <= LTRIM(RTRIM(@EnglishDescription))) " 
                + "AND   (@FrenchDescription IS NULL OR @FrenchDescription = '' OR [DimProduct].[FrenchDescription] <= LTRIM(RTRIM(@FrenchDescription))) " 
                + "AND   (@ChineseDescription IS NULL OR @ChineseDescription = '' OR [DimProduct].[ChineseDescription] <= LTRIM(RTRIM(@ChineseDescription))) " 
                + "AND   (@ArabicDescription IS NULL OR @ArabicDescription = '' OR [DimProduct].[ArabicDescription] <= LTRIM(RTRIM(@ArabicDescription))) " 
                + "AND   (@HebrewDescription IS NULL OR @HebrewDescription = '' OR [DimProduct].[HebrewDescription] <= LTRIM(RTRIM(@HebrewDescription))) " 
                + "AND   (@ThaiDescription IS NULL OR @ThaiDescription = '' OR [DimProduct].[ThaiDescription] <= LTRIM(RTRIM(@ThaiDescription))) " 
                + "AND   (@GermanDescription IS NULL OR @GermanDescription = '' OR [DimProduct].[GermanDescription] <= LTRIM(RTRIM(@GermanDescription))) " 
                + "AND   (@JapaneseDescription IS NULL OR @JapaneseDescription = '' OR [DimProduct].[JapaneseDescription] <= LTRIM(RTRIM(@JapaneseDescription))) " 
                + "AND   (@TurkishDescription IS NULL OR @TurkishDescription = '' OR [DimProduct].[TurkishDescription] <= LTRIM(RTRIM(@TurkishDescription))) " 
                + "AND   (@StartDate IS NULL OR @StartDate = '' OR [DimProduct].[StartDate] <= LTRIM(RTRIM(@StartDate))) " 
                + "AND   (@EndDate IS NULL OR @EndDate = '' OR [DimProduct].[EndDate] <= LTRIM(RTRIM(@EndDate))) " 
                + "AND   (@Status IS NULL OR @Status = '' OR [DimProduct].[Status] <= LTRIM(RTRIM(@Status))) " 
                + "";
        }
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        selectCommand.CommandType = CommandType.Text;
        if (sField == "Product Key") {
            selectCommand.Parameters.AddWithValue("@ProductKey", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@ProductKey", DBNull.Value); }
        if (sField == "Product Alternate Key") {
            selectCommand.Parameters.AddWithValue("@ProductAlternateKey", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@ProductAlternateKey", DBNull.Value); }
        if (sField == "Product Subcategory Key") {
            selectCommand.Parameters.AddWithValue("@EnglishProductSubcategoryName", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@EnglishProductSubcategoryName", DBNull.Value); }
        if (sField == "Weight Unit Measure Code") {
            selectCommand.Parameters.AddWithValue("@WeightUnitMeasureCode", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@WeightUnitMeasureCode", DBNull.Value); }
        if (sField == "Size Unit Measure Code") {
            selectCommand.Parameters.AddWithValue("@SizeUnitMeasureCode", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@SizeUnitMeasureCode", DBNull.Value); }
        if (sField == "English Product Name") {
            selectCommand.Parameters.AddWithValue("@EnglishProductName", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@EnglishProductName", DBNull.Value); }
        if (sField == "Spanish Product Name") {
            selectCommand.Parameters.AddWithValue("@SpanishProductName", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@SpanishProductName", DBNull.Value); }
        if (sField == "French Product Name") {
            selectCommand.Parameters.AddWithValue("@FrenchProductName", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@FrenchProductName", DBNull.Value); }
        if (sField == "Standard Cost") {
            selectCommand.Parameters.AddWithValue("@StandardCost", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@StandardCost", DBNull.Value); }
        if (sField == "Finished Goods Flag") {
            selectCommand.Parameters.AddWithValue("@FinishedGoodsFlag", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@FinishedGoodsFlag", DBNull.Value); }
        if (sField == "Color") {
            selectCommand.Parameters.AddWithValue("@Color", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@Color", DBNull.Value); }
        if (sField == "Safety Stock Level") {
            selectCommand.Parameters.AddWithValue("@SafetyStockLevel", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@SafetyStockLevel", DBNull.Value); }
        if (sField == "Reorder Point") {
            selectCommand.Parameters.AddWithValue("@ReorderPoint", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@ReorderPoint", DBNull.Value); }
        if (sField == "List Price") {
            selectCommand.Parameters.AddWithValue("@ListPrice", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@ListPrice", DBNull.Value); }
        if (sField == "Size") {
            selectCommand.Parameters.AddWithValue("@Size", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@Size", DBNull.Value); }
        if (sField == "Size Range") {
            selectCommand.Parameters.AddWithValue("@SizeRange", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@SizeRange", DBNull.Value); }
        if (sField == "Weight") {
            selectCommand.Parameters.AddWithValue("@Weight", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@Weight", DBNull.Value); }
        if (sField == "Days To Manufacture") {
            selectCommand.Parameters.AddWithValue("@DaysToManufacture", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@DaysToManufacture", DBNull.Value); }
        if (sField == "Product Line") {
            selectCommand.Parameters.AddWithValue("@ProductLine", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@ProductLine", DBNull.Value); }
        if (sField == "Dealer Price") {
            selectCommand.Parameters.AddWithValue("@DealerPrice", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@DealerPrice", DBNull.Value); }
        if (sField == "Class") {
            selectCommand.Parameters.AddWithValue("@Class", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@Class", DBNull.Value); }
        if (sField == "Style") {
            selectCommand.Parameters.AddWithValue("@Style", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@Style", DBNull.Value); }
        if (sField == "Model Name") {
            selectCommand.Parameters.AddWithValue("@ModelName", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@ModelName", DBNull.Value); }
        if (sField == "English Description") {
            selectCommand.Parameters.AddWithValue("@EnglishDescription", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@EnglishDescription", DBNull.Value); }
        if (sField == "French Description") {
            selectCommand.Parameters.AddWithValue("@FrenchDescription", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@FrenchDescription", DBNull.Value); }
        if (sField == "Chinese Description") {
            selectCommand.Parameters.AddWithValue("@ChineseDescription", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@ChineseDescription", DBNull.Value); }
        if (sField == "Arabic Description") {
            selectCommand.Parameters.AddWithValue("@ArabicDescription", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@ArabicDescription", DBNull.Value); }
        if (sField == "Hebrew Description") {
            selectCommand.Parameters.AddWithValue("@HebrewDescription", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@HebrewDescription", DBNull.Value); }
        if (sField == "Thai Description") {
            selectCommand.Parameters.AddWithValue("@ThaiDescription", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@ThaiDescription", DBNull.Value); }
        if (sField == "German Description") {
            selectCommand.Parameters.AddWithValue("@GermanDescription", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@GermanDescription", DBNull.Value); }
        if (sField == "Japanese Description") {
            selectCommand.Parameters.AddWithValue("@JapaneseDescription", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@JapaneseDescription", DBNull.Value); }
        if (sField == "Turkish Description") {
            selectCommand.Parameters.AddWithValue("@TurkishDescription", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@TurkishDescription", DBNull.Value); }
        if (sField == "Start Date") {
            selectCommand.Parameters.AddWithValue("@StartDate", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@StartDate", DBNull.Value); }
        if (sField == "End Date") {
            selectCommand.Parameters.AddWithValue("@EndDate", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@EndDate", DBNull.Value); }
        if (sField == "Status") {
            selectCommand.Parameters.AddWithValue("@Status", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@Status", DBNull.Value); }
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

    public static dbo_DimProductClass Select_Record(dbo_DimProductClass clsdbo_DimProductPara)
    {
        dbo_DimProductClass clsdbo_DimProduct = new dbo_DimProductClass();
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement
            = "SELECT " 
            + "     [ProductKey] "
            + "    ,[ProductAlternateKey] "
            + "    ,[ProductSubcategoryKey] "
            + "    ,[WeightUnitMeasureCode] "
            + "    ,[SizeUnitMeasureCode] "
            + "    ,[EnglishProductName] "
            + "    ,[SpanishProductName] "
            + "    ,[FrenchProductName] "
            + "    ,[StandardCost] "
            + "    ,[FinishedGoodsFlag] "
            + "    ,[Color] "
            + "    ,[SafetyStockLevel] "
            + "    ,[ReorderPoint] "
            + "    ,[ListPrice] "
            + "    ,[Size] "
            + "    ,[SizeRange] "
            + "    ,[Weight] "
            + "    ,[DaysToManufacture] "
            + "    ,[ProductLine] "
            + "    ,[DealerPrice] "
            + "    ,[Class] "
            + "    ,[Style] "
            + "    ,[ModelName] "
            + "    ,[EnglishDescription] "
            + "    ,[FrenchDescription] "
            + "    ,[ChineseDescription] "
            + "    ,[ArabicDescription] "
            + "    ,[HebrewDescription] "
            + "    ,[ThaiDescription] "
            + "    ,[GermanDescription] "
            + "    ,[JapaneseDescription] "
            + "    ,[TurkishDescription] "
            + "    ,[StartDate] "
            + "    ,[EndDate] "
            + "    ,[Status] "
            + "FROM "
            + "     [dbo].[DimProduct] "
            + "WHERE "
            + "     [ProductKey] = @ProductKey "
            + "";
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        selectCommand.CommandType = CommandType.Text;
        selectCommand.Parameters.AddWithValue("@ProductKey", clsdbo_DimProductPara.ProductKey);
        try
        {
            connection.Open();
            SqlDataReader reader
                = selectCommand.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                clsdbo_DimProduct.ProductKey = System.Convert.ToInt32(reader["ProductKey"]);
                clsdbo_DimProduct.ProductAlternateKey = reader["ProductAlternateKey"] is DBNull ? null : reader["ProductAlternateKey"].ToString();
                clsdbo_DimProduct.ProductSubcategoryKey = reader["ProductSubcategoryKey"] is DBNull ? null : (Int32?)reader["ProductSubcategoryKey"];
                clsdbo_DimProduct.WeightUnitMeasureCode = reader["WeightUnitMeasureCode"] is DBNull ? null : reader["WeightUnitMeasureCode"].ToString();
                clsdbo_DimProduct.SizeUnitMeasureCode = reader["SizeUnitMeasureCode"] is DBNull ? null : reader["SizeUnitMeasureCode"].ToString();
                clsdbo_DimProduct.EnglishProductName = System.Convert.ToString(reader["EnglishProductName"]);
                clsdbo_DimProduct.SpanishProductName = System.Convert.ToString(reader["SpanishProductName"]);
                clsdbo_DimProduct.FrenchProductName = System.Convert.ToString(reader["FrenchProductName"]);
                clsdbo_DimProduct.StandardCost = reader["StandardCost"] is DBNull ? null : (Decimal?)reader["StandardCost"];
                clsdbo_DimProduct.FinishedGoodsFlag = System.Convert.ToBoolean(reader["FinishedGoodsFlag"]);
                clsdbo_DimProduct.Color = System.Convert.ToString(reader["Color"]);
                clsdbo_DimProduct.SafetyStockLevel = reader["SafetyStockLevel"] is DBNull ? null : (Int16?)reader["SafetyStockLevel"];
                clsdbo_DimProduct.ReorderPoint = reader["ReorderPoint"] is DBNull ? null : (Int16?)reader["ReorderPoint"];
                clsdbo_DimProduct.ListPrice = reader["ListPrice"] is DBNull ? null : (Decimal?)reader["ListPrice"];
                clsdbo_DimProduct.Size = reader["Size"] is DBNull ? null : reader["Size"].ToString();
                clsdbo_DimProduct.SizeRange = reader["SizeRange"] is DBNull ? null : reader["SizeRange"].ToString();
                clsdbo_DimProduct.Weight = reader["Weight"] is DBNull ? null : (Decimal?)(Double?)reader["Weight"];
                clsdbo_DimProduct.DaysToManufacture = reader["DaysToManufacture"] is DBNull ? null : (Int32?)reader["DaysToManufacture"];
                clsdbo_DimProduct.ProductLine = reader["ProductLine"] is DBNull ? null : reader["ProductLine"].ToString();
                clsdbo_DimProduct.DealerPrice = reader["DealerPrice"] is DBNull ? null : (Decimal?)reader["DealerPrice"];
                clsdbo_DimProduct.Class = reader["Class"] is DBNull ? null : reader["Class"].ToString();
                clsdbo_DimProduct.Style = reader["Style"] is DBNull ? null : reader["Style"].ToString();
                clsdbo_DimProduct.ModelName = reader["ModelName"] is DBNull ? null : reader["ModelName"].ToString();
                clsdbo_DimProduct.EnglishDescription = reader["EnglishDescription"] is DBNull ? null : reader["EnglishDescription"].ToString();
                clsdbo_DimProduct.FrenchDescription = reader["FrenchDescription"] is DBNull ? null : reader["FrenchDescription"].ToString();
                clsdbo_DimProduct.ChineseDescription = reader["ChineseDescription"] is DBNull ? null : reader["ChineseDescription"].ToString();
                clsdbo_DimProduct.ArabicDescription = reader["ArabicDescription"] is DBNull ? null : reader["ArabicDescription"].ToString();
                clsdbo_DimProduct.HebrewDescription = reader["HebrewDescription"] is DBNull ? null : reader["HebrewDescription"].ToString();
                clsdbo_DimProduct.ThaiDescription = reader["ThaiDescription"] is DBNull ? null : reader["ThaiDescription"].ToString();
                clsdbo_DimProduct.GermanDescription = reader["GermanDescription"] is DBNull ? null : reader["GermanDescription"].ToString();
                clsdbo_DimProduct.JapaneseDescription = reader["JapaneseDescription"] is DBNull ? null : reader["JapaneseDescription"].ToString();
                clsdbo_DimProduct.TurkishDescription = reader["TurkishDescription"] is DBNull ? null : reader["TurkishDescription"].ToString();
                clsdbo_DimProduct.StartDate = reader["StartDate"] is DBNull ? null : (DateTime?)reader["StartDate"];
                clsdbo_DimProduct.EndDate = reader["EndDate"] is DBNull ? null : (DateTime?)reader["EndDate"];
                clsdbo_DimProduct.Status = reader["Status"] is DBNull ? null : reader["Status"].ToString();
            }
            else
            {
                clsdbo_DimProduct = null;
            }
            reader.Close();
        }
        catch (SqlException)
        {
            return clsdbo_DimProduct;
        }
        finally
        {
            connection.Close();
        }
        return clsdbo_DimProduct;
    }

    public static bool Add(dbo_DimProductClass clsdbo_DimProduct)
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string insertStatement
            = "INSERT " 
            + "     [dbo].[DimProduct] "
            + "     ( "
            + "     [ProductAlternateKey] "
            + "    ,[ProductSubcategoryKey] "
            + "    ,[WeightUnitMeasureCode] "
            + "    ,[SizeUnitMeasureCode] "
            + "    ,[EnglishProductName] "
            + "    ,[SpanishProductName] "
            + "    ,[FrenchProductName] "
            + "    ,[StandardCost] "
            + "    ,[FinishedGoodsFlag] "
            + "    ,[Color] "
            + "    ,[SafetyStockLevel] "
            + "    ,[ReorderPoint] "
            + "    ,[ListPrice] "
            + "    ,[Size] "
            + "    ,[SizeRange] "
            + "    ,[Weight] "
            + "    ,[DaysToManufacture] "
            + "    ,[ProductLine] "
            + "    ,[DealerPrice] "
            + "    ,[Class] "
            + "    ,[Style] "
            + "    ,[ModelName] "
            + "    ,[EnglishDescription] "
            + "    ,[FrenchDescription] "
            + "    ,[ChineseDescription] "
            + "    ,[ArabicDescription] "
            + "    ,[HebrewDescription] "
            + "    ,[ThaiDescription] "
            + "    ,[GermanDescription] "
            + "    ,[JapaneseDescription] "
            + "    ,[TurkishDescription] "
            + "    ,[StartDate] "
            + "    ,[EndDate] "
            + "    ,[Status] "
            + "     ) "
            + "VALUES " 
            + "     ( "
            + "     @ProductAlternateKey "
            + "    ,@ProductSubcategoryKey "
            + "    ,@WeightUnitMeasureCode "
            + "    ,@SizeUnitMeasureCode "
            + "    ,@EnglishProductName "
            + "    ,@SpanishProductName "
            + "    ,@FrenchProductName "
            + "    ,@StandardCost "
            + "    ,@FinishedGoodsFlag "
            + "    ,@Color "
            + "    ,@SafetyStockLevel "
            + "    ,@ReorderPoint "
            + "    ,@ListPrice "
            + "    ,@Size "
            + "    ,@SizeRange "
            + "    ,@Weight "
            + "    ,@DaysToManufacture "
            + "    ,@ProductLine "
            + "    ,@DealerPrice "
            + "    ,@Class "
            + "    ,@Style "
            + "    ,@ModelName "
            + "    ,@EnglishDescription "
            + "    ,@FrenchDescription "
            + "    ,@ChineseDescription "
            + "    ,@ArabicDescription "
            + "    ,@HebrewDescription "
            + "    ,@ThaiDescription "
            + "    ,@GermanDescription "
            + "    ,@JapaneseDescription "
            + "    ,@TurkishDescription "
            + "    ,@StartDate "
            + "    ,@EndDate "
            + "    ,@Status "
            + "     ) "
            + "";
        SqlCommand insertCommand = new SqlCommand(insertStatement, connection);
        insertCommand.CommandType = CommandType.Text;
        if (clsdbo_DimProduct.ProductAlternateKey != null) {
            insertCommand.Parameters.AddWithValue("@ProductAlternateKey", clsdbo_DimProduct.ProductAlternateKey);
        } else {
            insertCommand.Parameters.AddWithValue("@ProductAlternateKey", DBNull.Value); }
        if (clsdbo_DimProduct.ProductSubcategoryKey.HasValue == true) {
            insertCommand.Parameters.AddWithValue("@ProductSubcategoryKey", clsdbo_DimProduct.ProductSubcategoryKey);
        } else {
            insertCommand.Parameters.AddWithValue("@ProductSubcategoryKey", DBNull.Value); }
        if (clsdbo_DimProduct.WeightUnitMeasureCode != null) {
            insertCommand.Parameters.AddWithValue("@WeightUnitMeasureCode", clsdbo_DimProduct.WeightUnitMeasureCode);
        } else {
            insertCommand.Parameters.AddWithValue("@WeightUnitMeasureCode", DBNull.Value); }
        if (clsdbo_DimProduct.SizeUnitMeasureCode != null) {
            insertCommand.Parameters.AddWithValue("@SizeUnitMeasureCode", clsdbo_DimProduct.SizeUnitMeasureCode);
        } else {
            insertCommand.Parameters.AddWithValue("@SizeUnitMeasureCode", DBNull.Value); }
        insertCommand.Parameters.AddWithValue("@EnglishProductName", clsdbo_DimProduct.EnglishProductName);
        insertCommand.Parameters.AddWithValue("@SpanishProductName", clsdbo_DimProduct.SpanishProductName);
        insertCommand.Parameters.AddWithValue("@FrenchProductName", clsdbo_DimProduct.FrenchProductName);
        if (clsdbo_DimProduct.StandardCost.HasValue == true) {
            insertCommand.Parameters.AddWithValue("@StandardCost", clsdbo_DimProduct.StandardCost);
        } else {
            insertCommand.Parameters.AddWithValue("@StandardCost", DBNull.Value); }
        insertCommand.Parameters.AddWithValue("@FinishedGoodsFlag", clsdbo_DimProduct.FinishedGoodsFlag);
        insertCommand.Parameters.AddWithValue("@Color", clsdbo_DimProduct.Color);
        if (clsdbo_DimProduct.SafetyStockLevel.HasValue == true) {
            insertCommand.Parameters.AddWithValue("@SafetyStockLevel", clsdbo_DimProduct.SafetyStockLevel);
        } else {
            insertCommand.Parameters.AddWithValue("@SafetyStockLevel", DBNull.Value); }
        if (clsdbo_DimProduct.ReorderPoint.HasValue == true) {
            insertCommand.Parameters.AddWithValue("@ReorderPoint", clsdbo_DimProduct.ReorderPoint);
        } else {
            insertCommand.Parameters.AddWithValue("@ReorderPoint", DBNull.Value); }
        if (clsdbo_DimProduct.ListPrice.HasValue == true) {
            insertCommand.Parameters.AddWithValue("@ListPrice", clsdbo_DimProduct.ListPrice);
        } else {
            insertCommand.Parameters.AddWithValue("@ListPrice", DBNull.Value); }
        if (clsdbo_DimProduct.Size != null) {
            insertCommand.Parameters.AddWithValue("@Size", clsdbo_DimProduct.Size);
        } else {
            insertCommand.Parameters.AddWithValue("@Size", DBNull.Value); }
        if (clsdbo_DimProduct.SizeRange != null) {
            insertCommand.Parameters.AddWithValue("@SizeRange", clsdbo_DimProduct.SizeRange);
        } else {
            insertCommand.Parameters.AddWithValue("@SizeRange", DBNull.Value); }
        if (clsdbo_DimProduct.Weight.HasValue == true) {
            insertCommand.Parameters.AddWithValue("@Weight", clsdbo_DimProduct.Weight);
        } else {
            insertCommand.Parameters.AddWithValue("@Weight", DBNull.Value); }
        if (clsdbo_DimProduct.DaysToManufacture.HasValue == true) {
            insertCommand.Parameters.AddWithValue("@DaysToManufacture", clsdbo_DimProduct.DaysToManufacture);
        } else {
            insertCommand.Parameters.AddWithValue("@DaysToManufacture", DBNull.Value); }
        if (clsdbo_DimProduct.ProductLine != null) {
            insertCommand.Parameters.AddWithValue("@ProductLine", clsdbo_DimProduct.ProductLine);
        } else {
            insertCommand.Parameters.AddWithValue("@ProductLine", DBNull.Value); }
        if (clsdbo_DimProduct.DealerPrice.HasValue == true) {
            insertCommand.Parameters.AddWithValue("@DealerPrice", clsdbo_DimProduct.DealerPrice);
        } else {
            insertCommand.Parameters.AddWithValue("@DealerPrice", DBNull.Value); }
        if (clsdbo_DimProduct.Class != null) {
            insertCommand.Parameters.AddWithValue("@Class", clsdbo_DimProduct.Class);
        } else {
            insertCommand.Parameters.AddWithValue("@Class", DBNull.Value); }
        if (clsdbo_DimProduct.Style != null) {
            insertCommand.Parameters.AddWithValue("@Style", clsdbo_DimProduct.Style);
        } else {
            insertCommand.Parameters.AddWithValue("@Style", DBNull.Value); }
        if (clsdbo_DimProduct.ModelName != null) {
            insertCommand.Parameters.AddWithValue("@ModelName", clsdbo_DimProduct.ModelName);
        } else {
            insertCommand.Parameters.AddWithValue("@ModelName", DBNull.Value); }
        if (clsdbo_DimProduct.EnglishDescription != null) {
            insertCommand.Parameters.AddWithValue("@EnglishDescription", clsdbo_DimProduct.EnglishDescription);
        } else {
            insertCommand.Parameters.AddWithValue("@EnglishDescription", DBNull.Value); }
        if (clsdbo_DimProduct.FrenchDescription != null) {
            insertCommand.Parameters.AddWithValue("@FrenchDescription", clsdbo_DimProduct.FrenchDescription);
        } else {
            insertCommand.Parameters.AddWithValue("@FrenchDescription", DBNull.Value); }
        if (clsdbo_DimProduct.ChineseDescription != null) {
            insertCommand.Parameters.AddWithValue("@ChineseDescription", clsdbo_DimProduct.ChineseDescription);
        } else {
            insertCommand.Parameters.AddWithValue("@ChineseDescription", DBNull.Value); }
        if (clsdbo_DimProduct.ArabicDescription != null) {
            insertCommand.Parameters.AddWithValue("@ArabicDescription", clsdbo_DimProduct.ArabicDescription);
        } else {
            insertCommand.Parameters.AddWithValue("@ArabicDescription", DBNull.Value); }
        if (clsdbo_DimProduct.HebrewDescription != null) {
            insertCommand.Parameters.AddWithValue("@HebrewDescription", clsdbo_DimProduct.HebrewDescription);
        } else {
            insertCommand.Parameters.AddWithValue("@HebrewDescription", DBNull.Value); }
        if (clsdbo_DimProduct.ThaiDescription != null) {
            insertCommand.Parameters.AddWithValue("@ThaiDescription", clsdbo_DimProduct.ThaiDescription);
        } else {
            insertCommand.Parameters.AddWithValue("@ThaiDescription", DBNull.Value); }
        if (clsdbo_DimProduct.GermanDescription != null) {
            insertCommand.Parameters.AddWithValue("@GermanDescription", clsdbo_DimProduct.GermanDescription);
        } else {
            insertCommand.Parameters.AddWithValue("@GermanDescription", DBNull.Value); }
        if (clsdbo_DimProduct.JapaneseDescription != null) {
            insertCommand.Parameters.AddWithValue("@JapaneseDescription", clsdbo_DimProduct.JapaneseDescription);
        } else {
            insertCommand.Parameters.AddWithValue("@JapaneseDescription", DBNull.Value); }
        if (clsdbo_DimProduct.TurkishDescription != null) {
            insertCommand.Parameters.AddWithValue("@TurkishDescription", clsdbo_DimProduct.TurkishDescription);
        } else {
            insertCommand.Parameters.AddWithValue("@TurkishDescription", DBNull.Value); }
        if (clsdbo_DimProduct.StartDate.HasValue == true) {
            insertCommand.Parameters.AddWithValue("@StartDate", clsdbo_DimProduct.StartDate);
        } else {
            insertCommand.Parameters.AddWithValue("@StartDate", DBNull.Value); }
        if (clsdbo_DimProduct.EndDate.HasValue == true) {
            insertCommand.Parameters.AddWithValue("@EndDate", clsdbo_DimProduct.EndDate);
        } else {
            insertCommand.Parameters.AddWithValue("@EndDate", DBNull.Value); }
        if (clsdbo_DimProduct.Status != null) {
            insertCommand.Parameters.AddWithValue("@Status", clsdbo_DimProduct.Status);
        } else {
            insertCommand.Parameters.AddWithValue("@Status", DBNull.Value); }
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

    public static bool Update(dbo_DimProductClass olddbo_DimProductClass, 
           dbo_DimProductClass newdbo_DimProductClass)
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string updateStatement
            = "UPDATE "  
            + "     [dbo].[DimProduct] "
            + "SET "
            + "     [ProductAlternateKey] = @NewProductAlternateKey "
            + "    ,[ProductSubcategoryKey] = @NewProductSubcategoryKey "
            + "    ,[WeightUnitMeasureCode] = @NewWeightUnitMeasureCode "
            + "    ,[SizeUnitMeasureCode] = @NewSizeUnitMeasureCode "
            + "    ,[EnglishProductName] = @NewEnglishProductName "
            + "    ,[SpanishProductName] = @NewSpanishProductName "
            + "    ,[FrenchProductName] = @NewFrenchProductName "
            + "    ,[StandardCost] = @NewStandardCost "
            + "    ,[FinishedGoodsFlag] = @NewFinishedGoodsFlag "
            + "    ,[Color] = @NewColor "
            + "    ,[SafetyStockLevel] = @NewSafetyStockLevel "
            + "    ,[ReorderPoint] = @NewReorderPoint "
            + "    ,[ListPrice] = @NewListPrice "
            + "    ,[Size] = @NewSize "
            + "    ,[SizeRange] = @NewSizeRange "
            + "    ,[Weight] = @NewWeight "
            + "    ,[DaysToManufacture] = @NewDaysToManufacture "
            + "    ,[ProductLine] = @NewProductLine "
            + "    ,[DealerPrice] = @NewDealerPrice "
            + "    ,[Class] = @NewClass "
            + "    ,[Style] = @NewStyle "
            + "    ,[ModelName] = @NewModelName "
            + "    ,[EnglishDescription] = @NewEnglishDescription "
            + "    ,[FrenchDescription] = @NewFrenchDescription "
            + "    ,[ChineseDescription] = @NewChineseDescription "
            + "    ,[ArabicDescription] = @NewArabicDescription "
            + "    ,[HebrewDescription] = @NewHebrewDescription "
            + "    ,[ThaiDescription] = @NewThaiDescription "
            + "    ,[GermanDescription] = @NewGermanDescription "
            + "    ,[JapaneseDescription] = @NewJapaneseDescription "
            + "    ,[TurkishDescription] = @NewTurkishDescription "
            + "    ,[StartDate] = @NewStartDate "
            + "    ,[EndDate] = @NewEndDate "
            + "    ,[Status] = @NewStatus "
            + "WHERE "
            + "     [ProductKey] = @OldProductKey " 
            + " AND ((@OldProductAlternateKey IS NULL AND [ProductAlternateKey] IS NULL) OR [ProductAlternateKey] = @OldProductAlternateKey) " 
            + " AND ((@OldProductSubcategoryKey IS NULL AND [ProductSubcategoryKey] IS NULL) OR [ProductSubcategoryKey] = @OldProductSubcategoryKey) " 
            + " AND ((@OldWeightUnitMeasureCode IS NULL AND [WeightUnitMeasureCode] IS NULL) OR [WeightUnitMeasureCode] = @OldWeightUnitMeasureCode) " 
            + " AND ((@OldSizeUnitMeasureCode IS NULL AND [SizeUnitMeasureCode] IS NULL) OR [SizeUnitMeasureCode] = @OldSizeUnitMeasureCode) " 
            + " AND [EnglishProductName] = @OldEnglishProductName " 
            + " AND [SpanishProductName] = @OldSpanishProductName " 
            + " AND [FrenchProductName] = @OldFrenchProductName " 
            + " AND ((@OldStandardCost IS NULL AND [StandardCost] IS NULL) OR [StandardCost] = @OldStandardCost) " 
            + " AND [FinishedGoodsFlag] = @OldFinishedGoodsFlag " 
            + " AND [Color] = @OldColor " 
            + " AND ((@OldSafetyStockLevel IS NULL AND [SafetyStockLevel] IS NULL) OR [SafetyStockLevel] = @OldSafetyStockLevel) " 
            + " AND ((@OldReorderPoint IS NULL AND [ReorderPoint] IS NULL) OR [ReorderPoint] = @OldReorderPoint) " 
            + " AND ((@OldListPrice IS NULL AND [ListPrice] IS NULL) OR [ListPrice] = @OldListPrice) " 
            + " AND ((@OldSize IS NULL AND [Size] IS NULL) OR [Size] = @OldSize) " 
            + " AND ((@OldSizeRange IS NULL AND [SizeRange] IS NULL) OR [SizeRange] = @OldSizeRange) " 
            + " AND ((@OldWeight IS NULL AND [Weight] IS NULL) OR [Weight] = @OldWeight) " 
            + " AND ((@OldDaysToManufacture IS NULL AND [DaysToManufacture] IS NULL) OR [DaysToManufacture] = @OldDaysToManufacture) " 
            + " AND ((@OldProductLine IS NULL AND [ProductLine] IS NULL) OR [ProductLine] = @OldProductLine) " 
            + " AND ((@OldDealerPrice IS NULL AND [DealerPrice] IS NULL) OR [DealerPrice] = @OldDealerPrice) " 
            + " AND ((@OldClass IS NULL AND [Class] IS NULL) OR [Class] = @OldClass) " 
            + " AND ((@OldStyle IS NULL AND [Style] IS NULL) OR [Style] = @OldStyle) " 
            + " AND ((@OldModelName IS NULL AND [ModelName] IS NULL) OR [ModelName] = @OldModelName) " 
            + " AND ((@OldEnglishDescription IS NULL AND [EnglishDescription] IS NULL) OR [EnglishDescription] = @OldEnglishDescription) " 
            + " AND ((@OldFrenchDescription IS NULL AND [FrenchDescription] IS NULL) OR [FrenchDescription] = @OldFrenchDescription) " 
            + " AND ((@OldChineseDescription IS NULL AND [ChineseDescription] IS NULL) OR [ChineseDescription] = @OldChineseDescription) " 
            + " AND ((@OldArabicDescription IS NULL AND [ArabicDescription] IS NULL) OR [ArabicDescription] = @OldArabicDescription) " 
            + " AND ((@OldHebrewDescription IS NULL AND [HebrewDescription] IS NULL) OR [HebrewDescription] = @OldHebrewDescription) " 
            + " AND ((@OldThaiDescription IS NULL AND [ThaiDescription] IS NULL) OR [ThaiDescription] = @OldThaiDescription) " 
            + " AND ((@OldGermanDescription IS NULL AND [GermanDescription] IS NULL) OR [GermanDescription] = @OldGermanDescription) " 
            + " AND ((@OldJapaneseDescription IS NULL AND [JapaneseDescription] IS NULL) OR [JapaneseDescription] = @OldJapaneseDescription) " 
            + " AND ((@OldTurkishDescription IS NULL AND [TurkishDescription] IS NULL) OR [TurkishDescription] = @OldTurkishDescription) " 
            + " AND ((@OldStartDate IS NULL AND [StartDate] IS NULL) OR [StartDate] = @OldStartDate) " 
            + " AND ((@OldEndDate IS NULL AND [EndDate] IS NULL) OR [EndDate] = @OldEndDate) " 
            + " AND ((@OldStatus IS NULL AND [Status] IS NULL) OR [Status] = @OldStatus) " 
            + "";
        SqlCommand updateCommand = new SqlCommand(updateStatement, connection);
        updateCommand.CommandType = CommandType.Text;
        if (newdbo_DimProductClass.ProductAlternateKey != null) {
            updateCommand.Parameters.AddWithValue("@NewProductAlternateKey", newdbo_DimProductClass.ProductAlternateKey);
        } else {
            updateCommand.Parameters.AddWithValue("@NewProductAlternateKey", DBNull.Value); }
        if (newdbo_DimProductClass.ProductSubcategoryKey.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@NewProductSubcategoryKey", newdbo_DimProductClass.ProductSubcategoryKey);
        } else {
            updateCommand.Parameters.AddWithValue("@NewProductSubcategoryKey", DBNull.Value); }
        if (newdbo_DimProductClass.WeightUnitMeasureCode != null) {
            updateCommand.Parameters.AddWithValue("@NewWeightUnitMeasureCode", newdbo_DimProductClass.WeightUnitMeasureCode);
        } else {
            updateCommand.Parameters.AddWithValue("@NewWeightUnitMeasureCode", DBNull.Value); }
        if (newdbo_DimProductClass.SizeUnitMeasureCode != null) {
            updateCommand.Parameters.AddWithValue("@NewSizeUnitMeasureCode", newdbo_DimProductClass.SizeUnitMeasureCode);
        } else {
            updateCommand.Parameters.AddWithValue("@NewSizeUnitMeasureCode", DBNull.Value); }
        updateCommand.Parameters.AddWithValue("@NewEnglishProductName", newdbo_DimProductClass.EnglishProductName);
        updateCommand.Parameters.AddWithValue("@NewSpanishProductName", newdbo_DimProductClass.SpanishProductName);
        updateCommand.Parameters.AddWithValue("@NewFrenchProductName", newdbo_DimProductClass.FrenchProductName);
        if (newdbo_DimProductClass.StandardCost.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@NewStandardCost", newdbo_DimProductClass.StandardCost);
        } else {
            updateCommand.Parameters.AddWithValue("@NewStandardCost", DBNull.Value); }
        updateCommand.Parameters.AddWithValue("@NewFinishedGoodsFlag", newdbo_DimProductClass.FinishedGoodsFlag);
        updateCommand.Parameters.AddWithValue("@NewColor", newdbo_DimProductClass.Color);
        if (newdbo_DimProductClass.SafetyStockLevel.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@NewSafetyStockLevel", newdbo_DimProductClass.SafetyStockLevel);
        } else {
            updateCommand.Parameters.AddWithValue("@NewSafetyStockLevel", DBNull.Value); }
        if (newdbo_DimProductClass.ReorderPoint.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@NewReorderPoint", newdbo_DimProductClass.ReorderPoint);
        } else {
            updateCommand.Parameters.AddWithValue("@NewReorderPoint", DBNull.Value); }
        if (newdbo_DimProductClass.ListPrice.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@NewListPrice", newdbo_DimProductClass.ListPrice);
        } else {
            updateCommand.Parameters.AddWithValue("@NewListPrice", DBNull.Value); }
        if (newdbo_DimProductClass.Size != null) {
            updateCommand.Parameters.AddWithValue("@NewSize", newdbo_DimProductClass.Size);
        } else {
            updateCommand.Parameters.AddWithValue("@NewSize", DBNull.Value); }
        if (newdbo_DimProductClass.SizeRange != null) {
            updateCommand.Parameters.AddWithValue("@NewSizeRange", newdbo_DimProductClass.SizeRange);
        } else {
            updateCommand.Parameters.AddWithValue("@NewSizeRange", DBNull.Value); }
        if (newdbo_DimProductClass.Weight.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@NewWeight", newdbo_DimProductClass.Weight);
        } else {
            updateCommand.Parameters.AddWithValue("@NewWeight", DBNull.Value); }
        if (newdbo_DimProductClass.DaysToManufacture.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@NewDaysToManufacture", newdbo_DimProductClass.DaysToManufacture);
        } else {
            updateCommand.Parameters.AddWithValue("@NewDaysToManufacture", DBNull.Value); }
        if (newdbo_DimProductClass.ProductLine != null) {
            updateCommand.Parameters.AddWithValue("@NewProductLine", newdbo_DimProductClass.ProductLine);
        } else {
            updateCommand.Parameters.AddWithValue("@NewProductLine", DBNull.Value); }
        if (newdbo_DimProductClass.DealerPrice.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@NewDealerPrice", newdbo_DimProductClass.DealerPrice);
        } else {
            updateCommand.Parameters.AddWithValue("@NewDealerPrice", DBNull.Value); }
        if (newdbo_DimProductClass.Class != null) {
            updateCommand.Parameters.AddWithValue("@NewClass", newdbo_DimProductClass.Class);
        } else {
            updateCommand.Parameters.AddWithValue("@NewClass", DBNull.Value); }
        if (newdbo_DimProductClass.Style != null) {
            updateCommand.Parameters.AddWithValue("@NewStyle", newdbo_DimProductClass.Style);
        } else {
            updateCommand.Parameters.AddWithValue("@NewStyle", DBNull.Value); }
        if (newdbo_DimProductClass.ModelName != null) {
            updateCommand.Parameters.AddWithValue("@NewModelName", newdbo_DimProductClass.ModelName);
        } else {
            updateCommand.Parameters.AddWithValue("@NewModelName", DBNull.Value); }
        if (newdbo_DimProductClass.EnglishDescription != null) {
            updateCommand.Parameters.AddWithValue("@NewEnglishDescription", newdbo_DimProductClass.EnglishDescription);
        } else {
            updateCommand.Parameters.AddWithValue("@NewEnglishDescription", DBNull.Value); }
        if (newdbo_DimProductClass.FrenchDescription != null) {
            updateCommand.Parameters.AddWithValue("@NewFrenchDescription", newdbo_DimProductClass.FrenchDescription);
        } else {
            updateCommand.Parameters.AddWithValue("@NewFrenchDescription", DBNull.Value); }
        if (newdbo_DimProductClass.ChineseDescription != null) {
            updateCommand.Parameters.AddWithValue("@NewChineseDescription", newdbo_DimProductClass.ChineseDescription);
        } else {
            updateCommand.Parameters.AddWithValue("@NewChineseDescription", DBNull.Value); }
        if (newdbo_DimProductClass.ArabicDescription != null) {
            updateCommand.Parameters.AddWithValue("@NewArabicDescription", newdbo_DimProductClass.ArabicDescription);
        } else {
            updateCommand.Parameters.AddWithValue("@NewArabicDescription", DBNull.Value); }
        if (newdbo_DimProductClass.HebrewDescription != null) {
            updateCommand.Parameters.AddWithValue("@NewHebrewDescription", newdbo_DimProductClass.HebrewDescription);
        } else {
            updateCommand.Parameters.AddWithValue("@NewHebrewDescription", DBNull.Value); }
        if (newdbo_DimProductClass.ThaiDescription != null) {
            updateCommand.Parameters.AddWithValue("@NewThaiDescription", newdbo_DimProductClass.ThaiDescription);
        } else {
            updateCommand.Parameters.AddWithValue("@NewThaiDescription", DBNull.Value); }
        if (newdbo_DimProductClass.GermanDescription != null) {
            updateCommand.Parameters.AddWithValue("@NewGermanDescription", newdbo_DimProductClass.GermanDescription);
        } else {
            updateCommand.Parameters.AddWithValue("@NewGermanDescription", DBNull.Value); }
        if (newdbo_DimProductClass.JapaneseDescription != null) {
            updateCommand.Parameters.AddWithValue("@NewJapaneseDescription", newdbo_DimProductClass.JapaneseDescription);
        } else {
            updateCommand.Parameters.AddWithValue("@NewJapaneseDescription", DBNull.Value); }
        if (newdbo_DimProductClass.TurkishDescription != null) {
            updateCommand.Parameters.AddWithValue("@NewTurkishDescription", newdbo_DimProductClass.TurkishDescription);
        } else {
            updateCommand.Parameters.AddWithValue("@NewTurkishDescription", DBNull.Value); }
        if (newdbo_DimProductClass.StartDate.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@NewStartDate", newdbo_DimProductClass.StartDate);
        } else {
            updateCommand.Parameters.AddWithValue("@NewStartDate", DBNull.Value); }
        if (newdbo_DimProductClass.EndDate.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@NewEndDate", newdbo_DimProductClass.EndDate);
        } else {
            updateCommand.Parameters.AddWithValue("@NewEndDate", DBNull.Value); }
        if (newdbo_DimProductClass.Status != null) {
            updateCommand.Parameters.AddWithValue("@NewStatus", newdbo_DimProductClass.Status);
        } else {
            updateCommand.Parameters.AddWithValue("@NewStatus", DBNull.Value); }
        updateCommand.Parameters.AddWithValue("@OldProductKey", olddbo_DimProductClass.ProductKey);
        if (olddbo_DimProductClass.ProductAlternateKey != null) {
            updateCommand.Parameters.AddWithValue("@OldProductAlternateKey", olddbo_DimProductClass.ProductAlternateKey);
        } else {
            updateCommand.Parameters.AddWithValue("@OldProductAlternateKey", DBNull.Value); }
        if (olddbo_DimProductClass.ProductSubcategoryKey.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@OldProductSubcategoryKey", olddbo_DimProductClass.ProductSubcategoryKey);
        } else {
            updateCommand.Parameters.AddWithValue("@OldProductSubcategoryKey", DBNull.Value); }
        if (olddbo_DimProductClass.WeightUnitMeasureCode != null) {
            updateCommand.Parameters.AddWithValue("@OldWeightUnitMeasureCode", olddbo_DimProductClass.WeightUnitMeasureCode);
        } else {
            updateCommand.Parameters.AddWithValue("@OldWeightUnitMeasureCode", DBNull.Value); }
        if (olddbo_DimProductClass.SizeUnitMeasureCode != null) {
            updateCommand.Parameters.AddWithValue("@OldSizeUnitMeasureCode", olddbo_DimProductClass.SizeUnitMeasureCode);
        } else {
            updateCommand.Parameters.AddWithValue("@OldSizeUnitMeasureCode", DBNull.Value); }
        updateCommand.Parameters.AddWithValue("@OldEnglishProductName", olddbo_DimProductClass.EnglishProductName);
        updateCommand.Parameters.AddWithValue("@OldSpanishProductName", olddbo_DimProductClass.SpanishProductName);
        updateCommand.Parameters.AddWithValue("@OldFrenchProductName", olddbo_DimProductClass.FrenchProductName);
        if (olddbo_DimProductClass.StandardCost.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@OldStandardCost", olddbo_DimProductClass.StandardCost);
        } else {
            updateCommand.Parameters.AddWithValue("@OldStandardCost", DBNull.Value); }
        updateCommand.Parameters.AddWithValue("@OldFinishedGoodsFlag", olddbo_DimProductClass.FinishedGoodsFlag);
        updateCommand.Parameters.AddWithValue("@OldColor", olddbo_DimProductClass.Color);
        if (olddbo_DimProductClass.SafetyStockLevel.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@OldSafetyStockLevel", olddbo_DimProductClass.SafetyStockLevel);
        } else {
            updateCommand.Parameters.AddWithValue("@OldSafetyStockLevel", DBNull.Value); }
        if (olddbo_DimProductClass.ReorderPoint.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@OldReorderPoint", olddbo_DimProductClass.ReorderPoint);
        } else {
            updateCommand.Parameters.AddWithValue("@OldReorderPoint", DBNull.Value); }
        if (olddbo_DimProductClass.ListPrice.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@OldListPrice", olddbo_DimProductClass.ListPrice);
        } else {
            updateCommand.Parameters.AddWithValue("@OldListPrice", DBNull.Value); }
        if (olddbo_DimProductClass.Size != null) {
            updateCommand.Parameters.AddWithValue("@OldSize", olddbo_DimProductClass.Size);
        } else {
            updateCommand.Parameters.AddWithValue("@OldSize", DBNull.Value); }
        if (olddbo_DimProductClass.SizeRange != null) {
            updateCommand.Parameters.AddWithValue("@OldSizeRange", olddbo_DimProductClass.SizeRange);
        } else {
            updateCommand.Parameters.AddWithValue("@OldSizeRange", DBNull.Value); }
        if (olddbo_DimProductClass.Weight.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@OldWeight", olddbo_DimProductClass.Weight);
        } else {
            updateCommand.Parameters.AddWithValue("@OldWeight", DBNull.Value); }
        if (olddbo_DimProductClass.DaysToManufacture.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@OldDaysToManufacture", olddbo_DimProductClass.DaysToManufacture);
        } else {
            updateCommand.Parameters.AddWithValue("@OldDaysToManufacture", DBNull.Value); }
        if (olddbo_DimProductClass.ProductLine != null) {
            updateCommand.Parameters.AddWithValue("@OldProductLine", olddbo_DimProductClass.ProductLine);
        } else {
            updateCommand.Parameters.AddWithValue("@OldProductLine", DBNull.Value); }
        if (olddbo_DimProductClass.DealerPrice.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@OldDealerPrice", olddbo_DimProductClass.DealerPrice);
        } else {
            updateCommand.Parameters.AddWithValue("@OldDealerPrice", DBNull.Value); }
        if (olddbo_DimProductClass.Class != null) {
            updateCommand.Parameters.AddWithValue("@OldClass", olddbo_DimProductClass.Class);
        } else {
            updateCommand.Parameters.AddWithValue("@OldClass", DBNull.Value); }
        if (olddbo_DimProductClass.Style != null) {
            updateCommand.Parameters.AddWithValue("@OldStyle", olddbo_DimProductClass.Style);
        } else {
            updateCommand.Parameters.AddWithValue("@OldStyle", DBNull.Value); }
        if (olddbo_DimProductClass.ModelName != null) {
            updateCommand.Parameters.AddWithValue("@OldModelName", olddbo_DimProductClass.ModelName);
        } else {
            updateCommand.Parameters.AddWithValue("@OldModelName", DBNull.Value); }
        if (olddbo_DimProductClass.EnglishDescription != null) {
            updateCommand.Parameters.AddWithValue("@OldEnglishDescription", olddbo_DimProductClass.EnglishDescription);
        } else {
            updateCommand.Parameters.AddWithValue("@OldEnglishDescription", DBNull.Value); }
        if (olddbo_DimProductClass.FrenchDescription != null) {
            updateCommand.Parameters.AddWithValue("@OldFrenchDescription", olddbo_DimProductClass.FrenchDescription);
        } else {
            updateCommand.Parameters.AddWithValue("@OldFrenchDescription", DBNull.Value); }
        if (olddbo_DimProductClass.ChineseDescription != null) {
            updateCommand.Parameters.AddWithValue("@OldChineseDescription", olddbo_DimProductClass.ChineseDescription);
        } else {
            updateCommand.Parameters.AddWithValue("@OldChineseDescription", DBNull.Value); }
        if (olddbo_DimProductClass.ArabicDescription != null) {
            updateCommand.Parameters.AddWithValue("@OldArabicDescription", olddbo_DimProductClass.ArabicDescription);
        } else {
            updateCommand.Parameters.AddWithValue("@OldArabicDescription", DBNull.Value); }
        if (olddbo_DimProductClass.HebrewDescription != null) {
            updateCommand.Parameters.AddWithValue("@OldHebrewDescription", olddbo_DimProductClass.HebrewDescription);
        } else {
            updateCommand.Parameters.AddWithValue("@OldHebrewDescription", DBNull.Value); }
        if (olddbo_DimProductClass.ThaiDescription != null) {
            updateCommand.Parameters.AddWithValue("@OldThaiDescription", olddbo_DimProductClass.ThaiDescription);
        } else {
            updateCommand.Parameters.AddWithValue("@OldThaiDescription", DBNull.Value); }
        if (olddbo_DimProductClass.GermanDescription != null) {
            updateCommand.Parameters.AddWithValue("@OldGermanDescription", olddbo_DimProductClass.GermanDescription);
        } else {
            updateCommand.Parameters.AddWithValue("@OldGermanDescription", DBNull.Value); }
        if (olddbo_DimProductClass.JapaneseDescription != null) {
            updateCommand.Parameters.AddWithValue("@OldJapaneseDescription", olddbo_DimProductClass.JapaneseDescription);
        } else {
            updateCommand.Parameters.AddWithValue("@OldJapaneseDescription", DBNull.Value); }
        if (olddbo_DimProductClass.TurkishDescription != null) {
            updateCommand.Parameters.AddWithValue("@OldTurkishDescription", olddbo_DimProductClass.TurkishDescription);
        } else {
            updateCommand.Parameters.AddWithValue("@OldTurkishDescription", DBNull.Value); }
        if (olddbo_DimProductClass.StartDate.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@OldStartDate", olddbo_DimProductClass.StartDate);
        } else {
            updateCommand.Parameters.AddWithValue("@OldStartDate", DBNull.Value); }
        if (olddbo_DimProductClass.EndDate.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@OldEndDate", olddbo_DimProductClass.EndDate);
        } else {
            updateCommand.Parameters.AddWithValue("@OldEndDate", DBNull.Value); }
        if (olddbo_DimProductClass.Status != null) {
            updateCommand.Parameters.AddWithValue("@OldStatus", olddbo_DimProductClass.Status);
        } else {
            updateCommand.Parameters.AddWithValue("@OldStatus", DBNull.Value); }
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

    public static bool Delete(dbo_DimProductClass clsdbo_DimProduct)
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string deleteStatement
            = "DELETE FROM "  
            + "     [dbo].[DimProduct] "
            + "WHERE " 
            + "     [ProductKey] = @OldProductKey " 
            + " AND ((@OldProductAlternateKey IS NULL AND [ProductAlternateKey] IS NULL) OR [ProductAlternateKey] = @OldProductAlternateKey) " 
            + " AND ((@OldProductSubcategoryKey IS NULL AND [ProductSubcategoryKey] IS NULL) OR [ProductSubcategoryKey] = @OldProductSubcategoryKey) " 
            + " AND ((@OldWeightUnitMeasureCode IS NULL AND [WeightUnitMeasureCode] IS NULL) OR [WeightUnitMeasureCode] = @OldWeightUnitMeasureCode) " 
            + " AND ((@OldSizeUnitMeasureCode IS NULL AND [SizeUnitMeasureCode] IS NULL) OR [SizeUnitMeasureCode] = @OldSizeUnitMeasureCode) " 
            + " AND [EnglishProductName] = @OldEnglishProductName " 
            + " AND [SpanishProductName] = @OldSpanishProductName " 
            + " AND [FrenchProductName] = @OldFrenchProductName " 
            + " AND ((@OldStandardCost IS NULL AND [StandardCost] IS NULL) OR [StandardCost] = @OldStandardCost) " 
            + " AND [FinishedGoodsFlag] = @OldFinishedGoodsFlag " 
            + " AND [Color] = @OldColor " 
            + " AND ((@OldSafetyStockLevel IS NULL AND [SafetyStockLevel] IS NULL) OR [SafetyStockLevel] = @OldSafetyStockLevel) " 
            + " AND ((@OldReorderPoint IS NULL AND [ReorderPoint] IS NULL) OR [ReorderPoint] = @OldReorderPoint) " 
            + " AND ((@OldListPrice IS NULL AND [ListPrice] IS NULL) OR [ListPrice] = @OldListPrice) " 
            + " AND ((@OldSize IS NULL AND [Size] IS NULL) OR [Size] = @OldSize) " 
            + " AND ((@OldSizeRange IS NULL AND [SizeRange] IS NULL) OR [SizeRange] = @OldSizeRange) " 
            + " AND ((@OldWeight IS NULL AND [Weight] IS NULL) OR [Weight] = @OldWeight) " 
            + " AND ((@OldDaysToManufacture IS NULL AND [DaysToManufacture] IS NULL) OR [DaysToManufacture] = @OldDaysToManufacture) " 
            + " AND ((@OldProductLine IS NULL AND [ProductLine] IS NULL) OR [ProductLine] = @OldProductLine) " 
            + " AND ((@OldDealerPrice IS NULL AND [DealerPrice] IS NULL) OR [DealerPrice] = @OldDealerPrice) " 
            + " AND ((@OldClass IS NULL AND [Class] IS NULL) OR [Class] = @OldClass) " 
            + " AND ((@OldStyle IS NULL AND [Style] IS NULL) OR [Style] = @OldStyle) " 
            + " AND ((@OldModelName IS NULL AND [ModelName] IS NULL) OR [ModelName] = @OldModelName) " 
            + " AND ((@OldEnglishDescription IS NULL AND [EnglishDescription] IS NULL) OR [EnglishDescription] = @OldEnglishDescription) " 
            + " AND ((@OldFrenchDescription IS NULL AND [FrenchDescription] IS NULL) OR [FrenchDescription] = @OldFrenchDescription) " 
            + " AND ((@OldChineseDescription IS NULL AND [ChineseDescription] IS NULL) OR [ChineseDescription] = @OldChineseDescription) " 
            + " AND ((@OldArabicDescription IS NULL AND [ArabicDescription] IS NULL) OR [ArabicDescription] = @OldArabicDescription) " 
            + " AND ((@OldHebrewDescription IS NULL AND [HebrewDescription] IS NULL) OR [HebrewDescription] = @OldHebrewDescription) " 
            + " AND ((@OldThaiDescription IS NULL AND [ThaiDescription] IS NULL) OR [ThaiDescription] = @OldThaiDescription) " 
            + " AND ((@OldGermanDescription IS NULL AND [GermanDescription] IS NULL) OR [GermanDescription] = @OldGermanDescription) " 
            + " AND ((@OldJapaneseDescription IS NULL AND [JapaneseDescription] IS NULL) OR [JapaneseDescription] = @OldJapaneseDescription) " 
            + " AND ((@OldTurkishDescription IS NULL AND [TurkishDescription] IS NULL) OR [TurkishDescription] = @OldTurkishDescription) " 
            + " AND ((@OldStartDate IS NULL AND [StartDate] IS NULL) OR [StartDate] = @OldStartDate) " 
            + " AND ((@OldEndDate IS NULL AND [EndDate] IS NULL) OR [EndDate] = @OldEndDate) " 
            + " AND ((@OldStatus IS NULL AND [Status] IS NULL) OR [Status] = @OldStatus) " 
            + "";
        SqlCommand deleteCommand = new SqlCommand(deleteStatement, connection);
        deleteCommand.CommandType = CommandType.Text;
        deleteCommand.Parameters.AddWithValue("@OldProductKey", clsdbo_DimProduct.ProductKey);
        if (clsdbo_DimProduct.ProductAlternateKey != null) {
            deleteCommand.Parameters.AddWithValue("@OldProductAlternateKey", clsdbo_DimProduct.ProductAlternateKey);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldProductAlternateKey", DBNull.Value); }
        if (clsdbo_DimProduct.ProductSubcategoryKey.HasValue == true) {
            deleteCommand.Parameters.AddWithValue("@OldProductSubcategoryKey", clsdbo_DimProduct.ProductSubcategoryKey);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldProductSubcategoryKey", DBNull.Value); }
        if (clsdbo_DimProduct.WeightUnitMeasureCode != null) {
            deleteCommand.Parameters.AddWithValue("@OldWeightUnitMeasureCode", clsdbo_DimProduct.WeightUnitMeasureCode);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldWeightUnitMeasureCode", DBNull.Value); }
        if (clsdbo_DimProduct.SizeUnitMeasureCode != null) {
            deleteCommand.Parameters.AddWithValue("@OldSizeUnitMeasureCode", clsdbo_DimProduct.SizeUnitMeasureCode);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldSizeUnitMeasureCode", DBNull.Value); }
        deleteCommand.Parameters.AddWithValue("@OldEnglishProductName", clsdbo_DimProduct.EnglishProductName);
        deleteCommand.Parameters.AddWithValue("@OldSpanishProductName", clsdbo_DimProduct.SpanishProductName);
        deleteCommand.Parameters.AddWithValue("@OldFrenchProductName", clsdbo_DimProduct.FrenchProductName);
        if (clsdbo_DimProduct.StandardCost.HasValue == true) {
            deleteCommand.Parameters.AddWithValue("@OldStandardCost", clsdbo_DimProduct.StandardCost);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldStandardCost", DBNull.Value); }
        deleteCommand.Parameters.AddWithValue("@OldFinishedGoodsFlag", clsdbo_DimProduct.FinishedGoodsFlag);
        deleteCommand.Parameters.AddWithValue("@OldColor", clsdbo_DimProduct.Color);
        if (clsdbo_DimProduct.SafetyStockLevel.HasValue == true) {
            deleteCommand.Parameters.AddWithValue("@OldSafetyStockLevel", clsdbo_DimProduct.SafetyStockLevel);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldSafetyStockLevel", DBNull.Value); }
        if (clsdbo_DimProduct.ReorderPoint.HasValue == true) {
            deleteCommand.Parameters.AddWithValue("@OldReorderPoint", clsdbo_DimProduct.ReorderPoint);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldReorderPoint", DBNull.Value); }
        if (clsdbo_DimProduct.ListPrice.HasValue == true) {
            deleteCommand.Parameters.AddWithValue("@OldListPrice", clsdbo_DimProduct.ListPrice);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldListPrice", DBNull.Value); }
        if (clsdbo_DimProduct.Size != null) {
            deleteCommand.Parameters.AddWithValue("@OldSize", clsdbo_DimProduct.Size);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldSize", DBNull.Value); }
        if (clsdbo_DimProduct.SizeRange != null) {
            deleteCommand.Parameters.AddWithValue("@OldSizeRange", clsdbo_DimProduct.SizeRange);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldSizeRange", DBNull.Value); }
        if (clsdbo_DimProduct.Weight.HasValue == true) {
            deleteCommand.Parameters.AddWithValue("@OldWeight", clsdbo_DimProduct.Weight);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldWeight", DBNull.Value); }
        if (clsdbo_DimProduct.DaysToManufacture.HasValue == true) {
            deleteCommand.Parameters.AddWithValue("@OldDaysToManufacture", clsdbo_DimProduct.DaysToManufacture);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldDaysToManufacture", DBNull.Value); }
        if (clsdbo_DimProduct.ProductLine != null) {
            deleteCommand.Parameters.AddWithValue("@OldProductLine", clsdbo_DimProduct.ProductLine);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldProductLine", DBNull.Value); }
        if (clsdbo_DimProduct.DealerPrice.HasValue == true) {
            deleteCommand.Parameters.AddWithValue("@OldDealerPrice", clsdbo_DimProduct.DealerPrice);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldDealerPrice", DBNull.Value); }
        if (clsdbo_DimProduct.Class != null) {
            deleteCommand.Parameters.AddWithValue("@OldClass", clsdbo_DimProduct.Class);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldClass", DBNull.Value); }
        if (clsdbo_DimProduct.Style != null) {
            deleteCommand.Parameters.AddWithValue("@OldStyle", clsdbo_DimProduct.Style);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldStyle", DBNull.Value); }
        if (clsdbo_DimProduct.ModelName != null) {
            deleteCommand.Parameters.AddWithValue("@OldModelName", clsdbo_DimProduct.ModelName);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldModelName", DBNull.Value); }
        if (clsdbo_DimProduct.EnglishDescription != null) {
            deleteCommand.Parameters.AddWithValue("@OldEnglishDescription", clsdbo_DimProduct.EnglishDescription);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldEnglishDescription", DBNull.Value); }
        if (clsdbo_DimProduct.FrenchDescription != null) {
            deleteCommand.Parameters.AddWithValue("@OldFrenchDescription", clsdbo_DimProduct.FrenchDescription);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldFrenchDescription", DBNull.Value); }
        if (clsdbo_DimProduct.ChineseDescription != null) {
            deleteCommand.Parameters.AddWithValue("@OldChineseDescription", clsdbo_DimProduct.ChineseDescription);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldChineseDescription", DBNull.Value); }
        if (clsdbo_DimProduct.ArabicDescription != null) {
            deleteCommand.Parameters.AddWithValue("@OldArabicDescription", clsdbo_DimProduct.ArabicDescription);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldArabicDescription", DBNull.Value); }
        if (clsdbo_DimProduct.HebrewDescription != null) {
            deleteCommand.Parameters.AddWithValue("@OldHebrewDescription", clsdbo_DimProduct.HebrewDescription);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldHebrewDescription", DBNull.Value); }
        if (clsdbo_DimProduct.ThaiDescription != null) {
            deleteCommand.Parameters.AddWithValue("@OldThaiDescription", clsdbo_DimProduct.ThaiDescription);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldThaiDescription", DBNull.Value); }
        if (clsdbo_DimProduct.GermanDescription != null) {
            deleteCommand.Parameters.AddWithValue("@OldGermanDescription", clsdbo_DimProduct.GermanDescription);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldGermanDescription", DBNull.Value); }
        if (clsdbo_DimProduct.JapaneseDescription != null) {
            deleteCommand.Parameters.AddWithValue("@OldJapaneseDescription", clsdbo_DimProduct.JapaneseDescription);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldJapaneseDescription", DBNull.Value); }
        if (clsdbo_DimProduct.TurkishDescription != null) {
            deleteCommand.Parameters.AddWithValue("@OldTurkishDescription", clsdbo_DimProduct.TurkishDescription);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldTurkishDescription", DBNull.Value); }
        if (clsdbo_DimProduct.StartDate.HasValue == true) {
            deleteCommand.Parameters.AddWithValue("@OldStartDate", clsdbo_DimProduct.StartDate);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldStartDate", DBNull.Value); }
        if (clsdbo_DimProduct.EndDate.HasValue == true) {
            deleteCommand.Parameters.AddWithValue("@OldEndDate", clsdbo_DimProduct.EndDate);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldEndDate", DBNull.Value); }
        if (clsdbo_DimProduct.Status != null) {
            deleteCommand.Parameters.AddWithValue("@OldStatus", clsdbo_DimProduct.Status);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldStatus", DBNull.Value); }
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

 
