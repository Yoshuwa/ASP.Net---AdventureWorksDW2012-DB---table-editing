using System;
using System.Data;
using System.Data.SqlClient;

public class dbo_FactInternetSalesDataClass
{

    public static DataTable SelectAll()
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement
            = "SELECT "  
            + "     [dbo].[FactInternetSales].[SalesOrderNumber] "
            + "    ,[dbo].[FactInternetSales].[SalesOrderLineNumber] "
            + "    ,[A238].[EnglishProductName] "
            + "    ,[A239].[FullDateAlternateKey] "
            + "    ,[A240].[FullDateAlternateKey] "
            + "    ,[A241].[FullDateAlternateKey] "
            + "    ,[A242].[FirstName] "
            + "    ,[A243].[EnglishPromotionName] "
            + "    ,[A244].[CurrencyName] "
            + "    ,[A245].[SalesTerritoryAlternateKey] "
            + "    ,[dbo].[FactInternetSales].[RevisionNumber] "
            + "    ,[dbo].[FactInternetSales].[OrderQuantity] "
            + "    ,[dbo].[FactInternetSales].[UnitPrice] "
            + "    ,[dbo].[FactInternetSales].[ExtendedAmount] "
            + "    ,[dbo].[FactInternetSales].[UnitPriceDiscountPct] "
            + "    ,[dbo].[FactInternetSales].[DiscountAmount] "
            + "    ,[dbo].[FactInternetSales].[ProductStandardCost] "
            + "    ,[dbo].[FactInternetSales].[TotalProductCost] "
            + "    ,[dbo].[FactInternetSales].[SalesAmount] "
            + "    ,[dbo].[FactInternetSales].[TaxAmt] "
            + "    ,[dbo].[FactInternetSales].[Freight] "
            + "    ,[dbo].[FactInternetSales].[CarrierTrackingNumber] "
            + "    ,[dbo].[FactInternetSales].[CustomerPONumber] "
            + "    ,[dbo].[FactInternetSales].[OrderDate] "
            + "    ,[dbo].[FactInternetSales].[DueDate] "
            + "    ,[dbo].[FactInternetSales].[ShipDate] "
            + "FROM " 
            + "     [dbo].[FactInternetSales] " 
            + "INNER JOIN [dbo].[DimProduct] as [A238] ON [dbo].[FactInternetSales].[ProductKey] = [A238].[ProductKey] "
            + "INNER JOIN [dbo].[DimDate] as [A239] ON [dbo].[FactInternetSales].[OrderDateKey] = [A239].[DateKey] "
            + "INNER JOIN [dbo].[DimDate] as [A240] ON [dbo].[FactInternetSales].[DueDateKey] = [A240].[DateKey] "
            + "INNER JOIN [dbo].[DimDate] as [A241] ON [dbo].[FactInternetSales].[ShipDateKey] = [A241].[DateKey] "
            + "INNER JOIN [dbo].[DimCustomer] as [A242] ON [dbo].[FactInternetSales].[CustomerKey] = [A242].[CustomerKey] "
            + "INNER JOIN [dbo].[DimPromotion] as [A243] ON [dbo].[FactInternetSales].[PromotionKey] = [A243].[PromotionKey] "
            + "INNER JOIN [dbo].[DimCurrency] as [A244] ON [dbo].[FactInternetSales].[CurrencyKey] = [A244].[CurrencyKey] "
            + "INNER JOIN [dbo].[DimSalesTerritory] as [A245] ON [dbo].[FactInternetSales].[SalesTerritoryKey] = [A245].[SalesTerritoryKey] "
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
            + "     [dbo].[FactInternetSales].[SalesOrderNumber] "
            + "    ,[dbo].[FactInternetSales].[SalesOrderLineNumber] "
            + "    ,[A238].[EnglishProductName]"
            + "    ,[A239].[FullDateAlternateKey]"
            + "    ,[A240].[FullDateAlternateKey]"
            + "    ,[A241].[FullDateAlternateKey]"
            + "    ,[A242].[FirstName]"
            + "    ,[A243].[EnglishPromotionName]"
            + "    ,[A244].[CurrencyName]"
            + "    ,[A245].[SalesTerritoryAlternateKey]"
            + "    ,[dbo].[FactInternetSales].[RevisionNumber] "
            + "    ,[dbo].[FactInternetSales].[OrderQuantity] "
            + "    ,[dbo].[FactInternetSales].[UnitPrice] "
            + "    ,[dbo].[FactInternetSales].[ExtendedAmount] "
            + "    ,[dbo].[FactInternetSales].[UnitPriceDiscountPct] "
            + "    ,[dbo].[FactInternetSales].[DiscountAmount] "
            + "    ,[dbo].[FactInternetSales].[ProductStandardCost] "
            + "    ,[dbo].[FactInternetSales].[TotalProductCost] "
            + "    ,[dbo].[FactInternetSales].[SalesAmount] "
            + "    ,[dbo].[FactInternetSales].[TaxAmt] "
            + "    ,[dbo].[FactInternetSales].[Freight] "
            + "    ,[dbo].[FactInternetSales].[CarrierTrackingNumber] "
            + "    ,[dbo].[FactInternetSales].[CustomerPONumber] "
            + "    ,[dbo].[FactInternetSales].[OrderDate] "
            + "    ,[dbo].[FactInternetSales].[DueDate] "
            + "    ,[dbo].[FactInternetSales].[ShipDate] "
            + "FROM " 
            + "     [dbo].[FactInternetSales] " 
            + "INNER JOIN [dbo].[DimProduct] as [A238] ON [dbo].[FactInternetSales].[ProductKey] = [A238].[ProductKey] "
            + "INNER JOIN [dbo].[DimDate] as [A239] ON [dbo].[FactInternetSales].[OrderDateKey] = [A239].[DateKey] "
            + "INNER JOIN [dbo].[DimDate] as [A240] ON [dbo].[FactInternetSales].[DueDateKey] = [A240].[DateKey] "
            + "INNER JOIN [dbo].[DimDate] as [A241] ON [dbo].[FactInternetSales].[ShipDateKey] = [A241].[DateKey] "
            + "INNER JOIN [dbo].[DimCustomer] as [A242] ON [dbo].[FactInternetSales].[CustomerKey] = [A242].[CustomerKey] "
            + "INNER JOIN [dbo].[DimPromotion] as [A243] ON [dbo].[FactInternetSales].[PromotionKey] = [A243].[PromotionKey] "
            + "INNER JOIN [dbo].[DimCurrency] as [A244] ON [dbo].[FactInternetSales].[CurrencyKey] = [A244].[CurrencyKey] "
            + "INNER JOIN [dbo].[DimSalesTerritory] as [A245] ON [dbo].[FactInternetSales].[SalesTerritoryKey] = [A245].[SalesTerritoryKey] "
                + "WHERE " 
                + "     (@SalesOrderNumber IS NULL OR @SalesOrderNumber = '' OR [FactInternetSales].[SalesOrderNumber] LIKE '%' + LTRIM(RTRIM(@SalesOrderNumber)) + '%') " 
                + "AND   (@SalesOrderLineNumber IS NULL OR @SalesOrderLineNumber = '' OR [FactInternetSales].[SalesOrderLineNumber] LIKE '%' + LTRIM(RTRIM(@SalesOrderLineNumber)) + '%') " 
                + "AND   (@EnglishProductName238 IS NULL OR @EnglishProductName238 = '' OR [A238].[EnglishProductName] LIKE '%' + LTRIM(RTRIM(@EnglishProductName238)) + '%') " 
                + "AND   (@FullDateAlternateKey239 IS NULL OR @FullDateAlternateKey239 = '' OR [A239].[FullDateAlternateKey] LIKE '%' + LTRIM(RTRIM(@FullDateAlternateKey239)) + '%') " 
                + "AND   (@FullDateAlternateKey240 IS NULL OR @FullDateAlternateKey240 = '' OR [A240].[FullDateAlternateKey] LIKE '%' + LTRIM(RTRIM(@FullDateAlternateKey240)) + '%') " 
                + "AND   (@FullDateAlternateKey241 IS NULL OR @FullDateAlternateKey241 = '' OR [A241].[FullDateAlternateKey] LIKE '%' + LTRIM(RTRIM(@FullDateAlternateKey241)) + '%') " 
                + "AND   (@FirstName242 IS NULL OR @FirstName242 = '' OR [A242].[FirstName] LIKE '%' + LTRIM(RTRIM(@FirstName242)) + '%') " 
                + "AND   (@EnglishPromotionName243 IS NULL OR @EnglishPromotionName243 = '' OR [A243].[EnglishPromotionName] LIKE '%' + LTRIM(RTRIM(@EnglishPromotionName243)) + '%') " 
                + "AND   (@CurrencyName244 IS NULL OR @CurrencyName244 = '' OR [A244].[CurrencyName] LIKE '%' + LTRIM(RTRIM(@CurrencyName244)) + '%') " 
                + "AND   (@SalesTerritoryAlternateKey245 IS NULL OR @SalesTerritoryAlternateKey245 = '' OR [A245].[SalesTerritoryAlternateKey] LIKE '%' + LTRIM(RTRIM(@SalesTerritoryAlternateKey245)) + '%') " 
                + "AND   (@RevisionNumber IS NULL OR @RevisionNumber = '' OR [FactInternetSales].[RevisionNumber] LIKE '%' + LTRIM(RTRIM(@RevisionNumber)) + '%') " 
                + "AND   (@OrderQuantity IS NULL OR @OrderQuantity = '' OR [FactInternetSales].[OrderQuantity] LIKE '%' + LTRIM(RTRIM(@OrderQuantity)) + '%') " 
                + "AND   (@UnitPrice IS NULL OR @UnitPrice = '' OR [FactInternetSales].[UnitPrice] LIKE '%' + LTRIM(RTRIM(@UnitPrice)) + '%') " 
                + "AND   (@ExtendedAmount IS NULL OR @ExtendedAmount = '' OR [FactInternetSales].[ExtendedAmount] LIKE '%' + LTRIM(RTRIM(@ExtendedAmount)) + '%') " 
                + "AND   (@UnitPriceDiscountPct IS NULL OR @UnitPriceDiscountPct = '' OR [FactInternetSales].[UnitPriceDiscountPct] LIKE '%' + LTRIM(RTRIM(@UnitPriceDiscountPct)) + '%') " 
                + "AND   (@DiscountAmount IS NULL OR @DiscountAmount = '' OR [FactInternetSales].[DiscountAmount] LIKE '%' + LTRIM(RTRIM(@DiscountAmount)) + '%') " 
                + "AND   (@ProductStandardCost IS NULL OR @ProductStandardCost = '' OR [FactInternetSales].[ProductStandardCost] LIKE '%' + LTRIM(RTRIM(@ProductStandardCost)) + '%') " 
                + "AND   (@TotalProductCost IS NULL OR @TotalProductCost = '' OR [FactInternetSales].[TotalProductCost] LIKE '%' + LTRIM(RTRIM(@TotalProductCost)) + '%') " 
                + "AND   (@SalesAmount IS NULL OR @SalesAmount = '' OR [FactInternetSales].[SalesAmount] LIKE '%' + LTRIM(RTRIM(@SalesAmount)) + '%') " 
                + "AND   (@TaxAmt IS NULL OR @TaxAmt = '' OR [FactInternetSales].[TaxAmt] LIKE '%' + LTRIM(RTRIM(@TaxAmt)) + '%') " 
                + "AND   (@Freight IS NULL OR @Freight = '' OR [FactInternetSales].[Freight] LIKE '%' + LTRIM(RTRIM(@Freight)) + '%') " 
                + "AND   (@CarrierTrackingNumber IS NULL OR @CarrierTrackingNumber = '' OR [FactInternetSales].[CarrierTrackingNumber] LIKE '%' + LTRIM(RTRIM(@CarrierTrackingNumber)) + '%') " 
                + "AND   (@CustomerPONumber IS NULL OR @CustomerPONumber = '' OR [FactInternetSales].[CustomerPONumber] LIKE '%' + LTRIM(RTRIM(@CustomerPONumber)) + '%') " 
                + "AND   (@OrderDate IS NULL OR @OrderDate = '' OR [FactInternetSales].[OrderDate] LIKE '%' + LTRIM(RTRIM(@OrderDate)) + '%') " 
                + "AND   (@DueDate IS NULL OR @DueDate = '' OR [FactInternetSales].[DueDate] LIKE '%' + LTRIM(RTRIM(@DueDate)) + '%') " 
                + "AND   (@ShipDate IS NULL OR @ShipDate = '' OR [FactInternetSales].[ShipDate] LIKE '%' + LTRIM(RTRIM(@ShipDate)) + '%') " 
                + "";
        } else if (sCondition == "Equals") {
            selectStatement
                = "SELECT "
            + "     [dbo].[FactInternetSales].[SalesOrderNumber] "
            + "    ,[dbo].[FactInternetSales].[SalesOrderLineNumber] "
            + "    ,[A238].[EnglishProductName]"
            + "    ,[A239].[FullDateAlternateKey]"
            + "    ,[A240].[FullDateAlternateKey]"
            + "    ,[A241].[FullDateAlternateKey]"
            + "    ,[A242].[FirstName]"
            + "    ,[A243].[EnglishPromotionName]"
            + "    ,[A244].[CurrencyName]"
            + "    ,[A245].[SalesTerritoryAlternateKey]"
            + "    ,[dbo].[FactInternetSales].[RevisionNumber] "
            + "    ,[dbo].[FactInternetSales].[OrderQuantity] "
            + "    ,[dbo].[FactInternetSales].[UnitPrice] "
            + "    ,[dbo].[FactInternetSales].[ExtendedAmount] "
            + "    ,[dbo].[FactInternetSales].[UnitPriceDiscountPct] "
            + "    ,[dbo].[FactInternetSales].[DiscountAmount] "
            + "    ,[dbo].[FactInternetSales].[ProductStandardCost] "
            + "    ,[dbo].[FactInternetSales].[TotalProductCost] "
            + "    ,[dbo].[FactInternetSales].[SalesAmount] "
            + "    ,[dbo].[FactInternetSales].[TaxAmt] "
            + "    ,[dbo].[FactInternetSales].[Freight] "
            + "    ,[dbo].[FactInternetSales].[CarrierTrackingNumber] "
            + "    ,[dbo].[FactInternetSales].[CustomerPONumber] "
            + "    ,[dbo].[FactInternetSales].[OrderDate] "
            + "    ,[dbo].[FactInternetSales].[DueDate] "
            + "    ,[dbo].[FactInternetSales].[ShipDate] "
            + "FROM " 
            + "     [dbo].[FactInternetSales] " 
            + "INNER JOIN [dbo].[DimProduct] as [A238] ON [dbo].[FactInternetSales].[ProductKey] = [A238].[ProductKey] "
            + "INNER JOIN [dbo].[DimDate] as [A239] ON [dbo].[FactInternetSales].[OrderDateKey] = [A239].[DateKey] "
            + "INNER JOIN [dbo].[DimDate] as [A240] ON [dbo].[FactInternetSales].[DueDateKey] = [A240].[DateKey] "
            + "INNER JOIN [dbo].[DimDate] as [A241] ON [dbo].[FactInternetSales].[ShipDateKey] = [A241].[DateKey] "
            + "INNER JOIN [dbo].[DimCustomer] as [A242] ON [dbo].[FactInternetSales].[CustomerKey] = [A242].[CustomerKey] "
            + "INNER JOIN [dbo].[DimPromotion] as [A243] ON [dbo].[FactInternetSales].[PromotionKey] = [A243].[PromotionKey] "
            + "INNER JOIN [dbo].[DimCurrency] as [A244] ON [dbo].[FactInternetSales].[CurrencyKey] = [A244].[CurrencyKey] "
            + "INNER JOIN [dbo].[DimSalesTerritory] as [A245] ON [dbo].[FactInternetSales].[SalesTerritoryKey] = [A245].[SalesTerritoryKey] "
                + "WHERE " 
                + "     (@SalesOrderNumber IS NULL OR @SalesOrderNumber = '' OR [FactInternetSales].[SalesOrderNumber] = LTRIM(RTRIM(@SalesOrderNumber))) " 
                + "AND   (@SalesOrderLineNumber IS NULL OR @SalesOrderLineNumber = '' OR [FactInternetSales].[SalesOrderLineNumber] = LTRIM(RTRIM(@SalesOrderLineNumber))) " 
                + "AND   (@EnglishProductName238 IS NULL OR @EnglishProductName238 = '' OR [A238].[EnglishProductName] = LTRIM(RTRIM(@EnglishProductName238))) " 
                + "AND   (@FullDateAlternateKey239 IS NULL OR @FullDateAlternateKey239 = '' OR [A239].[FullDateAlternateKey] = LTRIM(RTRIM(@FullDateAlternateKey239))) " 
                + "AND   (@FullDateAlternateKey240 IS NULL OR @FullDateAlternateKey240 = '' OR [A240].[FullDateAlternateKey] = LTRIM(RTRIM(@FullDateAlternateKey240))) " 
                + "AND   (@FullDateAlternateKey241 IS NULL OR @FullDateAlternateKey241 = '' OR [A241].[FullDateAlternateKey] = LTRIM(RTRIM(@FullDateAlternateKey241))) " 
                + "AND   (@FirstName242 IS NULL OR @FirstName242 = '' OR [A242].[FirstName] = LTRIM(RTRIM(@FirstName242))) " 
                + "AND   (@EnglishPromotionName243 IS NULL OR @EnglishPromotionName243 = '' OR [A243].[EnglishPromotionName] = LTRIM(RTRIM(@EnglishPromotionName243))) " 
                + "AND   (@CurrencyName244 IS NULL OR @CurrencyName244 = '' OR [A244].[CurrencyName] = LTRIM(RTRIM(@CurrencyName244))) " 
                + "AND   (@SalesTerritoryAlternateKey245 IS NULL OR @SalesTerritoryAlternateKey245 = '' OR [A245].[SalesTerritoryAlternateKey] = LTRIM(RTRIM(@SalesTerritoryAlternateKey245))) " 
                + "AND   (@RevisionNumber IS NULL OR @RevisionNumber = '' OR [FactInternetSales].[RevisionNumber] = LTRIM(RTRIM(@RevisionNumber))) " 
                + "AND   (@OrderQuantity IS NULL OR @OrderQuantity = '' OR [FactInternetSales].[OrderQuantity] = LTRIM(RTRIM(@OrderQuantity))) " 
                + "AND   (@UnitPrice IS NULL OR @UnitPrice = '' OR [FactInternetSales].[UnitPrice] = LTRIM(RTRIM(@UnitPrice))) " 
                + "AND   (@ExtendedAmount IS NULL OR @ExtendedAmount = '' OR [FactInternetSales].[ExtendedAmount] = LTRIM(RTRIM(@ExtendedAmount))) " 
                + "AND   (@UnitPriceDiscountPct IS NULL OR @UnitPriceDiscountPct = '' OR [FactInternetSales].[UnitPriceDiscountPct] = LTRIM(RTRIM(@UnitPriceDiscountPct))) " 
                + "AND   (@DiscountAmount IS NULL OR @DiscountAmount = '' OR [FactInternetSales].[DiscountAmount] = LTRIM(RTRIM(@DiscountAmount))) " 
                + "AND   (@ProductStandardCost IS NULL OR @ProductStandardCost = '' OR [FactInternetSales].[ProductStandardCost] = LTRIM(RTRIM(@ProductStandardCost))) " 
                + "AND   (@TotalProductCost IS NULL OR @TotalProductCost = '' OR [FactInternetSales].[TotalProductCost] = LTRIM(RTRIM(@TotalProductCost))) " 
                + "AND   (@SalesAmount IS NULL OR @SalesAmount = '' OR [FactInternetSales].[SalesAmount] = LTRIM(RTRIM(@SalesAmount))) " 
                + "AND   (@TaxAmt IS NULL OR @TaxAmt = '' OR [FactInternetSales].[TaxAmt] = LTRIM(RTRIM(@TaxAmt))) " 
                + "AND   (@Freight IS NULL OR @Freight = '' OR [FactInternetSales].[Freight] = LTRIM(RTRIM(@Freight))) " 
                + "AND   (@CarrierTrackingNumber IS NULL OR @CarrierTrackingNumber = '' OR [FactInternetSales].[CarrierTrackingNumber] = LTRIM(RTRIM(@CarrierTrackingNumber))) " 
                + "AND   (@CustomerPONumber IS NULL OR @CustomerPONumber = '' OR [FactInternetSales].[CustomerPONumber] = LTRIM(RTRIM(@CustomerPONumber))) " 
                + "AND   (@OrderDate IS NULL OR @OrderDate = '' OR [FactInternetSales].[OrderDate] = LTRIM(RTRIM(@OrderDate))) " 
                + "AND   (@DueDate IS NULL OR @DueDate = '' OR [FactInternetSales].[DueDate] = LTRIM(RTRIM(@DueDate))) " 
                + "AND   (@ShipDate IS NULL OR @ShipDate = '' OR [FactInternetSales].[ShipDate] = LTRIM(RTRIM(@ShipDate))) " 
                + "";
        } else if  (sCondition == "Starts with...") {
            selectStatement
                = "SELECT "
            + "     [dbo].[FactInternetSales].[SalesOrderNumber] "
            + "    ,[dbo].[FactInternetSales].[SalesOrderLineNumber] "
            + "    ,[A238].[EnglishProductName]"
            + "    ,[A239].[FullDateAlternateKey]"
            + "    ,[A240].[FullDateAlternateKey]"
            + "    ,[A241].[FullDateAlternateKey]"
            + "    ,[A242].[FirstName]"
            + "    ,[A243].[EnglishPromotionName]"
            + "    ,[A244].[CurrencyName]"
            + "    ,[A245].[SalesTerritoryAlternateKey]"
            + "    ,[dbo].[FactInternetSales].[RevisionNumber] "
            + "    ,[dbo].[FactInternetSales].[OrderQuantity] "
            + "    ,[dbo].[FactInternetSales].[UnitPrice] "
            + "    ,[dbo].[FactInternetSales].[ExtendedAmount] "
            + "    ,[dbo].[FactInternetSales].[UnitPriceDiscountPct] "
            + "    ,[dbo].[FactInternetSales].[DiscountAmount] "
            + "    ,[dbo].[FactInternetSales].[ProductStandardCost] "
            + "    ,[dbo].[FactInternetSales].[TotalProductCost] "
            + "    ,[dbo].[FactInternetSales].[SalesAmount] "
            + "    ,[dbo].[FactInternetSales].[TaxAmt] "
            + "    ,[dbo].[FactInternetSales].[Freight] "
            + "    ,[dbo].[FactInternetSales].[CarrierTrackingNumber] "
            + "    ,[dbo].[FactInternetSales].[CustomerPONumber] "
            + "    ,[dbo].[FactInternetSales].[OrderDate] "
            + "    ,[dbo].[FactInternetSales].[DueDate] "
            + "    ,[dbo].[FactInternetSales].[ShipDate] "
            + "FROM " 
            + "     [dbo].[FactInternetSales] " 
            + "INNER JOIN [dbo].[DimProduct] as [A238] ON [dbo].[FactInternetSales].[ProductKey] = [A238].[ProductKey] "
            + "INNER JOIN [dbo].[DimDate] as [A239] ON [dbo].[FactInternetSales].[OrderDateKey] = [A239].[DateKey] "
            + "INNER JOIN [dbo].[DimDate] as [A240] ON [dbo].[FactInternetSales].[DueDateKey] = [A240].[DateKey] "
            + "INNER JOIN [dbo].[DimDate] as [A241] ON [dbo].[FactInternetSales].[ShipDateKey] = [A241].[DateKey] "
            + "INNER JOIN [dbo].[DimCustomer] as [A242] ON [dbo].[FactInternetSales].[CustomerKey] = [A242].[CustomerKey] "
            + "INNER JOIN [dbo].[DimPromotion] as [A243] ON [dbo].[FactInternetSales].[PromotionKey] = [A243].[PromotionKey] "
            + "INNER JOIN [dbo].[DimCurrency] as [A244] ON [dbo].[FactInternetSales].[CurrencyKey] = [A244].[CurrencyKey] "
            + "INNER JOIN [dbo].[DimSalesTerritory] as [A245] ON [dbo].[FactInternetSales].[SalesTerritoryKey] = [A245].[SalesTerritoryKey] "
                + "WHERE " 
                + "     (@SalesOrderNumber IS NULL OR @SalesOrderNumber = '' OR [FactInternetSales].[SalesOrderNumber] LIKE LTRIM(RTRIM(@SalesOrderNumber)) + '%') " 
                + "AND   (@SalesOrderLineNumber IS NULL OR @SalesOrderLineNumber = '' OR [FactInternetSales].[SalesOrderLineNumber] LIKE LTRIM(RTRIM(@SalesOrderLineNumber)) + '%') " 
                + "AND   (@EnglishProductName238 IS NULL OR @EnglishProductName238 = '' OR [A238].[EnglishProductName] LIKE LTRIM(RTRIM(@EnglishProductName238)) + '%') " 
                + "AND   (@FullDateAlternateKey239 IS NULL OR @FullDateAlternateKey239 = '' OR [A239].[FullDateAlternateKey] LIKE LTRIM(RTRIM(@FullDateAlternateKey239)) + '%') " 
                + "AND   (@FullDateAlternateKey240 IS NULL OR @FullDateAlternateKey240 = '' OR [A240].[FullDateAlternateKey] LIKE LTRIM(RTRIM(@FullDateAlternateKey240)) + '%') " 
                + "AND   (@FullDateAlternateKey241 IS NULL OR @FullDateAlternateKey241 = '' OR [A241].[FullDateAlternateKey] LIKE LTRIM(RTRIM(@FullDateAlternateKey241)) + '%') " 
                + "AND   (@FirstName242 IS NULL OR @FirstName242 = '' OR [A242].[FirstName] LIKE LTRIM(RTRIM(@FirstName242)) + '%') " 
                + "AND   (@EnglishPromotionName243 IS NULL OR @EnglishPromotionName243 = '' OR [A243].[EnglishPromotionName] LIKE LTRIM(RTRIM(@EnglishPromotionName243)) + '%') " 
                + "AND   (@CurrencyName244 IS NULL OR @CurrencyName244 = '' OR [A244].[CurrencyName] LIKE LTRIM(RTRIM(@CurrencyName244)) + '%') " 
                + "AND   (@SalesTerritoryAlternateKey245 IS NULL OR @SalesTerritoryAlternateKey245 = '' OR [A245].[SalesTerritoryAlternateKey] LIKE LTRIM(RTRIM(@SalesTerritoryAlternateKey245)) + '%') " 
                + "AND   (@RevisionNumber IS NULL OR @RevisionNumber = '' OR [FactInternetSales].[RevisionNumber] LIKE LTRIM(RTRIM(@RevisionNumber)) + '%') " 
                + "AND   (@OrderQuantity IS NULL OR @OrderQuantity = '' OR [FactInternetSales].[OrderQuantity] LIKE LTRIM(RTRIM(@OrderQuantity)) + '%') " 
                + "AND   (@UnitPrice IS NULL OR @UnitPrice = '' OR [FactInternetSales].[UnitPrice] LIKE LTRIM(RTRIM(@UnitPrice)) + '%') " 
                + "AND   (@ExtendedAmount IS NULL OR @ExtendedAmount = '' OR [FactInternetSales].[ExtendedAmount] LIKE LTRIM(RTRIM(@ExtendedAmount)) + '%') " 
                + "AND   (@UnitPriceDiscountPct IS NULL OR @UnitPriceDiscountPct = '' OR [FactInternetSales].[UnitPriceDiscountPct] LIKE LTRIM(RTRIM(@UnitPriceDiscountPct)) + '%') " 
                + "AND   (@DiscountAmount IS NULL OR @DiscountAmount = '' OR [FactInternetSales].[DiscountAmount] LIKE LTRIM(RTRIM(@DiscountAmount)) + '%') " 
                + "AND   (@ProductStandardCost IS NULL OR @ProductStandardCost = '' OR [FactInternetSales].[ProductStandardCost] LIKE LTRIM(RTRIM(@ProductStandardCost)) + '%') " 
                + "AND   (@TotalProductCost IS NULL OR @TotalProductCost = '' OR [FactInternetSales].[TotalProductCost] LIKE LTRIM(RTRIM(@TotalProductCost)) + '%') " 
                + "AND   (@SalesAmount IS NULL OR @SalesAmount = '' OR [FactInternetSales].[SalesAmount] LIKE LTRIM(RTRIM(@SalesAmount)) + '%') " 
                + "AND   (@TaxAmt IS NULL OR @TaxAmt = '' OR [FactInternetSales].[TaxAmt] LIKE LTRIM(RTRIM(@TaxAmt)) + '%') " 
                + "AND   (@Freight IS NULL OR @Freight = '' OR [FactInternetSales].[Freight] LIKE LTRIM(RTRIM(@Freight)) + '%') " 
                + "AND   (@CarrierTrackingNumber IS NULL OR @CarrierTrackingNumber = '' OR [FactInternetSales].[CarrierTrackingNumber] LIKE LTRIM(RTRIM(@CarrierTrackingNumber)) + '%') " 
                + "AND   (@CustomerPONumber IS NULL OR @CustomerPONumber = '' OR [FactInternetSales].[CustomerPONumber] LIKE LTRIM(RTRIM(@CustomerPONumber)) + '%') " 
                + "AND   (@OrderDate IS NULL OR @OrderDate = '' OR [FactInternetSales].[OrderDate] LIKE LTRIM(RTRIM(@OrderDate)) + '%') " 
                + "AND   (@DueDate IS NULL OR @DueDate = '' OR [FactInternetSales].[DueDate] LIKE LTRIM(RTRIM(@DueDate)) + '%') " 
                + "AND   (@ShipDate IS NULL OR @ShipDate = '' OR [FactInternetSales].[ShipDate] LIKE LTRIM(RTRIM(@ShipDate)) + '%') " 
                + "";
        } else if  (sCondition == "More than...") {
            selectStatement
                = "SELECT "
            + "     [dbo].[FactInternetSales].[SalesOrderNumber] "
            + "    ,[dbo].[FactInternetSales].[SalesOrderLineNumber] "
            + "    ,[A238].[EnglishProductName]"
            + "    ,[A239].[FullDateAlternateKey]"
            + "    ,[A240].[FullDateAlternateKey]"
            + "    ,[A241].[FullDateAlternateKey]"
            + "    ,[A242].[FirstName]"
            + "    ,[A243].[EnglishPromotionName]"
            + "    ,[A244].[CurrencyName]"
            + "    ,[A245].[SalesTerritoryAlternateKey]"
            + "    ,[dbo].[FactInternetSales].[RevisionNumber] "
            + "    ,[dbo].[FactInternetSales].[OrderQuantity] "
            + "    ,[dbo].[FactInternetSales].[UnitPrice] "
            + "    ,[dbo].[FactInternetSales].[ExtendedAmount] "
            + "    ,[dbo].[FactInternetSales].[UnitPriceDiscountPct] "
            + "    ,[dbo].[FactInternetSales].[DiscountAmount] "
            + "    ,[dbo].[FactInternetSales].[ProductStandardCost] "
            + "    ,[dbo].[FactInternetSales].[TotalProductCost] "
            + "    ,[dbo].[FactInternetSales].[SalesAmount] "
            + "    ,[dbo].[FactInternetSales].[TaxAmt] "
            + "    ,[dbo].[FactInternetSales].[Freight] "
            + "    ,[dbo].[FactInternetSales].[CarrierTrackingNumber] "
            + "    ,[dbo].[FactInternetSales].[CustomerPONumber] "
            + "    ,[dbo].[FactInternetSales].[OrderDate] "
            + "    ,[dbo].[FactInternetSales].[DueDate] "
            + "    ,[dbo].[FactInternetSales].[ShipDate] "
            + "FROM " 
            + "     [dbo].[FactInternetSales] " 
            + "INNER JOIN [dbo].[DimProduct] as [A238] ON [dbo].[FactInternetSales].[ProductKey] = [A238].[ProductKey] "
            + "INNER JOIN [dbo].[DimDate] as [A239] ON [dbo].[FactInternetSales].[OrderDateKey] = [A239].[DateKey] "
            + "INNER JOIN [dbo].[DimDate] as [A240] ON [dbo].[FactInternetSales].[DueDateKey] = [A240].[DateKey] "
            + "INNER JOIN [dbo].[DimDate] as [A241] ON [dbo].[FactInternetSales].[ShipDateKey] = [A241].[DateKey] "
            + "INNER JOIN [dbo].[DimCustomer] as [A242] ON [dbo].[FactInternetSales].[CustomerKey] = [A242].[CustomerKey] "
            + "INNER JOIN [dbo].[DimPromotion] as [A243] ON [dbo].[FactInternetSales].[PromotionKey] = [A243].[PromotionKey] "
            + "INNER JOIN [dbo].[DimCurrency] as [A244] ON [dbo].[FactInternetSales].[CurrencyKey] = [A244].[CurrencyKey] "
            + "INNER JOIN [dbo].[DimSalesTerritory] as [A245] ON [dbo].[FactInternetSales].[SalesTerritoryKey] = [A245].[SalesTerritoryKey] "
                + "WHERE " 
                + "     (@SalesOrderNumber IS NULL OR @SalesOrderNumber = '' OR [FactInternetSales].[SalesOrderNumber] > LTRIM(RTRIM(@SalesOrderNumber))) " 
                + "AND   (@SalesOrderLineNumber IS NULL OR @SalesOrderLineNumber = '' OR [FactInternetSales].[SalesOrderLineNumber] > LTRIM(RTRIM(@SalesOrderLineNumber))) " 
                + "AND   (@EnglishProductName238 IS NULL OR @EnglishProductName238 = '' OR [A238].[EnglishProductName] > LTRIM(RTRIM(@EnglishProductName238))) " 
                + "AND   (@FullDateAlternateKey239 IS NULL OR @FullDateAlternateKey239 = '' OR [A239].[FullDateAlternateKey] > LTRIM(RTRIM(@FullDateAlternateKey239))) " 
                + "AND   (@FullDateAlternateKey240 IS NULL OR @FullDateAlternateKey240 = '' OR [A240].[FullDateAlternateKey] > LTRIM(RTRIM(@FullDateAlternateKey240))) " 
                + "AND   (@FullDateAlternateKey241 IS NULL OR @FullDateAlternateKey241 = '' OR [A241].[FullDateAlternateKey] > LTRIM(RTRIM(@FullDateAlternateKey241))) " 
                + "AND   (@FirstName242 IS NULL OR @FirstName242 = '' OR [A242].[FirstName] > LTRIM(RTRIM(@FirstName242))) " 
                + "AND   (@EnglishPromotionName243 IS NULL OR @EnglishPromotionName243 = '' OR [A243].[EnglishPromotionName] > LTRIM(RTRIM(@EnglishPromotionName243))) " 
                + "AND   (@CurrencyName244 IS NULL OR @CurrencyName244 = '' OR [A244].[CurrencyName] > LTRIM(RTRIM(@CurrencyName244))) " 
                + "AND   (@SalesTerritoryAlternateKey245 IS NULL OR @SalesTerritoryAlternateKey245 = '' OR [A245].[SalesTerritoryAlternateKey] > LTRIM(RTRIM(@SalesTerritoryAlternateKey245))) " 
                + "AND   (@RevisionNumber IS NULL OR @RevisionNumber = '' OR [FactInternetSales].[RevisionNumber] > LTRIM(RTRIM(@RevisionNumber))) " 
                + "AND   (@OrderQuantity IS NULL OR @OrderQuantity = '' OR [FactInternetSales].[OrderQuantity] > LTRIM(RTRIM(@OrderQuantity))) " 
                + "AND   (@UnitPrice IS NULL OR @UnitPrice = '' OR [FactInternetSales].[UnitPrice] > LTRIM(RTRIM(@UnitPrice))) " 
                + "AND   (@ExtendedAmount IS NULL OR @ExtendedAmount = '' OR [FactInternetSales].[ExtendedAmount] > LTRIM(RTRIM(@ExtendedAmount))) " 
                + "AND   (@UnitPriceDiscountPct IS NULL OR @UnitPriceDiscountPct = '' OR [FactInternetSales].[UnitPriceDiscountPct] > LTRIM(RTRIM(@UnitPriceDiscountPct))) " 
                + "AND   (@DiscountAmount IS NULL OR @DiscountAmount = '' OR [FactInternetSales].[DiscountAmount] > LTRIM(RTRIM(@DiscountAmount))) " 
                + "AND   (@ProductStandardCost IS NULL OR @ProductStandardCost = '' OR [FactInternetSales].[ProductStandardCost] > LTRIM(RTRIM(@ProductStandardCost))) " 
                + "AND   (@TotalProductCost IS NULL OR @TotalProductCost = '' OR [FactInternetSales].[TotalProductCost] > LTRIM(RTRIM(@TotalProductCost))) " 
                + "AND   (@SalesAmount IS NULL OR @SalesAmount = '' OR [FactInternetSales].[SalesAmount] > LTRIM(RTRIM(@SalesAmount))) " 
                + "AND   (@TaxAmt IS NULL OR @TaxAmt = '' OR [FactInternetSales].[TaxAmt] > LTRIM(RTRIM(@TaxAmt))) " 
                + "AND   (@Freight IS NULL OR @Freight = '' OR [FactInternetSales].[Freight] > LTRIM(RTRIM(@Freight))) " 
                + "AND   (@CarrierTrackingNumber IS NULL OR @CarrierTrackingNumber = '' OR [FactInternetSales].[CarrierTrackingNumber] > LTRIM(RTRIM(@CarrierTrackingNumber))) " 
                + "AND   (@CustomerPONumber IS NULL OR @CustomerPONumber = '' OR [FactInternetSales].[CustomerPONumber] > LTRIM(RTRIM(@CustomerPONumber))) " 
                + "AND   (@OrderDate IS NULL OR @OrderDate = '' OR [FactInternetSales].[OrderDate] > LTRIM(RTRIM(@OrderDate))) " 
                + "AND   (@DueDate IS NULL OR @DueDate = '' OR [FactInternetSales].[DueDate] > LTRIM(RTRIM(@DueDate))) " 
                + "AND   (@ShipDate IS NULL OR @ShipDate = '' OR [FactInternetSales].[ShipDate] > LTRIM(RTRIM(@ShipDate))) " 
                + "";
        } else if  (sCondition == "Less than...") {
            selectStatement
                = "SELECT " 
            + "     [dbo].[FactInternetSales].[SalesOrderNumber] "
            + "    ,[dbo].[FactInternetSales].[SalesOrderLineNumber] "
            + "    ,[A238].[EnglishProductName]"
            + "    ,[A239].[FullDateAlternateKey]"
            + "    ,[A240].[FullDateAlternateKey]"
            + "    ,[A241].[FullDateAlternateKey]"
            + "    ,[A242].[FirstName]"
            + "    ,[A243].[EnglishPromotionName]"
            + "    ,[A244].[CurrencyName]"
            + "    ,[A245].[SalesTerritoryAlternateKey]"
            + "    ,[dbo].[FactInternetSales].[RevisionNumber] "
            + "    ,[dbo].[FactInternetSales].[OrderQuantity] "
            + "    ,[dbo].[FactInternetSales].[UnitPrice] "
            + "    ,[dbo].[FactInternetSales].[ExtendedAmount] "
            + "    ,[dbo].[FactInternetSales].[UnitPriceDiscountPct] "
            + "    ,[dbo].[FactInternetSales].[DiscountAmount] "
            + "    ,[dbo].[FactInternetSales].[ProductStandardCost] "
            + "    ,[dbo].[FactInternetSales].[TotalProductCost] "
            + "    ,[dbo].[FactInternetSales].[SalesAmount] "
            + "    ,[dbo].[FactInternetSales].[TaxAmt] "
            + "    ,[dbo].[FactInternetSales].[Freight] "
            + "    ,[dbo].[FactInternetSales].[CarrierTrackingNumber] "
            + "    ,[dbo].[FactInternetSales].[CustomerPONumber] "
            + "    ,[dbo].[FactInternetSales].[OrderDate] "
            + "    ,[dbo].[FactInternetSales].[DueDate] "
            + "    ,[dbo].[FactInternetSales].[ShipDate] "
            + "FROM " 
            + "     [dbo].[FactInternetSales] " 
            + "INNER JOIN [dbo].[DimProduct] as [A238] ON [dbo].[FactInternetSales].[ProductKey] = [A238].[ProductKey] "
            + "INNER JOIN [dbo].[DimDate] as [A239] ON [dbo].[FactInternetSales].[OrderDateKey] = [A239].[DateKey] "
            + "INNER JOIN [dbo].[DimDate] as [A240] ON [dbo].[FactInternetSales].[DueDateKey] = [A240].[DateKey] "
            + "INNER JOIN [dbo].[DimDate] as [A241] ON [dbo].[FactInternetSales].[ShipDateKey] = [A241].[DateKey] "
            + "INNER JOIN [dbo].[DimCustomer] as [A242] ON [dbo].[FactInternetSales].[CustomerKey] = [A242].[CustomerKey] "
            + "INNER JOIN [dbo].[DimPromotion] as [A243] ON [dbo].[FactInternetSales].[PromotionKey] = [A243].[PromotionKey] "
            + "INNER JOIN [dbo].[DimCurrency] as [A244] ON [dbo].[FactInternetSales].[CurrencyKey] = [A244].[CurrencyKey] "
            + "INNER JOIN [dbo].[DimSalesTerritory] as [A245] ON [dbo].[FactInternetSales].[SalesTerritoryKey] = [A245].[SalesTerritoryKey] "
                + "WHERE " 
                + "     (@SalesOrderNumber IS NULL OR @SalesOrderNumber = '' OR [FactInternetSales].[SalesOrderNumber] < LTRIM(RTRIM(@SalesOrderNumber))) " 
                + "AND   (@SalesOrderLineNumber IS NULL OR @SalesOrderLineNumber = '' OR [FactInternetSales].[SalesOrderLineNumber] < LTRIM(RTRIM(@SalesOrderLineNumber))) " 
                + "AND   (@EnglishProductName238 IS NULL OR @EnglishProductName238 = '' OR [A238].[EnglishProductName] < LTRIM(RTRIM(@EnglishProductName238))) " 
                + "AND   (@FullDateAlternateKey239 IS NULL OR @FullDateAlternateKey239 = '' OR [A239].[FullDateAlternateKey] < LTRIM(RTRIM(@FullDateAlternateKey239))) " 
                + "AND   (@FullDateAlternateKey240 IS NULL OR @FullDateAlternateKey240 = '' OR [A240].[FullDateAlternateKey] < LTRIM(RTRIM(@FullDateAlternateKey240))) " 
                + "AND   (@FullDateAlternateKey241 IS NULL OR @FullDateAlternateKey241 = '' OR [A241].[FullDateAlternateKey] < LTRIM(RTRIM(@FullDateAlternateKey241))) " 
                + "AND   (@FirstName242 IS NULL OR @FirstName242 = '' OR [A242].[FirstName] < LTRIM(RTRIM(@FirstName242))) " 
                + "AND   (@EnglishPromotionName243 IS NULL OR @EnglishPromotionName243 = '' OR [A243].[EnglishPromotionName] < LTRIM(RTRIM(@EnglishPromotionName243))) " 
                + "AND   (@CurrencyName244 IS NULL OR @CurrencyName244 = '' OR [A244].[CurrencyName] < LTRIM(RTRIM(@CurrencyName244))) " 
                + "AND   (@SalesTerritoryAlternateKey245 IS NULL OR @SalesTerritoryAlternateKey245 = '' OR [A245].[SalesTerritoryAlternateKey] < LTRIM(RTRIM(@SalesTerritoryAlternateKey245))) " 
                + "AND   (@RevisionNumber IS NULL OR @RevisionNumber = '' OR [FactInternetSales].[RevisionNumber] < LTRIM(RTRIM(@RevisionNumber))) " 
                + "AND   (@OrderQuantity IS NULL OR @OrderQuantity = '' OR [FactInternetSales].[OrderQuantity] < LTRIM(RTRIM(@OrderQuantity))) " 
                + "AND   (@UnitPrice IS NULL OR @UnitPrice = '' OR [FactInternetSales].[UnitPrice] < LTRIM(RTRIM(@UnitPrice))) " 
                + "AND   (@ExtendedAmount IS NULL OR @ExtendedAmount = '' OR [FactInternetSales].[ExtendedAmount] < LTRIM(RTRIM(@ExtendedAmount))) " 
                + "AND   (@UnitPriceDiscountPct IS NULL OR @UnitPriceDiscountPct = '' OR [FactInternetSales].[UnitPriceDiscountPct] < LTRIM(RTRIM(@UnitPriceDiscountPct))) " 
                + "AND   (@DiscountAmount IS NULL OR @DiscountAmount = '' OR [FactInternetSales].[DiscountAmount] < LTRIM(RTRIM(@DiscountAmount))) " 
                + "AND   (@ProductStandardCost IS NULL OR @ProductStandardCost = '' OR [FactInternetSales].[ProductStandardCost] < LTRIM(RTRIM(@ProductStandardCost))) " 
                + "AND   (@TotalProductCost IS NULL OR @TotalProductCost = '' OR [FactInternetSales].[TotalProductCost] < LTRIM(RTRIM(@TotalProductCost))) " 
                + "AND   (@SalesAmount IS NULL OR @SalesAmount = '' OR [FactInternetSales].[SalesAmount] < LTRIM(RTRIM(@SalesAmount))) " 
                + "AND   (@TaxAmt IS NULL OR @TaxAmt = '' OR [FactInternetSales].[TaxAmt] < LTRIM(RTRIM(@TaxAmt))) " 
                + "AND   (@Freight IS NULL OR @Freight = '' OR [FactInternetSales].[Freight] < LTRIM(RTRIM(@Freight))) " 
                + "AND   (@CarrierTrackingNumber IS NULL OR @CarrierTrackingNumber = '' OR [FactInternetSales].[CarrierTrackingNumber] < LTRIM(RTRIM(@CarrierTrackingNumber))) " 
                + "AND   (@CustomerPONumber IS NULL OR @CustomerPONumber = '' OR [FactInternetSales].[CustomerPONumber] < LTRIM(RTRIM(@CustomerPONumber))) " 
                + "AND   (@OrderDate IS NULL OR @OrderDate = '' OR [FactInternetSales].[OrderDate] < LTRIM(RTRIM(@OrderDate))) " 
                + "AND   (@DueDate IS NULL OR @DueDate = '' OR [FactInternetSales].[DueDate] < LTRIM(RTRIM(@DueDate))) " 
                + "AND   (@ShipDate IS NULL OR @ShipDate = '' OR [FactInternetSales].[ShipDate] < LTRIM(RTRIM(@ShipDate))) " 
                + "";
        } else if  (sCondition == "Equal or more than...") {
            selectStatement
                = "SELECT "
            + "     [dbo].[FactInternetSales].[SalesOrderNumber] "
            + "    ,[dbo].[FactInternetSales].[SalesOrderLineNumber] "
            + "    ,[A238].[EnglishProductName]"
            + "    ,[A239].[FullDateAlternateKey]"
            + "    ,[A240].[FullDateAlternateKey]"
            + "    ,[A241].[FullDateAlternateKey]"
            + "    ,[A242].[FirstName]"
            + "    ,[A243].[EnglishPromotionName]"
            + "    ,[A244].[CurrencyName]"
            + "    ,[A245].[SalesTerritoryAlternateKey]"
            + "    ,[dbo].[FactInternetSales].[RevisionNumber] "
            + "    ,[dbo].[FactInternetSales].[OrderQuantity] "
            + "    ,[dbo].[FactInternetSales].[UnitPrice] "
            + "    ,[dbo].[FactInternetSales].[ExtendedAmount] "
            + "    ,[dbo].[FactInternetSales].[UnitPriceDiscountPct] "
            + "    ,[dbo].[FactInternetSales].[DiscountAmount] "
            + "    ,[dbo].[FactInternetSales].[ProductStandardCost] "
            + "    ,[dbo].[FactInternetSales].[TotalProductCost] "
            + "    ,[dbo].[FactInternetSales].[SalesAmount] "
            + "    ,[dbo].[FactInternetSales].[TaxAmt] "
            + "    ,[dbo].[FactInternetSales].[Freight] "
            + "    ,[dbo].[FactInternetSales].[CarrierTrackingNumber] "
            + "    ,[dbo].[FactInternetSales].[CustomerPONumber] "
            + "    ,[dbo].[FactInternetSales].[OrderDate] "
            + "    ,[dbo].[FactInternetSales].[DueDate] "
            + "    ,[dbo].[FactInternetSales].[ShipDate] "
            + "FROM " 
            + "     [dbo].[FactInternetSales] " 
            + "INNER JOIN [dbo].[DimProduct] as [A238] ON [dbo].[FactInternetSales].[ProductKey] = [A238].[ProductKey] "
            + "INNER JOIN [dbo].[DimDate] as [A239] ON [dbo].[FactInternetSales].[OrderDateKey] = [A239].[DateKey] "
            + "INNER JOIN [dbo].[DimDate] as [A240] ON [dbo].[FactInternetSales].[DueDateKey] = [A240].[DateKey] "
            + "INNER JOIN [dbo].[DimDate] as [A241] ON [dbo].[FactInternetSales].[ShipDateKey] = [A241].[DateKey] "
            + "INNER JOIN [dbo].[DimCustomer] as [A242] ON [dbo].[FactInternetSales].[CustomerKey] = [A242].[CustomerKey] "
            + "INNER JOIN [dbo].[DimPromotion] as [A243] ON [dbo].[FactInternetSales].[PromotionKey] = [A243].[PromotionKey] "
            + "INNER JOIN [dbo].[DimCurrency] as [A244] ON [dbo].[FactInternetSales].[CurrencyKey] = [A244].[CurrencyKey] "
            + "INNER JOIN [dbo].[DimSalesTerritory] as [A245] ON [dbo].[FactInternetSales].[SalesTerritoryKey] = [A245].[SalesTerritoryKey] "
                + "WHERE " 
                + "     (@SalesOrderNumber IS NULL OR @SalesOrderNumber = '' OR [FactInternetSales].[SalesOrderNumber] >= LTRIM(RTRIM(@SalesOrderNumber))) " 
                + "AND   (@SalesOrderLineNumber IS NULL OR @SalesOrderLineNumber = '' OR [FactInternetSales].[SalesOrderLineNumber] >= LTRIM(RTRIM(@SalesOrderLineNumber))) " 
                + "AND   (@EnglishProductName238 IS NULL OR @EnglishProductName238 = '' OR [A238].[EnglishProductName] >= LTRIM(RTRIM(@EnglishProductName238))) " 
                + "AND   (@FullDateAlternateKey239 IS NULL OR @FullDateAlternateKey239 = '' OR [A239].[FullDateAlternateKey] >= LTRIM(RTRIM(@FullDateAlternateKey239))) " 
                + "AND   (@FullDateAlternateKey240 IS NULL OR @FullDateAlternateKey240 = '' OR [A240].[FullDateAlternateKey] >= LTRIM(RTRIM(@FullDateAlternateKey240))) " 
                + "AND   (@FullDateAlternateKey241 IS NULL OR @FullDateAlternateKey241 = '' OR [A241].[FullDateAlternateKey] >= LTRIM(RTRIM(@FullDateAlternateKey241))) " 
                + "AND   (@FirstName242 IS NULL OR @FirstName242 = '' OR [A242].[FirstName] >= LTRIM(RTRIM(@FirstName242))) " 
                + "AND   (@EnglishPromotionName243 IS NULL OR @EnglishPromotionName243 = '' OR [A243].[EnglishPromotionName] >= LTRIM(RTRIM(@EnglishPromotionName243))) " 
                + "AND   (@CurrencyName244 IS NULL OR @CurrencyName244 = '' OR [A244].[CurrencyName] >= LTRIM(RTRIM(@CurrencyName244))) " 
                + "AND   (@SalesTerritoryAlternateKey245 IS NULL OR @SalesTerritoryAlternateKey245 = '' OR [A245].[SalesTerritoryAlternateKey] >= LTRIM(RTRIM(@SalesTerritoryAlternateKey245))) " 
                + "AND   (@RevisionNumber IS NULL OR @RevisionNumber = '' OR [FactInternetSales].[RevisionNumber] >= LTRIM(RTRIM(@RevisionNumber))) " 
                + "AND   (@OrderQuantity IS NULL OR @OrderQuantity = '' OR [FactInternetSales].[OrderQuantity] >= LTRIM(RTRIM(@OrderQuantity))) " 
                + "AND   (@UnitPrice IS NULL OR @UnitPrice = '' OR [FactInternetSales].[UnitPrice] >= LTRIM(RTRIM(@UnitPrice))) " 
                + "AND   (@ExtendedAmount IS NULL OR @ExtendedAmount = '' OR [FactInternetSales].[ExtendedAmount] >= LTRIM(RTRIM(@ExtendedAmount))) " 
                + "AND   (@UnitPriceDiscountPct IS NULL OR @UnitPriceDiscountPct = '' OR [FactInternetSales].[UnitPriceDiscountPct] >= LTRIM(RTRIM(@UnitPriceDiscountPct))) " 
                + "AND   (@DiscountAmount IS NULL OR @DiscountAmount = '' OR [FactInternetSales].[DiscountAmount] >= LTRIM(RTRIM(@DiscountAmount))) " 
                + "AND   (@ProductStandardCost IS NULL OR @ProductStandardCost = '' OR [FactInternetSales].[ProductStandardCost] >= LTRIM(RTRIM(@ProductStandardCost))) " 
                + "AND   (@TotalProductCost IS NULL OR @TotalProductCost = '' OR [FactInternetSales].[TotalProductCost] >= LTRIM(RTRIM(@TotalProductCost))) " 
                + "AND   (@SalesAmount IS NULL OR @SalesAmount = '' OR [FactInternetSales].[SalesAmount] >= LTRIM(RTRIM(@SalesAmount))) " 
                + "AND   (@TaxAmt IS NULL OR @TaxAmt = '' OR [FactInternetSales].[TaxAmt] >= LTRIM(RTRIM(@TaxAmt))) " 
                + "AND   (@Freight IS NULL OR @Freight = '' OR [FactInternetSales].[Freight] >= LTRIM(RTRIM(@Freight))) " 
                + "AND   (@CarrierTrackingNumber IS NULL OR @CarrierTrackingNumber = '' OR [FactInternetSales].[CarrierTrackingNumber] >= LTRIM(RTRIM(@CarrierTrackingNumber))) " 
                + "AND   (@CustomerPONumber IS NULL OR @CustomerPONumber = '' OR [FactInternetSales].[CustomerPONumber] >= LTRIM(RTRIM(@CustomerPONumber))) " 
                + "AND   (@OrderDate IS NULL OR @OrderDate = '' OR [FactInternetSales].[OrderDate] >= LTRIM(RTRIM(@OrderDate))) " 
                + "AND   (@DueDate IS NULL OR @DueDate = '' OR [FactInternetSales].[DueDate] >= LTRIM(RTRIM(@DueDate))) " 
                + "AND   (@ShipDate IS NULL OR @ShipDate = '' OR [FactInternetSales].[ShipDate] >= LTRIM(RTRIM(@ShipDate))) " 
                + "";
        } else if (sCondition == "Equal or less than...") {
            selectStatement 
                = "SELECT "
            + "     [dbo].[FactInternetSales].[SalesOrderNumber] "
            + "    ,[dbo].[FactInternetSales].[SalesOrderLineNumber] "
            + "    ,[A238].[EnglishProductName]"
            + "    ,[A239].[FullDateAlternateKey]"
            + "    ,[A240].[FullDateAlternateKey]"
            + "    ,[A241].[FullDateAlternateKey]"
            + "    ,[A242].[FirstName]"
            + "    ,[A243].[EnglishPromotionName]"
            + "    ,[A244].[CurrencyName]"
            + "    ,[A245].[SalesTerritoryAlternateKey]"
            + "    ,[dbo].[FactInternetSales].[RevisionNumber] "
            + "    ,[dbo].[FactInternetSales].[OrderQuantity] "
            + "    ,[dbo].[FactInternetSales].[UnitPrice] "
            + "    ,[dbo].[FactInternetSales].[ExtendedAmount] "
            + "    ,[dbo].[FactInternetSales].[UnitPriceDiscountPct] "
            + "    ,[dbo].[FactInternetSales].[DiscountAmount] "
            + "    ,[dbo].[FactInternetSales].[ProductStandardCost] "
            + "    ,[dbo].[FactInternetSales].[TotalProductCost] "
            + "    ,[dbo].[FactInternetSales].[SalesAmount] "
            + "    ,[dbo].[FactInternetSales].[TaxAmt] "
            + "    ,[dbo].[FactInternetSales].[Freight] "
            + "    ,[dbo].[FactInternetSales].[CarrierTrackingNumber] "
            + "    ,[dbo].[FactInternetSales].[CustomerPONumber] "
            + "    ,[dbo].[FactInternetSales].[OrderDate] "
            + "    ,[dbo].[FactInternetSales].[DueDate] "
            + "    ,[dbo].[FactInternetSales].[ShipDate] "
            + "FROM " 
            + "     [dbo].[FactInternetSales] " 
            + "INNER JOIN [dbo].[DimProduct] as [A238] ON [dbo].[FactInternetSales].[ProductKey] = [A238].[ProductKey] "
            + "INNER JOIN [dbo].[DimDate] as [A239] ON [dbo].[FactInternetSales].[OrderDateKey] = [A239].[DateKey] "
            + "INNER JOIN [dbo].[DimDate] as [A240] ON [dbo].[FactInternetSales].[DueDateKey] = [A240].[DateKey] "
            + "INNER JOIN [dbo].[DimDate] as [A241] ON [dbo].[FactInternetSales].[ShipDateKey] = [A241].[DateKey] "
            + "INNER JOIN [dbo].[DimCustomer] as [A242] ON [dbo].[FactInternetSales].[CustomerKey] = [A242].[CustomerKey] "
            + "INNER JOIN [dbo].[DimPromotion] as [A243] ON [dbo].[FactInternetSales].[PromotionKey] = [A243].[PromotionKey] "
            + "INNER JOIN [dbo].[DimCurrency] as [A244] ON [dbo].[FactInternetSales].[CurrencyKey] = [A244].[CurrencyKey] "
            + "INNER JOIN [dbo].[DimSalesTerritory] as [A245] ON [dbo].[FactInternetSales].[SalesTerritoryKey] = [A245].[SalesTerritoryKey] "
                + "WHERE " 
                + "     (@SalesOrderNumber IS NULL OR @SalesOrderNumber = '' OR [FactInternetSales].[SalesOrderNumber] <= LTRIM(RTRIM(@SalesOrderNumber))) " 
                + "AND   (@SalesOrderLineNumber IS NULL OR @SalesOrderLineNumber = '' OR [FactInternetSales].[SalesOrderLineNumber] <= LTRIM(RTRIM(@SalesOrderLineNumber))) " 
                + "AND   (@EnglishProductName238 IS NULL OR @EnglishProductName238 = '' OR [A238].[EnglishProductName] <= LTRIM(RTRIM(@EnglishProductName238))) " 
                + "AND   (@FullDateAlternateKey239 IS NULL OR @FullDateAlternateKey239 = '' OR [A239].[FullDateAlternateKey] <= LTRIM(RTRIM(@FullDateAlternateKey239))) " 
                + "AND   (@FullDateAlternateKey240 IS NULL OR @FullDateAlternateKey240 = '' OR [A240].[FullDateAlternateKey] <= LTRIM(RTRIM(@FullDateAlternateKey240))) " 
                + "AND   (@FullDateAlternateKey241 IS NULL OR @FullDateAlternateKey241 = '' OR [A241].[FullDateAlternateKey] <= LTRIM(RTRIM(@FullDateAlternateKey241))) " 
                + "AND   (@FirstName242 IS NULL OR @FirstName242 = '' OR [A242].[FirstName] <= LTRIM(RTRIM(@FirstName242))) " 
                + "AND   (@EnglishPromotionName243 IS NULL OR @EnglishPromotionName243 = '' OR [A243].[EnglishPromotionName] <= LTRIM(RTRIM(@EnglishPromotionName243))) " 
                + "AND   (@CurrencyName244 IS NULL OR @CurrencyName244 = '' OR [A244].[CurrencyName] <= LTRIM(RTRIM(@CurrencyName244))) " 
                + "AND   (@SalesTerritoryAlternateKey245 IS NULL OR @SalesTerritoryAlternateKey245 = '' OR [A245].[SalesTerritoryAlternateKey] <= LTRIM(RTRIM(@SalesTerritoryAlternateKey245))) " 
                + "AND   (@RevisionNumber IS NULL OR @RevisionNumber = '' OR [FactInternetSales].[RevisionNumber] <= LTRIM(RTRIM(@RevisionNumber))) " 
                + "AND   (@OrderQuantity IS NULL OR @OrderQuantity = '' OR [FactInternetSales].[OrderQuantity] <= LTRIM(RTRIM(@OrderQuantity))) " 
                + "AND   (@UnitPrice IS NULL OR @UnitPrice = '' OR [FactInternetSales].[UnitPrice] <= LTRIM(RTRIM(@UnitPrice))) " 
                + "AND   (@ExtendedAmount IS NULL OR @ExtendedAmount = '' OR [FactInternetSales].[ExtendedAmount] <= LTRIM(RTRIM(@ExtendedAmount))) " 
                + "AND   (@UnitPriceDiscountPct IS NULL OR @UnitPriceDiscountPct = '' OR [FactInternetSales].[UnitPriceDiscountPct] <= LTRIM(RTRIM(@UnitPriceDiscountPct))) " 
                + "AND   (@DiscountAmount IS NULL OR @DiscountAmount = '' OR [FactInternetSales].[DiscountAmount] <= LTRIM(RTRIM(@DiscountAmount))) " 
                + "AND   (@ProductStandardCost IS NULL OR @ProductStandardCost = '' OR [FactInternetSales].[ProductStandardCost] <= LTRIM(RTRIM(@ProductStandardCost))) " 
                + "AND   (@TotalProductCost IS NULL OR @TotalProductCost = '' OR [FactInternetSales].[TotalProductCost] <= LTRIM(RTRIM(@TotalProductCost))) " 
                + "AND   (@SalesAmount IS NULL OR @SalesAmount = '' OR [FactInternetSales].[SalesAmount] <= LTRIM(RTRIM(@SalesAmount))) " 
                + "AND   (@TaxAmt IS NULL OR @TaxAmt = '' OR [FactInternetSales].[TaxAmt] <= LTRIM(RTRIM(@TaxAmt))) " 
                + "AND   (@Freight IS NULL OR @Freight = '' OR [FactInternetSales].[Freight] <= LTRIM(RTRIM(@Freight))) " 
                + "AND   (@CarrierTrackingNumber IS NULL OR @CarrierTrackingNumber = '' OR [FactInternetSales].[CarrierTrackingNumber] <= LTRIM(RTRIM(@CarrierTrackingNumber))) " 
                + "AND   (@CustomerPONumber IS NULL OR @CustomerPONumber = '' OR [FactInternetSales].[CustomerPONumber] <= LTRIM(RTRIM(@CustomerPONumber))) " 
                + "AND   (@OrderDate IS NULL OR @OrderDate = '' OR [FactInternetSales].[OrderDate] <= LTRIM(RTRIM(@OrderDate))) " 
                + "AND   (@DueDate IS NULL OR @DueDate = '' OR [FactInternetSales].[DueDate] <= LTRIM(RTRIM(@DueDate))) " 
                + "AND   (@ShipDate IS NULL OR @ShipDate = '' OR [FactInternetSales].[ShipDate] <= LTRIM(RTRIM(@ShipDate))) " 
                + "";
        }
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        selectCommand.CommandType = CommandType.Text;
        if (sField == "Sales Order Number") {
            selectCommand.Parameters.AddWithValue("@SalesOrderNumber", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@SalesOrderNumber", DBNull.Value); }
        if (sField == "Sales Order Line Number") {
            selectCommand.Parameters.AddWithValue("@SalesOrderLineNumber", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@SalesOrderLineNumber", DBNull.Value); }
        if (sField == "Product Key") {
            selectCommand.Parameters.AddWithValue("@EnglishProductName238", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@EnglishProductName238", DBNull.Value); }
        if (sField == "Order Date Key") {
            selectCommand.Parameters.AddWithValue("@FullDateAlternateKey239", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@FullDateAlternateKey239", DBNull.Value); }
        if (sField == "Due Date Key") {
            selectCommand.Parameters.AddWithValue("@FullDateAlternateKey240", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@FullDateAlternateKey240", DBNull.Value); }
        if (sField == "Ship Date Key") {
            selectCommand.Parameters.AddWithValue("@FullDateAlternateKey241", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@FullDateAlternateKey241", DBNull.Value); }
        if (sField == "Customer Key") {
            selectCommand.Parameters.AddWithValue("@FirstName242", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@FirstName242", DBNull.Value); }
        if (sField == "Promotion Key") {
            selectCommand.Parameters.AddWithValue("@EnglishPromotionName243", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@EnglishPromotionName243", DBNull.Value); }
        if (sField == "Currency Key") {
            selectCommand.Parameters.AddWithValue("@CurrencyName244", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@CurrencyName244", DBNull.Value); }
        if (sField == "Sales Territory Key") {
            selectCommand.Parameters.AddWithValue("@SalesTerritoryAlternateKey245", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@SalesTerritoryAlternateKey245", DBNull.Value); }
        if (sField == "Revision Number") {
            selectCommand.Parameters.AddWithValue("@RevisionNumber", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@RevisionNumber", DBNull.Value); }
        if (sField == "Order Quantity") {
            selectCommand.Parameters.AddWithValue("@OrderQuantity", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@OrderQuantity", DBNull.Value); }
        if (sField == "Unit Price") {
            selectCommand.Parameters.AddWithValue("@UnitPrice", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@UnitPrice", DBNull.Value); }
        if (sField == "Extended Amount") {
            selectCommand.Parameters.AddWithValue("@ExtendedAmount", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@ExtendedAmount", DBNull.Value); }
        if (sField == "Unit Price Discount Pct") {
            selectCommand.Parameters.AddWithValue("@UnitPriceDiscountPct", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@UnitPriceDiscountPct", DBNull.Value); }
        if (sField == "Discount Amount") {
            selectCommand.Parameters.AddWithValue("@DiscountAmount", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@DiscountAmount", DBNull.Value); }
        if (sField == "Product Standard Cost") {
            selectCommand.Parameters.AddWithValue("@ProductStandardCost", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@ProductStandardCost", DBNull.Value); }
        if (sField == "Total Product Cost") {
            selectCommand.Parameters.AddWithValue("@TotalProductCost", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@TotalProductCost", DBNull.Value); }
        if (sField == "Sales Amount") {
            selectCommand.Parameters.AddWithValue("@SalesAmount", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@SalesAmount", DBNull.Value); }
        if (sField == "Tax Amt") {
            selectCommand.Parameters.AddWithValue("@TaxAmt", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@TaxAmt", DBNull.Value); }
        if (sField == "Freight") {
            selectCommand.Parameters.AddWithValue("@Freight", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@Freight", DBNull.Value); }
        if (sField == "Carrier Tracking Number") {
            selectCommand.Parameters.AddWithValue("@CarrierTrackingNumber", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@CarrierTrackingNumber", DBNull.Value); }
        if (sField == "Customer P O Number") {
            selectCommand.Parameters.AddWithValue("@CustomerPONumber", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@CustomerPONumber", DBNull.Value); }
        if (sField == "Order Date") {
            selectCommand.Parameters.AddWithValue("@OrderDate", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@OrderDate", DBNull.Value); }
        if (sField == "Due Date") {
            selectCommand.Parameters.AddWithValue("@DueDate", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@DueDate", DBNull.Value); }
        if (sField == "Ship Date") {
            selectCommand.Parameters.AddWithValue("@ShipDate", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@ShipDate", DBNull.Value); }
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

    public static dbo_FactInternetSalesClass Select_Record(dbo_FactInternetSalesClass clsdbo_FactInternetSalesPara)
    {
        dbo_FactInternetSalesClass clsdbo_FactInternetSales = new dbo_FactInternetSalesClass();
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement
            = "SELECT " 
            + "     [SalesOrderNumber] "
            + "    ,[SalesOrderLineNumber] "
            + "    ,[ProductKey] "
            + "    ,[OrderDateKey] "
            + "    ,[DueDateKey] "
            + "    ,[ShipDateKey] "
            + "    ,[CustomerKey] "
            + "    ,[PromotionKey] "
            + "    ,[CurrencyKey] "
            + "    ,[SalesTerritoryKey] "
            + "    ,[RevisionNumber] "
            + "    ,[OrderQuantity] "
            + "    ,[UnitPrice] "
            + "    ,[ExtendedAmount] "
            + "    ,[UnitPriceDiscountPct] "
            + "    ,[DiscountAmount] "
            + "    ,[ProductStandardCost] "
            + "    ,[TotalProductCost] "
            + "    ,[SalesAmount] "
            + "    ,[TaxAmt] "
            + "    ,[Freight] "
            + "    ,[CarrierTrackingNumber] "
            + "    ,[CustomerPONumber] "
            + "    ,[OrderDate] "
            + "    ,[DueDate] "
            + "    ,[ShipDate] "
            + "FROM "
            + "     [dbo].[FactInternetSales] "
            + "WHERE "
            + "     [SalesOrderNumber] = @SalesOrderNumber "
            + " AND [SalesOrderLineNumber] = @SalesOrderLineNumber "
            + "";
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        selectCommand.CommandType = CommandType.Text;
        selectCommand.Parameters.AddWithValue("@SalesOrderNumber", clsdbo_FactInternetSalesPara.SalesOrderNumber);
        selectCommand.Parameters.AddWithValue("@SalesOrderLineNumber", clsdbo_FactInternetSalesPara.SalesOrderLineNumber);
        try
        {
            connection.Open();
            SqlDataReader reader
                = selectCommand.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                clsdbo_FactInternetSales.SalesOrderNumber = System.Convert.ToString(reader["SalesOrderNumber"]);
                clsdbo_FactInternetSales.SalesOrderLineNumber = System.Convert.ToByte(reader["SalesOrderLineNumber"]);
                clsdbo_FactInternetSales.ProductKey = System.Convert.ToInt32(reader["ProductKey"]);
                clsdbo_FactInternetSales.OrderDateKey = System.Convert.ToInt32(reader["OrderDateKey"]);
                clsdbo_FactInternetSales.DueDateKey = System.Convert.ToInt32(reader["DueDateKey"]);
                clsdbo_FactInternetSales.ShipDateKey = System.Convert.ToInt32(reader["ShipDateKey"]);
                clsdbo_FactInternetSales.CustomerKey = System.Convert.ToInt32(reader["CustomerKey"]);
                clsdbo_FactInternetSales.PromotionKey = System.Convert.ToInt32(reader["PromotionKey"]);
                clsdbo_FactInternetSales.CurrencyKey = System.Convert.ToInt32(reader["CurrencyKey"]);
                clsdbo_FactInternetSales.SalesTerritoryKey = System.Convert.ToInt32(reader["SalesTerritoryKey"]);
                clsdbo_FactInternetSales.RevisionNumber = System.Convert.ToByte(reader["RevisionNumber"]);
                clsdbo_FactInternetSales.OrderQuantity = System.Convert.ToInt16(reader["OrderQuantity"]);
                clsdbo_FactInternetSales.UnitPrice = System.Convert.ToDecimal(reader["UnitPrice"]);
                clsdbo_FactInternetSales.ExtendedAmount = System.Convert.ToDecimal(reader["ExtendedAmount"]);
                clsdbo_FactInternetSales.UnitPriceDiscountPct = System.Convert.ToDecimal(reader["UnitPriceDiscountPct"]);
                clsdbo_FactInternetSales.DiscountAmount = System.Convert.ToDecimal(reader["DiscountAmount"]);
                clsdbo_FactInternetSales.ProductStandardCost = System.Convert.ToDecimal(reader["ProductStandardCost"]);
                clsdbo_FactInternetSales.TotalProductCost = System.Convert.ToDecimal(reader["TotalProductCost"]);
                clsdbo_FactInternetSales.SalesAmount = System.Convert.ToDecimal(reader["SalesAmount"]);
                clsdbo_FactInternetSales.TaxAmt = System.Convert.ToDecimal(reader["TaxAmt"]);
                clsdbo_FactInternetSales.Freight = System.Convert.ToDecimal(reader["Freight"]);
                clsdbo_FactInternetSales.CarrierTrackingNumber = reader["CarrierTrackingNumber"] is DBNull ? null : reader["CarrierTrackingNumber"].ToString();
                clsdbo_FactInternetSales.CustomerPONumber = reader["CustomerPONumber"] is DBNull ? null : reader["CustomerPONumber"].ToString();
                clsdbo_FactInternetSales.OrderDate = reader["OrderDate"] is DBNull ? null : (DateTime?)reader["OrderDate"];
                clsdbo_FactInternetSales.DueDate = reader["DueDate"] is DBNull ? null : (DateTime?)reader["DueDate"];
                clsdbo_FactInternetSales.ShipDate = reader["ShipDate"] is DBNull ? null : (DateTime?)reader["ShipDate"];
            }
            else
            {
                clsdbo_FactInternetSales = null;
            }
            reader.Close();
        }
        catch (SqlException)
        {
            return clsdbo_FactInternetSales;
        }
        finally
        {
            connection.Close();
        }
        return clsdbo_FactInternetSales;
    }

    public static bool Add(dbo_FactInternetSalesClass clsdbo_FactInternetSales)
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string insertStatement
            = "INSERT " 
            + "     [dbo].[FactInternetSales] "
            + "     ( "
            + "     [SalesOrderNumber] "
            + "    ,[SalesOrderLineNumber] "
            + "    ,[ProductKey] "
            + "    ,[OrderDateKey] "
            + "    ,[DueDateKey] "
            + "    ,[ShipDateKey] "
            + "    ,[CustomerKey] "
            + "    ,[PromotionKey] "
            + "    ,[CurrencyKey] "
            + "    ,[SalesTerritoryKey] "
            + "    ,[RevisionNumber] "
            + "    ,[OrderQuantity] "
            + "    ,[UnitPrice] "
            + "    ,[ExtendedAmount] "
            + "    ,[UnitPriceDiscountPct] "
            + "    ,[DiscountAmount] "
            + "    ,[ProductStandardCost] "
            + "    ,[TotalProductCost] "
            + "    ,[SalesAmount] "
            + "    ,[TaxAmt] "
            + "    ,[Freight] "
            + "    ,[CarrierTrackingNumber] "
            + "    ,[CustomerPONumber] "
            + "    ,[OrderDate] "
            + "    ,[DueDate] "
            + "    ,[ShipDate] "
            + "     ) "
            + "VALUES " 
            + "     ( "
            + "     @SalesOrderNumber "
            + "    ,@SalesOrderLineNumber "
            + "    ,@ProductKey "
            + "    ,@OrderDateKey "
            + "    ,@DueDateKey "
            + "    ,@ShipDateKey "
            + "    ,@CustomerKey "
            + "    ,@PromotionKey "
            + "    ,@CurrencyKey "
            + "    ,@SalesTerritoryKey "
            + "    ,@RevisionNumber "
            + "    ,@OrderQuantity "
            + "    ,@UnitPrice "
            + "    ,@ExtendedAmount "
            + "    ,@UnitPriceDiscountPct "
            + "    ,@DiscountAmount "
            + "    ,@ProductStandardCost "
            + "    ,@TotalProductCost "
            + "    ,@SalesAmount "
            + "    ,@TaxAmt "
            + "    ,@Freight "
            + "    ,@CarrierTrackingNumber "
            + "    ,@CustomerPONumber "
            + "    ,@OrderDate "
            + "    ,@DueDate "
            + "    ,@ShipDate "
            + "     ) "
            + "";
        SqlCommand insertCommand = new SqlCommand(insertStatement, connection);
        insertCommand.CommandType = CommandType.Text;
        insertCommand.Parameters.AddWithValue("@SalesOrderNumber", clsdbo_FactInternetSales.SalesOrderNumber);
        insertCommand.Parameters.AddWithValue("@SalesOrderLineNumber", clsdbo_FactInternetSales.SalesOrderLineNumber);
        insertCommand.Parameters.AddWithValue("@ProductKey", clsdbo_FactInternetSales.ProductKey);
        insertCommand.Parameters.AddWithValue("@OrderDateKey", clsdbo_FactInternetSales.OrderDateKey);
        insertCommand.Parameters.AddWithValue("@DueDateKey", clsdbo_FactInternetSales.DueDateKey);
        insertCommand.Parameters.AddWithValue("@ShipDateKey", clsdbo_FactInternetSales.ShipDateKey);
        insertCommand.Parameters.AddWithValue("@CustomerKey", clsdbo_FactInternetSales.CustomerKey);
        insertCommand.Parameters.AddWithValue("@PromotionKey", clsdbo_FactInternetSales.PromotionKey);
        insertCommand.Parameters.AddWithValue("@CurrencyKey", clsdbo_FactInternetSales.CurrencyKey);
        insertCommand.Parameters.AddWithValue("@SalesTerritoryKey", clsdbo_FactInternetSales.SalesTerritoryKey);
        insertCommand.Parameters.AddWithValue("@RevisionNumber", clsdbo_FactInternetSales.RevisionNumber);
        insertCommand.Parameters.AddWithValue("@OrderQuantity", clsdbo_FactInternetSales.OrderQuantity);
        insertCommand.Parameters.AddWithValue("@UnitPrice", clsdbo_FactInternetSales.UnitPrice);
        insertCommand.Parameters.AddWithValue("@ExtendedAmount", clsdbo_FactInternetSales.ExtendedAmount);
        insertCommand.Parameters.AddWithValue("@UnitPriceDiscountPct", clsdbo_FactInternetSales.UnitPriceDiscountPct);
        insertCommand.Parameters.AddWithValue("@DiscountAmount", clsdbo_FactInternetSales.DiscountAmount);
        insertCommand.Parameters.AddWithValue("@ProductStandardCost", clsdbo_FactInternetSales.ProductStandardCost);
        insertCommand.Parameters.AddWithValue("@TotalProductCost", clsdbo_FactInternetSales.TotalProductCost);
        insertCommand.Parameters.AddWithValue("@SalesAmount", clsdbo_FactInternetSales.SalesAmount);
        insertCommand.Parameters.AddWithValue("@TaxAmt", clsdbo_FactInternetSales.TaxAmt);
        insertCommand.Parameters.AddWithValue("@Freight", clsdbo_FactInternetSales.Freight);
        if (clsdbo_FactInternetSales.CarrierTrackingNumber != null) {
            insertCommand.Parameters.AddWithValue("@CarrierTrackingNumber", clsdbo_FactInternetSales.CarrierTrackingNumber);
        } else {
            insertCommand.Parameters.AddWithValue("@CarrierTrackingNumber", DBNull.Value); }
        if (clsdbo_FactInternetSales.CustomerPONumber != null) {
            insertCommand.Parameters.AddWithValue("@CustomerPONumber", clsdbo_FactInternetSales.CustomerPONumber);
        } else {
            insertCommand.Parameters.AddWithValue("@CustomerPONumber", DBNull.Value); }
        if (clsdbo_FactInternetSales.OrderDate.HasValue == true) {
            insertCommand.Parameters.AddWithValue("@OrderDate", clsdbo_FactInternetSales.OrderDate);
        } else {
            insertCommand.Parameters.AddWithValue("@OrderDate", DBNull.Value); }
        if (clsdbo_FactInternetSales.DueDate.HasValue == true) {
            insertCommand.Parameters.AddWithValue("@DueDate", clsdbo_FactInternetSales.DueDate);
        } else {
            insertCommand.Parameters.AddWithValue("@DueDate", DBNull.Value); }
        if (clsdbo_FactInternetSales.ShipDate.HasValue == true) {
            insertCommand.Parameters.AddWithValue("@ShipDate", clsdbo_FactInternetSales.ShipDate);
        } else {
            insertCommand.Parameters.AddWithValue("@ShipDate", DBNull.Value); }
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

    public static bool Update(dbo_FactInternetSalesClass olddbo_FactInternetSalesClass, 
           dbo_FactInternetSalesClass newdbo_FactInternetSalesClass)
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string updateStatement
            = "UPDATE "  
            + "     [dbo].[FactInternetSales] "
            + "SET "
            + "     [SalesOrderNumber] = @NewSalesOrderNumber "
            + "    ,[SalesOrderLineNumber] = @NewSalesOrderLineNumber "
            + "    ,[ProductKey] = @NewProductKey "
            + "    ,[OrderDateKey] = @NewOrderDateKey "
            + "    ,[DueDateKey] = @NewDueDateKey "
            + "    ,[ShipDateKey] = @NewShipDateKey "
            + "    ,[CustomerKey] = @NewCustomerKey "
            + "    ,[PromotionKey] = @NewPromotionKey "
            + "    ,[CurrencyKey] = @NewCurrencyKey "
            + "    ,[SalesTerritoryKey] = @NewSalesTerritoryKey "
            + "    ,[RevisionNumber] = @NewRevisionNumber "
            + "    ,[OrderQuantity] = @NewOrderQuantity "
            + "    ,[UnitPrice] = @NewUnitPrice "
            + "    ,[ExtendedAmount] = @NewExtendedAmount "
            + "    ,[UnitPriceDiscountPct] = @NewUnitPriceDiscountPct "
            + "    ,[DiscountAmount] = @NewDiscountAmount "
            + "    ,[ProductStandardCost] = @NewProductStandardCost "
            + "    ,[TotalProductCost] = @NewTotalProductCost "
            + "    ,[SalesAmount] = @NewSalesAmount "
            + "    ,[TaxAmt] = @NewTaxAmt "
            + "    ,[Freight] = @NewFreight "
            + "    ,[CarrierTrackingNumber] = @NewCarrierTrackingNumber "
            + "    ,[CustomerPONumber] = @NewCustomerPONumber "
            + "    ,[OrderDate] = @NewOrderDate "
            + "    ,[DueDate] = @NewDueDate "
            + "    ,[ShipDate] = @NewShipDate "
            + "WHERE "
            + "     [SalesOrderNumber] = @OldSalesOrderNumber " 
            + " AND [SalesOrderLineNumber] = @OldSalesOrderLineNumber " 
            + " AND [ProductKey] = @OldProductKey " 
            + " AND [OrderDateKey] = @OldOrderDateKey " 
            + " AND [DueDateKey] = @OldDueDateKey " 
            + " AND [ShipDateKey] = @OldShipDateKey " 
            + " AND [CustomerKey] = @OldCustomerKey " 
            + " AND [PromotionKey] = @OldPromotionKey " 
            + " AND [CurrencyKey] = @OldCurrencyKey " 
            + " AND [SalesTerritoryKey] = @OldSalesTerritoryKey " 
            + " AND [RevisionNumber] = @OldRevisionNumber " 
            + " AND [OrderQuantity] = @OldOrderQuantity " 
            + " AND [UnitPrice] = @OldUnitPrice " 
            + " AND [ExtendedAmount] = @OldExtendedAmount " 
            + " AND [UnitPriceDiscountPct] = @OldUnitPriceDiscountPct " 
            + " AND [DiscountAmount] = @OldDiscountAmount " 
            + " AND [ProductStandardCost] = @OldProductStandardCost " 
            + " AND [TotalProductCost] = @OldTotalProductCost " 
            + " AND [SalesAmount] = @OldSalesAmount " 
            + " AND [TaxAmt] = @OldTaxAmt " 
            + " AND [Freight] = @OldFreight " 
            + " AND ((@OldCarrierTrackingNumber IS NULL AND [CarrierTrackingNumber] IS NULL) OR [CarrierTrackingNumber] = @OldCarrierTrackingNumber) " 
            + " AND ((@OldCustomerPONumber IS NULL AND [CustomerPONumber] IS NULL) OR [CustomerPONumber] = @OldCustomerPONumber) " 
            + " AND ((@OldOrderDate IS NULL AND [OrderDate] IS NULL) OR [OrderDate] = @OldOrderDate) " 
            + " AND ((@OldDueDate IS NULL AND [DueDate] IS NULL) OR [DueDate] = @OldDueDate) " 
            + " AND ((@OldShipDate IS NULL AND [ShipDate] IS NULL) OR [ShipDate] = @OldShipDate) " 
            + "";
        SqlCommand updateCommand = new SqlCommand(updateStatement, connection);
        updateCommand.CommandType = CommandType.Text;
        updateCommand.Parameters.AddWithValue("@NewSalesOrderNumber", newdbo_FactInternetSalesClass.SalesOrderNumber);
        updateCommand.Parameters.AddWithValue("@NewSalesOrderLineNumber", newdbo_FactInternetSalesClass.SalesOrderLineNumber);
        updateCommand.Parameters.AddWithValue("@NewProductKey", newdbo_FactInternetSalesClass.ProductKey);
        updateCommand.Parameters.AddWithValue("@NewOrderDateKey", newdbo_FactInternetSalesClass.OrderDateKey);
        updateCommand.Parameters.AddWithValue("@NewDueDateKey", newdbo_FactInternetSalesClass.DueDateKey);
        updateCommand.Parameters.AddWithValue("@NewShipDateKey", newdbo_FactInternetSalesClass.ShipDateKey);
        updateCommand.Parameters.AddWithValue("@NewCustomerKey", newdbo_FactInternetSalesClass.CustomerKey);
        updateCommand.Parameters.AddWithValue("@NewPromotionKey", newdbo_FactInternetSalesClass.PromotionKey);
        updateCommand.Parameters.AddWithValue("@NewCurrencyKey", newdbo_FactInternetSalesClass.CurrencyKey);
        updateCommand.Parameters.AddWithValue("@NewSalesTerritoryKey", newdbo_FactInternetSalesClass.SalesTerritoryKey);
        updateCommand.Parameters.AddWithValue("@NewRevisionNumber", newdbo_FactInternetSalesClass.RevisionNumber);
        updateCommand.Parameters.AddWithValue("@NewOrderQuantity", newdbo_FactInternetSalesClass.OrderQuantity);
        updateCommand.Parameters.AddWithValue("@NewUnitPrice", newdbo_FactInternetSalesClass.UnitPrice);
        updateCommand.Parameters.AddWithValue("@NewExtendedAmount", newdbo_FactInternetSalesClass.ExtendedAmount);
        updateCommand.Parameters.AddWithValue("@NewUnitPriceDiscountPct", newdbo_FactInternetSalesClass.UnitPriceDiscountPct);
        updateCommand.Parameters.AddWithValue("@NewDiscountAmount", newdbo_FactInternetSalesClass.DiscountAmount);
        updateCommand.Parameters.AddWithValue("@NewProductStandardCost", newdbo_FactInternetSalesClass.ProductStandardCost);
        updateCommand.Parameters.AddWithValue("@NewTotalProductCost", newdbo_FactInternetSalesClass.TotalProductCost);
        updateCommand.Parameters.AddWithValue("@NewSalesAmount", newdbo_FactInternetSalesClass.SalesAmount);
        updateCommand.Parameters.AddWithValue("@NewTaxAmt", newdbo_FactInternetSalesClass.TaxAmt);
        updateCommand.Parameters.AddWithValue("@NewFreight", newdbo_FactInternetSalesClass.Freight);
        if (newdbo_FactInternetSalesClass.CarrierTrackingNumber != null) {
            updateCommand.Parameters.AddWithValue("@NewCarrierTrackingNumber", newdbo_FactInternetSalesClass.CarrierTrackingNumber);
        } else {
            updateCommand.Parameters.AddWithValue("@NewCarrierTrackingNumber", DBNull.Value); }
        if (newdbo_FactInternetSalesClass.CustomerPONumber != null) {
            updateCommand.Parameters.AddWithValue("@NewCustomerPONumber", newdbo_FactInternetSalesClass.CustomerPONumber);
        } else {
            updateCommand.Parameters.AddWithValue("@NewCustomerPONumber", DBNull.Value); }
        if (newdbo_FactInternetSalesClass.OrderDate.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@NewOrderDate", newdbo_FactInternetSalesClass.OrderDate);
        } else {
            updateCommand.Parameters.AddWithValue("@NewOrderDate", DBNull.Value); }
        if (newdbo_FactInternetSalesClass.DueDate.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@NewDueDate", newdbo_FactInternetSalesClass.DueDate);
        } else {
            updateCommand.Parameters.AddWithValue("@NewDueDate", DBNull.Value); }
        if (newdbo_FactInternetSalesClass.ShipDate.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@NewShipDate", newdbo_FactInternetSalesClass.ShipDate);
        } else {
            updateCommand.Parameters.AddWithValue("@NewShipDate", DBNull.Value); }
        updateCommand.Parameters.AddWithValue("@OldSalesOrderNumber", olddbo_FactInternetSalesClass.SalesOrderNumber);
        updateCommand.Parameters.AddWithValue("@OldSalesOrderLineNumber", olddbo_FactInternetSalesClass.SalesOrderLineNumber);
        updateCommand.Parameters.AddWithValue("@OldProductKey", olddbo_FactInternetSalesClass.ProductKey);
        updateCommand.Parameters.AddWithValue("@OldOrderDateKey", olddbo_FactInternetSalesClass.OrderDateKey);
        updateCommand.Parameters.AddWithValue("@OldDueDateKey", olddbo_FactInternetSalesClass.DueDateKey);
        updateCommand.Parameters.AddWithValue("@OldShipDateKey", olddbo_FactInternetSalesClass.ShipDateKey);
        updateCommand.Parameters.AddWithValue("@OldCustomerKey", olddbo_FactInternetSalesClass.CustomerKey);
        updateCommand.Parameters.AddWithValue("@OldPromotionKey", olddbo_FactInternetSalesClass.PromotionKey);
        updateCommand.Parameters.AddWithValue("@OldCurrencyKey", olddbo_FactInternetSalesClass.CurrencyKey);
        updateCommand.Parameters.AddWithValue("@OldSalesTerritoryKey", olddbo_FactInternetSalesClass.SalesTerritoryKey);
        updateCommand.Parameters.AddWithValue("@OldRevisionNumber", olddbo_FactInternetSalesClass.RevisionNumber);
        updateCommand.Parameters.AddWithValue("@OldOrderQuantity", olddbo_FactInternetSalesClass.OrderQuantity);
        updateCommand.Parameters.AddWithValue("@OldUnitPrice", olddbo_FactInternetSalesClass.UnitPrice);
        updateCommand.Parameters.AddWithValue("@OldExtendedAmount", olddbo_FactInternetSalesClass.ExtendedAmount);
        updateCommand.Parameters.AddWithValue("@OldUnitPriceDiscountPct", olddbo_FactInternetSalesClass.UnitPriceDiscountPct);
        updateCommand.Parameters.AddWithValue("@OldDiscountAmount", olddbo_FactInternetSalesClass.DiscountAmount);
        updateCommand.Parameters.AddWithValue("@OldProductStandardCost", olddbo_FactInternetSalesClass.ProductStandardCost);
        updateCommand.Parameters.AddWithValue("@OldTotalProductCost", olddbo_FactInternetSalesClass.TotalProductCost);
        updateCommand.Parameters.AddWithValue("@OldSalesAmount", olddbo_FactInternetSalesClass.SalesAmount);
        updateCommand.Parameters.AddWithValue("@OldTaxAmt", olddbo_FactInternetSalesClass.TaxAmt);
        updateCommand.Parameters.AddWithValue("@OldFreight", olddbo_FactInternetSalesClass.Freight);
        if (olddbo_FactInternetSalesClass.CarrierTrackingNumber != null) {
            updateCommand.Parameters.AddWithValue("@OldCarrierTrackingNumber", olddbo_FactInternetSalesClass.CarrierTrackingNumber);
        } else {
            updateCommand.Parameters.AddWithValue("@OldCarrierTrackingNumber", DBNull.Value); }
        if (olddbo_FactInternetSalesClass.CustomerPONumber != null) {
            updateCommand.Parameters.AddWithValue("@OldCustomerPONumber", olddbo_FactInternetSalesClass.CustomerPONumber);
        } else {
            updateCommand.Parameters.AddWithValue("@OldCustomerPONumber", DBNull.Value); }
        if (olddbo_FactInternetSalesClass.OrderDate.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@OldOrderDate", olddbo_FactInternetSalesClass.OrderDate);
        } else {
            updateCommand.Parameters.AddWithValue("@OldOrderDate", DBNull.Value); }
        if (olddbo_FactInternetSalesClass.DueDate.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@OldDueDate", olddbo_FactInternetSalesClass.DueDate);
        } else {
            updateCommand.Parameters.AddWithValue("@OldDueDate", DBNull.Value); }
        if (olddbo_FactInternetSalesClass.ShipDate.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@OldShipDate", olddbo_FactInternetSalesClass.ShipDate);
        } else {
            updateCommand.Parameters.AddWithValue("@OldShipDate", DBNull.Value); }
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

    public static bool Delete(dbo_FactInternetSalesClass clsdbo_FactInternetSales)
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string deleteStatement
            = "DELETE FROM "  
            + "     [dbo].[FactInternetSales] "
            + "WHERE " 
            + "     [SalesOrderNumber] = @OldSalesOrderNumber " 
            + " AND [SalesOrderLineNumber] = @OldSalesOrderLineNumber " 
            + " AND [ProductKey] = @OldProductKey " 
            + " AND [OrderDateKey] = @OldOrderDateKey " 
            + " AND [DueDateKey] = @OldDueDateKey " 
            + " AND [ShipDateKey] = @OldShipDateKey " 
            + " AND [CustomerKey] = @OldCustomerKey " 
            + " AND [PromotionKey] = @OldPromotionKey " 
            + " AND [CurrencyKey] = @OldCurrencyKey " 
            + " AND [SalesTerritoryKey] = @OldSalesTerritoryKey " 
            + " AND [RevisionNumber] = @OldRevisionNumber " 
            + " AND [OrderQuantity] = @OldOrderQuantity " 
            + " AND [UnitPrice] = @OldUnitPrice " 
            + " AND [ExtendedAmount] = @OldExtendedAmount " 
            + " AND [UnitPriceDiscountPct] = @OldUnitPriceDiscountPct " 
            + " AND [DiscountAmount] = @OldDiscountAmount " 
            + " AND [ProductStandardCost] = @OldProductStandardCost " 
            + " AND [TotalProductCost] = @OldTotalProductCost " 
            + " AND [SalesAmount] = @OldSalesAmount " 
            + " AND [TaxAmt] = @OldTaxAmt " 
            + " AND [Freight] = @OldFreight " 
            + " AND ((@OldCarrierTrackingNumber IS NULL AND [CarrierTrackingNumber] IS NULL) OR [CarrierTrackingNumber] = @OldCarrierTrackingNumber) " 
            + " AND ((@OldCustomerPONumber IS NULL AND [CustomerPONumber] IS NULL) OR [CustomerPONumber] = @OldCustomerPONumber) " 
            + " AND ((@OldOrderDate IS NULL AND [OrderDate] IS NULL) OR [OrderDate] = @OldOrderDate) " 
            + " AND ((@OldDueDate IS NULL AND [DueDate] IS NULL) OR [DueDate] = @OldDueDate) " 
            + " AND ((@OldShipDate IS NULL AND [ShipDate] IS NULL) OR [ShipDate] = @OldShipDate) " 
            + "";
        SqlCommand deleteCommand = new SqlCommand(deleteStatement, connection);
        deleteCommand.CommandType = CommandType.Text;
        deleteCommand.Parameters.AddWithValue("@OldSalesOrderNumber", clsdbo_FactInternetSales.SalesOrderNumber);
        deleteCommand.Parameters.AddWithValue("@OldSalesOrderLineNumber", clsdbo_FactInternetSales.SalesOrderLineNumber);
        deleteCommand.Parameters.AddWithValue("@OldProductKey", clsdbo_FactInternetSales.ProductKey);
        deleteCommand.Parameters.AddWithValue("@OldOrderDateKey", clsdbo_FactInternetSales.OrderDateKey);
        deleteCommand.Parameters.AddWithValue("@OldDueDateKey", clsdbo_FactInternetSales.DueDateKey);
        deleteCommand.Parameters.AddWithValue("@OldShipDateKey", clsdbo_FactInternetSales.ShipDateKey);
        deleteCommand.Parameters.AddWithValue("@OldCustomerKey", clsdbo_FactInternetSales.CustomerKey);
        deleteCommand.Parameters.AddWithValue("@OldPromotionKey", clsdbo_FactInternetSales.PromotionKey);
        deleteCommand.Parameters.AddWithValue("@OldCurrencyKey", clsdbo_FactInternetSales.CurrencyKey);
        deleteCommand.Parameters.AddWithValue("@OldSalesTerritoryKey", clsdbo_FactInternetSales.SalesTerritoryKey);
        deleteCommand.Parameters.AddWithValue("@OldRevisionNumber", clsdbo_FactInternetSales.RevisionNumber);
        deleteCommand.Parameters.AddWithValue("@OldOrderQuantity", clsdbo_FactInternetSales.OrderQuantity);
        deleteCommand.Parameters.AddWithValue("@OldUnitPrice", clsdbo_FactInternetSales.UnitPrice);
        deleteCommand.Parameters.AddWithValue("@OldExtendedAmount", clsdbo_FactInternetSales.ExtendedAmount);
        deleteCommand.Parameters.AddWithValue("@OldUnitPriceDiscountPct", clsdbo_FactInternetSales.UnitPriceDiscountPct);
        deleteCommand.Parameters.AddWithValue("@OldDiscountAmount", clsdbo_FactInternetSales.DiscountAmount);
        deleteCommand.Parameters.AddWithValue("@OldProductStandardCost", clsdbo_FactInternetSales.ProductStandardCost);
        deleteCommand.Parameters.AddWithValue("@OldTotalProductCost", clsdbo_FactInternetSales.TotalProductCost);
        deleteCommand.Parameters.AddWithValue("@OldSalesAmount", clsdbo_FactInternetSales.SalesAmount);
        deleteCommand.Parameters.AddWithValue("@OldTaxAmt", clsdbo_FactInternetSales.TaxAmt);
        deleteCommand.Parameters.AddWithValue("@OldFreight", clsdbo_FactInternetSales.Freight);
        if (clsdbo_FactInternetSales.CarrierTrackingNumber != null) {
            deleteCommand.Parameters.AddWithValue("@OldCarrierTrackingNumber", clsdbo_FactInternetSales.CarrierTrackingNumber);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldCarrierTrackingNumber", DBNull.Value); }
        if (clsdbo_FactInternetSales.CustomerPONumber != null) {
            deleteCommand.Parameters.AddWithValue("@OldCustomerPONumber", clsdbo_FactInternetSales.CustomerPONumber);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldCustomerPONumber", DBNull.Value); }
        if (clsdbo_FactInternetSales.OrderDate.HasValue == true) {
            deleteCommand.Parameters.AddWithValue("@OldOrderDate", clsdbo_FactInternetSales.OrderDate);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldOrderDate", DBNull.Value); }
        if (clsdbo_FactInternetSales.DueDate.HasValue == true) {
            deleteCommand.Parameters.AddWithValue("@OldDueDate", clsdbo_FactInternetSales.DueDate);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldDueDate", DBNull.Value); }
        if (clsdbo_FactInternetSales.ShipDate.HasValue == true) {
            deleteCommand.Parameters.AddWithValue("@OldShipDate", clsdbo_FactInternetSales.ShipDate);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldShipDate", DBNull.Value); }
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

 
