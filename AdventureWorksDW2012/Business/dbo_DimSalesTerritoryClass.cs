using System;
public class dbo_DimSalesTerritoryClass
{
    private Int32 m_SalesTerritoryKey;
    private Nullable<Int32> m_SalesTerritoryAlternateKey;
    private String m_SalesTerritoryRegion;
    private String m_SalesTerritoryCountry;
    private String m_SalesTerritoryGroup;

    public dbo_DimSalesTerritoryClass() { }

    public Int32 SalesTerritoryKey
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
    public Nullable<Int32> SalesTerritoryAlternateKey
    {
        get
        {
            return m_SalesTerritoryAlternateKey;
        }
        set
        {
            m_SalesTerritoryAlternateKey = value;
        }
    }

    public String SalesTerritoryRegion
    {
        get
        {
            return m_SalesTerritoryRegion;
        }
        set
        {
            m_SalesTerritoryRegion = value;
        }
    }
    public String SalesTerritoryCountry
    {
        get
        {
            return m_SalesTerritoryCountry;
        }
        set
        {
            m_SalesTerritoryCountry = value;
        }
    }
    public String SalesTerritoryGroup
    {
        get
        {
            return m_SalesTerritoryGroup;
        }
        set
        {
            m_SalesTerritoryGroup = value;
        }
    }

}

 
