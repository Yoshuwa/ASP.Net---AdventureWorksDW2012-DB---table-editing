using System;
public class dbo_DimSalesReasonClass
{
    private Int32 m_SalesReasonKey;
    private Int32 m_SalesReasonAlternateKey;
    private String m_SalesReasonName;
    private String m_SalesReasonReasonType;

    public dbo_DimSalesReasonClass() { }

    public Int32 SalesReasonKey
    {
        get
        {
            return m_SalesReasonKey;
        }
        set
        {
            m_SalesReasonKey = value;
        }
    }
    public Int32 SalesReasonAlternateKey
    {
        get
        {
            return m_SalesReasonAlternateKey;
        }
        set
        {
            m_SalesReasonAlternateKey = value;
        }
    }
    public String SalesReasonName
    {
        get
        {
            return m_SalesReasonName;
        }
        set
        {
            m_SalesReasonName = value;
        }
    }
    public String SalesReasonReasonType
    {
        get
        {
            return m_SalesReasonReasonType;
        }
        set
        {
            m_SalesReasonReasonType = value;
        }
    }
}

 
