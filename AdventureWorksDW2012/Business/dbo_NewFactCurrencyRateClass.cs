using System;
public class dbo_NewFactCurrencyRateClass
{
    private Nullable<Decimal> m_AverageRate;
    private String m_CurrencyID;
    private Nullable<DateTime> m_CurrencyDate;
    private Nullable<Decimal> m_EndOfDayRate;
    private Nullable<Int32> m_CurrencyKey;
    private Nullable<Int32> m_DateKey;

    public dbo_NewFactCurrencyRateClass() { }

    public Nullable<Decimal> AverageRate
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

    public String CurrencyID
    {
        get
        {
            return m_CurrencyID;
        }
        set
        {
            m_CurrencyID = value;
        }
    }

    public Nullable<DateTime> CurrencyDate
    {
        get
        {
            return m_CurrencyDate;
        }
        set
        {
            m_CurrencyDate = value;
        }
    }

    public Nullable<Decimal> EndOfDayRate
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

    public Nullable<Int32> CurrencyKey
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

    public Nullable<Int32> DateKey
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

}

 
