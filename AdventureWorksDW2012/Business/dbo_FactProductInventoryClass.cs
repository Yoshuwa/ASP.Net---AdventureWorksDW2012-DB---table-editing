using System;
public class dbo_FactProductInventoryClass
{
    private Int32 m_ProductKey;
    private Int32 m_DateKey;
    private DateTime m_MovementDate;
    private Decimal m_UnitCost;
    private Int32 m_UnitsIn;
    private Int32 m_UnitsOut;
    private Int32 m_UnitsBalance;

    public dbo_FactProductInventoryClass() { }

    public Int32 ProductKey
    {
        get
        {
            return m_ProductKey;
        }
        set
        {
            m_ProductKey = value;
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
    public DateTime MovementDate
    {
        get
        {
            return m_MovementDate;
        }
        set
        {
            m_MovementDate = value;
        }
    }
    public Decimal UnitCost
    {
        get
        {
            return m_UnitCost;
        }
        set
        {
            m_UnitCost = value;
        }
    }
    public Int32 UnitsIn
    {
        get
        {
            return m_UnitsIn;
        }
        set
        {
            m_UnitsIn = value;
        }
    }
    public Int32 UnitsOut
    {
        get
        {
            return m_UnitsOut;
        }
        set
        {
            m_UnitsOut = value;
        }
    }
    public Int32 UnitsBalance
    {
        get
        {
            return m_UnitsBalance;
        }
        set
        {
            m_UnitsBalance = value;
        }
    }
}

 
