using System;
public class dbo_DimProductSubcategory_dbo_DimProductCategoryClass
{    
    private Int32 m_ProductCategoryKey; 
    
    private String m_EnglishProductCategoryName ;

    public dbo_DimProductSubcategory_dbo_DimProductCategoryClass() { }

    public Int32 ProductCategoryKey
    {
        get
        {
            return m_ProductCategoryKey;
        }  
        set
        {
            m_ProductCategoryKey = value;
        }
    }

    public String EnglishProductCategoryName
    {
        get
        {
            return m_EnglishProductCategoryName;
        }  
        set
        {
            m_EnglishProductCategoryName = value; 
        }
    }

}


 
