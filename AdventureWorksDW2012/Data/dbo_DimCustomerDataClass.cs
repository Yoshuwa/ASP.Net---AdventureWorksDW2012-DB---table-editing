using System;
using System.Data;
using System.Data.SqlClient;

public class dbo_DimCustomerDataClass
{

    public static DataTable SelectAll()
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement
            = "SELECT "  
            + "     [dbo].[DimCustomer].[CustomerKey] "
            + "    ,[dbo].[DimGeography].[StateProvinceName] "
            + "    ,[dbo].[DimCustomer].[CustomerAlternateKey] "
            + "    ,[dbo].[DimCustomer].[Title] "
            + "    ,[dbo].[DimCustomer].[FirstName] "
            + "    ,[dbo].[DimCustomer].[MiddleName] "
            + "    ,[dbo].[DimCustomer].[LastName] "
            + "    ,[dbo].[DimCustomer].[NameStyle] "
            + "    ,[dbo].[DimCustomer].[BirthDate] "
            + "    ,[dbo].[DimCustomer].[MaritalStatus] "
            + "    ,[dbo].[DimCustomer].[Suffix] "
            + "    ,[dbo].[DimCustomer].[Gender] "
            + "    ,[dbo].[DimCustomer].[EmailAddress] "
            + "    ,[dbo].[DimCustomer].[YearlyIncome] "
            + "    ,[dbo].[DimCustomer].[TotalChildren] "
            + "    ,[dbo].[DimCustomer].[NumberChildrenAtHome] "
            + "    ,[dbo].[DimCustomer].[EnglishEducation] "
            + "    ,[dbo].[DimCustomer].[SpanishEducation] "
            + "    ,[dbo].[DimCustomer].[FrenchEducation] "
            + "    ,[dbo].[DimCustomer].[EnglishOccupation] "
            + "    ,[dbo].[DimCustomer].[SpanishOccupation] "
            + "    ,[dbo].[DimCustomer].[FrenchOccupation] "
            + "    ,[dbo].[DimCustomer].[HouseOwnerFlag] "
            + "    ,[dbo].[DimCustomer].[NumberCarsOwned] "
            + "    ,[dbo].[DimCustomer].[AddressLine1] "
            + "    ,[dbo].[DimCustomer].[AddressLine2] "
            + "    ,[dbo].[DimCustomer].[Phone] "
            + "    ,[dbo].[DimCustomer].[DateFirstPurchase] "
            + "    ,[dbo].[DimCustomer].[CommuteDistance] "
            + "FROM " 
            + "     [dbo].[DimCustomer] " 
            + "LEFT JOIN [dbo].[DimGeography] ON [dbo].[DimCustomer].[GeographyKey] = [dbo].[DimGeography].[GeographyKey] "
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
            + "     [dbo].[DimCustomer].[CustomerKey] "
            + "    ,[dbo].[DimGeography].[StateProvinceName] "
            + "    ,[dbo].[DimCustomer].[CustomerAlternateKey] "
            + "    ,[dbo].[DimCustomer].[Title] "
            + "    ,[dbo].[DimCustomer].[FirstName] "
            + "    ,[dbo].[DimCustomer].[MiddleName] "
            + "    ,[dbo].[DimCustomer].[LastName] "
            + "    ,[dbo].[DimCustomer].[NameStyle] "
            + "    ,[dbo].[DimCustomer].[BirthDate] "
            + "    ,[dbo].[DimCustomer].[MaritalStatus] "
            + "    ,[dbo].[DimCustomer].[Suffix] "
            + "    ,[dbo].[DimCustomer].[Gender] "
            + "    ,[dbo].[DimCustomer].[EmailAddress] "
            + "    ,[dbo].[DimCustomer].[YearlyIncome] "
            + "    ,[dbo].[DimCustomer].[TotalChildren] "
            + "    ,[dbo].[DimCustomer].[NumberChildrenAtHome] "
            + "    ,[dbo].[DimCustomer].[EnglishEducation] "
            + "    ,[dbo].[DimCustomer].[SpanishEducation] "
            + "    ,[dbo].[DimCustomer].[FrenchEducation] "
            + "    ,[dbo].[DimCustomer].[EnglishOccupation] "
            + "    ,[dbo].[DimCustomer].[SpanishOccupation] "
            + "    ,[dbo].[DimCustomer].[FrenchOccupation] "
            + "    ,[dbo].[DimCustomer].[HouseOwnerFlag] "
            + "    ,[dbo].[DimCustomer].[NumberCarsOwned] "
            + "    ,[dbo].[DimCustomer].[AddressLine1] "
            + "    ,[dbo].[DimCustomer].[AddressLine2] "
            + "    ,[dbo].[DimCustomer].[Phone] "
            + "    ,[dbo].[DimCustomer].[DateFirstPurchase] "
            + "    ,[dbo].[DimCustomer].[CommuteDistance] "
            + "FROM " 
            + "     [dbo].[DimCustomer] " 
            + "LEFT JOIN [dbo].[DimGeography] ON [dbo].[DimCustomer].[GeographyKey] = [dbo].[DimGeography].[GeographyKey] "
                + "WHERE " 
                + "     (@CustomerKey IS NULL OR @CustomerKey = '' OR [DimCustomer].[CustomerKey] LIKE '%' + LTRIM(RTRIM(@CustomerKey)) + '%') " 
                + "AND   (@StateProvinceName IS NULL OR @StateProvinceName = '' OR [dbo].[DimGeography].[StateProvinceName] LIKE '%' + LTRIM(RTRIM(@StateProvinceName)) + '%') " 
                + "AND   (@CustomerAlternateKey IS NULL OR @CustomerAlternateKey = '' OR [DimCustomer].[CustomerAlternateKey] LIKE '%' + LTRIM(RTRIM(@CustomerAlternateKey)) + '%') " 
                + "AND   (@Title IS NULL OR @Title = '' OR [DimCustomer].[Title] LIKE '%' + LTRIM(RTRIM(@Title)) + '%') " 
                + "AND   (@FirstName IS NULL OR @FirstName = '' OR [DimCustomer].[FirstName] LIKE '%' + LTRIM(RTRIM(@FirstName)) + '%') " 
                + "AND   (@MiddleName IS NULL OR @MiddleName = '' OR [DimCustomer].[MiddleName] LIKE '%' + LTRIM(RTRIM(@MiddleName)) + '%') " 
                + "AND   (@LastName IS NULL OR @LastName = '' OR [DimCustomer].[LastName] LIKE '%' + LTRIM(RTRIM(@LastName)) + '%') " 
                + "AND   (@NameStyle IS NULL OR @NameStyle = '' OR [DimCustomer].[NameStyle] LIKE '%' + LTRIM(RTRIM(@NameStyle)) + '%') " 
                + "AND   (@BirthDate IS NULL OR @BirthDate = '' OR [DimCustomer].[BirthDate] LIKE '%' + LTRIM(RTRIM(@BirthDate)) + '%') " 
                + "AND   (@MaritalStatus IS NULL OR @MaritalStatus = '' OR [DimCustomer].[MaritalStatus] LIKE '%' + LTRIM(RTRIM(@MaritalStatus)) + '%') " 
                + "AND   (@Suffix IS NULL OR @Suffix = '' OR [DimCustomer].[Suffix] LIKE '%' + LTRIM(RTRIM(@Suffix)) + '%') " 
                + "AND   (@Gender IS NULL OR @Gender = '' OR [DimCustomer].[Gender] LIKE '%' + LTRIM(RTRIM(@Gender)) + '%') " 
                + "AND   (@EmailAddress IS NULL OR @EmailAddress = '' OR [DimCustomer].[EmailAddress] LIKE '%' + LTRIM(RTRIM(@EmailAddress)) + '%') " 
                + "AND   (@YearlyIncome IS NULL OR @YearlyIncome = '' OR [DimCustomer].[YearlyIncome] LIKE '%' + LTRIM(RTRIM(@YearlyIncome)) + '%') " 
                + "AND   (@TotalChildren IS NULL OR @TotalChildren = '' OR [DimCustomer].[TotalChildren] LIKE '%' + LTRIM(RTRIM(@TotalChildren)) + '%') " 
                + "AND   (@NumberChildrenAtHome IS NULL OR @NumberChildrenAtHome = '' OR [DimCustomer].[NumberChildrenAtHome] LIKE '%' + LTRIM(RTRIM(@NumberChildrenAtHome)) + '%') " 
                + "AND   (@EnglishEducation IS NULL OR @EnglishEducation = '' OR [DimCustomer].[EnglishEducation] LIKE '%' + LTRIM(RTRIM(@EnglishEducation)) + '%') " 
                + "AND   (@SpanishEducation IS NULL OR @SpanishEducation = '' OR [DimCustomer].[SpanishEducation] LIKE '%' + LTRIM(RTRIM(@SpanishEducation)) + '%') " 
                + "AND   (@FrenchEducation IS NULL OR @FrenchEducation = '' OR [DimCustomer].[FrenchEducation] LIKE '%' + LTRIM(RTRIM(@FrenchEducation)) + '%') " 
                + "AND   (@EnglishOccupation IS NULL OR @EnglishOccupation = '' OR [DimCustomer].[EnglishOccupation] LIKE '%' + LTRIM(RTRIM(@EnglishOccupation)) + '%') " 
                + "AND   (@SpanishOccupation IS NULL OR @SpanishOccupation = '' OR [DimCustomer].[SpanishOccupation] LIKE '%' + LTRIM(RTRIM(@SpanishOccupation)) + '%') " 
                + "AND   (@FrenchOccupation IS NULL OR @FrenchOccupation = '' OR [DimCustomer].[FrenchOccupation] LIKE '%' + LTRIM(RTRIM(@FrenchOccupation)) + '%') " 
                + "AND   (@HouseOwnerFlag IS NULL OR @HouseOwnerFlag = '' OR [DimCustomer].[HouseOwnerFlag] LIKE '%' + LTRIM(RTRIM(@HouseOwnerFlag)) + '%') " 
                + "AND   (@NumberCarsOwned IS NULL OR @NumberCarsOwned = '' OR [DimCustomer].[NumberCarsOwned] LIKE '%' + LTRIM(RTRIM(@NumberCarsOwned)) + '%') " 
                + "AND   (@AddressLine1 IS NULL OR @AddressLine1 = '' OR [DimCustomer].[AddressLine1] LIKE '%' + LTRIM(RTRIM(@AddressLine1)) + '%') " 
                + "AND   (@AddressLine2 IS NULL OR @AddressLine2 = '' OR [DimCustomer].[AddressLine2] LIKE '%' + LTRIM(RTRIM(@AddressLine2)) + '%') " 
                + "AND   (@Phone IS NULL OR @Phone = '' OR [DimCustomer].[Phone] LIKE '%' + LTRIM(RTRIM(@Phone)) + '%') " 
                + "AND   (@DateFirstPurchase IS NULL OR @DateFirstPurchase = '' OR [DimCustomer].[DateFirstPurchase] LIKE '%' + LTRIM(RTRIM(@DateFirstPurchase)) + '%') " 
                + "AND   (@CommuteDistance IS NULL OR @CommuteDistance = '' OR [DimCustomer].[CommuteDistance] LIKE '%' + LTRIM(RTRIM(@CommuteDistance)) + '%') " 
                + "";
        } else if (sCondition == "Equals") {
            selectStatement
                = "SELECT "
            + "     [dbo].[DimCustomer].[CustomerKey] "
            + "    ,[dbo].[DimGeography].[StateProvinceName] "
            + "    ,[dbo].[DimCustomer].[CustomerAlternateKey] "
            + "    ,[dbo].[DimCustomer].[Title] "
            + "    ,[dbo].[DimCustomer].[FirstName] "
            + "    ,[dbo].[DimCustomer].[MiddleName] "
            + "    ,[dbo].[DimCustomer].[LastName] "
            + "    ,[dbo].[DimCustomer].[NameStyle] "
            + "    ,[dbo].[DimCustomer].[BirthDate] "
            + "    ,[dbo].[DimCustomer].[MaritalStatus] "
            + "    ,[dbo].[DimCustomer].[Suffix] "
            + "    ,[dbo].[DimCustomer].[Gender] "
            + "    ,[dbo].[DimCustomer].[EmailAddress] "
            + "    ,[dbo].[DimCustomer].[YearlyIncome] "
            + "    ,[dbo].[DimCustomer].[TotalChildren] "
            + "    ,[dbo].[DimCustomer].[NumberChildrenAtHome] "
            + "    ,[dbo].[DimCustomer].[EnglishEducation] "
            + "    ,[dbo].[DimCustomer].[SpanishEducation] "
            + "    ,[dbo].[DimCustomer].[FrenchEducation] "
            + "    ,[dbo].[DimCustomer].[EnglishOccupation] "
            + "    ,[dbo].[DimCustomer].[SpanishOccupation] "
            + "    ,[dbo].[DimCustomer].[FrenchOccupation] "
            + "    ,[dbo].[DimCustomer].[HouseOwnerFlag] "
            + "    ,[dbo].[DimCustomer].[NumberCarsOwned] "
            + "    ,[dbo].[DimCustomer].[AddressLine1] "
            + "    ,[dbo].[DimCustomer].[AddressLine2] "
            + "    ,[dbo].[DimCustomer].[Phone] "
            + "    ,[dbo].[DimCustomer].[DateFirstPurchase] "
            + "    ,[dbo].[DimCustomer].[CommuteDistance] "
            + "FROM " 
            + "     [dbo].[DimCustomer] " 
            + "LEFT JOIN [dbo].[DimGeography] ON [dbo].[DimCustomer].[GeographyKey] = [dbo].[DimGeography].[GeographyKey] "
                + "WHERE " 
                + "     (@CustomerKey IS NULL OR @CustomerKey = '' OR [DimCustomer].[CustomerKey] = LTRIM(RTRIM(@CustomerKey))) " 
                + "AND   (@StateProvinceName IS NULL OR @StateProvinceName = '' OR [dbo].[DimGeography].[StateProvinceName] = LTRIM(RTRIM(@StateProvinceName))) " 
                + "AND   (@CustomerAlternateKey IS NULL OR @CustomerAlternateKey = '' OR [DimCustomer].[CustomerAlternateKey] = LTRIM(RTRIM(@CustomerAlternateKey))) " 
                + "AND   (@Title IS NULL OR @Title = '' OR [DimCustomer].[Title] = LTRIM(RTRIM(@Title))) " 
                + "AND   (@FirstName IS NULL OR @FirstName = '' OR [DimCustomer].[FirstName] = LTRIM(RTRIM(@FirstName))) " 
                + "AND   (@MiddleName IS NULL OR @MiddleName = '' OR [DimCustomer].[MiddleName] = LTRIM(RTRIM(@MiddleName))) " 
                + "AND   (@LastName IS NULL OR @LastName = '' OR [DimCustomer].[LastName] = LTRIM(RTRIM(@LastName))) " 
                + "AND   (@NameStyle IS NULL OR @NameStyle = '' OR [DimCustomer].[NameStyle] = LTRIM(RTRIM(@NameStyle))) " 
                + "AND   (@BirthDate IS NULL OR @BirthDate = '' OR [DimCustomer].[BirthDate] = LTRIM(RTRIM(@BirthDate))) " 
                + "AND   (@MaritalStatus IS NULL OR @MaritalStatus = '' OR [DimCustomer].[MaritalStatus] = LTRIM(RTRIM(@MaritalStatus))) " 
                + "AND   (@Suffix IS NULL OR @Suffix = '' OR [DimCustomer].[Suffix] = LTRIM(RTRIM(@Suffix))) " 
                + "AND   (@Gender IS NULL OR @Gender = '' OR [DimCustomer].[Gender] = LTRIM(RTRIM(@Gender))) " 
                + "AND   (@EmailAddress IS NULL OR @EmailAddress = '' OR [DimCustomer].[EmailAddress] = LTRIM(RTRIM(@EmailAddress))) " 
                + "AND   (@YearlyIncome IS NULL OR @YearlyIncome = '' OR [DimCustomer].[YearlyIncome] = LTRIM(RTRIM(@YearlyIncome))) " 
                + "AND   (@TotalChildren IS NULL OR @TotalChildren = '' OR [DimCustomer].[TotalChildren] = LTRIM(RTRIM(@TotalChildren))) " 
                + "AND   (@NumberChildrenAtHome IS NULL OR @NumberChildrenAtHome = '' OR [DimCustomer].[NumberChildrenAtHome] = LTRIM(RTRIM(@NumberChildrenAtHome))) " 
                + "AND   (@EnglishEducation IS NULL OR @EnglishEducation = '' OR [DimCustomer].[EnglishEducation] = LTRIM(RTRIM(@EnglishEducation))) " 
                + "AND   (@SpanishEducation IS NULL OR @SpanishEducation = '' OR [DimCustomer].[SpanishEducation] = LTRIM(RTRIM(@SpanishEducation))) " 
                + "AND   (@FrenchEducation IS NULL OR @FrenchEducation = '' OR [DimCustomer].[FrenchEducation] = LTRIM(RTRIM(@FrenchEducation))) " 
                + "AND   (@EnglishOccupation IS NULL OR @EnglishOccupation = '' OR [DimCustomer].[EnglishOccupation] = LTRIM(RTRIM(@EnglishOccupation))) " 
                + "AND   (@SpanishOccupation IS NULL OR @SpanishOccupation = '' OR [DimCustomer].[SpanishOccupation] = LTRIM(RTRIM(@SpanishOccupation))) " 
                + "AND   (@FrenchOccupation IS NULL OR @FrenchOccupation = '' OR [DimCustomer].[FrenchOccupation] = LTRIM(RTRIM(@FrenchOccupation))) " 
                + "AND   (@HouseOwnerFlag IS NULL OR @HouseOwnerFlag = '' OR [DimCustomer].[HouseOwnerFlag] = LTRIM(RTRIM(@HouseOwnerFlag))) " 
                + "AND   (@NumberCarsOwned IS NULL OR @NumberCarsOwned = '' OR [DimCustomer].[NumberCarsOwned] = LTRIM(RTRIM(@NumberCarsOwned))) " 
                + "AND   (@AddressLine1 IS NULL OR @AddressLine1 = '' OR [DimCustomer].[AddressLine1] = LTRIM(RTRIM(@AddressLine1))) " 
                + "AND   (@AddressLine2 IS NULL OR @AddressLine2 = '' OR [DimCustomer].[AddressLine2] = LTRIM(RTRIM(@AddressLine2))) " 
                + "AND   (@Phone IS NULL OR @Phone = '' OR [DimCustomer].[Phone] = LTRIM(RTRIM(@Phone))) " 
                + "AND   (@DateFirstPurchase IS NULL OR @DateFirstPurchase = '' OR [DimCustomer].[DateFirstPurchase] = LTRIM(RTRIM(@DateFirstPurchase))) " 
                + "AND   (@CommuteDistance IS NULL OR @CommuteDistance = '' OR [DimCustomer].[CommuteDistance] = LTRIM(RTRIM(@CommuteDistance))) " 
                + "";
        } else if  (sCondition == "Starts with...") {
            selectStatement
                = "SELECT "
            + "     [dbo].[DimCustomer].[CustomerKey] "
            + "    ,[dbo].[DimGeography].[StateProvinceName] "
            + "    ,[dbo].[DimCustomer].[CustomerAlternateKey] "
            + "    ,[dbo].[DimCustomer].[Title] "
            + "    ,[dbo].[DimCustomer].[FirstName] "
            + "    ,[dbo].[DimCustomer].[MiddleName] "
            + "    ,[dbo].[DimCustomer].[LastName] "
            + "    ,[dbo].[DimCustomer].[NameStyle] "
            + "    ,[dbo].[DimCustomer].[BirthDate] "
            + "    ,[dbo].[DimCustomer].[MaritalStatus] "
            + "    ,[dbo].[DimCustomer].[Suffix] "
            + "    ,[dbo].[DimCustomer].[Gender] "
            + "    ,[dbo].[DimCustomer].[EmailAddress] "
            + "    ,[dbo].[DimCustomer].[YearlyIncome] "
            + "    ,[dbo].[DimCustomer].[TotalChildren] "
            + "    ,[dbo].[DimCustomer].[NumberChildrenAtHome] "
            + "    ,[dbo].[DimCustomer].[EnglishEducation] "
            + "    ,[dbo].[DimCustomer].[SpanishEducation] "
            + "    ,[dbo].[DimCustomer].[FrenchEducation] "
            + "    ,[dbo].[DimCustomer].[EnglishOccupation] "
            + "    ,[dbo].[DimCustomer].[SpanishOccupation] "
            + "    ,[dbo].[DimCustomer].[FrenchOccupation] "
            + "    ,[dbo].[DimCustomer].[HouseOwnerFlag] "
            + "    ,[dbo].[DimCustomer].[NumberCarsOwned] "
            + "    ,[dbo].[DimCustomer].[AddressLine1] "
            + "    ,[dbo].[DimCustomer].[AddressLine2] "
            + "    ,[dbo].[DimCustomer].[Phone] "
            + "    ,[dbo].[DimCustomer].[DateFirstPurchase] "
            + "    ,[dbo].[DimCustomer].[CommuteDistance] "
            + "FROM " 
            + "     [dbo].[DimCustomer] " 
            + "LEFT JOIN [dbo].[DimGeography] ON [dbo].[DimCustomer].[GeographyKey] = [dbo].[DimGeography].[GeographyKey] "
                + "WHERE " 
                + "     (@CustomerKey IS NULL OR @CustomerKey = '' OR [DimCustomer].[CustomerKey] LIKE LTRIM(RTRIM(@CustomerKey)) + '%') " 
                + "AND   (@StateProvinceName IS NULL OR @StateProvinceName = '' OR [dbo].[DimGeography].[StateProvinceName] LIKE LTRIM(RTRIM(@StateProvinceName)) + '%') " 
                + "AND   (@CustomerAlternateKey IS NULL OR @CustomerAlternateKey = '' OR [DimCustomer].[CustomerAlternateKey] LIKE LTRIM(RTRIM(@CustomerAlternateKey)) + '%') " 
                + "AND   (@Title IS NULL OR @Title = '' OR [DimCustomer].[Title] LIKE LTRIM(RTRIM(@Title)) + '%') " 
                + "AND   (@FirstName IS NULL OR @FirstName = '' OR [DimCustomer].[FirstName] LIKE LTRIM(RTRIM(@FirstName)) + '%') " 
                + "AND   (@MiddleName IS NULL OR @MiddleName = '' OR [DimCustomer].[MiddleName] LIKE LTRIM(RTRIM(@MiddleName)) + '%') " 
                + "AND   (@LastName IS NULL OR @LastName = '' OR [DimCustomer].[LastName] LIKE LTRIM(RTRIM(@LastName)) + '%') " 
                + "AND   (@NameStyle IS NULL OR @NameStyle = '' OR [DimCustomer].[NameStyle] LIKE LTRIM(RTRIM(@NameStyle)) + '%') " 
                + "AND   (@BirthDate IS NULL OR @BirthDate = '' OR [DimCustomer].[BirthDate] LIKE LTRIM(RTRIM(@BirthDate)) + '%') " 
                + "AND   (@MaritalStatus IS NULL OR @MaritalStatus = '' OR [DimCustomer].[MaritalStatus] LIKE LTRIM(RTRIM(@MaritalStatus)) + '%') " 
                + "AND   (@Suffix IS NULL OR @Suffix = '' OR [DimCustomer].[Suffix] LIKE LTRIM(RTRIM(@Suffix)) + '%') " 
                + "AND   (@Gender IS NULL OR @Gender = '' OR [DimCustomer].[Gender] LIKE LTRIM(RTRIM(@Gender)) + '%') " 
                + "AND   (@EmailAddress IS NULL OR @EmailAddress = '' OR [DimCustomer].[EmailAddress] LIKE LTRIM(RTRIM(@EmailAddress)) + '%') " 
                + "AND   (@YearlyIncome IS NULL OR @YearlyIncome = '' OR [DimCustomer].[YearlyIncome] LIKE LTRIM(RTRIM(@YearlyIncome)) + '%') " 
                + "AND   (@TotalChildren IS NULL OR @TotalChildren = '' OR [DimCustomer].[TotalChildren] LIKE LTRIM(RTRIM(@TotalChildren)) + '%') " 
                + "AND   (@NumberChildrenAtHome IS NULL OR @NumberChildrenAtHome = '' OR [DimCustomer].[NumberChildrenAtHome] LIKE LTRIM(RTRIM(@NumberChildrenAtHome)) + '%') " 
                + "AND   (@EnglishEducation IS NULL OR @EnglishEducation = '' OR [DimCustomer].[EnglishEducation] LIKE LTRIM(RTRIM(@EnglishEducation)) + '%') " 
                + "AND   (@SpanishEducation IS NULL OR @SpanishEducation = '' OR [DimCustomer].[SpanishEducation] LIKE LTRIM(RTRIM(@SpanishEducation)) + '%') " 
                + "AND   (@FrenchEducation IS NULL OR @FrenchEducation = '' OR [DimCustomer].[FrenchEducation] LIKE LTRIM(RTRIM(@FrenchEducation)) + '%') " 
                + "AND   (@EnglishOccupation IS NULL OR @EnglishOccupation = '' OR [DimCustomer].[EnglishOccupation] LIKE LTRIM(RTRIM(@EnglishOccupation)) + '%') " 
                + "AND   (@SpanishOccupation IS NULL OR @SpanishOccupation = '' OR [DimCustomer].[SpanishOccupation] LIKE LTRIM(RTRIM(@SpanishOccupation)) + '%') " 
                + "AND   (@FrenchOccupation IS NULL OR @FrenchOccupation = '' OR [DimCustomer].[FrenchOccupation] LIKE LTRIM(RTRIM(@FrenchOccupation)) + '%') " 
                + "AND   (@HouseOwnerFlag IS NULL OR @HouseOwnerFlag = '' OR [DimCustomer].[HouseOwnerFlag] LIKE LTRIM(RTRIM(@HouseOwnerFlag)) + '%') " 
                + "AND   (@NumberCarsOwned IS NULL OR @NumberCarsOwned = '' OR [DimCustomer].[NumberCarsOwned] LIKE LTRIM(RTRIM(@NumberCarsOwned)) + '%') " 
                + "AND   (@AddressLine1 IS NULL OR @AddressLine1 = '' OR [DimCustomer].[AddressLine1] LIKE LTRIM(RTRIM(@AddressLine1)) + '%') " 
                + "AND   (@AddressLine2 IS NULL OR @AddressLine2 = '' OR [DimCustomer].[AddressLine2] LIKE LTRIM(RTRIM(@AddressLine2)) + '%') " 
                + "AND   (@Phone IS NULL OR @Phone = '' OR [DimCustomer].[Phone] LIKE LTRIM(RTRIM(@Phone)) + '%') " 
                + "AND   (@DateFirstPurchase IS NULL OR @DateFirstPurchase = '' OR [DimCustomer].[DateFirstPurchase] LIKE LTRIM(RTRIM(@DateFirstPurchase)) + '%') " 
                + "AND   (@CommuteDistance IS NULL OR @CommuteDistance = '' OR [DimCustomer].[CommuteDistance] LIKE LTRIM(RTRIM(@CommuteDistance)) + '%') " 
                + "";
        } else if  (sCondition == "More than...") {
            selectStatement
                = "SELECT "
            + "     [dbo].[DimCustomer].[CustomerKey] "
            + "    ,[dbo].[DimGeography].[StateProvinceName] "
            + "    ,[dbo].[DimCustomer].[CustomerAlternateKey] "
            + "    ,[dbo].[DimCustomer].[Title] "
            + "    ,[dbo].[DimCustomer].[FirstName] "
            + "    ,[dbo].[DimCustomer].[MiddleName] "
            + "    ,[dbo].[DimCustomer].[LastName] "
            + "    ,[dbo].[DimCustomer].[NameStyle] "
            + "    ,[dbo].[DimCustomer].[BirthDate] "
            + "    ,[dbo].[DimCustomer].[MaritalStatus] "
            + "    ,[dbo].[DimCustomer].[Suffix] "
            + "    ,[dbo].[DimCustomer].[Gender] "
            + "    ,[dbo].[DimCustomer].[EmailAddress] "
            + "    ,[dbo].[DimCustomer].[YearlyIncome] "
            + "    ,[dbo].[DimCustomer].[TotalChildren] "
            + "    ,[dbo].[DimCustomer].[NumberChildrenAtHome] "
            + "    ,[dbo].[DimCustomer].[EnglishEducation] "
            + "    ,[dbo].[DimCustomer].[SpanishEducation] "
            + "    ,[dbo].[DimCustomer].[FrenchEducation] "
            + "    ,[dbo].[DimCustomer].[EnglishOccupation] "
            + "    ,[dbo].[DimCustomer].[SpanishOccupation] "
            + "    ,[dbo].[DimCustomer].[FrenchOccupation] "
            + "    ,[dbo].[DimCustomer].[HouseOwnerFlag] "
            + "    ,[dbo].[DimCustomer].[NumberCarsOwned] "
            + "    ,[dbo].[DimCustomer].[AddressLine1] "
            + "    ,[dbo].[DimCustomer].[AddressLine2] "
            + "    ,[dbo].[DimCustomer].[Phone] "
            + "    ,[dbo].[DimCustomer].[DateFirstPurchase] "
            + "    ,[dbo].[DimCustomer].[CommuteDistance] "
            + "FROM " 
            + "     [dbo].[DimCustomer] " 
            + "LEFT JOIN [dbo].[DimGeography] ON [dbo].[DimCustomer].[GeographyKey] = [dbo].[DimGeography].[GeographyKey] "
                + "WHERE " 
                + "     (@CustomerKey IS NULL OR @CustomerKey = '' OR [DimCustomer].[CustomerKey] > LTRIM(RTRIM(@CustomerKey))) " 
                + "AND   (@StateProvinceName IS NULL OR @StateProvinceName = '' OR [dbo].[DimGeography].[StateProvinceName] > LTRIM(RTRIM(@StateProvinceName))) " 
                + "AND   (@CustomerAlternateKey IS NULL OR @CustomerAlternateKey = '' OR [DimCustomer].[CustomerAlternateKey] > LTRIM(RTRIM(@CustomerAlternateKey))) " 
                + "AND   (@Title IS NULL OR @Title = '' OR [DimCustomer].[Title] > LTRIM(RTRIM(@Title))) " 
                + "AND   (@FirstName IS NULL OR @FirstName = '' OR [DimCustomer].[FirstName] > LTRIM(RTRIM(@FirstName))) " 
                + "AND   (@MiddleName IS NULL OR @MiddleName = '' OR [DimCustomer].[MiddleName] > LTRIM(RTRIM(@MiddleName))) " 
                + "AND   (@LastName IS NULL OR @LastName = '' OR [DimCustomer].[LastName] > LTRIM(RTRIM(@LastName))) " 
                + "AND   (@NameStyle IS NULL OR @NameStyle = '' OR [DimCustomer].[NameStyle] > LTRIM(RTRIM(@NameStyle))) " 
                + "AND   (@BirthDate IS NULL OR @BirthDate = '' OR [DimCustomer].[BirthDate] > LTRIM(RTRIM(@BirthDate))) " 
                + "AND   (@MaritalStatus IS NULL OR @MaritalStatus = '' OR [DimCustomer].[MaritalStatus] > LTRIM(RTRIM(@MaritalStatus))) " 
                + "AND   (@Suffix IS NULL OR @Suffix = '' OR [DimCustomer].[Suffix] > LTRIM(RTRIM(@Suffix))) " 
                + "AND   (@Gender IS NULL OR @Gender = '' OR [DimCustomer].[Gender] > LTRIM(RTRIM(@Gender))) " 
                + "AND   (@EmailAddress IS NULL OR @EmailAddress = '' OR [DimCustomer].[EmailAddress] > LTRIM(RTRIM(@EmailAddress))) " 
                + "AND   (@YearlyIncome IS NULL OR @YearlyIncome = '' OR [DimCustomer].[YearlyIncome] > LTRIM(RTRIM(@YearlyIncome))) " 
                + "AND   (@TotalChildren IS NULL OR @TotalChildren = '' OR [DimCustomer].[TotalChildren] > LTRIM(RTRIM(@TotalChildren))) " 
                + "AND   (@NumberChildrenAtHome IS NULL OR @NumberChildrenAtHome = '' OR [DimCustomer].[NumberChildrenAtHome] > LTRIM(RTRIM(@NumberChildrenAtHome))) " 
                + "AND   (@EnglishEducation IS NULL OR @EnglishEducation = '' OR [DimCustomer].[EnglishEducation] > LTRIM(RTRIM(@EnglishEducation))) " 
                + "AND   (@SpanishEducation IS NULL OR @SpanishEducation = '' OR [DimCustomer].[SpanishEducation] > LTRIM(RTRIM(@SpanishEducation))) " 
                + "AND   (@FrenchEducation IS NULL OR @FrenchEducation = '' OR [DimCustomer].[FrenchEducation] > LTRIM(RTRIM(@FrenchEducation))) " 
                + "AND   (@EnglishOccupation IS NULL OR @EnglishOccupation = '' OR [DimCustomer].[EnglishOccupation] > LTRIM(RTRIM(@EnglishOccupation))) " 
                + "AND   (@SpanishOccupation IS NULL OR @SpanishOccupation = '' OR [DimCustomer].[SpanishOccupation] > LTRIM(RTRIM(@SpanishOccupation))) " 
                + "AND   (@FrenchOccupation IS NULL OR @FrenchOccupation = '' OR [DimCustomer].[FrenchOccupation] > LTRIM(RTRIM(@FrenchOccupation))) " 
                + "AND   (@HouseOwnerFlag IS NULL OR @HouseOwnerFlag = '' OR [DimCustomer].[HouseOwnerFlag] > LTRIM(RTRIM(@HouseOwnerFlag))) " 
                + "AND   (@NumberCarsOwned IS NULL OR @NumberCarsOwned = '' OR [DimCustomer].[NumberCarsOwned] > LTRIM(RTRIM(@NumberCarsOwned))) " 
                + "AND   (@AddressLine1 IS NULL OR @AddressLine1 = '' OR [DimCustomer].[AddressLine1] > LTRIM(RTRIM(@AddressLine1))) " 
                + "AND   (@AddressLine2 IS NULL OR @AddressLine2 = '' OR [DimCustomer].[AddressLine2] > LTRIM(RTRIM(@AddressLine2))) " 
                + "AND   (@Phone IS NULL OR @Phone = '' OR [DimCustomer].[Phone] > LTRIM(RTRIM(@Phone))) " 
                + "AND   (@DateFirstPurchase IS NULL OR @DateFirstPurchase = '' OR [DimCustomer].[DateFirstPurchase] > LTRIM(RTRIM(@DateFirstPurchase))) " 
                + "AND   (@CommuteDistance IS NULL OR @CommuteDistance = '' OR [DimCustomer].[CommuteDistance] > LTRIM(RTRIM(@CommuteDistance))) " 
                + "";
        } else if  (sCondition == "Less than...") {
            selectStatement
                = "SELECT " 
            + "     [dbo].[DimCustomer].[CustomerKey] "
            + "    ,[dbo].[DimGeography].[StateProvinceName] "
            + "    ,[dbo].[DimCustomer].[CustomerAlternateKey] "
            + "    ,[dbo].[DimCustomer].[Title] "
            + "    ,[dbo].[DimCustomer].[FirstName] "
            + "    ,[dbo].[DimCustomer].[MiddleName] "
            + "    ,[dbo].[DimCustomer].[LastName] "
            + "    ,[dbo].[DimCustomer].[NameStyle] "
            + "    ,[dbo].[DimCustomer].[BirthDate] "
            + "    ,[dbo].[DimCustomer].[MaritalStatus] "
            + "    ,[dbo].[DimCustomer].[Suffix] "
            + "    ,[dbo].[DimCustomer].[Gender] "
            + "    ,[dbo].[DimCustomer].[EmailAddress] "
            + "    ,[dbo].[DimCustomer].[YearlyIncome] "
            + "    ,[dbo].[DimCustomer].[TotalChildren] "
            + "    ,[dbo].[DimCustomer].[NumberChildrenAtHome] "
            + "    ,[dbo].[DimCustomer].[EnglishEducation] "
            + "    ,[dbo].[DimCustomer].[SpanishEducation] "
            + "    ,[dbo].[DimCustomer].[FrenchEducation] "
            + "    ,[dbo].[DimCustomer].[EnglishOccupation] "
            + "    ,[dbo].[DimCustomer].[SpanishOccupation] "
            + "    ,[dbo].[DimCustomer].[FrenchOccupation] "
            + "    ,[dbo].[DimCustomer].[HouseOwnerFlag] "
            + "    ,[dbo].[DimCustomer].[NumberCarsOwned] "
            + "    ,[dbo].[DimCustomer].[AddressLine1] "
            + "    ,[dbo].[DimCustomer].[AddressLine2] "
            + "    ,[dbo].[DimCustomer].[Phone] "
            + "    ,[dbo].[DimCustomer].[DateFirstPurchase] "
            + "    ,[dbo].[DimCustomer].[CommuteDistance] "
            + "FROM " 
            + "     [dbo].[DimCustomer] " 
            + "LEFT JOIN [dbo].[DimGeography] ON [dbo].[DimCustomer].[GeographyKey] = [dbo].[DimGeography].[GeographyKey] "
                + "WHERE " 
                + "     (@CustomerKey IS NULL OR @CustomerKey = '' OR [DimCustomer].[CustomerKey] < LTRIM(RTRIM(@CustomerKey))) " 
                + "AND   (@StateProvinceName IS NULL OR @StateProvinceName = '' OR [dbo].[DimGeography].[StateProvinceName] < LTRIM(RTRIM(@StateProvinceName))) " 
                + "AND   (@CustomerAlternateKey IS NULL OR @CustomerAlternateKey = '' OR [DimCustomer].[CustomerAlternateKey] < LTRIM(RTRIM(@CustomerAlternateKey))) " 
                + "AND   (@Title IS NULL OR @Title = '' OR [DimCustomer].[Title] < LTRIM(RTRIM(@Title))) " 
                + "AND   (@FirstName IS NULL OR @FirstName = '' OR [DimCustomer].[FirstName] < LTRIM(RTRIM(@FirstName))) " 
                + "AND   (@MiddleName IS NULL OR @MiddleName = '' OR [DimCustomer].[MiddleName] < LTRIM(RTRIM(@MiddleName))) " 
                + "AND   (@LastName IS NULL OR @LastName = '' OR [DimCustomer].[LastName] < LTRIM(RTRIM(@LastName))) " 
                + "AND   (@NameStyle IS NULL OR @NameStyle = '' OR [DimCustomer].[NameStyle] < LTRIM(RTRIM(@NameStyle))) " 
                + "AND   (@BirthDate IS NULL OR @BirthDate = '' OR [DimCustomer].[BirthDate] < LTRIM(RTRIM(@BirthDate))) " 
                + "AND   (@MaritalStatus IS NULL OR @MaritalStatus = '' OR [DimCustomer].[MaritalStatus] < LTRIM(RTRIM(@MaritalStatus))) " 
                + "AND   (@Suffix IS NULL OR @Suffix = '' OR [DimCustomer].[Suffix] < LTRIM(RTRIM(@Suffix))) " 
                + "AND   (@Gender IS NULL OR @Gender = '' OR [DimCustomer].[Gender] < LTRIM(RTRIM(@Gender))) " 
                + "AND   (@EmailAddress IS NULL OR @EmailAddress = '' OR [DimCustomer].[EmailAddress] < LTRIM(RTRIM(@EmailAddress))) " 
                + "AND   (@YearlyIncome IS NULL OR @YearlyIncome = '' OR [DimCustomer].[YearlyIncome] < LTRIM(RTRIM(@YearlyIncome))) " 
                + "AND   (@TotalChildren IS NULL OR @TotalChildren = '' OR [DimCustomer].[TotalChildren] < LTRIM(RTRIM(@TotalChildren))) " 
                + "AND   (@NumberChildrenAtHome IS NULL OR @NumberChildrenAtHome = '' OR [DimCustomer].[NumberChildrenAtHome] < LTRIM(RTRIM(@NumberChildrenAtHome))) " 
                + "AND   (@EnglishEducation IS NULL OR @EnglishEducation = '' OR [DimCustomer].[EnglishEducation] < LTRIM(RTRIM(@EnglishEducation))) " 
                + "AND   (@SpanishEducation IS NULL OR @SpanishEducation = '' OR [DimCustomer].[SpanishEducation] < LTRIM(RTRIM(@SpanishEducation))) " 
                + "AND   (@FrenchEducation IS NULL OR @FrenchEducation = '' OR [DimCustomer].[FrenchEducation] < LTRIM(RTRIM(@FrenchEducation))) " 
                + "AND   (@EnglishOccupation IS NULL OR @EnglishOccupation = '' OR [DimCustomer].[EnglishOccupation] < LTRIM(RTRIM(@EnglishOccupation))) " 
                + "AND   (@SpanishOccupation IS NULL OR @SpanishOccupation = '' OR [DimCustomer].[SpanishOccupation] < LTRIM(RTRIM(@SpanishOccupation))) " 
                + "AND   (@FrenchOccupation IS NULL OR @FrenchOccupation = '' OR [DimCustomer].[FrenchOccupation] < LTRIM(RTRIM(@FrenchOccupation))) " 
                + "AND   (@HouseOwnerFlag IS NULL OR @HouseOwnerFlag = '' OR [DimCustomer].[HouseOwnerFlag] < LTRIM(RTRIM(@HouseOwnerFlag))) " 
                + "AND   (@NumberCarsOwned IS NULL OR @NumberCarsOwned = '' OR [DimCustomer].[NumberCarsOwned] < LTRIM(RTRIM(@NumberCarsOwned))) " 
                + "AND   (@AddressLine1 IS NULL OR @AddressLine1 = '' OR [DimCustomer].[AddressLine1] < LTRIM(RTRIM(@AddressLine1))) " 
                + "AND   (@AddressLine2 IS NULL OR @AddressLine2 = '' OR [DimCustomer].[AddressLine2] < LTRIM(RTRIM(@AddressLine2))) " 
                + "AND   (@Phone IS NULL OR @Phone = '' OR [DimCustomer].[Phone] < LTRIM(RTRIM(@Phone))) " 
                + "AND   (@DateFirstPurchase IS NULL OR @DateFirstPurchase = '' OR [DimCustomer].[DateFirstPurchase] < LTRIM(RTRIM(@DateFirstPurchase))) " 
                + "AND   (@CommuteDistance IS NULL OR @CommuteDistance = '' OR [DimCustomer].[CommuteDistance] < LTRIM(RTRIM(@CommuteDistance))) " 
                + "";
        } else if  (sCondition == "Equal or more than...") {
            selectStatement
                = "SELECT "
            + "     [dbo].[DimCustomer].[CustomerKey] "
            + "    ,[dbo].[DimGeography].[StateProvinceName] "
            + "    ,[dbo].[DimCustomer].[CustomerAlternateKey] "
            + "    ,[dbo].[DimCustomer].[Title] "
            + "    ,[dbo].[DimCustomer].[FirstName] "
            + "    ,[dbo].[DimCustomer].[MiddleName] "
            + "    ,[dbo].[DimCustomer].[LastName] "
            + "    ,[dbo].[DimCustomer].[NameStyle] "
            + "    ,[dbo].[DimCustomer].[BirthDate] "
            + "    ,[dbo].[DimCustomer].[MaritalStatus] "
            + "    ,[dbo].[DimCustomer].[Suffix] "
            + "    ,[dbo].[DimCustomer].[Gender] "
            + "    ,[dbo].[DimCustomer].[EmailAddress] "
            + "    ,[dbo].[DimCustomer].[YearlyIncome] "
            + "    ,[dbo].[DimCustomer].[TotalChildren] "
            + "    ,[dbo].[DimCustomer].[NumberChildrenAtHome] "
            + "    ,[dbo].[DimCustomer].[EnglishEducation] "
            + "    ,[dbo].[DimCustomer].[SpanishEducation] "
            + "    ,[dbo].[DimCustomer].[FrenchEducation] "
            + "    ,[dbo].[DimCustomer].[EnglishOccupation] "
            + "    ,[dbo].[DimCustomer].[SpanishOccupation] "
            + "    ,[dbo].[DimCustomer].[FrenchOccupation] "
            + "    ,[dbo].[DimCustomer].[HouseOwnerFlag] "
            + "    ,[dbo].[DimCustomer].[NumberCarsOwned] "
            + "    ,[dbo].[DimCustomer].[AddressLine1] "
            + "    ,[dbo].[DimCustomer].[AddressLine2] "
            + "    ,[dbo].[DimCustomer].[Phone] "
            + "    ,[dbo].[DimCustomer].[DateFirstPurchase] "
            + "    ,[dbo].[DimCustomer].[CommuteDistance] "
            + "FROM " 
            + "     [dbo].[DimCustomer] " 
            + "LEFT JOIN [dbo].[DimGeography] ON [dbo].[DimCustomer].[GeographyKey] = [dbo].[DimGeography].[GeographyKey] "
                + "WHERE " 
                + "     (@CustomerKey IS NULL OR @CustomerKey = '' OR [DimCustomer].[CustomerKey] >= LTRIM(RTRIM(@CustomerKey))) " 
                + "AND   (@StateProvinceName IS NULL OR @StateProvinceName = '' OR [dbo].[DimGeography].[StateProvinceName] >= LTRIM(RTRIM(@StateProvinceName))) " 
                + "AND   (@CustomerAlternateKey IS NULL OR @CustomerAlternateKey = '' OR [DimCustomer].[CustomerAlternateKey] >= LTRIM(RTRIM(@CustomerAlternateKey))) " 
                + "AND   (@Title IS NULL OR @Title = '' OR [DimCustomer].[Title] >= LTRIM(RTRIM(@Title))) " 
                + "AND   (@FirstName IS NULL OR @FirstName = '' OR [DimCustomer].[FirstName] >= LTRIM(RTRIM(@FirstName))) " 
                + "AND   (@MiddleName IS NULL OR @MiddleName = '' OR [DimCustomer].[MiddleName] >= LTRIM(RTRIM(@MiddleName))) " 
                + "AND   (@LastName IS NULL OR @LastName = '' OR [DimCustomer].[LastName] >= LTRIM(RTRIM(@LastName))) " 
                + "AND   (@NameStyle IS NULL OR @NameStyle = '' OR [DimCustomer].[NameStyle] >= LTRIM(RTRIM(@NameStyle))) " 
                + "AND   (@BirthDate IS NULL OR @BirthDate = '' OR [DimCustomer].[BirthDate] >= LTRIM(RTRIM(@BirthDate))) " 
                + "AND   (@MaritalStatus IS NULL OR @MaritalStatus = '' OR [DimCustomer].[MaritalStatus] >= LTRIM(RTRIM(@MaritalStatus))) " 
                + "AND   (@Suffix IS NULL OR @Suffix = '' OR [DimCustomer].[Suffix] >= LTRIM(RTRIM(@Suffix))) " 
                + "AND   (@Gender IS NULL OR @Gender = '' OR [DimCustomer].[Gender] >= LTRIM(RTRIM(@Gender))) " 
                + "AND   (@EmailAddress IS NULL OR @EmailAddress = '' OR [DimCustomer].[EmailAddress] >= LTRIM(RTRIM(@EmailAddress))) " 
                + "AND   (@YearlyIncome IS NULL OR @YearlyIncome = '' OR [DimCustomer].[YearlyIncome] >= LTRIM(RTRIM(@YearlyIncome))) " 
                + "AND   (@TotalChildren IS NULL OR @TotalChildren = '' OR [DimCustomer].[TotalChildren] >= LTRIM(RTRIM(@TotalChildren))) " 
                + "AND   (@NumberChildrenAtHome IS NULL OR @NumberChildrenAtHome = '' OR [DimCustomer].[NumberChildrenAtHome] >= LTRIM(RTRIM(@NumberChildrenAtHome))) " 
                + "AND   (@EnglishEducation IS NULL OR @EnglishEducation = '' OR [DimCustomer].[EnglishEducation] >= LTRIM(RTRIM(@EnglishEducation))) " 
                + "AND   (@SpanishEducation IS NULL OR @SpanishEducation = '' OR [DimCustomer].[SpanishEducation] >= LTRIM(RTRIM(@SpanishEducation))) " 
                + "AND   (@FrenchEducation IS NULL OR @FrenchEducation = '' OR [DimCustomer].[FrenchEducation] >= LTRIM(RTRIM(@FrenchEducation))) " 
                + "AND   (@EnglishOccupation IS NULL OR @EnglishOccupation = '' OR [DimCustomer].[EnglishOccupation] >= LTRIM(RTRIM(@EnglishOccupation))) " 
                + "AND   (@SpanishOccupation IS NULL OR @SpanishOccupation = '' OR [DimCustomer].[SpanishOccupation] >= LTRIM(RTRIM(@SpanishOccupation))) " 
                + "AND   (@FrenchOccupation IS NULL OR @FrenchOccupation = '' OR [DimCustomer].[FrenchOccupation] >= LTRIM(RTRIM(@FrenchOccupation))) " 
                + "AND   (@HouseOwnerFlag IS NULL OR @HouseOwnerFlag = '' OR [DimCustomer].[HouseOwnerFlag] >= LTRIM(RTRIM(@HouseOwnerFlag))) " 
                + "AND   (@NumberCarsOwned IS NULL OR @NumberCarsOwned = '' OR [DimCustomer].[NumberCarsOwned] >= LTRIM(RTRIM(@NumberCarsOwned))) " 
                + "AND   (@AddressLine1 IS NULL OR @AddressLine1 = '' OR [DimCustomer].[AddressLine1] >= LTRIM(RTRIM(@AddressLine1))) " 
                + "AND   (@AddressLine2 IS NULL OR @AddressLine2 = '' OR [DimCustomer].[AddressLine2] >= LTRIM(RTRIM(@AddressLine2))) " 
                + "AND   (@Phone IS NULL OR @Phone = '' OR [DimCustomer].[Phone] >= LTRIM(RTRIM(@Phone))) " 
                + "AND   (@DateFirstPurchase IS NULL OR @DateFirstPurchase = '' OR [DimCustomer].[DateFirstPurchase] >= LTRIM(RTRIM(@DateFirstPurchase))) " 
                + "AND   (@CommuteDistance IS NULL OR @CommuteDistance = '' OR [DimCustomer].[CommuteDistance] >= LTRIM(RTRIM(@CommuteDistance))) " 
                + "";
        } else if (sCondition == "Equal or less than...") {
            selectStatement 
                = "SELECT "
            + "     [dbo].[DimCustomer].[CustomerKey] "
            + "    ,[dbo].[DimGeography].[StateProvinceName] "
            + "    ,[dbo].[DimCustomer].[CustomerAlternateKey] "
            + "    ,[dbo].[DimCustomer].[Title] "
            + "    ,[dbo].[DimCustomer].[FirstName] "
            + "    ,[dbo].[DimCustomer].[MiddleName] "
            + "    ,[dbo].[DimCustomer].[LastName] "
            + "    ,[dbo].[DimCustomer].[NameStyle] "
            + "    ,[dbo].[DimCustomer].[BirthDate] "
            + "    ,[dbo].[DimCustomer].[MaritalStatus] "
            + "    ,[dbo].[DimCustomer].[Suffix] "
            + "    ,[dbo].[DimCustomer].[Gender] "
            + "    ,[dbo].[DimCustomer].[EmailAddress] "
            + "    ,[dbo].[DimCustomer].[YearlyIncome] "
            + "    ,[dbo].[DimCustomer].[TotalChildren] "
            + "    ,[dbo].[DimCustomer].[NumberChildrenAtHome] "
            + "    ,[dbo].[DimCustomer].[EnglishEducation] "
            + "    ,[dbo].[DimCustomer].[SpanishEducation] "
            + "    ,[dbo].[DimCustomer].[FrenchEducation] "
            + "    ,[dbo].[DimCustomer].[EnglishOccupation] "
            + "    ,[dbo].[DimCustomer].[SpanishOccupation] "
            + "    ,[dbo].[DimCustomer].[FrenchOccupation] "
            + "    ,[dbo].[DimCustomer].[HouseOwnerFlag] "
            + "    ,[dbo].[DimCustomer].[NumberCarsOwned] "
            + "    ,[dbo].[DimCustomer].[AddressLine1] "
            + "    ,[dbo].[DimCustomer].[AddressLine2] "
            + "    ,[dbo].[DimCustomer].[Phone] "
            + "    ,[dbo].[DimCustomer].[DateFirstPurchase] "
            + "    ,[dbo].[DimCustomer].[CommuteDistance] "
            + "FROM " 
            + "     [dbo].[DimCustomer] " 
            + "LEFT JOIN [dbo].[DimGeography] ON [dbo].[DimCustomer].[GeographyKey] = [dbo].[DimGeography].[GeographyKey] "
                + "WHERE " 
                + "     (@CustomerKey IS NULL OR @CustomerKey = '' OR [DimCustomer].[CustomerKey] <= LTRIM(RTRIM(@CustomerKey))) " 
                + "AND   (@StateProvinceName IS NULL OR @StateProvinceName = '' OR [dbo].[DimGeography].[StateProvinceName] <= LTRIM(RTRIM(@StateProvinceName))) " 
                + "AND   (@CustomerAlternateKey IS NULL OR @CustomerAlternateKey = '' OR [DimCustomer].[CustomerAlternateKey] <= LTRIM(RTRIM(@CustomerAlternateKey))) " 
                + "AND   (@Title IS NULL OR @Title = '' OR [DimCustomer].[Title] <= LTRIM(RTRIM(@Title))) " 
                + "AND   (@FirstName IS NULL OR @FirstName = '' OR [DimCustomer].[FirstName] <= LTRIM(RTRIM(@FirstName))) " 
                + "AND   (@MiddleName IS NULL OR @MiddleName = '' OR [DimCustomer].[MiddleName] <= LTRIM(RTRIM(@MiddleName))) " 
                + "AND   (@LastName IS NULL OR @LastName = '' OR [DimCustomer].[LastName] <= LTRIM(RTRIM(@LastName))) " 
                + "AND   (@NameStyle IS NULL OR @NameStyle = '' OR [DimCustomer].[NameStyle] <= LTRIM(RTRIM(@NameStyle))) " 
                + "AND   (@BirthDate IS NULL OR @BirthDate = '' OR [DimCustomer].[BirthDate] <= LTRIM(RTRIM(@BirthDate))) " 
                + "AND   (@MaritalStatus IS NULL OR @MaritalStatus = '' OR [DimCustomer].[MaritalStatus] <= LTRIM(RTRIM(@MaritalStatus))) " 
                + "AND   (@Suffix IS NULL OR @Suffix = '' OR [DimCustomer].[Suffix] <= LTRIM(RTRIM(@Suffix))) " 
                + "AND   (@Gender IS NULL OR @Gender = '' OR [DimCustomer].[Gender] <= LTRIM(RTRIM(@Gender))) " 
                + "AND   (@EmailAddress IS NULL OR @EmailAddress = '' OR [DimCustomer].[EmailAddress] <= LTRIM(RTRIM(@EmailAddress))) " 
                + "AND   (@YearlyIncome IS NULL OR @YearlyIncome = '' OR [DimCustomer].[YearlyIncome] <= LTRIM(RTRIM(@YearlyIncome))) " 
                + "AND   (@TotalChildren IS NULL OR @TotalChildren = '' OR [DimCustomer].[TotalChildren] <= LTRIM(RTRIM(@TotalChildren))) " 
                + "AND   (@NumberChildrenAtHome IS NULL OR @NumberChildrenAtHome = '' OR [DimCustomer].[NumberChildrenAtHome] <= LTRIM(RTRIM(@NumberChildrenAtHome))) " 
                + "AND   (@EnglishEducation IS NULL OR @EnglishEducation = '' OR [DimCustomer].[EnglishEducation] <= LTRIM(RTRIM(@EnglishEducation))) " 
                + "AND   (@SpanishEducation IS NULL OR @SpanishEducation = '' OR [DimCustomer].[SpanishEducation] <= LTRIM(RTRIM(@SpanishEducation))) " 
                + "AND   (@FrenchEducation IS NULL OR @FrenchEducation = '' OR [DimCustomer].[FrenchEducation] <= LTRIM(RTRIM(@FrenchEducation))) " 
                + "AND   (@EnglishOccupation IS NULL OR @EnglishOccupation = '' OR [DimCustomer].[EnglishOccupation] <= LTRIM(RTRIM(@EnglishOccupation))) " 
                + "AND   (@SpanishOccupation IS NULL OR @SpanishOccupation = '' OR [DimCustomer].[SpanishOccupation] <= LTRIM(RTRIM(@SpanishOccupation))) " 
                + "AND   (@FrenchOccupation IS NULL OR @FrenchOccupation = '' OR [DimCustomer].[FrenchOccupation] <= LTRIM(RTRIM(@FrenchOccupation))) " 
                + "AND   (@HouseOwnerFlag IS NULL OR @HouseOwnerFlag = '' OR [DimCustomer].[HouseOwnerFlag] <= LTRIM(RTRIM(@HouseOwnerFlag))) " 
                + "AND   (@NumberCarsOwned IS NULL OR @NumberCarsOwned = '' OR [DimCustomer].[NumberCarsOwned] <= LTRIM(RTRIM(@NumberCarsOwned))) " 
                + "AND   (@AddressLine1 IS NULL OR @AddressLine1 = '' OR [DimCustomer].[AddressLine1] <= LTRIM(RTRIM(@AddressLine1))) " 
                + "AND   (@AddressLine2 IS NULL OR @AddressLine2 = '' OR [DimCustomer].[AddressLine2] <= LTRIM(RTRIM(@AddressLine2))) " 
                + "AND   (@Phone IS NULL OR @Phone = '' OR [DimCustomer].[Phone] <= LTRIM(RTRIM(@Phone))) " 
                + "AND   (@DateFirstPurchase IS NULL OR @DateFirstPurchase = '' OR [DimCustomer].[DateFirstPurchase] <= LTRIM(RTRIM(@DateFirstPurchase))) " 
                + "AND   (@CommuteDistance IS NULL OR @CommuteDistance = '' OR [DimCustomer].[CommuteDistance] <= LTRIM(RTRIM(@CommuteDistance))) " 
                + "";
        }
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        selectCommand.CommandType = CommandType.Text;
        if (sField == "Customer Key") {
            selectCommand.Parameters.AddWithValue("@CustomerKey", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@CustomerKey", DBNull.Value); }
        if (sField == "Geography Key") {
            selectCommand.Parameters.AddWithValue("@StateProvinceName", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@StateProvinceName", DBNull.Value); }
        if (sField == "Customer Alternate Key") {
            selectCommand.Parameters.AddWithValue("@CustomerAlternateKey", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@CustomerAlternateKey", DBNull.Value); }
        if (sField == "Title") {
            selectCommand.Parameters.AddWithValue("@Title", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@Title", DBNull.Value); }
        if (sField == "First Name") {
            selectCommand.Parameters.AddWithValue("@FirstName", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@FirstName", DBNull.Value); }
        if (sField == "Middle Name") {
            selectCommand.Parameters.AddWithValue("@MiddleName", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@MiddleName", DBNull.Value); }
        if (sField == "Last Name") {
            selectCommand.Parameters.AddWithValue("@LastName", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@LastName", DBNull.Value); }
        if (sField == "Name Style") {
            selectCommand.Parameters.AddWithValue("@NameStyle", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@NameStyle", DBNull.Value); }
        if (sField == "Birth Date") {
            selectCommand.Parameters.AddWithValue("@BirthDate", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@BirthDate", DBNull.Value); }
        if (sField == "Marital Status") {
            selectCommand.Parameters.AddWithValue("@MaritalStatus", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@MaritalStatus", DBNull.Value); }
        if (sField == "Suffix") {
            selectCommand.Parameters.AddWithValue("@Suffix", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@Suffix", DBNull.Value); }
        if (sField == "Gender") {
            selectCommand.Parameters.AddWithValue("@Gender", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@Gender", DBNull.Value); }
        if (sField == "Email Address") {
            selectCommand.Parameters.AddWithValue("@EmailAddress", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@EmailAddress", DBNull.Value); }
        if (sField == "Yearly Income") {
            selectCommand.Parameters.AddWithValue("@YearlyIncome", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@YearlyIncome", DBNull.Value); }
        if (sField == "Total Children") {
            selectCommand.Parameters.AddWithValue("@TotalChildren", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@TotalChildren", DBNull.Value); }
        if (sField == "Number Children At Home") {
            selectCommand.Parameters.AddWithValue("@NumberChildrenAtHome", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@NumberChildrenAtHome", DBNull.Value); }
        if (sField == "English Education") {
            selectCommand.Parameters.AddWithValue("@EnglishEducation", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@EnglishEducation", DBNull.Value); }
        if (sField == "Spanish Education") {
            selectCommand.Parameters.AddWithValue("@SpanishEducation", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@SpanishEducation", DBNull.Value); }
        if (sField == "French Education") {
            selectCommand.Parameters.AddWithValue("@FrenchEducation", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@FrenchEducation", DBNull.Value); }
        if (sField == "English Occupation") {
            selectCommand.Parameters.AddWithValue("@EnglishOccupation", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@EnglishOccupation", DBNull.Value); }
        if (sField == "Spanish Occupation") {
            selectCommand.Parameters.AddWithValue("@SpanishOccupation", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@SpanishOccupation", DBNull.Value); }
        if (sField == "French Occupation") {
            selectCommand.Parameters.AddWithValue("@FrenchOccupation", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@FrenchOccupation", DBNull.Value); }
        if (sField == "House Owner Flag") {
            selectCommand.Parameters.AddWithValue("@HouseOwnerFlag", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@HouseOwnerFlag", DBNull.Value); }
        if (sField == "Number Cars Owned") {
            selectCommand.Parameters.AddWithValue("@NumberCarsOwned", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@NumberCarsOwned", DBNull.Value); }
        if (sField == "Address Line1") {
            selectCommand.Parameters.AddWithValue("@AddressLine1", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@AddressLine1", DBNull.Value); }
        if (sField == "Address Line2") {
            selectCommand.Parameters.AddWithValue("@AddressLine2", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@AddressLine2", DBNull.Value); }
        if (sField == "Phone") {
            selectCommand.Parameters.AddWithValue("@Phone", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@Phone", DBNull.Value); }
        if (sField == "Date First Purchase") {
            selectCommand.Parameters.AddWithValue("@DateFirstPurchase", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@DateFirstPurchase", DBNull.Value); }
        if (sField == "Commute Distance") {
            selectCommand.Parameters.AddWithValue("@CommuteDistance", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@CommuteDistance", DBNull.Value); }
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

    public static dbo_DimCustomerClass Select_Record(dbo_DimCustomerClass clsdbo_DimCustomerPara)
    {
        dbo_DimCustomerClass clsdbo_DimCustomer = new dbo_DimCustomerClass();
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement
            = "SELECT " 
            + "     [CustomerKey] "
            + "    ,[GeographyKey] "
            + "    ,[CustomerAlternateKey] "
            + "    ,[Title] "
            + "    ,[FirstName] "
            + "    ,[MiddleName] "
            + "    ,[LastName] "
            + "    ,[NameStyle] "
            + "    ,[BirthDate] "
            + "    ,[MaritalStatus] "
            + "    ,[Suffix] "
            + "    ,[Gender] "
            + "    ,[EmailAddress] "
            + "    ,[YearlyIncome] "
            + "    ,[TotalChildren] "
            + "    ,[NumberChildrenAtHome] "
            + "    ,[EnglishEducation] "
            + "    ,[SpanishEducation] "
            + "    ,[FrenchEducation] "
            + "    ,[EnglishOccupation] "
            + "    ,[SpanishOccupation] "
            + "    ,[FrenchOccupation] "
            + "    ,[HouseOwnerFlag] "
            + "    ,[NumberCarsOwned] "
            + "    ,[AddressLine1] "
            + "    ,[AddressLine2] "
            + "    ,[Phone] "
            + "    ,[DateFirstPurchase] "
            + "    ,[CommuteDistance] "
            + "FROM "
            + "     [dbo].[DimCustomer] "
            + "WHERE "
            + "     [CustomerKey] = @CustomerKey "
            + "";
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        selectCommand.CommandType = CommandType.Text;
        selectCommand.Parameters.AddWithValue("@CustomerKey", clsdbo_DimCustomerPara.CustomerKey);
        try
        {
            connection.Open();
            SqlDataReader reader
                = selectCommand.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                clsdbo_DimCustomer.CustomerKey = System.Convert.ToInt32(reader["CustomerKey"]);
                clsdbo_DimCustomer.GeographyKey = reader["GeographyKey"] is DBNull ? null : (Int32?)reader["GeographyKey"];
                clsdbo_DimCustomer.CustomerAlternateKey = System.Convert.ToString(reader["CustomerAlternateKey"]);
                clsdbo_DimCustomer.Title = reader["Title"] is DBNull ? null : reader["Title"].ToString();
                clsdbo_DimCustomer.FirstName = reader["FirstName"] is DBNull ? null : reader["FirstName"].ToString();
                clsdbo_DimCustomer.MiddleName = reader["MiddleName"] is DBNull ? null : reader["MiddleName"].ToString();
                clsdbo_DimCustomer.LastName = reader["LastName"] is DBNull ? null : reader["LastName"].ToString();
                clsdbo_DimCustomer.NameStyle = reader["NameStyle"] is DBNull ? null : (Boolean?)reader["NameStyle"];
                clsdbo_DimCustomer.BirthDate = reader["BirthDate"] is DBNull ? null : (DateTime?)reader["BirthDate"];
                clsdbo_DimCustomer.MaritalStatus = reader["MaritalStatus"] is DBNull ? null : reader["MaritalStatus"].ToString();
                clsdbo_DimCustomer.Suffix = reader["Suffix"] is DBNull ? null : reader["Suffix"].ToString();
                clsdbo_DimCustomer.Gender = reader["Gender"] is DBNull ? null : reader["Gender"].ToString();
                clsdbo_DimCustomer.EmailAddress = reader["EmailAddress"] is DBNull ? null : reader["EmailAddress"].ToString();
                clsdbo_DimCustomer.YearlyIncome = reader["YearlyIncome"] is DBNull ? null : (Decimal?)reader["YearlyIncome"];
                clsdbo_DimCustomer.TotalChildren = reader["TotalChildren"] is DBNull ? null : (Byte?)reader["TotalChildren"];
                clsdbo_DimCustomer.NumberChildrenAtHome = reader["NumberChildrenAtHome"] is DBNull ? null : (Byte?)reader["NumberChildrenAtHome"];
                clsdbo_DimCustomer.EnglishEducation = reader["EnglishEducation"] is DBNull ? null : reader["EnglishEducation"].ToString();
                clsdbo_DimCustomer.SpanishEducation = reader["SpanishEducation"] is DBNull ? null : reader["SpanishEducation"].ToString();
                clsdbo_DimCustomer.FrenchEducation = reader["FrenchEducation"] is DBNull ? null : reader["FrenchEducation"].ToString();
                clsdbo_DimCustomer.EnglishOccupation = reader["EnglishOccupation"] is DBNull ? null : reader["EnglishOccupation"].ToString();
                clsdbo_DimCustomer.SpanishOccupation = reader["SpanishOccupation"] is DBNull ? null : reader["SpanishOccupation"].ToString();
                clsdbo_DimCustomer.FrenchOccupation = reader["FrenchOccupation"] is DBNull ? null : reader["FrenchOccupation"].ToString();
                clsdbo_DimCustomer.HouseOwnerFlag = reader["HouseOwnerFlag"] is DBNull ? null : reader["HouseOwnerFlag"].ToString();
                clsdbo_DimCustomer.NumberCarsOwned = reader["NumberCarsOwned"] is DBNull ? null : (Byte?)reader["NumberCarsOwned"];
                clsdbo_DimCustomer.AddressLine1 = reader["AddressLine1"] is DBNull ? null : reader["AddressLine1"].ToString();
                clsdbo_DimCustomer.AddressLine2 = reader["AddressLine2"] is DBNull ? null : reader["AddressLine2"].ToString();
                clsdbo_DimCustomer.Phone = reader["Phone"] is DBNull ? null : reader["Phone"].ToString();
                clsdbo_DimCustomer.DateFirstPurchase = reader["DateFirstPurchase"] is DBNull ? null : (DateTime?)reader["DateFirstPurchase"];
                clsdbo_DimCustomer.CommuteDistance = reader["CommuteDistance"] is DBNull ? null : reader["CommuteDistance"].ToString();
            }
            else
            {
                clsdbo_DimCustomer = null;
            }
            reader.Close();
        }
        catch (SqlException)
        {
            return clsdbo_DimCustomer;
        }
        finally
        {
            connection.Close();
        }
        return clsdbo_DimCustomer;
    }

    public static bool Add(dbo_DimCustomerClass clsdbo_DimCustomer)
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string insertStatement
            = "INSERT " 
            + "     [dbo].[DimCustomer] "
            + "     ( "
            + "     [GeographyKey] "
            + "    ,[CustomerAlternateKey] "
            + "    ,[Title] "
            + "    ,[FirstName] "
            + "    ,[MiddleName] "
            + "    ,[LastName] "
            + "    ,[NameStyle] "
            + "    ,[BirthDate] "
            + "    ,[MaritalStatus] "
            + "    ,[Suffix] "
            + "    ,[Gender] "
            + "    ,[EmailAddress] "
            + "    ,[YearlyIncome] "
            + "    ,[TotalChildren] "
            + "    ,[NumberChildrenAtHome] "
            + "    ,[EnglishEducation] "
            + "    ,[SpanishEducation] "
            + "    ,[FrenchEducation] "
            + "    ,[EnglishOccupation] "
            + "    ,[SpanishOccupation] "
            + "    ,[FrenchOccupation] "
            + "    ,[HouseOwnerFlag] "
            + "    ,[NumberCarsOwned] "
            + "    ,[AddressLine1] "
            + "    ,[AddressLine2] "
            + "    ,[Phone] "
            + "    ,[DateFirstPurchase] "
            + "    ,[CommuteDistance] "
            + "     ) "
            + "VALUES " 
            + "     ( "
            + "     @GeographyKey "
            + "    ,@CustomerAlternateKey "
            + "    ,@Title "
            + "    ,@FirstName "
            + "    ,@MiddleName "
            + "    ,@LastName "
            + "    ,@NameStyle "
            + "    ,@BirthDate "
            + "    ,@MaritalStatus "
            + "    ,@Suffix "
            + "    ,@Gender "
            + "    ,@EmailAddress "
            + "    ,@YearlyIncome "
            + "    ,@TotalChildren "
            + "    ,@NumberChildrenAtHome "
            + "    ,@EnglishEducation "
            + "    ,@SpanishEducation "
            + "    ,@FrenchEducation "
            + "    ,@EnglishOccupation "
            + "    ,@SpanishOccupation "
            + "    ,@FrenchOccupation "
            + "    ,@HouseOwnerFlag "
            + "    ,@NumberCarsOwned "
            + "    ,@AddressLine1 "
            + "    ,@AddressLine2 "
            + "    ,@Phone "
            + "    ,@DateFirstPurchase "
            + "    ,@CommuteDistance "
            + "     ) "
            + "";
        SqlCommand insertCommand = new SqlCommand(insertStatement, connection);
        insertCommand.CommandType = CommandType.Text;
        if (clsdbo_DimCustomer.GeographyKey.HasValue == true) {
            insertCommand.Parameters.AddWithValue("@GeographyKey", clsdbo_DimCustomer.GeographyKey);
        } else {
            insertCommand.Parameters.AddWithValue("@GeographyKey", DBNull.Value); }
        insertCommand.Parameters.AddWithValue("@CustomerAlternateKey", clsdbo_DimCustomer.CustomerAlternateKey);
        if (clsdbo_DimCustomer.Title != null) {
            insertCommand.Parameters.AddWithValue("@Title", clsdbo_DimCustomer.Title);
        } else {
            insertCommand.Parameters.AddWithValue("@Title", DBNull.Value); }
        if (clsdbo_DimCustomer.FirstName != null) {
            insertCommand.Parameters.AddWithValue("@FirstName", clsdbo_DimCustomer.FirstName);
        } else {
            insertCommand.Parameters.AddWithValue("@FirstName", DBNull.Value); }
        if (clsdbo_DimCustomer.MiddleName != null) {
            insertCommand.Parameters.AddWithValue("@MiddleName", clsdbo_DimCustomer.MiddleName);
        } else {
            insertCommand.Parameters.AddWithValue("@MiddleName", DBNull.Value); }
        if (clsdbo_DimCustomer.LastName != null) {
            insertCommand.Parameters.AddWithValue("@LastName", clsdbo_DimCustomer.LastName);
        } else {
            insertCommand.Parameters.AddWithValue("@LastName", DBNull.Value); }
        if (clsdbo_DimCustomer.NameStyle.HasValue == true) {
            insertCommand.Parameters.AddWithValue("@NameStyle", clsdbo_DimCustomer.NameStyle);
        } else {
            insertCommand.Parameters.AddWithValue("@NameStyle", DBNull.Value); }
        if (clsdbo_DimCustomer.BirthDate.HasValue == true) {
            insertCommand.Parameters.AddWithValue("@BirthDate", clsdbo_DimCustomer.BirthDate);
        } else {
            insertCommand.Parameters.AddWithValue("@BirthDate", DBNull.Value); }
        if (clsdbo_DimCustomer.MaritalStatus != null) {
            insertCommand.Parameters.AddWithValue("@MaritalStatus", clsdbo_DimCustomer.MaritalStatus);
        } else {
            insertCommand.Parameters.AddWithValue("@MaritalStatus", DBNull.Value); }
        if (clsdbo_DimCustomer.Suffix != null) {
            insertCommand.Parameters.AddWithValue("@Suffix", clsdbo_DimCustomer.Suffix);
        } else {
            insertCommand.Parameters.AddWithValue("@Suffix", DBNull.Value); }
        if (clsdbo_DimCustomer.Gender != null) {
            insertCommand.Parameters.AddWithValue("@Gender", clsdbo_DimCustomer.Gender);
        } else {
            insertCommand.Parameters.AddWithValue("@Gender", DBNull.Value); }
        if (clsdbo_DimCustomer.EmailAddress != null) {
            insertCommand.Parameters.AddWithValue("@EmailAddress", clsdbo_DimCustomer.EmailAddress);
        } else {
            insertCommand.Parameters.AddWithValue("@EmailAddress", DBNull.Value); }
        if (clsdbo_DimCustomer.YearlyIncome.HasValue == true) {
            insertCommand.Parameters.AddWithValue("@YearlyIncome", clsdbo_DimCustomer.YearlyIncome);
        } else {
            insertCommand.Parameters.AddWithValue("@YearlyIncome", DBNull.Value); }
        if (clsdbo_DimCustomer.TotalChildren.HasValue == true) {
            insertCommand.Parameters.AddWithValue("@TotalChildren", clsdbo_DimCustomer.TotalChildren);
        } else {
            insertCommand.Parameters.AddWithValue("@TotalChildren", DBNull.Value); }
        if (clsdbo_DimCustomer.NumberChildrenAtHome.HasValue == true) {
            insertCommand.Parameters.AddWithValue("@NumberChildrenAtHome", clsdbo_DimCustomer.NumberChildrenAtHome);
        } else {
            insertCommand.Parameters.AddWithValue("@NumberChildrenAtHome", DBNull.Value); }
        if (clsdbo_DimCustomer.EnglishEducation != null) {
            insertCommand.Parameters.AddWithValue("@EnglishEducation", clsdbo_DimCustomer.EnglishEducation);
        } else {
            insertCommand.Parameters.AddWithValue("@EnglishEducation", DBNull.Value); }
        if (clsdbo_DimCustomer.SpanishEducation != null) {
            insertCommand.Parameters.AddWithValue("@SpanishEducation", clsdbo_DimCustomer.SpanishEducation);
        } else {
            insertCommand.Parameters.AddWithValue("@SpanishEducation", DBNull.Value); }
        if (clsdbo_DimCustomer.FrenchEducation != null) {
            insertCommand.Parameters.AddWithValue("@FrenchEducation", clsdbo_DimCustomer.FrenchEducation);
        } else {
            insertCommand.Parameters.AddWithValue("@FrenchEducation", DBNull.Value); }
        if (clsdbo_DimCustomer.EnglishOccupation != null) {
            insertCommand.Parameters.AddWithValue("@EnglishOccupation", clsdbo_DimCustomer.EnglishOccupation);
        } else {
            insertCommand.Parameters.AddWithValue("@EnglishOccupation", DBNull.Value); }
        if (clsdbo_DimCustomer.SpanishOccupation != null) {
            insertCommand.Parameters.AddWithValue("@SpanishOccupation", clsdbo_DimCustomer.SpanishOccupation);
        } else {
            insertCommand.Parameters.AddWithValue("@SpanishOccupation", DBNull.Value); }
        if (clsdbo_DimCustomer.FrenchOccupation != null) {
            insertCommand.Parameters.AddWithValue("@FrenchOccupation", clsdbo_DimCustomer.FrenchOccupation);
        } else {
            insertCommand.Parameters.AddWithValue("@FrenchOccupation", DBNull.Value); }
        if (clsdbo_DimCustomer.HouseOwnerFlag != null) {
            insertCommand.Parameters.AddWithValue("@HouseOwnerFlag", clsdbo_DimCustomer.HouseOwnerFlag);
        } else {
            insertCommand.Parameters.AddWithValue("@HouseOwnerFlag", DBNull.Value); }
        if (clsdbo_DimCustomer.NumberCarsOwned.HasValue == true) {
            insertCommand.Parameters.AddWithValue("@NumberCarsOwned", clsdbo_DimCustomer.NumberCarsOwned);
        } else {
            insertCommand.Parameters.AddWithValue("@NumberCarsOwned", DBNull.Value); }
        if (clsdbo_DimCustomer.AddressLine1 != null) {
            insertCommand.Parameters.AddWithValue("@AddressLine1", clsdbo_DimCustomer.AddressLine1);
        } else {
            insertCommand.Parameters.AddWithValue("@AddressLine1", DBNull.Value); }
        if (clsdbo_DimCustomer.AddressLine2 != null) {
            insertCommand.Parameters.AddWithValue("@AddressLine2", clsdbo_DimCustomer.AddressLine2);
        } else {
            insertCommand.Parameters.AddWithValue("@AddressLine2", DBNull.Value); }
        if (clsdbo_DimCustomer.Phone != null) {
            insertCommand.Parameters.AddWithValue("@Phone", clsdbo_DimCustomer.Phone);
        } else {
            insertCommand.Parameters.AddWithValue("@Phone", DBNull.Value); }
        if (clsdbo_DimCustomer.DateFirstPurchase.HasValue == true) {
            insertCommand.Parameters.AddWithValue("@DateFirstPurchase", clsdbo_DimCustomer.DateFirstPurchase);
        } else {
            insertCommand.Parameters.AddWithValue("@DateFirstPurchase", DBNull.Value); }
        if (clsdbo_DimCustomer.CommuteDistance != null) {
            insertCommand.Parameters.AddWithValue("@CommuteDistance", clsdbo_DimCustomer.CommuteDistance);
        } else {
            insertCommand.Parameters.AddWithValue("@CommuteDistance", DBNull.Value); }
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

    public static bool Update(dbo_DimCustomerClass olddbo_DimCustomerClass, 
           dbo_DimCustomerClass newdbo_DimCustomerClass)
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string updateStatement
            = "UPDATE "  
            + "     [dbo].[DimCustomer] "
            + "SET "
            + "     [GeographyKey] = @NewGeographyKey "
            + "    ,[CustomerAlternateKey] = @NewCustomerAlternateKey "
            + "    ,[Title] = @NewTitle "
            + "    ,[FirstName] = @NewFirstName "
            + "    ,[MiddleName] = @NewMiddleName "
            + "    ,[LastName] = @NewLastName "
            + "    ,[NameStyle] = @NewNameStyle "
            + "    ,[BirthDate] = @NewBirthDate "
            + "    ,[MaritalStatus] = @NewMaritalStatus "
            + "    ,[Suffix] = @NewSuffix "
            + "    ,[Gender] = @NewGender "
            + "    ,[EmailAddress] = @NewEmailAddress "
            + "    ,[YearlyIncome] = @NewYearlyIncome "
            + "    ,[TotalChildren] = @NewTotalChildren "
            + "    ,[NumberChildrenAtHome] = @NewNumberChildrenAtHome "
            + "    ,[EnglishEducation] = @NewEnglishEducation "
            + "    ,[SpanishEducation] = @NewSpanishEducation "
            + "    ,[FrenchEducation] = @NewFrenchEducation "
            + "    ,[EnglishOccupation] = @NewEnglishOccupation "
            + "    ,[SpanishOccupation] = @NewSpanishOccupation "
            + "    ,[FrenchOccupation] = @NewFrenchOccupation "
            + "    ,[HouseOwnerFlag] = @NewHouseOwnerFlag "
            + "    ,[NumberCarsOwned] = @NewNumberCarsOwned "
            + "    ,[AddressLine1] = @NewAddressLine1 "
            + "    ,[AddressLine2] = @NewAddressLine2 "
            + "    ,[Phone] = @NewPhone "
            + "    ,[DateFirstPurchase] = @NewDateFirstPurchase "
            + "    ,[CommuteDistance] = @NewCommuteDistance "
            + "WHERE "
            + "     [CustomerKey] = @OldCustomerKey " 
            + " AND ((@OldGeographyKey IS NULL AND [GeographyKey] IS NULL) OR [GeographyKey] = @OldGeographyKey) " 
            + " AND [CustomerAlternateKey] = @OldCustomerAlternateKey " 
            + " AND ((@OldTitle IS NULL AND [Title] IS NULL) OR [Title] = @OldTitle) " 
            + " AND ((@OldFirstName IS NULL AND [FirstName] IS NULL) OR [FirstName] = @OldFirstName) " 
            + " AND ((@OldMiddleName IS NULL AND [MiddleName] IS NULL) OR [MiddleName] = @OldMiddleName) " 
            + " AND ((@OldLastName IS NULL AND [LastName] IS NULL) OR [LastName] = @OldLastName) " 
            + " AND ((@OldNameStyle IS NULL AND [NameStyle] IS NULL) OR [NameStyle] = @OldNameStyle) " 
            + " AND ((@OldBirthDate IS NULL AND [BirthDate] IS NULL) OR [BirthDate] = @OldBirthDate) " 
            + " AND ((@OldMaritalStatus IS NULL AND [MaritalStatus] IS NULL) OR [MaritalStatus] = @OldMaritalStatus) " 
            + " AND ((@OldSuffix IS NULL AND [Suffix] IS NULL) OR [Suffix] = @OldSuffix) " 
            + " AND ((@OldGender IS NULL AND [Gender] IS NULL) OR [Gender] = @OldGender) " 
            + " AND ((@OldEmailAddress IS NULL AND [EmailAddress] IS NULL) OR [EmailAddress] = @OldEmailAddress) " 
            + " AND ((@OldYearlyIncome IS NULL AND [YearlyIncome] IS NULL) OR [YearlyIncome] = @OldYearlyIncome) " 
            + " AND ((@OldTotalChildren IS NULL AND [TotalChildren] IS NULL) OR [TotalChildren] = @OldTotalChildren) " 
            + " AND ((@OldNumberChildrenAtHome IS NULL AND [NumberChildrenAtHome] IS NULL) OR [NumberChildrenAtHome] = @OldNumberChildrenAtHome) " 
            + " AND ((@OldEnglishEducation IS NULL AND [EnglishEducation] IS NULL) OR [EnglishEducation] = @OldEnglishEducation) " 
            + " AND ((@OldSpanishEducation IS NULL AND [SpanishEducation] IS NULL) OR [SpanishEducation] = @OldSpanishEducation) " 
            + " AND ((@OldFrenchEducation IS NULL AND [FrenchEducation] IS NULL) OR [FrenchEducation] = @OldFrenchEducation) " 
            + " AND ((@OldEnglishOccupation IS NULL AND [EnglishOccupation] IS NULL) OR [EnglishOccupation] = @OldEnglishOccupation) " 
            + " AND ((@OldSpanishOccupation IS NULL AND [SpanishOccupation] IS NULL) OR [SpanishOccupation] = @OldSpanishOccupation) " 
            + " AND ((@OldFrenchOccupation IS NULL AND [FrenchOccupation] IS NULL) OR [FrenchOccupation] = @OldFrenchOccupation) " 
            + " AND ((@OldHouseOwnerFlag IS NULL AND [HouseOwnerFlag] IS NULL) OR [HouseOwnerFlag] = @OldHouseOwnerFlag) " 
            + " AND ((@OldNumberCarsOwned IS NULL AND [NumberCarsOwned] IS NULL) OR [NumberCarsOwned] = @OldNumberCarsOwned) " 
            + " AND ((@OldAddressLine1 IS NULL AND [AddressLine1] IS NULL) OR [AddressLine1] = @OldAddressLine1) " 
            + " AND ((@OldAddressLine2 IS NULL AND [AddressLine2] IS NULL) OR [AddressLine2] = @OldAddressLine2) " 
            + " AND ((@OldPhone IS NULL AND [Phone] IS NULL) OR [Phone] = @OldPhone) " 
            + " AND ((@OldDateFirstPurchase IS NULL AND [DateFirstPurchase] IS NULL) OR [DateFirstPurchase] = @OldDateFirstPurchase) " 
            + " AND ((@OldCommuteDistance IS NULL AND [CommuteDistance] IS NULL) OR [CommuteDistance] = @OldCommuteDistance) " 
            + "";
        SqlCommand updateCommand = new SqlCommand(updateStatement, connection);
        updateCommand.CommandType = CommandType.Text;
        if (newdbo_DimCustomerClass.GeographyKey.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@NewGeographyKey", newdbo_DimCustomerClass.GeographyKey);
        } else {
            updateCommand.Parameters.AddWithValue("@NewGeographyKey", DBNull.Value); }
        updateCommand.Parameters.AddWithValue("@NewCustomerAlternateKey", newdbo_DimCustomerClass.CustomerAlternateKey);
        if (newdbo_DimCustomerClass.Title != null) {
            updateCommand.Parameters.AddWithValue("@NewTitle", newdbo_DimCustomerClass.Title);
        } else {
            updateCommand.Parameters.AddWithValue("@NewTitle", DBNull.Value); }
        if (newdbo_DimCustomerClass.FirstName != null) {
            updateCommand.Parameters.AddWithValue("@NewFirstName", newdbo_DimCustomerClass.FirstName);
        } else {
            updateCommand.Parameters.AddWithValue("@NewFirstName", DBNull.Value); }
        if (newdbo_DimCustomerClass.MiddleName != null) {
            updateCommand.Parameters.AddWithValue("@NewMiddleName", newdbo_DimCustomerClass.MiddleName);
        } else {
            updateCommand.Parameters.AddWithValue("@NewMiddleName", DBNull.Value); }
        if (newdbo_DimCustomerClass.LastName != null) {
            updateCommand.Parameters.AddWithValue("@NewLastName", newdbo_DimCustomerClass.LastName);
        } else {
            updateCommand.Parameters.AddWithValue("@NewLastName", DBNull.Value); }
        if (newdbo_DimCustomerClass.NameStyle.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@NewNameStyle", newdbo_DimCustomerClass.NameStyle);
        } else {
            updateCommand.Parameters.AddWithValue("@NewNameStyle", DBNull.Value); }
        if (newdbo_DimCustomerClass.BirthDate.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@NewBirthDate", newdbo_DimCustomerClass.BirthDate);
        } else {
            updateCommand.Parameters.AddWithValue("@NewBirthDate", DBNull.Value); }
        if (newdbo_DimCustomerClass.MaritalStatus != null) {
            updateCommand.Parameters.AddWithValue("@NewMaritalStatus", newdbo_DimCustomerClass.MaritalStatus);
        } else {
            updateCommand.Parameters.AddWithValue("@NewMaritalStatus", DBNull.Value); }
        if (newdbo_DimCustomerClass.Suffix != null) {
            updateCommand.Parameters.AddWithValue("@NewSuffix", newdbo_DimCustomerClass.Suffix);
        } else {
            updateCommand.Parameters.AddWithValue("@NewSuffix", DBNull.Value); }
        if (newdbo_DimCustomerClass.Gender != null) {
            updateCommand.Parameters.AddWithValue("@NewGender", newdbo_DimCustomerClass.Gender);
        } else {
            updateCommand.Parameters.AddWithValue("@NewGender", DBNull.Value); }
        if (newdbo_DimCustomerClass.EmailAddress != null) {
            updateCommand.Parameters.AddWithValue("@NewEmailAddress", newdbo_DimCustomerClass.EmailAddress);
        } else {
            updateCommand.Parameters.AddWithValue("@NewEmailAddress", DBNull.Value); }
        if (newdbo_DimCustomerClass.YearlyIncome.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@NewYearlyIncome", newdbo_DimCustomerClass.YearlyIncome);
        } else {
            updateCommand.Parameters.AddWithValue("@NewYearlyIncome", DBNull.Value); }
        if (newdbo_DimCustomerClass.TotalChildren.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@NewTotalChildren", newdbo_DimCustomerClass.TotalChildren);
        } else {
            updateCommand.Parameters.AddWithValue("@NewTotalChildren", DBNull.Value); }
        if (newdbo_DimCustomerClass.NumberChildrenAtHome.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@NewNumberChildrenAtHome", newdbo_DimCustomerClass.NumberChildrenAtHome);
        } else {
            updateCommand.Parameters.AddWithValue("@NewNumberChildrenAtHome", DBNull.Value); }
        if (newdbo_DimCustomerClass.EnglishEducation != null) {
            updateCommand.Parameters.AddWithValue("@NewEnglishEducation", newdbo_DimCustomerClass.EnglishEducation);
        } else {
            updateCommand.Parameters.AddWithValue("@NewEnglishEducation", DBNull.Value); }
        if (newdbo_DimCustomerClass.SpanishEducation != null) {
            updateCommand.Parameters.AddWithValue("@NewSpanishEducation", newdbo_DimCustomerClass.SpanishEducation);
        } else {
            updateCommand.Parameters.AddWithValue("@NewSpanishEducation", DBNull.Value); }
        if (newdbo_DimCustomerClass.FrenchEducation != null) {
            updateCommand.Parameters.AddWithValue("@NewFrenchEducation", newdbo_DimCustomerClass.FrenchEducation);
        } else {
            updateCommand.Parameters.AddWithValue("@NewFrenchEducation", DBNull.Value); }
        if (newdbo_DimCustomerClass.EnglishOccupation != null) {
            updateCommand.Parameters.AddWithValue("@NewEnglishOccupation", newdbo_DimCustomerClass.EnglishOccupation);
        } else {
            updateCommand.Parameters.AddWithValue("@NewEnglishOccupation", DBNull.Value); }
        if (newdbo_DimCustomerClass.SpanishOccupation != null) {
            updateCommand.Parameters.AddWithValue("@NewSpanishOccupation", newdbo_DimCustomerClass.SpanishOccupation);
        } else {
            updateCommand.Parameters.AddWithValue("@NewSpanishOccupation", DBNull.Value); }
        if (newdbo_DimCustomerClass.FrenchOccupation != null) {
            updateCommand.Parameters.AddWithValue("@NewFrenchOccupation", newdbo_DimCustomerClass.FrenchOccupation);
        } else {
            updateCommand.Parameters.AddWithValue("@NewFrenchOccupation", DBNull.Value); }
        if (newdbo_DimCustomerClass.HouseOwnerFlag != null) {
            updateCommand.Parameters.AddWithValue("@NewHouseOwnerFlag", newdbo_DimCustomerClass.HouseOwnerFlag);
        } else {
            updateCommand.Parameters.AddWithValue("@NewHouseOwnerFlag", DBNull.Value); }
        if (newdbo_DimCustomerClass.NumberCarsOwned.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@NewNumberCarsOwned", newdbo_DimCustomerClass.NumberCarsOwned);
        } else {
            updateCommand.Parameters.AddWithValue("@NewNumberCarsOwned", DBNull.Value); }
        if (newdbo_DimCustomerClass.AddressLine1 != null) {
            updateCommand.Parameters.AddWithValue("@NewAddressLine1", newdbo_DimCustomerClass.AddressLine1);
        } else {
            updateCommand.Parameters.AddWithValue("@NewAddressLine1", DBNull.Value); }
        if (newdbo_DimCustomerClass.AddressLine2 != null) {
            updateCommand.Parameters.AddWithValue("@NewAddressLine2", newdbo_DimCustomerClass.AddressLine2);
        } else {
            updateCommand.Parameters.AddWithValue("@NewAddressLine2", DBNull.Value); }
        if (newdbo_DimCustomerClass.Phone != null) {
            updateCommand.Parameters.AddWithValue("@NewPhone", newdbo_DimCustomerClass.Phone);
        } else {
            updateCommand.Parameters.AddWithValue("@NewPhone", DBNull.Value); }
        if (newdbo_DimCustomerClass.DateFirstPurchase.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@NewDateFirstPurchase", newdbo_DimCustomerClass.DateFirstPurchase);
        } else {
            updateCommand.Parameters.AddWithValue("@NewDateFirstPurchase", DBNull.Value); }
        if (newdbo_DimCustomerClass.CommuteDistance != null) {
            updateCommand.Parameters.AddWithValue("@NewCommuteDistance", newdbo_DimCustomerClass.CommuteDistance);
        } else {
            updateCommand.Parameters.AddWithValue("@NewCommuteDistance", DBNull.Value); }
        updateCommand.Parameters.AddWithValue("@OldCustomerKey", olddbo_DimCustomerClass.CustomerKey);
        if (olddbo_DimCustomerClass.GeographyKey.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@OldGeographyKey", olddbo_DimCustomerClass.GeographyKey);
        } else {
            updateCommand.Parameters.AddWithValue("@OldGeographyKey", DBNull.Value); }
        updateCommand.Parameters.AddWithValue("@OldCustomerAlternateKey", olddbo_DimCustomerClass.CustomerAlternateKey);
        if (olddbo_DimCustomerClass.Title != null) {
            updateCommand.Parameters.AddWithValue("@OldTitle", olddbo_DimCustomerClass.Title);
        } else {
            updateCommand.Parameters.AddWithValue("@OldTitle", DBNull.Value); }
        if (olddbo_DimCustomerClass.FirstName != null) {
            updateCommand.Parameters.AddWithValue("@OldFirstName", olddbo_DimCustomerClass.FirstName);
        } else {
            updateCommand.Parameters.AddWithValue("@OldFirstName", DBNull.Value); }
        if (olddbo_DimCustomerClass.MiddleName != null) {
            updateCommand.Parameters.AddWithValue("@OldMiddleName", olddbo_DimCustomerClass.MiddleName);
        } else {
            updateCommand.Parameters.AddWithValue("@OldMiddleName", DBNull.Value); }
        if (olddbo_DimCustomerClass.LastName != null) {
            updateCommand.Parameters.AddWithValue("@OldLastName", olddbo_DimCustomerClass.LastName);
        } else {
            updateCommand.Parameters.AddWithValue("@OldLastName", DBNull.Value); }
        if (olddbo_DimCustomerClass.NameStyle.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@OldNameStyle", olddbo_DimCustomerClass.NameStyle);
        } else {
            updateCommand.Parameters.AddWithValue("@OldNameStyle", DBNull.Value); }
        if (olddbo_DimCustomerClass.BirthDate.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@OldBirthDate", olddbo_DimCustomerClass.BirthDate);
        } else {
            updateCommand.Parameters.AddWithValue("@OldBirthDate", DBNull.Value); }
        if (olddbo_DimCustomerClass.MaritalStatus != null) {
            updateCommand.Parameters.AddWithValue("@OldMaritalStatus", olddbo_DimCustomerClass.MaritalStatus);
        } else {
            updateCommand.Parameters.AddWithValue("@OldMaritalStatus", DBNull.Value); }
        if (olddbo_DimCustomerClass.Suffix != null) {
            updateCommand.Parameters.AddWithValue("@OldSuffix", olddbo_DimCustomerClass.Suffix);
        } else {
            updateCommand.Parameters.AddWithValue("@OldSuffix", DBNull.Value); }
        if (olddbo_DimCustomerClass.Gender != null) {
            updateCommand.Parameters.AddWithValue("@OldGender", olddbo_DimCustomerClass.Gender);
        } else {
            updateCommand.Parameters.AddWithValue("@OldGender", DBNull.Value); }
        if (olddbo_DimCustomerClass.EmailAddress != null) {
            updateCommand.Parameters.AddWithValue("@OldEmailAddress", olddbo_DimCustomerClass.EmailAddress);
        } else {
            updateCommand.Parameters.AddWithValue("@OldEmailAddress", DBNull.Value); }
        if (olddbo_DimCustomerClass.YearlyIncome.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@OldYearlyIncome", olddbo_DimCustomerClass.YearlyIncome);
        } else {
            updateCommand.Parameters.AddWithValue("@OldYearlyIncome", DBNull.Value); }
        if (olddbo_DimCustomerClass.TotalChildren.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@OldTotalChildren", olddbo_DimCustomerClass.TotalChildren);
        } else {
            updateCommand.Parameters.AddWithValue("@OldTotalChildren", DBNull.Value); }
        if (olddbo_DimCustomerClass.NumberChildrenAtHome.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@OldNumberChildrenAtHome", olddbo_DimCustomerClass.NumberChildrenAtHome);
        } else {
            updateCommand.Parameters.AddWithValue("@OldNumberChildrenAtHome", DBNull.Value); }
        if (olddbo_DimCustomerClass.EnglishEducation != null) {
            updateCommand.Parameters.AddWithValue("@OldEnglishEducation", olddbo_DimCustomerClass.EnglishEducation);
        } else {
            updateCommand.Parameters.AddWithValue("@OldEnglishEducation", DBNull.Value); }
        if (olddbo_DimCustomerClass.SpanishEducation != null) {
            updateCommand.Parameters.AddWithValue("@OldSpanishEducation", olddbo_DimCustomerClass.SpanishEducation);
        } else {
            updateCommand.Parameters.AddWithValue("@OldSpanishEducation", DBNull.Value); }
        if (olddbo_DimCustomerClass.FrenchEducation != null) {
            updateCommand.Parameters.AddWithValue("@OldFrenchEducation", olddbo_DimCustomerClass.FrenchEducation);
        } else {
            updateCommand.Parameters.AddWithValue("@OldFrenchEducation", DBNull.Value); }
        if (olddbo_DimCustomerClass.EnglishOccupation != null) {
            updateCommand.Parameters.AddWithValue("@OldEnglishOccupation", olddbo_DimCustomerClass.EnglishOccupation);
        } else {
            updateCommand.Parameters.AddWithValue("@OldEnglishOccupation", DBNull.Value); }
        if (olddbo_DimCustomerClass.SpanishOccupation != null) {
            updateCommand.Parameters.AddWithValue("@OldSpanishOccupation", olddbo_DimCustomerClass.SpanishOccupation);
        } else {
            updateCommand.Parameters.AddWithValue("@OldSpanishOccupation", DBNull.Value); }
        if (olddbo_DimCustomerClass.FrenchOccupation != null) {
            updateCommand.Parameters.AddWithValue("@OldFrenchOccupation", olddbo_DimCustomerClass.FrenchOccupation);
        } else {
            updateCommand.Parameters.AddWithValue("@OldFrenchOccupation", DBNull.Value); }
        if (olddbo_DimCustomerClass.HouseOwnerFlag != null) {
            updateCommand.Parameters.AddWithValue("@OldHouseOwnerFlag", olddbo_DimCustomerClass.HouseOwnerFlag);
        } else {
            updateCommand.Parameters.AddWithValue("@OldHouseOwnerFlag", DBNull.Value); }
        if (olddbo_DimCustomerClass.NumberCarsOwned.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@OldNumberCarsOwned", olddbo_DimCustomerClass.NumberCarsOwned);
        } else {
            updateCommand.Parameters.AddWithValue("@OldNumberCarsOwned", DBNull.Value); }
        if (olddbo_DimCustomerClass.AddressLine1 != null) {
            updateCommand.Parameters.AddWithValue("@OldAddressLine1", olddbo_DimCustomerClass.AddressLine1);
        } else {
            updateCommand.Parameters.AddWithValue("@OldAddressLine1", DBNull.Value); }
        if (olddbo_DimCustomerClass.AddressLine2 != null) {
            updateCommand.Parameters.AddWithValue("@OldAddressLine2", olddbo_DimCustomerClass.AddressLine2);
        } else {
            updateCommand.Parameters.AddWithValue("@OldAddressLine2", DBNull.Value); }
        if (olddbo_DimCustomerClass.Phone != null) {
            updateCommand.Parameters.AddWithValue("@OldPhone", olddbo_DimCustomerClass.Phone);
        } else {
            updateCommand.Parameters.AddWithValue("@OldPhone", DBNull.Value); }
        if (olddbo_DimCustomerClass.DateFirstPurchase.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@OldDateFirstPurchase", olddbo_DimCustomerClass.DateFirstPurchase);
        } else {
            updateCommand.Parameters.AddWithValue("@OldDateFirstPurchase", DBNull.Value); }
        if (olddbo_DimCustomerClass.CommuteDistance != null) {
            updateCommand.Parameters.AddWithValue("@OldCommuteDistance", olddbo_DimCustomerClass.CommuteDistance);
        } else {
            updateCommand.Parameters.AddWithValue("@OldCommuteDistance", DBNull.Value); }
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

    public static bool Delete(dbo_DimCustomerClass clsdbo_DimCustomer)
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string deleteStatement
            = "DELETE FROM "  
            + "     [dbo].[DimCustomer] "
            + "WHERE " 
            + "     [CustomerKey] = @OldCustomerKey " 
            + " AND ((@OldGeographyKey IS NULL AND [GeographyKey] IS NULL) OR [GeographyKey] = @OldGeographyKey) " 
            + " AND [CustomerAlternateKey] = @OldCustomerAlternateKey " 
            + " AND ((@OldTitle IS NULL AND [Title] IS NULL) OR [Title] = @OldTitle) " 
            + " AND ((@OldFirstName IS NULL AND [FirstName] IS NULL) OR [FirstName] = @OldFirstName) " 
            + " AND ((@OldMiddleName IS NULL AND [MiddleName] IS NULL) OR [MiddleName] = @OldMiddleName) " 
            + " AND ((@OldLastName IS NULL AND [LastName] IS NULL) OR [LastName] = @OldLastName) " 
            + " AND ((@OldNameStyle IS NULL AND [NameStyle] IS NULL) OR [NameStyle] = @OldNameStyle) " 
            + " AND ((@OldBirthDate IS NULL AND [BirthDate] IS NULL) OR [BirthDate] = @OldBirthDate) " 
            + " AND ((@OldMaritalStatus IS NULL AND [MaritalStatus] IS NULL) OR [MaritalStatus] = @OldMaritalStatus) " 
            + " AND ((@OldSuffix IS NULL AND [Suffix] IS NULL) OR [Suffix] = @OldSuffix) " 
            + " AND ((@OldGender IS NULL AND [Gender] IS NULL) OR [Gender] = @OldGender) " 
            + " AND ((@OldEmailAddress IS NULL AND [EmailAddress] IS NULL) OR [EmailAddress] = @OldEmailAddress) " 
            + " AND ((@OldYearlyIncome IS NULL AND [YearlyIncome] IS NULL) OR [YearlyIncome] = @OldYearlyIncome) " 
            + " AND ((@OldTotalChildren IS NULL AND [TotalChildren] IS NULL) OR [TotalChildren] = @OldTotalChildren) " 
            + " AND ((@OldNumberChildrenAtHome IS NULL AND [NumberChildrenAtHome] IS NULL) OR [NumberChildrenAtHome] = @OldNumberChildrenAtHome) " 
            + " AND ((@OldEnglishEducation IS NULL AND [EnglishEducation] IS NULL) OR [EnglishEducation] = @OldEnglishEducation) " 
            + " AND ((@OldSpanishEducation IS NULL AND [SpanishEducation] IS NULL) OR [SpanishEducation] = @OldSpanishEducation) " 
            + " AND ((@OldFrenchEducation IS NULL AND [FrenchEducation] IS NULL) OR [FrenchEducation] = @OldFrenchEducation) " 
            + " AND ((@OldEnglishOccupation IS NULL AND [EnglishOccupation] IS NULL) OR [EnglishOccupation] = @OldEnglishOccupation) " 
            + " AND ((@OldSpanishOccupation IS NULL AND [SpanishOccupation] IS NULL) OR [SpanishOccupation] = @OldSpanishOccupation) " 
            + " AND ((@OldFrenchOccupation IS NULL AND [FrenchOccupation] IS NULL) OR [FrenchOccupation] = @OldFrenchOccupation) " 
            + " AND ((@OldHouseOwnerFlag IS NULL AND [HouseOwnerFlag] IS NULL) OR [HouseOwnerFlag] = @OldHouseOwnerFlag) " 
            + " AND ((@OldNumberCarsOwned IS NULL AND [NumberCarsOwned] IS NULL) OR [NumberCarsOwned] = @OldNumberCarsOwned) " 
            + " AND ((@OldAddressLine1 IS NULL AND [AddressLine1] IS NULL) OR [AddressLine1] = @OldAddressLine1) " 
            + " AND ((@OldAddressLine2 IS NULL AND [AddressLine2] IS NULL) OR [AddressLine2] = @OldAddressLine2) " 
            + " AND ((@OldPhone IS NULL AND [Phone] IS NULL) OR [Phone] = @OldPhone) " 
            + " AND ((@OldDateFirstPurchase IS NULL AND [DateFirstPurchase] IS NULL) OR [DateFirstPurchase] = @OldDateFirstPurchase) " 
            + " AND ((@OldCommuteDistance IS NULL AND [CommuteDistance] IS NULL) OR [CommuteDistance] = @OldCommuteDistance) " 
            + "";
        SqlCommand deleteCommand = new SqlCommand(deleteStatement, connection);
        deleteCommand.CommandType = CommandType.Text;
        deleteCommand.Parameters.AddWithValue("@OldCustomerKey", clsdbo_DimCustomer.CustomerKey);
        if (clsdbo_DimCustomer.GeographyKey.HasValue == true) {
            deleteCommand.Parameters.AddWithValue("@OldGeographyKey", clsdbo_DimCustomer.GeographyKey);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldGeographyKey", DBNull.Value); }
        deleteCommand.Parameters.AddWithValue("@OldCustomerAlternateKey", clsdbo_DimCustomer.CustomerAlternateKey);
        if (clsdbo_DimCustomer.Title != null) {
            deleteCommand.Parameters.AddWithValue("@OldTitle", clsdbo_DimCustomer.Title);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldTitle", DBNull.Value); }
        if (clsdbo_DimCustomer.FirstName != null) {
            deleteCommand.Parameters.AddWithValue("@OldFirstName", clsdbo_DimCustomer.FirstName);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldFirstName", DBNull.Value); }
        if (clsdbo_DimCustomer.MiddleName != null) {
            deleteCommand.Parameters.AddWithValue("@OldMiddleName", clsdbo_DimCustomer.MiddleName);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldMiddleName", DBNull.Value); }
        if (clsdbo_DimCustomer.LastName != null) {
            deleteCommand.Parameters.AddWithValue("@OldLastName", clsdbo_DimCustomer.LastName);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldLastName", DBNull.Value); }
        if (clsdbo_DimCustomer.NameStyle.HasValue == true) {
            deleteCommand.Parameters.AddWithValue("@OldNameStyle", clsdbo_DimCustomer.NameStyle);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldNameStyle", DBNull.Value); }
        if (clsdbo_DimCustomer.BirthDate.HasValue == true) {
            deleteCommand.Parameters.AddWithValue("@OldBirthDate", clsdbo_DimCustomer.BirthDate);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldBirthDate", DBNull.Value); }
        if (clsdbo_DimCustomer.MaritalStatus != null) {
            deleteCommand.Parameters.AddWithValue("@OldMaritalStatus", clsdbo_DimCustomer.MaritalStatus);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldMaritalStatus", DBNull.Value); }
        if (clsdbo_DimCustomer.Suffix != null) {
            deleteCommand.Parameters.AddWithValue("@OldSuffix", clsdbo_DimCustomer.Suffix);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldSuffix", DBNull.Value); }
        if (clsdbo_DimCustomer.Gender != null) {
            deleteCommand.Parameters.AddWithValue("@OldGender", clsdbo_DimCustomer.Gender);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldGender", DBNull.Value); }
        if (clsdbo_DimCustomer.EmailAddress != null) {
            deleteCommand.Parameters.AddWithValue("@OldEmailAddress", clsdbo_DimCustomer.EmailAddress);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldEmailAddress", DBNull.Value); }
        if (clsdbo_DimCustomer.YearlyIncome.HasValue == true) {
            deleteCommand.Parameters.AddWithValue("@OldYearlyIncome", clsdbo_DimCustomer.YearlyIncome);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldYearlyIncome", DBNull.Value); }
        if (clsdbo_DimCustomer.TotalChildren.HasValue == true) {
            deleteCommand.Parameters.AddWithValue("@OldTotalChildren", clsdbo_DimCustomer.TotalChildren);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldTotalChildren", DBNull.Value); }
        if (clsdbo_DimCustomer.NumberChildrenAtHome.HasValue == true) {
            deleteCommand.Parameters.AddWithValue("@OldNumberChildrenAtHome", clsdbo_DimCustomer.NumberChildrenAtHome);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldNumberChildrenAtHome", DBNull.Value); }
        if (clsdbo_DimCustomer.EnglishEducation != null) {
            deleteCommand.Parameters.AddWithValue("@OldEnglishEducation", clsdbo_DimCustomer.EnglishEducation);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldEnglishEducation", DBNull.Value); }
        if (clsdbo_DimCustomer.SpanishEducation != null) {
            deleteCommand.Parameters.AddWithValue("@OldSpanishEducation", clsdbo_DimCustomer.SpanishEducation);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldSpanishEducation", DBNull.Value); }
        if (clsdbo_DimCustomer.FrenchEducation != null) {
            deleteCommand.Parameters.AddWithValue("@OldFrenchEducation", clsdbo_DimCustomer.FrenchEducation);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldFrenchEducation", DBNull.Value); }
        if (clsdbo_DimCustomer.EnglishOccupation != null) {
            deleteCommand.Parameters.AddWithValue("@OldEnglishOccupation", clsdbo_DimCustomer.EnglishOccupation);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldEnglishOccupation", DBNull.Value); }
        if (clsdbo_DimCustomer.SpanishOccupation != null) {
            deleteCommand.Parameters.AddWithValue("@OldSpanishOccupation", clsdbo_DimCustomer.SpanishOccupation);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldSpanishOccupation", DBNull.Value); }
        if (clsdbo_DimCustomer.FrenchOccupation != null) {
            deleteCommand.Parameters.AddWithValue("@OldFrenchOccupation", clsdbo_DimCustomer.FrenchOccupation);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldFrenchOccupation", DBNull.Value); }
        if (clsdbo_DimCustomer.HouseOwnerFlag != null) {
            deleteCommand.Parameters.AddWithValue("@OldHouseOwnerFlag", clsdbo_DimCustomer.HouseOwnerFlag);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldHouseOwnerFlag", DBNull.Value); }
        if (clsdbo_DimCustomer.NumberCarsOwned.HasValue == true) {
            deleteCommand.Parameters.AddWithValue("@OldNumberCarsOwned", clsdbo_DimCustomer.NumberCarsOwned);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldNumberCarsOwned", DBNull.Value); }
        if (clsdbo_DimCustomer.AddressLine1 != null) {
            deleteCommand.Parameters.AddWithValue("@OldAddressLine1", clsdbo_DimCustomer.AddressLine1);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldAddressLine1", DBNull.Value); }
        if (clsdbo_DimCustomer.AddressLine2 != null) {
            deleteCommand.Parameters.AddWithValue("@OldAddressLine2", clsdbo_DimCustomer.AddressLine2);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldAddressLine2", DBNull.Value); }
        if (clsdbo_DimCustomer.Phone != null) {
            deleteCommand.Parameters.AddWithValue("@OldPhone", clsdbo_DimCustomer.Phone);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldPhone", DBNull.Value); }
        if (clsdbo_DimCustomer.DateFirstPurchase.HasValue == true) {
            deleteCommand.Parameters.AddWithValue("@OldDateFirstPurchase", clsdbo_DimCustomer.DateFirstPurchase);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldDateFirstPurchase", DBNull.Value); }
        if (clsdbo_DimCustomer.CommuteDistance != null) {
            deleteCommand.Parameters.AddWithValue("@OldCommuteDistance", clsdbo_DimCustomer.CommuteDistance);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldCommuteDistance", DBNull.Value); }
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

 
