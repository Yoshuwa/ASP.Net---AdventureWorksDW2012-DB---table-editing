using System;
public class dbo_DimAccountClass
{
    private Int32 m_AccountKey;
    private Nullable<Int32> m_ParentAccountKey;
    private Nullable<Int32> m_AccountCodeAlternateKey;
    private Nullable<Int32> m_ParentAccountCodeAlternateKey;
    private String m_AccountDescription;
    private String m_AccountType;
    private String m_Operator;
    private String m_CustomMembers;
    private String m_ValueType;
    private String m_CustomMemberOptions;

    public dbo_DimAccountClass() { }

    public Int32 AccountKey
    {
        get
        {
            return m_AccountKey;
        }
        set
        {
            m_AccountKey = value;
        }
    }
    public Nullable<Int32> ParentAccountKey
    {
        get
        {
            return m_ParentAccountKey;
        }
        set
        {
            m_ParentAccountKey = value;
        }
    }

    public Nullable<Int32> AccountCodeAlternateKey
    {
        get
        {
            return m_AccountCodeAlternateKey;
        }
        set
        {
            m_AccountCodeAlternateKey = value;
        }
    }

    public Nullable<Int32> ParentAccountCodeAlternateKey
    {
        get
        {
            return m_ParentAccountCodeAlternateKey;
        }
        set
        {
            m_ParentAccountCodeAlternateKey = value;
        }
    }

    public String AccountDescription
    {
        get
        {
            return m_AccountDescription;
        }
        set
        {
            m_AccountDescription = value;
        }
    }

    public String AccountType
    {
        get
        {
            return m_AccountType;
        }
        set
        {
            m_AccountType = value;
        }
    }

    public String Operator
    {
        get
        {
            return m_Operator;
        }
        set
        {
            m_Operator = value;
        }
    }

    public String CustomMembers
    {
        get
        {
            return m_CustomMembers;
        }
        set
        {
            m_CustomMembers = value;
        }
    }

    public String ValueType
    {
        get
        {
            return m_ValueType;
        }
        set
        {
            m_ValueType = value;
        }
    }

    public String CustomMemberOptions
    {
        get
        {
            return m_CustomMemberOptions;
        }
        set
        {
            m_CustomMemberOptions = value;
        }
    }

}

 
