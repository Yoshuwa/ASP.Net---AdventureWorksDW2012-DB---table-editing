using System;
public class dbo_FactFinanceClass
{
    private Int32 m_FinanceKey;
    private Int32 m_DateKey;
    private Int32 m_OrganizationKey;
    private Int32 m_DepartmentGroupKey;
    private Int32 m_ScenarioKey;
    private Int32 m_AccountKey;
    private Decimal m_Amount;
    private Nullable<DateTime> m_Date;

    public dbo_FactFinanceClass() { }

    public Int32 FinanceKey
    {
        get
        {
            return m_FinanceKey;
        }
        set
        {
            m_FinanceKey = value;
        }
    }
    public Int32 DateKey
    {
        get
        {
            return m_DateKey;
        }
        set
        {
            m_DateKey = value;
        }
    }
    public Int32 OrganizationKey
    {
        get
        {
            return m_OrganizationKey;
        }
        set
        {
            m_OrganizationKey = value;
        }
    }
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
    public Int32 ScenarioKey
    {
        get
        {
            return m_ScenarioKey;
        }
        set
        {
            m_ScenarioKey = value;
        }
    }
    public Int32 AccountKey
    {
        get
        {
            return m_AccountKey;
        }
        set
        {
            m_AccountKey = value;
        }
    }
    public Decimal Amount
    {
        get
        {
            return m_Amount;
        }
        set
        {
            m_Amount = value;
        }
    }
    public Nullable<DateTime> Date
    {
        get
        {
            return m_Date;
        }
        set
        {
            m_Date = value;
        }
    }

}

 
