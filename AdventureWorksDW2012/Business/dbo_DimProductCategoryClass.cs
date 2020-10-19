using System;
public class dbo_DimProductCategoryClass
{
    private Int32 m_ProductCategoryKey;
    private Nullable<Int32> m_ProductCategoryAlternateKey;
    private String m_EnglishProductCategoryName;
    private String m_SpanishProductCategoryName;
    private String m_FrenchProductCategoryName;

    public dbo_DimProductCategoryClass() { }

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
    public Nullable<Int32> ProductCategoryAlternateKey
    {
        get
        {
            return m_ProductCategoryAlternateKey;
        }
        set
        {
            m_ProductCategoryAlternateKey = value;
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
    public String SpanishProductCategoryName
    {
        get
        {
            return m_SpanishProductCategoryName;
        }
        set
        {
            m_SpanishProductCategoryName = value;
        }
    }
    public String FrenchProductCategoryName
    {
        get
        {
            return m_FrenchProductCategoryName;
        }
        set
        {
            m_FrenchProductCategoryName = value;
        }
    }
}

 
