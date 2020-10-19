using System;
public class dbo_DimDepartmentGroupClass
{
    private Int32 m_DepartmentGroupKey;
    private Nullable<Int32> m_ParentDepartmentGroupKey;
    private String m_DepartmentGroupName;

    public dbo_DimDepartmentGroupClass() { }

    public Int32 DepartmentGroupKey
    {
        get
        {
            return m_DepartmentGroupKey;
        }
        set
        {
            m_DepartmentGroupKey = value;
        }
    }
    public Nullable<Int32> ParentDepartmentGroupKey
    {
        get
        {
            return m_ParentDepartmentGroupKey;
        }
        set
        {
            m_ParentDepartmentGroupKey = value;
        }
    }

    public String DepartmentGroupName
    {
        get
        {
            return m_DepartmentGroupName;
        }
        set
        {
            m_DepartmentGroupName = value;
        }
    }

}

 
