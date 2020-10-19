using System;
using System.Data;
using System.Data.SqlClient;

public class dbo_FactResellerSalesDataClass
{

    public static DataTable SelectAll()
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement
            = "SELECT "  
            + "     [dbo].[FactResellerSales].[SalesOrderNumber] "
            + "    ,[dbo].[FactResellerSales].[SalesOrderLineNumber] "
            + "    ,[A274].[ProductAlternateKey] "
            + "    ,[A275].[DateKey] "
            + "    ,[A276].[DateKey] "
            + "    ,[A277].[DateKey] "
            + "    ,[A278].[ResellerKey] "
            + "    ,[A279].[EmployeeKey] "
            + "    ,[A280].[PromotionKey] "
            + "    ,[A281].[CurrencyKey] "
            + "    ,[A282].[SalesTerritoryKey] "
            + "    ,[dbo].[FactResellerSales].[RevisionNumber] "
            + "    ,[dbo].[FactResellerSales].[OrderQuantity] "
            + "    ,[dbo].[FactResellerSales].[UnitPrice] "
            + "    ,[dbo].[FactResellerSales].[ExtendedAmount] "
            + "    ,[dbo].[FactResellerSales].[UnitPriceDiscountPct] "
            + "    ,[dbo].[FactResellerSales].[DiscountAmount] "
            + "    ,[dbo].[FactResellerSales].[ProductStandardCost] "
            + "    ,[dbo].[FactResellerSales].[TotalProductCost] "
            + "    ,[dbo].[FactResellerSales].[SalesAmount] "
            + "    ,[dbo].[FactResellerSales].[TaxAmt] "
            + "    ,[dbo].[FactResellerSales].[Freight] "
            + "    ,[dbo].[FactResellerSales].[CarrierTrackingNumber] "
            + "    ,[dbo].[FactResellerSales].[CustomerPONumber] "
            + "    ,[dbo].[FactResellerSales].[OrderDate] "
            + "    ,[dbo].[FactResellerSales].[DueDate] "
            + "    ,[dbo].[FactResellerSales].[ShipDate] "
            + "FROM " 
            + "     [dbo].[FactResellerSales] " 
            + "INNER JOIN [dbo].[DimProduct] as [A274] ON [dbo].[FactResellerSales].[ProductKey] = [A274].[ProductKey] "
            + "INNER JOIN [dbo].[DimDate] as [A275] ON [dbo].[FactResellerSales].[OrderDateKey] = [A275].[DateKey] "
            + "INNER JOIN [dbo].[DimDate] as [A276] ON [dbo].[FactResellerSales].[DueDateKey] = [A276].[DateKey] "
            + "INNER JOIN [dbo].[DimDate] as [A277] ON [dbo].[FactResellerSales].[ShipDateKey] = [A277].[DateKey] "
            + "INNER JOIN [dbo].[DimReseller] as [A278] ON [dbo].[FactResellerSales].[ResellerKey] = [A278].[ResellerKey] "
            + "INNER JOIN [dbo].[DimEmployee] as [A279] ON [dbo].[FactResellerSales].[EmployeeKey] = [A279].[EmployeeKey] "
            + "INNER JOIN [dbo].[DimPromotion] as [A280] ON [dbo].[FactResellerSales].[PromotionKey] = [A280].[PromotionKey] "
            + "INNER JOIN [dbo].[DimCurrency] as [A281] ON [dbo].[FactResellerSales].[CurrencyKey] = [A281].[CurrencyKey] "
            + "INNER JOIN [dbo].[DimSalesTerritory] as [A282] ON [dbo].[FactResellerSales].[SalesTerritoryKey] = [A282].[SalesTerritoryKey] "
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
            + "     [dbo].[FactResellerSales].[SalesOrderNumber] "
            + "    ,[dbo].[FactResellerSales].[SalesOrderLineNumber] "
            + "    ,[A274].[ProductAlternateKey]"
            + "    ,[A275].[DateKey]"
            + "    ,[A276].[DateKey]"
            + "    ,[A277].[DateKey]"
            + "    ,[A278].[ResellerKey]"
            + "    ,[A279].[EmployeeKey]"
            + "    ,[A280].[PromotionKey]"
            + "    ,[A281].[CurrencyKey]"
            + "    ,[A282].[SalesTerritoryKey]"
            + "    ,[dbo].[FactResellerSales].[RevisionNumber] "
            + "    ,[dbo].[FactResellerSales].[OrderQuantity] "
            + "    ,[dbo].[FactResellerSales].[UnitPrice] "
            + "    ,[dbo].[FactResellerSales].[ExtendedAmount] "
            + "    ,[dbo].[FactResellerSales].[UnitPriceDiscountPct] "
            + "    ,[dbo].[FactResellerSales].[DiscountAmount] "
            + "    ,[dbo].[FactResellerSales].[ProductStandardCost] "
            + "    ,[dbo].[FactResellerSales].[TotalProductCost] "
            + "    ,[dbo].[FactResellerSales].[SalesAmount] "
            + "    ,[dbo].[FactResellerSales].[TaxAmt] "
            + "    ,[dbo].[FactResellerSales].[Freight] "
            + "    ,[dbo].[FactResellerSales].[CarrierTrackingNumber] "
            + "    ,[dbo].[FactResellerSales].[CustomerPONumber] "
            + "    ,[dbo].[FactResellerSales].[OrderDate] "
            + "    ,[dbo].[FactResellerSales].[DueDate] "
            + "    ,[dbo].[FactResellerSales].[ShipDate] "
            + "FROM " 
            + "     [dbo].[FactResellerSales] " 
            + "INNER JOIN [dbo].[DimProduct] as [A274] ON [dbo].[FactResellerSales].[ProductKey] = [A274].[ProductKey] "
            + "INNER JOIN [dbo].[DimDate] as [A275] ON [dbo].[FactResellerSales].[OrderDateKey] = [A275].[DateKey] "
            + "INNER JOIN [dbo].[DimDate] as [A276] ON [dbo].[FactResellerSales].[DueDateKey] = [A276].[DateKey] "
            + "INNER JOIN [dbo].[DimDate] as [A277] ON [dbo].[FactResellerSales].[ShipDateKey] = [A277].[DateKey] "
            + "INNER JOIN [dbo].[DimReseller] as [A278] ON [dbo].[FactResellerSales].[ResellerKey] = [A278].[ResellerKey] "
            + "INNER JOIN [dbo].[DimEmployee] as [A279] ON [dbo].[FactResellerSales].[EmployeeKey] = [A279].[EmployeeKey] "
            + "INNER JOIN [dbo].[DimPromotion] as [A280] ON [dbo].[FactResellerSales].[PromotionKey] = [A280].[PromotionKey] "
            + "INNER JOIN [dbo].[DimCurrency] as [A281] ON [dbo].[FactResellerSales].[CurrencyKey] = [A281].[CurrencyKey] "
            + "INNER JOIN [dbo].[DimSalesTerritory] as [A282] ON [dbo].[FactResellerSales].[SalesTerritoryKey] = [A282].[SalesTerritoryKey] "
                + "WHERE " 
                + "     (@SalesOrderNumber IS NULL OR @SalesOrderNumber = '' OR [FactResellerSales].[SalesOrderNumber] LIKE '%' + LTRIM(RTRIM(@SalesOrderNumber)) + '%') " 
                + "AND   (@SalesOrderLineNumber IS NULL OR @SalesOrderLineNumber = '' OR [FactResellerSales].[SalesOrderLineNumber] LIKE '%' + LTRIM(RTRIM(@SalesOrderLineNumber)) + '%') " 
                + "AND   (@ProductAlternateKey274 IS NULL OR @ProductAlternateKey274 = '' OR [A274].[ProductAlternateKey] LIKE '%' + LTRIM(RTRIM(@ProductAlternateKey274)) + '%') " 
                + "AND   (@DateKey275 IS NULL OR @DateKey275 = '' OR [A275].[DateKey] LIKE '%' + LTRIM(RTRIM(@DateKey275)) + '%') " 
                + "AND   (@DateKey276 IS NULL OR @DateKey276 = '' OR [A276].[DateKey] LIKE '%' + LTRIM(RTRIM(@DateKey276)) + '%') " 
                + "AND   (@DateKey277 IS NULL OR @DateKey277 = '' OR [A277].[DateKey] LIKE '%' + LTRIM(RTRIM(@DateKey277)) + '%') " 
                + "AND   (@ResellerKey278 IS NULL OR @ResellerKey278 = '' OR [A278].[ResellerKey] LIKE '%' + LTRIM(RTRIM(@ResellerKey278)) + '%') " 
                + "AND   (@EmployeeKey279 IS NULL OR @EmployeeKey279 = '' OR [A279].[EmployeeKey] LIKE '%' + LTRIM(RTRIM(@EmployeeKey279)) + '%') " 
                + "AND   (@PromotionKey280 IS NULL OR @PromotionKey280 = '' OR [A280].[PromotionKey] LIKE '%' + LTRIM(RTRIM(@PromotionKey280)) + '%') " 
                + "AND   (@CurrencyKey281 IS NULL OR @CurrencyKey281 = '' OR [A281].[CurrencyKey] LIKE '%' + LTRIM(RTRIM(@CurrencyKey281)) + '%') " 
                + "AND   (@SalesTerritoryKey282 IS NULL OR @SalesTerritoryKey282 = '' OR [A282].[SalesTerritoryKey] LIKE '%' + LTRIM(RTRIM(@SalesTerritoryKey282)) + '%') " 
                + "AND   (@RevisionNumber IS NULL OR @RevisionNumber = '' OR [FactResellerSales].[RevisionNumber] LIKE '%' + LTRIM(RTRIM(@RevisionNumber)) + '%') " 
                + "AND   (@OrderQuantity IS NULL OR @OrderQuantity = '' OR [FactResellerSales].[OrderQuantity] LIKE '%' + LTRIM(RTRIM(@OrderQuantity)) + '%') " 
                + "AND   (@UnitPrice IS NULL OR @UnitPrice = '' OR [FactResellerSales].[UnitPrice] LIKE '%' + LTRIM(RTRIM(@UnitPrice)) + '%') " 
                + "AND   (@ExtendedAmount IS NULL OR @ExtendedAmount = '' OR [FactResellerSales].[ExtendedAmount] LIKE '%' + LTRIM(RTRIM(@ExtendedAmount)) + '%') " 
                + "AND   (@UnitPriceDiscountPct IS NULL OR @UnitPriceDiscountPct = '' OR [FactResellerSales].[UnitPriceDiscountPct] LIKE '%' + LTRIM(RTRIM(@UnitPriceDiscountPct)) + '%') " 
                + "AND   (@DiscountAmount IS NULL OR @DiscountAmount = '' OR [FactResellerSales].[DiscountAmount] LIKE '%' + LTRIM(RTRIM(@DiscountAmount)) + '%') " 
                + "AND   (@ProductStandardCost IS NULL OR @ProductStandardCost = '' OR [FactResellerSales].[ProductStandardCost] LIKE '%' + LTRIM(RTRIM(@ProductStandardCost)) + '%') " 
                + "AND   (@TotalProductCost IS NULL OR @TotalProductCost = '' OR [FactResellerSales].[TotalProductCost] LIKE '%' + LTRIM(RTRIM(@TotalProductCost)) + '%') " 
                + "AND   (@SalesAmount IS NULL OR @SalesAmount = '' OR [FactResellerSales].[SalesAmount] LIKE '%' + LTRIM(RTRIM(@SalesAmount)) + '%') " 
                + "AND   (@TaxAmt IS NULL OR @TaxAmt = '' OR [FactResellerSales].[TaxAmt] LIKE '%' + LTRIM(RTRIM(@TaxAmt)) + '%') " 
                + "AND   (@Freight IS NULL OR @Freight = '' OR [FactResellerSales].[Freight] LIKE '%' + LTRIM(RTRIM(@Freight)) + '%') " 
                + "AND   (@CarrierTrackingNumber IS NULL OR @CarrierTrackingNumber = '' OR [FactResellerSales].[CarrierTrackingNumber] LIKE '%' + LTRIM(RTRIM(@CarrierTrackingNumber)) + '%') " 
                + "AND   (@CustomerPONumber IS NULL OR @CustomerPONumber = '' OR [FactResellerSales].[CustomerPONumber] LIKE '%' + LTRIM(RTRIM(@CustomerPONumber)) + '%') " 
                + "AND   (@OrderDate IS NULL OR @OrderDate = '' OR [FactResellerSales].[OrderDate] LIKE '%' + LTRIM(RTRIM(@OrderDate)) + '%') " 
                + "AND   (@DueDate IS NULL OR @DueDate = '' OR [FactResellerSales].[DueDate] LIKE '%' + LTRIM(RTRIM(@DueDate)) + '%') " 
                + "AND   (@ShipDate IS NULL OR @ShipDate = '' OR [FactResellerSales].[ShipDate] LIKE '%' + LTRIM(RTRIM(@ShipDate)) + '%') " 
                + "";
        } else if (sCondition == "Equals") {
            selectStatement
                = "SELECT "
            + "     [dbo].[FactResellerSales].[SalesOrderNumber] "
            + "    ,[dbo].[FactResellerSales].[SalesOrderLineNumber] "
            + "    ,[A274].[ProductAlternateKey]"
            + "    ,[A275].[DateKey]"
            + "    ,[A276].[DateKey]"
            + "    ,[A277].[DateKey]"
            + "    ,[A278].[ResellerKey]"
            + "    ,[A279].[EmployeeKey]"
            + "    ,[A280].[PromotionKey]"
            + "    ,[A281].[CurrencyKey]"
            + "    ,[A282].[SalesTerritoryKey]"
            + "    ,[dbo].[FactResellerSales].[RevisionNumber] "
            + "    ,[dbo].[FactResellerSales].[OrderQuantity] "
            + "    ,[dbo].[FactResellerSales].[UnitPrice] "
            + "    ,[dbo].[FactResellerSales].[ExtendedAmount] "
            + "    ,[dbo].[FactResellerSales].[UnitPriceDiscountPct] "
            + "    ,[dbo].[FactResellerSales].[DiscountAmount] "
            + "    ,[dbo].[FactResellerSales].[ProductStandardCost] "
            + "    ,[dbo].[FactResellerSales].[TotalProductCost] "
            + "    ,[dbo].[FactResellerSales].[SalesAmount] "
            + "    ,[dbo].[FactResellerSales].[TaxAmt] "
            + "    ,[dbo].[FactResellerSales].[Freight] "
            + "    ,[dbo].[FactResellerSales].[CarrierTrackingNumber] "
            + "    ,[dbo].[FactResellerSales].[CustomerPONumber] "
            + "    ,[dbo].[FactResellerSales].[OrderDate] "
            + "    ,[dbo].[FactResellerSales].[DueDate] "
            + "    ,[dbo].[FactResellerSales].[ShipDate] "
            + "FROM " 
            + "     [dbo].[FactResellerSales] " 
            + "INNER JOIN [dbo].[DimProduct] as [A274] ON [dbo].[FactResellerSales].[ProductKey] = [A274].[ProductKey] "
            + "INNER JOIN [dbo].[DimDate] as [A275] ON [dbo].[FactResellerSales].[OrderDateKey] = [A275].[DateKey] "
            + "INNER JOIN [dbo].[DimDate] as [A276] ON [dbo].[FactResellerSales].[DueDateKey] = [A276].[DateKey] "
            + "INNER JOIN [dbo].[DimDate] as [A277] ON [dbo].[FactResellerSales].[ShipDateKey] = [A277].[DateKey] "
            + "INNER JOIN [dbo].[DimReseller] as [A278] ON [dbo].[FactResellerSales].[ResellerKey] = [A278].[ResellerKey] "
            + "INNER JOIN [dbo].[DimEmployee] as [A279] ON [dbo].[FactResellerSales].[EmployeeKey] = [A279].[EmployeeKey] "
            + "INNER JOIN [dbo].[DimPromotion] as [A280] ON [dbo].[FactResellerSales].[PromotionKey] = [A280].[PromotionKey] "
            + "INNER JOIN [dbo].[DimCurrency] as [A281] ON [dbo].[FactResellerSales].[CurrencyKey] = [A281].[CurrencyKey] "
            + "INNER JOIN [dbo].[DimSalesTerritory] as [A282] ON [dbo].[FactResellerSales].[SalesTerritoryKey] = [A282].[SalesTerritoryKey] "
                + "WHERE " 
                + "     (@SalesOrderNumber IS NULL OR @SalesOrderNumber = '' OR [FactResellerSales].[SalesOrderNumber] = LTRIM(RTRIM(@SalesOrderNumber))) " 
                + "AND   (@SalesOrderLineNumber IS NULL OR @SalesOrderLineNumber = '' OR [FactResellerSales].[SalesOrderLineNumber] = LTRIM(RTRIM(@SalesOrderLineNumber))) " 
                + "AND   (@ProductAlternateKey274 IS NULL OR @ProductAlternateKey274 = '' OR [A274].[ProductAlternateKey] = LTRIM(RTRIM(@ProductAlternateKey274))) " 
                + "AND   (@DateKey275 IS NULL OR @DateKey275 = '' OR [A275].[DateKey] = LTRIM(RTRIM(@DateKey275))) " 
                + "AND   (@DateKey276 IS NULL OR @DateKey276 = '' OR [A276].[DateKey] = LTRIM(RTRIM(@DateKey276))) " 
                + "AND   (@DateKey277 IS NULL OR @DateKey277 = '' OR [A277].[DateKey] = LTRIM(RTRIM(@DateKey277))) " 
                + "AND   (@ResellerKey278 IS NULL OR @ResellerKey278 = '' OR [A278].[ResellerKey] = LTRIM(RTRIM(@ResellerKey278))) " 
                + "AND   (@EmployeeKey279 IS NULL OR @EmployeeKey279 = '' OR [A279].[EmployeeKey] = LTRIM(RTRIM(@EmployeeKey279))) " 
                + "AND   (@PromotionKey280 IS NULL OR @PromotionKey280 = '' OR [A280].[PromotionKey] = LTRIM(RTRIM(@PromotionKey280))) " 
                + "AND   (@CurrencyKey281 IS NULL OR @CurrencyKey281 = '' OR [A281].[CurrencyKey] = LTRIM(RTRIM(@CurrencyKey281))) " 
                + "AND   (@SalesTerritoryKey282 IS NULL OR @SalesTerritoryKey282 = '' OR [A282].[SalesTerritoryKey] = LTRIM(RTRIM(@SalesTerritoryKey282))) " 
                + "AND   (@RevisionNumber IS NULL OR @RevisionNumber = '' OR [FactResellerSales].[RevisionNumber] = LTRIM(RTRIM(@RevisionNumber))) " 
                + "AND   (@OrderQuantity IS NULL OR @OrderQuantity = '' OR [FactResellerSales].[OrderQuantity] = LTRIM(RTRIM(@OrderQuantity))) " 
                + "AND   (@UnitPrice IS NULL OR @UnitPrice = '' OR [FactResellerSales].[UnitPrice] = LTRIM(RTRIM(@UnitPrice))) " 
                + "AND   (@ExtendedAmount IS NULL OR @ExtendedAmount = '' OR [FactResellerSales].[ExtendedAmount] = LTRIM(RTRIM(@ExtendedAmount))) " 
                + "AND   (@UnitPriceDiscountPct IS NULL OR @UnitPriceDiscountPct = '' OR [FactResellerSales].[UnitPriceDiscountPct] = LTRIM(RTRIM(@UnitPriceDiscountPct))) " 
                + "AND   (@DiscountAmount IS NULL OR @DiscountAmount = '' OR [FactResellerSales].[DiscountAmount] = LTRIM(RTRIM(@DiscountAmount))) " 
                + "AND   (@ProductStandardCost IS NULL OR @ProductStandardCost = '' OR [FactResellerSales].[ProductStandardCost] = LTRIM(RTRIM(@ProductStandardCost))) " 
                + "AND   (@TotalProductCost IS NULL OR @TotalProductCost = '' OR [FactResellerSales].[TotalProductCost] = LTRIM(RTRIM(@TotalProductCost))) " 
                + "AND   (@SalesAmount IS NULL OR @SalesAmount = '' OR [FactResellerSales].[SalesAmount] = LTRIM(RTRIM(@SalesAmount))) " 
                + "AND   (@TaxAmt IS NULL OR @TaxAmt = '' OR [FactResellerSales].[TaxAmt] = LTRIM(RTRIM(@TaxAmt))) " 
                + "AND   (@Freight IS NULL OR @Freight = '' OR [FactResellerSales].[Freight] = LTRIM(RTRIM(@Freight))) " 
                + "AND   (@CarrierTrackingNumber IS NULL OR @CarrierTrackingNumber = '' OR [FactResellerSales].[CarrierTrackingNumber] = LTRIM(RTRIM(@CarrierTrackingNumber))) " 
                + "AND   (@CustomerPONumber IS NULL OR @CustomerPONumber = '' OR [FactResellerSales].[CustomerPONumber] = LTRIM(RTRIM(@CustomerPONumber))) " 
                + "AND   (@OrderDate IS NULL OR @OrderDate = '' OR [FactResellerSales].[OrderDate] = LTRIM(RTRIM(@OrderDate))) " 
                + "AND   (@DueDate IS NULL OR @DueDate = '' OR [FactResellerSales].[DueDate] = LTRIM(RTRIM(@DueDate))) " 
                + "AND   (@ShipDate IS NULL OR @ShipDate = '' OR [FactResellerSales].[ShipDate] = LTRIM(RTRIM(@ShipDate))) " 
                + "";
        } else if  (sCondition == "Starts with...") {
            selectStatement
                = "SELECT "
            + "     [dbo].[FactResellerSales].[SalesOrderNumber] "
            + "    ,[dbo].[FactResellerSales].[SalesOrderLineNumber] "
            + "    ,[A274].[ProductAlternateKey]"
            + "    ,[A275].[DateKey]"
            + "    ,[A276].[DateKey]"
            + "    ,[A277].[DateKey]"
            + "    ,[A278].[ResellerKey]"
            + "    ,[A279].[EmployeeKey]"
            + "    ,[A280].[PromotionKey]"
            + "    ,[A281].[CurrencyKey]"
            + "    ,[A282].[SalesTerritoryKey]"
            + "    ,[dbo].[FactResellerSales].[RevisionNumber] "
            + "    ,[dbo].[FactResellerSales].[OrderQuantity] "
            + "    ,[dbo].[FactResellerSales].[UnitPrice] "
            + "    ,[dbo].[FactResellerSales].[ExtendedAmount] "
            + "    ,[dbo].[FactResellerSales].[UnitPriceDiscountPct] "
            + "    ,[dbo].[FactResellerSales].[DiscountAmount] "
            + "    ,[dbo].[FactResellerSales].[ProductStandardCost] "
            + "    ,[dbo].[FactResellerSales].[TotalProductCost] "
            + "    ,[dbo].[FactResellerSales].[SalesAmount] "
            + "    ,[dbo].[FactResellerSales].[TaxAmt] "
            + "    ,[dbo].[FactResellerSales].[Freight] "
            + "    ,[dbo].[FactResellerSales].[CarrierTrackingNumber] "
            + "    ,[dbo].[FactResellerSales].[CustomerPONumber] "
            + "    ,[dbo].[FactResellerSales].[OrderDate] "
            + "    ,[dbo].[FactResellerSales].[DueDate] "
            + "    ,[dbo].[FactResellerSales].[ShipDate] "
            + "FROM " 
            + "     [dbo].[FactResellerSales] " 
            + "INNER JOIN [dbo].[DimProduct] as [A274] ON [dbo].[FactResellerSales].[ProductKey] = [A274].[ProductKey] "
            + "INNER JOIN [dbo].[DimDate] as [A275] ON [dbo].[FactResellerSales].[OrderDateKey] = [A275].[DateKey] "
            + "INNER JOIN [dbo].[DimDate] as [A276] ON [dbo].[FactResellerSales].[DueDateKey] = [A276].[DateKey] "
            + "INNER JOIN [dbo].[DimDate] as [A277] ON [dbo].[FactResellerSales].[ShipDateKey] = [A277].[DateKey] "
            + "INNER JOIN [dbo].[DimReseller] as [A278] ON [dbo].[FactResellerSales].[ResellerKey] = [A278].[ResellerKey] "
            + "INNER JOIN [dbo].[DimEmployee] as [A279] ON [dbo].[FactResellerSales].[EmployeeKey] = [A279].[EmployeeKey] "
            + "INNER JOIN [dbo].[DimPromotion] as [A280] ON [dbo].[FactResellerSales].[PromotionKey] = [A280].[PromotionKey] "
            + "INNER JOIN [dbo].[DimCurrency] as [A281] ON [dbo].[FactResellerSales].[CurrencyKey] = [A281].[CurrencyKey] "
            + "INNER JOIN [dbo].[DimSalesTerritory] as [A282] ON [dbo].[FactResellerSales].[SalesTerritoryKey] = [A282].[SalesTerritoryKey] "
                + "WHERE " 
                + "     (@SalesOrderNumber IS NULL OR @SalesOrderNumber = '' OR [FactResellerSales].[SalesOrderNumber] LIKE LTRIM(RTRIM(@SalesOrderNumber)) + '%') " 
                + "AND   (@SalesOrderLineNumber IS NULL OR @SalesOrderLineNumber = '' OR [FactResellerSales].[SalesOrderLineNumber] LIKE LTRIM(RTRIM(@SalesOrderLineNumber)) + '%') " 
                + "AND   (@ProductAlternateKey274 IS NULL OR @ProductAlternateKey274 = '' OR [A274].[ProductAlternateKey] LIKE LTRIM(RTRIM(@ProductAlternateKey274)) + '%') " 
                + "AND   (@DateKey275 IS NULL OR @DateKey275 = '' OR [A275].[DateKey] LIKE LTRIM(RTRIM(@DateKey275)) + '%') " 
                + "AND   (@DateKey276 IS NULL OR @DateKey276 = '' OR [A276].[DateKey] LIKE LTRIM(RTRIM(@DateKey276)) + '%') " 
                + "AND   (@DateKey277 IS NULL OR @DateKey277 = '' OR [A277].[DateKey] LIKE LTRIM(RTRIM(@DateKey277)) + '%') " 
                + "AND   (@ResellerKey278 IS NULL OR @ResellerKey278 = '' OR [A278].[ResellerKey] LIKE LTRIM(RTRIM(@ResellerKey278)) + '%') " 
                + "AND   (@EmployeeKey279 IS NULL OR @EmployeeKey279 = '' OR [A279].[EmployeeKey] LIKE LTRIM(RTRIM(@EmployeeKey279)) + '%') " 
                + "AND   (@PromotionKey280 IS NULL OR @PromotionKey280 = '' OR [A280].[PromotionKey] LIKE LTRIM(RTRIM(@PromotionKey280)) + '%') " 
                + "AND   (@CurrencyKey281 IS NULL OR @CurrencyKey281 = '' OR [A281].[CurrencyKey] LIKE LTRIM(RTRIM(@CurrencyKey281)) + '%') " 
                + "AND   (@SalesTerritoryKey282 IS NULL OR @SalesTerritoryKey282 = '' OR [A282].[SalesTerritoryKey] LIKE LTRIM(RTRIM(@SalesTerritoryKey282)) + '%') " 
                + "AND   (@RevisionNumber IS NULL OR @RevisionNumber = '' OR [FactResellerSales].[RevisionNumber] LIKE LTRIM(RTRIM(@RevisionNumber)) + '%') " 
                + "AND   (@OrderQuantity IS NULL OR @OrderQuantity = '' OR [FactResellerSales].[OrderQuantity] LIKE LTRIM(RTRIM(@OrderQuantity)) + '%') " 
                + "AND   (@UnitPrice IS NULL OR @UnitPrice = '' OR [FactResellerSales].[UnitPrice] LIKE LTRIM(RTRIM(@UnitPrice)) + '%') " 
                + "AND   (@ExtendedAmount IS NULL OR @ExtendedAmount = '' OR [FactResellerSales].[ExtendedAmount] LIKE LTRIM(RTRIM(@ExtendedAmount)) + '%') " 
                + "AND   (@UnitPriceDiscountPct IS NULL OR @UnitPriceDiscountPct = '' OR [FactResellerSales].[UnitPriceDiscountPct] LIKE LTRIM(RTRIM(@UnitPriceDiscountPct)) + '%') " 
                + "AND   (@DiscountAmount IS NULL OR @DiscountAmount = '' OR [FactResellerSales].[DiscountAmount] LIKE LTRIM(RTRIM(@DiscountAmount)) + '%') " 
                + "AND   (@ProductStandardCost IS NULL OR @ProductStandardCost = '' OR [FactResellerSales].[ProductStandardCost] LIKE LTRIM(RTRIM(@ProductStandardCost)) + '%') " 
                + "AND   (@TotalProductCost IS NULL OR @TotalProductCost = '' OR [FactResellerSales].[TotalProductCost] LIKE LTRIM(RTRIM(@TotalProductCost)) + '%') " 
                + "AND   (@SalesAmount IS NULL OR @SalesAmount = '' OR [FactResellerSales].[SalesAmount] LIKE LTRIM(RTRIM(@SalesAmount)) + '%') " 
                + "AND   (@TaxAmt IS NULL OR @TaxAmt = '' OR [FactResellerSales].[TaxAmt] LIKE LTRIM(RTRIM(@TaxAmt)) + '%') " 
                + "AND   (@Freight IS NULL OR @Freight = '' OR [FactResellerSales].[Freight] LIKE LTRIM(RTRIM(@Freight)) + '%') " 
                + "AND   (@CarrierTrackingNumber IS NULL OR @CarrierTrackingNumber = '' OR [FactResellerSales].[CarrierTrackingNumber] LIKE LTRIM(RTRIM(@CarrierTrackingNumber)) + '%') " 
                + "AND   (@CustomerPONumber IS NULL OR @CustomerPONumber = '' OR [FactResellerSales].[CustomerPONumber] LIKE LTRIM(RTRIM(@CustomerPONumber)) + '%') " 
                + "AND   (@OrderDate IS NULL OR @OrderDate = '' OR [FactResellerSales].[OrderDate] LIKE LTRIM(RTRIM(@OrderDate)) + '%') " 
                + "AND   (@DueDate IS NULL OR @DueDate = '' OR [FactResellerSales].[DueDate] LIKE LTRIM(RTRIM(@DueDate)) + '%') " 
                + "AND   (@ShipDate IS NULL OR @ShipDate = '' OR [FactResellerSales].[ShipDate] LIKE LTRIM(RTRIM(@ShipDate)) + '%') " 
                + "";
        } else if  (sCondition == "More than...") {
            selectStatement
                = "SELECT "
            + "     [dbo].[FactResellerSales].[SalesOrderNumber] "
            + "    ,[dbo].[FactResellerSales].[SalesOrderLineNumber] "
            + "    ,[A274].[ProductAlternateKey]"
            + "    ,[A275].[DateKey]"
            + "    ,[A276].[DateKey]"
            + "    ,[A277].[DateKey]"
            + "    ,[A278].[ResellerKey]"
            + "    ,[A279].[EmployeeKey]"
            + "    ,[A280].[PromotionKey]"
            + "    ,[A281].[CurrencyKey]"
            + "    ,[A282].[SalesTerritoryKey]"
            + "    ,[dbo].[FactResellerSales].[RevisionNumber] "
            + "    ,[dbo].[FactResellerSales].[OrderQuantity] "
            + "    ,[dbo].[FactResellerSales].[UnitPrice] "
            + "    ,[dbo].[FactResellerSales].[ExtendedAmount] "
            + "    ,[dbo].[FactResellerSales].[UnitPriceDiscountPct] "
            + "    ,[dbo].[FactResellerSales].[DiscountAmount] "
            + "    ,[dbo].[FactResellerSales].[ProductStandardCost] "
            + "    ,[dbo].[FactResellerSales].[TotalProductCost] "
            + "    ,[dbo].[FactResellerSales].[SalesAmount] "
            + "    ,[dbo].[FactResellerSales].[TaxAmt] "
            + "    ,[dbo].[FactResellerSales].[Freight] "
            + "    ,[dbo].[FactResellerSales].[CarrierTrackingNumber] "
            + "    ,[dbo].[FactResellerSales].[CustomerPONumber] "
            + "    ,[dbo].[FactResellerSales].[OrderDate] "
            + "    ,[dbo].[FactResellerSales].[DueDate] "
            + "    ,[dbo].[FactResellerSales].[ShipDate] "
            + "FROM " 
            + "     [dbo].[FactResellerSales] " 
            + "INNER JOIN [dbo].[DimProduct] as [A274] ON [dbo].[FactResellerSales].[ProductKey] = [A274].[ProductKey] "
            + "INNER JOIN [dbo].[DimDate] as [A275] ON [dbo].[FactResellerSales].[OrderDateKey] = [A275].[DateKey] "
            + "INNER JOIN [dbo].[DimDate] as [A276] ON [dbo].[FactResellerSales].[DueDateKey] = [A276].[DateKey] "
            + "INNER JOIN [dbo].[DimDate] as [A277] ON [dbo].[FactResellerSales].[ShipDateKey] = [A277].[DateKey] "
            + "INNER JOIN [dbo].[DimReseller] as [A278] ON [dbo].[FactResellerSales].[ResellerKey] = [A278].[ResellerKey] "
            + "INNER JOIN [dbo].[DimEmployee] as [A279] ON [dbo].[FactResellerSales].[EmployeeKey] = [A279].[EmployeeKey] "
            + "INNER JOIN [dbo].[DimPromotion] as [A280] ON [dbo].[FactResellerSales].[PromotionKey] = [A280].[PromotionKey] "
            + "INNER JOIN [dbo].[DimCurrency] as [A281] ON [dbo].[FactResellerSales].[CurrencyKey] = [A281].[CurrencyKey] "
            + "INNER JOIN [dbo].[DimSalesTerritory] as [A282] ON [dbo].[FactResellerSales].[SalesTerritoryKey] = [A282].[SalesTerritoryKey] "
                + "WHERE " 
                + "     (@SalesOrderNumber IS NULL OR @SalesOrderNumber = '' OR [FactResellerSales].[SalesOrderNumber] > LTRIM(RTRIM(@SalesOrderNumber))) " 
                + "AND   (@SalesOrderLineNumber IS NULL OR @SalesOrderLineNumber = '' OR [FactResellerSales].[SalesOrderLineNumber] > LTRIM(RTRIM(@SalesOrderLineNumber))) " 
                + "AND   (@ProductAlternateKey274 IS NULL OR @ProductAlternateKey274 = '' OR [A274].[ProductAlternateKey] > LTRIM(RTRIM(@ProductAlternateKey274))) " 
                + "AND   (@DateKey275 IS NULL OR @DateKey275 = '' OR [A275].[DateKey] > LTRIM(RTRIM(@DateKey275))) " 
                + "AND   (@DateKey276 IS NULL OR @DateKey276 = '' OR [A276].[DateKey] > LTRIM(RTRIM(@DateKey276))) " 
                + "AND   (@DateKey277 IS NULL OR @DateKey277 = '' OR [A277].[DateKey] > LTRIM(RTRIM(@DateKey277))) " 
                + "AND   (@ResellerKey278 IS NULL OR @ResellerKey278 = '' OR [A278].[ResellerKey] > LTRIM(RTRIM(@ResellerKey278))) " 
                + "AND   (@EmployeeKey279 IS NULL OR @EmployeeKey279 = '' OR [A279].[EmployeeKey] > LTRIM(RTRIM(@EmployeeKey279))) " 
                + "AND   (@PromotionKey280 IS NULL OR @PromotionKey280 = '' OR [A280].[PromotionKey] > LTRIM(RTRIM(@PromotionKey280))) " 
                + "AND   (@CurrencyKey281 IS NULL OR @CurrencyKey281 = '' OR [A281].[CurrencyKey] > LTRIM(RTRIM(@CurrencyKey281))) " 
                + "AND   (@SalesTerritoryKey282 IS NULL OR @SalesTerritoryKey282 = '' OR [A282].[SalesTerritoryKey] > LTRIM(RTRIM(@SalesTerritoryKey282))) " 
                + "AND   (@RevisionNumber IS NULL OR @RevisionNumber = '' OR [FactResellerSales].[RevisionNumber] > LTRIM(RTRIM(@RevisionNumber))) " 
                + "AND   (@OrderQuantity IS NULL OR @OrderQuantity = '' OR [FactResellerSales].[OrderQuantity] > LTRIM(RTRIM(@OrderQuantity))) " 
                + "AND   (@UnitPrice IS NULL OR @UnitPrice = '' OR [FactResellerSales].[UnitPrice] > LTRIM(RTRIM(@UnitPrice))) " 
                + "AND   (@ExtendedAmount IS NULL OR @ExtendedAmount = '' OR [FactResellerSales].[ExtendedAmount] > LTRIM(RTRIM(@ExtendedAmount))) " 
                + "AND   (@UnitPriceDiscountPct IS NULL OR @UnitPriceDiscountPct = '' OR [FactResellerSales].[UnitPriceDiscountPct] > LTRIM(RTRIM(@UnitPriceDiscountPct))) " 
                + "AND   (@DiscountAmount IS NULL OR @DiscountAmount = '' OR [FactResellerSales].[DiscountAmount] > LTRIM(RTRIM(@DiscountAmount))) " 
                + "AND   (@ProductStandardCost IS NULL OR @ProductStandardCost = '' OR [FactResellerSales].[ProductStandardCost] > LTRIM(RTRIM(@ProductStandardCost))) " 
                + "AND   (@TotalProductCost IS NULL OR @TotalProductCost = '' OR [FactResellerSales].[TotalProductCost] > LTRIM(RTRIM(@TotalProductCost))) " 
                + "AND   (@SalesAmount IS NULL OR @SalesAmount = '' OR [FactResellerSales].[SalesAmount] > LTRIM(RTRIM(@SalesAmount))) " 
                + "AND   (@TaxAmt IS NULL OR @TaxAmt = '' OR [FactResellerSales].[TaxAmt] > LTRIM(RTRIM(@TaxAmt))) " 
                + "AND   (@Freight IS NULL OR @Freight = '' OR [FactResellerSales].[Freight] > LTRIM(RTRIM(@Freight))) " 
                + "AND   (@CarrierTrackingNumber IS NULL OR @CarrierTrackingNumber = '' OR [FactResellerSales].[CarrierTrackingNumber] > LTRIM(RTRIM(@CarrierTrackingNumber))) " 
                + "AND   (@CustomerPONumber IS NULL OR @CustomerPONumber = '' OR [FactResellerSales].[CustomerPONumber] > LTRIM(RTRIM(@CustomerPONumber))) " 
                + "AND   (@OrderDate IS NULL OR @OrderDate = '' OR [FactResellerSales].[OrderDate] > LTRIM(RTRIM(@OrderDate))) " 
                + "AND   (@DueDate IS NULL OR @DueDate = '' OR [FactResellerSales].[DueDate] > LTRIM(RTRIM(@DueDate))) " 
                + "AND   (@ShipDate IS NULL OR @ShipDate = '' OR [FactResellerSales].[ShipDate] > LTRIM(RTRIM(@ShipDate))) " 
                + "";
        } else if  (sCondition == "Less than...") {
            selectStatement
                = "SELECT " 
            + "     [dbo].[FactResellerSales].[SalesOrderNumber] "
            + "    ,[dbo].[FactResellerSales].[SalesOrderLineNumber] "
            + "    ,[A274].[ProductAlternateKey]"
            + "    ,[A275].[DateKey]"
            + "    ,[A276].[DateKey]"
            + "    ,[A277].[DateKey]"
            + "    ,[A278].[ResellerKey]"
            + "    ,[A279].[EmployeeKey]"
            + "    ,[A280].[PromotionKey]"
            + "    ,[A281].[CurrencyKey]"
            + "    ,[A282].[SalesTerritoryKey]"
            + "    ,[dbo].[FactResellerSales].[RevisionNumber] "
            + "    ,[dbo].[FactResellerSales].[OrderQuantity] "
            + "    ,[dbo].[FactResellerSales].[UnitPrice] "
            + "    ,[dbo].[FactResellerSales].[ExtendedAmount] "
            + "    ,[dbo].[FactResellerSales].[UnitPriceDiscountPct] "
            + "    ,[dbo].[FactResellerSales].[DiscountAmount] "
            + "    ,[dbo].[FactResellerSales].[ProductStandardCost] "
            + "    ,[dbo].[FactResellerSales].[TotalProductCost] "
            + "    ,[dbo].[FactResellerSales].[SalesAmount] "
            + "    ,[dbo].[FactResellerSales].[TaxAmt] "
            + "    ,[dbo].[FactResellerSales].[Freight] "
            + "    ,[dbo].[FactResellerSales].[CarrierTrackingNumber] "
            + "    ,[dbo].[FactResellerSales].[CustomerPONumber] "
            + "    ,[dbo].[FactResellerSales].[OrderDate] "
            + "    ,[dbo].[FactResellerSales].[DueDate] "
            + "    ,[dbo].[FactResellerSales].[ShipDate] "
            + "FROM " 
            + "     [dbo].[FactResellerSales] " 
            + "INNER JOIN [dbo].[DimProduct] as [A274] ON [dbo].[FactResellerSales].[ProductKey] = [A274].[ProductKey] "
            + "INNER JOIN [dbo].[DimDate] as [A275] ON [dbo].[FactResellerSales].[OrderDateKey] = [A275].[DateKey] "
            + "INNER JOIN [dbo].[DimDate] as [A276] ON [dbo].[FactResellerSales].[DueDateKey] = [A276].[DateKey] "
            + "INNER JOIN [dbo].[DimDate] as [A277] ON [dbo].[FactResellerSales].[ShipDateKey] = [A277].[DateKey] "
            + "INNER JOIN [dbo].[DimReseller] as [A278] ON [dbo].[FactResellerSales].[ResellerKey] = [A278].[ResellerKey] "
            + "INNER JOIN [dbo].[DimEmployee] as [A279] ON [dbo].[FactResellerSales].[EmployeeKey] = [A279].[EmployeeKey] "
            + "INNER JOIN [dbo].[DimPromotion] as [A280] ON [dbo].[FactResellerSales].[PromotionKey] = [A280].[PromotionKey] "
            + "INNER JOIN [dbo].[DimCurrency] as [A281] ON [dbo].[FactResellerSales].[CurrencyKey] = [A281].[CurrencyKey] "
            + "INNER JOIN [dbo].[DimSalesTerritory] as [A282] ON [dbo].[FactResellerSales].[SalesTerritoryKey] = [A282].[SalesTerritoryKey] "
                + "WHERE " 
                + "     (@SalesOrderNumber IS NULL OR @SalesOrderNumber = '' OR [FactResellerSales].[SalesOrderNumber] < LTRIM(RTRIM(@SalesOrderNumber))) " 
                + "AND   (@SalesOrderLineNumber IS NULL OR @SalesOrderLineNumber = '' OR [FactResellerSales].[SalesOrderLineNumber] < LTRIM(RTRIM(@SalesOrderLineNumber))) " 
                + "AND   (@ProductAlternateKey274 IS NULL OR @ProductAlternateKey274 = '' OR [A274].[ProductAlternateKey] < LTRIM(RTRIM(@ProductAlternateKey274))) " 
                + "AND   (@DateKey275 IS NULL OR @DateKey275 = '' OR [A275].[DateKey] < LTRIM(RTRIM(@DateKey275))) " 
                + "AND   (@DateKey276 IS NULL OR @DateKey276 = '' OR [A276].[DateKey] < LTRIM(RTRIM(@DateKey276))) " 
                + "AND   (@DateKey277 IS NULL OR @DateKey277 = '' OR [A277].[DateKey] < LTRIM(RTRIM(@DateKey277))) " 
                + "AND   (@ResellerKey278 IS NULL OR @ResellerKey278 = '' OR [A278].[ResellerKey] < LTRIM(RTRIM(@ResellerKey278))) " 
                + "AND   (@EmployeeKey279 IS NULL OR @EmployeeKey279 = '' OR [A279].[EmployeeKey] < LTRIM(RTRIM(@EmployeeKey279))) " 
                + "AND   (@PromotionKey280 IS NULL OR @PromotionKey280 = '' OR [A280].[PromotionKey] < LTRIM(RTRIM(@PromotionKey280))) " 
                + "AND   (@CurrencyKey281 IS NULL OR @CurrencyKey281 = '' OR [A281].[CurrencyKey] < LTRIM(RTRIM(@CurrencyKey281))) " 
                + "AND   (@SalesTerritoryKey282 IS NULL OR @SalesTerritoryKey282 = '' OR [A282].[SalesTerritoryKey] < LTRIM(RTRIM(@SalesTerritoryKey282))) " 
                + "AND   (@RevisionNumber IS NULL OR @RevisionNumber = '' OR [FactResellerSales].[RevisionNumber] < LTRIM(RTRIM(@RevisionNumber))) " 
                + "AND   (@OrderQuantity IS NULL OR @OrderQuantity = '' OR [FactResellerSales].[OrderQuantity] < LTRIM(RTRIM(@OrderQuantity))) " 
                + "AND   (@UnitPrice IS NULL OR @UnitPrice = '' OR [FactResellerSales].[UnitPrice] < LTRIM(RTRIM(@UnitPrice))) " 
                + "AND   (@ExtendedAmount IS NULL OR @ExtendedAmount = '' OR [FactResellerSales].[ExtendedAmount] < LTRIM(RTRIM(@ExtendedAmount))) " 
                + "AND   (@UnitPriceDiscountPct IS NULL OR @UnitPriceDiscountPct = '' OR [FactResellerSales].[UnitPriceDiscountPct] < LTRIM(RTRIM(@UnitPriceDiscountPct))) " 
                + "AND   (@DiscountAmount IS NULL OR @DiscountAmount = '' OR [FactResellerSales].[DiscountAmount] < LTRIM(RTRIM(@DiscountAmount))) " 
                + "AND   (@ProductStandardCost IS NULL OR @ProductStandardCost = '' OR [FactResellerSales].[ProductStandardCost] < LTRIM(RTRIM(@ProductStandardCost))) " 
                + "AND   (@TotalProductCost IS NULL OR @TotalProductCost = '' OR [FactResellerSales].[TotalProductCost] < LTRIM(RTRIM(@TotalProductCost))) " 
                + "AND   (@SalesAmount IS NULL OR @SalesAmount = '' OR [FactResellerSales].[SalesAmount] < LTRIM(RTRIM(@SalesAmount))) " 
                + "AND   (@TaxAmt IS NULL OR @TaxAmt = '' OR [FactResellerSales].[TaxAmt] < LTRIM(RTRIM(@TaxAmt))) " 
                + "AND   (@Freight IS NULL OR @Freight = '' OR [FactResellerSales].[Freight] < LTRIM(RTRIM(@Freight))) " 
                + "AND   (@CarrierTrackingNumber IS NULL OR @CarrierTrackingNumber = '' OR [FactResellerSales].[CarrierTrackingNumber] < LTRIM(RTRIM(@CarrierTrackingNumber))) " 
                + "AND   (@CustomerPONumber IS NULL OR @CustomerPONumber = '' OR [FactResellerSales].[CustomerPONumber] < LTRIM(RTRIM(@CustomerPONumber))) " 
                + "AND   (@OrderDate IS NULL OR @OrderDate = '' OR [FactResellerSales].[OrderDate] < LTRIM(RTRIM(@OrderDate))) " 
                + "AND   (@DueDate IS NULL OR @DueDate = '' OR [FactResellerSales].[DueDate] < LTRIM(RTRIM(@DueDate))) " 
                + "AND   (@ShipDate IS NULL OR @ShipDate = '' OR [FactResellerSales].[ShipDate] < LTRIM(RTRIM(@ShipDate))) " 
                + "";
        } else if  (sCondition == "Equal or more than...") {
            selectStatement
                = "SELECT "
            + "     [dbo].[FactResellerSales].[SalesOrderNumber] "
            + "    ,[dbo].[FactResellerSales].[SalesOrderLineNumber] "
            + "    ,[A274].[ProductAlternateKey]"
            + "    ,[A275].[DateKey]"
            + "    ,[A276].[DateKey]"
            + "    ,[A277].[DateKey]"
            + "    ,[A278].[ResellerKey]"
            + "    ,[A279].[EmployeeKey]"
            + "    ,[A280].[PromotionKey]"
            + "    ,[A281].[CurrencyKey]"
            + "    ,[A282].[SalesTerritoryKey]"
            + "    ,[dbo].[FactResellerSales].[RevisionNumber] "
            + "    ,[dbo].[FactResellerSales].[OrderQuantity] "
            + "    ,[dbo].[FactResellerSales].[UnitPrice] "
            + "    ,[dbo].[FactResellerSales].[ExtendedAmount] "
            + "    ,[dbo].[FactResellerSales].[UnitPriceDiscountPct] "
            + "    ,[dbo].[FactResellerSales].[DiscountAmount] "
            + "    ,[dbo].[FactResellerSales].[ProductStandardCost] "
            + "    ,[dbo].[FactResellerSales].[TotalProductCost] "
            + "    ,[dbo].[FactResellerSales].[SalesAmount] "
            + "    ,[dbo].[FactResellerSales].[TaxAmt] "
            + "    ,[dbo].[FactResellerSales].[Freight] "
            + "    ,[dbo].[FactResellerSales].[CarrierTrackingNumber] "
            + "    ,[dbo].[FactResellerSales].[CustomerPONumber] "
            + "    ,[dbo].[FactResellerSales].[OrderDate] "
            + "    ,[dbo].[FactResellerSales].[DueDate] "
            + "    ,[dbo].[FactResellerSales].[ShipDate] "
            + "FROM " 
            + "     [dbo].[FactResellerSales] " 
            + "INNER JOIN [dbo].[DimProduct] as [A274] ON [dbo].[FactResellerSales].[ProductKey] = [A274].[ProductKey] "
            + "INNER JOIN [dbo].[DimDate] as [A275] ON [dbo].[FactResellerSales].[OrderDateKey] = [A275].[DateKey] "
            + "INNER JOIN [dbo].[DimDate] as [A276] ON [dbo].[FactResellerSales].[DueDateKey] = [A276].[DateKey] "
            + "INNER JOIN [dbo].[DimDate] as [A277] ON [dbo].[FactResellerSales].[ShipDateKey] = [A277].[DateKey] "
            + "INNER JOIN [dbo].[DimReseller] as [A278] ON [dbo].[FactResellerSales].[ResellerKey] = [A278].[ResellerKey] "
            + "INNER JOIN [dbo].[DimEmployee] as [A279] ON [dbo].[FactResellerSales].[EmployeeKey] = [A279].[EmployeeKey] "
            + "INNER JOIN [dbo].[DimPromotion] as [A280] ON [dbo].[FactResellerSales].[PromotionKey] = [A280].[PromotionKey] "
            + "INNER JOIN [dbo].[DimCurrency] as [A281] ON [dbo].[FactResellerSales].[CurrencyKey] = [A281].[CurrencyKey] "
            + "INNER JOIN [dbo].[DimSalesTerritory] as [A282] ON [dbo].[FactResellerSales].[SalesTerritoryKey] = [A282].[SalesTerritoryKey] "
                + "WHERE " 
                + "     (@SalesOrderNumber IS NULL OR @SalesOrderNumber = '' OR [FactResellerSales].[SalesOrderNumber] >= LTRIM(RTRIM(@SalesOrderNumber))) " 
                + "AND   (@SalesOrderLineNumber IS NULL OR @SalesOrderLineNumber = '' OR [FactResellerSales].[SalesOrderLineNumber] >= LTRIM(RTRIM(@SalesOrderLineNumber))) " 
                + "AND   (@ProductAlternateKey274 IS NULL OR @ProductAlternateKey274 = '' OR [A274].[ProductAlternateKey] >= LTRIM(RTRIM(@ProductAlternateKey274))) " 
                + "AND   (@DateKey275 IS NULL OR @DateKey275 = '' OR [A275].[DateKey] >= LTRIM(RTRIM(@DateKey275))) " 
                + "AND   (@DateKey276 IS NULL OR @DateKey276 = '' OR [A276].[DateKey] >= LTRIM(RTRIM(@DateKey276))) " 
                + "AND   (@DateKey277 IS NULL OR @DateKey277 = '' OR [A277].[DateKey] >= LTRIM(RTRIM(@DateKey277))) " 
                + "AND   (@ResellerKey278 IS NULL OR @ResellerKey278 = '' OR [A278].[ResellerKey] >= LTRIM(RTRIM(@ResellerKey278))) " 
                + "AND   (@EmployeeKey279 IS NULL OR @EmployeeKey279 = '' OR [A279].[EmployeeKey] >= LTRIM(RTRIM(@EmployeeKey279))) " 
                + "AND   (@PromotionKey280 IS NULL OR @PromotionKey280 = '' OR [A280].[PromotionKey] >= LTRIM(RTRIM(@PromotionKey280))) " 
                + "AND   (@CurrencyKey281 IS NULL OR @CurrencyKey281 = '' OR [A281].[CurrencyKey] >= LTRIM(RTRIM(@CurrencyKey281))) " 
                + "AND   (@SalesTerritoryKey282 IS NULL OR @SalesTerritoryKey282 = '' OR [A282].[SalesTerritoryKey] >= LTRIM(RTRIM(@SalesTerritoryKey282))) " 
                + "AND   (@RevisionNumber IS NULL OR @RevisionNumber = '' OR [FactResellerSales].[RevisionNumber] >= LTRIM(RTRIM(@RevisionNumber))) " 
                + "AND   (@OrderQuantity IS NULL OR @OrderQuantity = '' OR [FactResellerSales].[OrderQuantity] >= LTRIM(RTRIM(@OrderQuantity))) " 
                + "AND   (@UnitPrice IS NULL OR @UnitPrice = '' OR [FactResellerSales].[UnitPrice] >= LTRIM(RTRIM(@UnitPrice))) " 
                + "AND   (@ExtendedAmount IS NULL OR @ExtendedAmount = '' OR [FactResellerSales].[ExtendedAmount] >= LTRIM(RTRIM(@ExtendedAmount))) " 
                + "AND   (@UnitPriceDiscountPct IS NULL OR @UnitPriceDiscountPct = '' OR [FactResellerSales].[UnitPriceDiscountPct] >= LTRIM(RTRIM(@UnitPriceDiscountPct))) " 
                + "AND   (@DiscountAmount IS NULL OR @DiscountAmount = '' OR [FactResellerSales].[DiscountAmount] >= LTRIM(RTRIM(@DiscountAmount))) " 
                + "AND   (@ProductStandardCost IS NULL OR @ProductStandardCost = '' OR [FactResellerSales].[ProductStandardCost] >= LTRIM(RTRIM(@ProductStandardCost))) " 
                + "AND   (@TotalProductCost IS NULL OR @TotalProductCost = '' OR [FactResellerSales].[TotalProductCost] >= LTRIM(RTRIM(@TotalProductCost))) " 
                + "AND   (@SalesAmount IS NULL OR @SalesAmount = '' OR [FactResellerSales].[SalesAmount] >= LTRIM(RTRIM(@SalesAmount))) " 
                + "AND   (@TaxAmt IS NULL OR @TaxAmt = '' OR [FactResellerSales].[TaxAmt] >= LTRIM(RTRIM(@TaxAmt))) " 
                + "AND   (@Freight IS NULL OR @Freight = '' OR [FactResellerSales].[Freight] >= LTRIM(RTRIM(@Freight))) " 
                + "AND   (@CarrierTrackingNumber IS NULL OR @CarrierTrackingNumber = '' OR [FactResellerSales].[CarrierTrackingNumber] >= LTRIM(RTRIM(@CarrierTrackingNumber))) " 
                + "AND   (@CustomerPONumber IS NULL OR @CustomerPONumber = '' OR [FactResellerSales].[CustomerPONumber] >= LTRIM(RTRIM(@CustomerPONumber))) " 
                + "AND   (@OrderDate IS NULL OR @OrderDate = '' OR [FactResellerSales].[OrderDate] >= LTRIM(RTRIM(@OrderDate))) " 
                + "AND   (@DueDate IS NULL OR @DueDate = '' OR [FactResellerSales].[DueDate] >= LTRIM(RTRIM(@DueDate))) " 
                + "AND   (@ShipDate IS NULL OR @ShipDate = '' OR [FactResellerSales].[ShipDate] >= LTRIM(RTRIM(@ShipDate))) " 
                + "";
        } else if (sCondition == "Equal or less than...") {
            selectStatement 
                = "SELECT "
            + "     [dbo].[FactResellerSales].[SalesOrderNumber] "
            + "    ,[dbo].[FactResellerSales].[SalesOrderLineNumber] "
            + "    ,[A274].[ProductAlternateKey]"
            + "    ,[A275].[DateKey]"
            + "    ,[A276].[DateKey]"
            + "    ,[A277].[DateKey]"
            + "    ,[A278].[ResellerKey]"
            + "    ,[A279].[EmployeeKey]"
            + "    ,[A280].[PromotionKey]"
            + "    ,[A281].[CurrencyKey]"
            + "    ,[A282].[SalesTerritoryKey]"
            + "    ,[dbo].[FactResellerSales].[RevisionNumber] "
            + "    ,[dbo].[FactResellerSales].[OrderQuantity] "
            + "    ,[dbo].[FactResellerSales].[UnitPrice] "
            + "    ,[dbo].[FactResellerSales].[ExtendedAmount] "
            + "    ,[dbo].[FactResellerSales].[UnitPriceDiscountPct] "
            + "    ,[dbo].[FactResellerSales].[DiscountAmount] "
            + "    ,[dbo].[FactResellerSales].[ProductStandardCost] "
            + "    ,[dbo].[FactResellerSales].[TotalProductCost] "
            + "    ,[dbo].[FactResellerSales].[SalesAmount] "
            + "    ,[dbo].[FactResellerSales].[TaxAmt] "
            + "    ,[dbo].[FactResellerSales].[Freight] "
            + "    ,[dbo].[FactResellerSales].[CarrierTrackingNumber] "
            + "    ,[dbo].[FactResellerSales].[CustomerPONumber] "
            + "    ,[dbo].[FactResellerSales].[OrderDate] "
            + "    ,[dbo].[FactResellerSales].[DueDate] "
            + "    ,[dbo].[FactResellerSales].[ShipDate] "
            + "FROM " 
            + "     [dbo].[FactResellerSales] " 
            + "INNER JOIN [dbo].[DimProduct] as [A274] ON [dbo].[FactResellerSales].[ProductKey] = [A274].[ProductKey] "
            + "INNER JOIN [dbo].[DimDate] as [A275] ON [dbo].[FactResellerSales].[OrderDateKey] = [A275].[DateKey] "
            + "INNER JOIN [dbo].[DimDate] as [A276] ON [dbo].[FactResellerSales].[DueDateKey] = [A276].[DateKey] "
            + "INNER JOIN [dbo].[DimDate] as [A277] ON [dbo].[FactResellerSales].[ShipDateKey] = [A277].[DateKey] "
            + "INNER JOIN [dbo].[DimReseller] as [A278] ON [dbo].[FactResellerSales].[ResellerKey] = [A278].[ResellerKey] "
            + "INNER JOIN [dbo].[DimEmployee] as [A279] ON [dbo].[FactResellerSales].[EmployeeKey] = [A279].[EmployeeKey] "
            + "INNER JOIN [dbo].[DimPromotion] as [A280] ON [dbo].[FactResellerSales].[PromotionKey] = [A280].[PromotionKey] "
            + "INNER JOIN [dbo].[DimCurrency] as [A281] ON [dbo].[FactResellerSales].[CurrencyKey] = [A281].[CurrencyKey] "
            + "INNER JOIN [dbo].[DimSalesTerritory] as [A282] ON [dbo].[FactResellerSales].[SalesTerritoryKey] = [A282].[SalesTerritoryKey] "
                + "WHERE " 
                + "     (@SalesOrderNumber IS NULL OR @SalesOrderNumber = '' OR [FactResellerSales].[SalesOrderNumber] <= LTRIM(RTRIM(@SalesOrderNumber))) " 
                + "AND   (@SalesOrderLineNumber IS NULL OR @SalesOrderLineNumber = '' OR [FactResellerSales].[SalesOrderLineNumber] <= LTRIM(RTRIM(@SalesOrderLineNumber))) " 
                + "AND   (@ProductAlternateKey274 IS NULL OR @ProductAlternateKey274 = '' OR [A274].[ProductAlternateKey] <= LTRIM(RTRIM(@ProductAlternateKey274))) " 
                + "AND   (@DateKey275 IS NULL OR @DateKey275 = '' OR [A275].[DateKey] <= LTRIM(RTRIM(@DateKey275))) " 
                + "AND   (@DateKey276 IS NULL OR @DateKey276 = '' OR [A276].[DateKey] <= LTRIM(RTRIM(@DateKey276))) " 
                + "AND   (@DateKey277 IS NULL OR @DateKey277 = '' OR [A277].[DateKey] <= LTRIM(RTRIM(@DateKey277))) " 
                + "AND   (@ResellerKey278 IS NULL OR @ResellerKey278 = '' OR [A278].[ResellerKey] <= LTRIM(RTRIM(@ResellerKey278))) " 
                + "AND   (@EmployeeKey279 IS NULL OR @EmployeeKey279 = '' OR [A279].[EmployeeKey] <= LTRIM(RTRIM(@EmployeeKey279))) " 
                + "AND   (@PromotionKey280 IS NULL OR @PromotionKey280 = '' OR [A280].[PromotionKey] <= LTRIM(RTRIM(@PromotionKey280))) " 
                + "AND   (@CurrencyKey281 IS NULL OR @CurrencyKey281 = '' OR [A281].[CurrencyKey] <= LTRIM(RTRIM(@CurrencyKey281))) " 
                + "AND   (@SalesTerritoryKey282 IS NULL OR @SalesTerritoryKey282 = '' OR [A282].[SalesTerritoryKey] <= LTRIM(RTRIM(@SalesTerritoryKey282))) " 
                + "AND   (@RevisionNumber IS NULL OR @RevisionNumber = '' OR [FactResellerSales].[RevisionNumber] <= LTRIM(RTRIM(@RevisionNumber))) " 
                + "AND   (@OrderQuantity IS NULL OR @OrderQuantity = '' OR [FactResellerSales].[OrderQuantity] <= LTRIM(RTRIM(@OrderQuantity))) " 
                + "AND   (@UnitPrice IS NULL OR @UnitPrice = '' OR [FactResellerSales].[UnitPrice] <= LTRIM(RTRIM(@UnitPrice))) " 
                + "AND   (@ExtendedAmount IS NULL OR @ExtendedAmount = '' OR [FactResellerSales].[ExtendedAmount] <= LTRIM(RTRIM(@ExtendedAmount))) " 
                + "AND   (@UnitPriceDiscountPct IS NULL OR @UnitPriceDiscountPct = '' OR [FactResellerSales].[UnitPriceDiscountPct] <= LTRIM(RTRIM(@UnitPriceDiscountPct))) " 
                + "AND   (@DiscountAmount IS NULL OR @DiscountAmount = '' OR [FactResellerSales].[DiscountAmount] <= LTRIM(RTRIM(@DiscountAmount))) " 
                + "AND   (@ProductStandardCost IS NULL OR @ProductStandardCost = '' OR [FactResellerSales].[ProductStandardCost] <= LTRIM(RTRIM(@ProductStandardCost))) " 
                + "AND   (@TotalProductCost IS NULL OR @TotalProductCost = '' OR [FactResellerSales].[TotalProductCost] <= LTRIM(RTRIM(@TotalProductCost))) " 
                + "AND   (@SalesAmount IS NULL OR @SalesAmount = '' OR [FactResellerSales].[SalesAmount] <= LTRIM(RTRIM(@SalesAmount))) " 
                + "AND   (@TaxAmt IS NULL OR @TaxAmt = '' OR [FactResellerSales].[TaxAmt] <= LTRIM(RTRIM(@TaxAmt))) " 
                + "AND   (@Freight IS NULL OR @Freight = '' OR [FactResellerSales].[Freight] <= LTRIM(RTRIM(@Freight))) " 
                + "AND   (@CarrierTrackingNumber IS NULL OR @CarrierTrackingNumber = '' OR [FactResellerSales].[CarrierTrackingNumber] <= LTRIM(RTRIM(@CarrierTrackingNumber))) " 
                + "AND   (@CustomerPONumber IS NULL OR @CustomerPONumber = '' OR [FactResellerSales].[CustomerPONumber] <= LTRIM(RTRIM(@CustomerPONumber))) " 
                + "AND   (@OrderDate IS NULL OR @OrderDate = '' OR [FactResellerSales].[OrderDate] <= LTRIM(RTRIM(@OrderDate))) " 
                + "AND   (@DueDate IS NULL OR @DueDate = '' OR [FactResellerSales].[DueDate] <= LTRIM(RTRIM(@DueDate))) " 
                + "AND   (@ShipDate IS NULL OR @ShipDate = '' OR [FactResellerSales].[ShipDate] <= LTRIM(RTRIM(@ShipDate))) " 
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
            selectCommand.Parameters.AddWithValue("@ProductAlternateKey274", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@ProductAlternateKey274", DBNull.Value); }
        if (sField == "Order Date Key") {
            selectCommand.Parameters.AddWithValue("@DateKey275", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@DateKey275", DBNull.Value); }
        if (sField == "Due Date Key") {
            selectCommand.Parameters.AddWithValue("@DateKey276", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@DateKey276", DBNull.Value); }
        if (sField == "Ship Date Key") {
            selectCommand.Parameters.AddWithValue("@DateKey277", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@DateKey277", DBNull.Value); }
        if (sField == "Reseller Key") {
            selectCommand.Parameters.AddWithValue("@ResellerKey278", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@ResellerKey278", DBNull.Value); }
        if (sField == "Employee Key") {
            selectCommand.Parameters.AddWithValue("@EmployeeKey279", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@EmployeeKey279", DBNull.Value); }
        if (sField == "Promotion Key") {
            selectCommand.Parameters.AddWithValue("@PromotionKey280", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@PromotionKey280", DBNull.Value); }
        if (sField == "Currency Key") {
            selectCommand.Parameters.AddWithValue("@CurrencyKey281", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@CurrencyKey281", DBNull.Value); }
        if (sField == "Sales Territory Key") {
            selectCommand.Parameters.AddWithValue("@SalesTerritoryKey282", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@SalesTerritoryKey282", DBNull.Value); }
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

    public static dbo_FactResellerSalesClass Select_Record(dbo_FactResellerSalesClass clsdbo_FactResellerSalesPara)
    {
        dbo_FactResellerSalesClass clsdbo_FactResellerSales = new dbo_FactResellerSalesClass();
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement
            = "SELECT " 
            + "     [SalesOrderNumber] "
            + "    ,[SalesOrderLineNumber] "
            + "    ,[ProductKey] "
            + "    ,[OrderDateKey] "
            + "    ,[DueDateKey] "
            + "    ,[ShipDateKey] "
            + "    ,[ResellerKey] "
            + "    ,[EmployeeKey] "
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
            + "     [dbo].[FactResellerSales] "
            + "WHERE "
            + "     [SalesOrderNumber] = @SalesOrderNumber "
            + " AND [SalesOrderLineNumber] = @SalesOrderLineNumber "
            + "";
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        selectCommand.CommandType = CommandType.Text;
        selectCommand.Parameters.AddWithValue("@SalesOrderNumber", clsdbo_FactResellerSalesPara.SalesOrderNumber);
        selectCommand.Parameters.AddWithValue("@SalesOrderLineNumber", clsdbo_FactResellerSalesPara.SalesOrderLineNumber);
        try
        {
            connection.Open();
            SqlDataReader reader
                = selectCommand.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                clsdbo_FactResellerSales.SalesOrderNumber = System.Convert.ToString(reader["SalesOrderNumber"]);
                clsdbo_FactResellerSales.SalesOrderLineNumber = System.Convert.ToByte(reader["SalesOrderLineNumber"]);
                clsdbo_FactResellerSales.ProductKey = System.Convert.ToInt32(reader["ProductKey"]);
                clsdbo_FactResellerSales.OrderDateKey = System.Convert.ToInt32(reader["OrderDateKey"]);
                clsdbo_FactResellerSales.DueDateKey = System.Convert.ToInt32(reader["DueDateKey"]);
                clsdbo_FactResellerSales.ShipDateKey = System.Convert.ToInt32(reader["ShipDateKey"]);
                clsdbo_FactResellerSales.ResellerKey = System.Convert.ToInt32(reader["ResellerKey"]);
                clsdbo_FactResellerSales.EmployeeKey = System.Convert.ToInt32(reader["EmployeeKey"]);
                clsdbo_FactResellerSales.PromotionKey = System.Convert.ToInt32(reader["PromotionKey"]);
                clsdbo_FactResellerSales.CurrencyKey = System.Convert.ToInt32(reader["CurrencyKey"]);
                clsdbo_FactResellerSales.SalesTerritoryKey = System.Convert.ToInt32(reader["SalesTerritoryKey"]);
                clsdbo_FactResellerSales.RevisionNumber = reader["RevisionNumber"] is DBNull ? null : (Byte?)reader["RevisionNumber"];
                clsdbo_FactResellerSales.OrderQuantity = reader["OrderQuantity"] is DBNull ? null : (Int16?)reader["OrderQuantity"];
                clsdbo_FactResellerSales.UnitPrice = reader["UnitPrice"] is DBNull ? null : (Decimal?)reader["UnitPrice"];
                clsdbo_FactResellerSales.ExtendedAmount = reader["ExtendedAmount"] is DBNull ? null : (Decimal?)reader["ExtendedAmount"];
                clsdbo_FactResellerSales.UnitPriceDiscountPct = reader["UnitPriceDiscountPct"] is DBNull ? null : (Decimal?)(Double?)reader["UnitPriceDiscountPct"];
                clsdbo_FactResellerSales.DiscountAmount = reader["DiscountAmount"] is DBNull ? null : (Decimal?)(Double?)reader["DiscountAmount"];
                clsdbo_FactResellerSales.ProductStandardCost = reader["ProductStandardCost"] is DBNull ? null : (Decimal?)reader["ProductStandardCost"];
                clsdbo_FactResellerSales.TotalProductCost = reader["TotalProductCost"] is DBNull ? null : (Decimal?)reader["TotalProductCost"];
                clsdbo_FactResellerSales.SalesAmount = reader["SalesAmount"] is DBNull ? null : (Decimal?)reader["SalesAmount"];
                clsdbo_FactResellerSales.TaxAmt = reader["TaxAmt"] is DBNull ? null : (Decimal?)reader["TaxAmt"];
                clsdbo_FactResellerSales.Freight = reader["Freight"] is DBNull ? null : (Decimal?)reader["Freight"];
                clsdbo_FactResellerSales.CarrierTrackingNumber = reader["CarrierTrackingNumber"] is DBNull ? null : reader["CarrierTrackingNumber"].ToString();
                clsdbo_FactResellerSales.CustomerPONumber = reader["CustomerPONumber"] is DBNull ? null : reader["CustomerPONumber"].ToString();
                clsdbo_FactResellerSales.OrderDate = reader["OrderDate"] is DBNull ? null : (DateTime?)reader["OrderDate"];
                clsdbo_FactResellerSales.DueDate = reader["DueDate"] is DBNull ? null : (DateTime?)reader["DueDate"];
                clsdbo_FactResellerSales.ShipDate = reader["ShipDate"] is DBNull ? null : (DateTime?)reader["ShipDate"];
            }
            else
            {
                clsdbo_FactResellerSales = null;
            }
            reader.Close();
        }
        catch (SqlException)
        {
            return clsdbo_FactResellerSales;
        }
        finally
        {
            connection.Close();
        }
        return clsdbo_FactResellerSales;
    }

    public static bool Add(dbo_FactResellerSalesClass clsdbo_FactResellerSales)
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string insertStatement
            = "INSERT " 
            + "     [dbo].[FactResellerSales] "
            + "     ( "
            + "     [SalesOrderNumber] "
            + "    ,[SalesOrderLineNumber] "
            + "    ,[ProductKey] "
            + "    ,[OrderDateKey] "
            + "    ,[DueDateKey] "
            + "    ,[ShipDateKey] "
            + "    ,[ResellerKey] "
            + "    ,[EmployeeKey] "
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
            + "    ,@ResellerKey "
            + "    ,@EmployeeKey "
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
        insertCommand.Parameters.AddWithValue("@SalesOrderNumber", clsdbo_FactResellerSales.SalesOrderNumber);
        insertCommand.Parameters.AddWithValue("@SalesOrderLineNumber", clsdbo_FactResellerSales.SalesOrderLineNumber);
        insertCommand.Parameters.AddWithValue("@ProductKey", clsdbo_FactResellerSales.ProductKey);
        insertCommand.Parameters.AddWithValue("@OrderDateKey", clsdbo_FactResellerSales.OrderDateKey);
        insertCommand.Parameters.AddWithValue("@DueDateKey", clsdbo_FactResellerSales.DueDateKey);
        insertCommand.Parameters.AddWithValue("@ShipDateKey", clsdbo_FactResellerSales.ShipDateKey);
        insertCommand.Parameters.AddWithValue("@ResellerKey", clsdbo_FactResellerSales.ResellerKey);
        insertCommand.Parameters.AddWithValue("@EmployeeKey", clsdbo_FactResellerSales.EmployeeKey);
        insertCommand.Parameters.AddWithValue("@PromotionKey", clsdbo_FactResellerSales.PromotionKey);
        insertCommand.Parameters.AddWithValue("@CurrencyKey", clsdbo_FactResellerSales.CurrencyKey);
        insertCommand.Parameters.AddWithValue("@SalesTerritoryKey", clsdbo_FactResellerSales.SalesTerritoryKey);
        if (clsdbo_FactResellerSales.RevisionNumber.HasValue == true) {
            insertCommand.Parameters.AddWithValue("@RevisionNumber", clsdbo_FactResellerSales.RevisionNumber);
        } else {
            insertCommand.Parameters.AddWithValue("@RevisionNumber", DBNull.Value); }
        if (clsdbo_FactResellerSales.OrderQuantity.HasValue == true) {
            insertCommand.Parameters.AddWithValue("@OrderQuantity", clsdbo_FactResellerSales.OrderQuantity);
        } else {
            insertCommand.Parameters.AddWithValue("@OrderQuantity", DBNull.Value); }
        if (clsdbo_FactResellerSales.UnitPrice.HasValue == true) {
            insertCommand.Parameters.AddWithValue("@UnitPrice", clsdbo_FactResellerSales.UnitPrice);
        } else {
            insertCommand.Parameters.AddWithValue("@UnitPrice", DBNull.Value); }
        if (clsdbo_FactResellerSales.ExtendedAmount.HasValue == true) {
            insertCommand.Parameters.AddWithValue("@ExtendedAmount", clsdbo_FactResellerSales.ExtendedAmount);
        } else {
            insertCommand.Parameters.AddWithValue("@ExtendedAmount", DBNull.Value); }
        if (clsdbo_FactResellerSales.UnitPriceDiscountPct.HasValue == true) {
            insertCommand.Parameters.AddWithValue("@UnitPriceDiscountPct", clsdbo_FactResellerSales.UnitPriceDiscountPct);
        } else {
            insertCommand.Parameters.AddWithValue("@UnitPriceDiscountPct", DBNull.Value); }
        if (clsdbo_FactResellerSales.DiscountAmount.HasValue == true) {
            insertCommand.Parameters.AddWithValue("@DiscountAmount", clsdbo_FactResellerSales.DiscountAmount);
        } else {
            insertCommand.Parameters.AddWithValue("@DiscountAmount", DBNull.Value); }
        if (clsdbo_FactResellerSales.ProductStandardCost.HasValue == true) {
            insertCommand.Parameters.AddWithValue("@ProductStandardCost", clsdbo_FactResellerSales.ProductStandardCost);
        } else {
            insertCommand.Parameters.AddWithValue("@ProductStandardCost", DBNull.Value); }
        if (clsdbo_FactResellerSales.TotalProductCost.HasValue == true) {
            insertCommand.Parameters.AddWithValue("@TotalProductCost", clsdbo_FactResellerSales.TotalProductCost);
        } else {
            insertCommand.Parameters.AddWithValue("@TotalProductCost", DBNull.Value); }
        if (clsdbo_FactResellerSales.SalesAmount.HasValue == true) {
            insertCommand.Parameters.AddWithValue("@SalesAmount", clsdbo_FactResellerSales.SalesAmount);
        } else {
            insertCommand.Parameters.AddWithValue("@SalesAmount", DBNull.Value); }
        if (clsdbo_FactResellerSales.TaxAmt.HasValue == true) {
            insertCommand.Parameters.AddWithValue("@TaxAmt", clsdbo_FactResellerSales.TaxAmt);
        } else {
            insertCommand.Parameters.AddWithValue("@TaxAmt", DBNull.Value); }
        if (clsdbo_FactResellerSales.Freight.HasValue == true) {
            insertCommand.Parameters.AddWithValue("@Freight", clsdbo_FactResellerSales.Freight);
        } else {
            insertCommand.Parameters.AddWithValue("@Freight", DBNull.Value); }
        if (clsdbo_FactResellerSales.CarrierTrackingNumber != null) {
            insertCommand.Parameters.AddWithValue("@CarrierTrackingNumber", clsdbo_FactResellerSales.CarrierTrackingNumber);
        } else {
            insertCommand.Parameters.AddWithValue("@CarrierTrackingNumber", DBNull.Value); }
        if (clsdbo_FactResellerSales.CustomerPONumber != null) {
            insertCommand.Parameters.AddWithValue("@CustomerPONumber", clsdbo_FactResellerSales.CustomerPONumber);
        } else {
            insertCommand.Parameters.AddWithValue("@CustomerPONumber", DBNull.Value); }
        if (clsdbo_FactResellerSales.OrderDate.HasValue == true) {
            insertCommand.Parameters.AddWithValue("@OrderDate", clsdbo_FactResellerSales.OrderDate);
        } else {
            insertCommand.Parameters.AddWithValue("@OrderDate", DBNull.Value); }
        if (clsdbo_FactResellerSales.DueDate.HasValue == true) {
            insertCommand.Parameters.AddWithValue("@DueDate", clsdbo_FactResellerSales.DueDate);
        } else {
            insertCommand.Parameters.AddWithValue("@DueDate", DBNull.Value); }
        if (clsdbo_FactResellerSales.ShipDate.HasValue == true) {
            insertCommand.Parameters.AddWithValue("@ShipDate", clsdbo_FactResellerSales.ShipDate);
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

    public static bool Update(dbo_FactResellerSalesClass olddbo_FactResellerSalesClass, 
           dbo_FactResellerSalesClass newdbo_FactResellerSalesClass)
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string updateStatement
            = "UPDATE "  
            + "     [dbo].[FactResellerSales] "
            + "SET "
            + "     [SalesOrderNumber] = @NewSalesOrderNumber "
            + "    ,[SalesOrderLineNumber] = @NewSalesOrderLineNumber "
            + "    ,[ProductKey] = @NewProductKey "
            + "    ,[OrderDateKey] = @NewOrderDateKey "
            + "    ,[DueDateKey] = @NewDueDateKey "
            + "    ,[ShipDateKey] = @NewShipDateKey "
            + "    ,[ResellerKey] = @NewResellerKey "
            + "    ,[EmployeeKey] = @NewEmployeeKey "
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
            + " AND [ResellerKey] = @OldResellerKey " 
            + " AND [EmployeeKey] = @OldEmployeeKey " 
            + " AND [PromotionKey] = @OldPromotionKey " 
            + " AND [CurrencyKey] = @OldCurrencyKey " 
            + " AND [SalesTerritoryKey] = @OldSalesTerritoryKey " 
            + " AND ((@OldRevisionNumber IS NULL AND [RevisionNumber] IS NULL) OR [RevisionNumber] = @OldRevisionNumber) " 
            + " AND ((@OldOrderQuantity IS NULL AND [OrderQuantity] IS NULL) OR [OrderQuantity] = @OldOrderQuantity) " 
            + " AND ((@OldUnitPrice IS NULL AND [UnitPrice] IS NULL) OR [UnitPrice] = @OldUnitPrice) " 
            + " AND ((@OldExtendedAmount IS NULL AND [ExtendedAmount] IS NULL) OR [ExtendedAmount] = @OldExtendedAmount) " 
            + " AND ((@OldUnitPriceDiscountPct IS NULL AND [UnitPriceDiscountPct] IS NULL) OR [UnitPriceDiscountPct] = @OldUnitPriceDiscountPct) " 
            + " AND ((@OldDiscountAmount IS NULL AND [DiscountAmount] IS NULL) OR [DiscountAmount] = @OldDiscountAmount) " 
            + " AND ((@OldProductStandardCost IS NULL AND [ProductStandardCost] IS NULL) OR [ProductStandardCost] = @OldProductStandardCost) " 
            + " AND ((@OldTotalProductCost IS NULL AND [TotalProductCost] IS NULL) OR [TotalProductCost] = @OldTotalProductCost) " 
            + " AND ((@OldSalesAmount IS NULL AND [SalesAmount] IS NULL) OR [SalesAmount] = @OldSalesAmount) " 
            + " AND ((@OldTaxAmt IS NULL AND [TaxAmt] IS NULL) OR [TaxAmt] = @OldTaxAmt) " 
            + " AND ((@OldFreight IS NULL AND [Freight] IS NULL) OR [Freight] = @OldFreight) " 
            + " AND ((@OldCarrierTrackingNumber IS NULL AND [CarrierTrackingNumber] IS NULL) OR [CarrierTrackingNumber] = @OldCarrierTrackingNumber) " 
            + " AND ((@OldCustomerPONumber IS NULL AND [CustomerPONumber] IS NULL) OR [CustomerPONumber] = @OldCustomerPONumber) " 
            + " AND ((@OldOrderDate IS NULL AND [OrderDate] IS NULL) OR [OrderDate] = @OldOrderDate) " 
            + " AND ((@OldDueDate IS NULL AND [DueDate] IS NULL) OR [DueDate] = @OldDueDate) " 
            + " AND ((@OldShipDate IS NULL AND [ShipDate] IS NULL) OR [ShipDate] = @OldShipDate) " 
            + "";
        SqlCommand updateCommand = new SqlCommand(updateStatement, connection);
        updateCommand.CommandType = CommandType.Text;
        updateCommand.Parameters.AddWithValue("@NewSalesOrderNumber", newdbo_FactResellerSalesClass.SalesOrderNumber);
        updateCommand.Parameters.AddWithValue("@NewSalesOrderLineNumber", newdbo_FactResellerSalesClass.SalesOrderLineNumber);
        updateCommand.Parameters.AddWithValue("@NewProductKey", newdbo_FactResellerSalesClass.ProductKey);
        updateCommand.Parameters.AddWithValue("@NewOrderDateKey", newdbo_FactResellerSalesClass.OrderDateKey);
        updateCommand.Parameters.AddWithValue("@NewDueDateKey", newdbo_FactResellerSalesClass.DueDateKey);
        updateCommand.Parameters.AddWithValue("@NewShipDateKey", newdbo_FactResellerSalesClass.ShipDateKey);
        updateCommand.Parameters.AddWithValue("@NewResellerKey", newdbo_FactResellerSalesClass.ResellerKey);
        updateCommand.Parameters.AddWithValue("@NewEmployeeKey", newdbo_FactResellerSalesClass.EmployeeKey);
        updateCommand.Parameters.AddWithValue("@NewPromotionKey", newdbo_FactResellerSalesClass.PromotionKey);
        updateCommand.Parameters.AddWithValue("@NewCurrencyKey", newdbo_FactResellerSalesClass.CurrencyKey);
        updateCommand.Parameters.AddWithValue("@NewSalesTerritoryKey", newdbo_FactResellerSalesClass.SalesTerritoryKey);
        if (newdbo_FactResellerSalesClass.RevisionNumber.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@NewRevisionNumber", newdbo_FactResellerSalesClass.RevisionNumber);
        } else {
            updateCommand.Parameters.AddWithValue("@NewRevisionNumber", DBNull.Value); }
        if (newdbo_FactResellerSalesClass.OrderQuantity.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@NewOrderQuantity", newdbo_FactResellerSalesClass.OrderQuantity);
        } else {
            updateCommand.Parameters.AddWithValue("@NewOrderQuantity", DBNull.Value); }
        if (newdbo_FactResellerSalesClass.UnitPrice.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@NewUnitPrice", newdbo_FactResellerSalesClass.UnitPrice);
        } else {
            updateCommand.Parameters.AddWithValue("@NewUnitPrice", DBNull.Value); }
        if (newdbo_FactResellerSalesClass.ExtendedAmount.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@NewExtendedAmount", newdbo_FactResellerSalesClass.ExtendedAmount);
        } else {
            updateCommand.Parameters.AddWithValue("@NewExtendedAmount", DBNull.Value); }
        if (newdbo_FactResellerSalesClass.UnitPriceDiscountPct.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@NewUnitPriceDiscountPct", newdbo_FactResellerSalesClass.UnitPriceDiscountPct);
        } else {
            updateCommand.Parameters.AddWithValue("@NewUnitPriceDiscountPct", DBNull.Value); }
        if (newdbo_FactResellerSalesClass.DiscountAmount.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@NewDiscountAmount", newdbo_FactResellerSalesClass.DiscountAmount);
        } else {
            updateCommand.Parameters.AddWithValue("@NewDiscountAmount", DBNull.Value); }
        if (newdbo_FactResellerSalesClass.ProductStandardCost.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@NewProductStandardCost", newdbo_FactResellerSalesClass.ProductStandardCost);
        } else {
            updateCommand.Parameters.AddWithValue("@NewProductStandardCost", DBNull.Value); }
        if (newdbo_FactResellerSalesClass.TotalProductCost.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@NewTotalProductCost", newdbo_FactResellerSalesClass.TotalProductCost);
        } else {
            updateCommand.Parameters.AddWithValue("@NewTotalProductCost", DBNull.Value); }
        if (newdbo_FactResellerSalesClass.SalesAmount.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@NewSalesAmount", newdbo_FactResellerSalesClass.SalesAmount);
        } else {
            updateCommand.Parameters.AddWithValue("@NewSalesAmount", DBNull.Value); }
        if (newdbo_FactResellerSalesClass.TaxAmt.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@NewTaxAmt", newdbo_FactResellerSalesClass.TaxAmt);
        } else {
            updateCommand.Parameters.AddWithValue("@NewTaxAmt", DBNull.Value); }
        if (newdbo_FactResellerSalesClass.Freight.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@NewFreight", newdbo_FactResellerSalesClass.Freight);
        } else {
            updateCommand.Parameters.AddWithValue("@NewFreight", DBNull.Value); }
        if (newdbo_FactResellerSalesClass.CarrierTrackingNumber != null) {
            updateCommand.Parameters.AddWithValue("@NewCarrierTrackingNumber", newdbo_FactResellerSalesClass.CarrierTrackingNumber);
        } else {
            updateCommand.Parameters.AddWithValue("@NewCarrierTrackingNumber", DBNull.Value); }
        if (newdbo_FactResellerSalesClass.CustomerPONumber != null) {
            updateCommand.Parameters.AddWithValue("@NewCustomerPONumber", newdbo_FactResellerSalesClass.CustomerPONumber);
        } else {
            updateCommand.Parameters.AddWithValue("@NewCustomerPONumber", DBNull.Value); }
        if (newdbo_FactResellerSalesClass.OrderDate.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@NewOrderDate", newdbo_FactResellerSalesClass.OrderDate);
        } else {
            updateCommand.Parameters.AddWithValue("@NewOrderDate", DBNull.Value); }
        if (newdbo_FactResellerSalesClass.DueDate.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@NewDueDate", newdbo_FactResellerSalesClass.DueDate);
        } else {
            updateCommand.Parameters.AddWithValue("@NewDueDate", DBNull.Value); }
        if (newdbo_FactResellerSalesClass.ShipDate.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@NewShipDate", newdbo_FactResellerSalesClass.ShipDate);
        } else {
            updateCommand.Parameters.AddWithValue("@NewShipDate", DBNull.Value); }
        updateCommand.Parameters.AddWithValue("@OldSalesOrderNumber", olddbo_FactResellerSalesClass.SalesOrderNumber);
        updateCommand.Parameters.AddWithValue("@OldSalesOrderLineNumber", olddbo_FactResellerSalesClass.SalesOrderLineNumber);
        updateCommand.Parameters.AddWithValue("@OldProductKey", olddbo_FactResellerSalesClass.ProductKey);
        updateCommand.Parameters.AddWithValue("@OldOrderDateKey", olddbo_FactResellerSalesClass.OrderDateKey);
        updateCommand.Parameters.AddWithValue("@OldDueDateKey", olddbo_FactResellerSalesClass.DueDateKey);
        updateCommand.Parameters.AddWithValue("@OldShipDateKey", olddbo_FactResellerSalesClass.ShipDateKey);
        updateCommand.Parameters.AddWithValue("@OldResellerKey", olddbo_FactResellerSalesClass.ResellerKey);
        updateCommand.Parameters.AddWithValue("@OldEmployeeKey", olddbo_FactResellerSalesClass.EmployeeKey);
        updateCommand.Parameters.AddWithValue("@OldPromotionKey", olddbo_FactResellerSalesClass.PromotionKey);
        updateCommand.Parameters.AddWithValue("@OldCurrencyKey", olddbo_FactResellerSalesClass.CurrencyKey);
        updateCommand.Parameters.AddWithValue("@OldSalesTerritoryKey", olddbo_FactResellerSalesClass.SalesTerritoryKey);
        if (olddbo_FactResellerSalesClass.RevisionNumber.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@OldRevisionNumber", olddbo_FactResellerSalesClass.RevisionNumber);
        } else {
            updateCommand.Parameters.AddWithValue("@OldRevisionNumber", DBNull.Value); }
        if (olddbo_FactResellerSalesClass.OrderQuantity.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@OldOrderQuantity", olddbo_FactResellerSalesClass.OrderQuantity);
        } else {
            updateCommand.Parameters.AddWithValue("@OldOrderQuantity", DBNull.Value); }
        if (olddbo_FactResellerSalesClass.UnitPrice.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@OldUnitPrice", olddbo_FactResellerSalesClass.UnitPrice);
        } else {
            updateCommand.Parameters.AddWithValue("@OldUnitPrice", DBNull.Value); }
        if (olddbo_FactResellerSalesClass.ExtendedAmount.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@OldExtendedAmount", olddbo_FactResellerSalesClass.ExtendedAmount);
        } else {
            updateCommand.Parameters.AddWithValue("@OldExtendedAmount", DBNull.Value); }
        if (olddbo_FactResellerSalesClass.UnitPriceDiscountPct.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@OldUnitPriceDiscountPct", olddbo_FactResellerSalesClass.UnitPriceDiscountPct);
        } else {
            updateCommand.Parameters.AddWithValue("@OldUnitPriceDiscountPct", DBNull.Value); }
        if (olddbo_FactResellerSalesClass.DiscountAmount.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@OldDiscountAmount", olddbo_FactResellerSalesClass.DiscountAmount);
        } else {
            updateCommand.Parameters.AddWithValue("@OldDiscountAmount", DBNull.Value); }
        if (olddbo_FactResellerSalesClass.ProductStandardCost.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@OldProductStandardCost", olddbo_FactResellerSalesClass.ProductStandardCost);
        } else {
            updateCommand.Parameters.AddWithValue("@OldProductStandardCost", DBNull.Value); }
        if (olddbo_FactResellerSalesClass.TotalProductCost.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@OldTotalProductCost", olddbo_FactResellerSalesClass.TotalProductCost);
        } else {
            updateCommand.Parameters.AddWithValue("@OldTotalProductCost", DBNull.Value); }
        if (olddbo_FactResellerSalesClass.SalesAmount.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@OldSalesAmount", olddbo_FactResellerSalesClass.SalesAmount);
        } else {
            updateCommand.Parameters.AddWithValue("@OldSalesAmount", DBNull.Value); }
        if (olddbo_FactResellerSalesClass.TaxAmt.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@OldTaxAmt", olddbo_FactResellerSalesClass.TaxAmt);
        } else {
            updateCommand.Parameters.AddWithValue("@OldTaxAmt", DBNull.Value); }
        if (olddbo_FactResellerSalesClass.Freight.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@OldFreight", olddbo_FactResellerSalesClass.Freight);
        } else {
            updateCommand.Parameters.AddWithValue("@OldFreight", DBNull.Value); }
        if (olddbo_FactResellerSalesClass.CarrierTrackingNumber != null) {
            updateCommand.Parameters.AddWithValue("@OldCarrierTrackingNumber", olddbo_FactResellerSalesClass.CarrierTrackingNumber);
        } else {
            updateCommand.Parameters.AddWithValue("@OldCarrierTrackingNumber", DBNull.Value); }
        if (olddbo_FactResellerSalesClass.CustomerPONumber != null) {
            updateCommand.Parameters.AddWithValue("@OldCustomerPONumber", olddbo_FactResellerSalesClass.CustomerPONumber);
        } else {
            updateCommand.Parameters.AddWithValue("@OldCustomerPONumber", DBNull.Value); }
        if (olddbo_FactResellerSalesClass.OrderDate.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@OldOrderDate", olddbo_FactResellerSalesClass.OrderDate);
        } else {
            updateCommand.Parameters.AddWithValue("@OldOrderDate", DBNull.Value); }
        if (olddbo_FactResellerSalesClass.DueDate.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@OldDueDate", olddbo_FactResellerSalesClass.DueDate);
        } else {
            updateCommand.Parameters.AddWithValue("@OldDueDate", DBNull.Value); }
        if (olddbo_FactResellerSalesClass.ShipDate.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@OldShipDate", olddbo_FactResellerSalesClass.ShipDate);
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

    public static bool Delete(dbo_FactResellerSalesClass clsdbo_FactResellerSales)
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string deleteStatement
            = "DELETE FROM "  
            + "     [dbo].[FactResellerSales] "
            + "WHERE " 
            + "     [SalesOrderNumber] = @OldSalesOrderNumber " 
            + " AND [SalesOrderLineNumber] = @OldSalesOrderLineNumber " 
            + " AND [ProductKey] = @OldProductKey " 
            + " AND [OrderDateKey] = @OldOrderDateKey " 
            + " AND [DueDateKey] = @OldDueDateKey " 
            + " AND [ShipDateKey] = @OldShipDateKey " 
            + " AND [ResellerKey] = @OldResellerKey " 
            + " AND [EmployeeKey] = @OldEmployeeKey " 
            + " AND [PromotionKey] = @OldPromotionKey " 
            + " AND [CurrencyKey] = @OldCurrencyKey " 
            + " AND [SalesTerritoryKey] = @OldSalesTerritoryKey " 
            + " AND ((@OldRevisionNumber IS NULL AND [RevisionNumber] IS NULL) OR [RevisionNumber] = @OldRevisionNumber) " 
            + " AND ((@OldOrderQuantity IS NULL AND [OrderQuantity] IS NULL) OR [OrderQuantity] = @OldOrderQuantity) " 
            + " AND ((@OldUnitPrice IS NULL AND [UnitPrice] IS NULL) OR [UnitPrice] = @OldUnitPrice) " 
            + " AND ((@OldExtendedAmount IS NULL AND [ExtendedAmount] IS NULL) OR [ExtendedAmount] = @OldExtendedAmount) " 
            + " AND ((@OldUnitPriceDiscountPct IS NULL AND [UnitPriceDiscountPct] IS NULL) OR [UnitPriceDiscountPct] = @OldUnitPriceDiscountPct) " 
            + " AND ((@OldDiscountAmount IS NULL AND [DiscountAmount] IS NULL) OR [DiscountAmount] = @OldDiscountAmount) " 
            + " AND ((@OldProductStandardCost IS NULL AND [ProductStandardCost] IS NULL) OR [ProductStandardCost] = @OldProductStandardCost) " 
            + " AND ((@OldTotalProductCost IS NULL AND [TotalProductCost] IS NULL) OR [TotalProductCost] = @OldTotalProductCost) " 
            + " AND ((@OldSalesAmount IS NULL AND [SalesAmount] IS NULL) OR [SalesAmount] = @OldSalesAmount) " 
            + " AND ((@OldTaxAmt IS NULL AND [TaxAmt] IS NULL) OR [TaxAmt] = @OldTaxAmt) " 
            + " AND ((@OldFreight IS NULL AND [Freight] IS NULL) OR [Freight] = @OldFreight) " 
            + " AND ((@OldCarrierTrackingNumber IS NULL AND [CarrierTrackingNumber] IS NULL) OR [CarrierTrackingNumber] = @OldCarrierTrackingNumber) " 
            + " AND ((@OldCustomerPONumber IS NULL AND [CustomerPONumber] IS NULL) OR [CustomerPONumber] = @OldCustomerPONumber) " 
            + " AND ((@OldOrderDate IS NULL AND [OrderDate] IS NULL) OR [OrderDate] = @OldOrderDate) " 
            + " AND ((@OldDueDate IS NULL AND [DueDate] IS NULL) OR [DueDate] = @OldDueDate) " 
            + " AND ((@OldShipDate IS NULL AND [ShipDate] IS NULL) OR [ShipDate] = @OldShipDate) " 
            + "";
        SqlCommand deleteCommand = new SqlCommand(deleteStatement, connection);
        deleteCommand.CommandType = CommandType.Text;
        deleteCommand.Parameters.AddWithValue("@OldSalesOrderNumber", clsdbo_FactResellerSales.SalesOrderNumber);
        deleteCommand.Parameters.AddWithValue("@OldSalesOrderLineNumber", clsdbo_FactResellerSales.SalesOrderLineNumber);
        deleteCommand.Parameters.AddWithValue("@OldProductKey", clsdbo_FactResellerSales.ProductKey);
        deleteCommand.Parameters.AddWithValue("@OldOrderDateKey", clsdbo_FactResellerSales.OrderDateKey);
        deleteCommand.Parameters.AddWithValue("@OldDueDateKey", clsdbo_FactResellerSales.DueDateKey);
        deleteCommand.Parameters.AddWithValue("@OldShipDateKey", clsdbo_FactResellerSales.ShipDateKey);
        deleteCommand.Parameters.AddWithValue("@OldResellerKey", clsdbo_FactResellerSales.ResellerKey);
        deleteCommand.Parameters.AddWithValue("@OldEmployeeKey", clsdbo_FactResellerSales.EmployeeKey);
        deleteCommand.Parameters.AddWithValue("@OldPromotionKey", clsdbo_FactResellerSales.PromotionKey);
        deleteCommand.Parameters.AddWithValue("@OldCurrencyKey", clsdbo_FactResellerSales.CurrencyKey);
        deleteCommand.Parameters.AddWithValue("@OldSalesTerritoryKey", clsdbo_FactResellerSales.SalesTerritoryKey);
        if (clsdbo_FactResellerSales.RevisionNumber.HasValue == true) {
            deleteCommand.Parameters.AddWithValue("@OldRevisionNumber", clsdbo_FactResellerSales.RevisionNumber);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldRevisionNumber", DBNull.Value); }
        if (clsdbo_FactResellerSales.OrderQuantity.HasValue == true) {
            deleteCommand.Parameters.AddWithValue("@OldOrderQuantity", clsdbo_FactResellerSales.OrderQuantity);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldOrderQuantity", DBNull.Value); }
        if (clsdbo_FactResellerSales.UnitPrice.HasValue == true) {
            deleteCommand.Parameters.AddWithValue("@OldUnitPrice", clsdbo_FactResellerSales.UnitPrice);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldUnitPrice", DBNull.Value); }
        if (clsdbo_FactResellerSales.ExtendedAmount.HasValue == true) {
            deleteCommand.Parameters.AddWithValue("@OldExtendedAmount", clsdbo_FactResellerSales.ExtendedAmount);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldExtendedAmount", DBNull.Value); }
        if (clsdbo_FactResellerSales.UnitPriceDiscountPct.HasValue == true) {
            deleteCommand.Parameters.AddWithValue("@OldUnitPriceDiscountPct", clsdbo_FactResellerSales.UnitPriceDiscountPct);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldUnitPriceDiscountPct", DBNull.Value); }
        if (clsdbo_FactResellerSales.DiscountAmount.HasValue == true) {
            deleteCommand.Parameters.AddWithValue("@OldDiscountAmount", clsdbo_FactResellerSales.DiscountAmount);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldDiscountAmount", DBNull.Value); }
        if (clsdbo_FactResellerSales.ProductStandardCost.HasValue == true) {
            deleteCommand.Parameters.AddWithValue("@OldProductStandardCost", clsdbo_FactResellerSales.ProductStandardCost);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldProductStandardCost", DBNull.Value); }
        if (clsdbo_FactResellerSales.TotalProductCost.HasValue == true) {
            deleteCommand.Parameters.AddWithValue("@OldTotalProductCost", clsdbo_FactResellerSales.TotalProductCost);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldTotalProductCost", DBNull.Value); }
        if (clsdbo_FactResellerSales.SalesAmount.HasValue == true) {
            deleteCommand.Parameters.AddWithValue("@OldSalesAmount", clsdbo_FactResellerSales.SalesAmount);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldSalesAmount", DBNull.Value); }
        if (clsdbo_FactResellerSales.TaxAmt.HasValue == true) {
            deleteCommand.Parameters.AddWithValue("@OldTaxAmt", clsdbo_FactResellerSales.TaxAmt);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldTaxAmt", DBNull.Value); }
        if (clsdbo_FactResellerSales.Freight.HasValue == true) {
            deleteCommand.Parameters.AddWithValue("@OldFreight", clsdbo_FactResellerSales.Freight);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldFreight", DBNull.Value); }
        if (clsdbo_FactResellerSales.CarrierTrackingNumber != null) {
            deleteCommand.Parameters.AddWithValue("@OldCarrierTrackingNumber", clsdbo_FactResellerSales.CarrierTrackingNumber);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldCarrierTrackingNumber", DBNull.Value); }
        if (clsdbo_FactResellerSales.CustomerPONumber != null) {
            deleteCommand.Parameters.AddWithValue("@OldCustomerPONumber", clsdbo_FactResellerSales.CustomerPONumber);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldCustomerPONumber", DBNull.Value); }
        if (clsdbo_FactResellerSales.OrderDate.HasValue == true) {
            deleteCommand.Parameters.AddWithValue("@OldOrderDate", clsdbo_FactResellerSales.OrderDate);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldOrderDate", DBNull.Value); }
        if (clsdbo_FactResellerSales.DueDate.HasValue == true) {
            deleteCommand.Parameters.AddWithValue("@OldDueDate", clsdbo_FactResellerSales.DueDate);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldDueDate", DBNull.Value); }
        if (clsdbo_FactResellerSales.ShipDate.HasValue == true) {
            deleteCommand.Parameters.AddWithValue("@OldShipDate", clsdbo_FactResellerSales.ShipDate);
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

 
