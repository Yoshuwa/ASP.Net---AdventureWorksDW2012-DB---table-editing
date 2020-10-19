using System;
public class dbo_FactSalesQuotaClass
{
    private Int32 m_SalesQuotaKey;
    private Int32 m_EmployeeKey;
    private Int32 m_DateKey;
    private Int16 m_CalendarYear;
    private Byte m_CalendarQuarter;
    private Decimal m_SalesAmountQuota;
    private Nullable<DateTime> m_Date;

    public dbo_FactSalesQuotaClass() { }

    public Int32 SalesQuotaKey
    {
        get
        {
            return m_SalesQuotaKey;
        }
        set
        {
            m_SalesQuotaKey = value;
        }
    }
    public Int32 EmployeeKey
    {
        get
        {
            return m_EmployeeKey;
        }
        set
        {
            m_EmployeeKey = value;
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
    public Int16 CalendarYear
    {
        get
        {
            return m_CalendarYear;
        }
        set
        {
            m_CalendarYear = value;
        }
    }
    public Byte CalendarQuarter
    {
        get
        {
            return m_CalendarQuarter;
        }
        set
        {
            m_CalendarQuarter = value;
        }
    }
    public Decimal SalesAmountQuota
    {
        get
        {
            return m_SalesAmountQuota;
        }
        set
        {
            m_SalesAmountQuota = value;
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

 
