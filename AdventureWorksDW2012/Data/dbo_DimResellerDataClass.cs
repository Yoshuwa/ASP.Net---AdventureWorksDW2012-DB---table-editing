using System;
using System.Data;
using System.Data.SqlClient;

public class dbo_DimResellerDataClass
{

    public static DataTable SelectAll()
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement
            = "SELECT "  
            + "     [dbo].[DimReseller].[ResellerKey] "
            + "    ,[dbo].[DimGeography].[StateProvinceName] "
            + "    ,[dbo].[DimReseller].[ResellerAlternateKey] "
            + "    ,[dbo].[DimReseller].[Phone] "
            + "    ,[dbo].[DimReseller].[BusinessType] "
            + "    ,[dbo].[DimReseller].[ResellerName] "
            + "    ,[dbo].[DimReseller].[NumberEmployees] "
            + "    ,[dbo].[DimReseller].[OrderFrequency] "
            + "    ,[dbo].[DimReseller].[OrderMonth] "
            + "    ,[dbo].[DimReseller].[FirstOrderYear] "
            + "    ,[dbo].[DimReseller].[LastOrderYear] "
            + "    ,[dbo].[DimReseller].[ProductLine] "
            + "    ,[dbo].[DimReseller].[AddressLine1] "
            + "    ,[dbo].[DimReseller].[AddressLine2] "
            + "    ,[dbo].[DimReseller].[AnnualSales] "
            + "    ,[dbo].[DimReseller].[BankName] "
            + "    ,[dbo].[DimReseller].[MinPaymentType] "
            + "    ,[dbo].[DimReseller].[MinPaymentAmount] "
            + "    ,[dbo].[DimReseller].[AnnualRevenue] "
            + "    ,[dbo].[DimReseller].[YearOpened] "
            + "FROM " 
            + "     [dbo].[DimReseller] " 
            + "LEFT JOIN [dbo].[DimGeography] ON [dbo].[DimReseller].[GeographyKey] = [dbo].[DimGeography].[GeographyKey] "
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
            + "     [dbo].[DimReseller].[ResellerKey] "
            + "    ,[dbo].[DimGeography].[StateProvinceName] "
            + "    ,[dbo].[DimReseller].[ResellerAlternateKey] "
            + "    ,[dbo].[DimReseller].[Phone] "
            + "    ,[dbo].[DimReseller].[BusinessType] "
            + "    ,[dbo].[DimReseller].[ResellerName] "
            + "    ,[dbo].[DimReseller].[NumberEmployees] "
            + "    ,[dbo].[DimReseller].[OrderFrequency] "
            + "    ,[dbo].[DimReseller].[OrderMonth] "
            + "    ,[dbo].[DimReseller].[FirstOrderYear] "
            + "    ,[dbo].[DimReseller].[LastOrderYear] "
            + "    ,[dbo].[DimReseller].[ProductLine] "
            + "    ,[dbo].[DimReseller].[AddressLine1] "
            + "    ,[dbo].[DimReseller].[AddressLine2] "
            + "    ,[dbo].[DimReseller].[AnnualSales] "
            + "    ,[dbo].[DimReseller].[BankName] "
            + "    ,[dbo].[DimReseller].[MinPaymentType] "
            + "    ,[dbo].[DimReseller].[MinPaymentAmount] "
            + "    ,[dbo].[DimReseller].[AnnualRevenue] "
            + "    ,[dbo].[DimReseller].[YearOpened] "
            + "FROM " 
            + "     [dbo].[DimReseller] " 
            + "LEFT JOIN [dbo].[DimGeography] ON [dbo].[DimReseller].[GeographyKey] = [dbo].[DimGeography].[GeographyKey] "
                + "WHERE " 
                + "     (@ResellerKey IS NULL OR @ResellerKey = '' OR [DimReseller].[ResellerKey] LIKE '%' + LTRIM(RTRIM(@ResellerKey)) + '%') " 
                + "AND   (@StateProvinceName IS NULL OR @StateProvinceName = '' OR [dbo].[DimGeography].[StateProvinceName] LIKE '%' + LTRIM(RTRIM(@StateProvinceName)) + '%') " 
                + "AND   (@ResellerAlternateKey IS NULL OR @ResellerAlternateKey = '' OR [DimReseller].[ResellerAlternateKey] LIKE '%' + LTRIM(RTRIM(@ResellerAlternateKey)) + '%') " 
                + "AND   (@Phone IS NULL OR @Phone = '' OR [DimReseller].[Phone] LIKE '%' + LTRIM(RTRIM(@Phone)) + '%') " 
                + "AND   (@BusinessType IS NULL OR @BusinessType = '' OR [DimReseller].[BusinessType] LIKE '%' + LTRIM(RTRIM(@BusinessType)) + '%') " 
                + "AND   (@ResellerName IS NULL OR @ResellerName = '' OR [DimReseller].[ResellerName] LIKE '%' + LTRIM(RTRIM(@ResellerName)) + '%') " 
                + "AND   (@NumberEmployees IS NULL OR @NumberEmployees = '' OR [DimReseller].[NumberEmployees] LIKE '%' + LTRIM(RTRIM(@NumberEmployees)) + '%') " 
                + "AND   (@OrderFrequency IS NULL OR @OrderFrequency = '' OR [DimReseller].[OrderFrequency] LIKE '%' + LTRIM(RTRIM(@OrderFrequency)) + '%') " 
                + "AND   (@OrderMonth IS NULL OR @OrderMonth = '' OR [DimReseller].[OrderMonth] LIKE '%' + LTRIM(RTRIM(@OrderMonth)) + '%') " 
                + "AND   (@FirstOrderYear IS NULL OR @FirstOrderYear = '' OR [DimReseller].[FirstOrderYear] LIKE '%' + LTRIM(RTRIM(@FirstOrderYear)) + '%') " 
                + "AND   (@LastOrderYear IS NULL OR @LastOrderYear = '' OR [DimReseller].[LastOrderYear] LIKE '%' + LTRIM(RTRIM(@LastOrderYear)) + '%') " 
                + "AND   (@ProductLine IS NULL OR @ProductLine = '' OR [DimReseller].[ProductLine] LIKE '%' + LTRIM(RTRIM(@ProductLine)) + '%') " 
                + "AND   (@AddressLine1 IS NULL OR @AddressLine1 = '' OR [DimReseller].[AddressLine1] LIKE '%' + LTRIM(RTRIM(@AddressLine1)) + '%') " 
                + "AND   (@AddressLine2 IS NULL OR @AddressLine2 = '' OR [DimReseller].[AddressLine2] LIKE '%' + LTRIM(RTRIM(@AddressLine2)) + '%') " 
                + "AND   (@AnnualSales IS NULL OR @AnnualSales = '' OR [DimReseller].[AnnualSales] LIKE '%' + LTRIM(RTRIM(@AnnualSales)) + '%') " 
                + "AND   (@BankName IS NULL OR @BankName = '' OR [DimReseller].[BankName] LIKE '%' + LTRIM(RTRIM(@BankName)) + '%') " 
                + "AND   (@MinPaymentType IS NULL OR @MinPaymentType = '' OR [DimReseller].[MinPaymentType] LIKE '%' + LTRIM(RTRIM(@MinPaymentType)) + '%') " 
                + "AND   (@MinPaymentAmount IS NULL OR @MinPaymentAmount = '' OR [DimReseller].[MinPaymentAmount] LIKE '%' + LTRIM(RTRIM(@MinPaymentAmount)) + '%') " 
                + "AND   (@AnnualRevenue IS NULL OR @AnnualRevenue = '' OR [DimReseller].[AnnualRevenue] LIKE '%' + LTRIM(RTRIM(@AnnualRevenue)) + '%') " 
                + "AND   (@YearOpened IS NULL OR @YearOpened = '' OR [DimReseller].[YearOpened] LIKE '%' + LTRIM(RTRIM(@YearOpened)) + '%') " 
                + "";
        } else if (sCondition == "Equals") {
            selectStatement
                = "SELECT "
            + "     [dbo].[DimReseller].[ResellerKey] "
            + "    ,[dbo].[DimGeography].[StateProvinceName] "
            + "    ,[dbo].[DimReseller].[ResellerAlternateKey] "
            + "    ,[dbo].[DimReseller].[Phone] "
            + "    ,[dbo].[DimReseller].[BusinessType] "
            + "    ,[dbo].[DimReseller].[ResellerName] "
            + "    ,[dbo].[DimReseller].[NumberEmployees] "
            + "    ,[dbo].[DimReseller].[OrderFrequency] "
            + "    ,[dbo].[DimReseller].[OrderMonth] "
            + "    ,[dbo].[DimReseller].[FirstOrderYear] "
            + "    ,[dbo].[DimReseller].[LastOrderYear] "
            + "    ,[dbo].[DimReseller].[ProductLine] "
            + "    ,[dbo].[DimReseller].[AddressLine1] "
            + "    ,[dbo].[DimReseller].[AddressLine2] "
            + "    ,[dbo].[DimReseller].[AnnualSales] "
            + "    ,[dbo].[DimReseller].[BankName] "
            + "    ,[dbo].[DimReseller].[MinPaymentType] "
            + "    ,[dbo].[DimReseller].[MinPaymentAmount] "
            + "    ,[dbo].[DimReseller].[AnnualRevenue] "
            + "    ,[dbo].[DimReseller].[YearOpened] "
            + "FROM " 
            + "     [dbo].[DimReseller] " 
            + "LEFT JOIN [dbo].[DimGeography] ON [dbo].[DimReseller].[GeographyKey] = [dbo].[DimGeography].[GeographyKey] "
                + "WHERE " 
                + "     (@ResellerKey IS NULL OR @ResellerKey = '' OR [DimReseller].[ResellerKey] = LTRIM(RTRIM(@ResellerKey))) " 
                + "AND   (@StateProvinceName IS NULL OR @StateProvinceName = '' OR [dbo].[DimGeography].[StateProvinceName] = LTRIM(RTRIM(@StateProvinceName))) " 
                + "AND   (@ResellerAlternateKey IS NULL OR @ResellerAlternateKey = '' OR [DimReseller].[ResellerAlternateKey] = LTRIM(RTRIM(@ResellerAlternateKey))) " 
                + "AND   (@Phone IS NULL OR @Phone = '' OR [DimReseller].[Phone] = LTRIM(RTRIM(@Phone))) " 
                + "AND   (@BusinessType IS NULL OR @BusinessType = '' OR [DimReseller].[BusinessType] = LTRIM(RTRIM(@BusinessType))) " 
                + "AND   (@ResellerName IS NULL OR @ResellerName = '' OR [DimReseller].[ResellerName] = LTRIM(RTRIM(@ResellerName))) " 
                + "AND   (@NumberEmployees IS NULL OR @NumberEmployees = '' OR [DimReseller].[NumberEmployees] = LTRIM(RTRIM(@NumberEmployees))) " 
                + "AND   (@OrderFrequency IS NULL OR @OrderFrequency = '' OR [DimReseller].[OrderFrequency] = LTRIM(RTRIM(@OrderFrequency))) " 
                + "AND   (@OrderMonth IS NULL OR @OrderMonth = '' OR [DimReseller].[OrderMonth] = LTRIM(RTRIM(@OrderMonth))) " 
                + "AND   (@FirstOrderYear IS NULL OR @FirstOrderYear = '' OR [DimReseller].[FirstOrderYear] = LTRIM(RTRIM(@FirstOrderYear))) " 
                + "AND   (@LastOrderYear IS NULL OR @LastOrderYear = '' OR [DimReseller].[LastOrderYear] = LTRIM(RTRIM(@LastOrderYear))) " 
                + "AND   (@ProductLine IS NULL OR @ProductLine = '' OR [DimReseller].[ProductLine] = LTRIM(RTRIM(@ProductLine))) " 
                + "AND   (@AddressLine1 IS NULL OR @AddressLine1 = '' OR [DimReseller].[AddressLine1] = LTRIM(RTRIM(@AddressLine1))) " 
                + "AND   (@AddressLine2 IS NULL OR @AddressLine2 = '' OR [DimReseller].[AddressLine2] = LTRIM(RTRIM(@AddressLine2))) " 
                + "AND   (@AnnualSales IS NULL OR @AnnualSales = '' OR [DimReseller].[AnnualSales] = LTRIM(RTRIM(@AnnualSales))) " 
                + "AND   (@BankName IS NULL OR @BankName = '' OR [DimReseller].[BankName] = LTRIM(RTRIM(@BankName))) " 
                + "AND   (@MinPaymentType IS NULL OR @MinPaymentType = '' OR [DimReseller].[MinPaymentType] = LTRIM(RTRIM(@MinPaymentType))) " 
                + "AND   (@MinPaymentAmount IS NULL OR @MinPaymentAmount = '' OR [DimReseller].[MinPaymentAmount] = LTRIM(RTRIM(@MinPaymentAmount))) " 
                + "AND   (@AnnualRevenue IS NULL OR @AnnualRevenue = '' OR [DimReseller].[AnnualRevenue] = LTRIM(RTRIM(@AnnualRevenue))) " 
                + "AND   (@YearOpened IS NULL OR @YearOpened = '' OR [DimReseller].[YearOpened] = LTRIM(RTRIM(@YearOpened))) " 
                + "";
        } else if  (sCondition == "Starts with...") {
            selectStatement
                = "SELECT "
            + "     [dbo].[DimReseller].[ResellerKey] "
            + "    ,[dbo].[DimGeography].[StateProvinceName] "
            + "    ,[dbo].[DimReseller].[ResellerAlternateKey] "
            + "    ,[dbo].[DimReseller].[Phone] "
            + "    ,[dbo].[DimReseller].[BusinessType] "
            + "    ,[dbo].[DimReseller].[ResellerName] "
            + "    ,[dbo].[DimReseller].[NumberEmployees] "
            + "    ,[dbo].[DimReseller].[OrderFrequency] "
            + "    ,[dbo].[DimReseller].[OrderMonth] "
            + "    ,[dbo].[DimReseller].[FirstOrderYear] "
            + "    ,[dbo].[DimReseller].[LastOrderYear] "
            + "    ,[dbo].[DimReseller].[ProductLine] "
            + "    ,[dbo].[DimReseller].[AddressLine1] "
            + "    ,[dbo].[DimReseller].[AddressLine2] "
            + "    ,[dbo].[DimReseller].[AnnualSales] "
            + "    ,[dbo].[DimReseller].[BankName] "
            + "    ,[dbo].[DimReseller].[MinPaymentType] "
            + "    ,[dbo].[DimReseller].[MinPaymentAmount] "
            + "    ,[dbo].[DimReseller].[AnnualRevenue] "
            + "    ,[dbo].[DimReseller].[YearOpened] "
            + "FROM " 
            + "     [dbo].[DimReseller] " 
            + "LEFT JOIN [dbo].[DimGeography] ON [dbo].[DimReseller].[GeographyKey] = [dbo].[DimGeography].[GeographyKey] "
                + "WHERE " 
                + "     (@ResellerKey IS NULL OR @ResellerKey = '' OR [DimReseller].[ResellerKey] LIKE LTRIM(RTRIM(@ResellerKey)) + '%') " 
                + "AND   (@StateProvinceName IS NULL OR @StateProvinceName = '' OR [dbo].[DimGeography].[StateProvinceName] LIKE LTRIM(RTRIM(@StateProvinceName)) + '%') " 
                + "AND   (@ResellerAlternateKey IS NULL OR @ResellerAlternateKey = '' OR [DimReseller].[ResellerAlternateKey] LIKE LTRIM(RTRIM(@ResellerAlternateKey)) + '%') " 
                + "AND   (@Phone IS NULL OR @Phone = '' OR [DimReseller].[Phone] LIKE LTRIM(RTRIM(@Phone)) + '%') " 
                + "AND   (@BusinessType IS NULL OR @BusinessType = '' OR [DimReseller].[BusinessType] LIKE LTRIM(RTRIM(@BusinessType)) + '%') " 
                + "AND   (@ResellerName IS NULL OR @ResellerName = '' OR [DimReseller].[ResellerName] LIKE LTRIM(RTRIM(@ResellerName)) + '%') " 
                + "AND   (@NumberEmployees IS NULL OR @NumberEmployees = '' OR [DimReseller].[NumberEmployees] LIKE LTRIM(RTRIM(@NumberEmployees)) + '%') " 
                + "AND   (@OrderFrequency IS NULL OR @OrderFrequency = '' OR [DimReseller].[OrderFrequency] LIKE LTRIM(RTRIM(@OrderFrequency)) + '%') " 
                + "AND   (@OrderMonth IS NULL OR @OrderMonth = '' OR [DimReseller].[OrderMonth] LIKE LTRIM(RTRIM(@OrderMonth)) + '%') " 
                + "AND   (@FirstOrderYear IS NULL OR @FirstOrderYear = '' OR [DimReseller].[FirstOrderYear] LIKE LTRIM(RTRIM(@FirstOrderYear)) + '%') " 
                + "AND   (@LastOrderYear IS NULL OR @LastOrderYear = '' OR [DimReseller].[LastOrderYear] LIKE LTRIM(RTRIM(@LastOrderYear)) + '%') " 
                + "AND   (@ProductLine IS NULL OR @ProductLine = '' OR [DimReseller].[ProductLine] LIKE LTRIM(RTRIM(@ProductLine)) + '%') " 
                + "AND   (@AddressLine1 IS NULL OR @AddressLine1 = '' OR [DimReseller].[AddressLine1] LIKE LTRIM(RTRIM(@AddressLine1)) + '%') " 
                + "AND   (@AddressLine2 IS NULL OR @AddressLine2 = '' OR [DimReseller].[AddressLine2] LIKE LTRIM(RTRIM(@AddressLine2)) + '%') " 
                + "AND   (@AnnualSales IS NULL OR @AnnualSales = '' OR [DimReseller].[AnnualSales] LIKE LTRIM(RTRIM(@AnnualSales)) + '%') " 
                + "AND   (@BankName IS NULL OR @BankName = '' OR [DimReseller].[BankName] LIKE LTRIM(RTRIM(@BankName)) + '%') " 
                + "AND   (@MinPaymentType IS NULL OR @MinPaymentType = '' OR [DimReseller].[MinPaymentType] LIKE LTRIM(RTRIM(@MinPaymentType)) + '%') " 
                + "AND   (@MinPaymentAmount IS NULL OR @MinPaymentAmount = '' OR [DimReseller].[MinPaymentAmount] LIKE LTRIM(RTRIM(@MinPaymentAmount)) + '%') " 
                + "AND   (@AnnualRevenue IS NULL OR @AnnualRevenue = '' OR [DimReseller].[AnnualRevenue] LIKE LTRIM(RTRIM(@AnnualRevenue)) + '%') " 
                + "AND   (@YearOpened IS NULL OR @YearOpened = '' OR [DimReseller].[YearOpened] LIKE LTRIM(RTRIM(@YearOpened)) + '%') " 
                + "";
        } else if  (sCondition == "More than...") {
            selectStatement
                = "SELECT "
            + "     [dbo].[DimReseller].[ResellerKey] "
            + "    ,[dbo].[DimGeography].[StateProvinceName] "
            + "    ,[dbo].[DimReseller].[ResellerAlternateKey] "
            + "    ,[dbo].[DimReseller].[Phone] "
            + "    ,[dbo].[DimReseller].[BusinessType] "
            + "    ,[dbo].[DimReseller].[ResellerName] "
            + "    ,[dbo].[DimReseller].[NumberEmployees] "
            + "    ,[dbo].[DimReseller].[OrderFrequency] "
            + "    ,[dbo].[DimReseller].[OrderMonth] "
            + "    ,[dbo].[DimReseller].[FirstOrderYear] "
            + "    ,[dbo].[DimReseller].[LastOrderYear] "
            + "    ,[dbo].[DimReseller].[ProductLine] "
            + "    ,[dbo].[DimReseller].[AddressLine1] "
            + "    ,[dbo].[DimReseller].[AddressLine2] "
            + "    ,[dbo].[DimReseller].[AnnualSales] "
            + "    ,[dbo].[DimReseller].[BankName] "
            + "    ,[dbo].[DimReseller].[MinPaymentType] "
            + "    ,[dbo].[DimReseller].[MinPaymentAmount] "
            + "    ,[dbo].[DimReseller].[AnnualRevenue] "
            + "    ,[dbo].[DimReseller].[YearOpened] "
            + "FROM " 
            + "     [dbo].[DimReseller] " 
            + "LEFT JOIN [dbo].[DimGeography] ON [dbo].[DimReseller].[GeographyKey] = [dbo].[DimGeography].[GeographyKey] "
                + "WHERE " 
                + "     (@ResellerKey IS NULL OR @ResellerKey = '' OR [DimReseller].[ResellerKey] > LTRIM(RTRIM(@ResellerKey))) " 
                + "AND   (@StateProvinceName IS NULL OR @StateProvinceName = '' OR [dbo].[DimGeography].[StateProvinceName] > LTRIM(RTRIM(@StateProvinceName))) " 
                + "AND   (@ResellerAlternateKey IS NULL OR @ResellerAlternateKey = '' OR [DimReseller].[ResellerAlternateKey] > LTRIM(RTRIM(@ResellerAlternateKey))) " 
                + "AND   (@Phone IS NULL OR @Phone = '' OR [DimReseller].[Phone] > LTRIM(RTRIM(@Phone))) " 
                + "AND   (@BusinessType IS NULL OR @BusinessType = '' OR [DimReseller].[BusinessType] > LTRIM(RTRIM(@BusinessType))) " 
                + "AND   (@ResellerName IS NULL OR @ResellerName = '' OR [DimReseller].[ResellerName] > LTRIM(RTRIM(@ResellerName))) " 
                + "AND   (@NumberEmployees IS NULL OR @NumberEmployees = '' OR [DimReseller].[NumberEmployees] > LTRIM(RTRIM(@NumberEmployees))) " 
                + "AND   (@OrderFrequency IS NULL OR @OrderFrequency = '' OR [DimReseller].[OrderFrequency] > LTRIM(RTRIM(@OrderFrequency))) " 
                + "AND   (@OrderMonth IS NULL OR @OrderMonth = '' OR [DimReseller].[OrderMonth] > LTRIM(RTRIM(@OrderMonth))) " 
                + "AND   (@FirstOrderYear IS NULL OR @FirstOrderYear = '' OR [DimReseller].[FirstOrderYear] > LTRIM(RTRIM(@FirstOrderYear))) " 
                + "AND   (@LastOrderYear IS NULL OR @LastOrderYear = '' OR [DimReseller].[LastOrderYear] > LTRIM(RTRIM(@LastOrderYear))) " 
                + "AND   (@ProductLine IS NULL OR @ProductLine = '' OR [DimReseller].[ProductLine] > LTRIM(RTRIM(@ProductLine))) " 
                + "AND   (@AddressLine1 IS NULL OR @AddressLine1 = '' OR [DimReseller].[AddressLine1] > LTRIM(RTRIM(@AddressLine1))) " 
                + "AND   (@AddressLine2 IS NULL OR @AddressLine2 = '' OR [DimReseller].[AddressLine2] > LTRIM(RTRIM(@AddressLine2))) " 
                + "AND   (@AnnualSales IS NULL OR @AnnualSales = '' OR [DimReseller].[AnnualSales] > LTRIM(RTRIM(@AnnualSales))) " 
                + "AND   (@BankName IS NULL OR @BankName = '' OR [DimReseller].[BankName] > LTRIM(RTRIM(@BankName))) " 
                + "AND   (@MinPaymentType IS NULL OR @MinPaymentType = '' OR [DimReseller].[MinPaymentType] > LTRIM(RTRIM(@MinPaymentType))) " 
                + "AND   (@MinPaymentAmount IS NULL OR @MinPaymentAmount = '' OR [DimReseller].[MinPaymentAmount] > LTRIM(RTRIM(@MinPaymentAmount))) " 
                + "AND   (@AnnualRevenue IS NULL OR @AnnualRevenue = '' OR [DimReseller].[AnnualRevenue] > LTRIM(RTRIM(@AnnualRevenue))) " 
                + "AND   (@YearOpened IS NULL OR @YearOpened = '' OR [DimReseller].[YearOpened] > LTRIM(RTRIM(@YearOpened))) " 
                + "";
        } else if  (sCondition == "Less than...") {
            selectStatement
                = "SELECT " 
            + "     [dbo].[DimReseller].[ResellerKey] "
            + "    ,[dbo].[DimGeography].[StateProvinceName] "
            + "    ,[dbo].[DimReseller].[ResellerAlternateKey] "
            + "    ,[dbo].[DimReseller].[Phone] "
            + "    ,[dbo].[DimReseller].[BusinessType] "
            + "    ,[dbo].[DimReseller].[ResellerName] "
            + "    ,[dbo].[DimReseller].[NumberEmployees] "
            + "    ,[dbo].[DimReseller].[OrderFrequency] "
            + "    ,[dbo].[DimReseller].[OrderMonth] "
            + "    ,[dbo].[DimReseller].[FirstOrderYear] "
            + "    ,[dbo].[DimReseller].[LastOrderYear] "
            + "    ,[dbo].[DimReseller].[ProductLine] "
            + "    ,[dbo].[DimReseller].[AddressLine1] "
            + "    ,[dbo].[DimReseller].[AddressLine2] "
            + "    ,[dbo].[DimReseller].[AnnualSales] "
            + "    ,[dbo].[DimReseller].[BankName] "
            + "    ,[dbo].[DimReseller].[MinPaymentType] "
            + "    ,[dbo].[DimReseller].[MinPaymentAmount] "
            + "    ,[dbo].[DimReseller].[AnnualRevenue] "
            + "    ,[dbo].[DimReseller].[YearOpened] "
            + "FROM " 
            + "     [dbo].[DimReseller] " 
            + "LEFT JOIN [dbo].[DimGeography] ON [dbo].[DimReseller].[GeographyKey] = [dbo].[DimGeography].[GeographyKey] "
                + "WHERE " 
                + "     (@ResellerKey IS NULL OR @ResellerKey = '' OR [DimReseller].[ResellerKey] < LTRIM(RTRIM(@ResellerKey))) " 
                + "AND   (@StateProvinceName IS NULL OR @StateProvinceName = '' OR [dbo].[DimGeography].[StateProvinceName] < LTRIM(RTRIM(@StateProvinceName))) " 
                + "AND   (@ResellerAlternateKey IS NULL OR @ResellerAlternateKey = '' OR [DimReseller].[ResellerAlternateKey] < LTRIM(RTRIM(@ResellerAlternateKey))) " 
                + "AND   (@Phone IS NULL OR @Phone = '' OR [DimReseller].[Phone] < LTRIM(RTRIM(@Phone))) " 
                + "AND   (@BusinessType IS NULL OR @BusinessType = '' OR [DimReseller].[BusinessType] < LTRIM(RTRIM(@BusinessType))) " 
                + "AND   (@ResellerName IS NULL OR @ResellerName = '' OR [DimReseller].[ResellerName] < LTRIM(RTRIM(@ResellerName))) " 
                + "AND   (@NumberEmployees IS NULL OR @NumberEmployees = '' OR [DimReseller].[NumberEmployees] < LTRIM(RTRIM(@NumberEmployees))) " 
                + "AND   (@OrderFrequency IS NULL OR @OrderFrequency = '' OR [DimReseller].[OrderFrequency] < LTRIM(RTRIM(@OrderFrequency))) " 
                + "AND   (@OrderMonth IS NULL OR @OrderMonth = '' OR [DimReseller].[OrderMonth] < LTRIM(RTRIM(@OrderMonth))) " 
                + "AND   (@FirstOrderYear IS NULL OR @FirstOrderYear = '' OR [DimReseller].[FirstOrderYear] < LTRIM(RTRIM(@FirstOrderYear))) " 
                + "AND   (@LastOrderYear IS NULL OR @LastOrderYear = '' OR [DimReseller].[LastOrderYear] < LTRIM(RTRIM(@LastOrderYear))) " 
                + "AND   (@ProductLine IS NULL OR @ProductLine = '' OR [DimReseller].[ProductLine] < LTRIM(RTRIM(@ProductLine))) " 
                + "AND   (@AddressLine1 IS NULL OR @AddressLine1 = '' OR [DimReseller].[AddressLine1] < LTRIM(RTRIM(@AddressLine1))) " 
                + "AND   (@AddressLine2 IS NULL OR @AddressLine2 = '' OR [DimReseller].[AddressLine2] < LTRIM(RTRIM(@AddressLine2))) " 
                + "AND   (@AnnualSales IS NULL OR @AnnualSales = '' OR [DimReseller].[AnnualSales] < LTRIM(RTRIM(@AnnualSales))) " 
                + "AND   (@BankName IS NULL OR @BankName = '' OR [DimReseller].[BankName] < LTRIM(RTRIM(@BankName))) " 
                + "AND   (@MinPaymentType IS NULL OR @MinPaymentType = '' OR [DimReseller].[MinPaymentType] < LTRIM(RTRIM(@MinPaymentType))) " 
                + "AND   (@MinPaymentAmount IS NULL OR @MinPaymentAmount = '' OR [DimReseller].[MinPaymentAmount] < LTRIM(RTRIM(@MinPaymentAmount))) " 
                + "AND   (@AnnualRevenue IS NULL OR @AnnualRevenue = '' OR [DimReseller].[AnnualRevenue] < LTRIM(RTRIM(@AnnualRevenue))) " 
                + "AND   (@YearOpened IS NULL OR @YearOpened = '' OR [DimReseller].[YearOpened] < LTRIM(RTRIM(@YearOpened))) " 
                + "";
        } else if  (sCondition == "Equal or more than...") {
            selectStatement
                = "SELECT "
            + "     [dbo].[DimReseller].[ResellerKey] "
            + "    ,[dbo].[DimGeography].[StateProvinceName] "
            + "    ,[dbo].[DimReseller].[ResellerAlternateKey] "
            + "    ,[dbo].[DimReseller].[Phone] "
            + "    ,[dbo].[DimReseller].[BusinessType] "
            + "    ,[dbo].[DimReseller].[ResellerName] "
            + "    ,[dbo].[DimReseller].[NumberEmployees] "
            + "    ,[dbo].[DimReseller].[OrderFrequency] "
            + "    ,[dbo].[DimReseller].[OrderMonth] "
            + "    ,[dbo].[DimReseller].[FirstOrderYear] "
            + "    ,[dbo].[DimReseller].[LastOrderYear] "
            + "    ,[dbo].[DimReseller].[ProductLine] "
            + "    ,[dbo].[DimReseller].[AddressLine1] "
            + "    ,[dbo].[DimReseller].[AddressLine2] "
            + "    ,[dbo].[DimReseller].[AnnualSales] "
            + "    ,[dbo].[DimReseller].[BankName] "
            + "    ,[dbo].[DimReseller].[MinPaymentType] "
            + "    ,[dbo].[DimReseller].[MinPaymentAmount] "
            + "    ,[dbo].[DimReseller].[AnnualRevenue] "
            + "    ,[dbo].[DimReseller].[YearOpened] "
            + "FROM " 
            + "     [dbo].[DimReseller] " 
            + "LEFT JOIN [dbo].[DimGeography] ON [dbo].[DimReseller].[GeographyKey] = [dbo].[DimGeography].[GeographyKey] "
                + "WHERE " 
                + "     (@ResellerKey IS NULL OR @ResellerKey = '' OR [DimReseller].[ResellerKey] >= LTRIM(RTRIM(@ResellerKey))) " 
                + "AND   (@StateProvinceName IS NULL OR @StateProvinceName = '' OR [dbo].[DimGeography].[StateProvinceName] >= LTRIM(RTRIM(@StateProvinceName))) " 
                + "AND   (@ResellerAlternateKey IS NULL OR @ResellerAlternateKey = '' OR [DimReseller].[ResellerAlternateKey] >= LTRIM(RTRIM(@ResellerAlternateKey))) " 
                + "AND   (@Phone IS NULL OR @Phone = '' OR [DimReseller].[Phone] >= LTRIM(RTRIM(@Phone))) " 
                + "AND   (@BusinessType IS NULL OR @BusinessType = '' OR [DimReseller].[BusinessType] >= LTRIM(RTRIM(@BusinessType))) " 
                + "AND   (@ResellerName IS NULL OR @ResellerName = '' OR [DimReseller].[ResellerName] >= LTRIM(RTRIM(@ResellerName))) " 
                + "AND   (@NumberEmployees IS NULL OR @NumberEmployees = '' OR [DimReseller].[NumberEmployees] >= LTRIM(RTRIM(@NumberEmployees))) " 
                + "AND   (@OrderFrequency IS NULL OR @OrderFrequency = '' OR [DimReseller].[OrderFrequency] >= LTRIM(RTRIM(@OrderFrequency))) " 
                + "AND   (@OrderMonth IS NULL OR @OrderMonth = '' OR [DimReseller].[OrderMonth] >= LTRIM(RTRIM(@OrderMonth))) " 
                + "AND   (@FirstOrderYear IS NULL OR @FirstOrderYear = '' OR [DimReseller].[FirstOrderYear] >= LTRIM(RTRIM(@FirstOrderYear))) " 
                + "AND   (@LastOrderYear IS NULL OR @LastOrderYear = '' OR [DimReseller].[LastOrderYear] >= LTRIM(RTRIM(@LastOrderYear))) " 
                + "AND   (@ProductLine IS NULL OR @ProductLine = '' OR [DimReseller].[ProductLine] >= LTRIM(RTRIM(@ProductLine))) " 
                + "AND   (@AddressLine1 IS NULL OR @AddressLine1 = '' OR [DimReseller].[AddressLine1] >= LTRIM(RTRIM(@AddressLine1))) " 
                + "AND   (@AddressLine2 IS NULL OR @AddressLine2 = '' OR [DimReseller].[AddressLine2] >= LTRIM(RTRIM(@AddressLine2))) " 
                + "AND   (@AnnualSales IS NULL OR @AnnualSales = '' OR [DimReseller].[AnnualSales] >= LTRIM(RTRIM(@AnnualSales))) " 
                + "AND   (@BankName IS NULL OR @BankName = '' OR [DimReseller].[BankName] >= LTRIM(RTRIM(@BankName))) " 
                + "AND   (@MinPaymentType IS NULL OR @MinPaymentType = '' OR [DimReseller].[MinPaymentType] >= LTRIM(RTRIM(@MinPaymentType))) " 
                + "AND   (@MinPaymentAmount IS NULL OR @MinPaymentAmount = '' OR [DimReseller].[MinPaymentAmount] >= LTRIM(RTRIM(@MinPaymentAmount))) " 
                + "AND   (@AnnualRevenue IS NULL OR @AnnualRevenue = '' OR [DimReseller].[AnnualRevenue] >= LTRIM(RTRIM(@AnnualRevenue))) " 
                + "AND   (@YearOpened IS NULL OR @YearOpened = '' OR [DimReseller].[YearOpened] >= LTRIM(RTRIM(@YearOpened))) " 
                + "";
        } else if (sCondition == "Equal or less than...") {
            selectStatement 
                = "SELECT "
            + "     [dbo].[DimReseller].[ResellerKey] "
            + "    ,[dbo].[DimGeography].[StateProvinceName] "
            + "    ,[dbo].[DimReseller].[ResellerAlternateKey] "
            + "    ,[dbo].[DimReseller].[Phone] "
            + "    ,[dbo].[DimReseller].[BusinessType] "
            + "    ,[dbo].[DimReseller].[ResellerName] "
            + "    ,[dbo].[DimReseller].[NumberEmployees] "
            + "    ,[dbo].[DimReseller].[OrderFrequency] "
            + "    ,[dbo].[DimReseller].[OrderMonth] "
            + "    ,[dbo].[DimReseller].[FirstOrderYear] "
            + "    ,[dbo].[DimReseller].[LastOrderYear] "
            + "    ,[dbo].[DimReseller].[ProductLine] "
            + "    ,[dbo].[DimReseller].[AddressLine1] "
            + "    ,[dbo].[DimReseller].[AddressLine2] "
            + "    ,[dbo].[DimReseller].[AnnualSales] "
            + "    ,[dbo].[DimReseller].[BankName] "
            + "    ,[dbo].[DimReseller].[MinPaymentType] "
            + "    ,[dbo].[DimReseller].[MinPaymentAmount] "
            + "    ,[dbo].[DimReseller].[AnnualRevenue] "
            + "    ,[dbo].[DimReseller].[YearOpened] "
            + "FROM " 
            + "     [dbo].[DimReseller] " 
            + "LEFT JOIN [dbo].[DimGeography] ON [dbo].[DimReseller].[GeographyKey] = [dbo].[DimGeography].[GeographyKey] "
                + "WHERE " 
                + "     (@ResellerKey IS NULL OR @ResellerKey = '' OR [DimReseller].[ResellerKey] <= LTRIM(RTRIM(@ResellerKey))) " 
                + "AND   (@StateProvinceName IS NULL OR @StateProvinceName = '' OR [dbo].[DimGeography].[StateProvinceName] <= LTRIM(RTRIM(@StateProvinceName))) " 
                + "AND   (@ResellerAlternateKey IS NULL OR @ResellerAlternateKey = '' OR [DimReseller].[ResellerAlternateKey] <= LTRIM(RTRIM(@ResellerAlternateKey))) " 
                + "AND   (@Phone IS NULL OR @Phone = '' OR [DimReseller].[Phone] <= LTRIM(RTRIM(@Phone))) " 
                + "AND   (@BusinessType IS NULL OR @BusinessType = '' OR [DimReseller].[BusinessType] <= LTRIM(RTRIM(@BusinessType))) " 
                + "AND   (@ResellerName IS NULL OR @ResellerName = '' OR [DimReseller].[ResellerName] <= LTRIM(RTRIM(@ResellerName))) " 
                + "AND   (@NumberEmployees IS NULL OR @NumberEmployees = '' OR [DimReseller].[NumberEmployees] <= LTRIM(RTRIM(@NumberEmployees))) " 
                + "AND   (@OrderFrequency IS NULL OR @OrderFrequency = '' OR [DimReseller].[OrderFrequency] <= LTRIM(RTRIM(@OrderFrequency))) " 
                + "AND   (@OrderMonth IS NULL OR @OrderMonth = '' OR [DimReseller].[OrderMonth] <= LTRIM(RTRIM(@OrderMonth))) " 
                + "AND   (@FirstOrderYear IS NULL OR @FirstOrderYear = '' OR [DimReseller].[FirstOrderYear] <= LTRIM(RTRIM(@FirstOrderYear))) " 
                + "AND   (@LastOrderYear IS NULL OR @LastOrderYear = '' OR [DimReseller].[LastOrderYear] <= LTRIM(RTRIM(@LastOrderYear))) " 
                + "AND   (@ProductLine IS NULL OR @ProductLine = '' OR [DimReseller].[ProductLine] <= LTRIM(RTRIM(@ProductLine))) " 
                + "AND   (@AddressLine1 IS NULL OR @AddressLine1 = '' OR [DimReseller].[AddressLine1] <= LTRIM(RTRIM(@AddressLine1))) " 
                + "AND   (@AddressLine2 IS NULL OR @AddressLine2 = '' OR [DimReseller].[AddressLine2] <= LTRIM(RTRIM(@AddressLine2))) " 
                + "AND   (@AnnualSales IS NULL OR @AnnualSales = '' OR [DimReseller].[AnnualSales] <= LTRIM(RTRIM(@AnnualSales))) " 
                + "AND   (@BankName IS NULL OR @BankName = '' OR [DimReseller].[BankName] <= LTRIM(RTRIM(@BankName))) " 
                + "AND   (@MinPaymentType IS NULL OR @MinPaymentType = '' OR [DimReseller].[MinPaymentType] <= LTRIM(RTRIM(@MinPaymentType))) " 
                + "AND   (@MinPaymentAmount IS NULL OR @MinPaymentAmount = '' OR [DimReseller].[MinPaymentAmount] <= LTRIM(RTRIM(@MinPaymentAmount))) " 
                + "AND   (@AnnualRevenue IS NULL OR @AnnualRevenue = '' OR [DimReseller].[AnnualRevenue] <= LTRIM(RTRIM(@AnnualRevenue))) " 
                + "AND   (@YearOpened IS NULL OR @YearOpened = '' OR [DimReseller].[YearOpened] <= LTRIM(RTRIM(@YearOpened))) " 
                + "";
        }
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        selectCommand.CommandType = CommandType.Text;
        if (sField == "Reseller Key") {
            selectCommand.Parameters.AddWithValue("@ResellerKey", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@ResellerKey", DBNull.Value); }
        if (sField == "Geography Key") {
            selectCommand.Parameters.AddWithValue("@StateProvinceName", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@StateProvinceName", DBNull.Value); }
        if (sField == "Reseller Alternate Key") {
            selectCommand.Parameters.AddWithValue("@ResellerAlternateKey", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@ResellerAlternateKey", DBNull.Value); }
        if (sField == "Phone") {
            selectCommand.Parameters.AddWithValue("@Phone", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@Phone", DBNull.Value); }
        if (sField == "Business Type") {
            selectCommand.Parameters.AddWithValue("@BusinessType", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@BusinessType", DBNull.Value); }
        if (sField == "Reseller Name") {
            selectCommand.Parameters.AddWithValue("@ResellerName", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@ResellerName", DBNull.Value); }
        if (sField == "Number Employees") {
            selectCommand.Parameters.AddWithValue("@NumberEmployees", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@NumberEmployees", DBNull.Value); }
        if (sField == "Order Frequency") {
            selectCommand.Parameters.AddWithValue("@OrderFrequency", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@OrderFrequency", DBNull.Value); }
        if (sField == "Order Month") {
            selectCommand.Parameters.AddWithValue("@OrderMonth", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@OrderMonth", DBNull.Value); }
        if (sField == "First Order Year") {
            selectCommand.Parameters.AddWithValue("@FirstOrderYear", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@FirstOrderYear", DBNull.Value); }
        if (sField == "Last Order Year") {
            selectCommand.Parameters.AddWithValue("@LastOrderYear", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@LastOrderYear", DBNull.Value); }
        if (sField == "Product Line") {
            selectCommand.Parameters.AddWithValue("@ProductLine", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@ProductLine", DBNull.Value); }
        if (sField == "Address Line1") {
            selectCommand.Parameters.AddWithValue("@AddressLine1", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@AddressLine1", DBNull.Value); }
        if (sField == "Address Line2") {
            selectCommand.Parameters.AddWithValue("@AddressLine2", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@AddressLine2", DBNull.Value); }
        if (sField == "Annual Sales") {
            selectCommand.Parameters.AddWithValue("@AnnualSales", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@AnnualSales", DBNull.Value); }
        if (sField == "Bank Name") {
            selectCommand.Parameters.AddWithValue("@BankName", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@BankName", DBNull.Value); }
        if (sField == "Min Payment Type") {
            selectCommand.Parameters.AddWithValue("@MinPaymentType", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@MinPaymentType", DBNull.Value); }
        if (sField == "Min Payment Amount") {
            selectCommand.Parameters.AddWithValue("@MinPaymentAmount", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@MinPaymentAmount", DBNull.Value); }
        if (sField == "Annual Revenue") {
            selectCommand.Parameters.AddWithValue("@AnnualRevenue", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@AnnualRevenue", DBNull.Value); }
        if (sField == "Year Opened") {
            selectCommand.Parameters.AddWithValue("@YearOpened", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@YearOpened", DBNull.Value); }
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

    public static dbo_DimResellerClass Select_Record(dbo_DimResellerClass clsdbo_DimResellerPara)
    {
        dbo_DimResellerClass clsdbo_DimReseller = new dbo_DimResellerClass();
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement
            = "SELECT " 
            + "     [ResellerKey] "
            + "    ,[GeographyKey] "
            + "    ,[ResellerAlternateKey] "
            + "    ,[Phone] "
            + "    ,[BusinessType] "
            + "    ,[ResellerName] "
            + "    ,[NumberEmployees] "
            + "    ,[OrderFrequency] "
            + "    ,[OrderMonth] "
            + "    ,[FirstOrderYear] "
            + "    ,[LastOrderYear] "
            + "    ,[ProductLine] "
            + "    ,[AddressLine1] "
            + "    ,[AddressLine2] "
            + "    ,[AnnualSales] "
            + "    ,[BankName] "
            + "    ,[MinPaymentType] "
            + "    ,[MinPaymentAmount] "
            + "    ,[AnnualRevenue] "
            + "    ,[YearOpened] "
            + "FROM "
            + "     [dbo].[DimReseller] "
            + "WHERE "
            + "     [ResellerKey] = @ResellerKey "
            + "";
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        selectCommand.CommandType = CommandType.Text;
        selectCommand.Parameters.AddWithValue("@ResellerKey", clsdbo_DimResellerPara.ResellerKey);
        try
        {
            connection.Open();
            SqlDataReader reader
                = selectCommand.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                clsdbo_DimReseller.ResellerKey = System.Convert.ToInt32(reader["ResellerKey"]);
                clsdbo_DimReseller.GeographyKey = reader["GeographyKey"] is DBNull ? null : (Int32?)reader["GeographyKey"];
                clsdbo_DimReseller.ResellerAlternateKey = reader["ResellerAlternateKey"] is DBNull ? null : reader["ResellerAlternateKey"].ToString();
                clsdbo_DimReseller.Phone = reader["Phone"] is DBNull ? null : reader["Phone"].ToString();
                clsdbo_DimReseller.BusinessType = System.Convert.ToString(reader["BusinessType"]);
                clsdbo_DimReseller.ResellerName = System.Convert.ToString(reader["ResellerName"]);
                clsdbo_DimReseller.NumberEmployees = reader["NumberEmployees"] is DBNull ? null : (Int32?)reader["NumberEmployees"];
                clsdbo_DimReseller.OrderFrequency = reader["OrderFrequency"] is DBNull ? null : reader["OrderFrequency"].ToString();
                clsdbo_DimReseller.OrderMonth = reader["OrderMonth"] is DBNull ? null : (Byte?)reader["OrderMonth"];
                clsdbo_DimReseller.FirstOrderYear = reader["FirstOrderYear"] is DBNull ? null : (Int32?)reader["FirstOrderYear"];
                clsdbo_DimReseller.LastOrderYear = reader["LastOrderYear"] is DBNull ? null : (Int32?)reader["LastOrderYear"];
                clsdbo_DimReseller.ProductLine = reader["ProductLine"] is DBNull ? null : reader["ProductLine"].ToString();
                clsdbo_DimReseller.AddressLine1 = reader["AddressLine1"] is DBNull ? null : reader["AddressLine1"].ToString();
                clsdbo_DimReseller.AddressLine2 = reader["AddressLine2"] is DBNull ? null : reader["AddressLine2"].ToString();
                clsdbo_DimReseller.AnnualSales = reader["AnnualSales"] is DBNull ? null : (Decimal?)reader["AnnualSales"];
                clsdbo_DimReseller.BankName = reader["BankName"] is DBNull ? null : reader["BankName"].ToString();
                clsdbo_DimReseller.MinPaymentType = reader["MinPaymentType"] is DBNull ? null : (Byte?)reader["MinPaymentType"];
                clsdbo_DimReseller.MinPaymentAmount = reader["MinPaymentAmount"] is DBNull ? null : (Decimal?)reader["MinPaymentAmount"];
                clsdbo_DimReseller.AnnualRevenue = reader["AnnualRevenue"] is DBNull ? null : (Decimal?)reader["AnnualRevenue"];
                clsdbo_DimReseller.YearOpened = reader["YearOpened"] is DBNull ? null : (Int32?)reader["YearOpened"];
            }
            else
            {
                clsdbo_DimReseller = null;
            }
            reader.Close();
        }
        catch (SqlException)
        {
            return clsdbo_DimReseller;
        }
        finally
        {
            connection.Close();
        }
        return clsdbo_DimReseller;
    }

    public static bool Add(dbo_DimResellerClass clsdbo_DimReseller)
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string insertStatement
            = "INSERT " 
            + "     [dbo].[DimReseller] "
            + "     ( "
            + "     [GeographyKey] "
            + "    ,[ResellerAlternateKey] "
            + "    ,[Phone] "
            + "    ,[BusinessType] "
            + "    ,[ResellerName] "
            + "    ,[NumberEmployees] "
            + "    ,[OrderFrequency] "
            + "    ,[OrderMonth] "
            + "    ,[FirstOrderYear] "
            + "    ,[LastOrderYear] "
            + "    ,[ProductLine] "
            + "    ,[AddressLine1] "
            + "    ,[AddressLine2] "
            + "    ,[AnnualSales] "
            + "    ,[BankName] "
            + "    ,[MinPaymentType] "
            + "    ,[MinPaymentAmount] "
            + "    ,[AnnualRevenue] "
            + "    ,[YearOpened] "
            + "     ) "
            + "VALUES " 
            + "     ( "
            + "     @GeographyKey "
            + "    ,@ResellerAlternateKey "
            + "    ,@Phone "
            + "    ,@BusinessType "
            + "    ,@ResellerName "
            + "    ,@NumberEmployees "
            + "    ,@OrderFrequency "
            + "    ,@OrderMonth "
            + "    ,@FirstOrderYear "
            + "    ,@LastOrderYear "
            + "    ,@ProductLine "
            + "    ,@AddressLine1 "
            + "    ,@AddressLine2 "
            + "    ,@AnnualSales "
            + "    ,@BankName "
            + "    ,@MinPaymentType "
            + "    ,@MinPaymentAmount "
            + "    ,@AnnualRevenue "
            + "    ,@YearOpened "
            + "     ) "
            + "";
        SqlCommand insertCommand = new SqlCommand(insertStatement, connection);
        insertCommand.CommandType = CommandType.Text;
        if (clsdbo_DimReseller.GeographyKey.HasValue == true) {
            insertCommand.Parameters.AddWithValue("@GeographyKey", clsdbo_DimReseller.GeographyKey);
        } else {
            insertCommand.Parameters.AddWithValue("@GeographyKey", DBNull.Value); }
        if (clsdbo_DimReseller.ResellerAlternateKey != null) {
            insertCommand.Parameters.AddWithValue("@ResellerAlternateKey", clsdbo_DimReseller.ResellerAlternateKey);
        } else {
            insertCommand.Parameters.AddWithValue("@ResellerAlternateKey", DBNull.Value); }
        if (clsdbo_DimReseller.Phone != null) {
            insertCommand.Parameters.AddWithValue("@Phone", clsdbo_DimReseller.Phone);
        } else {
            insertCommand.Parameters.AddWithValue("@Phone", DBNull.Value); }
        insertCommand.Parameters.AddWithValue("@BusinessType", clsdbo_DimReseller.BusinessType);
        insertCommand.Parameters.AddWithValue("@ResellerName", clsdbo_DimReseller.ResellerName);
        if (clsdbo_DimReseller.NumberEmployees.HasValue == true) {
            insertCommand.Parameters.AddWithValue("@NumberEmployees", clsdbo_DimReseller.NumberEmployees);
        } else {
            insertCommand.Parameters.AddWithValue("@NumberEmployees", DBNull.Value); }
        if (clsdbo_DimReseller.OrderFrequency != null) {
            insertCommand.Parameters.AddWithValue("@OrderFrequency", clsdbo_DimReseller.OrderFrequency);
        } else {
            insertCommand.Parameters.AddWithValue("@OrderFrequency", DBNull.Value); }
        if (clsdbo_DimReseller.OrderMonth.HasValue == true) {
            insertCommand.Parameters.AddWithValue("@OrderMonth", clsdbo_DimReseller.OrderMonth);
        } else {
            insertCommand.Parameters.AddWithValue("@OrderMonth", DBNull.Value); }
        if (clsdbo_DimReseller.FirstOrderYear.HasValue == true) {
            insertCommand.Parameters.AddWithValue("@FirstOrderYear", clsdbo_DimReseller.FirstOrderYear);
        } else {
            insertCommand.Parameters.AddWithValue("@FirstOrderYear", DBNull.Value); }
        if (clsdbo_DimReseller.LastOrderYear.HasValue == true) {
            insertCommand.Parameters.AddWithValue("@LastOrderYear", clsdbo_DimReseller.LastOrderYear);
        } else {
            insertCommand.Parameters.AddWithValue("@LastOrderYear", DBNull.Value); }
        if (clsdbo_DimReseller.ProductLine != null) {
            insertCommand.Parameters.AddWithValue("@ProductLine", clsdbo_DimReseller.ProductLine);
        } else {
            insertCommand.Parameters.AddWithValue("@ProductLine", DBNull.Value); }
        if (clsdbo_DimReseller.AddressLine1 != null) {
            insertCommand.Parameters.AddWithValue("@AddressLine1", clsdbo_DimReseller.AddressLine1);
        } else {
            insertCommand.Parameters.AddWithValue("@AddressLine1", DBNull.Value); }
        if (clsdbo_DimReseller.AddressLine2 != null) {
            insertCommand.Parameters.AddWithValue("@AddressLine2", clsdbo_DimReseller.AddressLine2);
        } else {
            insertCommand.Parameters.AddWithValue("@AddressLine2", DBNull.Value); }
        if (clsdbo_DimReseller.AnnualSales.HasValue == true) {
            insertCommand.Parameters.AddWithValue("@AnnualSales", clsdbo_DimReseller.AnnualSales);
        } else {
            insertCommand.Parameters.AddWithValue("@AnnualSales", DBNull.Value); }
        if (clsdbo_DimReseller.BankName != null) {
            insertCommand.Parameters.AddWithValue("@BankName", clsdbo_DimReseller.BankName);
        } else {
            insertCommand.Parameters.AddWithValue("@BankName", DBNull.Value); }
        if (clsdbo_DimReseller.MinPaymentType.HasValue == true) {
            insertCommand.Parameters.AddWithValue("@MinPaymentType", clsdbo_DimReseller.MinPaymentType);
        } else {
            insertCommand.Parameters.AddWithValue("@MinPaymentType", DBNull.Value); }
        if (clsdbo_DimReseller.MinPaymentAmount.HasValue == true) {
            insertCommand.Parameters.AddWithValue("@MinPaymentAmount", clsdbo_DimReseller.MinPaymentAmount);
        } else {
            insertCommand.Parameters.AddWithValue("@MinPaymentAmount", DBNull.Value); }
        if (clsdbo_DimReseller.AnnualRevenue.HasValue == true) {
            insertCommand.Parameters.AddWithValue("@AnnualRevenue", clsdbo_DimReseller.AnnualRevenue);
        } else {
            insertCommand.Parameters.AddWithValue("@AnnualRevenue", DBNull.Value); }
        if (clsdbo_DimReseller.YearOpened.HasValue == true) {
            insertCommand.Parameters.AddWithValue("@YearOpened", clsdbo_DimReseller.YearOpened);
        } else {
            insertCommand.Parameters.AddWithValue("@YearOpened", DBNull.Value); }
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

    public static bool Update(dbo_DimResellerClass olddbo_DimResellerClass, 
           dbo_DimResellerClass newdbo_DimResellerClass)
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string updateStatement
            = "UPDATE "  
            + "     [dbo].[DimReseller] "
            + "SET "
            + "     [GeographyKey] = @NewGeographyKey "
            + "    ,[ResellerAlternateKey] = @NewResellerAlternateKey "
            + "    ,[Phone] = @NewPhone "
            + "    ,[BusinessType] = @NewBusinessType "
            + "    ,[ResellerName] = @NewResellerName "
            + "    ,[NumberEmployees] = @NewNumberEmployees "
            + "    ,[OrderFrequency] = @NewOrderFrequency "
            + "    ,[OrderMonth] = @NewOrderMonth "
            + "    ,[FirstOrderYear] = @NewFirstOrderYear "
            + "    ,[LastOrderYear] = @NewLastOrderYear "
            + "    ,[ProductLine] = @NewProductLine "
            + "    ,[AddressLine1] = @NewAddressLine1 "
            + "    ,[AddressLine2] = @NewAddressLine2 "
            + "    ,[AnnualSales] = @NewAnnualSales "
            + "    ,[BankName] = @NewBankName "
            + "    ,[MinPaymentType] = @NewMinPaymentType "
            + "    ,[MinPaymentAmount] = @NewMinPaymentAmount "
            + "    ,[AnnualRevenue] = @NewAnnualRevenue "
            + "    ,[YearOpened] = @NewYearOpened "
            + "WHERE "
            + "     [ResellerKey] = @OldResellerKey " 
            + " AND ((@OldGeographyKey IS NULL AND [GeographyKey] IS NULL) OR [GeographyKey] = @OldGeographyKey) " 
            + " AND ((@OldResellerAlternateKey IS NULL AND [ResellerAlternateKey] IS NULL) OR [ResellerAlternateKey] = @OldResellerAlternateKey) " 
            + " AND ((@OldPhone IS NULL AND [Phone] IS NULL) OR [Phone] = @OldPhone) " 
            + " AND [BusinessType] = @OldBusinessType " 
            + " AND [ResellerName] = @OldResellerName " 
            + " AND ((@OldNumberEmployees IS NULL AND [NumberEmployees] IS NULL) OR [NumberEmployees] = @OldNumberEmployees) " 
            + " AND ((@OldOrderFrequency IS NULL AND [OrderFrequency] IS NULL) OR [OrderFrequency] = @OldOrderFrequency) " 
            + " AND ((@OldOrderMonth IS NULL AND [OrderMonth] IS NULL) OR [OrderMonth] = @OldOrderMonth) " 
            + " AND ((@OldFirstOrderYear IS NULL AND [FirstOrderYear] IS NULL) OR [FirstOrderYear] = @OldFirstOrderYear) " 
            + " AND ((@OldLastOrderYear IS NULL AND [LastOrderYear] IS NULL) OR [LastOrderYear] = @OldLastOrderYear) " 
            + " AND ((@OldProductLine IS NULL AND [ProductLine] IS NULL) OR [ProductLine] = @OldProductLine) " 
            + " AND ((@OldAddressLine1 IS NULL AND [AddressLine1] IS NULL) OR [AddressLine1] = @OldAddressLine1) " 
            + " AND ((@OldAddressLine2 IS NULL AND [AddressLine2] IS NULL) OR [AddressLine2] = @OldAddressLine2) " 
            + " AND ((@OldAnnualSales IS NULL AND [AnnualSales] IS NULL) OR [AnnualSales] = @OldAnnualSales) " 
            + " AND ((@OldBankName IS NULL AND [BankName] IS NULL) OR [BankName] = @OldBankName) " 
            + " AND ((@OldMinPaymentType IS NULL AND [MinPaymentType] IS NULL) OR [MinPaymentType] = @OldMinPaymentType) " 
            + " AND ((@OldMinPaymentAmount IS NULL AND [MinPaymentAmount] IS NULL) OR [MinPaymentAmount] = @OldMinPaymentAmount) " 
            + " AND ((@OldAnnualRevenue IS NULL AND [AnnualRevenue] IS NULL) OR [AnnualRevenue] = @OldAnnualRevenue) " 
            + " AND ((@OldYearOpened IS NULL AND [YearOpened] IS NULL) OR [YearOpened] = @OldYearOpened) " 
            + "";
        SqlCommand updateCommand = new SqlCommand(updateStatement, connection);
        updateCommand.CommandType = CommandType.Text;
        if (newdbo_DimResellerClass.GeographyKey.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@NewGeographyKey", newdbo_DimResellerClass.GeographyKey);
        } else {
            updateCommand.Parameters.AddWithValue("@NewGeographyKey", DBNull.Value); }
        if (newdbo_DimResellerClass.ResellerAlternateKey != null) {
            updateCommand.Parameters.AddWithValue("@NewResellerAlternateKey", newdbo_DimResellerClass.ResellerAlternateKey);
        } else {
            updateCommand.Parameters.AddWithValue("@NewResellerAlternateKey", DBNull.Value); }
        if (newdbo_DimResellerClass.Phone != null) {
            updateCommand.Parameters.AddWithValue("@NewPhone", newdbo_DimResellerClass.Phone);
        } else {
            updateCommand.Parameters.AddWithValue("@NewPhone", DBNull.Value); }
        updateCommand.Parameters.AddWithValue("@NewBusinessType", newdbo_DimResellerClass.BusinessType);
        updateCommand.Parameters.AddWithValue("@NewResellerName", newdbo_DimResellerClass.ResellerName);
        if (newdbo_DimResellerClass.NumberEmployees.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@NewNumberEmployees", newdbo_DimResellerClass.NumberEmployees);
        } else {
            updateCommand.Parameters.AddWithValue("@NewNumberEmployees", DBNull.Value); }
        if (newdbo_DimResellerClass.OrderFrequency != null) {
            updateCommand.Parameters.AddWithValue("@NewOrderFrequency", newdbo_DimResellerClass.OrderFrequency);
        } else {
            updateCommand.Parameters.AddWithValue("@NewOrderFrequency", DBNull.Value); }
        if (newdbo_DimResellerClass.OrderMonth.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@NewOrderMonth", newdbo_DimResellerClass.OrderMonth);
        } else {
            updateCommand.Parameters.AddWithValue("@NewOrderMonth", DBNull.Value); }
        if (newdbo_DimResellerClass.FirstOrderYear.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@NewFirstOrderYear", newdbo_DimResellerClass.FirstOrderYear);
        } else {
            updateCommand.Parameters.AddWithValue("@NewFirstOrderYear", DBNull.Value); }
        if (newdbo_DimResellerClass.LastOrderYear.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@NewLastOrderYear", newdbo_DimResellerClass.LastOrderYear);
        } else {
            updateCommand.Parameters.AddWithValue("@NewLastOrderYear", DBNull.Value); }
        if (newdbo_DimResellerClass.ProductLine != null) {
            updateCommand.Parameters.AddWithValue("@NewProductLine", newdbo_DimResellerClass.ProductLine);
        } else {
            updateCommand.Parameters.AddWithValue("@NewProductLine", DBNull.Value); }
        if (newdbo_DimResellerClass.AddressLine1 != null) {
            updateCommand.Parameters.AddWithValue("@NewAddressLine1", newdbo_DimResellerClass.AddressLine1);
        } else {
            updateCommand.Parameters.AddWithValue("@NewAddressLine1", DBNull.Value); }
        if (newdbo_DimResellerClass.AddressLine2 != null) {
            updateCommand.Parameters.AddWithValue("@NewAddressLine2", newdbo_DimResellerClass.AddressLine2);
        } else {
            updateCommand.Parameters.AddWithValue("@NewAddressLine2", DBNull.Value); }
        if (newdbo_DimResellerClass.AnnualSales.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@NewAnnualSales", newdbo_DimResellerClass.AnnualSales);
        } else {
            updateCommand.Parameters.AddWithValue("@NewAnnualSales", DBNull.Value); }
        if (newdbo_DimResellerClass.BankName != null) {
            updateCommand.Parameters.AddWithValue("@NewBankName", newdbo_DimResellerClass.BankName);
        } else {
            updateCommand.Parameters.AddWithValue("@NewBankName", DBNull.Value); }
        if (newdbo_DimResellerClass.MinPaymentType.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@NewMinPaymentType", newdbo_DimResellerClass.MinPaymentType);
        } else {
            updateCommand.Parameters.AddWithValue("@NewMinPaymentType", DBNull.Value); }
        if (newdbo_DimResellerClass.MinPaymentAmount.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@NewMinPaymentAmount", newdbo_DimResellerClass.MinPaymentAmount);
        } else {
            updateCommand.Parameters.AddWithValue("@NewMinPaymentAmount", DBNull.Value); }
        if (newdbo_DimResellerClass.AnnualRevenue.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@NewAnnualRevenue", newdbo_DimResellerClass.AnnualRevenue);
        } else {
            updateCommand.Parameters.AddWithValue("@NewAnnualRevenue", DBNull.Value); }
        if (newdbo_DimResellerClass.YearOpened.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@NewYearOpened", newdbo_DimResellerClass.YearOpened);
        } else {
            updateCommand.Parameters.AddWithValue("@NewYearOpened", DBNull.Value); }
        updateCommand.Parameters.AddWithValue("@OldResellerKey", olddbo_DimResellerClass.ResellerKey);
        if (olddbo_DimResellerClass.GeographyKey.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@OldGeographyKey", olddbo_DimResellerClass.GeographyKey);
        } else {
            updateCommand.Parameters.AddWithValue("@OldGeographyKey", DBNull.Value); }
        if (olddbo_DimResellerClass.ResellerAlternateKey != null) {
            updateCommand.Parameters.AddWithValue("@OldResellerAlternateKey", olddbo_DimResellerClass.ResellerAlternateKey);
        } else {
            updateCommand.Parameters.AddWithValue("@OldResellerAlternateKey", DBNull.Value); }
        if (olddbo_DimResellerClass.Phone != null) {
            updateCommand.Parameters.AddWithValue("@OldPhone", olddbo_DimResellerClass.Phone);
        } else {
            updateCommand.Parameters.AddWithValue("@OldPhone", DBNull.Value); }
        updateCommand.Parameters.AddWithValue("@OldBusinessType", olddbo_DimResellerClass.BusinessType);
        updateCommand.Parameters.AddWithValue("@OldResellerName", olddbo_DimResellerClass.ResellerName);
        if (olddbo_DimResellerClass.NumberEmployees.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@OldNumberEmployees", olddbo_DimResellerClass.NumberEmployees);
        } else {
            updateCommand.Parameters.AddWithValue("@OldNumberEmployees", DBNull.Value); }
        if (olddbo_DimResellerClass.OrderFrequency != null) {
            updateCommand.Parameters.AddWithValue("@OldOrderFrequency", olddbo_DimResellerClass.OrderFrequency);
        } else {
            updateCommand.Parameters.AddWithValue("@OldOrderFrequency", DBNull.Value); }
        if (olddbo_DimResellerClass.OrderMonth.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@OldOrderMonth", olddbo_DimResellerClass.OrderMonth);
        } else {
            updateCommand.Parameters.AddWithValue("@OldOrderMonth", DBNull.Value); }
        if (olddbo_DimResellerClass.FirstOrderYear.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@OldFirstOrderYear", olddbo_DimResellerClass.FirstOrderYear);
        } else {
            updateCommand.Parameters.AddWithValue("@OldFirstOrderYear", DBNull.Value); }
        if (olddbo_DimResellerClass.LastOrderYear.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@OldLastOrderYear", olddbo_DimResellerClass.LastOrderYear);
        } else {
            updateCommand.Parameters.AddWithValue("@OldLastOrderYear", DBNull.Value); }
        if (olddbo_DimResellerClass.ProductLine != null) {
            updateCommand.Parameters.AddWithValue("@OldProductLine", olddbo_DimResellerClass.ProductLine);
        } else {
            updateCommand.Parameters.AddWithValue("@OldProductLine", DBNull.Value); }
        if (olddbo_DimResellerClass.AddressLine1 != null) {
            updateCommand.Parameters.AddWithValue("@OldAddressLine1", olddbo_DimResellerClass.AddressLine1);
        } else {
            updateCommand.Parameters.AddWithValue("@OldAddressLine1", DBNull.Value); }
        if (olddbo_DimResellerClass.AddressLine2 != null) {
            updateCommand.Parameters.AddWithValue("@OldAddressLine2", olddbo_DimResellerClass.AddressLine2);
        } else {
            updateCommand.Parameters.AddWithValue("@OldAddressLine2", DBNull.Value); }
        if (olddbo_DimResellerClass.AnnualSales.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@OldAnnualSales", olddbo_DimResellerClass.AnnualSales);
        } else {
            updateCommand.Parameters.AddWithValue("@OldAnnualSales", DBNull.Value); }
        if (olddbo_DimResellerClass.BankName != null) {
            updateCommand.Parameters.AddWithValue("@OldBankName", olddbo_DimResellerClass.BankName);
        } else {
            updateCommand.Parameters.AddWithValue("@OldBankName", DBNull.Value); }
        if (olddbo_DimResellerClass.MinPaymentType.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@OldMinPaymentType", olddbo_DimResellerClass.MinPaymentType);
        } else {
            updateCommand.Parameters.AddWithValue("@OldMinPaymentType", DBNull.Value); }
        if (olddbo_DimResellerClass.MinPaymentAmount.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@OldMinPaymentAmount", olddbo_DimResellerClass.MinPaymentAmount);
        } else {
            updateCommand.Parameters.AddWithValue("@OldMinPaymentAmount", DBNull.Value); }
        if (olddbo_DimResellerClass.AnnualRevenue.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@OldAnnualRevenue", olddbo_DimResellerClass.AnnualRevenue);
        } else {
            updateCommand.Parameters.AddWithValue("@OldAnnualRevenue", DBNull.Value); }
        if (olddbo_DimResellerClass.YearOpened.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@OldYearOpened", olddbo_DimResellerClass.YearOpened);
        } else {
            updateCommand.Parameters.AddWithValue("@OldYearOpened", DBNull.Value); }
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

    public static bool Delete(dbo_DimResellerClass clsdbo_DimReseller)
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string deleteStatement
            = "DELETE FROM "  
            + "     [dbo].[DimReseller] "
            + "WHERE " 
            + "     [ResellerKey] = @OldResellerKey " 
            + " AND ((@OldGeographyKey IS NULL AND [GeographyKey] IS NULL) OR [GeographyKey] = @OldGeographyKey) " 
            + " AND ((@OldResellerAlternateKey IS NULL AND [ResellerAlternateKey] IS NULL) OR [ResellerAlternateKey] = @OldResellerAlternateKey) " 
            + " AND ((@OldPhone IS NULL AND [Phone] IS NULL) OR [Phone] = @OldPhone) " 
            + " AND [BusinessType] = @OldBusinessType " 
            + " AND [ResellerName] = @OldResellerName " 
            + " AND ((@OldNumberEmployees IS NULL AND [NumberEmployees] IS NULL) OR [NumberEmployees] = @OldNumberEmployees) " 
            + " AND ((@OldOrderFrequency IS NULL AND [OrderFrequency] IS NULL) OR [OrderFrequency] = @OldOrderFrequency) " 
            + " AND ((@OldOrderMonth IS NULL AND [OrderMonth] IS NULL) OR [OrderMonth] = @OldOrderMonth) " 
            + " AND ((@OldFirstOrderYear IS NULL AND [FirstOrderYear] IS NULL) OR [FirstOrderYear] = @OldFirstOrderYear) " 
            + " AND ((@OldLastOrderYear IS NULL AND [LastOrderYear] IS NULL) OR [LastOrderYear] = @OldLastOrderYear) " 
            + " AND ((@OldProductLine IS NULL AND [ProductLine] IS NULL) OR [ProductLine] = @OldProductLine) " 
            + " AND ((@OldAddressLine1 IS NULL AND [AddressLine1] IS NULL) OR [AddressLine1] = @OldAddressLine1) " 
            + " AND ((@OldAddressLine2 IS NULL AND [AddressLine2] IS NULL) OR [AddressLine2] = @OldAddressLine2) " 
            + " AND ((@OldAnnualSales IS NULL AND [AnnualSales] IS NULL) OR [AnnualSales] = @OldAnnualSales) " 
            + " AND ((@OldBankName IS NULL AND [BankName] IS NULL) OR [BankName] = @OldBankName) " 
            + " AND ((@OldMinPaymentType IS NULL AND [MinPaymentType] IS NULL) OR [MinPaymentType] = @OldMinPaymentType) " 
            + " AND ((@OldMinPaymentAmount IS NULL AND [MinPaymentAmount] IS NULL) OR [MinPaymentAmount] = @OldMinPaymentAmount) " 
            + " AND ((@OldAnnualRevenue IS NULL AND [AnnualRevenue] IS NULL) OR [AnnualRevenue] = @OldAnnualRevenue) " 
            + " AND ((@OldYearOpened IS NULL AND [YearOpened] IS NULL) OR [YearOpened] = @OldYearOpened) " 
            + "";
        SqlCommand deleteCommand = new SqlCommand(deleteStatement, connection);
        deleteCommand.CommandType = CommandType.Text;
        deleteCommand.Parameters.AddWithValue("@OldResellerKey", clsdbo_DimReseller.ResellerKey);
        if (clsdbo_DimReseller.GeographyKey.HasValue == true) {
            deleteCommand.Parameters.AddWithValue("@OldGeographyKey", clsdbo_DimReseller.GeographyKey);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldGeographyKey", DBNull.Value); }
        if (clsdbo_DimReseller.ResellerAlternateKey != null) {
            deleteCommand.Parameters.AddWithValue("@OldResellerAlternateKey", clsdbo_DimReseller.ResellerAlternateKey);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldResellerAlternateKey", DBNull.Value); }
        if (clsdbo_DimReseller.Phone != null) {
            deleteCommand.Parameters.AddWithValue("@OldPhone", clsdbo_DimReseller.Phone);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldPhone", DBNull.Value); }
        deleteCommand.Parameters.AddWithValue("@OldBusinessType", clsdbo_DimReseller.BusinessType);
        deleteCommand.Parameters.AddWithValue("@OldResellerName", clsdbo_DimReseller.ResellerName);
        if (clsdbo_DimReseller.NumberEmployees.HasValue == true) {
            deleteCommand.Parameters.AddWithValue("@OldNumberEmployees", clsdbo_DimReseller.NumberEmployees);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldNumberEmployees", DBNull.Value); }
        if (clsdbo_DimReseller.OrderFrequency != null) {
            deleteCommand.Parameters.AddWithValue("@OldOrderFrequency", clsdbo_DimReseller.OrderFrequency);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldOrderFrequency", DBNull.Value); }
        if (clsdbo_DimReseller.OrderMonth.HasValue == true) {
            deleteCommand.Parameters.AddWithValue("@OldOrderMonth", clsdbo_DimReseller.OrderMonth);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldOrderMonth", DBNull.Value); }
        if (clsdbo_DimReseller.FirstOrderYear.HasValue == true) {
            deleteCommand.Parameters.AddWithValue("@OldFirstOrderYear", clsdbo_DimReseller.FirstOrderYear);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldFirstOrderYear", DBNull.Value); }
        if (clsdbo_DimReseller.LastOrderYear.HasValue == true) {
            deleteCommand.Parameters.AddWithValue("@OldLastOrderYear", clsdbo_DimReseller.LastOrderYear);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldLastOrderYear", DBNull.Value); }
        if (clsdbo_DimReseller.ProductLine != null) {
            deleteCommand.Parameters.AddWithValue("@OldProductLine", clsdbo_DimReseller.ProductLine);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldProductLine", DBNull.Value); }
        if (clsdbo_DimReseller.AddressLine1 != null) {
            deleteCommand.Parameters.AddWithValue("@OldAddressLine1", clsdbo_DimReseller.AddressLine1);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldAddressLine1", DBNull.Value); }
        if (clsdbo_DimReseller.AddressLine2 != null) {
            deleteCommand.Parameters.AddWithValue("@OldAddressLine2", clsdbo_DimReseller.AddressLine2);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldAddressLine2", DBNull.Value); }
        if (clsdbo_DimReseller.AnnualSales.HasValue == true) {
            deleteCommand.Parameters.AddWithValue("@OldAnnualSales", clsdbo_DimReseller.AnnualSales);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldAnnualSales", DBNull.Value); }
        if (clsdbo_DimReseller.BankName != null) {
            deleteCommand.Parameters.AddWithValue("@OldBankName", clsdbo_DimReseller.BankName);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldBankName", DBNull.Value); }
        if (clsdbo_DimReseller.MinPaymentType.HasValue == true) {
            deleteCommand.Parameters.AddWithValue("@OldMinPaymentType", clsdbo_DimReseller.MinPaymentType);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldMinPaymentType", DBNull.Value); }
        if (clsdbo_DimReseller.MinPaymentAmount.HasValue == true) {
            deleteCommand.Parameters.AddWithValue("@OldMinPaymentAmount", clsdbo_DimReseller.MinPaymentAmount);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldMinPaymentAmount", DBNull.Value); }
        if (clsdbo_DimReseller.AnnualRevenue.HasValue == true) {
            deleteCommand.Parameters.AddWithValue("@OldAnnualRevenue", clsdbo_DimReseller.AnnualRevenue);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldAnnualRevenue", DBNull.Value); }
        if (clsdbo_DimReseller.YearOpened.HasValue == true) {
            deleteCommand.Parameters.AddWithValue("@OldYearOpened", clsdbo_DimReseller.YearOpened);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldYearOpened", DBNull.Value); }
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

 
