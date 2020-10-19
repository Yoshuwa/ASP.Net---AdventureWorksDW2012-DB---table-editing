using System;
public class dbo_DimPromotionClass
{
    private Int32 m_PromotionKey;
    private Nullable<Int32> m_PromotionAlternateKey;
    private String m_EnglishPromotionName;
    private String m_SpanishPromotionName;
    private String m_FrenchPromotionName;
    private Nullable<Decimal> m_DiscountPct;
    private String m_EnglishPromotionType;
    private String m_SpanishPromotionType;
    private String m_FrenchPromotionType;
    private String m_EnglishPromotionCategory;
    private String m_SpanishPromotionCategory;
    private String m_FrenchPromotionCategory;
    private DateTime m_StartDate;
    private Nullable<DateTime> m_EndDate;
    private Nullable<Int32> m_MinQty;
    private Nullable<Int32> m_MaxQty;

    public dbo_DimPromotionClass() { }

    public Int32 PromotionKey
    {
        get
        {
            return m_PromotionKey;
        }
        set
        {
            m_PromotionKey = value;
        }
    }
    public Nullable<Int32> PromotionAlternateKey
    {
        get
        {
            return m_PromotionAlternateKey;
        }
        set
        {
            m_PromotionAlternateKey = value;
        }
    }

    public String EnglishPromotionName
    {
        get
        {
            return m_EnglishPromotionName;
        }
        set
        {
            m_EnglishPromotionName = value;
        }
    }

    public String SpanishPromotionName
    {
        get
        {
            return m_SpanishPromotionName;
        }
        set
        {
            m_SpanishPromotionName = value;
        }
    }

    public String FrenchPromotionName
    {
        get
        {
            return m_FrenchPromotionName;
        }
        set
        {
            m_FrenchPromotionName = value;
        }
    }

    public Nullable<Decimal> DiscountPct
    {
        get
        {
            return m_DiscountPct;
        }
        set
        {
            m_DiscountPct = value;
        }
    }

    public String EnglishPromotionType
    {
        get
        {
            return m_EnglishPromotionType;
        }
        set
        {
            m_EnglishPromotionType = value;
        }
    }

    public String SpanishPromotionType
    {
        get
        {
            return m_SpanishPromotionType;
        }
        set
        {
            m_SpanishPromotionType = value;
        }
    }

    public String FrenchPromotionType
    {
        get
        {
            return m_FrenchPromotionType;
        }
        set
        {
            m_FrenchPromotionType = value;
        }
    }

    public String EnglishPromotionCategory
    {
        get
        {
            return m_EnglishPromotionCategory;
        }
        set
        {
            m_EnglishPromotionCategory = value;
        }
    }

    public String SpanishPromotionCategory
    {
        get
        {
            return m_SpanishPromotionCategory;
        }
        set
        {
            m_SpanishPromotionCategory = value;
        }
    }

    public String FrenchPromotionCategory
    {
        get
        {
            return m_FrenchPromotionCategory;
        }
        set
        {
            m_FrenchPromotionCategory = value;
        }
    }

    public DateTime StartDate
    {
        get
        {
            return m_StartDate;
        }
        set
        {
            m_StartDate = value;
        }
    }
    public Nullable<DateTime> EndDate
    {
        get
        {
            return m_EndDate;
        }
        set
        {
            m_EndDate = value;
        }
    }

    public Nullable<Int32> MinQty
    {
        get
        {
            return m_MinQty;
        }
        set
        {
            m_MinQty = value;
        }
    }

    public Nullable<Int32> MaxQty
    {
        get
        {
            return m_MaxQty;
        }
        set
        {
            m_MaxQty = value;
        }
    }

}

 
