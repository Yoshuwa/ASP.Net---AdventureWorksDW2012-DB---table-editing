using System;
using System.Data;
using System.Data.SqlClient;

public class dbo_DimPromotionDataClass
{

    public static DataTable SelectAll()
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement
            = "SELECT "  
            + "     [dbo].[DimPromotion].[PromotionKey] "
            + "    ,[dbo].[DimPromotion].[PromotionAlternateKey] "
            + "    ,[dbo].[DimPromotion].[EnglishPromotionName] "
            + "    ,[dbo].[DimPromotion].[SpanishPromotionName] "
            + "    ,[dbo].[DimPromotion].[FrenchPromotionName] "
            + "    ,[dbo].[DimPromotion].[DiscountPct] "
            + "    ,[dbo].[DimPromotion].[EnglishPromotionType] "
            + "    ,[dbo].[DimPromotion].[SpanishPromotionType] "
            + "    ,[dbo].[DimPromotion].[FrenchPromotionType] "
            + "    ,[dbo].[DimPromotion].[EnglishPromotionCategory] "
            + "    ,[dbo].[DimPromotion].[SpanishPromotionCategory] "
            + "    ,[dbo].[DimPromotion].[FrenchPromotionCategory] "
            + "    ,[dbo].[DimPromotion].[StartDate] "
            + "    ,[dbo].[DimPromotion].[EndDate] "
            + "    ,[dbo].[DimPromotion].[MinQty] "
            + "    ,[dbo].[DimPromotion].[MaxQty] "
            + "FROM " 
            + "     [dbo].[DimPromotion] " 
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
            + "     [dbo].[DimPromotion].[PromotionKey] "
            + "    ,[dbo].[DimPromotion].[PromotionAlternateKey] "
            + "    ,[dbo].[DimPromotion].[EnglishPromotionName] "
            + "    ,[dbo].[DimPromotion].[SpanishPromotionName] "
            + "    ,[dbo].[DimPromotion].[FrenchPromotionName] "
            + "    ,[dbo].[DimPromotion].[DiscountPct] "
            + "    ,[dbo].[DimPromotion].[EnglishPromotionType] "
            + "    ,[dbo].[DimPromotion].[SpanishPromotionType] "
            + "    ,[dbo].[DimPromotion].[FrenchPromotionType] "
            + "    ,[dbo].[DimPromotion].[EnglishPromotionCategory] "
            + "    ,[dbo].[DimPromotion].[SpanishPromotionCategory] "
            + "    ,[dbo].[DimPromotion].[FrenchPromotionCategory] "
            + "    ,[dbo].[DimPromotion].[StartDate] "
            + "    ,[dbo].[DimPromotion].[EndDate] "
            + "    ,[dbo].[DimPromotion].[MinQty] "
            + "    ,[dbo].[DimPromotion].[MaxQty] "
            + "FROM " 
            + "     [dbo].[DimPromotion] " 
                + "WHERE " 
                + "     (@PromotionKey IS NULL OR @PromotionKey = '' OR [DimPromotion].[PromotionKey] LIKE '%' + LTRIM(RTRIM(@PromotionKey)) + '%') " 
                + "AND   (@PromotionAlternateKey IS NULL OR @PromotionAlternateKey = '' OR [DimPromotion].[PromotionAlternateKey] LIKE '%' + LTRIM(RTRIM(@PromotionAlternateKey)) + '%') " 
                + "AND   (@EnglishPromotionName IS NULL OR @EnglishPromotionName = '' OR [DimPromotion].[EnglishPromotionName] LIKE '%' + LTRIM(RTRIM(@EnglishPromotionName)) + '%') " 
                + "AND   (@SpanishPromotionName IS NULL OR @SpanishPromotionName = '' OR [DimPromotion].[SpanishPromotionName] LIKE '%' + LTRIM(RTRIM(@SpanishPromotionName)) + '%') " 
                + "AND   (@FrenchPromotionName IS NULL OR @FrenchPromotionName = '' OR [DimPromotion].[FrenchPromotionName] LIKE '%' + LTRIM(RTRIM(@FrenchPromotionName)) + '%') " 
                + "AND   (@DiscountPct IS NULL OR @DiscountPct = '' OR [DimPromotion].[DiscountPct] LIKE '%' + LTRIM(RTRIM(@DiscountPct)) + '%') " 
                + "AND   (@EnglishPromotionType IS NULL OR @EnglishPromotionType = '' OR [DimPromotion].[EnglishPromotionType] LIKE '%' + LTRIM(RTRIM(@EnglishPromotionType)) + '%') " 
                + "AND   (@SpanishPromotionType IS NULL OR @SpanishPromotionType = '' OR [DimPromotion].[SpanishPromotionType] LIKE '%' + LTRIM(RTRIM(@SpanishPromotionType)) + '%') " 
                + "AND   (@FrenchPromotionType IS NULL OR @FrenchPromotionType = '' OR [DimPromotion].[FrenchPromotionType] LIKE '%' + LTRIM(RTRIM(@FrenchPromotionType)) + '%') " 
                + "AND   (@EnglishPromotionCategory IS NULL OR @EnglishPromotionCategory = '' OR [DimPromotion].[EnglishPromotionCategory] LIKE '%' + LTRIM(RTRIM(@EnglishPromotionCategory)) + '%') " 
                + "AND   (@SpanishPromotionCategory IS NULL OR @SpanishPromotionCategory = '' OR [DimPromotion].[SpanishPromotionCategory] LIKE '%' + LTRIM(RTRIM(@SpanishPromotionCategory)) + '%') " 
                + "AND   (@FrenchPromotionCategory IS NULL OR @FrenchPromotionCategory = '' OR [DimPromotion].[FrenchPromotionCategory] LIKE '%' + LTRIM(RTRIM(@FrenchPromotionCategory)) + '%') " 
                + "AND   (@StartDate IS NULL OR @StartDate = '' OR [DimPromotion].[StartDate] LIKE '%' + LTRIM(RTRIM(@StartDate)) + '%') " 
                + "AND   (@EndDate IS NULL OR @EndDate = '' OR [DimPromotion].[EndDate] LIKE '%' + LTRIM(RTRIM(@EndDate)) + '%') " 
                + "AND   (@MinQty IS NULL OR @MinQty = '' OR [DimPromotion].[MinQty] LIKE '%' + LTRIM(RTRIM(@MinQty)) + '%') " 
                + "AND   (@MaxQty IS NULL OR @MaxQty = '' OR [DimPromotion].[MaxQty] LIKE '%' + LTRIM(RTRIM(@MaxQty)) + '%') " 
                + "";
        } else if (sCondition == "Equals") {
            selectStatement
                = "SELECT "
            + "     [dbo].[DimPromotion].[PromotionKey] "
            + "    ,[dbo].[DimPromotion].[PromotionAlternateKey] "
            + "    ,[dbo].[DimPromotion].[EnglishPromotionName] "
            + "    ,[dbo].[DimPromotion].[SpanishPromotionName] "
            + "    ,[dbo].[DimPromotion].[FrenchPromotionName] "
            + "    ,[dbo].[DimPromotion].[DiscountPct] "
            + "    ,[dbo].[DimPromotion].[EnglishPromotionType] "
            + "    ,[dbo].[DimPromotion].[SpanishPromotionType] "
            + "    ,[dbo].[DimPromotion].[FrenchPromotionType] "
            + "    ,[dbo].[DimPromotion].[EnglishPromotionCategory] "
            + "    ,[dbo].[DimPromotion].[SpanishPromotionCategory] "
            + "    ,[dbo].[DimPromotion].[FrenchPromotionCategory] "
            + "    ,[dbo].[DimPromotion].[StartDate] "
            + "    ,[dbo].[DimPromotion].[EndDate] "
            + "    ,[dbo].[DimPromotion].[MinQty] "
            + "    ,[dbo].[DimPromotion].[MaxQty] "
            + "FROM " 
            + "     [dbo].[DimPromotion] " 
                + "WHERE " 
                + "     (@PromotionKey IS NULL OR @PromotionKey = '' OR [DimPromotion].[PromotionKey] = LTRIM(RTRIM(@PromotionKey))) " 
                + "AND   (@PromotionAlternateKey IS NULL OR @PromotionAlternateKey = '' OR [DimPromotion].[PromotionAlternateKey] = LTRIM(RTRIM(@PromotionAlternateKey))) " 
                + "AND   (@EnglishPromotionName IS NULL OR @EnglishPromotionName = '' OR [DimPromotion].[EnglishPromotionName] = LTRIM(RTRIM(@EnglishPromotionName))) " 
                + "AND   (@SpanishPromotionName IS NULL OR @SpanishPromotionName = '' OR [DimPromotion].[SpanishPromotionName] = LTRIM(RTRIM(@SpanishPromotionName))) " 
                + "AND   (@FrenchPromotionName IS NULL OR @FrenchPromotionName = '' OR [DimPromotion].[FrenchPromotionName] = LTRIM(RTRIM(@FrenchPromotionName))) " 
                + "AND   (@DiscountPct IS NULL OR @DiscountPct = '' OR [DimPromotion].[DiscountPct] = LTRIM(RTRIM(@DiscountPct))) " 
                + "AND   (@EnglishPromotionType IS NULL OR @EnglishPromotionType = '' OR [DimPromotion].[EnglishPromotionType] = LTRIM(RTRIM(@EnglishPromotionType))) " 
                + "AND   (@SpanishPromotionType IS NULL OR @SpanishPromotionType = '' OR [DimPromotion].[SpanishPromotionType] = LTRIM(RTRIM(@SpanishPromotionType))) " 
                + "AND   (@FrenchPromotionType IS NULL OR @FrenchPromotionType = '' OR [DimPromotion].[FrenchPromotionType] = LTRIM(RTRIM(@FrenchPromotionType))) " 
                + "AND   (@EnglishPromotionCategory IS NULL OR @EnglishPromotionCategory = '' OR [DimPromotion].[EnglishPromotionCategory] = LTRIM(RTRIM(@EnglishPromotionCategory))) " 
                + "AND   (@SpanishPromotionCategory IS NULL OR @SpanishPromotionCategory = '' OR [DimPromotion].[SpanishPromotionCategory] = LTRIM(RTRIM(@SpanishPromotionCategory))) " 
                + "AND   (@FrenchPromotionCategory IS NULL OR @FrenchPromotionCategory = '' OR [DimPromotion].[FrenchPromotionCategory] = LTRIM(RTRIM(@FrenchPromotionCategory))) " 
                + "AND   (@StartDate IS NULL OR @StartDate = '' OR [DimPromotion].[StartDate] = LTRIM(RTRIM(@StartDate))) " 
                + "AND   (@EndDate IS NULL OR @EndDate = '' OR [DimPromotion].[EndDate] = LTRIM(RTRIM(@EndDate))) " 
                + "AND   (@MinQty IS NULL OR @MinQty = '' OR [DimPromotion].[MinQty] = LTRIM(RTRIM(@MinQty))) " 
                + "AND   (@MaxQty IS NULL OR @MaxQty = '' OR [DimPromotion].[MaxQty] = LTRIM(RTRIM(@MaxQty))) " 
                + "";
        } else if  (sCondition == "Starts with...") {
            selectStatement
                = "SELECT "
            + "     [dbo].[DimPromotion].[PromotionKey] "
            + "    ,[dbo].[DimPromotion].[PromotionAlternateKey] "
            + "    ,[dbo].[DimPromotion].[EnglishPromotionName] "
            + "    ,[dbo].[DimPromotion].[SpanishPromotionName] "
            + "    ,[dbo].[DimPromotion].[FrenchPromotionName] "
            + "    ,[dbo].[DimPromotion].[DiscountPct] "
            + "    ,[dbo].[DimPromotion].[EnglishPromotionType] "
            + "    ,[dbo].[DimPromotion].[SpanishPromotionType] "
            + "    ,[dbo].[DimPromotion].[FrenchPromotionType] "
            + "    ,[dbo].[DimPromotion].[EnglishPromotionCategory] "
            + "    ,[dbo].[DimPromotion].[SpanishPromotionCategory] "
            + "    ,[dbo].[DimPromotion].[FrenchPromotionCategory] "
            + "    ,[dbo].[DimPromotion].[StartDate] "
            + "    ,[dbo].[DimPromotion].[EndDate] "
            + "    ,[dbo].[DimPromotion].[MinQty] "
            + "    ,[dbo].[DimPromotion].[MaxQty] "
            + "FROM " 
            + "     [dbo].[DimPromotion] " 
                + "WHERE " 
                + "     (@PromotionKey IS NULL OR @PromotionKey = '' OR [DimPromotion].[PromotionKey] LIKE LTRIM(RTRIM(@PromotionKey)) + '%') " 
                + "AND   (@PromotionAlternateKey IS NULL OR @PromotionAlternateKey = '' OR [DimPromotion].[PromotionAlternateKey] LIKE LTRIM(RTRIM(@PromotionAlternateKey)) + '%') " 
                + "AND   (@EnglishPromotionName IS NULL OR @EnglishPromotionName = '' OR [DimPromotion].[EnglishPromotionName] LIKE LTRIM(RTRIM(@EnglishPromotionName)) + '%') " 
                + "AND   (@SpanishPromotionName IS NULL OR @SpanishPromotionName = '' OR [DimPromotion].[SpanishPromotionName] LIKE LTRIM(RTRIM(@SpanishPromotionName)) + '%') " 
                + "AND   (@FrenchPromotionName IS NULL OR @FrenchPromotionName = '' OR [DimPromotion].[FrenchPromotionName] LIKE LTRIM(RTRIM(@FrenchPromotionName)) + '%') " 
                + "AND   (@DiscountPct IS NULL OR @DiscountPct = '' OR [DimPromotion].[DiscountPct] LIKE LTRIM(RTRIM(@DiscountPct)) + '%') " 
                + "AND   (@EnglishPromotionType IS NULL OR @EnglishPromotionType = '' OR [DimPromotion].[EnglishPromotionType] LIKE LTRIM(RTRIM(@EnglishPromotionType)) + '%') " 
                + "AND   (@SpanishPromotionType IS NULL OR @SpanishPromotionType = '' OR [DimPromotion].[SpanishPromotionType] LIKE LTRIM(RTRIM(@SpanishPromotionType)) + '%') " 
                + "AND   (@FrenchPromotionType IS NULL OR @FrenchPromotionType = '' OR [DimPromotion].[FrenchPromotionType] LIKE LTRIM(RTRIM(@FrenchPromotionType)) + '%') " 
                + "AND   (@EnglishPromotionCategory IS NULL OR @EnglishPromotionCategory = '' OR [DimPromotion].[EnglishPromotionCategory] LIKE LTRIM(RTRIM(@EnglishPromotionCategory)) + '%') " 
                + "AND   (@SpanishPromotionCategory IS NULL OR @SpanishPromotionCategory = '' OR [DimPromotion].[SpanishPromotionCategory] LIKE LTRIM(RTRIM(@SpanishPromotionCategory)) + '%') " 
                + "AND   (@FrenchPromotionCategory IS NULL OR @FrenchPromotionCategory = '' OR [DimPromotion].[FrenchPromotionCategory] LIKE LTRIM(RTRIM(@FrenchPromotionCategory)) + '%') " 
                + "AND   (@StartDate IS NULL OR @StartDate = '' OR [DimPromotion].[StartDate] LIKE LTRIM(RTRIM(@StartDate)) + '%') " 
                + "AND   (@EndDate IS NULL OR @EndDate = '' OR [DimPromotion].[EndDate] LIKE LTRIM(RTRIM(@EndDate)) + '%') " 
                + "AND   (@MinQty IS NULL OR @MinQty = '' OR [DimPromotion].[MinQty] LIKE LTRIM(RTRIM(@MinQty)) + '%') " 
                + "AND   (@MaxQty IS NULL OR @MaxQty = '' OR [DimPromotion].[MaxQty] LIKE LTRIM(RTRIM(@MaxQty)) + '%') " 
                + "";
        } else if  (sCondition == "More than...") {
            selectStatement
                = "SELECT "
            + "     [dbo].[DimPromotion].[PromotionKey] "
            + "    ,[dbo].[DimPromotion].[PromotionAlternateKey] "
            + "    ,[dbo].[DimPromotion].[EnglishPromotionName] "
            + "    ,[dbo].[DimPromotion].[SpanishPromotionName] "
            + "    ,[dbo].[DimPromotion].[FrenchPromotionName] "
            + "    ,[dbo].[DimPromotion].[DiscountPct] "
            + "    ,[dbo].[DimPromotion].[EnglishPromotionType] "
            + "    ,[dbo].[DimPromotion].[SpanishPromotionType] "
            + "    ,[dbo].[DimPromotion].[FrenchPromotionType] "
            + "    ,[dbo].[DimPromotion].[EnglishPromotionCategory] "
            + "    ,[dbo].[DimPromotion].[SpanishPromotionCategory] "
            + "    ,[dbo].[DimPromotion].[FrenchPromotionCategory] "
            + "    ,[dbo].[DimPromotion].[StartDate] "
            + "    ,[dbo].[DimPromotion].[EndDate] "
            + "    ,[dbo].[DimPromotion].[MinQty] "
            + "    ,[dbo].[DimPromotion].[MaxQty] "
            + "FROM " 
            + "     [dbo].[DimPromotion] " 
                + "WHERE " 
                + "     (@PromotionKey IS NULL OR @PromotionKey = '' OR [DimPromotion].[PromotionKey] > LTRIM(RTRIM(@PromotionKey))) " 
                + "AND   (@PromotionAlternateKey IS NULL OR @PromotionAlternateKey = '' OR [DimPromotion].[PromotionAlternateKey] > LTRIM(RTRIM(@PromotionAlternateKey))) " 
                + "AND   (@EnglishPromotionName IS NULL OR @EnglishPromotionName = '' OR [DimPromotion].[EnglishPromotionName] > LTRIM(RTRIM(@EnglishPromotionName))) " 
                + "AND   (@SpanishPromotionName IS NULL OR @SpanishPromotionName = '' OR [DimPromotion].[SpanishPromotionName] > LTRIM(RTRIM(@SpanishPromotionName))) " 
                + "AND   (@FrenchPromotionName IS NULL OR @FrenchPromotionName = '' OR [DimPromotion].[FrenchPromotionName] > LTRIM(RTRIM(@FrenchPromotionName))) " 
                + "AND   (@DiscountPct IS NULL OR @DiscountPct = '' OR [DimPromotion].[DiscountPct] > LTRIM(RTRIM(@DiscountPct))) " 
                + "AND   (@EnglishPromotionType IS NULL OR @EnglishPromotionType = '' OR [DimPromotion].[EnglishPromotionType] > LTRIM(RTRIM(@EnglishPromotionType))) " 
                + "AND   (@SpanishPromotionType IS NULL OR @SpanishPromotionType = '' OR [DimPromotion].[SpanishPromotionType] > LTRIM(RTRIM(@SpanishPromotionType))) " 
                + "AND   (@FrenchPromotionType IS NULL OR @FrenchPromotionType = '' OR [DimPromotion].[FrenchPromotionType] > LTRIM(RTRIM(@FrenchPromotionType))) " 
                + "AND   (@EnglishPromotionCategory IS NULL OR @EnglishPromotionCategory = '' OR [DimPromotion].[EnglishPromotionCategory] > LTRIM(RTRIM(@EnglishPromotionCategory))) " 
                + "AND   (@SpanishPromotionCategory IS NULL OR @SpanishPromotionCategory = '' OR [DimPromotion].[SpanishPromotionCategory] > LTRIM(RTRIM(@SpanishPromotionCategory))) " 
                + "AND   (@FrenchPromotionCategory IS NULL OR @FrenchPromotionCategory = '' OR [DimPromotion].[FrenchPromotionCategory] > LTRIM(RTRIM(@FrenchPromotionCategory))) " 
                + "AND   (@StartDate IS NULL OR @StartDate = '' OR [DimPromotion].[StartDate] > LTRIM(RTRIM(@StartDate))) " 
                + "AND   (@EndDate IS NULL OR @EndDate = '' OR [DimPromotion].[EndDate] > LTRIM(RTRIM(@EndDate))) " 
                + "AND   (@MinQty IS NULL OR @MinQty = '' OR [DimPromotion].[MinQty] > LTRIM(RTRIM(@MinQty))) " 
                + "AND   (@MaxQty IS NULL OR @MaxQty = '' OR [DimPromotion].[MaxQty] > LTRIM(RTRIM(@MaxQty))) " 
                + "";
        } else if  (sCondition == "Less than...") {
            selectStatement
                = "SELECT " 
            + "     [dbo].[DimPromotion].[PromotionKey] "
            + "    ,[dbo].[DimPromotion].[PromotionAlternateKey] "
            + "    ,[dbo].[DimPromotion].[EnglishPromotionName] "
            + "    ,[dbo].[DimPromotion].[SpanishPromotionName] "
            + "    ,[dbo].[DimPromotion].[FrenchPromotionName] "
            + "    ,[dbo].[DimPromotion].[DiscountPct] "
            + "    ,[dbo].[DimPromotion].[EnglishPromotionType] "
            + "    ,[dbo].[DimPromotion].[SpanishPromotionType] "
            + "    ,[dbo].[DimPromotion].[FrenchPromotionType] "
            + "    ,[dbo].[DimPromotion].[EnglishPromotionCategory] "
            + "    ,[dbo].[DimPromotion].[SpanishPromotionCategory] "
            + "    ,[dbo].[DimPromotion].[FrenchPromotionCategory] "
            + "    ,[dbo].[DimPromotion].[StartDate] "
            + "    ,[dbo].[DimPromotion].[EndDate] "
            + "    ,[dbo].[DimPromotion].[MinQty] "
            + "    ,[dbo].[DimPromotion].[MaxQty] "
            + "FROM " 
            + "     [dbo].[DimPromotion] " 
                + "WHERE " 
                + "     (@PromotionKey IS NULL OR @PromotionKey = '' OR [DimPromotion].[PromotionKey] < LTRIM(RTRIM(@PromotionKey))) " 
                + "AND   (@PromotionAlternateKey IS NULL OR @PromotionAlternateKey = '' OR [DimPromotion].[PromotionAlternateKey] < LTRIM(RTRIM(@PromotionAlternateKey))) " 
                + "AND   (@EnglishPromotionName IS NULL OR @EnglishPromotionName = '' OR [DimPromotion].[EnglishPromotionName] < LTRIM(RTRIM(@EnglishPromotionName))) " 
                + "AND   (@SpanishPromotionName IS NULL OR @SpanishPromotionName = '' OR [DimPromotion].[SpanishPromotionName] < LTRIM(RTRIM(@SpanishPromotionName))) " 
                + "AND   (@FrenchPromotionName IS NULL OR @FrenchPromotionName = '' OR [DimPromotion].[FrenchPromotionName] < LTRIM(RTRIM(@FrenchPromotionName))) " 
                + "AND   (@DiscountPct IS NULL OR @DiscountPct = '' OR [DimPromotion].[DiscountPct] < LTRIM(RTRIM(@DiscountPct))) " 
                + "AND   (@EnglishPromotionType IS NULL OR @EnglishPromotionType = '' OR [DimPromotion].[EnglishPromotionType] < LTRIM(RTRIM(@EnglishPromotionType))) " 
                + "AND   (@SpanishPromotionType IS NULL OR @SpanishPromotionType = '' OR [DimPromotion].[SpanishPromotionType] < LTRIM(RTRIM(@SpanishPromotionType))) " 
                + "AND   (@FrenchPromotionType IS NULL OR @FrenchPromotionType = '' OR [DimPromotion].[FrenchPromotionType] < LTRIM(RTRIM(@FrenchPromotionType))) " 
                + "AND   (@EnglishPromotionCategory IS NULL OR @EnglishPromotionCategory = '' OR [DimPromotion].[EnglishPromotionCategory] < LTRIM(RTRIM(@EnglishPromotionCategory))) " 
                + "AND   (@SpanishPromotionCategory IS NULL OR @SpanishPromotionCategory = '' OR [DimPromotion].[SpanishPromotionCategory] < LTRIM(RTRIM(@SpanishPromotionCategory))) " 
                + "AND   (@FrenchPromotionCategory IS NULL OR @FrenchPromotionCategory = '' OR [DimPromotion].[FrenchPromotionCategory] < LTRIM(RTRIM(@FrenchPromotionCategory))) " 
                + "AND   (@StartDate IS NULL OR @StartDate = '' OR [DimPromotion].[StartDate] < LTRIM(RTRIM(@StartDate))) " 
                + "AND   (@EndDate IS NULL OR @EndDate = '' OR [DimPromotion].[EndDate] < LTRIM(RTRIM(@EndDate))) " 
                + "AND   (@MinQty IS NULL OR @MinQty = '' OR [DimPromotion].[MinQty] < LTRIM(RTRIM(@MinQty))) " 
                + "AND   (@MaxQty IS NULL OR @MaxQty = '' OR [DimPromotion].[MaxQty] < LTRIM(RTRIM(@MaxQty))) " 
                + "";
        } else if  (sCondition == "Equal or more than...") {
            selectStatement
                = "SELECT "
            + "     [dbo].[DimPromotion].[PromotionKey] "
            + "    ,[dbo].[DimPromotion].[PromotionAlternateKey] "
            + "    ,[dbo].[DimPromotion].[EnglishPromotionName] "
            + "    ,[dbo].[DimPromotion].[SpanishPromotionName] "
            + "    ,[dbo].[DimPromotion].[FrenchPromotionName] "
            + "    ,[dbo].[DimPromotion].[DiscountPct] "
            + "    ,[dbo].[DimPromotion].[EnglishPromotionType] "
            + "    ,[dbo].[DimPromotion].[SpanishPromotionType] "
            + "    ,[dbo].[DimPromotion].[FrenchPromotionType] "
            + "    ,[dbo].[DimPromotion].[EnglishPromotionCategory] "
            + "    ,[dbo].[DimPromotion].[SpanishPromotionCategory] "
            + "    ,[dbo].[DimPromotion].[FrenchPromotionCategory] "
            + "    ,[dbo].[DimPromotion].[StartDate] "
            + "    ,[dbo].[DimPromotion].[EndDate] "
            + "    ,[dbo].[DimPromotion].[MinQty] "
            + "    ,[dbo].[DimPromotion].[MaxQty] "
            + "FROM " 
            + "     [dbo].[DimPromotion] " 
                + "WHERE " 
                + "     (@PromotionKey IS NULL OR @PromotionKey = '' OR [DimPromotion].[PromotionKey] >= LTRIM(RTRIM(@PromotionKey))) " 
                + "AND   (@PromotionAlternateKey IS NULL OR @PromotionAlternateKey = '' OR [DimPromotion].[PromotionAlternateKey] >= LTRIM(RTRIM(@PromotionAlternateKey))) " 
                + "AND   (@EnglishPromotionName IS NULL OR @EnglishPromotionName = '' OR [DimPromotion].[EnglishPromotionName] >= LTRIM(RTRIM(@EnglishPromotionName))) " 
                + "AND   (@SpanishPromotionName IS NULL OR @SpanishPromotionName = '' OR [DimPromotion].[SpanishPromotionName] >= LTRIM(RTRIM(@SpanishPromotionName))) " 
                + "AND   (@FrenchPromotionName IS NULL OR @FrenchPromotionName = '' OR [DimPromotion].[FrenchPromotionName] >= LTRIM(RTRIM(@FrenchPromotionName))) " 
                + "AND   (@DiscountPct IS NULL OR @DiscountPct = '' OR [DimPromotion].[DiscountPct] >= LTRIM(RTRIM(@DiscountPct))) " 
                + "AND   (@EnglishPromotionType IS NULL OR @EnglishPromotionType = '' OR [DimPromotion].[EnglishPromotionType] >= LTRIM(RTRIM(@EnglishPromotionType))) " 
                + "AND   (@SpanishPromotionType IS NULL OR @SpanishPromotionType = '' OR [DimPromotion].[SpanishPromotionType] >= LTRIM(RTRIM(@SpanishPromotionType))) " 
                + "AND   (@FrenchPromotionType IS NULL OR @FrenchPromotionType = '' OR [DimPromotion].[FrenchPromotionType] >= LTRIM(RTRIM(@FrenchPromotionType))) " 
                + "AND   (@EnglishPromotionCategory IS NULL OR @EnglishPromotionCategory = '' OR [DimPromotion].[EnglishPromotionCategory] >= LTRIM(RTRIM(@EnglishPromotionCategory))) " 
                + "AND   (@SpanishPromotionCategory IS NULL OR @SpanishPromotionCategory = '' OR [DimPromotion].[SpanishPromotionCategory] >= LTRIM(RTRIM(@SpanishPromotionCategory))) " 
                + "AND   (@FrenchPromotionCategory IS NULL OR @FrenchPromotionCategory = '' OR [DimPromotion].[FrenchPromotionCategory] >= LTRIM(RTRIM(@FrenchPromotionCategory))) " 
                + "AND   (@StartDate IS NULL OR @StartDate = '' OR [DimPromotion].[StartDate] >= LTRIM(RTRIM(@StartDate))) " 
                + "AND   (@EndDate IS NULL OR @EndDate = '' OR [DimPromotion].[EndDate] >= LTRIM(RTRIM(@EndDate))) " 
                + "AND   (@MinQty IS NULL OR @MinQty = '' OR [DimPromotion].[MinQty] >= LTRIM(RTRIM(@MinQty))) " 
                + "AND   (@MaxQty IS NULL OR @MaxQty = '' OR [DimPromotion].[MaxQty] >= LTRIM(RTRIM(@MaxQty))) " 
                + "";
        } else if (sCondition == "Equal or less than...") {
            selectStatement 
                = "SELECT "
            + "     [dbo].[DimPromotion].[PromotionKey] "
            + "    ,[dbo].[DimPromotion].[PromotionAlternateKey] "
            + "    ,[dbo].[DimPromotion].[EnglishPromotionName] "
            + "    ,[dbo].[DimPromotion].[SpanishPromotionName] "
            + "    ,[dbo].[DimPromotion].[FrenchPromotionName] "
            + "    ,[dbo].[DimPromotion].[DiscountPct] "
            + "    ,[dbo].[DimPromotion].[EnglishPromotionType] "
            + "    ,[dbo].[DimPromotion].[SpanishPromotionType] "
            + "    ,[dbo].[DimPromotion].[FrenchPromotionType] "
            + "    ,[dbo].[DimPromotion].[EnglishPromotionCategory] "
            + "    ,[dbo].[DimPromotion].[SpanishPromotionCategory] "
            + "    ,[dbo].[DimPromotion].[FrenchPromotionCategory] "
            + "    ,[dbo].[DimPromotion].[StartDate] "
            + "    ,[dbo].[DimPromotion].[EndDate] "
            + "    ,[dbo].[DimPromotion].[MinQty] "
            + "    ,[dbo].[DimPromotion].[MaxQty] "
            + "FROM " 
            + "     [dbo].[DimPromotion] " 
                + "WHERE " 
                + "     (@PromotionKey IS NULL OR @PromotionKey = '' OR [DimPromotion].[PromotionKey] <= LTRIM(RTRIM(@PromotionKey))) " 
                + "AND   (@PromotionAlternateKey IS NULL OR @PromotionAlternateKey = '' OR [DimPromotion].[PromotionAlternateKey] <= LTRIM(RTRIM(@PromotionAlternateKey))) " 
                + "AND   (@EnglishPromotionName IS NULL OR @EnglishPromotionName = '' OR [DimPromotion].[EnglishPromotionName] <= LTRIM(RTRIM(@EnglishPromotionName))) " 
                + "AND   (@SpanishPromotionName IS NULL OR @SpanishPromotionName = '' OR [DimPromotion].[SpanishPromotionName] <= LTRIM(RTRIM(@SpanishPromotionName))) " 
                + "AND   (@FrenchPromotionName IS NULL OR @FrenchPromotionName = '' OR [DimPromotion].[FrenchPromotionName] <= LTRIM(RTRIM(@FrenchPromotionName))) " 
                + "AND   (@DiscountPct IS NULL OR @DiscountPct = '' OR [DimPromotion].[DiscountPct] <= LTRIM(RTRIM(@DiscountPct))) " 
                + "AND   (@EnglishPromotionType IS NULL OR @EnglishPromotionType = '' OR [DimPromotion].[EnglishPromotionType] <= LTRIM(RTRIM(@EnglishPromotionType))) " 
                + "AND   (@SpanishPromotionType IS NULL OR @SpanishPromotionType = '' OR [DimPromotion].[SpanishPromotionType] <= LTRIM(RTRIM(@SpanishPromotionType))) " 
                + "AND   (@FrenchPromotionType IS NULL OR @FrenchPromotionType = '' OR [DimPromotion].[FrenchPromotionType] <= LTRIM(RTRIM(@FrenchPromotionType))) " 
                + "AND   (@EnglishPromotionCategory IS NULL OR @EnglishPromotionCategory = '' OR [DimPromotion].[EnglishPromotionCategory] <= LTRIM(RTRIM(@EnglishPromotionCategory))) " 
                + "AND   (@SpanishPromotionCategory IS NULL OR @SpanishPromotionCategory = '' OR [DimPromotion].[SpanishPromotionCategory] <= LTRIM(RTRIM(@SpanishPromotionCategory))) " 
                + "AND   (@FrenchPromotionCategory IS NULL OR @FrenchPromotionCategory = '' OR [DimPromotion].[FrenchPromotionCategory] <= LTRIM(RTRIM(@FrenchPromotionCategory))) " 
                + "AND   (@StartDate IS NULL OR @StartDate = '' OR [DimPromotion].[StartDate] <= LTRIM(RTRIM(@StartDate))) " 
                + "AND   (@EndDate IS NULL OR @EndDate = '' OR [DimPromotion].[EndDate] <= LTRIM(RTRIM(@EndDate))) " 
                + "AND   (@MinQty IS NULL OR @MinQty = '' OR [DimPromotion].[MinQty] <= LTRIM(RTRIM(@MinQty))) " 
                + "AND   (@MaxQty IS NULL OR @MaxQty = '' OR [DimPromotion].[MaxQty] <= LTRIM(RTRIM(@MaxQty))) " 
                + "";
        }
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        selectCommand.CommandType = CommandType.Text;
        if (sField == "Promotion Key") {
            selectCommand.Parameters.AddWithValue("@PromotionKey", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@PromotionKey", DBNull.Value); }
        if (sField == "Promotion Alternate Key") {
            selectCommand.Parameters.AddWithValue("@PromotionAlternateKey", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@PromotionAlternateKey", DBNull.Value); }
        if (sField == "English Promotion Name") {
            selectCommand.Parameters.AddWithValue("@EnglishPromotionName", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@EnglishPromotionName", DBNull.Value); }
        if (sField == "Spanish Promotion Name") {
            selectCommand.Parameters.AddWithValue("@SpanishPromotionName", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@SpanishPromotionName", DBNull.Value); }
        if (sField == "French Promotion Name") {
            selectCommand.Parameters.AddWithValue("@FrenchPromotionName", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@FrenchPromotionName", DBNull.Value); }
        if (sField == "Discount Pct") {
            selectCommand.Parameters.AddWithValue("@DiscountPct", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@DiscountPct", DBNull.Value); }
        if (sField == "English Promotion Type") {
            selectCommand.Parameters.AddWithValue("@EnglishPromotionType", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@EnglishPromotionType", DBNull.Value); }
        if (sField == "Spanish Promotion Type") {
            selectCommand.Parameters.AddWithValue("@SpanishPromotionType", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@SpanishPromotionType", DBNull.Value); }
        if (sField == "French Promotion Type") {
            selectCommand.Parameters.AddWithValue("@FrenchPromotionType", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@FrenchPromotionType", DBNull.Value); }
        if (sField == "English Promotion Category") {
            selectCommand.Parameters.AddWithValue("@EnglishPromotionCategory", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@EnglishPromotionCategory", DBNull.Value); }
        if (sField == "Spanish Promotion Category") {
            selectCommand.Parameters.AddWithValue("@SpanishPromotionCategory", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@SpanishPromotionCategory", DBNull.Value); }
        if (sField == "French Promotion Category") {
            selectCommand.Parameters.AddWithValue("@FrenchPromotionCategory", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@FrenchPromotionCategory", DBNull.Value); }
        if (sField == "Start Date") {
            selectCommand.Parameters.AddWithValue("@StartDate", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@StartDate", DBNull.Value); }
        if (sField == "End Date") {
            selectCommand.Parameters.AddWithValue("@EndDate", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@EndDate", DBNull.Value); }
        if (sField == "Min Qty") {
            selectCommand.Parameters.AddWithValue("@MinQty", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@MinQty", DBNull.Value); }
        if (sField == "Max Qty") {
            selectCommand.Parameters.AddWithValue("@MaxQty", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@MaxQty", DBNull.Value); }
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

    public static dbo_DimPromotionClass Select_Record(dbo_DimPromotionClass clsdbo_DimPromotionPara)
    {
        dbo_DimPromotionClass clsdbo_DimPromotion = new dbo_DimPromotionClass();
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement
            = "SELECT " 
            + "     [PromotionKey] "
            + "    ,[PromotionAlternateKey] "
            + "    ,[EnglishPromotionName] "
            + "    ,[SpanishPromotionName] "
            + "    ,[FrenchPromotionName] "
            + "    ,[DiscountPct] "
            + "    ,[EnglishPromotionType] "
            + "    ,[SpanishPromotionType] "
            + "    ,[FrenchPromotionType] "
            + "    ,[EnglishPromotionCategory] "
            + "    ,[SpanishPromotionCategory] "
            + "    ,[FrenchPromotionCategory] "
            + "    ,[StartDate] "
            + "    ,[EndDate] "
            + "    ,[MinQty] "
            + "    ,[MaxQty] "
            + "FROM "
            + "     [dbo].[DimPromotion] "
            + "WHERE "
            + "     [PromotionKey] = @PromotionKey "
            + "";
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        selectCommand.CommandType = CommandType.Text;
        selectCommand.Parameters.AddWithValue("@PromotionKey", clsdbo_DimPromotionPara.PromotionKey);
        try
        {
            connection.Open();
            SqlDataReader reader
                = selectCommand.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                clsdbo_DimPromotion.PromotionKey = System.Convert.ToInt32(reader["PromotionKey"]);
                clsdbo_DimPromotion.PromotionAlternateKey = reader["PromotionAlternateKey"] is DBNull ? null : (Int32?)reader["PromotionAlternateKey"];
                clsdbo_DimPromotion.EnglishPromotionName = reader["EnglishPromotionName"] is DBNull ? null : reader["EnglishPromotionName"].ToString();
                clsdbo_DimPromotion.SpanishPromotionName = reader["SpanishPromotionName"] is DBNull ? null : reader["SpanishPromotionName"].ToString();
                clsdbo_DimPromotion.FrenchPromotionName = reader["FrenchPromotionName"] is DBNull ? null : reader["FrenchPromotionName"].ToString();
                clsdbo_DimPromotion.DiscountPct = reader["DiscountPct"] is DBNull ? null : (Decimal?)(Double?)reader["DiscountPct"];
                clsdbo_DimPromotion.EnglishPromotionType = reader["EnglishPromotionType"] is DBNull ? null : reader["EnglishPromotionType"].ToString();
                clsdbo_DimPromotion.SpanishPromotionType = reader["SpanishPromotionType"] is DBNull ? null : reader["SpanishPromotionType"].ToString();
                clsdbo_DimPromotion.FrenchPromotionType = reader["FrenchPromotionType"] is DBNull ? null : reader["FrenchPromotionType"].ToString();
                clsdbo_DimPromotion.EnglishPromotionCategory = reader["EnglishPromotionCategory"] is DBNull ? null : reader["EnglishPromotionCategory"].ToString();
                clsdbo_DimPromotion.SpanishPromotionCategory = reader["SpanishPromotionCategory"] is DBNull ? null : reader["SpanishPromotionCategory"].ToString();
                clsdbo_DimPromotion.FrenchPromotionCategory = reader["FrenchPromotionCategory"] is DBNull ? null : reader["FrenchPromotionCategory"].ToString();
                clsdbo_DimPromotion.StartDate = System.Convert.ToDateTime(reader["StartDate"]);
                clsdbo_DimPromotion.EndDate = reader["EndDate"] is DBNull ? null : (DateTime?)reader["EndDate"];
                clsdbo_DimPromotion.MinQty = reader["MinQty"] is DBNull ? null : (Int32?)reader["MinQty"];
                clsdbo_DimPromotion.MaxQty = reader["MaxQty"] is DBNull ? null : (Int32?)reader["MaxQty"];
            }
            else
            {
                clsdbo_DimPromotion = null;
            }
            reader.Close();
        }
        catch (SqlException)
        {
            return clsdbo_DimPromotion;
        }
        finally
        {
            connection.Close();
        }
        return clsdbo_DimPromotion;
    }

    public static bool Add(dbo_DimPromotionClass clsdbo_DimPromotion)
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string insertStatement
            = "INSERT " 
            + "     [dbo].[DimPromotion] "
            + "     ( "
            + "     [PromotionAlternateKey] "
            + "    ,[EnglishPromotionName] "
            + "    ,[SpanishPromotionName] "
            + "    ,[FrenchPromotionName] "
            + "    ,[DiscountPct] "
            + "    ,[EnglishPromotionType] "
            + "    ,[SpanishPromotionType] "
            + "    ,[FrenchPromotionType] "
            + "    ,[EnglishPromotionCategory] "
            + "    ,[SpanishPromotionCategory] "
            + "    ,[FrenchPromotionCategory] "
            + "    ,[StartDate] "
            + "    ,[EndDate] "
            + "    ,[MinQty] "
            + "    ,[MaxQty] "
            + "     ) "
            + "VALUES " 
            + "     ( "
            + "     @PromotionAlternateKey "
            + "    ,@EnglishPromotionName "
            + "    ,@SpanishPromotionName "
            + "    ,@FrenchPromotionName "
            + "    ,@DiscountPct "
            + "    ,@EnglishPromotionType "
            + "    ,@SpanishPromotionType "
            + "    ,@FrenchPromotionType "
            + "    ,@EnglishPromotionCategory "
            + "    ,@SpanishPromotionCategory "
            + "    ,@FrenchPromotionCategory "
            + "    ,@StartDate "
            + "    ,@EndDate "
            + "    ,@MinQty "
            + "    ,@MaxQty "
            + "     ) "
            + "";
        SqlCommand insertCommand = new SqlCommand(insertStatement, connection);
        insertCommand.CommandType = CommandType.Text;
        if (clsdbo_DimPromotion.PromotionAlternateKey.HasValue == true) {
            insertCommand.Parameters.AddWithValue("@PromotionAlternateKey", clsdbo_DimPromotion.PromotionAlternateKey);
        } else {
            insertCommand.Parameters.AddWithValue("@PromotionAlternateKey", DBNull.Value); }
        if (clsdbo_DimPromotion.EnglishPromotionName != null) {
            insertCommand.Parameters.AddWithValue("@EnglishPromotionName", clsdbo_DimPromotion.EnglishPromotionName);
        } else {
            insertCommand.Parameters.AddWithValue("@EnglishPromotionName", DBNull.Value); }
        if (clsdbo_DimPromotion.SpanishPromotionName != null) {
            insertCommand.Parameters.AddWithValue("@SpanishPromotionName", clsdbo_DimPromotion.SpanishPromotionName);
        } else {
            insertCommand.Parameters.AddWithValue("@SpanishPromotionName", DBNull.Value); }
        if (clsdbo_DimPromotion.FrenchPromotionName != null) {
            insertCommand.Parameters.AddWithValue("@FrenchPromotionName", clsdbo_DimPromotion.FrenchPromotionName);
        } else {
            insertCommand.Parameters.AddWithValue("@FrenchPromotionName", DBNull.Value); }
        if (clsdbo_DimPromotion.DiscountPct.HasValue == true) {
            insertCommand.Parameters.AddWithValue("@DiscountPct", clsdbo_DimPromotion.DiscountPct);
        } else {
            insertCommand.Parameters.AddWithValue("@DiscountPct", DBNull.Value); }
        if (clsdbo_DimPromotion.EnglishPromotionType != null) {
            insertCommand.Parameters.AddWithValue("@EnglishPromotionType", clsdbo_DimPromotion.EnglishPromotionType);
        } else {
            insertCommand.Parameters.AddWithValue("@EnglishPromotionType", DBNull.Value); }
        if (clsdbo_DimPromotion.SpanishPromotionType != null) {
            insertCommand.Parameters.AddWithValue("@SpanishPromotionType", clsdbo_DimPromotion.SpanishPromotionType);
        } else {
            insertCommand.Parameters.AddWithValue("@SpanishPromotionType", DBNull.Value); }
        if (clsdbo_DimPromotion.FrenchPromotionType != null) {
            insertCommand.Parameters.AddWithValue("@FrenchPromotionType", clsdbo_DimPromotion.FrenchPromotionType);
        } else {
            insertCommand.Parameters.AddWithValue("@FrenchPromotionType", DBNull.Value); }
        if (clsdbo_DimPromotion.EnglishPromotionCategory != null) {
            insertCommand.Parameters.AddWithValue("@EnglishPromotionCategory", clsdbo_DimPromotion.EnglishPromotionCategory);
        } else {
            insertCommand.Parameters.AddWithValue("@EnglishPromotionCategory", DBNull.Value); }
        if (clsdbo_DimPromotion.SpanishPromotionCategory != null) {
            insertCommand.Parameters.AddWithValue("@SpanishPromotionCategory", clsdbo_DimPromotion.SpanishPromotionCategory);
        } else {
            insertCommand.Parameters.AddWithValue("@SpanishPromotionCategory", DBNull.Value); }
        if (clsdbo_DimPromotion.FrenchPromotionCategory != null) {
            insertCommand.Parameters.AddWithValue("@FrenchPromotionCategory", clsdbo_DimPromotion.FrenchPromotionCategory);
        } else {
            insertCommand.Parameters.AddWithValue("@FrenchPromotionCategory", DBNull.Value); }
        insertCommand.Parameters.AddWithValue("@StartDate", clsdbo_DimPromotion.StartDate);
        if (clsdbo_DimPromotion.EndDate.HasValue == true) {
            insertCommand.Parameters.AddWithValue("@EndDate", clsdbo_DimPromotion.EndDate);
        } else {
            insertCommand.Parameters.AddWithValue("@EndDate", DBNull.Value); }
        if (clsdbo_DimPromotion.MinQty.HasValue == true) {
            insertCommand.Parameters.AddWithValue("@MinQty", clsdbo_DimPromotion.MinQty);
        } else {
            insertCommand.Parameters.AddWithValue("@MinQty", DBNull.Value); }
        if (clsdbo_DimPromotion.MaxQty.HasValue == true) {
            insertCommand.Parameters.AddWithValue("@MaxQty", clsdbo_DimPromotion.MaxQty);
        } else {
            insertCommand.Parameters.AddWithValue("@MaxQty", DBNull.Value); }
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

    public static bool Update(dbo_DimPromotionClass olddbo_DimPromotionClass, 
           dbo_DimPromotionClass newdbo_DimPromotionClass)
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string updateStatement
            = "UPDATE "  
            + "     [dbo].[DimPromotion] "
            + "SET "
            + "     [PromotionAlternateKey] = @NewPromotionAlternateKey "
            + "    ,[EnglishPromotionName] = @NewEnglishPromotionName "
            + "    ,[SpanishPromotionName] = @NewSpanishPromotionName "
            + "    ,[FrenchPromotionName] = @NewFrenchPromotionName "
            + "    ,[DiscountPct] = @NewDiscountPct "
            + "    ,[EnglishPromotionType] = @NewEnglishPromotionType "
            + "    ,[SpanishPromotionType] = @NewSpanishPromotionType "
            + "    ,[FrenchPromotionType] = @NewFrenchPromotionType "
            + "    ,[EnglishPromotionCategory] = @NewEnglishPromotionCategory "
            + "    ,[SpanishPromotionCategory] = @NewSpanishPromotionCategory "
            + "    ,[FrenchPromotionCategory] = @NewFrenchPromotionCategory "
            + "    ,[StartDate] = @NewStartDate "
            + "    ,[EndDate] = @NewEndDate "
            + "    ,[MinQty] = @NewMinQty "
            + "    ,[MaxQty] = @NewMaxQty "
            + "WHERE "
            + "     [PromotionKey] = @OldPromotionKey " 
            + " AND ((@OldPromotionAlternateKey IS NULL AND [PromotionAlternateKey] IS NULL) OR [PromotionAlternateKey] = @OldPromotionAlternateKey) " 
            + " AND ((@OldEnglishPromotionName IS NULL AND [EnglishPromotionName] IS NULL) OR [EnglishPromotionName] = @OldEnglishPromotionName) " 
            + " AND ((@OldSpanishPromotionName IS NULL AND [SpanishPromotionName] IS NULL) OR [SpanishPromotionName] = @OldSpanishPromotionName) " 
            + " AND ((@OldFrenchPromotionName IS NULL AND [FrenchPromotionName] IS NULL) OR [FrenchPromotionName] = @OldFrenchPromotionName) " 
            + " AND ((@OldDiscountPct IS NULL AND [DiscountPct] IS NULL) OR [DiscountPct] = @OldDiscountPct) " 
            + " AND ((@OldEnglishPromotionType IS NULL AND [EnglishPromotionType] IS NULL) OR [EnglishPromotionType] = @OldEnglishPromotionType) " 
            + " AND ((@OldSpanishPromotionType IS NULL AND [SpanishPromotionType] IS NULL) OR [SpanishPromotionType] = @OldSpanishPromotionType) " 
            + " AND ((@OldFrenchPromotionType IS NULL AND [FrenchPromotionType] IS NULL) OR [FrenchPromotionType] = @OldFrenchPromotionType) " 
            + " AND ((@OldEnglishPromotionCategory IS NULL AND [EnglishPromotionCategory] IS NULL) OR [EnglishPromotionCategory] = @OldEnglishPromotionCategory) " 
            + " AND ((@OldSpanishPromotionCategory IS NULL AND [SpanishPromotionCategory] IS NULL) OR [SpanishPromotionCategory] = @OldSpanishPromotionCategory) " 
            + " AND ((@OldFrenchPromotionCategory IS NULL AND [FrenchPromotionCategory] IS NULL) OR [FrenchPromotionCategory] = @OldFrenchPromotionCategory) " 
            + " AND [StartDate] = @OldStartDate " 
            + " AND ((@OldEndDate IS NULL AND [EndDate] IS NULL) OR [EndDate] = @OldEndDate) " 
            + " AND ((@OldMinQty IS NULL AND [MinQty] IS NULL) OR [MinQty] = @OldMinQty) " 
            + " AND ((@OldMaxQty IS NULL AND [MaxQty] IS NULL) OR [MaxQty] = @OldMaxQty) " 
            + "";
        SqlCommand updateCommand = new SqlCommand(updateStatement, connection);
        updateCommand.CommandType = CommandType.Text;
        if (newdbo_DimPromotionClass.PromotionAlternateKey.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@NewPromotionAlternateKey", newdbo_DimPromotionClass.PromotionAlternateKey);
        } else {
            updateCommand.Parameters.AddWithValue("@NewPromotionAlternateKey", DBNull.Value); }
        if (newdbo_DimPromotionClass.EnglishPromotionName != null) {
            updateCommand.Parameters.AddWithValue("@NewEnglishPromotionName", newdbo_DimPromotionClass.EnglishPromotionName);
        } else {
            updateCommand.Parameters.AddWithValue("@NewEnglishPromotionName", DBNull.Value); }
        if (newdbo_DimPromotionClass.SpanishPromotionName != null) {
            updateCommand.Parameters.AddWithValue("@NewSpanishPromotionName", newdbo_DimPromotionClass.SpanishPromotionName);
        } else {
            updateCommand.Parameters.AddWithValue("@NewSpanishPromotionName", DBNull.Value); }
        if (newdbo_DimPromotionClass.FrenchPromotionName != null) {
            updateCommand.Parameters.AddWithValue("@NewFrenchPromotionName", newdbo_DimPromotionClass.FrenchPromotionName);
        } else {
            updateCommand.Parameters.AddWithValue("@NewFrenchPromotionName", DBNull.Value); }
        if (newdbo_DimPromotionClass.DiscountPct.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@NewDiscountPct", newdbo_DimPromotionClass.DiscountPct);
        } else {
            updateCommand.Parameters.AddWithValue("@NewDiscountPct", DBNull.Value); }
        if (newdbo_DimPromotionClass.EnglishPromotionType != null) {
            updateCommand.Parameters.AddWithValue("@NewEnglishPromotionType", newdbo_DimPromotionClass.EnglishPromotionType);
        } else {
            updateCommand.Parameters.AddWithValue("@NewEnglishPromotionType", DBNull.Value); }
        if (newdbo_DimPromotionClass.SpanishPromotionType != null) {
            updateCommand.Parameters.AddWithValue("@NewSpanishPromotionType", newdbo_DimPromotionClass.SpanishPromotionType);
        } else {
            updateCommand.Parameters.AddWithValue("@NewSpanishPromotionType", DBNull.Value); }
        if (newdbo_DimPromotionClass.FrenchPromotionType != null) {
            updateCommand.Parameters.AddWithValue("@NewFrenchPromotionType", newdbo_DimPromotionClass.FrenchPromotionType);
        } else {
            updateCommand.Parameters.AddWithValue("@NewFrenchPromotionType", DBNull.Value); }
        if (newdbo_DimPromotionClass.EnglishPromotionCategory != null) {
            updateCommand.Parameters.AddWithValue("@NewEnglishPromotionCategory", newdbo_DimPromotionClass.EnglishPromotionCategory);
        } else {
            updateCommand.Parameters.AddWithValue("@NewEnglishPromotionCategory", DBNull.Value); }
        if (newdbo_DimPromotionClass.SpanishPromotionCategory != null) {
            updateCommand.Parameters.AddWithValue("@NewSpanishPromotionCategory", newdbo_DimPromotionClass.SpanishPromotionCategory);
        } else {
            updateCommand.Parameters.AddWithValue("@NewSpanishPromotionCategory", DBNull.Value); }
        if (newdbo_DimPromotionClass.FrenchPromotionCategory != null) {
            updateCommand.Parameters.AddWithValue("@NewFrenchPromotionCategory", newdbo_DimPromotionClass.FrenchPromotionCategory);
        } else {
            updateCommand.Parameters.AddWithValue("@NewFrenchPromotionCategory", DBNull.Value); }
        updateCommand.Parameters.AddWithValue("@NewStartDate", newdbo_DimPromotionClass.StartDate);
        if (newdbo_DimPromotionClass.EndDate.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@NewEndDate", newdbo_DimPromotionClass.EndDate);
        } else {
            updateCommand.Parameters.AddWithValue("@NewEndDate", DBNull.Value); }
        if (newdbo_DimPromotionClass.MinQty.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@NewMinQty", newdbo_DimPromotionClass.MinQty);
        } else {
            updateCommand.Parameters.AddWithValue("@NewMinQty", DBNull.Value); }
        if (newdbo_DimPromotionClass.MaxQty.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@NewMaxQty", newdbo_DimPromotionClass.MaxQty);
        } else {
            updateCommand.Parameters.AddWithValue("@NewMaxQty", DBNull.Value); }
        updateCommand.Parameters.AddWithValue("@OldPromotionKey", olddbo_DimPromotionClass.PromotionKey);
        if (olddbo_DimPromotionClass.PromotionAlternateKey.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@OldPromotionAlternateKey", olddbo_DimPromotionClass.PromotionAlternateKey);
        } else {
            updateCommand.Parameters.AddWithValue("@OldPromotionAlternateKey", DBNull.Value); }
        if (olddbo_DimPromotionClass.EnglishPromotionName != null) {
            updateCommand.Parameters.AddWithValue("@OldEnglishPromotionName", olddbo_DimPromotionClass.EnglishPromotionName);
        } else {
            updateCommand.Parameters.AddWithValue("@OldEnglishPromotionName", DBNull.Value); }
        if (olddbo_DimPromotionClass.SpanishPromotionName != null) {
            updateCommand.Parameters.AddWithValue("@OldSpanishPromotionName", olddbo_DimPromotionClass.SpanishPromotionName);
        } else {
            updateCommand.Parameters.AddWithValue("@OldSpanishPromotionName", DBNull.Value); }
        if (olddbo_DimPromotionClass.FrenchPromotionName != null) {
            updateCommand.Parameters.AddWithValue("@OldFrenchPromotionName", olddbo_DimPromotionClass.FrenchPromotionName);
        } else {
            updateCommand.Parameters.AddWithValue("@OldFrenchPromotionName", DBNull.Value); }
        if (olddbo_DimPromotionClass.DiscountPct.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@OldDiscountPct", olddbo_DimPromotionClass.DiscountPct);
        } else {
            updateCommand.Parameters.AddWithValue("@OldDiscountPct", DBNull.Value); }
        if (olddbo_DimPromotionClass.EnglishPromotionType != null) {
            updateCommand.Parameters.AddWithValue("@OldEnglishPromotionType", olddbo_DimPromotionClass.EnglishPromotionType);
        } else {
            updateCommand.Parameters.AddWithValue("@OldEnglishPromotionType", DBNull.Value); }
        if (olddbo_DimPromotionClass.SpanishPromotionType != null) {
            updateCommand.Parameters.AddWithValue("@OldSpanishPromotionType", olddbo_DimPromotionClass.SpanishPromotionType);
        } else {
            updateCommand.Parameters.AddWithValue("@OldSpanishPromotionType", DBNull.Value); }
        if (olddbo_DimPromotionClass.FrenchPromotionType != null) {
            updateCommand.Parameters.AddWithValue("@OldFrenchPromotionType", olddbo_DimPromotionClass.FrenchPromotionType);
        } else {
            updateCommand.Parameters.AddWithValue("@OldFrenchPromotionType", DBNull.Value); }
        if (olddbo_DimPromotionClass.EnglishPromotionCategory != null) {
            updateCommand.Parameters.AddWithValue("@OldEnglishPromotionCategory", olddbo_DimPromotionClass.EnglishPromotionCategory);
        } else {
            updateCommand.Parameters.AddWithValue("@OldEnglishPromotionCategory", DBNull.Value); }
        if (olddbo_DimPromotionClass.SpanishPromotionCategory != null) {
            updateCommand.Parameters.AddWithValue("@OldSpanishPromotionCategory", olddbo_DimPromotionClass.SpanishPromotionCategory);
        } else {
            updateCommand.Parameters.AddWithValue("@OldSpanishPromotionCategory", DBNull.Value); }
        if (olddbo_DimPromotionClass.FrenchPromotionCategory != null) {
            updateCommand.Parameters.AddWithValue("@OldFrenchPromotionCategory", olddbo_DimPromotionClass.FrenchPromotionCategory);
        } else {
            updateCommand.Parameters.AddWithValue("@OldFrenchPromotionCategory", DBNull.Value); }
        updateCommand.Parameters.AddWithValue("@OldStartDate", olddbo_DimPromotionClass.StartDate);
        if (olddbo_DimPromotionClass.EndDate.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@OldEndDate", olddbo_DimPromotionClass.EndDate);
        } else {
            updateCommand.Parameters.AddWithValue("@OldEndDate", DBNull.Value); }
        if (olddbo_DimPromotionClass.MinQty.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@OldMinQty", olddbo_DimPromotionClass.MinQty);
        } else {
            updateCommand.Parameters.AddWithValue("@OldMinQty", DBNull.Value); }
        if (olddbo_DimPromotionClass.MaxQty.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@OldMaxQty", olddbo_DimPromotionClass.MaxQty);
        } else {
            updateCommand.Parameters.AddWithValue("@OldMaxQty", DBNull.Value); }
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

    public static bool Delete(dbo_DimPromotionClass clsdbo_DimPromotion)
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string deleteStatement
            = "DELETE FROM "  
            + "     [dbo].[DimPromotion] "
            + "WHERE " 
            + "     [PromotionKey] = @OldPromotionKey " 
            + " AND ((@OldPromotionAlternateKey IS NULL AND [PromotionAlternateKey] IS NULL) OR [PromotionAlternateKey] = @OldPromotionAlternateKey) " 
            + " AND ((@OldEnglishPromotionName IS NULL AND [EnglishPromotionName] IS NULL) OR [EnglishPromotionName] = @OldEnglishPromotionName) " 
            + " AND ((@OldSpanishPromotionName IS NULL AND [SpanishPromotionName] IS NULL) OR [SpanishPromotionName] = @OldSpanishPromotionName) " 
            + " AND ((@OldFrenchPromotionName IS NULL AND [FrenchPromotionName] IS NULL) OR [FrenchPromotionName] = @OldFrenchPromotionName) " 
            + " AND ((@OldDiscountPct IS NULL AND [DiscountPct] IS NULL) OR [DiscountPct] = @OldDiscountPct) " 
            + " AND ((@OldEnglishPromotionType IS NULL AND [EnglishPromotionType] IS NULL) OR [EnglishPromotionType] = @OldEnglishPromotionType) " 
            + " AND ((@OldSpanishPromotionType IS NULL AND [SpanishPromotionType] IS NULL) OR [SpanishPromotionType] = @OldSpanishPromotionType) " 
            + " AND ((@OldFrenchPromotionType IS NULL AND [FrenchPromotionType] IS NULL) OR [FrenchPromotionType] = @OldFrenchPromotionType) " 
            + " AND ((@OldEnglishPromotionCategory IS NULL AND [EnglishPromotionCategory] IS NULL) OR [EnglishPromotionCategory] = @OldEnglishPromotionCategory) " 
            + " AND ((@OldSpanishPromotionCategory IS NULL AND [SpanishPromotionCategory] IS NULL) OR [SpanishPromotionCategory] = @OldSpanishPromotionCategory) " 
            + " AND ((@OldFrenchPromotionCategory IS NULL AND [FrenchPromotionCategory] IS NULL) OR [FrenchPromotionCategory] = @OldFrenchPromotionCategory) " 
            + " AND [StartDate] = @OldStartDate " 
            + " AND ((@OldEndDate IS NULL AND [EndDate] IS NULL) OR [EndDate] = @OldEndDate) " 
            + " AND ((@OldMinQty IS NULL AND [MinQty] IS NULL) OR [MinQty] = @OldMinQty) " 
            + " AND ((@OldMaxQty IS NULL AND [MaxQty] IS NULL) OR [MaxQty] = @OldMaxQty) " 
            + "";
        SqlCommand deleteCommand = new SqlCommand(deleteStatement, connection);
        deleteCommand.CommandType = CommandType.Text;
        deleteCommand.Parameters.AddWithValue("@OldPromotionKey", clsdbo_DimPromotion.PromotionKey);
        if (clsdbo_DimPromotion.PromotionAlternateKey.HasValue == true) {
            deleteCommand.Parameters.AddWithValue("@OldPromotionAlternateKey", clsdbo_DimPromotion.PromotionAlternateKey);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldPromotionAlternateKey", DBNull.Value); }
        if (clsdbo_DimPromotion.EnglishPromotionName != null) {
            deleteCommand.Parameters.AddWithValue("@OldEnglishPromotionName", clsdbo_DimPromotion.EnglishPromotionName);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldEnglishPromotionName", DBNull.Value); }
        if (clsdbo_DimPromotion.SpanishPromotionName != null) {
            deleteCommand.Parameters.AddWithValue("@OldSpanishPromotionName", clsdbo_DimPromotion.SpanishPromotionName);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldSpanishPromotionName", DBNull.Value); }
        if (clsdbo_DimPromotion.FrenchPromotionName != null) {
            deleteCommand.Parameters.AddWithValue("@OldFrenchPromotionName", clsdbo_DimPromotion.FrenchPromotionName);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldFrenchPromotionName", DBNull.Value); }
        if (clsdbo_DimPromotion.DiscountPct.HasValue == true) {
            deleteCommand.Parameters.AddWithValue("@OldDiscountPct", clsdbo_DimPromotion.DiscountPct);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldDiscountPct", DBNull.Value); }
        if (clsdbo_DimPromotion.EnglishPromotionType != null) {
            deleteCommand.Parameters.AddWithValue("@OldEnglishPromotionType", clsdbo_DimPromotion.EnglishPromotionType);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldEnglishPromotionType", DBNull.Value); }
        if (clsdbo_DimPromotion.SpanishPromotionType != null) {
            deleteCommand.Parameters.AddWithValue("@OldSpanishPromotionType", clsdbo_DimPromotion.SpanishPromotionType);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldSpanishPromotionType", DBNull.Value); }
        if (clsdbo_DimPromotion.FrenchPromotionType != null) {
            deleteCommand.Parameters.AddWithValue("@OldFrenchPromotionType", clsdbo_DimPromotion.FrenchPromotionType);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldFrenchPromotionType", DBNull.Value); }
        if (clsdbo_DimPromotion.EnglishPromotionCategory != null) {
            deleteCommand.Parameters.AddWithValue("@OldEnglishPromotionCategory", clsdbo_DimPromotion.EnglishPromotionCategory);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldEnglishPromotionCategory", DBNull.Value); }
        if (clsdbo_DimPromotion.SpanishPromotionCategory != null) {
            deleteCommand.Parameters.AddWithValue("@OldSpanishPromotionCategory", clsdbo_DimPromotion.SpanishPromotionCategory);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldSpanishPromotionCategory", DBNull.Value); }
        if (clsdbo_DimPromotion.FrenchPromotionCategory != null) {
            deleteCommand.Parameters.AddWithValue("@OldFrenchPromotionCategory", clsdbo_DimPromotion.FrenchPromotionCategory);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldFrenchPromotionCategory", DBNull.Value); }
        deleteCommand.Parameters.AddWithValue("@OldStartDate", clsdbo_DimPromotion.StartDate);
        if (clsdbo_DimPromotion.EndDate.HasValue == true) {
            deleteCommand.Parameters.AddWithValue("@OldEndDate", clsdbo_DimPromotion.EndDate);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldEndDate", DBNull.Value); }
        if (clsdbo_DimPromotion.MinQty.HasValue == true) {
            deleteCommand.Parameters.AddWithValue("@OldMinQty", clsdbo_DimPromotion.MinQty);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldMinQty", DBNull.Value); }
        if (clsdbo_DimPromotion.MaxQty.HasValue == true) {
            deleteCommand.Parameters.AddWithValue("@OldMaxQty", clsdbo_DimPromotion.MaxQty);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldMaxQty", DBNull.Value); }
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

 
