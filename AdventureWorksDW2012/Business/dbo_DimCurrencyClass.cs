using System;
public class dbo_DimCurrencyClass
{
    private Int32 m_CurrencyKey;
    private String m_CurrencyAlternateKey;
    private String m_CurrencyName;

    public dbo_DimCurrencyClass() { }

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
    public String CurrencyAlternateKey
    {
        get
        {
            return m_CurrencyAlternateKey;
        }
        set
        {
            m_CurrencyAlternateKey = value;
        }
    }
    public String CurrencyName
    {
        get
        {
            return m_CurrencyName;
        }
        set
        {
            m_CurrencyName = value;
        }
    }
}

 
