using System;
public class dbo_DimGeography_dbo_DimSalesTerritoryClass
{    
    private Int32 m_SalesTerritoryKey; 
    
    private String m_SalesTerritoryAlternateKey ;

    public dbo_DimGeography_dbo_DimSalesTerritoryClass() { }

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

    public String SalesTerritoryAlternateKey
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

}


 
