using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class dbo_DimDepartmentGroup_dbo_DimDepartmentGroupDataClass65
{
    public static List<dbo_DimDepartmentGroup_dbo_DimDepartmentGroupClass65> List()
    {
        List<dbo_DimDepartmentGroup_dbo_DimDepartmentGroupClass65> dbo_DimDepartmentGroup_dbo_DimDepartmentGroupList = new List<dbo_DimDepartmentGroup_dbo_DimDepartmentGroupClass65>();
        SqlConnection connection = AdventureWorksDW2012DataClass.GetConnection();
        string selectStatement 
            = "SELECT "  
            + "     [DepartmentGroupKey] " 
            + "    ,[DepartmentGroupName] " 
            + "FROM " 
            + "     [dbo].[DimDepartmentGroup] " 
            + "";
        SqlCommand selectCommand = new SqlCommand(selectStatement, connection);
        try
        {
            connection.Open();
            SqlDataReader reader = selectCommand.ExecuteReader();
            dbo_DimDepartmentGroup_dbo_DimDepartmentGroupClass65 clsdbo_DimDepartmentGroup_dbo_DimDepartmentGroup = new dbo_DimDepartmentGroup_dbo_DimDepartmentGroupClass65();
            while (reader.Read())
            {
                clsdbo_DimDepartmentGroup_dbo_DimDepartmentGroup = new dbo_DimDepartmentGroup_dbo_DimDepartmentGroupClass65();
                clsdbo_DimDepartmentGroup_dbo_DimDepartmentGroup.DepartmentGroupKey = System.Convert.ToInt32(reader["DepartmentGroupKey"]);
                clsdbo_DimDepartmentGroup_dbo_DimDepartmentGroup.DepartmentGroupName = Convert.ToString(reader["DepartmentGroupName"]);
                dbo_DimDepartmentGroup_dbo_DimDepartmentGroupList.Add(clsdbo_DimDepartmentGroup_dbo_DimDepartmentGroup);
            }
            reader.Close();
        }
        catch (SqlException)
        {
            return dbo_DimDepartmentGroup_dbo_DimDepartmentGroupList;
        }
        finally
        {
            connection.Close();
        }
        return dbo_DimDepartmentGroup_dbo_DimDepartmentGroupList;
    }

}


 
