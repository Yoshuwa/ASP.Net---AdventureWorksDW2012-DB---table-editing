using System;
public class dbo_FactAdditionalInternationalProductDescriptionClass
{
    private Int32 m_ProductKey;
    private String m_CultureName;
    private String m_ProductDescription;

    public dbo_FactAdditionalInternationalProductDescriptionClass() { }

    public Int32 ProductKey
    {
        get
        {
            return m_ProductKey;
        }
        set
        {
            m_ProductKey = value;
        }
    }
    public String CultureName
    {
        get
        {
            return m_CultureName;
        }
        set
        {
            m_CultureName = value;
        }
    }
    public String ProductDescription
    {
        get
        {
            return m_ProductDescription;
        }
        set
        {
            m_ProductDescription = value;
        }
    }
}

 
