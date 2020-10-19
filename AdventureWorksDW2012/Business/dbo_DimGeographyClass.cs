using System;
public class dbo_DimGeographyClass
{
    private Int32 m_GeographyKey;
    private String m_City;
    private String m_StateProvinceCode;
    private String m_StateProvinceName;
    private String m_CountryRegionCode;
    private String m_EnglishCountryRegionName;
    private String m_SpanishCountryRegionName;
    private String m_FrenchCountryRegionName;
    private String m_PostalCode;
    private Nullable<Int32> m_SalesTerritoryKey;
    private String m_IpAddressLocator;

    public dbo_DimGeographyClass() { }

    public Int32 GeographyKey
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
    public String City
    {
        get
        {
            return m_City;
        }
        set
        {
            m_City = value;
        }
    }

    public String StateProvinceCode
    {
        get
        {
            return m_StateProvinceCode;
        }
        set
        {
            m_StateProvinceCode = value;
        }
    }

    public String StateProvinceName
    {
        get
        {
            return m_StateProvinceName;
        }
        set
        {
            m_StateProvinceName = value;
        }
    }

    public String CountryRegionCode
    {
        get
        {
            return m_CountryRegionCode;
        }
        set
        {
            m_CountryRegionCode = value;
        }
    }

    public String EnglishCountryRegionName
    {
        get
        {
            return m_EnglishCountryRegionName;
        }
        set
        {
            m_EnglishCountryRegionName = value;
        }
    }

    public String SpanishCountryRegionName
    {
        get
        {
            return m_SpanishCountryRegionName;
        }
        set
        {
            m_SpanishCountryRegionName = value;
        }
    }

    public String FrenchCountryRegionName
    {
        get
        {
            return m_FrenchCountryRegionName;
        }
        set
        {
            m_FrenchCountryRegionName = value;
        }
    }

    public String PostalCode
    {
        get
        {
            return m_PostalCode;
        }
        set
        {
            m_PostalCode = value;
        }
    }

    public Nullable<Int32> SalesTerritoryKey
    {
        get
        {
            return m_SalesTerritoryKey;
        }
        set
        {
            m_SalesTerritoryKey = value;
        }
    }

    public String IpAddressLocator
    {
        get
        {
            return m_IpAddressLocator;
        }
        set
        {
            m_IpAddressLocator = value;
        }
    }

}

 
