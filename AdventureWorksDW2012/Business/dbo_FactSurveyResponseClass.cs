using System;
public class dbo_FactSurveyResponseClass
{
    private Int32 m_SurveyResponseKey;
    private Int32 m_DateKey;
    private Int32 m_CustomerKey;
    private Int32 m_ProductCategoryKey;
    private String m_EnglishProductCategoryName;
    private Int32 m_ProductSubcategoryKey;
    private String m_EnglishProductSubcategoryName;
    private Nullable<DateTime> m_Date;

    public dbo_FactSurveyResponseClass() { }

    public Int32 SurveyResponseKey
    {
        get
        {
            return m_SurveyResponseKey;
        }
        set
        {
            m_SurveyResponseKey = value;
        }
    }
    public Int32 DateKey
    {
        get
        {
            return m_DateKey;
        }
        set
        {
            m_DateKey = value;
        }
    }
    public Int32 CustomerKey
    {
        get
        {
            return m_CustomerKey;
        }
        set
        {
            m_CustomerKey = value;
        }
    }
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
    public Nullable<DateTime> Date
    {
        get
        {
            return m_Date;
        }
        set
        {
            m_Date = value;
        }
    }

}

 
