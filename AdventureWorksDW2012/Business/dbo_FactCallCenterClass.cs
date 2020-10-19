using System;
public class dbo_FactCallCenterClass
{
    private Int32 m_FactCallCenterID;
    private Int32 m_DateKey;
    private String m_WageType;
    private String m_Shift;
    private Int16 m_LevelOneOperators;
    private Int16 m_LevelTwoOperators;
    private Int16 m_TotalOperators;
    private Int32 m_Calls;
    private Int32 m_AutomaticResponses;
    private Int32 m_Orders;
    private Int16 m_IssuesRaised;
    private Int16 m_AverageTimePerIssue;
    private Decimal m_ServiceGrade;
    private Nullable<DateTime> m_Date;

    public dbo_FactCallCenterClass() { }

    public Int32 FactCallCenterID
    {
        get
        {
            return m_FactCallCenterID;
        }
        set
        {
            m_FactCallCenterID = value;
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
    public String WageType
    {
        get
        {
            return m_WageType;
        }
        set
        {
            m_WageType = value;
        }
    }
    public String Shift
    {
        get
        {
            return m_Shift;
        }
        set
        {
            m_Shift = value;
        }
    }
    public Int16 LevelOneOperators
    {
        get
        {
            return m_LevelOneOperators;
        }
        set
        {
            m_LevelOneOperators = value;
        }
    }
    public Int16 LevelTwoOperators
    {
        get
        {
            return m_LevelTwoOperators;
        }
        set
        {
            m_LevelTwoOperators = value;
        }
    }
    public Int16 TotalOperators
    {
        get
        {
            return m_TotalOperators;
        }
        set
        {
            m_TotalOperators = value;
        }
    }
    public Int32 Calls
    {
        get
        {
            return m_Calls;
        }
        set
        {
            m_Calls = value;
        }
    }
    public Int32 AutomaticResponses
    {
        get
        {
            return m_AutomaticResponses;
        }
        set
        {
            m_AutomaticResponses = value;
        }
    }
    public Int32 Orders
    {
        get
        {
            return m_Orders;
        }
        set
        {
            m_Orders = value;
        }
    }
    public Int16 IssuesRaised
    {
        get
        {
            return m_IssuesRaised;
        }
        set
        {
            m_IssuesRaised = value;
        }
    }
    public Int16 AverageTimePerIssue
    {
        get
        {
            return m_AverageTimePerIssue;
        }
        set
        {
            m_AverageTimePerIssue = value;
        }
    }
    public Decimal ServiceGrade
    {
        get
        {
            return m_ServiceGrade;
        }
        set
        {
            m_ServiceGrade = value;
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

 
