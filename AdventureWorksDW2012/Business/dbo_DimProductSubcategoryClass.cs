using System;
public class dbo_DimProductSubcategoryClass
{
    private Int32 m_ProductSubcategoryKey;
    private Nullable<Int32> m_ProductSubcategoryAlternateKey;
    private String m_EnglishProductSubcategoryName;
    private String m_SpanishProductSubcategoryName;
    private String m_FrenchProductSubcategoryName;
    private Nullable<Int32> m_ProductCategoryKey;

    public dbo_DimProductSubcategoryClass() { }

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
    public Nullable<Int32> ProductSubcategoryAlternateKey
    {
        get
        {
            return m_ProductSubcategoryAlternateKey;
        }
        set
        {
            m_ProductSubcategoryAlternateKey = value;
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
    public String SpanishProductSubcategoryName
    {
        get
        {
            return m_SpanishProductSubcategoryName;
        }
        set
        {
            m_SpanishProductSubcategoryName = value;
        }
    }
    public String FrenchProductSubcategoryName
    {
        get
        {
            return m_FrenchProductSubcategoryName;
        }
        set
        {
            m_FrenchProductSubcategoryName = value;
        }
    }
    public Nullable<Int32> ProductCategoryKey
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

}

 
