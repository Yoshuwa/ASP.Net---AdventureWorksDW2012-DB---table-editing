using System;
public class dbo_AdventureWorksDWBuildVersionClass
{
    private String m_DBVersion;
    private Nullable<DateTime> m_VersionDate;

    public dbo_AdventureWorksDWBuildVersionClass() { }

    public String DBVersion
    {
        get
        {
            return m_DBVersion;
        }
        set
        {
            m_DBVersion = value;
        }
    }

    public Nullable<DateTime> VersionDate
    {
        get
        {
            return m_VersionDate;
        }
        set
        {
            m_VersionDate = value;
        }
    }

}

 
