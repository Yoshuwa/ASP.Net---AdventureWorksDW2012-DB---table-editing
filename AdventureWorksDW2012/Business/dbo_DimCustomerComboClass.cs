using System;
public class dbo_DimCustomer_dbo_DimGeographyClass
{    
    private Int32 m_GeographyKey; 
    
    private String m_StateProvinceName ;

    public dbo_DimCustomer_dbo_DimGeographyClass() { }

    public Int32 GeographyKey
    {
        get
        {
            return m_GeographyKey;
        }  
        set
        {
            m_GeographyKey = value;
        }
    }

    public String StateProvinceName
    {
        get
        {
            return m_StateProvinceName;
        }  
        set
        {
            m_StateProvinceName = value; 
        }
    }

}


 
