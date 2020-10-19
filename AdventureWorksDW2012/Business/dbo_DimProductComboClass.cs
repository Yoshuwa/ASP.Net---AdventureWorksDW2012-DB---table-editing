using System;
public class dbo_DimProduct_dbo_DimProductSubcategoryClass
{    
    private Int32 m_ProductSubcategoryKey; 
    
    private String m_EnglishProductSubcategoryName ;

    public dbo_DimProduct_dbo_DimProductSubcategoryClass() { }

    public Int32 ProductSubcategoryKey
    {
        get
        {
            return m_ProductSubcategoryKey;
        }  
        set
        {
            m_ProductSubcategoryKey = value;
        }
    }

    public String EnglishProductSubcategoryName
    {
        get
        {
            return m_EnglishProductSubcategoryName;
        }  
        set
        {
            m_EnglishProductSubcategoryName = value; 
        }
    }

}


 
