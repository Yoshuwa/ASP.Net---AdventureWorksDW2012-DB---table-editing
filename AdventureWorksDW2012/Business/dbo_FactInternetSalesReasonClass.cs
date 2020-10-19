using System;
public class dbo_FactInternetSalesReasonClass
{
    private String m_SalesOrderNumber;
    private Byte m_SalesOrderLineNumber;
    private Int32 m_SalesReasonKey;

    public dbo_FactInternetSalesReasonClass() { }

    public String SalesOrderNumber
    {
        get
        {
            return m_SalesOrderNumber;
        }
        set
        {
            m_SalesOrderNumber = value;
        }
    }
    public Byte SalesOrderLineNumber
    {
        get
        {
            return m_SalesOrderLineNumber;
        }
        set
        {
            m_SalesOrderLineNumber = value;
        }
    }
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
}

 
