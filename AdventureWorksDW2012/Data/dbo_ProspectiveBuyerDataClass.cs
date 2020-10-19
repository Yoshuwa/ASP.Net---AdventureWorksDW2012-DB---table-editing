using System;
using System.Data;
using System.Data.SqlClient;

public class dbo_ProspectiveBuyerDataClass
{

    public static DataTable SelectAll()
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement
            = "SELECT "  
            + "     [dbo].[ProspectiveBuyer].[ProspectiveBuyerKey] "
            + "    ,[dbo].[ProspectiveBuyer].[ProspectAlternateKey] "
            + "    ,[dbo].[ProspectiveBuyer].[FirstName] "
            + "    ,[dbo].[ProspectiveBuyer].[MiddleName] "
            + "    ,[dbo].[ProspectiveBuyer].[LastName] "
            + "    ,[dbo].[ProspectiveBuyer].[BirthDate] "
            + "    ,[dbo].[ProspectiveBuyer].[MaritalStatus] "
            + "    ,[dbo].[ProspectiveBuyer].[Gender] "
            + "    ,[dbo].[ProspectiveBuyer].[EmailAddress] "
            + "    ,[dbo].[ProspectiveBuyer].[YearlyIncome] "
            + "    ,[dbo].[ProspectiveBuyer].[TotalChildren] "
            + "    ,[dbo].[ProspectiveBuyer].[NumberChildrenAtHome] "
            + "    ,[dbo].[ProspectiveBuyer].[Education] "
            + "    ,[dbo].[ProspectiveBuyer].[Occupation] "
            + "    ,[dbo].[ProspectiveBuyer].[HouseOwnerFlag] "
            + "    ,[dbo].[ProspectiveBuyer].[NumberCarsOwned] "
            + "    ,[dbo].[ProspectiveBuyer].[AddressLine1] "
            + "    ,[dbo].[ProspectiveBuyer].[AddressLine2] "
            + "    ,[dbo].[ProspectiveBuyer].[City] "
            + "    ,[dbo].[ProspectiveBuyer].[StateProvinceCode] "
            + "    ,[dbo].[ProspectiveBuyer].[PostalCode] "
            + "    ,[dbo].[ProspectiveBuyer].[Phone] "
            + "    ,[dbo].[ProspectiveBuyer].[Salutation] "
            + "    ,[dbo].[ProspectiveBuyer].[Unknown] "
            + "FROM " 
            + "     [dbo].[ProspectiveBuyer] " 
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
            + "     [dbo].[ProspectiveBuyer].[ProspectiveBuyerKey] "
            + "    ,[dbo].[ProspectiveBuyer].[ProspectAlternateKey] "
            + "    ,[dbo].[ProspectiveBuyer].[FirstName] "
            + "    ,[dbo].[ProspectiveBuyer].[MiddleName] "
            + "    ,[dbo].[ProspectiveBuyer].[LastName] "
            + "    ,[dbo].[ProspectiveBuyer].[BirthDate] "
            + "    ,[dbo].[ProspectiveBuyer].[MaritalStatus] "
            + "    ,[dbo].[ProspectiveBuyer].[Gender] "
            + "    ,[dbo].[ProspectiveBuyer].[EmailAddress] "
            + "    ,[dbo].[ProspectiveBuyer].[YearlyIncome] "
            + "    ,[dbo].[ProspectiveBuyer].[TotalChildren] "
            + "    ,[dbo].[ProspectiveBuyer].[NumberChildrenAtHome] "
            + "    ,[dbo].[ProspectiveBuyer].[Education] "
            + "    ,[dbo].[ProspectiveBuyer].[Occupation] "
            + "    ,[dbo].[ProspectiveBuyer].[HouseOwnerFlag] "
            + "    ,[dbo].[ProspectiveBuyer].[NumberCarsOwned] "
            + "    ,[dbo].[ProspectiveBuyer].[AddressLine1] "
            + "    ,[dbo].[ProspectiveBuyer].[AddressLine2] "
            + "    ,[dbo].[ProspectiveBuyer].[City] "
            + "    ,[dbo].[ProspectiveBuyer].[StateProvinceCode] "
            + "    ,[dbo].[ProspectiveBuyer].[PostalCode] "
            + "    ,[dbo].[ProspectiveBuyer].[Phone] "
            + "    ,[dbo].[ProspectiveBuyer].[Salutation] "
            + "    ,[dbo].[ProspectiveBuyer].[Unknown] "
            + "FROM " 
            + "     [dbo].[ProspectiveBuyer] " 
                + "WHERE " 
                + "     (@ProspectiveBuyerKey IS NULL OR @ProspectiveBuyerKey = '' OR [ProspectiveBuyer].[ProspectiveBuyerKey] LIKE '%' + LTRIM(RTRIM(@ProspectiveBuyerKey)) + '%') " 
                + "AND   (@ProspectAlternateKey IS NULL OR @ProspectAlternateKey = '' OR [ProspectiveBuyer].[ProspectAlternateKey] LIKE '%' + LTRIM(RTRIM(@ProspectAlternateKey)) + '%') " 
                + "AND   (@FirstName IS NULL OR @FirstName = '' OR [ProspectiveBuyer].[FirstName] LIKE '%' + LTRIM(RTRIM(@FirstName)) + '%') " 
                + "AND   (@MiddleName IS NULL OR @MiddleName = '' OR [ProspectiveBuyer].[MiddleName] LIKE '%' + LTRIM(RTRIM(@MiddleName)) + '%') " 
                + "AND   (@LastName IS NULL OR @LastName = '' OR [ProspectiveBuyer].[LastName] LIKE '%' + LTRIM(RTRIM(@LastName)) + '%') " 
                + "AND   (@BirthDate IS NULL OR @BirthDate = '' OR [ProspectiveBuyer].[BirthDate] LIKE '%' + LTRIM(RTRIM(@BirthDate)) + '%') " 
                + "AND   (@MaritalStatus IS NULL OR @MaritalStatus = '' OR [ProspectiveBuyer].[MaritalStatus] LIKE '%' + LTRIM(RTRIM(@MaritalStatus)) + '%') " 
                + "AND   (@Gender IS NULL OR @Gender = '' OR [ProspectiveBuyer].[Gender] LIKE '%' + LTRIM(RTRIM(@Gender)) + '%') " 
                + "AND   (@EmailAddress IS NULL OR @EmailAddress = '' OR [ProspectiveBuyer].[EmailAddress] LIKE '%' + LTRIM(RTRIM(@EmailAddress)) + '%') " 
                + "AND   (@YearlyIncome IS NULL OR @YearlyIncome = '' OR [ProspectiveBuyer].[YearlyIncome] LIKE '%' + LTRIM(RTRIM(@YearlyIncome)) + '%') " 
                + "AND   (@TotalChildren IS NULL OR @TotalChildren = '' OR [ProspectiveBuyer].[TotalChildren] LIKE '%' + LTRIM(RTRIM(@TotalChildren)) + '%') " 
                + "AND   (@NumberChildrenAtHome IS NULL OR @NumberChildrenAtHome = '' OR [ProspectiveBuyer].[NumberChildrenAtHome] LIKE '%' + LTRIM(RTRIM(@NumberChildrenAtHome)) + '%') " 
                + "AND   (@Education IS NULL OR @Education = '' OR [ProspectiveBuyer].[Education] LIKE '%' + LTRIM(RTRIM(@Education)) + '%') " 
                + "AND   (@Occupation IS NULL OR @Occupation = '' OR [ProspectiveBuyer].[Occupation] LIKE '%' + LTRIM(RTRIM(@Occupation)) + '%') " 
                + "AND   (@HouseOwnerFlag IS NULL OR @HouseOwnerFlag = '' OR [ProspectiveBuyer].[HouseOwnerFlag] LIKE '%' + LTRIM(RTRIM(@HouseOwnerFlag)) + '%') " 
                + "AND   (@NumberCarsOwned IS NULL OR @NumberCarsOwned = '' OR [ProspectiveBuyer].[NumberCarsOwned] LIKE '%' + LTRIM(RTRIM(@NumberCarsOwned)) + '%') " 
                + "AND   (@AddressLine1 IS NULL OR @AddressLine1 = '' OR [ProspectiveBuyer].[AddressLine1] LIKE '%' + LTRIM(RTRIM(@AddressLine1)) + '%') " 
                + "AND   (@AddressLine2 IS NULL OR @AddressLine2 = '' OR [ProspectiveBuyer].[AddressLine2] LIKE '%' + LTRIM(RTRIM(@AddressLine2)) + '%') " 
                + "AND   (@City IS NULL OR @City = '' OR [ProspectiveBuyer].[City] LIKE '%' + LTRIM(RTRIM(@City)) + '%') " 
                + "AND   (@StateProvinceCode IS NULL OR @StateProvinceCode = '' OR [ProspectiveBuyer].[StateProvinceCode] LIKE '%' + LTRIM(RTRIM(@StateProvinceCode)) + '%') " 
                + "AND   (@PostalCode IS NULL OR @PostalCode = '' OR [ProspectiveBuyer].[PostalCode] LIKE '%' + LTRIM(RTRIM(@PostalCode)) + '%') " 
                + "AND   (@Phone IS NULL OR @Phone = '' OR [ProspectiveBuyer].[Phone] LIKE '%' + LTRIM(RTRIM(@Phone)) + '%') " 
                + "AND   (@Salutation IS NULL OR @Salutation = '' OR [ProspectiveBuyer].[Salutation] LIKE '%' + LTRIM(RTRIM(@Salutation)) + '%') " 
                + "AND   (@Unknown IS NULL OR @Unknown = '' OR [ProspectiveBuyer].[Unknown] LIKE '%' + LTRIM(RTRIM(@Unknown)) + '%') " 
                + "";
        } else if (sCondition == "Equals") {
            selectStatement
                = "SELECT "
            + "     [dbo].[ProspectiveBuyer].[ProspectiveBuyerKey] "
            + "    ,[dbo].[ProspectiveBuyer].[ProspectAlternateKey] "
            + "    ,[dbo].[ProspectiveBuyer].[FirstName] "
            + "    ,[dbo].[ProspectiveBuyer].[MiddleName] "
            + "    ,[dbo].[ProspectiveBuyer].[LastName] "
            + "    ,[dbo].[ProspectiveBuyer].[BirthDate] "
            + "    ,[dbo].[ProspectiveBuyer].[MaritalStatus] "
            + "    ,[dbo].[ProspectiveBuyer].[Gender] "
            + "    ,[dbo].[ProspectiveBuyer].[EmailAddress] "
            + "    ,[dbo].[ProspectiveBuyer].[YearlyIncome] "
            + "    ,[dbo].[ProspectiveBuyer].[TotalChildren] "
            + "    ,[dbo].[ProspectiveBuyer].[NumberChildrenAtHome] "
            + "    ,[dbo].[ProspectiveBuyer].[Education] "
            + "    ,[dbo].[ProspectiveBuyer].[Occupation] "
            + "    ,[dbo].[ProspectiveBuyer].[HouseOwnerFlag] "
            + "    ,[dbo].[ProspectiveBuyer].[NumberCarsOwned] "
            + "    ,[dbo].[ProspectiveBuyer].[AddressLine1] "
            + "    ,[dbo].[ProspectiveBuyer].[AddressLine2] "
            + "    ,[dbo].[ProspectiveBuyer].[City] "
            + "    ,[dbo].[ProspectiveBuyer].[StateProvinceCode] "
            + "    ,[dbo].[ProspectiveBuyer].[PostalCode] "
            + "    ,[dbo].[ProspectiveBuyer].[Phone] "
            + "    ,[dbo].[ProspectiveBuyer].[Salutation] "
            + "    ,[dbo].[ProspectiveBuyer].[Unknown] "
            + "FROM " 
            + "     [dbo].[ProspectiveBuyer] " 
                + "WHERE " 
                + "     (@ProspectiveBuyerKey IS NULL OR @ProspectiveBuyerKey = '' OR [ProspectiveBuyer].[ProspectiveBuyerKey] = LTRIM(RTRIM(@ProspectiveBuyerKey))) " 
                + "AND   (@ProspectAlternateKey IS NULL OR @ProspectAlternateKey = '' OR [ProspectiveBuyer].[ProspectAlternateKey] = LTRIM(RTRIM(@ProspectAlternateKey))) " 
                + "AND   (@FirstName IS NULL OR @FirstName = '' OR [ProspectiveBuyer].[FirstName] = LTRIM(RTRIM(@FirstName))) " 
                + "AND   (@MiddleName IS NULL OR @MiddleName = '' OR [ProspectiveBuyer].[MiddleName] = LTRIM(RTRIM(@MiddleName))) " 
                + "AND   (@LastName IS NULL OR @LastName = '' OR [ProspectiveBuyer].[LastName] = LTRIM(RTRIM(@LastName))) " 
                + "AND   (@BirthDate IS NULL OR @BirthDate = '' OR [ProspectiveBuyer].[BirthDate] = LTRIM(RTRIM(@BirthDate))) " 
                + "AND   (@MaritalStatus IS NULL OR @MaritalStatus = '' OR [ProspectiveBuyer].[MaritalStatus] = LTRIM(RTRIM(@MaritalStatus))) " 
                + "AND   (@Gender IS NULL OR @Gender = '' OR [ProspectiveBuyer].[Gender] = LTRIM(RTRIM(@Gender))) " 
                + "AND   (@EmailAddress IS NULL OR @EmailAddress = '' OR [ProspectiveBuyer].[EmailAddress] = LTRIM(RTRIM(@EmailAddress))) " 
                + "AND   (@YearlyIncome IS NULL OR @YearlyIncome = '' OR [ProspectiveBuyer].[YearlyIncome] = LTRIM(RTRIM(@YearlyIncome))) " 
                + "AND   (@TotalChildren IS NULL OR @TotalChildren = '' OR [ProspectiveBuyer].[TotalChildren] = LTRIM(RTRIM(@TotalChildren))) " 
                + "AND   (@NumberChildrenAtHome IS NULL OR @NumberChildrenAtHome = '' OR [ProspectiveBuyer].[NumberChildrenAtHome] = LTRIM(RTRIM(@NumberChildrenAtHome))) " 
                + "AND   (@Education IS NULL OR @Education = '' OR [ProspectiveBuyer].[Education] = LTRIM(RTRIM(@Education))) " 
                + "AND   (@Occupation IS NULL OR @Occupation = '' OR [ProspectiveBuyer].[Occupation] = LTRIM(RTRIM(@Occupation))) " 
                + "AND   (@HouseOwnerFlag IS NULL OR @HouseOwnerFlag = '' OR [ProspectiveBuyer].[HouseOwnerFlag] = LTRIM(RTRIM(@HouseOwnerFlag))) " 
                + "AND   (@NumberCarsOwned IS NULL OR @NumberCarsOwned = '' OR [ProspectiveBuyer].[NumberCarsOwned] = LTRIM(RTRIM(@NumberCarsOwned))) " 
                + "AND   (@AddressLine1 IS NULL OR @AddressLine1 = '' OR [ProspectiveBuyer].[AddressLine1] = LTRIM(RTRIM(@AddressLine1))) " 
                + "AND   (@AddressLine2 IS NULL OR @AddressLine2 = '' OR [ProspectiveBuyer].[AddressLine2] = LTRIM(RTRIM(@AddressLine2))) " 
                + "AND   (@City IS NULL OR @City = '' OR [ProspectiveBuyer].[City] = LTRIM(RTRIM(@City))) " 
                + "AND   (@StateProvinceCode IS NULL OR @StateProvinceCode = '' OR [ProspectiveBuyer].[StateProvinceCode] = LTRIM(RTRIM(@StateProvinceCode))) " 
                + "AND   (@PostalCode IS NULL OR @PostalCode = '' OR [ProspectiveBuyer].[PostalCode] = LTRIM(RTRIM(@PostalCode))) " 
                + "AND   (@Phone IS NULL OR @Phone = '' OR [ProspectiveBuyer].[Phone] = LTRIM(RTRIM(@Phone))) " 
                + "AND   (@Salutation IS NULL OR @Salutation = '' OR [ProspectiveBuyer].[Salutation] = LTRIM(RTRIM(@Salutation))) " 
                + "AND   (@Unknown IS NULL OR @Unknown = '' OR [ProspectiveBuyer].[Unknown] = LTRIM(RTRIM(@Unknown))) " 
                + "";
        } else if  (sCondition == "Starts with...") {
            selectStatement
                = "SELECT "
            + "     [dbo].[ProspectiveBuyer].[ProspectiveBuyerKey] "
            + "    ,[dbo].[ProspectiveBuyer].[ProspectAlternateKey] "
            + "    ,[dbo].[ProspectiveBuyer].[FirstName] "
            + "    ,[dbo].[ProspectiveBuyer].[MiddleName] "
            + "    ,[dbo].[ProspectiveBuyer].[LastName] "
            + "    ,[dbo].[ProspectiveBuyer].[BirthDate] "
            + "    ,[dbo].[ProspectiveBuyer].[MaritalStatus] "
            + "    ,[dbo].[ProspectiveBuyer].[Gender] "
            + "    ,[dbo].[ProspectiveBuyer].[EmailAddress] "
            + "    ,[dbo].[ProspectiveBuyer].[YearlyIncome] "
            + "    ,[dbo].[ProspectiveBuyer].[TotalChildren] "
            + "    ,[dbo].[ProspectiveBuyer].[NumberChildrenAtHome] "
            + "    ,[dbo].[ProspectiveBuyer].[Education] "
            + "    ,[dbo].[ProspectiveBuyer].[Occupation] "
            + "    ,[dbo].[ProspectiveBuyer].[HouseOwnerFlag] "
            + "    ,[dbo].[ProspectiveBuyer].[NumberCarsOwned] "
            + "    ,[dbo].[ProspectiveBuyer].[AddressLine1] "
            + "    ,[dbo].[ProspectiveBuyer].[AddressLine2] "
            + "    ,[dbo].[ProspectiveBuyer].[City] "
            + "    ,[dbo].[ProspectiveBuyer].[StateProvinceCode] "
            + "    ,[dbo].[ProspectiveBuyer].[PostalCode] "
            + "    ,[dbo].[ProspectiveBuyer].[Phone] "
            + "    ,[dbo].[ProspectiveBuyer].[Salutation] "
            + "    ,[dbo].[ProspectiveBuyer].[Unknown] "
            + "FROM " 
            + "     [dbo].[ProspectiveBuyer] " 
                + "WHERE " 
                + "     (@ProspectiveBuyerKey IS NULL OR @ProspectiveBuyerKey = '' OR [ProspectiveBuyer].[ProspectiveBuyerKey] LIKE LTRIM(RTRIM(@ProspectiveBuyerKey)) + '%') " 
                + "AND   (@ProspectAlternateKey IS NULL OR @ProspectAlternateKey = '' OR [ProspectiveBuyer].[ProspectAlternateKey] LIKE LTRIM(RTRIM(@ProspectAlternateKey)) + '%') " 
                + "AND   (@FirstName IS NULL OR @FirstName = '' OR [ProspectiveBuyer].[FirstName] LIKE LTRIM(RTRIM(@FirstName)) + '%') " 
                + "AND   (@MiddleName IS NULL OR @MiddleName = '' OR [ProspectiveBuyer].[MiddleName] LIKE LTRIM(RTRIM(@MiddleName)) + '%') " 
                + "AND   (@LastName IS NULL OR @LastName = '' OR [ProspectiveBuyer].[LastName] LIKE LTRIM(RTRIM(@LastName)) + '%') " 
                + "AND   (@BirthDate IS NULL OR @BirthDate = '' OR [ProspectiveBuyer].[BirthDate] LIKE LTRIM(RTRIM(@BirthDate)) + '%') " 
                + "AND   (@MaritalStatus IS NULL OR @MaritalStatus = '' OR [ProspectiveBuyer].[MaritalStatus] LIKE LTRIM(RTRIM(@MaritalStatus)) + '%') " 
                + "AND   (@Gender IS NULL OR @Gender = '' OR [ProspectiveBuyer].[Gender] LIKE LTRIM(RTRIM(@Gender)) + '%') " 
                + "AND   (@EmailAddress IS NULL OR @EmailAddress = '' OR [ProspectiveBuyer].[EmailAddress] LIKE LTRIM(RTRIM(@EmailAddress)) + '%') " 
                + "AND   (@YearlyIncome IS NULL OR @YearlyIncome = '' OR [ProspectiveBuyer].[YearlyIncome] LIKE LTRIM(RTRIM(@YearlyIncome)) + '%') " 
                + "AND   (@TotalChildren IS NULL OR @TotalChildren = '' OR [ProspectiveBuyer].[TotalChildren] LIKE LTRIM(RTRIM(@TotalChildren)) + '%') " 
                + "AND   (@NumberChildrenAtHome IS NULL OR @NumberChildrenAtHome = '' OR [ProspectiveBuyer].[NumberChildrenAtHome] LIKE LTRIM(RTRIM(@NumberChildrenAtHome)) + '%') " 
                + "AND   (@Education IS NULL OR @Education = '' OR [ProspectiveBuyer].[Education] LIKE LTRIM(RTRIM(@Education)) + '%') " 
                + "AND   (@Occupation IS NULL OR @Occupation = '' OR [ProspectiveBuyer].[Occupation] LIKE LTRIM(RTRIM(@Occupation)) + '%') " 
                + "AND   (@HouseOwnerFlag IS NULL OR @HouseOwnerFlag = '' OR [ProspectiveBuyer].[HouseOwnerFlag] LIKE LTRIM(RTRIM(@HouseOwnerFlag)) + '%') " 
                + "AND   (@NumberCarsOwned IS NULL OR @NumberCarsOwned = '' OR [ProspectiveBuyer].[NumberCarsOwned] LIKE LTRIM(RTRIM(@NumberCarsOwned)) + '%') " 
                + "AND   (@AddressLine1 IS NULL OR @AddressLine1 = '' OR [ProspectiveBuyer].[AddressLine1] LIKE LTRIM(RTRIM(@AddressLine1)) + '%') " 
                + "AND   (@AddressLine2 IS NULL OR @AddressLine2 = '' OR [ProspectiveBuyer].[AddressLine2] LIKE LTRIM(RTRIM(@AddressLine2)) + '%') " 
                + "AND   (@City IS NULL OR @City = '' OR [ProspectiveBuyer].[City] LIKE LTRIM(RTRIM(@City)) + '%') " 
                + "AND   (@StateProvinceCode IS NULL OR @StateProvinceCode = '' OR [ProspectiveBuyer].[StateProvinceCode] LIKE LTRIM(RTRIM(@StateProvinceCode)) + '%') " 
                + "AND   (@PostalCode IS NULL OR @PostalCode = '' OR [ProspectiveBuyer].[PostalCode] LIKE LTRIM(RTRIM(@PostalCode)) + '%') " 
                + "AND   (@Phone IS NULL OR @Phone = '' OR [ProspectiveBuyer].[Phone] LIKE LTRIM(RTRIM(@Phone)) + '%') " 
                + "AND   (@Salutation IS NULL OR @Salutation = '' OR [ProspectiveBuyer].[Salutation] LIKE LTRIM(RTRIM(@Salutation)) + '%') " 
                + "AND   (@Unknown IS NULL OR @Unknown = '' OR [ProspectiveBuyer].[Unknown] LIKE LTRIM(RTRIM(@Unknown)) + '%') " 
                + "";
        } else if  (sCondition == "More than...") {
            selectStatement
                = "SELECT "
            + "     [dbo].[ProspectiveBuyer].[ProspectiveBuyerKey] "
            + "    ,[dbo].[ProspectiveBuyer].[ProspectAlternateKey] "
            + "    ,[dbo].[ProspectiveBuyer].[FirstName] "
            + "    ,[dbo].[ProspectiveBuyer].[MiddleName] "
            + "    ,[dbo].[ProspectiveBuyer].[LastName] "
            + "    ,[dbo].[ProspectiveBuyer].[BirthDate] "
            + "    ,[dbo].[ProspectiveBuyer].[MaritalStatus] "
            + "    ,[dbo].[ProspectiveBuyer].[Gender] "
            + "    ,[dbo].[ProspectiveBuyer].[EmailAddress] "
            + "    ,[dbo].[ProspectiveBuyer].[YearlyIncome] "
            + "    ,[dbo].[ProspectiveBuyer].[TotalChildren] "
            + "    ,[dbo].[ProspectiveBuyer].[NumberChildrenAtHome] "
            + "    ,[dbo].[ProspectiveBuyer].[Education] "
            + "    ,[dbo].[ProspectiveBuyer].[Occupation] "
            + "    ,[dbo].[ProspectiveBuyer].[HouseOwnerFlag] "
            + "    ,[dbo].[ProspectiveBuyer].[NumberCarsOwned] "
            + "    ,[dbo].[ProspectiveBuyer].[AddressLine1] "
            + "    ,[dbo].[ProspectiveBuyer].[AddressLine2] "
            + "    ,[dbo].[ProspectiveBuyer].[City] "
            + "    ,[dbo].[ProspectiveBuyer].[StateProvinceCode] "
            + "    ,[dbo].[ProspectiveBuyer].[PostalCode] "
            + "    ,[dbo].[ProspectiveBuyer].[Phone] "
            + "    ,[dbo].[ProspectiveBuyer].[Salutation] "
            + "    ,[dbo].[ProspectiveBuyer].[Unknown] "
            + "FROM " 
            + "     [dbo].[ProspectiveBuyer] " 
                + "WHERE " 
                + "     (@ProspectiveBuyerKey IS NULL OR @ProspectiveBuyerKey = '' OR [ProspectiveBuyer].[ProspectiveBuyerKey] > LTRIM(RTRIM(@ProspectiveBuyerKey))) " 
                + "AND   (@ProspectAlternateKey IS NULL OR @ProspectAlternateKey = '' OR [ProspectiveBuyer].[ProspectAlternateKey] > LTRIM(RTRIM(@ProspectAlternateKey))) " 
                + "AND   (@FirstName IS NULL OR @FirstName = '' OR [ProspectiveBuyer].[FirstName] > LTRIM(RTRIM(@FirstName))) " 
                + "AND   (@MiddleName IS NULL OR @MiddleName = '' OR [ProspectiveBuyer].[MiddleName] > LTRIM(RTRIM(@MiddleName))) " 
                + "AND   (@LastName IS NULL OR @LastName = '' OR [ProspectiveBuyer].[LastName] > LTRIM(RTRIM(@LastName))) " 
                + "AND   (@BirthDate IS NULL OR @BirthDate = '' OR [ProspectiveBuyer].[BirthDate] > LTRIM(RTRIM(@BirthDate))) " 
                + "AND   (@MaritalStatus IS NULL OR @MaritalStatus = '' OR [ProspectiveBuyer].[MaritalStatus] > LTRIM(RTRIM(@MaritalStatus))) " 
                + "AND   (@Gender IS NULL OR @Gender = '' OR [ProspectiveBuyer].[Gender] > LTRIM(RTRIM(@Gender))) " 
                + "AND   (@EmailAddress IS NULL OR @EmailAddress = '' OR [ProspectiveBuyer].[EmailAddress] > LTRIM(RTRIM(@EmailAddress))) " 
                + "AND   (@YearlyIncome IS NULL OR @YearlyIncome = '' OR [ProspectiveBuyer].[YearlyIncome] > LTRIM(RTRIM(@YearlyIncome))) " 
                + "AND   (@TotalChildren IS NULL OR @TotalChildren = '' OR [ProspectiveBuyer].[TotalChildren] > LTRIM(RTRIM(@TotalChildren))) " 
                + "AND   (@NumberChildrenAtHome IS NULL OR @NumberChildrenAtHome = '' OR [ProspectiveBuyer].[NumberChildrenAtHome] > LTRIM(RTRIM(@NumberChildrenAtHome))) " 
                + "AND   (@Education IS NULL OR @Education = '' OR [ProspectiveBuyer].[Education] > LTRIM(RTRIM(@Education))) " 
                + "AND   (@Occupation IS NULL OR @Occupation = '' OR [ProspectiveBuyer].[Occupation] > LTRIM(RTRIM(@Occupation))) " 
                + "AND   (@HouseOwnerFlag IS NULL OR @HouseOwnerFlag = '' OR [ProspectiveBuyer].[HouseOwnerFlag] > LTRIM(RTRIM(@HouseOwnerFlag))) " 
                + "AND   (@NumberCarsOwned IS NULL OR @NumberCarsOwned = '' OR [ProspectiveBuyer].[NumberCarsOwned] > LTRIM(RTRIM(@NumberCarsOwned))) " 
                + "AND   (@AddressLine1 IS NULL OR @AddressLine1 = '' OR [ProspectiveBuyer].[AddressLine1] > LTRIM(RTRIM(@AddressLine1))) " 
                + "AND   (@AddressLine2 IS NULL OR @AddressLine2 = '' OR [ProspectiveBuyer].[AddressLine2] > LTRIM(RTRIM(@AddressLine2))) " 
                + "AND   (@City IS NULL OR @City = '' OR [ProspectiveBuyer].[City] > LTRIM(RTRIM(@City))) " 
                + "AND   (@StateProvinceCode IS NULL OR @StateProvinceCode = '' OR [ProspectiveBuyer].[StateProvinceCode] > LTRIM(RTRIM(@StateProvinceCode))) " 
                + "AND   (@PostalCode IS NULL OR @PostalCode = '' OR [ProspectiveBuyer].[PostalCode] > LTRIM(RTRIM(@PostalCode))) " 
                + "AND   (@Phone IS NULL OR @Phone = '' OR [ProspectiveBuyer].[Phone] > LTRIM(RTRIM(@Phone))) " 
                + "AND   (@Salutation IS NULL OR @Salutation = '' OR [ProspectiveBuyer].[Salutation] > LTRIM(RTRIM(@Salutation))) " 
                + "AND   (@Unknown IS NULL OR @Unknown = '' OR [ProspectiveBuyer].[Unknown] > LTRIM(RTRIM(@Unknown))) " 
                + "";
        } else if  (sCondition == "Less than...") {
            selectStatement
                = "SELECT " 
            + "     [dbo].[ProspectiveBuyer].[ProspectiveBuyerKey] "
            + "    ,[dbo].[ProspectiveBuyer].[ProspectAlternateKey] "
            + "    ,[dbo].[ProspectiveBuyer].[FirstName] "
            + "    ,[dbo].[ProspectiveBuyer].[MiddleName] "
            + "    ,[dbo].[ProspectiveBuyer].[LastName] "
            + "    ,[dbo].[ProspectiveBuyer].[BirthDate] "
            + "    ,[dbo].[ProspectiveBuyer].[MaritalStatus] "
            + "    ,[dbo].[ProspectiveBuyer].[Gender] "
            + "    ,[dbo].[ProspectiveBuyer].[EmailAddress] "
            + "    ,[dbo].[ProspectiveBuyer].[YearlyIncome] "
            + "    ,[dbo].[ProspectiveBuyer].[TotalChildren] "
            + "    ,[dbo].[ProspectiveBuyer].[NumberChildrenAtHome] "
            + "    ,[dbo].[ProspectiveBuyer].[Education] "
            + "    ,[dbo].[ProspectiveBuyer].[Occupation] "
            + "    ,[dbo].[ProspectiveBuyer].[HouseOwnerFlag] "
            + "    ,[dbo].[ProspectiveBuyer].[NumberCarsOwned] "
            + "    ,[dbo].[ProspectiveBuyer].[AddressLine1] "
            + "    ,[dbo].[ProspectiveBuyer].[AddressLine2] "
            + "    ,[dbo].[ProspectiveBuyer].[City] "
            + "    ,[dbo].[ProspectiveBuyer].[StateProvinceCode] "
            + "    ,[dbo].[ProspectiveBuyer].[PostalCode] "
            + "    ,[dbo].[ProspectiveBuyer].[Phone] "
            + "    ,[dbo].[ProspectiveBuyer].[Salutation] "
            + "    ,[dbo].[ProspectiveBuyer].[Unknown] "
            + "FROM " 
            + "     [dbo].[ProspectiveBuyer] " 
                + "WHERE " 
                + "     (@ProspectiveBuyerKey IS NULL OR @ProspectiveBuyerKey = '' OR [ProspectiveBuyer].[ProspectiveBuyerKey] < LTRIM(RTRIM(@ProspectiveBuyerKey))) " 
                + "AND   (@ProspectAlternateKey IS NULL OR @ProspectAlternateKey = '' OR [ProspectiveBuyer].[ProspectAlternateKey] < LTRIM(RTRIM(@ProspectAlternateKey))) " 
                + "AND   (@FirstName IS NULL OR @FirstName = '' OR [ProspectiveBuyer].[FirstName] < LTRIM(RTRIM(@FirstName))) " 
                + "AND   (@MiddleName IS NULL OR @MiddleName = '' OR [ProspectiveBuyer].[MiddleName] < LTRIM(RTRIM(@MiddleName))) " 
                + "AND   (@LastName IS NULL OR @LastName = '' OR [ProspectiveBuyer].[LastName] < LTRIM(RTRIM(@LastName))) " 
                + "AND   (@BirthDate IS NULL OR @BirthDate = '' OR [ProspectiveBuyer].[BirthDate] < LTRIM(RTRIM(@BirthDate))) " 
                + "AND   (@MaritalStatus IS NULL OR @MaritalStatus = '' OR [ProspectiveBuyer].[MaritalStatus] < LTRIM(RTRIM(@MaritalStatus))) " 
                + "AND   (@Gender IS NULL OR @Gender = '' OR [ProspectiveBuyer].[Gender] < LTRIM(RTRIM(@Gender))) " 
                + "AND   (@EmailAddress IS NULL OR @EmailAddress = '' OR [ProspectiveBuyer].[EmailAddress] < LTRIM(RTRIM(@EmailAddress))) " 
                + "AND   (@YearlyIncome IS NULL OR @YearlyIncome = '' OR [ProspectiveBuyer].[YearlyIncome] < LTRIM(RTRIM(@YearlyIncome))) " 
                + "AND   (@TotalChildren IS NULL OR @TotalChildren = '' OR [ProspectiveBuyer].[TotalChildren] < LTRIM(RTRIM(@TotalChildren))) " 
                + "AND   (@NumberChildrenAtHome IS NULL OR @NumberChildrenAtHome = '' OR [ProspectiveBuyer].[NumberChildrenAtHome] < LTRIM(RTRIM(@NumberChildrenAtHome))) " 
                + "AND   (@Education IS NULL OR @Education = '' OR [ProspectiveBuyer].[Education] < LTRIM(RTRIM(@Education))) " 
                + "AND   (@Occupation IS NULL OR @Occupation = '' OR [ProspectiveBuyer].[Occupation] < LTRIM(RTRIM(@Occupation))) " 
                + "AND   (@HouseOwnerFlag IS NULL OR @HouseOwnerFlag = '' OR [ProspectiveBuyer].[HouseOwnerFlag] < LTRIM(RTRIM(@HouseOwnerFlag))) " 
                + "AND   (@NumberCarsOwned IS NULL OR @NumberCarsOwned = '' OR [ProspectiveBuyer].[NumberCarsOwned] < LTRIM(RTRIM(@NumberCarsOwned))) " 
                + "AND   (@AddressLine1 IS NULL OR @AddressLine1 = '' OR [ProspectiveBuyer].[AddressLine1] < LTRIM(RTRIM(@AddressLine1))) " 
                + "AND   (@AddressLine2 IS NULL OR @AddressLine2 = '' OR [ProspectiveBuyer].[AddressLine2] < LTRIM(RTRIM(@AddressLine2))) " 
                + "AND   (@City IS NULL OR @City = '' OR [ProspectiveBuyer].[City] < LTRIM(RTRIM(@City))) " 
                + "AND   (@StateProvinceCode IS NULL OR @StateProvinceCode = '' OR [ProspectiveBuyer].[StateProvinceCode] < LTRIM(RTRIM(@StateProvinceCode))) " 
                + "AND   (@PostalCode IS NULL OR @PostalCode = '' OR [ProspectiveBuyer].[PostalCode] < LTRIM(RTRIM(@PostalCode))) " 
                + "AND   (@Phone IS NULL OR @Phone = '' OR [ProspectiveBuyer].[Phone] < LTRIM(RTRIM(@Phone))) " 
                + "AND   (@Salutation IS NULL OR @Salutation = '' OR [ProspectiveBuyer].[Salutation] < LTRIM(RTRIM(@Salutation))) " 
                + "AND   (@Unknown IS NULL OR @Unknown = '' OR [ProspectiveBuyer].[Unknown] < LTRIM(RTRIM(@Unknown))) " 
                + "";
        } else if  (sCondition == "Equal or more than...") {
            selectStatement
                = "SELECT "
            + "     [dbo].[ProspectiveBuyer].[ProspectiveBuyerKey] "
            + "    ,[dbo].[ProspectiveBuyer].[ProspectAlternateKey] "
            + "    ,[dbo].[ProspectiveBuyer].[FirstName] "
            + "    ,[dbo].[ProspectiveBuyer].[MiddleName] "
            + "    ,[dbo].[ProspectiveBuyer].[LastName] "
            + "    ,[dbo].[ProspectiveBuyer].[BirthDate] "
            + "    ,[dbo].[ProspectiveBuyer].[MaritalStatus] "
            + "    ,[dbo].[ProspectiveBuyer].[Gender] "
            + "    ,[dbo].[ProspectiveBuyer].[EmailAddress] "
            + "    ,[dbo].[ProspectiveBuyer].[YearlyIncome] "
            + "    ,[dbo].[ProspectiveBuyer].[TotalChildren] "
            + "    ,[dbo].[ProspectiveBuyer].[NumberChildrenAtHome] "
            + "    ,[dbo].[ProspectiveBuyer].[Education] "
            + "    ,[dbo].[ProspectiveBuyer].[Occupation] "
            + "    ,[dbo].[ProspectiveBuyer].[HouseOwnerFlag] "
            + "    ,[dbo].[ProspectiveBuyer].[NumberCarsOwned] "
            + "    ,[dbo].[ProspectiveBuyer].[AddressLine1] "
            + "    ,[dbo].[ProspectiveBuyer].[AddressLine2] "
            + "    ,[dbo].[ProspectiveBuyer].[City] "
            + "    ,[dbo].[ProspectiveBuyer].[StateProvinceCode] "
            + "    ,[dbo].[ProspectiveBuyer].[PostalCode] "
            + "    ,[dbo].[ProspectiveBuyer].[Phone] "
            + "    ,[dbo].[ProspectiveBuyer].[Salutation] "
            + "    ,[dbo].[ProspectiveBuyer].[Unknown] "
            + "FROM " 
            + "     [dbo].[ProspectiveBuyer] " 
                + "WHERE " 
                + "     (@ProspectiveBuyerKey IS NULL OR @ProspectiveBuyerKey = '' OR [ProspectiveBuyer].[ProspectiveBuyerKey] >= LTRIM(RTRIM(@ProspectiveBuyerKey))) " 
                + "AND   (@ProspectAlternateKey IS NULL OR @ProspectAlternateKey = '' OR [ProspectiveBuyer].[ProspectAlternateKey] >= LTRIM(RTRIM(@ProspectAlternateKey))) " 
                + "AND   (@FirstName IS NULL OR @FirstName = '' OR [ProspectiveBuyer].[FirstName] >= LTRIM(RTRIM(@FirstName))) " 
                + "AND   (@MiddleName IS NULL OR @MiddleName = '' OR [ProspectiveBuyer].[MiddleName] >= LTRIM(RTRIM(@MiddleName))) " 
                + "AND   (@LastName IS NULL OR @LastName = '' OR [ProspectiveBuyer].[LastName] >= LTRIM(RTRIM(@LastName))) " 
                + "AND   (@BirthDate IS NULL OR @BirthDate = '' OR [ProspectiveBuyer].[BirthDate] >= LTRIM(RTRIM(@BirthDate))) " 
                + "AND   (@MaritalStatus IS NULL OR @MaritalStatus = '' OR [ProspectiveBuyer].[MaritalStatus] >= LTRIM(RTRIM(@MaritalStatus))) " 
                + "AND   (@Gender IS NULL OR @Gender = '' OR [ProspectiveBuyer].[Gender] >= LTRIM(RTRIM(@Gender))) " 
                + "AND   (@EmailAddress IS NULL OR @EmailAddress = '' OR [ProspectiveBuyer].[EmailAddress] >= LTRIM(RTRIM(@EmailAddress))) " 
                + "AND   (@YearlyIncome IS NULL OR @YearlyIncome = '' OR [ProspectiveBuyer].[YearlyIncome] >= LTRIM(RTRIM(@YearlyIncome))) " 
                + "AND   (@TotalChildren IS NULL OR @TotalChildren = '' OR [ProspectiveBuyer].[TotalChildren] >= LTRIM(RTRIM(@TotalChildren))) " 
                + "AND   (@NumberChildrenAtHome IS NULL OR @NumberChildrenAtHome = '' OR [ProspectiveBuyer].[NumberChildrenAtHome] >= LTRIM(RTRIM(@NumberChildrenAtHome))) " 
                + "AND   (@Education IS NULL OR @Education = '' OR [ProspectiveBuyer].[Education] >= LTRIM(RTRIM(@Education))) " 
                + "AND   (@Occupation IS NULL OR @Occupation = '' OR [ProspectiveBuyer].[Occupation] >= LTRIM(RTRIM(@Occupation))) " 
                + "AND   (@HouseOwnerFlag IS NULL OR @HouseOwnerFlag = '' OR [ProspectiveBuyer].[HouseOwnerFlag] >= LTRIM(RTRIM(@HouseOwnerFlag))) " 
                + "AND   (@NumberCarsOwned IS NULL OR @NumberCarsOwned = '' OR [ProspectiveBuyer].[NumberCarsOwned] >= LTRIM(RTRIM(@NumberCarsOwned))) " 
                + "AND   (@AddressLine1 IS NULL OR @AddressLine1 = '' OR [ProspectiveBuyer].[AddressLine1] >= LTRIM(RTRIM(@AddressLine1))) " 
                + "AND   (@AddressLine2 IS NULL OR @AddressLine2 = '' OR [ProspectiveBuyer].[AddressLine2] >= LTRIM(RTRIM(@AddressLine2))) " 
                + "AND   (@City IS NULL OR @City = '' OR [ProspectiveBuyer].[City] >= LTRIM(RTRIM(@City))) " 
                + "AND   (@StateProvinceCode IS NULL OR @StateProvinceCode = '' OR [ProspectiveBuyer].[StateProvinceCode] >= LTRIM(RTRIM(@StateProvinceCode))) " 
                + "AND   (@PostalCode IS NULL OR @PostalCode = '' OR [ProspectiveBuyer].[PostalCode] >= LTRIM(RTRIM(@PostalCode))) " 
                + "AND   (@Phone IS NULL OR @Phone = '' OR [ProspectiveBuyer].[Phone] >= LTRIM(RTRIM(@Phone))) " 
                + "AND   (@Salutation IS NULL OR @Salutation = '' OR [ProspectiveBuyer].[Salutation] >= LTRIM(RTRIM(@Salutation))) " 
                + "AND   (@Unknown IS NULL OR @Unknown = '' OR [ProspectiveBuyer].[Unknown] >= LTRIM(RTRIM(@Unknown))) " 
                + "";
        } else if (sCondition == "Equal or less than...") {
            selectStatement 
                = "SELECT "
            + "     [dbo].[ProspectiveBuyer].[ProspectiveBuyerKey] "
            + "    ,[dbo].[ProspectiveBuyer].[ProspectAlternateKey] "
            + "    ,[dbo].[ProspectiveBuyer].[FirstName] "
            + "    ,[dbo].[ProspectiveBuyer].[MiddleName] "
            + "    ,[dbo].[ProspectiveBuyer].[LastName] "
            + "    ,[dbo].[ProspectiveBuyer].[BirthDate] "
            + "    ,[dbo].[ProspectiveBuyer].[MaritalStatus] "
            + "    ,[dbo].[ProspectiveBuyer].[Gender] "
            + "    ,[dbo].[ProspectiveBuyer].[EmailAddress] "
            + "    ,[dbo].[ProspectiveBuyer].[YearlyIncome] "
            + "    ,[dbo].[ProspectiveBuyer].[TotalChildren] "
            + "    ,[dbo].[ProspectiveBuyer].[NumberChildrenAtHome] "
            + "    ,[dbo].[ProspectiveBuyer].[Education] "
            + "    ,[dbo].[ProspectiveBuyer].[Occupation] "
            + "    ,[dbo].[ProspectiveBuyer].[HouseOwnerFlag] "
            + "    ,[dbo].[ProspectiveBuyer].[NumberCarsOwned] "
            + "    ,[dbo].[ProspectiveBuyer].[AddressLine1] "
            + "    ,[dbo].[ProspectiveBuyer].[AddressLine2] "
            + "    ,[dbo].[ProspectiveBuyer].[City] "
            + "    ,[dbo].[ProspectiveBuyer].[StateProvinceCode] "
            + "    ,[dbo].[ProspectiveBuyer].[PostalCode] "
            + "    ,[dbo].[ProspectiveBuyer].[Phone] "
            + "    ,[dbo].[ProspectiveBuyer].[Salutation] "
            + "    ,[dbo].[ProspectiveBuyer].[Unknown] "
            + "FROM " 
            + "     [dbo].[ProspectiveBuyer] " 
                + "WHERE " 
                + "     (@ProspectiveBuyerKey IS NULL OR @ProspectiveBuyerKey = '' OR [ProspectiveBuyer].[ProspectiveBuyerKey] <= LTRIM(RTRIM(@ProspectiveBuyerKey))) " 
                + "AND   (@ProspectAlternateKey IS NULL OR @ProspectAlternateKey = '' OR [ProspectiveBuyer].[ProspectAlternateKey] <= LTRIM(RTRIM(@ProspectAlternateKey))) " 
                + "AND   (@FirstName IS NULL OR @FirstName = '' OR [ProspectiveBuyer].[FirstName] <= LTRIM(RTRIM(@FirstName))) " 
                + "AND   (@MiddleName IS NULL OR @MiddleName = '' OR [ProspectiveBuyer].[MiddleName] <= LTRIM(RTRIM(@MiddleName))) " 
                + "AND   (@LastName IS NULL OR @LastName = '' OR [ProspectiveBuyer].[LastName] <= LTRIM(RTRIM(@LastName))) " 
                + "AND   (@BirthDate IS NULL OR @BirthDate = '' OR [ProspectiveBuyer].[BirthDate] <= LTRIM(RTRIM(@BirthDate))) " 
                + "AND   (@MaritalStatus IS NULL OR @MaritalStatus = '' OR [ProspectiveBuyer].[MaritalStatus] <= LTRIM(RTRIM(@MaritalStatus))) " 
                + "AND   (@Gender IS NULL OR @Gender = '' OR [ProspectiveBuyer].[Gender] <= LTRIM(RTRIM(@Gender))) " 
                + "AND   (@EmailAddress IS NULL OR @EmailAddress = '' OR [ProspectiveBuyer].[EmailAddress] <= LTRIM(RTRIM(@EmailAddress))) " 
                + "AND   (@YearlyIncome IS NULL OR @YearlyIncome = '' OR [ProspectiveBuyer].[YearlyIncome] <= LTRIM(RTRIM(@YearlyIncome))) " 
                + "AND   (@TotalChildren IS NULL OR @TotalChildren = '' OR [ProspectiveBuyer].[TotalChildren] <= LTRIM(RTRIM(@TotalChildren))) " 
                + "AND   (@NumberChildrenAtHome IS NULL OR @NumberChildrenAtHome = '' OR [ProspectiveBuyer].[NumberChildrenAtHome] <= LTRIM(RTRIM(@NumberChildrenAtHome))) " 
                + "AND   (@Education IS NULL OR @Education = '' OR [ProspectiveBuyer].[Education] <= LTRIM(RTRIM(@Education))) " 
                + "AND   (@Occupation IS NULL OR @Occupation = '' OR [ProspectiveBuyer].[Occupation] <= LTRIM(RTRIM(@Occupation))) " 
                + "AND   (@HouseOwnerFlag IS NULL OR @HouseOwnerFlag = '' OR [ProspectiveBuyer].[HouseOwnerFlag] <= LTRIM(RTRIM(@HouseOwnerFlag))) " 
                + "AND   (@NumberCarsOwned IS NULL OR @NumberCarsOwned = '' OR [ProspectiveBuyer].[NumberCarsOwned] <= LTRIM(RTRIM(@NumberCarsOwned))) " 
                + "AND   (@AddressLine1 IS NULL OR @AddressLine1 = '' OR [ProspectiveBuyer].[AddressLine1] <= LTRIM(RTRIM(@AddressLine1))) " 
                + "AND   (@AddressLine2 IS NULL OR @AddressLine2 = '' OR [ProspectiveBuyer].[AddressLine2] <= LTRIM(RTRIM(@AddressLine2))) " 
                + "AND   (@City IS NULL OR @City = '' OR [ProspectiveBuyer].[City] <= LTRIM(RTRIM(@City))) " 
                + "AND   (@StateProvinceCode IS NULL OR @StateProvinceCode = '' OR [ProspectiveBuyer].[StateProvinceCode] <= LTRIM(RTRIM(@StateProvinceCode))) " 
                + "AND   (@PostalCode IS NULL OR @PostalCode = '' OR [ProspectiveBuyer].[PostalCode] <= LTRIM(RTRIM(@PostalCode))) " 
                + "AND   (@Phone IS NULL OR @Phone = '' OR [ProspectiveBuyer].[Phone] <= LTRIM(RTRIM(@Phone))) " 
                + "AND   (@Salutation IS NULL OR @Salutation = '' OR [ProspectiveBuyer].[Salutation] <= LTRIM(RTRIM(@Salutation))) " 
                + "AND   (@Unknown IS NULL OR @Unknown = '' OR [ProspectiveBuyer].[Unknown] <= LTRIM(RTRIM(@Unknown))) " 
                + "";
        }
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        selectCommand.CommandType = CommandType.Text;
        if (sField == "Prospective Buyer Key") {
            selectCommand.Parameters.AddWithValue("@ProspectiveBuyerKey", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@ProspectiveBuyerKey", DBNull.Value); }
        if (sField == "Prospect Alternate Key") {
            selectCommand.Parameters.AddWithValue("@ProspectAlternateKey", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@ProspectAlternateKey", DBNull.Value); }
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
        if (sField == "Birth Date") {
            selectCommand.Parameters.AddWithValue("@BirthDate", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@BirthDate", DBNull.Value); }
        if (sField == "Marital Status") {
            selectCommand.Parameters.AddWithValue("@MaritalStatus", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@MaritalStatus", DBNull.Value); }
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
        if (sField == "Education") {
            selectCommand.Parameters.AddWithValue("@Education", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@Education", DBNull.Value); }
        if (sField == "Occupation") {
            selectCommand.Parameters.AddWithValue("@Occupation", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@Occupation", DBNull.Value); }
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
        if (sField == "City") {
            selectCommand.Parameters.AddWithValue("@City", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@City", DBNull.Value); }
        if (sField == "State Province Code") {
            selectCommand.Parameters.AddWithValue("@StateProvinceCode", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@StateProvinceCode", DBNull.Value); }
        if (sField == "Postal Code") {
            selectCommand.Parameters.AddWithValue("@PostalCode", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@PostalCode", DBNull.Value); }
        if (sField == "Phone") {
            selectCommand.Parameters.AddWithValue("@Phone", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@Phone", DBNull.Value); }
        if (sField == "Salutation") {
            selectCommand.Parameters.AddWithValue("@Salutation", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@Salutation", DBNull.Value); }
        if (sField == "Unknown") {
            selectCommand.Parameters.AddWithValue("@Unknown", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@Unknown", DBNull.Value); }
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

    public static dbo_ProspectiveBuyerClass Select_Record(dbo_ProspectiveBuyerClass clsdbo_ProspectiveBuyerPara)
    {
        dbo_ProspectiveBuyerClass clsdbo_ProspectiveBuyer = new dbo_ProspectiveBuyerClass();
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement
            = "SELECT " 
            + "     [ProspectiveBuyerKey] "
            + "    ,[ProspectAlternateKey] "
            + "    ,[FirstName] "
            + "    ,[MiddleName] "
            + "    ,[LastName] "
            + "    ,[BirthDate] "
            + "    ,[MaritalStatus] "
            + "    ,[Gender] "
            + "    ,[EmailAddress] "
            + "    ,[YearlyIncome] "
            + "    ,[TotalChildren] "
            + "    ,[NumberChildrenAtHome] "
            + "    ,[Education] "
            + "    ,[Occupation] "
            + "    ,[HouseOwnerFlag] "
            + "    ,[NumberCarsOwned] "
            + "    ,[AddressLine1] "
            + "    ,[AddressLine2] "
            + "    ,[City] "
            + "    ,[StateProvinceCode] "
            + "    ,[PostalCode] "
            + "    ,[Phone] "
            + "    ,[Salutation] "
            + "    ,[Unknown] "
            + "FROM "
            + "     [dbo].[ProspectiveBuyer] "
            + "WHERE "
            + "     [ProspectiveBuyerKey] = @ProspectiveBuyerKey "
            + "";
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        selectCommand.CommandType = CommandType.Text;
        selectCommand.Parameters.AddWithValue("@ProspectiveBuyerKey", clsdbo_ProspectiveBuyerPara.ProspectiveBuyerKey);
        try
        {
            connection.Open();
            SqlDataReader reader
                = selectCommand.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                clsdbo_ProspectiveBuyer.ProspectiveBuyerKey = System.Convert.ToInt32(reader["ProspectiveBuyerKey"]);
                clsdbo_ProspectiveBuyer.ProspectAlternateKey = reader["ProspectAlternateKey"] is DBNull ? null : reader["ProspectAlternateKey"].ToString();
                clsdbo_ProspectiveBuyer.FirstName = reader["FirstName"] is DBNull ? null : reader["FirstName"].ToString();
                clsdbo_ProspectiveBuyer.MiddleName = reader["MiddleName"] is DBNull ? null : reader["MiddleName"].ToString();
                clsdbo_ProspectiveBuyer.LastName = reader["LastName"] is DBNull ? null : reader["LastName"].ToString();
                clsdbo_ProspectiveBuyer.BirthDate = reader["BirthDate"] is DBNull ? null : (DateTime?)reader["BirthDate"];
                clsdbo_ProspectiveBuyer.MaritalStatus = reader["MaritalStatus"] is DBNull ? null : reader["MaritalStatus"].ToString();
                clsdbo_ProspectiveBuyer.Gender = reader["Gender"] is DBNull ? null : reader["Gender"].ToString();
                clsdbo_ProspectiveBuyer.EmailAddress = reader["EmailAddress"] is DBNull ? null : reader["EmailAddress"].ToString();
                clsdbo_ProspectiveBuyer.YearlyIncome = reader["YearlyIncome"] is DBNull ? null : (Decimal?)reader["YearlyIncome"];
                clsdbo_ProspectiveBuyer.TotalChildren = reader["TotalChildren"] is DBNull ? null : (Byte?)reader["TotalChildren"];
                clsdbo_ProspectiveBuyer.NumberChildrenAtHome = reader["NumberChildrenAtHome"] is DBNull ? null : (Byte?)reader["NumberChildrenAtHome"];
                clsdbo_ProspectiveBuyer.Education = reader["Education"] is DBNull ? null : reader["Education"].ToString();
                clsdbo_ProspectiveBuyer.Occupation = reader["Occupation"] is DBNull ? null : reader["Occupation"].ToString();
                clsdbo_ProspectiveBuyer.HouseOwnerFlag = reader["HouseOwnerFlag"] is DBNull ? null : reader["HouseOwnerFlag"].ToString();
                clsdbo_ProspectiveBuyer.NumberCarsOwned = reader["NumberCarsOwned"] is DBNull ? null : (Byte?)reader["NumberCarsOwned"];
                clsdbo_ProspectiveBuyer.AddressLine1 = reader["AddressLine1"] is DBNull ? null : reader["AddressLine1"].ToString();
                clsdbo_ProspectiveBuyer.AddressLine2 = reader["AddressLine2"] is DBNull ? null : reader["AddressLine2"].ToString();
                clsdbo_ProspectiveBuyer.City = reader["City"] is DBNull ? null : reader["City"].ToString();
                clsdbo_ProspectiveBuyer.StateProvinceCode = reader["StateProvinceCode"] is DBNull ? null : reader["StateProvinceCode"].ToString();
                clsdbo_ProspectiveBuyer.PostalCode = reader["PostalCode"] is DBNull ? null : reader["PostalCode"].ToString();
                clsdbo_ProspectiveBuyer.Phone = reader["Phone"] is DBNull ? null : reader["Phone"].ToString();
                clsdbo_ProspectiveBuyer.Salutation = reader["Salutation"] is DBNull ? null : reader["Salutation"].ToString();
                clsdbo_ProspectiveBuyer.Unknown = reader["Unknown"] is DBNull ? null : (Int32?)reader["Unknown"];
            }
            else
            {
                clsdbo_ProspectiveBuyer = null;
            }
            reader.Close();
        }
        catch (SqlException)
        {
            return clsdbo_ProspectiveBuyer;
        }
        finally
        {
            connection.Close();
        }
        return clsdbo_ProspectiveBuyer;
    }

    public static bool Add(dbo_ProspectiveBuyerClass clsdbo_ProspectiveBuyer)
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string insertStatement
            = "INSERT " 
            + "     [dbo].[ProspectiveBuyer] "
            + "     ( "
            + "     [ProspectAlternateKey] "
            + "    ,[FirstName] "
            + "    ,[MiddleName] "
            + "    ,[LastName] "
            + "    ,[BirthDate] "
            + "    ,[MaritalStatus] "
            + "    ,[Gender] "
            + "    ,[EmailAddress] "
            + "    ,[YearlyIncome] "
            + "    ,[TotalChildren] "
            + "    ,[NumberChildrenAtHome] "
            + "    ,[Education] "
            + "    ,[Occupation] "
            + "    ,[HouseOwnerFlag] "
            + "    ,[NumberCarsOwned] "
            + "    ,[AddressLine1] "
            + "    ,[AddressLine2] "
            + "    ,[City] "
            + "    ,[StateProvinceCode] "
            + "    ,[PostalCode] "
            + "    ,[Phone] "
            + "    ,[Salutation] "
            + "    ,[Unknown] "
            + "     ) "
            + "VALUES " 
            + "     ( "
            + "     @ProspectAlternateKey "
            + "    ,@FirstName "
            + "    ,@MiddleName "
            + "    ,@LastName "
            + "    ,@BirthDate "
            + "    ,@MaritalStatus "
            + "    ,@Gender "
            + "    ,@EmailAddress "
            + "    ,@YearlyIncome "
            + "    ,@TotalChildren "
            + "    ,@NumberChildrenAtHome "
            + "    ,@Education "
            + "    ,@Occupation "
            + "    ,@HouseOwnerFlag "
            + "    ,@NumberCarsOwned "
            + "    ,@AddressLine1 "
            + "    ,@AddressLine2 "
            + "    ,@City "
            + "    ,@StateProvinceCode "
            + "    ,@PostalCode "
            + "    ,@Phone "
            + "    ,@Salutation "
            + "    ,@Unknown "
            + "     ) "
            + "";
        SqlCommand insertCommand = new SqlCommand(insertStatement, connection);
        insertCommand.CommandType = CommandType.Text;
        if (clsdbo_ProspectiveBuyer.ProspectAlternateKey != null) {
            insertCommand.Parameters.AddWithValue("@ProspectAlternateKey", clsdbo_ProspectiveBuyer.ProspectAlternateKey);
        } else {
            insertCommand.Parameters.AddWithValue("@ProspectAlternateKey", DBNull.Value); }
        if (clsdbo_ProspectiveBuyer.FirstName != null) {
            insertCommand.Parameters.AddWithValue("@FirstName", clsdbo_ProspectiveBuyer.FirstName);
        } else {
            insertCommand.Parameters.AddWithValue("@FirstName", DBNull.Value); }
        if (clsdbo_ProspectiveBuyer.MiddleName != null) {
            insertCommand.Parameters.AddWithValue("@MiddleName", clsdbo_ProspectiveBuyer.MiddleName);
        } else {
            insertCommand.Parameters.AddWithValue("@MiddleName", DBNull.Value); }
        if (clsdbo_ProspectiveBuyer.LastName != null) {
            insertCommand.Parameters.AddWithValue("@LastName", clsdbo_ProspectiveBuyer.LastName);
        } else {
            insertCommand.Parameters.AddWithValue("@LastName", DBNull.Value); }
        if (clsdbo_ProspectiveBuyer.BirthDate.HasValue == true) {
            insertCommand.Parameters.AddWithValue("@BirthDate", clsdbo_ProspectiveBuyer.BirthDate);
        } else {
            insertCommand.Parameters.AddWithValue("@BirthDate", DBNull.Value); }
        if (clsdbo_ProspectiveBuyer.MaritalStatus != null) {
            insertCommand.Parameters.AddWithValue("@MaritalStatus", clsdbo_ProspectiveBuyer.MaritalStatus);
        } else {
            insertCommand.Parameters.AddWithValue("@MaritalStatus", DBNull.Value); }
        if (clsdbo_ProspectiveBuyer.Gender != null) {
            insertCommand.Parameters.AddWithValue("@Gender", clsdbo_ProspectiveBuyer.Gender);
        } else {
            insertCommand.Parameters.AddWithValue("@Gender", DBNull.Value); }
        if (clsdbo_ProspectiveBuyer.EmailAddress != null) {
            insertCommand.Parameters.AddWithValue("@EmailAddress", clsdbo_ProspectiveBuyer.EmailAddress);
        } else {
            insertCommand.Parameters.AddWithValue("@EmailAddress", DBNull.Value); }
        if (clsdbo_ProspectiveBuyer.YearlyIncome.HasValue == true) {
            insertCommand.Parameters.AddWithValue("@YearlyIncome", clsdbo_ProspectiveBuyer.YearlyIncome);
        } else {
            insertCommand.Parameters.AddWithValue("@YearlyIncome", DBNull.Value); }
        if (clsdbo_ProspectiveBuyer.TotalChildren.HasValue == true) {
            insertCommand.Parameters.AddWithValue("@TotalChildren", clsdbo_ProspectiveBuyer.TotalChildren);
        } else {
            insertCommand.Parameters.AddWithValue("@TotalChildren", DBNull.Value); }
        if (clsdbo_ProspectiveBuyer.NumberChildrenAtHome.HasValue == true) {
            insertCommand.Parameters.AddWithValue("@NumberChildrenAtHome", clsdbo_ProspectiveBuyer.NumberChildrenAtHome);
        } else {
            insertCommand.Parameters.AddWithValue("@NumberChildrenAtHome", DBNull.Value); }
        if (clsdbo_ProspectiveBuyer.Education != null) {
            insertCommand.Parameters.AddWithValue("@Education", clsdbo_ProspectiveBuyer.Education);
        } else {
            insertCommand.Parameters.AddWithValue("@Education", DBNull.Value); }
        if (clsdbo_ProspectiveBuyer.Occupation != null) {
            insertCommand.Parameters.AddWithValue("@Occupation", clsdbo_ProspectiveBuyer.Occupation);
        } else {
            insertCommand.Parameters.AddWithValue("@Occupation", DBNull.Value); }
        if (clsdbo_ProspectiveBuyer.HouseOwnerFlag != null) {
            insertCommand.Parameters.AddWithValue("@HouseOwnerFlag", clsdbo_ProspectiveBuyer.HouseOwnerFlag);
        } else {
            insertCommand.Parameters.AddWithValue("@HouseOwnerFlag", DBNull.Value); }
        if (clsdbo_ProspectiveBuyer.NumberCarsOwned.HasValue == true) {
            insertCommand.Parameters.AddWithValue("@NumberCarsOwned", clsdbo_ProspectiveBuyer.NumberCarsOwned);
        } else {
            insertCommand.Parameters.AddWithValue("@NumberCarsOwned", DBNull.Value); }
        if (clsdbo_ProspectiveBuyer.AddressLine1 != null) {
            insertCommand.Parameters.AddWithValue("@AddressLine1", clsdbo_ProspectiveBuyer.AddressLine1);
        } else {
            insertCommand.Parameters.AddWithValue("@AddressLine1", DBNull.Value); }
        if (clsdbo_ProspectiveBuyer.AddressLine2 != null) {
            insertCommand.Parameters.AddWithValue("@AddressLine2", clsdbo_ProspectiveBuyer.AddressLine2);
        } else {
            insertCommand.Parameters.AddWithValue("@AddressLine2", DBNull.Value); }
        if (clsdbo_ProspectiveBuyer.City != null) {
            insertCommand.Parameters.AddWithValue("@City", clsdbo_ProspectiveBuyer.City);
        } else {
            insertCommand.Parameters.AddWithValue("@City", DBNull.Value); }
        if (clsdbo_ProspectiveBuyer.StateProvinceCode != null) {
            insertCommand.Parameters.AddWithValue("@StateProvinceCode", clsdbo_ProspectiveBuyer.StateProvinceCode);
        } else {
            insertCommand.Parameters.AddWithValue("@StateProvinceCode", DBNull.Value); }
        if (clsdbo_ProspectiveBuyer.PostalCode != null) {
            insertCommand.Parameters.AddWithValue("@PostalCode", clsdbo_ProspectiveBuyer.PostalCode);
        } else {
            insertCommand.Parameters.AddWithValue("@PostalCode", DBNull.Value); }
        if (clsdbo_ProspectiveBuyer.Phone != null) {
            insertCommand.Parameters.AddWithValue("@Phone", clsdbo_ProspectiveBuyer.Phone);
        } else {
            insertCommand.Parameters.AddWithValue("@Phone", DBNull.Value); }
        if (clsdbo_ProspectiveBuyer.Salutation != null) {
            insertCommand.Parameters.AddWithValue("@Salutation", clsdbo_ProspectiveBuyer.Salutation);
        } else {
            insertCommand.Parameters.AddWithValue("@Salutation", DBNull.Value); }
        if (clsdbo_ProspectiveBuyer.Unknown.HasValue == true) {
            insertCommand.Parameters.AddWithValue("@Unknown", clsdbo_ProspectiveBuyer.Unknown);
        } else {
            insertCommand.Parameters.AddWithValue("@Unknown", DBNull.Value); }
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

    public static bool Update(dbo_ProspectiveBuyerClass olddbo_ProspectiveBuyerClass, 
           dbo_ProspectiveBuyerClass newdbo_ProspectiveBuyerClass)
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string updateStatement
            = "UPDATE "  
            + "     [dbo].[ProspectiveBuyer] "
            + "SET "
            + "     [ProspectAlternateKey] = @NewProspectAlternateKey "
            + "    ,[FirstName] = @NewFirstName "
            + "    ,[MiddleName] = @NewMiddleName "
            + "    ,[LastName] = @NewLastName "
            + "    ,[BirthDate] = @NewBirthDate "
            + "    ,[MaritalStatus] = @NewMaritalStatus "
            + "    ,[Gender] = @NewGender "
            + "    ,[EmailAddress] = @NewEmailAddress "
            + "    ,[YearlyIncome] = @NewYearlyIncome "
            + "    ,[TotalChildren] = @NewTotalChildren "
            + "    ,[NumberChildrenAtHome] = @NewNumberChildrenAtHome "
            + "    ,[Education] = @NewEducation "
            + "    ,[Occupation] = @NewOccupation "
            + "    ,[HouseOwnerFlag] = @NewHouseOwnerFlag "
            + "    ,[NumberCarsOwned] = @NewNumberCarsOwned "
            + "    ,[AddressLine1] = @NewAddressLine1 "
            + "    ,[AddressLine2] = @NewAddressLine2 "
            + "    ,[City] = @NewCity "
            + "    ,[StateProvinceCode] = @NewStateProvinceCode "
            + "    ,[PostalCode] = @NewPostalCode "
            + "    ,[Phone] = @NewPhone "
            + "    ,[Salutation] = @NewSalutation "
            + "    ,[Unknown] = @NewUnknown "
            + "WHERE "
            + "     [ProspectiveBuyerKey] = @OldProspectiveBuyerKey " 
            + " AND ((@OldProspectAlternateKey IS NULL AND [ProspectAlternateKey] IS NULL) OR [ProspectAlternateKey] = @OldProspectAlternateKey) " 
            + " AND ((@OldFirstName IS NULL AND [FirstName] IS NULL) OR [FirstName] = @OldFirstName) " 
            + " AND ((@OldMiddleName IS NULL AND [MiddleName] IS NULL) OR [MiddleName] = @OldMiddleName) " 
            + " AND ((@OldLastName IS NULL AND [LastName] IS NULL) OR [LastName] = @OldLastName) " 
            + " AND ((@OldBirthDate IS NULL AND [BirthDate] IS NULL) OR [BirthDate] = @OldBirthDate) " 
            + " AND ((@OldMaritalStatus IS NULL AND [MaritalStatus] IS NULL) OR [MaritalStatus] = @OldMaritalStatus) " 
            + " AND ((@OldGender IS NULL AND [Gender] IS NULL) OR [Gender] = @OldGender) " 
            + " AND ((@OldEmailAddress IS NULL AND [EmailAddress] IS NULL) OR [EmailAddress] = @OldEmailAddress) " 
            + " AND ((@OldYearlyIncome IS NULL AND [YearlyIncome] IS NULL) OR [YearlyIncome] = @OldYearlyIncome) " 
            + " AND ((@OldTotalChildren IS NULL AND [TotalChildren] IS NULL) OR [TotalChildren] = @OldTotalChildren) " 
            + " AND ((@OldNumberChildrenAtHome IS NULL AND [NumberChildrenAtHome] IS NULL) OR [NumberChildrenAtHome] = @OldNumberChildrenAtHome) " 
            + " AND ((@OldEducation IS NULL AND [Education] IS NULL) OR [Education] = @OldEducation) " 
            + " AND ((@OldOccupation IS NULL AND [Occupation] IS NULL) OR [Occupation] = @OldOccupation) " 
            + " AND ((@OldHouseOwnerFlag IS NULL AND [HouseOwnerFlag] IS NULL) OR [HouseOwnerFlag] = @OldHouseOwnerFlag) " 
            + " AND ((@OldNumberCarsOwned IS NULL AND [NumberCarsOwned] IS NULL) OR [NumberCarsOwned] = @OldNumberCarsOwned) " 
            + " AND ((@OldAddressLine1 IS NULL AND [AddressLine1] IS NULL) OR [AddressLine1] = @OldAddressLine1) " 
            + " AND ((@OldAddressLine2 IS NULL AND [AddressLine2] IS NULL) OR [AddressLine2] = @OldAddressLine2) " 
            + " AND ((@OldCity IS NULL AND [City] IS NULL) OR [City] = @OldCity) " 
            + " AND ((@OldStateProvinceCode IS NULL AND [StateProvinceCode] IS NULL) OR [StateProvinceCode] = @OldStateProvinceCode) " 
            + " AND ((@OldPostalCode IS NULL AND [PostalCode] IS NULL) OR [PostalCode] = @OldPostalCode) " 
            + " AND ((@OldPhone IS NULL AND [Phone] IS NULL) OR [Phone] = @OldPhone) " 
            + " AND ((@OldSalutation IS NULL AND [Salutation] IS NULL) OR [Salutation] = @OldSalutation) " 
            + " AND ((@OldUnknown IS NULL AND [Unknown] IS NULL) OR [Unknown] = @OldUnknown) " 
            + "";
        SqlCommand updateCommand = new SqlCommand(updateStatement, connection);
        updateCommand.CommandType = CommandType.Text;
        if (newdbo_ProspectiveBuyerClass.ProspectAlternateKey != null) {
            updateCommand.Parameters.AddWithValue("@NewProspectAlternateKey", newdbo_ProspectiveBuyerClass.ProspectAlternateKey);
        } else {
            updateCommand.Parameters.AddWithValue("@NewProspectAlternateKey", DBNull.Value); }
        if (newdbo_ProspectiveBuyerClass.FirstName != null) {
            updateCommand.Parameters.AddWithValue("@NewFirstName", newdbo_ProspectiveBuyerClass.FirstName);
        } else {
            updateCommand.Parameters.AddWithValue("@NewFirstName", DBNull.Value); }
        if (newdbo_ProspectiveBuyerClass.MiddleName != null) {
            updateCommand.Parameters.AddWithValue("@NewMiddleName", newdbo_ProspectiveBuyerClass.MiddleName);
        } else {
            updateCommand.Parameters.AddWithValue("@NewMiddleName", DBNull.Value); }
        if (newdbo_ProspectiveBuyerClass.LastName != null) {
            updateCommand.Parameters.AddWithValue("@NewLastName", newdbo_ProspectiveBuyerClass.LastName);
        } else {
            updateCommand.Parameters.AddWithValue("@NewLastName", DBNull.Value); }
        if (newdbo_ProspectiveBuyerClass.BirthDate.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@NewBirthDate", newdbo_ProspectiveBuyerClass.BirthDate);
        } else {
            updateCommand.Parameters.AddWithValue("@NewBirthDate", DBNull.Value); }
        if (newdbo_ProspectiveBuyerClass.MaritalStatus != null) {
            updateCommand.Parameters.AddWithValue("@NewMaritalStatus", newdbo_ProspectiveBuyerClass.MaritalStatus);
        } else {
            updateCommand.Parameters.AddWithValue("@NewMaritalStatus", DBNull.Value); }
        if (newdbo_ProspectiveBuyerClass.Gender != null) {
            updateCommand.Parameters.AddWithValue("@NewGender", newdbo_ProspectiveBuyerClass.Gender);
        } else {
            updateCommand.Parameters.AddWithValue("@NewGender", DBNull.Value); }
        if (newdbo_ProspectiveBuyerClass.EmailAddress != null) {
            updateCommand.Parameters.AddWithValue("@NewEmailAddress", newdbo_ProspectiveBuyerClass.EmailAddress);
        } else {
            updateCommand.Parameters.AddWithValue("@NewEmailAddress", DBNull.Value); }
        if (newdbo_ProspectiveBuyerClass.YearlyIncome.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@NewYearlyIncome", newdbo_ProspectiveBuyerClass.YearlyIncome);
        } else {
            updateCommand.Parameters.AddWithValue("@NewYearlyIncome", DBNull.Value); }
        if (newdbo_ProspectiveBuyerClass.TotalChildren.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@NewTotalChildren", newdbo_ProspectiveBuyerClass.TotalChildren);
        } else {
            updateCommand.Parameters.AddWithValue("@NewTotalChildren", DBNull.Value); }
        if (newdbo_ProspectiveBuyerClass.NumberChildrenAtHome.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@NewNumberChildrenAtHome", newdbo_ProspectiveBuyerClass.NumberChildrenAtHome);
        } else {
            updateCommand.Parameters.AddWithValue("@NewNumberChildrenAtHome", DBNull.Value); }
        if (newdbo_ProspectiveBuyerClass.Education != null) {
            updateCommand.Parameters.AddWithValue("@NewEducation", newdbo_ProspectiveBuyerClass.Education);
        } else {
            updateCommand.Parameters.AddWithValue("@NewEducation", DBNull.Value); }
        if (newdbo_ProspectiveBuyerClass.Occupation != null) {
            updateCommand.Parameters.AddWithValue("@NewOccupation", newdbo_ProspectiveBuyerClass.Occupation);
        } else {
            updateCommand.Parameters.AddWithValue("@NewOccupation", DBNull.Value); }
        if (newdbo_ProspectiveBuyerClass.HouseOwnerFlag != null) {
            updateCommand.Parameters.AddWithValue("@NewHouseOwnerFlag", newdbo_ProspectiveBuyerClass.HouseOwnerFlag);
        } else {
            updateCommand.Parameters.AddWithValue("@NewHouseOwnerFlag", DBNull.Value); }
        if (newdbo_ProspectiveBuyerClass.NumberCarsOwned.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@NewNumberCarsOwned", newdbo_ProspectiveBuyerClass.NumberCarsOwned);
        } else {
            updateCommand.Parameters.AddWithValue("@NewNumberCarsOwned", DBNull.Value); }
        if (newdbo_ProspectiveBuyerClass.AddressLine1 != null) {
            updateCommand.Parameters.AddWithValue("@NewAddressLine1", newdbo_ProspectiveBuyerClass.AddressLine1);
        } else {
            updateCommand.Parameters.AddWithValue("@NewAddressLine1", DBNull.Value); }
        if (newdbo_ProspectiveBuyerClass.AddressLine2 != null) {
            updateCommand.Parameters.AddWithValue("@NewAddressLine2", newdbo_ProspectiveBuyerClass.AddressLine2);
        } else {
            updateCommand.Parameters.AddWithValue("@NewAddressLine2", DBNull.Value); }
        if (newdbo_ProspectiveBuyerClass.City != null) {
            updateCommand.Parameters.AddWithValue("@NewCity", newdbo_ProspectiveBuyerClass.City);
        } else {
            updateCommand.Parameters.AddWithValue("@NewCity", DBNull.Value); }
        if (newdbo_ProspectiveBuyerClass.StateProvinceCode != null) {
            updateCommand.Parameters.AddWithValue("@NewStateProvinceCode", newdbo_ProspectiveBuyerClass.StateProvinceCode);
        } else {
            updateCommand.Parameters.AddWithValue("@NewStateProvinceCode", DBNull.Value); }
        if (newdbo_ProspectiveBuyerClass.PostalCode != null) {
            updateCommand.Parameters.AddWithValue("@NewPostalCode", newdbo_ProspectiveBuyerClass.PostalCode);
        } else {
            updateCommand.Parameters.AddWithValue("@NewPostalCode", DBNull.Value); }
        if (newdbo_ProspectiveBuyerClass.Phone != null) {
            updateCommand.Parameters.AddWithValue("@NewPhone", newdbo_ProspectiveBuyerClass.Phone);
        } else {
            updateCommand.Parameters.AddWithValue("@NewPhone", DBNull.Value); }
        if (newdbo_ProspectiveBuyerClass.Salutation != null) {
            updateCommand.Parameters.AddWithValue("@NewSalutation", newdbo_ProspectiveBuyerClass.Salutation);
        } else {
            updateCommand.Parameters.AddWithValue("@NewSalutation", DBNull.Value); }
        if (newdbo_ProspectiveBuyerClass.Unknown.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@NewUnknown", newdbo_ProspectiveBuyerClass.Unknown);
        } else {
            updateCommand.Parameters.AddWithValue("@NewUnknown", DBNull.Value); }
        updateCommand.Parameters.AddWithValue("@OldProspectiveBuyerKey", olddbo_ProspectiveBuyerClass.ProspectiveBuyerKey);
        if (olddbo_ProspectiveBuyerClass.ProspectAlternateKey != null) {
            updateCommand.Parameters.AddWithValue("@OldProspectAlternateKey", olddbo_ProspectiveBuyerClass.ProspectAlternateKey);
        } else {
            updateCommand.Parameters.AddWithValue("@OldProspectAlternateKey", DBNull.Value); }
        if (olddbo_ProspectiveBuyerClass.FirstName != null) {
            updateCommand.Parameters.AddWithValue("@OldFirstName", olddbo_ProspectiveBuyerClass.FirstName);
        } else {
            updateCommand.Parameters.AddWithValue("@OldFirstName", DBNull.Value); }
        if (olddbo_ProspectiveBuyerClass.MiddleName != null) {
            updateCommand.Parameters.AddWithValue("@OldMiddleName", olddbo_ProspectiveBuyerClass.MiddleName);
        } else {
            updateCommand.Parameters.AddWithValue("@OldMiddleName", DBNull.Value); }
        if (olddbo_ProspectiveBuyerClass.LastName != null) {
            updateCommand.Parameters.AddWithValue("@OldLastName", olddbo_ProspectiveBuyerClass.LastName);
        } else {
            updateCommand.Parameters.AddWithValue("@OldLastName", DBNull.Value); }
        if (olddbo_ProspectiveBuyerClass.BirthDate.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@OldBirthDate", olddbo_ProspectiveBuyerClass.BirthDate);
        } else {
            updateCommand.Parameters.AddWithValue("@OldBirthDate", DBNull.Value); }
        if (olddbo_ProspectiveBuyerClass.MaritalStatus != null) {
            updateCommand.Parameters.AddWithValue("@OldMaritalStatus", olddbo_ProspectiveBuyerClass.MaritalStatus);
        } else {
            updateCommand.Parameters.AddWithValue("@OldMaritalStatus", DBNull.Value); }
        if (olddbo_ProspectiveBuyerClass.Gender != null) {
            updateCommand.Parameters.AddWithValue("@OldGender", olddbo_ProspectiveBuyerClass.Gender);
        } else {
            updateCommand.Parameters.AddWithValue("@OldGender", DBNull.Value); }
        if (olddbo_ProspectiveBuyerClass.EmailAddress != null) {
            updateCommand.Parameters.AddWithValue("@OldEmailAddress", olddbo_ProspectiveBuyerClass.EmailAddress);
        } else {
            updateCommand.Parameters.AddWithValue("@OldEmailAddress", DBNull.Value); }
        if (olddbo_ProspectiveBuyerClass.YearlyIncome.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@OldYearlyIncome", olddbo_ProspectiveBuyerClass.YearlyIncome);
        } else {
            updateCommand.Parameters.AddWithValue("@OldYearlyIncome", DBNull.Value); }
        if (olddbo_ProspectiveBuyerClass.TotalChildren.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@OldTotalChildren", olddbo_ProspectiveBuyerClass.TotalChildren);
        } else {
            updateCommand.Parameters.AddWithValue("@OldTotalChildren", DBNull.Value); }
        if (olddbo_ProspectiveBuyerClass.NumberChildrenAtHome.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@OldNumberChildrenAtHome", olddbo_ProspectiveBuyerClass.NumberChildrenAtHome);
        } else {
            updateCommand.Parameters.AddWithValue("@OldNumberChildrenAtHome", DBNull.Value); }
        if (olddbo_ProspectiveBuyerClass.Education != null) {
            updateCommand.Parameters.AddWithValue("@OldEducation", olddbo_ProspectiveBuyerClass.Education);
        } else {
            updateCommand.Parameters.AddWithValue("@OldEducation", DBNull.Value); }
        if (olddbo_ProspectiveBuyerClass.Occupation != null) {
            updateCommand.Parameters.AddWithValue("@OldOccupation", olddbo_ProspectiveBuyerClass.Occupation);
        } else {
            updateCommand.Parameters.AddWithValue("@OldOccupation", DBNull.Value); }
        if (olddbo_ProspectiveBuyerClass.HouseOwnerFlag != null) {
            updateCommand.Parameters.AddWithValue("@OldHouseOwnerFlag", olddbo_ProspectiveBuyerClass.HouseOwnerFlag);
        } else {
            updateCommand.Parameters.AddWithValue("@OldHouseOwnerFlag", DBNull.Value); }
        if (olddbo_ProspectiveBuyerClass.NumberCarsOwned.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@OldNumberCarsOwned", olddbo_ProspectiveBuyerClass.NumberCarsOwned);
        } else {
            updateCommand.Parameters.AddWithValue("@OldNumberCarsOwned", DBNull.Value); }
        if (olddbo_ProspectiveBuyerClass.AddressLine1 != null) {
            updateCommand.Parameters.AddWithValue("@OldAddressLine1", olddbo_ProspectiveBuyerClass.AddressLine1);
        } else {
            updateCommand.Parameters.AddWithValue("@OldAddressLine1", DBNull.Value); }
        if (olddbo_ProspectiveBuyerClass.AddressLine2 != null) {
            updateCommand.Parameters.AddWithValue("@OldAddressLine2", olddbo_ProspectiveBuyerClass.AddressLine2);
        } else {
            updateCommand.Parameters.AddWithValue("@OldAddressLine2", DBNull.Value); }
        if (olddbo_ProspectiveBuyerClass.City != null) {
            updateCommand.Parameters.AddWithValue("@OldCity", olddbo_ProspectiveBuyerClass.City);
        } else {
            updateCommand.Parameters.AddWithValue("@OldCity", DBNull.Value); }
        if (olddbo_ProspectiveBuyerClass.StateProvinceCode != null) {
            updateCommand.Parameters.AddWithValue("@OldStateProvinceCode", olddbo_ProspectiveBuyerClass.StateProvinceCode);
        } else {
            updateCommand.Parameters.AddWithValue("@OldStateProvinceCode", DBNull.Value); }
        if (olddbo_ProspectiveBuyerClass.PostalCode != null) {
            updateCommand.Parameters.AddWithValue("@OldPostalCode", olddbo_ProspectiveBuyerClass.PostalCode);
        } else {
            updateCommand.Parameters.AddWithValue("@OldPostalCode", DBNull.Value); }
        if (olddbo_ProspectiveBuyerClass.Phone != null) {
            updateCommand.Parameters.AddWithValue("@OldPhone", olddbo_ProspectiveBuyerClass.Phone);
        } else {
            updateCommand.Parameters.AddWithValue("@OldPhone", DBNull.Value); }
        if (olddbo_ProspectiveBuyerClass.Salutation != null) {
            updateCommand.Parameters.AddWithValue("@OldSalutation", olddbo_ProspectiveBuyerClass.Salutation);
        } else {
            updateCommand.Parameters.AddWithValue("@OldSalutation", DBNull.Value); }
        if (olddbo_ProspectiveBuyerClass.Unknown.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@OldUnknown", olddbo_ProspectiveBuyerClass.Unknown);
        } else {
            updateCommand.Parameters.AddWithValue("@OldUnknown", DBNull.Value); }
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

    public static bool Delete(dbo_ProspectiveBuyerClass clsdbo_ProspectiveBuyer)
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string deleteStatement
            = "DELETE FROM "  
            + "     [dbo].[ProspectiveBuyer] "
            + "WHERE " 
            + "     [ProspectiveBuyerKey] = @OldProspectiveBuyerKey " 
            + " AND ((@OldProspectAlternateKey IS NULL AND [ProspectAlternateKey] IS NULL) OR [ProspectAlternateKey] = @OldProspectAlternateKey) " 
            + " AND ((@OldFirstName IS NULL AND [FirstName] IS NULL) OR [FirstName] = @OldFirstName) " 
            + " AND ((@OldMiddleName IS NULL AND [MiddleName] IS NULL) OR [MiddleName] = @OldMiddleName) " 
            + " AND ((@OldLastName IS NULL AND [LastName] IS NULL) OR [LastName] = @OldLastName) " 
            + " AND ((@OldBirthDate IS NULL AND [BirthDate] IS NULL) OR [BirthDate] = @OldBirthDate) " 
            + " AND ((@OldMaritalStatus IS NULL AND [MaritalStatus] IS NULL) OR [MaritalStatus] = @OldMaritalStatus) " 
            + " AND ((@OldGender IS NULL AND [Gender] IS NULL) OR [Gender] = @OldGender) " 
            + " AND ((@OldEmailAddress IS NULL AND [EmailAddress] IS NULL) OR [EmailAddress] = @OldEmailAddress) " 
            + " AND ((@OldYearlyIncome IS NULL AND [YearlyIncome] IS NULL) OR [YearlyIncome] = @OldYearlyIncome) " 
            + " AND ((@OldTotalChildren IS NULL AND [TotalChildren] IS NULL) OR [TotalChildren] = @OldTotalChildren) " 
            + " AND ((@OldNumberChildrenAtHome IS NULL AND [NumberChildrenAtHome] IS NULL) OR [NumberChildrenAtHome] = @OldNumberChildrenAtHome) " 
            + " AND ((@OldEducation IS NULL AND [Education] IS NULL) OR [Education] = @OldEducation) " 
            + " AND ((@OldOccupation IS NULL AND [Occupation] IS NULL) OR [Occupation] = @OldOccupation) " 
            + " AND ((@OldHouseOwnerFlag IS NULL AND [HouseOwnerFlag] IS NULL) OR [HouseOwnerFlag] = @OldHouseOwnerFlag) " 
            + " AND ((@OldNumberCarsOwned IS NULL AND [NumberCarsOwned] IS NULL) OR [NumberCarsOwned] = @OldNumberCarsOwned) " 
            + " AND ((@OldAddressLine1 IS NULL AND [AddressLine1] IS NULL) OR [AddressLine1] = @OldAddressLine1) " 
            + " AND ((@OldAddressLine2 IS NULL AND [AddressLine2] IS NULL) OR [AddressLine2] = @OldAddressLine2) " 
            + " AND ((@OldCity IS NULL AND [City] IS NULL) OR [City] = @OldCity) " 
            + " AND ((@OldStateProvinceCode IS NULL AND [StateProvinceCode] IS NULL) OR [StateProvinceCode] = @OldStateProvinceCode) " 
            + " AND ((@OldPostalCode IS NULL AND [PostalCode] IS NULL) OR [PostalCode] = @OldPostalCode) " 
            + " AND ((@OldPhone IS NULL AND [Phone] IS NULL) OR [Phone] = @OldPhone) " 
            + " AND ((@OldSalutation IS NULL AND [Salutation] IS NULL) OR [Salutation] = @OldSalutation) " 
            + " AND ((@OldUnknown IS NULL AND [Unknown] IS NULL) OR [Unknown] = @OldUnknown) " 
            + "";
        SqlCommand deleteCommand = new SqlCommand(deleteStatement, connection);
        deleteCommand.CommandType = CommandType.Text;
        deleteCommand.Parameters.AddWithValue("@OldProspectiveBuyerKey", clsdbo_ProspectiveBuyer.ProspectiveBuyerKey);
        if (clsdbo_ProspectiveBuyer.ProspectAlternateKey != null) {
            deleteCommand.Parameters.AddWithValue("@OldProspectAlternateKey", clsdbo_ProspectiveBuyer.ProspectAlternateKey);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldProspectAlternateKey", DBNull.Value); }
        if (clsdbo_ProspectiveBuyer.FirstName != null) {
            deleteCommand.Parameters.AddWithValue("@OldFirstName", clsdbo_ProspectiveBuyer.FirstName);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldFirstName", DBNull.Value); }
        if (clsdbo_ProspectiveBuyer.MiddleName != null) {
            deleteCommand.Parameters.AddWithValue("@OldMiddleName", clsdbo_ProspectiveBuyer.MiddleName);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldMiddleName", DBNull.Value); }
        if (clsdbo_ProspectiveBuyer.LastName != null) {
            deleteCommand.Parameters.AddWithValue("@OldLastName", clsdbo_ProspectiveBuyer.LastName);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldLastName", DBNull.Value); }
        if (clsdbo_ProspectiveBuyer.BirthDate.HasValue == true) {
            deleteCommand.Parameters.AddWithValue("@OldBirthDate", clsdbo_ProspectiveBuyer.BirthDate);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldBirthDate", DBNull.Value); }
        if (clsdbo_ProspectiveBuyer.MaritalStatus != null) {
            deleteCommand.Parameters.AddWithValue("@OldMaritalStatus", clsdbo_ProspectiveBuyer.MaritalStatus);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldMaritalStatus", DBNull.Value); }
        if (clsdbo_ProspectiveBuyer.Gender != null) {
            deleteCommand.Parameters.AddWithValue("@OldGender", clsdbo_ProspectiveBuyer.Gender);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldGender", DBNull.Value); }
        if (clsdbo_ProspectiveBuyer.EmailAddress != null) {
            deleteCommand.Parameters.AddWithValue("@OldEmailAddress", clsdbo_ProspectiveBuyer.EmailAddress);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldEmailAddress", DBNull.Value); }
        if (clsdbo_ProspectiveBuyer.YearlyIncome.HasValue == true) {
            deleteCommand.Parameters.AddWithValue("@OldYearlyIncome", clsdbo_ProspectiveBuyer.YearlyIncome);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldYearlyIncome", DBNull.Value); }
        if (clsdbo_ProspectiveBuyer.TotalChildren.HasValue == true) {
            deleteCommand.Parameters.AddWithValue("@OldTotalChildren", clsdbo_ProspectiveBuyer.TotalChildren);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldTotalChildren", DBNull.Value); }
        if (clsdbo_ProspectiveBuyer.NumberChildrenAtHome.HasValue == true) {
            deleteCommand.Parameters.AddWithValue("@OldNumberChildrenAtHome", clsdbo_ProspectiveBuyer.NumberChildrenAtHome);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldNumberChildrenAtHome", DBNull.Value); }
        if (clsdbo_ProspectiveBuyer.Education != null) {
            deleteCommand.Parameters.AddWithValue("@OldEducation", clsdbo_ProspectiveBuyer.Education);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldEducation", DBNull.Value); }
        if (clsdbo_ProspectiveBuyer.Occupation != null) {
            deleteCommand.Parameters.AddWithValue("@OldOccupation", clsdbo_ProspectiveBuyer.Occupation);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldOccupation", DBNull.Value); }
        if (clsdbo_ProspectiveBuyer.HouseOwnerFlag != null) {
            deleteCommand.Parameters.AddWithValue("@OldHouseOwnerFlag", clsdbo_ProspectiveBuyer.HouseOwnerFlag);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldHouseOwnerFlag", DBNull.Value); }
        if (clsdbo_ProspectiveBuyer.NumberCarsOwned.HasValue == true) {
            deleteCommand.Parameters.AddWithValue("@OldNumberCarsOwned", clsdbo_ProspectiveBuyer.NumberCarsOwned);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldNumberCarsOwned", DBNull.Value); }
        if (clsdbo_ProspectiveBuyer.AddressLine1 != null) {
            deleteCommand.Parameters.AddWithValue("@OldAddressLine1", clsdbo_ProspectiveBuyer.AddressLine1);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldAddressLine1", DBNull.Value); }
        if (clsdbo_ProspectiveBuyer.AddressLine2 != null) {
            deleteCommand.Parameters.AddWithValue("@OldAddressLine2", clsdbo_ProspectiveBuyer.AddressLine2);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldAddressLine2", DBNull.Value); }
        if (clsdbo_ProspectiveBuyer.City != null) {
            deleteCommand.Parameters.AddWithValue("@OldCity", clsdbo_ProspectiveBuyer.City);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldCity", DBNull.Value); }
        if (clsdbo_ProspectiveBuyer.StateProvinceCode != null) {
            deleteCommand.Parameters.AddWithValue("@OldStateProvinceCode", clsdbo_ProspectiveBuyer.StateProvinceCode);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldStateProvinceCode", DBNull.Value); }
        if (clsdbo_ProspectiveBuyer.PostalCode != null) {
            deleteCommand.Parameters.AddWithValue("@OldPostalCode", clsdbo_ProspectiveBuyer.PostalCode);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldPostalCode", DBNull.Value); }
        if (clsdbo_ProspectiveBuyer.Phone != null) {
            deleteCommand.Parameters.AddWithValue("@OldPhone", clsdbo_ProspectiveBuyer.Phone);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldPhone", DBNull.Value); }
        if (clsdbo_ProspectiveBuyer.Salutation != null) {
            deleteCommand.Parameters.AddWithValue("@OldSalutation", clsdbo_ProspectiveBuyer.Salutation);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldSalutation", DBNull.Value); }
        if (clsdbo_ProspectiveBuyer.Unknown.HasValue == true) {
            deleteCommand.Parameters.AddWithValue("@OldUnknown", clsdbo_ProspectiveBuyer.Unknown);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldUnknown", DBNull.Value); }
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

 
