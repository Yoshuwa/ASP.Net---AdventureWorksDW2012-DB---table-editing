using System;
using System.Data;
using System.Data.SqlClient;

public class dbo_DimEmployeeDataClass
{

    public static DataTable SelectAll()
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement
            = "SELECT "  
            + "     [dbo].[DimEmployee].[EmployeeKey] "
            + "    ,[A68].[FirstName] "
            + "    ,[dbo].[DimEmployee].[EmployeeNationalIDAlternateKey] "
            + "    ,[dbo].[DimEmployee].[ParentEmployeeNationalIDAlternateKey] "
            + "    ,[A71].[SalesTerritoryAlternateKey] "
            + "    ,[dbo].[DimEmployee].[FirstName] "
            + "    ,[dbo].[DimEmployee].[LastName] "
            + "    ,[dbo].[DimEmployee].[MiddleName] "
            + "    ,[dbo].[DimEmployee].[NameStyle] "
            + "    ,[dbo].[DimEmployee].[Title] "
            + "    ,[dbo].[DimEmployee].[HireDate] "
            + "    ,[dbo].[DimEmployee].[BirthDate] "
            + "    ,[dbo].[DimEmployee].[LoginID] "
            + "    ,[dbo].[DimEmployee].[EmailAddress] "
            + "    ,[dbo].[DimEmployee].[Phone] "
            + "    ,[dbo].[DimEmployee].[MaritalStatus] "
            + "    ,[dbo].[DimEmployee].[EmergencyContactName] "
            + "    ,[dbo].[DimEmployee].[EmergencyContactPhone] "
            + "    ,[dbo].[DimEmployee].[SalariedFlag] "
            + "    ,[dbo].[DimEmployee].[Gender] "
            + "    ,[dbo].[DimEmployee].[PayFrequency] "
            + "    ,[dbo].[DimEmployee].[BaseRate] "
            + "    ,[dbo].[DimEmployee].[VacationHours] "
            + "    ,[dbo].[DimEmployee].[SickLeaveHours] "
            + "    ,[dbo].[DimEmployee].[CurrentFlag] "
            + "    ,[dbo].[DimEmployee].[SalesPersonFlag] "
            + "    ,[dbo].[DimEmployee].[DepartmentName] "
            + "    ,[dbo].[DimEmployee].[StartDate] "
            + "    ,[dbo].[DimEmployee].[EndDate] "
            + "    ,[dbo].[DimEmployee].[Status] "
            + "FROM " 
            + "     [dbo].[DimEmployee] " 
            + "LEFT JOIN [dbo].[DimEmployee] as [A68] ON [dbo].[DimEmployee].[ParentEmployeeKey] = [A68].[ParentEmployeeKey] "
            + "LEFT JOIN [dbo].[DimSalesTerritory] as [A71] ON [dbo].[DimEmployee].[SalesTerritoryKey] = [A71].[SalesTerritoryAlternateKey] "
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
            + "     [dbo].[DimEmployee].[EmployeeKey] "
            + "    ,[A68].[FirstName]"
            + "    ,[dbo].[DimEmployee].[EmployeeNationalIDAlternateKey] "
            + "    ,[dbo].[DimEmployee].[ParentEmployeeNationalIDAlternateKey] "
            + "    ,[A71].[SalesTerritoryAlternateKey]"
            + "    ,[dbo].[DimEmployee].[FirstName] "
            + "    ,[dbo].[DimEmployee].[LastName] "
            + "    ,[dbo].[DimEmployee].[MiddleName] "
            + "    ,[dbo].[DimEmployee].[NameStyle] "
            + "    ,[dbo].[DimEmployee].[Title] "
            + "    ,[dbo].[DimEmployee].[HireDate] "
            + "    ,[dbo].[DimEmployee].[BirthDate] "
            + "    ,[dbo].[DimEmployee].[LoginID] "
            + "    ,[dbo].[DimEmployee].[EmailAddress] "
            + "    ,[dbo].[DimEmployee].[Phone] "
            + "    ,[dbo].[DimEmployee].[MaritalStatus] "
            + "    ,[dbo].[DimEmployee].[EmergencyContactName] "
            + "    ,[dbo].[DimEmployee].[EmergencyContactPhone] "
            + "    ,[dbo].[DimEmployee].[SalariedFlag] "
            + "    ,[dbo].[DimEmployee].[Gender] "
            + "    ,[dbo].[DimEmployee].[PayFrequency] "
            + "    ,[dbo].[DimEmployee].[BaseRate] "
            + "    ,[dbo].[DimEmployee].[VacationHours] "
            + "    ,[dbo].[DimEmployee].[SickLeaveHours] "
            + "    ,[dbo].[DimEmployee].[CurrentFlag] "
            + "    ,[dbo].[DimEmployee].[SalesPersonFlag] "
            + "    ,[dbo].[DimEmployee].[DepartmentName] "
            + "    ,[dbo].[DimEmployee].[StartDate] "
            + "    ,[dbo].[DimEmployee].[EndDate] "
            + "    ,[dbo].[DimEmployee].[Status] "
            + "FROM " 
            + "     [dbo].[DimEmployee] " 
            + "LEFT JOIN [dbo].[DimEmployee] as [A68] ON [dbo].[DimEmployee].[ParentEmployeeKey] = [A68].[ParentEmployeeKey] "
            + "LEFT JOIN [dbo].[DimSalesTerritory] as [A71] ON [dbo].[DimEmployee].[SalesTerritoryKey] = [A71].[SalesTerritoryAlternateKey] "
                + "WHERE " 
                + "     (@EmployeeKey IS NULL OR @EmployeeKey = '' OR [DimEmployee].[EmployeeKey] LIKE '%' + LTRIM(RTRIM(@EmployeeKey)) + '%') " 
                + "AND   (@FirstName68 IS NULL OR @FirstName68 = '' OR [A68].[FirstName] LIKE '%' + LTRIM(RTRIM(@FirstName68)) + '%') " 
                + "AND   (@EmployeeNationalIDAlternateKey IS NULL OR @EmployeeNationalIDAlternateKey = '' OR [DimEmployee].[EmployeeNationalIDAlternateKey] LIKE '%' + LTRIM(RTRIM(@EmployeeNationalIDAlternateKey)) + '%') " 
                + "AND   (@ParentEmployeeNationalIDAlternateKey IS NULL OR @ParentEmployeeNationalIDAlternateKey = '' OR [DimEmployee].[ParentEmployeeNationalIDAlternateKey] LIKE '%' + LTRIM(RTRIM(@ParentEmployeeNationalIDAlternateKey)) + '%') " 
                + "AND   (@SalesTerritoryAlternateKey71 IS NULL OR @SalesTerritoryAlternateKey71 = '' OR [A71].[SalesTerritoryAlternateKey] LIKE '%' + LTRIM(RTRIM(@SalesTerritoryAlternateKey71)) + '%') " 
                + "AND   (@FirstName IS NULL OR @FirstName = '' OR [DimEmployee].[FirstName] LIKE '%' + LTRIM(RTRIM(@FirstName)) + '%') " 
                + "AND   (@LastName IS NULL OR @LastName = '' OR [DimEmployee].[LastName] LIKE '%' + LTRIM(RTRIM(@LastName)) + '%') " 
                + "AND   (@MiddleName IS NULL OR @MiddleName = '' OR [DimEmployee].[MiddleName] LIKE '%' + LTRIM(RTRIM(@MiddleName)) + '%') " 
                + "AND   (@NameStyle IS NULL OR @NameStyle = '' OR [DimEmployee].[NameStyle] LIKE '%' + LTRIM(RTRIM(@NameStyle)) + '%') " 
                + "AND   (@Title IS NULL OR @Title = '' OR [DimEmployee].[Title] LIKE '%' + LTRIM(RTRIM(@Title)) + '%') " 
                + "AND   (@HireDate IS NULL OR @HireDate = '' OR [DimEmployee].[HireDate] LIKE '%' + LTRIM(RTRIM(@HireDate)) + '%') " 
                + "AND   (@BirthDate IS NULL OR @BirthDate = '' OR [DimEmployee].[BirthDate] LIKE '%' + LTRIM(RTRIM(@BirthDate)) + '%') " 
                + "AND   (@LoginID IS NULL OR @LoginID = '' OR [DimEmployee].[LoginID] LIKE '%' + LTRIM(RTRIM(@LoginID)) + '%') " 
                + "AND   (@EmailAddress IS NULL OR @EmailAddress = '' OR [DimEmployee].[EmailAddress] LIKE '%' + LTRIM(RTRIM(@EmailAddress)) + '%') " 
                + "AND   (@Phone IS NULL OR @Phone = '' OR [DimEmployee].[Phone] LIKE '%' + LTRIM(RTRIM(@Phone)) + '%') " 
                + "AND   (@MaritalStatus IS NULL OR @MaritalStatus = '' OR [DimEmployee].[MaritalStatus] LIKE '%' + LTRIM(RTRIM(@MaritalStatus)) + '%') " 
                + "AND   (@EmergencyContactName IS NULL OR @EmergencyContactName = '' OR [DimEmployee].[EmergencyContactName] LIKE '%' + LTRIM(RTRIM(@EmergencyContactName)) + '%') " 
                + "AND   (@EmergencyContactPhone IS NULL OR @EmergencyContactPhone = '' OR [DimEmployee].[EmergencyContactPhone] LIKE '%' + LTRIM(RTRIM(@EmergencyContactPhone)) + '%') " 
                + "AND   (@SalariedFlag IS NULL OR @SalariedFlag = '' OR [DimEmployee].[SalariedFlag] LIKE '%' + LTRIM(RTRIM(@SalariedFlag)) + '%') " 
                + "AND   (@Gender IS NULL OR @Gender = '' OR [DimEmployee].[Gender] LIKE '%' + LTRIM(RTRIM(@Gender)) + '%') " 
                + "AND   (@PayFrequency IS NULL OR @PayFrequency = '' OR [DimEmployee].[PayFrequency] LIKE '%' + LTRIM(RTRIM(@PayFrequency)) + '%') " 
                + "AND   (@BaseRate IS NULL OR @BaseRate = '' OR [DimEmployee].[BaseRate] LIKE '%' + LTRIM(RTRIM(@BaseRate)) + '%') " 
                + "AND   (@VacationHours IS NULL OR @VacationHours = '' OR [DimEmployee].[VacationHours] LIKE '%' + LTRIM(RTRIM(@VacationHours)) + '%') " 
                + "AND   (@SickLeaveHours IS NULL OR @SickLeaveHours = '' OR [DimEmployee].[SickLeaveHours] LIKE '%' + LTRIM(RTRIM(@SickLeaveHours)) + '%') " 
                + "AND   (@CurrentFlag IS NULL OR @CurrentFlag = '' OR [DimEmployee].[CurrentFlag] LIKE '%' + LTRIM(RTRIM(@CurrentFlag)) + '%') " 
                + "AND   (@SalesPersonFlag IS NULL OR @SalesPersonFlag = '' OR [DimEmployee].[SalesPersonFlag] LIKE '%' + LTRIM(RTRIM(@SalesPersonFlag)) + '%') " 
                + "AND   (@DepartmentName IS NULL OR @DepartmentName = '' OR [DimEmployee].[DepartmentName] LIKE '%' + LTRIM(RTRIM(@DepartmentName)) + '%') " 
                + "AND   (@StartDate IS NULL OR @StartDate = '' OR [DimEmployee].[StartDate] LIKE '%' + LTRIM(RTRIM(@StartDate)) + '%') " 
                + "AND   (@EndDate IS NULL OR @EndDate = '' OR [DimEmployee].[EndDate] LIKE '%' + LTRIM(RTRIM(@EndDate)) + '%') " 
                + "AND   (@Status IS NULL OR @Status = '' OR [DimEmployee].[Status] LIKE '%' + LTRIM(RTRIM(@Status)) + '%') " 
                + "";
        } else if (sCondition == "Equals") {
            selectStatement
                = "SELECT "
            + "     [dbo].[DimEmployee].[EmployeeKey] "
            + "    ,[A68].[FirstName]"
            + "    ,[dbo].[DimEmployee].[EmployeeNationalIDAlternateKey] "
            + "    ,[dbo].[DimEmployee].[ParentEmployeeNationalIDAlternateKey] "
            + "    ,[A71].[SalesTerritoryAlternateKey]"
            + "    ,[dbo].[DimEmployee].[FirstName] "
            + "    ,[dbo].[DimEmployee].[LastName] "
            + "    ,[dbo].[DimEmployee].[MiddleName] "
            + "    ,[dbo].[DimEmployee].[NameStyle] "
            + "    ,[dbo].[DimEmployee].[Title] "
            + "    ,[dbo].[DimEmployee].[HireDate] "
            + "    ,[dbo].[DimEmployee].[BirthDate] "
            + "    ,[dbo].[DimEmployee].[LoginID] "
            + "    ,[dbo].[DimEmployee].[EmailAddress] "
            + "    ,[dbo].[DimEmployee].[Phone] "
            + "    ,[dbo].[DimEmployee].[MaritalStatus] "
            + "    ,[dbo].[DimEmployee].[EmergencyContactName] "
            + "    ,[dbo].[DimEmployee].[EmergencyContactPhone] "
            + "    ,[dbo].[DimEmployee].[SalariedFlag] "
            + "    ,[dbo].[DimEmployee].[Gender] "
            + "    ,[dbo].[DimEmployee].[PayFrequency] "
            + "    ,[dbo].[DimEmployee].[BaseRate] "
            + "    ,[dbo].[DimEmployee].[VacationHours] "
            + "    ,[dbo].[DimEmployee].[SickLeaveHours] "
            + "    ,[dbo].[DimEmployee].[CurrentFlag] "
            + "    ,[dbo].[DimEmployee].[SalesPersonFlag] "
            + "    ,[dbo].[DimEmployee].[DepartmentName] "
            + "    ,[dbo].[DimEmployee].[StartDate] "
            + "    ,[dbo].[DimEmployee].[EndDate] "
            + "    ,[dbo].[DimEmployee].[Status] "
            + "FROM " 
            + "     [dbo].[DimEmployee] " 
            + "LEFT JOIN [dbo].[DimEmployee] as [A68] ON [dbo].[DimEmployee].[ParentEmployeeKey] = [A68].[ParentEmployeeKey] "
            + "LEFT JOIN [dbo].[DimSalesTerritory] as [A71] ON [dbo].[DimEmployee].[SalesTerritoryKey] = [A71].[SalesTerritoryAlternateKey] "
                + "WHERE " 
                + "     (@EmployeeKey IS NULL OR @EmployeeKey = '' OR [DimEmployee].[EmployeeKey] = LTRIM(RTRIM(@EmployeeKey))) " 
                + "AND   (@FirstName68 IS NULL OR @FirstName68 = '' OR [A68].[FirstName] = LTRIM(RTRIM(@FirstName68))) " 
                + "AND   (@EmployeeNationalIDAlternateKey IS NULL OR @EmployeeNationalIDAlternateKey = '' OR [DimEmployee].[EmployeeNationalIDAlternateKey] = LTRIM(RTRIM(@EmployeeNationalIDAlternateKey))) " 
                + "AND   (@ParentEmployeeNationalIDAlternateKey IS NULL OR @ParentEmployeeNationalIDAlternateKey = '' OR [DimEmployee].[ParentEmployeeNationalIDAlternateKey] = LTRIM(RTRIM(@ParentEmployeeNationalIDAlternateKey))) " 
                + "AND   (@SalesTerritoryAlternateKey71 IS NULL OR @SalesTerritoryAlternateKey71 = '' OR [A71].[SalesTerritoryAlternateKey] = LTRIM(RTRIM(@SalesTerritoryAlternateKey71))) " 
                + "AND   (@FirstName IS NULL OR @FirstName = '' OR [DimEmployee].[FirstName] = LTRIM(RTRIM(@FirstName))) " 
                + "AND   (@LastName IS NULL OR @LastName = '' OR [DimEmployee].[LastName] = LTRIM(RTRIM(@LastName))) " 
                + "AND   (@MiddleName IS NULL OR @MiddleName = '' OR [DimEmployee].[MiddleName] = LTRIM(RTRIM(@MiddleName))) " 
                + "AND   (@NameStyle IS NULL OR @NameStyle = '' OR [DimEmployee].[NameStyle] = LTRIM(RTRIM(@NameStyle))) " 
                + "AND   (@Title IS NULL OR @Title = '' OR [DimEmployee].[Title] = LTRIM(RTRIM(@Title))) " 
                + "AND   (@HireDate IS NULL OR @HireDate = '' OR [DimEmployee].[HireDate] = LTRIM(RTRIM(@HireDate))) " 
                + "AND   (@BirthDate IS NULL OR @BirthDate = '' OR [DimEmployee].[BirthDate] = LTRIM(RTRIM(@BirthDate))) " 
                + "AND   (@LoginID IS NULL OR @LoginID = '' OR [DimEmployee].[LoginID] = LTRIM(RTRIM(@LoginID))) " 
                + "AND   (@EmailAddress IS NULL OR @EmailAddress = '' OR [DimEmployee].[EmailAddress] = LTRIM(RTRIM(@EmailAddress))) " 
                + "AND   (@Phone IS NULL OR @Phone = '' OR [DimEmployee].[Phone] = LTRIM(RTRIM(@Phone))) " 
                + "AND   (@MaritalStatus IS NULL OR @MaritalStatus = '' OR [DimEmployee].[MaritalStatus] = LTRIM(RTRIM(@MaritalStatus))) " 
                + "AND   (@EmergencyContactName IS NULL OR @EmergencyContactName = '' OR [DimEmployee].[EmergencyContactName] = LTRIM(RTRIM(@EmergencyContactName))) " 
                + "AND   (@EmergencyContactPhone IS NULL OR @EmergencyContactPhone = '' OR [DimEmployee].[EmergencyContactPhone] = LTRIM(RTRIM(@EmergencyContactPhone))) " 
                + "AND   (@SalariedFlag IS NULL OR @SalariedFlag = '' OR [DimEmployee].[SalariedFlag] = LTRIM(RTRIM(@SalariedFlag))) " 
                + "AND   (@Gender IS NULL OR @Gender = '' OR [DimEmployee].[Gender] = LTRIM(RTRIM(@Gender))) " 
                + "AND   (@PayFrequency IS NULL OR @PayFrequency = '' OR [DimEmployee].[PayFrequency] = LTRIM(RTRIM(@PayFrequency))) " 
                + "AND   (@BaseRate IS NULL OR @BaseRate = '' OR [DimEmployee].[BaseRate] = LTRIM(RTRIM(@BaseRate))) " 
                + "AND   (@VacationHours IS NULL OR @VacationHours = '' OR [DimEmployee].[VacationHours] = LTRIM(RTRIM(@VacationHours))) " 
                + "AND   (@SickLeaveHours IS NULL OR @SickLeaveHours = '' OR [DimEmployee].[SickLeaveHours] = LTRIM(RTRIM(@SickLeaveHours))) " 
                + "AND   (@CurrentFlag IS NULL OR @CurrentFlag = '' OR [DimEmployee].[CurrentFlag] = LTRIM(RTRIM(@CurrentFlag))) " 
                + "AND   (@SalesPersonFlag IS NULL OR @SalesPersonFlag = '' OR [DimEmployee].[SalesPersonFlag] = LTRIM(RTRIM(@SalesPersonFlag))) " 
                + "AND   (@DepartmentName IS NULL OR @DepartmentName = '' OR [DimEmployee].[DepartmentName] = LTRIM(RTRIM(@DepartmentName))) " 
                + "AND   (@StartDate IS NULL OR @StartDate = '' OR [DimEmployee].[StartDate] = LTRIM(RTRIM(@StartDate))) " 
                + "AND   (@EndDate IS NULL OR @EndDate = '' OR [DimEmployee].[EndDate] = LTRIM(RTRIM(@EndDate))) " 
                + "AND   (@Status IS NULL OR @Status = '' OR [DimEmployee].[Status] = LTRIM(RTRIM(@Status))) " 
                + "";
        } else if  (sCondition == "Starts with...") {
            selectStatement
                = "SELECT "
            + "     [dbo].[DimEmployee].[EmployeeKey] "
            + "    ,[A68].[FirstName]"
            + "    ,[dbo].[DimEmployee].[EmployeeNationalIDAlternateKey] "
            + "    ,[dbo].[DimEmployee].[ParentEmployeeNationalIDAlternateKey] "
            + "    ,[A71].[SalesTerritoryAlternateKey]"
            + "    ,[dbo].[DimEmployee].[FirstName] "
            + "    ,[dbo].[DimEmployee].[LastName] "
            + "    ,[dbo].[DimEmployee].[MiddleName] "
            + "    ,[dbo].[DimEmployee].[NameStyle] "
            + "    ,[dbo].[DimEmployee].[Title] "
            + "    ,[dbo].[DimEmployee].[HireDate] "
            + "    ,[dbo].[DimEmployee].[BirthDate] "
            + "    ,[dbo].[DimEmployee].[LoginID] "
            + "    ,[dbo].[DimEmployee].[EmailAddress] "
            + "    ,[dbo].[DimEmployee].[Phone] "
            + "    ,[dbo].[DimEmployee].[MaritalStatus] "
            + "    ,[dbo].[DimEmployee].[EmergencyContactName] "
            + "    ,[dbo].[DimEmployee].[EmergencyContactPhone] "
            + "    ,[dbo].[DimEmployee].[SalariedFlag] "
            + "    ,[dbo].[DimEmployee].[Gender] "
            + "    ,[dbo].[DimEmployee].[PayFrequency] "
            + "    ,[dbo].[DimEmployee].[BaseRate] "
            + "    ,[dbo].[DimEmployee].[VacationHours] "
            + "    ,[dbo].[DimEmployee].[SickLeaveHours] "
            + "    ,[dbo].[DimEmployee].[CurrentFlag] "
            + "    ,[dbo].[DimEmployee].[SalesPersonFlag] "
            + "    ,[dbo].[DimEmployee].[DepartmentName] "
            + "    ,[dbo].[DimEmployee].[StartDate] "
            + "    ,[dbo].[DimEmployee].[EndDate] "
            + "    ,[dbo].[DimEmployee].[Status] "
            + "FROM " 
            + "     [dbo].[DimEmployee] " 
            + "LEFT JOIN [dbo].[DimEmployee] as [A68] ON [dbo].[DimEmployee].[ParentEmployeeKey] = [A68].[ParentEmployeeKey] "
            + "LEFT JOIN [dbo].[DimSalesTerritory] as [A71] ON [dbo].[DimEmployee].[SalesTerritoryKey] = [A71].[SalesTerritoryAlternateKey] "
                + "WHERE " 
                + "     (@EmployeeKey IS NULL OR @EmployeeKey = '' OR [DimEmployee].[EmployeeKey] LIKE LTRIM(RTRIM(@EmployeeKey)) + '%') " 
                + "AND   (@FirstName68 IS NULL OR @FirstName68 = '' OR [A68].[FirstName] LIKE LTRIM(RTRIM(@FirstName68)) + '%') " 
                + "AND   (@EmployeeNationalIDAlternateKey IS NULL OR @EmployeeNationalIDAlternateKey = '' OR [DimEmployee].[EmployeeNationalIDAlternateKey] LIKE LTRIM(RTRIM(@EmployeeNationalIDAlternateKey)) + '%') " 
                + "AND   (@ParentEmployeeNationalIDAlternateKey IS NULL OR @ParentEmployeeNationalIDAlternateKey = '' OR [DimEmployee].[ParentEmployeeNationalIDAlternateKey] LIKE LTRIM(RTRIM(@ParentEmployeeNationalIDAlternateKey)) + '%') " 
                + "AND   (@SalesTerritoryAlternateKey71 IS NULL OR @SalesTerritoryAlternateKey71 = '' OR [A71].[SalesTerritoryAlternateKey] LIKE LTRIM(RTRIM(@SalesTerritoryAlternateKey71)) + '%') " 
                + "AND   (@FirstName IS NULL OR @FirstName = '' OR [DimEmployee].[FirstName] LIKE LTRIM(RTRIM(@FirstName)) + '%') " 
                + "AND   (@LastName IS NULL OR @LastName = '' OR [DimEmployee].[LastName] LIKE LTRIM(RTRIM(@LastName)) + '%') " 
                + "AND   (@MiddleName IS NULL OR @MiddleName = '' OR [DimEmployee].[MiddleName] LIKE LTRIM(RTRIM(@MiddleName)) + '%') " 
                + "AND   (@NameStyle IS NULL OR @NameStyle = '' OR [DimEmployee].[NameStyle] LIKE LTRIM(RTRIM(@NameStyle)) + '%') " 
                + "AND   (@Title IS NULL OR @Title = '' OR [DimEmployee].[Title] LIKE LTRIM(RTRIM(@Title)) + '%') " 
                + "AND   (@HireDate IS NULL OR @HireDate = '' OR [DimEmployee].[HireDate] LIKE LTRIM(RTRIM(@HireDate)) + '%') " 
                + "AND   (@BirthDate IS NULL OR @BirthDate = '' OR [DimEmployee].[BirthDate] LIKE LTRIM(RTRIM(@BirthDate)) + '%') " 
                + "AND   (@LoginID IS NULL OR @LoginID = '' OR [DimEmployee].[LoginID] LIKE LTRIM(RTRIM(@LoginID)) + '%') " 
                + "AND   (@EmailAddress IS NULL OR @EmailAddress = '' OR [DimEmployee].[EmailAddress] LIKE LTRIM(RTRIM(@EmailAddress)) + '%') " 
                + "AND   (@Phone IS NULL OR @Phone = '' OR [DimEmployee].[Phone] LIKE LTRIM(RTRIM(@Phone)) + '%') " 
                + "AND   (@MaritalStatus IS NULL OR @MaritalStatus = '' OR [DimEmployee].[MaritalStatus] LIKE LTRIM(RTRIM(@MaritalStatus)) + '%') " 
                + "AND   (@EmergencyContactName IS NULL OR @EmergencyContactName = '' OR [DimEmployee].[EmergencyContactName] LIKE LTRIM(RTRIM(@EmergencyContactName)) + '%') " 
                + "AND   (@EmergencyContactPhone IS NULL OR @EmergencyContactPhone = '' OR [DimEmployee].[EmergencyContactPhone] LIKE LTRIM(RTRIM(@EmergencyContactPhone)) + '%') " 
                + "AND   (@SalariedFlag IS NULL OR @SalariedFlag = '' OR [DimEmployee].[SalariedFlag] LIKE LTRIM(RTRIM(@SalariedFlag)) + '%') " 
                + "AND   (@Gender IS NULL OR @Gender = '' OR [DimEmployee].[Gender] LIKE LTRIM(RTRIM(@Gender)) + '%') " 
                + "AND   (@PayFrequency IS NULL OR @PayFrequency = '' OR [DimEmployee].[PayFrequency] LIKE LTRIM(RTRIM(@PayFrequency)) + '%') " 
                + "AND   (@BaseRate IS NULL OR @BaseRate = '' OR [DimEmployee].[BaseRate] LIKE LTRIM(RTRIM(@BaseRate)) + '%') " 
                + "AND   (@VacationHours IS NULL OR @VacationHours = '' OR [DimEmployee].[VacationHours] LIKE LTRIM(RTRIM(@VacationHours)) + '%') " 
                + "AND   (@SickLeaveHours IS NULL OR @SickLeaveHours = '' OR [DimEmployee].[SickLeaveHours] LIKE LTRIM(RTRIM(@SickLeaveHours)) + '%') " 
                + "AND   (@CurrentFlag IS NULL OR @CurrentFlag = '' OR [DimEmployee].[CurrentFlag] LIKE LTRIM(RTRIM(@CurrentFlag)) + '%') " 
                + "AND   (@SalesPersonFlag IS NULL OR @SalesPersonFlag = '' OR [DimEmployee].[SalesPersonFlag] LIKE LTRIM(RTRIM(@SalesPersonFlag)) + '%') " 
                + "AND   (@DepartmentName IS NULL OR @DepartmentName = '' OR [DimEmployee].[DepartmentName] LIKE LTRIM(RTRIM(@DepartmentName)) + '%') " 
                + "AND   (@StartDate IS NULL OR @StartDate = '' OR [DimEmployee].[StartDate] LIKE LTRIM(RTRIM(@StartDate)) + '%') " 
                + "AND   (@EndDate IS NULL OR @EndDate = '' OR [DimEmployee].[EndDate] LIKE LTRIM(RTRIM(@EndDate)) + '%') " 
                + "AND   (@Status IS NULL OR @Status = '' OR [DimEmployee].[Status] LIKE LTRIM(RTRIM(@Status)) + '%') " 
                + "";
        } else if  (sCondition == "More than...") {
            selectStatement
                = "SELECT "
            + "     [dbo].[DimEmployee].[EmployeeKey] "
            + "    ,[A68].[FirstName]"
            + "    ,[dbo].[DimEmployee].[EmployeeNationalIDAlternateKey] "
            + "    ,[dbo].[DimEmployee].[ParentEmployeeNationalIDAlternateKey] "
            + "    ,[A71].[SalesTerritoryAlternateKey]"
            + "    ,[dbo].[DimEmployee].[FirstName] "
            + "    ,[dbo].[DimEmployee].[LastName] "
            + "    ,[dbo].[DimEmployee].[MiddleName] "
            + "    ,[dbo].[DimEmployee].[NameStyle] "
            + "    ,[dbo].[DimEmployee].[Title] "
            + "    ,[dbo].[DimEmployee].[HireDate] "
            + "    ,[dbo].[DimEmployee].[BirthDate] "
            + "    ,[dbo].[DimEmployee].[LoginID] "
            + "    ,[dbo].[DimEmployee].[EmailAddress] "
            + "    ,[dbo].[DimEmployee].[Phone] "
            + "    ,[dbo].[DimEmployee].[MaritalStatus] "
            + "    ,[dbo].[DimEmployee].[EmergencyContactName] "
            + "    ,[dbo].[DimEmployee].[EmergencyContactPhone] "
            + "    ,[dbo].[DimEmployee].[SalariedFlag] "
            + "    ,[dbo].[DimEmployee].[Gender] "
            + "    ,[dbo].[DimEmployee].[PayFrequency] "
            + "    ,[dbo].[DimEmployee].[BaseRate] "
            + "    ,[dbo].[DimEmployee].[VacationHours] "
            + "    ,[dbo].[DimEmployee].[SickLeaveHours] "
            + "    ,[dbo].[DimEmployee].[CurrentFlag] "
            + "    ,[dbo].[DimEmployee].[SalesPersonFlag] "
            + "    ,[dbo].[DimEmployee].[DepartmentName] "
            + "    ,[dbo].[DimEmployee].[StartDate] "
            + "    ,[dbo].[DimEmployee].[EndDate] "
            + "    ,[dbo].[DimEmployee].[Status] "
            + "FROM " 
            + "     [dbo].[DimEmployee] " 
            + "LEFT JOIN [dbo].[DimEmployee] as [A68] ON [dbo].[DimEmployee].[ParentEmployeeKey] = [A68].[ParentEmployeeKey] "
            + "LEFT JOIN [dbo].[DimSalesTerritory] as [A71] ON [dbo].[DimEmployee].[SalesTerritoryKey] = [A71].[SalesTerritoryAlternateKey] "
                + "WHERE " 
                + "     (@EmployeeKey IS NULL OR @EmployeeKey = '' OR [DimEmployee].[EmployeeKey] > LTRIM(RTRIM(@EmployeeKey))) " 
                + "AND   (@FirstName68 IS NULL OR @FirstName68 = '' OR [A68].[FirstName] > LTRIM(RTRIM(@FirstName68))) " 
                + "AND   (@EmployeeNationalIDAlternateKey IS NULL OR @EmployeeNationalIDAlternateKey = '' OR [DimEmployee].[EmployeeNationalIDAlternateKey] > LTRIM(RTRIM(@EmployeeNationalIDAlternateKey))) " 
                + "AND   (@ParentEmployeeNationalIDAlternateKey IS NULL OR @ParentEmployeeNationalIDAlternateKey = '' OR [DimEmployee].[ParentEmployeeNationalIDAlternateKey] > LTRIM(RTRIM(@ParentEmployeeNationalIDAlternateKey))) " 
                + "AND   (@SalesTerritoryAlternateKey71 IS NULL OR @SalesTerritoryAlternateKey71 = '' OR [A71].[SalesTerritoryAlternateKey] > LTRIM(RTRIM(@SalesTerritoryAlternateKey71))) " 
                + "AND   (@FirstName IS NULL OR @FirstName = '' OR [DimEmployee].[FirstName] > LTRIM(RTRIM(@FirstName))) " 
                + "AND   (@LastName IS NULL OR @LastName = '' OR [DimEmployee].[LastName] > LTRIM(RTRIM(@LastName))) " 
                + "AND   (@MiddleName IS NULL OR @MiddleName = '' OR [DimEmployee].[MiddleName] > LTRIM(RTRIM(@MiddleName))) " 
                + "AND   (@NameStyle IS NULL OR @NameStyle = '' OR [DimEmployee].[NameStyle] > LTRIM(RTRIM(@NameStyle))) " 
                + "AND   (@Title IS NULL OR @Title = '' OR [DimEmployee].[Title] > LTRIM(RTRIM(@Title))) " 
                + "AND   (@HireDate IS NULL OR @HireDate = '' OR [DimEmployee].[HireDate] > LTRIM(RTRIM(@HireDate))) " 
                + "AND   (@BirthDate IS NULL OR @BirthDate = '' OR [DimEmployee].[BirthDate] > LTRIM(RTRIM(@BirthDate))) " 
                + "AND   (@LoginID IS NULL OR @LoginID = '' OR [DimEmployee].[LoginID] > LTRIM(RTRIM(@LoginID))) " 
                + "AND   (@EmailAddress IS NULL OR @EmailAddress = '' OR [DimEmployee].[EmailAddress] > LTRIM(RTRIM(@EmailAddress))) " 
                + "AND   (@Phone IS NULL OR @Phone = '' OR [DimEmployee].[Phone] > LTRIM(RTRIM(@Phone))) " 
                + "AND   (@MaritalStatus IS NULL OR @MaritalStatus = '' OR [DimEmployee].[MaritalStatus] > LTRIM(RTRIM(@MaritalStatus))) " 
                + "AND   (@EmergencyContactName IS NULL OR @EmergencyContactName = '' OR [DimEmployee].[EmergencyContactName] > LTRIM(RTRIM(@EmergencyContactName))) " 
                + "AND   (@EmergencyContactPhone IS NULL OR @EmergencyContactPhone = '' OR [DimEmployee].[EmergencyContactPhone] > LTRIM(RTRIM(@EmergencyContactPhone))) " 
                + "AND   (@SalariedFlag IS NULL OR @SalariedFlag = '' OR [DimEmployee].[SalariedFlag] > LTRIM(RTRIM(@SalariedFlag))) " 
                + "AND   (@Gender IS NULL OR @Gender = '' OR [DimEmployee].[Gender] > LTRIM(RTRIM(@Gender))) " 
                + "AND   (@PayFrequency IS NULL OR @PayFrequency = '' OR [DimEmployee].[PayFrequency] > LTRIM(RTRIM(@PayFrequency))) " 
                + "AND   (@BaseRate IS NULL OR @BaseRate = '' OR [DimEmployee].[BaseRate] > LTRIM(RTRIM(@BaseRate))) " 
                + "AND   (@VacationHours IS NULL OR @VacationHours = '' OR [DimEmployee].[VacationHours] > LTRIM(RTRIM(@VacationHours))) " 
                + "AND   (@SickLeaveHours IS NULL OR @SickLeaveHours = '' OR [DimEmployee].[SickLeaveHours] > LTRIM(RTRIM(@SickLeaveHours))) " 
                + "AND   (@CurrentFlag IS NULL OR @CurrentFlag = '' OR [DimEmployee].[CurrentFlag] > LTRIM(RTRIM(@CurrentFlag))) " 
                + "AND   (@SalesPersonFlag IS NULL OR @SalesPersonFlag = '' OR [DimEmployee].[SalesPersonFlag] > LTRIM(RTRIM(@SalesPersonFlag))) " 
                + "AND   (@DepartmentName IS NULL OR @DepartmentName = '' OR [DimEmployee].[DepartmentName] > LTRIM(RTRIM(@DepartmentName))) " 
                + "AND   (@StartDate IS NULL OR @StartDate = '' OR [DimEmployee].[StartDate] > LTRIM(RTRIM(@StartDate))) " 
                + "AND   (@EndDate IS NULL OR @EndDate = '' OR [DimEmployee].[EndDate] > LTRIM(RTRIM(@EndDate))) " 
                + "AND   (@Status IS NULL OR @Status = '' OR [DimEmployee].[Status] > LTRIM(RTRIM(@Status))) " 
                + "";
        } else if  (sCondition == "Less than...") {
            selectStatement
                = "SELECT " 
            + "     [dbo].[DimEmployee].[EmployeeKey] "
            + "    ,[A68].[FirstName]"
            + "    ,[dbo].[DimEmployee].[EmployeeNationalIDAlternateKey] "
            + "    ,[dbo].[DimEmployee].[ParentEmployeeNationalIDAlternateKey] "
            + "    ,[A71].[SalesTerritoryAlternateKey]"
            + "    ,[dbo].[DimEmployee].[FirstName] "
            + "    ,[dbo].[DimEmployee].[LastName] "
            + "    ,[dbo].[DimEmployee].[MiddleName] "
            + "    ,[dbo].[DimEmployee].[NameStyle] "
            + "    ,[dbo].[DimEmployee].[Title] "
            + "    ,[dbo].[DimEmployee].[HireDate] "
            + "    ,[dbo].[DimEmployee].[BirthDate] "
            + "    ,[dbo].[DimEmployee].[LoginID] "
            + "    ,[dbo].[DimEmployee].[EmailAddress] "
            + "    ,[dbo].[DimEmployee].[Phone] "
            + "    ,[dbo].[DimEmployee].[MaritalStatus] "
            + "    ,[dbo].[DimEmployee].[EmergencyContactName] "
            + "    ,[dbo].[DimEmployee].[EmergencyContactPhone] "
            + "    ,[dbo].[DimEmployee].[SalariedFlag] "
            + "    ,[dbo].[DimEmployee].[Gender] "
            + "    ,[dbo].[DimEmployee].[PayFrequency] "
            + "    ,[dbo].[DimEmployee].[BaseRate] "
            + "    ,[dbo].[DimEmployee].[VacationHours] "
            + "    ,[dbo].[DimEmployee].[SickLeaveHours] "
            + "    ,[dbo].[DimEmployee].[CurrentFlag] "
            + "    ,[dbo].[DimEmployee].[SalesPersonFlag] "
            + "    ,[dbo].[DimEmployee].[DepartmentName] "
            + "    ,[dbo].[DimEmployee].[StartDate] "
            + "    ,[dbo].[DimEmployee].[EndDate] "
            + "    ,[dbo].[DimEmployee].[Status] "
            + "FROM " 
            + "     [dbo].[DimEmployee] " 
            + "LEFT JOIN [dbo].[DimEmployee] as [A68] ON [dbo].[DimEmployee].[ParentEmployeeKey] = [A68].[ParentEmployeeKey] "
            + "LEFT JOIN [dbo].[DimSalesTerritory] as [A71] ON [dbo].[DimEmployee].[SalesTerritoryKey] = [A71].[SalesTerritoryAlternateKey] "
                + "WHERE " 
                + "     (@EmployeeKey IS NULL OR @EmployeeKey = '' OR [DimEmployee].[EmployeeKey] < LTRIM(RTRIM(@EmployeeKey))) " 
                + "AND   (@FirstName68 IS NULL OR @FirstName68 = '' OR [A68].[FirstName] < LTRIM(RTRIM(@FirstName68))) " 
                + "AND   (@EmployeeNationalIDAlternateKey IS NULL OR @EmployeeNationalIDAlternateKey = '' OR [DimEmployee].[EmployeeNationalIDAlternateKey] < LTRIM(RTRIM(@EmployeeNationalIDAlternateKey))) " 
                + "AND   (@ParentEmployeeNationalIDAlternateKey IS NULL OR @ParentEmployeeNationalIDAlternateKey = '' OR [DimEmployee].[ParentEmployeeNationalIDAlternateKey] < LTRIM(RTRIM(@ParentEmployeeNationalIDAlternateKey))) " 
                + "AND   (@SalesTerritoryAlternateKey71 IS NULL OR @SalesTerritoryAlternateKey71 = '' OR [A71].[SalesTerritoryAlternateKey] < LTRIM(RTRIM(@SalesTerritoryAlternateKey71))) " 
                + "AND   (@FirstName IS NULL OR @FirstName = '' OR [DimEmployee].[FirstName] < LTRIM(RTRIM(@FirstName))) " 
                + "AND   (@LastName IS NULL OR @LastName = '' OR [DimEmployee].[LastName] < LTRIM(RTRIM(@LastName))) " 
                + "AND   (@MiddleName IS NULL OR @MiddleName = '' OR [DimEmployee].[MiddleName] < LTRIM(RTRIM(@MiddleName))) " 
                + "AND   (@NameStyle IS NULL OR @NameStyle = '' OR [DimEmployee].[NameStyle] < LTRIM(RTRIM(@NameStyle))) " 
                + "AND   (@Title IS NULL OR @Title = '' OR [DimEmployee].[Title] < LTRIM(RTRIM(@Title))) " 
                + "AND   (@HireDate IS NULL OR @HireDate = '' OR [DimEmployee].[HireDate] < LTRIM(RTRIM(@HireDate))) " 
                + "AND   (@BirthDate IS NULL OR @BirthDate = '' OR [DimEmployee].[BirthDate] < LTRIM(RTRIM(@BirthDate))) " 
                + "AND   (@LoginID IS NULL OR @LoginID = '' OR [DimEmployee].[LoginID] < LTRIM(RTRIM(@LoginID))) " 
                + "AND   (@EmailAddress IS NULL OR @EmailAddress = '' OR [DimEmployee].[EmailAddress] < LTRIM(RTRIM(@EmailAddress))) " 
                + "AND   (@Phone IS NULL OR @Phone = '' OR [DimEmployee].[Phone] < LTRIM(RTRIM(@Phone))) " 
                + "AND   (@MaritalStatus IS NULL OR @MaritalStatus = '' OR [DimEmployee].[MaritalStatus] < LTRIM(RTRIM(@MaritalStatus))) " 
                + "AND   (@EmergencyContactName IS NULL OR @EmergencyContactName = '' OR [DimEmployee].[EmergencyContactName] < LTRIM(RTRIM(@EmergencyContactName))) " 
                + "AND   (@EmergencyContactPhone IS NULL OR @EmergencyContactPhone = '' OR [DimEmployee].[EmergencyContactPhone] < LTRIM(RTRIM(@EmergencyContactPhone))) " 
                + "AND   (@SalariedFlag IS NULL OR @SalariedFlag = '' OR [DimEmployee].[SalariedFlag] < LTRIM(RTRIM(@SalariedFlag))) " 
                + "AND   (@Gender IS NULL OR @Gender = '' OR [DimEmployee].[Gender] < LTRIM(RTRIM(@Gender))) " 
                + "AND   (@PayFrequency IS NULL OR @PayFrequency = '' OR [DimEmployee].[PayFrequency] < LTRIM(RTRIM(@PayFrequency))) " 
                + "AND   (@BaseRate IS NULL OR @BaseRate = '' OR [DimEmployee].[BaseRate] < LTRIM(RTRIM(@BaseRate))) " 
                + "AND   (@VacationHours IS NULL OR @VacationHours = '' OR [DimEmployee].[VacationHours] < LTRIM(RTRIM(@VacationHours))) " 
                + "AND   (@SickLeaveHours IS NULL OR @SickLeaveHours = '' OR [DimEmployee].[SickLeaveHours] < LTRIM(RTRIM(@SickLeaveHours))) " 
                + "AND   (@CurrentFlag IS NULL OR @CurrentFlag = '' OR [DimEmployee].[CurrentFlag] < LTRIM(RTRIM(@CurrentFlag))) " 
                + "AND   (@SalesPersonFlag IS NULL OR @SalesPersonFlag = '' OR [DimEmployee].[SalesPersonFlag] < LTRIM(RTRIM(@SalesPersonFlag))) " 
                + "AND   (@DepartmentName IS NULL OR @DepartmentName = '' OR [DimEmployee].[DepartmentName] < LTRIM(RTRIM(@DepartmentName))) " 
                + "AND   (@StartDate IS NULL OR @StartDate = '' OR [DimEmployee].[StartDate] < LTRIM(RTRIM(@StartDate))) " 
                + "AND   (@EndDate IS NULL OR @EndDate = '' OR [DimEmployee].[EndDate] < LTRIM(RTRIM(@EndDate))) " 
                + "AND   (@Status IS NULL OR @Status = '' OR [DimEmployee].[Status] < LTRIM(RTRIM(@Status))) " 
                + "";
        } else if  (sCondition == "Equal or more than...") {
            selectStatement
                = "SELECT "
            + "     [dbo].[DimEmployee].[EmployeeKey] "
            + "    ,[A68].[FirstName]"
            + "    ,[dbo].[DimEmployee].[EmployeeNationalIDAlternateKey] "
            + "    ,[dbo].[DimEmployee].[ParentEmployeeNationalIDAlternateKey] "
            + "    ,[A71].[SalesTerritoryAlternateKey]"
            + "    ,[dbo].[DimEmployee].[FirstName] "
            + "    ,[dbo].[DimEmployee].[LastName] "
            + "    ,[dbo].[DimEmployee].[MiddleName] "
            + "    ,[dbo].[DimEmployee].[NameStyle] "
            + "    ,[dbo].[DimEmployee].[Title] "
            + "    ,[dbo].[DimEmployee].[HireDate] "
            + "    ,[dbo].[DimEmployee].[BirthDate] "
            + "    ,[dbo].[DimEmployee].[LoginID] "
            + "    ,[dbo].[DimEmployee].[EmailAddress] "
            + "    ,[dbo].[DimEmployee].[Phone] "
            + "    ,[dbo].[DimEmployee].[MaritalStatus] "
            + "    ,[dbo].[DimEmployee].[EmergencyContactName] "
            + "    ,[dbo].[DimEmployee].[EmergencyContactPhone] "
            + "    ,[dbo].[DimEmployee].[SalariedFlag] "
            + "    ,[dbo].[DimEmployee].[Gender] "
            + "    ,[dbo].[DimEmployee].[PayFrequency] "
            + "    ,[dbo].[DimEmployee].[BaseRate] "
            + "    ,[dbo].[DimEmployee].[VacationHours] "
            + "    ,[dbo].[DimEmployee].[SickLeaveHours] "
            + "    ,[dbo].[DimEmployee].[CurrentFlag] "
            + "    ,[dbo].[DimEmployee].[SalesPersonFlag] "
            + "    ,[dbo].[DimEmployee].[DepartmentName] "
            + "    ,[dbo].[DimEmployee].[StartDate] "
            + "    ,[dbo].[DimEmployee].[EndDate] "
            + "    ,[dbo].[DimEmployee].[Status] "
            + "FROM " 
            + "     [dbo].[DimEmployee] " 
            + "LEFT JOIN [dbo].[DimEmployee] as [A68] ON [dbo].[DimEmployee].[ParentEmployeeKey] = [A68].[ParentEmployeeKey] "
            + "LEFT JOIN [dbo].[DimSalesTerritory] as [A71] ON [dbo].[DimEmployee].[SalesTerritoryKey] = [A71].[SalesTerritoryAlternateKey] "
                + "WHERE " 
                + "     (@EmployeeKey IS NULL OR @EmployeeKey = '' OR [DimEmployee].[EmployeeKey] >= LTRIM(RTRIM(@EmployeeKey))) " 
                + "AND   (@FirstName68 IS NULL OR @FirstName68 = '' OR [A68].[FirstName] >= LTRIM(RTRIM(@FirstName68))) " 
                + "AND   (@EmployeeNationalIDAlternateKey IS NULL OR @EmployeeNationalIDAlternateKey = '' OR [DimEmployee].[EmployeeNationalIDAlternateKey] >= LTRIM(RTRIM(@EmployeeNationalIDAlternateKey))) " 
                + "AND   (@ParentEmployeeNationalIDAlternateKey IS NULL OR @ParentEmployeeNationalIDAlternateKey = '' OR [DimEmployee].[ParentEmployeeNationalIDAlternateKey] >= LTRIM(RTRIM(@ParentEmployeeNationalIDAlternateKey))) " 
                + "AND   (@SalesTerritoryAlternateKey71 IS NULL OR @SalesTerritoryAlternateKey71 = '' OR [A71].[SalesTerritoryAlternateKey] >= LTRIM(RTRIM(@SalesTerritoryAlternateKey71))) " 
                + "AND   (@FirstName IS NULL OR @FirstName = '' OR [DimEmployee].[FirstName] >= LTRIM(RTRIM(@FirstName))) " 
                + "AND   (@LastName IS NULL OR @LastName = '' OR [DimEmployee].[LastName] >= LTRIM(RTRIM(@LastName))) " 
                + "AND   (@MiddleName IS NULL OR @MiddleName = '' OR [DimEmployee].[MiddleName] >= LTRIM(RTRIM(@MiddleName))) " 
                + "AND   (@NameStyle IS NULL OR @NameStyle = '' OR [DimEmployee].[NameStyle] >= LTRIM(RTRIM(@NameStyle))) " 
                + "AND   (@Title IS NULL OR @Title = '' OR [DimEmployee].[Title] >= LTRIM(RTRIM(@Title))) " 
                + "AND   (@HireDate IS NULL OR @HireDate = '' OR [DimEmployee].[HireDate] >= LTRIM(RTRIM(@HireDate))) " 
                + "AND   (@BirthDate IS NULL OR @BirthDate = '' OR [DimEmployee].[BirthDate] >= LTRIM(RTRIM(@BirthDate))) " 
                + "AND   (@LoginID IS NULL OR @LoginID = '' OR [DimEmployee].[LoginID] >= LTRIM(RTRIM(@LoginID))) " 
                + "AND   (@EmailAddress IS NULL OR @EmailAddress = '' OR [DimEmployee].[EmailAddress] >= LTRIM(RTRIM(@EmailAddress))) " 
                + "AND   (@Phone IS NULL OR @Phone = '' OR [DimEmployee].[Phone] >= LTRIM(RTRIM(@Phone))) " 
                + "AND   (@MaritalStatus IS NULL OR @MaritalStatus = '' OR [DimEmployee].[MaritalStatus] >= LTRIM(RTRIM(@MaritalStatus))) " 
                + "AND   (@EmergencyContactName IS NULL OR @EmergencyContactName = '' OR [DimEmployee].[EmergencyContactName] >= LTRIM(RTRIM(@EmergencyContactName))) " 
                + "AND   (@EmergencyContactPhone IS NULL OR @EmergencyContactPhone = '' OR [DimEmployee].[EmergencyContactPhone] >= LTRIM(RTRIM(@EmergencyContactPhone))) " 
                + "AND   (@SalariedFlag IS NULL OR @SalariedFlag = '' OR [DimEmployee].[SalariedFlag] >= LTRIM(RTRIM(@SalariedFlag))) " 
                + "AND   (@Gender IS NULL OR @Gender = '' OR [DimEmployee].[Gender] >= LTRIM(RTRIM(@Gender))) " 
                + "AND   (@PayFrequency IS NULL OR @PayFrequency = '' OR [DimEmployee].[PayFrequency] >= LTRIM(RTRIM(@PayFrequency))) " 
                + "AND   (@BaseRate IS NULL OR @BaseRate = '' OR [DimEmployee].[BaseRate] >= LTRIM(RTRIM(@BaseRate))) " 
                + "AND   (@VacationHours IS NULL OR @VacationHours = '' OR [DimEmployee].[VacationHours] >= LTRIM(RTRIM(@VacationHours))) " 
                + "AND   (@SickLeaveHours IS NULL OR @SickLeaveHours = '' OR [DimEmployee].[SickLeaveHours] >= LTRIM(RTRIM(@SickLeaveHours))) " 
                + "AND   (@CurrentFlag IS NULL OR @CurrentFlag = '' OR [DimEmployee].[CurrentFlag] >= LTRIM(RTRIM(@CurrentFlag))) " 
                + "AND   (@SalesPersonFlag IS NULL OR @SalesPersonFlag = '' OR [DimEmployee].[SalesPersonFlag] >= LTRIM(RTRIM(@SalesPersonFlag))) " 
                + "AND   (@DepartmentName IS NULL OR @DepartmentName = '' OR [DimEmployee].[DepartmentName] >= LTRIM(RTRIM(@DepartmentName))) " 
                + "AND   (@StartDate IS NULL OR @StartDate = '' OR [DimEmployee].[StartDate] >= LTRIM(RTRIM(@StartDate))) " 
                + "AND   (@EndDate IS NULL OR @EndDate = '' OR [DimEmployee].[EndDate] >= LTRIM(RTRIM(@EndDate))) " 
                + "AND   (@Status IS NULL OR @Status = '' OR [DimEmployee].[Status] >= LTRIM(RTRIM(@Status))) " 
                + "";
        } else if (sCondition == "Equal or less than...") {
            selectStatement 
                = "SELECT "
            + "     [dbo].[DimEmployee].[EmployeeKey] "
            + "    ,[A68].[FirstName]"
            + "    ,[dbo].[DimEmployee].[EmployeeNationalIDAlternateKey] "
            + "    ,[dbo].[DimEmployee].[ParentEmployeeNationalIDAlternateKey] "
            + "    ,[A71].[SalesTerritoryAlternateKey]"
            + "    ,[dbo].[DimEmployee].[FirstName] "
            + "    ,[dbo].[DimEmployee].[LastName] "
            + "    ,[dbo].[DimEmployee].[MiddleName] "
            + "    ,[dbo].[DimEmployee].[NameStyle] "
            + "    ,[dbo].[DimEmployee].[Title] "
            + "    ,[dbo].[DimEmployee].[HireDate] "
            + "    ,[dbo].[DimEmployee].[BirthDate] "
            + "    ,[dbo].[DimEmployee].[LoginID] "
            + "    ,[dbo].[DimEmployee].[EmailAddress] "
            + "    ,[dbo].[DimEmployee].[Phone] "
            + "    ,[dbo].[DimEmployee].[MaritalStatus] "
            + "    ,[dbo].[DimEmployee].[EmergencyContactName] "
            + "    ,[dbo].[DimEmployee].[EmergencyContactPhone] "
            + "    ,[dbo].[DimEmployee].[SalariedFlag] "
            + "    ,[dbo].[DimEmployee].[Gender] "
            + "    ,[dbo].[DimEmployee].[PayFrequency] "
            + "    ,[dbo].[DimEmployee].[BaseRate] "
            + "    ,[dbo].[DimEmployee].[VacationHours] "
            + "    ,[dbo].[DimEmployee].[SickLeaveHours] "
            + "    ,[dbo].[DimEmployee].[CurrentFlag] "
            + "    ,[dbo].[DimEmployee].[SalesPersonFlag] "
            + "    ,[dbo].[DimEmployee].[DepartmentName] "
            + "    ,[dbo].[DimEmployee].[StartDate] "
            + "    ,[dbo].[DimEmployee].[EndDate] "
            + "    ,[dbo].[DimEmployee].[Status] "
            + "FROM " 
            + "     [dbo].[DimEmployee] " 
            + "LEFT JOIN [dbo].[DimEmployee] as [A68] ON [dbo].[DimEmployee].[ParentEmployeeKey] = [A68].[ParentEmployeeKey] "
            + "LEFT JOIN [dbo].[DimSalesTerritory] as [A71] ON [dbo].[DimEmployee].[SalesTerritoryKey] = [A71].[SalesTerritoryAlternateKey] "
                + "WHERE " 
                + "     (@EmployeeKey IS NULL OR @EmployeeKey = '' OR [DimEmployee].[EmployeeKey] <= LTRIM(RTRIM(@EmployeeKey))) " 
                + "AND   (@FirstName68 IS NULL OR @FirstName68 = '' OR [A68].[FirstName] <= LTRIM(RTRIM(@FirstName68))) " 
                + "AND   (@EmployeeNationalIDAlternateKey IS NULL OR @EmployeeNationalIDAlternateKey = '' OR [DimEmployee].[EmployeeNationalIDAlternateKey] <= LTRIM(RTRIM(@EmployeeNationalIDAlternateKey))) " 
                + "AND   (@ParentEmployeeNationalIDAlternateKey IS NULL OR @ParentEmployeeNationalIDAlternateKey = '' OR [DimEmployee].[ParentEmployeeNationalIDAlternateKey] <= LTRIM(RTRIM(@ParentEmployeeNationalIDAlternateKey))) " 
                + "AND   (@SalesTerritoryAlternateKey71 IS NULL OR @SalesTerritoryAlternateKey71 = '' OR [A71].[SalesTerritoryAlternateKey] <= LTRIM(RTRIM(@SalesTerritoryAlternateKey71))) " 
                + "AND   (@FirstName IS NULL OR @FirstName = '' OR [DimEmployee].[FirstName] <= LTRIM(RTRIM(@FirstName))) " 
                + "AND   (@LastName IS NULL OR @LastName = '' OR [DimEmployee].[LastName] <= LTRIM(RTRIM(@LastName))) " 
                + "AND   (@MiddleName IS NULL OR @MiddleName = '' OR [DimEmployee].[MiddleName] <= LTRIM(RTRIM(@MiddleName))) " 
                + "AND   (@NameStyle IS NULL OR @NameStyle = '' OR [DimEmployee].[NameStyle] <= LTRIM(RTRIM(@NameStyle))) " 
                + "AND   (@Title IS NULL OR @Title = '' OR [DimEmployee].[Title] <= LTRIM(RTRIM(@Title))) " 
                + "AND   (@HireDate IS NULL OR @HireDate = '' OR [DimEmployee].[HireDate] <= LTRIM(RTRIM(@HireDate))) " 
                + "AND   (@BirthDate IS NULL OR @BirthDate = '' OR [DimEmployee].[BirthDate] <= LTRIM(RTRIM(@BirthDate))) " 
                + "AND   (@LoginID IS NULL OR @LoginID = '' OR [DimEmployee].[LoginID] <= LTRIM(RTRIM(@LoginID))) " 
                + "AND   (@EmailAddress IS NULL OR @EmailAddress = '' OR [DimEmployee].[EmailAddress] <= LTRIM(RTRIM(@EmailAddress))) " 
                + "AND   (@Phone IS NULL OR @Phone = '' OR [DimEmployee].[Phone] <= LTRIM(RTRIM(@Phone))) " 
                + "AND   (@MaritalStatus IS NULL OR @MaritalStatus = '' OR [DimEmployee].[MaritalStatus] <= LTRIM(RTRIM(@MaritalStatus))) " 
                + "AND   (@EmergencyContactName IS NULL OR @EmergencyContactName = '' OR [DimEmployee].[EmergencyContactName] <= LTRIM(RTRIM(@EmergencyContactName))) " 
                + "AND   (@EmergencyContactPhone IS NULL OR @EmergencyContactPhone = '' OR [DimEmployee].[EmergencyContactPhone] <= LTRIM(RTRIM(@EmergencyContactPhone))) " 
                + "AND   (@SalariedFlag IS NULL OR @SalariedFlag = '' OR [DimEmployee].[SalariedFlag] <= LTRIM(RTRIM(@SalariedFlag))) " 
                + "AND   (@Gender IS NULL OR @Gender = '' OR [DimEmployee].[Gender] <= LTRIM(RTRIM(@Gender))) " 
                + "AND   (@PayFrequency IS NULL OR @PayFrequency = '' OR [DimEmployee].[PayFrequency] <= LTRIM(RTRIM(@PayFrequency))) " 
                + "AND   (@BaseRate IS NULL OR @BaseRate = '' OR [DimEmployee].[BaseRate] <= LTRIM(RTRIM(@BaseRate))) " 
                + "AND   (@VacationHours IS NULL OR @VacationHours = '' OR [DimEmployee].[VacationHours] <= LTRIM(RTRIM(@VacationHours))) " 
                + "AND   (@SickLeaveHours IS NULL OR @SickLeaveHours = '' OR [DimEmployee].[SickLeaveHours] <= LTRIM(RTRIM(@SickLeaveHours))) " 
                + "AND   (@CurrentFlag IS NULL OR @CurrentFlag = '' OR [DimEmployee].[CurrentFlag] <= LTRIM(RTRIM(@CurrentFlag))) " 
                + "AND   (@SalesPersonFlag IS NULL OR @SalesPersonFlag = '' OR [DimEmployee].[SalesPersonFlag] <= LTRIM(RTRIM(@SalesPersonFlag))) " 
                + "AND   (@DepartmentName IS NULL OR @DepartmentName = '' OR [DimEmployee].[DepartmentName] <= LTRIM(RTRIM(@DepartmentName))) " 
                + "AND   (@StartDate IS NULL OR @StartDate = '' OR [DimEmployee].[StartDate] <= LTRIM(RTRIM(@StartDate))) " 
                + "AND   (@EndDate IS NULL OR @EndDate = '' OR [DimEmployee].[EndDate] <= LTRIM(RTRIM(@EndDate))) " 
                + "AND   (@Status IS NULL OR @Status = '' OR [DimEmployee].[Status] <= LTRIM(RTRIM(@Status))) " 
                + "";
        }
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        selectCommand.CommandType = CommandType.Text;
        if (sField == "Employee Key") {
            selectCommand.Parameters.AddWithValue("@EmployeeKey", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@EmployeeKey", DBNull.Value); }
        if (sField == "Parent Employee Key") {
            selectCommand.Parameters.AddWithValue("@FirstName68", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@FirstName68", DBNull.Value); }
        if (sField == "Employee National I D Alternate Key") {
            selectCommand.Parameters.AddWithValue("@EmployeeNationalIDAlternateKey", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@EmployeeNationalIDAlternateKey", DBNull.Value); }
        if (sField == "Parent Employee National I D Alternate Key") {
            selectCommand.Parameters.AddWithValue("@ParentEmployeeNationalIDAlternateKey", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@ParentEmployeeNationalIDAlternateKey", DBNull.Value); }
        if (sField == "Sales Territory Key") {
            selectCommand.Parameters.AddWithValue("@SalesTerritoryAlternateKey71", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@SalesTerritoryAlternateKey71", DBNull.Value); }
        if (sField == "First Name") {
            selectCommand.Parameters.AddWithValue("@FirstName", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@FirstName", DBNull.Value); }
        if (sField == "Last Name") {
            selectCommand.Parameters.AddWithValue("@LastName", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@LastName", DBNull.Value); }
        if (sField == "Middle Name") {
            selectCommand.Parameters.AddWithValue("@MiddleName", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@MiddleName", DBNull.Value); }
        if (sField == "Name Style") {
            selectCommand.Parameters.AddWithValue("@NameStyle", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@NameStyle", DBNull.Value); }
        if (sField == "Title") {
            selectCommand.Parameters.AddWithValue("@Title", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@Title", DBNull.Value); }
        if (sField == "Hire Date") {
            selectCommand.Parameters.AddWithValue("@HireDate", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@HireDate", DBNull.Value); }
        if (sField == "Birth Date") {
            selectCommand.Parameters.AddWithValue("@BirthDate", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@BirthDate", DBNull.Value); }
        if (sField == "Login I D") {
            selectCommand.Parameters.AddWithValue("@LoginID", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@LoginID", DBNull.Value); }
        if (sField == "Email Address") {
            selectCommand.Parameters.AddWithValue("@EmailAddress", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@EmailAddress", DBNull.Value); }
        if (sField == "Phone") {
            selectCommand.Parameters.AddWithValue("@Phone", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@Phone", DBNull.Value); }
        if (sField == "Marital Status") {
            selectCommand.Parameters.AddWithValue("@MaritalStatus", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@MaritalStatus", DBNull.Value); }
        if (sField == "Emergency Contact Name") {
            selectCommand.Parameters.AddWithValue("@EmergencyContactName", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@EmergencyContactName", DBNull.Value); }
        if (sField == "Emergency Contact Phone") {
            selectCommand.Parameters.AddWithValue("@EmergencyContactPhone", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@EmergencyContactPhone", DBNull.Value); }
        if (sField == "Salaried Flag") {
            selectCommand.Parameters.AddWithValue("@SalariedFlag", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@SalariedFlag", DBNull.Value); }
        if (sField == "Gender") {
            selectCommand.Parameters.AddWithValue("@Gender", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@Gender", DBNull.Value); }
        if (sField == "Pay Frequency") {
            selectCommand.Parameters.AddWithValue("@PayFrequency", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@PayFrequency", DBNull.Value); }
        if (sField == "Base Rate") {
            selectCommand.Parameters.AddWithValue("@BaseRate", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@BaseRate", DBNull.Value); }
        if (sField == "Vacation Hours") {
            selectCommand.Parameters.AddWithValue("@VacationHours", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@VacationHours", DBNull.Value); }
        if (sField == "Sick Leave Hours") {
            selectCommand.Parameters.AddWithValue("@SickLeaveHours", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@SickLeaveHours", DBNull.Value); }
        if (sField == "Current Flag") {
            selectCommand.Parameters.AddWithValue("@CurrentFlag", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@CurrentFlag", DBNull.Value); }
        if (sField == "Sales Person Flag") {
            selectCommand.Parameters.AddWithValue("@SalesPersonFlag", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@SalesPersonFlag", DBNull.Value); }
        if (sField == "Department Name") {
            selectCommand.Parameters.AddWithValue("@DepartmentName", sValue);
        } else {
            selectCommand.Parameters.AddWithValue("@DepartmentName", DBNull.Value); }
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

    public static dbo_DimEmployeeClass Select_Record(dbo_DimEmployeeClass clsdbo_DimEmployeePara)
    {
        dbo_DimEmployeeClass clsdbo_DimEmployee = new dbo_DimEmployeeClass();
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement
            = "SELECT " 
            + "     [EmployeeKey] "
            + "    ,[ParentEmployeeKey] "
            + "    ,[EmployeeNationalIDAlternateKey] "
            + "    ,[ParentEmployeeNationalIDAlternateKey] "
            + "    ,[SalesTerritoryKey] "
            + "    ,[FirstName] "
            + "    ,[LastName] "
            + "    ,[MiddleName] "
            + "    ,[NameStyle] "
            + "    ,[Title] "
            + "    ,[HireDate] "
            + "    ,[BirthDate] "
            + "    ,[LoginID] "
            + "    ,[EmailAddress] "
            + "    ,[Phone] "
            + "    ,[MaritalStatus] "
            + "    ,[EmergencyContactName] "
            + "    ,[EmergencyContactPhone] "
            + "    ,[SalariedFlag] "
            + "    ,[Gender] "
            + "    ,[PayFrequency] "
            + "    ,[BaseRate] "
            + "    ,[VacationHours] "
            + "    ,[SickLeaveHours] "
            + "    ,[CurrentFlag] "
            + "    ,[SalesPersonFlag] "
            + "    ,[DepartmentName] "
            + "    ,[StartDate] "
            + "    ,[EndDate] "
            + "    ,[Status] "
            + "FROM "
            + "     [dbo].[DimEmployee] "
            + "WHERE "
            + "     [EmployeeKey] = @EmployeeKey "
            + "";
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        selectCommand.CommandType = CommandType.Text;
        selectCommand.Parameters.AddWithValue("@EmployeeKey", clsdbo_DimEmployeePara.EmployeeKey);
        try
        {
            connection.Open();
            SqlDataReader reader
                = selectCommand.ExecuteReader(CommandBehavior.SingleRow);
            if (reader.Read())
            {
                clsdbo_DimEmployee.EmployeeKey = System.Convert.ToInt32(reader["EmployeeKey"]);
                clsdbo_DimEmployee.ParentEmployeeKey = reader["ParentEmployeeKey"] is DBNull ? null : (Int32?)reader["ParentEmployeeKey"];
                clsdbo_DimEmployee.EmployeeNationalIDAlternateKey = reader["EmployeeNationalIDAlternateKey"] is DBNull ? null : reader["EmployeeNationalIDAlternateKey"].ToString();
                clsdbo_DimEmployee.ParentEmployeeNationalIDAlternateKey = reader["ParentEmployeeNationalIDAlternateKey"] is DBNull ? null : reader["ParentEmployeeNationalIDAlternateKey"].ToString();
                clsdbo_DimEmployee.SalesTerritoryKey = reader["SalesTerritoryKey"] is DBNull ? null : (Int32?)reader["SalesTerritoryKey"];
                clsdbo_DimEmployee.FirstName = System.Convert.ToString(reader["FirstName"]);
                clsdbo_DimEmployee.LastName = System.Convert.ToString(reader["LastName"]);
                clsdbo_DimEmployee.MiddleName = reader["MiddleName"] is DBNull ? null : reader["MiddleName"].ToString();
                clsdbo_DimEmployee.NameStyle = System.Convert.ToBoolean(reader["NameStyle"]);
                clsdbo_DimEmployee.Title = reader["Title"] is DBNull ? null : reader["Title"].ToString();
                clsdbo_DimEmployee.HireDate = reader["HireDate"] is DBNull ? null : (DateTime?)reader["HireDate"];
                clsdbo_DimEmployee.BirthDate = reader["BirthDate"] is DBNull ? null : (DateTime?)reader["BirthDate"];
                clsdbo_DimEmployee.LoginID = reader["LoginID"] is DBNull ? null : reader["LoginID"].ToString();
                clsdbo_DimEmployee.EmailAddress = reader["EmailAddress"] is DBNull ? null : reader["EmailAddress"].ToString();
                clsdbo_DimEmployee.Phone = reader["Phone"] is DBNull ? null : reader["Phone"].ToString();
                clsdbo_DimEmployee.MaritalStatus = reader["MaritalStatus"] is DBNull ? null : reader["MaritalStatus"].ToString();
                clsdbo_DimEmployee.EmergencyContactName = reader["EmergencyContactName"] is DBNull ? null : reader["EmergencyContactName"].ToString();
                clsdbo_DimEmployee.EmergencyContactPhone = reader["EmergencyContactPhone"] is DBNull ? null : reader["EmergencyContactPhone"].ToString();
                clsdbo_DimEmployee.SalariedFlag = reader["SalariedFlag"] is DBNull ? null : (Boolean?)reader["SalariedFlag"];
                clsdbo_DimEmployee.Gender = reader["Gender"] is DBNull ? null : reader["Gender"].ToString();
                clsdbo_DimEmployee.PayFrequency = reader["PayFrequency"] is DBNull ? null : (Byte?)reader["PayFrequency"];
                clsdbo_DimEmployee.BaseRate = reader["BaseRate"] is DBNull ? null : (Decimal?)reader["BaseRate"];
                clsdbo_DimEmployee.VacationHours = reader["VacationHours"] is DBNull ? null : (Int16?)reader["VacationHours"];
                clsdbo_DimEmployee.SickLeaveHours = reader["SickLeaveHours"] is DBNull ? null : (Int16?)reader["SickLeaveHours"];
                clsdbo_DimEmployee.CurrentFlag = System.Convert.ToBoolean(reader["CurrentFlag"]);
                clsdbo_DimEmployee.SalesPersonFlag = System.Convert.ToBoolean(reader["SalesPersonFlag"]);
                clsdbo_DimEmployee.DepartmentName = reader["DepartmentName"] is DBNull ? null : reader["DepartmentName"].ToString();
                clsdbo_DimEmployee.StartDate = reader["StartDate"] is DBNull ? null : (DateTime?)reader["StartDate"];
                clsdbo_DimEmployee.EndDate = reader["EndDate"] is DBNull ? null : (DateTime?)reader["EndDate"];
                clsdbo_DimEmployee.Status = reader["Status"] is DBNull ? null : reader["Status"].ToString();
            }
            else
            {
                clsdbo_DimEmployee = null;
            }
            reader.Close();
        }
        catch (SqlException)
        {
            return clsdbo_DimEmployee;
        }
        finally
        {
            connection.Close();
        }
        return clsdbo_DimEmployee;
    }

    public static bool Add(dbo_DimEmployeeClass clsdbo_DimEmployee)
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string insertStatement
            = "INSERT " 
            + "     [dbo].[DimEmployee] "
            + "     ( "
            + "     [ParentEmployeeKey] "
            + "    ,[EmployeeNationalIDAlternateKey] "
            + "    ,[ParentEmployeeNationalIDAlternateKey] "
            + "    ,[SalesTerritoryKey] "
            + "    ,[FirstName] "
            + "    ,[LastName] "
            + "    ,[MiddleName] "
            + "    ,[NameStyle] "
            + "    ,[Title] "
            + "    ,[HireDate] "
            + "    ,[BirthDate] "
            + "    ,[LoginID] "
            + "    ,[EmailAddress] "
            + "    ,[Phone] "
            + "    ,[MaritalStatus] "
            + "    ,[EmergencyContactName] "
            + "    ,[EmergencyContactPhone] "
            + "    ,[SalariedFlag] "
            + "    ,[Gender] "
            + "    ,[PayFrequency] "
            + "    ,[BaseRate] "
            + "    ,[VacationHours] "
            + "    ,[SickLeaveHours] "
            + "    ,[CurrentFlag] "
            + "    ,[SalesPersonFlag] "
            + "    ,[DepartmentName] "
            + "    ,[StartDate] "
            + "    ,[EndDate] "
            + "    ,[Status] "
            + "     ) "
            + "VALUES " 
            + "     ( "
            + "     @ParentEmployeeKey "
            + "    ,@EmployeeNationalIDAlternateKey "
            + "    ,@ParentEmployeeNationalIDAlternateKey "
            + "    ,@SalesTerritoryKey "
            + "    ,@FirstName "
            + "    ,@LastName "
            + "    ,@MiddleName "
            + "    ,@NameStyle "
            + "    ,@Title "
            + "    ,@HireDate "
            + "    ,@BirthDate "
            + "    ,@LoginID "
            + "    ,@EmailAddress "
            + "    ,@Phone "
            + "    ,@MaritalStatus "
            + "    ,@EmergencyContactName "
            + "    ,@EmergencyContactPhone "
            + "    ,@SalariedFlag "
            + "    ,@Gender "
            + "    ,@PayFrequency "
            + "    ,@BaseRate "
            + "    ,@VacationHours "
            + "    ,@SickLeaveHours "
            + "    ,@CurrentFlag "
            + "    ,@SalesPersonFlag "
            + "    ,@DepartmentName "
            + "    ,@StartDate "
            + "    ,@EndDate "
            + "    ,@Status "
            + "     ) "
            + "";
        SqlCommand insertCommand = new SqlCommand(insertStatement, connection);
        insertCommand.CommandType = CommandType.Text;
        if (clsdbo_DimEmployee.ParentEmployeeKey.HasValue == true) {
            insertCommand.Parameters.AddWithValue("@ParentEmployeeKey", clsdbo_DimEmployee.ParentEmployeeKey);
        } else {
            insertCommand.Parameters.AddWithValue("@ParentEmployeeKey", DBNull.Value); }
        if (clsdbo_DimEmployee.EmployeeNationalIDAlternateKey != null) {
            insertCommand.Parameters.AddWithValue("@EmployeeNationalIDAlternateKey", clsdbo_DimEmployee.EmployeeNationalIDAlternateKey);
        } else {
            insertCommand.Parameters.AddWithValue("@EmployeeNationalIDAlternateKey", DBNull.Value); }
        if (clsdbo_DimEmployee.ParentEmployeeNationalIDAlternateKey != null) {
            insertCommand.Parameters.AddWithValue("@ParentEmployeeNationalIDAlternateKey", clsdbo_DimEmployee.ParentEmployeeNationalIDAlternateKey);
        } else {
            insertCommand.Parameters.AddWithValue("@ParentEmployeeNationalIDAlternateKey", DBNull.Value); }
        if (clsdbo_DimEmployee.SalesTerritoryKey.HasValue == true) {
            insertCommand.Parameters.AddWithValue("@SalesTerritoryKey", clsdbo_DimEmployee.SalesTerritoryKey);
        } else {
            insertCommand.Parameters.AddWithValue("@SalesTerritoryKey", DBNull.Value); }
        insertCommand.Parameters.AddWithValue("@FirstName", clsdbo_DimEmployee.FirstName);
        insertCommand.Parameters.AddWithValue("@LastName", clsdbo_DimEmployee.LastName);
        if (clsdbo_DimEmployee.MiddleName != null) {
            insertCommand.Parameters.AddWithValue("@MiddleName", clsdbo_DimEmployee.MiddleName);
        } else {
            insertCommand.Parameters.AddWithValue("@MiddleName", DBNull.Value); }
        insertCommand.Parameters.AddWithValue("@NameStyle", clsdbo_DimEmployee.NameStyle);
        if (clsdbo_DimEmployee.Title != null) {
            insertCommand.Parameters.AddWithValue("@Title", clsdbo_DimEmployee.Title);
        } else {
            insertCommand.Parameters.AddWithValue("@Title", DBNull.Value); }
        if (clsdbo_DimEmployee.HireDate.HasValue == true) {
            insertCommand.Parameters.AddWithValue("@HireDate", clsdbo_DimEmployee.HireDate);
        } else {
            insertCommand.Parameters.AddWithValue("@HireDate", DBNull.Value); }
        if (clsdbo_DimEmployee.BirthDate.HasValue == true) {
            insertCommand.Parameters.AddWithValue("@BirthDate", clsdbo_DimEmployee.BirthDate);
        } else {
            insertCommand.Parameters.AddWithValue("@BirthDate", DBNull.Value); }
        if (clsdbo_DimEmployee.LoginID != null) {
            insertCommand.Parameters.AddWithValue("@LoginID", clsdbo_DimEmployee.LoginID);
        } else {
            insertCommand.Parameters.AddWithValue("@LoginID", DBNull.Value); }
        if (clsdbo_DimEmployee.EmailAddress != null) {
            insertCommand.Parameters.AddWithValue("@EmailAddress", clsdbo_DimEmployee.EmailAddress);
        } else {
            insertCommand.Parameters.AddWithValue("@EmailAddress", DBNull.Value); }
        if (clsdbo_DimEmployee.Phone != null) {
            insertCommand.Parameters.AddWithValue("@Phone", clsdbo_DimEmployee.Phone);
        } else {
            insertCommand.Parameters.AddWithValue("@Phone", DBNull.Value); }
        if (clsdbo_DimEmployee.MaritalStatus != null) {
            insertCommand.Parameters.AddWithValue("@MaritalStatus", clsdbo_DimEmployee.MaritalStatus);
        } else {
            insertCommand.Parameters.AddWithValue("@MaritalStatus", DBNull.Value); }
        if (clsdbo_DimEmployee.EmergencyContactName != null) {
            insertCommand.Parameters.AddWithValue("@EmergencyContactName", clsdbo_DimEmployee.EmergencyContactName);
        } else {
            insertCommand.Parameters.AddWithValue("@EmergencyContactName", DBNull.Value); }
        if (clsdbo_DimEmployee.EmergencyContactPhone != null) {
            insertCommand.Parameters.AddWithValue("@EmergencyContactPhone", clsdbo_DimEmployee.EmergencyContactPhone);
        } else {
            insertCommand.Parameters.AddWithValue("@EmergencyContactPhone", DBNull.Value); }
        if (clsdbo_DimEmployee.SalariedFlag.HasValue == true) {
            insertCommand.Parameters.AddWithValue("@SalariedFlag", clsdbo_DimEmployee.SalariedFlag);
        } else {
            insertCommand.Parameters.AddWithValue("@SalariedFlag", DBNull.Value); }
        if (clsdbo_DimEmployee.Gender != null) {
            insertCommand.Parameters.AddWithValue("@Gender", clsdbo_DimEmployee.Gender);
        } else {
            insertCommand.Parameters.AddWithValue("@Gender", DBNull.Value); }
        if (clsdbo_DimEmployee.PayFrequency.HasValue == true) {
            insertCommand.Parameters.AddWithValue("@PayFrequency", clsdbo_DimEmployee.PayFrequency);
        } else {
            insertCommand.Parameters.AddWithValue("@PayFrequency", DBNull.Value); }
        if (clsdbo_DimEmployee.BaseRate.HasValue == true) {
            insertCommand.Parameters.AddWithValue("@BaseRate", clsdbo_DimEmployee.BaseRate);
        } else {
            insertCommand.Parameters.AddWithValue("@BaseRate", DBNull.Value); }
        if (clsdbo_DimEmployee.VacationHours.HasValue == true) {
            insertCommand.Parameters.AddWithValue("@VacationHours", clsdbo_DimEmployee.VacationHours);
        } else {
            insertCommand.Parameters.AddWithValue("@VacationHours", DBNull.Value); }
        if (clsdbo_DimEmployee.SickLeaveHours.HasValue == true) {
            insertCommand.Parameters.AddWithValue("@SickLeaveHours", clsdbo_DimEmployee.SickLeaveHours);
        } else {
            insertCommand.Parameters.AddWithValue("@SickLeaveHours", DBNull.Value); }
        insertCommand.Parameters.AddWithValue("@CurrentFlag", clsdbo_DimEmployee.CurrentFlag);
        insertCommand.Parameters.AddWithValue("@SalesPersonFlag", clsdbo_DimEmployee.SalesPersonFlag);
        if (clsdbo_DimEmployee.DepartmentName != null) {
            insertCommand.Parameters.AddWithValue("@DepartmentName", clsdbo_DimEmployee.DepartmentName);
        } else {
            insertCommand.Parameters.AddWithValue("@DepartmentName", DBNull.Value); }
        if (clsdbo_DimEmployee.StartDate.HasValue == true) {
            insertCommand.Parameters.AddWithValue("@StartDate", clsdbo_DimEmployee.StartDate);
        } else {
            insertCommand.Parameters.AddWithValue("@StartDate", DBNull.Value); }
        if (clsdbo_DimEmployee.EndDate.HasValue == true) {
            insertCommand.Parameters.AddWithValue("@EndDate", clsdbo_DimEmployee.EndDate);
        } else {
            insertCommand.Parameters.AddWithValue("@EndDate", DBNull.Value); }
        if (clsdbo_DimEmployee.Status != null) {
            insertCommand.Parameters.AddWithValue("@Status", clsdbo_DimEmployee.Status);
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

    public static bool Update(dbo_DimEmployeeClass olddbo_DimEmployeeClass, 
           dbo_DimEmployeeClass newdbo_DimEmployeeClass)
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string updateStatement
            = "UPDATE "  
            + "     [dbo].[DimEmployee] "
            + "SET "
            + "     [ParentEmployeeKey] = @NewParentEmployeeKey "
            + "    ,[EmployeeNationalIDAlternateKey] = @NewEmployeeNationalIDAlternateKey "
            + "    ,[ParentEmployeeNationalIDAlternateKey] = @NewParentEmployeeNationalIDAlternateKey "
            + "    ,[SalesTerritoryKey] = @NewSalesTerritoryKey "
            + "    ,[FirstName] = @NewFirstName "
            + "    ,[LastName] = @NewLastName "
            + "    ,[MiddleName] = @NewMiddleName "
            + "    ,[NameStyle] = @NewNameStyle "
            + "    ,[Title] = @NewTitle "
            + "    ,[HireDate] = @NewHireDate "
            + "    ,[BirthDate] = @NewBirthDate "
            + "    ,[LoginID] = @NewLoginID "
            + "    ,[EmailAddress] = @NewEmailAddress "
            + "    ,[Phone] = @NewPhone "
            + "    ,[MaritalStatus] = @NewMaritalStatus "
            + "    ,[EmergencyContactName] = @NewEmergencyContactName "
            + "    ,[EmergencyContactPhone] = @NewEmergencyContactPhone "
            + "    ,[SalariedFlag] = @NewSalariedFlag "
            + "    ,[Gender] = @NewGender "
            + "    ,[PayFrequency] = @NewPayFrequency "
            + "    ,[BaseRate] = @NewBaseRate "
            + "    ,[VacationHours] = @NewVacationHours "
            + "    ,[SickLeaveHours] = @NewSickLeaveHours "
            + "    ,[CurrentFlag] = @NewCurrentFlag "
            + "    ,[SalesPersonFlag] = @NewSalesPersonFlag "
            + "    ,[DepartmentName] = @NewDepartmentName "
            + "    ,[StartDate] = @NewStartDate "
            + "    ,[EndDate] = @NewEndDate "
            + "    ,[Status] = @NewStatus "
            + "WHERE "
            + "     [EmployeeKey] = @OldEmployeeKey " 
            + " AND ((@OldParentEmployeeKey IS NULL AND [ParentEmployeeKey] IS NULL) OR [ParentEmployeeKey] = @OldParentEmployeeKey) " 
            + " AND ((@OldEmployeeNationalIDAlternateKey IS NULL AND [EmployeeNationalIDAlternateKey] IS NULL) OR [EmployeeNationalIDAlternateKey] = @OldEmployeeNationalIDAlternateKey) " 
            + " AND ((@OldParentEmployeeNationalIDAlternateKey IS NULL AND [ParentEmployeeNationalIDAlternateKey] IS NULL) OR [ParentEmployeeNationalIDAlternateKey] = @OldParentEmployeeNationalIDAlternateKey) " 
            + " AND ((@OldSalesTerritoryKey IS NULL AND [SalesTerritoryKey] IS NULL) OR [SalesTerritoryKey] = @OldSalesTerritoryKey) " 
            + " AND [FirstName] = @OldFirstName " 
            + " AND [LastName] = @OldLastName " 
            + " AND ((@OldMiddleName IS NULL AND [MiddleName] IS NULL) OR [MiddleName] = @OldMiddleName) " 
            + " AND [NameStyle] = @OldNameStyle " 
            + " AND ((@OldTitle IS NULL AND [Title] IS NULL) OR [Title] = @OldTitle) " 
            + " AND ((@OldHireDate IS NULL AND [HireDate] IS NULL) OR [HireDate] = @OldHireDate) " 
            + " AND ((@OldBirthDate IS NULL AND [BirthDate] IS NULL) OR [BirthDate] = @OldBirthDate) " 
            + " AND ((@OldLoginID IS NULL AND [LoginID] IS NULL) OR [LoginID] = @OldLoginID) " 
            + " AND ((@OldEmailAddress IS NULL AND [EmailAddress] IS NULL) OR [EmailAddress] = @OldEmailAddress) " 
            + " AND ((@OldPhone IS NULL AND [Phone] IS NULL) OR [Phone] = @OldPhone) " 
            + " AND ((@OldMaritalStatus IS NULL AND [MaritalStatus] IS NULL) OR [MaritalStatus] = @OldMaritalStatus) " 
            + " AND ((@OldEmergencyContactName IS NULL AND [EmergencyContactName] IS NULL) OR [EmergencyContactName] = @OldEmergencyContactName) " 
            + " AND ((@OldEmergencyContactPhone IS NULL AND [EmergencyContactPhone] IS NULL) OR [EmergencyContactPhone] = @OldEmergencyContactPhone) " 
            + " AND ((@OldSalariedFlag IS NULL AND [SalariedFlag] IS NULL) OR [SalariedFlag] = @OldSalariedFlag) " 
            + " AND ((@OldGender IS NULL AND [Gender] IS NULL) OR [Gender] = @OldGender) " 
            + " AND ((@OldPayFrequency IS NULL AND [PayFrequency] IS NULL) OR [PayFrequency] = @OldPayFrequency) " 
            + " AND ((@OldBaseRate IS NULL AND [BaseRate] IS NULL) OR [BaseRate] = @OldBaseRate) " 
            + " AND ((@OldVacationHours IS NULL AND [VacationHours] IS NULL) OR [VacationHours] = @OldVacationHours) " 
            + " AND ((@OldSickLeaveHours IS NULL AND [SickLeaveHours] IS NULL) OR [SickLeaveHours] = @OldSickLeaveHours) " 
            + " AND [CurrentFlag] = @OldCurrentFlag " 
            + " AND [SalesPersonFlag] = @OldSalesPersonFlag " 
            + " AND ((@OldDepartmentName IS NULL AND [DepartmentName] IS NULL) OR [DepartmentName] = @OldDepartmentName) " 
            + " AND ((@OldStartDate IS NULL AND [StartDate] IS NULL) OR [StartDate] = @OldStartDate) " 
            + " AND ((@OldEndDate IS NULL AND [EndDate] IS NULL) OR [EndDate] = @OldEndDate) " 
            + " AND ((@OldStatus IS NULL AND [Status] IS NULL) OR [Status] = @OldStatus) " 
            + "";
        SqlCommand updateCommand = new SqlCommand(updateStatement, connection);
        updateCommand.CommandType = CommandType.Text;
        if (newdbo_DimEmployeeClass.ParentEmployeeKey.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@NewParentEmployeeKey", newdbo_DimEmployeeClass.ParentEmployeeKey);
        } else {
            updateCommand.Parameters.AddWithValue("@NewParentEmployeeKey", DBNull.Value); }
        if (newdbo_DimEmployeeClass.EmployeeNationalIDAlternateKey != null) {
            updateCommand.Parameters.AddWithValue("@NewEmployeeNationalIDAlternateKey", newdbo_DimEmployeeClass.EmployeeNationalIDAlternateKey);
        } else {
            updateCommand.Parameters.AddWithValue("@NewEmployeeNationalIDAlternateKey", DBNull.Value); }
        if (newdbo_DimEmployeeClass.ParentEmployeeNationalIDAlternateKey != null) {
            updateCommand.Parameters.AddWithValue("@NewParentEmployeeNationalIDAlternateKey", newdbo_DimEmployeeClass.ParentEmployeeNationalIDAlternateKey);
        } else {
            updateCommand.Parameters.AddWithValue("@NewParentEmployeeNationalIDAlternateKey", DBNull.Value); }
        if (newdbo_DimEmployeeClass.SalesTerritoryKey.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@NewSalesTerritoryKey", newdbo_DimEmployeeClass.SalesTerritoryKey);
        } else {
            updateCommand.Parameters.AddWithValue("@NewSalesTerritoryKey", DBNull.Value); }
        updateCommand.Parameters.AddWithValue("@NewFirstName", newdbo_DimEmployeeClass.FirstName);
        updateCommand.Parameters.AddWithValue("@NewLastName", newdbo_DimEmployeeClass.LastName);
        if (newdbo_DimEmployeeClass.MiddleName != null) {
            updateCommand.Parameters.AddWithValue("@NewMiddleName", newdbo_DimEmployeeClass.MiddleName);
        } else {
            updateCommand.Parameters.AddWithValue("@NewMiddleName", DBNull.Value); }
        updateCommand.Parameters.AddWithValue("@NewNameStyle", newdbo_DimEmployeeClass.NameStyle);
        if (newdbo_DimEmployeeClass.Title != null) {
            updateCommand.Parameters.AddWithValue("@NewTitle", newdbo_DimEmployeeClass.Title);
        } else {
            updateCommand.Parameters.AddWithValue("@NewTitle", DBNull.Value); }
        if (newdbo_DimEmployeeClass.HireDate.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@NewHireDate", newdbo_DimEmployeeClass.HireDate);
        } else {
            updateCommand.Parameters.AddWithValue("@NewHireDate", DBNull.Value); }
        if (newdbo_DimEmployeeClass.BirthDate.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@NewBirthDate", newdbo_DimEmployeeClass.BirthDate);
        } else {
            updateCommand.Parameters.AddWithValue("@NewBirthDate", DBNull.Value); }
        if (newdbo_DimEmployeeClass.LoginID != null) {
            updateCommand.Parameters.AddWithValue("@NewLoginID", newdbo_DimEmployeeClass.LoginID);
        } else {
            updateCommand.Parameters.AddWithValue("@NewLoginID", DBNull.Value); }
        if (newdbo_DimEmployeeClass.EmailAddress != null) {
            updateCommand.Parameters.AddWithValue("@NewEmailAddress", newdbo_DimEmployeeClass.EmailAddress);
        } else {
            updateCommand.Parameters.AddWithValue("@NewEmailAddress", DBNull.Value); }
        if (newdbo_DimEmployeeClass.Phone != null) {
            updateCommand.Parameters.AddWithValue("@NewPhone", newdbo_DimEmployeeClass.Phone);
        } else {
            updateCommand.Parameters.AddWithValue("@NewPhone", DBNull.Value); }
        if (newdbo_DimEmployeeClass.MaritalStatus != null) {
            updateCommand.Parameters.AddWithValue("@NewMaritalStatus", newdbo_DimEmployeeClass.MaritalStatus);
        } else {
            updateCommand.Parameters.AddWithValue("@NewMaritalStatus", DBNull.Value); }
        if (newdbo_DimEmployeeClass.EmergencyContactName != null) {
            updateCommand.Parameters.AddWithValue("@NewEmergencyContactName", newdbo_DimEmployeeClass.EmergencyContactName);
        } else {
            updateCommand.Parameters.AddWithValue("@NewEmergencyContactName", DBNull.Value); }
        if (newdbo_DimEmployeeClass.EmergencyContactPhone != null) {
            updateCommand.Parameters.AddWithValue("@NewEmergencyContactPhone", newdbo_DimEmployeeClass.EmergencyContactPhone);
        } else {
            updateCommand.Parameters.AddWithValue("@NewEmergencyContactPhone", DBNull.Value); }
        if (newdbo_DimEmployeeClass.SalariedFlag.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@NewSalariedFlag", newdbo_DimEmployeeClass.SalariedFlag);
        } else {
            updateCommand.Parameters.AddWithValue("@NewSalariedFlag", DBNull.Value); }
        if (newdbo_DimEmployeeClass.Gender != null) {
            updateCommand.Parameters.AddWithValue("@NewGender", newdbo_DimEmployeeClass.Gender);
        } else {
            updateCommand.Parameters.AddWithValue("@NewGender", DBNull.Value); }
        if (newdbo_DimEmployeeClass.PayFrequency.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@NewPayFrequency", newdbo_DimEmployeeClass.PayFrequency);
        } else {
            updateCommand.Parameters.AddWithValue("@NewPayFrequency", DBNull.Value); }
        if (newdbo_DimEmployeeClass.BaseRate.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@NewBaseRate", newdbo_DimEmployeeClass.BaseRate);
        } else {
            updateCommand.Parameters.AddWithValue("@NewBaseRate", DBNull.Value); }
        if (newdbo_DimEmployeeClass.VacationHours.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@NewVacationHours", newdbo_DimEmployeeClass.VacationHours);
        } else {
            updateCommand.Parameters.AddWithValue("@NewVacationHours", DBNull.Value); }
        if (newdbo_DimEmployeeClass.SickLeaveHours.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@NewSickLeaveHours", newdbo_DimEmployeeClass.SickLeaveHours);
        } else {
            updateCommand.Parameters.AddWithValue("@NewSickLeaveHours", DBNull.Value); }
        updateCommand.Parameters.AddWithValue("@NewCurrentFlag", newdbo_DimEmployeeClass.CurrentFlag);
        updateCommand.Parameters.AddWithValue("@NewSalesPersonFlag", newdbo_DimEmployeeClass.SalesPersonFlag);
        if (newdbo_DimEmployeeClass.DepartmentName != null) {
            updateCommand.Parameters.AddWithValue("@NewDepartmentName", newdbo_DimEmployeeClass.DepartmentName);
        } else {
            updateCommand.Parameters.AddWithValue("@NewDepartmentName", DBNull.Value); }
        if (newdbo_DimEmployeeClass.StartDate.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@NewStartDate", newdbo_DimEmployeeClass.StartDate);
        } else {
            updateCommand.Parameters.AddWithValue("@NewStartDate", DBNull.Value); }
        if (newdbo_DimEmployeeClass.EndDate.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@NewEndDate", newdbo_DimEmployeeClass.EndDate);
        } else {
            updateCommand.Parameters.AddWithValue("@NewEndDate", DBNull.Value); }
        if (newdbo_DimEmployeeClass.Status != null) {
            updateCommand.Parameters.AddWithValue("@NewStatus", newdbo_DimEmployeeClass.Status);
        } else {
            updateCommand.Parameters.AddWithValue("@NewStatus", DBNull.Value); }
        updateCommand.Parameters.AddWithValue("@OldEmployeeKey", olddbo_DimEmployeeClass.EmployeeKey);
        if (olddbo_DimEmployeeClass.ParentEmployeeKey.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@OldParentEmployeeKey", olddbo_DimEmployeeClass.ParentEmployeeKey);
        } else {
            updateCommand.Parameters.AddWithValue("@OldParentEmployeeKey", DBNull.Value); }
        if (olddbo_DimEmployeeClass.EmployeeNationalIDAlternateKey != null) {
            updateCommand.Parameters.AddWithValue("@OldEmployeeNationalIDAlternateKey", olddbo_DimEmployeeClass.EmployeeNationalIDAlternateKey);
        } else {
            updateCommand.Parameters.AddWithValue("@OldEmployeeNationalIDAlternateKey", DBNull.Value); }
        if (olddbo_DimEmployeeClass.ParentEmployeeNationalIDAlternateKey != null) {
            updateCommand.Parameters.AddWithValue("@OldParentEmployeeNationalIDAlternateKey", olddbo_DimEmployeeClass.ParentEmployeeNationalIDAlternateKey);
        } else {
            updateCommand.Parameters.AddWithValue("@OldParentEmployeeNationalIDAlternateKey", DBNull.Value); }
        if (olddbo_DimEmployeeClass.SalesTerritoryKey.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@OldSalesTerritoryKey", olddbo_DimEmployeeClass.SalesTerritoryKey);
        } else {
            updateCommand.Parameters.AddWithValue("@OldSalesTerritoryKey", DBNull.Value); }
        updateCommand.Parameters.AddWithValue("@OldFirstName", olddbo_DimEmployeeClass.FirstName);
        updateCommand.Parameters.AddWithValue("@OldLastName", olddbo_DimEmployeeClass.LastName);
        if (olddbo_DimEmployeeClass.MiddleName != null) {
            updateCommand.Parameters.AddWithValue("@OldMiddleName", olddbo_DimEmployeeClass.MiddleName);
        } else {
            updateCommand.Parameters.AddWithValue("@OldMiddleName", DBNull.Value); }
        updateCommand.Parameters.AddWithValue("@OldNameStyle", olddbo_DimEmployeeClass.NameStyle);
        if (olddbo_DimEmployeeClass.Title != null) {
            updateCommand.Parameters.AddWithValue("@OldTitle", olddbo_DimEmployeeClass.Title);
        } else {
            updateCommand.Parameters.AddWithValue("@OldTitle", DBNull.Value); }
        if (olddbo_DimEmployeeClass.HireDate.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@OldHireDate", olddbo_DimEmployeeClass.HireDate);
        } else {
            updateCommand.Parameters.AddWithValue("@OldHireDate", DBNull.Value); }
        if (olddbo_DimEmployeeClass.BirthDate.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@OldBirthDate", olddbo_DimEmployeeClass.BirthDate);
        } else {
            updateCommand.Parameters.AddWithValue("@OldBirthDate", DBNull.Value); }
        if (olddbo_DimEmployeeClass.LoginID != null) {
            updateCommand.Parameters.AddWithValue("@OldLoginID", olddbo_DimEmployeeClass.LoginID);
        } else {
            updateCommand.Parameters.AddWithValue("@OldLoginID", DBNull.Value); }
        if (olddbo_DimEmployeeClass.EmailAddress != null) {
            updateCommand.Parameters.AddWithValue("@OldEmailAddress", olddbo_DimEmployeeClass.EmailAddress);
        } else {
            updateCommand.Parameters.AddWithValue("@OldEmailAddress", DBNull.Value); }
        if (olddbo_DimEmployeeClass.Phone != null) {
            updateCommand.Parameters.AddWithValue("@OldPhone", olddbo_DimEmployeeClass.Phone);
        } else {
            updateCommand.Parameters.AddWithValue("@OldPhone", DBNull.Value); }
        if (olddbo_DimEmployeeClass.MaritalStatus != null) {
            updateCommand.Parameters.AddWithValue("@OldMaritalStatus", olddbo_DimEmployeeClass.MaritalStatus);
        } else {
            updateCommand.Parameters.AddWithValue("@OldMaritalStatus", DBNull.Value); }
        if (olddbo_DimEmployeeClass.EmergencyContactName != null) {
            updateCommand.Parameters.AddWithValue("@OldEmergencyContactName", olddbo_DimEmployeeClass.EmergencyContactName);
        } else {
            updateCommand.Parameters.AddWithValue("@OldEmergencyContactName", DBNull.Value); }
        if (olddbo_DimEmployeeClass.EmergencyContactPhone != null) {
            updateCommand.Parameters.AddWithValue("@OldEmergencyContactPhone", olddbo_DimEmployeeClass.EmergencyContactPhone);
        } else {
            updateCommand.Parameters.AddWithValue("@OldEmergencyContactPhone", DBNull.Value); }
        if (olddbo_DimEmployeeClass.SalariedFlag.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@OldSalariedFlag", olddbo_DimEmployeeClass.SalariedFlag);
        } else {
            updateCommand.Parameters.AddWithValue("@OldSalariedFlag", DBNull.Value); }
        if (olddbo_DimEmployeeClass.Gender != null) {
            updateCommand.Parameters.AddWithValue("@OldGender", olddbo_DimEmployeeClass.Gender);
        } else {
            updateCommand.Parameters.AddWithValue("@OldGender", DBNull.Value); }
        if (olddbo_DimEmployeeClass.PayFrequency.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@OldPayFrequency", olddbo_DimEmployeeClass.PayFrequency);
        } else {
            updateCommand.Parameters.AddWithValue("@OldPayFrequency", DBNull.Value); }
        if (olddbo_DimEmployeeClass.BaseRate.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@OldBaseRate", olddbo_DimEmployeeClass.BaseRate);
        } else {
            updateCommand.Parameters.AddWithValue("@OldBaseRate", DBNull.Value); }
        if (olddbo_DimEmployeeClass.VacationHours.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@OldVacationHours", olddbo_DimEmployeeClass.VacationHours);
        } else {
            updateCommand.Parameters.AddWithValue("@OldVacationHours", DBNull.Value); }
        if (olddbo_DimEmployeeClass.SickLeaveHours.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@OldSickLeaveHours", olddbo_DimEmployeeClass.SickLeaveHours);
        } else {
            updateCommand.Parameters.AddWithValue("@OldSickLeaveHours", DBNull.Value); }
        updateCommand.Parameters.AddWithValue("@OldCurrentFlag", olddbo_DimEmployeeClass.CurrentFlag);
        updateCommand.Parameters.AddWithValue("@OldSalesPersonFlag", olddbo_DimEmployeeClass.SalesPersonFlag);
        if (olddbo_DimEmployeeClass.DepartmentName != null) {
            updateCommand.Parameters.AddWithValue("@OldDepartmentName", olddbo_DimEmployeeClass.DepartmentName);
        } else {
            updateCommand.Parameters.AddWithValue("@OldDepartmentName", DBNull.Value); }
        if (olddbo_DimEmployeeClass.StartDate.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@OldStartDate", olddbo_DimEmployeeClass.StartDate);
        } else {
            updateCommand.Parameters.AddWithValue("@OldStartDate", DBNull.Value); }
        if (olddbo_DimEmployeeClass.EndDate.HasValue == true) {
            updateCommand.Parameters.AddWithValue("@OldEndDate", olddbo_DimEmployeeClass.EndDate);
        } else {
            updateCommand.Parameters.AddWithValue("@OldEndDate", DBNull.Value); }
        if (olddbo_DimEmployeeClass.Status != null) {
            updateCommand.Parameters.AddWithValue("@OldStatus", olddbo_DimEmployeeClass.Status);
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

    public static bool Delete(dbo_DimEmployeeClass clsdbo_DimEmployee)
    {
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string deleteStatement
            = "DELETE FROM "  
            + "     [dbo].[DimEmployee] "
            + "WHERE " 
            + "     [EmployeeKey] = @OldEmployeeKey " 
            + " AND ((@OldParentEmployeeKey IS NULL AND [ParentEmployeeKey] IS NULL) OR [ParentEmployeeKey] = @OldParentEmployeeKey) " 
            + " AND ((@OldEmployeeNationalIDAlternateKey IS NULL AND [EmployeeNationalIDAlternateKey] IS NULL) OR [EmployeeNationalIDAlternateKey] = @OldEmployeeNationalIDAlternateKey) " 
            + " AND ((@OldParentEmployeeNationalIDAlternateKey IS NULL AND [ParentEmployeeNationalIDAlternateKey] IS NULL) OR [ParentEmployeeNationalIDAlternateKey] = @OldParentEmployeeNationalIDAlternateKey) " 
            + " AND ((@OldSalesTerritoryKey IS NULL AND [SalesTerritoryKey] IS NULL) OR [SalesTerritoryKey] = @OldSalesTerritoryKey) " 
            + " AND [FirstName] = @OldFirstName " 
            + " AND [LastName] = @OldLastName " 
            + " AND ((@OldMiddleName IS NULL AND [MiddleName] IS NULL) OR [MiddleName] = @OldMiddleName) " 
            + " AND [NameStyle] = @OldNameStyle " 
            + " AND ((@OldTitle IS NULL AND [Title] IS NULL) OR [Title] = @OldTitle) " 
            + " AND ((@OldHireDate IS NULL AND [HireDate] IS NULL) OR [HireDate] = @OldHireDate) " 
            + " AND ((@OldBirthDate IS NULL AND [BirthDate] IS NULL) OR [BirthDate] = @OldBirthDate) " 
            + " AND ((@OldLoginID IS NULL AND [LoginID] IS NULL) OR [LoginID] = @OldLoginID) " 
            + " AND ((@OldEmailAddress IS NULL AND [EmailAddress] IS NULL) OR [EmailAddress] = @OldEmailAddress) " 
            + " AND ((@OldPhone IS NULL AND [Phone] IS NULL) OR [Phone] = @OldPhone) " 
            + " AND ((@OldMaritalStatus IS NULL AND [MaritalStatus] IS NULL) OR [MaritalStatus] = @OldMaritalStatus) " 
            + " AND ((@OldEmergencyContactName IS NULL AND [EmergencyContactName] IS NULL) OR [EmergencyContactName] = @OldEmergencyContactName) " 
            + " AND ((@OldEmergencyContactPhone IS NULL AND [EmergencyContactPhone] IS NULL) OR [EmergencyContactPhone] = @OldEmergencyContactPhone) " 
            + " AND ((@OldSalariedFlag IS NULL AND [SalariedFlag] IS NULL) OR [SalariedFlag] = @OldSalariedFlag) " 
            + " AND ((@OldGender IS NULL AND [Gender] IS NULL) OR [Gender] = @OldGender) " 
            + " AND ((@OldPayFrequency IS NULL AND [PayFrequency] IS NULL) OR [PayFrequency] = @OldPayFrequency) " 
            + " AND ((@OldBaseRate IS NULL AND [BaseRate] IS NULL) OR [BaseRate] = @OldBaseRate) " 
            + " AND ((@OldVacationHours IS NULL AND [VacationHours] IS NULL) OR [VacationHours] = @OldVacationHours) " 
            + " AND ((@OldSickLeaveHours IS NULL AND [SickLeaveHours] IS NULL) OR [SickLeaveHours] = @OldSickLeaveHours) " 
            + " AND [CurrentFlag] = @OldCurrentFlag " 
            + " AND [SalesPersonFlag] = @OldSalesPersonFlag " 
            + " AND ((@OldDepartmentName IS NULL AND [DepartmentName] IS NULL) OR [DepartmentName] = @OldDepartmentName) " 
            + " AND ((@OldStartDate IS NULL AND [StartDate] IS NULL) OR [StartDate] = @OldStartDate) " 
            + " AND ((@OldEndDate IS NULL AND [EndDate] IS NULL) OR [EndDate] = @OldEndDate) " 
            + " AND ((@OldStatus IS NULL AND [Status] IS NULL) OR [Status] = @OldStatus) " 
            + "";
        SqlCommand deleteCommand = new SqlCommand(deleteStatement, connection);
        deleteCommand.CommandType = CommandType.Text;
        deleteCommand.Parameters.AddWithValue("@OldEmployeeKey", clsdbo_DimEmployee.EmployeeKey);
        if (clsdbo_DimEmployee.ParentEmployeeKey.HasValue == true) {
            deleteCommand.Parameters.AddWithValue("@OldParentEmployeeKey", clsdbo_DimEmployee.ParentEmployeeKey);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldParentEmployeeKey", DBNull.Value); }
        if (clsdbo_DimEmployee.EmployeeNationalIDAlternateKey != null) {
            deleteCommand.Parameters.AddWithValue("@OldEmployeeNationalIDAlternateKey", clsdbo_DimEmployee.EmployeeNationalIDAlternateKey);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldEmployeeNationalIDAlternateKey", DBNull.Value); }
        if (clsdbo_DimEmployee.ParentEmployeeNationalIDAlternateKey != null) {
            deleteCommand.Parameters.AddWithValue("@OldParentEmployeeNationalIDAlternateKey", clsdbo_DimEmployee.ParentEmployeeNationalIDAlternateKey);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldParentEmployeeNationalIDAlternateKey", DBNull.Value); }
        if (clsdbo_DimEmployee.SalesTerritoryKey.HasValue == true) {
            deleteCommand.Parameters.AddWithValue("@OldSalesTerritoryKey", clsdbo_DimEmployee.SalesTerritoryKey);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldSalesTerritoryKey", DBNull.Value); }
        deleteCommand.Parameters.AddWithValue("@OldFirstName", clsdbo_DimEmployee.FirstName);
        deleteCommand.Parameters.AddWithValue("@OldLastName", clsdbo_DimEmployee.LastName);
        if (clsdbo_DimEmployee.MiddleName != null) {
            deleteCommand.Parameters.AddWithValue("@OldMiddleName", clsdbo_DimEmployee.MiddleName);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldMiddleName", DBNull.Value); }
        deleteCommand.Parameters.AddWithValue("@OldNameStyle", clsdbo_DimEmployee.NameStyle);
        if (clsdbo_DimEmployee.Title != null) {
            deleteCommand.Parameters.AddWithValue("@OldTitle", clsdbo_DimEmployee.Title);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldTitle", DBNull.Value); }
        if (clsdbo_DimEmployee.HireDate.HasValue == true) {
            deleteCommand.Parameters.AddWithValue("@OldHireDate", clsdbo_DimEmployee.HireDate);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldHireDate", DBNull.Value); }
        if (clsdbo_DimEmployee.BirthDate.HasValue == true) {
            deleteCommand.Parameters.AddWithValue("@OldBirthDate", clsdbo_DimEmployee.BirthDate);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldBirthDate", DBNull.Value); }
        if (clsdbo_DimEmployee.LoginID != null) {
            deleteCommand.Parameters.AddWithValue("@OldLoginID", clsdbo_DimEmployee.LoginID);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldLoginID", DBNull.Value); }
        if (clsdbo_DimEmployee.EmailAddress != null) {
            deleteCommand.Parameters.AddWithValue("@OldEmailAddress", clsdbo_DimEmployee.EmailAddress);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldEmailAddress", DBNull.Value); }
        if (clsdbo_DimEmployee.Phone != null) {
            deleteCommand.Parameters.AddWithValue("@OldPhone", clsdbo_DimEmployee.Phone);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldPhone", DBNull.Value); }
        if (clsdbo_DimEmployee.MaritalStatus != null) {
            deleteCommand.Parameters.AddWithValue("@OldMaritalStatus", clsdbo_DimEmployee.MaritalStatus);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldMaritalStatus", DBNull.Value); }
        if (clsdbo_DimEmployee.EmergencyContactName != null) {
            deleteCommand.Parameters.AddWithValue("@OldEmergencyContactName", clsdbo_DimEmployee.EmergencyContactName);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldEmergencyContactName", DBNull.Value); }
        if (clsdbo_DimEmployee.EmergencyContactPhone != null) {
            deleteCommand.Parameters.AddWithValue("@OldEmergencyContactPhone", clsdbo_DimEmployee.EmergencyContactPhone);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldEmergencyContactPhone", DBNull.Value); }
        if (clsdbo_DimEmployee.SalariedFlag.HasValue == true) {
            deleteCommand.Parameters.AddWithValue("@OldSalariedFlag", clsdbo_DimEmployee.SalariedFlag);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldSalariedFlag", DBNull.Value); }
        if (clsdbo_DimEmployee.Gender != null) {
            deleteCommand.Parameters.AddWithValue("@OldGender", clsdbo_DimEmployee.Gender);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldGender", DBNull.Value); }
        if (clsdbo_DimEmployee.PayFrequency.HasValue == true) {
            deleteCommand.Parameters.AddWithValue("@OldPayFrequency", clsdbo_DimEmployee.PayFrequency);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldPayFrequency", DBNull.Value); }
        if (clsdbo_DimEmployee.BaseRate.HasValue == true) {
            deleteCommand.Parameters.AddWithValue("@OldBaseRate", clsdbo_DimEmployee.BaseRate);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldBaseRate", DBNull.Value); }
        if (clsdbo_DimEmployee.VacationHours.HasValue == true) {
            deleteCommand.Parameters.AddWithValue("@OldVacationHours", clsdbo_DimEmployee.VacationHours);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldVacationHours", DBNull.Value); }
        if (clsdbo_DimEmployee.SickLeaveHours.HasValue == true) {
            deleteCommand.Parameters.AddWithValue("@OldSickLeaveHours", clsdbo_DimEmployee.SickLeaveHours);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldSickLeaveHours", DBNull.Value); }
        deleteCommand.Parameters.AddWithValue("@OldCurrentFlag", clsdbo_DimEmployee.CurrentFlag);
        deleteCommand.Parameters.AddWithValue("@OldSalesPersonFlag", clsdbo_DimEmployee.SalesPersonFlag);
        if (clsdbo_DimEmployee.DepartmentName != null) {
            deleteCommand.Parameters.AddWithValue("@OldDepartmentName", clsdbo_DimEmployee.DepartmentName);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldDepartmentName", DBNull.Value); }
        if (clsdbo_DimEmployee.StartDate.HasValue == true) {
            deleteCommand.Parameters.AddWithValue("@OldStartDate", clsdbo_DimEmployee.StartDate);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldStartDate", DBNull.Value); }
        if (clsdbo_DimEmployee.EndDate.HasValue == true) {
            deleteCommand.Parameters.AddWithValue("@OldEndDate", clsdbo_DimEmployee.EndDate);
        } else {
            deleteCommand.Parameters.AddWithValue("@OldEndDate", DBNull.Value); }
        if (clsdbo_DimEmployee.Status != null) {
            deleteCommand.Parameters.AddWithValue("@OldStatus", clsdbo_DimEmployee.Status);
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

 
