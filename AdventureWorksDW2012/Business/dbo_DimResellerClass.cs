using System;
public class dbo_DimResellerClass
{
    private Int32 m_ResellerKey;
    private Nullable<Int32> m_GeographyKey;
    private String m_ResellerAlternateKey;
    private String m_Phone;
    private String m_BusinessType;
    private String m_ResellerName;
    private Nullable<Int32> m_NumberEmployees;
    private String m_OrderFrequency;
    private Nullable<Byte> m_OrderMonth;
    private Nullable<Int32> m_FirstOrderYear;
    private Nullable<Int32> m_LastOrderYear;
    private String m_ProductLine;
    private String m_AddressLine1;
    private String m_AddressLine2;
    private Nullable<Decimal> m_AnnualSales;
    private String m_BankName;
    private Nullable<Byte> m_MinPaymentType;
    private Nullable<Decimal> m_MinPaymentAmount;
    private Nullable<Decimal> m_AnnualRevenue;
    private Nullable<Int32> m_YearOpened;

    public dbo_DimResellerClass() { }

    public Int32 ResellerKey
    {
        get
        {
            return m_ResellerKey;
        }
        set
        {
            m_ResellerKey = value;
        }
    }
    public Nullable<Int32> GeographyKey
    {
        get
        {
            return m_GeographyKey;
        }
        set
        {
            m_GeographyKey = value;
        }
    }

    public String ResellerAlternateKey
    {
        get
        {
            return m_ResellerAlternateKey;
        }
        set
        {
            m_ResellerAlternateKey = value;
        }
    }

    public String Phone
    {
        get
        {
            return m_Phone;
        }
        set
        {
            m_Phone = value;
        }
    }

    public String BusinessType
    {
        get
        {
            return m_BusinessType;
        }
        set
        {
            m_BusinessType = value;
        }
    }
    public String ResellerName
    {
        get
        {
            return m_ResellerName;
        }
        set
        {
            m_ResellerName = value;
        }
    }
    public Nullable<Int32> NumberEmployees
    {
        get
        {
            return m_NumberEmployees;
        }
        set
        {
            m_NumberEmployees = value;
        }
    }

    public String OrderFrequency
    {
        get
        {
            return m_OrderFrequency;
        }
        set
        {
            m_OrderFrequency = value;
        }
    }

    public Nullable<Byte> OrderMonth
    {
        get
        {
            return m_OrderMonth;
        }
        set
        {
            m_OrderMonth = value;
        }
    }

    public Nullable<Int32> FirstOrderYear
    {
        get
        {
            return m_FirstOrderYear;
        }
        set
        {
            m_FirstOrderYear = value;
        }
    }

    public Nullable<Int32> LastOrderYear
    {
        get
        {
            return m_LastOrderYear;
        }
        set
        {
            m_LastOrderYear = value;
        }
    }

    public String ProductLine
    {
        get
        {
            return m_ProductLine;
        }
        set
        {
            m_ProductLine = value;
        }
    }

    public String AddressLine1
    {
        get
        {
            return m_AddressLine1;
        }
        set
        {
            m_AddressLine1 = value;
        }
    }

    public String AddressLine2
    {
        get
        {
            return m_AddressLine2;
        }
        set
        {
            m_AddressLine2 = value;
        }
    }

    public Nullable<Decimal> AnnualSales
    {
        get
        {
            return m_AnnualSales;
        }
        set
        {
            m_AnnualSales = value;
        }
    }

    public String BankName
    {
        get
        {
            return m_BankName;
        }
        set
        {
            m_BankName = value;
        }
    }

    public Nullable<Byte> MinPaymentType
    {
        get
        {
            return m_MinPaymentType;
        }
        set
        {
            m_MinPaymentType = value;
        }
    }

    public Nullable<Decimal> MinPaymentAmount
    {
        get
        {
            return m_MinPaymentAmount;
        }
        set
        {
            m_MinPaymentAmount = value;
        }
    }

    public Nullable<Decimal> AnnualRevenue
    {
        get
        {
            return m_AnnualRevenue;
        }
        set
        {
            m_AnnualRevenue = value;
        }
    }

    public Nullable<Int32> YearOpened
    {
        get
        {
            return m_YearOpened;
        }
        set
        {
            m_YearOpened = value;
        }
    }

}

 
