using System;
public class dbo_FactCurrencyRateClass
{
    private Int32 m_CurrencyKey;
    private Int32 m_DateKey;
    private Decimal m_AverageRate;
    private Decimal m_EndOfDayRate;
    private Nullable<DateTime> m_Date;

    public dbo_FactCurrencyRateClass() { }

    public Int32 CurrencyKey
    {
        get
        {
            return m_CurrencyKey;
        }
        set
        {
            m_CurrencyKey = value;
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
    public Decimal AverageRate
    {
        get
        {
            return m_AverageRate;
        }
        set
        {
            m_AverageRate = value;
        }
    }
    public Decimal EndOfDayRate
    {
        get
        {
            return m_EndOfDayRate;
        }
        set
        {
            m_EndOfDayRate = value;
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

 
