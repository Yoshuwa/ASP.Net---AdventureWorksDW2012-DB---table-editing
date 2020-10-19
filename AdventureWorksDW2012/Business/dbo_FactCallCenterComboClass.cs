using System;
public class dbo_FactCallCenter_dbo_DimDateClass
{    
    private Int32 m_DateKey; 
    
    private String m_FullDateAlternateKey ;

    public dbo_FactCallCenter_dbo_DimDateClass() { }

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

    public String FullDateAlternateKey
    {
        get
        {
            return m_FullDateAlternateKey;
        }  
        set
        {
            m_FullDateAlternateKey = value; 
        }
    }

}


 
