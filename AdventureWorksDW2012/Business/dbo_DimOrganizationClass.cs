using System;
public class dbo_DimOrganizationClass
{
    private Int32 m_OrganizationKey;
    private Nullable<Int32> m_ParentOrganizationKey;
    private String m_PercentageOfOwnership;
    private String m_OrganizationName;
    private Nullable<Int32> m_CurrencyKey;

    public dbo_DimOrganizationClass() { }

    public Int32 OrganizationKey
    {
        get
        {
            return m_OrganizationKey;
        }
        set
        {
            m_OrganizationKey = value;
        }
    }
    public Nullable<Int32> ParentOrganizationKey
    {
        get
        {
            return m_ParentOrganizationKey;
        }
        set
        {
            m_ParentOrganizationKey = value;
        }
    }

    public String PercentageOfOwnership
    {
        get
        {
            return m_PercentageOfOwnership;
        }
        set
        {
            m_PercentageOfOwnership = value;
        }
    }

    public String OrganizationName
    {
        get
        {
            return m_OrganizationName;
        }
        set
        {
            m_OrganizationName = value;
        }
    }

    public Nullable<Int32> CurrencyKey
    {
        get
        {
            return m_CurrencyKey;
        }
        set
        {
            m_CurrencyKey = value;
        }
    }

}

 
