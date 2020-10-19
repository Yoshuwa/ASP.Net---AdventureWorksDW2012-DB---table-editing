using System;
using System.Data;
using System.Data.SqlClient;

public class dbo_DimGeographyDataClass
{

    public static DataTable SelectAll()
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement
            = "SELECT "  
            + "     [dbo].[DimGeography].[GeographyKey] "
            + "    ,[dbo].[DimGeography].[City] "
            + "    ,[dbo].[DimGeography].[StateProvinceCode] "
            + "    ,[dbo].[DimGeography].[StateProvinceName] "
            + "    ,[dbo].[DimGeography].[CountryRegionCode] "
            + "    ,[dbo].[DimGeography].[EnglishCountryRegionName] "
            + "    ,[dbo].[DimGeography].[SpanishCountryRegionName] "
            + "    ,[dbo].[DimGeography].[FrenchCountryRegionName] "
            + "    ,[dbo].[DimGeography].[PostalCode] "
            + "    ,[dbo].[DimSalesTerritory].[SalesTerritoryAlternateKey] "
            + "    ,[dbo].[DimGeography].[IpAddressLocator] "
            + "FROM " 
            + "     [dbo].[DimGeography] " 
            + "LEFT JOIN [dbo].[DimSalesTerritory] ON [dbo].[DimGeography].[SalesTerritoryKey] = [dbo].[DimSalesTerritory].[SalesTerritoryKey] "
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
            + "     [dbo].[DimGeography].[GeographyKey] "
            + "    ,[dbo].[DimGeography].[City] "
            + "    ,[dbo].[DimGeography].[StateProvinceCode] "
            + "    ,[dbo].[DimGeography].[StateProvinceName] "
            + "    ,[dbo].[DimGeography].[CountryRegionCode] "
            + "    ,[dbo].[DimGeography].[EnglishCountryRegionName] "
            + "    ,[dbo].[DimGeography].[SpanishCountryRegionName] "
            + "    ,[dbo].[DimGeography].[FrenchCountryRegionName] "
            + "    ,[dbo].[DimGeography].[PostalCode] "
            + "    ,[dbo].[DimSalesTerritory].[SalesTerritoryAlternateKey] "
            + "    ,[dbo].[DimGeography].[IpAddressLocator] "
            + "FROM " 
            + "     [dbo].[DimGeography] " 
            + "LEFT JOIN [dbo].[DimSalesTerritory] ON [dbo].[DimGeography].[SalesTerritoryKey] = [dbo].[DimSalesTerritory].[SalesTerritoryKey] "
                + "WHERE " 
                + "     (@GeographyKey IS NULL OR @GeographyKey = '' OR [DimGeography].[GeographyKey] LIKE '%' + LTRIM(RTRIM(@GeographyKey)) + '%') " 
                + "AND   (@City IS NULL OR @City = '' OR [DimGeography].[City] LIKE '%' + LTRIM(RTRIM(@City)) + '%') " 
                + "AND   (@StateProvinceCode IS NULL OR @StateProvinceCode = '' OR [DimGeography].[StateProvinceCode] LIKE '%' + LTRIM(RTRIM(@StateProvinceCode)) + '%') " 
                + "AND   (@StateProvinceName IS NULL OR @StateProvinceName = '' OR [DimGeography].[StateProvinceName] LIKE '%' + LTRIM(RTRIM(@StateProvinceName)) + '%') " 
                + "AND   (@CountryRegionCode IS NULL OR @CountryRegionCode = '' OR [DimGeography].[CountryRegionCode] LIKE '%' + LTRIM(RTRIM(@CountryRegionCode)) + '%') " 
                + "AND   (@EnglishCountryRegionName IS NULL OR @EnglishCountryRegionName = '' OR [DimGeography].[EnglishCountryRegionName] LIKE '%' + LTRIM(RTRIM(@EnglishCountryRegionName)) + '%') " 
                + "AND   (@SpanishCountryRegionName IS NULL OR @SpanishCountryRegionName = '' OR [DimGeography].[SpanishCountryRegionName] LIKE '%' + LTRIM(RTRIM(@SpanishCountryRegionName)) + '%') " 
                + "AND   (@FrenchCountryRegionName IS NULL OR @FrenchCountryRegionName = '' OR [DimGeography].[FrenchCountryRegionName] LIKE '%' + LTRIM(RTRIM(@FrenchCountryRegionName)) + '%') " 
                + "AND   (@PostalCode IS NULL OR @PostalCode = '' OR [DimGeography].[PostalCode] LIKE '%' + LTRIM(RTRIM(@PostalCode)) + '%') " 
                + "AND   (@SalesTerritoryAlternateKey IS NULL OR @SalesTerritoryAlternateKey = '' OR [dbo].[DimSalesTerritory].[SalesTerritoryAlternateKey] LIKE '%' + LTRIM(RTRIM(@SalesTerritoryAlternateKey)) + '%') " 
                + "AND   (@IpAddressLocator IS NULL OR @IpAddressLocator = '' OR [DimGeography].[IpAddressLocator] LIKE '%' + LTRIM(RTRIM(@IpAddressLocator)) + '%') " 
                + "";
        } else if (sCondition == "Equals") {
            selectStatement
                = "SELECT "
            + "     [dbo].[DimGeography].[GeographyKey] "
            + "    ,[dbo].[DimGeography].[City] "
            + "    ,[dbo].[DimGeography].[StateProvinceCode] "
            + "    ,[dbo].[DimGeography].[StateProvinceName] "
            + "    ,[dbo].[DimGeography].[CountryRegionCode] "
            + "    ,[dbo].[DimGeography].[EnglishCountryRegionName] "
            + "    ,[dbo].[DimGeography].[SpanishCountryRegionName] "
            + "    ,[dbo].[DimGeography].[FrenchCountryRegionName] "
            + "    ,[dbo].[DimGeography].[PostalCode] "
            + "    ,[dbo].[DimSalesTerritory].[SalesTerritoryAlternateKey] "
            + "    ,[dbo].[DimGeography].[IpAddressLocator] "
            + "FROM " 
            + "     [dbo].[DimGeography] " 
            + "LEFT JOIN [dbo].[DimSalesTerritory] ON [dbo].[DimGeography].[SalesTerritoryKey] = [dbo].[DimSalesTerritory].[SalesTerritoryKey] "
                + "WHERE " 
                + "     (@GeographyKey IS NULL OR @GeographyKey = '' OR [DimGeography].[GeographyKey] = LTRIM(RTRIM(@GeographyKey))) " 
                + "AND   (@City IS NULL OR @City = '' OR [DimGeography].[City] = LTRIM(RTRIM(@City))) " 
                + "AND   (@StateProvinceCode IS NULL OR @StateProvinceCode = '' OR [DimGeography].[StateProvinceCode] = LTRIM(RTRIM(@StateProvinceCode))) " 
                + "AND   (@StateProvinceName IS NULL OR @StateProvinceName = '' OR [DimGeography].[StateProvinceName] = LTRIM(RTRIM(@StateProvinceName))) " 
                + "AND   (@CountryRegionCode IS NULL OR @CountryRegionCode = '' OR [DimGeography].[CountryRegionCode] = LTRIM(RTRIM(@CountryRegionCode))) " 
                + "AND   (@EnglishCountryRegionName IS NULL OR @EnglishCountryRegionName = '' OR [DimGeography].[EnglishCountryRegionName] = LTRIM(RTRIM(@EnglishCountryRegionName))) " 
                + "AND   (@SpanishCountryRegionName IS NULL OR @SpanishCountryRegionName = '' OR [DimGeography].[SpanishCountryRegionName] = LTRIM(RTRIM(@SpanishCountryRegionName))) " 
                + "AND   (@FrenchCountryRegionName IS NULL OR @FrenchCountryRegionName = '' OR [DimGeography].[FrenchCountryRegionName] = LTRIM(RTRIM(@FrenchCountryRegionName))) " 
                + "AND   (@PostalCode IS NULL OR @PostalCode = '' OR [DimGeography].[PostalCode] = LTRIM(RTRIM(@PostalCode))) " 
                + "AND   (@SalesTerritoryAlternateKey IS NULL OR @SalesTerritoryAlternateKey = '' OR [dbo].[DimSalesTerritory].[SalesTerritoryAlternateKey] = LTRIM(RTRIM(@SalesTerritoryAlternateKey))) " 
                + "AND   (@IpAddressLocator IS NULL OR @IpAddressLocator = '' OR [DimGeography].[IpAddressLocator] = LTRIM(RTRIM(@IpAddressLocator))) " 
                + "";
        } else if  (sCondition == "Starts with...") {
            selectStatement
                = "SELECT "
            + "     [dbo].[DimGeography].[GeographyKey] "
            + "    ,[dbo].[DimGeography].[City] "
            + "    ,[dbo].[DimGeography].[StateProvinceCode] "
            + "    ,[dbo].[DimGeography].[StateProvinceName] "
            + "    ,[dbo].[DimGeography].[CountryRegionCode] "
            + "    ,[dbo].[DimGeography].[EnglishCountryRegionName] "
            + "    ,[dbo].[DimGeography].[SpanishCountryRegionName] "
            + "    ,[dbo].[DimGeography].[FrenchCountryRegionName] "
            + "    ,[dbo].[DimGeography].[PostalCode] "
            + "    ,[dbo].[DimSalesTerritory].[SalesTerritoryAlternateKey] "
            + "    ,[dbo].[DimGeography].[IpAddressLocator] "
            + "FROM " 
            + "     [dbo].[DimGeography] " 
            + "LEFT JOIN [dbo].[DimSalesTerritory] ON [dbo].[DimGeography].[SalesTerritoryKey] = [dbo].[DimSalesTerritory].[SalesTerritoryKey] "
                + "WHERE " 
                + "     (@GeographyKey IS NULL OR @GeographyKey = '' OR [DimGeography].[GeographyKey] LIKE LTRIM(RTRIM(@GeographyKey)) + '%') " 
                + "AND   (@City IS NULL OR @City = '' OR [DimGeography].[City] LIKE LTRIM(RTRIM(@City)) + '%') " 
                + "AND   (@StateProvinceCode IS NULL OR @StateProvinceCode = '' OR [DimGeography].[StateProvinceCode] LIKE LTRIM(RTRIM(@StateProvinceCode)) + '%') " 
                + "AND   (@StateProvinceName IS NULL OR @StateProvinceName = '' OR [DimGeography].[StateProvinceName] LIKE LTRIM(RTRIM(@StateProvinceName)) + '%') " 
                + "AND   (@CountryRegionCode IS NULL OR @CountryRegionCode = '' OR [DimGeography].[CountryRegionCode] LIKE LTRIM(RTRIM(@CountryRegionCode)) + '%') " 
                + "AND   (@EnglishCountryRegionName IS NULL OR @EnglishCountryRegionName = '' OR [DimGeography].[EnglishCountryRegionName] LIKE LTRIM(RTRIM(@EnglishCountryRegionName)) + '%') " 
                + "AND   (@SpanishCountryRegionName IS NULL OR @SpanishCountryRegionName = '' OR [DimGeography].[SpanishCountryRegionName] LIKE LTRIM(RTRIM(@SpanishCountryRegionName)) + '%') " 
                + "AND   (@FrenchCountryRegionName IS NULL OR @FrenchCountryRegionName = '' OR [DimGeography].[FrenchCountryRegionName] LIKE LTRIM(RTRIM(@FrenchCountryRegionName)) + '%') " 
                + "AND   (@PostalCode IS NULL OR @PostalCode = '' OR [DimGeography].[PostalCode] LIKE LTRIM(RTRIM(@PostalCode)) + '%') " 
                + "AND   (@SalesTerritoryAlternateKey IS NULL OR @SalesTerritoryAlternateKey = '' OR [dbo].[DimSalesTerritory].[SalesTerritoryAlternateKey] LIKE LTRIM(RTRIM(@SalesTerritoryAlternateKey)) + '%') " 
                + "AND   (@IpAddressLocator IS NULL OR @IpAddressLocator = '' OR [DimGeography].[IpAddressLocator] LIKE LTRIM(RTRIM(@IpAddressLocator)) + '%') " 
                + "";
        } else if  (sCondition == "More than...") {
            selectStatement
                = "SELECT "
            + "     [dbo].[DimGeography].[GeographyKey] "
            + "    ,[dbo].[DimGeography].[City] "
            + "    ,[dbo].[DimGeography].[StateProvinceCode] "
            + "    ,[dbo].[DimGeography].[StateProvinceName] "
            + "    ,[dbo].[DimGeography].[CountryRegionCode] "
            + "    ,[dbo].[DimGeography].[EnglishCountryRegionName] "
            + "    ,[dbo].[DimGeography].[SpanishCountryRegionName] "
            + "    ,[dbo].[DimGeography].[FrenchCountryRegionName] "
            + "    ,[dbo].[DimGeography].[PostalCode] "
            + "    ,[dbo].[DimSalesTerritory].[SalesTerritoryAlternateKey] "
            + "    ,[dbo].[DimGeography].[IpAddressLocator] "
            + "FROM " 
            + "     [dbo].[DimGeography] " 
            + "LEFT JOIN [dbo].[DimSalesTerritory] ON [dbo].[DimGeography].[SalesTerritoryKey] = [dbo].[DimSalesTerritory].[SalesTerritoryKey] "
                + "WHERE " 
                + "     (@GeographyKey IS NULL OR @GeographyKey = '' OR [DimGeography].[GeographyKey] > LTRIM(RTRIM(@GeographyKey))) " 
                + "AND   (@City IS NULL OR @City = '' OR [DimGeography].[City] > LTRIM(RTRIM(@City))) " 
                + "AND   (@StateProvinceCode IS NULL OR @StateProvinceCode = '' OR [DimGeography].[StateProvinceCode] > LTRIM(RTRIM(@StateProvinceCode))) " 
                + "AND   (@StateProvinceName IS NULL OR @StateProvinceName = '' OR [DimGeography].[StateProvinceName] > LTRIM(RTRIM(@StateProvinceName))) " 
                + "AND   (@CountryRegionCode IS NULL OR @CountryRegionCode = '' OR [DimGeography].[CountryRegionCode] > LTRIM(RTRIM(@CountryRegionCode))) " 
                + "AND   (@EnglishCountryRegionName IS NULL OR @EnglishCountryRegionName = '' OR [DimGeography].[EnglishCountryRegionName] > LTRIM(RTRIM(@EnglishCountryRegionName))) " 
                + "AND   (@SpanishCountryRegionName IS NULL OR @SpanishCountryRegionName = '' OR [DimGeography].[SpanishCountryRegionName] > LTRIM(RTRIM(@SpanishCountryRegionName))) " 
                + "AND   (@FrenchCountryRegionName IS NULL OR @FrenchCountryRegionName = '' OR [DimGeography].[FrenchCountryRegionName] > LTRIM(RTRIM(@FrenchCountryRegionName))) " 
                + "AND   (@PostalCode IS NULL OR @PostalCode = '' OR [DimGeography].[PostalCode] > LTRIM(RTRIM(@PostalCode))) " 
                + "AND   (@SalesTerritoryAlternateKey IS NULL OR @SalesTerritoryAlternateKey = '' OR [dbo].[DimSalesTerritory].[SalesTerritoryAlternateKey] > LTRIM(RTRIM(@SalesTerritoryAlternateKey))) " 
                + "AND   (@IpAddressLocator IS NULL OR @IpAddressLocator = '' OR [DimGeography].[IpAddressLocator] > LTRIM(RTRIM(@IpAddressLocator))) " 
                + "";
        } else if  (sCondition == "Less than...") {
            selectStatement
                = "SELECT " 
            + "     [dbo].[DimGeography].[GeographyKey] "
            + "    ,[dbo].[DimGeography].[City] "
            + "    ,[dbo].[DimGeography].[StateProvinceCode] "
            + "    ,[dbo].[DimGeography].[StateProvinceName] "
            + "    ,[dbo].[DimGeography].[CountryRegionCode] "
            + "    ,[dbo].[DimGeography].[EnglishCountryRegionName] "
            + "    ,[dbo].[DimGeography].[SpanishCountryRegionName] "
            + "    ,[dbo].[DimGeography].[FrenchCountryRegionName] "
            + "    ,[dbo].[DimGeography].[PostalCode] "
            + "    ,[dbo].[DimSalesTerritory].[SalesTerritoryAlternateKey] "
            + "    ,[dbo].[DimGeography].[IpAddressLocator] "
            + "FROM " 
            + "     [dbo].[DimGeography] " 
            + "LEFT JOIN [dbo].[DimSalesTerritory] ON [dbo].[DimGeography].[SalesTerritoryKey] = [dbo].[DimSalesTerritory].[SalesTerritoryKey] "
                + "WHERE " 
                + "     (@GeographyKey IS NULL OR @GeographyKey = '' OR [DimGeography].[GeographyKey] < LTRIM(RTRIM(@GeographyKey))) " 
                + "AND   (@City IS NULL OR @City = '' OR [DimGeography].[City] < LTRIM(RTRIM(@City))) " 
                + "AND   (@StateProvinceCode IS NULL OR @StateProvinceCode = '' OR [DimGeography].[StateProvinceCode] < LTRIM(RTRIM(@StateProvinceCode))) " 
                + "AND   (@StateProvinceName IS NULL OR @StateProvinceName = '' OR [DimGeography].[StateProvinceName] < LTRIM(RTRIM(@StateProvinceName))) " 
                + "AND   (@CountryRegionCode IS NULL OR @CountryRegionCode = '' OR [DimGeography].[CountryRegionCode] < LTRIM(RTRIM(@CountryRegionCode))) " 
                + "AND   (@EnglishCountryRegionName IS NULL OR @EnglishCountryRegionName = '' OR [DimGeography].[EnglishCountryRegionName] < LTRIM(RTRIM(@EnglishCountryRegionName))) " 
                + "AND   (@SpanishCountryRegionName IS NULL OR @SpanishCountryRegionName = '' OR [DimGeography].[SpanishCountryRegionName] < LTRIM(RTRIM(@SpanishCountryRegionName))) " 
                + "AND   (@FrenchCountryRegionName IS NULL OR @FrenchCountryRegionName = '' OR [DimGeography].[FrenchCountryRegionName] < LTRIM(RTRIM(@FrenchCountryRegionName))) " 
                + "AND   (@PostalCode IS NULL OR @PostalCode = '' OR [DimGeography].[PostalCode] < LTRIM(RTRIM(@PostalCode))) " 
                + "AND   (@SalesTerritoryAlternateKey IS NULL OR @SalesTerritoryAlternateKey = '' OR [dbo].[DimSalesTerritory].[SalesTerritoryAlternateKey] < LTRIM(RTRIM(@SalesTerritoryAlternateKey))) " 
                + "AND   (@IpAddressLocator IS NULL OR @IpAddressLocator = '' OR [DimGeography].[IpAddressLocator] < LTRIM(RTRIM(@IpAddressLocator))) " 
                + "";
        } else if  (sCondition == "Equal or more than...") {
            selectStatement
                = "SELECT "
            + "     [dbo].[DimGeography].[GeographyKey] "
            + "    ,[dbo].[DimGeography].[City] "
            + "    ,[dbo].[DimGeography].[StateProvinceCode] "
            + "    ,[dbo].[DimGeography].[StateProvinceName] "
            + "    ,[dbo].[DimGeography].[CountryRegionCode] "
            + "    ,[dbo].[DimGeography].[EnglishCountryRegionName] "
            + "    ,[dbo].[DimGeography].[SpanishCountryRegionName] "
            + "    ,[dbo].[DimGeography].[FrenchCountryRegionName] "
            + "    ,[dbo].[DimGeography].[PostalCode] "
            + "    ,[dbo].[DimSalesTerritory].[SalesTerritoryAlternateKey] "
            + "    ,[dbo].[DimGeography].[IpAddressLocator] "
            + "FROM " 
            + "     [dbo].[DimGeography] " 
            + "LEFT JOIN [dbo].[DimSalesTerritory] ON [dbo].[DimGeography].[SalesTerritoryKey] = [dbo].[DimSalesTerritory].[SalesTerritoryKey] "
                + "WHERE " 
                + "     (@GeographyKey IS NULL OR @GeographyKey = '' OR [DimGeography].[GeographyKey] >= LTRIM(RTRIM(@GeographyKey))) " 
                + "AND   (@City IS NULL OR @City = '' OR [DimGeography].[City] >= LTRIM(RTRIM(@City))) " 
                + "AND   (@StateProvinceCode IS NULL OR @StateProvinceCode = '' OR [DimGeography].[StateProvinceCode] >= LTRIM(RTRIM(@StateProvinceCode))) " 
                + "AND   (@StateProvinceName IS NULL OR @StateProvinceName = '' OR [DimGeography].[StateProvinceName] >= LTRIM(RTRIM(@StateProvinceName))) " 
                + "AND   (@CountryRegionCode IS NULL OR @CountryRegionCode = '' OR [DimGeography].[CountryRegionCode] >= LTRIM(RTRIM(@CountryRegionCode))) " 
                + "AND   (@EnglishCountryRegionName IS NULL OR @EnglishCountryRegionName = '' OR [DimGeography].[EnglishCountryRegionName] >= LTRIM(RTRIM(@EnglishCountryRegionName))) " 
                + "AND   (@SpanishCountryRegionName IS NULL OR @SpanishCountryRegionName = '' OR [DimGeography].[SpanishCountryRegionName] >= LTRIM(RTRIM(@SpanishCountryRegionName))) " 
                + "AND   (@FrenchCountryRegionName IS NULL OR @FrenchCountryRegionName = '' OR [DimGeography].[FrenchCountryRegionName] >= LTRIM(RTRIM(@FrenchCountryRegionName))) " 
                + "AND   (@PostalCode IS NULL OR @PostalCode = '' OR [DimGeography].[PostalCode] >= LTRIM(RTRIM(@PostalCode))) " 
                + "AND   (@SalesTerritoryAlternateKey IS NULL OR @SalesTerritoryAlternateKey = '' OR [dbo].[DimSalesTerritory].[SalesTerritoryAlternateKey] >= LTRIM(RTRIM(@SalesTerritoryAlternateKey))) " 
                + "AND   (@IpAddressLocator IS NULL OR @IpAddressLocator = '' OR [DimGeography].[IpAddressLocator] >= LTRIM(RTRIM(@IpAddressLocator))) " 
                + "";
        } else if (sCondition == "Equal or less than...") {
            selectStatement 
                = "SELECT "
            + "     [dbo].[DimGeography].[GeographyKey] "
            + "    ,[dbo].[DimGeography].[City] "
            + "    ,[dbo].[DimGeography].[StateProvinceCode] "
            + "    ,[dbo].[DimGeography].[StateProvinceName] "
            + "    ,[dbo].[DimGeography].[CountryRegionCode] "
            + "    ,[dbo].[DimGeography].[EnglishCountryRegionName] "
            + "    ,[dbo].[DimGeography].[SpanishCountryRegionName] "
            + "    ,[dbo].[DimGeography].[FrenchCountryRegionName] "
            + "    ,[dbo].[DimGeography].[PostalCode] "
            + "    ,[dbo].[DimSalesTerritory].[SalesTerritoryAlternateKey] "
            + "    ,[dbo].[DimGeography].[IpAddressLocator] "
            + "FROM " 
            + "     [dbo].[DimGeography] " 
            + "LEFT JOIN [dbo].[DimSalesTerritory] ON [dbo].[DimGeography].[SalesTerritoryKey] = [dbo].[DimSalesTerritory].[SalesTerritoryKey] "
                + "WHERE " 
                + "     (@GeographyKey IS NULL OR @GeographyKey = '' OR [DimGeography].[GeographyKey] <= LTRIM(RTRIM(@GeographyKey))) " 
                + "AND   (@City IS NULL OR @City = '' OR [DimGeography].[City] <= LTRIM(RTRIM(@City))) " 
                + "AND   (@StateProvinceCode IS NULL OR @StateProvinceCode = '' OR [DimGeography].[StateProvinceCode] <= LTRIM(RTRIM(@StateProvinceCode))) " 
                + "AND   (@StateProvinceName IS NULL OR @StateProvinceName = '' OR [DimGeography].[StateProvinceName] <= LTRIM(RTRIM(@StateProvinceName))) " 
                + "AND   (@CountryRegionCode IS NULL OR @CountryRegionCode = '' OR [DimGeography].[CountryRegionCode] <= LTRIM(RTRIM(@CountryRegionCode))) " 
                + "AND   (@EnglishCountryRegionName IS NULL OR @EnglishCountryRegionName = '' OR [DimGeography].[EnglishCountryRegionName] <= LTRIM(RTRIM(@EnglishCountryRegionName))) " 
                + "AND   (@SpanishCountryRegionName IS NULL OR @SpanishCountryRegionName = '' OR [DimGeography].[SpanishCountryRegionName] <= LTRIM(RTRIM(@SpanishCountryRegionName))) " 
                + "AND   (@FrenchCountryRegionName IS NULL OR @FrenchCountryRegionName = '' OR [DimGeography].[FrenchCountryRegionName] <= LTRIM(RTRIM(@FrenchCountryRegionName))) " 
                + "AND   (@PostalCode IS NULL OR @PostalCode = '' OR [DimGeography].[PostalCode] <= LTRIM(RTRIM(@PostalCode))) " 
                + "AND   (@SalesTerritoryAlternateKey IS NULL OR @SalesTerritoryAlternateKey = '' OR [dbo].[DimSalesTerritory].[SalesTerritoryAlternateKey] <= LTRIM(RTRIM(@SalesTerritoryAlternateKey))) " 
                + "AND   (@IpAddressLocator IS NULL OR @IpAddressLocator = '' OR [DimGeography].[IpAddressLocator] <= LTRIM(RTRIM(@IpAddressLocator))) " 
                + "";
        }
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        selectCommand.CommandType = CommandType.Text;
        if (sField == "Geography Key") {
            selectCommand.Parameters.AddWithValue("@GeographyKey", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@GeographyKey", DBNull.Value); }
        if (sField == "City") {
            selectCommand.Parameters.AddWithValue("@City", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@City", DBNull.Value); }
        if (sField == "State Province Code") {
            selectCommand.Parameters.AddWithValue("@StateProvinceCode", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@StateProvinceCode", DBNull.Value); }
        if (sField == "State Province Name") {
            selectCommand.Parameters.AddWithValue("@StateProvinceName", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@StateProvinceName", DBNull.Value); }
        if (sField == "Country Region Code") {
            selectCommand.Parameters.AddWithValue("@CountryRegionCode", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@CountryRegionCode", DBNull.Value); }
        if (sField == "English Country Region Name") {
            selectCommand.Parameters.AddWithValue("@EnglishCountryRegionName", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@EnglishCountryRegionName", DBNull.Value); }
        if (sField == "Spanish Country Region Name") {
            selectCommand.Parameters.AddWithValue("@SpanishCountryRegionName", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@SpanishCountryRegionName", DBNull.Value); }
        if (sField == "French Country Region Name") {
            selectCommand.Parameters.AddWithValue("@FrenchCountryRegionName", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@FrenchCountryRegionName", DBNull.Value); }
        if (sField == "Postal Code") {
            selectCommand.Parameters.AddWithValue("@PostalCode", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@PostalCode", DBNull.Value); }
        if (sField == "Sales Territory Key") {
            selectCommand.Parameters.AddWithValue("@SalesTerritoryAlternateKey", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@SalesTerritoryAlternateKey", DBNull.Value); }
        if (sField == "Ip Address Locator") {
            selectCommand.Parameters.AddWithValue("@IpAddressLocator", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@IpAddressLocator", DBNull.Value); }
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

    public static dbo_DimGeographyClass Select_Record(dbo_DimGeographyClass clsdbo_DimGeographyPara)
    {
        dbo_DimGeographyClass clsdbo_DimGeography = new dbo_DimGeographyClass();
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement
            = "SELECT " 
            + "     [GeographyKey] "
            + "    ,[City] "
            + "    ,[StateProvinceCode] "
            + "    ,[StateProvinceName] "
            + "    ,[CountryRegionCode] "
            + "    ,[EnglishCountryRegionName] "
            + "    ,[SpanishCountryRegionName] "
            + "    ,[FrenchCountryRegionName] "
            + "    ,[PostalCode] "
            + "    ,[SalesTerritoryKey] "
            + "    ,[IpAddressLocator] "
            + "FROM "
            + "     [dbo].[DimGeography] "
            + "WHERE "
            + "     [GeographyKey] = @GeographyKey "
            + "";
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        selectCommand.CommandType = CommandType.Text;
        selectCommand.Parameters.AddWithValue("@GeographyKey", clsdbo_DimGeographyPara.GeographyKey);
        try
        {
            connection.Open();
            SqlDataReader reader
                = selectCommand.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                clsdbo_DimGeography.GeographyKey = System.Convert.ToInt32(reader["GeographyKey"]);
                clsdbo_DimGeography.City = reader["City"] is DBNull ? null : reader["City"].ToString();
                clsdbo_DimGeography.StateProvinceCode = reader["StateProvinceCode"] is DBNull ? null : reader["StateProvinceCode"].ToString();
                clsdbo_DimGeography.StateProvinceName = reader["StateProvinceName"] is DBNull ? null : reader["StateProvinceName"].ToString();
                clsdbo_DimGeography.CountryRegionCode = reader["CountryRegionCode"] is DBNull ? null : reader["CountryRegionCode"].ToString();
                clsdbo_DimGeography.EnglishCountryRegionName = reader["EnglishCountryRegionName"] is DBNull ? null : reader["EnglishCountryRegionName"].ToString();
                clsdbo_DimGeography.SpanishCountryRegionName = reader["SpanishCountryRegionName"] is DBNull ? null : reader["SpanishCountryRegionName"].ToString();
                clsdbo_DimGeography.FrenchCountryRegionName = reader["FrenchCountryRegionName"] is DBNull ? null : reader["FrenchCountryRegionName"].ToString();
                clsdbo_DimGeography.PostalCode = reader["PostalCode"] is DBNull ? null : reader["PostalCode"].ToString();
                clsdbo_DimGeography.SalesTerritoryKey = reader["SalesTerritoryKey"] is DBNull ? null : (Int32?)reader["SalesTerritoryKey"];
                clsdbo_DimGeography.IpAddressLocator = reader["IpAddressLocator"] is DBNull ? null : reader["IpAddressLocator"].ToString();
            }
            else
            {
                clsdbo_DimGeography = null;
            }
            reader.Close();
        }
        catch (SqlException)
        {
            return clsdbo_DimGeography;
        }
        finally
        {
            connection.Close();
        }
        return clsdbo_DimGeography;
    }

    public static bool Add(dbo_DimGeographyClass clsdbo_DimGeography)
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string insertStatement
            = "INSERT " 
            + "     [dbo].[DimGeography] "
            + "     ( "
            + "     [City] "
            + "    ,[StateProvinceCode] "
            + "    ,[StateProvinceName] "
            + "    ,[CountryRegionCode] "
            + "    ,[EnglishCountryRegionName] "
            + "    ,[SpanishCountryRegionName] "
            + "    ,[FrenchCountryRegionName] "
            + "    ,[PostalCode] "
            + "    ,[SalesTerritoryKey] "
            + "    ,[IpAddressLocator] "
            + "     ) "
            + "VALUES " 
            + "     ( "
            + "     @City "
            + "    ,@StateProvinceCode "
            + "    ,@StateProvinceName "
            + "    ,@CountryRegionCode "
            + "    ,@EnglishCountryRegionName "
            + "    ,@SpanishCountryRegionName "
            + "    ,@FrenchCountryRegionName "
            + "    ,@PostalCode "
            + "    ,@SalesTerritoryKey "
            + "    ,@IpAddressLocator "
            + "     ) "
            + "";
        SqlCommand insertCommand = new SqlCommand(insertStatement, connection);
        insertCommand.CommandType = CommandType.Text;
        if (clsdbo_DimGeography.City != null) {
            insertCommand.Parameters.AddWithValue("@City", clsdbo_DimGeography.City);
        } else {
            insertCommand.Parameters.AddWithValue("@City", DBNull.Value); }
        if (clsdbo_DimGeography.StateProvinceCode != null) {
            insertCommand.Parameters.AddWithValue("@StateProvinceCode", clsdbo_DimGeography.StateProvinceCode);
        } else {
            insertCommand.Parameters.AddWithValue("@StateProvinceCode", DBNull.Value); }
        if (clsdbo_DimGeography.StateProvinceName != null) {
            insertCommand.Parameters.AddWithValue("@StateProvinceName", clsdbo_DimGeography.StateProvinceName);
        } else {
            insertCommand.Parameters.AddWithValue("@StateProvinceName", DBNull.Value); }
        if (clsdbo_DimGeography.CountryRegionCode != null) {
            insertCommand.Parameters.AddWithValue("@CountryRegionCode", clsdbo_DimGeography.CountryRegionCode);
        } else {
            insertCommand.Parameters.AddWithValue("@CountryRegionCode", DBNull.Value); }
        if (clsdbo_DimGeography.EnglishCountryRegionName != null) {
            insertCommand.Parameters.AddWithValue("@EnglishCountryRegionName", clsdbo_DimGeography.EnglishCountryRegionName);
        } else {
            insertCommand.Parameters.AddWithValue("@EnglishCountryRegionName", DBNull.Value); }
        if (clsdbo_DimGeography.SpanishCountryRegionName != null) {
            insertCommand.Parameters.AddWithValue("@SpanishCountryRegionName", clsdbo_DimGeography.SpanishCountryRegionName);
        } else {
            insertCommand.Parameters.AddWithValue("@SpanishCountryRegionName", DBNull.Value); }
        if (clsdbo_DimGeography.FrenchCountryRegionName != null) {
            insertCommand.Parameters.AddWithValue("@FrenchCountryRegionName", clsdbo_DimGeography.FrenchCountryRegionName);
        } else {
            insertCommand.Parameters.AddWithValue("@FrenchCountryRegionName", DBNull.Value); }
        if (clsdbo_DimGeography.PostalCode != null) {
            insertCommand.Parameters.AddWithValue("@PostalCode", clsdbo_DimGeography.PostalCode);
        } else {
            insertCommand.Parameters.AddWithValue("@PostalCode", DBNull.Value); }
        if (clsdbo_DimGeography.SalesTerritoryKey.HasValue == true) {
            insertCommand.Parameters.AddWithValue("@SalesTerritoryKey", clsdbo_DimGeography.SalesTerritoryKey);
        } else {
            insertCommand.Parameters.AddWithValue("@SalesTerritoryKey", DBNull.Value); }
        if (clsdbo_DimGeography.IpAddressLocator != null) {
            insertCommand.Parameters.AddWithValue("@IpAddressLocator", clsdbo_DimGeography.IpAddressLocator);
        } else {
            insertCommand.Parameters.AddWithValue("@IpAddressLocator", DBNull.Value); }
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

    public static bool Update(dbo_DimGeographyClass olddbo_DimGeographyClass, 
           dbo_DimGeographyClass newdbo_DimGeographyClass)
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string updateStatement
            = "UPDATE "  
            + "     [dbo].[DimGeography] "
            + "SET "
            + "     [City] = @NewCity "
            + "    ,[StateProvinceCode] = @NewStateProvinceCode "
            + "    ,[StateProvinceName] = @NewStateProvinceName "
            + "    ,[CountryRegionCode] = @NewCountryRegionCode "
            + "    ,[EnglishCountryRegionName] = @NewEnglishCountryRegionName "
            + "    ,[SpanishCountryRegionName] = @NewSpanishCountryRegionName "
            + "    ,[FrenchCountryRegionName] = @NewFrenchCountryRegionName "
            + "    ,[PostalCode] = @NewPostalCode "
            + "    ,[SalesTerritoryKey] = @NewSalesTerritoryKey "
            + "    ,[IpAddressLocator] = @NewIpAddressLocator "
            + "WHERE "
            + "     [GeographyKey] = @OldGeographyKey " 
            + " AND ((@OldCity IS NULL AND [City] IS NULL) OR [City] = @OldCity) " 
            + " AND ((@OldStateProvinceCode IS NULL AND [StateProvinceCode] IS NULL) OR [StateProvinceCode] = @OldStateProvinceCode) " 
            + " AND ((@OldStateProvinceName IS NULL AND [StateProvinceName] IS NULL) OR [StateProvinceName] = @OldStateProvinceName) " 
            + " AND ((@OldCountryRegionCode IS NULL AND [CountryRegionCode] IS NULL) OR [CountryRegionCode] = @OldCountryRegionCode) " 
            + " AND ((@OldEnglishCountryRegionName IS NULL AND [EnglishCountryRegionName] IS NULL) OR [EnglishCountryRegionName] = @OldEnglishCountryRegionName) " 
            + " AND ((@OldSpanishCountryRegionName IS NULL AND [SpanishCountryRegionName] IS NULL) OR [SpanishCountryRegionName] = @OldSpanishCountryRegionName) " 
            + " AND ((@OldFrenchCountryRegionName IS NULL AND [FrenchCountryRegionName] IS NULL) OR [FrenchCountryRegionName] = @OldFrenchCountryRegionName) " 
            + " AND ((@OldPostalCode IS NULL AND [PostalCode] IS NULL) OR [PostalCode] = @OldPostalCode) " 
            + " AND ((@OldSalesTerritoryKey IS NULL AND [SalesTerritoryKey] IS NULL) OR [SalesTerritoryKey] = @OldSalesTerritoryKey) " 
            + " AND ((@OldIpAddressLocator IS NULL AND [IpAddressLocator] IS NULL) OR [IpAddressLocator] = @OldIpAddressLocator) " 
            + "";
        SqlCommand updateCommand = new SqlCommand(updateStatement, connection);
        updateCommand.CommandType = CommandType.Text;
        if (newdbo_DimGeographyClass.City != null) {
            updateCommand.Parameters.AddWithValue("@NewCity", newdbo_DimGeographyClass.City);
        } else {
            updateCommand.Parameters.AddWithValue("@NewCity", DBNull.Value); }
        if (newdbo_DimGeographyClass.StateProvinceCode != null) {
            updateCommand.Parameters.AddWithValue("@NewStateProvinceCode", newdbo_DimGeographyClass.StateProvinceCode);
        } else {
            updateCommand.Parameters.AddWithValue("@NewStateProvinceCode", DBNull.Value); }
        if (newdbo_DimGeographyClass.StateProvinceName != null) {
            updateCommand.Parameters.AddWithValue("@NewStateProvinceName", newdbo_DimGeographyClass.StateProvinceName);
        } else {
            updateCommand.Parameters.AddWithValue("@NewStateProvinceName", DBNull.Value); }
        if (newdbo_DimGeographyClass.CountryRegionCode != null) {
            updateCommand.Parameters.AddWithValue("@NewCountryRegionCode", newdbo_DimGeographyClass.CountryRegionCode);
        } else {
            updateCommand.Parameters.AddWithValue("@NewCountryRegionCode", DBNull.Value); }
        if (newdbo_DimGeographyClass.EnglishCountryRegionName != null) {
            updateCommand.Parameters.AddWithValue("@NewEnglishCountryRegionName", newdbo_DimGeographyClass.EnglishCountryRegionName);
        } else {
            updateCommand.Parameters.AddWithValue("@NewEnglishCountryRegionName", DBNull.Value); }
        if (newdbo_DimGeographyClass.SpanishCountryRegionName != null) {
            updateCommand.Parameters.AddWithValue("@NewSpanishCountryRegionName", newdbo_DimGeographyClass.SpanishCountryRegionName);
        } else {
            updateCommand.Parameters.AddWithValue("@NewSpanishCountryRegionName", DBNull.Value); }
        if (newdbo_DimGeographyClass.FrenchCountryRegionName != null) {
            updateCommand.Parameters.AddWithValue("@NewFrenchCountryRegionName", newdbo_DimGeographyClass.FrenchCountryRegionName);
        } else {
            updateCommand.Parameters.AddWithValue("@NewFrenchCountryRegionName", DBNull.Value); }
        if (newdbo_DimGeographyClass.PostalCode != null) {
            updateCommand.Parameters.AddWithValue("@NewPostalCode", newdbo_DimGeographyClass.PostalCode);
        } else {
            updateCommand.Parameters.AddWithValue("@NewPostalCode", DBNull.Value); }
        if (newdbo_DimGeographyClass.SalesTerritoryKey.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@NewSalesTerritoryKey", newdbo_DimGeographyClass.SalesTerritoryKey);
        } else {
            updateCommand.Parameters.AddWithValue("@NewSalesTerritoryKey", DBNull.Value); }
        if (newdbo_DimGeographyClass.IpAddressLocator != null) {
            updateCommand.Parameters.AddWithValue("@NewIpAddressLocator", newdbo_DimGeographyClass.IpAddressLocator);
        } else {
            updateCommand.Parameters.AddWithValue("@NewIpAddressLocator", DBNull.Value); }
        updateCommand.Parameters.AddWithValue("@OldGeographyKey", olddbo_DimGeographyClass.GeographyKey);
        if (olddbo_DimGeographyClass.City != null) {
            updateCommand.Parameters.AddWithValue("@OldCity", olddbo_DimGeographyClass.City);
        } else {
            updateCommand.Parameters.AddWithValue("@OldCity", DBNull.Value); }
        if (olddbo_DimGeographyClass.StateProvinceCode != null) {
            updateCommand.Parameters.AddWithValue("@OldStateProvinceCode", olddbo_DimGeographyClass.StateProvinceCode);
        } else {
            updateCommand.Parameters.AddWithValue("@OldStateProvinceCode", DBNull.Value); }
        if (olddbo_DimGeographyClass.StateProvinceName != null) {
            updateCommand.Parameters.AddWithValue("@OldStateProvinceName", olddbo_DimGeographyClass.StateProvinceName);
        } else {
            updateCommand.Parameters.AddWithValue("@OldStateProvinceName", DBNull.Value); }
        if (olddbo_DimGeographyClass.CountryRegionCode != null) {
            updateCommand.Parameters.AddWithValue("@OldCountryRegionCode", olddbo_DimGeographyClass.CountryRegionCode);
        } else {
            updateCommand.Parameters.AddWithValue("@OldCountryRegionCode", DBNull.Value); }
        if (olddbo_DimGeographyClass.EnglishCountryRegionName != null) {
            updateCommand.Parameters.AddWithValue("@OldEnglishCountryRegionName", olddbo_DimGeographyClass.EnglishCountryRegionName);
        } else {
            updateCommand.Parameters.AddWithValue("@OldEnglishCountryRegionName", DBNull.Value); }
        if (olddbo_DimGeographyClass.SpanishCountryRegionName != null) {
            updateCommand.Parameters.AddWithValue("@OldSpanishCountryRegionName", olddbo_DimGeographyClass.SpanishCountryRegionName);
        } else {
            updateCommand.Parameters.AddWithValue("@OldSpanishCountryRegionName", DBNull.Value); }
        if (olddbo_DimGeographyClass.FrenchCountryRegionName != null) {
            updateCommand.Parameters.AddWithValue("@OldFrenchCountryRegionName", olddbo_DimGeographyClass.FrenchCountryRegionName);
        } else {
            updateCommand.Parameters.AddWithValue("@OldFrenchCountryRegionName", DBNull.Value); }
        if (olddbo_DimGeographyClass.PostalCode != null) {
            updateCommand.Parameters.AddWithValue("@OldPostalCode", olddbo_DimGeographyClass.PostalCode);
        } else {
            updateCommand.Parameters.AddWithValue("@OldPostalCode", DBNull.Value); }
        if (olddbo_DimGeographyClass.SalesTerritoryKey.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@OldSalesTerritoryKey", olddbo_DimGeographyClass.SalesTerritoryKey);
        } else {
            updateCommand.Parameters.AddWithValue("@OldSalesTerritoryKey", DBNull.Value); }
        if (olddbo_DimGeographyClass.IpAddressLocator != null) {
            updateCommand.Parameters.AddWithValue("@OldIpAddressLocator", olddbo_DimGeographyClass.IpAddressLocator);
        } else {
            updateCommand.Parameters.AddWithValue("@OldIpAddressLocator", DBNull.Value); }
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

    public static bool Delete(dbo_DimGeographyClass clsdbo_DimGeography)
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string deleteStatement
            = "DELETE FROM "  
            + "     [dbo].[DimGeography] "
            + "WHERE " 
            + "     [GeographyKey] = @OldGeographyKey " 
            + " AND ((@OldCity IS NULL AND [City] IS NULL) OR [City] = @OldCity) " 
            + " AND ((@OldStateProvinceCode IS NULL AND [StateProvinceCode] IS NULL) OR [StateProvinceCode] = @OldStateProvinceCode) " 
            + " AND ((@OldStateProvinceName IS NULL AND [StateProvinceName] IS NULL) OR [StateProvinceName] = @OldStateProvinceName) " 
            + " AND ((@OldCountryRegionCode IS NULL AND [CountryRegionCode] IS NULL) OR [CountryRegionCode] = @OldCountryRegionCode) " 
            + " AND ((@OldEnglishCountryRegionName IS NULL AND [EnglishCountryRegionName] IS NULL) OR [EnglishCountryRegionName] = @OldEnglishCountryRegionName) " 
            + " AND ((@OldSpanishCountryRegionName IS NULL AND [SpanishCountryRegionName] IS NULL) OR [SpanishCountryRegionName] = @OldSpanishCountryRegionName) " 
            + " AND ((@OldFrenchCountryRegionName IS NULL AND [FrenchCountryRegionName] IS NULL) OR [FrenchCountryRegionName] = @OldFrenchCountryRegionName) " 
            + " AND ((@OldPostalCode IS NULL AND [PostalCode] IS NULL) OR [PostalCode] = @OldPostalCode) " 
            + " AND ((@OldSalesTerritoryKey IS NULL AND [SalesTerritoryKey] IS NULL) OR [SalesTerritoryKey] = @OldSalesTerritoryKey) " 
            + " AND ((@OldIpAddressLocator IS NULL AND [IpAddressLocator] IS NULL) OR [IpAddressLocator] = @OldIpAddressLocator) " 
            + "";
        SqlCommand deleteCommand = new SqlCommand(deleteStatement, connection);
        deleteCommand.CommandType = CommandType.Text;
        deleteCommand.Parameters.AddWithValue("@OldGeographyKey", clsdbo_DimGeography.GeographyKey);
        if (clsdbo_DimGeography.City != null) {
            deleteCommand.Parameters.AddWithValue("@OldCity", clsdbo_DimGeography.City);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldCity", DBNull.Value); }
        if (clsdbo_DimGeography.StateProvinceCode != null) {
            deleteCommand.Parameters.AddWithValue("@OldStateProvinceCode", clsdbo_DimGeography.StateProvinceCode);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldStateProvinceCode", DBNull.Value); }
        if (clsdbo_DimGeography.StateProvinceName != null) {
            deleteCommand.Parameters.AddWithValue("@OldStateProvinceName", clsdbo_DimGeography.StateProvinceName);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldStateProvinceName", DBNull.Value); }
        if (clsdbo_DimGeography.CountryRegionCode != null) {
            deleteCommand.Parameters.AddWithValue("@OldCountryRegionCode", clsdbo_DimGeography.CountryRegionCode);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldCountryRegionCode", DBNull.Value); }
        if (clsdbo_DimGeography.EnglishCountryRegionName != null) {
            deleteCommand.Parameters.AddWithValue("@OldEnglishCountryRegionName", clsdbo_DimGeography.EnglishCountryRegionName);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldEnglishCountryRegionName", DBNull.Value); }
        if (clsdbo_DimGeography.SpanishCountryRegionName != null) {
            deleteCommand.Parameters.AddWithValue("@OldSpanishCountryRegionName", clsdbo_DimGeography.SpanishCountryRegionName);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldSpanishCountryRegionName", DBNull.Value); }
        if (clsdbo_DimGeography.FrenchCountryRegionName != null) {
            deleteCommand.Parameters.AddWithValue("@OldFrenchCountryRegionName", clsdbo_DimGeography.FrenchCountryRegionName);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldFrenchCountryRegionName", DBNull.Value); }
        if (clsdbo_DimGeography.PostalCode != null) {
            deleteCommand.Parameters.AddWithValue("@OldPostalCode", clsdbo_DimGeography.PostalCode);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldPostalCode", DBNull.Value); }
        if (clsdbo_DimGeography.SalesTerritoryKey.HasValue == true) {
            deleteCommand.Parameters.AddWithValue("@OldSalesTerritoryKey", clsdbo_DimGeography.SalesTerritoryKey);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldSalesTerritoryKey", DBNull.Value); }
        if (clsdbo_DimGeography.IpAddressLocator != null) {
            deleteCommand.Parameters.AddWithValue("@OldIpAddressLocator", clsdbo_DimGeography.IpAddressLocator);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldIpAddressLocator", DBNull.Value); }
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

 
