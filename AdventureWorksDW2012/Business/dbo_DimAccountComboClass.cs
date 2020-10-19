using System;
public class dbo_DimAccount_dbo_DimAccountClass4
{    
    private Int32 m_AccountKey; 
    
    private String m_ParentAccountKey ;

    public dbo_DimAccount_dbo_DimAccountClass4() { }

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

    public String ParentAccountKey
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

}


 
